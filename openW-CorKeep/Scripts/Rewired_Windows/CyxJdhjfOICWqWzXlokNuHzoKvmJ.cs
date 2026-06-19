using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class CyxJdhjfOICWqWzXlokNuHzoKvmJ : PlatformInputManager, pSdznuaGwmothEGkyHtMJwPUSUzT
{
	private class GdZLnXxkOIHlKtGBscttffEFwmuN : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int LusMdEiDqdQTbCyhdabCWVzDFyXo;

		private int oDyNvbEZQVEsiZkITUqKOAqlEhgP;

		public Guid QCgDlmObzkqFYIBkCQXuPsXAmbtk;

		public string tGDvniuTJlIejPUqmFlvZJqcfanC;

		public readonly miYcigybCPTrspuzuSiEafduhOCF dlebRgYnNGqgfxiKwiIgcssIjIos;

		public oAfWbvFtzBgLaRIiknILWPaYvJGR kcUDoGGvTTFQjqprocofCvMCThrxB;

		public xCjHMUlKilLbcWgIcpQhdLGbHDVD cSavbmZXIlQoZHmhZdfxPxWWHDyX;

		public string lRSuCVqBFiwoLENPMKoDoRlJImPV;

		public string ItAxoFoPRBouslYknrpHyLycCekt;

		public int fMKicojkVfzslrdIfOWAGBzVnuLu;

		public Guid FGsKIGidIcXjhgOEkAILRQlLggAJA;

		public Guid jjNvGhLgVUdZtpAIwEHsdtIgDaOV;

		public Guid XSFoSrQpBibIEVzUoZjAOKiFEFuj;

		public int pCOoHkGiSIHiSbyVcoxRfoAIeuTv;

		public bool ACPFfUcDKNakIhAkCMchvCBEiyiYb;

		public string nxPkdjTEaYZiiBvqOirqdkCMTUKd;

		public string jbwnbOsIejfhAmLhlzPPbAkWUQKl;

		public int nPiyjiiLZOAQyMtoKzHdHuuDWJWb;

		public int CZfargRSUjtJFNXVXeMuMbYWEvtT;

		public int JiDYAISMELSdeAeNTOpuFUNqNoeA;

		public int XgOfIkiRHnILohqIHAYoSyoaJzGm;

		public int GbjktuKNCSrBbfYrJsiehchCrjiu;

		public bool fkTCPIsHqSotwhwqqxJjzcdbvPaE;

		public Controller.Extension ZkjAiMEJtsmRQfeeNfvntanXhRvD;

		private float[] clzVDdnQeJtPTEjsqyOnxxnjwgWF;

		private bool[] BBGDxlFHAEhGSUylCUELYJeKbTkq;

		private HardwareJoystickMap_InputManager lLCNnOeDbTyjEfJmIYZNhgQuwLGU;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> oNvfXgHTSzWYvqRLhMnfTNcZKGTMA;

		private bool IRNtfBVvjIJinyEzklEhELbHRxCV;

		private bool cqXHkAlKwTFmiBwAbNWFxpEGFNxHA;

		private bool mqrfeYgULFvxoMNGcRuwKWRaomqCA;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return LusMdEiDqdQTbCyhdabCWVzDFyXo;
			}
			set
			{
				LusMdEiDqdQTbCyhdabCWVzDFyXo = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return oDyNvbEZQVEsiZkITUqKOAqlEhgP;
			}
			set
			{
				oDyNvbEZQVEsiZkITUqKOAqlEhgP = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (tGDvniuTJlIejPUqmFlvZJqcfanC != "Unknown Controller")
				{
					return tGDvniuTJlIejPUqmFlvZJqcfanC;
				}
				if (ACPFfUcDKNakIhAkCMchvCBEiyiYb && !string.IsNullOrEmpty(nxPkdjTEaYZiiBvqOirqdkCMTUKd))
				{
					return nxPkdjTEaYZiiBvqOirqdkCMTUKd;
				}
				return ItAxoFoPRBouslYknrpHyLycCekt;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (oDyNvbEZQVEsiZkITUqKOAqlEhgP < 0)
				{
					return null;
				}
				return oDyNvbEZQVEsiZkITUqKOAqlEhgP;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => ZkjAiMEJtsmRQfeeNfvntanXhRvD;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => FGsKIGidIcXjhgOEkAILRQlLggAJA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public GdZLnXxkOIHlKtGBscttffEFwmuN(miYcigybCPTrspuzuSiEafduhOCF P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			dlebRgYnNGqgfxiKwiIgcssIjIos = P_0;
			oNvfXgHTSzWYvqRLhMnfTNcZKGTMA = P_1;
			oDyNvbEZQVEsiZkITUqKOAqlEhgP = -1;
			LusMdEiDqdQTbCyhdabCWVzDFyXo = -1;
		}

		public void rLWwQxexfxoyfnZMYixBxaGYQjDh()
		{
			string itAxoFoPRBouslYknrpHyLycCekt = ItAxoFoPRBouslYknrpHyLycCekt;
			Guid guid = jjNvGhLgVUdZtpAIwEHsdtIgDaOV;
			XSFoSrQpBibIEVzUoZjAOKiFEFuj = MiscTools.CreateGuidHashSHA1(itAxoFoPRBouslYknrpHyLycCekt + guid.ToString());
			nPiyjiiLZOAQyMtoKzHdHuuDWJWb = JiDYAISMELSdeAeNTOpuFUNqNoeA;
			CZfargRSUjtJFNXVXeMuMbYWEvtT = XgOfIkiRHnILohqIHAYoSyoaJzGm + GbjktuKNCSrBbfYrJsiehchCrjiu * 8;
			YmDTkDaQMSaNQiLHStgHZBoMzlUP();
			QCgDlmObzkqFYIBkCQXuPsXAmbtk = lLCNnOeDbTyjEfJmIYZNhgQuwLGU.hardwareMapIdentifier.guid;
			tGDvniuTJlIejPUqmFlvZJqcfanC = lLCNnOeDbTyjEfJmIYZNhgQuwLGU.controllerName;
			IRNtfBVvjIJinyEzklEhELbHRxCV = QCgDlmObzkqFYIBkCQXuPsXAmbtk == Guid.Empty;
			clzVDdnQeJtPTEjsqyOnxxnjwgWF = new float[nPiyjiiLZOAQyMtoKzHdHuuDWJWb];
			BBGDxlFHAEhGSUylCUELYJeKbTkq = new bool[CZfargRSUjtJFNXVXeMuMbYWEvtT];
			dlebRgYnNGqgfxiKwiIgcssIjIos.MBLHUatrHowFeYYtjhaeCIONlXyS();
			Update();
		}

		public void ElfNyjfcTcaQHAvZbxMeNfiCuqCqA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0)
		{
			if (P_0 != null)
			{
				oDyNvbEZQVEsiZkITUqKOAqlEhgP = P_0.oDyNvbEZQVEsiZkITUqKOAqlEhgP;
				LusMdEiDqdQTbCyhdabCWVzDFyXo = P_0.LusMdEiDqdQTbCyhdabCWVzDFyXo;
				for (int i = 0; i < MathTools.Min(BBGDxlFHAEhGSUylCUELYJeKbTkq.Length, P_0.BBGDxlFHAEhGSUylCUELYJeKbTkq.Length); i++)
				{
					BBGDxlFHAEhGSUylCUELYJeKbTkq[i] = P_0.BBGDxlFHAEhGSUylCUELYJeKbTkq[i];
				}
				for (int j = 0; j < MathTools.Min(clzVDdnQeJtPTEjsqyOnxxnjwgWF.Length, P_0.clzVDdnQeJtPTEjsqyOnxxnjwgWF.Length); j++)
				{
					clzVDdnQeJtPTEjsqyOnxxnjwgWF[j] = P_0.clzVDdnQeJtPTEjsqyOnxxnjwgWF[j];
				}
				cqXHkAlKwTFmiBwAbNWFxpEGFNxHA = P_0.cqXHkAlKwTFmiBwAbNWFxpEGFNxHA;
				dlebRgYnNGqgfxiKwiIgcssIjIos.EXPlxRixCcRPLsQmLoftzkcYuHFi(P_0.dlebRgYnNGqgfxiKwiIgcssIjIos);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			dlebRgYnNGqgfxiKwiIgcssIjIos.jYYGdTdvKUcDWEewFdtVRxjMTMfLB();
			bool[] array = dlebRgYnNGqgfxiKwiIgcssIjIos.DgYGqaifPrMrAFLEdBkWxGdcEZMsB;
			int[] kaOPusyXetDQXtjvQzpISYVfYWfb = dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.KaOPusyXetDQXtjvQzpISYVfYWfb;
			PGWPLLHiStANnRfrMmmnqyuOCpvX(array, kaOPusyXetDQXtjvQzpISYVfYWfb);
			OPROhNmFDkZcWshLlErvenXAUIdk(array, kaOPusyXetDQXtjvQzpISYVfYWfb);
			dlebRgYnNGqgfxiKwiIgcssIjIos.LeyaTusvhDLBuBIdlkMJvmVMafTD();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (nPiyjiiLZOAQyMtoKzHdHuuDWJWb != dataUpdater.axisCount || CZfargRSUjtJFNXVXeMuMbYWEvtT != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < nPiyjiiLZOAQyMtoKzHdHuuDWJWb; i++)
			{
				dataUpdater.axisValues[i] = clzVDdnQeJtPTEjsqyOnxxnjwgWF[i];
			}
			for (int j = 0; j < CZfargRSUjtJFNXVXeMuMbYWEvtT; j++)
			{
				dataUpdater.buttonValues[j] = BBGDxlFHAEhGSUylCUELYJeKbTkq[j];
			}
			if (cqXHkAlKwTFmiBwAbNWFxpEGFNxHA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int cSSelrJcgvnxYdCOyGuwXryBPByhA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0)
		{
			if (P_0.LusMdEiDqdQTbCyhdabCWVzDFyXo == LusMdEiDqdQTbCyhdabCWVzDFyXo)
			{
				return 2;
			}
			if (JiDYAISMELSdeAeNTOpuFUNqNoeA != P_0.JiDYAISMELSdeAeNTOpuFUNqNoeA)
			{
				return 0;
			}
			if (XgOfIkiRHnILohqIHAYoSyoaJzGm != P_0.XgOfIkiRHnILohqIHAYoSyoaJzGm)
			{
				return 0;
			}
			if (GbjktuKNCSrBbfYrJsiehchCrjiu != P_0.GbjktuKNCSrBbfYrJsiehchCrjiu)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.XSFoSrQpBibIEVzUoZjAOKiFEFuj == XSFoSrQpBibIEVzUoZjAOKiFEFuj)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo HuztLhDWkOkjVnNyKKbxOyhBAIWu()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			MThoteyPXsVRcCwaEssLZuMhFAhB(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			JoCakJDMASfuhXjLSOvziezMIqxh(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(LusMdEiDqdQTbCyhdabCWVzDFyXo);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool pHuOOlARjbZLiAAgBbdAPAKzvJzy()
		{
			try
			{
				dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc.hgdrauSEnHabHHNCGmDpGsYixbJWA();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void eKGwHLHkdPvnGKMPZAMlRUkBobb()
		{
			try
			{
				if (dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc != null)
				{
					dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc.JFtgQeubYmhwWhIMlgFUXXNcOVpf();
				}
			}
			catch
			{
			}
		}

		public void zvcAaTinHbWaTgbXXGvbDfBdkwGTb()
		{
			try
			{
				if (dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc != null)
				{
					dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc.qUSLHdlhISyIgybstyFDACYBVvCc();
				}
			}
			catch
			{
			}
		}

		private void PGWPLLHiStANnRfrMmmnqyuOCpvX(bool[] P_0, int[] P_1)
		{
			if (nPiyjiiLZOAQyMtoKzHdHuuDWJWb <= 0)
			{
				return;
			}
			switch (lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						lBehLBFcBtqNkjuIYmXjLXtTudMP(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						lBehLBFcBtqNkjuIYmXjLXtTudMP(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void OPROhNmFDkZcWshLlErvenXAUIdk(bool[] P_0, int[] P_1)
		{
			if (CZfargRSUjtJFNXVXeMuMbYWEvtT <= 0)
			{
				return;
			}
			switch (lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						IcqHNTKOAkdOmeHRPyoMFDBFxHtRA(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)lLCNnOeDbTyjEfJmIYZNhgQuwLGU.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						IcqHNTKOAkdOmeHRPyoMFDBFxHtRA(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void lBehLBFcBtqNkjuIYmXjLXtTudMP(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= nPiyjiiLZOAQyMtoKzHdHuuDWJWb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			clzVDdnQeJtPTEjsqyOnxxnjwgWF[P_1] = AOYYUbgUsuGLRoTxRNfmJuNaCQRm(P_0, P_2, P_3);
			if (!cqXHkAlKwTFmiBwAbNWFxpEGFNxHA && clzVDdnQeJtPTEjsqyOnxxnjwgWF[P_1] != 0f)
			{
				cqXHkAlKwTFmiBwAbNWFxpEGFNxHA = true;
			}
		}

		private void IcqHNTKOAkdOmeHRPyoMFDBFxHtRA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= CZfargRSUjtJFNXVXeMuMbYWEvtT)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			BBGDxlFHAEhGSUylCUELYJeKbTkq[P_1] = RtTSsfFfLGPCCCrSbbQjGEjrENQD(P_0, P_2, P_3);
			if (!cqXHkAlKwTFmiBwAbNWFxpEGFNxHA && BBGDxlFHAEhGSUylCUELYJeKbTkq[P_1])
			{
				cqXHkAlKwTFmiBwAbNWFxpEGFNxHA = true;
			}
		}

		private float AOYYUbgUsuGLRoTxRNfmJuNaCQRm(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return uAHYNoDgfShBAdcBTRboAlHnRfYS((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= XgOfIkiRHnILohqIHAYoSyoaJzGm || sourceButton >= 128)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= GbjktuKNCSrBbfYrJsiehchCrjiu || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = LloaXvoFPnsDiJXvZbuoDNSHqstl(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = LloaXvoFPnsDiJXvZbuoDNSHqstl(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && YNIQakcxvBEVRcBiCKdRnAndvqrx(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			return 0f;
		}

		private float uAHYNoDgfShBAdcBTRboAlHnRfYS(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.eyWMfIIKREHFJgAyDunBmYTYDiOX, 
				DirectInputAxis.Y => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.XkGAmodPFxypeMGclVqEnktybMjlA, 
				DirectInputAxis.Z => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.GFHgIIBrHphZnltcbrcFKbogKuFFA, 
				DirectInputAxis.RotationX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.yFOqYEkzHrIxQIMPAlBAdunRhtnu, 
				DirectInputAxis.RotationY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.ZKRPDskyQcXXowThfGcPxUImhghK, 
				DirectInputAxis.RotationZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.wZCCclvyAdTENTHSvTrQEGgaHJngA, 
				DirectInputAxis.Slider0 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.BPBmZTJyJraxtGjbLmfthThZpkwm[0], 
				DirectInputAxis.Slider1 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.BPBmZTJyJraxtGjbLmfthThZpkwm[1], 
				DirectInputAxis.VelocityX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.BjucICzvWTbTOTjAPJvnjUdjMeaM, 
				DirectInputAxis.VelocityY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.eEWIjLZWjzSWgJDIyWItmCfEHDMhA, 
				DirectInputAxis.VelocityZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.iYIjKMAegDiTYhPuqmBTnfJFeeHGb, 
				DirectInputAxis.AngularVelocityX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.UTlcXaFoVQdPVCWbNrCVNZWPIpuG, 
				DirectInputAxis.AngularVelocityY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.mFhgqKIRqnJrMtgtGlQBFryDjLTD, 
				DirectInputAxis.AngularVelocityZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.VhghMTsFqztwuRxgNtpkJwtAUNMR, 
				DirectInputAxis.VelocitySlider0 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.YJIhAuyFDsgNMbcaYgIQditqjjdXA[0], 
				DirectInputAxis.VelocitySlider1 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.YJIhAuyFDsgNMbcaYgIQditqjjdXA[1], 
				DirectInputAxis.AccelerationX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.bqAoigifSniDhxQYQjJyHxGEYjNL, 
				DirectInputAxis.AccelerationY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.pFSGtqCEmEWpntVahWIbNpAKZuYI, 
				DirectInputAxis.AccelerationZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.KucjVrgzNcLPFlYVLqXVCYTssxHo, 
				DirectInputAxis.AngularAccelerationX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.sAxtpHJWFVmkuwNzyaiPWpuBJNpN, 
				DirectInputAxis.AngularAccelerationY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.YTpEaZGWqQUOuppfdsblLUcHwZJw, 
				DirectInputAxis.AngularAccelerationZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.gCxBlyivhtmAlNfHOiOuWWGjtkqk, 
				DirectInputAxis.AccelerationSlider0 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.TQOFgkiMEIDRbcFtRANefWiSliGhb[0], 
				DirectInputAxis.AccelerationSlider1 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.TQOFgkiMEIDRbcFtRANefWiSliGhb[1], 
				DirectInputAxis.ForceX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.BaFNLfYVfIwTRTgTGfcQaFkkHuBT, 
				DirectInputAxis.ForceY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.RboycnvjCyVjEIjCKaNegUWfwpHCA, 
				DirectInputAxis.ForceZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.uEYedEDzciAafYkJlbrXjTjXuxDiA, 
				DirectInputAxis.TorqueX => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.KzevoDOdEuKPpCcddYgATrtcDArJA, 
				DirectInputAxis.TorqueY => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.AIxuXUGFgrrKjDBAtZsfrKCztwwU, 
				DirectInputAxis.TorqueZ => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.qwkIHBKqogWuOYhwHHJvDPCbfFLJ, 
				DirectInputAxis.ForceSlider0 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.zBzRkwnlllBnxBjjnHmpVrkkIduVA[0], 
				DirectInputAxis.ForceSlider1 => dlebRgYnNGqgfxiKwiIgcssIjIos.gWRvYlmgsOfUWCPHNMWwYMKbhJaH.zBzRkwnlllBnxBjjnHmpVrkkIduVA[1], 
				_ => 0f, 
			};
		}

		private bool RtTSsfFfLGPCCCrSbbQjGEjrENQD(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return false;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!P_1[P_0.requiredButtons[j]])
						{
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= XgOfIkiRHnILohqIHAYoSyoaJzGm || sourceButton >= 128)
				{
					return false;
				}
				return P_1[sourceButton];
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis > 32)
				{
					return false;
				}
				float num = uAHYNoDgfShBAdcBTRboAlHnRfYS((DirectInputAxis)P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= GbjktuKNCSrBbfYrJsiehchCrjiu || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return false;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return false;
				}
				for (int k = 0; k < customCalculationSourceData.Length; k++)
				{
					if (customCalculationSourceData[k] == null)
					{
						continue;
					}
					switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
					{
						if (qRsgfXOiEDIGHeHpjoylAOsEJlnRb(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (YNIQakcxvBEVRcBiCKdRnAndvqrx(customCalculationSourceData[k], out var num2))
						{
							customCalculation.AddData((num2 != 0f) ? 1f : 0f);
						}
						break;
					}
					}
				}
				if (!customCalculation.Process())
				{
					return false;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return false;
				}
				return (float)customCalculation.Result != 0f;
			}
			return false;
		}

		private bool NAEgIDxjuBIwLGnrVhPoYKDAwSVQ(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (lLCNnOeDbTyjEfJmIYZNhgQuwLGU.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float LloaXvoFPnsDiJXvZbuoDNSHqstl(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private bool qRsgfXOiEDIGHeHpjoylAOsEJlnRb(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= XgOfIkiRHnILohqIHAYoSyoaJzGm || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool YNIQakcxvBEVRcBiCKdRnAndvqrx(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
			{
				return false;
			}
			P_1 = uAHYNoDgfShBAdcBTRboAlHnRfYS((DirectInputAxis)P_0.sourceAxis);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType jadIiJIJBaeUUZNCyXeIDXwBHQbiA(xCjHMUlKilLbcWgIcpQhdLGbHDVD P_0)
		{
			return P_0 switch
			{
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Keyboard => ControlDeviceType.Keyboard, 
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Joystick => ControlDeviceType.Joystick, 
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Gamepad => ControlDeviceType.Gamepad, 
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Mouse => ControlDeviceType.Mouse, 
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Flight => ControlDeviceType.Flight, 
				xCjHMUlKilLbcWgIcpQhdLGbHDVD.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void YmDTkDaQMSaNQiLHStgHZBoMzlUP()
		{
			lLCNnOeDbTyjEfJmIYZNhgQuwLGU = oNvfXgHTSzWYvqRLhMnfTNcZKGTMA(HuztLhDWkOkjVnNyKKbxOyhBAIWu());
			if (lLCNnOeDbTyjEfJmIYZNhgQuwLGU == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			nPiyjiiLZOAQyMtoKzHdHuuDWJWb = lLCNnOeDbTyjEfJmIYZNhgQuwLGU.axisCount;
			CZfargRSUjtJFNXVXeMuMbYWEvtT = lLCNnOeDbTyjEfJmIYZNhgQuwLGU.buttonCount;
		}

		private void mgPQrjntdDMblJbjEOoPGBXWtfon()
		{
		}

		private string zQNAGFMYDsjXmGInjSNjfySwrORF()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (ACPFfUcDKNakIhAkCMchvCBEiyiYb && !string.IsNullOrEmpty(nxPkdjTEaYZiiBvqOirqdkCMTUKd)) ? nxPkdjTEaYZiiBvqOirqdkCMTUKd : ItAxoFoPRBouslYknrpHyLycCekt, fMKicojkVfzslrdIfOWAGBzVnuLu.ToString("X4"), new PidVid(jjNvGhLgVUdZtpAIwEHsdtIgDaOV).vendorId.ToString("X4")));
		}

		private void MThoteyPXsVRcCwaEssLZuMhFAhB(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = jadIiJIJBaeUUZNCyXeIDXwBHQbiA(cSavbmZXIlQoZHmhZdfxPxWWHDyX);
			P_0.hardwareIdentifier = zQNAGFMYDsjXmGInjSNjfySwrORF();
			P_0.hardwareAxisCount = JiDYAISMELSdeAeNTOpuFUNqNoeA;
			P_0.hardwareButtonCount = XgOfIkiRHnILohqIHAYoSyoaJzGm;
			P_0.hardwareHatCount = GbjktuKNCSrBbfYrJsiehchCrjiu;
			P_0.hw_productName = ItAxoFoPRBouslYknrpHyLycCekt;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = fMKicojkVfzslrdIfOWAGBzVnuLu;
			P_0.hw_pidVid = new PidVid(jjNvGhLgVUdZtpAIwEHsdtIgDaOV);
			P_0.hw_isBluetoothDevice = ACPFfUcDKNakIhAkCMchvCBEiyiYb;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(nxPkdjTEaYZiiBvqOirqdkCMTUKd)) ? nxPkdjTEaYZiiBvqOirqdkCMTUKd : string.Empty);
			P_0.definitionMatchTag = jbwnbOsIejfhAmLhlzPPbAkWUQKl;
		}

		private void JoCakJDMASfuhXjLSOvziezMIqxh(BridgedController P_0)
		{
			MThoteyPXsVRcCwaEssLZuMhFAhB(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = lLCNnOeDbTyjEfJmIYZNhgQuwLGU.ToGameHardwareControllerMap();
			P_0.instanceName = lRSuCVqBFiwoLENPMKoDoRlJImPV;
			P_0.productName = ItAxoFoPRBouslYknrpHyLycCekt;
			P_0.isXInputDevice = fkTCPIsHqSotwhwqqxJjzcdbvPaE;
			P_0.axisCount = nPiyjiiLZOAQyMtoKzHdHuuDWJWb;
			P_0.buttonCount = CZfargRSUjtJFNXVXeMuMbYWEvtT;
			P_0.unknownControllerHats = gxSlCafySeeQKgNqXgwRexQiKLxAA();
			P_0.controllerTypeGuid = QCgDlmObzkqFYIBkCQXuPsXAmbtk;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void DLUVcsJofwQITZZGWfIuduJbSLPe()
		{
			for (int i = 0; i < CZfargRSUjtJFNXVXeMuMbYWEvtT; i++)
			{
				BBGDxlFHAEhGSUylCUELYJeKbTkq[i] = false;
			}
			for (int j = 0; j < nPiyjiiLZOAQyMtoKzHdHuuDWJWb; j++)
			{
				clzVDdnQeJtPTEjsqyOnxxnjwgWF[j] = 0f;
			}
		}

		private UnknownControllerHat[] gxSlCafySeeQKgNqXgwRexQiKLxAA()
		{
			if (!IRNtfBVvjIJinyEzklEhELbHRxCV)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void xTFhmkzjUzmmKDShwvmePLldyNBi()
		{
			DPhgmjUdSJkOpecLALByApmMUbuQ(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void IsiMJwLKOCbhTfEdAVNtBhaPWRod()
		{
			try
			{
				DPhgmjUdSJkOpecLALByApmMUbuQ(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void DPhgmjUdSJkOpecLALByApmMUbuQ(bool P_0)
		{
			if (!mqrfeYgULFvxoMNGcRuwKWRaomqCA)
			{
				if (P_0 && dlebRgYnNGqgfxiKwiIgcssIjIos != null)
				{
					dlebRgYnNGqgfxiKwiIgcssIjIos.Dispose();
				}
				mqrfeYgULFvxoMNGcRuwKWRaomqCA = true;
			}
		}

		public static int hvMOKxYJxddquBUgUZglqiPnAkad(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, GdZLnXxkOIHlKtGBscttffEFwmuN P_1)
		{
			if (P_0.oDyNvbEZQVEsiZkITUqKOAqlEhgP < P_1.oDyNvbEZQVEsiZkITUqKOAqlEhgP)
			{
				return -1;
			}
			if (P_0.oDyNvbEZQVEsiZkITUqKOAqlEhgP > P_1.oDyNvbEZQVEsiZkITUqKOAqlEhgP)
			{
				return 1;
			}
			return 0;
		}

		public static int eUMVmyyghYerfFTzAzQjSuFbziUV(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, GdZLnXxkOIHlKtGBscttffEFwmuN P_1)
		{
			if (P_0.pCOoHkGiSIHiSbyVcoxRfoAIeuTv < P_1.pCOoHkGiSIHiSbyVcoxRfoAIeuTv)
			{
				return -1;
			}
			if (P_0.pCOoHkGiSIHiSbyVcoxRfoAIeuTv > P_1.pCOoHkGiSIHiSbyVcoxRfoAIeuTv)
			{
				return 1;
			}
			return 0;
		}
	}

	private class miYcigybCPTrspuzuSiEafduhOCF : IDisposable
	{
		public class clQCvABmUnORfcnNvPocVVQEyXXX
		{
			public float eyWMfIIKREHFJgAyDunBmYTYDiOX;

			public float XkGAmodPFxypeMGclVqEnktybMjlA;

			public float GFHgIIBrHphZnltcbrcFKbogKuFFA;

			public float yFOqYEkzHrIxQIMPAlBAdunRhtnu;

			public float ZKRPDskyQcXXowThfGcPxUImhghK;

			public float wZCCclvyAdTENTHSvTrQEGgaHJngA;

			public float[] BPBmZTJyJraxtGjbLmfthThZpkwm;

			public readonly int[] KaOPusyXetDQXtjvQzpISYVfYWfb;

			public readonly bool[] kZmXcOuglSvBieixrgTNwkyaaIgh;

			public float BjucICzvWTbTOTjAPJvnjUdjMeaM;

			public float eEWIjLZWjzSWgJDIyWItmCfEHDMhA;

			public float iYIjKMAegDiTYhPuqmBTnfJFeeHGb;

			public float UTlcXaFoVQdPVCWbNrCVNZWPIpuG;

			public float mFhgqKIRqnJrMtgtGlQBFryDjLTD;

			public float VhghMTsFqztwuRxgNtpkJwtAUNMR;

			public readonly float[] YJIhAuyFDsgNMbcaYgIQditqjjdXA;

			public float bqAoigifSniDhxQYQjJyHxGEYjNL;

			public float pFSGtqCEmEWpntVahWIbNpAKZuYI;

			public float KucjVrgzNcLPFlYVLqXVCYTssxHo;

			public float sAxtpHJWFVmkuwNzyaiPWpuBJNpN;

			public float YTpEaZGWqQUOuppfdsblLUcHwZJw;

			public float gCxBlyivhtmAlNfHOiOuWWGjtkqk;

			public readonly float[] TQOFgkiMEIDRbcFtRANefWiSliGhb;

			public float BaFNLfYVfIwTRTgTGfcQaFkkHuBT;

			public float RboycnvjCyVjEIjCKaNegUWfwpHCA;

			public float uEYedEDzciAafYkJlbrXjTjXuxDiA;

			public float KzevoDOdEuKPpCcddYgATrtcDArJA;

			public float AIxuXUGFgrrKjDBAtZsfrKCztwwU;

			public float qwkIHBKqogWuOYhwHHJvDPCbfFLJ;

			public readonly float[] zBzRkwnlllBnxBjjnHmpVrkkIduVA;

			public clQCvABmUnORfcnNvPocVVQEyXXX()
			{
				BPBmZTJyJraxtGjbLmfthThZpkwm = new float[2];
				KaOPusyXetDQXtjvQzpISYVfYWfb = new int[4];
				kZmXcOuglSvBieixrgTNwkyaaIgh = new bool[128];
				YJIhAuyFDsgNMbcaYgIQditqjjdXA = new float[2];
				TQOFgkiMEIDRbcFtRANefWiSliGhb = new float[2];
				zBzRkwnlllBnxBjjnHmpVrkkIduVA = new float[2];
			}

			public void ylNhfGEeICZvqlzYShOXEgNwuLnp()
			{
				eyWMfIIKREHFJgAyDunBmYTYDiOX = 0f;
				XkGAmodPFxypeMGclVqEnktybMjlA = 0f;
				GFHgIIBrHphZnltcbrcFKbogKuFFA = 0f;
				yFOqYEkzHrIxQIMPAlBAdunRhtnu = 0f;
				ZKRPDskyQcXXowThfGcPxUImhghK = 0f;
				wZCCclvyAdTENTHSvTrQEGgaHJngA = 0f;
				for (int i = 0; i < BPBmZTJyJraxtGjbLmfthThZpkwm.Length; i++)
				{
					BPBmZTJyJraxtGjbLmfthThZpkwm[i] = 0f;
				}
				for (int j = 0; j < KaOPusyXetDQXtjvQzpISYVfYWfb.Length; j++)
				{
					KaOPusyXetDQXtjvQzpISYVfYWfb[j] = 0;
				}
				for (int k = 0; k < kZmXcOuglSvBieixrgTNwkyaaIgh.Length; k++)
				{
					kZmXcOuglSvBieixrgTNwkyaaIgh[k] = false;
				}
				BjucICzvWTbTOTjAPJvnjUdjMeaM = 0f;
				eEWIjLZWjzSWgJDIyWItmCfEHDMhA = 0f;
				iYIjKMAegDiTYhPuqmBTnfJFeeHGb = 0f;
				UTlcXaFoVQdPVCWbNrCVNZWPIpuG = 0f;
				mFhgqKIRqnJrMtgtGlQBFryDjLTD = 0f;
				VhghMTsFqztwuRxgNtpkJwtAUNMR = 0f;
				for (int l = 0; l < YJIhAuyFDsgNMbcaYgIQditqjjdXA.Length; l++)
				{
					YJIhAuyFDsgNMbcaYgIQditqjjdXA[l] = 0f;
				}
				bqAoigifSniDhxQYQjJyHxGEYjNL = 0f;
				pFSGtqCEmEWpntVahWIbNpAKZuYI = 0f;
				KucjVrgzNcLPFlYVLqXVCYTssxHo = 0f;
				sAxtpHJWFVmkuwNzyaiPWpuBJNpN = 0f;
				YTpEaZGWqQUOuppfdsblLUcHwZJw = 0f;
				gCxBlyivhtmAlNfHOiOuWWGjtkqk = 0f;
				for (int m = 0; m < TQOFgkiMEIDRbcFtRANefWiSliGhb.Length; m++)
				{
					TQOFgkiMEIDRbcFtRANefWiSliGhb[m] = 0f;
				}
				BaFNLfYVfIwTRTgTGfcQaFkkHuBT = 0f;
				RboycnvjCyVjEIjCKaNegUWfwpHCA = 0f;
				uEYedEDzciAafYkJlbrXjTjXuxDiA = 0f;
				KzevoDOdEuKPpCcddYgATrtcDArJA = 0f;
				AIxuXUGFgrrKjDBAtZsfrKCztwwU = 0f;
				qwkIHBKqogWuOYhwHHJvDPCbfFLJ = 0f;
				for (int n = 0; n < zBzRkwnlllBnxBjjnHmpVrkkIduVA.Length; n++)
				{
					zBzRkwnlllBnxBjjnHmpVrkkIduVA[n] = 0f;
				}
			}

			public void EAoeLdeVuqiwmLjlViiPOPlgvFDmA(clQCvABmUnORfcnNvPocVVQEyXXX P_0)
			{
				eyWMfIIKREHFJgAyDunBmYTYDiOX = P_0.eyWMfIIKREHFJgAyDunBmYTYDiOX;
				XkGAmodPFxypeMGclVqEnktybMjlA = P_0.XkGAmodPFxypeMGclVqEnktybMjlA;
				GFHgIIBrHphZnltcbrcFKbogKuFFA = P_0.GFHgIIBrHphZnltcbrcFKbogKuFFA;
				yFOqYEkzHrIxQIMPAlBAdunRhtnu = P_0.yFOqYEkzHrIxQIMPAlBAdunRhtnu;
				ZKRPDskyQcXXowThfGcPxUImhghK = P_0.ZKRPDskyQcXXowThfGcPxUImhghK;
				wZCCclvyAdTENTHSvTrQEGgaHJngA = P_0.wZCCclvyAdTENTHSvTrQEGgaHJngA;
				for (int i = 0; i < BPBmZTJyJraxtGjbLmfthThZpkwm.Length; i++)
				{
					BPBmZTJyJraxtGjbLmfthThZpkwm[i] = P_0.BPBmZTJyJraxtGjbLmfthThZpkwm[i];
				}
				for (int j = 0; j < KaOPusyXetDQXtjvQzpISYVfYWfb.Length; j++)
				{
					KaOPusyXetDQXtjvQzpISYVfYWfb[j] = P_0.KaOPusyXetDQXtjvQzpISYVfYWfb[j];
				}
				for (int k = 0; k < kZmXcOuglSvBieixrgTNwkyaaIgh.Length; k++)
				{
					kZmXcOuglSvBieixrgTNwkyaaIgh[k] = P_0.kZmXcOuglSvBieixrgTNwkyaaIgh[k];
				}
				BjucICzvWTbTOTjAPJvnjUdjMeaM = P_0.BjucICzvWTbTOTjAPJvnjUdjMeaM;
				eEWIjLZWjzSWgJDIyWItmCfEHDMhA = P_0.eEWIjLZWjzSWgJDIyWItmCfEHDMhA;
				iYIjKMAegDiTYhPuqmBTnfJFeeHGb = P_0.iYIjKMAegDiTYhPuqmBTnfJFeeHGb;
				UTlcXaFoVQdPVCWbNrCVNZWPIpuG = P_0.UTlcXaFoVQdPVCWbNrCVNZWPIpuG;
				mFhgqKIRqnJrMtgtGlQBFryDjLTD = P_0.mFhgqKIRqnJrMtgtGlQBFryDjLTD;
				VhghMTsFqztwuRxgNtpkJwtAUNMR = P_0.VhghMTsFqztwuRxgNtpkJwtAUNMR;
				for (int l = 0; l < YJIhAuyFDsgNMbcaYgIQditqjjdXA.Length; l++)
				{
					YJIhAuyFDsgNMbcaYgIQditqjjdXA[l] = P_0.YJIhAuyFDsgNMbcaYgIQditqjjdXA[l];
				}
				bqAoigifSniDhxQYQjJyHxGEYjNL = P_0.bqAoigifSniDhxQYQjJyHxGEYjNL;
				pFSGtqCEmEWpntVahWIbNpAKZuYI = P_0.pFSGtqCEmEWpntVahWIbNpAKZuYI;
				KucjVrgzNcLPFlYVLqXVCYTssxHo = P_0.KucjVrgzNcLPFlYVLqXVCYTssxHo;
				sAxtpHJWFVmkuwNzyaiPWpuBJNpN = P_0.sAxtpHJWFVmkuwNzyaiPWpuBJNpN;
				YTpEaZGWqQUOuppfdsblLUcHwZJw = P_0.YTpEaZGWqQUOuppfdsblLUcHwZJw;
				gCxBlyivhtmAlNfHOiOuWWGjtkqk = P_0.gCxBlyivhtmAlNfHOiOuWWGjtkqk;
				for (int m = 0; m < TQOFgkiMEIDRbcFtRANefWiSliGhb.Length; m++)
				{
					TQOFgkiMEIDRbcFtRANefWiSliGhb[m] = P_0.TQOFgkiMEIDRbcFtRANefWiSliGhb[m];
				}
				BaFNLfYVfIwTRTgTGfcQaFkkHuBT = P_0.BaFNLfYVfIwTRTgTGfcQaFkkHuBT;
				RboycnvjCyVjEIjCKaNegUWfwpHCA = P_0.RboycnvjCyVjEIjCKaNegUWfwpHCA;
				uEYedEDzciAafYkJlbrXjTjXuxDiA = P_0.uEYedEDzciAafYkJlbrXjTjXuxDiA;
				KzevoDOdEuKPpCcddYgATrtcDArJA = P_0.KzevoDOdEuKPpCcddYgATrtcDArJA;
				AIxuXUGFgrrKjDBAtZsfrKCztwwU = P_0.AIxuXUGFgrrKjDBAtZsfrKCztwwU;
				qwkIHBKqogWuOYhwHHJvDPCbfFLJ = P_0.qwkIHBKqogWuOYhwHHJvDPCbfFLJ;
				for (int n = 0; n < zBzRkwnlllBnxBjjnHmpVrkkIduVA.Length; n++)
				{
					zBzRkwnlllBnxBjjnHmpVrkkIduVA[n] = P_0.zBzRkwnlllBnxBjjnHmpVrkkIduVA[n];
				}
			}

			public unsafe void KEpOJheQTEAiEuvZrfqKIaUacRMCA(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						kZmXcOuglSvBieixrgTNwkyaaIgh[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					TQOFgkiMEIDRbcFtRANefWiSliGhb[k] = *ptr;
					ptr++;
				}
				bqAoigifSniDhxQYQjJyHxGEYjNL = *ptr;
				ptr++;
				pFSGtqCEmEWpntVahWIbNpAKZuYI = *ptr;
				ptr++;
				KucjVrgzNcLPFlYVLqXVCYTssxHo = *ptr;
				ptr++;
				sAxtpHJWFVmkuwNzyaiPWpuBJNpN = *ptr;
				ptr++;
				YTpEaZGWqQUOuppfdsblLUcHwZJw = *ptr;
				ptr++;
				gCxBlyivhtmAlNfHOiOuWWGjtkqk = *ptr;
				ptr++;
				UTlcXaFoVQdPVCWbNrCVNZWPIpuG = *ptr;
				ptr++;
				mFhgqKIRqnJrMtgtGlQBFryDjLTD = *ptr;
				ptr++;
				VhghMTsFqztwuRxgNtpkJwtAUNMR = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					zBzRkwnlllBnxBjjnHmpVrkkIduVA[l] = *ptr;
					ptr++;
				}
				BaFNLfYVfIwTRTgTGfcQaFkkHuBT = *ptr;
				ptr++;
				RboycnvjCyVjEIjCKaNegUWfwpHCA = *ptr;
				ptr++;
				uEYedEDzciAafYkJlbrXjTjXuxDiA = *ptr;
				ptr++;
				yFOqYEkzHrIxQIMPAlBAdunRhtnu = *ptr;
				ptr++;
				ZKRPDskyQcXXowThfGcPxUImhghK = *ptr;
				ptr++;
				wZCCclvyAdTENTHSvTrQEGgaHJngA = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					BPBmZTJyJraxtGjbLmfthThZpkwm[m] = *ptr;
					ptr++;
				}
				KzevoDOdEuKPpCcddYgATrtcDArJA = *ptr;
				ptr++;
				AIxuXUGFgrrKjDBAtZsfrKCztwwU = *ptr;
				ptr++;
				qwkIHBKqogWuOYhwHHJvDPCbfFLJ = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					YJIhAuyFDsgNMbcaYgIQditqjjdXA[n] = *ptr;
					ptr++;
				}
				BjucICzvWTbTOTjAPJvnjUdjMeaM = *ptr;
				ptr++;
				eEWIjLZWjzSWgJDIyWItmCfEHDMhA = *ptr;
				ptr++;
				iYIjKMAegDiTYhPuqmBTnfJFeeHGb = *ptr;
				ptr++;
				eyWMfIIKREHFJgAyDunBmYTYDiOX = *ptr;
				ptr++;
				XkGAmodPFxypeMGclVqEnktybMjlA = *ptr;
				ptr++;
				GFHgIIBrHphZnltcbrcFKbogKuFFA = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					KaOPusyXetDQXtjvQzpISYVfYWfb[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void OzXUUMHnTXjDonMrTgSYZFpKBjqAA(IzQgfDkzjTmspgxWvNpFitmeknESA P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.CjEnaageEMHiJpyZhSEjoCRTJnLC;
				int[] array2 = P_0.xUnEIVdijlauGELuTyMSTVBiTeTLA;
				int[] array3 = P_0.cFJbdSIxCCaoqcAbLxjehxKIKZbDA;
				int[] array4 = P_0.MqqDNzzWsJtVRfBEbBLJbbOWigtab;
				int[] array5 = P_0.HJGMEnfWBkObtvxczCvYphWHkrJl;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.anoDPUijofMmwdpNjuiyAbLOZQHHA[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(array2[j]);
					ptr++;
				}
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.ZWSISyKTeLjkmPOAhDhNtTNqWSkK);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.AqPEnJCkauiInCatAlJdbEgzSwlub);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.GPUScCsscLNIRcoqJHnvIlnybxMEA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.FNcyNtHMLJSpGDmjuZcGnAOcybme);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.KwNDwJphpfgBEAPhXLuXstksTVObA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.IvnKtIjEdjPfKVuNMFurlbPxljUX);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.BmVuNqKTaeQiTMYYJtpHVGAZeCuA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.IJzAPVmvGJgdhcYVscuYBRfPQNVB);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.DPgGRWYyixWRILmRGevGYRmpVyDG);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(array3[k]);
					ptr++;
				}
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.xUAFGlHVcGyBvtUiffmwFKMWSbWm);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.BkBETNIjUBRgLbEWfDMqrAXEgFXMA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.rrlBeEqTTHzCvwhQQJNpawJbUjeT);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.mSsentqWVPLijLZQEVErZiXebQgbA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.nPSRwlwHveRxatrqLvjTXAAAjTnF);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(array4[l]);
					ptr++;
				}
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.OzoapQJHcjKvcMVeKrjMmiZRugnoA);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.dDIVAKIHMAzxpflGtoDcFKhPGVEj);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.naCGwGjFoMaMbepAyEeZOBvXRKSOA);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(array5[m]);
					ptr++;
				}
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.hmBqYGdIFIdePUrFPzZZvSKRlvhj);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.PQbvBQFGdcURMfrdJVtRGnhlxDtr);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.MKxaZEvsDBDFmBwZWkIYIxFetzTU);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.WUWgLBZzdSHtJsNgVyVeDQwQDMRW);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.fUNSCshvabYYSlFQlEDDDUmcSRCf);
				ptr++;
				*ptr = xDaBvxJNILVpzmfedxUwIoeCCocI(P_0.aHBiMKVabkBMSbQQGrPBCusQpIVC);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int LvmYRIQmVlDSdhXLtSvCCwkyDkfU = 2;

		private const int cIkVrvifnUWvYHjsLbSmfRNQXsdG = 2;

		private const int ysTWQYcYWbjuPHowIgsUshDzFdXj = 128;

		private const int AaWfZqALeGRcxhikdxmZkkQTyKbWA = 32;

		private const int fulmJAOSYEOkAddeTuuBFuQcyGbJ = 0;

		private const int eLiifayHIgfPCrWWgUWCXPItHubn = 264;

		private const int WPLVpKtXipfJcMQBuToAbRDSikxt = 272;

		private readonly int FlqdNFdOvrDMRWbPDYKibeCZeCIIb;

		private readonly ButtonLoopSet JeYbPvNAFxzSTpacXVIUsEEfUVXL;

		private readonly DualThreadLowLevelInputEventQueue vcszACjbpCXghBuVolOokMEZYHVD;

		private ZnRFLPLytHowXnprFuWRVUHdSnFi CzYkkAmdWErrMUOTteRuVqLuNHlR;

		private readonly IzQgfDkzjTmspgxWvNpFitmeknESA VivLkBDpMIkLWqoNbaTbjQAPEyvz;

		private readonly IzQgfDkzjTmspgxWvNpFitmeknESA xizWQmliCfhNeIvlZuCowpbayQAi;

		private readonly object KmXtnHMMmJOXulkmADcgiwonysrJ;

		private bool ujdXNpKBRtsiuzlmyKnAaObpeATgA;

		public readonly anbhbdfzsmouOkCCbStpOglBHmiHb SMRTsdAlHeuDLbbqWqOMPvghgyqc;

		private readonly clQCvABmUnORfcnNvPocVVQEyXXX wtJZsGrpBpdeajfLWFgGvPasyaBQA;

		private bool XQodmaifWKtPfRWNVlOWfonRNRvKA;

		public bool[] DgYGqaifPrMrAFLEdBkWxGdcEZMsB => JeYbPvNAFxzSTpacXVIUsEEfUVXL.Current.effectiveValue;

		public clQCvABmUnORfcnNvPocVVQEyXXX gWRvYlmgsOfUWCPHNMWwYMKbhJaH => wtJZsGrpBpdeajfLWFgGvPasyaBQA;

		public miYcigybCPTrspuzuSiEafduhOCF(anbhbdfzsmouOkCCbStpOglBHmiHb P_0, UpdateLoopSetting P_1)
		{
			SMRTsdAlHeuDLbbqWqOMPvghgyqc = P_0;
			FlqdNFdOvrDMRWbPDYKibeCZeCIIb = P_0.RNKyTXsPFKaezXBNcgSTeyzDkSYD.CVceVtZHyzfaUReonVZsPJOuiPIp;
			JeYbPvNAFxzSTpacXVIUsEEfUVXL = new ButtonLoopSet(P_1, FlqdNFdOvrDMRWbPDYKibeCZeCIIb);
			vcszACjbpCXghBuVolOokMEZYHVD = new DualThreadLowLevelInputEventQueue((int)((float)rGfCWQcoVBNNMLBCPGciUTleuQNNA.jBtHaTgeNpmGYIOhRQexVaFAnUZE * 0.25f), 128, 32, 2);
			wtJZsGrpBpdeajfLWFgGvPasyaBQA = new clQCvABmUnORfcnNvPocVVQEyXXX();
			VivLkBDpMIkLWqoNbaTbjQAPEyvz = new IzQgfDkzjTmspgxWvNpFitmeknESA();
			xizWQmliCfhNeIvlZuCowpbayQAi = new IzQgfDkzjTmspgxWvNpFitmeknESA();
			KmXtnHMMmJOXulkmADcgiwonysrJ = new object();
			if (rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb != null)
			{
				rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent += AZsdycBgEQSuKxKNUARsxjFPKvOO;
			}
		}

		public void jYYGdTdvKUcDWEewFdtVRxjMTMfLB()
		{
			JeYbPvNAFxzSTpacXVIUsEEfUVXL.SetUpdateLoop(ReInput.currentUpdateLoop);
			fptTzIaTgWlUWnkEIiSYrGTYBvCE();
		}

		public void LeyaTusvhDLBuBIdlkMJvmVMafTD()
		{
			JeYbPvNAFxzSTpacXVIUsEEfUVXL.Current.ClearWasTrueThisFrame();
		}

		public void MBLHUatrHowFeYYtjhaeCIONlXyS()
		{
			YgCkTnYyGBIsQibJikAFEZVecWF();
			ujdXNpKBRtsiuzlmyKnAaObpeATgA = true;
		}

		public void tJXVrwETMVDTLIpLkFLlZwzJfJKI()
		{
			ujdXNpKBRtsiuzlmyKnAaObpeATgA = false;
			YgCkTnYyGBIsQibJikAFEZVecWF();
		}

		public void EXPlxRixCcRPLsQmLoftzkcYuHFi(miYcigybCPTrspuzuSiEafduhOCF P_0)
		{
			if (P_0 == null || P_0 == this || P_0.FlqdNFdOvrDMRWbPDYKibeCZeCIIb != FlqdNFdOvrDMRWbPDYKibeCZeCIIb)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (KmXtnHMMmJOXulkmADcgiwonysrJ)
			{
				lock (P_0.KmXtnHMMmJOXulkmADcgiwonysrJ)
				{
					JeYbPvNAFxzSTpacXVIUsEEfUVXL.Import(P_0.JeYbPvNAFxzSTpacXVIUsEEfUVXL);
					wtJZsGrpBpdeajfLWFgGvPasyaBQA.EAoeLdeVuqiwmLjlViiPOPlgvFDmA(P_0.wtJZsGrpBpdeajfLWFgGvPasyaBQA);
					VivLkBDpMIkLWqoNbaTbjQAPEyvz.iDQakQIvEbLIEkPKtqmyoQqaAAlP(P_0.VivLkBDpMIkLWqoNbaTbjQAPEyvz);
					xizWQmliCfhNeIvlZuCowpbayQAi.iDQakQIvEbLIEkPKtqmyoQqaAAlP(P_0.xizWQmliCfhNeIvlZuCowpbayQAi);
					vcszACjbpCXghBuVolOokMEZYHVD.ImportAll(P_0.vcszACjbpCXghBuVolOokMEZYHVD);
					CzYkkAmdWErrMUOTteRuVqLuNHlR = ZnRFLPLytHowXnprFuWRVUHdSnFi.LtWpxfRFjlHonjjiSdbifHtmfhQgA(P_0.CzYkkAmdWErrMUOTteRuVqLuNHlR, VivLkBDpMIkLWqoNbaTbjQAPEyvz);
					ujdXNpKBRtsiuzlmyKnAaObpeATgA = P_0.ujdXNpKBRtsiuzlmyKnAaObpeATgA;
				}
			}
		}

		public void vmRaIOCGjVwGzELXXccmVZrHISOAA(int P_0, int P_1, int P_2, float P_3)
		{
			lock (KmXtnHMMmJOXulkmADcgiwonysrJ)
			{
				CzYkkAmdWErrMUOTteRuVqLuNHlR = new ZnRFLPLytHowXnprFuWRVUHdSnFi(VivLkBDpMIkLWqoNbaTbjQAPEyvz, P_0, P_1, P_2, P_3);
			}
		}

		private void AZsdycBgEQSuKxKNUARsxjFPKvOO()
		{
			if (!ujdXNpKBRtsiuzlmyKnAaObpeATgA)
			{
				return;
			}
			double realTime;
			try
			{
				SMRTsdAlHeuDLbbqWqOMPvghgyqc.yFgeOrOTvKYmoybfKJXBtdrRcEBBA(VivLkBDpMIkLWqoNbaTbjQAPEyvz);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (KmXtnHMMmJOXulkmADcgiwonysrJ)
			{
				if (CzYkkAmdWErrMUOTteRuVqLuNHlR != null)
				{
					CzYkkAmdWErrMUOTteRuVqLuNHlR.EBeGtDJBOXhODEouFbtjtNPROwzhb(realTime);
				}
				if (!VivLkBDpMIkLWqoNbaTbjQAPEyvz.SPqCvGwXtfBzQaVExrtJuSpRmaPJ(xizWQmliCfhNeIvlZuCowpbayQAi))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = vcszACjbpCXghBuVolOokMEZYHVD.T_CreateEvent())
					{
						clQCvABmUnORfcnNvPocVVQEyXXX.OzXUUMHnTXjDonMrTgSYZFpKBjqAA(VivLkBDpMIkLWqoNbaTbjQAPEyvz, realTime, newEventWrapper.Event);
					}
					xizWQmliCfhNeIvlZuCowpbayQAi.iDQakQIvEbLIEkPKtqmyoQqaAAlP(VivLkBDpMIkLWqoNbaTbjQAPEyvz);
				}
			}
		}

		private void fptTzIaTgWlUWnkEIiSYrGTYBvCE()
		{
			while (vcszACjbpCXghBuVolOokMEZYHVD.ProcessNewEvents())
			{
				wtJZsGrpBpdeajfLWFgGvPasyaBQA.KEpOJheQTEAiEuvZrfqKIaUacRMCA(ref vcszACjbpCXghBuVolOokMEZYHVD.currentEvent);
				for (int i = 0; i < FlqdNFdOvrDMRWbPDYKibeCZeCIIb; i++)
				{
					JeYbPvNAFxzSTpacXVIUsEEfUVXL.SetValue(i, wtJZsGrpBpdeajfLWFgGvPasyaBQA.kZmXcOuglSvBieixrgTNwkyaaIgh[i], vcszACjbpCXghBuVolOokMEZYHVD.currentEvent.GetTimestamp());
				}
			}
		}

		private void YgCkTnYyGBIsQibJikAFEZVecWF()
		{
			wtJZsGrpBpdeajfLWFgGvPasyaBQA.ylNhfGEeICZvqlzYShOXEgNwuLnp();
			lock (KmXtnHMMmJOXulkmADcgiwonysrJ)
			{
				VivLkBDpMIkLWqoNbaTbjQAPEyvz.tKisPlxtItMavbxMTWCEDYxudBMl();
				xizWQmliCfhNeIvlZuCowpbayQAi.tKisPlxtItMavbxMTWCEDYxudBMl();
				vcszACjbpCXghBuVolOokMEZYHVD.Clear();
			}
			JeYbPvNAFxzSTpacXVIUsEEfUVXL.Clear();
		}

		public void Dispose()
		{
			LIfyWvgIUeTgLpJRKskbEwYxxSsL(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void OYqIlpgjLCbcdLqpOkzcKbaVpkpD()
		{
			try
			{
				LIfyWvgIUeTgLpJRKskbEwYxxSsL(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void LIfyWvgIUeTgLpJRKskbEwYxxSsL(bool P_0)
		{
			if (!XQodmaifWKtPfRWNVlOWfonRNRvKA)
			{
				if (P_0)
				{
					tJXVrwETMVDTLIpLkFLlZwzJfJKI();
					vcszACjbpCXghBuVolOokMEZYHVD.Dispose();
				}
				if (rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb != null)
				{
					rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent -= AZsdycBgEQSuKxKNUARsxjFPKvOO;
				}
				XQodmaifWKtPfRWNVlOWfonRNRvKA = true;
			}
		}

		private static float xDaBvxJNILVpzmfedxUwIoeCCocI(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class ZnRFLPLytHowXnprFuWRVUHdSnFi
	{
		private IzQgfDkzjTmspgxWvNpFitmeknESA JExGETGgVACDNsFBIuvDqSxYjNwUA;

		private gJyDzIakYZcYDNwmJYjYeNwTTCUF XdLamjcWYGCUNcsYYoENtwTUpGtKA;

		private int YsAeTKByIyDKPumhEjWlDJChwpyQb;

		private int AJHqTZhDTFradqluQoqyqJSTyWjm;

		private int ZNDoMAuZFMTPsViHXfhToXOLlurm;

		private float failOOJSOjzVJsLIovLhPiAVvOZe;

		public IzQgfDkzjTmspgxWvNpFitmeknESA ptldHHhHyjfFqvgdqEtWpaAYkJgw => JExGETGgVACDNsFBIuvDqSxYjNwUA;

		public static ZnRFLPLytHowXnprFuWRVUHdSnFi LtWpxfRFjlHonjjiSdbifHtmfhQgA(ZnRFLPLytHowXnprFuWRVUHdSnFi P_0, IzQgfDkzjTmspgxWvNpFitmeknESA P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new ZnRFLPLytHowXnprFuWRVUHdSnFi(P_0, P_1);
		}

		public ZnRFLPLytHowXnprFuWRVUHdSnFi(IzQgfDkzjTmspgxWvNpFitmeknESA P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			XdLamjcWYGCUNcsYYoENtwTUpGtKA = new gJyDzIakYZcYDNwmJYjYeNwTTCUF(P_0);
			JExGETGgVACDNsFBIuvDqSxYjNwUA = new IzQgfDkzjTmspgxWvNpFitmeknESA();
		}

		private ZnRFLPLytHowXnprFuWRVUHdSnFi(ZnRFLPLytHowXnprFuWRVUHdSnFi P_0, IzQgfDkzjTmspgxWvNpFitmeknESA P_1)
			: this(P_1, P_0.YsAeTKByIyDKPumhEjWlDJChwpyQb, P_0.AJHqTZhDTFradqluQoqyqJSTyWjm, P_0.ZNDoMAuZFMTPsViHXfhToXOLlurm, P_0.failOOJSOjzVJsLIovLhPiAVvOZe)
		{
			EKoeztcRlanXKAFaZuwRXAVVrdGFA(P_0);
		}

		private ZnRFLPLytHowXnprFuWRVUHdSnFi(int P_0, int P_1, int P_2, float P_3)
		{
			YsAeTKByIyDKPumhEjWlDJChwpyQb = P_0;
			AJHqTZhDTFradqluQoqyqJSTyWjm = P_1;
			ZNDoMAuZFMTPsViHXfhToXOLlurm = P_2;
			failOOJSOjzVJsLIovLhPiAVvOZe = P_3;
		}

		public void EBeGtDJBOXhODEouFbtjtNPROwzhb(double P_0)
		{
			XdLamjcWYGCUNcsYYoENtwTUpGtKA.UynwzUvCswIFkcKwcezDFdlDTCfmA(P_0);
			if (!XdLamjcWYGCUNcsYYoENtwTUpGtKA.CVZwAbPuQVbirbHfOjDqCCeKOgIJ)
			{
				if (P_0 >= XdLamjcWYGCUNcsYYoENtwTUpGtKA.DnESWGVQlPWOkOAoiBjvCxANEBCM + (double)failOOJSOjzVJsLIovLhPiAVvOZe)
				{
					JExGETGgVACDNsFBIuvDqSxYjNwUA.tKisPlxtItMavbxMTWCEDYxudBMl();
				}
				return;
			}
			IzQgfDkzjTmspgxWvNpFitmeknESA izQgfDkzjTmspgxWvNpFitmeknESA = XdLamjcWYGCUNcsYYoENtwTUpGtKA.YzbYSemRgHmSxhXILxNexlxlwADJ;
			IzQgfDkzjTmspgxWvNpFitmeknESA izQgfDkzjTmspgxWvNpFitmeknESA2 = XdLamjcWYGCUNcsYYoENtwTUpGtKA.rcvZTMamjRYTUhPlCIfEEOzuinsoA;
			JExGETGgVACDNsFBIuvDqSxYjNwUA.WUWgLBZzdSHtJsNgVyVeDQwQDMRW = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.WUWgLBZzdSHtJsNgVyVeDQwQDMRW);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.fUNSCshvabYYSlFQlEDDDUmcSRCf = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.fUNSCshvabYYSlFQlEDDDUmcSRCf);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.aHBiMKVabkBMSbQQGrPBCusQpIVC = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.aHBiMKVabkBMSbQQGrPBCusQpIVC);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.mSsentqWVPLijLZQEVErZiXebQgbA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.mSsentqWVPLijLZQEVErZiXebQgbA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.nPSRwlwHveRxatrqLvjTXAAAjTnF = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.nPSRwlwHveRxatrqLvjTXAAAjTnF);
			for (int i = 0; i < JExGETGgVACDNsFBIuvDqSxYjNwUA.MqqDNzzWsJtVRfBEbBLJbbOWigtab.Length; i++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i] = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i]);
			}
			for (int j = 0; j < JExGETGgVACDNsFBIuvDqSxYjNwUA.CjEnaageEMHiJpyZhSEjoCRTJnLC.Length; j++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.CjEnaageEMHiJpyZhSEjoCRTJnLC[j] = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.CjEnaageEMHiJpyZhSEjoCRTJnLC[j]);
			}
			for (int k = 0; k < JExGETGgVACDNsFBIuvDqSxYjNwUA.anoDPUijofMmwdpNjuiyAbLOZQHHA.Length; k++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.anoDPUijofMmwdpNjuiyAbLOZQHHA[k] = izQgfDkzjTmspgxWvNpFitmeknESA2.anoDPUijofMmwdpNjuiyAbLOZQHHA[k];
			}
			JExGETGgVACDNsFBIuvDqSxYjNwUA.hmBqYGdIFIdePUrFPzZZvSKRlvhj = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.hmBqYGdIFIdePUrFPzZZvSKRlvhj);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.PQbvBQFGdcURMfrdJVtRGnhlxDtr = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.PQbvBQFGdcURMfrdJVtRGnhlxDtr);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.MKxaZEvsDBDFmBwZWkIYIxFetzTU = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.MKxaZEvsDBDFmBwZWkIYIxFetzTU);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.BmVuNqKTaeQiTMYYJtpHVGAZeCuA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.BmVuNqKTaeQiTMYYJtpHVGAZeCuA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.IJzAPVmvGJgdhcYVscuYBRfPQNVB = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.IJzAPVmvGJgdhcYVscuYBRfPQNVB);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.DPgGRWYyixWRILmRGevGYRmpVyDG = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.DPgGRWYyixWRILmRGevGYRmpVyDG);
			for (int l = 0; l < JExGETGgVACDNsFBIuvDqSxYjNwUA.HJGMEnfWBkObtvxczCvYphWHkrJl.Length; l++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.HJGMEnfWBkObtvxczCvYphWHkrJl[l] = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.HJGMEnfWBkObtvxczCvYphWHkrJl[l]);
			}
			JExGETGgVACDNsFBIuvDqSxYjNwUA.ZWSISyKTeLjkmPOAhDhNtTNqWSkK = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.ZWSISyKTeLjkmPOAhDhNtTNqWSkK);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.AqPEnJCkauiInCatAlJdbEgzSwlub = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.AqPEnJCkauiInCatAlJdbEgzSwlub);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.GPUScCsscLNIRcoqJHnvIlnybxMEA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.GPUScCsscLNIRcoqJHnvIlnybxMEA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.FNcyNtHMLJSpGDmjuZcGnAOcybme = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.FNcyNtHMLJSpGDmjuZcGnAOcybme);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.KwNDwJphpfgBEAPhXLuXstksTVObA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.KwNDwJphpfgBEAPhXLuXstksTVObA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.IvnKtIjEdjPfKVuNMFurlbPxljUX = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.IvnKtIjEdjPfKVuNMFurlbPxljUX);
			for (int m = 0; m < JExGETGgVACDNsFBIuvDqSxYjNwUA.xUnEIVdijlauGELuTyMSTVBiTeTLA.Length; m++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.xUnEIVdijlauGELuTyMSTVBiTeTLA[m] = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.xUnEIVdijlauGELuTyMSTVBiTeTLA[m]);
			}
			JExGETGgVACDNsFBIuvDqSxYjNwUA.xUAFGlHVcGyBvtUiffmwFKMWSbWm = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.xUAFGlHVcGyBvtUiffmwFKMWSbWm);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.BkBETNIjUBRgLbEWfDMqrAXEgFXMA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.BkBETNIjUBRgLbEWfDMqrAXEgFXMA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.rrlBeEqTTHzCvwhQQJNpawJbUjeT = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.rrlBeEqTTHzCvwhQQJNpawJbUjeT);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.OzoapQJHcjKvcMVeKrjMmiZRugnoA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.OzoapQJHcjKvcMVeKrjMmiZRugnoA);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.dDIVAKIHMAzxpflGtoDcFKhPGVEj = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.dDIVAKIHMAzxpflGtoDcFKhPGVEj);
			JExGETGgVACDNsFBIuvDqSxYjNwUA.naCGwGjFoMaMbepAyEeZOBvXRKSOA = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.naCGwGjFoMaMbepAyEeZOBvXRKSOA);
			for (int n = 0; n < JExGETGgVACDNsFBIuvDqSxYjNwUA.cFJbdSIxCCaoqcAbLxjehxKIKZbDA.Length; n++)
			{
				JExGETGgVACDNsFBIuvDqSxYjNwUA.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n] = FWiYCOfmOiLHqqSHwThjVTraLEhT(izQgfDkzjTmspgxWvNpFitmeknESA.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n]);
			}
		}

		public void EKoeztcRlanXKAFaZuwRXAVVrdGFA(ZnRFLPLytHowXnprFuWRVUHdSnFi P_0)
		{
			JExGETGgVACDNsFBIuvDqSxYjNwUA.iDQakQIvEbLIEkPKtqmyoQqaAAlP(P_0.JExGETGgVACDNsFBIuvDqSxYjNwUA);
			XdLamjcWYGCUNcsYYoENtwTUpGtKA.fyQKZvyQCmSNKptsRNFmKHulRxcu(P_0.XdLamjcWYGCUNcsYYoENtwTUpGtKA);
			YsAeTKByIyDKPumhEjWlDJChwpyQb = P_0.YsAeTKByIyDKPumhEjWlDJChwpyQb;
			AJHqTZhDTFradqluQoqyqJSTyWjm = P_0.AJHqTZhDTFradqluQoqyqJSTyWjm;
			ZNDoMAuZFMTPsViHXfhToXOLlurm = P_0.ZNDoMAuZFMTPsViHXfhToXOLlurm;
			failOOJSOjzVJsLIovLhPiAVvOZe = P_0.failOOJSOjzVJsLIovLhPiAVvOZe;
		}

		private int FWiYCOfmOiLHqqSHwThjVTraLEhT(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, YsAeTKByIyDKPumhEjWlDJChwpyQb, AJHqTZhDTFradqluQoqyqJSTyWjm, -65535, 65535);
		}
	}

	private class gJyDzIakYZcYDNwmJYjYeNwTTCUF
	{
		private double JuYsSOgUcEjtQrhDKnGlkUSoDcFS;

		private IzQgfDkzjTmspgxWvNpFitmeknESA PoWscrkwyunFcVIsIqEEWugyDhQQ;

		private IzQgfDkzjTmspgxWvNpFitmeknESA GRjwfHngtXKkiFNmTleFAxWSrqhq;

		private IzQgfDkzjTmspgxWvNpFitmeknESA qbELtakTLSXITGXeDKGBRBPCJTCC;

		private bool fChpzfQmxOYCDEJTGFByIszGfIkA;

		private double dyHhMApbvwesoJIEjTcCJubbgxOmA;

		public IzQgfDkzjTmspgxWvNpFitmeknESA rcvZTMamjRYTUhPlCIfEEOzuinsoA => PoWscrkwyunFcVIsIqEEWugyDhQQ;

		public IzQgfDkzjTmspgxWvNpFitmeknESA YzbYSemRgHmSxhXILxNexlxlwADJ => qbELtakTLSXITGXeDKGBRBPCJTCC;

		public bool CVZwAbPuQVbirbHfOjDqCCeKOgIJ => fChpzfQmxOYCDEJTGFByIszGfIkA;

		public double DnESWGVQlPWOkOAoiBjvCxANEBCM => dyHhMApbvwesoJIEjTcCJubbgxOmA;

		public gJyDzIakYZcYDNwmJYjYeNwTTCUF(IzQgfDkzjTmspgxWvNpFitmeknESA P_0)
		{
			PoWscrkwyunFcVIsIqEEWugyDhQQ = P_0;
			GRjwfHngtXKkiFNmTleFAxWSrqhq = new IzQgfDkzjTmspgxWvNpFitmeknESA();
			qbELtakTLSXITGXeDKGBRBPCJTCC = new IzQgfDkzjTmspgxWvNpFitmeknESA();
		}

		public void UynwzUvCswIFkcKwcezDFdlDTCfmA(double P_0)
		{
			JuYsSOgUcEjtQrhDKnGlkUSoDcFS = P_0;
			qbELtakTLSXITGXeDKGBRBPCJTCC.WUWgLBZzdSHtJsNgVyVeDQwQDMRW = PoWscrkwyunFcVIsIqEEWugyDhQQ.WUWgLBZzdSHtJsNgVyVeDQwQDMRW - GRjwfHngtXKkiFNmTleFAxWSrqhq.WUWgLBZzdSHtJsNgVyVeDQwQDMRW;
			qbELtakTLSXITGXeDKGBRBPCJTCC.fUNSCshvabYYSlFQlEDDDUmcSRCf = PoWscrkwyunFcVIsIqEEWugyDhQQ.fUNSCshvabYYSlFQlEDDDUmcSRCf - GRjwfHngtXKkiFNmTleFAxWSrqhq.fUNSCshvabYYSlFQlEDDDUmcSRCf;
			qbELtakTLSXITGXeDKGBRBPCJTCC.aHBiMKVabkBMSbQQGrPBCusQpIVC = PoWscrkwyunFcVIsIqEEWugyDhQQ.aHBiMKVabkBMSbQQGrPBCusQpIVC - GRjwfHngtXKkiFNmTleFAxWSrqhq.aHBiMKVabkBMSbQQGrPBCusQpIVC;
			qbELtakTLSXITGXeDKGBRBPCJTCC.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA = PoWscrkwyunFcVIsIqEEWugyDhQQ.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA - GRjwfHngtXKkiFNmTleFAxWSrqhq.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.mSsentqWVPLijLZQEVErZiXebQgbA = PoWscrkwyunFcVIsIqEEWugyDhQQ.mSsentqWVPLijLZQEVErZiXebQgbA - GRjwfHngtXKkiFNmTleFAxWSrqhq.mSsentqWVPLijLZQEVErZiXebQgbA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.nPSRwlwHveRxatrqLvjTXAAAjTnF = PoWscrkwyunFcVIsIqEEWugyDhQQ.nPSRwlwHveRxatrqLvjTXAAAjTnF - GRjwfHngtXKkiFNmTleFAxWSrqhq.nPSRwlwHveRxatrqLvjTXAAAjTnF;
			for (int i = 0; i < PoWscrkwyunFcVIsIqEEWugyDhQQ.MqqDNzzWsJtVRfBEbBLJbbOWigtab.Length; i++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i] = PoWscrkwyunFcVIsIqEEWugyDhQQ.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i] - GRjwfHngtXKkiFNmTleFAxWSrqhq.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i];
			}
			for (int j = 0; j < PoWscrkwyunFcVIsIqEEWugyDhQQ.CjEnaageEMHiJpyZhSEjoCRTJnLC.Length; j++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.CjEnaageEMHiJpyZhSEjoCRTJnLC[j] = PoWscrkwyunFcVIsIqEEWugyDhQQ.CjEnaageEMHiJpyZhSEjoCRTJnLC[j] - GRjwfHngtXKkiFNmTleFAxWSrqhq.CjEnaageEMHiJpyZhSEjoCRTJnLC[j];
			}
			for (int k = 0; k < PoWscrkwyunFcVIsIqEEWugyDhQQ.anoDPUijofMmwdpNjuiyAbLOZQHHA.Length; k++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.anoDPUijofMmwdpNjuiyAbLOZQHHA[k] = PoWscrkwyunFcVIsIqEEWugyDhQQ.anoDPUijofMmwdpNjuiyAbLOZQHHA[k] != GRjwfHngtXKkiFNmTleFAxWSrqhq.anoDPUijofMmwdpNjuiyAbLOZQHHA[k];
			}
			qbELtakTLSXITGXeDKGBRBPCJTCC.hmBqYGdIFIdePUrFPzZZvSKRlvhj = PoWscrkwyunFcVIsIqEEWugyDhQQ.hmBqYGdIFIdePUrFPzZZvSKRlvhj - GRjwfHngtXKkiFNmTleFAxWSrqhq.hmBqYGdIFIdePUrFPzZZvSKRlvhj;
			qbELtakTLSXITGXeDKGBRBPCJTCC.PQbvBQFGdcURMfrdJVtRGnhlxDtr = PoWscrkwyunFcVIsIqEEWugyDhQQ.PQbvBQFGdcURMfrdJVtRGnhlxDtr - GRjwfHngtXKkiFNmTleFAxWSrqhq.PQbvBQFGdcURMfrdJVtRGnhlxDtr;
			qbELtakTLSXITGXeDKGBRBPCJTCC.MKxaZEvsDBDFmBwZWkIYIxFetzTU = PoWscrkwyunFcVIsIqEEWugyDhQQ.MKxaZEvsDBDFmBwZWkIYIxFetzTU - GRjwfHngtXKkiFNmTleFAxWSrqhq.MKxaZEvsDBDFmBwZWkIYIxFetzTU;
			qbELtakTLSXITGXeDKGBRBPCJTCC.BmVuNqKTaeQiTMYYJtpHVGAZeCuA = PoWscrkwyunFcVIsIqEEWugyDhQQ.BmVuNqKTaeQiTMYYJtpHVGAZeCuA - GRjwfHngtXKkiFNmTleFAxWSrqhq.BmVuNqKTaeQiTMYYJtpHVGAZeCuA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.IJzAPVmvGJgdhcYVscuYBRfPQNVB = PoWscrkwyunFcVIsIqEEWugyDhQQ.IJzAPVmvGJgdhcYVscuYBRfPQNVB - GRjwfHngtXKkiFNmTleFAxWSrqhq.IJzAPVmvGJgdhcYVscuYBRfPQNVB;
			qbELtakTLSXITGXeDKGBRBPCJTCC.DPgGRWYyixWRILmRGevGYRmpVyDG = PoWscrkwyunFcVIsIqEEWugyDhQQ.DPgGRWYyixWRILmRGevGYRmpVyDG - GRjwfHngtXKkiFNmTleFAxWSrqhq.DPgGRWYyixWRILmRGevGYRmpVyDG;
			for (int l = 0; l < PoWscrkwyunFcVIsIqEEWugyDhQQ.HJGMEnfWBkObtvxczCvYphWHkrJl.Length; l++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.HJGMEnfWBkObtvxczCvYphWHkrJl[l] = PoWscrkwyunFcVIsIqEEWugyDhQQ.HJGMEnfWBkObtvxczCvYphWHkrJl[l] - GRjwfHngtXKkiFNmTleFAxWSrqhq.HJGMEnfWBkObtvxczCvYphWHkrJl[l];
			}
			qbELtakTLSXITGXeDKGBRBPCJTCC.ZWSISyKTeLjkmPOAhDhNtTNqWSkK = PoWscrkwyunFcVIsIqEEWugyDhQQ.ZWSISyKTeLjkmPOAhDhNtTNqWSkK - GRjwfHngtXKkiFNmTleFAxWSrqhq.ZWSISyKTeLjkmPOAhDhNtTNqWSkK;
			qbELtakTLSXITGXeDKGBRBPCJTCC.AqPEnJCkauiInCatAlJdbEgzSwlub = PoWscrkwyunFcVIsIqEEWugyDhQQ.AqPEnJCkauiInCatAlJdbEgzSwlub - GRjwfHngtXKkiFNmTleFAxWSrqhq.AqPEnJCkauiInCatAlJdbEgzSwlub;
			qbELtakTLSXITGXeDKGBRBPCJTCC.GPUScCsscLNIRcoqJHnvIlnybxMEA = PoWscrkwyunFcVIsIqEEWugyDhQQ.GPUScCsscLNIRcoqJHnvIlnybxMEA - GRjwfHngtXKkiFNmTleFAxWSrqhq.GPUScCsscLNIRcoqJHnvIlnybxMEA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.FNcyNtHMLJSpGDmjuZcGnAOcybme = PoWscrkwyunFcVIsIqEEWugyDhQQ.FNcyNtHMLJSpGDmjuZcGnAOcybme - GRjwfHngtXKkiFNmTleFAxWSrqhq.FNcyNtHMLJSpGDmjuZcGnAOcybme;
			qbELtakTLSXITGXeDKGBRBPCJTCC.KwNDwJphpfgBEAPhXLuXstksTVObA = PoWscrkwyunFcVIsIqEEWugyDhQQ.KwNDwJphpfgBEAPhXLuXstksTVObA - GRjwfHngtXKkiFNmTleFAxWSrqhq.KwNDwJphpfgBEAPhXLuXstksTVObA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.IvnKtIjEdjPfKVuNMFurlbPxljUX = PoWscrkwyunFcVIsIqEEWugyDhQQ.IvnKtIjEdjPfKVuNMFurlbPxljUX - GRjwfHngtXKkiFNmTleFAxWSrqhq.IvnKtIjEdjPfKVuNMFurlbPxljUX;
			for (int m = 0; m < PoWscrkwyunFcVIsIqEEWugyDhQQ.xUnEIVdijlauGELuTyMSTVBiTeTLA.Length; m++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.xUnEIVdijlauGELuTyMSTVBiTeTLA[m] = PoWscrkwyunFcVIsIqEEWugyDhQQ.xUnEIVdijlauGELuTyMSTVBiTeTLA[m] - GRjwfHngtXKkiFNmTleFAxWSrqhq.xUnEIVdijlauGELuTyMSTVBiTeTLA[m];
			}
			qbELtakTLSXITGXeDKGBRBPCJTCC.xUAFGlHVcGyBvtUiffmwFKMWSbWm = PoWscrkwyunFcVIsIqEEWugyDhQQ.xUAFGlHVcGyBvtUiffmwFKMWSbWm - GRjwfHngtXKkiFNmTleFAxWSrqhq.xUAFGlHVcGyBvtUiffmwFKMWSbWm;
			qbELtakTLSXITGXeDKGBRBPCJTCC.BkBETNIjUBRgLbEWfDMqrAXEgFXMA = PoWscrkwyunFcVIsIqEEWugyDhQQ.BkBETNIjUBRgLbEWfDMqrAXEgFXMA - GRjwfHngtXKkiFNmTleFAxWSrqhq.BkBETNIjUBRgLbEWfDMqrAXEgFXMA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.rrlBeEqTTHzCvwhQQJNpawJbUjeT = PoWscrkwyunFcVIsIqEEWugyDhQQ.rrlBeEqTTHzCvwhQQJNpawJbUjeT - GRjwfHngtXKkiFNmTleFAxWSrqhq.rrlBeEqTTHzCvwhQQJNpawJbUjeT;
			qbELtakTLSXITGXeDKGBRBPCJTCC.OzoapQJHcjKvcMVeKrjMmiZRugnoA = PoWscrkwyunFcVIsIqEEWugyDhQQ.OzoapQJHcjKvcMVeKrjMmiZRugnoA - GRjwfHngtXKkiFNmTleFAxWSrqhq.OzoapQJHcjKvcMVeKrjMmiZRugnoA;
			qbELtakTLSXITGXeDKGBRBPCJTCC.dDIVAKIHMAzxpflGtoDcFKhPGVEj = PoWscrkwyunFcVIsIqEEWugyDhQQ.dDIVAKIHMAzxpflGtoDcFKhPGVEj - GRjwfHngtXKkiFNmTleFAxWSrqhq.dDIVAKIHMAzxpflGtoDcFKhPGVEj;
			qbELtakTLSXITGXeDKGBRBPCJTCC.naCGwGjFoMaMbepAyEeZOBvXRKSOA = PoWscrkwyunFcVIsIqEEWugyDhQQ.naCGwGjFoMaMbepAyEeZOBvXRKSOA - GRjwfHngtXKkiFNmTleFAxWSrqhq.naCGwGjFoMaMbepAyEeZOBvXRKSOA;
			for (int n = 0; n < PoWscrkwyunFcVIsIqEEWugyDhQQ.cFJbdSIxCCaoqcAbLxjehxKIKZbDA.Length; n++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n] = PoWscrkwyunFcVIsIqEEWugyDhQQ.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n] - GRjwfHngtXKkiFNmTleFAxWSrqhq.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n];
			}
			fChpzfQmxOYCDEJTGFByIszGfIkA = fhRmhpEqbgPJFHzzUuDXifaDMaPb();
			if (fChpzfQmxOYCDEJTGFByIszGfIkA)
			{
				dyHhMApbvwesoJIEjTcCJubbgxOmA = P_0;
				GRjwfHngtXKkiFNmTleFAxWSrqhq.iDQakQIvEbLIEkPKtqmyoQqaAAlP(PoWscrkwyunFcVIsIqEEWugyDhQQ);
			}
		}

		public void fyQKZvyQCmSNKptsRNFmKHulRxcu(gJyDzIakYZcYDNwmJYjYeNwTTCUF P_0)
		{
			JuYsSOgUcEjtQrhDKnGlkUSoDcFS = P_0.JuYsSOgUcEjtQrhDKnGlkUSoDcFS;
			GRjwfHngtXKkiFNmTleFAxWSrqhq.iDQakQIvEbLIEkPKtqmyoQqaAAlP(P_0.GRjwfHngtXKkiFNmTleFAxWSrqhq);
			qbELtakTLSXITGXeDKGBRBPCJTCC.iDQakQIvEbLIEkPKtqmyoQqaAAlP(P_0.qbELtakTLSXITGXeDKGBRBPCJTCC);
		}

		private bool fhRmhpEqbgPJFHzzUuDXifaDMaPb()
		{
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.fUNSCshvabYYSlFQlEDDDUmcSRCf != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.aHBiMKVabkBMSbQQGrPBCusQpIVC != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.mSsentqWVPLijLZQEVErZiXebQgbA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.nPSRwlwHveRxatrqLvjTXAAAjTnF != 0)
			{
				return true;
			}
			for (int i = 0; i < PoWscrkwyunFcVIsIqEEWugyDhQQ.MqqDNzzWsJtVRfBEbBLJbbOWigtab.Length; i++)
			{
				if (qbELtakTLSXITGXeDKGBRBPCJTCC.MqqDNzzWsJtVRfBEbBLJbbOWigtab[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < PoWscrkwyunFcVIsIqEEWugyDhQQ.CjEnaageEMHiJpyZhSEjoCRTJnLC.Length; j++)
			{
				if (qbELtakTLSXITGXeDKGBRBPCJTCC.CjEnaageEMHiJpyZhSEjoCRTJnLC[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < PoWscrkwyunFcVIsIqEEWugyDhQQ.anoDPUijofMmwdpNjuiyAbLOZQHHA.Length; k++)
			{
				if (qbELtakTLSXITGXeDKGBRBPCJTCC.anoDPUijofMmwdpNjuiyAbLOZQHHA[k])
				{
					return true;
				}
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.hmBqYGdIFIdePUrFPzZZvSKRlvhj != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.PQbvBQFGdcURMfrdJVtRGnhlxDtr != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.MKxaZEvsDBDFmBwZWkIYIxFetzTU != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.BmVuNqKTaeQiTMYYJtpHVGAZeCuA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.IJzAPVmvGJgdhcYVscuYBRfPQNVB != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.DPgGRWYyixWRILmRGevGYRmpVyDG != 0)
			{
				return true;
			}
			for (int l = 0; l < PoWscrkwyunFcVIsIqEEWugyDhQQ.HJGMEnfWBkObtvxczCvYphWHkrJl.Length; l++)
			{
				if (qbELtakTLSXITGXeDKGBRBPCJTCC.HJGMEnfWBkObtvxczCvYphWHkrJl[l] != 0)
				{
					return true;
				}
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.ZWSISyKTeLjkmPOAhDhNtTNqWSkK != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.AqPEnJCkauiInCatAlJdbEgzSwlub != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.GPUScCsscLNIRcoqJHnvIlnybxMEA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.FNcyNtHMLJSpGDmjuZcGnAOcybme != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.KwNDwJphpfgBEAPhXLuXstksTVObA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.IvnKtIjEdjPfKVuNMFurlbPxljUX != 0)
			{
				return true;
			}
			for (int m = 0; m < PoWscrkwyunFcVIsIqEEWugyDhQQ.xUnEIVdijlauGELuTyMSTVBiTeTLA.Length; m++)
			{
				qbELtakTLSXITGXeDKGBRBPCJTCC.xUnEIVdijlauGELuTyMSTVBiTeTLA[m] = PoWscrkwyunFcVIsIqEEWugyDhQQ.xUnEIVdijlauGELuTyMSTVBiTeTLA[m] - GRjwfHngtXKkiFNmTleFAxWSrqhq.xUnEIVdijlauGELuTyMSTVBiTeTLA[m];
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.xUAFGlHVcGyBvtUiffmwFKMWSbWm != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.BkBETNIjUBRgLbEWfDMqrAXEgFXMA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.rrlBeEqTTHzCvwhQQJNpawJbUjeT != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.OzoapQJHcjKvcMVeKrjMmiZRugnoA != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.dDIVAKIHMAzxpflGtoDcFKhPGVEj != 0)
			{
				return true;
			}
			if (qbELtakTLSXITGXeDKGBRBPCJTCC.naCGwGjFoMaMbepAyEeZOBvXRKSOA != 0)
			{
				return true;
			}
			for (int n = 0; n < PoWscrkwyunFcVIsIqEEWugyDhQQ.cFJbdSIxCCaoqcAbLxjehxKIKZbDA.Length; n++)
			{
				if (qbELtakTLSXITGXeDKGBRBPCJTCC.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class mYRirIvxKYeZcyLdCDuGXxEsCFdr
	{
		public enum MsMkfkBktchgiKDqxGLNwRXVRExk
		{
			Exact = 0,
			Approximate = 1
		}

		public class mFlYVhbmAaiZraQZlDtkVCJYKPHwA
		{
			public int KmTsXfbTKeIVvXSfdELoyOjRGNHq;

			public Guid WYHBnCUrJpvvApMcOBGOOXchqzhl;

			public Guid SDpEMRIJTCAVARxDHRHEKTsaveak;

			public int HPAJiXdxFAFQDOVwkJSjMHIVclrK;

			public int GXAYpCwqPnFSwHuJHpsUyjZremSw;

			public int zEqSiPbWVpjSANOmoekLIPbtoMcuA;

			public int YWtNYhRavnXTOckvdJirerhncPPb;

			public bool RMAKUjWiqAGBEfQLcFoyLCYGIKxuA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, MsMkfkBktchgiKDqxGLNwRXVRExk P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == KmTsXfbTKeIVvXSfdELoyOjRGNHq)
				{
					return true;
				}
				if (GXAYpCwqPnFSwHuJHpsUyjZremSw != P_0.JiDYAISMELSdeAeNTOpuFUNqNoeA)
				{
					return false;
				}
				if (zEqSiPbWVpjSANOmoekLIPbtoMcuA != P_0.XgOfIkiRHnILohqIHAYoSyoaJzGm)
				{
					return false;
				}
				if (YWtNYhRavnXTOckvdJirerhncPPb != P_0.GbjktuKNCSrBbfYrJsiehchCrjiu)
				{
					return false;
				}
				return P_1 switch
				{
					MsMkfkBktchgiKDqxGLNwRXVRExk.Exact => WYHBnCUrJpvvApMcOBGOOXchqzhl == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					MsMkfkBktchgiKDqxGLNwRXVRExk.Approximate => SDpEMRIJTCAVARxDHRHEKTsaveak == P_0.XSFoSrQpBibIEVzUoZjAOKiFEFuj, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string IsQFEOqrrewLWGLBTUhDdlFgTuBB()
			{
				string text = "" + "rewiredId = " + KmTsXfbTKeIVvXSfdELoyOjRGNHq + "\n";
				Guid wYHBnCUrJpvvApMcOBGOOXchqzhl = WYHBnCUrJpvvApMcOBGOOXchqzhl;
				string text2 = text + "instanceGuid = " + wYHBnCUrJpvvApMcOBGOOXchqzhl.ToString() + "\n";
				wYHBnCUrJpvvApMcOBGOOXchqzhl = SDpEMRIJTCAVARxDHRHEKTsaveak;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + wYHBnCUrJpvvApMcOBGOOXchqzhl.ToString() + "\n", "lastInputManagerId = ", HPAJiXdxFAFQDOVwkJSjMHIVclrK.ToString(), "\n"), "hardwareAxisCount = ", GXAYpCwqPnFSwHuJHpsUyjZremSw.ToString(), "\n"), "hardwareButtonCount = ", zEqSiPbWVpjSANOmoekLIPbtoMcuA.ToString(), "\n"), "hardwareHatCount = ", YWtNYhRavnXTOckvdJirerhncPPb.ToString(), "\n");
			}
		}

		private sealed class SgoFLhaysCxYrhvoATCsrrbKOyhdb : IEnumerable<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>, IEnumerable, IEnumerator<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>, IEnumerator, IDisposable
		{
			private int IUgVXZWrUvKCKrrrcdZZoRZVfZck;

			private mFlYVhbmAaiZraQZlDtkVCJYKPHwA KEvLBJcAmNYhIIXuPeDmekZiBpQD;

			private int TdeJccvFAIdNYhaOvhZBvAxyuiUvA;

			public mYRirIvxKYeZcyLdCDuGXxEsCFdr dLWqBYqFqymjeLFwgksMwkoaGmjn;

			private GdZLnXxkOIHlKtGBscttffEFwmuN VaWtULBBqKjqdAkfCleaAHbIDlhQ;

			public GdZLnXxkOIHlKtGBscttffEFwmuN gdTqpsqGlUaEBoErCWNATmVYMPXI;

			private MsMkfkBktchgiKDqxGLNwRXVRExk KVabvoPwOoiJJETNujgQBGxeeufDA;

			public MsMkfkBktchgiKDqxGLNwRXVRExk LsParNyScnLJPTzZgOyOMqyQmDpe;

			private int BvoakPETJYLyhUcRIFHsLLdJVymU;

			private int sHkytTddsROOXPWwQrNsWzdRluFu;

			mFlYVhbmAaiZraQZlDtkVCJYKPHwA IEnumerator<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>.Current
			{
				[DebuggerHidden]
				get
				{
					return KEvLBJcAmNYhIIXuPeDmekZiBpQD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KEvLBJcAmNYhIIXuPeDmekZiBpQD;
				}
			}

			[DebuggerHidden]
			public SgoFLhaysCxYrhvoATCsrrbKOyhdb(int P_0)
			{
				IUgVXZWrUvKCKrrrcdZZoRZVfZck = P_0;
				TdeJccvFAIdNYhaOvhZBvAxyuiUvA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				IUgVXZWrUvKCKrrrcdZZoRZVfZck = -2;
			}

			private bool MoveNext()
			{
				int iUgVXZWrUvKCKrrrcdZZoRZVfZck = IUgVXZWrUvKCKrrrcdZZoRZVfZck;
				mYRirIvxKYeZcyLdCDuGXxEsCFdr mYRirIvxKYeZcyLdCDuGXxEsCFdr2 = dLWqBYqFqymjeLFwgksMwkoaGmjn;
				if (iUgVXZWrUvKCKrrrcdZZoRZVfZck != 0)
				{
					if (iUgVXZWrUvKCKrrrcdZZoRZVfZck != 1)
					{
						return false;
					}
					IUgVXZWrUvKCKrrrcdZZoRZVfZck = -1;
					goto IL_0083;
				}
				IUgVXZWrUvKCKrrrcdZZoRZVfZck = -1;
				BvoakPETJYLyhUcRIFHsLLdJVymU = mYRirIvxKYeZcyLdCDuGXxEsCFdr2.JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count;
				sHkytTddsROOXPWwQrNsWzdRluFu = 0;
				goto IL_0093;
				IL_0083:
				sHkytTddsROOXPWwQrNsWzdRluFu++;
				goto IL_0093;
				IL_0093:
				if (sHkytTddsROOXPWwQrNsWzdRluFu < BvoakPETJYLyhUcRIFHsLLdJVymU)
				{
					if (mYRirIvxKYeZcyLdCDuGXxEsCFdr2.JPyGhwHNiBGNdycoXKxeKVelgRBmA[sHkytTddsROOXPWwQrNsWzdRluFu].RMAKUjWiqAGBEfQLcFoyLCYGIKxuA(VaWtULBBqKjqdAkfCleaAHbIDlhQ, KVabvoPwOoiJJETNujgQBGxeeufDA))
					{
						KEvLBJcAmNYhIIXuPeDmekZiBpQD = mYRirIvxKYeZcyLdCDuGXxEsCFdr2.JPyGhwHNiBGNdycoXKxeKVelgRBmA[sHkytTddsROOXPWwQrNsWzdRluFu];
						IUgVXZWrUvKCKrrrcdZZoRZVfZck = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<mFlYVhbmAaiZraQZlDtkVCJYKPHwA> IEnumerable<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>.GetEnumerator()
			{
				SgoFLhaysCxYrhvoATCsrrbKOyhdb sgoFLhaysCxYrhvoATCsrrbKOyhdb;
				if (IUgVXZWrUvKCKrrrcdZZoRZVfZck == -2 && TdeJccvFAIdNYhaOvhZBvAxyuiUvA == Environment.CurrentManagedThreadId)
				{
					IUgVXZWrUvKCKrrrcdZZoRZVfZck = 0;
					sgoFLhaysCxYrhvoATCsrrbKOyhdb = this;
				}
				else
				{
					sgoFLhaysCxYrhvoATCsrrbKOyhdb = new SgoFLhaysCxYrhvoATCsrrbKOyhdb(0);
					sgoFLhaysCxYrhvoATCsrrbKOyhdb.dLWqBYqFqymjeLFwgksMwkoaGmjn = dLWqBYqFqymjeLFwgksMwkoaGmjn;
				}
				sgoFLhaysCxYrhvoATCsrrbKOyhdb.VaWtULBBqKjqdAkfCleaAHbIDlhQ = gdTqpsqGlUaEBoErCWNATmVYMPXI;
				sgoFLhaysCxYrhvoATCsrrbKOyhdb.KVabvoPwOoiJJETNujgQBGxeeufDA = LsParNyScnLJPTzZgOyOMqyQmDpe;
				return sgoFLhaysCxYrhvoATCsrrbKOyhdb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>)this).GetEnumerator();
			}
		}

		private List<mFlYVhbmAaiZraQZlDtkVCJYKPHwA> JPyGhwHNiBGNdycoXKxeKVelgRBmA;

		public mYRirIvxKYeZcyLdCDuGXxEsCFdr()
		{
			JPyGhwHNiBGNdycoXKxeKVelgRBmA = new List<mFlYVhbmAaiZraQZlDtkVCJYKPHwA>();
		}

		public void WGuGmyGcyrohZXoeBqYwkCxjJuoAA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count;
			for (int i = 0; i < count; i++)
			{
				if (JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].RMAKUjWiqAGBEfQLcFoyLCYGIKxuA(P_0, MsMkfkBktchgiKDqxGLNwRXVRExk.Exact))
				{
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].KmTsXfbTKeIVvXSfdELoyOjRGNHq = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].WYHBnCUrJpvvApMcOBGOOXchqzhl = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].SDpEMRIJTCAVARxDHRHEKTsaveak = P_0.XSFoSrQpBibIEVzUoZjAOKiFEFuj;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].HPAJiXdxFAFQDOVwkJSjMHIVclrK = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].GXAYpCwqPnFSwHuJHpsUyjZremSw = P_0.JiDYAISMELSdeAeNTOpuFUNqNoeA;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].zEqSiPbWVpjSANOmoekLIPbtoMcuA = P_0.XgOfIkiRHnILohqIHAYoSyoaJzGm;
					JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].YWtNYhRavnXTOckvdJirerhncPPb = P_0.GbjktuKNCSrBbfYrJsiehchCrjiu;
					WBAgfYjlMQZYOdREVjvXgjWwwzhsA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			JPyGhwHNiBGNdycoXKxeKVelgRBmA.Add(new mFlYVhbmAaiZraQZlDtkVCJYKPHwA
			{
				KmTsXfbTKeIVvXSfdELoyOjRGNHq = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				WYHBnCUrJpvvApMcOBGOOXchqzhl = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				SDpEMRIJTCAVARxDHRHEKTsaveak = P_0.XSFoSrQpBibIEVzUoZjAOKiFEFuj,
				HPAJiXdxFAFQDOVwkJSjMHIVclrK = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				GXAYpCwqPnFSwHuJHpsUyjZremSw = P_0.JiDYAISMELSdeAeNTOpuFUNqNoeA,
				zEqSiPbWVpjSANOmoekLIPbtoMcuA = P_0.XgOfIkiRHnILohqIHAYoSyoaJzGm,
				YWtNYhRavnXTOckvdJirerhncPPb = P_0.GbjktuKNCSrBbfYrJsiehchCrjiu
			});
			WBAgfYjlMQZYOdREVjvXgjWwwzhsA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count - 1);
		}

		public bool VLUQDhXLXLiqXQkeRHMVDCxVRnJxA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, MsMkfkBktchgiKDqxGLNwRXVRExk P_1)
		{
			int count = JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count;
			for (int i = 0; i < count; i++)
			{
				if (JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].RMAKUjWiqAGBEfQLcFoyLCYGIKxuA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(SgoFLhaysCxYrhvoATCsrrbKOyhdb))]
		public IEnumerable<mFlYVhbmAaiZraQZlDtkVCJYKPHwA> eMUDzblCzqzldkfEcdZCVuFTgMYAA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, MsMkfkBktchgiKDqxGLNwRXVRExk P_1)
		{
			return new SgoFLhaysCxYrhvoATCsrrbKOyhdb(-2)
			{
				dLWqBYqFqymjeLFwgksMwkoaGmjn = this,
				gdTqpsqGlUaEBoErCWNATmVYMPXI = P_0,
				LsParNyScnLJPTzZgOyOMqyQmDpe = P_1
			};
		}

		private void WBAgfYjlMQZYOdREVjvXgjWwwzhsA(int P_0, Guid P_1, int P_2)
		{
			for (int num = JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (JPyGhwHNiBGNdycoXKxeKVelgRBmA[num].KmTsXfbTKeIVvXSfdELoyOjRGNHq == P_0 || JPyGhwHNiBGNdycoXKxeKVelgRBmA[num].WYHBnCUrJpvvApMcOBGOOXchqzhl == P_1))
				{
					JPyGhwHNiBGNdycoXKxeKVelgRBmA.RemoveAt(num);
				}
			}
		}

		public virtual string ayIfmFBoaQRgRTjFSCqEhnvUHCs()
		{
			string text = "";
			text = text + "Joystick records: " + JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count + "\n";
			for (int i = 0; i < JPyGhwHNiBGNdycoXKxeKVelgRBmA.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + JPyGhwHNiBGNdycoXKxeKVelgRBmA[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class ydNKRIYeuXbhtmYNoJRVJHgBmzFj
	{
		public GdZLnXxkOIHlKtGBscttffEFwmuN gulceYKVuRzFgfRxsdKZzWtZCoTy;

		public oAfWbvFtzBgLaRIiknILWPaYvJGR wgnJJfKJEciviDkRyxWhIRdBSsHEA;

		public bool xqgQSpNTaieCxJJnTjQyRxMNokUi
		{
			get
			{
				if (gulceYKVuRzFgfRxsdKZzWtZCoTy != null)
				{
					return wgnJJfKJEciviDkRyxWhIRdBSsHEA != null;
				}
				return false;
			}
		}

		public ydNKRIYeuXbhtmYNoJRVJHgBmzFj(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, oAfWbvFtzBgLaRIiknILWPaYvJGR P_1)
		{
			gulceYKVuRzFgfRxsdKZzWtZCoTy = P_0;
			wgnJJfKJEciviDkRyxWhIRdBSsHEA = P_1;
		}

		public static List<oAfWbvFtzBgLaRIiknILWPaYvJGR> iNMVAQyLGgxBcgTGdOogBzdJfSQJ(List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> P_0)
		{
			if (P_0 == null)
			{
				return new List<oAfWbvFtzBgLaRIiknILWPaYvJGR>();
			}
			List<oAfWbvFtzBgLaRIiknILWPaYvJGR> list = new List<oAfWbvFtzBgLaRIiknILWPaYvJGR>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].xqgQSpNTaieCxJJnTjQyRxMNokUi)
				{
					list.Add(P_0[i].wgnJJfKJEciviDkRyxWhIRdBSsHEA);
				}
			}
			return list;
		}
	}

	private class teeQIucgAszJhwMqJPHjdyptwaMj
	{
		public anbhbdfzsmouOkCCbStpOglBHmiHb AQQORgGyOyRvOvLhgbwaktjUzzom;

		public teeQIucgAszJhwMqJPHjdyptwaMj(anbhbdfzsmouOkCCbStpOglBHmiHb P_0)
		{
			AQQORgGyOyRvOvLhgbwaktjUzzom = P_0;
		}
	}

	private class BytfgteDcFlkvdXfaxfzmvlctRTFb
	{
		private mzqJTIdBsSUaygbgcyoEGageZZMf.SmZogzZkPKHtAJEUsEWRKgBhNyLZ tYpdtGBgttnAefxqGyryJryCZfnlB;

		private mzqJTIdBsSUaygbgcyoEGageZZMf.fxibodRAoVCBTkrLfCxHBSejkfdBc pALsvDNMzJMiVMJPjCfSxjVhmVRW;

		private NativeBuffer LCFoXOlthNgyHYMlTjtAQzNBOwRB;

		private int wcDAHqqyNTCYkeWfnyIrajISkUxF;

		public BytfgteDcFlkvdXfaxfzmvlctRTFb()
		{
			tYpdtGBgttnAefxqGyryJryCZfnlB = new mzqJTIdBsSUaygbgcyoEGageZZMf.SmZogzZkPKHtAJEUsEWRKgBhNyLZ
			{
				AnQWYVWnriemQpdcMFRIJGkImNusA = (uint)Marshal.SizeOf(typeof(mzqJTIdBsSUaygbgcyoEGageZZMf.SmZogzZkPKHtAJEUsEWRKgBhNyLZ)),
				KzQhoiFNwGAerDrnPhmljGAiuPZOB = true,
				OdTmdwZMeDSCQHtXXPUslOMXHcbfA = true,
				KdRpIuGWAJuXOgMEkqRfirsJsAZV = false,
				KiqBCwcLIcimZYlRVHHatXkzlNRB = true,
				NezAWcIRUEQfdmoiznzotJsPaTsk = IntPtr.Zero
			};
			pALsvDNMzJMiVMJPjCfSxjVhmVRW = mzqJTIdBsSUaygbgcyoEGageZZMf.fxibodRAoVCBTkrLfCxHBSejkfdBc.qxeJFbQwAhlfgbnHqLlCepOGuAKv();
			LCFoXOlthNgyHYMlTjtAQzNBOwRB = new NativeBuffer((int)pALsvDNMzJMiVMJPjCfSxjVhmVRW.VOQakwlhgOQTpesWrDrYgleYHVGh);
			LCFoXOlthNgyHYMlTjtAQzNBOwRB.Write(pALsvDNMzJMiVMJPjCfSxjVhmVRW.VOQakwlhgOQTpesWrDrYgleYHVGh, 0);
		}

		public bool BVqqjNaDAEKKTIvWCfUmPCCKuoTs()
		{
			int num = kMMTORQxVdGqgaIVZgAivwguywxL();
			if (num == wcDAHqqyNTCYkeWfnyIrajISkUxF)
			{
				return false;
			}
			wcDAHqqyNTCYkeWfnyIrajISkUxF = num;
			return true;
		}

		public void ZXrRzuzsqvMTXdHHurQcWLDTDVDeA(int P_0)
		{
			wcDAHqqyNTCYkeWfnyIrajISkUxF = P_0;
		}

		private int kMMTORQxVdGqgaIVZgAivwguywxL()
		{
			try
			{
				return hvnhVrGGJGHgzOeFnMnHvVzmekkF.sjGPOqoKqLiRcQgeTMuhoulFHzjC(ref tYpdtGBgttnAefxqGyryJryCZfnlB, LCFoXOlthNgyHYMlTjtAQzNBOwRB);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum xCjHMUlKilLbcWgIcpQhdLGbHDVD
	{
		Device = 17,
		Mouse = 18,
		Keyboard = 19,
		Joystick = 20,
		Gamepad = 21,
		Driving = 22,
		Flight = 23,
		FirstPerson = 24,
		ControlDevice = 25,
		ScreenPointer = 26,
		Remote = 27,
		Supplemental = 28
	}

	private const OaagXIZrfeDFhvWXSIZbhwFlMfQK WzFjduQYcQayfKQhqaHxlTGmcJTJ = OaagXIZrfeDFhvWXSIZbhwFlMfQK.GameControl;

	private const eMAFjwbvQxnHIqzOYhMTOmlFgCfn epxsBnBzIFLUSpaxEaSZiZPnBYwwA = eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly;

	private IntPtr myeFmjJQhIPbFgvBhgWMMLdyLnnz;

	private tQhzEkPAiyaHrgrdhRCmrtbuAchaA MntsIiOQXRwAjiesZYnwoFuvxhZD;

	private List<GdZLnXxkOIHlKtGBscttffEFwmuN> tGeHaThAikyMDQdfvDNHjaHkxmpGA;

	private int LeHRQkaWUXTgOCWXeJUJmqjGMspm;

	private mYRirIvxKYeZcyLdCDuGXxEsCFdr dHoddqgfyBkzbXxHAwXgokuuapKr;

	private bool LTyMIEAStXlcFivCqtWZXeFmwOxU;

	private tfBBbpYawsTqFdIUEKOlukvpcHoaA qcUcfBugPNjTCmMJBGZZqPaMAntbA;

	private UpdateLoopSetting PSYCrPHvrwFpnyKUwbpihSDkazxbA;

	private Action<int, ControllerDataUpdater> XdkIevyODqilRHDgBkdEcVZbzZHFA;

	private PlatformInputManager RvAMLyQqPUWwbOBizKMzrmpmSgOv;

	private TimerRealTime fgbisdHFYfLRknyQsaneduohWzMOA;

	private global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool> rRhIHTkkntDGrALXAyJwPrdCRLdl;

	private BytfgteDcFlkvdXfaxfzmvlctRTFb zbXNBPROrsuOBugVZAaJLWKgsiXy;

	private int VlkBTFiESCDBQyPzzaUgpxAZZjxpA;

	private int WIuxKGvHlUWNkojbGaYwwgActvwj;

	private global::McjQlNxEMWbTtbUlrizSwucUAAoO<List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj>> qiSGCOcnWVBgntYjpTxQcHoPkXsL;

	private readonly object gnTfenSLfpxNPsPeQoIWlaNxhjOp = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> UOAdUloIrGLNsyiyZJiswlDvPHmu;

	private Func<int> xnrnpxhkNqWgcYILtdLEhEmRJGXbb;

	tfBBbpYawsTqFdIUEKOlukvpcHoaA pSdznuaGwmothEGkyHtMJwPUSUzT.wbjsmIpoJYIDLciADgGvDfNBzFtGA
	{
		get
		{
			return qcUcfBugPNjTCmMJBGZZqPaMAntbA;
		}
		set
		{
			qcUcfBugPNjTCmMJBGZZqPaMAntbA = tfBBbpYawsTqFdIUEKOlukvpcHoaA2;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => LeHRQkaWUXTgOCWXeJUJmqjGMspm;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => RvAMLyQqPUWwbOBizKMzrmpmSgOv;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<tQhzEkPAiyaHrgrdhRCmrtbuAchaA>(MntsIiOQXRwAjiesZYnwoFuvxhZD);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public CyxJdhjfOICWqWzXlokNuHzoKvmJ(UpdateLoopSetting P_0, tfBBbpYawsTqFdIUEKOlukvpcHoaA P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			PSYCrPHvrwFpnyKUwbpihSDkazxbA = P_0;
			qcUcfBugPNjTCmMJBGZZqPaMAntbA = P_1;
			myeFmjJQhIPbFgvBhgWMMLdyLnnz = P_2;
			UOAdUloIrGLNsyiyZJiswlDvPHmu = P_3;
			xnrnpxhkNqWgcYILtdLEhEmRJGXbb = P_4;
			RvAMLyQqPUWwbOBizKMzrmpmSgOv = this;
			MntsIiOQXRwAjiesZYnwoFuvxhZD = new tQhzEkPAiyaHrgrdhRCmrtbuAchaA();
			XdkIevyODqilRHDgBkdEcVZbzZHFA = UpdateControllerData;
			zbXNBPROrsuOBugVZAaJLWKgsiXy = new BytfgteDcFlkvdXfaxfzmvlctRTFb();
			rRhIHTkkntDGrALXAyJwPrdCRLdl = new global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool>(true, kpobKVQDSiwYRkGXhDjFuXocpIRn);
			qiSGCOcnWVBgntYjpTxQcHoPkXsL = new global::McjQlNxEMWbTtbUlrizSwucUAAoO<List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj>>(true, () => nxMTeenHsBcCEdzSmrqHlibMiYzbb());
			lewfEFBiZdwSCFKqpzgboZwTICMr();
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		dHoddqgfyBkzbXxHAwXgokuuapKr = new mYRirIvxKYeZcyLdCDuGXxEsCFdr();
		fgbisdHFYfLRknyQsaneduohWzMOA = new TimerRealTime(1.0);
		fgbisdHFYfLRknyQsaneduohWzMOA.Start();
		NPBgWxGmwWFBCKDvcfUeRIlmjIOL();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		GljjeacqQKcpqfPixSDAPFqvqFgnA();
		tkLVEbzNfUThkgHkQePkRrjiYHQF();
		wbwpbnCZqjBgdiLAVaxCeEQBabKD();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (qiSGCOcnWVBgntYjpTxQcHoPkXsL != null)
		{
			qiSGCOcnWVBgntYjpTxQcHoPkXsL.mkQAsPQkdBLuRVdsGBfjsPGJgaIJ();
		}
		if (rRhIHTkkntDGrALXAyJwPrdCRLdl != null)
		{
			rRhIHTkkntDGrALXAyJwPrdCRLdl.mkQAsPQkdBLuRVdsGBfjsPGJgaIJ();
		}
		if (tGeHaThAikyMDQdfvDNHjaHkxmpGA == null)
		{
			return;
		}
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			for (int i = 0; i < tGeHaThAikyMDQdfvDNHjaHkxmpGA.Count; i++)
			{
				if (tGeHaThAikyMDQdfvDNHjaHkxmpGA[i] != null)
				{
					tGeHaThAikyMDQdfvDNHjaHkxmpGA[i].zvcAaTinHbWaTgbXXGvbDfBdkwGTb();
					tGeHaThAikyMDQdfvDNHjaHkxmpGA[i].xTFhmkzjUzmmKDShwvmePLldyNBi();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return XdkIevyODqilRHDgBkdEcVZbzZHFA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			for (int i = 0; i < LeHRQkaWUXTgOCWXeJUJmqjGMspm; i++)
			{
				if (tGeHaThAikyMDQdfvDNHjaHkxmpGA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					tGeHaThAikyMDQdfvDNHjaHkxmpGA[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		LTyMIEAStXlcFivCqtWZXeFmwOxU = true;
		fgbisdHFYfLRknyQsaneduohWzMOA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		LTyMIEAStXlcFivCqtWZXeFmwOxU = true;
		fgbisdHFYfLRknyQsaneduohWzMOA.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void GljjeacqQKcpqfPixSDAPFqvqFgnA()
	{
		if (rRhIHTkkntDGrALXAyJwPrdCRLdl.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
		{
			if (rRhIHTkkntDGrALXAyJwPrdCRLdl.hRRQBhRlrNLlIwAAvCWMAegGhfdIA() && !fgbisdHFYfLRknyQsaneduohWzMOA.running && !qiSGCOcnWVBgntYjpTxQcHoPkXsL.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
			{
				if (rRhIHTkkntDGrALXAyJwPrdCRLdl.pIVDjHonGkoGmUlIarmyWTCFlTfh)
				{
					LTyMIEAStXlcFivCqtWZXeFmwOxU = true;
				}
				fgbisdHFYfLRknyQsaneduohWzMOA.Start();
			}
		}
		else if (!fgbisdHFYfLRknyQsaneduohWzMOA.running)
		{
			fgbisdHFYfLRknyQsaneduohWzMOA.Start();
		}
		else if (fgbisdHFYfLRknyQsaneduohWzMOA.Update())
		{
			rRhIHTkkntDGrALXAyJwPrdCRLdl.ZRNxDcQZRiFYRKxfnaKLNAFnscDt();
		}
	}

	private List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> nxMTeenHsBcCEdzSmrqHlibMiYzbb()
	{
		List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> list = new List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj>();
		IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> list2 = MkVWIuqrRTXKJDteCchztJOFzxCJ();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				oAfWbvFtzBgLaRIiknILWPaYvJGR oAfWbvFtzBgLaRIiknILWPaYvJGR2 = list2[i];
				Guid kzwkcdaJgmrrHxFfbAIZCYxqvfXZ = oAfWbvFtzBgLaRIiknILWPaYvJGR2.KzwkcdaJgmrrHxFfbAIZCYxqvfXZ;
				anbhbdfzsmouOkCCbStpOglBHmiHb anbhbdfzsmouOkCCbStpOglBHmiHb2 = new anbhbdfzsmouOkCCbStpOglBHmiHb(MntsIiOQXRwAjiesZYnwoFuvxhZD, kzwkcdaJgmrrHxFfbAIZCYxqvfXZ);
				JtIbPdmTCYIpHnAGxmTzjBkAaONU jtIbPdmTCYIpHnAGxmTzjBkAaONU = anbhbdfzsmouOkCCbStpOglBHmiHb2.hVGspDTKQbBpKbSbBEbmoAmxyKlmA;
				if (qcUcfBugPNjTCmMJBGZZqPaMAntbA == null)
				{
					goto IL_00bd;
				}
				string text = oAfWbvFtzBgLaRIiknILWPaYvJGR2.yPlEBmQDdIgFczWAPigatngdjYFF.ToString();
				if (!qcUcfBugPNjTCmMJBGZZqPaMAntbA.NCxLQazZbCIdTfBuyhxxqLbZdkdB(jtIbPdmTCYIpHnAGxmTzjBkAaONU.rkWuVsHOLGNOufCAarCQDPzfHNbX, StringTools.SanitizeDeviceString(oAfWbvFtzBgLaRIiknILWPaYvJGR2.psVmskHZzblxuamlundDsEQNHEjW), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (phxLYZaFXEdPcKesDYFkQObzzCot.XhDVEHkaYdfdRoDEaWPBndRzzedc(InputSource.DirectInput, (ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.MdHkuOXVoHvIuHjZLCewaiUoLddQ, (ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.FMguLFyIWTEbghmkaAjeiaMjEuQNA, (phxLYZaFXEdPcKesDYFkQObzzCot.NaHcSyBcuEUglAJrulvAbOKAstXr)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(jtIbPdmTCYIpHnAGxmTzjBkAaONU.rkWuVsHOLGNOufCAarCQDPzfHNbX)) ? MiscTools.CreateGuidHashSHA256(jtIbPdmTCYIpHnAGxmTzjBkAaONU.rkWuVsHOLGNOufCAarCQDPzfHNbX) : oAfWbvFtzBgLaRIiknILWPaYvJGR2.KzwkcdaJgmrrHxFfbAIZCYxqvfXZ);
				bool flag = false;
				lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
				{
					if (tGeHaThAikyMDQdfvDNHjaHkxmpGA != null)
					{
						for (int j = 0; j < tGeHaThAikyMDQdfvDNHjaHkxmpGA.Count; j++)
						{
							if (tGeHaThAikyMDQdfvDNHjaHkxmpGA[j] != null && tGeHaThAikyMDQdfvDNHjaHkxmpGA[j].FGsKIGidIcXjhgOEkAILRQlLggAJA == guid)
							{
								anbhbdfzsmouOkCCbStpOglBHmiHb2 = tGeHaThAikyMDQdfvDNHjaHkxmpGA[j].dlebRgYnNGqgfxiKwiIgcssIjIos.SMRTsdAlHeuDLbbqWqOMPvghgyqc;
								flag = true;
								break;
							}
						}
					}
				}
				GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = new GdZLnXxkOIHlKtGBscttffEFwmuN(new miYcigybCPTrspuzuSiEafduhOCF(anbhbdfzsmouOkCCbStpOglBHmiHb2, PSYCrPHvrwFpnyKUwbpihSDkazxbA), UOAdUloIrGLNsyiyZJiswlDvPHmu);
				gdZLnXxkOIHlKtGBscttffEFwmuN.kcUDoGGvTTFQjqprocofCvMCThrxB = oAfWbvFtzBgLaRIiknILWPaYvJGR2;
				gdZLnXxkOIHlKtGBscttffEFwmuN.lRSuCVqBFiwoLENPMKoDoRlJImPV = oAfWbvFtzBgLaRIiknILWPaYvJGR2.dVasHGHCoqiTscKMyLLSxaMvdCUe;
				gdZLnXxkOIHlKtGBscttffEFwmuN.FGsKIGidIcXjhgOEkAILRQlLggAJA = guid;
				gdZLnXxkOIHlKtGBscttffEFwmuN.ItAxoFoPRBouslYknrpHyLycCekt = StringTools.SanitizeDeviceString(oAfWbvFtzBgLaRIiknILWPaYvJGR2.psVmskHZzblxuamlundDsEQNHEjW);
				gdZLnXxkOIHlKtGBscttffEFwmuN.jjNvGhLgVUdZtpAIwEHsdtIgDaOV = oAfWbvFtzBgLaRIiknILWPaYvJGR2.yPlEBmQDdIgFczWAPigatngdjYFF;
				gdZLnXxkOIHlKtGBscttffEFwmuN.cSavbmZXIlQoZHmhZdfxPxWWHDyX = (xCjHMUlKilLbcWgIcpQhdLGbHDVD)oAfWbvFtzBgLaRIiknILWPaYvJGR2.MMkFjnAWHbUsAtgKCDCWRWroaldrA;
				gNOxZLwzKvGKxOfiVrhJuExItcqU gNOxZLwzKvGKxOfiVrhJuExItcqU2 = anbhbdfzsmouOkCCbStpOglBHmiHb2.RNKyTXsPFKaezXBNcgSTeyzDkSYD;
				gdZLnXxkOIHlKtGBscttffEFwmuN.fMKicojkVfzslrdIfOWAGBzVnuLu = jtIbPdmTCYIpHnAGxmTzjBkAaONU.FMguLFyIWTEbghmkaAjeiaMjEuQNA;
				gdZLnXxkOIHlKtGBscttffEFwmuN.fkTCPIsHqSotwhwqqxJjzcdbvPaE = false;
				try
				{
					gdZLnXxkOIHlKtGBscttffEFwmuN.pCOoHkGiSIHiSbyVcoxRfoAIeuTv = jtIbPdmTCYIpHnAGxmTzjBkAaONU.meXdRJiGzEiIvjhdlADLlbjBJzAo;
				}
				catch (Exception)
				{
					gdZLnXxkOIHlKtGBscttffEFwmuN.pCOoHkGiSIHiSbyVcoxRfoAIeuTv = 0;
				}
				gdZLnXxkOIHlKtGBscttffEFwmuN.JiDYAISMELSdeAeNTOpuFUNqNoeA = gNOxZLwzKvGKxOfiVrhJuExItcqU2.SfuUiqbrwXRNHBrwvOpZqKYoXHay;
				gdZLnXxkOIHlKtGBscttffEFwmuN.XgOfIkiRHnILohqIHAYoSyoaJzGm = gNOxZLwzKvGKxOfiVrhJuExItcqU2.CVceVtZHyzfaUReonVZsPJOuiPIp;
				gdZLnXxkOIHlKtGBscttffEFwmuN.GbjktuKNCSrBbfYrJsiehchCrjiu = gNOxZLwzKvGKxOfiVrhJuExItcqU2.pVdfUEkkbRTxAIwzRWQKgBPlHpKJ;
				gdZLnXxkOIHlKtGBscttffEFwmuN.ZkjAiMEJtsmRQfeeNfvntanXhRvD = new DirectInputControllerExtension(oAfWbvFtzBgLaRIiknILWPaYvJGR2, anbhbdfzsmouOkCCbStpOglBHmiHb2);
				uZeyKdcnQmhYYnAgGSgLkCGzAbFg(gdZLnXxkOIHlKtGBscttffEFwmuN, jtIbPdmTCYIpHnAGxmTzjBkAaONU, out gdZLnXxkOIHlKtGBscttffEFwmuN.jbwnbOsIejfhAmLhlzPPbAkWUQKl);
				try
				{
					string text2;
					try
					{
						text2 = jtIbPdmTCYIpHnAGxmTzjBkAaONU.XysvtKXvdNRBzUPMIEyIyJCTGjhg;
					}
					catch
					{
						text2 = gdZLnXxkOIHlKtGBscttffEFwmuN.ItAxoFoPRBouslYknrpHyLycCekt;
					}
					if (HjYZqtJbFhQtNyvOOklYUPPvcmpfA.BUaaacVfZuenlHydLUdhCzFffdMhA((ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.MdHkuOXVoHvIuHjZLCewaiUoLddQ, (ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.FMguLFyIWTEbghmkaAjeiaMjEuQNA, text2) && HjYZqtJbFhQtNyvOOklYUPPvcmpfA.JQiifDqPDbRNVzYhnccblVMsFpJI((ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.MdHkuOXVoHvIuHjZLCewaiUoLddQ, (ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.FMguLFyIWTEbghmkaAjeiaMjEuQNA, text2, out var num, out var num2, out var num3))
					{
						gdZLnXxkOIHlKtGBscttffEFwmuN.dlebRgYnNGqgfxiKwiIgcssIjIos.vmRaIOCGjVwGzELXXccmVZrHISOAA(num, num2, num3, HjYZqtJbFhQtNyvOOklYUPPvcmpfA.oghxPNsdCVFjJHirUoyqCYaaFVphB((ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.MdHkuOXVoHvIuHjZLCewaiUoLddQ, (ushort)jtIbPdmTCYIpHnAGxmTzjBkAaONU.FMguLFyIWTEbghmkaAjeiaMjEuQNA, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<PyvhEXOOIhgSeIwyAsaBOIoxukWy> list3 = anbhbdfzsmouOkCCbStpOglBHmiHb2.eVgvcOjHtltmfBoVtaXBosCZZLtf();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].rIJOgGdoahKmEQbbieuTfbHeEGPAA.pGDeHoojINfTkjqOcpkEWPcgsbLeA & vSIYNxlhLuRVvxutxhRoERRIotdU.Axis) != vSIYNxlhLuRVvxutxhRoERRIotdU.All)
							{
								anbhbdfzsmouOkCCbStpOglBHmiHb2.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.qTLFClLwrsoQgWHqGfHWrpakJzwF = new KWcqbYjQsKhCDApIfHPKAlCTmmekA(-65535, 65535);
							}
						}
					}
					anbhbdfzsmouOkCCbStpOglBHmiHb2.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.KTzmYoCEDrvCANpIqnRGxyJulhWe = KKxHGCHPMHInTEePGtrtVwTyaQRDA.Absolute;
					anbhbdfzsmouOkCCbStpOglBHmiHb2.HRLbmKbJSZhGVcrHGofdADrYBMmPB(myeFmjJQhIPbFgvBhgWMMLdyLnnz, pcrAdDTdMCmYoHsivRUQoFLZOknO.NonExclusive | pcrAdDTdMCmYoHsivRUQoFLZOknO.Background);
					anbhbdfzsmouOkCCbStpOglBHmiHb2.JFtgQeubYmhwWhIMlgFUXXNcOVpf();
				}
				list.Add(new ydNKRIYeuXbhtmYNoJRVJHgBmzFj(gdZLnXxkOIHlKtGBscttffEFwmuN, oAfWbvFtzBgLaRIiknILWPaYvJGR2));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void NPBgWxGmwWFBCKDvcfUeRIlmjIOL()
	{
		pCqDZfhohpzHtLHBEFreedEGdYUG(nxMTeenHsBcCEdzSmrqHlibMiYzbb());
	}

	private void pCqDZfhohpzHtLHBEFreedEGdYUG(List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> P_0)
	{
		List<GdZLnXxkOIHlKtGBscttffEFwmuN> list = new List<GdZLnXxkOIHlKtGBscttffEFwmuN>();
		VlkBTFiESCDBQyPzzaUgpxAZZjxpA = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].xqgQSpNTaieCxJJnTjQyRxMNokUi)
			{
				continue;
			}
			try
			{
				GdZLnXxkOIHlKtGBscttffEFwmuN gulceYKVuRzFgfRxsdKZzWtZCoTy = P_0[i].gulceYKVuRzFgfRxsdKZzWtZCoTy;
				gulceYKVuRzFgfRxsdKZzWtZCoTy.rLWwQxexfxoyfnZMYixBxaGYQjDh();
				if (gulceYKVuRzFgfRxsdKZzWtZCoTy.ACPFfUcDKNakIhAkCMchvCBEiyiYb)
				{
					VlkBTFiESCDBQyPzzaUgpxAZZjxpA++;
				}
				list.Add(gulceYKVuRzFgfRxsdKZzWtZCoTy);
			}
			catch (Exception)
			{
			}
		}
		zbXNBPROrsuOBugVZAaJLWKgsiXy.ZXrRzuzsqvMTXdHHurQcWLDTDVDeA(VlkBTFiESCDBQyPzzaUgpxAZZjxpA);
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			List<GdZLnXxkOIHlKtGBscttffEFwmuN> list2 = tGeHaThAikyMDQdfvDNHjaHkxmpGA;
			int leHRQkaWUXTgOCWXeJUJmqjGMspm = LeHRQkaWUXTgOCWXeJUJmqjGMspm;
			int count = list.Count;
			JVrKIPqGqhCyhbMcHePyXAfAzFwcA(leHRQkaWUXTgOCWXeJUJmqjGMspm, count, list2, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			XMMxvZoUtyowrdCHjEYPFRAzRdOtA(list2, list, false);
			XMMxvZoUtyowrdCHjEYPFRAzRdOtA(list, list2, true);
			MActDIhjeaIPCMaAdFkCNAQcwmME(list, list2);
			tGeHaThAikyMDQdfvDNHjaHkxmpGA = list;
			LeHRQkaWUXTgOCWXeJUJmqjGMspm = list.Count;
		}
	}

	private void uZeyKdcnQmhYYnAgGSgLkCGzAbFg(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, JtIbPdmTCYIpHnAGxmTzjBkAaONU P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = AXZmLhfOaXDLyYVNwRRyjGqxlFh.jdyktFCcimoovPTInevfRbthhhAN(P_1.rkWuVsHOLGNOufCAarCQDPzfHNbX);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			aNTkFKnqqQjRlbXRHwhJJCyplUUJ aNTkFKnqqQjRlbXRHwhJJCyplUUJ2 = hvnhVrGGJGHgzOeFnMnHvVzmekkF.zssksiyhMjvfBNaKdDDhjdhkYOIiA(text.ToLower(CultureInfo.InvariantCulture));
			if (aNTkFKnqqQjRlbXRHwhJJCyplUUJ2 != null)
			{
				P_0.ACPFfUcDKNakIhAkCMchvCBEiyiYb = aNTkFKnqqQjRlbXRHwhJJCyplUUJ2.oHztpHRidygEEgsKHeZPjMhOvpyP;
				P_0.nxPkdjTEaYZiiBvqOirqdkCMTUKd = aNTkFKnqqQjRlbXRHwhJJCyplUUJ2.gUbtKKtsVYgdsHfCOpRudpNrcsUCA;
				P_2 = phxLYZaFXEdPcKesDYFkQObzzCot.WtVgDZcKWifevVrRwilhIQKEQwlfb(aNTkFKnqqQjRlbXRHwhJJCyplUUJ2, P_0.jjNvGhLgVUdZtpAIwEHsdtIgDaOV, P_0.ItAxoFoPRBouslYknrpHyLycCekt, P_0.nxPkdjTEaYZiiBvqOirqdkCMTUKd);
				aNTkFKnqqQjRlbXRHwhJJCyplUUJ2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void wbwpbnCZqjBgdiLAVaxCeEQBabKD()
	{
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			for (int i = 0; i < LeHRQkaWUXTgOCWXeJUJmqjGMspm; i++)
			{
				try
				{
					GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = tGeHaThAikyMDQdfvDNHjaHkxmpGA[i];
					if (gdZLnXxkOIHlKtGBscttffEFwmuN != null && gdZLnXxkOIHlKtGBscttffEFwmuN.pHuOOlARjbZLiAAgBbdAPAKzvJzy() && (wbjsmIpoJYIDLciADgGvDfNBzFtGA == null || !gdZLnXxkOIHlKtGBscttffEFwmuN.fkTCPIsHqSotwhwqqxJjzcdbvPaE))
					{
						gdZLnXxkOIHlKtGBscttffEFwmuN.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> MkVWIuqrRTXKJDteCchztJOFzxCJ()
	{
		try
		{
			IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> list = MntsIiOQXRwAjiesZYnwoFuvxhZD.ISZAaZHIFxTftdsVBLTLCQFbqLWYA(OaagXIZrfeDFhvWXSIZbhwFlMfQK.GameControl, eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly);
			WIuxKGvHlUWNkojbGaYwwgActvwj = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			WIuxKGvHlUWNkojbGaYwwgActvwj = 0;
			return EmptyObjects<oAfWbvFtzBgLaRIiknILWPaYvJGR>.EmptyReadOnlyIListT;
		}
	}

	private void lewfEFBiZdwSCFKqpzgboZwTICMr()
	{
		MntsIiOQXRwAjiesZYnwoFuvxhZD.wMCqrRBDoRdvIDZeWGmieGpYmmIeb();
	}

	private void JVrKIPqGqhCyhbMcHePyXAfAzFwcA(int P_0, int P_1, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_2, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(GdZLnXxkOIHlKtGBscttffEFwmuN.eUMVmyyghYerfFTzAzQjSuFbziUV);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			yYoCjafMJmtBFRCmuZOtvEZlOtLBA(P_1, P_3, P_0, P_2, mYRirIvxKYeZcyLdCDuGXxEsCFdr.MsMkfkBktchgiKDqxGLNwRXVRExk.Exact);
		}
		ASeTxtvBUETgTBgWJEWvBcFJOixR(P_1, P_3, mYRirIvxKYeZcyLdCDuGXxEsCFdr.MsMkfkBktchgiKDqxGLNwRXVRExk.Exact);
		for (int i = 0; i < P_1; i++)
		{
			GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = P_3[i];
			if (gdZLnXxkOIHlKtGBscttffEFwmuN != null && gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = zxjammcEAWGnKHBbjVfGHzAQmcOlA(P_3);
				gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = xnrnpxhkNqWgcYILtdLEhEmRJGXbb();
				dHoddqgfyBkzbXxHAwXgokuuapKr.WGuGmyGcyrohZXoeBqYwkCxjJuoAA(gdZLnXxkOIHlKtGBscttffEFwmuN);
			}
		}
		P_3.Sort(GdZLnXxkOIHlKtGBscttffEFwmuN.hvMOKxYJxddquBUgUZglqiPnAkad);
	}

	private void PLifchfDZfGdYclKxeGHaCwhnnpOA(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
			{
				P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
			}
		}
	}

	private bool ySiEzNGAPXFUjDNHGdbeAVQmDFMyA(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int zxjammcEAWGnKHBbjVfGHzAQmcOlA(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
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

	private bool IpfvfuJCybMfLEZTDuIXanVsiNMt(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void yYoCjafMJmtBFRCmuZOtvEZlOtLBA(int P_0, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_1, int P_2, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_3, mYRirIvxKYeZcyLdCDuGXxEsCFdr.MsMkfkBktchgiKDqxGLNwRXVRExk P_4)
	{
		int num = ((P_4 != mYRirIvxKYeZcyLdCDuGXxEsCFdr.MsMkfkBktchgiKDqxGLNwRXVRExk.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = P_1[i];
			if (gdZLnXxkOIHlKtGBscttffEFwmuN == null || gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN2 = P_3[j];
				if (gdZLnXxkOIHlKtGBscttffEFwmuN2 != null && !IpfvfuJCybMfLEZTDuIXanVsiNMt(P_1, gdZLnXxkOIHlKtGBscttffEFwmuN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && gdZLnXxkOIHlKtGBscttffEFwmuN.cSSelrJcgvnxYdCOyGuwXryBPByhA(gdZLnXxkOIHlKtGBscttffEFwmuN2) >= num)
				{
					gdZLnXxkOIHlKtGBscttffEFwmuN.ElfNyjfcTcaQHAvZbxMeNfiCuqCqA(gdZLnXxkOIHlKtGBscttffEFwmuN2);
					dHoddqgfyBkzbXxHAwXgokuuapKr.WGuGmyGcyrohZXoeBqYwkCxjJuoAA(gdZLnXxkOIHlKtGBscttffEFwmuN);
				}
			}
		}
	}

	private void ASeTxtvBUETgTBgWJEWvBcFJOixR(int P_0, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_1, mYRirIvxKYeZcyLdCDuGXxEsCFdr.MsMkfkBktchgiKDqxGLNwRXVRExk P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = P_1[i];
			if (gdZLnXxkOIHlKtGBscttffEFwmuN == null || gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			mYRirIvxKYeZcyLdCDuGXxEsCFdr.mFlYVhbmAaiZraQZlDtkVCJYKPHwA mFlYVhbmAaiZraQZlDtkVCJYKPHwA = null;
			foreach (mYRirIvxKYeZcyLdCDuGXxEsCFdr.mFlYVhbmAaiZraQZlDtkVCJYKPHwA item in dHoddqgfyBkzbXxHAwXgokuuapKr.eMUDzblCzqzldkfEcdZCVuFTgMYAA(gdZLnXxkOIHlKtGBscttffEFwmuN, P_2))
			{
				if (!IpfvfuJCybMfLEZTDuIXanVsiNMt(P_1, item.KmTsXfbTKeIVvXSfdELoyOjRGNHq) && item.HPAJiXdxFAFQDOVwkJSjMHIVclrK >= 0)
				{
					mFlYVhbmAaiZraQZlDtkVCJYKPHwA = item;
					break;
				}
			}
			if (mFlYVhbmAaiZraQZlDtkVCJYKPHwA != null)
			{
				int num = mFlYVhbmAaiZraQZlDtkVCJYKPHwA.HPAJiXdxFAFQDOVwkJSjMHIVclrK;
				if (!ySiEzNGAPXFUjDNHGdbeAVQmDFMyA(P_1, num))
				{
					num = (mFlYVhbmAaiZraQZlDtkVCJYKPHwA.HPAJiXdxFAFQDOVwkJSjMHIVclrK = zxjammcEAWGnKHBbjVfGHzAQmcOlA(P_1));
				}
				gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = mFlYVhbmAaiZraQZlDtkVCJYKPHwA.KmTsXfbTKeIVvXSfdELoyOjRGNHq;
				dHoddqgfyBkzbXxHAwXgokuuapKr.WGuGmyGcyrohZXoeBqYwkCxjJuoAA(gdZLnXxkOIHlKtGBscttffEFwmuN);
			}
		}
	}

	private void tkLVEbzNfUThkgHkQePkRrjiYHQF()
	{
		if (LTyMIEAStXlcFivCqtWZXeFmwOxU)
		{
			vQEiHKGHfAbiRJRcDypuDGoTTBRr();
		}
		if (qiSGCOcnWVBgntYjpTxQcHoPkXsL.rYnfxXQpvqMpOJxdAcMymuXfVPdJ && qiSGCOcnWVBgntYjpTxQcHoPkXsL.hRRQBhRlrNLlIwAAvCWMAegGhfdIA())
		{
			MZdtRLhCHGOeSZlFcdlBclPbXYUJ(qiSGCOcnWVBgntYjpTxQcHoPkXsL.pIVDjHonGkoGmUlIarmyWTCFlTfh);
		}
	}

	private void vQEiHKGHfAbiRJRcDypuDGoTTBRr()
	{
		LTyMIEAStXlcFivCqtWZXeFmwOxU = false;
		if (!qiSGCOcnWVBgntYjpTxQcHoPkXsL.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
		{
			qiSGCOcnWVBgntYjpTxQcHoPkXsL.ZRNxDcQZRiFYRKxfnaKLNAFnscDt();
		}
	}

	private void MZdtRLhCHGOeSZlFcdlBclPbXYUJ(List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> P_0)
	{
		if (XXJbEwBeuNSibVxqbudaJIceNRQJA(ydNKRIYeuXbhtmYNoJRVJHgBmzFj.iNMVAQyLGgxBcgTGdOogBzdJfSQJ(P_0)))
		{
			pCqDZfhohpzHtLHBEFreedEGdYUG(P_0);
		}
	}

	private bool XXJbEwBeuNSibVxqbudaJIceNRQJA(IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> P_0)
	{
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !TDWjzeTXpLpTwBLHzDlIyUvQTIcl(P_0[i].KzwkcdaJgmrrHxFfbAIZCYxqvfXZ))
				{
					return true;
				}
			}
			int count2 = tGeHaThAikyMDQdfvDNHjaHkxmpGA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (tGeHaThAikyMDQdfvDNHjaHkxmpGA[j] != null && !GamUjsZkrVgoXIHkrzQxEBxiPFTUA(P_0, tGeHaThAikyMDQdfvDNHjaHkxmpGA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool TDWjzeTXpLpTwBLHzDlIyUvQTIcl(Guid P_0)
	{
		lock (gnTfenSLfpxNPsPeQoIWlaNxhjOp)
		{
			int count = tGeHaThAikyMDQdfvDNHjaHkxmpGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (tGeHaThAikyMDQdfvDNHjaHkxmpGA[i] != null && tGeHaThAikyMDQdfvDNHjaHkxmpGA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool GamUjsZkrVgoXIHkrzQxEBxiPFTUA(IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].KzwkcdaJgmrrHxFfbAIZCYxqvfXZ == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void XMMxvZoUtyowrdCHjEYPFRAzRdOtA(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN = P_0[i];
			if (gdZLnXxkOIHlKtGBscttffEFwmuN == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					GdZLnXxkOIHlKtGBscttffEFwmuN gdZLnXxkOIHlKtGBscttffEFwmuN2 = P_1[j];
					if (gdZLnXxkOIHlKtGBscttffEFwmuN2 != null && gdZLnXxkOIHlKtGBscttffEFwmuN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == gdZLnXxkOIHlKtGBscttffEFwmuN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				NKDxphHOqjbgjBpZnJcHHmPRFubbA(P_0[i], P_2);
			}
		}
	}

	private void NKDxphHOqjbgjBpZnJcHHmPRFubbA(GdZLnXxkOIHlKtGBscttffEFwmuN P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}

	private bool kpobKVQDSiwYRkGXhDjFuXocpIRn()
	{
		int num = MntsIiOQXRwAjiesZYnwoFuvxhZD.YYlJGBUmAucmJnDNlzGpnPFGtCMV(OaagXIZrfeDFhvWXSIZbhwFlMfQK.GameControl, eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly);
		if (WIuxKGvHlUWNkojbGaYwwgActvwj != num)
		{
			WIuxKGvHlUWNkojbGaYwwgActvwj = num;
			return true;
		}
		if (VlkBTFiESCDBQyPzzaUgpxAZZjxpA > 0 && zbXNBPROrsuOBugVZAaJLWKgsiXy.BVqqjNaDAEKKTIvWCfUmPCCKuoTs())
		{
			return true;
		}
		return false;
	}

	private void MActDIhjeaIPCMaAdFkCNAQcwmME(List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_0, List<GdZLnXxkOIHlKtGBscttffEFwmuN> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].xTFhmkzjUzmmKDShwvmePLldyNBi();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void rYibVJtdceIanKDryqxmjDJZoGmSA(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<ydNKRIYeuXbhtmYNoJRVJHgBmzFj> OhNPjzvNxYDzaHwrLyKqSidSHvaQ()
	{
		return nxMTeenHsBcCEdzSmrqHlibMiYzbb();
	}
}
