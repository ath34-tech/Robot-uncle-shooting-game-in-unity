using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public GameObject explosion;
    public UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("lives").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);

        if (transform.position.x < -25f)
        {
            float randomYPos = Random.Range(-7f, 7f);
            transform.position = new Vector3(25f, randomYPos, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D damagingMaterials)
    {
        if(damagingMaterials.gameObject.layer== LayerMask.NameToLayer("player"))
        {
            if (damagingMaterials.gameObject.tag == "player")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                if (health == 10)
                {
                    _uiManager.UpdateScore(10);
                    Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    health -= 10;
                }
            }
        }

    }

}
