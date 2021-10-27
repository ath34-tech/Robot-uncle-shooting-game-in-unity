using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrbBehaviour : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 25.2f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.layer == LayerMask.NameToLayer("enemies"))
        {
            Destroy(this.gameObject);
        }

    }
}
