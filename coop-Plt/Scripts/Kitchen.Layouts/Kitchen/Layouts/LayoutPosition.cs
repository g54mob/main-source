using System;
using MessagePack;
using UnityEngine;

namespace Kitchen.Layouts
{
	[Serializable]
	[MessagePackObject(false)]
	public struct LayoutPosition : IEquatable<LayoutPosition>
	{
		[Key(0)]
		public readonly int x;

		[Key(1)]
		public readonly int y;

		public LayoutPosition(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static implicit operator Vector2(LayoutPosition pos)
		{
			return new Vector2(pos.x, pos.y);
		}

		public static implicit operator LayoutPosition(Vector2 pos)
		{
			return new LayoutPosition((int)pos.x, (int)pos.y);
		}

		public static implicit operator Vector3(LayoutPosition pos)
		{
			return new Vector3(pos.x, 0f, pos.y);
		}

		public static implicit operator LayoutPosition(Vector3 pos)
		{
			return new LayoutPosition((int)pos.x, (int)pos.z);
		}

		public static implicit operator LayoutPosition(Orientation pos)
		{
			Vector3 vector = pos.ToOffset();
			return new LayoutPosition((int)vector.x, (int)vector.z);
		}

		public static LayoutPosition operator +(LayoutPosition p1)
		{
			return p1;
		}

		public static LayoutPosition operator -(LayoutPosition p1)
		{
			return new LayoutPosition(-p1.x, -p1.y);
		}

		public static LayoutPosition operator +(LayoutPosition p1, LayoutPosition p2)
		{
			return new LayoutPosition(p1.x + p2.x, p1.y + p2.y);
		}

		public static LayoutPosition operator -(LayoutPosition p1, LayoutPosition p2)
		{
			return new LayoutPosition(p1.x - p2.x, p1.y - p2.y);
		}

		public bool Equals(LayoutPosition other)
		{
			if (x == other.x)
			{
				return y == other.y;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is LayoutPosition other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return x * 123128427 + y;
		}

		public static bool operator ==(LayoutPosition left, LayoutPosition right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(LayoutPosition left, LayoutPosition right)
		{
			return !left.Equals(right);
		}
	}
}
