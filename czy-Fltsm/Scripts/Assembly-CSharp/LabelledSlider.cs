using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabelledSlider : Slider
{
	[SerializeField]
	private TextMeshProUGUI _minimumLabel;

	[SerializeField]
	private TextMeshProUGUI _maximumLabel;

	protected override void Awake()
	{
		base.Awake();
		_minimumLabel.text = base.minValue.ToString();
		_maximumLabel.text = base.maxValue.ToString();
	}
}
