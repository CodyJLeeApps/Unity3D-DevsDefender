using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : Singleton<TowerManager> {

	private TowerBtn towerBtnPressed;
	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start () {
		
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			if(hit.collider.tag == "buildsite") {
				hit.collider.tag = "buildsiteFull";
				PlaceTower(hit);
			}
		}
		if(spriteRenderer.enabled) {
			FollowMouse();
		}
	}

	// SelectedTower is called when the tower buttons are pressed.
	// The selected tower is passed into this function.
	public void SelectedTower(TowerBtn towerSelected) {
		towerBtnPressed = towerSelected;
		EnableDragSprite(towerBtnPressed.DragSprite);
	}

	// PlaceTower allows the placement of a tower after the user presses
	// the tower button, the user will see the Sprite dragging as the mouse moves.
	public void PlaceTower(RaycastHit2D hit) {
		if( !EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null ) {
			GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
			newTower.transform.position = hit.transform.position;
			DisableDragSprite();
		}

	} // End PlaceTower()

	public void EnableDragSprite(Sprite sprite) {
		spriteRenderer.enabled = true;
		spriteRenderer.sprite = sprite; // set the sprite you passed in to the sprite being dragged.
	}

	public void DisableDragSprite() {
		spriteRenderer.enabled = false;
	}

	// handles the sprites being attached to the cursor movement.
	public void FollowMouse() {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector2(transform.position.x, transform.position.y);
	}

}
