using UnityEngine;

public class EnergyManualProducerPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private LabelledValueSlider _energySlider;

	private EnergyManualProducer _producer;

	public BuildablePanelElementId Id => BuildablePanelElementId.EnergyManualProducer;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<EnergyManualProducer>(out _producer))
		{
			base.gameObject.SetActive(value: true);
			_producer = buildable.GetComponent<EnergyManualProducer>();
			_producer.OnEnergyFillPercentageUpdated.AddListener(OnEnergyFillPercentageUpdated);
			OnEnergyFillPercentageUpdated();
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		if (_producer != null)
		{
			_producer.OnEnergyFillPercentageUpdated.RemoveListener(OnEnergyFillPercentageUpdated);
		}
	}

	private void OnDisable()
	{
		if (_producer != null)
		{
			_producer.OnEnergyFillPercentageUpdated.RemoveListener(OnEnergyFillPercentageUpdated);
		}
	}

	private void OnEnergyFillPercentageUpdated()
	{
		if (!(_producer == null))
		{
			_energySlider.SetValueWithoutNotify(_producer.EnergyFillPercentage);
		}
	}

	public void UpdateEnergy(float percentage)
	{
		if (!(_producer == null))
		{
			_producer.SetEnergyFillPercentage(Mathf.Round(percentage * 100f) / 100f);
		}
	}
}
