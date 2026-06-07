using System;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldSliderSync : ActiveComponent
{
	[SceneBind("Slider")]
	private BoundedSlider slider;

	[SceneBind("Value/Text")]
	private Text text;

	private Func<float, string> valueToText;

	public float Value
	{
		get
		{
			return slider.value;
		}
		set
		{
			slider.value = value;
			text.text = valueToText((slider != null) ? slider.value : slider.value);
		}
	}

	public float maxValue
	{
		get
		{
			return slider.maxValue;
		}
		set
		{
			slider.maxValue = value;
		}
	}

	public float minValue
	{
		get
		{
			return slider.minValue;
		}
		set
		{
			slider.minValue = value;
		}
	}

	public Transform SliderTransform => slider.transform;

	public void Init(Func<float, string> valueToTextFunction, float[] bounds = null)
	{
		valueToText = valueToTextFunction;
		base.Init();
		if (bounds != null)
		{
			slider.SetUpBounds(bounds);
		}
		slider.onValueChanged.RemoveAllListeners();
		slider.onValueChanged.AddListener(delegate(float x)
		{
			text.text = valueToText(x);
		});
	}

	public void Init(Func<float, string> valueToTextFunction, int[] bounds)
	{
		valueToText = valueToTextFunction;
		base.Init();
		if (bounds != null)
		{
			slider.SetUpBounds(bounds);
		}
		slider.onValueChanged.RemoveAllListeners();
		slider.onValueChanged.AddListener(delegate(float x)
		{
			text.text = valueToText(x);
		});
	}

	public override void Init()
	{
		throw new NotImplementedException("Use Init(Func<float, string>)");
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}
}
