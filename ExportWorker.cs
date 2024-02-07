using GIFToSpriteSheet;
using System.ComponentModel;
using System.Drawing.Imaging;

public class ExportWorker
{

    private readonly BackgroundWorker _worker;
    private readonly MainWindow _window;

    public ExportWorker(MainWindow window)
    {
        _window = window;
        _worker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        _worker.DoWork += worker_DoWork;
        _worker.ProgressChanged += worker_ProgressChanged;
        _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        _worker.RunWorkerAsync();
    }
    public static void Run(MainWindow window)
    {
        new ExportWorker(window);
    }


    /// <summary>
    /// Do worker logic.
    /// Save all gifs as png spritesheets...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {

        _window.btn_Convert.BeginInvoke(new Action(() =>
        {
            _window.btn_Convert.Enabled = false;
            _window.btn_Import.Enabled = false;
            _window.btn_Export.Enabled = false;
            _window.scrollbar_Columns.Enabled = false;
        }));

        int total = _window.gifs.Count;
        int completed = 0;

        foreach (KeyValuePair<string, System.Drawing.Image> pair in _window.gifs)
        {
            Bitmap bitmap = _window.GifToSpritesheet(pair.Value, _window.scrollbar_Columns.Value);
            string file = Path.GetFileNameWithoutExtension(pair.Key) + ".png";
            _window.BeginInvoke(new Action(() =>
            {
                bitmap.Save(Path.Combine(_window.exportDirectory, file), ImageFormat.Png);
            }));


            int progress = (int)Math.Ceiling((double)100 / total * completed++);
            _worker.ReportProgress(progress);
        }
    }


    /// <summary>
    /// Show convert progress
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //_window.txt_import.Dispatcher.Invoke(new Action(() => { _window.lbl_run_progress.Content = $"{e.ProgressPercentage}%"; }));

        _window.loadingBar.BeginInvoke(new Action(() => { 
            _window.loadingBar.Value = e.ProgressPercentage;
        }));
    }

    /// <summary>
    /// Handle logic on background worker complete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void worker_RunWorkerCompleted(object sender,
                                           RunWorkerCompletedEventArgs e)
    {
        //_window.txtbox_Import.Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
        //{
        //    _window.btn_Convert.Enabled = true;
        //    _window.btn_Import.Enabled = true;
        //    _window.btn_Export.Enabled = true;
        //    //TODO: popup message that its finished
        //}));

        _window.BeginInvoke(new Action(() =>
        {
            string message = $"All {_window.gifs.Count} GIFs has been converted to PNG spritesheets!";
            MessageBox.Show(message);

            _window.btn_Convert.Enabled = true;
            _window.btn_Import.Enabled = true;
            _window.btn_Export.Enabled = true;
            _window.scrollbar_Columns.Enabled = true;
            _window.loadingBar.Value = 100;
            _window.MainWindow_Load(sender, e);
        }));
    }
}
