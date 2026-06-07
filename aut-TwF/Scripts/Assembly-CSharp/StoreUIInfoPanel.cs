using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class StoreUIInfoPanel : MonoBehaviour
{
	[Header("Common info")]
	[SerializeField]
	private TextMeshProUGUI selectedElementName;

	[SerializeField]
	private TextMeshProUGUI selectedElementDescription;

	[SerializeField]
	private UIList selectedElementCostList;

	[SerializeField]
	private StoreUITowerInfo towerInfo;

	[SerializeField]
	private StoreUIProcessorInfo processorInfo;

	[SerializeField]
	private StoreUIExtractorInfo extractorInfo;

	[SerializeField]
	private GameObject costPanel;

	private GameplayObjectData selectedElement;

	private void OnEnable()
	{
		ClearInfoPanel();
	}

	public void LoadInfoPanel(GameplayObjectData gameplayObjectData)
	{
		selectedElement = gameplayObjectData;
		selectedElementName.text = selectedElement.DisplayName;
		selectedElementDescription.text = selectedElement.Description;
		costPanel.gameObject.SetActive(value: false);
		towerInfo.gameObject.SetActive(value: false);
		processorInfo.gameObject.SetActive(value: false);
		extractorInfo.gameObject.SetActive(value: false);
		Processor component2;
		Extractor component3;
		if (selectedElement.Prefab.TryGetComponent<Tower>(out var component))
		{
			towerInfo.gameObject.SetActive(value: true);
			towerInfo.SelectedTower = component;
		}
		else if (selectedElement.Prefab.TryGetComponent<Processor>(out component2))
		{
			processorInfo.gameObject.SetActive(value: true);
			processorInfo.SelectedProcessor = component2;
		}
		else if (selectedElement.Prefab.TryGetComponent<Extractor>(out component3))
		{
			extractorInfo.gameObject.SetActive(value: true);
			extractorInfo.SelectedExtractor = component3;
		}
		costPanel.gameObject.SetActive(value: true);
		selectedElementCostList.LoadList(selectedElement.BuyCost);
	}

	public void LoadLockedInfoPanel()
	{
		selectedElement = null;
		selectedElementName.text = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_store_label_locked").Entry.GetLocalizedString();
		selectedElementDescription.text = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_store_text_unlockBuildingText").Entry.GetLocalizedString();
		selectedElementCostList.ClearList();
		costPanel.gameObject.SetActive(value: false);
		towerInfo.gameObject.SetActive(value: false);
		processorInfo.gameObject.SetActive(value: false);
		extractorInfo.gameObject.SetActive(value: false);
	}

	public void ClearInfoPanel()
	{
		selectedElement = null;
		selectedElementName.text = "-";
		selectedElementDescription.text = "";
		selectedElementCostList.ClearList();
		costPanel.gameObject.SetActive(value: false);
		towerInfo.gameObject.SetActive(value: false);
		processorInfo.gameObject.SetActive(value: false);
		extractorInfo.gameObject.SetActive(value: false);
	}
}
