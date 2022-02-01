using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] ParticleSystem pSys;
    [SerializeField] GameObject pObj;
    [SerializeField] Transform gunPos;

    int gunSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        pSys.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GunSelection();
        Pistol();
        MachineGun();
    }

    private void Pistol()
    {
        if (gunSelect == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pSys.Play();
                pSys.Emit(1);
            }
            if (Input.GetMouseButton(0))
            {
                //nothing yet.
            }
            if (Input.GetMouseButtonUp(0))
            {
                pSys.emissionRate = 1f;
                pSys.Stop();
            }

        }
    }

    private void MachineGun()
    {
        if (gunSelect == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pSys.Play();
                pSys.Emit(1);
            }
            if (Input.GetMouseButton(0))
            {
                pSys.Play();
                pSys.emissionRate = 10f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                pSys.emissionRate = 1f;
                pSys.Stop();
            }

        }
    }

    private void GunSelection()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gunSelect++;
            print($"gunSelect {gunSelect}");
            if (gunSelect > 2)
            {
                gunSelect = 0;
            }
        }
    }
}
