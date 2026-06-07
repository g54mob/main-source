using UnityEngine;
using UnityEngine.UI;

public class DefenderLevelLoadView : BaseGUIPanelView
{
	public const string LoadLevelEvent = "DefenderLevelLoadView.LoadLevelEvent";

	public const string DeleteLevelEvent = "DefenderLevelLoadView.DeleteLevelEvent";

	public const string NewLevelEvent = "DefenderLevelLoadView.NewLevelEvent";

	public const string BackEvent = "DefenderLevelLoadView.BackEvent";

	private GameObject emptyLevelTextPrefab;

	private GameObject levelLoadSlotPrefab;

	private GameObject levelListPanel;

	private Button newLevelButton;

	private Button backButton;

	public DefenderLevelLoadView(MainMenuView mainMenuView)
	{
		emptyLevelTextPrefab = mainMenuView.emptyLevelTextPrefab;
		levelLoadSlotPrefab = mainMenuView.levelLoadSlotPrefab;
		base.MainPanel = mainMenuView.mainPanel.transform.Find("DefenderLevelLoadPanel").gameObject;
		levelListPanel = base.MainPanel.transform.FindChildRecursively("LevelListPanel").gameObject;
		newLevelButton = base.MainPanel.transform.FindComponent<Button>("NewLevelButton", isRecursively: true);
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		newLevelButton.onClick.AddListener(delegate
		{
			NotifyChange("DefenderLevelLoadView.NewLevelEvent");
		});
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("DefenderLevelLoadView.BackEvent");
		});
	}

	public void RemoveAllLevelLoadSlots()
	{
		levelListPanel.transform.RemoveAllChildren();
	}

	public void AddEmptyLevelSlot()
	{
		Util.InstantiateForGUI(emptyLevelTextPrefab, levelListPanel.transform, "EmptyLevelText");
	}

	public void AddLevelLoadSlot(LevelModel levelModel)
	{
		GameObject gameObject = Util.InstantiateForGUI(levelLoadSlotPrefab, levelListPanel.transform, "LevelSlot_" + levelModel.GetId());
		gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			NotifyChange("DefenderLevelLoadView.LoadLevelEvent", levelModel);
		});
		Button button = gameObject.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		button.gameObject.SetActive(value: true);
		button.onClick.AddListener(delegate
		{
			NotifyChange("DefenderLevelLoadView.DeleteLevelEvent", levelModel);
		});
		LevelLoadSlotView levelLoadSlotView = gameObject.AddComponent<LevelLoadSlotView>();
		levelLoadSlotView.mainPanel = gameObject;
		levelLoadSlotView.Initialize();
		new LevelLoadSlotController(levelLoadSlotView, levelModel);
	}

	public void RemoveLevelLoadSlot(string levelModelId)
	{
		GameObject gameObject = null;
		foreach (Transform item in levelListPanel.transform)
		{
			string text = item.gameObject.name.Replace("LevelSlot_", "");
			if (levelModelId == text)
			{
				gameObject = item.gameObject;
				break;
			}
		}
		if (gameObject != null)
		{
			Object.Destroy(gameObject);
		}
	}
}
