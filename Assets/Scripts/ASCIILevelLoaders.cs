using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ASCIILevelLoaders : MonoBehaviour
{

    public float xOffset;
    public float yOffset;

    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject goal;
    public GameObject enemy;

    public GameObject currentPlayer;

    private Vector2 startPos;

    public string fileName;
    public int currentLevel = 0;

    public int CurrentLevel
    {
        get { return currentLevel; }

        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    // empty; hold level
    public GameObject level;

    void Start()
    {
        LoadLevel(); //call load level
    }

    //creates level(ASCII)
    void LoadLevel()
    {
        Destroy(level); //Destroy current level
        level = new GameObject("Level"); //New level gameObject
        
        string current_file_path = //path to the level file
            Application.dataPath +
            "/Levels/" +
            fileName.Replace(
                "Num", 
                currentLevel + "");

        string[] fileLines = File.ReadAllLines(current_file_path);
        
        //loop through each line
        for (int y = 0; y < fileLines.Length; y++)
        {
            //current line
            string lineText = fileLines[y];
            
            char[] characters = lineText.ToCharArray();
            
            //loop through each char
            for (int x = 0; x < characters.Length; x++)
            {
                //grab the current char
                char c = characters[x];
                
                //var for newObj
                GameObject newObj;

                switch (c)
                {
                    case 'p': //if char is a 'p'
                        //make a player gameObject
                        newObj = Instantiate<GameObject>(player);
                        if (currentPlayer == null) // if we don't have a currentPlayer
                            currentPlayer = newObj; // make this the currentPlayer
                        //save this position to startPos to use for reseting the player
                        startPos = new Vector2(
                            x + xOffset, -y + yOffset);
                        break;
                    case 'w' : //if char is a 'w'
                        //make a wall
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '*' : //if char is an '*'
                        //make an obstacle
                        newObj = Instantiate<GameObject>(obstacle);
                        break;
                    case '&' : //if char is '&'
                        //make a goal
                        newObj = Instantiate<GameObject>(goal);
                        break;
                   case 'e' : //if char is 'E'
                        //make an enemy
                        newObj = Instantiate<GameObject>(enemy);
                        break;
                    default: //if the char is anything else
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    //if newObj is !player
                    if (!newObj.name.Contains("Player"))
                    {
                        //make the level gameObject it's parent
                        newObj.transform.parent = level.transform;
                    }
                    
                    //whatever newObj is, set it's position based on the offsets
                    //and it's position in the file
                    newObj.transform.position =
                        new Vector3(x + xOffset, -y + yOffset,0);
                }
                
            }
        }
    }

    public void ResetPlayer()
    {
        //return player startPos
        currentPlayer.transform.position = startPos;
    }

    void Update()
    {
        
    }
}
