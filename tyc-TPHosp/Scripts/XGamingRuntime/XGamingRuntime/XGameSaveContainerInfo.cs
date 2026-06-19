using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveContainerInfo
	{
		public string Name { get; }

		public string DisplayName { get; }

		public uint BlobCount { get; }

		public ulong TotalSize { get; }

		public DateTime LastModifiedTime { get; }

		internal XGameSaveContainerInfo(XGamingRuntime.Interop.XGameSaveContainerInfo interopInfo)
		{
			Name = interopInfo.name.GetString();
			DisplayName = interopInfo.displayName.GetString();
			BlobCount = interopInfo.blobCount;
			TotalSize = interopInfo.totalSize;
			LastModifiedTime = interopInfo.lastModifiedTime.DateTime;
		}
	}
}
