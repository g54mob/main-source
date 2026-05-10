using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Core.StatisticsSystem
{
	[Serializable]
	public class NumericStatistic
	{
		[SerializeField]
		[ReadOnly]
		[AllowNesting]
		private float _value;

		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				float value2 = Value;
				_value = Mathf.Clamp(value, Min, Max);
				if (value2 != _value)
				{
					this.ValueChanged?.Invoke(_value);
					this.UnitIntervalChanged?.Invoke(UnitInterval);
				}
			}
		}

		public int IntValue => (int)Value;

		[field: SerializeField]
		public Vector2 ValueRange { get; set; } = Vector2.zero;

		public float Min => Mathf.Min(ValueRange.x, ValueRange.y);

		public float Max => Mathf.Max(ValueRange.x, ValueRange.y);

		[field: SerializeField]
		public Vector2 InitializationRange { get; set; } = Vector2.zero;

		public float UnitInterval => Mathf.InverseLerp(ValueRange.x, ValueRange.y, Value);

		public float PercentageValue => UnitInterval * 100f;

		[field: SerializeField]
		public bool PublicValue { get; set; }

		public event Action<float> ValueChanged;

		public event Action<float> UnitIntervalChanged;

		public void InitializeValue()
		{
			Value = UnityEngine.Random.Range(InitializationRange.x, InitializationRange.y);
		}

		public void AddToValue(float toAdd)
		{
			Value += toAdd;
		}

		public void SetValueFromPercentage(float percentage)
		{
			percentage = Mathf.Clamp(percentage, 0f, 100f);
			SetValueFromUnitInterval(percentage / 100f);
		}

		public void SetValueFromUnitInterval(float unitInterval)
		{
			unitInterval = Mathf.Clamp01(unitInterval);
			Value = Mathf.Lerp(ValueRange.x, ValueRange.y, unitInterval);
		}

		public NumericStatistic(Vector2 valueRange, Vector2 initializationRange, bool publicValue)
		{
			ValueRange = valueRange;
			InitializationRange = initializationRange;
			PublicValue = publicValue;
			InitializeValue();
		}

		public NumericStatistic(NumericStatistic baseNumericStatistic)
			: this(baseNumericStatistic.ValueRange, baseNumericStatistic.InitializationRange, baseNumericStatistic.PublicValue)
		{
		}
	}
}
