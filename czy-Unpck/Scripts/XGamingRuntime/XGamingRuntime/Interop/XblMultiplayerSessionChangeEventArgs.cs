using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionChangeEventArgs
	{
		internal XblMultiplayerSessionReference SessionReference;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal byte[] Branch;

		internal readonly ulong ChangeNumber;

		internal unsafe string GetBranch()
		{
			fixed (byte* branch = Branch)
			{
				return Converters.BytePointerToString(branch, 40);
			}
		}
	}
}
