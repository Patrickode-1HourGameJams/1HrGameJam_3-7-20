using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offset;

    [SerializeField]
    private int orderInSnake;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3
            (
                player.transform.position.x + offset.x,
                player.transform.position.y + offset.y,
                player.transform.position.z + offset.z
            );

        transform.LookAt(player.transform);
    }
}
