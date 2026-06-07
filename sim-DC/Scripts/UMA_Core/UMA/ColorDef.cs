using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public struct ColorDef
	{
		public int chan;

		public uint mCol;

		public uint aCol;

		public ColorDef(int Channels, uint MCol, uint ACol)
		{
			chan = 0;
			mCol = 0u;
			aCol = 0u;
		}

		public static uint ToUInt(Color32 color)
		{
			return 0u;
		}

		public static Color32 ToColor(uint color)
		{
			return default(Color32);
		}
	}
}
