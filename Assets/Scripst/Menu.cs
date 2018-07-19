using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Menu : MonoBehaviour {

    public GameObject Bolita;
    public Text puntaje_actual;
    public Text Puntuacion;
    public Image Panel_perder;
    public GameObject panel_record;

    void Start()
    {

    }

    public void reanudar()
    {
        Application.LoadLevel("EnJuego");
        
    }

    public void iniciar()
    {
        Application.LoadLevel("EnJuego");
    }

    public void menuPrincipal()
    {
        Application.LoadLevel("Inicio");

    }

    public void cerrarNuevoRecord()
    {
        panel_record.SetActive(false);
    }

    public void salir()
    {
        Application.Quit();
    }

    public void info()
    {
        Application.LoadLevel("Info");

        
    }

    public void link()
    {
        Application.OpenURL("https://www.linkedin.com/in/christian-de-la-cruz-2628b5160/");
    }

}
