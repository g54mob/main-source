using UnityEngine;
using UnityEngine.UI;

public class SandboxLevelLoadView : BaseGUIPanelView
{
	public const string LoadLevelEvent = "SandboxLevelLoadView.LoadLevelEvent";

	public const string BackEvent = "SandboxLevelLoadView.BackEvent";

	private GameObject emptyLevelTextPrefab;

	private GameObject levelLoadSlotPrefab;

	private GameObject levelListPanel;

	private Button backButton;

	public SandboxLevelLoadView(MainMenuView mainMenuView)
	{
		emptyLevelTextPrefab = mainMenuView.emptyLevelTextPrefab;
		levelLoadSlotPrefab = mainMenuView.levelLoadSlotPrefab;
		base.MainPanel = mainMenuView.mainPanel.transform.Find("SandboxLevelLoadPanel").gameObject;
		levelListPanel = base.MainPanel.transform.FindChildRecursively("LevelListPanel").gameObject;
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("SandboxLevelLoadView.BackEvent");
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

	public void AddLevelLoadSlot(LevelModel levelModel, int levelNumber = 0)
	{
		GameObject gameObject = Util.InstantiateForGUI(levelLoadSlotPrefab, levelListPanel.transform, "LevelSlot_" + levelModel.GetId());
		Button component = gameObject.GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			NotifyChange("SandboxLevelLoadView.LoadLevelEvent", levelModel);
		});
		component.interactable = true;
		LevelLoadSlotView component2 = gameObject.GetComponent<LevelLoadSlotView>();
		component2.mainPanel = gameObject;
		component2.Initialize();
		component2.SetLevelIndex(levelNumber);
		LevelLoadSlotStylesApplier component3 = gameObject.GetComponent<LevelLoadSlotStylesApplier>();
		if (component3 != null)
		{
			component3.BaseId = levelModel.Id;
		}
		new SandboxLevelSlotController(component2, levelModel);
	}
}
