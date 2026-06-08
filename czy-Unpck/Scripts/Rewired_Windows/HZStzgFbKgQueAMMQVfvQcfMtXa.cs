using System;
using System.Runtime.CompilerServices;

internal class HZStzgFbKgQueAMMQVfvQcfMtXa : bmLmBCpqnyTtLeIFgDTVIITYzQAA
{
	protected internal unsafe void* tkIGqgtIwxjuCkXnyDpVvseOkZD;

	[CompilerGenerated]
	private object rgPruxIMjrxjIZjeyZilGZlrWXq;

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return rgPruxIMjrxjIZjeyZilGZlrWXq;
		}
		[CompilerGenerated]
		set
		{
			rgPruxIMjrxjIZjeyZilGZlrWXq = value;
		}
	}

	public unsafe IntPtr NativePointer
	{
		get
		{
			return (IntPtr)tkIGqgtIwxjuCkXnyDpVvseOkZD;
		}
		set
		{
			void* ptr = (void*)value;
			if (tkIGqgtIwxjuCkXnyDpVvseOkZD != ptr)
			{
				vtosHPrFLOTfTHrNKEXFbpKZxV();
				void* ptr2 = tkIGqgtIwxjuCkXnyDpVvseOkZD;
				tkIGqgtIwxjuCkXnyDpVvseOkZD = ptr;
				AdWcSYabYutaWYVGyDHvXXQnpZs((IntPtr)ptr2);
			}
		}
	}

	public HZStzgFbKgQueAMMQVfvQcfMtXa(IntPtr pointer)
	{
		NativePointer = pointer;
	}

	protected HZStzgFbKgQueAMMQVfvQcfMtXa()
	{
	}

	public static explicit operator IntPtr(HZStzgFbKgQueAMMQVfvQcfMtXa cppObject)
	{
		return cppObject?.NativePointer ?? IntPtr.Zero;
	}

	protected void LGbANlRJdsowtzvRuSgTHEOUgAg(HZStzgFbKgQueAMMQVfvQcfMtXa P_0)
	{
		NativePointer = P_0.NativePointer;
		P_0.NativePointer = IntPtr.Zero;
	}

	protected void LGbANlRJdsowtzvRuSgTHEOUgAg(IntPtr P_0)
	{
		NativePointer = P_0;
	}

	protected virtual void vtosHPrFLOTfTHrNKEXFbpKZxV()
	{
	}

	protected virtual void AdWcSYabYutaWYVGyDHvXXQnpZs(IntPtr P_0)
	{
	}

	protected override void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
	}

	public static T EDfiWSzKoiuPplMomDyrCpboyVsl<T>(IntPtr P_0) where T : HZStzgFbKgQueAMMQVfvQcfMtXa
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return null;
	}

	internal static T vdjJoJgoOOGGvbvKDWVUoqtOcSl<T>(IntPtr P_0)
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return (T)(object)null;
	}

	public static IntPtr VQfnueSqPpFFFrEsaoXKrANsest<TCallback>(YcEKPykyufPoBZCDgnRECPtNieq P_0) where TCallback : YcEKPykyufPoBZCDgnRECPtNieq
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		if (P_0 is HZStzgFbKgQueAMMQVfvQcfMtXa)
		{
			return ((HZStzgFbKgQueAMMQVfvQcfMtXa)P_0).NativePointer;
		}
		rbxRGgVbdVaTzhNUZzcznsHGKjRo rbxRGgVbdVaTzhNUZzcznsHGKjRo2 = P_0.Shadow as rbxRGgVbdVaTzhNUZzcznsHGKjRo;
		if (rbxRGgVbdVaTzhNUZzcznsHGKjRo2 == null)
		{
			rbxRGgVbdVaTzhNUZzcznsHGKjRo2 = new rbxRGgVbdVaTzhNUZzcznsHGKjRo();
			rbxRGgVbdVaTzhNUZzcznsHGKjRo2.XcqbVqdtLKNrEHBlIGziwanWbzsI(P_0);
		}
		return rbxRGgVbdVaTzhNUZzcznsHGKjRo2.TRyLtPfiiFpGPNucOuzDDNMGpwr(typeof(TCallback));
	}
}
