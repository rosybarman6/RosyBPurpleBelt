using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    [Header("Explosion Parts")]
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("explosion");
        GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);
        Debug.Log(explosionObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
