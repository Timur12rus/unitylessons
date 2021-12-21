using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 3.0f;
    public Transform target;   // за этим будет следить камера
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;
        // Lerp() плавно уменьшает расстояние между объектами
        transform.position = Vector3.Lerp(transform.position, position,speed * Time.deltaTime);  
    }
}
