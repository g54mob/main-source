using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct XPackageChunkSelector
	{
		[FieldOffset(0)]
		internal XPackageChunkSelectorType type;

		[FieldOffset(4)]
		internal UTF8StringPtr languageOrTag;

		[FieldOffset(4)]
		internal uint chunkId;
	}
}
