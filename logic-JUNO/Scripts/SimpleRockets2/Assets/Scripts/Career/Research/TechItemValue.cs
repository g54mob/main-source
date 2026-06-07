using UnityEngine;

namespace Assets.Scripts.Career.Research
{
	public class TechItemValue
	{
		public enum ItemValueType
		{
			Bool = 0,
			Float = 1
		}

		private bool _valueBool;

		private float _valueFloat;

		private string _valueFormat;

		public string DisplayString => TechItem.NameText;

		public Vector3 PartRotation { get; }

		public float PartScale { get; }

		public TechItem TechItem { get; }

		public string Value { get; }

		public bool ValueAsBool => _valueBool;

		public float ValueAsFloat => _valueFloat;

		public string ValueString
		{
			get
			{
				if (ValueType == ItemValueType.Float)
				{
					return string.Format(_valueFormat, ValueAsFloat);
				}
				return TechItem.DisplayValue;
			}
		}

		public ItemValueType ValueType { get; }

		public bool Visible { get; }

		public TechItemValue(TechItem techItem, string value, string valueFormat, bool? visibleOverride, float? partScale = null, Vector3? partRotation = null)
		{
			TechItem = techItem;
			Value = value;
			if (float.TryParse(value, out _valueFloat))
			{
				ValueType = ItemValueType.Float;
				_valueBool = _valueFloat != 0f;
			}
			else
			{
				ValueType = ItemValueType.Bool;
				_valueBool = bool.Parse(value);
				_valueFloat = (_valueBool ? 1f : 0f);
			}
			_valueFormat = valueFormat ?? techItem.ValueFormat;
			Visible = visibleOverride ?? techItem.Visible;
			PartScale = partScale ?? 1f;
			PartRotation = partRotation ?? Vector3.zero;
		}
	}
}
