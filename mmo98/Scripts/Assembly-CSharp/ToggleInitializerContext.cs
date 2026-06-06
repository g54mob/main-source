using R3;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleInitializerContext : InitializerContext<Toggle>
{
	public ToggleInitializerContext Configure(ReactiveProperty<bool> property)
	{
		return SetValueWithoutNotify(property.Value).OnValueChanged(delegate(bool x)
		{
			property.Value = x;
		});
	}

	public ToggleInitializerContext SetValue(bool value)
	{
		Target.isOn = value;
		return this;
	}

	public ToggleInitializerContext SetValueWithoutNotify(bool value)
	{
		Target.SetIsOnWithoutNotify(value);
		return this;
	}

	public ToggleInitializerContext OnValueChanged(UnityAction<bool> callback, bool value)
	{
		callback(value);
		return OnValueChanged(callback);
	}

	public ToggleInitializerContext OnValueChanged(UnityAction<bool> callback)
	{
		Target.onValueChanged.AddListener(callback);
		return this;
	}
}
