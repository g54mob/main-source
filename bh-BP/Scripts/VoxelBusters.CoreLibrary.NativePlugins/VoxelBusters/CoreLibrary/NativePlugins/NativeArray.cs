using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct NativeArray
	{
		public IntPtr Pointer { get; set; }

		public int Length { get; set; }

		public T[] GetStructArray<T>() where T : struct
		{
			return null;
		}

		public string[] GetStringArray()
		{
			return null;
		}
	}
}
