using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	[SerializeField] private float timeBetweenAttacks;
	[SerializeField] private float attackRadius;

	private Projectile projectile;
	private Enemy targetEnemy = null;
	private float attackCounter = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
}	// End of Tower() Class
