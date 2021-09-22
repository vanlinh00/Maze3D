using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=u8UbHJCDJjY
//https://weblog.jamisbuck.org/2011/1/24/maze-generation-hunt-and-kill-algorithm

public class MazeController : MonoBehaviour
{
    public int height;
    public int weight;
    public GameObject Wall;
    public GameObject Plane;
    void Start()
    {
        Vector3 change = new Vector3();
        change.x = transform.position.x;
        change.y = transform.position.y;
        change.z = transform.position.z;
        for (int i=0;i<height;i++ )
        {
            change.x = i * 3.5f;
            change.z = 3.5f;
            transform.position = change;
            for (int j=0;j<weight ;j++ )
            {
                change.z = transform.position.z+3.5f;
                transform.position = change;
                Mazascell cell = new Mazascell();
                GameObject Obcell = Instantiate(Plane, transform.position, Quaternion.identity);

            }
            
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
