using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemEnergyProducerEnergyOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private EnergyItemProducer _producer;

	[SerializeField]
	private TextMeshProUGUI _amountText;

	[SerializeField]
	private Image _image;

	private bool _greyscale;

	protected override void Awake()
	{
		base.Awake();
		_amountText.text = "+" + _producer.PowerRate.ToString("F0");
		_image.material = Object.Instantiate(_image.material);
	}

	private void Update()
	{
		if (_producer.IsGenerating)
		{
			if (_greyscale)
			{
				_image.material.DisableKeyword("GREYSCALE_ON");
				_greyscale = false;
			}
		}
		else if (!_greyscale)
		{
			_image.material.EnableKeyword("GREYSCALE_ON");
			_greyscale = true;
		}
	}
}
