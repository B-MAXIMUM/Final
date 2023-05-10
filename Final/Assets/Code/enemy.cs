using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public bool GetEmBoys = false;
    public static enemy enemyS;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyS = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 15)
        {
            Vector3 direction = player.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude > 0.5f)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
    }
}
