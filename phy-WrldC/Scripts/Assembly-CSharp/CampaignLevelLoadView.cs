using UnityEngine;
using UnityEngine.UI;

public class CampaignLevelLoadView : BaseGUIPanelView
{
	public const string LoadLevelEvent = "CampaignLevelLoadView.LoadLevelEvent";

	public const string BackEvent = "CampaignLevelLoadView.BackEvent";

	private GameObject emptyLevelTextPrefab;

	private GameObject levelLoadSlotPrefab;

	private GameObject levelListPanel;

	private Button backButton;

	private GridLayoutGroup gridLayoutGroup;

	private int levelSlotsPerColumn;

	public CampaignLevelLoadView(MainMenuView mainMenuView)
	{
		emptyLevelTextPrefab = mainMenuView.emptyLevelTextPrefab;
		levelLoadSlotPrefab = mainMenuView.levelLoadSlotPrefab;
		levelSlotsPerColumn = mainMenuView.LevelSlotsPerColumn;
		base.MainPanel = mainMenuView.mainPanel.transform.Find("CampaignLevelLoadPanel").gameObject;
		levelListPanel = base.MainPanel.transform.FindChildRecursively("LevelListPanel").gameObject;
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		gridLayoutGroup = levelListPanel.GetComponent<GridLayoutGroup>();
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("CampaignLevelLoadView.BackEvent");
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

	public void AddLevelLoadSlot(CampaignLevelModel campaignLevelModel)
	{
		GameObject gameObject = Util.InstantiateForGUI(levelLoadSlotPrefab, levelListPanel.transform, "LevelSlot_" + campaignLevelModel.LevelModel.GetId());
		Button component = gameObject.GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			NotifyChange("CampaignLevelLoadView.LoadLevelEvent", campaignLevelModel);
		});
		component.interactable = campaignLevelModel.IsLevelPlayable;
		LevelLoadSlotView component2 = gameObject.GetComponent<LevelLoadSlotView>();
		component2.mainPanel = gameObject;
		component2.Initialize();
		LevelLoadSlotStylesApplier component3 = gameObject.GetComponent<LevelLoadSlotStylesApplier>();
		if (component3 != null)
		{
			component3.BaseId = campaignLevelModel.LevelModel.Id;
		}
		new CampaignLevelSlotController(component2, campaignLevelModel);
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

	public void RefreshPanelSize(int levelsCount)
	{
		if (levelsCount >= levelSlotsPerColumn)
		{
			gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
			gridLayoutGroup.constraintCount = levelSlotsPerColumn;
		}
	}
}
