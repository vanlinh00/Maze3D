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
        Vector3 Rightw = new Vector3();
        Vector3 Leftw = new Vector3();
        change.x = transform.position.x;
        change.y = transform.position.y;
        change.z = transform.position.z;
        Mazecell[,] gif = new Mazecell[height, weight]; 
        for (int i=0;i<height;i++ )
        {
            change.x = i * 3f;
            change.z = 3f;
            transform.position = change;
            for (int j=0;j<weight ;j++ )
            {
                change.z = transform.position.z+3f;
                transform.position = change;
                Mazecell cell = new Mazecell();
                GameObject Obcell = Instantiate(Plane, transform.position, Quaternion.identity);

               
                Rightw.y =transform.position.y+ 1.18f;
                Rightw.z = transform.position.z+1.237f;
                Rightw.x = transform.position.x;

                GameObject Wallright = Instantiate(Wall, Rightw, Quaternion.identity);
                cell.RigthWall = Wallright;

                Rightw.z = transform.position.z - 1.237f;
                GameObject Wallleft = Instantiate(Wall, Rightw, Quaternion.identity);
                cell.LeftWall = Wallleft;

                //Rightw.x = transform.position.x - 1.66f;
                //GameObject WallUp = Instantiate(Wall,Rightw, Quaternion.identity);
                //cell.UpWall = WallUp;
                //Rightw.x = transform.position.x + 1.66f;
                //GameObject DownWall = Instantiate(Wall,Rightw, Quaternion.identity);
                //cell.RigthWall = DownWall;

            }
            
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
