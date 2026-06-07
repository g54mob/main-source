using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class fFefNhCbntXshSNsZQmcBeOGabccA : PlatformInputManager, INativePlatformHelper
{
	private class oyhSmBsIiiXwtWtDMDOfhykcgvjA
	{
		private class RiYDEnoYFvCZHwMaDOZNJMwckqUX
		{
			public int KlyaFQJFgAiLqiQwrHwhBFNTqlUG;

			public int eANgNmcOyMeDFfvoDYNMOiIyIWQiA;

			public int HomBISEtncdaOGQlWsGgweEJtPykA;

			public InputSource aUYdnyNZRSLIqNiJICEJZzxoGeHK;

			public RiYDEnoYFvCZHwMaDOZNJMwckqUX(int P_0, int P_1, int P_2, InputSource P_3)
			{
				KlyaFQJFgAiLqiQwrHwhBFNTqlUG = P_0;
				eANgNmcOyMeDFfvoDYNMOiIyIWQiA = P_1;
				HomBISEtncdaOGQlWsGgweEJtPykA = P_2;
				aUYdnyNZRSLIqNiJICEJZzxoGeHK = P_3;
			}

			public void XPVAsxJivSZQBCVGPfGcxtLMWKehA(int P_0)
			{
				eANgNmcOyMeDFfvoDYNMOiIyIWQiA = P_0;
			}

			public wIBadonhQJMIwRprxJJrXeVpdYbX OwxOyDnnltudaKNaDXqJlbsevPsr()
			{
				return new wIBadonhQJMIwRprxJJrXeVpdYbX(KlyaFQJFgAiLqiQwrHwhBFNTqlUG, eANgNmcOyMeDFfvoDYNMOiIyIWQiA, aUYdnyNZRSLIqNiJICEJZzxoGeHK);
			}

			public static int hQBnaGgchzoJHKRKhvIfkfzjScfx(RiYDEnoYFvCZHwMaDOZNJMwckqUX P_0, RiYDEnoYFvCZHwMaDOZNJMwckqUX P_1)
			{
				if (P_0.KlyaFQJFgAiLqiQwrHwhBFNTqlUG < P_1.KlyaFQJFgAiLqiQwrHwhBFNTqlUG)
				{
					return -1;
				}
				if (P_0.KlyaFQJFgAiLqiQwrHwhBFNTqlUG > P_1.KlyaFQJFgAiLqiQwrHwhBFNTqlUG)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct wIBadonhQJMIwRprxJJrXeVpdYbX
		{
			public int LnHkCICSgpERZEQDdAmmsFgtyfGc;

			public int TKSbqxBIdgqflChrvnsyqtuUVEOl;

			public InputSource YknbDYAyeYmKHSyePOlhSxmwtDgE;

			public wIBadonhQJMIwRprxJJrXeVpdYbX(int P_0, int P_1, InputSource P_2)
			{
				LnHkCICSgpERZEQDdAmmsFgtyfGc = P_0;
				TKSbqxBIdgqflChrvnsyqtuUVEOl = P_1;
				YknbDYAyeYmKHSyePOlhSxmwtDgE = P_2;
			}
		}

		public enum jxGcSPmpBoKicuDhYvuEVLlAHnuBA
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<RiYDEnoYFvCZHwMaDOZNJMwckqUX> vHcPArcbOZPIKWXsxUKJBsAQDjSB;

		private List<RiYDEnoYFvCZHwMaDOZNJMwckqUX> BxQMqKgknqKMkRylhuBYcrnsdArr;

		public int BUyVRvrjYLBaQpPfTFnecufmeZqo => BxQMqKgknqKMkRylhuBYcrnsdArr.Count;

		public oyhSmBsIiiXwtWtDMDOfhykcgvjA()
		{
			BxQMqKgknqKMkRylhuBYcrnsdArr = new List<RiYDEnoYFvCZHwMaDOZNJMwckqUX>();
			vHcPArcbOZPIKWXsxUKJBsAQDjSB = new List<RiYDEnoYFvCZHwMaDOZNJMwckqUX>();
		}

		public void hyZgkxIunzPheFxtmxwyuFoQuNeRA(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = LQDMGLKfcxVatEFEnuQqcYlEPkNI(sourceJoystick.rewiredId, jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected);
			RiYDEnoYFvCZHwMaDOZNJMwckqUX riYDEnoYFvCZHwMaDOZNJMwckqUX;
			if (num >= 0)
			{
				riYDEnoYFvCZHwMaDOZNJMwckqUX = BxQMqKgknqKMkRylhuBYcrnsdArr[num];
				riYDEnoYFvCZHwMaDOZNJMwckqUX.XPVAsxJivSZQBCVGPfGcxtLMWKehA(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new bHNevqcqymNdyjjkmjsePlAkQFpu(sourceJoystick, riYDEnoYFvCZHwMaDOZNJMwckqUX.KlyaFQJFgAiLqiQwrHwhBFNTqlUG);
				return;
			}
			num = LQDMGLKfcxVatEFEnuQqcYlEPkNI(sourceJoystick.rewiredId, jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected);
			if (num >= 0)
			{
				riYDEnoYFvCZHwMaDOZNJMwckqUX = vHcPArcbOZPIKWXsxUKJBsAQDjSB[num];
				vHcPArcbOZPIKWXsxUKJBsAQDjSB.RemoveAt(num);
				int klyaFQJFgAiLqiQwrHwhBFNTqlUG = RakQWDFlgCKdnFbIWeNXdpKnPKNcA(riYDEnoYFvCZHwMaDOZNJMwckqUX.KlyaFQJFgAiLqiQwrHwhBFNTqlUG);
				riYDEnoYFvCZHwMaDOZNJMwckqUX.KlyaFQJFgAiLqiQwrHwhBFNTqlUG = klyaFQJFgAiLqiQwrHwhBFNTqlUG;
			}
			else
			{
				riYDEnoYFvCZHwMaDOZNJMwckqUX = new RiYDEnoYFvCZHwMaDOZNJMwckqUX(bPoZDLSeOcnRwBNCrqtZuWDJKSz(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new bHNevqcqymNdyjjkmjsePlAkQFpu(sourceJoystick, riYDEnoYFvCZHwMaDOZNJMwckqUX.KlyaFQJFgAiLqiQwrHwhBFNTqlUG);
			BxQMqKgknqKMkRylhuBYcrnsdArr.Add(riYDEnoYFvCZHwMaDOZNJMwckqUX);
			BxQMqKgknqKMkRylhuBYcrnsdArr.Sort(RiYDEnoYFvCZHwMaDOZNJMwckqUX.hQBnaGgchzoJHKRKhvIfkfzjScfx);
		}

		public void OgDoecnbdqetNOPOOOeoPmCvDhTM(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0.rewiredId, jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				RiYDEnoYFvCZHwMaDOZNJMwckqUX item = BxQMqKgknqKMkRylhuBYcrnsdArr[num];
				BxQMqKgknqKMkRylhuBYcrnsdArr.RemoveAt(num);
				vHcPArcbOZPIKWXsxUKJBsAQDjSB.Add(item);
			}
		}

		public void yQVhfyoCSUaSaKZsJRSWcTvpGblHA(int P_0, int P_1)
		{
			int num = LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0, jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected);
			if (num >= 0)
			{
				BxQMqKgknqKMkRylhuBYcrnsdArr[num].XPVAsxJivSZQBCVGPfGcxtLMWKehA(P_1);
				return;
			}
			num = LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0, jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected);
			if (num >= 0)
			{
				vHcPArcbOZPIKWXsxUKJBsAQDjSB[num].XPVAsxJivSZQBCVGPfGcxtLMWKehA(P_1);
			}
		}

		public bool YjyCTQFbQPYtrIezPqoqIllfTWeCB(int P_0, jxGcSPmpBoKicuDhYvuEVLlAHnuBA P_1)
		{
			return LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0, P_1) >= 0;
		}

		public int LQDMGLKfcxVatEFEnuQqcYlEPkNI(int P_0, jxGcSPmpBoKicuDhYvuEVLlAHnuBA P_1)
		{
			switch (P_1)
			{
			case jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected:
			{
				int count2 = BxQMqKgknqKMkRylhuBYcrnsdArr.Count;
				for (int j = 0; j < count2; j++)
				{
					if (BxQMqKgknqKMkRylhuBYcrnsdArr[j].HomBISEtncdaOGQlWsGgweEJtPykA == P_0)
					{
						return j;
					}
				}
				break;
			}
			case jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected:
			{
				int count = vHcPArcbOZPIKWXsxUKJBsAQDjSB.Count;
				for (int i = 0; i < count; i++)
				{
					if (vHcPArcbOZPIKWXsxUKJBsAQDjSB[i].HomBISEtncdaOGQlWsGgweEJtPykA == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int vhvlTpibxByUooqboujWQtqvsQVw(int P_0, InputSource P_1, jxGcSPmpBoKicuDhYvuEVLlAHnuBA P_2)
		{
			switch (P_2)
			{
			case jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected:
			{
				int count2 = BxQMqKgknqKMkRylhuBYcrnsdArr.Count;
				for (int j = 0; j < count2; j++)
				{
					if (BxQMqKgknqKMkRylhuBYcrnsdArr[j].KlyaFQJFgAiLqiQwrHwhBFNTqlUG == P_0 && BxQMqKgknqKMkRylhuBYcrnsdArr[j].aUYdnyNZRSLIqNiJICEJZzxoGeHK == P_1)
					{
						return j;
					}
				}
				break;
			}
			case jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected:
			{
				int count = vHcPArcbOZPIKWXsxUKJBsAQDjSB.Count;
				for (int i = 0; i < count; i++)
				{
					if (vHcPArcbOZPIKWXsxUKJBsAQDjSB[i].KlyaFQJFgAiLqiQwrHwhBFNTqlUG == P_0 && vHcPArcbOZPIKWXsxUKJBsAQDjSB[i].aUYdnyNZRSLIqNiJICEJZzxoGeHK == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public wIBadonhQJMIwRprxJJrXeVpdYbX KPQjrGSUgDUJZbAYgTXaHyZTKamM(int P_0, jxGcSPmpBoKicuDhYvuEVLlAHnuBA P_1)
		{
			if (P_1 == jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected)
			{
				if (P_0 < 0 || P_0 >= BxQMqKgknqKMkRylhuBYcrnsdArr.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return BxQMqKgknqKMkRylhuBYcrnsdArr[P_0].OwxOyDnnltudaKNaDXqJlbsevPsr();
			}
			if (P_0 < 0 || P_0 >= vHcPArcbOZPIKWXsxUKJBsAQDjSB.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return vHcPArcbOZPIKWXsxUKJBsAQDjSB[P_0].OwxOyDnnltudaKNaDXqJlbsevPsr();
		}

		public int BMFzsHbxYBfmYvPeuePwdrICbbiRA(int P_0, InputSource P_1, jxGcSPmpBoKicuDhYvuEVLlAHnuBA P_2)
		{
			int num = vhvlTpibxByUooqboujWQtqvsQVw(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected => BxQMqKgknqKMkRylhuBYcrnsdArr[num].eANgNmcOyMeDFfvoDYNMOiIyIWQiA, 
				jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected => vHcPArcbOZPIKWXsxUKJBsAQDjSB[num].eANgNmcOyMeDFfvoDYNMOiIyIWQiA, 
				_ => -1, 
			};
		}

		private int RakQWDFlgCKdnFbIWeNXdpKnPKNcA(int P_0)
		{
			int count = BxQMqKgknqKMkRylhuBYcrnsdArr.Count;
			for (int i = 0; i < count; i++)
			{
				if (BxQMqKgknqKMkRylhuBYcrnsdArr[i].KlyaFQJFgAiLqiQwrHwhBFNTqlUG == P_0)
				{
					return bPoZDLSeOcnRwBNCrqtZuWDJKSz();
				}
			}
			return P_0;
		}

		private int bPoZDLSeOcnRwBNCrqtZuWDJKSz()
		{
			int count = BxQMqKgknqKMkRylhuBYcrnsdArr.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (BxQMqKgknqKMkRylhuBYcrnsdArr[i].KlyaFQJFgAiLqiQwrHwhBFNTqlUG == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}
	}

	private class bHNevqcqymNdyjjkmjsePlAkQFpu : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic aSnilikZGrhSTzWcCugCmgDyfSKk;

		private int iHhYrGMTcrdklLXpSxrIswYoxUsD;

		int IInputManagerJoystickPublic.rewiredId => aSnilikZGrhSTzWcCugCmgDyfSKk.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => iHhYrGMTcrdklLXpSxrIswYoxUsD;

		string IInputManagerJoystickPublic.name => aSnilikZGrhSTzWcCugCmgDyfSKk.name;

		long? IInputManagerJoystickPublic.systemId => aSnilikZGrhSTzWcCugCmgDyfSKk.systemId;

		int IInputManagerJoystickPublic.unityId => aSnilikZGrhSTzWcCugCmgDyfSKk.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => aSnilikZGrhSTzWcCugCmgDyfSKk.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => aSnilikZGrhSTzWcCugCmgDyfSKk.extension;

		public bHNevqcqymNdyjjkmjsePlAkQFpu(IInputManagerJoystickPublic P_0, int P_1)
		{
			aSnilikZGrhSTzWcCugCmgDyfSKk = P_0;
			iHhYrGMTcrdklLXpSxrIswYoxUsD = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			aSnilikZGrhSTzWcCugCmgDyfSKk.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			aSnilikZGrhSTzWcCugCmgDyfSKk.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (aSnilikZGrhSTzWcCugCmgDyfSKk is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class CclgzMGebdlniyUGFEoAyRyniIRoA
	{
		public static readonly CclgzMGebdlniyUGFEoAyRyniIRoA _003C_003E9 = new CclgzMGebdlniyUGFEoAyRyniIRoA();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool sqCAvImcSWexFRpEHnlhoNXcgIAS(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class bBhgWcPwLiYbWdgFagiRNXvnjoIs
	{
		public int GUkMuPFYttYpUSGXLTxTOqjNKisk;

		internal int tRFqGoUbDgFUMTRChnwAgQklEOmO()
		{
			return GUkMuPFYttYpUSGXLTxTOqjNKisk++;
		}
	}

	private const bool qlrCCBkqNmcTAlZhdoodKdIZGtJcA = false;

	private const bool yWhaQAbJSwlTWFwWSDDibrvdkomeb = false;

	private const bool ZiIZfXwSdsqgtCYkmIlabIaSCVIT = false;

	private const bool PQnecxFAFbJZXAuqOlfzobxCaWMh = false;

	private const bool zamZUaMdxogFJFDnAWWMxWqNJkJk = false;

	private const bool pTCGxphVXJEPwDdtHhyrgGIhDQYk = false;

	private bool xzOmUXddemtNnZIyHmvtkgDivpaY;

	private fjrnnPHmkeIdshLYWXhkVPRNVfKW XYHGYpBtotNZIHnQdeLggmfmPGNVA;

	private IndexedDictionary<int, PlatformInputManager> gwhIAKdqTnTyuuLZhuYOIFRDGPyJ;

	private oyhSmBsIiiXwtWtDMDOfhykcgvjA lcRCHugkKjmrGXxdrBNsosJPHhhyA;

	private Action<int, ControllerDataUpdater> xUxZgHWAaZoFeOdfjEYOeIrboMJIb;

	private WindowsStandalonePrimaryInputSource bVawbcuuklPnWzhzXDptPjWItAW;

	private PlatformInputManager YVzrCmDqVyohJQTWJoHCFUbWQsrC;

	private bool vslWPbqmfLNnbtLTjqNtdMCjEEMZ;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> LvjAMvfRqUpjTXPgERXbtAvwBePtA;

	private Func<int> uLeGaOKIIuySRHnJxgqOIDqtbocJ;

	private Func<PidVid, bool> yhGKhQSDSpdaELkUUcxlDMNJNtaj;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = JUcffnbUUIpygcbMFvGmfZKcYwgXc.ZLZaGWbwzmpMIjVooHavHBoFscUrc();
			IntPtr intPtr2 = JUcffnbUUIpygcbMFvGmfZKcYwgXc.qWjERgEBhkYCmLqVtYTSraemSGCkA();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => lcRCHugkKjmrGXxdrBNsosJPHhhyA.BUyVRvrjYLBaQpPfTFnecufmeZqo;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => YVzrCmDqVyohJQTWJoHCFUbWQsrC;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => YVzrCmDqVyohJQTWJoHCFUbWQsrC.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (YVzrCmDqVyohJQTWJoHCFUbWQsrC == null)
			{
				return InputSource.None;
			}
			return YVzrCmDqVyohJQTWJoHCFUbWQsrC.inputSourceType;
		}
	}

	public fFefNhCbntXshSNsZQmcBeOGabccA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			bVawbcuuklPnWzhzXDptPjWItAW = P_0.windowsStandalonePrimaryInputSource;
			yhGKhQSDSpdaELkUUcxlDMNJNtaj = CclgzMGebdlniyUGFEoAyRyniIRoA._003C_003E9.sqCAvImcSWexFRpEHnlhoNXcgIAS;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.DirectInput || bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.RawInput);
			ajDppfGDDPBwqFwQEKktuSmXoPMu ajDppfGDDPBwqFwQEKktuSmXoPMu2 = ajDppfGDDPBwqFwQEKktuSmXoPMu.None;
			if (flag2)
			{
				ajDppfGDDPBwqFwQEKktuSmXoPMu2 = (P_0.GetPlatformVar_useWindowsGamingInput() ? ajDppfGDDPBwqFwQEKktuSmXoPMu.WindowsGamingInput : (P_0.useXInput ? ajDppfGDDPBwqFwQEKktuSmXoPMu.XInput : ajDppfGDDPBwqFwQEKktuSmXoPMu.None));
			}
			bool flag3 = ajDppfGDDPBwqFwQEKktuSmXoPMu2 == ajDppfGDDPBwqFwQEKktuSmXoPMu.WindowsGamingInput || ajDppfGDDPBwqFwQEKktuSmXoPMu2 == ajDppfGDDPBwqFwQEKktuSmXoPMu.XInput || bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.XInput || bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			LvjAMvfRqUpjTXPgERXbtAvwBePtA = P_1;
			uLeGaOKIIuySRHnJxgqOIDqtbocJ = P_2;
			bool flag4 = false;
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					MROXnswaFDYJOaQMZFuqDWLdEBUH.NvCKeSxLIwPZyGnKMmwXYjNNDbct(flag3);
				}
				catch (Exception ex)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				switch (ajDppfGDDPBwqFwQEKktuSmXoPMu2)
				{
				case ajDppfGDDPBwqFwQEKktuSmXoPMu.XInput:
					if (tHTpYzkRHKYOurTSSamwmUxeGcfE(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case ajDppfGDDPBwqFwQEKktuSmXoPMu.WindowsGamingInput:
					if (sDPzTBrBDpgZuAZSNEJyTCwmxdBk(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (tHTpYzkRHKYOurTSSamwmUxeGcfE(P_0, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							P_0.useXInput = false;
						}
					}
					break;
				}
			}
			if (flag)
			{
				if (!flag4 && !tHTpYzkRHKYOurTSSamwmUxeGcfE(P_0, true, out YVzrCmDqVyohJQTWJoHCFUbWQsrC))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				XYHGYpBtotNZIHnQdeLggmfmPGNVA = new fjrnnPHmkeIdshLYWXhkVPRNVfKW();
				bool flag5 = false;
				if (bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = edYSgYwoEvyMoiSWXhgvRGcfVWFn(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, platformInputManager as AHuLsFUDywwjZMRMOCnliKJcVPho);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = RsHEbVJJsNSAzWPFAFOPUPunWODCA(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, platformInputManager as AHuLsFUDywwjZMRMOCnliKJcVPho);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							bVawbcuuklPnWzhzXDptPjWItAW = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = RsHEbVJJsNSAzWPFAFOPUPunWODCA(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, platformInputManager as AHuLsFUDywwjZMRMOCnliKJcVPho);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = edYSgYwoEvyMoiSWXhgvRGcfVWFn(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, platformInputManager as AHuLsFUDywwjZMRMOCnliKJcVPho);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							bVawbcuuklPnWzhzXDptPjWItAW = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = tHTpYzkRHKYOurTSSamwmUxeGcfE(P_0, true, out YVzrCmDqVyohJQTWJoHCFUbWQsrC);
					flag4 = flag5;
					if (flag5)
					{
						sjWfeYHSlfhymoatptnQwiZvAtcq(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = RsHEbVJJsNSAzWPFAFOPUPunWODCA(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							bVawbcuuklPnWzhzXDptPjWItAW = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (bVawbcuuklPnWzhzXDptPjWItAW == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = sDPzTBrBDpgZuAZSNEJyTCwmxdBk(P_0, true, out YVzrCmDqVyohJQTWJoHCFUbWQsrC);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = tHTpYzkRHKYOurTSSamwmUxeGcfE(P_0, true, out YVzrCmDqVyohJQTWJoHCFUbWQsrC);
							flag4 = flag5;
							if (flag5)
							{
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								P_0.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = RsHEbVJJsNSAzWPFAFOPUPunWODCA(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								bVawbcuuklPnWzhzXDptPjWItAW = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						sjWfeYHSlfhymoatptnQwiZvAtcq(P_0, XYHGYpBtotNZIHnQdeLggmfmPGNVA);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				XYHGYpBtotNZIHnQdeLggmfmPGNVA.sUVPblfVkYwSMtEexxdYvqTIxNfh += LNZwpDIeljrcigownsFDLynfmSgw;
				XYHGYpBtotNZIHnQdeLggmfmPGNVA.sYYgCIChTpznytwUlbkgDMNMvvJcb += bVxpWgBAaJyELLSmFqkXcNSLDdqJ;
			}
			if (YVzrCmDqVyohJQTWJoHCFUbWQsrC == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			xUxZgHWAaZoFeOdfjEYOeIrboMJIb = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool edYSgYwoEvyMoiSWXhgvRGcfVWFn(ConfigVars P_0, fjrnnPHmkeIdshLYWXhkVPRNVfKW P_1, AHuLsFUDywwjZMRMOCnliKJcVPho P_2)
	{
		dxtTGgzBQXNrKPngRZEZyZBogkbP dxtTGgzBQXNrKPngRZEZyZBogkbP2 = null;
		laCHEXrFQKVPafsRtaZTamLraAteb laCHEXrFQKVPafsRtaZTamLraAteb2 = null;
		try
		{
			dxtTGgzBQXNrKPngRZEZyZBogkbP2 = new dxtTGgzBQXNrKPngRZEZyZBogkbP(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			laCHEXrFQKVPafsRtaZTamLraAteb2 = (laCHEXrFQKVPafsRtaZTamLraAteb)(YVzrCmDqVyohJQTWJoHCFUbWQsrC = new laCHEXrFQKVPafsRtaZTamLraAteb(P_0.updateLoop, P_2, P_1.aWmRvppPqCxodZSpKOQcGnoNJlKh, LvjAMvfRqUpjTXPgERXbtAvwBePtA, uLeGaOKIIuySRHnJxgqOIDqtbocJ));
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(5, dxtTGgzBQXNrKPngRZEZyZBogkbP2);
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(1, YVzrCmDqVyohJQTWJoHCFUbWQsrC);
			P_1.TkVGtZBcyWQEZMVQJrFEKNYAdtVX += dxtTGgzBQXNrKPngRZEZyZBogkbP2.ATwyXfLTCfAUthyhzNjiOhCAEvxBA;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			laCHEXrFQKVPafsRtaZTamLraAteb2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
			laCHEXrFQKVPafsRtaZTamLraAteb2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
			laCHEXrFQKVPafsRtaZTamLraAteb2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			return true;
		}
		catch (Exception)
		{
			laCHEXrFQKVPafsRtaZTamLraAteb2?.OnDestroy();
			dxtTGgzBQXNrKPngRZEZyZBogkbP2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool RsHEbVJJsNSAzWPFAFOPUPunWODCA(ConfigVars P_0, fjrnnPHmkeIdshLYWXhkVPRNVfKW P_1, AHuLsFUDywwjZMRMOCnliKJcVPho P_2)
	{
		dxtTGgzBQXNrKPngRZEZyZBogkbP dxtTGgzBQXNrKPngRZEZyZBogkbP2 = null;
		try
		{
			dxtTGgzBQXNrKPngRZEZyZBogkbP2 = new dxtTGgzBQXNrKPngRZEZyZBogkbP(P_0, P_2, LvjAMvfRqUpjTXPgERXbtAvwBePtA, uLeGaOKIIuySRHnJxgqOIDqtbocJ, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(5, dxtTGgzBQXNrKPngRZEZyZBogkbP2);
			P_1.TkVGtZBcyWQEZMVQJrFEKNYAdtVX += dxtTGgzBQXNrKPngRZEZyZBogkbP2.ATwyXfLTCfAUthyhzNjiOhCAEvxBA;
			YVzrCmDqVyohJQTWJoHCFUbWQsrC = dxtTGgzBQXNrKPngRZEZyZBogkbP2;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			dxtTGgzBQXNrKPngRZEZyZBogkbP2?.OnDestroy();
		}
		return false;
	}

	private bool sjWfeYHSlfhymoatptnQwiZvAtcq(ConfigVars P_0, fjrnnPHmkeIdshLYWXhkVPRNVfKW P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		dxtTGgzBQXNrKPngRZEZyZBogkbP dxtTGgzBQXNrKPngRZEZyZBogkbP2 = null;
		try
		{
			dxtTGgzBQXNrKPngRZEZyZBogkbP2 = new dxtTGgzBQXNrKPngRZEZyZBogkbP(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.TkVGtZBcyWQEZMVQJrFEKNYAdtVX += dxtTGgzBQXNrKPngRZEZyZBogkbP2.ATwyXfLTCfAUthyhzNjiOhCAEvxBA;
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(5, dxtTGgzBQXNrKPngRZEZyZBogkbP2);
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
			dxtTGgzBQXNrKPngRZEZyZBogkbP2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			dxtTGgzBQXNrKPngRZEZyZBogkbP2?.OnDestroy();
			dxtTGgzBQXNrKPngRZEZyZBogkbP2 = null;
			return false;
		}
	}

	private bool tHTpYzkRHKYOurTSSamwmUxeGcfE(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				bBhgWcPwLiYbWdgFagiRNXvnjoIs bBhgWcPwLiYbWdgFagiRNXvnjoIs2 = new bBhgWcPwLiYbWdgFagiRNXvnjoIs();
				bBhgWcPwLiYbWdgFagiRNXvnjoIs2.GUkMuPFYttYpUSGXLTxTOqjNKisk = 0;
				P_2 = new YRWshAzrzpyrkrqnhWtbeAGqyKfV(flag, updateLoop, LvjAMvfRqUpjTXPgERXbtAvwBePtA, bBhgWcPwLiYbWdgFagiRNXvnjoIs2.tRFqGoUbDgFUMTRChnwAgQklEOmO, yhGKhQSDSpdaELkUUcxlDMNJNtaj);
				gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(2, P_2);
			}
			else
			{
				P_2 = new YRWshAzrzpyrkrqnhWtbeAGqyKfV(flag, updateLoop, LvjAMvfRqUpjTXPgERXbtAvwBePtA, uLeGaOKIIuySRHnJxgqOIDqtbocJ, yhGKhQSDSpdaELkUUcxlDMNJNtaj);
				gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(2, P_2);
				P_2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
				P_2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
				P_2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			}
			return true;
		}
		catch
		{
			P_2 = null;
			if (P_1)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				P_0.useXInput = false;
				for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
				{
					if (gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i] != null && gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i] is EvYpgWgAiaVrxrmiqwIIXwlPQUow { NJWtNkjjVIKTPZjQTKdnhkrQFscK: not null } evYpgWgAiaVrxrmiqwIIXwlPQUow && evYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK.azCbppjpTazUEEMuYNCVtMqpcCBhb == ajDppfGDDPBwqFwQEKktuSmXoPMu.XInput)
					{
						evYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + bVawbcuuklPnWzhzXDptPjWItAW.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool sDPzTBrBDpgZuAZSNEJyTCwmxdBk(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new GcOHGGVirLyDQtfnYDHnKCwIELMm(P_0, LvjAMvfRqUpjTXPgERXbtAvwBePtA, uLeGaOKIIuySRHnJxgqOIDqtbocJ, yhGKhQSDSpdaELkUUcxlDMNJNtaj);
			if (P_1)
			{
				YVzrCmDqVyohJQTWJoHCFUbWQsrC = P_2;
			}
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Add(30, P_2);
			P_2.DeviceConnectedEvent += QTZjsrlDnKjGlkSJsACqgHAlpuHO;
			P_2.DeviceDisconnectedEvent += UgHDnxViXIUQKmhGhponklJwrFyG;
			P_2.UpdateControllerInfoEvent += xCVpuDnGVBkJiHEguEbWcylEPRNhA;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
				{
					if (gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i] != null && gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i] is EvYpgWgAiaVrxrmiqwIIXwlPQUow { NJWtNkjjVIKTPZjQTKdnhkrQFscK: not null } evYpgWgAiaVrxrmiqwIIXwlPQUow && evYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK.azCbppjpTazUEEMuYNCVtMqpcCBhb == ajDppfGDDPBwqFwQEKktuSmXoPMu.WindowsGamingInput)
					{
						evYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK = null;
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		xzOmUXddemtNnZIyHmvtkgDivpaY = true;
		lcRCHugkKjmrGXxdrBNsosJPHhhyA = new oyhSmBsIiiXwtWtDMDOfhykcgvjA();
		for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
		{
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].Initialize();
		}
	}

	public virtual void SYONYEZapHnMFeDaIwwZqwKtiGXM(UpdateLoopType P_0)
	{
		for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
		{
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count - 1; num >= 0; num--)
		{
			gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[num].OnDestroy();
		}
		gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Clear();
		if (XYHGYpBtotNZIHnQdeLggmfmPGNVA != null)
		{
			XYHGYpBtotNZIHnQdeLggmfmPGNVA.qCHcqvdZNKUVcLudMdTwNaHPLAVvA();
			XYHGYpBtotNZIHnQdeLggmfmPGNVA = null;
		}
		MROXnswaFDYJOaQMZFuqDWLdEBUH.dcLYGpkGcnAsxIOwHMuvaqFFkyemc();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return xUxZgHWAaZoFeOdfjEYOeIrboMJIb;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.GetValue((int)data.source).UpdateControllerData(lcRCHugkKjmrGXxdrBNsosJPHhhyA.BMFzsHbxYBfmYvPeuePwdrICbbiRA(controllerId, data.source, oyhSmBsIiiXwtWtDMDOfhykcgvjA.jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void QTZjsrlDnKjGlkSJsACqgHAlpuHO(BridgedController P_0)
	{
		if (P_0 != null)
		{
			lcRCHugkKjmrGXxdrBNsosJPHhhyA.hyZgkxIunzPheFxtmxwyuFoQuNeRA(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void UgHDnxViXIUQKmhGhponklJwrFyG(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			lcRCHugkKjmrGXxdrBNsosJPHhhyA.OgDoecnbdqetNOPOOOeoPmCvDhTM(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void LNZwpDIeljrcigownsFDLynfmSgw(EventArgs P_0)
	{
		if (xzOmUXddemtNnZIyHmvtkgDivpaY)
		{
			for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
			{
				gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].SystemDeviceConnected();
			}
		}
	}

	private void bVxpWgBAaJyELLSmFqkXcNSLDdqJ(EventArgs P_0)
	{
		if (xzOmUXddemtNnZIyHmvtkgDivpaY)
		{
			for (int i = 0; i < gwhIAKdqTnTyuuLZhuYOIFRDGPyJ.Count; i++)
			{
				gwhIAKdqTnTyuuLZhuYOIFRDGPyJ[i].SystemDeviceDisconnected();
			}
		}
	}

	private void xCVpuDnGVBkJiHEguEbWcylEPRNhA(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		lcRCHugkKjmrGXxdrBNsosJPHhhyA.yQVhfyoCSUaSaKZsJRSWcTvpGblHA(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		oyhSmBsIiiXwtWtDMDOfhykcgvjA.jxGcSPmpBoKicuDhYvuEVLlAHnuBA jxGcSPmpBoKicuDhYvuEVLlAHnuBA = oyhSmBsIiiXwtWtDMDOfhykcgvjA.jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Connected;
		int num = lcRCHugkKjmrGXxdrBNsosJPHhhyA.LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0.sourceJoystick.rewiredId, jxGcSPmpBoKicuDhYvuEVLlAHnuBA);
		if (num < 0)
		{
			jxGcSPmpBoKicuDhYvuEVLlAHnuBA = oyhSmBsIiiXwtWtDMDOfhykcgvjA.jxGcSPmpBoKicuDhYvuEVLlAHnuBA.Disconnected;
			num = lcRCHugkKjmrGXxdrBNsosJPHhhyA.LQDMGLKfcxVatEFEnuQqcYlEPkNI(P_0.sourceJoystick.rewiredId, jxGcSPmpBoKicuDhYvuEVLlAHnuBA);
		}
		if (num >= 0)
		{
			oyhSmBsIiiXwtWtDMDOfhykcgvjA.wIBadonhQJMIwRprxJJrXeVpdYbX wIBadonhQJMIwRprxJJrXeVpdYbX = lcRCHugkKjmrGXxdrBNsosJPHhhyA.KPQjrGSUgDUJZbAYgTXaHyZTKamM(num, jxGcSPmpBoKicuDhYvuEVLlAHnuBA);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new bHNevqcqymNdyjjkmjsePlAkQFpu(P_0.sourceJoystick, wIBadonhQJMIwRprxJJrXeVpdYbX.LnHkCICSgpERZEQDdAmmsFgtyfGc)));
			}
		}
	}
}
