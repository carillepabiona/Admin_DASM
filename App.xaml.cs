#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
#endif

using Admin_DASM;

namespace Admin_DASM;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        var window = new Window(new MainPage());

#if WINDOWS

        window.Created += (s, e) =>
        {
            var nativeWindow =
                window.Handler.PlatformView;

            var hwnd =
                WindowNative.GetWindowHandle(nativeWindow);

            var windowId =
                Microsoft.UI.Win32Interop
                    .GetWindowIdFromWindow(hwnd);

            var appWindow =
                AppWindow.GetFromWindowId(windowId);

            // SAVE WINDOW INSTANCE
            AppWindowHolder.Instance.Set(appWindow);

            int loginWidth = 650;
            int loginHeight = 720;

            // =========================
            // LOGIN WINDOW SIZE
            // =========================

            appWindow.Resize(
                new SizeInt32(
                    loginWidth,
                    loginHeight));

            // =========================
            // REMOVE TITLE BAR
            // =========================

            if (appWindow.Presenter
                is OverlappedPresenter presenter)
            {
                presenter.IsResizable = false;

                presenter.IsMaximizable = false;

                presenter.IsMinimizable = false;

                presenter.SetBorderAndTitleBar(
                    false,
                    false);
            }

            appWindow.Title = string.Empty;

            // =========================
            // CENTER WINDOW
            // =========================

            var displayArea =
                DisplayArea.GetFromWindowId(
                    windowId,
                    DisplayAreaFallback.Primary);

            int x =
                (displayArea.WorkArea.Width
                 - loginWidth) / 2;

            int y =
                (displayArea.WorkArea.Height
                 - loginHeight) / 2;

            appWindow.Move(
                new PointInt32(x, y));
        };

#endif

        return window;
    }
}