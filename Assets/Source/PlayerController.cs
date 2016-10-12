using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private int playerNumber;
    public Player player;

    void Awake()
    {
        Debug.Log("player is awake");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = this.GetComponent<Player>();
        playerNumber = player.getPlayerNumber();

        Debug.Log("This player is player number: " + playerNumber);
    }

    void FixedUpdate()
    {
        string splayernumber = playerNumber.ToString();
        //Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal"+splayernumber);
        float moveVertical = Input.GetAxis("Vertical"+splayernumber);
        //get input from controller
        if (moveHorizontal == 0 && moveVertical == 0) {
            moveHorizontal = Input.GetAxis("L_XAxis_" + splayernumber);
            moveVertical = Input.GetAxis("L_YAxis_" + splayernumber);
        }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    

    public int getPlayerId(Player player)
    {
        return player.getPlayerNumber();
    }
}