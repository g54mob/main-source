using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class ngzGskRWZJYrKPHiTCFoPljOBNT : IAtWYRTLVsoEdIqmYRuPtJcaegz
{
	[CompilerGenerated]
	private NUrIhTgICtFHYBDdcvQoxuOfGlt BPRFHVKFNNdGxZlyDTAyCLenZGrV;

	public NUrIhTgICtFHYBDdcvQoxuOfGlt Callback
	{
		[CompilerGenerated]
		get
		{
			return BPRFHVKFNNdGxZlyDTAyCLenZGrV;
		}
		[CompilerGenerated]
		private set
		{
			BPRFHVKFNNdGxZlyDTAyCLenZGrV = value;
		}
	}

	protected abstract YcEAYcheCtPpqqoDLFNjlanIafmR GetVtbl { get; }

	public unsafe virtual void EhDmNHbdNOhARNgJSMpMFgeqbsn(NUrIhTgICtFHYBDdcvQoxuOfGlt P_0)
	{
		Callback = P_0;
		base.NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.NativePointer, GetVtbl.Pointer);
		((IntPtr*)(void*)base.NativePointer)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.NativePointer)[1]).Free();
			Marshal.FreeHGlobal(base.NativePointer);
			base.NativePointer = IntPtr.Zero;
		}
		Callback = null;
		base.LLOFbzNISIbRkZTwkaVnsPpYig(P_0);
	}

	internal unsafe static T yahYmCoQMMfVRooGdVFikKwxYmd<T>(IntPtr P_0) where T : ngzGskRWZJYrKPHiTCFoPljOBNT
	{
		return (T)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
