using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ijiBXpHfHCHkWgpGJNRCcqgyhIBb : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr HQVOEjUFmnYHvJAUzoMGgyvwyIJA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct aFwbNciNitgAEJBbJyNpSNzRsdfu
	{
		public uint DNmBoKJpnJCNiUTIgpzdyzHxSmDz;

		public IntPtr zLIApVKkcJggLYeJubkcXCIPACqfA;

		public int tEpcPIJDituJiRQoMtmcrxXIhKvU;

		public int tpWmBixmIAoYASJnzAoHAIsGHmXM;

		public IntPtr UDhymFVwHkbWQChVgpqcHOanhzYx;

		public IntPtr HAeJsQgHRbpnEJbgRgKxfQZdXGZC;

		public IntPtr hmcEuYeGKCGyUgWzWRDKzXZwrblG;

		public IntPtr PiEQrVRnJEBWKvIwjpVXwzRVhHtt;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string PffhxBbXkyJJcNJsbHLkjmuFQjJCA;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string SnHdnobibtkuAihFpePoeBVzLCBkA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct ZcuUvibtFaQXkceFKdRIAOGwZPbj
	{
		public IntPtr hfskzvGbBabDEcABaPQlTofMhhMGA;

		public IntPtr cyiZxJKdsJCNOBvOrvYggyOSUDPFA;

		public IntPtr NcSdnldjTGZrIPdBfGHFXsEnauHCb;

		public IntPtr rbwANrAVatsPtirsHJNfYSgmJJKn;

		public int yCGfhPZLXcGkshAMEQukJFPbAhse;

		public int XysGdbUJjJIExyVGWfWMtWiPIwXZ;

		public int yoyBBRcXfLNpKPKUNjiiKVSCevaUA;

		public int RsHXvjFuhEQpwqSRplkOGFjctWT;

		public int VhEhLRrPtFJkhBKZJfpsWgMNGyacA;

		public IntPtr WpwnHPOHlxjwExDNlkXqazSnsate;

		public IntPtr FZTZahUUveiXmhLlmldQnCttegxcA;

		public uint CQeFVDfFbUZdriVcBJAfqASfQsEmA;
	}

	private const int mUztwfqBvkERSwpxKNbImDAearVjA = 20;

	private const int wsLyABpsOPgeYdayGmUGCCxjrmJJ = 1410;

	private readonly ushort JODOZTPAPTopwAZtAYClHanAqjnl;

	private readonly string ElmGAdOUWtDVhbOWESNbrfYhxfef;

	private bool gFAhUWPFzEcphZgCyWSXkvrBmgtR;

	private IntPtr FJMdsVxVaKEVMYMvbIlPXjOvBQhiA;

	private int eCetYIEYWtDXicHPTkKSDKEaKrUV;

	private uint oSLNsbqIEHgwFjKAvMhRBtWWbJev;

	private HQVOEjUFmnYHvJAUzoMGgyvwyIJA dbQDLOGVGXghDVJEtDoortQqmKtkA;

	private HQVOEjUFmnYHvJAUzoMGgyvwyIJA gsUchHJcnfWwNXHpnaNGzUYmYCLL;

	public IntPtr tnAuwJjkgDbvEYUrYALpxycIefwC => FJMdsVxVaKEVMYMvbIlPXjOvBQhiA;

	public uint ZvvDHTIxIpilPWivLajgZRztAnyPA => oSLNsbqIEHgwFjKAvMhRBtWWbJev;

	public bool JFCHqenblljejZuTkjWsgXxAAvlP
	{
		get
		{
			if (!(FJMdsVxVaKEVMYMvbIlPXjOvBQhiA != IntPtr.Zero))
			{
				return false;
			}
			return QQRxaxrgiNTzrcqIplfGJiHqdREF(FJMdsVxVaKEVMYMvbIlPXjOvBQhiA);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort NWxeqjtgbAcayFAfyQGXHiNeWQwO([In] ref aFwbNciNitgAEJBbJyNpSNzRsdfu P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool viGkFcjJxcDtyNKsvjAjcjzWixci([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr BvUnPUIVvjIPhzGIQLMypOvwjWeD(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr TqmWePMCGIoRhrSFFdCeiyyRbsku(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool JHEBXkGKpptFvLQlPQCrydVtDoaj(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool QQRxaxrgiNTzrcqIplfGJiHqdREF(IntPtr P_0);

	public void Dispose()
	{
		bKUCfXsYccmYUmKLHsjvSJprGcur(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void UlQFkneapDegbKvxXQQqwgvyCbFdb()
	{
		try
		{
			bKUCfXsYccmYUmKLHsjvSJprGcur(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void bKUCfXsYccmYUmKLHsjvSJprGcur(bool P_0)
	{
		if (!gFAhUWPFzEcphZgCyWSXkvrBmgtR)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(oSLNsbqIEHgwFjKAvMhRBtWWbJev);
			}
			if (FJMdsVxVaKEVMYMvbIlPXjOvBQhiA != IntPtr.Zero)
			{
				JHEBXkGKpptFvLQlPQCrydVtDoaj(FJMdsVxVaKEVMYMvbIlPXjOvBQhiA);
				FJMdsVxVaKEVMYMvbIlPXjOvBQhiA = IntPtr.Zero;
			}
			if (JODOZTPAPTopwAZtAYClHanAqjnl != 0 && !string.IsNullOrEmpty(ElmGAdOUWtDVhbOWESNbrfYhxfef))
			{
				viGkFcjJxcDtyNKsvjAjcjzWixci(ElmGAdOUWtDVhbOWESNbrfYhxfef, IntPtr.Zero);
			}
			gFAhUWPFzEcphZgCyWSXkvrBmgtR = true;
		}
	}

	public ijiBXpHfHCHkWgpGJNRCcqgyhIBb(string P_0, bool P_1, HQVOEjUFmnYHvJAUzoMGgyvwyIJA P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		oSLNsbqIEHgwFjKAvMhRBtWWbJev = ObjectInstanceTracker.Default.Register(this);
		ElmGAdOUWtDVhbOWESNbrfYhxfef = P_0;
		dbQDLOGVGXghDVJEtDoortQqmKtkA = AaOEXNfhHBWYhitXGQRUbARuJYhqA;
		gsUchHJcnfWwNXHpnaNGzUYmYCLL = P_2;
		eCetYIEYWtDXicHPTkKSDKEaKrUV = 0;
		aFwbNciNitgAEJBbJyNpSNzRsdfu aFwbNciNitgAEJBbJyNpSNzRsdfu2 = new aFwbNciNitgAEJBbJyNpSNzRsdfu
		{
			zLIApVKkcJggLYeJubkcXCIPACqfA = Marshal.GetFunctionPointerForDelegate(dbQDLOGVGXghDVJEtDoortQqmKtkA)
		};
		while (JODOZTPAPTopwAZtAYClHanAqjnl == 0 && eCetYIEYWtDXicHPTkKSDKEaKrUV < 20)
		{
			aFwbNciNitgAEJBbJyNpSNzRsdfu2.SnHdnobibtkuAihFpePoeBVzLCBkA = P_0;
			JODOZTPAPTopwAZtAYClHanAqjnl = NWxeqjtgbAcayFAfyQGXHiNeWQwO(ref aFwbNciNitgAEJBbJyNpSNzRsdfu2);
			if (JODOZTPAPTopwAZtAYClHanAqjnl != 0)
			{
				break;
			}
			eCetYIEYWtDXicHPTkKSDKEaKrUV++;
			P_0 = ElmGAdOUWtDVhbOWESNbrfYhxfef + eCetYIEYWtDXicHPTkKSDKEaKrUV;
		}
		if (JODOZTPAPTopwAZtAYClHanAqjnl == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (ElmGAdOUWtDVhbOWESNbrfYhxfef != P_0)
		{
			ElmGAdOUWtDVhbOWESNbrfYhxfef = P_0;
		}
		if (P_1)
		{
			FJMdsVxVaKEVMYMvbIlPXjOvBQhiA = RbutjtYavgdpTOMkSqojiQVpiMxs(P_0, new IntPtr((int)oSLNsbqIEHgwFjKAvMhRBtWWbJev));
		}
		else
		{
			FJMdsVxVaKEVMYMvbIlPXjOvBQhiA = QSRmbjtxZGMtWFwWFJXPFsZQkElq(P_0, new IntPtr((int)oSLNsbqIEHgwFjKAvMhRBtWWbJev));
		}
	}

	private IntPtr QSRmbjtxZGMtWFwWFJXPFsZQkElq(string P_0, IntPtr P_1)
	{
		return BvUnPUIVvjIPhzGIQLMypOvwjWeD(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr RbutjtYavgdpTOMkSqojiQVpiMxs(string P_0, IntPtr P_1)
	{
		return BvUnPUIVvjIPhzGIQLMypOvwjWeD(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.tPNwuqFBXPefWiKDHnvrZaTEXoww, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(HQVOEjUFmnYHvJAUzoMGgyvwyIJA))]
	private unsafe static IntPtr AaOEXNfhHBWYhitXGQRUbARuJYhqA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return TqmWePMCGIoRhrSFFdCeiyyRbsku(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			ZcuUvibtFaQXkceFKdRIAOGwZPbj* ptr = (ZcuUvibtFaQXkceFKdRIAOGwZPbj*)(void*)P_3;
			if (ptr->hfskzvGbBabDEcABaPQlTofMhhMGA != IntPtr.Zero)
			{
				JUcffnbUUIpygcbMFvGmfZKcYwgXc.vEbOJbfmFJGWUYQmXRBXZMxCxpAI(P_0, -21, ptr->hfskzvGbBabDEcABaPQlTofMhhMGA);
			}
		}
		else
		{
			instanceId = (uint)JUcffnbUUIpygcbMFvGmfZKcYwgXc.yZuhPkslSJlAEoNdjVbEtGyxxAXX(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<ijiBXpHfHCHkWgpGJNRCcqgyhIBb>(instanceId, out var instance))
		{
			instance.gsUchHJcnfWwNXHpnaNGzUYmYCLL(P_0, P_1, P_2, P_3);
		}
		return TqmWePMCGIoRhrSFFdCeiyyRbsku(P_0, P_1, P_2, P_3);
	}

	public void DzeFoWGJUVCYBfeoJvpfJiZhNGFeB(HQVOEjUFmnYHvJAUzoMGgyvwyIJA P_0)
	{
		gsUchHJcnfWwNXHpnaNGzUYmYCLL = P_0;
	}
}
