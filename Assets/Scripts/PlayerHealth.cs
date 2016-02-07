using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100.0f;	
	public float currentHealth = 0.0f;
	public Text health; 
	public GameObject HealthBar;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		health.text = "" + currentHealth;
		//health = GetComponent<Text> ();
		//health.text = "FUck you";
		//InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//health = GetComponent<Text> ();
		//health = GameObject.GetComponent<Text>();
		//health.text = "Hi" + currentHealth;
	}

	void decreaseHealth(){
		if (currentHealth > 0) {
			currentHealth -= 2f;
		}
		float calculcatedHealth = currentHealth / maxHealth;
		setHealthBar (calculcatedHealth);
	}	
	public void setHealthBar(float myHealth){
		//my health has to be between 0 and 1
		HealthBar.transform.localScale = new Vector2(myHealth, HealthBar.transform.localScale.y);
	}
}
