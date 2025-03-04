using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
using UnityEditor;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;

    public static bool showWinScreen = false;
    public static bool showLoseScreen = false;
    public static int staminaText;
    public static string detected = "HIDDEN";
    public static int bullets = 10;

    public Stack<string> lootStack = new Stack<string>();

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = print;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    void OnGUI()
    { 

        GUI.Box(new Rect(20, 20, 150, 25), "Stamina: " +
           staminaText);

        GUI.Box(new Rect(20, 50, 150, 25), "Status: " +
           detected);

        GUI.Box(new Rect(20, 80, 150, 25), "Bullets: " +
           bullets);

        if (showWinScreen == true)
        {
            Time.timeScale = 0f;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                showWinScreen = false;
                Utilities.RestartLevel(0);
            }
        }

        if (showLoseScreen == true)
        {
            Time.timeScale = 0f;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU LOSE!"))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully...");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    showLoseScreen = false;
                    debug("Reverting to scene 0: " +
                       e.ToString());
                }
                finally
                {
                    debug("Restart handled...");
                    showLoseScreen = false;
                    Utilities.RestartLevel(0);
                }
            }
        }
    }

    public void Initialize()
    {
        _state = "Manager initialized...";
        _state.FancyDebug();
        Debug.Log(_state);

        lootStack.Push("Stamina Upgrade");
        lootStack.Push("Jump Upgrade");
        lootStack.Push("Sneaky Upgrade");
        lootStack.Push("Elevator Key");
        lootStack.Push("Ammo");

        debug(_state);
        LogWithDelegate(debug);

        //GameObject player = GameObject.Find("Player");
        //PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        //playerBehavior.playerJump += HandlePlayerJump;
    }

    //public void HandlePlayerJump()
    //{
        //debug("Player has jumped.");
    //}

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good change of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items left!", lootStack.Count);
    }

    public static void print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
    }

    void Start()
    {
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);

        Initialize();
    }

    void Update()
    {
        
    }
}
