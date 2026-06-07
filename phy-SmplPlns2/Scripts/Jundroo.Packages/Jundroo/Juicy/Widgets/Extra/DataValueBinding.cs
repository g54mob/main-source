using System;
using System.Reflection;
using Jundroo.Common.Math;
using Jundroo.Juicy.Widgets.Serialization;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class DataValueBinding : IDynamicValue
	{
		public const string StartSequence = "{|";

		private AttributeSet _attributeSet;

		private object _dataModel;

		private object _lastValue;

		private Func<object, object> _propertyAccessor;

		public string BindingPath { get; }

		public string Format { get; }

		public string Name { get; }

		public Widget Widget { get; }

		public DataValueBinding(Widget widget, AttributeSet attributeSet, string name, string value)
		{
			_attributeSet = attributeSet;
			Widget = widget;
			Name = name;
			value = value.Trim('{', '}', '|');
			int num = value.IndexOf(':');
			if (num >= 0)
			{
				BindingPath = value.Substring(0, num);
				Format = value.Substring(num + 1);
			}
			else
			{
				BindingPath = value;
			}
		}

		public object GetCurrentValue(object dataModel)
		{
			if (_propertyAccessor == null || _dataModel != dataModel)
			{
				_dataModel = dataModel;
				_propertyAccessor = GetPropertyAccessorByPath(dataModel, BindingPath);
			}
			if (_propertyAccessor != null)
			{
				return _propertyAccessor(dataModel);
			}
			return null;
		}

		public void UpdateValue(object dataModel)
		{
			object currentValue = GetCurrentValue(dataModel);
			if (object.Equals(_lastValue, currentValue))
			{
				return;
			}
			_lastValue = currentValue;
			string value = string.Empty;
			if (Format != null && currentValue is IFormattable formattable)
			{
				if (!HandleCustomFormat(currentValue, Format, out value))
				{
					value = formattable.ToString(Format, null);
				}
			}
			else
			{
				value = currentValue?.ToString() ?? string.Empty;
			}
			_attributeSet.ApplyAttribute(Widget, Name, value);
		}

		private static Func<object, object> GetPropertyAccessorByPath(object obj, string bindingPath)
		{
			string[] array = bindingPath.Split('.');
			PropertyInfo[] propertyInfos = new PropertyInfo[array.Length];
			Type type = obj?.GetType();
			for (int i = 0; i < array.Length; i++)
			{
				if (type == null)
				{
					break;
				}
				PropertyInfo property = type.GetProperty(array[i]);
				if (property == null)
				{
					throw new ArgumentException("Property '" + array[i] + "' not found on type '" + type.Name + "'");
				}
				propertyInfos[i] = property;
				type = property.PropertyType;
			}
			if (type != null)
			{
				return delegate(object model)
				{
					object obj2 = model;
					PropertyInfo[] array2 = propertyInfos;
					foreach (PropertyInfo propertyInfo in array2)
					{
						if (obj2 == null)
						{
							return (object)null;
						}
						obj2 = propertyInfo.GetValue(obj2);
					}
					return obj2;
				};
			}
			return null;
		}

		private bool HandleCustomFormat(object result, string format, out string value)
		{
			switch (format)
			{
			case "velocity":
				value = ((float)result).Format(UnitType.Speed);
				break;
			case "mass":
				value = ((float)result).Format(UnitType.Mass);
				break;
			case "distance":
				value = ((float)result).Format(UnitType.LongDistance, solo: false, longName: false, "0.0");
				break;
			default:
				value = string.Empty;
				return false;
			}
			return true;
		}
	}
}
