using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public LineRenderer lineRenderer;

    private Vector2 dragStartPos;
    private bool isDragging = false;

    void Update()
    {
        HandleShooting();
        UpdateLineRenderer();
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Shoot();
            isDragging = false;
        }
    }

    void Shoot()
    {
        Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootingDirection = (dragEndPos - dragStartPos).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = shootingDirection * projectile.GetComponent<Projectile>().speed;
    }

    void UpdateLineRenderer()
    {
        if (isDragging)
        {
            Vector2 dragCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, dragCurrentPos);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position);
        }
    }
}
