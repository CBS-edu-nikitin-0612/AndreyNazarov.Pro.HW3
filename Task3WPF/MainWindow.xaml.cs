using System.IO;
using System.IO.Compression;
using System.Windows;


namespace Task3WPF
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

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            ListBoxResult.Items.Clear();
            SearchFile(TextBoxPath.Text);            
        }

        private void SearchFile(string path)
        {
            DirectoryInfo directoryInfo = new(path);
            foreach (var item in directoryInfo.GetFiles( TextBoxInputText.Text))
            {
                ListBoxResult.Items.Add(item);
            }
            foreach (var item in directoryInfo.GetDirectories())
            {
                SearchFile(item.FullName);
            }
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            StreamReader streamReader = new( ListBoxResult.SelectedItem.ToString());
            TextBoxView.Text = streamReader.ReadToEnd();
            streamReader.Close();
        }

        private void ButtonZip_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.GetFullPath(ListBoxResult.SelectedItem.ToString());
            FileStream fileInput = File.OpenRead(path);
            FileStream fileOutput = File.Create(Path.ChangeExtension(path, ".zip"));

            GZipStream gZipStream = new(fileOutput, CompressionMode.Compress);
            int inputByte = fileInput.ReadByte();
            while(inputByte != -1)
            {
                gZipStream.WriteByte((byte)inputByte);
                inputByte = fileInput.ReadByte();
            }
            gZipStream.Close();
        }
    }
}
