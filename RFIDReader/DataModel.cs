using System;

namespace RFIDReader
{
    [Serializable]
    class DataModel
    {
        public string ID { get; set; }
        public float Credit { get; set; }
        public float Rate { get; set; }
        public string ProcessFile { get; set; }
        public char Key { get; set; }
        public string SoundFile { get; set; }
    }
}
