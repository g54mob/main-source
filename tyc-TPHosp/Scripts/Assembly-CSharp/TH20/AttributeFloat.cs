using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AttributeFloat : AttributeBase<float>
	{
		private class ModifierRecord
		{
			public float _timeAdded;

			public AttributeModifier _modifier;
		}

		private List<ModifierRecord> _modifiers;

		public AttributeFloat(float initialValue, float minValue, float maxValue)
			: base(initialValue, minValue, maxValue)
		{
		}

		public void Update(float modificationOverTime, float deltaTime, float multiplier)
		{
			float num = modificationOverTime * deltaTime;
			if (_modifiers != null)
			{
				for (int i = 0; i < _modifiers.Count; i++)
				{
					ModifierRecord modifierRecord = _modifiers[i];
					num += modifierRecord._modifier.AmountToModify(deltaTime);
				}
				_modifiers.RemoveAll((ModifierRecord o) => GameTime.time - o._timeAdded >= o._modifier.TimeToModify());
			}
			Modify(num, multiplier);
		}

		public void AddModifier(AttributeModifier modifier)
		{
			if (_modifiers == null)
			{
				_modifiers = new List<ModifierRecord>();
			}
			_modifiers.Add(new ModifierRecord
			{
				_modifier = modifier,
				_timeAdded = GameTime.time
			});
		}

		public void Modify(float modifyValue, float multiplier)
		{
			_lastValue = _value;
			modifyValue *= multiplier;
			_value = Mathf.Clamp(_value + modifyValue, _min, _max);
			if (!_lastValue.Equals(_value))
			{
				CheckCallbacks();
			}
		}

		protected override int CompareValues(float lhs, float rhs)
		{
			if (lhs < rhs)
			{
				return -1;
			}
			if (lhs > rhs)
			{
				return 1;
			}
			return 0;
		}
	}
}
