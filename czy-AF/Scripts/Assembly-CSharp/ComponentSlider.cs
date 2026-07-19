using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComponentSlider : MonoBehaviour
{
	public Slider slider;

	public void SetData(Hashtable h)
	{
		if (h["min"] != null)
		{
			slider.minValue = (float)h["min"];
		}
		if (h["max"] != null)
		{
			slider.maxValue = (float)h["max"];
		}
		if (h["round"] != null)
		{
			slider.wholeNumbers = (bool)h["round"];
		}
		if (h["value"] != null)
		{
			slider.value = (float)h["value"];
		}
	}

	public void ValueChanged(Transform t)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Change", slider.value, t);
	}

	public void SetValue(float _value)
	{
		slider.value = _value;
	}
}
