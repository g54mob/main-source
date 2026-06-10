using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FishLogPanel : MonoBehaviour
{
	public GameObject speciesEntryPrefab;

	public Transform speciesListParent;

	public FishLogDetailView detailView;

	public List<Fish> allFishSpecies;

	[Header("Scroll")]
	public ScrollRect speciesListScrollRect;

	[Header("Preference Icons")]
	public List<PreferenceIconMapping> preferenceIcons = new List<PreferenceIconMapping>();

	[Header("Strength Formatting")]
	public List<StrengthTextMapping> strengthFormats = new List<StrengthTextMapping>();

	public Action newFishSelected;

	private bool isPopulating;

	public Fish selectedFish;

	private void Start()
	{
		PopulateSpeciesList();
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.OnLogUpdated += PopulateSpeciesList;
		}
	}

	private void OnDestroy()
	{
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.OnLogUpdated -= PopulateSpeciesList;
		}
	}

	private void PopulateSpeciesList()
	{
		if (speciesListParent == null || isPopulating)
		{
			return;
		}
		isPopulating = true;
		foreach (Transform item in speciesListParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		List<Fish> list = (from fish2 in allFishSpecies
			where !fish2.isBossFish || FishLogManager.Instance.HasCaughtSpecies(fish2.speciesName)
			orderby FishLogManager.Instance.HasCaughtSpecies(fish2.speciesName) descending, fish2.isBossFish descending, fish2.speciesName
			select fish2).ToList();
		FishLogSpeciesEntry fishLogSpeciesEntry = null;
		for (int num = 0; num < list.Count; num++)
		{
			Fish data = list[num];
			FishLogSpeciesEntry component = UnityEngine.Object.Instantiate(speciesEntryPrefab, speciesListParent).GetComponent<FishLogSpeciesEntry>();
			component.Setup(data, this);
			if (num == 0)
			{
				fishLogSpeciesEntry = component;
			}
		}
		if (selectedFish != null && list.Contains(selectedFish))
		{
			newFishSelected?.Invoke();
		}
		else if (list.Count > 0)
		{
			Fish fish = list[0];
			if (FishLogManager.Instance.IsFishNew(fish.speciesName))
			{
				FishLogManager.Instance.MarkFishAsSeen(fish.speciesName);
				if (fishLogSpeciesEntry != null)
				{
					fishLogSpeciesEntry.HideNewIndicator(animate: false);
				}
			}
			OnSpeciesSelected(fish);
		}
		RefreshUI();
		isPopulating = false;
	}

	public void OnSpeciesSelected(Fish selectedSpecies)
	{
		selectedFish = selectedSpecies;
		detailView.DisplaySpecies(selectedSpecies, this);
		newFishSelected?.Invoke();
	}

	public Sprite GetPreferenceIcon(FishPreferenceType type)
	{
		foreach (PreferenceIconMapping preferenceIcon in preferenceIcons)
		{
			if (preferenceIcon.type == type)
			{
				return preferenceIcon.icon;
			}
		}
		return null;
	}

	public LocalizedString GetPreferenceDescription(FishPreferenceType type)
	{
		foreach (PreferenceIconMapping preferenceIcon in preferenceIcons)
		{
			if (preferenceIcon.type == type)
			{
				return preferenceIcon.text;
			}
		}
		return null;
	}

	public LocalizedString GetStrengthFormat(string strength)
	{
		foreach (StrengthTextMapping strengthFormat in strengthFormats)
		{
			if (strengthFormat.strength == strength)
			{
				return strengthFormat.formatText;
			}
		}
		return null;
	}

	public void ResetScrollToTop()
	{
		if (speciesListScrollRect != null)
		{
			speciesListScrollRect.verticalNormalizedPosition = 1f;
		}
	}

	public void RefreshUI()
	{
		Debug.Log("[FishLogPanel] RefreshUI called - updating fish log display");
		if (detailView != null)
		{
			detailView.RefreshCurrentSpecies(this);
			Debug.Log("[FishLogPanel] Detail view refreshed");
		}
		else
		{
			Debug.LogWarning("[FishLogPanel] Detail view is null, cannot refresh");
		}
	}
}
