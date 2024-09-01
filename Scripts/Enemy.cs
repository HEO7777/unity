using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        print(HP);
        if (HP <= 0)
            gameObject.SetActive(false);
    }

        void OnCollisionEnter(Collision collision)
    {
        if (HP <= 0)
            return;

        if (collision.gameObject.CompareTag("Weapon"))
            HP -= 10.0f;
    }
}
