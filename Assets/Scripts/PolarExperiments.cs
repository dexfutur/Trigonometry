using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;
    [SerializeField] Transform bolita;
    [SerializeField] private float radialSpeed;
    [SerializeField] private float radialAceel;
    [SerializeField] private float AngularSpeed;
    [SerializeField] private float AngularAccel;
    [SerializeField] private Camera camara;

    private void Start()
    {
        Assert.IsNotNull(bolita, "bolita reference");
    }
    private void Update()
    {
        angleDeg += AngularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;
        if (Mathf.Abs(radius) > camara.orthographicSize)
        {
            radialSpeed *= -1;
            radius = Mathf.Sign(radius) * camara.orthographicSize;
        }
        bolita.position = PolarToCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, bolita.position, Color.red);
    }


    private Vector3 PolarToCartesian(float radius, float angle)
    {
      
         float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
         float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector3(x, y, 0);

    }

}
