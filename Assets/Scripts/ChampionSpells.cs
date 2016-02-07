using UnityEngine;
using System.Collections;

public class ChampionSpells : MonoBehaviour {
	public GameObject qProjectile;
	public bool isSpell1Active = false;
	public float spell1Range = 5;

	private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	}

	void activateSpell1() {
		isSpell1Active = true;
		this.GetComponent<championMovement>().mousePosition = transform.position;
	}

	void deactivateSpell1() {
		isSpell1Active = false;
	}

	void castSpell1() {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 castPos = new Vector2(mousePosition.x, mousePosition.y);
		Vector2 currentLocation = new Vector2(transform.position.x, transform.position.y);
		castPos = (castPos - currentLocation).normalized * spell1Range + currentLocation;

		qProjectile.GetComponent<straightSkillShot>().targetLocation = castPos;
		Instantiate(qProjectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
		deactivateSpell1();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Spell1")) {
			if(isSpell1Active == false) {
				activateSpell1();
			} else {
				deactivateSpell1();
			}
		}

		if(Input.GetMouseButtonDown(0)) {
			if(isSpell1Active == true) {
				castSpell1();
			}
		}

		if(Input.GetMouseButtonDown(1)) {
			if(isSpell1Active == true) {
				deactivateSpell1();
			}
		}
	}
}
