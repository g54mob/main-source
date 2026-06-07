using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderInput : MonoBehaviour
{
	[Serializable]
	public class OnValueChanged : UnityEvent<string, int, float>
	{
	}

	[Serializable]
	public class OnFloatValueChanged : UnityEvent<float>
	{
	}

	[Serializable]
	public class OnBeginChange : UnityEvent
	{
	}

	public Slider slider;

	public InputField inputField;

	public OnValueChanged onValueChanged;

	public OnFloatValueChanged onFloatValueChanged;

	public OnBeginChange onBeginChange;

	public float floatValue
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public string GetStringValue()
	{
		return null;
	}

	public float GetFloatValue()
	{
		return 0f;
	}

	public int GetIntValue()
	{
		return 0;
	}

	public short GetShortValue()
	{
		return 0;
	}

	public byte GetByteValue()
	{
		return 0;
	}

	public void SetValue(float val)
	{
	}

	public void SetValue(int val)
	{
	}

	public void SetValue(short val)
	{
	}

	public void SetValue(byte val)
	{
	}

	public void OnSliderBeginDrag()
	{
	}

	public void OnInputFieldBeginEdit()
	{
	}

	public void UpdateValueFromFloat(float value)
	{
	}

	public void UpdateValueFromString(string value)
	{
	}

	private void Notify()
	{
	}
}
