using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWind : MonoBehaviour
{
    public Transform target;
    public GameObject[] Core;
    public float forceAmount = 1000f;

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.GameStatus != GameManager.eGameStatus.E_GAME_STATUS_END)
                return;

        if (other.CompareTag("Player"))
        {
            Vector3 forceDirection = (target.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(forceDirection * forceAmount);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.GameStatus != GameManager.eGameStatus.E_GAME_STATUS_END)
            return;


    }
}
