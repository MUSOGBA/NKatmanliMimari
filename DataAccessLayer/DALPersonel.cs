using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
   public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> deger = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * from TBLBILGI",baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                deger.Add(ent);
            }
            dr.Close();
            return deger;
        }

        public static int PersonelEkleme(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHIR,GOREV,MAAS) values(@P1,@P2,@P3,@P4,@P5)",baglanti.bgl);
            if (komut2.Connection.State !=ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            komut2.Parameters.AddWithValue("@P1",p.Ad);
            komut2.Parameters.AddWithValue("@P2", p.Soyad);
            komut2.Parameters.AddWithValue("@P3", p.Sehir);
            komut2.Parameters.AddWithValue("@P4", p.Gorev);
            komut2.Parameters.AddWithValue("@P5", p.Maas);

            return komut2.ExecuteNonQuery();

        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("delete from TBLBILGI where ID=@d1",baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@d1",p);
            return komut3.ExecuteNonQuery()>0;
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("update TblBilgi set Ad=@g1,Soyad=@s2,Gorev=@g3,Sehir=@g4,Maas=@g5 where Id=@g6", baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }

            komut4.Parameters.AddWithValue("@g1",ent.Ad);
            komut4.Parameters.AddWithValue("@g2", ent.Soyad);
            komut4.Parameters.AddWithValue("@g3", ent.Sehir);
            komut4.Parameters.AddWithValue("@g4", ent.Gorev);
            komut4.Parameters.AddWithValue("@g5", ent.Maas);
            komut4.Parameters.AddWithValue("@g6", ent.Id);

            return komut4.ExecuteNonQuery()>0;
        }
        
    }
}
