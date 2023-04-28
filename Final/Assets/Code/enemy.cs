using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.posotion) < 10)
        {
            Vector3 direction = player.position - this.transform.positiion;
            this.transform.rotation = Quanternion.Slerp(this.transform.rotation, Quanternion.LookRoration(direction), 0.1f);
            if (direction.manitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
    }
}
