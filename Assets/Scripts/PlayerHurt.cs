using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
    public static float HP = 100;
    public GameObject bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.GetComponent<Image>().fillAmount = HP / 100;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "10")
            HP -= 10;
    }
}
