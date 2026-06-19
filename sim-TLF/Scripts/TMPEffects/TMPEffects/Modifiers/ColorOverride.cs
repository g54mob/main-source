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

		public bool OverrideAlpha => Override.HasFlag(OverrideMode.Alpha);

		public bool OverrideColor => Override.HasFlag(OverrideMode.Color);

		public ColorOverride(ColorOverride original)
		{
			Color = original.Color;
			Override = original.Override;
		}

		public ColorOverride(Color32 color, OverrideMode overrideMode)
		{
			Override = overrideMode;
			Color = color;
		}

		public Color32 GetValue(Color32 fallback)
		{
			Color32 result = ((!OverrideColor) ? fallback : Color);
			if (OverrideAlpha)
			{
				result.a = Color.a;
			}
			else
			{
				result.a = fallback.a;
			}
			return result;
		}

		public bool Equals(ColorOverride obj)
		{
			if (Override == obj.Override && Color.r == obj.Color.r && Color.g == obj.Color.g && Color.b == obj.Color.b)
			{
				return Color.a == obj.Color.a;
			}
			return false;
		}

		public static ColorOverride LerpUnclamped(ColorOverride start, Color32 end, float t)
		{
			return LerpUnclamped(end, start, 1f - t);
		}

		public static ColorOverride LerpUnclamped(Color32 start, ColorOverride end, float t)
		{
			if (t >= 1f)
			{
				return new ColorOverride(end);
			}
			if (t <= 0f)
			{
				return new ColorOverride
				{
					Color = start,
					Override = end.Override
				};
			}
			return new ColorOverride
			{
				Color = Color32.LerpUnclamped(start, end.Color, t),
				Override = end.Override
			};
		}

		public static ColorOverride LerpUnclamped(ColorOverride start, ColorOverride end, float t)
		{
			ColorOverride result = default(ColorOverride);
			byte b = 0;
			byte b2 = 0;
			byte b3 = 0;
			byte b4 = 0;
			Color32 color;
			if (t >= 1f)
			{
				if (end.OverrideAlpha)
				{
					result.Override |= OverrideMode.Alpha;
				}
				b4 = end.Color.a;
				if (end.OverrideColor)
				{
					result.Override |= OverrideMode.Color;
				}
				b = end.Color.r;
				b2 = end.Color.g;
				b3 = end.Color.b;
				color = new Color32(b, b2, b3, b4);
			}
			else if (t <= 0f)
			{
				if (start.OverrideAlpha)
				{
					result.Override |= OverrideMode.Alpha;
				}
				b4 = start.Color.a;
				if (start.OverrideColor)
				{
					result.Override |= OverrideMode.Color;
				}
				b = start.Color.r;
				b2 = start.Color.g;
				b3 = start.Color.b;
				color = new Color32(b, b2, b3, b4);
			}
			else
			{
				color = Color32.Lerp(start.Color, end.Color, t);
				if (start.OverrideAlpha || end.OverrideAlpha)
				{
					result.Override |= OverrideMode.Alpha;
				}
				if (start.OverrideColor || end.OverrideColor)
				{
					result.Override |= OverrideMode.Color;
				}
			}
			result.Color = color;
			return result;
		}

		public static ColorOverride operator +(ColorOverride lhs, ColorOverride rhs)
		{
			ColorOverride result = default(ColorOverride);
			byte r = 0;
			byte g = 0;
			byte b = 0;
			byte a = 0;
			if (rhs.OverrideAlpha)
			{
				result.Override |= OverrideMode.Alpha;
				a = rhs.Color.a;
			}
			else if (lhs.OverrideAlpha)
			{
				result.Override |= OverrideMode.Alpha;
				a = lhs.Color.a;
			}
			if (rhs.OverrideColor)
			{
				result.Override |= OverrideMode.Color;
				r = rhs.Color.r;
				g = rhs.Color.g;
				b = rhs.Color.b;
			}
			else if (lhs.OverrideColor)
			{
				result.Override |= OverrideMode.Color;
				r = lhs.Color.r;
				g = lhs.Color.g;
				b = lhs.Color.b;
			}
			result.Color = new Color32(r, g, b, a);
			return result;
		}

		public override string ToString()
		{
			string[] obj = new string[5] { "{ Color: ", null, null, null, null };
			Color32 color = Color;
			obj[1] = color.ToString();
			obj[2] = " Override: ";
			obj[3] = Override.ToString();
			obj[4] = " }";
			return string.Concat(obj);
		}
	}
}
