using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoc : MonoBehaviour
{
    // Start is called before the first frame update
    public int volta=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
		volta+=1;
        print("Voltas: "+volta);
        //GameObject.Destroy(collider);//N quebra nd n vlw flw


    }
}
