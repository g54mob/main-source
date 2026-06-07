using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class ZvXGRXARsRAyWcsebKvThCOsAbjHb : PlatformInputManager, INativePlatformHelper
{
	private class tXUksfkvxazFcTPMqkXnRqbhXbnf
	{
		private class eEOGQiSIyGHlBSLKqaQAJWPgXImDA
		{
			public int alvcHKfsREQBIBmFtkZWgOMBlwVeB;

			public int GMwEAFUALRCdUdhbfxvyeIEWhcHN;

			public int XiolMlefvUPCoUBiWJjVCaVxIRtj;

			public InputSource avviHdvauaJfVmZxPbKwdCJXvBdi;

			public eEOGQiSIyGHlBSLKqaQAJWPgXImDA(int P_0, int P_1, int P_2, InputSource P_3)
			{
				alvcHKfsREQBIBmFtkZWgOMBlwVeB = P_0;
				GMwEAFUALRCdUdhbfxvyeIEWhcHN = P_1;
				XiolMlefvUPCoUBiWJjVCaVxIRtj = P_2;
				avviHdvauaJfVmZxPbKwdCJXvBdi = P_3;
			}

			public void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(int P_0)
			{
				GMwEAFUALRCdUdhbfxvyeIEWhcHN = P_0;
			}

			public dBNHojIRzqiKplZChbcRruaQRWLH kRAhiHDegkXaSnzlJslgBnsknKrhb()
			{
				return new dBNHojIRzqiKplZChbcRruaQRWLH(alvcHKfsREQBIBmFtkZWgOMBlwVeB, GMwEAFUALRCdUdhbfxvyeIEWhcHN, avviHdvauaJfVmZxPbKwdCJXvBdi);
			}

			public static int IufNAidJSMSVxqzNnLRiIstGJoMw(eEOGQiSIyGHlBSLKqaQAJWPgXImDA P_0, eEOGQiSIyGHlBSLKqaQAJWPgXImDA P_1)
			{
				if (P_0.alvcHKfsREQBIBmFtkZWgOMBlwVeB < P_1.alvcHKfsREQBIBmFtkZWgOMBlwVeB)
				{
					return -1;
				}
				if (P_0.alvcHKfsREQBIBmFtkZWgOMBlwVeB > P_1.alvcHKfsREQBIBmFtkZWgOMBlwVeB)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct dBNHojIRzqiKplZChbcRruaQRWLH
		{
			public int alvcHKfsREQBIBmFtkZWgOMBlwVeB;

			public int GMwEAFUALRCdUdhbfxvyeIEWhcHN;

			public InputSource avviHdvauaJfVmZxPbKwdCJXvBdi;

			public dBNHojIRzqiKplZChbcRruaQRWLH(int P_0, int P_1, InputSource P_2)
			{
				alvcHKfsREQBIBmFtkZWgOMBlwVeB = P_0;
				GMwEAFUALRCdUdhbfxvyeIEWhcHN = P_1;
				avviHdvauaJfVmZxPbKwdCJXvBdi = P_2;
			}
		}

		public enum MzNyfLdlCwPUuANRcyFrGjmmdvCAA
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<eEOGQiSIyGHlBSLKqaQAJWPgXImDA> ulYanuhNezLQNMZilcYpkKAltUljA;

		private List<eEOGQiSIyGHlBSLKqaQAJWPgXImDA> OacwNENxNgxFidyTvPbMabvEFECu;

		public int iiPHCWqruKSunGlgjfUJIrYBmpzm => OacwNENxNgxFidyTvPbMabvEFECu.Count;

		public tXUksfkvxazFcTPMqkXnRqbhXbnf()
		{
			OacwNENxNgxFidyTvPbMabvEFECu = new List<eEOGQiSIyGHlBSLKqaQAJWPgXImDA>();
			ulYanuhNezLQNMZilcYpkKAltUljA = new List<eEOGQiSIyGHlBSLKqaQAJWPgXImDA>();
		}

		public void nTpceOMbERHfAWEKuknABukpBSPu(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = aTrbXeANmagDWpbUFhssjZPOGFfnA(sourceJoystick.rewiredId, MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected);
			eEOGQiSIyGHlBSLKqaQAJWPgXImDA eEOGQiSIyGHlBSLKqaQAJWPgXImDA2;
			if (num >= 0)
			{
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA2 = OacwNENxNgxFidyTvPbMabvEFECu[num];
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA2.cmTGFsRmXJEFbLoGhVUXbOoqUnNg(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new kHSTacYadHQgBEpYEicUGBvpMKon(sourceJoystick, eEOGQiSIyGHlBSLKqaQAJWPgXImDA2.alvcHKfsREQBIBmFtkZWgOMBlwVeB);
				return;
			}
			num = aTrbXeANmagDWpbUFhssjZPOGFfnA(sourceJoystick.rewiredId, MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected);
			if (num >= 0)
			{
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA2 = ulYanuhNezLQNMZilcYpkKAltUljA[num];
				ulYanuhNezLQNMZilcYpkKAltUljA.RemoveAt(num);
				int alvcHKfsREQBIBmFtkZWgOMBlwVeB = hPyGAMkzBoSydeGHygpMoSlYpMCi(eEOGQiSIyGHlBSLKqaQAJWPgXImDA2.alvcHKfsREQBIBmFtkZWgOMBlwVeB);
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA2.alvcHKfsREQBIBmFtkZWgOMBlwVeB = alvcHKfsREQBIBmFtkZWgOMBlwVeB;
			}
			else
			{
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA2 = new eEOGQiSIyGHlBSLKqaQAJWPgXImDA(hPyGAMkzBoSydeGHygpMoSlYpMCi(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new kHSTacYadHQgBEpYEicUGBvpMKon(sourceJoystick, eEOGQiSIyGHlBSLKqaQAJWPgXImDA2.alvcHKfsREQBIBmFtkZWgOMBlwVeB);
			OacwNENxNgxFidyTvPbMabvEFECu.Add(eEOGQiSIyGHlBSLKqaQAJWPgXImDA2);
			OacwNENxNgxFidyTvPbMabvEFECu.Sort(eEOGQiSIyGHlBSLKqaQAJWPgXImDA.IufNAidJSMSVxqzNnLRiIstGJoMw);
		}

		public void KjeBHfkGmaWFVWDWirxuUvbezZWG(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0.rewiredId, MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				eEOGQiSIyGHlBSLKqaQAJWPgXImDA item = OacwNENxNgxFidyTvPbMabvEFECu[num];
				OacwNENxNgxFidyTvPbMabvEFECu.RemoveAt(num);
				ulYanuhNezLQNMZilcYpkKAltUljA.Add(item);
			}
		}

		public void oPPkQQRScKXLmfBnsrVmGvILeqRC(int P_0, int P_1)
		{
			int num = aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0, MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected);
			if (num >= 0)
			{
				OacwNENxNgxFidyTvPbMabvEFECu[num].cmTGFsRmXJEFbLoGhVUXbOoqUnNg(P_1);
				return;
			}
			num = aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0, MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected);
			if (num >= 0)
			{
				ulYanuhNezLQNMZilcYpkKAltUljA[num].cmTGFsRmXJEFbLoGhVUXbOoqUnNg(P_1);
			}
		}

		public bool ghyGlwPuMUWtZfXZdoPpZMgHrCIp(int P_0, MzNyfLdlCwPUuANRcyFrGjmmdvCAA P_1)
		{
			if (aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int aTrbXeANmagDWpbUFhssjZPOGFfnA(int P_0, MzNyfLdlCwPUuANRcyFrGjmmdvCAA P_1)
		{
			switch (P_1)
			{
			case MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected:
			{
				int count2 = OacwNENxNgxFidyTvPbMabvEFECu.Count;
				for (int j = 0; j < count2; j++)
				{
					if (OacwNENxNgxFidyTvPbMabvEFECu[j].XiolMlefvUPCoUBiWJjVCaVxIRtj == P_0)
					{
						return j;
					}
				}
				break;
			}
			case MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected:
			{
				int count = ulYanuhNezLQNMZilcYpkKAltUljA.Count;
				for (int i = 0; i < count; i++)
				{
					if (ulYanuhNezLQNMZilcYpkKAltUljA[i].XiolMlefvUPCoUBiWJjVCaVxIRtj == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int aTrbXeANmagDWpbUFhssjZPOGFfnA(int P_0, InputSource P_1, MzNyfLdlCwPUuANRcyFrGjmmdvCAA P_2)
		{
			switch (P_2)
			{
			case MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected:
			{
				int count2 = OacwNENxNgxFidyTvPbMabvEFECu.Count;
				for (int j = 0; j < count2; j++)
				{
					if (OacwNENxNgxFidyTvPbMabvEFECu[j].alvcHKfsREQBIBmFtkZWgOMBlwVeB == P_0 && OacwNENxNgxFidyTvPbMabvEFECu[j].avviHdvauaJfVmZxPbKwdCJXvBdi == P_1)
					{
						return j;
					}
				}
				break;
			}
			case MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected:
			{
				int count = ulYanuhNezLQNMZilcYpkKAltUljA.Count;
				for (int i = 0; i < count; i++)
				{
					if (ulYanuhNezLQNMZilcYpkKAltUljA[i].alvcHKfsREQBIBmFtkZWgOMBlwVeB == P_0 && ulYanuhNezLQNMZilcYpkKAltUljA[i].avviHdvauaJfVmZxPbKwdCJXvBdi == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public dBNHojIRzqiKplZChbcRruaQRWLH kRAhiHDegkXaSnzlJslgBnsknKrhb(int P_0, MzNyfLdlCwPUuANRcyFrGjmmdvCAA P_1)
		{
			if (P_1 == MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected)
			{
				if (P_0 < 0 || P_0 >= OacwNENxNgxFidyTvPbMabvEFECu.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return OacwNENxNgxFidyTvPbMabvEFECu[P_0].kRAhiHDegkXaSnzlJslgBnsknKrhb();
			}
			if (P_0 < 0 || P_0 >= ulYanuhNezLQNMZilcYpkKAltUljA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return ulYanuhNezLQNMZilcYpkKAltUljA[P_0].kRAhiHDegkXaSnzlJslgBnsknKrhb();
		}

		public int BGofYUulkeNZQubFkEqpsAQfHUaN(int P_0, InputSource P_1, MzNyfLdlCwPUuANRcyFrGjmmdvCAA P_2)
		{
			int num = aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected => OacwNENxNgxFidyTvPbMabvEFECu[num].GMwEAFUALRCdUdhbfxvyeIEWhcHN, 
				MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected => ulYanuhNezLQNMZilcYpkKAltUljA[num].GMwEAFUALRCdUdhbfxvyeIEWhcHN, 
				_ => -1, 
			};
		}

		private int hPyGAMkzBoSydeGHygpMoSlYpMCi(int P_0)
		{
			int count = OacwNENxNgxFidyTvPbMabvEFECu.Count;
			for (int i = 0; i < count; i++)
			{
				if (OacwNENxNgxFidyTvPbMabvEFECu[i].alvcHKfsREQBIBmFtkZWgOMBlwVeB == P_0)
				{
					return hPyGAMkzBoSydeGHygpMoSlYpMCi();
				}
			}
			return P_0;
		}

		private int hPyGAMkzBoSydeGHygpMoSlYpMCi()
		{
			int count = OacwNENxNgxFidyTvPbMabvEFECu.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (OacwNENxNgxFidyTvPbMabvEFECu[i].alvcHKfsREQBIBmFtkZWgOMBlwVeB == num)
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

	private class kHSTacYadHQgBEpYEicUGBvpMKon : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic UOFqirErmvMNabjsFWtrdaqLdGmG;

		private int KiTtXSzcOwHMdVpJQjwDUpEoQfVB;

		public int rewiredId => UOFqirErmvMNabjsFWtrdaqLdGmG.rewiredId;

		public int inputManagerId => KiTtXSzcOwHMdVpJQjwDUpEoQfVB;

		public string name => UOFqirErmvMNabjsFWtrdaqLdGmG.name;

		public long? systemId => UOFqirErmvMNabjsFWtrdaqLdGmG.systemId;

		public int unityId => UOFqirErmvMNabjsFWtrdaqLdGmG.unityId;

		public Guid instanceGuid => UOFqirErmvMNabjsFWtrdaqLdGmG.instanceGuid;

		public Guid persistentGuid => instanceGuid;

		public Controller.Extension extension => UOFqirErmvMNabjsFWtrdaqLdGmG.extension;

		public kHSTacYadHQgBEpYEicUGBvpMKon(IInputManagerJoystickPublic P_0, int P_1)
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG = P_0;
			KiTtXSzcOwHMdVpJQjwDUpEoQfVB = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG.StopVibration();
		}
	}

	private sealed class xZxHVXVEiPmyWxeXopdcRHMoLFhF
	{
		public int kUOsJxYLUWyznwEfWHvxXAFCYHJt;

		internal int BFnCMsUwhTsndJlKQofoKCQuaCjH()
		{
			return kUOsJxYLUWyznwEfWHvxXAFCYHJt++;
		}
	}

	private const bool BJXhibcnpXWixczuDRYloBnAAcxQ = false;

	private const bool LxdIraTHKVHyZSGyOGnmtCUYLbGF = false;

	private const bool OCbwChzAtahwfyOCSfAfRyNQxzPf = false;

	private const bool QDqZqofgFQsDhnmBAAVgoNFLTpCd = false;

	private const bool GPmovfOYFgVgimkuCFuUkCgpoBok = false;

	private bool khuHbEfjZduWJkBMZYZFiKyXZnzg;

	private object wMmJNRPsSEoFKwaZTHvzuFephCvl;

	private IndexedDictionary<int, PlatformInputManager> AEvtiTWepFgluLgeghcjCjkbyqh;

	private tXUksfkvxazFcTPMqkXnRqbhXbnf kzlUmaQOxbWuLvXHdfOusecwqFCJ;

	private Action<int, ControllerDataUpdater> gIbTlsSrKDMpanbmCiYbwdiijXPD;

	private WindowsStandalonePrimaryInputSource birYCICSHVIBemjybiOicMXoSPIV;

	private bool HTaEKrIPWfGKUsacwDGpMoKoMjfC;

	private PlatformInputManager ewPuxDjadzNAGkyZuovLGXCJpSMn;

	private bool yZLLmEpuJhUXWuiOLOqCkEpVBFQq;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TGhMfMpddOgpnflvcRUCHgmAPREiA;

	private Func<int> CGMcJfJcoaSZisGLhxSsARZLqayx;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.gBBqUdSFcejTTQUMOBCKULCrNSfi();
			IntPtr intPtr2 = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.vXOctowsgMjuwZXcfPERVmiXpeTg();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => kzlUmaQOxbWuLvXHdfOusecwqFCJ.iiPHCWqruKSunGlgjfUJIrYBmpzm;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ewPuxDjadzNAGkyZuovLGXCJpSMn;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => ewPuxDjadzNAGkyZuovLGXCJpSMn.inputSource;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (ewPuxDjadzNAGkyZuovLGXCJpSMn == null)
			{
				return InputSource.None;
			}
			return ewPuxDjadzNAGkyZuovLGXCJpSMn.inputSourceType;
		}
	}

	public ZvXGRXARsRAyWcsebKvThCOsAbjHb(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		birYCICSHVIBemjybiOicMXoSPIV = P_0.windowsStandalonePrimaryInputSource;
		HTaEKrIPWfGKUsacwDGpMoKoMjfC = P_0.useXInput;
		TGhMfMpddOgpnflvcRUCHgmAPREiA = P_1;
		CGMcJfJcoaSZisGLhxSsARZLqayx = P_2;
		bool flag = false;
		AEvtiTWepFgluLgeghcjCjkbyqh = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				FAsHqxeBatkZAlvOYNBwGTMPNyEq.qPhGjuHRNEfrkMynCGIBKdbFaOxF();
				QOnrDTDFtrKijCbOMVvnoYTrhaxW qOnrDTDFtrKijCbOMVvnoYTrhaxW = (QOnrDTDFtrKijCbOMVvnoYTrhaxW)(wMmJNRPsSEoFKwaZTHvzuFephCvl = new QOnrDTDFtrKijCbOMVvnoYTrhaxW());
				bool flag2 = false;
				if (birYCICSHVIBemjybiOicMXoSPIV == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = POBBLKhbMXBHWHqckeUsUTijTfYJ(P_0, qOnrDTDFtrKijCbOMVvnoYTrhaxW);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = tkwOaWyDyIvkRIltskDuwePPiLukA(P_0, qOnrDTDFtrKijCbOMVvnoYTrhaxW);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							birYCICSHVIBemjybiOicMXoSPIV = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (birYCICSHVIBemjybiOicMXoSPIV == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = tkwOaWyDyIvkRIltskDuwePPiLukA(P_0, qOnrDTDFtrKijCbOMVvnoYTrhaxW);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = POBBLKhbMXBHWHqckeUsUTijTfYJ(P_0, qOnrDTDFtrKijCbOMVvnoYTrhaxW);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							birYCICSHVIBemjybiOicMXoSPIV = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (birYCICSHVIBemjybiOicMXoSPIV == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = bhbeWcThDLapGaUKFdyYMODwktTy(P_0, false);
					if (flag2)
					{
						sShpboZJChQPUTgMwIJvhhMscroS(P_0, qOnrDTDFtrKijCbOMVvnoYTrhaxW);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				qOnrDTDFtrKijCbOMVvnoYTrhaxW.AJNExKnaBXFBOkZoIWhmrelMMjJTA += fMETbuWJvSMkxSEBJPpdAdARbGDW;
				qOnrDTDFtrKijCbOMVvnoYTrhaxW.FiLZHDTlGVoWKYTAhoSQlRSTyUsL += lzsOMpAlDaVTdmbDtGNXTjFtLYEc;
				for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
				{
					PlatformInputManager platformInputManager = AEvtiTWepFgluLgeghcjCjkbyqh[i];
					platformInputManager.DeviceConnectedEvent += rJPNuNndJgnnnxlitjaXzWtdYQbO;
					platformInputManager.DeviceDisconnectedEvent += ADGQreqteaHFDDqxnLaYBrAQRekq;
					platformInputManager.UpdateControllerInfoEvent += GUBRFIamhzYUsXNjUEAgwxZlDtTDA;
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
			bhbeWcThDLapGaUKFdyYMODwktTy(P_0, true);
		}
		gIbTlsSrKDMpanbmCiYbwdiijXPD = UpdateControllerData;
	}

	private bool POBBLKhbMXBHWHqckeUsUTijTfYJ(ConfigVars P_0, QOnrDTDFtrKijCbOMVvnoYTrhaxW P_1)
	{
		ncVapRIcLeMmeuUJBqPqimIyTuLw ncVapRIcLeMmeuUJBqPqimIyTuLw2 = null;
		RednHzHjISZZavTermPTuizNgEaaA rednHzHjISZZavTermPTuizNgEaaA = null;
		try
		{
			ncVapRIcLeMmeuUJBqPqimIyTuLw2 = new ncVapRIcLeMmeuUJBqPqimIyTuLw(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			rednHzHjISZZavTermPTuizNgEaaA = (RednHzHjISZZavTermPTuizNgEaaA)(ewPuxDjadzNAGkyZuovLGXCJpSMn = new RednHzHjISZZavTermPTuizNgEaaA(P_0.updateLoop, HTaEKrIPWfGKUsacwDGpMoKoMjfC, ((QOnrDTDFtrKijCbOMVvnoYTrhaxW)wMmJNRPsSEoFKwaZTHvzuFephCvl).UZrpHbOeJXmTKqlpektZUmPTDHyP, TGhMfMpddOgpnflvcRUCHgmAPREiA, CGMcJfJcoaSZisGLhxSsARZLqayx));
			AEvtiTWepFgluLgeghcjCjkbyqh.Add(5, ncVapRIcLeMmeuUJBqPqimIyTuLw2);
			AEvtiTWepFgluLgeghcjCjkbyqh.Add(1, ewPuxDjadzNAGkyZuovLGXCJpSMn);
			P_1.inPQwydyVnMUXiqwghxAiYgWSHeB += ncVapRIcLeMmeuUJBqPqimIyTuLw2.hOkJQtYQxqLKALRbEqWBOBDxccbL;
			return true;
		}
		catch (Exception)
		{
			rednHzHjISZZavTermPTuizNgEaaA?.OnDestroy();
			ncVapRIcLeMmeuUJBqPqimIyTuLw2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
		}
		return false;
	}

	private bool tkwOaWyDyIvkRIltskDuwePPiLukA(ConfigVars P_0, QOnrDTDFtrKijCbOMVvnoYTrhaxW P_1)
	{
		ncVapRIcLeMmeuUJBqPqimIyTuLw ncVapRIcLeMmeuUJBqPqimIyTuLw2 = null;
		try
		{
			ncVapRIcLeMmeuUJBqPqimIyTuLw2 = new ncVapRIcLeMmeuUJBqPqimIyTuLw(P_0, P_0.useXInput, TGhMfMpddOgpnflvcRUCHgmAPREiA, CGMcJfJcoaSZisGLhxSsARZLqayx, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			AEvtiTWepFgluLgeghcjCjkbyqh.Add(5, ncVapRIcLeMmeuUJBqPqimIyTuLw2);
			P_1.inPQwydyVnMUXiqwghxAiYgWSHeB += ncVapRIcLeMmeuUJBqPqimIyTuLw2.hOkJQtYQxqLKALRbEqWBOBDxccbL;
			ewPuxDjadzNAGkyZuovLGXCJpSMn = ncVapRIcLeMmeuUJBqPqimIyTuLw2;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			ncVapRIcLeMmeuUJBqPqimIyTuLw2?.OnDestroy();
		}
		return false;
	}

	private bool sShpboZJChQPUTgMwIJvhhMscroS(ConfigVars P_0, QOnrDTDFtrKijCbOMVvnoYTrhaxW P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		ncVapRIcLeMmeuUJBqPqimIyTuLw ncVapRIcLeMmeuUJBqPqimIyTuLw2 = null;
		try
		{
			ncVapRIcLeMmeuUJBqPqimIyTuLw2 = new ncVapRIcLeMmeuUJBqPqimIyTuLw(P_0, false, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.inPQwydyVnMUXiqwghxAiYgWSHeB += ncVapRIcLeMmeuUJBqPqimIyTuLw2.hOkJQtYQxqLKALRbEqWBOBDxccbL;
			AEvtiTWepFgluLgeghcjCjkbyqh.Add(5, ncVapRIcLeMmeuUJBqPqimIyTuLw2);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			ncVapRIcLeMmeuUJBqPqimIyTuLw2?.OnDestroy();
			ncVapRIcLeMmeuUJBqPqimIyTuLw2 = null;
			return false;
		}
	}

	private bool bhbeWcThDLapGaUKFdyYMODwktTy(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = ewPuxDjadzNAGkyZuovLGXCJpSMn == null;
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
				xZxHVXVEiPmyWxeXopdcRHMoLFhF xZxHVXVEiPmyWxeXopdcRHMoLFhF2 = new xZxHVXVEiPmyWxeXopdcRHMoLFhF();
				xZxHVXVEiPmyWxeXopdcRHMoLFhF2.kUOsJxYLUWyznwEfWHvxXAFCYHJt = 0;
				AlBcJmeoydKHZKsNzaymBkJbpJeM value = new AlBcJmeoydKHZKsNzaymBkJbpJeM(flag2, updateLoop, TGhMfMpddOgpnflvcRUCHgmAPREiA, xZxHVXVEiPmyWxeXopdcRHMoLFhF2.BFnCMsUwhTsndJlKQofoKCQuaCjH);
				AEvtiTWepFgluLgeghcjCjkbyqh.Add(2, value);
			}
			else
			{
				AlBcJmeoydKHZKsNzaymBkJbpJeM alBcJmeoydKHZKsNzaymBkJbpJeM = new AlBcJmeoydKHZKsNzaymBkJbpJeM(flag2, updateLoop, TGhMfMpddOgpnflvcRUCHgmAPREiA, CGMcJfJcoaSZisGLhxSsARZLqayx);
				if (flag)
				{
					ewPuxDjadzNAGkyZuovLGXCJpSMn = alBcJmeoydKHZKsNzaymBkJbpJeM;
				}
				AEvtiTWepFgluLgeghcjCjkbyqh.Add(2, alBcJmeoydKHZKsNzaymBkJbpJeM);
				if (P_1)
				{
					alBcJmeoydKHZKsNzaymBkJbpJeM.DeviceConnectedEvent += rJPNuNndJgnnnxlitjaXzWtdYQbO;
					alBcJmeoydKHZKsNzaymBkJbpJeM.DeviceDisconnectedEvent += ADGQreqteaHFDDqxnLaYBrAQRekq;
					alBcJmeoydKHZKsNzaymBkJbpJeM.UpdateControllerInfoEvent += GUBRFIamhzYUsXNjUEAgwxZlDtTDA;
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
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + birYCICSHVIBemjybiOicMXoSPIV.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
				P_0.useXInput = false;
				for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
				{
					if (AEvtiTWepFgluLgeghcjCjkbyqh[i] != null && AEvtiTWepFgluLgeghcjCjkbyqh[i] is InpDmQfQABlCOUIizbBrrTlTjrHt inpDmQfQABlCOUIizbBrrTlTjrHt)
					{
						inpDmQfQABlCOUIizbBrrTlTjrHt.HTaEKrIPWfGKUsacwDGpMoKoMjfC = false;
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
		khuHbEfjZduWJkBMZYZFiKyXZnzg = true;
		kzlUmaQOxbWuLvXHdfOusecwqFCJ = new tXUksfkvxazFcTPMqkXnRqbhXbnf();
		for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
		{
			AEvtiTWepFgluLgeghcjCjkbyqh[i].Initialize();
		}
	}

	public virtual void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(UpdateLoopType P_0)
	{
		for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
		{
			AEvtiTWepFgluLgeghcjCjkbyqh[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = AEvtiTWepFgluLgeghcjCjkbyqh.Count - 1; num >= 0; num--)
		{
			AEvtiTWepFgluLgeghcjCjkbyqh[num].OnDestroy();
		}
		if (wMmJNRPsSEoFKwaZTHvzuFephCvl != null)
		{
			((QOnrDTDFtrKijCbOMVvnoYTrhaxW)wMmJNRPsSEoFKwaZTHvzuFephCvl).SHpKvvkQdsduWbSBkccfCFGmOuaI();
			wMmJNRPsSEoFKwaZTHvzuFephCvl = null;
		}
		FAsHqxeBatkZAlvOYNBwGTMPNyEq.hIlanWXkrCYfgvCyascUuCUOCBcL();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return gIbTlsSrKDMpanbmCiYbwdiijXPD;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		AEvtiTWepFgluLgeghcjCjkbyqh.GetValue((int)data.source).UpdateControllerData(kzlUmaQOxbWuLvXHdfOusecwqFCJ.BGofYUulkeNZQubFkEqpsAQfHUaN(controllerId, data.source, tXUksfkvxazFcTPMqkXnRqbhXbnf.MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected), data);
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
		for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = AEvtiTWepFgluLgeghcjCjkbyqh[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = AEvtiTWepFgluLgeghcjCjkbyqh[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void rJPNuNndJgnnnxlitjaXzWtdYQbO(BridgedController P_0)
	{
		if (P_0 != null)
		{
			kzlUmaQOxbWuLvXHdfOusecwqFCJ.nTpceOMbERHfAWEKuknABukpBSPu(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void ADGQreqteaHFDDqxnLaYBrAQRekq(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			kzlUmaQOxbWuLvXHdfOusecwqFCJ.KjeBHfkGmaWFVWDWirxuUvbezZWG(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void fMETbuWJvSMkxSEBJPpdAdARbGDW(EventArgs P_0)
	{
		if (khuHbEfjZduWJkBMZYZFiKyXZnzg)
		{
			for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
			{
				AEvtiTWepFgluLgeghcjCjkbyqh[i].SystemDeviceConnected();
			}
		}
	}

	private void lzsOMpAlDaVTdmbDtGNXTjFtLYEc(EventArgs P_0)
	{
		if (khuHbEfjZduWJkBMZYZFiKyXZnzg)
		{
			for (int i = 0; i < AEvtiTWepFgluLgeghcjCjkbyqh.Count; i++)
			{
				AEvtiTWepFgluLgeghcjCjkbyqh[i].SystemDeviceDisconnected();
			}
		}
	}

	private void GUBRFIamhzYUsXNjUEAgwxZlDtTDA(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		kzlUmaQOxbWuLvXHdfOusecwqFCJ.oPPkQQRScKXLmfBnsrVmGvILeqRC(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		tXUksfkvxazFcTPMqkXnRqbhXbnf.MzNyfLdlCwPUuANRcyFrGjmmdvCAA mzNyfLdlCwPUuANRcyFrGjmmdvCAA = tXUksfkvxazFcTPMqkXnRqbhXbnf.MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Connected;
		int num = kzlUmaQOxbWuLvXHdfOusecwqFCJ.aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0.sourceJoystick.rewiredId, mzNyfLdlCwPUuANRcyFrGjmmdvCAA);
		if (num < 0)
		{
			mzNyfLdlCwPUuANRcyFrGjmmdvCAA = tXUksfkvxazFcTPMqkXnRqbhXbnf.MzNyfLdlCwPUuANRcyFrGjmmdvCAA.Disconnected;
			num = kzlUmaQOxbWuLvXHdfOusecwqFCJ.aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0.sourceJoystick.rewiredId, mzNyfLdlCwPUuANRcyFrGjmmdvCAA);
		}
		if (num >= 0)
		{
			tXUksfkvxazFcTPMqkXnRqbhXbnf.dBNHojIRzqiKplZChbcRruaQRWLH dBNHojIRzqiKplZChbcRruaQRWLH = kzlUmaQOxbWuLvXHdfOusecwqFCJ.kRAhiHDegkXaSnzlJslgBnsknKrhb(num, mzNyfLdlCwPUuANRcyFrGjmmdvCAA);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new kHSTacYadHQgBEpYEicUGBvpMKon(P_0.sourceJoystick, dBNHojIRzqiKplZChbcRruaQRWLH.alvcHKfsREQBIBmFtkZWgOMBlwVeB)));
			}
		}
	}
}
