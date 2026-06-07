using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class wRGJqvlkSUqSTLLyCDlEyuxIbzU : PlatformInputManager, INativePlatformHelper
{
	private class lyRWmyWrTkkKqYEnnNYgWsNqCeA
	{
		private class VgZAyeizOSLApoliytBqeiARNnE
		{
			public int XRsRAyNfLNBbCXWkChtiwaoHcJX;

			public int npxfEttkHIspMYeYQqJCEsiwauX;

			public int mSvZfXBvxTHpgbdZddhfoMjLzMl;

			public InputSource ZfsAwHWQezYJXJnEkPTMXerdwlx;

			public VgZAyeizOSLApoliytBqeiARNnE(int mapperId, int managerId, int id, InputSource source)
			{
				XRsRAyNfLNBbCXWkChtiwaoHcJX = mapperId;
				npxfEttkHIspMYeYQqJCEsiwauX = managerId;
				mSvZfXBvxTHpgbdZddhfoMjLzMl = id;
				ZfsAwHWQezYJXJnEkPTMXerdwlx = source;
			}

			public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(int P_0)
			{
				npxfEttkHIspMYeYQqJCEsiwauX = P_0;
			}

			public hChyxezXUugHgAeqmlgEHJxIJyE FtLirbPmlhaUtUCzePQZBISsSvx()
			{
				return new hChyxezXUugHgAeqmlgEHJxIJyE(XRsRAyNfLNBbCXWkChtiwaoHcJX, npxfEttkHIspMYeYQqJCEsiwauX, ZfsAwHWQezYJXJnEkPTMXerdwlx);
			}

			public static int pGeAWIQxMRPorXdsKdbSsoJcoYW(VgZAyeizOSLApoliytBqeiARNnE P_0, VgZAyeizOSLApoliytBqeiARNnE P_1)
			{
				if (P_0.XRsRAyNfLNBbCXWkChtiwaoHcJX < P_1.XRsRAyNfLNBbCXWkChtiwaoHcJX)
				{
					return -1;
				}
				if (P_0.XRsRAyNfLNBbCXWkChtiwaoHcJX > P_1.XRsRAyNfLNBbCXWkChtiwaoHcJX)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct hChyxezXUugHgAeqmlgEHJxIJyE
		{
			public int XRsRAyNfLNBbCXWkChtiwaoHcJX;

			public int npxfEttkHIspMYeYQqJCEsiwauX;

			public InputSource ZfsAwHWQezYJXJnEkPTMXerdwlx;

			public hChyxezXUugHgAeqmlgEHJxIJyE(int mapperId, int managerId, InputSource source)
			{
				XRsRAyNfLNBbCXWkChtiwaoHcJX = mapperId;
				npxfEttkHIspMYeYQqJCEsiwauX = managerId;
				ZfsAwHWQezYJXJnEkPTMXerdwlx = source;
			}
		}

		public enum CWwpuIoNrVfHGzxNoTaVcnvEDql
		{
			DfsndYxHYVKUdQgDuAfETngfexb = 0,
			ibjqBHyFNJOhWJActsfrTOPbIjF = 1
		}

		private List<VgZAyeizOSLApoliytBqeiARNnE> VzHplWqDoiGPRsoLYmhFkyqFIad;

		private List<VgZAyeizOSLApoliytBqeiARNnE> ljlFgsoFTzbpyFQeQerixAJeKUQN;

		public int deviceCount => ljlFgsoFTzbpyFQeQerixAJeKUQN.Count;

		public lyRWmyWrTkkKqYEnnNYgWsNqCeA()
		{
			ljlFgsoFTzbpyFQeQerixAJeKUQN = new List<VgZAyeizOSLApoliytBqeiARNnE>();
			VzHplWqDoiGPRsoLYmhFkyqFIad = new List<VgZAyeizOSLApoliytBqeiARNnE>();
		}

		public void AQseuqGpSAGZYovnDOPmjUCBiYJ(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = HkuBROogyjTXYCIdeWrOxVjcZYh(sourceJoystick.rewiredId, CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb);
			VgZAyeizOSLApoliytBqeiARNnE vgZAyeizOSLApoliytBqeiARNnE;
			if (num >= 0)
			{
				vgZAyeizOSLApoliytBqeiARNnE = ljlFgsoFTzbpyFQeQerixAJeKUQN[num];
				vgZAyeizOSLApoliytBqeiARNnE.RMEkOMsGFSFWbHqrAFftMTIKNIHO(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new OEBEbFbMrNNpsFtcGmubYYlnvxav(sourceJoystick, vgZAyeizOSLApoliytBqeiARNnE.XRsRAyNfLNBbCXWkChtiwaoHcJX);
				return;
			}
			num = HkuBROogyjTXYCIdeWrOxVjcZYh(sourceJoystick.rewiredId, CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF);
			if (num >= 0)
			{
				vgZAyeizOSLApoliytBqeiARNnE = VzHplWqDoiGPRsoLYmhFkyqFIad[num];
				VzHplWqDoiGPRsoLYmhFkyqFIad.RemoveAt(num);
				int xRsRAyNfLNBbCXWkChtiwaoHcJX = GVzfOeZIHlvOxZmwPALqMBXmapC(vgZAyeizOSLApoliytBqeiARNnE.XRsRAyNfLNBbCXWkChtiwaoHcJX);
				vgZAyeizOSLApoliytBqeiARNnE.XRsRAyNfLNBbCXWkChtiwaoHcJX = xRsRAyNfLNBbCXWkChtiwaoHcJX;
			}
			else
			{
				vgZAyeizOSLApoliytBqeiARNnE = new VgZAyeizOSLApoliytBqeiARNnE(GVzfOeZIHlvOxZmwPALqMBXmapC(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new OEBEbFbMrNNpsFtcGmubYYlnvxav(sourceJoystick, vgZAyeizOSLApoliytBqeiARNnE.XRsRAyNfLNBbCXWkChtiwaoHcJX);
			ljlFgsoFTzbpyFQeQerixAJeKUQN.Add(vgZAyeizOSLApoliytBqeiARNnE);
			ljlFgsoFTzbpyFQeQerixAJeKUQN.Sort(VgZAyeizOSLApoliytBqeiARNnE.pGeAWIQxMRPorXdsKdbSsoJcoYW);
		}

		public void xuhDPJaZkjYMDrlxHwHUrcDEAvOB(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = HkuBROogyjTXYCIdeWrOxVjcZYh(P_0.rewiredId, CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				VgZAyeizOSLApoliytBqeiARNnE item = ljlFgsoFTzbpyFQeQerixAJeKUQN[num];
				ljlFgsoFTzbpyFQeQerixAJeKUQN.RemoveAt(num);
				VzHplWqDoiGPRsoLYmhFkyqFIad.Add(item);
			}
		}

		public void DUOGkuBaUPzJcBWcTTLKNwFtFwDf(int P_0, int P_1)
		{
			int num = HkuBROogyjTXYCIdeWrOxVjcZYh(P_0, CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb);
			if (num >= 0)
			{
				VgZAyeizOSLApoliytBqeiARNnE vgZAyeizOSLApoliytBqeiARNnE = ljlFgsoFTzbpyFQeQerixAJeKUQN[num];
				vgZAyeizOSLApoliytBqeiARNnE.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_1);
				return;
			}
			num = HkuBROogyjTXYCIdeWrOxVjcZYh(P_0, CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF);
			if (num >= 0)
			{
				VgZAyeizOSLApoliytBqeiARNnE vgZAyeizOSLApoliytBqeiARNnE = VzHplWqDoiGPRsoLYmhFkyqFIad[num];
				vgZAyeizOSLApoliytBqeiARNnE.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_1);
			}
		}

		public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(int P_0, CWwpuIoNrVfHGzxNoTaVcnvEDql P_1)
		{
			if (HkuBROogyjTXYCIdeWrOxVjcZYh(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int HkuBROogyjTXYCIdeWrOxVjcZYh(int P_0, CWwpuIoNrVfHGzxNoTaVcnvEDql P_1)
		{
			switch (P_1)
			{
			case CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb:
			{
				int count2 = ljlFgsoFTzbpyFQeQerixAJeKUQN.Count;
				for (int j = 0; j < count2; j++)
				{
					if (ljlFgsoFTzbpyFQeQerixAJeKUQN[j].mSvZfXBvxTHpgbdZddhfoMjLzMl == P_0)
					{
						return j;
					}
				}
				break;
			}
			case CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF:
			{
				int count = VzHplWqDoiGPRsoLYmhFkyqFIad.Count;
				for (int i = 0; i < count; i++)
				{
					if (VzHplWqDoiGPRsoLYmhFkyqFIad[i].mSvZfXBvxTHpgbdZddhfoMjLzMl == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int HkuBROogyjTXYCIdeWrOxVjcZYh(int P_0, InputSource P_1, CWwpuIoNrVfHGzxNoTaVcnvEDql P_2)
		{
			switch (P_2)
			{
			case CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb:
			{
				int count2 = ljlFgsoFTzbpyFQeQerixAJeKUQN.Count;
				for (int j = 0; j < count2; j++)
				{
					if (ljlFgsoFTzbpyFQeQerixAJeKUQN[j].XRsRAyNfLNBbCXWkChtiwaoHcJX == P_0 && ljlFgsoFTzbpyFQeQerixAJeKUQN[j].ZfsAwHWQezYJXJnEkPTMXerdwlx == P_1)
					{
						return j;
					}
				}
				break;
			}
			case CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF:
			{
				int count = VzHplWqDoiGPRsoLYmhFkyqFIad.Count;
				for (int i = 0; i < count; i++)
				{
					if (VzHplWqDoiGPRsoLYmhFkyqFIad[i].XRsRAyNfLNBbCXWkChtiwaoHcJX == P_0 && VzHplWqDoiGPRsoLYmhFkyqFIad[i].ZfsAwHWQezYJXJnEkPTMXerdwlx == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public hChyxezXUugHgAeqmlgEHJxIJyE FtLirbPmlhaUtUCzePQZBISsSvx(int P_0, CWwpuIoNrVfHGzxNoTaVcnvEDql P_1)
		{
			if (P_1 == CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb)
			{
				if (P_0 < 0 || P_0 >= ljlFgsoFTzbpyFQeQerixAJeKUQN.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return ljlFgsoFTzbpyFQeQerixAJeKUQN[P_0].FtLirbPmlhaUtUCzePQZBISsSvx();
			}
			if (P_0 < 0 || P_0 >= VzHplWqDoiGPRsoLYmhFkyqFIad.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return VzHplWqDoiGPRsoLYmhFkyqFIad[P_0].FtLirbPmlhaUtUCzePQZBISsSvx();
		}

		public int qCbgdmFwubqJWTxyDqoDIPwDbKeJ(int P_0, InputSource P_1, CWwpuIoNrVfHGzxNoTaVcnvEDql P_2)
		{
			int num = HkuBROogyjTXYCIdeWrOxVjcZYh(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb => ljlFgsoFTzbpyFQeQerixAJeKUQN[num].npxfEttkHIspMYeYQqJCEsiwauX, 
				CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF => VzHplWqDoiGPRsoLYmhFkyqFIad[num].npxfEttkHIspMYeYQqJCEsiwauX, 
				_ => -1, 
			};
		}

		private int GVzfOeZIHlvOxZmwPALqMBXmapC(int P_0)
		{
			int count = ljlFgsoFTzbpyFQeQerixAJeKUQN.Count;
			for (int i = 0; i < count; i++)
			{
				if (ljlFgsoFTzbpyFQeQerixAJeKUQN[i].XRsRAyNfLNBbCXWkChtiwaoHcJX == P_0)
				{
					return GVzfOeZIHlvOxZmwPALqMBXmapC();
				}
			}
			return P_0;
		}

		private int GVzfOeZIHlvOxZmwPALqMBXmapC()
		{
			int count = ljlFgsoFTzbpyFQeQerixAJeKUQN.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (ljlFgsoFTzbpyFQeQerixAJeKUQN[i].XRsRAyNfLNBbCXWkChtiwaoHcJX == num)
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

	private class OEBEbFbMrNNpsFtcGmubYYlnvxav : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic fUWusVflpgaWsSNSoAiTBPWnobsa;

		private int nTGVfpKPcLEZKfcOkaFESiNEJGdr;

		public int rewiredId => fUWusVflpgaWsSNSoAiTBPWnobsa.rewiredId;

		public int inputManagerId => nTGVfpKPcLEZKfcOkaFESiNEJGdr;

		public string name => fUWusVflpgaWsSNSoAiTBPWnobsa.name;

		public long? systemId => fUWusVflpgaWsSNSoAiTBPWnobsa.systemId;

		public int unityId => fUWusVflpgaWsSNSoAiTBPWnobsa.unityId;

		public Guid instanceGuid => fUWusVflpgaWsSNSoAiTBPWnobsa.instanceGuid;

		public Guid persistentGuid => instanceGuid;

		public Controller.Extension extension => fUWusVflpgaWsSNSoAiTBPWnobsa.extension;

		public OEBEbFbMrNNpsFtcGmubYYlnvxav(IInputManagerJoystickPublic sourceJoystick, int bridgeJoystickId)
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa = sourceJoystick;
			nTGVfpKPcLEZKfcOkaFESiNEJGdr = bridgeJoystickId;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.StopVibration();
		}
	}

	private sealed class pxUDKJlTyIXXFVKvtqeQsDeusPf
	{
		public int LSBZNFvFIBjrdZJYfgPRzEbigLTH;

		public int gywfYCfpkMLytswWtdEOskcWGadq()
		{
			return LSBZNFvFIBjrdZJYfgPRzEbigLTH++;
		}
	}

	private const bool gqWiQPTotUuPrFdJmoJPIHTqFuv = false;

	private const bool qNeBEMaqOQARVspBvZiScFgsvPAo = false;

	private const bool bikEoRbAxjGlprFrvCBBBtnFgbJD = false;

	private const bool lvdwTWMEgJGyhGnHbXeSKRfbTFQ = false;

	private const bool lUvFaFdvWdnVsqLBrxzmpKALxyy = false;

	private bool ZTxcXqFCXcMcFbJzbogdaSAwtHxZ;

	private object NxtZDdoVwNnsGXEcsMrPSFINntt;

	private IndexedDictionary<int, PlatformInputManager> zYVYhVqAYkmVrNJmVgCYTDRQUpg;

	private lyRWmyWrTkkKqYEnnNYgWsNqCeA RZowOGlbUaSZpEuoEPWwGUHCmYf;

	private Action<int, ControllerDataUpdater> JcoiPGandIoCihCSGbQPMEFfAvAL;

	private WindowsStandalonePrimaryInputSource KDwMMuxMDAESaGNRSLcAGSdOVDCe;

	private bool qfxTAZziDwfEMBWJRcxXilSSzSp;

	private PlatformInputManager LMMdhtGnZeQEOByzBHUxskBnUeW;

	private bool JZMDHaICRedMEIRzwjcohKNKjZMm;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

	private Func<int> ngZnFDsAelLLgZWmCeeSqxddlic;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.LIKQoBfcynFjNAdlxkpqEkuDgNzq();
			IntPtr intPtr2 = AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR();
			return intPtr2 != IntPtr.Zero && intPtr == intPtr2;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => RZowOGlbUaSZpEuoEPWwGUHCmYf.deviceCount;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => LMMdhtGnZeQEOByzBHUxskBnUeW;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => LMMdhtGnZeQEOByzBHUxskBnUeW.inputSource;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (LMMdhtGnZeQEOByzBHUxskBnUeW == null)
			{
				return InputSource.None;
			}
			return LMMdhtGnZeQEOByzBHUxskBnUeW.inputSourceType;
		}
	}

	public wRGJqvlkSUqSTLLyCDlEyuxIbzU(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		KDwMMuxMDAESaGNRSLcAGSdOVDCe = configVars.windowsStandalonePrimaryInputSource;
		qfxTAZziDwfEMBWJRcxXilSSzSp = configVars.useXInput;
		muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
		ngZnFDsAelLLgZWmCeeSqxddlic = getNewJoystickId;
		bool flag = false;
		zYVYhVqAYkmVrNJmVgCYTDRQUpg = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				oizETVRXykJREMrljZxCoqipUeW.BVmTKMsAVVqdkfwNjSwlgNFzTsh();
				twgftrmepwYazrihxrRHOffVrij twgftrmepwYazrihxrRHOffVrij2 = (twgftrmepwYazrihxrRHOffVrij)(NxtZDdoVwNnsGXEcsMrPSFINntt = new twgftrmepwYazrihxrRHOffVrij());
				bool flag2 = false;
				if (KDwMMuxMDAESaGNRSLcAGSdOVDCe == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = sXIARuGYCUlTCrgXPtWGiwGFaFCg(configVars, twgftrmepwYazrihxrRHOffVrij2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = IQhAeuBCyJFaRddYZWdEWKtfHPez(configVars, twgftrmepwYazrihxrRHOffVrij2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							KDwMMuxMDAESaGNRSLcAGSdOVDCe = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (KDwMMuxMDAESaGNRSLcAGSdOVDCe == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = IQhAeuBCyJFaRddYZWdEWKtfHPez(configVars, twgftrmepwYazrihxrRHOffVrij2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = sXIARuGYCUlTCrgXPtWGiwGFaFCg(configVars, twgftrmepwYazrihxrRHOffVrij2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							KDwMMuxMDAESaGNRSLcAGSdOVDCe = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (KDwMMuxMDAESaGNRSLcAGSdOVDCe == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = EuqNwAyGBWWbMLKroMQwixzYpDJ(configVars, false);
					if (flag2)
					{
						LKycfUiaUuiMGDmbLBpVYHqQPfqb(configVars, twgftrmepwYazrihxrRHOffVrij2);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				twgftrmepwYazrihxrRHOffVrij2.DeviceConnectedEvent += CnTKZWfhtJJAtxjcyslTcfkrqOH;
				twgftrmepwYazrihxrRHOffVrij2.DeviceDisconnectedEvent += EfsXOmpDhUnNPXNISrmnfnXFdTW;
				for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
				{
					PlatformInputManager platformInputManager = zYVYhVqAYkmVrNJmVgCYTDRQUpg[i];
					platformInputManager.DeviceConnectedEvent += QTYeulEgVdHvtGBJECUdJuFLDGnK;
					platformInputManager.DeviceDisconnectedEvent += haXdrEDFghFNLsYCACOabZokikm;
					platformInputManager.UpdateControllerInfoEvent += hSOLqmXDvqiCkwlMnGuEAOfTKnZb;
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
			EuqNwAyGBWWbMLKroMQwixzYpDJ(configVars, true);
		}
		JcoiPGandIoCihCSGbQPMEFfAvAL = UpdateControllerData;
	}

	private bool sXIARuGYCUlTCrgXPtWGiwGFaFCg(ConfigVars P_0, twgftrmepwYazrihxrRHOffVrij P_1)
	{
		CKORtxtALbxyeRsqoWjMACyCwcV cKORtxtALbxyeRsqoWjMACyCwcV = null;
		gWmCLBokGZCLygUNKXrfUKPdZWyh gWmCLBokGZCLygUNKXrfUKPdZWyh2 = null;
		try
		{
			cKORtxtALbxyeRsqoWjMACyCwcV = new CKORtxtALbxyeRsqoWjMACyCwcV(P_0, useXInput: false, null, null, handleJoysticks: false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			gWmCLBokGZCLygUNKXrfUKPdZWyh2 = (gWmCLBokGZCLygUNKXrfUKPdZWyh)(LMMdhtGnZeQEOByzBHUxskBnUeW = new gWmCLBokGZCLygUNKXrfUKPdZWyh(P_0.updateLoop, qfxTAZziDwfEMBWJRcxXilSSzSp, ((twgftrmepwYazrihxrRHOffVrij)NxtZDdoVwNnsGXEcsMrPSFINntt).windowHandle, muwCboYBpXBddhISLPoaIQYyEVOW, ngZnFDsAelLLgZWmCeeSqxddlic));
			zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(5, cKORtxtALbxyeRsqoWjMACyCwcV);
			zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(1, LMMdhtGnZeQEOByzBHUxskBnUeW);
			P_1.WindowFocusEvent += cKORtxtALbxyeRsqoWjMACyCwcV.ExrHJJtpfvNVWwqCndSnwcdPMan;
			return true;
		}
		catch (Exception)
		{
			gWmCLBokGZCLygUNKXrfUKPdZWyh2?.OnDestroy();
			cKORtxtALbxyeRsqoWjMACyCwcV?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
		}
		return false;
	}

	private bool IQhAeuBCyJFaRddYZWdEWKtfHPez(ConfigVars P_0, twgftrmepwYazrihxrRHOffVrij P_1)
	{
		CKORtxtALbxyeRsqoWjMACyCwcV cKORtxtALbxyeRsqoWjMACyCwcV = null;
		try
		{
			cKORtxtALbxyeRsqoWjMACyCwcV = new CKORtxtALbxyeRsqoWjMACyCwcV(P_0, P_0.useXInput, muwCboYBpXBddhISLPoaIQYyEVOW, ngZnFDsAelLLgZWmCeeSqxddlic, handleJoysticks: true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(5, cKORtxtALbxyeRsqoWjMACyCwcV);
			P_1.WindowFocusEvent += cKORtxtALbxyeRsqoWjMACyCwcV.ExrHJJtpfvNVWwqCndSnwcdPMan;
			LMMdhtGnZeQEOByzBHUxskBnUeW = cKORtxtALbxyeRsqoWjMACyCwcV;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			cKORtxtALbxyeRsqoWjMACyCwcV?.OnDestroy();
		}
		return false;
	}

	private bool LKycfUiaUuiMGDmbLBpVYHqQPfqb(ConfigVars P_0, twgftrmepwYazrihxrRHOffVrij P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		CKORtxtALbxyeRsqoWjMACyCwcV cKORtxtALbxyeRsqoWjMACyCwcV = null;
		try
		{
			cKORtxtALbxyeRsqoWjMACyCwcV = new CKORtxtALbxyeRsqoWjMACyCwcV(P_0, useXInput: false, null, null, handleJoysticks: false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.WindowFocusEvent += cKORtxtALbxyeRsqoWjMACyCwcV.ExrHJJtpfvNVWwqCndSnwcdPMan;
			zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(5, cKORtxtALbxyeRsqoWjMACyCwcV);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			cKORtxtALbxyeRsqoWjMACyCwcV?.OnDestroy();
			cKORtxtALbxyeRsqoWjMACyCwcV = null;
			return false;
		}
	}

	private bool EuqNwAyGBWWbMLKroMQwixzYpDJ(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = LMMdhtGnZeQEOByzBHUxskBnUeW == null;
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
				pxUDKJlTyIXXFVKvtqeQsDeusPf pxUDKJlTyIXXFVKvtqeQsDeusPf2 = new pxUDKJlTyIXXFVKvtqeQsDeusPf();
				pxUDKJlTyIXXFVKvtqeQsDeusPf2.LSBZNFvFIBjrdZJYfgPRzEbigLTH = 0;
				dSElFGVpyqTZVtKoEbCEnZfBwBs value = new dSElFGVpyqTZVtKoEbCEnZfBwBs(flag3, updateLoop, muwCboYBpXBddhISLPoaIQYyEVOW, pxUDKJlTyIXXFVKvtqeQsDeusPf2.gywfYCfpkMLytswWtdEOskcWGadq);
				zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(2, value);
			}
			else
			{
				dSElFGVpyqTZVtKoEbCEnZfBwBs dSElFGVpyqTZVtKoEbCEnZfBwBs2 = new dSElFGVpyqTZVtKoEbCEnZfBwBs(flag3, updateLoop, muwCboYBpXBddhISLPoaIQYyEVOW, ngZnFDsAelLLgZWmCeeSqxddlic);
				if (flag)
				{
					LMMdhtGnZeQEOByzBHUxskBnUeW = dSElFGVpyqTZVtKoEbCEnZfBwBs2;
				}
				zYVYhVqAYkmVrNJmVgCYTDRQUpg.Add(2, dSElFGVpyqTZVtKoEbCEnZfBwBs2);
				if (P_1)
				{
					dSElFGVpyqTZVtKoEbCEnZfBwBs2.DeviceConnectedEvent += QTYeulEgVdHvtGBJECUdJuFLDGnK;
					dSElFGVpyqTZVtKoEbCEnZfBwBs2.DeviceDisconnectedEvent += haXdrEDFghFNLsYCACOabZokikm;
					dSElFGVpyqTZVtKoEbCEnZfBwBs2.UpdateControllerInfoEvent += hSOLqmXDvqiCkwlMnGuEAOfTKnZb;
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
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + KDwMMuxMDAESaGNRSLcAGSdOVDCe.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
				P_0.useXInput = false;
				for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
				{
					if (zYVYhVqAYkmVrNJmVgCYTDRQUpg[i] != null && zYVYhVqAYkmVrNJmVgCYTDRQUpg[i] is hVogZkGpYOPjCtJVInzVFePlclN hVogZkGpYOPjCtJVInzVFePlclN2)
					{
						hVogZkGpYOPjCtJVInzVFePlclN2.useXInput = false;
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
		ZTxcXqFCXcMcFbJzbogdaSAwtHxZ = true;
		RZowOGlbUaSZpEuoEPWwGUHCmYf = new lyRWmyWrTkkKqYEnnNYgWsNqCeA();
		for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
		{
			zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].Initialize();
		}
	}

	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
		{
			zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].Update(currentUpdateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count - 1; num >= 0; num--)
		{
			zYVYhVqAYkmVrNJmVgCYTDRQUpg[num].OnDestroy();
		}
		if (NxtZDdoVwNnsGXEcsMrPSFINntt != null)
		{
			((twgftrmepwYazrihxrRHOffVrij)NxtZDdoVwNnsGXEcsMrPSFINntt).vfuiOJRwWxFrKDItVySXuycYJSq();
			NxtZDdoVwNnsGXEcsMrPSFINntt = null;
		}
		oizETVRXykJREMrljZxCoqipUeW.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return JcoiPGandIoCihCSGbQPMEFfAvAL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		zYVYhVqAYkmVrNJmVgCYTDRQUpg.GetValue((int)data.source).UpdateControllerData(RZowOGlbUaSZpEuoEPWwGUHCmYf.qCbgdmFwubqJWTxyDqoDIPwDbKeJ(controllerId, data.source, lyRWmyWrTkkKqYEnnNYgWsNqCeA.CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb), data);
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
		for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void QTYeulEgVdHvtGBJECUdJuFLDGnK(BridgedController P_0)
	{
		if (P_0 != null)
		{
			RZowOGlbUaSZpEuoEPWwGUHCmYf.AQseuqGpSAGZYovnDOPmjUCBiYJ(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void haXdrEDFghFNLsYCACOabZokikm(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			RZowOGlbUaSZpEuoEPWwGUHCmYf.xuhDPJaZkjYMDrlxHwHUrcDEAvOB(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void CnTKZWfhtJJAtxjcyslTcfkrqOH(EventArgs P_0)
	{
		if (ZTxcXqFCXcMcFbJzbogdaSAwtHxZ)
		{
			for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
			{
				zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].SystemDeviceConnected();
			}
		}
	}

	private void EfsXOmpDhUnNPXNISrmnfnXFdTW(EventArgs P_0)
	{
		if (ZTxcXqFCXcMcFbJzbogdaSAwtHxZ)
		{
			for (int i = 0; i < zYVYhVqAYkmVrNJmVgCYTDRQUpg.Count; i++)
			{
				zYVYhVqAYkmVrNJmVgCYTDRQUpg[i].SystemDeviceDisconnected();
			}
		}
	}

	private void hSOLqmXDvqiCkwlMnGuEAOfTKnZb(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		RZowOGlbUaSZpEuoEPWwGUHCmYf.DUOGkuBaUPzJcBWcTTLKNwFtFwDf(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		lyRWmyWrTkkKqYEnnNYgWsNqCeA.CWwpuIoNrVfHGzxNoTaVcnvEDql cWwpuIoNrVfHGzxNoTaVcnvEDql = lyRWmyWrTkkKqYEnnNYgWsNqCeA.CWwpuIoNrVfHGzxNoTaVcnvEDql.DfsndYxHYVKUdQgDuAfETngfexb;
		int num = RZowOGlbUaSZpEuoEPWwGUHCmYf.HkuBROogyjTXYCIdeWrOxVjcZYh(P_0.sourceJoystick.rewiredId, cWwpuIoNrVfHGzxNoTaVcnvEDql);
		if (num < 0)
		{
			cWwpuIoNrVfHGzxNoTaVcnvEDql = lyRWmyWrTkkKqYEnnNYgWsNqCeA.CWwpuIoNrVfHGzxNoTaVcnvEDql.ibjqBHyFNJOhWJActsfrTOPbIjF;
			num = RZowOGlbUaSZpEuoEPWwGUHCmYf.HkuBROogyjTXYCIdeWrOxVjcZYh(P_0.sourceJoystick.rewiredId, cWwpuIoNrVfHGzxNoTaVcnvEDql);
		}
		if (num >= 0)
		{
			lyRWmyWrTkkKqYEnnNYgWsNqCeA.hChyxezXUugHgAeqmlgEHJxIJyE hChyxezXUugHgAeqmlgEHJxIJyE = RZowOGlbUaSZpEuoEPWwGUHCmYf.FtLirbPmlhaUtUCzePQZBISsSvx(num, cWwpuIoNrVfHGzxNoTaVcnvEDql);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new OEBEbFbMrNNpsFtcGmubYYlnvxav(P_0.sourceJoystick, hChyxezXUugHgAeqmlgEHJxIJyE.XRsRAyNfLNBbCXWkChtiwaoHcJX)));
			}
		}
	}
}
