using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	public class Block
	{
		public static int BlockSize = 1;

		public Color Color { get; private set; }

		public Block(Color _Color)
		{
			Color = _Color;
		}
	}
}
