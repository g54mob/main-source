using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderInitializerContext : InitializerContext<Slider>
{
	public SliderInitializerContext Configure(PrefFloatReactiveProperty property)
	{
		return SetValueWithoutNotify(property.Value).OnValueChanged(delegate(float x)
		{
			property.Value = x;
		});
	}

	public SliderInitializerContext Configure(PrefIntReactiveProperty property)
	{
		return SetValueWithoutNotify(property.Value).OnValueChanged(delegate(float x)
		{
			property.Value = Mathf.RoundToInt(x);
		});
	}

	public SliderInitializerContext SetValue(float value)
	{
		Target.value = value;
		return this;
	}

	public SliderInitializerContext SetValueWithoutNotify(float value)
	{
		Target.SetValueWithoutNotify(value);
		return this;
	}

	public SliderInitializerContext OnValueChanged(UnityAction<float> callback, float value)
	{
		callback(value);
		return OnValueChanged(callback);
	}

	public SliderInitializerContext OnValueChanged(UnityAction<float> callback)
	{
		Target.onValueChanged.AddListener(callback);
		return this;
	}
}
