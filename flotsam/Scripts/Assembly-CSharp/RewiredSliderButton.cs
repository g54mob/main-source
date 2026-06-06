using UnityEngine;
using UnityEngine.UI;

public class RewiredSliderButton : RewiredComponent
{
	[Header("Rewired Slider Button")]
	[SerializeField]
	private Slider _slider;

	[SerializeField]
	private float _valueChange = 1f;

	protected override void OnButtonDown()
	{
		_slider.value += _valueChange;
	}
}
