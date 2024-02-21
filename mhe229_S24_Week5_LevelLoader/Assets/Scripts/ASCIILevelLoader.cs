using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    
    GameObject level;
    int currentLevel = 0;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }
    string FILE_PATH;
    
    public static ASCIILevelLoader instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";

        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level Objects");
        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));
        Debug.Log(lines[0]);

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y].ToUpper();

            char[] characters = line.ToCharArray();

            for (int x = 0; x < characters.Length; x++)
            {
                char c = characters[x];
                Debug.Log(c);

                GameObject newObject = null;
                switch (c)
                {
                    case 'W': // if the caracter is a W add a wall
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    case 'P': // if the character is a P add a player
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        // follow player with camera 
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -10);
                        break;
                    case 'S': // if the character is an S add a spike
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Spike"));
                        break;
                    case 'G': // add a goal point
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Goal"));
                        break;
                    default:
                        break;
                }

                if (newObject != null)
                {
                    // Give new position based on ASCII file
                    newObject.transform.position = new Vector3(x, -y, 0);
                    newObject.transform.parent = level.transform;
                }
            }
        }
    }
}