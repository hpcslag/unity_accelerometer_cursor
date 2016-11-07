using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;

public class Arrow : MonoBehaviour {

	  Vector2 point;
    Rect rect;
    GUIStyle style = new GUIStyle();
    public int width, height;

    
    public float xSpeed = 1F;
    public float ySpeed = 1F;
    public float zSpeed = 1F;

    SerialPort sp;
    private bool isOpen = false;

    

    // Use this for initialization
    void Start()
    {
        GO();
    }

    public void GO()
    {
        try
        {
            sp = new SerialPort("\\\\.\\COM12", 9600); //Modify it.
            sp.ReadTimeout = 10;

            print("Port Opening...");
            sp.Open();
            isOpen = true;
            print("Port opened");
        }
        catch (Exception e)
        {
            isOpen = false;
            print("DEVICE NOT FOUND!");
        }
    }

    public void stop()
    {
        isOpen = false;
        sp.Close();
        print("destroy serial port");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GO();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            stop();
        }
    }

    void OnGUI(){

        point = new Vector2(Screen.width / 2 + width, Screen.height / 2 + height);

        style.fontSize = 75;
        style.normal.textColor = Color.red;

        if (isOpen)
        {
            //moveing arrow to current position
            string[] posi = sp.ReadLine().Split(new char[] { ',' });
            float p_x = float.Parse(posi[2]) * xSpeed * 100;//* Time.deltaTime;
            float p_y = this.transform.position.y * ySpeed;// * Time.deltaTime;
            float p_z = float.Parse(posi[3]) * zSpeed * 100;

            //Vector3 moveDirection = new Vector3(p_x, p_y, p_z);

            //transform.position = Vector3.Lerp(transform.position, moveDirection, 1F);
            //arrow.TransformPoint(new Vector3(p_x,p_y,p_z));
            //arrow.Translate(p_x,p_y,p_z);

            rect = new Rect(point.x + (-p_x), point.y + (-p_z), 300, 10);
        }

        GUI.Label(rect, "+", style);
    }
}
