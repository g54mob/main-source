using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputFieldStepper : MonoBehaviour
{
	[Serializable]
	public class OnValueChangedEvent : UnityEvent<int>
	{
	}

	public OnValueChangedEvent onValueChanged;

	public Text displayText;

	public int _minValue;

	public int _maxValue;

	private int _Value;

	public int MinValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int MaxValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int Value
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void OnPlus()
	{
	}

	public void OnMinus()
	{
	}

	public void Start()
	{
	}
}
