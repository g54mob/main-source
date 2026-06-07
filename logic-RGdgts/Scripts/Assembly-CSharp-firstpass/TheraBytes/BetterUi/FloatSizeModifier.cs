using System;
using System.Collections.Generic;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class FloatSizeModifier : ScreenDependentSize<float>
	{
		public SizeModifierCollection Mod;

		public FloatSizeModifier(float optimizedSize, float minSize, float maxSize)
			: base((float)default(_00210), (float)default(_00210), (float)default(_00210), (float)default(_00210))
		{
		}//IL_002a: Expected F4, but got O
		//IL_002a: Expected F4, but got O
		//IL_002a: Expected F4, but got O
		//IL_002a: Expected F4, but got O


		public override IEnumerable<SizeModifierCollection> GetModifiers()
		{
			return null;
		}

		protected override void AdjustSize(float factor, SizeModifierCollection mod, int index)
		{
		}

		protected override void CalculateOptimizedSize(float baseValue, float factor, SizeModifierCollection mod, int index)
		{
		}
	}
}
