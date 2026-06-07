using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct UnityCircularRegion
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public float Radius { get; set; }

		public IntPtr RegionIdPtr { get; set; }

		public static implicit operator UnityCircularRegion(CircularRegion circularRegion)
		{
			return default(UnityCircularRegion);
		}

		public static implicit operator CircularRegion(UnityCircularRegion circularRegion)
		{
			return default(CircularRegion);
		}
	}
}
