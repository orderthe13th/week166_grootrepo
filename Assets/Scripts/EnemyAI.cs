
using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed, lookTime;

    private int directionMultiplier;
    private float elapsed;
    private bool isMovingRight;

    private void Start()
    {
        directionMultiplier = 1;
        isMovingRight = true;
        elapsed = 0;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= lookTime)
        {
            isMovingRight = !isMovingRight;
            Debug.Log("Flipping me");
            FlipMe();
            elapsed = 0;
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void FlipMe()
    {
        if (isMovingRight)
        {
            directionMultiplier = 1;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            directionMultiplier = -1;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
