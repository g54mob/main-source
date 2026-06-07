using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct UnityColor
	{
		public float Red { get; set; }

		public float Green { get; set; }

		public float Blue { get; set; }

		public float Alpha { get; set; }

		public static implicit operator Color(UnityColor nativeColor)
		{
			return default(Color);
		}

		public static explicit operator UnityColor(Color color)
		{
			return default(UnityColor);
		}
	}
}
