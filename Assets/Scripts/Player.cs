using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed;
    public GameObject OrbBullet;
    public float cooldown;
    public float timeStamp;
    public float health;
    public GameObject explosion;
    public UIManager _uiManager;
    public int lives = 3;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-11, 0.26f, 0);
        _uiManager = GameObject.Find("lives").GetComponent<UIManager>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (timeStamp <= Time.time) { 
            Shoot();
    }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audio.Play();
            Instantiate(OrbBullet, transform.position+new Vector3(1.8f,0,0), Quaternion.identity);
            timeStamp = Time.time + cooldown;
        }
    }
    void Movement()
    {
        float VerticalDirection = Input.GetAxis("Vertical");
        float HorizontalDirection = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * speed * VerticalDirection * Time.deltaTime);
        transform.Translate(Vector3.right * speed * HorizontalDirection * Time.deltaTime);

       
            if (transform.position.y > 5.42f)
            {
                transform.position = new Vector3(transform.position.x, 5.42f, 0);
            }
            else if (transform.position.y < -6f)
            {
                transform.position = new Vector3(transform.position.x, -6f, 0);
            }
            else if (transform.position.x < -13.52f)
            {
                transform.position = new Vector3(-13.52f, transform.position.y, 0);
            }
            else if (transform.position.x > -6f)
            {
                transform.position = new Vector3(-6f, transform.position.y, 0);
            }
    }
    void OnTriggerEnter2D(Collider2D damagingMaterials)
    {
       if(damagingMaterials.gameObject.layer == LayerMask.NameToLayer("enemies"))
        {
            if (lives == 1)
            {
                _uiManager.UpdateLives(0);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                lives -= 1;
                _uiManager.UpdateLives(lives);
            }
        }
    }

}
