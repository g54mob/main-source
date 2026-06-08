using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public class SerializableULong
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int ulong_32BitLow;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int ulong_32BitHigh;

		public ulong value
		{
			get
			{
				return KbVCraoBxBhxOtiTRiMuEYmcXVg(ulong_32BitLow, ulong_32BitHigh);
			}
			set
			{
				numHmgmYVNtiCeTzVlwEBwHTbgd(value, out ulong_32BitLow, out ulong_32BitHigh);
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

		private void numHmgmYVNtiCeTzVlwEBwHTbgd(ulong P_0, out int P_1, out int P_2)
		{
			P_1 = (int)P_0;
			P_2 = (int)(P_0 >> 32);
		}

		private ulong KbVCraoBxBhxOtiTRiMuEYmcXVg(int P_0, int P_1)
		{
			ulong num = (ulong)P_0;
			num &= 0xFFFFFFFFu;
			ulong num2 = (ulong)((long)P_1 << 32);
			return num | num2;
		}

		public SerializableULong Clone()
		{
			SerializableULong serializableULong = new SerializableULong();
			while (true)
			{
				int num = 1336202315;
				while (true)
				{
					switch (num ^ 0x4FA4D44A)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						serializableULong.ulong_32BitHigh = ulong_32BitHigh;
						return serializableULong;
					}
					break;
					IL_0024:
					serializableULong.ulong_32BitLow = ulong_32BitLow;
					num = 1336202314;
				}
			}
		}
	}
}
