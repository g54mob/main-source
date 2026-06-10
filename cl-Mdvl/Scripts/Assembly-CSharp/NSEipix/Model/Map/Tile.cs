using System;
using NSEipix.Base;
using UnityEngine;

namespace NSEipix.Model.Map
{
	[Serializable]
	public class Tile : NSEipix.Base.Model
	{
		private static readonly float SqrtTwo = Mathf.Sqrt(2f);

		private int? hashCode;

		[SerializeField]
		private int x;

		[SerializeField]
		private int y;

		public int X => x;

		public int Y => y;

		public Tile(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static bool operator ==(Tile m, Tile n)
		{
			if ((object)m == n)
			{
				return true;
			}
			if ((object)m == null || (object)n == null)
			{
				return false;
			}
			if (m.X == n.X)
			{
				return m.Y == n.Y;
			}
			return false;
		}

		public static bool operator !=(Tile m, Tile n)
		{
			return !(m == n);
		}

		public override int GetHashCode()
		{
			int? num = (hashCode = hashCode ?? ((x + y) * (x + y + 1) / 2 + y));
			return num.Value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is Tile tile))
			{
				return false;
			}
			if (tile.X == X)
			{
				return tile.Y == Y;
			}
			return false;
		}

		public bool Equals(Tile m)
		{
			if ((object)m == null)
			{
				return false;
			}
			if (m.X == x)
			{
				return m.Y == y;
			}
			return false;
		}

		public float Distance(Tile target)
		{
			int a = Mathf.Abs(target.X - X);
			int b = Mathf.Abs(target.Y - Y);
			int num = Mathf.Min(a, b);
			return SqrtTwo * (float)num + (float)(Mathf.Max(a, b) - num);
		}

		public override string GetID()
		{
			return $"{x},{y}";
		}
	}
}
