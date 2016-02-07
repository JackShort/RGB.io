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

	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y), movementSpeed * Time.deltaTime);
		if(transform.position == target.position) {
			damageTarget();
		}
	}
}
