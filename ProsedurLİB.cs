using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AylikGelirKontrol.SqlCon
{
    class SqlProsedurCalistir
    {
        private  SqlConnection myConnection = new SqlConnection("Data Source=" + "YENEN" + ";Initial Catalog=" + "AylikGiderKontrolu" + ";Integrated Security=True");
        private List<Model> arrayliststatic = new List<Model>();
        private class Model
        {
            public string Prosedur_Adi { get; set; }
            public SqlDbType Prosedur_Tipi { get; set; }
            public string Prosedur_YuklencekVeri { get; set; }
            public string Prosedur_Nvarcharsa_Uzunluk { get; set; }
        }


        public String GET_Execute_Sqlcmd(string prosedur_Adi)
        {
            string response = "Baþarýlý...";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.CommandText = prosedur_Adi;
                foreach (Model eleman in arrayliststatic)
                {
                    if (eleman.Prosedur_Tipi.Equals(SqlDbType.NVarChar))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi, Convert.ToInt32(eleman.Prosedur_Nvarcharsa_Uzunluk));
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = eleman.Prosedur_YuklencekVeri;
                    }
                    else if (eleman.Prosedur_Tipi.Equals(SqlDbType.DateTime))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToDateTime(eleman.Prosedur_YuklencekVeri);
                    }
                    else if(eleman.Prosedur_Tipi.Equals(SqlDbType.Int))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToInt32(eleman.Prosedur_YuklencekVeri);
                    }
                    else if (eleman.Prosedur_Tipi.Equals(SqlDbType.Real))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToDouble(eleman.Prosedur_YuklencekVeri);
                    }else if (eleman.Prosedur_Tipi.Equals(SqlDbType.Bit))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToBoolean(eleman.Prosedur_YuklencekVeri);
                     
                    }
                }
                arrayliststatic.Clear();
                sqlCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                arrayliststatic.Clear();
                response = ex.ToString();
                myConnection.Close();
                
            }
            return response;
        }
        public void ProsedurEkle(string Prosedur_Adi, SqlDbType tip, string veri, string charuzuluk)
        { // sqldatatype ayrý  al
            Model model = new Model();
            model.Prosedur_Adi = Prosedur_Adi;
            model.Prosedur_Tipi = tip;
            model.Prosedur_YuklencekVeri = veri;
            model.Prosedur_Nvarcharsa_Uzunluk = charuzuluk;
            arrayliststatic.Add(model);
        }


        public DataTable get_Direkt_DataTable(String prosedur_Adi)
        { // geri data göndercek prosedürler için 
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.CommandText = prosedur_Adi;
            DataTable ds = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sqlCmd);
            adap.Fill(ds);
            myConnection.Close();
            return ds;
        }

        private SqlCommand Pro_ElemanEkle_DAtaDondur(string prosedur_Adi)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {                    
                sqlCmd.Connection = myConnection;
               
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.CommandText = prosedur_Adi;
                foreach (Model eleman in arrayliststatic)
                {
                    if (eleman.Prosedur_Tipi.Equals(SqlDbType.NVarChar))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi, Convert.ToInt32(eleman.Prosedur_Nvarcharsa_Uzunluk));
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = eleman.Prosedur_YuklencekVeri;
                    }
                    else if (eleman.Prosedur_Tipi.Equals(SqlDbType.DateTime))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToDateTime(eleman.Prosedur_YuklencekVeri);
                    }
                    else if (eleman.Prosedur_Tipi.Equals(SqlDbType.Int))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToInt32(eleman.Prosedur_YuklencekVeri);
                    }
                    else if (eleman.Prosedur_Tipi.Equals(SqlDbType.Real))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToDouble(eleman.Prosedur_YuklencekVeri);
                    }else if (eleman.Prosedur_Tipi.Equals(SqlDbType.Bit))
                    {
                        sqlCmd.Parameters.Add(eleman.Prosedur_Adi, eleman.Prosedur_Tipi);
                        sqlCmd.Parameters[eleman.Prosedur_Adi].Value = Convert.ToBoolean(eleman.Prosedur_Tipi);
                    }
                }
                arrayliststatic.Clear();      
               
            }
            catch (Exception ex)
            {
                arrayliststatic.Clear();
                sqlCmd = null;
               

            }
            return sqlCmd;
        }

        public DataTable get_Elemanekle_Datatable(string proseduradi)
        {

            DataTable ds = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(Pro_ElemanEkle_DAtaDondur(proseduradi));
            adap.Fill(ds);
            return ds;
        }

        public SqlDataReader get_SqldataReader(string proseduradi)
        {
            SqlCommand sqlcom = Pro_ElemanEkle_DAtaDondur(proseduradi);
            myConnection.Open();
            SqlDataReader reader =   sqlcom.ExecuteReader();  
            return reader;
        }
        public List<String> get_SqldataReader_List_String_Data(string proseduradi)
        {
            List<String> arraylist = new List<string>();
            SqlDataReader read = get_SqldataReader(proseduradi);
            while (read.Read())
            {
                arraylist.Add(read.GetValue(0).ToString());
            }
            myConnection.Close();
            return arraylist;
        }
        public void ConnectClose()
        {
            // get_SqldataReader fonksiyonun dan açýk kalanConnection kapanmasý için
            myConnection.Close();
        }
    }
}
