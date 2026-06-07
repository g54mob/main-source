using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class SizeModifierCollection
	{
		[Serializable]
		public class SizeModifier
		{
			public ImpactMode Mode;

			public float Impact;

			public SizeModifier()
			{
			}

			public SizeModifier(ImpactMode mode, float impact)
			{
			}

			internal float GetFactor(Component caller, Vector2 optimizedResolution, Vector2 actualResolution, float optimizedDpi, float actualDpi)
			{
				return 0f;
			}

			private float CalculateSize(float optimizedValue, float actualValue, float impact)
			{
				return 0f;
			}
		}

		public float ExponentialScale;

		public List<SizeModifier> SizeModifiers;

		public SizeModifierCollection(params SizeModifier[] mods)
		{
		}

		public SizeModifierCollection(float exponentialScale, params SizeModifier[] mods)
		{
		}

		public float CalculateFactor(Component caller, string screenConfig)
		{
			return 0f;
		}

		public SizeModifierCollection Clone()
		{
			return null;
		}

		public void CopyTo(SizeModifierCollection other)
		{
		}
	}
}
