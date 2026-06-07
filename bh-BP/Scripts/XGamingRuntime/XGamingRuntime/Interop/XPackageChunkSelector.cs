using System;

namespace XGamingRuntime.Interop
{
	internal struct XPackageChunkSelector
	{
		internal XPackageChunkSelectorType type;

		internal UIntPtr unionData;

		internal string LanguageOrTagOrFeature()
		{
			return null;
		}

		internal uint ChunkId()
		{
			return 0u;
		}
	}
}
