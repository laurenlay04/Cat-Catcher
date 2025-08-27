using UnityEngine;

/* When player Touches a Pizza: It checks if it's the player, Adds score, Plays a sound
Shows particles, Destroys the pizza (either right away or after the sound ends) */


public class CollectibleItem : MonoBehaviour {

    public int scoreValue = 1; //Value of item
    public GameObject collectEffectPrefab; //drag particle prefab here in inspector
    public AudioClip collectSound;
    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>(); //finds audio
    }
    private void OnTriggerEnter2D(Collider2D other){// Called when something enters this object's trigger
    
        if(other.CompareTag("Player")) // Check if player is colliding
        {
    // Call a method on the GameController to update score (optional)
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {   
                gameController.AddScore(scoreValue);  // Update score
            }
           
            if(collectEffectPrefab != null){
                //spawn particles
                Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
            }
            if (collectSound != null && audioSource != null){
                //Chomp effect
                audioSource.PlayOneShot(collectSound);  
                
                // Disable visual and physical components
                GetComponent<SpriteRenderer>().enabled = false; //hides pizza
                GetComponent<Collider2D>().enabled = false; //stops future collisions
                GetComponent<Rigidbody2D>().simulated = false; //stops movement/gravity

                Destroy(gameObject, collectSound.length);  // Destroys this object AFTER the sound has played
            } else{
    //Fallback if sound is not intiated
            Destroy(gameObject); //removes
            }
        }

    }
}