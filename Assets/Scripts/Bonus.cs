using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]public class Bonus : MonoBehaviour
{
    public int value = 1;
    static public UnityEvent takeBonus = new UnityEvent();

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreCounter.AddBonus(value);
            takeBonus.Invoke();
            Destroy(gameObject);
        }
    }
}
