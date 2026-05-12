#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace Admin_DASM;

public class AppWindowHolder
{
    // =========================================
    // SINGLETON INSTANCE
    // =========================================

    private static AppWindowHolder? _instance;

    public static AppWindowHolder Instance
        => _instance ??= new AppWindowHolder();

    // =========================================
    // WINDOW REFERENCE
    // =========================================

    public AppWindow? Window { get; private set; }

    public void Set(AppWindow window)
    {
        Window = window;
    }

    // =========================================
    // LOGIN WINDOW MODE
    // =========================================

    public async Task RestoreLoginWindow()
{
    if (Window == null)
        return;

    int loginWidth = 650;
    int loginHeight = 550;

    // =========================================
    // FORCE NORMAL WINDOW FIRST
    // =========================================

    Window.SetPresenter(
        AppWindowPresenterKind.Overlapped);

    // SMALL DELAY TO RESET WINDOW STATE
    await Task.Delay(100);

    // =========================================
    // RESIZE LOGIN WINDOW
    // =========================================

    Window.Resize(
        new SizeInt32(
            loginWidth,
            loginHeight));

    // =========================================
    // REMOVE TITLE BAR + BUTTONS
    // =========================================

    if (Window.Presenter is OverlappedPresenter presenter)
    {
        presenter.IsResizable = false;

        presenter.IsMaximizable = false;

        presenter.IsMinimizable = false;

        presenter.SetBorderAndTitleBar(
            false,
            false);
    }

    // =========================================
    // REMOVE TITLE
    // =========================================

    Window.Title = string.Empty;

    // =========================================
    // CENTER WINDOW
    // =========================================

    var displayArea =
        DisplayArea.GetFromWindowId(
            Window.Id,
            DisplayAreaFallback.Primary);

    int x =
        (displayArea.WorkArea.Width
         - loginWidth) / 2;

    int y =
        (displayArea.WorkArea.Height
         - loginHeight) / 2;

    Window.Move(
        new PointInt32(x, y));
}

    // =========================================
    // RESTORE FULL APP WINDOW
    // =========================================

   public async Task RestoreFullWindow()
{
    if (Window == null)
        return;

    // =========================================
    // RESTORE NORMAL WINDOW MODE
    // =========================================

    Window.SetPresenter(
        AppWindowPresenterKind.Overlapped);

    // IMPORTANT:
    // WAIT FOR WINDOW TO FINISH RESTORING
    await Task.Delay(100);

    // =========================================
    // RESTORE WINDOW CONTROLS
    // =========================================

    if (Window.Presenter is OverlappedPresenter presenter)
    {
        presenter.IsResizable = true;

        presenter.IsMaximizable = true;

        presenter.IsMinimizable = true;

        presenter.SetBorderAndTitleBar(
            true,
            true);

        // SMALL DELAY BEFORE MAXIMIZE
        await Task.Delay(50);

        presenter.Maximize();
    }

    Window.Title = "Admin DASM";
}

    // =========================================
    // TRUE FULLSCREEN
    // =========================================

    public void SetFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(
            AppWindowPresenterKind.FullScreen);
    }

    // =========================================
    // EXIT FULLSCREEN
    // =========================================

    public void ExitFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(
            AppWindowPresenterKind.Overlapped);
    }
}
#endif