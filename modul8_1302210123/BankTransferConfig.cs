using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302210123
{
    public class AppConfig
    {
        public BankTransferConfig config;
        public transfer config2;
        public confirmation config3;

        private const string filelocation = "D:\\Code\\TPKPL\\MOD8\\modul8_1302210123\\";
        private const string filepath = filelocation + "Bank_Transfer_config.json";

        public AppConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                setDefault();
                WriteNewConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string result = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(result);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, jsonString);
        }

        private void setDefault()
        {
            config = new BankTransferConfig("en", new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" }, new transfer(25000000, 6500, 1500), new confirmation("yes", "ya"));

        }
    }
    public class transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public transfer() { }
        public transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class confirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public confirmation() { }
        public confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
    public class BankTransferConfig
    {
        public String lang { get; set; }
        public transfer transfer { get; set; }
        public List<String> methods { get; set; }
        public confirmation confirmation { get; set; }



        public BankTransferConfig()
        {

        }

        public BankTransferConfig(String lang, List<String> methods, transfer transfer, confirmation confirmation)
        {
            this.lang = lang;
            this.methods = methods;
            this.transfer = transfer;
            this.confirmation = confirmation;
        }
    }   
}
