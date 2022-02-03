using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShoot : MonoBehaviour
{

    [SerializeField] ParticleSystem pSys;
    [SerializeField] GameObject pObj;
    [SerializeField] Transform gunPos;
    [SerializeField] GameObject pistolHUD;
    [SerializeField] GameObject machineGunHUD;
    [SerializeField] GameObject fireballHUD;

    Color pc;
    Color mg;
    Color fb;
    Color pc30 = new Color(1f,1f,1f, .3f);
    Color mg30 = new Color(1f, 1f, 1f, .3f);
    Color fb30 = new Color(1f, 1f, 1f, .3f);
    Color pc100 = new Color(1f, 1f, 1f, 1f);
    Color mg100 = new Color(1f, 1f, 1f, 1f);
    Color fb100 = new Color(1f, 1f, 1f, 1f);

    int gunSelect;

    // Start is called before the first frame update
    void Start()
    {
        gunSelect = 0 ;
        pSys.Play();

        pistolHUD.GetComponent<Image>().color =  new Color(1f, 1f, 1f, 1f);
        machineGunHUD.GetComponent<Image>().color = new Color(1f, 1f, 1f, .3f);
        fireballHUD.GetComponent<Image>().color = new Color(1f, 1f, 1f, .3f);

        pc = pc100;
        mg = mg30;
        fb = fb30;
    }

    // Update is called once per frame
    void Update()
    {
        GunSelection();
        Pistol();
        MachineGun();
        Fireball();
    }

    private void Pistol()
    {
        if (gunSelect != 1) { return; }
        fb = fb100;
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

    private void MachineGun()
    {
        if (gunSelect == 2)
        {
            if (Input.GetMouseButton(0))
            {
                pSys.emissionRate = 10f;
                pSys.Play();
            }
            if (Input.GetMouseButtonDown(0))
            {
                //nothing yet
            }
            if (Input.GetMouseButtonUp(0))
            {
                pSys.emissionRate = 1f;
                pSys.Stop();
            }

        }
    }

    private void Fireball()
    {
        print(gunSelect);
        if(gunSelect != 3) { return; }
        print("gun3");
        if (Input.GetMouseButtonDown(0))
        {
            pSys.emissionRate = 1f;
            pSys.Play();
            pSys.Emit(1);
        }
        if (Input.GetMouseButton(0))
        {
            // nothing yet
        }
        if (Input.GetMouseButtonUp(0))
        {
            pSys.emissionRate = 1f;
            pSys.Stop();
        }
    }

    private void GunSelection()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gunSelect++;
            print($"gunSelect {gunSelect}");
            if (gunSelect > 3)
            {
                gunSelect = 1;
            }
        }
    }
}
