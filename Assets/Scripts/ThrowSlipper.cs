//using UnityEngine;
//using DG.Tweening;
//using DG;

//public class TerlikFirlatma : MonoBehaviour
//{
//    public GameObject terlikPrefab; // Fýrlatýlacak terlik objesi
//    public Transform kol; // Kolun olduðu boþ nesne
//    public Transform hedef; // Çocuðun olduðu hedef nesne
//    public float firlatmaGucu = 5f; // Terliðin fýrlatma hýzý

//    private bool terlikFirlatildi = false;

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            FirlatTerlik();
//        }
//    }

//    private void FirlatTerlik()
//    {
//        GameObject terlik = Instantiate(terlikPrefab, kol.position, Quaternion.identity);
//        Rigidbody rb = terlik.GetComponent<Rigidbody>();

//        Vector3 firlatmaYonu = (hedef.position - kol.position).normalized;
//        rb.transform.DOJump(hedef.position, 1, 1, 1).SetEase(Ease.InCubic);
//    }
//}

using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject firePoint; // The point where the projectile will be spawned
    public GameObject projectilePrefab; // The projectile prefab

    public float projectileForce = 20f; // The force applied to the projectile

    // Update is called once per frame
    void Update()
    {
        // Check if the fire button is pressed (e.g., left mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // Call the Shoot method
        }
    }

    void Shoot()
    {
        // Create a new projectile at the firePoint position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component exists
        if (rb != null)
        {
            // Apply force to the projectile in the direction of its forward vector
            rb.AddForce(firePoint.transform.right * projectileForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Projectile prefab does not have a Rigidbody2D component.");
        }
    }
}
