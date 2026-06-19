using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public struct ColorOverride
	{
		[Flags]
		public enum OverrideMode : byte
		{
			None = 0,
			Color = 1,
			Alpha = 2
		}

		public OverrideMode Override;

		public Color32 Color;

		public bool OverrideAlpha => false;

		public bool OverrideColor => false;

		public ColorOverride(ColorOverride original)
		{
			Override = default(OverrideMode);
			Color = default(Color32);
		}

		public ColorOverride(Color32 color, OverrideMode overrideMode)
		{
			Override = default(OverrideMode);
			Color = default(Color32);
		}

		public Color32 GetValue(Color32 fallback)
		{
			return default(Color32);
		}

		public bool Equals(ColorOverride obj)
		{
			return false;
		}

		public static ColorOverride LerpUnclamped(ColorOverride start, Color32 end, float t)
		{
			return default(ColorOverride);
		}

		public static ColorOverride LerpUnclamped(Color32 start, ColorOverride end, float t)
		{
			return default(ColorOverride);
		}

		public static ColorOverride LerpUnclamped(ColorOverride start, ColorOverride end, float t)
		{
			return default(ColorOverride);
		}

		public static ColorOverride operator +(ColorOverride lhs, ColorOverride rhs)
		{
			return default(ColorOverride);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
