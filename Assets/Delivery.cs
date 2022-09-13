using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] float destroyDelay = 1.0f;

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Auch");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            this.spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            this.spriteRenderer.color = noPackageColor;
        }
    }
}
