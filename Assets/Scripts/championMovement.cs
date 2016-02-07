using UnityEngine;
using System.Collections;

public class championMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public float range = 5f;
	private Vector3 mousePosition;
	private bool needsToMove = false;
	private Transform transformToMoveTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), new Vector2(0, 0));

			if(hit.collider != null) {
				float distance = Vector2.Distance(transform.position, hit.transform.position);
				Debug.Log(Vector2.Distance(transform.position, hit.transform.position));
				if(distance > range) {
					needsToMove = true;
					transformToMoveTo = hit.transform;
					mousePosition = hit.transform.position;
				} else {
					mousePosition = transform.position;
				}
			}
		}

		if((transform.position.x != mousePosition.x) && (transform.position.y != mousePosition.y)) {
			if(needsToMove == true) {
				Debug.Log(Vector2.Distance(transform.position, transformToMoveTo.position));
				if(Vector2.Distance(transform.position, transformToMoveTo.position) <= 5) {
					mousePosition = transform.position;
					needsToMove = false;
				}
			}

			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(mousePosition.x, mousePosition.y), moveSpeed * Time.deltaTime);
		}
	}
}