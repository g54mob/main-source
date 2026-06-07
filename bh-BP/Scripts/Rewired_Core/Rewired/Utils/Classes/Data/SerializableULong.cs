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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public SerializableULong(SerializableULong P_0)
		{
		}

		private void eEIrrjWSwkADaYPZNeEJJfRWTKTIA(ulong P_0, out int P_1, out int P_2)
		{
			P_1 = default(int);
			P_2 = default(int);
		}

		private ulong GtGTMQIPfUNtSjhNZvMlAyopWEaR(int P_0, int P_1)
		{
			return 0uL;
		}

		public SerializableULong Clone()
		{
			return null;
		}
	}
}
