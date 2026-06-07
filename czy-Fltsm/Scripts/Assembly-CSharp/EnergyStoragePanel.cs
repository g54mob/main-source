using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStoragePanel : MonoBehaviour, IBuildablePanelElement, IDecorationPanelElement
{
	[SerializeField]
	private Slider _energySlider;

	[SerializeField]
	private TextMeshProUGUI _energyAmountText;

	private IEnergyGridStorage _storage;

	BuildablePanelElementId IBuildablePanelElement.Id => BuildablePanelElementId.EnergyStorage;

	DecorationPanelElementId IDecorationPanelElement.Id => DecorationPanelElementId.EnergyStorage;

	private void Update()
	{
		if (_storage != null)
		{
			_energySlider.value = _storage.NormalizedEnergyAmount;
			_energyAmountText.text = _storage.EnergyAmount.ToString("F0") + "/" + _storage.EnergyCapacity.ToString("F0");
		}
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryGetComponent<IEnergyGridStorage>(out _storage))
		{
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Activate(Decoration decoration)
	{
		base.gameObject.SetActive(value: true);
		_storage = decoration.GetComponent<IEnergyGridStorage>();
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}
}
