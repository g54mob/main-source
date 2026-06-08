using Unity.Collections;
using UnityEngine;

namespace Kitchen
{
	public struct Reachability
	{
		public BitField32 Matrix;

		public bool this[int dx, int dy]
		{
			get
			{
				return Matrix.IsSet(Offset(dx, dy));
			}
			set
			{
				Matrix.SetBits(Offset(dx, dy), value);
			}
		}

		private bool this[int offset]
		{
			get
			{
				return Matrix.IsSet(offset);
			}
			set
			{
				Matrix.SetBits(offset, value);
			}
		}

		public bool NextAdjacent(out Vector2 result, int base_offset = 0)
		{
			for (int i = base_offset; i < 32; i++)
			{
				if (this[i])
				{
					result = GetOffset(i);
					return true;
				}
			}
			result = default(Vector2);
			return false;
		}

		public bool GetDirectional(float x, float y)
		{
			int dx = Mathf.RoundToInt(x);
			int dy = Mathf.RoundToInt(y);
			return this[dx, dy];
		}

		public static Reachability operator &(Reachability a, Reachability b)
		{
			Reachability result = default(Reachability);
			for (int i = 0; i < 32; i++)
			{
				result[i] = a[i] & b[i];
			}
			return result;
		}

		public static Reachability operator |(Reachability a, Reachability b)
		{
			Reachability result = default(Reachability);
			for (int i = 0; i < 32; i++)
			{
				result[i] = a[i] | b[i];
			}
			return result;
		}

		private static int Offset(int dx, int dy)
		{
			dx += 2;
			dy += 2;
			int num = dx + dy * 5;
			if (num < 0 || num > 31)
			{
				Debug.LogWarning($"Tried to access offset {dx}, {dy}");
				return 0;
			}
			return num;
		}

		private static Vector2 GetOffset(int index)
		{
			return new Vector2(index % 5 - 2, index / 5 - 2);
		}
	}
}
