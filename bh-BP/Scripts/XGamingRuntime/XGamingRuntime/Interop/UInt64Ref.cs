using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[StructLayout((LayoutKind)0)]
	internal class UInt64Ref
	{
		internal readonly ulong Value;

		internal UInt64Ref(ulong value)
		{
		}
	}
}
