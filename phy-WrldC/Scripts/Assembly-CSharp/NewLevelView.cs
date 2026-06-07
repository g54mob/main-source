using UnityEngine;
using UnityEngine.UI;

public class NewLevelView : BaseGUIPanelView
{
	public const string CreateLevelEvent = "NewLevelView.CreateLevelEvent";

	public const string BackEvent = "NewLevelView.BackEvent";

	private GameObject levelTemplateSlotPrefab;

	private GameObject levelTemplateListPanel;

	private ToggleGroup levelTemplateListToggleGroup;

	private InputField levelNameInput;

	private InputField levelDescriptionInput;

	private Button createButton;

	private Button backButton;

	private LevelModel templateLevelModel;

	private string levelName;

	private string levelDescription;

	public NewLevelView(MainMenuView mainMenuView)
	{
		base.MainPanel = mainMenuView.mainPanel.transform.Find("NewLevelPanel").gameObject;
		levelTemplateListPanel = base.MainPanel.transform.Find("LevelTemplateListPanel").gameObject;
		levelTemplateListToggleGroup = levelTemplateListPanel.GetComponent<ToggleGroup>();
		levelNameInput = base.MainPanel.transform.FindComponent<InputField>("LevelNameInput", isRecursively: true);
		levelDescriptionInput = base.MainPanel.transform.FindComponent<InputField>("LevelDescriptionInput", isRecursively: true);
		createButton = base.MainPanel.transform.FindComponent<Button>("CreateButton", isRecursively: true);
		backButton = base.MainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		levelTemplateSlotPrefab = mainMenuView.levelTemplateSlotPrefab;
		levelNameInput.onEndEdit.AddListener(delegate(string name)
		{
			levelName = name;
		});
		levelDescriptionInput.onEndEdit.AddListener(delegate(string description)
		{
			levelDescription = description;
		});
		createButton.onClick.AddListener(CreateLevelHandler);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("NewLevelView.BackEvent");
		});
	}

	public void RemoveAllLevelTemplatSlots()
	{
		levelTemplateListPanel.transform.RemoveAllChildren();
	}

	public void AddLevelTemplateSlot(LevelModel templateLevelModel)
	{
		GameObject gameObject = Util.InstantiateForGUI(levelTemplateSlotPrefab, levelTemplateListPanel.transform, "LevelTemplateSlot_" + templateLevelModel.Name);
		Toggle component = gameObject.GetComponent<Toggle>();
		component.group = levelTemplateListToggleGroup;
		component.onValueChanged.AddListener(delegate(bool isOn)
		{
			SlotToggleHandler(isOn, templateLevelModel);
		});
		gameObject.GetComponentInChildren<Text>(includeInactive: true).text = templateLevelModel.Name;
	}

	private void SlotToggleHandler(bool isOn, LevelModel templateLevelModel)
	{
		if (isOn)
		{
			this.templateLevelModel = templateLevelModel;
		}
	}

	private void CreateLevelHandler()
	{
		if (templateLevelModel != null && !string.IsNullOrEmpty(levelName))
		{
			LevelModel levelModel = LevelModelBuilder.Clone(templateLevelModel, shouldGiveNewId: true);
			levelModel.Name = levelName;
			levelModel.Description = levelDescription;
			levelNameInput.text = "";
			levelDescriptionInput.text = "";
			NotifyChange("NewLevelView.CreateLevelEvent", levelModel);
		}
	}
}
