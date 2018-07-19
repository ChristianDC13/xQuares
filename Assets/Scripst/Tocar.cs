using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tocar : MonoBehaviour {


     float x = 0f;
     float y = 0f;
    float Speed = 3f;




    Vector3 target;

    public GameObject Bolita;
    public Text Puntaje;

    int puntos = 0;


    float bolitaX;
    float bolitaY;


    void Start()
    {
        puntos = 0;
         x = Random.Range(-1f, 1f);
         y = Random.Range(-1f, 1f);
    }


    void OnMouseDown()
    {

        puntos = int.Parse(Puntaje.text);
        

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (target.x < 0 && target.y > 0)
        {
            if (bolitaX < 0 && bolitaY > 0)
            {
                x = Random.Range(0f, 1f);
                y = -1 + x;

                puntos++;

            }
        }

        if (target.x > 0 && target.y > 0)
        {
            if (bolitaX > 0 && bolitaY > 0)
             {
                x = Random.Range(-1f, 0f);
                y = -1 - x;

                puntos++;

            }
        }

        if (target.x < 0 && target.y < 0)
        {
            if (bolitaX < 0 && bolitaY < 0)
            {
                x = Random.Range(0f, 1f);
                y = 1 - x;

                puntos++;

            }
        }

        if (target.x > 0 && target.y < 0)
        {
            if (bolitaX > 0 && bolitaY < 0)
            {
                x = Random.Range(-1f, 0f);
                y = 1 + x;

                puntos++;

            }
        }

        Speed += 0.15f;
        

    }

    void Update()
    {
        
        Bolita.transform.position += new Vector3(x, y) * Time.deltaTime * Speed;

        bolitaX = Bolita.transform.position.x;
        bolitaY = Bolita.transform.position.y;

        Puntaje.text = "" + puntos;


    }


}
