using UnityEngine;
public class MazeController : MonoBehaviour
{
    public int height;

    public int weight;

    public GameObject Wall;

    public GameObject Plane;
    Mazecell[,] gif;
    internal void Start()
    {
        gif  = new Mazecell[height, weight];
        Create();
        Debug.LogError(gif[0, 0].DownWall.transform.position.x);
        CreateMaze();
    }

    internal void Create()
    {
        Vector3 change = new Vector3();
        Vector3 Rightw = new Vector3();
      
        change.x = transform.position.x;
        change.y = transform.position.y;
        change.z = transform.position.z;
       
        for (int i = 0; i < height; i++)
        {

            change.x = i * 3f;
            change.z = 3f;
            transform.position = change;
            for (int j = 0; j < weight; j++)
            {
                change.z = transform.position.z + 3f;
                transform.position = change;

                Mazecell cell = new Mazecell();
                GameObject Obcell = Instantiate(Plane, transform.position, Quaternion.identity);
                cell.Plane = Plane;

                Rightw.y = transform.position.y + 1.18f;
                Rightw.z = transform.position.z + 1.237f;
                Rightw.x = transform.position.x;

                GameObject Wallright = Instantiate(Wall, Rightw, Quaternion.identity);
                cell.RigthWall = Wallright;

                Rightw.z = transform.position.z - 1.237f;
                GameObject Wallleft = Instantiate(Wall, Rightw, Quaternion.identity);
                cell.LeftWall = Wallleft;

                Rightw.z = change.z;
                Rightw.x = transform.position.x - 1.66f;
                GameObject WallUp = Instantiate(Wall, Rightw, Quaternion.Euler(0, 90, 0));

                cell.UpWall = WallUp;

                Rightw.x = transform.position.x + 1.66f;
                GameObject WallDown = Instantiate(Wall, Rightw, Quaternion.Euler(0, 90, 0));
                cell.DownWall = WallDown;

                gif[i, j] = cell;

            }

        }
    }
    void CreateMaze()
    {
        // Vector3 startpositon = gif[0, 0].Plane.transform.position;
        Run(2, 2);
    }
    void Run(int x,int y)
    {
        gif[x, y].Isvisited = true;
       
        int stop = 1;
        while (stop==1)
        {
            Debug.LogError(x+ "_"+ y);
            int choice = Random.RandomRange(1, 5);

            if (choice == 1)
            {
                //up
                Destroy(gif[x, y].UpWall);
                Destroy(gif[x - 1, y].DownWall);
                if (gif[x - 1, y].Isvisited == false)
                {
                    gif[x - 1, y].Isvisited = true;
                    x = x - 1;
                    y = y;
                }
                else
                {
                    stop = 0;
                    
                }
            }
            else if (choice == 2)
            {
                //down
                Destroy(gif[x, y].DownWall);
                Destroy(gif[x+1, y].UpWall);
                if (gif[x + 1, y].Isvisited == false)
                {
                    gif[x + 1, y].Isvisited = true;
                    x = x + 1;
                    y = y;
                }
                else
                {
                    stop = 0;
                }
            }
            else if (choice == 3)
            {
                //left
                
                Destroy(gif[x, y].LeftWall);
                Destroy(gif[x, y+1].RigthWall);
                if (gif[x, y + 1].Isvisited == false)
                {
                    gif[x, y + 1].Isvisited = true;
                    x = x;
                    y = y + 1;
                }
                else
                {
                    stop = 0;
                }
            }
            else if (choice == 4)
            {
                //right
                
                Destroy(gif[x, y].RigthWall);
                Destroy(gif[x, y-1].LeftWall);
                if (gif[x, y - 1].Isvisited == false)
                {
                    gif[x, y - 1].Isvisited = true;
                    x = x;
                    y = y - 1;
                }
                else
                {
                    stop = 0;
                }
            }

        }
    }
    internal void Update()
    {
    }
}
