using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPassiveGeneratorEnergyOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private EnergyPassiveGenerator _generator;

	[SerializeField]
	private Material _greyMaterial;

	[SerializeField]
	private TextMeshProUGUI _amountText;

	[SerializeField]
	private Image _backgroundImage;

	protected override void Awake()
	{
		base.Awake();
		_amountText.text = "+" + _generator.EnergyRate.ToString("F0");
	}

	private void Update()
	{
		if (_generator.IsRunning)
		{
			_backgroundImage.material = null;
		}
		else
		{
			_backgroundImage.material = _greyMaterial;
		}
	}
}
