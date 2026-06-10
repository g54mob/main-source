using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public struct SerializableVector2Int
	{
		private static readonly SerializableVector2Int sZero = new SerializableVector2Int(0, 0);

		private static readonly SerializableVector2Int sOne = new SerializableVector2Int(1, 1);

		public int x;

		public int y;

		public static SerializableVector2Int zero => sZero;

		public static SerializableVector2Int one => sOne;

		public SerializableVector2Int(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static implicit operator Vector2(SerializableVector2Int value)
		{
			return new Vector2(value.x, value.y);
		}

		public static implicit operator Vector2Int(SerializableVector2Int value)
		{
			return new Vector2Int(value.x, value.y);
		}

		public static implicit operator SerializableVector2Int(Vector2Int value)
		{
			return new SerializableVector2Int(value.x, value.y);
		}

		public static bool operator ==(SerializableVector2Int m, SerializableVector2Int n)
		{
			return m.Equals(n);
		}

		public static bool operator !=(SerializableVector2Int m, SerializableVector2Int n)
		{
			return !(m == n);
		}

		public override int GetHashCode()
		{
			int hashCode = y.GetHashCode();
			return x.GetHashCode() ^ (hashCode << 4) ^ (hashCode >> 28);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is Vector2Int)
			{
				return Equals((Vector2Int)obj);
			}
			if (obj is SerializableVector2Int)
			{
				return Equals((SerializableVector2Int)obj);
			}
			return false;
		}

		public bool Equals(Vector2Int value)
		{
			if (value.x == x)
			{
				return value.y == y;
			}
			return false;
		}

		public bool Equals(SerializableVector2Int value)
		{
			if (value.x == x)
			{
				return value.y == y;
			}
			return false;
		}

		public override string ToString()
		{
			return $"[X:{x}, Y:{y}]";
		}
	}
}
