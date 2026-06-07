using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct NativeError
	{
		public int Code { get; set; }

		public IntPtr DescriptionPtr { get; set; }
	}
}
