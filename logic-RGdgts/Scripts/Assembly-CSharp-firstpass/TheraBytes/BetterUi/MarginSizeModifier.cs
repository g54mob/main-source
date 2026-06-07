using System;
using System.Collections.Generic;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class MarginSizeModifier : ScreenDependentSize<Margin>
	{
		public SizeModifierCollection ModLeft;

		public SizeModifierCollection ModRight;

		public SizeModifierCollection ModTop;

		public SizeModifierCollection ModBottom;

		public MarginSizeModifier(Margin optimizedSize, Margin minSize, Margin maxSize)
			: base((Margin)default(_00210), (Margin)default(_00210), (Margin)default(_00210), (Margin)default(_00210))
		{
		}

		public override void DynamicInitialization()
		{
		}

		public override IEnumerable<SizeModifierCollection> GetModifiers()
		{
			return null;
		}

		protected override void AdjustSize(float factor, SizeModifierCollection mod, int index)
		{
		}

		protected override void CalculateOptimizedSize(Margin baseValue, float factor, SizeModifierCollection mod, int index)
		{
		}
	}
}
