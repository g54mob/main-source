using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreationInfosView : BaseGUIPanelView
{
	public const string CheatsChangedEvent = "LevelCreationInfosView.CheatsChangedEvent";

	public const string DelimitationChangedEvent = "LevelCreationInfosView.DelimitationChangedEvent";

	public const string CloseEvent = "LevelCreationInfosView.CloseEvent";

	private TextMeshProUGUI groupText;

	private TextMeshProUGUI nameText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI blocksText;

	private TextMeshProUGUI costText;

	private TextMeshProUGUI weightText;

	private GameObject cheatPanel;

	private Toggle unbreakableToggle;

	private Toggle unlimitedAmmoToggle;

	private Toggle delimitationToggle;

	private GameObject restrictedBlocksPanel;

	private GameObject restrictedBlocksListPanel;

	private Button restrictedHideButton;

	private TextMeshProUGUI restrictedHideButtonText;

	private Button closeButton;

	private DraggableWindow draggableWindow;

	private GameObject restrictedBlockSlotPrefab;

	public TopButtonsView TopButtonsView { get; private set; }

	public LevelCreationInfosView(TopButtonsView topButtonsView, GameObject restrictedBlockSlotPrefab)
	{
		TopButtonsView = topButtonsView;
		this.restrictedBlockSlotPrefab = restrictedBlockSlotPrefab;
		base.MainPanel = topButtonsView.mainPanel.transform.FindChildRecursively("LevelCreationInfosWindow").gameObject;
		groupText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("GroupText", isRecursively: true);
		nameText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		bestTimeText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		blocksText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("BlocksText", isRecursively: true);
		costText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("CostText", isRecursively: true);
		weightText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("WeightText", isRecursively: true);
		closeButton = base.MainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		cheatPanel = base.MainPanel.transform.FindChildRecursively("CheatPanel").gameObject;
		unbreakableToggle = cheatPanel.transform.FindComponent<Toggle>("UnbreakableToggle", isRecursively: true);
		unlimitedAmmoToggle = cheatPanel.transform.FindComponent<Toggle>("UnlimitedAmmoToggle", isRecursively: true);
		delimitationToggle = cheatPanel.transform.FindComponent<Toggle>("DelimitationToggle", isRecursively: true);
		restrictedBlocksPanel = base.MainPanel.transform.FindChildRecursively("RestrictedBlocksPanel").gameObject;
		restrictedBlocksListPanel = restrictedBlocksPanel.transform.FindChildRecursively("RestrictedBlocksListPanel").gameObject;
		restrictedHideButton = restrictedBlocksPanel.transform.FindComponent<Button>("RestrictedHideButton", isRecursively: true);
		restrictedHideButtonText = restrictedHideButton.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		draggableWindow = base.MainPanel.GetComponent<DraggableWindow>();
		draggableWindow.SaveWindowPosition();
		unbreakableToggle.onValueChanged.AddListener(delegate
		{
			NotifyChange("LevelCreationInfosView.CheatsChangedEvent");
		});
		unlimitedAmmoToggle.onValueChanged.AddListener(delegate
		{
			NotifyChange("LevelCreationInfosView.CheatsChangedEvent");
		});
		delimitationToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelCreationInfosView.DelimitationChangedEvent", isOn);
		});
		restrictedHideButton.onClick.AddListener(RestrictedHideButtonHandler);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCreationInfosView.CloseEvent");
		});
	}

	private void RestrictedHideButtonHandler()
	{
		restrictedBlocksListPanel.SetActive(!restrictedBlocksListPanel.activeSelf);
		restrictedHideButtonText.SetText(restrictedBlocksListPanel.activeSelf ? "\uf056" : "\uf055");
	}

	public void SetLevelInfosValues(string group, string name)
	{
		SetGroupName(group);
		SetLevelName(name);
	}

	public void SetGroupName(string groupName)
	{
		if (!string.IsNullOrEmpty(groupName))
		{
			groupText.gameObject.SetActive(value: true);
			groupText.SetText(groupName);
		}
		else
		{
			groupText.gameObject.SetActive(value: false);
		}
	}

	public void SetLevelName(string name)
	{
		nameText.SetText(name);
	}

	public void SetBestTime(float bestTime)
	{
		bestTimeText.SetText(Util.TimeParser(bestTime));
		bestTimeText.alignment = TextAlignmentOptions.Center;
	}

	public void SetBestTimes(LevelStatus.RecordsValues lowestTimeRecords)
	{
		string text = "<color=#F7EC3D>\uf005</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.BothStarValue);
		string text2 = "<color=#F7EC3D>\uf005</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.GoldStarValue);
		string text3 = "<color=#F7EC3D4D>\uf006</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.SilverStarValue);
		string text4 = "<color=#F7EC3D4D>\uf006</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.NoneStarValue);
		bestTimeText.SetText(text + "\n" + text2 + "\n" + text3 + "\n" + text4);
		bestTimeText.alignment = TextAlignmentOptions.Left;
	}

	public void SetCreationInfosValues(int blocks, float cost, float weight)
	{
		blocksText.text = "\uf1b3\t" + blocks;
		costText.text = " \uf0eb\t" + cost.ToString("0.##");
		weightText.text = "\ue908\t" + weight.ToString("0.##");
	}

	public void ResetWindowPosition()
	{
		draggableWindow.ResetWindowPosition();
	}

	public void SetCheatPanelVisibilityAndReset(bool isVisible)
	{
		if (cheatPanel.activeSelf != isVisible)
		{
			cheatPanel.SetActive(isVisible);
		}
		unbreakableToggle.SetValue(isOn: false);
		unlimitedAmmoToggle.SetValue(isOn: false);
		delimitationToggle.SetValue(isOn: false);
	}

	public bool GetUnbreakebleToggleValue()
	{
		return unbreakableToggle.isOn;
	}

	public bool GetUnlimitedAmmoToggleValue()
	{
		return unlimitedAmmoToggle.isOn;
	}

	public bool GetDelimitationToggleValue()
	{
		return delimitationToggle.isOn;
	}

	public void SetRestrictedBlocksPanelVisibility(bool isVisible)
	{
		if (restrictedBlocksPanel.activeSelf != isVisible)
		{
			restrictedBlocksPanel.SetActive(isVisible);
		}
	}

	public void SetRestrictedBlocks(Schematic[] restrictedSchematics)
	{
		restrictedBlocksListPanel.transform.RemoveAllChildren();
		for (int i = 0; i < restrictedSchematics.Length; i++)
		{
			GameObject gameObject = Util.InstantiateForGUI(restrictedBlockSlotPrefab, restrictedBlocksListPanel.transform, $"RestrictedBlock_{i}");
			gameObject.GetComponent<TextMeshProUGUI>().SetText(restrictedSchematics[i].Name);
			CreationModel creationModel = CreationModelBuilder.BuildCreationModelFromSchematic(restrictedSchematics[i]);
			gameObject.GetComponent<BlockModelTooltipTrigger>().CreationModel = creationModel;
		}
	}
}
