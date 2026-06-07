using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaterDistributerPanel : MonoBehaviour, IBuildablePanelElement
{
	private const string METRIC_FORMAT = "{0} ml";

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private Slider _consumptionSlider;

	[SerializeField]
	private Slider _availableSlider;

	[SerializeField]
	private Slider _refillThresholdSlider;

	[SerializeField]
	private Slider _refillAmountSlider;

	[SerializeField]
	private TextMeshProUGUI _consumptionField;

	[SerializeField]
	private TextMeshProUGUI _availableField;

	[SerializeField]
	private TextMeshProUGUI _refillThresholdField;

	[SerializeField]
	private TextMeshProUGUI _refillAmountField;

	private ItemDistributer _itemDistributer;

	private ItemToDistribute _itemToDistribute;

	public BuildablePanelElementId Id => BuildablePanelElementId.WaterDistribution;

	private void Awake()
	{
		_refillThresholdSlider.onValueChanged.AddListener(OnRefillThresholdChanged);
		_refillAmountSlider.onValueChanged.AddListener(OnRefillAmountChanged);
	}

	private void LateUpdate()
	{
		UpdateConsumptionAndAvailableFields();
	}

	private void OnDestroy()
	{
		_refillThresholdSlider.onValueChanged.RemoveListener(OnRefillThresholdChanged);
		_refillAmountSlider.onValueChanged.RemoveListener(OnRefillAmountChanged);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<ItemDistributer>(out _itemDistributer) && _itemDistributer.TryReturnItemToDistribute(_itemProperties, out _itemToDistribute))
		{
			base.gameObject.SetActive(value: true);
			InitializeSlider(_consumptionSlider, _itemToDistribute.Consumption);
			InitializeSlider(_availableSlider, _itemToDistribute.Available);
			InitializeSlider(_refillThresholdSlider, _itemToDistribute.RefillThreshold);
			InitializeSlider(_refillAmountSlider, _itemToDistribute.RefillAmount);
			UpdateConsumptionAndAvailableFields();
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void InitializeSlider(Slider slider, float value)
	{
		slider.maxValue = _itemToDistribute.Capacity;
		slider.value = value;
	}

	private void UpdateConsumptionAndAvailableFields()
	{
		_consumptionSlider.SetValueWithoutNotify(_itemToDistribute.Consumption);
		_availableSlider.SetValueWithoutNotify(_itemToDistribute.Available);
		_consumptionField.text = $"{Mathf.CeilToInt(_itemToDistribute.Consumption)} ml";
		_availableField.text = $"{Mathf.CeilToInt(_itemToDistribute.Available)} ml";
	}

	private void OnRefillThresholdChanged(float value)
	{
		_itemToDistribute.SetRefillThrehold(value);
		_refillThresholdField.text = $"{Mathf.CeilToInt(_itemToDistribute.RefillThreshold)} ml";
	}

	private void OnRefillAmountChanged(float value)
	{
		_itemToDistribute.SetRefillAmount(value);
		_refillAmountField.text = $"{Mathf.CeilToInt(_itemToDistribute.RefillAmount)} ml";
	}
}
