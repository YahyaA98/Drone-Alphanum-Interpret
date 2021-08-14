using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class CameraRandomizer : MonoBehaviour
{

    public GameObject theCamera;
    public Transform target;
    public TMP_Text label;
    public GameObject labelBackground;
    public GameObject thelight;
    public Light theLight2;
    
    public int counter;
    public string[] labels = {"0","1","2","3","4","5","6","7","8","9",
        "A","B","C","D","E","F","G","H","I","J","K","L","M","N", "O",
        "P","Q","R","S","T","U","V","W","X","Y","Z"
    };

    public int numberOfImagesPerLabel;


    void Start()
    {
        counter = 0;
    }


    void Update()
    {
        counter = counter + 1;
        if (UnityEngine.Input.GetButtonDown("Submit"))
        {
            // Position update
            theCamera.transform.position = new Vector3(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(15, 25), UnityEngine.Random.Range(-30, 30));

            // Point camera at Marker
            theCamera.transform.LookAt(target);

            // Reset 'drone pitch'
            theCamera.transform.localEulerAngles = new Vector3(
                theCamera.transform.eulerAngles.x,
                theCamera.transform.eulerAngles.y,
                theCamera.transform.eulerAngles.z
                );

            // Add Noise to rotation
            theCamera.transform.localEulerAngles = theCamera.transform.localEulerAngles + new Vector3(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3));

            // Light randomiser
            thelight.transform.position = new Vector3(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(15, 25), UnityEngine.Random.Range(-50, 50));
            thelight.transform.LookAt(target);
            theLight2.shadowStrength = UnityEngine.Random.Range(0.0f, 1.0f);

            // Randomise Colour
            int colorRandomizer = UnityEngine.Random.Range(0, 4);

            if (colorRandomizer == 0)
            {
                labelBackground.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            }
            else if (colorRandomizer == 1)
            {
                labelBackground.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            else if (colorRandomizer == 2)
            {
                labelBackground.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else
            {
                labelBackground.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }

            // Randomise BOLD
            int boldRandomizer = UnityEngine.Random.Range(0, 2);
            if (boldRandomizer==0)
            {
                label.fontStyle = TMPro.FontStyles.Bold;
            }
            else
            {
                label.fontStyle = TMPro.FontStyles.Normal;
            }

            // Determine Index (iD) from the counter 
            int iD = counter / numberOfImagesPerLabel;

            if (iD > 35)
            {
                Debug.Log("Stopping Playtime");
                UnityEditor.EditorApplication.isPlaying = false;
            }

            // Change text to the appropriate label
            label.text = labels[iD];

            // Create a new filepath if directory exists, if not, continue
            string filepath = Application.dataPath + "/digits/" + labels[iD];
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
                        
            // Capture image and store in appropriate directory
            Debug.Log("saved to " + filepath + "/image_" + counter.ToString() + ".png");
            ScreenCapture.CaptureScreenshot(filepath + "/image_" + counter.ToString() + ".png");
            counter = counter + 1;

            
        }
    }
}