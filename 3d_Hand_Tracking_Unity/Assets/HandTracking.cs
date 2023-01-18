using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject[] handPoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive.data;
        if(data.Length > 0)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);

            string[] points = data.Split(',');

            for (int i = 0; i < 21; i++)
            {
                print(points[i * 3]);
                float x = 6 - float.Parse(points[i * 3]) / 100;
                float y = float.Parse(points[i * 3 + 1]) / 100;
                float z = float.Parse(points[i * 3 + 2]) / 100;

                handPoints[i].transform.localPosition = new Vector3(x, y, z);
            }
        }
        
    }
}
