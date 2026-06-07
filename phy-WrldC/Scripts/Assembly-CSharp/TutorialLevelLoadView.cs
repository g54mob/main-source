using UnityEngine;
using UnityEngine.UI;

public class TutorialLevelLoadView : BaseGUIPanelView
{
	public const string LoadLevelEvent = "TutorialLevelLoadView.LoadLevelEvent";

	public const string BackEvent = "TutorialLevelLoadView.BackEvent";

	private GameObject emptyLevelTextPrefab;

	private GameObject levelLoadSlotPrefab;

	private GameObject levelListPanel;

	private Button backButton;

	public TutorialLevelLoadView(MainMenuView mainMenuView)
	{
		emptyLevelTextPrefab = mainMenuView.emptyLevelTextPrefab;
		levelLoadSlotPrefab = mainMenuView.levelLoadSlotPrefab;
		base.MainPanel = mainMenuView.mainPanel.transform.Find("TutorialLevelLoadPanel").gameObject;
		levelListPanel = base.MainPanel.transform.FindChildRecursively("LevelListPanel").gameObject;
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("TutorialLevelLoadView.BackEvent");
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
			NotifyChange("TutorialLevelLoadView.LoadLevelEvent", campaignLevelModel);
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
}
