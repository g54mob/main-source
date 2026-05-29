using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarIntRange : CVarInt
	{
		[Serializable]
		public struct FixedValues
		{
			public Vector2Int _range;
		}

		[SerializeField]
		private FixedValues _fixedValues;

		internal CVarIntRange()
		{
		}

		public override void SetCurrentValue(int newValue)
		{
			newValue = Math.Clamp(newValue, _fixedValues._range.x, _fixedValues._range.y);
			base.SetCurrentValue(newValue);
		}

		public override void CopyFrom(ConsoleVarValue other)
		{
			if (other is CVarIntRange cVarIntRange)
			{
				_fixedValues = cVarIntRange._fixedValues;
			}
		}

		public override void OnBeforeSerialize()
		{
			_defaultValue = Math.Clamp(_defaultValue, _fixedValues._range.x, _fixedValues._range.y);
			base.OnBeforeSerialize();
		}
	}
}
