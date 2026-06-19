using System;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public struct PugColor32 : IEquatable<PugColor32>
	{
		public byte r;

		public byte g;

		public byte b;

		public byte a;

		public int rgba => (r << 24) | (g << 16) | (b << 8) | a;

		public static implicit operator Color32(PugColor32 e)
		{
			return new Color32(e.r, e.g, e.b, e.a);
		}

		public static implicit operator PugColor32(Color32 e)
		{
			return new PugColor32
			{
				r = e.r,
				g = e.g,
				b = e.b,
				a = e.a
			};
		}

		public static implicit operator Color(PugColor32 e)
		{
			return (Color32)e;
		}

		public static implicit operator PugColor32(Color e)
		{
			return (Color32)e;
		}

		public PugColor32(byte r, byte g, byte b, byte a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public bool Equals(PugColor32 other)
		{
			return rgba == other.rgba;
		}

		public override bool Equals(object obj)
		{
			if (obj is PugColor32 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return rgba.GetHashCode();
		}
	}
}
