using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class gLMOoHNGsFznEIfqattDdCOlttwo : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr NPzodQIMQiakzvvLwUEIpqIwhcos(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct wXTYggwjxhvkapvebgjlXYBYBfLW
	{
		public uint FZHVyCpiqLfsIdFBODhrkqrggBzH;

		public IntPtr fqxZzLIJvFbAlyvMEjGmGGeMSEWN;

		public int txCZeYPdvrWtAbDbicWiFonBISTtA;

		public int vqzcVcerJGuMkfmyFWyTlNIBKsjoA;

		public IntPtr OYEdHPNtMuUoacqYCiAqKTYuzHql;

		public IntPtr BERnysapYlVPLhbsfaUvgpeuFLjM;

		public IntPtr lOTTvEgtXAjMoIzwkOzCyHhvIzRv;

		public IntPtr FspEiRNIyWworRlBBhkNjnxSRsXe;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string LBCQbTXEpsflGrJhTfnyjVYYyzdo;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string QpyUCohRsppGcQyAVCfgYAzsTCvv;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct VDZIxwEpEsQyAcKCAgZUtTuOnBLYB
	{
		public IntPtr baZOyfABKefFiEzUYmmdOxFDxNqF;

		public IntPtr qiJcWBUTnHtvwXXPRgZsztiDPonm;

		public IntPtr DlfQhntUGCHLuVEKHpCFrWeooHlH;

		public IntPtr xgBTgpSafzKxPCNbhNztRYUdKByR;

		public int gWxqQXXMEyRiABUFcFmuWsrwFGSo;

		public int XLTOrbYFkTucRQUBqwLIyhIEguvg;

		public int cyLiaBHSwXNLkaeLxOxmAmcTbvOh;

		public int VGFpgznBprMaTSoBxZLqVjzyDpoT;

		public int XrryWLlevBUrPbEYtFGaHyoEscAg;

		public IntPtr AwPoITKfCxPTwTPGLeUslPRwywNV;

		public IntPtr BioJdzIScqtPIDLySJjIiLHaaqVI;

		public uint UWZaQHLUoMTLHzDxrFmpDdukXioP;
	}

	private const int inMxEjuXmemzwCtwgGBSnHwzQlrs = 20;

	private const int egmrDNtupVJEyZJlmrEEFcFwqvhw = 1410;

	private readonly ushort JsoevHbRORcIUvyOucujFQRNFyHOA;

	private readonly string ICVeddAMPfXrTSTHmbahMeucepMxA;

	private bool oivTSEDHuQtNVvkNYAaZxwPCfwXW;

	private IntPtr JyrVBLhYtYtveiLmZGRDYQkqfOJV;

	private int ybDvJEQVohtQMYUgzuRSQojjxDoh;

	private uint gvaYolsdDDlOnZJHJHFRMgkRdTMhA;

	private NPzodQIMQiakzvvLwUEIpqIwhcos rhfaWEHFJBFzpdDVJGyoqkxhYEBE;

	private NPzodQIMQiakzvvLwUEIpqIwhcos gRrjZPHBkpImjlRuTnGCqGsdYEro;

	public IntPtr rppGPLxYnLFBssYNqQeZkqQHicYw => JyrVBLhYtYtveiLmZGRDYQkqfOJV;

	public uint TrMkUVpITtVgzQrerRLyQVTidcKf => gvaYolsdDDlOnZJHJHFRMgkRdTMhA;

	public bool HHzvwonmkrBKXpXAQNegxFTFgjLZ
	{
		get
		{
			if (!(JyrVBLhYtYtveiLmZGRDYQkqfOJV != IntPtr.Zero))
			{
				return false;
			}
			return OSkKIfvWtRlxBOAvBpPMCLlxizwz(JyrVBLhYtYtveiLmZGRDYQkqfOJV);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort HLMtZnfOiYeKQfHmASkNGebvzOQm([In] ref wXTYggwjxhvkapvebgjlXYBYBfLW P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool vUdeRevTmeRxAjYJNNsnjXZXsRMF([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr NKnVQKCyqvEsFFCZmclwFoolunYGA(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ZqPFIFMFNMjzJRROzwoqrqIQCmSgA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool NwzEggMhJxiHVchNjAktrlneLHAzA(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool OSkKIfvWtRlxBOAvBpPMCLlxizwz(IntPtr P_0);

	public void Dispose()
	{
		fznvOVsBdwtqwWhWzHXpDHPkkQSJ(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void OzrFopcusPKtBBkCjcHsvCZnnxdD()
	{
		try
		{
			fznvOVsBdwtqwWhWzHXpDHPkkQSJ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void fznvOVsBdwtqwWhWzHXpDHPkkQSJ(bool P_0)
	{
		if (!oivTSEDHuQtNVvkNYAaZxwPCfwXW)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(gvaYolsdDDlOnZJHJHFRMgkRdTMhA);
			}
			if (JyrVBLhYtYtveiLmZGRDYQkqfOJV != IntPtr.Zero)
			{
				NwzEggMhJxiHVchNjAktrlneLHAzA(JyrVBLhYtYtveiLmZGRDYQkqfOJV);
				JyrVBLhYtYtveiLmZGRDYQkqfOJV = IntPtr.Zero;
			}
			if (JsoevHbRORcIUvyOucujFQRNFyHOA != 0 && !string.IsNullOrEmpty(ICVeddAMPfXrTSTHmbahMeucepMxA))
			{
				vUdeRevTmeRxAjYJNNsnjXZXsRMF(ICVeddAMPfXrTSTHmbahMeucepMxA, IntPtr.Zero);
			}
			oivTSEDHuQtNVvkNYAaZxwPCfwXW = true;
		}
	}

	public gLMOoHNGsFznEIfqattDdCOlttwo(string P_0, bool P_1, NPzodQIMQiakzvvLwUEIpqIwhcos P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		gvaYolsdDDlOnZJHJHFRMgkRdTMhA = ObjectInstanceTracker.Default.Register(this);
		ICVeddAMPfXrTSTHmbahMeucepMxA = P_0;
		rhfaWEHFJBFzpdDVJGyoqkxhYEBE = EJlqaRfEULeaTFnEimtUNQzdUEPw;
		gRrjZPHBkpImjlRuTnGCqGsdYEro = P_2;
		ybDvJEQVohtQMYUgzuRSQojjxDoh = 0;
		wXTYggwjxhvkapvebgjlXYBYBfLW wXTYggwjxhvkapvebgjlXYBYBfLW2 = new wXTYggwjxhvkapvebgjlXYBYBfLW
		{
			fqxZzLIJvFbAlyvMEjGmGGeMSEWN = Marshal.GetFunctionPointerForDelegate(rhfaWEHFJBFzpdDVJGyoqkxhYEBE)
		};
		while (JsoevHbRORcIUvyOucujFQRNFyHOA == 0 && ybDvJEQVohtQMYUgzuRSQojjxDoh < 20)
		{
			wXTYggwjxhvkapvebgjlXYBYBfLW2.QpyUCohRsppGcQyAVCfgYAzsTCvv = P_0;
			JsoevHbRORcIUvyOucujFQRNFyHOA = HLMtZnfOiYeKQfHmASkNGebvzOQm(ref wXTYggwjxhvkapvebgjlXYBYBfLW2);
			if (JsoevHbRORcIUvyOucujFQRNFyHOA != 0)
			{
				break;
			}
			ybDvJEQVohtQMYUgzuRSQojjxDoh++;
			P_0 = ICVeddAMPfXrTSTHmbahMeucepMxA + ybDvJEQVohtQMYUgzuRSQojjxDoh;
		}
		if (JsoevHbRORcIUvyOucujFQRNFyHOA == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (ICVeddAMPfXrTSTHmbahMeucepMxA != P_0)
		{
			ICVeddAMPfXrTSTHmbahMeucepMxA = P_0;
		}
		if (P_1)
		{
			JyrVBLhYtYtveiLmZGRDYQkqfOJV = LfNEMfjKmkqRnxulovIbVrdyiOHib(P_0, new IntPtr((int)gvaYolsdDDlOnZJHJHFRMgkRdTMhA));
		}
		else
		{
			JyrVBLhYtYtveiLmZGRDYQkqfOJV = OEmKnMtOEIVyxhHRjrBjIvAZOXjB(P_0, new IntPtr((int)gvaYolsdDDlOnZJHJHFRMgkRdTMhA));
		}
	}

	private IntPtr OEmKnMtOEIVyxhHRjrBjIvAZOXjB(string P_0, IntPtr P_1)
	{
		return NKnVQKCyqvEsFFCZmclwFoolunYGA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr LfNEMfjKmkqRnxulovIbVrdyiOHib(string P_0, IntPtr P_1)
	{
		return NKnVQKCyqvEsFFCZmclwFoolunYGA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, jHxeSYMpHmzLkpJXlDMcvDxoJMih.vRkzDyTjKJLXoWsCfTBrWMxJhoSr, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(NPzodQIMQiakzvvLwUEIpqIwhcos))]
	private unsafe static IntPtr EJlqaRfEULeaTFnEimtUNQzdUEPw(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return ZqPFIFMFNMjzJRROzwoqrqIQCmSgA(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			VDZIxwEpEsQyAcKCAgZUtTuOnBLYB* ptr = (VDZIxwEpEsQyAcKCAgZUtTuOnBLYB*)(void*)P_3;
			if (ptr->baZOyfABKefFiEzUYmmdOxFDxNqF != IntPtr.Zero)
			{
				NtPSOxELPOOaKLQRVmbwGRgHcLOL.bjEbnxbrUZsmgPsdjHxNsSVZYnqQA(P_0, -21, ptr->baZOyfABKefFiEzUYmmdOxFDxNqF);
			}
		}
		else
		{
			instanceId = (uint)NtPSOxELPOOaKLQRVmbwGRgHcLOL.alFiKiwdRZmHoKVsTFwKkICuGwbj(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<gLMOoHNGsFznEIfqattDdCOlttwo>(instanceId, out var instance))
		{
			instance.gRrjZPHBkpImjlRuTnGCqGsdYEro(P_0, P_1, P_2, P_3);
		}
		return ZqPFIFMFNMjzJRROzwoqrqIQCmSgA(P_0, P_1, P_2, P_3);
	}

	public void ZhXXcCPZRRozrAdzDXorfHjSYhfi(NPzodQIMQiakzvvLwUEIpqIwhcos P_0)
	{
		gRrjZPHBkpImjlRuTnGCqGsdYEro = P_0;
	}
}
