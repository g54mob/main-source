using System;
using UnityEngine.UI;

public class InputFieldSliderSync : ActiveComponent
{
	[SceneBind("Slider")]
	private Slider slider;

	[SceneBind("InputField")]
	private InputField inputField;

	public new void Init()
	{
		base.Init();
		slider.onValueChanged.RemoveAllListeners();
		slider.onValueChanged.AddListener(delegate(float x)
		{
			try
			{
				if ((double)x != Convert.ToDouble(inputField.text))
				{
					inputField.text = x.ToString();
				}
			}
			catch (FormatException)
			{
				inputField.text = x.ToString();
			}
		});
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		inputField.onEndEdit.AddListener(delegate(string x)
		{
			double val = Convert.ToDouble(x);
			val = Math.Max(val, slider.minValue);
			val = Math.Min(val, slider.maxValue);
			inputField.text = val.ToString();
			if ((double)slider.value != val)
			{
				slider.value = (float)val;
			}
		});
	}
}
