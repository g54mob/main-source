using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyItemProducerPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private TextMeshProUGUI _itemName;

	[SerializeField]
	private TextMeshProUGUI _itemDescription;

	[SerializeField]
	private Slider _burnSlider;

	[SerializeField]
	private LabelledValueSlider _refillAmountPointSlider;

	[SerializeField]
	private LabelledValueSlider _energyFillSlider;

	[SerializeField]
	private ItemCounterSlot _energyItemSlot;

	private EnergyItemProducer _producer;

	public BuildablePanelElementId Id => BuildablePanelElementId.EnergyItemProducer;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<EnergyItemProducer>(out var buildableExtendable))
		{
			Activate(buildableExtendable);
			return true;
		}
		return false;
	}

	public void Activate(EnergyItemProducer producer)
	{
		base.gameObject.SetActive(value: true);
		_producer = producer;
		_itemName.text = _producer.EnergyItemProperties.LocalizedName;
		_itemDescription.text = _producer.EnergyItemProperties.LocalizedDescription;
		_burnSlider.maxValue = _producer.MaxBurnTime;
		_producer.Buildable.Inventory.InventoryUpdatedEvent.AddListener(UpdateItems);
		UpdateItems();
		_refillAmountPointSlider.SetMinMaxValues(0f, _producer.ImportCapacity);
		_refillAmountPointSlider.SetValueWithoutNotify(_producer.InventoryRefillAmountPoint);
		_producer.OnEnergyFillPercentageUpdated.AddListener(OnEnergyFillPercentageUpdated);
		OnEnergyFillPercentageUpdated();
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		if (_producer != null)
		{
			_producer.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateItems);
			_producer.OnEnergyFillPercentageUpdated.RemoveListener(OnEnergyFillPercentageUpdated);
		}
	}

	private void OnDisable()
	{
		if (_producer != null)
		{
			_producer.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateItems);
			_producer.OnEnergyFillPercentageUpdated.RemoveListener(OnEnergyFillPercentageUpdated);
		}
	}

	private void Update()
	{
		if (!(_producer == null))
		{
			_burnSlider.value = _producer.MaxBurnTime - _producer.BurnTimer;
		}
	}

	private void UpdateItems()
	{
		_energyItemSlot.Initialize(_producer.EnergyItemProperties, _producer.Buildable.Inventory.ReturnCount(SubInventoryType.Export), showCounter: true);
	}

	public void UpdateInventoryRefillAmountPoint(float fillPoint)
	{
		if (!(_producer == null))
		{
			_producer.SetInventoryRefillAmountPoint((int)fillPoint);
		}
	}

	public void UpdateEnergyRefillAmountPercentage(float percentage)
	{
		if (!(_producer == null))
		{
			_producer.SetEnergyFillPercentage(Mathf.Round(percentage * 100f) / 100f);
		}
	}

	private void OnEnergyFillPercentageUpdated()
	{
		if (!(_producer == null))
		{
			_energyFillSlider.SetValueWithoutNotify(_producer.EnergyFillPercentage);
		}
	}
}
