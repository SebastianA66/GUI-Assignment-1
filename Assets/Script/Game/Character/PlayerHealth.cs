using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.

    

    public AudioSource audioSource;

    public Text timeText;

    public GameObject gameOver;
                                            
    
    CharacterController playerMovement;                         
                             
    
    
   
    
}