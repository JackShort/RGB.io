using UnityEngine;
using System.Collections;

public class autoAttackMovement : MonoBehaviour {
	public Transform target;
	public float movementSpeed = 9f;

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
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y), movementSpeed * Time.deltaTime);
	}
}
