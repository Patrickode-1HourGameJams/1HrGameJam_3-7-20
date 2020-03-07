using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatPellet : MonoBehaviour
{
    [SerializeField]
    ///How many pellets are needed to finish the level.
    private int pelletsToEat;
    private int pelletsEaten = 0;

    [SerializeField]
    private float spawnRange;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        RelocatePellet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increase the number of pellets eaten.
            pelletsEaten++;

            //If enough pellets are eaten, end. Otherwise, relocate it.
            if (pelletsEaten >= pelletsToEat)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                RelocatePellet();
            }
        }
    }

    public void RelocatePellet()
    {
        //Set up a new position and make sure it's never too close to the player.
        Vector3 newPos = player.transform.position;
        while (Vector3.Distance(newPos, player.transform.position) <= 1)
        {
            newPos = new Vector3
            (
                Random.Range(-spawnRange, spawnRange),
                0.5f,
                Random.Range(-spawnRange, spawnRange)
            );
        }

        //Then set this pellet's transform to that new position.
        transform.position = newPos;
    }
}
