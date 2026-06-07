using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SelectableUI_perkBeacon : SelectableUI
{
	[Header("Perk Selection")]
	[SerializeField]
	private GameObject perkSelectionPanel;

	[SerializeField]
	private UIList perkSelectionList;

	[Header("Perk Panel")]
	[SerializeField]
	private GameObject perkInfoPanel;

	[SerializeField]
	private TextMeshProUGUI effectDescription;

	[SerializeField]
	private PerkBeaconResourceUI perkBeaconResourceUI;

	[SerializeField]
	private TextMeshProUGUI effectDurationText;

	[SerializeField]
	private FillBar timeBarFillBar;

	[SerializeField]
	private TextMeshProUGUI currentDurationText;

	private PerkBeacon perkBeacon;

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
			perkBeacon = SelectedObject as PerkBeacon;
			if ((bool)perkBeacon.SelectedRecipe)
			{
				ShowPerkInfoPanel();
				perkBeacon.onActivate += OnActivatePerkBeacon;
				if (perkBeacon.IsActive)
				{
					OnActivatePerkBeacon(perkBeacon);
				}
			}
			else
			{
				ShowPerkSelectionPanel();
			}
		}
	}

	private void OnDestroy()
	{
		perkBeacon.onActivate -= OnActivatePerkBeacon;
	}

	private void ShowPerkSelectionPanel()
	{
		perkInfoPanel.SetActive(value: false);
		perkSelectionPanel.SetActive(value: true);
		perkSelectionList.ClearList();
		perkSelectionList.LoadList(perkBeacon.Recipes);
		foreach (UIListElement element in perkSelectionList.Elements)
		{
			element.GetComponent<PerkBeaconPerk_UI>().onPerkSelected += delegate(ResourceActivatedGEData rageData)
			{
				perkBeacon.ChangeSelectedRecipe(rageData);
				ShowPerkInfoPanel();
				perkBeacon.onActivate += OnActivatePerkBeacon;
				if (perkBeacon.IsActive)
				{
					OnActivatePerkBeacon(perkBeacon);
				}
			};
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void ShowPerkInfoPanel()
	{
		perkSelectionPanel.SetActive(value: false);
		perkInfoPanel.SetActive(value: true);
		effectDescription.text = perkBeacon.SelectedRecipe.Description;
		perkBeaconResourceUI.Setup(perkBeacon);
		if (HasInifniteDuration())
		{
			effectDurationText.gameObject.SetActive(value: false);
			currentDurationText.text = "";
			timeBarFillBar.SetBarValue(perkBeacon.IsActive ? timeBarFillBar.MaxValue : 0f);
		}
		else
		{
			effectDurationText.gameObject.SetActive(value: true);
			effectDurationText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_snowfallBeacon_label_duration", null, FallbackBehavior.UseProjectSettings) + ": " + perkBeacon.SelectedRecipe.Duration + LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_second_short", null, FallbackBehavior.UseProjectSettings);
			timeBarFillBar.SetBarMaxValue(perkBeacon.SelectedRecipe.Duration);
			if (perkBeacon.IsActive)
			{
				float num = perkBeacon.SelectedRecipe.Duration - perkBeacon.CurrentDuration;
				timeBarFillBar.SetBarValue(num);
				currentDurationText.text = Mathf.CeilToInt(num) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
			}
			else
			{
				timeBarFillBar.SetBarValue(0f);
				currentDurationText.text = "";
			}
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private IEnumerator UpdateTimeBarCoroutine()
	{
		if (HasInifniteDuration())
		{
			timeBarFillBar.SetBarValue(timeBarFillBar.MaxValue);
			yield break;
		}
		while (perkBeacon.IsActive)
		{
			float num = perkBeacon.SelectedRecipe.Duration - perkBeacon.CurrentDuration;
			timeBarFillBar.SetBarValue(num);
			currentDurationText.text = Mathf.CeilToInt(num) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
			yield return null;
		}
		timeBarFillBar.SetBarValue(0f);
		currentDurationText.text = "";
	}

	private void OnActivatePerkBeacon(ResourceActivatedBuilding building)
	{
		this.StartCoroutineCheckingVar(UpdateTimeBarCoroutine(), ref updateTimeBarCoroutine, stopCoroutineIfRunning: true);
	}

	private bool HasInifniteDuration()
	{
		return perkBeacon.SelectedRecipe.Duration <= 0f;
	}
}
