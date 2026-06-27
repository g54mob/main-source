using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class TnUwvwyctKuogGDzbURVnwjdMkoR : cJKgBBgftnDeTEPdoKumTrwTXFON
{
	[CompilerGenerated]
	private zpYzeFToaqafecYyGAUFmHUClIYGb CtIFODjOVnZBKQbHWpoRKwlBmqOUA;

	public zpYzeFToaqafecYyGAUFmHUClIYGb LwzxoRWtlarRnQUizkRoNmBKaIeK
	{
		[CompilerGenerated]
		get
		{
			return CtIFODjOVnZBKQbHWpoRKwlBmqOUA;
		}
		[CompilerGenerated]
		private set
		{
			CtIFODjOVnZBKQbHWpoRKwlBmqOUA = ctIFODjOVnZBKQbHWpoRKwlBmqOUA;
		}
	}

	protected abstract mRtJLwLPcsBXEDzYvMZYWrpxYETX EFeTtJLxuwhjjbBXGohBpbTfxoQc { get; }

	public unsafe virtual void jQLFcMcSXlPzHTrQQyvERdGsupuU(zpYzeFToaqafecYyGAUFmHUClIYGb P_0)
	{
		LwzxoRWtlarRnQUizkRoNmBKaIeK = P_0;
		base.wkJiNziQVZeKUDzpAUZiJMbAGjgE = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.wkJiNziQVZeKUDzpAUZiJMbAGjgE, EFeTtJLxuwhjjbBXGohBpbTfxoQc.ryCaUIcsjYxMdTFaKTChGOJUUnhP);
		((IntPtr*)(void*)base.wkJiNziQVZeKUDzpAUZiJMbAGjgE)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void KnnZlxbkjUKiSBqYqNmxoHRgIeVv(bool P_0)
	{
		if (base.wkJiNziQVZeKUDzpAUZiJMbAGjgE != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.wkJiNziQVZeKUDzpAUZiJMbAGjgE)[1]).Free();
			Marshal.FreeHGlobal(base.wkJiNziQVZeKUDzpAUZiJMbAGjgE);
			base.wkJiNziQVZeKUDzpAUZiJMbAGjgE = IntPtr.Zero;
		}
		LwzxoRWtlarRnQUizkRoNmBKaIeK = null;
		gaQrzwvOdVXmnSNhewemIgRyyWhi(P_0);
	}

	internal unsafe static _0001 ewfEGTvGFUwLAORIFfknuwjcLdJI<_0001>(IntPtr P_0) where _0001 : TnUwvwyctKuogGDzbURVnwjdMkoR
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
