using MLCN_Localization;
using TMPro;
using UnityEngine;

public class OverviewScreen : MonoBehaviour
{
	[SerializeField]
	private TMP_Text[] labelProgressionLevel;

	[SerializeField]
	private TMP_Text labelCafeCapacity;

	[SerializeField]
	private TMP_Text labelUpkeep;

	[SerializeField]
	private TMP_InputField inputFieldCafeShopName;

	[Header("Cleanness")]
	[SerializeField]
	private TMP_Text labelCleanStatus;

	[SerializeField]
	private TMP_Text labelValueDirtyDishes;

	[SerializeField]
	private TMP_Text labelValueBrokenObjects;

	[SerializeField]
	private TMP_Text labelValueBroomables;

	[SerializeField]
	private TMP_Text labelValueSwiffables;

	[SerializeField]
	private string[] localizedCleannessStateKeys;

	[Header("Customer Rating")]
	[SerializeField]
	private SliderField sliderServiceBar;

	[SerializeField]
	private SliderField sliderProductBar;

	[SerializeField]
	private SliderField sliderAmbientBar;

	[SerializeField]
	private SliderField sliderCleannessBar;

	[SerializeField]
	private SliderField sliderRatingBar;

	private void Start()
	{
		TMP_Text[] array = labelProgressionLevel;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].text = ProgressionManager.GetCurrentLevel().ToString();
		}
		ProgressionManager.ListenOnLevelUp(delegate(int level)
		{
			TMP_Text[] array2 = labelProgressionLevel;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].text = level.ToString();
			}
		});
		labelCafeCapacity.text = CustomerManager.GetMaxCapacity().ToString();
		CustomerManager.OnUpdateMaxCustomerCapacity.AddListener(delegate(int capacity)
		{
			labelCafeCapacity.text = capacity.ToString();
		});
		CafeShopManager.OnLoadShopName.AddListener(delegate(string name)
		{
			inputFieldCafeShopName.SetTextWithoutNotify(name);
		});
		inputFieldCafeShopName.SetTextWithoutNotify(CafeShopManager.GetCafeShopName());
		UpdateCleannessStats();
		CustomerManager.OnUpdateCleanupState.AddListener(delegate
		{
			UpdateCleannessStats();
		});
		labelUpkeep.text = "-" + CafeShopManager.GetDailyUpkeep();
		CafeShopManager.OnUpkeepChanged.AddListener(delegate
		{
			labelUpkeep.text = "-" + CafeShopManager.GetDailyUpkeep();
		});
		UpdateCustomerRating(CafeShopManager.GetCafeShopRating());
		CafeShopManager.OnCafeRatingChanged.AddListener(delegate(CustomerRating rating)
		{
			UpdateCustomerRating(rating);
		});
	}

	public void UpdateCafeShopName(string name)
	{
		CafeShopManager.UpdateCafeShopName(name);
		TutorialManager.TryCheckSectionChecklistOption("RenameCafe", TutorialManager.TutorialState.RunCafe);
	}

	public void ExitNameInputField()
	{
		inputFieldCafeShopName.ReleaseSelection();
		inputFieldCafeShopName.interactable = false;
		inputFieldCafeShopName.interactable = true;
	}

	private void UpdateCleannessStats()
	{
		labelCleanStatus.text = LocalizationManager.GetLocalizedString(localizedCleannessStateKeys[(int)CustomerManager.GetCleanupState()], LocalizationManager.GetTableComputerKeys());
		labelValueDirtyDishes.text = CustomerManager.GetDirtStat(Dirt.DirtType.Dish).ToString();
		labelValueBrokenObjects.text = CustomerManager.GetDirtStat(Dirt.DirtType.BrokenObject).ToString();
		labelValueBroomables.text = CustomerManager.GetDirtStat(Dirt.DirtType.BroomableDirt).ToString();
		labelValueSwiffables.text = CustomerManager.GetDirtStat(Dirt.DirtType.SwifferDirt).ToString();
	}

	private void UpdateCustomerRating(CustomerRating rating)
	{
		float value = Mathf.InverseLerp(0f, 255f, (int)rating.service);
		float value2 = Mathf.InverseLerp(0f, 255f, (int)rating.product);
		float value3 = Mathf.InverseLerp(0f, 255f, CafeShopManager.GetAmbientRating());
		float value4 = Mathf.InverseLerp(CustomerManager.GetCleanupMin(), CustomerManager.GetCleanupMax(), rating.cleanness);
		float value5 = Mathf.InverseLerp(0f, 5f, rating.GetStarRating());
		sliderServiceBar.OnValueChange(value);
		sliderProductBar.OnValueChange(value2);
		sliderAmbientBar.OnValueChange(value3);
		sliderCleannessBar.OnValueChange(value4);
		sliderRatingBar.OnValueChange(value5);
	}
}
