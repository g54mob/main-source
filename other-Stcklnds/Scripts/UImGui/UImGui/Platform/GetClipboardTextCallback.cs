using System.Runtime.InteropServices;

namespace UImGui.Platform
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate string GetClipboardTextCallback(void* user_data);
}
