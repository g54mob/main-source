using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Dropdown))]
public abstract class TMP_EnumDropdown<T> : MonoBehaviour where T : Enum
{
	[Serializable]
	public class EnumDropDownEvent : UnityEvent<T>
	{
	}

	[SerializeField]
	private EnumDropDownEvent _onSelectionChanged = new EnumDropDownEvent();

	private TMP_Dropdown _dropDown;

	private Array _values;

	private List<string> _options;

	public EnumDropDownEvent OnSelectionChanged => _onSelectionChanged;

	private void Awake()
	{
		_dropDown = GetComponent<TMP_Dropdown>();
		_values = Enum.GetValues(typeof(T));
		_options = new List<string>(_values.Length);
	}

	private void OnEnable()
	{
		if (_options == null)
		{
			Awake();
		}
		_options.Clear();
		foreach (object value in _values)
		{
			if (TryReturnOption((T)value, out var option))
			{
				_options.Add(option);
			}
		}
		_dropDown.ClearOptions();
		_dropDown.AddOptions(_options);
		_dropDown.onValueChanged.AddListener(OnDropDownValueChanged);
	}

	private void OnDisable()
	{
		_dropDown.onValueChanged.RemoveListener(OnDropDownValueChanged);
	}

	private void OnDropDownValueChanged(int index)
	{
		OnValueChanged((T)_values.GetValue(index));
	}

	protected virtual void OnValueChanged(T value)
	{
		if (_onSelectionChanged != null)
		{
			_onSelectionChanged.Invoke(value);
		}
	}

	public bool TryReturnEnumValue(out T value)
	{
		value = (T)_values.GetValue(_dropDown.value);
		return true;
	}

	protected virtual bool TryReturnOption(T value, out string option)
	{
		option = value.ToString();
		return true;
	}
}
