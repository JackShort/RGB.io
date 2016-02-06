using UnityEngine;
using System.Collections;

public class championMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		}

		if((transform.position.x != mousePosition.x) && (transform.position.y != mousePosition.y)) {
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(mousePosition.x, mousePosition.y), moveSpeed * Time.deltaTime);
		}
	}
}