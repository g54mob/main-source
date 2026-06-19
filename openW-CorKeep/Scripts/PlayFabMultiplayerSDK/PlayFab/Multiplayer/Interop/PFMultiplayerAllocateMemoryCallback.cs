using System;
using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void* PFMultiplayerAllocateMemoryCallback(UIntPtr size, uint memoryTypeId);
}
