using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct UnityAttachment
	{
		public int DataArrayLength { get; set; }

		public IntPtr DataArrayPtr { get; set; }

		public IntPtr MimeTypePtr { get; set; }

		public IntPtr FileNamePtr { get; set; }
	}
}
