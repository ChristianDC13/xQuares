using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class ManejarPuntos : MonoBehaviour {

    public static ManejarPuntos manejar;

    public Text tx_puntuacion;
    public Text tx_record;
    public Text tx_diamantes;
    public GameObject panel_record;



    void Start () {
        panel_record.SetActive(false);


        string conn = "URI=file:" + Application.dataPath + "/Plugins/xqdatabase.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand cmd = dbconn.CreateCommand();
        cmd.CommandText = "SELECT * FROM puntaje";
        IDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            bool nuevo_record = false;

            int puntuacion = reader.GetInt32(0);
            int record = reader.GetInt32(1);
            int diamantes = reader.GetInt32(2);

            if(puntuacion > record)
            {
                panel_record.SetActive(true);

                nuevo_record = true;
                diamantes++;
            }

            reader.Close();


            if (nuevo_record)
            {
                cmd.CommandText = "UPDATE puntaje SET record=" + puntuacion + ", diamantes=diamantes+1";
                cmd.ExecuteNonQuery();
            }

            tx_puntuacion.text = "Puntuacion: " + puntuacion;
            tx_record.text = "Record: " + record;
            tx_diamantes.text = "" + diamantes;
        }

        cmd.Dispose();
        dbconn.Close();

    }


}
