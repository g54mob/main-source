using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class Vector3SizeModifier : ScreenDependentSize<Vector3>
	{
		public SizeModifierCollection ModX;

		public SizeModifierCollection ModY;

		public SizeModifierCollection ModZ;

		public Vector3SizeModifier(Vector3 optimizedSize, Vector3 minSize, Vector3 maxSize)
			: base((Vector3)default(_00210), (Vector3)default(_00210), (Vector3)default(_00210), (Vector3)default(_00210))
		{
		}

		public override IEnumerable<SizeModifierCollection> GetModifiers()
		{
			return null;
		}

		protected override void AdjustSize(float factor, SizeModifierCollection mod, int index)
		{
		}

		protected override void CalculateOptimizedSize(Vector3 baseValue, float factor, SizeModifierCollection mod, int index)
		{
		}
	}
}
