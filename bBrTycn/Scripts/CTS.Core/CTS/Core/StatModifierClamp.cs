using System;
using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Statistics/Modifiers/Clamp")]
	public class StatModifierClamp : StatModifierData
	{
		[SerializeField]
		private Vector2 _clampValue;

		public override bool ShouldModifySet()
		{
			return true;
		}

		public override bool ShouldModifyGet()
		{
			return true;
		}

		public override float Modify(float inValue)
		{
			return Math.Clamp(inValue, _clampValue.x, _clampValue.y);
		}
	}
}
