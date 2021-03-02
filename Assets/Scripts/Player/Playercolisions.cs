using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercolisions : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [SerializeField] int enemydamage;

    //externals 
    private healthBehaviour _healthBehaviour;

    private void Awake()
    {
        _healthBehaviour = this.gameObject.GetComponent<healthBehaviour>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("toquei");
        if (collision.gameObject.layer == 8) {
            print("toqueinoinimigo");
            _healthBehaviour.TakeDamage(enemydamage);
        }
    }
    
}
