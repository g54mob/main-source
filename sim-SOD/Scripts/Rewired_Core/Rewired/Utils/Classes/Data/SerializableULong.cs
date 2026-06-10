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
				return 0uL;
			}
			set
			{
			}
		}

		public SerializableULong()
		{
		}

		public SerializableULong(SerializableULong sULong)
		{
		}

		private void TopjOVIoxoyzgbZsXuBiDPRgkXE(ulong P_0, out int P_1, out int P_2)
		{
			P_1 = default(int);
			P_2 = default(int);
		}

		private ulong oICbRCjGWyEnltoxVqMbMEoHNLAv(int P_0, int P_1)
		{
			return 0uL;
		}

		public SerializableULong Clone()
		{
			return null;
		}
	}
}
