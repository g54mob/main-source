using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class plftjewYGZjqpbOBtonWJoHBIpt : PlatformInputManager, INativePlatformHelper
{
	private class lbIEJogDQpjRgWgvylqifBDbxuv
	{
		private class LbfUjpWnhCmYTiYqQUwQxuUkWEQ
		{
			public int KgBznvWrfYaFrffwtyFZRJZIyoD;

			public int geSeEuiyfPfnxkXKdxuhtWNnmgL;

			public int pKRrWABTEPEBFsJUZtSBiAQAJp;

			public InputSource ARbQMcDSmWJwSnMVxhlTeMoEfnf;

			public LbfUjpWnhCmYTiYqQUwQxuUkWEQ(int mapperId, int managerId, int id, InputSource source)
			{
				KgBznvWrfYaFrffwtyFZRJZIyoD = mapperId;
				geSeEuiyfPfnxkXKdxuhtWNnmgL = managerId;
				pKRrWABTEPEBFsJUZtSBiAQAJp = id;
				ARbQMcDSmWJwSnMVxhlTeMoEfnf = source;
			}

			public void CWncwVbJhTWISMonvIVEimpDcKXc(int P_0)
			{
				geSeEuiyfPfnxkXKdxuhtWNnmgL = P_0;
			}

			public nngdYnaLgMryEtARjnwrApsCVCXN EMitGsYKGqHkzkoKRohlRebReSbX()
			{
				return new nngdYnaLgMryEtARjnwrApsCVCXN(KgBznvWrfYaFrffwtyFZRJZIyoD, geSeEuiyfPfnxkXKdxuhtWNnmgL, ARbQMcDSmWJwSnMVxhlTeMoEfnf);
			}

			public static int kxPfeJTncCBTYhpeteRlJIirGuM(LbfUjpWnhCmYTiYqQUwQxuUkWEQ P_0, LbfUjpWnhCmYTiYqQUwQxuUkWEQ P_1)
			{
				if (P_0.KgBznvWrfYaFrffwtyFZRJZIyoD < P_1.KgBznvWrfYaFrffwtyFZRJZIyoD)
				{
					return -1;
				}
				if (P_0.KgBznvWrfYaFrffwtyFZRJZIyoD > P_1.KgBznvWrfYaFrffwtyFZRJZIyoD)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct nngdYnaLgMryEtARjnwrApsCVCXN
		{
			public int KgBznvWrfYaFrffwtyFZRJZIyoD;

			public int geSeEuiyfPfnxkXKdxuhtWNnmgL;

			public InputSource ARbQMcDSmWJwSnMVxhlTeMoEfnf;

			public nngdYnaLgMryEtARjnwrApsCVCXN(int mapperId, int managerId, InputSource source)
			{
				KgBznvWrfYaFrffwtyFZRJZIyoD = mapperId;
				geSeEuiyfPfnxkXKdxuhtWNnmgL = managerId;
				ARbQMcDSmWJwSnMVxhlTeMoEfnf = source;
			}
		}

		public enum mTEDfygTcYDWQatScGIBvUYlwhvk
		{
			SLLPWXkdwSWuCebTNNLdcVukhel = 0,
			pxIDOEabnUcUluxaEwWKgTcoDWJc = 1
		}

		private List<LbfUjpWnhCmYTiYqQUwQxuUkWEQ> GucZFThPUbgUuhAHfPWofRJHGAtO;

		private List<LbfUjpWnhCmYTiYqQUwQxuUkWEQ> cRGEivzZzyhRDsAwxPnZrRctOHI;

		public int deviceCount => cRGEivzZzyhRDsAwxPnZrRctOHI.Count;

		public lbIEJogDQpjRgWgvylqifBDbxuv()
		{
			cRGEivzZzyhRDsAwxPnZrRctOHI = new List<LbfUjpWnhCmYTiYqQUwQxuUkWEQ>();
			GucZFThPUbgUuhAHfPWofRJHGAtO = new List<LbfUjpWnhCmYTiYqQUwQxuUkWEQ>();
		}

		public void XBZUvOcuLtFtFXnfujHcUxUAKTE(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = ExRxpDlEMwqDfegjLZuvCQEtdBt(sourceJoystick.rewiredId, mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel);
			LbfUjpWnhCmYTiYqQUwQxuUkWEQ lbfUjpWnhCmYTiYqQUwQxuUkWEQ;
			if (num >= 0)
			{
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ = cRGEivzZzyhRDsAwxPnZrRctOHI[num];
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ.CWncwVbJhTWISMonvIVEimpDcKXc(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new UJMPJQtbTPcPUEoZbCOSsGYrCFz(sourceJoystick, lbfUjpWnhCmYTiYqQUwQxuUkWEQ.KgBznvWrfYaFrffwtyFZRJZIyoD);
				return;
			}
			num = ExRxpDlEMwqDfegjLZuvCQEtdBt(sourceJoystick.rewiredId, mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc);
			if (num >= 0)
			{
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ = GucZFThPUbgUuhAHfPWofRJHGAtO[num];
				GucZFThPUbgUuhAHfPWofRJHGAtO.RemoveAt(num);
				int kgBznvWrfYaFrffwtyFZRJZIyoD = FLUygnKBjghIWzkkyYaTjKopgpW(lbfUjpWnhCmYTiYqQUwQxuUkWEQ.KgBznvWrfYaFrffwtyFZRJZIyoD);
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ.KgBznvWrfYaFrffwtyFZRJZIyoD = kgBznvWrfYaFrffwtyFZRJZIyoD;
			}
			else
			{
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ = new LbfUjpWnhCmYTiYqQUwQxuUkWEQ(FLUygnKBjghIWzkkyYaTjKopgpW(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new UJMPJQtbTPcPUEoZbCOSsGYrCFz(sourceJoystick, lbfUjpWnhCmYTiYqQUwQxuUkWEQ.KgBznvWrfYaFrffwtyFZRJZIyoD);
			cRGEivzZzyhRDsAwxPnZrRctOHI.Add(lbfUjpWnhCmYTiYqQUwQxuUkWEQ);
			cRGEivzZzyhRDsAwxPnZrRctOHI.Sort(LbfUjpWnhCmYTiYqQUwQxuUkWEQ.kxPfeJTncCBTYhpeteRlJIirGuM);
		}

		public void uzIbUaKUNmSgiVpVandnXgJVnYY(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0.rewiredId, mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				LbfUjpWnhCmYTiYqQUwQxuUkWEQ item = cRGEivzZzyhRDsAwxPnZrRctOHI[num];
				cRGEivzZzyhRDsAwxPnZrRctOHI.RemoveAt(num);
				GucZFThPUbgUuhAHfPWofRJHGAtO.Add(item);
			}
		}

		public void SyvIbTjafAVcReaWupkjPmKeanP(int P_0, int P_1)
		{
			int num = ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0, mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel);
			if (num >= 0)
			{
				LbfUjpWnhCmYTiYqQUwQxuUkWEQ lbfUjpWnhCmYTiYqQUwQxuUkWEQ = cRGEivzZzyhRDsAwxPnZrRctOHI[num];
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ.CWncwVbJhTWISMonvIVEimpDcKXc(P_1);
				return;
			}
			num = ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0, mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc);
			if (num >= 0)
			{
				LbfUjpWnhCmYTiYqQUwQxuUkWEQ lbfUjpWnhCmYTiYqQUwQxuUkWEQ = GucZFThPUbgUuhAHfPWofRJHGAtO[num];
				lbfUjpWnhCmYTiYqQUwQxuUkWEQ.CWncwVbJhTWISMonvIVEimpDcKXc(P_1);
			}
		}

		public bool WDMRBLdLaAepmasexhLgbGtHkMQT(int P_0, mTEDfygTcYDWQatScGIBvUYlwhvk P_1)
		{
			if (ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int ExRxpDlEMwqDfegjLZuvCQEtdBt(int P_0, mTEDfygTcYDWQatScGIBvUYlwhvk P_1)
		{
			switch (P_1)
			{
			case mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel:
			{
				int count2 = cRGEivzZzyhRDsAwxPnZrRctOHI.Count;
				for (int j = 0; j < count2; j++)
				{
					if (cRGEivzZzyhRDsAwxPnZrRctOHI[j].pKRrWABTEPEBFsJUZtSBiAQAJp == P_0)
					{
						return j;
					}
				}
				break;
			}
			case mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc:
			{
				int count = GucZFThPUbgUuhAHfPWofRJHGAtO.Count;
				for (int i = 0; i < count; i++)
				{
					if (GucZFThPUbgUuhAHfPWofRJHGAtO[i].pKRrWABTEPEBFsJUZtSBiAQAJp == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int ExRxpDlEMwqDfegjLZuvCQEtdBt(int P_0, InputSource P_1, mTEDfygTcYDWQatScGIBvUYlwhvk P_2)
		{
			switch (P_2)
			{
			case mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel:
			{
				int count2 = cRGEivzZzyhRDsAwxPnZrRctOHI.Count;
				for (int j = 0; j < count2; j++)
				{
					if (cRGEivzZzyhRDsAwxPnZrRctOHI[j].KgBznvWrfYaFrffwtyFZRJZIyoD == P_0 && cRGEivzZzyhRDsAwxPnZrRctOHI[j].ARbQMcDSmWJwSnMVxhlTeMoEfnf == P_1)
					{
						return j;
					}
				}
				break;
			}
			case mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc:
			{
				int count = GucZFThPUbgUuhAHfPWofRJHGAtO.Count;
				for (int i = 0; i < count; i++)
				{
					if (GucZFThPUbgUuhAHfPWofRJHGAtO[i].KgBznvWrfYaFrffwtyFZRJZIyoD == P_0 && GucZFThPUbgUuhAHfPWofRJHGAtO[i].ARbQMcDSmWJwSnMVxhlTeMoEfnf == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public nngdYnaLgMryEtARjnwrApsCVCXN EMitGsYKGqHkzkoKRohlRebReSbX(int P_0, mTEDfygTcYDWQatScGIBvUYlwhvk P_1)
		{
			if (P_1 == mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel)
			{
				if (P_0 < 0 || P_0 >= cRGEivzZzyhRDsAwxPnZrRctOHI.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return cRGEivzZzyhRDsAwxPnZrRctOHI[P_0].EMitGsYKGqHkzkoKRohlRebReSbX();
			}
			if (P_0 < 0 || P_0 >= GucZFThPUbgUuhAHfPWofRJHGAtO.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return GucZFThPUbgUuhAHfPWofRJHGAtO[P_0].EMitGsYKGqHkzkoKRohlRebReSbX();
		}

		public int rlGAXrUUMatFrhmguRKodpLEeMq(int P_0, InputSource P_1, mTEDfygTcYDWQatScGIBvUYlwhvk P_2)
		{
			int num = ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel => cRGEivzZzyhRDsAwxPnZrRctOHI[num].geSeEuiyfPfnxkXKdxuhtWNnmgL, 
				mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc => GucZFThPUbgUuhAHfPWofRJHGAtO[num].geSeEuiyfPfnxkXKdxuhtWNnmgL, 
				_ => -1, 
			};
		}

		private int FLUygnKBjghIWzkkyYaTjKopgpW(int P_0)
		{
			int count = cRGEivzZzyhRDsAwxPnZrRctOHI.Count;
			for (int i = 0; i < count; i++)
			{
				if (cRGEivzZzyhRDsAwxPnZrRctOHI[i].KgBznvWrfYaFrffwtyFZRJZIyoD == P_0)
				{
					return FLUygnKBjghIWzkkyYaTjKopgpW();
				}
			}
			return P_0;
		}

		private int FLUygnKBjghIWzkkyYaTjKopgpW()
		{
			int count = cRGEivzZzyhRDsAwxPnZrRctOHI.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (cRGEivzZzyhRDsAwxPnZrRctOHI[i].KgBznvWrfYaFrffwtyFZRJZIyoD == num)
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

	private class UJMPJQtbTPcPUEoZbCOSsGYrCFz : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic igbQmSqThzEBDsBKZScaimlglKi;

		private int uahLqaTgMWNHnCbIHbrvZXoRgKr;

		public int rewiredId => igbQmSqThzEBDsBKZScaimlglKi.rewiredId;

		public int inputManagerId => uahLqaTgMWNHnCbIHbrvZXoRgKr;

		public string name => igbQmSqThzEBDsBKZScaimlglKi.name;

		public long? systemId => igbQmSqThzEBDsBKZScaimlglKi.systemId;

		public int unityId => igbQmSqThzEBDsBKZScaimlglKi.unityId;

		public Guid instanceGuid => igbQmSqThzEBDsBKZScaimlglKi.instanceGuid;

		public Guid persistentGuid => instanceGuid;

		public Controller.Extension extension => igbQmSqThzEBDsBKZScaimlglKi.extension;

		public UJMPJQtbTPcPUEoZbCOSsGYrCFz(IInputManagerJoystickPublic sourceJoystick, int bridgeJoystickId)
		{
			igbQmSqThzEBDsBKZScaimlglKi = sourceJoystick;
			uahLqaTgMWNHnCbIHbrvZXoRgKr = bridgeJoystickId;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			igbQmSqThzEBDsBKZScaimlglKi.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			igbQmSqThzEBDsBKZScaimlglKi.StopVibration();
		}
	}

	private sealed class HqCNPyqqbFYmvouwlNCLpXsQpqk
	{
		public int KkwenKcPgMthUjPIAjjsOvKvZNJ;

		public int vjLyfJoSEPaXQKCqQcgzRFLRiKj()
		{
			return KkwenKcPgMthUjPIAjjsOvKvZNJ++;
		}
	}

	private const bool dBtqMIKLDZFmWlBNBuYmvAodAsjK = false;

	private const bool dTicTRfaDpZixJJKkWneaLAlDYJ = false;

	private const bool aTDGKHFPHarBWbnyEjHgIWGjrIN = false;

	private const bool yaGvnVLCIAcNScaZMAYznlCqpFS = false;

	private const bool aYMUBEsqsyLQTnFtGNwZbpuWyls = false;

	private bool KXWdnFNvBxagMplhHMEKtfPiRjd;

	private object AOMxedxSApwljiuBlXgbahWvtr;

	private IndexedDictionary<int, PlatformInputManager> kKaVOWnhuvZfOvTwyeRjyucBnrs;

	private lbIEJogDQpjRgWgvylqifBDbxuv SVBdGHDaDnDWynsubizdFffVuqQG;

	private Action<int, ControllerDataUpdater> WmFnGJiLKLAaRkIIWsgqhlsBheL;

	private WindowsStandalonePrimaryInputSource FSFbmlePlFMELrRNdFQnhcQBRJI;

	private bool jKCiRUqrLdIAnpLruDUcJflTEbb;

	private PlatformInputManager ObhiZaVIPxECrBbksWjAaFTwhIWj;

	private bool MjbAtfTDnjfWdbhxRCAHLlaoXJGf;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

	private Func<int> soqxPQhwIsLUZvHgdWElDYIwuLk;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.GxdGpOqTKipkqLMfQXpBPIJCDnf();
			IntPtr intPtr2 = HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT();
			return intPtr2 != IntPtr.Zero && intPtr == intPtr2;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => SVBdGHDaDnDWynsubizdFffVuqQG.deviceCount;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ObhiZaVIPxECrBbksWjAaFTwhIWj;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => ObhiZaVIPxECrBbksWjAaFTwhIWj.inputSource;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (ObhiZaVIPxECrBbksWjAaFTwhIWj == null)
			{
				return InputSource.None;
			}
			return ObhiZaVIPxECrBbksWjAaFTwhIWj.inputSourceType;
		}
	}

	public plftjewYGZjqpbOBtonWJoHBIpt(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		FSFbmlePlFMELrRNdFQnhcQBRJI = configVars.windowsStandalonePrimaryInputSource;
		jKCiRUqrLdIAnpLruDUcJflTEbb = configVars.useXInput;
		bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
		soqxPQhwIsLUZvHgdWElDYIwuLk = getNewJoystickId;
		bool flag = false;
		kKaVOWnhuvZfOvTwyeRjyucBnrs = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				tRQxiUSWOtLDbmnzWRyhXVoemgO.EhDmNHbdNOhARNgJSMpMFgeqbsn();
				ilPVKwtdBpFeAVdxGdhaHfCOnenL ilPVKwtdBpFeAVdxGdhaHfCOnenL2 = (ilPVKwtdBpFeAVdxGdhaHfCOnenL)(AOMxedxSApwljiuBlXgbahWvtr = new ilPVKwtdBpFeAVdxGdhaHfCOnenL());
				bool flag2 = false;
				if (FSFbmlePlFMELrRNdFQnhcQBRJI == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = tduhdLUyDIThQcPovejXIxIDFEg(configVars, ilPVKwtdBpFeAVdxGdhaHfCOnenL2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = LAYiQlMbEICqkIJSsqBpAjEufRuM(configVars, ilPVKwtdBpFeAVdxGdhaHfCOnenL2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							FSFbmlePlFMELrRNdFQnhcQBRJI = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (FSFbmlePlFMELrRNdFQnhcQBRJI == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = LAYiQlMbEICqkIJSsqBpAjEufRuM(configVars, ilPVKwtdBpFeAVdxGdhaHfCOnenL2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = tduhdLUyDIThQcPovejXIxIDFEg(configVars, ilPVKwtdBpFeAVdxGdhaHfCOnenL2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							FSFbmlePlFMELrRNdFQnhcQBRJI = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (FSFbmlePlFMELrRNdFQnhcQBRJI == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = LcHWeNjcjRfrrpDzPWiZHHSXCzPA(configVars, false);
					if (flag2)
					{
						CHGNTFjsezWtWYhkwLmtcPbLdeN(configVars, ilPVKwtdBpFeAVdxGdhaHfCOnenL2);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				ilPVKwtdBpFeAVdxGdhaHfCOnenL2.DeviceConnectedEvent += HWybtVeZZUDEUVZkTRDyLxFgrON;
				ilPVKwtdBpFeAVdxGdhaHfCOnenL2.DeviceDisconnectedEvent += VQNmCjqHHJHMkrdAfOzYWMyKBMA;
				for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
				{
					PlatformInputManager platformInputManager = kKaVOWnhuvZfOvTwyeRjyucBnrs[i];
					platformInputManager.DeviceConnectedEvent += XEpJYgVErwFfKsMFpicMmlyUZIr;
					platformInputManager.DeviceDisconnectedEvent += mlqiHNWfKimVgUoSlooTGuVlLkg;
					platformInputManager.UpdateControllerInfoEvent += okjDpxWcNpDKHaOWADYlTlYGqlNN;
				}
			}
			catch (Exception ex)
			{
				OnDestroy();
				Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
				throw;
			}
		}
		if (!flag)
		{
			LcHWeNjcjRfrrpDzPWiZHHSXCzPA(configVars, true);
		}
		WmFnGJiLKLAaRkIIWsgqhlsBheL = UpdateControllerData;
	}

	private bool tduhdLUyDIThQcPovejXIxIDFEg(ConfigVars P_0, ilPVKwtdBpFeAVdxGdhaHfCOnenL P_1)
	{
		NXzLgwiThumaVjwcRJfjteRXIcP nXzLgwiThumaVjwcRJfjteRXIcP = null;
		dnJJlCvkyWsJFkQFpOPAltwceYg dnJJlCvkyWsJFkQFpOPAltwceYg2 = null;
		try
		{
			nXzLgwiThumaVjwcRJfjteRXIcP = new NXzLgwiThumaVjwcRJfjteRXIcP(P_0, useXInput: false, null, null, handleJoysticks: false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			dnJJlCvkyWsJFkQFpOPAltwceYg2 = (dnJJlCvkyWsJFkQFpOPAltwceYg)(ObhiZaVIPxECrBbksWjAaFTwhIWj = new dnJJlCvkyWsJFkQFpOPAltwceYg(P_0.updateLoop, jKCiRUqrLdIAnpLruDUcJflTEbb, ((ilPVKwtdBpFeAVdxGdhaHfCOnenL)AOMxedxSApwljiuBlXgbahWvtr).windowHandle, bKHIVnLAXWYbMiOIyqMJrMzriBW, soqxPQhwIsLUZvHgdWElDYIwuLk));
			kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(5, nXzLgwiThumaVjwcRJfjteRXIcP);
			kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(1, ObhiZaVIPxECrBbksWjAaFTwhIWj);
			P_1.WindowFocusEvent += nXzLgwiThumaVjwcRJfjteRXIcP.VGGcjEuuHiPXlUAUUbkEZBCKiyhH;
			return true;
		}
		catch (Exception)
		{
			dnJJlCvkyWsJFkQFpOPAltwceYg2?.OnDestroy();
			nXzLgwiThumaVjwcRJfjteRXIcP?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
		}
		return false;
	}

	private bool LAYiQlMbEICqkIJSsqBpAjEufRuM(ConfigVars P_0, ilPVKwtdBpFeAVdxGdhaHfCOnenL P_1)
	{
		NXzLgwiThumaVjwcRJfjteRXIcP nXzLgwiThumaVjwcRJfjteRXIcP = null;
		try
		{
			nXzLgwiThumaVjwcRJfjteRXIcP = new NXzLgwiThumaVjwcRJfjteRXIcP(P_0, P_0.useXInput, bKHIVnLAXWYbMiOIyqMJrMzriBW, soqxPQhwIsLUZvHgdWElDYIwuLk, handleJoysticks: true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(5, nXzLgwiThumaVjwcRJfjteRXIcP);
			P_1.WindowFocusEvent += nXzLgwiThumaVjwcRJfjteRXIcP.VGGcjEuuHiPXlUAUUbkEZBCKiyhH;
			ObhiZaVIPxECrBbksWjAaFTwhIWj = nXzLgwiThumaVjwcRJfjteRXIcP;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			nXzLgwiThumaVjwcRJfjteRXIcP?.OnDestroy();
		}
		return false;
	}

	private bool CHGNTFjsezWtWYhkwLmtcPbLdeN(ConfigVars P_0, ilPVKwtdBpFeAVdxGdhaHfCOnenL P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		NXzLgwiThumaVjwcRJfjteRXIcP nXzLgwiThumaVjwcRJfjteRXIcP = null;
		try
		{
			nXzLgwiThumaVjwcRJfjteRXIcP = new NXzLgwiThumaVjwcRJfjteRXIcP(P_0, useXInput: false, null, null, handleJoysticks: false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.WindowFocusEvent += nXzLgwiThumaVjwcRJfjteRXIcP.VGGcjEuuHiPXlUAUUbkEZBCKiyhH;
			kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(5, nXzLgwiThumaVjwcRJfjteRXIcP);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			nXzLgwiThumaVjwcRJfjteRXIcP?.OnDestroy();
			nXzLgwiThumaVjwcRJfjteRXIcP = null;
			return false;
		}
	}

	private bool LcHWeNjcjRfrrpDzPWiZHHSXCzPA(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = ObhiZaVIPxECrBbksWjAaFTwhIWj == null;
		bool flag2 = useXInput || flag || ReInput.currentPlatform == Platform.WindowsAppStore;
		bool flag3 = false;
		if (!flag2)
		{
			return false;
		}
		try
		{
			if (flag3)
			{
				HqCNPyqqbFYmvouwlNCLpXsQpqk hqCNPyqqbFYmvouwlNCLpXsQpqk = new HqCNPyqqbFYmvouwlNCLpXsQpqk();
				hqCNPyqqbFYmvouwlNCLpXsQpqk.KkwenKcPgMthUjPIAjjsOvKvZNJ = 0;
				mFhbDHUVMhTRsTSifoqtETGQFLi value = new mFhbDHUVMhTRsTSifoqtETGQFLi(flag3, updateLoop, bKHIVnLAXWYbMiOIyqMJrMzriBW, hqCNPyqqbFYmvouwlNCLpXsQpqk.vjLyfJoSEPaXQKCqQcgzRFLRiKj);
				kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(2, value);
			}
			else
			{
				mFhbDHUVMhTRsTSifoqtETGQFLi mFhbDHUVMhTRsTSifoqtETGQFLi2 = new mFhbDHUVMhTRsTSifoqtETGQFLi(flag3, updateLoop, bKHIVnLAXWYbMiOIyqMJrMzriBW, soqxPQhwIsLUZvHgdWElDYIwuLk);
				if (flag)
				{
					ObhiZaVIPxECrBbksWjAaFTwhIWj = mFhbDHUVMhTRsTSifoqtETGQFLi2;
				}
				kKaVOWnhuvZfOvTwyeRjyucBnrs.Add(2, mFhbDHUVMhTRsTSifoqtETGQFLi2);
				if (P_1)
				{
					mFhbDHUVMhTRsTSifoqtETGQFLi2.DeviceConnectedEvent += XEpJYgVErwFfKsMFpicMmlyUZIr;
					mFhbDHUVMhTRsTSifoqtETGQFLi2.DeviceDisconnectedEvent += mlqiHNWfKimVgUoSlooTGuVlLkg;
					mFhbDHUVMhTRsTSifoqtETGQFLi2.UpdateControllerInfoEvent += okjDpxWcNpDKHaOWADYlTlYGqlNN;
				}
			}
			return true;
		}
		catch (Exception)
		{
			if (flag)
			{
				OnDestroy();
				Logger.LogWarning("Unable to initialize XInput!");
				throw;
			}
			if (!flag3)
			{
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + FSFbmlePlFMELrRNdFQnhcQBRJI.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
				P_0.useXInput = false;
				for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
				{
					if (kKaVOWnhuvZfOvTwyeRjyucBnrs[i] != null && kKaVOWnhuvZfOvTwyeRjyucBnrs[i] is ofDdrrXOoPYnlTBBhXLegRaygjXC ofDdrrXOoPYnlTBBhXLegRaygjXC2)
					{
						ofDdrrXOoPYnlTBBhXLegRaygjXC2.useXInput = false;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		KXWdnFNvBxagMplhHMEKtfPiRjd = true;
		SVBdGHDaDnDWynsubizdFffVuqQG = new lbIEJogDQpjRgWgvylqifBDbxuv();
		for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
		{
			kKaVOWnhuvZfOvTwyeRjyucBnrs[i].Initialize();
		}
	}

	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
		{
			kKaVOWnhuvZfOvTwyeRjyucBnrs[i].Update(currentUpdateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = kKaVOWnhuvZfOvTwyeRjyucBnrs.Count - 1; num >= 0; num--)
		{
			kKaVOWnhuvZfOvTwyeRjyucBnrs[num].OnDestroy();
		}
		if (AOMxedxSApwljiuBlXgbahWvtr != null)
		{
			((ilPVKwtdBpFeAVdxGdhaHfCOnenL)AOMxedxSApwljiuBlXgbahWvtr).uQPqBISkswrGhilfkcaiZENHGmw();
			AOMxedxSApwljiuBlXgbahWvtr = null;
		}
		tRQxiUSWOtLDbmnzWRyhXVoemgO.LLOFbzNISIbRkZTwkaVnsPpYig();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return WmFnGJiLKLAaRkIIWsgqhlsBheL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		kKaVOWnhuvZfOvTwyeRjyucBnrs.GetValue((int)data.source).UpdateControllerData(SVBdGHDaDnDWynsubizdFffVuqQG.rlGAXrUUMatFrhmguRKodpLEeMq(controllerId, data.source, lbIEJogDQpjRgWgvylqifBDbxuv.mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel), data);
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
		for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = kKaVOWnhuvZfOvTwyeRjyucBnrs[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = kKaVOWnhuvZfOvTwyeRjyucBnrs[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void XEpJYgVErwFfKsMFpicMmlyUZIr(BridgedController P_0)
	{
		if (P_0 != null)
		{
			SVBdGHDaDnDWynsubizdFffVuqQG.XBZUvOcuLtFtFXnfujHcUxUAKTE(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void mlqiHNWfKimVgUoSlooTGuVlLkg(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			SVBdGHDaDnDWynsubizdFffVuqQG.uzIbUaKUNmSgiVpVandnXgJVnYY(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void HWybtVeZZUDEUVZkTRDyLxFgrON(EventArgs P_0)
	{
		if (KXWdnFNvBxagMplhHMEKtfPiRjd)
		{
			for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
			{
				kKaVOWnhuvZfOvTwyeRjyucBnrs[i].SystemDeviceConnected();
			}
		}
	}

	private void VQNmCjqHHJHMkrdAfOzYWMyKBMA(EventArgs P_0)
	{
		if (KXWdnFNvBxagMplhHMEKtfPiRjd)
		{
			for (int i = 0; i < kKaVOWnhuvZfOvTwyeRjyucBnrs.Count; i++)
			{
				kKaVOWnhuvZfOvTwyeRjyucBnrs[i].SystemDeviceDisconnected();
			}
		}
	}

	private void okjDpxWcNpDKHaOWADYlTlYGqlNN(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		SVBdGHDaDnDWynsubizdFffVuqQG.SyvIbTjafAVcReaWupkjPmKeanP(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		lbIEJogDQpjRgWgvylqifBDbxuv.mTEDfygTcYDWQatScGIBvUYlwhvk mTEDfygTcYDWQatScGIBvUYlwhvk = lbIEJogDQpjRgWgvylqifBDbxuv.mTEDfygTcYDWQatScGIBvUYlwhvk.SLLPWXkdwSWuCebTNNLdcVukhel;
		int num = SVBdGHDaDnDWynsubizdFffVuqQG.ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0.sourceJoystick.rewiredId, mTEDfygTcYDWQatScGIBvUYlwhvk);
		if (num < 0)
		{
			mTEDfygTcYDWQatScGIBvUYlwhvk = lbIEJogDQpjRgWgvylqifBDbxuv.mTEDfygTcYDWQatScGIBvUYlwhvk.pxIDOEabnUcUluxaEwWKgTcoDWJc;
			num = SVBdGHDaDnDWynsubizdFffVuqQG.ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0.sourceJoystick.rewiredId, mTEDfygTcYDWQatScGIBvUYlwhvk);
		}
		if (num >= 0)
		{
			lbIEJogDQpjRgWgvylqifBDbxuv.nngdYnaLgMryEtARjnwrApsCVCXN nngdYnaLgMryEtARjnwrApsCVCXN = SVBdGHDaDnDWynsubizdFffVuqQG.EMitGsYKGqHkzkoKRohlRebReSbX(num, mTEDfygTcYDWQatScGIBvUYlwhvk);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new UJMPJQtbTPcPUEoZbCOSsGYrCFz(P_0.sourceJoystick, nngdYnaLgMryEtARjnwrApsCVCXN.KgBznvWrfYaFrffwtyFZRJZIyoD)));
			}
		}
	}
}
