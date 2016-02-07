using UnityEngine;
using System.Collections;

public class championMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public float range = 5f;
	public float autoAttackCooldown = 1.5f;
	public GameObject projectile;

	public Vector3 mousePosition;
	private bool needsToMove = false;
	private Transform transformToMoveTo;
	private float autoAttackTimer;
	private bool shouldAutoAttack = false;

	// Use this for initialization
	void Start () {
		autoAttackTimer = autoAttackCooldown;
	}

	void autoAttack() {
		projectile.GetComponent<autoAttackMovement>().target = transformToMoveTo;
		Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

			//for clicking on enemies
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), new Vector2(0, 0));

			if((hit.collider != null) && (hit.collider.name != "player")) {
				float distance = Vector2.Distance(transform.position, hit.transform.position);
				if(distance > range) {
					needsToMove = true;
					transformToMoveTo = hit.transform;
					mousePosition = hit.transform.position;
					shouldAutoAttack = true;
				} else {
					transformToMoveTo = hit.transform;
					mousePosition = transform.position;
					shouldAutoAttack = true;
				}
			} else {
				shouldAutoAttack = false;
			}
		}

		if((transform.position.x != mousePosition.x) && (transform.position.y != mousePosition.y)) {
			if(needsToMove == true) {       //moves to auto attack range
				if(Vector2.Distance(transform.position, transformToMoveTo.position) <= 5) {
					mousePosition = transform.position;
					needsToMove = false;
				}
			}
					//moves to mouse position
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(mousePosition.x, mousePosition.y), moveSpeed * Time.deltaTime);
		}

		//auto attack nonsense
		if(shouldAutoAttack == true) {
			if(autoAttackTimer == autoAttackCooldown) {
				autoAttack();
				autoAttackTimer -= Time.deltaTime;
			}
		}

		if ((autoAttackTimer > 0) && (autoAttackTimer != autoAttackCooldown)) {
				autoAttackTimer -= Time.deltaTime;
		} else {
				autoAttackTimer = autoAttackCooldown;
		}
	}
}