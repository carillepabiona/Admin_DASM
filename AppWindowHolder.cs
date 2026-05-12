#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace Admin_DASM;

public class AppWindowHolder
{
    private static AppWindowHolder? _instance;

    public static AppWindowHolder Instance
        => _instance ??= new AppWindowHolder();

    public AppWindow? Window { get; private set; }

    public void Set(AppWindow window)
    {
        Window = window;
    }

    // =========================
    // RESTORE NORMAL APP WINDOW
    // =========================
    public void RestoreFullWindow()
    {
        if (Window == null)
            return;

        Window.SetPresenter(AppWindowPresenterKind.Overlapped);

        if (Window.Presenter is OverlappedPresenter presenter)
        {
            presenter.IsResizable = true;
            presenter.IsMaximizable = true;
            presenter.IsMinimizable = true;

            presenter.SetBorderAndTitleBar(true, true);

            presenter.Maximize();
        }

        Window.Title = "Admin DASM";
    }

    // =========================
    // TRUE FULLSCREEN
    // =========================
    public void SetFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(AppWindowPresenterKind.FullScreen);
    }

    // =========================
    // EXIT FULLSCREEN
    // =========================
    public void ExitFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(AppWindowPresenterKind.Overlapped);
    }

    // =========================
    // RETURN TO LOGIN WINDOW
    // =========================
    public void RestoreLoginWindow()
    {
        if (Window == null)
            return;

        int loginWidth = 650;
        int loginHeight = 720;

        Window.SetPresenter(AppWindowPresenterKind.Overlapped);

        Window.Resize(
            new SizeInt32(loginWidth, loginHeight));

        if (Window.Presenter is OverlappedPresenter presenter)
        {
            presenter.IsResizable = false;
            presenter.IsMaximizable = false;
            presenter.IsMinimizable = false;

            presenter.SetBorderAndTitleBar(false, false);
        }

        Window.Title = string.Empty;
    }
}
#endif