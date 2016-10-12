using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainController : MonoBehaviour {
    // Main Controller handles instantiating everything and scenes and shit
    public GameObject playerPrefab;
    public int numberOfPlayers; // to be determined

    public List<GameObject> players;

	// Use this for initialization
	void Start () {
        numberOfPlayers = 2;
        InstantiatePlayers();
        InitPlayerPositions();
	}

	// Update is called once per frame
	void Update () {
	
	}

    void InstantiatePlayers()
    {
        Debug.Log("instantiating players!");
        for (int i = 1; i < numberOfPlayers+1; i++)
        {
            GameObject player_prefab = Instantiate(playerPrefab) as GameObject;
            Player player = player_prefab.GetComponent<Player>();
            player.setPlayerNumber(i);
            players.Add(player_prefab);

        }
        Debug.Log("completed instantiated players");

    }

    void InitPlayerPositions()
        // prototype code
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = new Vector3(i*3, 10, 0);
        }
    }


}
