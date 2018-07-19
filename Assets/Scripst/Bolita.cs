using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;


public class Bolita : MonoBehaviour {

    public Text txPuntos;

    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        agregarPuntaje();
        Application.LoadLevel("Perder");

    }


    void agregarPuntaje()
    {
        try
        {
            int puntuacion = int.Parse(txPuntos.text);

            string conn = "URI=file:" + Application.dataPath + "/Plugins/xqdatabase.db";
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();

            IDbCommand cmd = dbconn.CreateCommand();
            
            cmd.CommandText = "UPDATE puntaje SET ultimo=" + puntuacion + "";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            dbconn.Close();
        }catch(Exception ex)
        {
            print(ex);
        }

    }

}
