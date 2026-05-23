using System;
using System.Runtime.CompilerServices;

internal class ShBsJJoeLKEbHXjUXgIbkAMePdAg : whSGMljKVQaOqipJrvAXBUmGuWoe
{
	protected internal unsafe void* gCHLRLMMTROdfhHdjSeFpmVcoRj;

	[CompilerGenerated]
	private object kIyXQdtXNCFjKPwhWVfIJOPImK;

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return kIyXQdtXNCFjKPwhWVfIJOPImK;
		}
		[CompilerGenerated]
		set
		{
			kIyXQdtXNCFjKPwhWVfIJOPImK = value;
		}
	}

	public unsafe IntPtr NativePointer
	{
		get
		{
			return (IntPtr)gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
		set
		{
			void* ptr = (void*)value;
			if (gCHLRLMMTROdfhHdjSeFpmVcoRj != ptr)
			{
				NativePointerUpdating();
				void* ptr2 = gCHLRLMMTROdfhHdjSeFpmVcoRj;
				gCHLRLMMTROdfhHdjSeFpmVcoRj = ptr;
				NativePointerUpdated((IntPtr)ptr2);
			}
		}
	}

	public ShBsJJoeLKEbHXjUXgIbkAMePdAg(IntPtr pointer)
	{
		NativePointer = pointer;
	}

	protected ShBsJJoeLKEbHXjUXgIbkAMePdAg()
	{
	}

	public static explicit operator IntPtr(ShBsJJoeLKEbHXjUXgIbkAMePdAg cppObject)
	{
		if (cppObject != null)
		{
			return cppObject.NativePointer;
		}
		return IntPtr.Zero;
	}

	protected void ABaBTUaIpMWXGmobfWZBHstqlkE(ShBsJJoeLKEbHXjUXgIbkAMePdAg P_0)
	{
		NativePointer = P_0.NativePointer;
		P_0.NativePointer = IntPtr.Zero;
	}

	protected void ABaBTUaIpMWXGmobfWZBHstqlkE(IntPtr P_0)
	{
		NativePointer = P_0;
	}

	protected virtual void NativePointerUpdating()
	{
	}

	protected virtual void NativePointerUpdated(IntPtr P_0)
	{
	}

	protected override void Dispose(bool P_0)
	{
	}

	public static T ZwyYBfEQIGgqQgGopzbnpJSGbTMJ<T>(IntPtr P_0) where T : ShBsJJoeLKEbHXjUXgIbkAMePdAg
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return null;
	}

	internal static T koyspqNZeqTfAsFCGBSYeaIozODB<T>(IntPtr P_0)
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return (T)(object)null;
	}

	public static IntPtr OoZcVExxPYgyPqibNjUOpuWmaPi<TCallback>(JEVDpHBHSPadiMQJjgeUMgqxoVU P_0) where TCallback : JEVDpHBHSPadiMQJjgeUMgqxoVU
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		if (P_0 is ShBsJJoeLKEbHXjUXgIbkAMePdAg)
		{
			return ((ShBsJJoeLKEbHXjUXgIbkAMePdAg)P_0).NativePointer;
		}
		gmwbVFwVVbYwAOUYGJvhsoowZxj gmwbVFwVVbYwAOUYGJvhsoowZxj2 = P_0.Shadow as gmwbVFwVVbYwAOUYGJvhsoowZxj;
		if (gmwbVFwVVbYwAOUYGJvhsoowZxj2 == null)
		{
			gmwbVFwVVbYwAOUYGJvhsoowZxj2 = new gmwbVFwVVbYwAOUYGJvhsoowZxj();
			gmwbVFwVVbYwAOUYGJvhsoowZxj2.OXxfSVQgpwyQzMSlFTkamYYmQrW(P_0);
		}
		return gmwbVFwVVbYwAOUYGJvhsoowZxj2.SahEcyAYIxyfuYacDzqDNNvmCaR(typeof(TCallback));
	}
}
