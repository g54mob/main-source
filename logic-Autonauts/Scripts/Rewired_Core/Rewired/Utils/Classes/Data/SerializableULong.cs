using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public class SerializableULong
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int ulong_32BitLow;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int ulong_32BitHigh;

		public ulong value
		{
			get
			{
				return xEFotzSHODeXVMXuQjgxEKMxCnF(ulong_32BitLow, ulong_32BitHigh);
			}
			set
			{
				SquTrvWlqFdxVHlUKPdJVpnIlgU(value, out ulong_32BitLow, out ulong_32BitHigh);
			}
		}

		public SerializableULong()
		{
		}

		public SerializableULong(SerializableULong sULong)
		{
			ulong_32BitLow = sULong.ulong_32BitLow;
			ulong_32BitHigh = sULong.ulong_32BitHigh;
		}

		private void SquTrvWlqFdxVHlUKPdJVpnIlgU(ulong P_0, out int P_1, out int P_2)
		{
			P_1 = (int)P_0;
			P_2 = (int)(P_0 >> 32);
		}

		private ulong xEFotzSHODeXVMXuQjgxEKMxCnF(int P_0, int P_1)
		{
			ulong num = (ulong)P_0;
			num &= 0xFFFFFFFFu;
			ulong num2 = (ulong)((long)P_1 << 32);
			return num | num2;
		}

		public SerializableULong Clone()
		{
			SerializableULong serializableULong = new SerializableULong();
			serializableULong.ulong_32BitLow = ulong_32BitLow;
			while (true)
			{
				int num = 541028156;
				while (true)
				{
					switch (num ^ 0x203F6F3D)
					{
					case 2:
						break;
					case 1:
						goto IL_0030;
					default:
						return serializableULong;
					}
					break;
					IL_0030:
					serializableULong.ulong_32BitHigh = ulong_32BitHigh;
					num = 541028157;
				}
			}
		}
	}
}
