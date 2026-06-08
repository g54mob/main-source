using System;

namespace XGamingRuntime.Interop
{
	internal struct XPackageChunkSelector
	{
		internal XPackageChunkSelectorType type;

		internal UIntPtr unionData;

		internal unsafe string LanguageOrTagOrFeature()
		{
			return Converters.PtrToStringUTF8((IntPtr)unionData.ToPointer());
		}

		internal uint ChunkId()
		{
			return Convert.ToUInt32(unionData.ToUInt64() & 0xFFFFFFFFu);
		}
	}
}
