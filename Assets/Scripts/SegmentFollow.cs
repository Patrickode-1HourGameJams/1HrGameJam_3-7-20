using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private float offset;

    [SerializeField]
    private int orderInSnake;

    void Start()
    {
        offset = (transform.position.z - player.transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp
            (
                transform.position,
                player.transform.position - player.transform.forward * -offset,
                0.9f
            );

        transform.forward = Vector3.Lerp(transform.forward, player.transform.forward, 0.9f);
    }
}
