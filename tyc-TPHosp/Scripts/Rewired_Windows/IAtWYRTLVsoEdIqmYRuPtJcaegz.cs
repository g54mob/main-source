using System;
using System.Runtime.CompilerServices;

internal class IAtWYRTLVsoEdIqmYRuPtJcaegz : yZksxhdUTylzOicveacdfsGcJWH
{
	protected internal unsafe void* gBbLrXrPAfTbPiLRobgphErqzjOU;

	[CompilerGenerated]
	private object iFePIIGULtRnFTcYeLwPpXuPNDz;

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return iFePIIGULtRnFTcYeLwPpXuPNDz;
		}
		[CompilerGenerated]
		set
		{
			iFePIIGULtRnFTcYeLwPpXuPNDz = value;
		}
	}

	public unsafe IntPtr NativePointer
	{
		get
		{
			return (IntPtr)gBbLrXrPAfTbPiLRobgphErqzjOU;
		}
		set
		{
			void* ptr = (void*)value;
			if (gBbLrXrPAfTbPiLRobgphErqzjOU != ptr)
			{
				iwGFPoAtzNiXodFLLpvxwWycpoYU();
				void* ptr2 = gBbLrXrPAfTbPiLRobgphErqzjOU;
				gBbLrXrPAfTbPiLRobgphErqzjOU = ptr;
				NZzenfmSegCyFAkuwqyFuwLRTMr((IntPtr)ptr2);
			}
		}
	}

	public IAtWYRTLVsoEdIqmYRuPtJcaegz(IntPtr pointer)
	{
		NativePointer = pointer;
	}

	protected IAtWYRTLVsoEdIqmYRuPtJcaegz()
	{
	}

	public static explicit operator IntPtr(IAtWYRTLVsoEdIqmYRuPtJcaegz cppObject)
	{
		return cppObject?.NativePointer ?? IntPtr.Zero;
	}

	protected void YASbjUCHxkHwgLvFeQppcsRyRlx(IAtWYRTLVsoEdIqmYRuPtJcaegz P_0)
	{
		NativePointer = P_0.NativePointer;
		P_0.NativePointer = IntPtr.Zero;
	}

	protected void YASbjUCHxkHwgLvFeQppcsRyRlx(IntPtr P_0)
	{
		NativePointer = P_0;
	}

	protected virtual void iwGFPoAtzNiXodFLLpvxwWycpoYU()
	{
	}

	protected virtual void NZzenfmSegCyFAkuwqyFuwLRTMr(IntPtr P_0)
	{
	}

	protected override void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
	}

	public static T XFEBdtzkKsZPkrEAeRHZKrmCFSj<T>(IntPtr P_0) where T : IAtWYRTLVsoEdIqmYRuPtJcaegz
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return null;
	}

	internal static T mYCHMgsAqQcCkvLeNameZFkgSTu<T>(IntPtr P_0)
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return (T)(object)null;
	}

	public static IntPtr OIGNERQyxbPPSbtUmGVsMHKYnjc<TCallback>(NUrIhTgICtFHYBDdcvQoxuOfGlt P_0) where TCallback : NUrIhTgICtFHYBDdcvQoxuOfGlt
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		if (P_0 is IAtWYRTLVsoEdIqmYRuPtJcaegz)
		{
			return ((IAtWYRTLVsoEdIqmYRuPtJcaegz)P_0).NativePointer;
		}
		uVOhyXJEBHNMmLikRbBJPYIweyE uVOhyXJEBHNMmLikRbBJPYIweyE2 = P_0.Shadow as uVOhyXJEBHNMmLikRbBJPYIweyE;
		if (uVOhyXJEBHNMmLikRbBJPYIweyE2 == null)
		{
			uVOhyXJEBHNMmLikRbBJPYIweyE2 = new uVOhyXJEBHNMmLikRbBJPYIweyE();
			uVOhyXJEBHNMmLikRbBJPYIweyE2.EhDmNHbdNOhARNgJSMpMFgeqbsn(P_0);
		}
		return uVOhyXJEBHNMmLikRbBJPYIweyE2.SnXWYarLWHAxUNNKUUfbiwNydPi(typeof(TCallback));
	}
}
