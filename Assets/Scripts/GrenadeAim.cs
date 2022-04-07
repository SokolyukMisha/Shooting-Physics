using System.Collections.Generic;
using UnityEngine;

public class GrenadeAim : MonoBehaviour
{
    [SerializeField] int numPoints = 50;
    [SerializeField] float timeBetweenPoints = 0.1f;

    LineRenderer lineRenderer;
    GrenadeShoot grenadeShoot;   
    LayerMask CollidableLayers;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        grenadeShoot = GetComponent<GrenadeShoot>();      
    }


    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Aiming();
        }
        else
        {
            lineRenderer.SetVertexCount(0);
        }
}

    private void Aiming()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = grenadeShoot.shootPoint.transform.position;
        Vector3 startingVelocity = grenadeShoot.shootPoint.transform.up * grenadeShoot.blastPower;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}

