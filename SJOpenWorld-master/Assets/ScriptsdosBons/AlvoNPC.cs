using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoNPC : MonoBehaviour
{

    public Transform[] target;
    public float speed;
    public float damping = 6.0f;

    private int current;

    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector4 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
        else current = (current + 1) % target.Length;
    }

}
