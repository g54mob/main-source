using System.Runtime.InteropServices;

namespace UImGui.Platform
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ImeSetInputScreenPosCallback(int x, int y);
}
