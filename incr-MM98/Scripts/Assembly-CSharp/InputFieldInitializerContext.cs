using TMPro;
using UnityEngine.Events;

public class InputFieldInitializerContext : InitializerContext<TMP_InputField>
{
	public InputFieldInitializerContext Configure(PrefStringReactiveProperty property)
	{
		return SetValueWithoutNotify(property.Value).OnEndEdit(delegate(string x)
		{
			property.Value = x;
		});
	}

	public InputFieldInitializerContext SetValue(string value)
	{
		Target.text = value;
		return this;
	}

	public InputFieldInitializerContext SetValueWithoutNotify(string value)
	{
		Target.SetTextWithoutNotify(value);
		return this;
	}

	public InputFieldInitializerContext OnValueChanged(UnityAction<string> callback, string value)
	{
		callback(value);
		return OnValueChanged(callback);
	}

	public InputFieldInitializerContext OnValueChanged(UnityAction<string> callback)
	{
		Target.onValueChanged.AddListener(callback);
		return this;
	}

	public InputFieldInitializerContext OnEndEdit(UnityAction<string> callback, string value)
	{
		callback(value);
		return OnEndEdit(callback);
	}

	public InputFieldInitializerContext OnEndEdit(UnityAction<string> callback)
	{
		Target.onEndEdit.AddListener(callback);
		return this;
	}
}
