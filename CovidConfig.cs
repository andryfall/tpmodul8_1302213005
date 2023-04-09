using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302213005
{

    public class AppConfig
    {
        public CovidConfig config;

        private const string filelocation = "C:\\Users\\andry\\Documents\\GitHub\\tpmodul8_1302213005\\";
        private const string filepath = filelocation + "covid_config.json";
        
        public AppConfig() {
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
            string hasilBaca = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<CovidConfig>(hasilBaca);
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
            config = new CovidConfig("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk ke dalam gedung ini");

        }
    }
    public class CovidConfig
    {
        public String satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public String pesan_ditolak { get; set; }
        public String pesan_diterima { get; set; }

        public CovidConfig()
        {

        }

        public CovidConfig(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }

        public void UbahSatuan()
        {
            if(this.satuan_suhu == "celcius")
            {
                this.satuan_suhu = "farenheit";
            }
            else
            {
                this.satuan_suhu = "celcius";
            }
        }

    }
}
