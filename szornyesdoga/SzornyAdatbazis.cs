using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace szornyesdoga
{
    internal class SzornyAdatbazis
    {
        private readonly string connectionString;

        public SzornyAdatbazis()
        {
            this.connectionString = "Server=localhost;Database=szornyek;Uid=root;Pwd=;";
        }

        public List<Szorny> Feltolt()
        {
            var szornyek = new List<Szorny>();
            string query = "SELECT * FROM szornyek;";

            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            string nev = reader.GetString("Nev");
                            int veszelyessegiSzint = reader.GetInt32("VeszelyessegiSzint");
                            string elohely = reader.GetString("Elohely");
                            string foGyengeseg = reader.GetString("FoGyengeseg");
                            string leggyakoribbZsakmany = reader.GetString("LeggyakoribbZsakmany");
                            bool veszelyesE = reader.GetBoolean("VeszelyesE");


                            Szorny szorny = new Szorny(id, nev, veszelyessegiSzint, elohely, foGyengeseg, leggyakoribbZsakmany, veszelyesE);

                            szornyek.Add(szorny);
                        }
                    }
                }
            }

            return szornyek;
        }
    }
}
