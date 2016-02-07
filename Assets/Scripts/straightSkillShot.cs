using UnityEngine;
using System.Collections;

public class straightSkillShot : MonoBehaviour {

	public float movementSpeed = 8f;
	public Vector2 targetLocation;

	// Use this for initialization
	void Start () {
	
	}

	void damageTarget() {
		Debug.Log("BOOM!!!!");
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
//			coll.gameObject.SendMessage("ApplyDamage", 10);
			damageTarget();

	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetLocation, movementSpeed * Time.deltaTime);

		if(transform.position.x == targetLocation.x && transform.position.y == targetLocation.y) {
			Destroy(this.gameObject);
		}
	}
}
