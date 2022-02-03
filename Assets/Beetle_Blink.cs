using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beetle_Blink : MonoBehaviour
{
    [SerializeField] private float lerpTime = 30f;
    [SerializeField] private float blinkDuration = 4f;
    [SerializeField] Slider slider;
 
    private float t = 0f;
    private float bt = 0f;

    bool shouldBlink;

    private void Start()
    {
        shouldBlink = false;
        
    }

    private void Update()
    {
        BlinkFast();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag != "PlayerBullet") { return; }

        shouldBlink = true;
    }


    private void BlinkFast()
    {

        if (shouldBlink == false) { bt = 0; t = 0; ChangeColor(t); return; }
        t += Time.deltaTime / Time.deltaTime * slider.value / 100f;
        bt += Time.deltaTime / Time.deltaTime * slider.value / 100f;
        ChangeColor(t);

        if (t > 1) { t = 0; }
        //print("bt:" + bt);
        if (bt >= blinkDuration)
        {
            shouldBlink = false;
        }
    }

    private void ChangeColor(float t)
    {
        if (shouldBlink == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, t);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }


}

