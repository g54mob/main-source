using UnityEngine;
using UnityEngine.UI;

public class ResearchEnergyOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private ResearchStation _researchStation;

	[SerializeField]
	private Image _image;

	private bool _greyscale;

	protected override void Awake()
	{
		base.Awake();
		_image.material = Object.Instantiate(_image.material);
	}

	private void Update()
	{
		if (_researchStation.IsResearching)
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
