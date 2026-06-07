using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SelectableUI_extractor : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI extractorNameText;

	[SerializeField]
	private ExtractorResourceUI extractorResourceUI;

	[SerializeField]
	private TextMeshProUGUI unitsLeftText;

	[Header("TimeBar")]
	[SerializeField]
	private FillBar timeBarFillBar;

	[SerializeField]
	private TextMeshProUGUI timeBarCurrentProgress;

	[SerializeField]
	private TextMeshProUGUI timeBarTotalTime;

	private Extractor extractor;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			extractor = SelectedObject as Extractor;
			extractor.onSpeedChanged += OnExtractorSpeedChanged;
			UpdateExtractorInfo();
		}
	}

	private void OnDestroy()
	{
		if ((bool)extractor)
		{
			extractor.onSpeedChanged -= OnExtractorSpeedChanged;
		}
	}

	private void Update()
	{
		UpdateTimeBar();
		UpdateUnitsLeftText();
	}

	private void UpdateExtractorInfo()
	{
		extractorNameText.text = extractor.ObjectData.DisplayName;
		extractorResourceUI.Setup(extractor);
		LoadResourceData();
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void LoadResourceData()
	{
		extractorResourceUI.Setup(extractor);
		timeBarFillBar.SetBarMaxValue(extractor.ExtractionTime);
		timeBarFillBar.SetBarValue(extractor.CurrentExtractionTime);
		timeBarTotalTime.text = FunctionLibrary.RoundToDecimals(extractor.ExtractionTime, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
	}

	private void UpdateTimeBar()
	{
		if (extractor.CurrentExtractionTime < extractor.ExtractionTime)
		{
			timeBarFillBar.SetBarValue(extractor.CurrentExtractionTime);
			timeBarCurrentProgress.text = Mathf.RoundToInt(extractor.CurrentExtractionTime / extractor.ExtractionTime * 100f) + "%";
		}
		else
		{
			timeBarFillBar.SetBarValue(0f);
			timeBarCurrentProgress.text = "0%";
		}
	}

	private void UpdateUnitsLeftText()
	{
		unitsLeftText.text = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_selectable_extractor_label_unitsLeft").Entry.GetLocalizedString() + " " + extractor.GetTotalUnitsLeft();
	}

	private void OnExtractorSpeedChanged(float newValue)
	{
		UpdateExtractorInfo();
	}
}
