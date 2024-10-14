using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = Camera.main.transform;
    }
    private void Update()
    {
        MoveToPlayer();

        if (Vector3.Distance(transform.position, playerTransform.position) < 1f)
        {
            Destroy(gameObject);
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
        }
    }
}