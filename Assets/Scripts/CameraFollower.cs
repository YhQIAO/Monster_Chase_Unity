using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform plaryer;
    private Vector3 tempops;

    [SerializeField]
    private float minX = -60, maxX = 60;

    // Start is called before the first frame update
    void Start()
    {
        plaryer = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void LateUpdate()
    {
        if(plaryer == null)
        {
            return;
        }

        tempops = transform.position;
        tempops.x = plaryer.position.x;

        if(tempops.x > maxX)
        {
            tempops.x = maxX;
        }
        if(tempops.x < minX)
        {
            tempops.x = minX;
        }
        transform.position = tempops;
    }
}
