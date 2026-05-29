using System;
using UnityEngine;

namespace ScheduleOne.Graffiti
{
	[Serializable]
	public struct UShort2
	{
		public ushort X;

		public ushort Y;

		public UShort2(ushort x, ushort y)
		{
			X = 0;
			Y = 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static UShort2 operator +(UShort2 a, UShort2 b)
		{
			return default(UShort2);
		}

		public static UShort2 operator -(UShort2 a, UShort2 b)
		{
			return default(UShort2);
		}

		public static implicit operator Vector2(UShort2 uShort2)
		{
			return default(Vector2);
		}
	}
}
