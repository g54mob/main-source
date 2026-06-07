using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct UnityRect
	{
		public float X { get; set; }

		public float Y { get; set; }

		public float Width { get; set; }

		public float Height { get; set; }

		public static implicit operator Rect(UnityRect nativeRect)
		{
			return default(Rect);
		}

		public static explicit operator UnityRect(Rect rect)
		{
			return default(UnityRect);
		}
	}
}
