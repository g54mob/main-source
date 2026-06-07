using UnityEngine;
using UnityEngine.UI;

public class AttackerLevelLoadView : BaseGUIPanelView
{
	public const string LoadLevelEvent = "AtackerLevelLoadView.LoadLevelEvent";

	public const string BackEvent = "AtackerLevelLoadView.BackEvent";

	private GameObject emptyLevelTextPrefab;

	private GameObject levelLoadSlotPrefab;

	private GameObject levelListPanel;

	private Button backButton;

	public AttackerLevelLoadView(MainMenuView mainMenuView)
	{
		emptyLevelTextPrefab = mainMenuView.emptyLevelTextPrefab;
		levelLoadSlotPrefab = mainMenuView.levelLoadSlotPrefab;
		base.MainPanel = mainMenuView.mainPanel.transform.Find("AttackerLevelLoadPanel").gameObject;
		levelListPanel = base.MainPanel.transform.FindChildRecursively("LevelListPanel").gameObject;
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("AtackerLevelLoadView.BackEvent");
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
			NotifyChange("AtackerLevelLoadView.LoadLevelEvent", levelModel);
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
