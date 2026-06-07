using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public static class LayerUtils
	{
		public static int GetIndexOfFirstLayerInMask(LayerMask mask, int defaultIndex = -1)
		{
			for (int i = 0; i < 32; i++)
			{
				int num = 1 << i;
				if (((int)mask & num) > 0)
				{
					return i;
				}
			}
			return defaultIndex;
		}
	}
}
