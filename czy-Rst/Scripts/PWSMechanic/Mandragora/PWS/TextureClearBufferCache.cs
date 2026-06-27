using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.PWS
{
	public static class TextureClearBufferCache
	{
		private static readonly Dictionary<int, Color32[]> Buffers = new Dictionary<int, Color32[]>();

		public static Color32[] Get(int pixelCount)
		{
			if (!Buffers.TryGetValue(pixelCount, out var value))
			{
				value = new Color32[pixelCount];
				Buffers[pixelCount] = value;
			}
			return value;
		}
	}
}
