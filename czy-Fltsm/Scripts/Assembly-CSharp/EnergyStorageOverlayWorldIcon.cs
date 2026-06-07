using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private GameObject _energyStorageGameObject;

	[SerializeField]
	private Slider _energyOverlaySlider;

	[SerializeField]
	private TextMeshProUGUI _energyOverlayText;

	private IEnergyGridStorage _energyStorage;

	protected override void Awake()
	{
		base.Awake();
		_energyStorage = _energyStorageGameObject.GetComponent<IEnergyGridStorage>();
		if (_energyStorage == null)
		{
			Debug.LogError("Gameobject did not haver a IEnergyGridStorage component.");
		}
	}

	private void Update()
	{
		_energyOverlayText.text = _energyStorage.EnergyAmount.ToString("F0");
		_energyOverlaySlider.value = _energyStorage.NormalizedEnergyAmount;
	}
}
