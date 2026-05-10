using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SelectableUI_snowfallBeacon : SelectableUI
{
	[SerializeField]
	private SnowfallBeaconResourceUI snowfallBeaconResourceUI;

	[SerializeField]
	private TextMeshProUGUI effectDurationText;

	[Header("TimeBar")]
	[SerializeField]
	private FillBar timeBarFillBar;

	[SerializeField]
	private TextMeshProUGUI currentDurationText;

	private SnowfallBeacon snowfallBeacon;

	private Coroutine updateTimeBarCoroutine;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			snowfallBeacon = SelectedObject as SnowfallBeacon;
			UpdateSnowfallBeaconInfo();
			snowfallBeacon.onActivate += OnActivateSnowfallBeacon;
			if (snowfallBeacon.IsActive)
			{
				OnActivateSnowfallBeacon(snowfallBeacon);
			}
		}
	}

	private void OnDestroy()
	{
		snowfallBeacon.onActivate -= OnActivateSnowfallBeacon;
	}

	private void UpdateSnowfallBeaconInfo()
	{
		effectDurationText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_snowfallBeacon_label_duration", null, FallbackBehavior.UseProjectSettings) + ": " + snowfallBeacon.SelectedRecipe.Duration + LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_second_short", null, FallbackBehavior.UseProjectSettings);
		snowfallBeaconResourceUI.Setup(snowfallBeacon);
		timeBarFillBar.SetBarMaxValue(snowfallBeacon.SelectedRecipe.Duration);
		float num = snowfallBeacon.SelectedRecipe.Duration - snowfallBeacon.CurrentDuration;
		timeBarFillBar.SetBarValue(num);
		if (snowfallBeacon.IsActive)
		{
			timeBarFillBar.SetBarValue(num);
			currentDurationText.text = Mathf.CeilToInt(num) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
		}
		else
		{
			timeBarFillBar.SetBarValue(0f);
			currentDurationText.text = "";
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private IEnumerator UpdateTimeBarCoroutine()
	{
		while (snowfallBeacon.IsActive)
		{
			float num = snowfallBeacon.SelectedRecipe.Duration - snowfallBeacon.CurrentDuration;
			timeBarFillBar.SetBarValue(num);
			currentDurationText.text = Mathf.CeilToInt(num) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
			yield return null;
		}
		timeBarFillBar.SetBarValue(0f);
		currentDurationText.text = "";
	}

	private void OnActivateSnowfallBeacon(ResourceActivatedBuilding building)
	{
		this.StartCoroutineCheckingVar(UpdateTimeBarCoroutine(), ref updateTimeBarCoroutine, stopCoroutineIfRunning: true);
	}
}
