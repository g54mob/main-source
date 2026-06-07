using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class LayerEx
	{
		public static int GetMinLayer()
		{
			return 0;
		}

		public static int GetMaxLayer()
		{
			return 31;
		}

		public static bool IsLayerBitSet(int layerBits, int layerNumber)
		{
			return (layerBits & (1 << layerNumber)) != 0;
		}

		public static int SetLayerBit(int layerBits, int layerNumber)
		{
			return layerBits | (1 << layerNumber);
		}

		public static int ClearLayerBit(int layerBits, int layerNumber)
		{
			return layerBits & ~(1 << layerNumber);
		}

		public static bool IsLayerValid(int layerNumber)
		{
			if (layerNumber >= GetMinLayer())
			{
				return layerNumber <= GetMaxLayer();
			}
			return false;
		}

		public static List<string> GetAllLayerNames()
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= 31; i++)
			{
				string text = LayerMask.LayerToName(i);
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			return list;
		}
	}
}
