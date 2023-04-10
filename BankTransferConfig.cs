using Newtonsoft.Json;
using System.IO;

namespace modul8_1302213030
{
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public string[] methods { get; set; }
        public string confirmation { get; set; }

        public static BankTransferConfig LoadConfig()
        {
            var file = "bank_transfer_config.json";
            if (!File.Exists(file))
            {
                return new BankTransferConfig
                {
                    lang = "en",
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000,
                    methods = new string[] { "RTO", "SKN", "RTGS", "BI FAST" },
                    confirmation = "yes",
                };
            }
            var json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<BankTransferConfig>(json);
        }
    }
}
