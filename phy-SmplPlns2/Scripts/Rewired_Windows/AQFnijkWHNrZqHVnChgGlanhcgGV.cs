using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class AQFnijkWHNrZqHVnChgGlanhcgGV : fwXJMrqTnqlNTIdOTYtiNwtNDijB
{
	[CompilerGenerated]
	private mtNcaKVQQjgkmRbmzgRSHcUSQywh TmRIPCCexgGEOgnJfJOAksrNLyaw;

	public mtNcaKVQQjgkmRbmzgRSHcUSQywh UIqvjYSjBljszfFaCKUrqBRUQuSfA
	{
		[CompilerGenerated]
		get
		{
			return TmRIPCCexgGEOgnJfJOAksrNLyaw;
		}
		[CompilerGenerated]
		private set
		{
			TmRIPCCexgGEOgnJfJOAksrNLyaw = tmRIPCCexgGEOgnJfJOAksrNLyaw;
		}
	}

	protected abstract zmOJlfDCdiCGHeQbKxXwAxjfChSB VCvSBGDUXzecvqzVdHSYjFbnBdOAA { get; }

	public unsafe virtual void iTEarVAyvuycXQXMlFYBPhUqlFKl(mtNcaKVQQjgkmRbmzgRSHcUSQywh P_0)
	{
		UIqvjYSjBljszfFaCKUrqBRUQuSfA = P_0;
		base.fREGeAsscSanGSwlvHwWDQIMIYWO = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.fREGeAsscSanGSwlvHwWDQIMIYWO, VCvSBGDUXzecvqzVdHSYjFbnBdOAA.wLLCQXgyDPcTrSRsnhegUOBWHjTS);
		((IntPtr*)(void*)base.fREGeAsscSanGSwlvHwWDQIMIYWO)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void HxucdmvgLRrbYCRELAucgzJmgdzk(bool P_0)
	{
		if (base.fREGeAsscSanGSwlvHwWDQIMIYWO != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.fREGeAsscSanGSwlvHwWDQIMIYWO)[1]).Free();
			Marshal.FreeHGlobal(base.fREGeAsscSanGSwlvHwWDQIMIYWO);
			base.fREGeAsscSanGSwlvHwWDQIMIYWO = IntPtr.Zero;
		}
		UIqvjYSjBljszfFaCKUrqBRUQuSfA = null;
		xdJRjddwsIoIjLOHFbQhfYDkNoNMA(P_0);
	}

	internal unsafe static _0001 flwNCAnZfLlpSDIGmXLykctuvZrU<_0001>(IntPtr P_0) where _0001 : AQFnijkWHNrZqHVnChgGlanhcgGV
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
