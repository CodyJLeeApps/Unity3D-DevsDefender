using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private Transform exitPoint;
	[SerializeField] private Transform[] wayPoints;
	[SerializeField] private float navigationUpdate;

	private int target = 0;
	private Transform enemy;
	private float navigationTime = 0f;

	// Use this for initialization
	void Start () {
		
		enemy = GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () {

		if(wayPoints != null) {
			
			navigationTime += Time.deltaTime;
			if(navigationTime > navigationUpdate) {
				
				if(target < wayPoints.Length) {
					enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
				} else {
					enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
				}
				navigationTime = 0f;

			} // End if navigationTime < navigationUpdate

		} // End if wayPoints != null
	
	} // End Update()

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.tag == "checkpoint") {
			target += 1;
		} else if(other.tag == "Finish") {
			GameManager.Instance.removeEnemyFromScreen();
			Destroy(gameObject);
		}

	} // End onTriggerEnter2D

} // End Enemy Class
