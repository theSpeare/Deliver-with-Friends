using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Camera currentCamera;
    private int playerNumber;

    public void setPlayerNumber(int _id)
    {
        playerNumber = _id;
    }

    public int getPlayerNumber()
    {
        return playerNumber;
    }
}
