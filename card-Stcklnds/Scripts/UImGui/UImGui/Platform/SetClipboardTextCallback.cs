using System.Runtime.InteropServices;

namespace UImGui.Platform
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void SetClipboardTextCallback(void* user_data, byte* text);
}
