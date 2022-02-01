using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] ParticleSystem pSys;
    [SerializeField] GameObject pObj;
    [SerializeField] Transform gunPos;

    // Start is called before the first frame update
    void Start()
    {
        pSys.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pSys.Emit(1);
        }
        if(Input.GetMouseButton(0))
        {
            pSys.Play();
            pSys.emissionRate = 10f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pSys.Stop();
        }
    }
}
