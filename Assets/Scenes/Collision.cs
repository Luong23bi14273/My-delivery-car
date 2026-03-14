using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touching");
    }


    int packageCount = 0;
    [SerializeField] float maxPackage = 3;
    [SerializeField] float timeDisapear = 0.5f;
    [SerializeField] Color32 haspackagecolor = new Color32(1,1,1,1);
    [SerializeField] Color32 hasnopackagecolor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && packageCount < maxPackage)
        {
            packageCount++;
            Debug.Log("Đã nhận gói hàng"+packageCount);
            spriteRenderer.color = haspackagecolor;
            Destroy(collision.gameObject, timeDisapear);
        }

        if (collision.tag == "Goal" && packageCount > 0)
        {
            Debug.Log("Đã đến vị trí");
            spriteRenderer.color = hasnopackagecolor;
            packageCount = 0;

        }
    }
}
