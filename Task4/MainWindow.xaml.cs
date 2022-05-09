using System.IO.IsolatedStorage;
using System.IO;
using System.Windows;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream stream = new IsolatedStorageFileStream("data1.txt", FileMode.Create, isolatedStorageFile);
            StreamWriter streamWriter = new StreamWriter(stream);

            streamWriter.Write (TextBoxInput.Text);
            streamWriter.Close();
            foreach (var item in isolatedStorageFile.GetFileNames())
            {
                TextBoxPath.Text += item;
            }
        }
    }
}
