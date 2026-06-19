using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
	[SerializeField]
	private UpgradeTreeUI _upgradeTree;

	[SerializeField]
	private BlueprintsMenu _uiBlueprints;

	[SerializeField]
	private GameHUD _gameHUD;

	[SerializeField]
	private ClickGroveDevConsoleUI _devConsoleUI;

	[SerializeField]
	private PauseMenu _pauseMenu;

	[SerializeField]
	private TrackingHUD _trackingHUD;

	[SerializeField]
	private InventoryUIController _inventoryUI;

	[SerializeField]
	private DialogueInterface _dialogueInterface;

	[SerializeField]
	private ItemBook _itemBook;

	[SerializeField]
	private GameCanvasRaycastBlocker _raycastBlocker;

	[SerializeField]
	private TutorialBoxHUD _tutorialBoxHUD;

	public void Initiate()
	{
	}
}
