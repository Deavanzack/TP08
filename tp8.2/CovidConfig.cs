using System;
using System.Text.Json;

public class CovidConfig
{
    public string suhu { get; set; }
    public int hari { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public class suhuconfig
    {
        public CovidConfig config;
        public const string filepath = "C:\\Users\\fadillah\\OneDrive - Telkom University\\Dokumen\\My File\\RPL\\SEMESTER 4\\Kontruksi Perangkat Lunak\\tp8.2\\tp8.2\\covid_config.json";
        public suhuconfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string configjsondata = File.ReadAllText(filepath);
            this.config = JsonSerializer.Deserialize<CovidConfig>(configjsondata);

        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, jsonString);
        }
        private void SetDefault()
        {
            config = new CovidConfig();
            config.suhu = "celcius";
            config.hari = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void ubahsatuan()
        {
            config = new CovidConfig();
            if (this.config.suhu == "celcius")
            {
                this.config.suhu = "farenheit";
            }
            else if (config.suhu == "farenheit")
            {
                this.config.suhu = "celcius";
            }
        }
    }
}
