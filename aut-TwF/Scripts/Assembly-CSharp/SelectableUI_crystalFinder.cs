using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SelectableUI_crystalFinder : SelectableUI
{
	[SerializeField]
	private UIList activationCostList;

	[SerializeField]
	private GameObject activationButton;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	private CrystalFinder crystalFinder;

	private bool canBeUsed;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			crystalFinder = SelectedObject as CrystalFinder;
			if ((bool)crystalFinder.TrackedAltar)
			{
				activationCostList.gameObject.SetActive(value: false);
				descriptionText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_crystalFinder_alreadyUsed", null, FallbackBehavior.UseProjectSettings);
				canBeUsed = false;
			}
			else if (crystalFinder.GetNearestAvailableCrystalAltar() == null)
			{
				activationCostList.gameObject.SetActive(value: false);
				descriptionText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_crystalFinder_allCrystalsFound", null, FallbackBehavior.UseProjectSettings);
				canBeUsed = false;
			}
			else
			{
				activationCostList.gameObject.SetActive(value: true);
				activationCostList.ClearList();
				activationCostList.LoadList(crystalFinder.ActivationCost);
				canBeUsed = true;
			}
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void Update()
	{
		if (canBeUsed && LTFunctionLibrary.GetLTGameManager().CanAfford(crystalFinder.ActivationCost))
		{
			if (!activationButton.activeSelf)
			{
				activationButton.SetActive(value: true);
				GetComponent<AutoTransformRebuild>().RebuildTransform();
			}
		}
		else if (activationButton.activeSelf)
		{
			activationButton.SetActive(value: false);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	public void ActivateButton()
	{
		crystalFinder.ActivateCrystalFinder();
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}
}
