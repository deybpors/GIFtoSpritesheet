using System.Drawing.Imaging;

namespace GIFToSpriteSheet
{
    public partial class MainWindow : Form
    {
        OpenFileDialog openFileDialog;
        FolderBrowserDialog exportFolderDialog;
        List<string> selectedFileNames;
        public Dictionary<string, System.Drawing.Image> gifs;
        public string exportDirectory = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_Load(object sender, EventArgs e)
        {
            gifs = new();
            openFileDialog = new OpenFileDialog();
            exportFolderDialog = new FolderBrowserDialog();
            selectedFileNames = new List<string>();
            openFileDialog.RestoreDirectory = true;
            label_Columns.Text = "No. of Columns: " + scrollbar_Columns.Value.ToString();
            scrollbar_Columns.Enabled = false;
            scrollbar_Columns.Value = 1;
            txtbox_Import.Text = "";
            txtbox_Export.Text = "";
            pbox_SpriteSheet.Image = null;
            loadingBar.Value = 0;
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Browse GIF Files";
            openFileDialog.Filter = "GIF files (*.gif)|*.gif|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFileNames = new List<string>();
                foreach (String file in openFileDialog.FileNames)
                {
                    selectedFileNames.Add(file);
                    gifs.Add(file, System.Drawing.Image.FromFile(file));
                    DisplayImage();
                }

                txtbox_Import.Text = openFileDialog.FileName;

            }
            else
            {
                selectedFileNames.Clear();
                gifs = new();
                txtbox_Import.Text = "";
            }

            btn_Convert.Enabled = CanConvert();

            if (selectedFileNames.Count > 0)
            {
                scrollbar_Columns.Enabled = true;
            }
            else
            {
                scrollbar_Columns.Enabled = false;
                scrollbar_Columns.Value = 1;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (exportFolderDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(exportFolderDialog.SelectedPath);
                exportDirectory = exportFolderDialog.SelectedPath;
                txtbox_Export.Text = exportDirectory;
            }

            btn_Convert.Enabled = CanConvert();
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            ExportWorker.Run(this);
        }

        private void scrollbar_Columns_ValueChanged(object sender, EventArgs e)
        {
            label_Columns.Text = "No. of Columns: " + scrollbar_Columns.Value.ToString();
            if(gifs.Count > 0)
            {
                System.Drawing.Image gif = gifs[selectedFileNames.First()];
                pbox_SpriteSheet.Image = GifToSpritesheet(gif, scrollbar_Columns.Value);
            }
        }

        private bool CanConvert()
        {
            return selectedFileNames.Count > 0 && exportDirectory != "";
        }

        private void DisplayImage()
        {
            System.Drawing.Image gif = gifs[selectedFileNames.First()];
            pbox_SpriteSheet.Image = GifToSpritesheet(gif);
        }

        public Bitmap GifToSpritesheet(System.Drawing.Image gif, int columns = 1)
        {
            FrameDimension frameSize = new FrameDimension(gif.FrameDimensionsList[0]);
            System.Drawing.Size imageSize = new System.Drawing.Size(gif.Size.Width, gif.Size.Height);
            int frames = gif.GetFrameCount(frameSize);
            int rows = (int)Math.Ceiling((double)frames / columns);
            Bitmap bitmap = new Bitmap(columns * imageSize.Width, rows * imageSize.Height);
            Graphics g = Graphics.FromImage(bitmap);

            for (int i = 0; i < frames; i++)
            {
                gif.SelectActiveFrame(frameSize, i);
                g.DrawImage(gif, i % columns * imageSize.Width, i / columns * imageSize.Height);
            }
            g.Dispose();

            return bitmap;
        }

    }
}