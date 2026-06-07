using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class Vector2SizeModifier : ScreenDependentSize<Vector2>
	{
		public SizeModifierCollection ModX;

		public SizeModifierCollection ModY;

		public Vector2SizeModifier(Vector2 optimizedSize, Vector2 minSize, Vector2 maxSize)
			: base((Vector2)default(_00210), (Vector2)default(_00210), (Vector2)default(_00210), (Vector2)default(_00210))
		{
		}

		public override IEnumerable<SizeModifierCollection> GetModifiers()
		{
			return null;
		}

		protected override void AdjustSize(float factor, SizeModifierCollection mod, int index)
		{
		}

		protected override void CalculateOptimizedSize(Vector2 baseValue, float factor, SizeModifierCollection mod, int index)
		{
		}
	}
}
