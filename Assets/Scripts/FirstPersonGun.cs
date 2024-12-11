using UnityEngine;

    public class FirstPersonGun : MonoBehaviour
    {
        Camera cam; 
        Ray ray; 
        RaycastHit hit; 
        Vector3 Hitpoint = Vector3.zero;
        GameManager gameManager;

        AudioSource audioSource; 

        public AudioClip gunSound;

        public AudioClip missSound;
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main; 
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            audioSource = gameObject.GetComponent<AudioSource>();

        }

        // Update is called once per frame
        void Update()
        {
            
            // Handle shooting input (e.g., left mouse button or another configured button)
            if (Input.GetButtonDown("Fire1") && gameManager.canShoot) // Fire1 is typically mapped to the left mouse button
            {
                
                if(cam) {
                    ray = cam.ScreenPointToRay(Input.mousePosition);
                    
                    if(Physics.Raycast(ray, out hit)) {
                        GameObject hitItem = hit.collider.gameObject;
                        gameManager.SetAmmo();
                        audioSource.PlayOneShot(gunSound, 1.0f); 
                        if(hitItem.tag == "bottle") {
                            Bottle bottleScript = hitItem.GetComponent<Bottle>();
                            if(bottleScript != null) {
                                bottleScript.Explode();
                                gameManager.destroyedBottle();
                            }
                        }
                        else if(hitItem.tag == "lossItem") {
                            gameManager.destroyedLossItem();
                        }
                        else {
                            audioSource.PlayOneShot(missSound, 1.0f);
                        }
                    }
                }
            }
        }

    }
