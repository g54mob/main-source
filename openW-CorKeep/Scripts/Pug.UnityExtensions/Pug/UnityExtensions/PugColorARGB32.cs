using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public readonly struct PugColorARGB32 : IEquatable<PugColorARGB32>
	{
		public readonly byte a;

		public readonly byte r;

		public readonly byte g;

		public readonly byte b;

		public PugColorARGB32(byte r, byte g, byte b, byte a)
		{
			this.a = a;
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public static implicit operator Color32(PugColorARGB32 c)
		{
			return new Color((int)c.r, (int)c.g, (int)c.b, (int)c.a);
		}

		public static implicit operator PugColorARGB32(Color32 c)
		{
			return new PugColorARGB32(c.r, c.g, c.b, c.a);
		}

		public static implicit operator Color(PugColorARGB32 c)
		{
			return new Color
			{
				r = (float)(int)c.r / 255f,
				b = (float)(int)c.b / 255f,
				g = (float)(int)c.g / 255f,
				a = (float)(int)c.a / 255f
			};
		}

		public static implicit operator PugColorARGB32(Color c)
		{
			return new PugColorARGB32((byte)math.round(c.r * 255f), (byte)math.round(c.g * 255f), (byte)math.round(c.b * 255f), (byte)math.round(c.a * 255f));
		}

		public bool Equals(PugColorARGB32 other)
		{
			if (a == other.a && r == other.r && g == other.g)
			{
				return b == other.b;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is PugColorARGB32 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (a << 24) | (r << 16) | (g << 8) | b;
		}
	}
}
