using System;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Linq;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace RFIDReader
{
    static class Backend
    {
        public static BindingList<DataModel> DataModels = new BindingList<DataModel>();

        public static void Init()
        {
            var models = Serializer.Deserialize();
            if (models == null) DataModels = new BindingList<DataModel>();
            else DataModels = new BindingList<DataModel>(models.ToList());
            Reader.Instance.IDDetected += (id) =>
            {
                ProcessId(id);
            };
        }

        public static void StartReader()
        {
            Reader.Instance.Initialize();
        }

        public static void StopReader()
        {
            Reader.Instance.Deinitialize();
        }

        public static void DeInit()
        {
            Serializer.Serialize(DataModels.ToArray());
        }

        public static void Dispose()
        {
            Reader.Instance.Dispose();
        }

        private static void ProcessId(string id)
        {
            DataModel cndd = null;
            
            cndd = GetModelFromId(id);
            if (cndd != null)
            {
                cndd = ProcessCredit(cndd);
                if (cndd != null)
                {
                    DataModels[DataModels.IndexOf(cndd)] = cndd;
                    LaunchProgram(cndd);
                    EmulateKey(cndd);
                    PlaySound(cndd);
                }
            }
        }

        private static DataModel GetModelFromId(string id)
        {
            if (id.Length >= 6 && id.Length <= 10)
            {
                foreach (var dataModel in DataModels)
                {
                    if (dataModel.ID == id) return dataModel;
                }
            }
            return null;
        }

        private static DataModel ProcessCredit(DataModel model)
        {
            if (model.Credit >= model.Rate)
            {
                model.Credit -= model.Rate;
                return model;
            }
            return null;
        }

        private static void LaunchProgram(DataModel model)
        {
            if (File.Exists(model.ProcessFile))
            {
                string targetPath = Path.GetFullPath(model.ProcessFile);
                if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(targetPath)).Length > 0) return;

                try
                {
                    Process.Start(targetPath);
                }
                catch
                {
                    return;
                } 
            }
        }

        private static void EmulateKey(DataModel model)
        {
            if (!Enum.IsDefined(typeof(VirtualKeyCode), (int)Char.ToUpper(model.Key))) return;
            if (!Char.IsLetterOrDigit(model.Key)) return;
            InputSimulator simulator = new InputSimulator();
            Thread.Sleep(500);
            simulator.Keyboard.KeyDown((VirtualKeyCode)Char.ToUpper(model.Key));
            simulator.Keyboard.Sleep(200);
            simulator.Keyboard.KeyUp((VirtualKeyCode)Char.ToUpper(model.Key));
        }

        private static void PlaySound(DataModel model)
        {
            if (File.Exists(model.SoundFile))
            {
                var targetPath = Path.GetFullPath(model.SoundFile);
                new SoundPlayer(targetPath).Play();
            }
        }
    }
}
