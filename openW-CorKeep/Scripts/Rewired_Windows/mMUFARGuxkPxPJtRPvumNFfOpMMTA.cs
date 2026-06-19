using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class mMUFARGuxkPxPJtRPvumNFfOpMMTA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr DYNytJcvYoQRKptVRSbZlVzgqRbo(int nCode, IntPtr wParam, IntPtr lParam);

	private struct KacmMpNdFwPMLsMbeaFjvJPfdmFs
	{
		public IntPtr RccPGPcmbmattIyJTMDGHGZSGRPbb;

		public IntPtr dWbcDjeIOlWAzDidfPOTfUocCwCr;

		public uint VfaVThRybvLYAyChpSKqfKLwIgBy;

		public IntPtr jsJeHnbibkKgXMDEeuvVxljSNDgt;
	}

	private const int UvjOdJlRyZddNgccuDxYEMyROBunA = 4;

	private static mMUFARGuxkPxPJtRPvumNFfOpMMTA wVimgxbTOMFdftSFfNJTBJGhUEoH;

	private IntPtr oUvuVFeFeDlfowOlOHcNdePfgUBj = IntPtr.Zero;

	private DYNytJcvYoQRKptVRSbZlVzgqRbo LlqpgsHcKGsWMwktTgidqcWiezvu;

	private Action<gucLkXvEiWCZWkHkbOGaIbKxUUki, dQyUqKQcUcWKCbKWSlwDswopixZq, uint, IntPtr> uBLRWXiqdoKNMTTCHCdjLWloaFZE;

	private byte[] wBYiOOjLmGHNpacOhVeHqcSKBBrxB;

	private readonly bool gkiGSBdWzWuqIOdZEetLbrhEEALO;

	private KacmMpNdFwPMLsMbeaFjvJPfdmFs rwhLKxAomxerrjUeidcIhQYKlVSIA;

	private bool kaRdjNDEILLMWwRVFzUFTEMfewhp;

	public mMUFARGuxkPxPJtRPvumNFfOpMMTA()
	{
		if (wVimgxbTOMFdftSFfNJTBJGhUEoH != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		wVimgxbTOMFdftSFfNJTBJGhUEoH = this;
		gkiGSBdWzWuqIOdZEetLbrhEEALO = IntPtr.Size == 8;
		wBYiOOjLmGHNpacOhVeHqcSKBBrxB = new byte[IntPtr.Size * 3 + 4];
	}

	public void rDphwkgroKTXrQrxrkezuTYlaYDL(Action<gucLkXvEiWCZWkHkbOGaIbKxUUki, dQyUqKQcUcWKCbKWSlwDswopixZq, uint, IntPtr> P_0, bool P_1)
	{
		uBLRWXiqdoKNMTTCHCdjLWloaFZE = P_0;
		LlqpgsHcKGsWMwktTgidqcWiezvu = CTnIgyElHVklpPSODdZTPIEqmXgr;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		oUvuVFeFeDlfowOlOHcNdePfgUBj = AkmWjYeKJTZdbWelmMilmQLuDnJk(4, LlqpgsHcKGsWMwktTgidqcWiezvu, IntPtr.Zero, num);
		if (oUvuVFeFeDlfowOlOHcNdePfgUBj == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void JGkDkAPlMJREeIlzllQtZHaXjvHq()
	{
		if (!(oUvuVFeFeDlfowOlOHcNdePfgUBj == IntPtr.Zero))
		{
			if (!XHHFkYdwzSXkdrEIHSqDhHTyaseB(oUvuVFeFeDlfowOlOHcNdePfgUBj))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				oUvuVFeFeDlfowOlOHcNdePfgUBj = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(DYNytJcvYoQRKptVRSbZlVzgqRbo))]
	private static IntPtr CTnIgyElHVklpPSODdZTPIEqmXgr(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, 0, wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB.Length);
		int num = 0;
		wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.RccPGPcmbmattIyJTMDGHGZSGRPbb = gucLkXvEiWCZWkHkbOGaIbKxUUki.IXAEbEiKrMWcXAlrSlFGcboVsEzAA(gucLkXvEiWCZWkHkbOGaIbKxUUki.RQAlRKALXAWvupBzZgHGkwzpjPQd(wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, num));
		num += gucLkXvEiWCZWkHkbOGaIbKxUUki.azJHqxnpPciFJcxtjstdBpuHvDNt;
		wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.dWbcDjeIOlWAzDidfPOTfUocCwCr = dQyUqKQcUcWKCbKWSlwDswopixZq.ZkcRTapdZqeyFcfqWRzQgiLbnxiaA(dQyUqKQcUcWKCbKWSlwDswopixZq.wCphdIABgEgQTNqJWvFZdYjdIpugA(wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, num));
		num += dQyUqKQcUcWKCbKWSlwDswopixZq.DMNBhzfbwjLuZFhOelYrDfdBpDwG;
		wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.VfaVThRybvLYAyChpSKqfKLwIgBy = BitConverter.ToUInt32(wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, num);
		num += 4;
		if (wVimgxbTOMFdftSFfNJTBJGhUEoH.gkiGSBdWzWuqIOdZEetLbrhEEALO)
		{
			wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.jsJeHnbibkKgXMDEeuvVxljSNDgt = new IntPtr(BitConverter.ToInt32(wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, num + 4));
		}
		else
		{
			wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.jsJeHnbibkKgXMDEeuvVxljSNDgt = new IntPtr(BitConverter.ToInt32(wVimgxbTOMFdftSFfNJTBJGhUEoH.wBYiOOjLmGHNpacOhVeHqcSKBBrxB, num));
		}
		if (P_0 >= 0)
		{
			wVimgxbTOMFdftSFfNJTBJGhUEoH.uBLRWXiqdoKNMTTCHCdjLWloaFZE(gucLkXvEiWCZWkHkbOGaIbKxUUki.WCxXnxVsdBFddnZitYhgksgQtjoJ(wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.RccPGPcmbmattIyJTMDGHGZSGRPbb), dQyUqKQcUcWKCbKWSlwDswopixZq.muDMhOmDvZcQAfovGuhSEPIBNxdKA(wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.dWbcDjeIOlWAzDidfPOTfUocCwCr), wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.VfaVThRybvLYAyChpSKqfKLwIgBy, wVimgxbTOMFdftSFfNJTBJGhUEoH.rwhLKxAomxerrjUeidcIhQYKlVSIA.jsJeHnbibkKgXMDEeuvVxljSNDgt);
		}
		return oaIZwdfLHYszTzsqDPdJYwTIuQXS(wVimgxbTOMFdftSFfNJTBJGhUEoH.oUvuVFeFeDlfowOlOHcNdePfgUBj, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		wGojLiOqXArtcYopXSIRSdwkPyzq(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ZJpOrgfxQBjFlhsjYoivOeyISFlK()
	{
		try
		{
			wGojLiOqXArtcYopXSIRSdwkPyzq(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void wGojLiOqXArtcYopXSIRSdwkPyzq(bool P_0)
	{
		if (!kaRdjNDEILLMWwRVFzUFTEMfewhp)
		{
			JGkDkAPlMJREeIlzllQtZHaXjvHq();
			if (wVimgxbTOMFdftSFfNJTBJGhUEoH == this)
			{
				wVimgxbTOMFdftSFfNJTBJGhUEoH = null;
			}
			kaRdjNDEILLMWwRVFzUFTEMfewhp = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr AkmWjYeKJTZdbWelmMilmQLuDnJk(int P_0, DYNytJcvYoQRKptVRSbZlVzgqRbo P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool XHHFkYdwzSXkdrEIHSqDhHTyaseB(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr oaIZwdfLHYszTzsqDPdJYwTIuQXS(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
