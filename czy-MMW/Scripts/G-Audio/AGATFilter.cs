using System;
using System.Reflection;
using UnityEngine;

[Serializable]
public abstract class AGATFilter : ScriptableObject
{
	public class FilterProperty
	{
		private PropertyInfo _info;

		private FloatPropertyRange _range;

		private float _currentValue;

		private string _labelString;

		private bool _isGroupToggle;

		private AGATFilter _filter;

		public float CurrentValue => _currentValue;

		public string LabelString => _labelString;

		public FloatPropertyRange Range => _range;

		public bool IsGroupToggle => _isGroupToggle;

		public bool GroupToggleState { get; set; }

		public void SetValue(float val)
		{
			if (val != _currentValue)
			{
				_currentValue = val;
				_info.SetValue(_filter, val, null);
				_labelString = _info.Name + ": " + _currentValue.ToString("0.00");
			}
		}

		public void SetToggleValue(bool val)
		{
			if (val != GroupToggleState)
			{
				_info.SetValue(_filter, val, null);
				GroupToggleState = val;
			}
		}

		public FilterProperty(PropertyInfo info, AGATFilter filterInstance)
		{
			_info = info;
			object[] customAttributes = info.GetCustomAttributes(typeof(FloatPropertyRange), inherit: true);
			if (customAttributes.Length == 0)
			{
				customAttributes = info.GetCustomAttributes(typeof(ToggleGroupProperty), inherit: true);
				if (customAttributes.Length == 1)
				{
					_isGroupToggle = true;
				}
			}
			else
			{
				_range = (FloatPropertyRange)customAttributes[0];
			}
			object value = info.GetValue(filterInstance, null);
			if (value is float)
			{
				_currentValue = (float)value;
				_labelString = _info.Name + ": " + _currentValue.ToString("0.00");
			}
			else if (value is double)
			{
				_currentValue = (float)(double)value;
				_labelString = _info.Name + ": " + _currentValue.ToString("0.00");
			}
			else if (value is bool)
			{
				GroupToggleState = (bool)value;
				_labelString = _info.Name;
			}
			_filter = filterInstance;
		}
	}

	[SerializeField]
	private int _slotIndex = -1;

	[SerializeField]
	protected bool _bypass;

	public int SlotIndex => _slotIndex;

	public bool Bypass
	{
		get
		{
			return _bypass;
		}
		set
		{
			if (value != _bypass)
			{
				if (!value)
				{
					ResetFilter();
				}
				_bypass = value;
			}
		}
	}

	public abstract Type ControlInterfaceType { get; }

	public abstract int NbOfFilterableChannels { get; }

	public virtual void InitFilter(int slotIndex)
	{
		_slotIndex = slotIndex;
	}

	public abstract void ResetFilter();

	public abstract bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData);

	public FilterProperty[] GetFilterProperties()
	{
		PropertyInfo[] properties = ControlInterfaceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		FilterProperty[] array = new FilterProperty[properties.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new FilterProperty(properties[i], this);
		}
		return array;
	}
}
