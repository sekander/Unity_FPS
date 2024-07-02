using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{

    public GameObject bulletSpawn;
    public float range = 100f;

    public float cursorOffset = 0f;

   // [SerializeField]
   // public GameObject spawnPoint;
   // [SerializeField] GameObject bullet;
   // [SerializeField] float projectileSpeed = 10.0f;
   // [SerializeField] float projectileRate = 1.0f;
    Vector3 raycastOrigin;



    [Header("Enemy Effects")]
    [SerializeField] GameObject shootVFX;
    [SerializeField] float durationVFX = 1.0f;
    //[SerializeField] AudioClip deathSFX;
    //[SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
    //[SerializeField] AudioClip shootSFX;
    //[SerializeField] [Range(0, 1)] float shootSFXVolume = 0.7f;


    //Vector3 spawnVFX;

    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = bulletSpawn.transform.position;
        //spawnPoint = new Vector3(spawnPoint.x + cursorOffset, spawnPoint.y, spawnPoint.z);

    }

    // Update is called once per frame
    void Update()
    {
        //spawnPoint = Camera.main.transform.position;
        //spawnPoint = Input.mousePosition;

        //spawnVFX = new Vector3(transform.position.x,
        //                       transform.position.y,
        //                       transform.position.z + 1.0f);
        
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //Debug.Log("Mouse Pos: " + spawnPoint);
        raycastOrigin = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f)); 

        // Create a vector at the center of our camera's viewport
        Vector3 lineOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Draw a line in the Scene View  from the point lineOrigin in the direction of fpsCam.transform.forward * weaponRange, using the color green
        Debug.DrawRay(lineOrigin, Camera.main.transform.forward * range, Color.green);
    }

    void Shoot(){

            //Create death effect
        GameObject shooting = Instantiate(shootVFX, 
                                          bulletSpawn.transform.position,
                                          Quaternion.identity);
        Destroy(shooting, durationVFX);



        RaycastHit hit;

        //GameObject bulletOBJ = Instantiate(bullet, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y
        //                                , spawnPoint.transform.position.z + 1.0f), Quaternion.identity) as GameObject;
        //    bulletOBJ.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, projectileSpeed);



        
        if(Physics.Raycast(raycastOrigin, transform.forward, out hit, range))
        {
            Debug.Log("Hit");
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

            if(enemyManager != null)
            {
                enemyManager.Hit(25.0f);
            }
        }
        

    }
}
