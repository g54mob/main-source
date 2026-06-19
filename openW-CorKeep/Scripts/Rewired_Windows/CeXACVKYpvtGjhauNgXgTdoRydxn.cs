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

internal class CeXACVKYpvtGjhauNgXgTdoRydxn : PlatformInputManager, INativePlatformHelper
{
	private class ZgNzBGVJUyBMucMlBMcAttYfeuutA
	{
		private class mbjNYRssZxGnTLriBoLTLCIjcHZI
		{
			public int lrDgzgeLkEMlsHRevTsrAHpGWgVCB;

			public int DzyGUAgqcOYQNWwgXarUEnojEBBm;

			public int iZTTeeYIjcvYStfpUtxkgEqUDNlL;

			public InputSource VRnPcQBqRSUWqaIHChbHFJHhrCOW;

			public mbjNYRssZxGnTLriBoLTLCIjcHZI(int P_0, int P_1, int P_2, InputSource P_3)
			{
				lrDgzgeLkEMlsHRevTsrAHpGWgVCB = P_0;
				DzyGUAgqcOYQNWwgXarUEnojEBBm = P_1;
				iZTTeeYIjcvYStfpUtxkgEqUDNlL = P_2;
				VRnPcQBqRSUWqaIHChbHFJHhrCOW = P_3;
			}

			public void cWsnxZahqEVHNcOxLbHiznfTGwvd(int P_0)
			{
				DzyGUAgqcOYQNWwgXarUEnojEBBm = P_0;
			}

			public PQwRqSbOMDWRoyKdjUszPGjivWqN dpUfplfXxtsDedpgBDaPlRKzHajH()
			{
				return new PQwRqSbOMDWRoyKdjUszPGjivWqN(lrDgzgeLkEMlsHRevTsrAHpGWgVCB, DzyGUAgqcOYQNWwgXarUEnojEBBm, VRnPcQBqRSUWqaIHChbHFJHhrCOW);
			}

			public static int OUaatamwrdrIJrFWtCbrCiHcAgiib(mbjNYRssZxGnTLriBoLTLCIjcHZI P_0, mbjNYRssZxGnTLriBoLTLCIjcHZI P_1)
			{
				if (P_0.lrDgzgeLkEMlsHRevTsrAHpGWgVCB < P_1.lrDgzgeLkEMlsHRevTsrAHpGWgVCB)
				{
					return -1;
				}
				if (P_0.lrDgzgeLkEMlsHRevTsrAHpGWgVCB > P_1.lrDgzgeLkEMlsHRevTsrAHpGWgVCB)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct PQwRqSbOMDWRoyKdjUszPGjivWqN
		{
			public int kAGabgEUOxHVTGbAzMbmbktcwesnA;

			public int kAhGkVjPAsmvbThnhPYediAFRBVZ;

			public InputSource lNCvymSFoGbfZlmwZSnbAwTxCjhO;

			public PQwRqSbOMDWRoyKdjUszPGjivWqN(int P_0, int P_1, InputSource P_2)
			{
				kAGabgEUOxHVTGbAzMbmbktcwesnA = P_0;
				kAhGkVjPAsmvbThnhPYediAFRBVZ = P_1;
				lNCvymSFoGbfZlmwZSnbAwTxCjhO = P_2;
			}
		}

		public enum MenNBjmHTkxzuZxlISPMFoJVtvxp
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<mbjNYRssZxGnTLriBoLTLCIjcHZI> QSPXSqgKfVhQApPLfAhQbFQFpPgtA;

		private List<mbjNYRssZxGnTLriBoLTLCIjcHZI> wRzhXgmcrabPymQjzkcYgQHhMQap;

		public int gTwADkfUXmtAdOvIZMqMwXljRxIb => wRzhXgmcrabPymQjzkcYgQHhMQap.Count;

		public ZgNzBGVJUyBMucMlBMcAttYfeuutA()
		{
			wRzhXgmcrabPymQjzkcYgQHhMQap = new List<mbjNYRssZxGnTLriBoLTLCIjcHZI>();
			QSPXSqgKfVhQApPLfAhQbFQFpPgtA = new List<mbjNYRssZxGnTLriBoLTLCIjcHZI>();
		}

		public void SdircXoDljyCcGMvcDNiBKGXDCzI(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = cUecNbCUcxDMjIlYzkXgBqHRpFEIb(sourceJoystick.rewiredId, MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected);
			mbjNYRssZxGnTLriBoLTLCIjcHZI mbjNYRssZxGnTLriBoLTLCIjcHZI2;
			if (num >= 0)
			{
				mbjNYRssZxGnTLriBoLTLCIjcHZI2 = wRzhXgmcrabPymQjzkcYgQHhMQap[num];
				mbjNYRssZxGnTLriBoLTLCIjcHZI2.cWsnxZahqEVHNcOxLbHiznfTGwvd(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new YFkatAsPeesVwUTmoJWiXNarVUsf(sourceJoystick, mbjNYRssZxGnTLriBoLTLCIjcHZI2.lrDgzgeLkEMlsHRevTsrAHpGWgVCB);
				return;
			}
			num = cUecNbCUcxDMjIlYzkXgBqHRpFEIb(sourceJoystick.rewiredId, MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected);
			if (num >= 0)
			{
				mbjNYRssZxGnTLriBoLTLCIjcHZI2 = QSPXSqgKfVhQApPLfAhQbFQFpPgtA[num];
				QSPXSqgKfVhQApPLfAhQbFQFpPgtA.RemoveAt(num);
				int lrDgzgeLkEMlsHRevTsrAHpGWgVCB = cNRPgfDgaGdcnoaAAwoNpuccKWOP(mbjNYRssZxGnTLriBoLTLCIjcHZI2.lrDgzgeLkEMlsHRevTsrAHpGWgVCB);
				mbjNYRssZxGnTLriBoLTLCIjcHZI2.lrDgzgeLkEMlsHRevTsrAHpGWgVCB = lrDgzgeLkEMlsHRevTsrAHpGWgVCB;
			}
			else
			{
				mbjNYRssZxGnTLriBoLTLCIjcHZI2 = new mbjNYRssZxGnTLriBoLTLCIjcHZI(OyJuIlQqyqqeDwfLQaFturyIVSLn(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new YFkatAsPeesVwUTmoJWiXNarVUsf(sourceJoystick, mbjNYRssZxGnTLriBoLTLCIjcHZI2.lrDgzgeLkEMlsHRevTsrAHpGWgVCB);
			wRzhXgmcrabPymQjzkcYgQHhMQap.Add(mbjNYRssZxGnTLriBoLTLCIjcHZI2);
			wRzhXgmcrabPymQjzkcYgQHhMQap.Sort(mbjNYRssZxGnTLriBoLTLCIjcHZI.OUaatamwrdrIJrFWtCbrCiHcAgiib);
		}

		public void bDsEzCbIfuGcBbKACbHoDLwemrKM(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0.rewiredId, MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				mbjNYRssZxGnTLriBoLTLCIjcHZI item = wRzhXgmcrabPymQjzkcYgQHhMQap[num];
				wRzhXgmcrabPymQjzkcYgQHhMQap.RemoveAt(num);
				QSPXSqgKfVhQApPLfAhQbFQFpPgtA.Add(item);
			}
		}

		public void ZSsceAkoISXvcgLkDbjOgoXcxQwI(int P_0, int P_1)
		{
			int num = cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0, MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected);
			if (num >= 0)
			{
				wRzhXgmcrabPymQjzkcYgQHhMQap[num].cWsnxZahqEVHNcOxLbHiznfTGwvd(P_1);
				return;
			}
			num = cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0, MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected);
			if (num >= 0)
			{
				QSPXSqgKfVhQApPLfAhQbFQFpPgtA[num].cWsnxZahqEVHNcOxLbHiznfTGwvd(P_1);
			}
		}

		public bool zpFCKclbKPwvdRwdVLAibhFYiWvS(int P_0, MenNBjmHTkxzuZxlISPMFoJVtvxp P_1)
		{
			return cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0, P_1) >= 0;
		}

		public int cUecNbCUcxDMjIlYzkXgBqHRpFEIb(int P_0, MenNBjmHTkxzuZxlISPMFoJVtvxp P_1)
		{
			switch (P_1)
			{
			case MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected:
			{
				int count2 = wRzhXgmcrabPymQjzkcYgQHhMQap.Count;
				for (int j = 0; j < count2; j++)
				{
					if (wRzhXgmcrabPymQjzkcYgQHhMQap[j].iZTTeeYIjcvYStfpUtxkgEqUDNlL == P_0)
					{
						return j;
					}
				}
				break;
			}
			case MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected:
			{
				int count = QSPXSqgKfVhQApPLfAhQbFQFpPgtA.Count;
				for (int i = 0; i < count; i++)
				{
					if (QSPXSqgKfVhQApPLfAhQbFQFpPgtA[i].iZTTeeYIjcvYStfpUtxkgEqUDNlL == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int MfMcATmUhTjFyDHtakSSSuIiQQOT(int P_0, InputSource P_1, MenNBjmHTkxzuZxlISPMFoJVtvxp P_2)
		{
			switch (P_2)
			{
			case MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected:
			{
				int count2 = wRzhXgmcrabPymQjzkcYgQHhMQap.Count;
				for (int j = 0; j < count2; j++)
				{
					if (wRzhXgmcrabPymQjzkcYgQHhMQap[j].lrDgzgeLkEMlsHRevTsrAHpGWgVCB == P_0 && wRzhXgmcrabPymQjzkcYgQHhMQap[j].VRnPcQBqRSUWqaIHChbHFJHhrCOW == P_1)
					{
						return j;
					}
				}
				break;
			}
			case MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected:
			{
				int count = QSPXSqgKfVhQApPLfAhQbFQFpPgtA.Count;
				for (int i = 0; i < count; i++)
				{
					if (QSPXSqgKfVhQApPLfAhQbFQFpPgtA[i].lrDgzgeLkEMlsHRevTsrAHpGWgVCB == P_0 && QSPXSqgKfVhQApPLfAhQbFQFpPgtA[i].VRnPcQBqRSUWqaIHChbHFJHhrCOW == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public PQwRqSbOMDWRoyKdjUszPGjivWqN zivoggGqaXCRJOTQwqroVnhSmbzH(int P_0, MenNBjmHTkxzuZxlISPMFoJVtvxp P_1)
		{
			if (P_1 == MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected)
			{
				if (P_0 < 0 || P_0 >= wRzhXgmcrabPymQjzkcYgQHhMQap.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return wRzhXgmcrabPymQjzkcYgQHhMQap[P_0].dpUfplfXxtsDedpgBDaPlRKzHajH();
			}
			if (P_0 < 0 || P_0 >= QSPXSqgKfVhQApPLfAhQbFQFpPgtA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return QSPXSqgKfVhQApPLfAhQbFQFpPgtA[P_0].dpUfplfXxtsDedpgBDaPlRKzHajH();
		}

		public int cmopvohCOVtGlQsumieKncnFvbXb(int P_0, InputSource P_1, MenNBjmHTkxzuZxlISPMFoJVtvxp P_2)
		{
			int num = MfMcATmUhTjFyDHtakSSSuIiQQOT(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected => wRzhXgmcrabPymQjzkcYgQHhMQap[num].DzyGUAgqcOYQNWwgXarUEnojEBBm, 
				MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected => QSPXSqgKfVhQApPLfAhQbFQFpPgtA[num].DzyGUAgqcOYQNWwgXarUEnojEBBm, 
				_ => -1, 
			};
		}

		private int cNRPgfDgaGdcnoaAAwoNpuccKWOP(int P_0)
		{
			int count = wRzhXgmcrabPymQjzkcYgQHhMQap.Count;
			for (int i = 0; i < count; i++)
			{
				if (wRzhXgmcrabPymQjzkcYgQHhMQap[i].lrDgzgeLkEMlsHRevTsrAHpGWgVCB == P_0)
				{
					return OyJuIlQqyqqeDwfLQaFturyIVSLn();
				}
			}
			return P_0;
		}

		private int OyJuIlQqyqqeDwfLQaFturyIVSLn()
		{
			int count = wRzhXgmcrabPymQjzkcYgQHhMQap.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (wRzhXgmcrabPymQjzkcYgQHhMQap[i].lrDgzgeLkEMlsHRevTsrAHpGWgVCB == num)
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

	private class YFkatAsPeesVwUTmoJWiXNarVUsf : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic HvQycKswWxkSPOToGTnGiGdnctJW;

		private int ZRSYFRYARzGanBiLCoSUgyIpnlzyA;

		int IInputManagerJoystickPublic.rewiredId => HvQycKswWxkSPOToGTnGiGdnctJW.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => ZRSYFRYARzGanBiLCoSUgyIpnlzyA;

		string IInputManagerJoystickPublic.name => HvQycKswWxkSPOToGTnGiGdnctJW.name;

		long? IInputManagerJoystickPublic.systemId => HvQycKswWxkSPOToGTnGiGdnctJW.systemId;

		int IInputManagerJoystickPublic.unityId => HvQycKswWxkSPOToGTnGiGdnctJW.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => HvQycKswWxkSPOToGTnGiGdnctJW.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => HvQycKswWxkSPOToGTnGiGdnctJW.extension;

		public YFkatAsPeesVwUTmoJWiXNarVUsf(IInputManagerJoystickPublic P_0, int P_1)
		{
			HvQycKswWxkSPOToGTnGiGdnctJW = P_0;
			ZRSYFRYARzGanBiLCoSUgyIpnlzyA = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			HvQycKswWxkSPOToGTnGiGdnctJW.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			HvQycKswWxkSPOToGTnGiGdnctJW.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (HvQycKswWxkSPOToGTnGiGdnctJW is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class rMIivguvpdqganHEPPXMLPYiIAAg
	{
		public static readonly rMIivguvpdqganHEPPXMLPYiIAAg _003C_003E9 = new rMIivguvpdqganHEPPXMLPYiIAAg();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool DwvLZigkISByDgbCVcAhaMvlQILq(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class EIAEnCHNZaCFCEyRaJTVRxHaNoPU
	{
		public int zqDmNzVmlxwPMjERLcoZcMVKBWlqA;

		internal int OUsotGWpBiGDQyRAbbFKcyIuPElnA()
		{
			return zqDmNzVmlxwPMjERLcoZcMVKBWlqA++;
		}
	}

	private const bool BrQPRjupLodQQBSbnwTxHOyOPjGAb = false;

	private const bool LoQNBmVbGeUPEsaMEKyqviVegahV = false;

	private const bool efrJIzgnxubfjxjmogpwfeWVBZRFA = false;

	private const bool gUUZbPTQVjeILnSmEHInqzRNiuBm = false;

	private const bool GKXbOICExmXnHjgbCSbOszAYPLSNA = false;

	private const bool OFjgLZrHFRiLgkipLSSrRcuicTFtA = false;

	private bool QCxfZnpHuwoMhoTwNbGlafbnFrliA;

	private AcOCgfLOsmxecAEEOlEkPRhCGlDW sZsNrJxggrGgOqdWrsbuixRxOkAI;

	private IndexedDictionary<int, PlatformInputManager> FCElDitJLdIViRhBfBJCQcjOTGzT;

	private ZgNzBGVJUyBMucMlBMcAttYfeuutA EXwQHKiFGroJIAvzlwswiOhMdIgi;

	private Action<int, ControllerDataUpdater> KRGzbnYesDGCwvrqtnBECCHqINEL;

	private WindowsStandalonePrimaryInputSource SamxvLerwqqUtEUhvbihtpZVQxLu;

	private PlatformInputManager lbGviYVCmannJhpBJdXKRWaNmYqM;

	private bool QWGAPsmhBNitmUHvOqxDpcbqGRWb;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> srOTyBFeqMgRNeutIsTfWDypuIWc;

	private Func<int> ZMJEXsGUQmmtLKwTdkZETCEuRllPA;

	private Func<PidVid, bool> VslgNmJUZhimSguKCZDnqBfKPFvgb;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = wfRybNWHWOpoyMQsxzdwHdiNgarj.qBcPlmeDfgHLMerisBIrLbCpsbZk();
			IntPtr intPtr2 = wfRybNWHWOpoyMQsxzdwHdiNgarj.DcEMACVJnwLAmZDRlamEsMKnjWNHA();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => EXwQHKiFGroJIAvzlwswiOhMdIgi.gTwADkfUXmtAdOvIZMqMwXljRxIb;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => lbGviYVCmannJhpBJdXKRWaNmYqM;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => lbGviYVCmannJhpBJdXKRWaNmYqM.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (lbGviYVCmannJhpBJdXKRWaNmYqM == null)
			{
				return InputSource.None;
			}
			return lbGviYVCmannJhpBJdXKRWaNmYqM.inputSourceType;
		}
	}

	public CeXACVKYpvtGjhauNgXgTdoRydxn(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			SamxvLerwqqUtEUhvbihtpZVQxLu = P_0.windowsStandalonePrimaryInputSource;
			VslgNmJUZhimSguKCZDnqBfKPFvgb = rMIivguvpdqganHEPPXMLPYiIAAg._003C_003E9.DwvLZigkISByDgbCVcAhaMvlQILq;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.DirectInput || SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.RawInput);
			BfkroJQJTBQveeRAQgPngoAAkNXDA bfkroJQJTBQveeRAQgPngoAAkNXDA = BfkroJQJTBQveeRAQgPngoAAkNXDA.None;
			if (flag2)
			{
				bfkroJQJTBQveeRAQgPngoAAkNXDA = (P_0.GetPlatformVar_useWindowsGamingInput() ? BfkroJQJTBQveeRAQgPngoAAkNXDA.WindowsGamingInput : (P_0.useXInput ? BfkroJQJTBQveeRAQgPngoAAkNXDA.XInput : BfkroJQJTBQveeRAQgPngoAAkNXDA.None));
			}
			bool flag3 = bfkroJQJTBQveeRAQgPngoAAkNXDA == BfkroJQJTBQveeRAQgPngoAAkNXDA.WindowsGamingInput || bfkroJQJTBQveeRAQgPngoAAkNXDA == BfkroJQJTBQveeRAQgPngoAAkNXDA.XInput || SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.XInput || SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			srOTyBFeqMgRNeutIsTfWDypuIWc = P_1;
			ZMJEXsGUQmmtLKwTdkZETCEuRllPA = P_2;
			bool flag4 = false;
			FCElDitJLdIViRhBfBJCQcjOTGzT = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					rGfCWQcoVBNNMLBCPGciUTleuQNNA.iehvoyhuSqWtalEEWLqXMJtUrvdj(flag3);
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
				switch (bfkroJQJTBQveeRAQgPngoAAkNXDA)
				{
				case BfkroJQJTBQveeRAQgPngoAAkNXDA.XInput:
					if (IsqFqZCuNSSZclCTEGXaJkcxFMspA(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case BfkroJQJTBQveeRAQgPngoAAkNXDA.WindowsGamingInput:
					if (XUyPaxfeXtZWivtEZqdkBMGjrtMr(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (IsqFqZCuNSSZclCTEGXaJkcxFMspA(P_0, false, out platformInputManager))
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
				if (!flag4 && !IsqFqZCuNSSZclCTEGXaJkcxFMspA(P_0, true, out lbGviYVCmannJhpBJdXKRWaNmYqM))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				sZsNrJxggrGgOqdWrsbuixRxOkAI = new AcOCgfLOsmxecAEEOlEkPRhCGlDW();
				bool flag5 = false;
				if (SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = HWpfEmeaOhhNqHHINsFdHJEegAWM(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, platformInputManager as tfBBbpYawsTqFdIUEKOlukvpcHoaA);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = uhccazVyxZVXpkPLIvEDLIJwKCKc(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, platformInputManager as tfBBbpYawsTqFdIUEKOlukvpcHoaA);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							SamxvLerwqqUtEUhvbihtpZVQxLu = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = uhccazVyxZVXpkPLIvEDLIJwKCKc(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, platformInputManager as tfBBbpYawsTqFdIUEKOlukvpcHoaA);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = HWpfEmeaOhhNqHHINsFdHJEegAWM(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, platformInputManager as tfBBbpYawsTqFdIUEKOlukvpcHoaA);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							SamxvLerwqqUtEUhvbihtpZVQxLu = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = IsqFqZCuNSSZclCTEGXaJkcxFMspA(P_0, true, out lbGviYVCmannJhpBJdXKRWaNmYqM);
					flag4 = flag5;
					if (flag5)
					{
						VCdlBeZAtpcpkVnrncWIbopwKthbb(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = uhccazVyxZVXpkPLIvEDLIJwKCKc(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							SamxvLerwqqUtEUhvbihtpZVQxLu = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (SamxvLerwqqUtEUhvbihtpZVQxLu == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = XUyPaxfeXtZWivtEZqdkBMGjrtMr(P_0, true, out lbGviYVCmannJhpBJdXKRWaNmYqM);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = IsqFqZCuNSSZclCTEGXaJkcxFMspA(P_0, true, out lbGviYVCmannJhpBJdXKRWaNmYqM);
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
							flag5 = uhccazVyxZVXpkPLIvEDLIJwKCKc(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								SamxvLerwqqUtEUhvbihtpZVQxLu = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						VCdlBeZAtpcpkVnrncWIbopwKthbb(P_0, sZsNrJxggrGgOqdWrsbuixRxOkAI);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				sZsNrJxggrGgOqdWrsbuixRxOkAI.TSiiUFtXmEUjAIAepmUWxbtXnvyy += ykqekjGpMlpFmXmVtiFNJLGmMnnE;
				sZsNrJxggrGgOqdWrsbuixRxOkAI.PZlJRcpBqrqjoVEBtBhqWefHtsEf += YBClyATRcLWvZqMwLGVLiLcSMDxy;
			}
			if (lbGviYVCmannJhpBJdXKRWaNmYqM == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			KRGzbnYesDGCwvrqtnBECCHqINEL = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool HWpfEmeaOhhNqHHINsFdHJEegAWM(ConfigVars P_0, AcOCgfLOsmxecAEEOlEkPRhCGlDW P_1, tfBBbpYawsTqFdIUEKOlukvpcHoaA P_2)
	{
		OoKXAmdYbXiAWwiETfBFmpRbcOsd ooKXAmdYbXiAWwiETfBFmpRbcOsd = null;
		CyxJdhjfOICWqWzXlokNuHzoKvmJ cyxJdhjfOICWqWzXlokNuHzoKvmJ = null;
		try
		{
			ooKXAmdYbXiAWwiETfBFmpRbcOsd = new OoKXAmdYbXiAWwiETfBFmpRbcOsd(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			cyxJdhjfOICWqWzXlokNuHzoKvmJ = (CyxJdhjfOICWqWzXlokNuHzoKvmJ)(lbGviYVCmannJhpBJdXKRWaNmYqM = new CyxJdhjfOICWqWzXlokNuHzoKvmJ(P_0.updateLoop, P_2, P_1.ZCFhCBpgiYAghewzIgpkIWOKLVPsA, srOTyBFeqMgRNeutIsTfWDypuIWc, ZMJEXsGUQmmtLKwTdkZETCEuRllPA));
			FCElDitJLdIViRhBfBJCQcjOTGzT.Add(5, ooKXAmdYbXiAWwiETfBFmpRbcOsd);
			FCElDitJLdIViRhBfBJCQcjOTGzT.Add(1, lbGviYVCmannJhpBJdXKRWaNmYqM);
			P_1.gpucTjJMiWFlRnsQVadKIBmDaxOv += ooKXAmdYbXiAWwiETfBFmpRbcOsd.jDZODRHIArZpwUlInIsbEsNFzivB;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
			cyxJdhjfOICWqWzXlokNuHzoKvmJ.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
			cyxJdhjfOICWqWzXlokNuHzoKvmJ.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
			cyxJdhjfOICWqWzXlokNuHzoKvmJ.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
			return true;
		}
		catch (Exception)
		{
			cyxJdhjfOICWqWzXlokNuHzoKvmJ?.OnDestroy();
			ooKXAmdYbXiAWwiETfBFmpRbcOsd?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool uhccazVyxZVXpkPLIvEDLIJwKCKc(ConfigVars P_0, AcOCgfLOsmxecAEEOlEkPRhCGlDW P_1, tfBBbpYawsTqFdIUEKOlukvpcHoaA P_2)
	{
		OoKXAmdYbXiAWwiETfBFmpRbcOsd ooKXAmdYbXiAWwiETfBFmpRbcOsd = null;
		try
		{
			ooKXAmdYbXiAWwiETfBFmpRbcOsd = new OoKXAmdYbXiAWwiETfBFmpRbcOsd(P_0, P_2, srOTyBFeqMgRNeutIsTfWDypuIWc, ZMJEXsGUQmmtLKwTdkZETCEuRllPA, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			FCElDitJLdIViRhBfBJCQcjOTGzT.Add(5, ooKXAmdYbXiAWwiETfBFmpRbcOsd);
			P_1.gpucTjJMiWFlRnsQVadKIBmDaxOv += ooKXAmdYbXiAWwiETfBFmpRbcOsd.jDZODRHIArZpwUlInIsbEsNFzivB;
			lbGviYVCmannJhpBJdXKRWaNmYqM = ooKXAmdYbXiAWwiETfBFmpRbcOsd;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			ooKXAmdYbXiAWwiETfBFmpRbcOsd?.OnDestroy();
		}
		return false;
	}

	private bool VCdlBeZAtpcpkVnrncWIbopwKthbb(ConfigVars P_0, AcOCgfLOsmxecAEEOlEkPRhCGlDW P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		OoKXAmdYbXiAWwiETfBFmpRbcOsd ooKXAmdYbXiAWwiETfBFmpRbcOsd = null;
		try
		{
			ooKXAmdYbXiAWwiETfBFmpRbcOsd = new OoKXAmdYbXiAWwiETfBFmpRbcOsd(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.gpucTjJMiWFlRnsQVadKIBmDaxOv += ooKXAmdYbXiAWwiETfBFmpRbcOsd.jDZODRHIArZpwUlInIsbEsNFzivB;
			FCElDitJLdIViRhBfBJCQcjOTGzT.Add(5, ooKXAmdYbXiAWwiETfBFmpRbcOsd);
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
			ooKXAmdYbXiAWwiETfBFmpRbcOsd.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			ooKXAmdYbXiAWwiETfBFmpRbcOsd?.OnDestroy();
			ooKXAmdYbXiAWwiETfBFmpRbcOsd = null;
			return false;
		}
	}

	private bool IsqFqZCuNSSZclCTEGXaJkcxFMspA(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				EIAEnCHNZaCFCEyRaJTVRxHaNoPU eIAEnCHNZaCFCEyRaJTVRxHaNoPU = new EIAEnCHNZaCFCEyRaJTVRxHaNoPU();
				eIAEnCHNZaCFCEyRaJTVRxHaNoPU.zqDmNzVmlxwPMjERLcoZcMVKBWlqA = 0;
				P_2 = new dthckWzdCvyytSjahUhAscVvCaQb(flag, updateLoop, srOTyBFeqMgRNeutIsTfWDypuIWc, eIAEnCHNZaCFCEyRaJTVRxHaNoPU.OUsotGWpBiGDQyRAbbFKcyIuPElnA, VslgNmJUZhimSguKCZDnqBfKPFvgb);
				FCElDitJLdIViRhBfBJCQcjOTGzT.Add(2, P_2);
			}
			else
			{
				P_2 = new dthckWzdCvyytSjahUhAscVvCaQb(flag, updateLoop, srOTyBFeqMgRNeutIsTfWDypuIWc, ZMJEXsGUQmmtLKwTdkZETCEuRllPA, VslgNmJUZhimSguKCZDnqBfKPFvgb);
				FCElDitJLdIViRhBfBJCQcjOTGzT.Add(2, P_2);
				P_2.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
				P_2.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
				P_2.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
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
				for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
				{
					if (FCElDitJLdIViRhBfBJCQcjOTGzT[i] != null && FCElDitJLdIViRhBfBJCQcjOTGzT[i] is pSdznuaGwmothEGkyHtMJwPUSUzT { wbjsmIpoJYIDLciADgGvDfNBzFtGA: not null } pSdznuaGwmothEGkyHtMJwPUSUzT2 && pSdznuaGwmothEGkyHtMJwPUSUzT2.wbjsmIpoJYIDLciADgGvDfNBzFtGA.NqnkERvjFsZuAlUsGtIBCeQgEMYt == BfkroJQJTBQveeRAQgPngoAAkNXDA.XInput)
					{
						pSdznuaGwmothEGkyHtMJwPUSUzT2.wbjsmIpoJYIDLciADgGvDfNBzFtGA = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + SamxvLerwqqUtEUhvbihtpZVQxLu.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool XUyPaxfeXtZWivtEZqdkBMGjrtMr(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new vWtFSuaTyJspWWUhIfofaGARYONiA(P_0, srOTyBFeqMgRNeutIsTfWDypuIWc, ZMJEXsGUQmmtLKwTdkZETCEuRllPA, VslgNmJUZhimSguKCZDnqBfKPFvgb);
			if (P_1)
			{
				lbGviYVCmannJhpBJdXKRWaNmYqM = P_2;
			}
			FCElDitJLdIViRhBfBJCQcjOTGzT.Add(30, P_2);
			P_2.DeviceConnectedEvent += zTyLsPpxrMVutJWLcrAukkeyirEh;
			P_2.DeviceDisconnectedEvent += fgufMDNwoYdPGjJnziOhngBnPhzCA;
			P_2.UpdateControllerInfoEvent += SVcCztbjZZTIgwqisVICybBJvPCX;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
				{
					if (FCElDitJLdIViRhBfBJCQcjOTGzT[i] != null && FCElDitJLdIViRhBfBJCQcjOTGzT[i] is pSdznuaGwmothEGkyHtMJwPUSUzT { wbjsmIpoJYIDLciADgGvDfNBzFtGA: not null } pSdznuaGwmothEGkyHtMJwPUSUzT2 && pSdznuaGwmothEGkyHtMJwPUSUzT2.wbjsmIpoJYIDLciADgGvDfNBzFtGA.NqnkERvjFsZuAlUsGtIBCeQgEMYt == BfkroJQJTBQveeRAQgPngoAAkNXDA.WindowsGamingInput)
					{
						pSdznuaGwmothEGkyHtMJwPUSUzT2.wbjsmIpoJYIDLciADgGvDfNBzFtGA = null;
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
		QCxfZnpHuwoMhoTwNbGlafbnFrliA = true;
		EXwQHKiFGroJIAvzlwswiOhMdIgi = new ZgNzBGVJUyBMucMlBMcAttYfeuutA();
		for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
		{
			FCElDitJLdIViRhBfBJCQcjOTGzT[i].Initialize();
		}
	}

	public virtual void lMfJKmHjnLKVTPXkOsHXokoekQEn(UpdateLoopType P_0)
	{
		for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
		{
			FCElDitJLdIViRhBfBJCQcjOTGzT[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = FCElDitJLdIViRhBfBJCQcjOTGzT.Count - 1; num >= 0; num--)
		{
			FCElDitJLdIViRhBfBJCQcjOTGzT[num].OnDestroy();
		}
		FCElDitJLdIViRhBfBJCQcjOTGzT.Clear();
		if (sZsNrJxggrGgOqdWrsbuixRxOkAI != null)
		{
			sZsNrJxggrGgOqdWrsbuixRxOkAI.LuPvDdHHKIYmPLvAAuigcflQCIub();
			sZsNrJxggrGgOqdWrsbuixRxOkAI = null;
		}
		rGfCWQcoVBNNMLBCPGciUTleuQNNA.UwMNTwqqzexhdhiVULxqLvpfopR();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return KRGzbnYesDGCwvrqtnBECCHqINEL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		FCElDitJLdIViRhBfBJCQcjOTGzT.GetValue((int)data.source).UpdateControllerData(EXwQHKiFGroJIAvzlwswiOhMdIgi.cmopvohCOVtGlQsumieKncnFvbXb(controllerId, data.source, ZgNzBGVJUyBMucMlBMcAttYfeuutA.MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected), data);
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
		for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = FCElDitJLdIViRhBfBJCQcjOTGzT[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = FCElDitJLdIViRhBfBJCQcjOTGzT[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void zTyLsPpxrMVutJWLcrAukkeyirEh(BridgedController P_0)
	{
		if (P_0 != null)
		{
			EXwQHKiFGroJIAvzlwswiOhMdIgi.SdircXoDljyCcGMvcDNiBKGXDCzI(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void fgufMDNwoYdPGjJnziOhngBnPhzCA(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			EXwQHKiFGroJIAvzlwswiOhMdIgi.bDsEzCbIfuGcBbKACbHoDLwemrKM(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void ykqekjGpMlpFmXmVtiFNJLGmMnnE(EventArgs P_0)
	{
		if (QCxfZnpHuwoMhoTwNbGlafbnFrliA)
		{
			for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
			{
				FCElDitJLdIViRhBfBJCQcjOTGzT[i].SystemDeviceConnected();
			}
		}
	}

	private void YBClyATRcLWvZqMwLGVLiLcSMDxy(EventArgs P_0)
	{
		if (QCxfZnpHuwoMhoTwNbGlafbnFrliA)
		{
			for (int i = 0; i < FCElDitJLdIViRhBfBJCQcjOTGzT.Count; i++)
			{
				FCElDitJLdIViRhBfBJCQcjOTGzT[i].SystemDeviceDisconnected();
			}
		}
	}

	private void SVcCztbjZZTIgwqisVICybBJvPCX(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		EXwQHKiFGroJIAvzlwswiOhMdIgi.ZSsceAkoISXvcgLkDbjOgoXcxQwI(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		ZgNzBGVJUyBMucMlBMcAttYfeuutA.MenNBjmHTkxzuZxlISPMFoJVtvxp menNBjmHTkxzuZxlISPMFoJVtvxp = ZgNzBGVJUyBMucMlBMcAttYfeuutA.MenNBjmHTkxzuZxlISPMFoJVtvxp.Connected;
		int num = EXwQHKiFGroJIAvzlwswiOhMdIgi.cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0.sourceJoystick.rewiredId, menNBjmHTkxzuZxlISPMFoJVtvxp);
		if (num < 0)
		{
			menNBjmHTkxzuZxlISPMFoJVtvxp = ZgNzBGVJUyBMucMlBMcAttYfeuutA.MenNBjmHTkxzuZxlISPMFoJVtvxp.Disconnected;
			num = EXwQHKiFGroJIAvzlwswiOhMdIgi.cUecNbCUcxDMjIlYzkXgBqHRpFEIb(P_0.sourceJoystick.rewiredId, menNBjmHTkxzuZxlISPMFoJVtvxp);
		}
		if (num >= 0)
		{
			ZgNzBGVJUyBMucMlBMcAttYfeuutA.PQwRqSbOMDWRoyKdjUszPGjivWqN pQwRqSbOMDWRoyKdjUszPGjivWqN = EXwQHKiFGroJIAvzlwswiOhMdIgi.zivoggGqaXCRJOTQwqroVnhSmbzH(num, menNBjmHTkxzuZxlISPMFoJVtvxp);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new YFkatAsPeesVwUTmoJWiXNarVUsf(P_0.sourceJoystick, pQwRqSbOMDWRoyKdjUszPGjivWqN.kAGabgEUOxHVTGbAzMbmbktcwesnA)));
			}
		}
	}
}
