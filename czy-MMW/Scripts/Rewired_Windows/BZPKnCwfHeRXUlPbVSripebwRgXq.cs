using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class BZPKnCwfHeRXUlPbVSripebwRgXq : PlatformInputManager, INativePlatformHelper
{
	private class ShPJKmqTqEscsPLrBwwdXiFfmbPl
	{
		private class kKGybnwNpHGVzTFGTYxbhumeLAYA
		{
			public int iMcXyapcaNMkTMjJlBQQOWwIGSEH;

			public int PdshXNZUvLeaWHgCykyvyHgPbXwCb;

			public int FdCoOZceZHTGelnghjGBNcJySqjv;

			public InputSource zlZzAiLJNVDMoznZjgkniOwtPGMuA;

			public kKGybnwNpHGVzTFGTYxbhumeLAYA(int P_0, int P_1, int P_2, InputSource P_3)
			{
				iMcXyapcaNMkTMjJlBQQOWwIGSEH = P_0;
				PdshXNZUvLeaWHgCykyvyHgPbXwCb = P_1;
				FdCoOZceZHTGelnghjGBNcJySqjv = P_2;
				zlZzAiLJNVDMoznZjgkniOwtPGMuA = P_3;
			}

			public void mXoEUQafZlCqkXBRhMxsbuBKEkXb(int P_0)
			{
				PdshXNZUvLeaWHgCykyvyHgPbXwCb = P_0;
			}

			public ByZveQAKNLcCwmiFIepiRBKFnHSu TchgkjKXLNuhCyNjqvVBUcKGFsXT()
			{
				return new ByZveQAKNLcCwmiFIepiRBKFnHSu(iMcXyapcaNMkTMjJlBQQOWwIGSEH, PdshXNZUvLeaWHgCykyvyHgPbXwCb, zlZzAiLJNVDMoznZjgkniOwtPGMuA);
			}

			public static int IHffvrGGKOqMSAPJlEYdPmTQLfZFA(kKGybnwNpHGVzTFGTYxbhumeLAYA P_0, kKGybnwNpHGVzTFGTYxbhumeLAYA P_1)
			{
				if (P_0.iMcXyapcaNMkTMjJlBQQOWwIGSEH < P_1.iMcXyapcaNMkTMjJlBQQOWwIGSEH)
				{
					return -1;
				}
				if (P_0.iMcXyapcaNMkTMjJlBQQOWwIGSEH > P_1.iMcXyapcaNMkTMjJlBQQOWwIGSEH)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct ByZveQAKNLcCwmiFIepiRBKFnHSu
		{
			public int hHiChMJlINMrNSFqxQwvqCQpRBLt;

			public int ICiyUfyxxWoSLfSYtoPWjqlzWSvX;

			public InputSource TFGtRwFoplQFXEgRTLBAoBUxXENf;

			public ByZveQAKNLcCwmiFIepiRBKFnHSu(int P_0, int P_1, InputSource P_2)
			{
				hHiChMJlINMrNSFqxQwvqCQpRBLt = P_0;
				ICiyUfyxxWoSLfSYtoPWjqlzWSvX = P_1;
				TFGtRwFoplQFXEgRTLBAoBUxXENf = P_2;
			}
		}

		public enum GlTQFMRUrZfduLsKIDJUzTDcBues
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<kKGybnwNpHGVzTFGTYxbhumeLAYA> pybdQtFEOLDTwmjhKguaPPOzOszO;

		private List<kKGybnwNpHGVzTFGTYxbhumeLAYA> uEKhgQnxOzKddFfneMlJDHKnoFRg;

		public int oIbVfFkhgKICVffWtSdpmHyCgdeib => uEKhgQnxOzKddFfneMlJDHKnoFRg.Count;

		public ShPJKmqTqEscsPLrBwwdXiFfmbPl()
		{
			uEKhgQnxOzKddFfneMlJDHKnoFRg = new List<kKGybnwNpHGVzTFGTYxbhumeLAYA>();
			pybdQtFEOLDTwmjhKguaPPOzOszO = new List<kKGybnwNpHGVzTFGTYxbhumeLAYA>();
		}

		public void JGlgEcCfIfQabTKsbepsnbCXUnfO(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = uEZdlvmangTjBLhqUefpDPkCDkWnA(sourceJoystick.rewiredId, GlTQFMRUrZfduLsKIDJUzTDcBues.Connected);
			kKGybnwNpHGVzTFGTYxbhumeLAYA kKGybnwNpHGVzTFGTYxbhumeLAYA2;
			if (num >= 0)
			{
				kKGybnwNpHGVzTFGTYxbhumeLAYA2 = uEKhgQnxOzKddFfneMlJDHKnoFRg[num];
				kKGybnwNpHGVzTFGTYxbhumeLAYA2.mXoEUQafZlCqkXBRhMxsbuBKEkXb(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new HVGGyzsuJEhfLHDhYOAUmSzPNlrQ(sourceJoystick, kKGybnwNpHGVzTFGTYxbhumeLAYA2.iMcXyapcaNMkTMjJlBQQOWwIGSEH);
				return;
			}
			num = uEZdlvmangTjBLhqUefpDPkCDkWnA(sourceJoystick.rewiredId, GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected);
			if (num >= 0)
			{
				kKGybnwNpHGVzTFGTYxbhumeLAYA2 = pybdQtFEOLDTwmjhKguaPPOzOszO[num];
				pybdQtFEOLDTwmjhKguaPPOzOszO.RemoveAt(num);
				int iMcXyapcaNMkTMjJlBQQOWwIGSEH = xzJtDGiaiCHknbOPmBwsYAkVmOlK(kKGybnwNpHGVzTFGTYxbhumeLAYA2.iMcXyapcaNMkTMjJlBQQOWwIGSEH);
				kKGybnwNpHGVzTFGTYxbhumeLAYA2.iMcXyapcaNMkTMjJlBQQOWwIGSEH = iMcXyapcaNMkTMjJlBQQOWwIGSEH;
			}
			else
			{
				kKGybnwNpHGVzTFGTYxbhumeLAYA2 = new kKGybnwNpHGVzTFGTYxbhumeLAYA(HLPOOBZwknnIKWZFlHeipHGQavzi(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new HVGGyzsuJEhfLHDhYOAUmSzPNlrQ(sourceJoystick, kKGybnwNpHGVzTFGTYxbhumeLAYA2.iMcXyapcaNMkTMjJlBQQOWwIGSEH);
			uEKhgQnxOzKddFfneMlJDHKnoFRg.Add(kKGybnwNpHGVzTFGTYxbhumeLAYA2);
			uEKhgQnxOzKddFfneMlJDHKnoFRg.Sort(kKGybnwNpHGVzTFGTYxbhumeLAYA.IHffvrGGKOqMSAPJlEYdPmTQLfZFA);
		}

		public void pDFrbQJSIbwQJdxYrEGYwAYqBovGA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = uEZdlvmangTjBLhqUefpDPkCDkWnA(P_0.rewiredId, GlTQFMRUrZfduLsKIDJUzTDcBues.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				kKGybnwNpHGVzTFGTYxbhumeLAYA item = uEKhgQnxOzKddFfneMlJDHKnoFRg[num];
				uEKhgQnxOzKddFfneMlJDHKnoFRg.RemoveAt(num);
				pybdQtFEOLDTwmjhKguaPPOzOszO.Add(item);
			}
		}

		public void IfwebZYKBYRkgqInXKtWHdJAfbzw(int P_0, int P_1)
		{
			int num = uEZdlvmangTjBLhqUefpDPkCDkWnA(P_0, GlTQFMRUrZfduLsKIDJUzTDcBues.Connected);
			if (num >= 0)
			{
				uEKhgQnxOzKddFfneMlJDHKnoFRg[num].mXoEUQafZlCqkXBRhMxsbuBKEkXb(P_1);
				return;
			}
			num = uEZdlvmangTjBLhqUefpDPkCDkWnA(P_0, GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected);
			if (num >= 0)
			{
				pybdQtFEOLDTwmjhKguaPPOzOszO[num].mXoEUQafZlCqkXBRhMxsbuBKEkXb(P_1);
			}
		}

		public int uEZdlvmangTjBLhqUefpDPkCDkWnA(int P_0, GlTQFMRUrZfduLsKIDJUzTDcBues P_1)
		{
			switch (P_1)
			{
			case GlTQFMRUrZfduLsKIDJUzTDcBues.Connected:
			{
				int count2 = uEKhgQnxOzKddFfneMlJDHKnoFRg.Count;
				for (int j = 0; j < count2; j++)
				{
					if (uEKhgQnxOzKddFfneMlJDHKnoFRg[j].FdCoOZceZHTGelnghjGBNcJySqjv == P_0)
					{
						return j;
					}
				}
				break;
			}
			case GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected:
			{
				int count = pybdQtFEOLDTwmjhKguaPPOzOszO.Count;
				for (int i = 0; i < count; i++)
				{
					if (pybdQtFEOLDTwmjhKguaPPOzOszO[i].FdCoOZceZHTGelnghjGBNcJySqjv == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int QJixgAWYZnmaPvdXoXeoHRUZoDWT(int P_0, InputSource P_1, GlTQFMRUrZfduLsKIDJUzTDcBues P_2)
		{
			switch (P_2)
			{
			case GlTQFMRUrZfduLsKIDJUzTDcBues.Connected:
			{
				int count2 = uEKhgQnxOzKddFfneMlJDHKnoFRg.Count;
				for (int j = 0; j < count2; j++)
				{
					if (uEKhgQnxOzKddFfneMlJDHKnoFRg[j].iMcXyapcaNMkTMjJlBQQOWwIGSEH == P_0 && uEKhgQnxOzKddFfneMlJDHKnoFRg[j].zlZzAiLJNVDMoznZjgkniOwtPGMuA == P_1)
					{
						return j;
					}
				}
				break;
			}
			case GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected:
			{
				int count = pybdQtFEOLDTwmjhKguaPPOzOszO.Count;
				for (int i = 0; i < count; i++)
				{
					if (pybdQtFEOLDTwmjhKguaPPOzOszO[i].iMcXyapcaNMkTMjJlBQQOWwIGSEH == P_0 && pybdQtFEOLDTwmjhKguaPPOzOszO[i].zlZzAiLJNVDMoznZjgkniOwtPGMuA == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public ByZveQAKNLcCwmiFIepiRBKFnHSu ttOLBboCnhDNkHQfyGKgcYDYCTgI(int P_0, GlTQFMRUrZfduLsKIDJUzTDcBues P_1)
		{
			if (P_1 == GlTQFMRUrZfduLsKIDJUzTDcBues.Connected)
			{
				if (P_0 < 0 || P_0 >= uEKhgQnxOzKddFfneMlJDHKnoFRg.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return uEKhgQnxOzKddFfneMlJDHKnoFRg[P_0].TchgkjKXLNuhCyNjqvVBUcKGFsXT();
			}
			if (P_0 < 0 || P_0 >= pybdQtFEOLDTwmjhKguaPPOzOszO.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return pybdQtFEOLDTwmjhKguaPPOzOszO[P_0].TchgkjKXLNuhCyNjqvVBUcKGFsXT();
		}

		public int asuFGzrdzKdLUPCPLfPTzgRlhOUW(int P_0, InputSource P_1, GlTQFMRUrZfduLsKIDJUzTDcBues P_2)
		{
			int num = QJixgAWYZnmaPvdXoXeoHRUZoDWT(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				GlTQFMRUrZfduLsKIDJUzTDcBues.Connected => uEKhgQnxOzKddFfneMlJDHKnoFRg[num].PdshXNZUvLeaWHgCykyvyHgPbXwCb, 
				GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected => pybdQtFEOLDTwmjhKguaPPOzOszO[num].PdshXNZUvLeaWHgCykyvyHgPbXwCb, 
				_ => -1, 
			};
		}

		private int xzJtDGiaiCHknbOPmBwsYAkVmOlK(int P_0)
		{
			int count = uEKhgQnxOzKddFfneMlJDHKnoFRg.Count;
			for (int i = 0; i < count; i++)
			{
				if (uEKhgQnxOzKddFfneMlJDHKnoFRg[i].iMcXyapcaNMkTMjJlBQQOWwIGSEH == P_0)
				{
					return HLPOOBZwknnIKWZFlHeipHGQavzi();
				}
			}
			return P_0;
		}

		private int HLPOOBZwknnIKWZFlHeipHGQavzi()
		{
			int count = uEKhgQnxOzKddFfneMlJDHKnoFRg.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (uEKhgQnxOzKddFfneMlJDHKnoFRg[i].iMcXyapcaNMkTMjJlBQQOWwIGSEH == num)
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

	private class HVGGyzsuJEhfLHDhYOAUmSzPNlrQ : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic QcyIjHcMpVdvcmLkIsyirjPrpiJgb;

		private int sbHOKYkpDcbRcFpOLDMTGJXxKmAIb;

		int IInputManagerJoystickPublic.rewiredId => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => sbHOKYkpDcbRcFpOLDMTGJXxKmAIb;

		string IInputManagerJoystickPublic.name => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.name;

		long? IInputManagerJoystickPublic.systemId => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.systemId;

		int IInputManagerJoystickPublic.unityId => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => QcyIjHcMpVdvcmLkIsyirjPrpiJgb.extension;

		public HVGGyzsuJEhfLHDhYOAUmSzPNlrQ(IInputManagerJoystickPublic P_0, int P_1)
		{
			QcyIjHcMpVdvcmLkIsyirjPrpiJgb = P_0;
			sbHOKYkpDcbRcFpOLDMTGJXxKmAIb = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			QcyIjHcMpVdvcmLkIsyirjPrpiJgb.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			QcyIjHcMpVdvcmLkIsyirjPrpiJgb.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}
	}

	private sealed class AZGkoXDjRKqqHOHgHMNKxpARREKM
	{
		public int ipnIlgersJfTFvJXnDDNgcDXJrDvA;

		internal int tUFDmKpzOzrCubQRoTMJBWOiSurV()
		{
			return ipnIlgersJfTFvJXnDDNgcDXJrDvA++;
		}
	}

	private bool QPkGVvoRNEIbnJhGrcklFaIZiTgdA;

	private object fEGjtSOVnCjduQYCajMwECsLjFyA;

	private IndexedDictionary<int, PlatformInputManager> aaBCkqmjuZWjpByKwocVVFEbHaOT;

	private ShPJKmqTqEscsPLrBwwdXiFfmbPl GHrZOsUKsmgNycoQQnChIdfDbyVJb;

	private Action<int, ControllerDataUpdater> OlSMSqoJUiAmVkUbKxzNLrGQaksY;

	private WindowsStandalonePrimaryInputSource duGyLwdAEBVDtCpHZbRHaujcFBRUA;

	private bool zrUgkDkUFUCRYuQDbzjqEQhEijUHb;

	private PlatformInputManager VpnIIqCGdHxMNJTnfRJuxARPOgob;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> VVSWAZzRVkbrAoCDDGBhFhxkvZqK;

	private Func<int> VYwsiJWvqGMjxymdgvMIrLbkfaBIA;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = xhdeZTSXJnCGxNhwofNZQKbUYVkf.jSsEoyCiXeWymrQCCFHpQUxMZmYnA();
			IntPtr intPtr2 = xhdeZTSXJnCGxNhwofNZQKbUYVkf.dMoylxvxjKLqXzqYCFnxmvNlHmFFA();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => GHrZOsUKsmgNycoQQnChIdfDbyVJb.oIbVfFkhgKICVffWtSdpmHyCgdeib;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => VpnIIqCGdHxMNJTnfRJuxARPOgob;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => VpnIIqCGdHxMNJTnfRJuxARPOgob.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (VpnIIqCGdHxMNJTnfRJuxARPOgob == null)
			{
				return InputSource.None;
			}
			return VpnIIqCGdHxMNJTnfRJuxARPOgob.inputSourceType;
		}
	}

	public BZPKnCwfHeRXUlPbVSripebwRgXq(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		duGyLwdAEBVDtCpHZbRHaujcFBRUA = P_0.windowsStandalonePrimaryInputSource;
		zrUgkDkUFUCRYuQDbzjqEQhEijUHb = P_0.useXInput;
		VVSWAZzRVkbrAoCDDGBhFhxkvZqK = P_1;
		VYwsiJWvqGMjxymdgvMIrLbkfaBIA = P_2;
		bool flag = false;
		aaBCkqmjuZWjpByKwocVVFEbHaOT = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				TOahviIJXSwhIkcLgNJHhAnDExwT.GMwgCSEzvdRqhmLrEfVqGQDSHtkTA();
				MztJSGjdIQTltRILslySBbknbsPG mztJSGjdIQTltRILslySBbknbsPG = (MztJSGjdIQTltRILslySBbknbsPG)(fEGjtSOVnCjduQYCajMwECsLjFyA = new MztJSGjdIQTltRILslySBbknbsPG());
				bool flag2 = false;
				if (duGyLwdAEBVDtCpHZbRHaujcFBRUA == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = fxGBnQGILsmhhiRRQDTKcJtJiFEJA(P_0, mztJSGjdIQTltRILslySBbknbsPG);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = MtZNUXeJKyoMjmjvEPbQinjelRpT(P_0, mztJSGjdIQTltRILslySBbknbsPG);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							duGyLwdAEBVDtCpHZbRHaujcFBRUA = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (duGyLwdAEBVDtCpHZbRHaujcFBRUA == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = MtZNUXeJKyoMjmjvEPbQinjelRpT(P_0, mztJSGjdIQTltRILslySBbknbsPG);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = fxGBnQGILsmhhiRRQDTKcJtJiFEJA(P_0, mztJSGjdIQTltRILslySBbknbsPG);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							duGyLwdAEBVDtCpHZbRHaujcFBRUA = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (duGyLwdAEBVDtCpHZbRHaujcFBRUA == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = fLcAOThURqFimmRfUQcfWVsxPqRHA(P_0, false);
					if (flag2)
					{
						SMpTUBhorSiReeNfZbmTgCAErTTG(P_0, mztJSGjdIQTltRILslySBbknbsPG);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				mztJSGjdIQTltRILslySBbknbsPG.EPWCkjITdpOLiwoYvGtvEddUkibzA += voYwUXYggcuWPdIOpOYPvaZYGWNFA;
				mztJSGjdIQTltRILslySBbknbsPG.wvIxwNgQhJAEcdqQMBjQZWCKHBHfA += QdlSksDYAhnHgzafufCUdnuMwyQm;
				for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
				{
					PlatformInputManager platformInputManager = aaBCkqmjuZWjpByKwocVVFEbHaOT[i];
					platformInputManager.DeviceConnectedEvent += NdUOEnYFyKayGBnINLfiIHmaZWThA;
					platformInputManager.DeviceDisconnectedEvent += bKBtgWVslRgyZZlcYNMTndcjuCeg;
					platformInputManager.UpdateControllerInfoEvent += nhSJlurvkRNxGyNjdfkuHlPVdFou;
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
			fLcAOThURqFimmRfUQcfWVsxPqRHA(P_0, true);
		}
		OlSMSqoJUiAmVkUbKxzNLrGQaksY = UpdateControllerData;
	}

	private bool fxGBnQGILsmhhiRRQDTKcJtJiFEJA(ConfigVars P_0, MztJSGjdIQTltRILslySBbknbsPG P_1)
	{
		llNHAvosMBZqIfUljDVwXfcmbjKc llNHAvosMBZqIfUljDVwXfcmbjKc2 = null;
		BSxuxkpqlruyakdxPRXoRuCTALKT bSxuxkpqlruyakdxPRXoRuCTALKT = null;
		try
		{
			llNHAvosMBZqIfUljDVwXfcmbjKc2 = new llNHAvosMBZqIfUljDVwXfcmbjKc(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			bSxuxkpqlruyakdxPRXoRuCTALKT = (BSxuxkpqlruyakdxPRXoRuCTALKT)(VpnIIqCGdHxMNJTnfRJuxARPOgob = new BSxuxkpqlruyakdxPRXoRuCTALKT(P_0.updateLoop, zrUgkDkUFUCRYuQDbzjqEQhEijUHb, ((MztJSGjdIQTltRILslySBbknbsPG)fEGjtSOVnCjduQYCajMwECsLjFyA).BDrdrECItDCRaacyCmvnpDrgxNUc, VVSWAZzRVkbrAoCDDGBhFhxkvZqK, VYwsiJWvqGMjxymdgvMIrLbkfaBIA));
			aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(5, llNHAvosMBZqIfUljDVwXfcmbjKc2);
			aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(1, VpnIIqCGdHxMNJTnfRJuxARPOgob);
			P_1.NhwPXzilyijqWilRAJQRnLCwPpLl += llNHAvosMBZqIfUljDVwXfcmbjKc2.MoIhzvhQSQHcexSyFOhWqEkVAfok;
			return true;
		}
		catch (Exception)
		{
			bSxuxkpqlruyakdxPRXoRuCTALKT?.OnDestroy();
			llNHAvosMBZqIfUljDVwXfcmbjKc2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
		}
		return false;
	}

	private bool MtZNUXeJKyoMjmjvEPbQinjelRpT(ConfigVars P_0, MztJSGjdIQTltRILslySBbknbsPG P_1)
	{
		llNHAvosMBZqIfUljDVwXfcmbjKc llNHAvosMBZqIfUljDVwXfcmbjKc2 = null;
		try
		{
			llNHAvosMBZqIfUljDVwXfcmbjKc2 = new llNHAvosMBZqIfUljDVwXfcmbjKc(P_0, P_0.useXInput, VVSWAZzRVkbrAoCDDGBhFhxkvZqK, VYwsiJWvqGMjxymdgvMIrLbkfaBIA, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(5, llNHAvosMBZqIfUljDVwXfcmbjKc2);
			P_1.NhwPXzilyijqWilRAJQRnLCwPpLl += llNHAvosMBZqIfUljDVwXfcmbjKc2.MoIhzvhQSQHcexSyFOhWqEkVAfok;
			VpnIIqCGdHxMNJTnfRJuxARPOgob = llNHAvosMBZqIfUljDVwXfcmbjKc2;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			llNHAvosMBZqIfUljDVwXfcmbjKc2?.OnDestroy();
		}
		return false;
	}

	private bool SMpTUBhorSiReeNfZbmTgCAErTTG(ConfigVars P_0, MztJSGjdIQTltRILslySBbknbsPG P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		llNHAvosMBZqIfUljDVwXfcmbjKc llNHAvosMBZqIfUljDVwXfcmbjKc2 = null;
		try
		{
			llNHAvosMBZqIfUljDVwXfcmbjKc2 = new llNHAvosMBZqIfUljDVwXfcmbjKc(P_0, false, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.NhwPXzilyijqWilRAJQRnLCwPpLl += llNHAvosMBZqIfUljDVwXfcmbjKc2.MoIhzvhQSQHcexSyFOhWqEkVAfok;
			aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(5, llNHAvosMBZqIfUljDVwXfcmbjKc2);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			llNHAvosMBZqIfUljDVwXfcmbjKc2?.OnDestroy();
			llNHAvosMBZqIfUljDVwXfcmbjKc2 = null;
			return false;
		}
	}

	private bool fLcAOThURqFimmRfUQcfWVsxPqRHA(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = VpnIIqCGdHxMNJTnfRJuxARPOgob == null;
		bool num = useXInput || flag || ReInput.currentPlatform == Platform.WindowsAppStore;
		bool flag2 = false;
		if (!num)
		{
			return false;
		}
		try
		{
			if (flag2)
			{
				AZGkoXDjRKqqHOHgHMNKxpARREKM aZGkoXDjRKqqHOHgHMNKxpARREKM = new AZGkoXDjRKqqHOHgHMNKxpARREKM();
				aZGkoXDjRKqqHOHgHMNKxpARREKM.ipnIlgersJfTFvJXnDDNgcDXJrDvA = 0;
				YTThbbQFtIqARDYQTwPJqwGhYwQD value = new YTThbbQFtIqARDYQTwPJqwGhYwQD(flag2, updateLoop, VVSWAZzRVkbrAoCDDGBhFhxkvZqK, aZGkoXDjRKqqHOHgHMNKxpARREKM.tUFDmKpzOzrCubQRoTMJBWOiSurV);
				aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(2, value);
			}
			else
			{
				YTThbbQFtIqARDYQTwPJqwGhYwQD yTThbbQFtIqARDYQTwPJqwGhYwQD = new YTThbbQFtIqARDYQTwPJqwGhYwQD(flag2, updateLoop, VVSWAZzRVkbrAoCDDGBhFhxkvZqK, VYwsiJWvqGMjxymdgvMIrLbkfaBIA);
				if (flag)
				{
					VpnIIqCGdHxMNJTnfRJuxARPOgob = yTThbbQFtIqARDYQTwPJqwGhYwQD;
				}
				aaBCkqmjuZWjpByKwocVVFEbHaOT.Add(2, yTThbbQFtIqARDYQTwPJqwGhYwQD);
				if (P_1)
				{
					yTThbbQFtIqARDYQTwPJqwGhYwQD.DeviceConnectedEvent += NdUOEnYFyKayGBnINLfiIHmaZWThA;
					yTThbbQFtIqARDYQTwPJqwGhYwQD.DeviceDisconnectedEvent += bKBtgWVslRgyZZlcYNMTndcjuCeg;
					yTThbbQFtIqARDYQTwPJqwGhYwQD.UpdateControllerInfoEvent += nhSJlurvkRNxGyNjdfkuHlPVdFou;
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
			if (!flag2)
			{
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + duGyLwdAEBVDtCpHZbRHaujcFBRUA.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
				P_0.useXInput = false;
				for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
				{
					if (aaBCkqmjuZWjpByKwocVVFEbHaOT[i] != null && aaBCkqmjuZWjpByKwocVVFEbHaOT[i] is ABvzBDZAjyYZQREtNVKEUBATbshn aBvzBDZAjyYZQREtNVKEUBATbshn)
					{
						aBvzBDZAjyYZQREtNVKEUBATbshn.RoRUWKRMsSCDFFFqEaHNhMKgysykA = false;
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
		QPkGVvoRNEIbnJhGrcklFaIZiTgdA = true;
		GHrZOsUKsmgNycoQQnChIdfDbyVJb = new ShPJKmqTqEscsPLrBwwdXiFfmbPl();
		for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
		{
			aaBCkqmjuZWjpByKwocVVFEbHaOT[i].Initialize();
		}
	}

	public virtual void soouqiDRMUNGLXeLDexZyVVoOube(UpdateLoopType P_0)
	{
		for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
		{
			aaBCkqmjuZWjpByKwocVVFEbHaOT[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = aaBCkqmjuZWjpByKwocVVFEbHaOT.Count - 1; num >= 0; num--)
		{
			aaBCkqmjuZWjpByKwocVVFEbHaOT[num].OnDestroy();
		}
		if (fEGjtSOVnCjduQYCajMwECsLjFyA != null)
		{
			((MztJSGjdIQTltRILslySBbknbsPG)fEGjtSOVnCjduQYCajMwECsLjFyA).ipQoqpBcXzpJMitwmsKIFlOnGmAE();
			fEGjtSOVnCjduQYCajMwECsLjFyA = null;
		}
		TOahviIJXSwhIkcLgNJHhAnDExwT.SoEjwuudRSwNDhKvMQQeGtZEItGW();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OlSMSqoJUiAmVkUbKxzNLrGQaksY;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		aaBCkqmjuZWjpByKwocVVFEbHaOT.GetValue((int)data.source).UpdateControllerData(GHrZOsUKsmgNycoQQnChIdfDbyVJb.asuFGzrdzKdLUPCPLfPTzgRlhOUW(controllerId, data.source, ShPJKmqTqEscsPLrBwwdXiFfmbPl.GlTQFMRUrZfduLsKIDJUzTDcBues.Connected), data);
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
		for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = aaBCkqmjuZWjpByKwocVVFEbHaOT[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = aaBCkqmjuZWjpByKwocVVFEbHaOT[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void NdUOEnYFyKayGBnINLfiIHmaZWThA(BridgedController P_0)
	{
		if (P_0 != null)
		{
			GHrZOsUKsmgNycoQQnChIdfDbyVJb.JGlgEcCfIfQabTKsbepsnbCXUnfO(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void bKBtgWVslRgyZZlcYNMTndcjuCeg(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			GHrZOsUKsmgNycoQQnChIdfDbyVJb.pDFrbQJSIbwQJdxYrEGYwAYqBovGA(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void voYwUXYggcuWPdIOpOYPvaZYGWNFA(EventArgs P_0)
	{
		if (QPkGVvoRNEIbnJhGrcklFaIZiTgdA)
		{
			for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
			{
				aaBCkqmjuZWjpByKwocVVFEbHaOT[i].SystemDeviceConnected();
			}
		}
	}

	private void QdlSksDYAhnHgzafufCUdnuMwyQm(EventArgs P_0)
	{
		if (QPkGVvoRNEIbnJhGrcklFaIZiTgdA)
		{
			for (int i = 0; i < aaBCkqmjuZWjpByKwocVVFEbHaOT.Count; i++)
			{
				aaBCkqmjuZWjpByKwocVVFEbHaOT[i].SystemDeviceDisconnected();
			}
		}
	}

	private void nhSJlurvkRNxGyNjdfkuHlPVdFou(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		GHrZOsUKsmgNycoQQnChIdfDbyVJb.IfwebZYKBYRkgqInXKtWHdJAfbzw(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		ShPJKmqTqEscsPLrBwwdXiFfmbPl.GlTQFMRUrZfduLsKIDJUzTDcBues glTQFMRUrZfduLsKIDJUzTDcBues = ShPJKmqTqEscsPLrBwwdXiFfmbPl.GlTQFMRUrZfduLsKIDJUzTDcBues.Connected;
		int num = GHrZOsUKsmgNycoQQnChIdfDbyVJb.uEZdlvmangTjBLhqUefpDPkCDkWnA(P_0.sourceJoystick.rewiredId, glTQFMRUrZfduLsKIDJUzTDcBues);
		if (num < 0)
		{
			glTQFMRUrZfduLsKIDJUzTDcBues = ShPJKmqTqEscsPLrBwwdXiFfmbPl.GlTQFMRUrZfduLsKIDJUzTDcBues.Disconnected;
			num = GHrZOsUKsmgNycoQQnChIdfDbyVJb.uEZdlvmangTjBLhqUefpDPkCDkWnA(P_0.sourceJoystick.rewiredId, glTQFMRUrZfduLsKIDJUzTDcBues);
		}
		if (num >= 0)
		{
			ShPJKmqTqEscsPLrBwwdXiFfmbPl.ByZveQAKNLcCwmiFIepiRBKFnHSu byZveQAKNLcCwmiFIepiRBKFnHSu = GHrZOsUKsmgNycoQQnChIdfDbyVJb.ttOLBboCnhDNkHQfyGKgcYDYCTgI(num, glTQFMRUrZfduLsKIDJUzTDcBues);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new HVGGyzsuJEhfLHDhYOAUmSzPNlrQ(P_0.sourceJoystick, byZveQAKNLcCwmiFIepiRBKFnHSu.hHiChMJlINMrNSFqxQwvqCQpRBLt)));
			}
		}
	}
}
