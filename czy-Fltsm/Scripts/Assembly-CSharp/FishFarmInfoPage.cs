using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishFarmInfoPage : MonoBehaviour
{
	[Header("Chow")]
	[SerializeField]
	private InventoryPanelItemSlot _feedItemSlot;

	[SerializeField]
	private Localize _feedItemNameField;

	[SerializeField]
	private TextMeshProUGUI _feedItemWeightField;

	[SerializeField]
	private TextMeshProUGUI _dailyConsuptionField;

	[Header("Hatchery")]
	[SerializeField]
	private TextMeshProUGUI _broodCycleField;

	[SerializeField]
	private TextMeshProUGUI _eggsPerBroodFields;

	[SerializeField]
	private Image _eggsPerBroodImage;

	[Header("Nursery")]
	[SerializeField]
	private TextMeshProUGUI _growthCycleField;

	public void Initialize(AquaFarm aquaFarm, FishProperties fishProperties)
	{
		_feedItemSlot.Initialize(fishProperties.FeedItemProperties, 1, showCounter: false);
		_feedItemNameField.SetTerm(fishProperties.FeedItemProperties.LocalizedNameTerm);
		_feedItemWeightField.text = $"= {aquaFarm.ItemDistributer.UnitsPerItem} g";
		_dailyConsuptionField.text = $"{fishProperties.FeedConsumptionPerDay} g";
		_broodCycleField.text = (fishProperties.FeedRequirementBrooding / fishProperties.FeedConsumptionPerDay).ToString();
		_eggsPerBroodFields.text = fishProperties.OffspringMaximum.ToString();
		_eggsPerBroodImage.sprite = fishProperties.OffspringIcon;
		_growthCycleField.text = (fishProperties.FeedRequirementGrowing / fishProperties.FeedConsumptionPerDay).ToString();
	}
}
