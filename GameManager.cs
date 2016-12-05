using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	// Public variables
	[SerializeField] private GameObject spawnPoint;
	[SerializeField] private GameObject[] enemies;
	[SerializeField] private int maxEnemiesOnScreen;
	[SerializeField] private int totalEnemies;
	[SerializeField] private int enemiesPerSpawn;

	// Private Variables
	private int enemiesOnScreen = 0;
	
	const float spawnDelay = 0.5f;


	// Use this for initialization
	void Start () {
		StartCoroutine(spawn()); // begin spawning enemies
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawn() {
		if(enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
			for(int i = 0; i < enemiesPerSpawn; i++) {
				if(enemiesOnScreen < maxEnemiesOnScreen) {
					GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen++;
				}
			}
			yield return new WaitForSeconds(spawnDelay);
			StartCoroutine(spawn());
		}
	}

	public void removeEnemyFromScreen() {
		if(enemiesOnScreen > 0) {
			enemiesOnScreen -= 1;
		}
	} // End removeEnemyFromScreen()

} // End of GameManager() Class
