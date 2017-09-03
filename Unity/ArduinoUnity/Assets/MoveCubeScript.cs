/*
    Arduino Unity example running on Windows 8.1,
    Visual Studio 2015.
    Arduino 1.6.4 IDE + Arduino Due.
*/

using System.Collections;
using System.Collections.Generic;
// NB Need to set compatibility mod to .NET
// not .NET (subset) in Unity 
// Edit>ProjectSettings>Player>ApiCompatibilityLevel
using System.IO.Ports;
using UnityEngine;

public class MoveCubeScript : MonoBehaviour {

    public float speed;

    public float amountToMove;

    // Note, COM port might not be recognised if this patch is not applied:
    // https://www.microsoft.com/en-us/download/details.aspx?id=45105
    // and/or if COM port number > 9:
    // https://forum.unity3d.com/threads/serialport-open-error.160041/
    // Solution, applied patch and/or force port number change.

    SerialPort sp = new SerialPort("COM9", 9600);
	// Use this for initialization
	void Start ()
    {
        sp.Open();
        sp.ReadTimeout = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        amountToMove = speed * Time.deltaTime;

        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
	}

    // Functionality to allow object to move
    void MoveObject(int Direction)
    {
        if (Direction == 1)
        {
            transform.Translate(Vector3.left * amountToMove, Space.World);
        }
        if (Direction == 2)
        {
            transform.Translate(Vector3.right * amountToMove, Space.World);
        }
    }
}
