using System;
using System.Windows.Threading;
using Keystroke.API;
using Keystroke.API.CallbackObjects;

namespace RFIDReader
{
    class Reader : IDisposable
    {
        public static readonly Reader Instance = new Reader();

        private Dispatcher Dispatcher = null;
        private KeystrokeAPI api = null;
        private bool ishooked = false;
        private string id = "";

        public delegate void IDDetectedEventHandler(string id);
        public event IDDetectedEventHandler IDDetected;

        private Reader()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void Initialize()
        {
            if (ishooked) return;
            api = new KeystrokeAPI();
            Dispatcher.Invoke(() =>
            {
                api.CreateKeyboardHook((KeyPressed keyPressed) =>
                {
                    if (keyPressed.KeyCode >= KeyCode.D0 && keyPressed.KeyCode <= KeyCode.D9)
                    {
                        id += ((int)keyPressed.KeyCode - 48);
                    }
                    else if (keyPressed.KeyCode >= KeyCode.NumPad0 && keyPressed.KeyCode <= KeyCode.NumPad9)
                    {
                        id += ((int)keyPressed.KeyCode - 96);
                    }
                    else if (keyPressed.KeyCode == KeyCode.Return)
                    {
                        OnIdDetected();
                        id = "";
                    }
                });
            });
            ishooked = true;
        }

        public void Deinitialize()
        {
            Dispatcher.Invoke(() =>
            {
                if (api != null) api.Dispose();
            });
            api = null;
            ishooked = false;
            id = "";
        }

        public void Dispose()
        {
            if (ishooked) Deinitialize();
            //Dispatcher.InvokeShutdown();
            //Dispatcher = null;
            api = null;
        }

        private void OnIdDetected()
        {
            IDDetected?.Invoke(id);
        }

    }
}
