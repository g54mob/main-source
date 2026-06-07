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

internal class laCHEXrFQKVPafsRtaZTamLraAteb : PlatformInputManager, EvYpgWgAiaVrxrmiqwIIXwlPQUow
{
	private class luuKOpfoMKySQQUXqdSrnScCisdo : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int wtTuxayxkxMXdxJfjWgECmNAkLQL;

		private int TUBqMHOSSBKHewiCXFxQeEWorbneA;

		public Guid tmLASYdOvuShEkfwMDpsmLzJMmgvA;

		public string WFmEsMkcLlUBnkeQkSsnNZhffbmEb;

		public readonly VqbdvMFmWDQOkQspiAnCJiRjjlByA SnPJwYARTUdjlIyKsJvaqdEBSIzP;

		public JwOsKFPjPBIlckyhencRQGSXVgXH FXnzTkbkBXXedWInieHbbhaCIngBA;

		public KXGyEgvKAlBEzlKeqCYObLtyDDCq ZZgoMpRIhzlRHcbFJUjLLiHnHnIb;

		public string UtzFfPmZNybBrzTTKDXmmZmIgKCB;

		public string fjmbvQuFJRluCSqpeIFaiSDtqfWB;

		public int QLtnZYhtHhdqzUVAznhMUDDImAMH;

		public Guid iFZBBskpSeyHxBVKshiXJFKMejHg;

		public Guid OFyQoTLFJChUlfESstukdbijCoFeb;

		public Guid utcEvDhYdeKaYMulsPoCFQOSHMjuA;

		public int GIxPvEYlCYmtGCrBybGLvZaTbuYX;

		public bool jMskMqLGpNhcWruWYVOpOvsfgLzC;

		public string YcwUpBDuSGbWawrbSnVwjjGPDBZBA;

		public string MaHHqwBmorQaCATdlSSBhtELnQHaA;

		public int UXZTfPuvZAuXApxtMlSHNgOEdAKeA;

		public int dLSExATVOfgXZqfDDiToGokXkviw;

		public int iWNVRoYLKIjDxAhsDQhvHDyMRLltA;

		public int uEhDGSsABnbKgGMGLpnmInKzgzNO;

		public int dkImGUEJAEWZpSRrLZZgjsXBnVlH;

		public bool SEcfLgAkTAqpwjOwJuAhStSTspxlb;

		public Controller.Extension kNKxVkUlZyEtOGCaVmOhtAGMUraS;

		private float[] VOAxCDfoYZduTepvoiVbUtFygiRdb;

		private bool[] aXjqUHRyGMEZGhtjMJhDWIYNjZdq;

		private HardwareJoystickMap_InputManager YqxBgucZtJhiQWNeMskNffczGJHEA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> RnEIXAHWUbLbViDHnMHrHMsCOqCE;

		private bool ttsgfuHxICnhPRrtcnbGGZlIdHSc;

		private bool ZKwhxmxwyLheqLjMhbUPvisJFiwL;

		private bool TKSdVyIPuHwOakOUmHGcCtmpyede;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return wtTuxayxkxMXdxJfjWgECmNAkLQL;
			}
			set
			{
				wtTuxayxkxMXdxJfjWgECmNAkLQL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return TUBqMHOSSBKHewiCXFxQeEWorbneA;
			}
			set
			{
				TUBqMHOSSBKHewiCXFxQeEWorbneA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (WFmEsMkcLlUBnkeQkSsnNZhffbmEb != "Unknown Controller")
				{
					return WFmEsMkcLlUBnkeQkSsnNZhffbmEb;
				}
				if (jMskMqLGpNhcWruWYVOpOvsfgLzC && !string.IsNullOrEmpty(YcwUpBDuSGbWawrbSnVwjjGPDBZBA))
				{
					return YcwUpBDuSGbWawrbSnVwjjGPDBZBA;
				}
				return fjmbvQuFJRluCSqpeIFaiSDtqfWB;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (TUBqMHOSSBKHewiCXFxQeEWorbneA < 0)
				{
					return null;
				}
				return TUBqMHOSSBKHewiCXFxQeEWorbneA;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => kNKxVkUlZyEtOGCaVmOhtAGMUraS;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => iFZBBskpSeyHxBVKshiXJFKMejHg;

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

		public luuKOpfoMKySQQUXqdSrnScCisdo(VqbdvMFmWDQOkQspiAnCJiRjjlByA P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			SnPJwYARTUdjlIyKsJvaqdEBSIzP = P_0;
			RnEIXAHWUbLbViDHnMHrHMsCOqCE = P_1;
			TUBqMHOSSBKHewiCXFxQeEWorbneA = -1;
			wtTuxayxkxMXdxJfjWgECmNAkLQL = -1;
		}

		public void UMhDjVixKtdCpUIKMTnZlaFJKdWe()
		{
			string text = fjmbvQuFJRluCSqpeIFaiSDtqfWB;
			Guid oFyQoTLFJChUlfESstukdbijCoFeb = OFyQoTLFJChUlfESstukdbijCoFeb;
			utcEvDhYdeKaYMulsPoCFQOSHMjuA = MiscTools.CreateGuidHashSHA1(text + oFyQoTLFJChUlfESstukdbijCoFeb.ToString());
			UXZTfPuvZAuXApxtMlSHNgOEdAKeA = iWNVRoYLKIjDxAhsDQhvHDyMRLltA;
			dLSExATVOfgXZqfDDiToGokXkviw = uEhDGSsABnbKgGMGLpnmInKzgzNO + dkImGUEJAEWZpSRrLZZgjsXBnVlH * 8;
			vxuvpcaYjKOgKTJuUDKRPSXNbrXd();
			tmLASYdOvuShEkfwMDpsmLzJMmgvA = YqxBgucZtJhiQWNeMskNffczGJHEA.hardwareMapIdentifier.guid;
			WFmEsMkcLlUBnkeQkSsnNZhffbmEb = YqxBgucZtJhiQWNeMskNffczGJHEA.controllerName;
			ttsgfuHxICnhPRrtcnbGGZlIdHSc = tmLASYdOvuShEkfwMDpsmLzJMmgvA == Guid.Empty;
			VOAxCDfoYZduTepvoiVbUtFygiRdb = new float[UXZTfPuvZAuXApxtMlSHNgOEdAKeA];
			aXjqUHRyGMEZGhtjMJhDWIYNjZdq = new bool[dLSExATVOfgXZqfDDiToGokXkviw];
			SnPJwYARTUdjlIyKsJvaqdEBSIzP.pveRfCdYXkCQqfezxXFqMLwYZZbG();
			Update();
		}

		public void tPYBvNxmHugJVMTVptvehJGRhaNT(luuKOpfoMKySQQUXqdSrnScCisdo P_0)
		{
			if (P_0 != null)
			{
				TUBqMHOSSBKHewiCXFxQeEWorbneA = P_0.TUBqMHOSSBKHewiCXFxQeEWorbneA;
				wtTuxayxkxMXdxJfjWgECmNAkLQL = P_0.wtTuxayxkxMXdxJfjWgECmNAkLQL;
				for (int i = 0; i < MathTools.Min(aXjqUHRyGMEZGhtjMJhDWIYNjZdq.Length, P_0.aXjqUHRyGMEZGhtjMJhDWIYNjZdq.Length); i++)
				{
					aXjqUHRyGMEZGhtjMJhDWIYNjZdq[i] = P_0.aXjqUHRyGMEZGhtjMJhDWIYNjZdq[i];
				}
				for (int j = 0; j < MathTools.Min(VOAxCDfoYZduTepvoiVbUtFygiRdb.Length, P_0.VOAxCDfoYZduTepvoiVbUtFygiRdb.Length); j++)
				{
					VOAxCDfoYZduTepvoiVbUtFygiRdb[j] = P_0.VOAxCDfoYZduTepvoiVbUtFygiRdb[j];
				}
				ZKwhxmxwyLheqLjMhbUPvisJFiwL = P_0.ZKwhxmxwyLheqLjMhbUPvisJFiwL;
				SnPJwYARTUdjlIyKsJvaqdEBSIzP.lcoIwbksvwXWLRXGPaXjdvANByCU(P_0.SnPJwYARTUdjlIyKsJvaqdEBSIzP);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			SnPJwYARTUdjlIyKsJvaqdEBSIzP.UDjwgdbDCQWJGBIgzGTRxvTGCpyK();
			bool[] array = SnPJwYARTUdjlIyKsJvaqdEBSIzP.sgltSIzHQdiQWiWjLNoGKTUNJvDC;
			int[] pznyWQiJPiDQGOuvbsIhWjwQNKRW = SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.pznyWQiJPiDQGOuvbsIhWjwQNKRW;
			qijsQbFkKpjSfgctGzNzLiGXkpuTA(array, pznyWQiJPiDQGOuvbsIhWjwQNKRW);
			fkkdmvaqRiDtIZqVbSMxwyjNcKkw(array, pznyWQiJPiDQGOuvbsIhWjwQNKRW);
			SnPJwYARTUdjlIyKsJvaqdEBSIzP.kiBgjOEwlHuAckuQxmRNfbQfBqWMc();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (UXZTfPuvZAuXApxtMlSHNgOEdAKeA != dataUpdater.axisCount || dLSExATVOfgXZqfDDiToGokXkviw != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < UXZTfPuvZAuXApxtMlSHNgOEdAKeA; i++)
			{
				dataUpdater.axisValues[i] = VOAxCDfoYZduTepvoiVbUtFygiRdb[i];
			}
			for (int j = 0; j < dLSExATVOfgXZqfDDiToGokXkviw; j++)
			{
				dataUpdater.buttonValues[j] = aXjqUHRyGMEZGhtjMJhDWIYNjZdq[j];
			}
			if (ZKwhxmxwyLheqLjMhbUPvisJFiwL && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int PJzgONkwutyeAjCIyNMcxBGGJijl(luuKOpfoMKySQQUXqdSrnScCisdo P_0)
		{
			if (P_0.wtTuxayxkxMXdxJfjWgECmNAkLQL == wtTuxayxkxMXdxJfjWgECmNAkLQL)
			{
				return 2;
			}
			if (iWNVRoYLKIjDxAhsDQhvHDyMRLltA != P_0.iWNVRoYLKIjDxAhsDQhvHDyMRLltA)
			{
				return 0;
			}
			if (uEhDGSsABnbKgGMGLpnmInKzgzNO != P_0.uEhDGSsABnbKgGMGLpnmInKzgzNO)
			{
				return 0;
			}
			if (dkImGUEJAEWZpSRrLZZgjsXBnVlH != P_0.dkImGUEJAEWZpSRrLZZgjsXBnVlH)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.utcEvDhYdeKaYMulsPoCFQOSHMjuA == utcEvDhYdeKaYMulsPoCFQOSHMjuA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo uQWANsHceIuTCUgyMYvIGLQWAZNB()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			nAqAxPBeNHSYJAdyOPVoJFAabPPTA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			cLzjdzPcCQUybkUHULjryZVJTEwr(bridgedController);
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
			return new ControllerDisconnectedEventArgs(wtTuxayxkxMXdxJfjWgECmNAkLQL);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool GPJKLHQxbrcMgznaROIEZBkaSZsV()
		{
			try
			{
				SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA.KfIjhEMElTDcRmzICiXlybsjGlKy();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void pJFXLMZzNudSfvBQQdgMCvnBIZhpA()
		{
			try
			{
				if (SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA != null)
				{
					SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA.yFWBlSAiUeHwYaAAdQRMvZfnNUaGA();
				}
			}
			catch
			{
			}
		}

		public void MsBfyrnNAfzNHONLDKelfenvcgZh()
		{
			try
			{
				if (SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA != null)
				{
					SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA.BYrYCjhRrQTlEFuhxTXDEQoMUZuU();
				}
			}
			catch
			{
			}
		}

		private void qijsQbFkKpjSfgctGzNzLiGXkpuTA(bool[] P_0, int[] P_1)
		{
			if (UXZTfPuvZAuXApxtMlSHNgOEdAKeA <= 0)
			{
				return;
			}
			switch (YqxBgucZtJhiQWNeMskNffczGJHEA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)YqxBgucZtJhiQWNeMskNffczGJHEA.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						MvNIwrNMHnOUoQTIMafxRNLCjnBI(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)YqxBgucZtJhiQWNeMskNffczGJHEA.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						MvNIwrNMHnOUoQTIMafxRNLCjnBI(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void fkkdmvaqRiDtIZqVbSMxwyjNcKkw(bool[] P_0, int[] P_1)
		{
			if (dLSExATVOfgXZqfDDiToGokXkviw <= 0)
			{
				return;
			}
			switch (YqxBgucZtJhiQWNeMskNffczGJHEA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)YqxBgucZtJhiQWNeMskNffczGJHEA.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						fvDYedQZAgHxmuqBHZpITWlCNNoG(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)YqxBgucZtJhiQWNeMskNffczGJHEA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						fvDYedQZAgHxmuqBHZpITWlCNNoG(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void MvNIwrNMHnOUoQTIMafxRNLCjnBI(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= UXZTfPuvZAuXApxtMlSHNgOEdAKeA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			VOAxCDfoYZduTepvoiVbUtFygiRdb[P_1] = bIvJTOeoEkABVFvcZUyqFbhpOEEf(P_0, P_2, P_3);
			if (!ZKwhxmxwyLheqLjMhbUPvisJFiwL && VOAxCDfoYZduTepvoiVbUtFygiRdb[P_1] != 0f)
			{
				ZKwhxmxwyLheqLjMhbUPvisJFiwL = true;
			}
		}

		private void fvDYedQZAgHxmuqBHZpITWlCNNoG(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= dLSExATVOfgXZqfDDiToGokXkviw)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			aXjqUHRyGMEZGhtjMJhDWIYNjZdq[P_1] = uuwdRBkTxMHQSarnxFSdmOkwwMHaA(P_0, P_2, P_3);
			if (!ZKwhxmxwyLheqLjMhbUPvisJFiwL && aXjqUHRyGMEZGhtjMJhDWIYNjZdq[P_1])
			{
				ZKwhxmxwyLheqLjMhbUPvisJFiwL = true;
			}
		}

		private float bIvJTOeoEkABVFvcZUyqFbhpOEEf(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return BXcFHODNdOEASSWLNMKoQMvyhfTq((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uEhDGSsABnbKgGMGLpnmInKzgzNO || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= dkImGUEJAEWZpSRrLZZgjsXBnVlH || sourceHat >= 4)
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
					num2 = aNDsWFqDFnPCykDrVXRqXaqOomeS(num, AxisDirection.Horizontal);
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
					num2 = aNDsWFqDFnPCykDrVXRqXaqOomeS(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && dlvbSEsCjNjZPVOkCuINdZLgGqkU(customCalculationSourceData[i], out var item))
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

		private float BXcFHODNdOEASSWLNMKoQMvyhfTq(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.TAbfoySJHSYCHDnkNeOPsTxLFwPHA, 
				DirectInputAxis.Y => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.uAljlGVcNhoOuvpcbTSGmvLtYewJ, 
				DirectInputAxis.Z => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.xFwBuspDlbUTjYwIrRbZjhIjqJOj, 
				DirectInputAxis.RotationX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.TjhJKmeiBzbyEngHAEcAdSLQWpcW, 
				DirectInputAxis.RotationY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.cqwhYOmpIwUvsRWhbpVNbJebnyai, 
				DirectInputAxis.RotationZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.ZbvprJvEYnONDiPQfeIODSOjoHwPA, 
				DirectInputAxis.Slider0 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.eYiAUnDePrHyhvcpRdEvtgTCwufM[0], 
				DirectInputAxis.Slider1 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.eYiAUnDePrHyhvcpRdEvtgTCwufM[1], 
				DirectInputAxis.VelocityX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.mgPMLqdjGLHiCGsEPpKpSzJcAwzKA, 
				DirectInputAxis.VelocityY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.ZHxczrZgvzPyywCIidejoIDLXyPI, 
				DirectInputAxis.VelocityZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.DcnVgcURyROMQwduwesPbKlYqoMj, 
				DirectInputAxis.AngularVelocityX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.vFQgpYDdLAZcJrSpNkGPJngWfItt, 
				DirectInputAxis.AngularVelocityY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.XfCGfuIUZzkAWyAcWkQDMPXIRfOEA, 
				DirectInputAxis.AngularVelocityZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.erPHVxkqgxrMkqGgPMgwLzLBNrNH, 
				DirectInputAxis.VelocitySlider0 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.jPbiiUumZoNOYGiqGkbWkETnLjoM[0], 
				DirectInputAxis.VelocitySlider1 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.jPbiiUumZoNOYGiqGkbWkETnLjoM[1], 
				DirectInputAxis.AccelerationX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.SXxovYaTErASvQLIENQqLUeFGUSo, 
				DirectInputAxis.AccelerationY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.YflbJKYTmWAZdBEslkprVUgFiXTaA, 
				DirectInputAxis.AccelerationZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.hdTGlZquVuGhRCeTLGmRYYhlQbYN, 
				DirectInputAxis.AngularAccelerationX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.RzMuhfJeVXhlyROxcpDXOPICBTgN, 
				DirectInputAxis.AngularAccelerationY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.nEKdAtUiwGDkeOnblEynINMURwEf, 
				DirectInputAxis.AngularAccelerationZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.JmOZWUoAtrQrpmIFQgDkbYueNblNA, 
				DirectInputAxis.AccelerationSlider0 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.gVptnAkLQIICzuRtDqsuWyQDsqHf[0], 
				DirectInputAxis.AccelerationSlider1 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.gVptnAkLQIICzuRtDqsuWyQDsqHf[1], 
				DirectInputAxis.ForceX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.wAelOXSIxKUbLsSPWrAGsPMdxaGw, 
				DirectInputAxis.ForceY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.eXhpBflMcVeEsnAAjqqsMumHzOCA, 
				DirectInputAxis.ForceZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.JHfqwoXVamvOxfEXzAPVBALYgjCy, 
				DirectInputAxis.TorqueX => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.nADTijOOUcZQfdKdpdVIZsVpuMiX, 
				DirectInputAxis.TorqueY => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.vDSAfcKuqrPqtoWAfDsnpyamqntD, 
				DirectInputAxis.TorqueZ => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.JcJMXvErquKRKbGqPfkvjZqsMnYuA, 
				DirectInputAxis.ForceSlider0 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.UKEvLMxzltaRvSqhzHApbcGbEbhx[0], 
				DirectInputAxis.ForceSlider1 => SnPJwYARTUdjlIyKsJvaqdEBSIzP.FdolqVwsiUluSfOPFVxkOJswShzT.UKEvLMxzltaRvSqhzHApbcGbEbhx[1], 
				_ => 0f, 
			};
		}

		private bool uuwdRBkTxMHQSarnxFSdmOkwwMHaA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= uEhDGSsABnbKgGMGLpnmInKzgzNO || sourceButton >= 128)
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
				float num = BXcFHODNdOEASSWLNMKoQMvyhfTq((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= dkImGUEJAEWZpSRrLZZgjsXBnVlH || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return kzrLVndRcNxFRncrZFugEkbNGWCdA(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (XuRgYtEkWNJQRyJppHKrKPSUpWci(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (dlvbSEsCjNjZPVOkCuINdZLgGqkU(customCalculationSourceData[k], out var num2))
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

		private bool kzrLVndRcNxFRncrZFugEkbNGWCdA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (YqxBgucZtJhiQWNeMskNffczGJHEA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float aNDsWFqDFnPCykDrVXRqXaqOomeS(int P_0, AxisDirection P_1)
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

		private bool XuRgYtEkWNJQRyJppHKrKPSUpWci(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= uEhDGSsABnbKgGMGLpnmInKzgzNO || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool dlvbSEsCjNjZPVOkCuINdZLgGqkU(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = BXcFHODNdOEASSWLNMKoQMvyhfTq((DirectInputAxis)P_0.sourceAxis);
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
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType EbSrElPhXcDiUmSIyVAWLjESGAmj(KXGyEgvKAlBEzlKeqCYObLtyDDCq P_0)
		{
			return P_0 switch
			{
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Keyboard => ControlDeviceType.Keyboard, 
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Joystick => ControlDeviceType.Joystick, 
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Gamepad => ControlDeviceType.Gamepad, 
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Mouse => ControlDeviceType.Mouse, 
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Flight => ControlDeviceType.Flight, 
				KXGyEgvKAlBEzlKeqCYObLtyDDCq.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void vxuvpcaYjKOgKTJuUDKRPSXNbrXd()
		{
			YqxBgucZtJhiQWNeMskNffczGJHEA = RnEIXAHWUbLbViDHnMHrHMsCOqCE(uQWANsHceIuTCUgyMYvIGLQWAZNB());
			if (YqxBgucZtJhiQWNeMskNffczGJHEA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			UXZTfPuvZAuXApxtMlSHNgOEdAKeA = YqxBgucZtJhiQWNeMskNffczGJHEA.axisCount;
			dLSExATVOfgXZqfDDiToGokXkviw = YqxBgucZtJhiQWNeMskNffczGJHEA.buttonCount;
		}

		private void RfcsHHxbtFHazovxGIPNQOvXDbvP()
		{
		}

		private string KyaoLdCSHwIqqfKlrivhbIsnPhCn()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (jMskMqLGpNhcWruWYVOpOvsfgLzC && !string.IsNullOrEmpty(YcwUpBDuSGbWawrbSnVwjjGPDBZBA)) ? YcwUpBDuSGbWawrbSnVwjjGPDBZBA : fjmbvQuFJRluCSqpeIFaiSDtqfWB, QLtnZYhtHhdqzUVAznhMUDDImAMH.ToString("X4"), new PidVid(OFyQoTLFJChUlfESstukdbijCoFeb).vendorId.ToString("X4")));
		}

		private void nAqAxPBeNHSYJAdyOPVoJFAabPPTA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = EbSrElPhXcDiUmSIyVAWLjESGAmj(ZZgoMpRIhzlRHcbFJUjLLiHnHnIb);
			P_0.hardwareIdentifier = KyaoLdCSHwIqqfKlrivhbIsnPhCn();
			P_0.hardwareAxisCount = iWNVRoYLKIjDxAhsDQhvHDyMRLltA;
			P_0.hardwareButtonCount = uEhDGSsABnbKgGMGLpnmInKzgzNO;
			P_0.hardwareHatCount = dkImGUEJAEWZpSRrLZZgjsXBnVlH;
			P_0.hw_productName = fjmbvQuFJRluCSqpeIFaiSDtqfWB;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = QLtnZYhtHhdqzUVAznhMUDDImAMH;
			P_0.hw_pidVid = new PidVid(OFyQoTLFJChUlfESstukdbijCoFeb);
			P_0.hw_isBluetoothDevice = jMskMqLGpNhcWruWYVOpOvsfgLzC;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(YcwUpBDuSGbWawrbSnVwjjGPDBZBA)) ? YcwUpBDuSGbWawrbSnVwjjGPDBZBA : string.Empty);
			P_0.definitionMatchTag = MaHHqwBmorQaCATdlSSBhtELnQHaA;
		}

		private void cLzjdzPcCQUybkUHULjryZVJTEwr(BridgedController P_0)
		{
			nAqAxPBeNHSYJAdyOPVoJFAabPPTA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = YqxBgucZtJhiQWNeMskNffczGJHEA.ToGameHardwareControllerMap();
			P_0.instanceName = UtzFfPmZNybBrzTTKDXmmZmIgKCB;
			P_0.productName = fjmbvQuFJRluCSqpeIFaiSDtqfWB;
			P_0.isXInputDevice = SEcfLgAkTAqpwjOwJuAhStSTspxlb;
			P_0.axisCount = UXZTfPuvZAuXApxtMlSHNgOEdAKeA;
			P_0.buttonCount = dLSExATVOfgXZqfDDiToGokXkviw;
			P_0.unknownControllerHats = DsfVxEnGIeBBKTmsTRLBzJadCRoAA();
			P_0.controllerTypeGuid = tmLASYdOvuShEkfwMDpsmLzJMmgvA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void uplvECRuaalPBuXVQtGmzNOcVOWq()
		{
			for (int i = 0; i < dLSExATVOfgXZqfDDiToGokXkviw; i++)
			{
				aXjqUHRyGMEZGhtjMJhDWIYNjZdq[i] = false;
			}
			for (int j = 0; j < UXZTfPuvZAuXApxtMlSHNgOEdAKeA; j++)
			{
				VOAxCDfoYZduTepvoiVbUtFygiRdb[j] = 0f;
			}
		}

		private UnknownControllerHat[] DsfVxEnGIeBBKTmsTRLBzJadCRoAA()
		{
			if (!ttsgfuHxICnhPRrtcnbGGZlIdHSc)
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

		public void UiucmEjtAjZvOaWpuxWyTsTsuyCP()
		{
			oWUpzDKwMNMXdPzBGQkgISOFffpo(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void nhRwHMJOMUToHCoWECcvBXHSvKhjA()
		{
			try
			{
				oWUpzDKwMNMXdPzBGQkgISOFffpo(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void oWUpzDKwMNMXdPzBGQkgISOFffpo(bool P_0)
		{
			if (!TKSdVyIPuHwOakOUmHGcCtmpyede)
			{
				if (P_0 && SnPJwYARTUdjlIyKsJvaqdEBSIzP != null)
				{
					SnPJwYARTUdjlIyKsJvaqdEBSIzP.Dispose();
				}
				TKSdVyIPuHwOakOUmHGcCtmpyede = true;
			}
		}

		public static int IEdWFNGsLfbksywIQwgxcVUoaUhR(luuKOpfoMKySQQUXqdSrnScCisdo P_0, luuKOpfoMKySQQUXqdSrnScCisdo P_1)
		{
			if (P_0.TUBqMHOSSBKHewiCXFxQeEWorbneA < P_1.TUBqMHOSSBKHewiCXFxQeEWorbneA)
			{
				return -1;
			}
			if (P_0.TUBqMHOSSBKHewiCXFxQeEWorbneA > P_1.TUBqMHOSSBKHewiCXFxQeEWorbneA)
			{
				return 1;
			}
			return 0;
		}

		public static int LpwfYeXnGcapwQnEXtnMynodmFT(luuKOpfoMKySQQUXqdSrnScCisdo P_0, luuKOpfoMKySQQUXqdSrnScCisdo P_1)
		{
			if (P_0.GIxPvEYlCYmtGCrBybGLvZaTbuYX < P_1.GIxPvEYlCYmtGCrBybGLvZaTbuYX)
			{
				return -1;
			}
			if (P_0.GIxPvEYlCYmtGCrBybGLvZaTbuYX > P_1.GIxPvEYlCYmtGCrBybGLvZaTbuYX)
			{
				return 1;
			}
			return 0;
		}
	}

	private class VqbdvMFmWDQOkQspiAnCJiRjjlByA : IDisposable
	{
		public class JRxcIiwDIvEHdKUNxBJmJNeZFNAj
		{
			public float TAbfoySJHSYCHDnkNeOPsTxLFwPHA;

			public float uAljlGVcNhoOuvpcbTSGmvLtYewJ;

			public float xFwBuspDlbUTjYwIrRbZjhIjqJOj;

			public float TjhJKmeiBzbyEngHAEcAdSLQWpcW;

			public float cqwhYOmpIwUvsRWhbpVNbJebnyai;

			public float ZbvprJvEYnONDiPQfeIODSOjoHwPA;

			public float[] eYiAUnDePrHyhvcpRdEvtgTCwufM;

			public readonly int[] pznyWQiJPiDQGOuvbsIhWjwQNKRW;

			public readonly bool[] BaDvCgsmiULiqLmtxLBHkTGlpadw;

			public float mgPMLqdjGLHiCGsEPpKpSzJcAwzKA;

			public float ZHxczrZgvzPyywCIidejoIDLXyPI;

			public float DcnVgcURyROMQwduwesPbKlYqoMj;

			public float vFQgpYDdLAZcJrSpNkGPJngWfItt;

			public float XfCGfuIUZzkAWyAcWkQDMPXIRfOEA;

			public float erPHVxkqgxrMkqGgPMgwLzLBNrNH;

			public readonly float[] jPbiiUumZoNOYGiqGkbWkETnLjoM;

			public float SXxovYaTErASvQLIENQqLUeFGUSo;

			public float YflbJKYTmWAZdBEslkprVUgFiXTaA;

			public float hdTGlZquVuGhRCeTLGmRYYhlQbYN;

			public float RzMuhfJeVXhlyROxcpDXOPICBTgN;

			public float nEKdAtUiwGDkeOnblEynINMURwEf;

			public float JmOZWUoAtrQrpmIFQgDkbYueNblNA;

			public readonly float[] gVptnAkLQIICzuRtDqsuWyQDsqHf;

			public float wAelOXSIxKUbLsSPWrAGsPMdxaGw;

			public float eXhpBflMcVeEsnAAjqqsMumHzOCA;

			public float JHfqwoXVamvOxfEXzAPVBALYgjCy;

			public float nADTijOOUcZQfdKdpdVIZsVpuMiX;

			public float vDSAfcKuqrPqtoWAfDsnpyamqntD;

			public float JcJMXvErquKRKbGqPfkvjZqsMnYuA;

			public readonly float[] UKEvLMxzltaRvSqhzHApbcGbEbhx;

			public JRxcIiwDIvEHdKUNxBJmJNeZFNAj()
			{
				eYiAUnDePrHyhvcpRdEvtgTCwufM = new float[2];
				pznyWQiJPiDQGOuvbsIhWjwQNKRW = new int[4];
				BaDvCgsmiULiqLmtxLBHkTGlpadw = new bool[128];
				jPbiiUumZoNOYGiqGkbWkETnLjoM = new float[2];
				gVptnAkLQIICzuRtDqsuWyQDsqHf = new float[2];
				UKEvLMxzltaRvSqhzHApbcGbEbhx = new float[2];
			}

			public void HPgiCqQBQUKsoAmEQetNIOhbcDiqA()
			{
				TAbfoySJHSYCHDnkNeOPsTxLFwPHA = 0f;
				uAljlGVcNhoOuvpcbTSGmvLtYewJ = 0f;
				xFwBuspDlbUTjYwIrRbZjhIjqJOj = 0f;
				TjhJKmeiBzbyEngHAEcAdSLQWpcW = 0f;
				cqwhYOmpIwUvsRWhbpVNbJebnyai = 0f;
				ZbvprJvEYnONDiPQfeIODSOjoHwPA = 0f;
				for (int i = 0; i < eYiAUnDePrHyhvcpRdEvtgTCwufM.Length; i++)
				{
					eYiAUnDePrHyhvcpRdEvtgTCwufM[i] = 0f;
				}
				for (int j = 0; j < pznyWQiJPiDQGOuvbsIhWjwQNKRW.Length; j++)
				{
					pznyWQiJPiDQGOuvbsIhWjwQNKRW[j] = 0;
				}
				for (int k = 0; k < BaDvCgsmiULiqLmtxLBHkTGlpadw.Length; k++)
				{
					BaDvCgsmiULiqLmtxLBHkTGlpadw[k] = false;
				}
				mgPMLqdjGLHiCGsEPpKpSzJcAwzKA = 0f;
				ZHxczrZgvzPyywCIidejoIDLXyPI = 0f;
				DcnVgcURyROMQwduwesPbKlYqoMj = 0f;
				vFQgpYDdLAZcJrSpNkGPJngWfItt = 0f;
				XfCGfuIUZzkAWyAcWkQDMPXIRfOEA = 0f;
				erPHVxkqgxrMkqGgPMgwLzLBNrNH = 0f;
				for (int l = 0; l < jPbiiUumZoNOYGiqGkbWkETnLjoM.Length; l++)
				{
					jPbiiUumZoNOYGiqGkbWkETnLjoM[l] = 0f;
				}
				SXxovYaTErASvQLIENQqLUeFGUSo = 0f;
				YflbJKYTmWAZdBEslkprVUgFiXTaA = 0f;
				hdTGlZquVuGhRCeTLGmRYYhlQbYN = 0f;
				RzMuhfJeVXhlyROxcpDXOPICBTgN = 0f;
				nEKdAtUiwGDkeOnblEynINMURwEf = 0f;
				JmOZWUoAtrQrpmIFQgDkbYueNblNA = 0f;
				for (int m = 0; m < gVptnAkLQIICzuRtDqsuWyQDsqHf.Length; m++)
				{
					gVptnAkLQIICzuRtDqsuWyQDsqHf[m] = 0f;
				}
				wAelOXSIxKUbLsSPWrAGsPMdxaGw = 0f;
				eXhpBflMcVeEsnAAjqqsMumHzOCA = 0f;
				JHfqwoXVamvOxfEXzAPVBALYgjCy = 0f;
				nADTijOOUcZQfdKdpdVIZsVpuMiX = 0f;
				vDSAfcKuqrPqtoWAfDsnpyamqntD = 0f;
				JcJMXvErquKRKbGqPfkvjZqsMnYuA = 0f;
				for (int n = 0; n < UKEvLMxzltaRvSqhzHApbcGbEbhx.Length; n++)
				{
					UKEvLMxzltaRvSqhzHApbcGbEbhx[n] = 0f;
				}
			}

			public void vALWBTVryalJoSPxVJYVVfHzBgSi(JRxcIiwDIvEHdKUNxBJmJNeZFNAj P_0)
			{
				TAbfoySJHSYCHDnkNeOPsTxLFwPHA = P_0.TAbfoySJHSYCHDnkNeOPsTxLFwPHA;
				uAljlGVcNhoOuvpcbTSGmvLtYewJ = P_0.uAljlGVcNhoOuvpcbTSGmvLtYewJ;
				xFwBuspDlbUTjYwIrRbZjhIjqJOj = P_0.xFwBuspDlbUTjYwIrRbZjhIjqJOj;
				TjhJKmeiBzbyEngHAEcAdSLQWpcW = P_0.TjhJKmeiBzbyEngHAEcAdSLQWpcW;
				cqwhYOmpIwUvsRWhbpVNbJebnyai = P_0.cqwhYOmpIwUvsRWhbpVNbJebnyai;
				ZbvprJvEYnONDiPQfeIODSOjoHwPA = P_0.ZbvprJvEYnONDiPQfeIODSOjoHwPA;
				for (int i = 0; i < eYiAUnDePrHyhvcpRdEvtgTCwufM.Length; i++)
				{
					eYiAUnDePrHyhvcpRdEvtgTCwufM[i] = P_0.eYiAUnDePrHyhvcpRdEvtgTCwufM[i];
				}
				for (int j = 0; j < pznyWQiJPiDQGOuvbsIhWjwQNKRW.Length; j++)
				{
					pznyWQiJPiDQGOuvbsIhWjwQNKRW[j] = P_0.pznyWQiJPiDQGOuvbsIhWjwQNKRW[j];
				}
				for (int k = 0; k < BaDvCgsmiULiqLmtxLBHkTGlpadw.Length; k++)
				{
					BaDvCgsmiULiqLmtxLBHkTGlpadw[k] = P_0.BaDvCgsmiULiqLmtxLBHkTGlpadw[k];
				}
				mgPMLqdjGLHiCGsEPpKpSzJcAwzKA = P_0.mgPMLqdjGLHiCGsEPpKpSzJcAwzKA;
				ZHxczrZgvzPyywCIidejoIDLXyPI = P_0.ZHxczrZgvzPyywCIidejoIDLXyPI;
				DcnVgcURyROMQwduwesPbKlYqoMj = P_0.DcnVgcURyROMQwduwesPbKlYqoMj;
				vFQgpYDdLAZcJrSpNkGPJngWfItt = P_0.vFQgpYDdLAZcJrSpNkGPJngWfItt;
				XfCGfuIUZzkAWyAcWkQDMPXIRfOEA = P_0.XfCGfuIUZzkAWyAcWkQDMPXIRfOEA;
				erPHVxkqgxrMkqGgPMgwLzLBNrNH = P_0.erPHVxkqgxrMkqGgPMgwLzLBNrNH;
				for (int l = 0; l < jPbiiUumZoNOYGiqGkbWkETnLjoM.Length; l++)
				{
					jPbiiUumZoNOYGiqGkbWkETnLjoM[l] = P_0.jPbiiUumZoNOYGiqGkbWkETnLjoM[l];
				}
				SXxovYaTErASvQLIENQqLUeFGUSo = P_0.SXxovYaTErASvQLIENQqLUeFGUSo;
				YflbJKYTmWAZdBEslkprVUgFiXTaA = P_0.YflbJKYTmWAZdBEslkprVUgFiXTaA;
				hdTGlZquVuGhRCeTLGmRYYhlQbYN = P_0.hdTGlZquVuGhRCeTLGmRYYhlQbYN;
				RzMuhfJeVXhlyROxcpDXOPICBTgN = P_0.RzMuhfJeVXhlyROxcpDXOPICBTgN;
				nEKdAtUiwGDkeOnblEynINMURwEf = P_0.nEKdAtUiwGDkeOnblEynINMURwEf;
				JmOZWUoAtrQrpmIFQgDkbYueNblNA = P_0.JmOZWUoAtrQrpmIFQgDkbYueNblNA;
				for (int m = 0; m < gVptnAkLQIICzuRtDqsuWyQDsqHf.Length; m++)
				{
					gVptnAkLQIICzuRtDqsuWyQDsqHf[m] = P_0.gVptnAkLQIICzuRtDqsuWyQDsqHf[m];
				}
				wAelOXSIxKUbLsSPWrAGsPMdxaGw = P_0.wAelOXSIxKUbLsSPWrAGsPMdxaGw;
				eXhpBflMcVeEsnAAjqqsMumHzOCA = P_0.eXhpBflMcVeEsnAAjqqsMumHzOCA;
				JHfqwoXVamvOxfEXzAPVBALYgjCy = P_0.JHfqwoXVamvOxfEXzAPVBALYgjCy;
				nADTijOOUcZQfdKdpdVIZsVpuMiX = P_0.nADTijOOUcZQfdKdpdVIZsVpuMiX;
				vDSAfcKuqrPqtoWAfDsnpyamqntD = P_0.vDSAfcKuqrPqtoWAfDsnpyamqntD;
				JcJMXvErquKRKbGqPfkvjZqsMnYuA = P_0.JcJMXvErquKRKbGqPfkvjZqsMnYuA;
				for (int n = 0; n < UKEvLMxzltaRvSqhzHApbcGbEbhx.Length; n++)
				{
					UKEvLMxzltaRvSqhzHApbcGbEbhx[n] = P_0.UKEvLMxzltaRvSqhzHApbcGbEbhx[n];
				}
			}

			public unsafe void hXIdKBajLWIpWDHDtgFCgSwpsTBBb(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						BaDvCgsmiULiqLmtxLBHkTGlpadw[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					gVptnAkLQIICzuRtDqsuWyQDsqHf[k] = *ptr;
					ptr++;
				}
				SXxovYaTErASvQLIENQqLUeFGUSo = *ptr;
				ptr++;
				YflbJKYTmWAZdBEslkprVUgFiXTaA = *ptr;
				ptr++;
				hdTGlZquVuGhRCeTLGmRYYhlQbYN = *ptr;
				ptr++;
				RzMuhfJeVXhlyROxcpDXOPICBTgN = *ptr;
				ptr++;
				nEKdAtUiwGDkeOnblEynINMURwEf = *ptr;
				ptr++;
				JmOZWUoAtrQrpmIFQgDkbYueNblNA = *ptr;
				ptr++;
				vFQgpYDdLAZcJrSpNkGPJngWfItt = *ptr;
				ptr++;
				XfCGfuIUZzkAWyAcWkQDMPXIRfOEA = *ptr;
				ptr++;
				erPHVxkqgxrMkqGgPMgwLzLBNrNH = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					UKEvLMxzltaRvSqhzHApbcGbEbhx[l] = *ptr;
					ptr++;
				}
				wAelOXSIxKUbLsSPWrAGsPMdxaGw = *ptr;
				ptr++;
				eXhpBflMcVeEsnAAjqqsMumHzOCA = *ptr;
				ptr++;
				JHfqwoXVamvOxfEXzAPVBALYgjCy = *ptr;
				ptr++;
				TjhJKmeiBzbyEngHAEcAdSLQWpcW = *ptr;
				ptr++;
				cqwhYOmpIwUvsRWhbpVNbJebnyai = *ptr;
				ptr++;
				ZbvprJvEYnONDiPQfeIODSOjoHwPA = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					eYiAUnDePrHyhvcpRdEvtgTCwufM[m] = *ptr;
					ptr++;
				}
				nADTijOOUcZQfdKdpdVIZsVpuMiX = *ptr;
				ptr++;
				vDSAfcKuqrPqtoWAfDsnpyamqntD = *ptr;
				ptr++;
				JcJMXvErquKRKbGqPfkvjZqsMnYuA = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					jPbiiUumZoNOYGiqGkbWkETnLjoM[n] = *ptr;
					ptr++;
				}
				mgPMLqdjGLHiCGsEPpKpSzJcAwzKA = *ptr;
				ptr++;
				ZHxczrZgvzPyywCIidejoIDLXyPI = *ptr;
				ptr++;
				DcnVgcURyROMQwduwesPbKlYqoMj = *ptr;
				ptr++;
				TAbfoySJHSYCHDnkNeOPsTxLFwPHA = *ptr;
				ptr++;
				uAljlGVcNhoOuvpcbTSGmvLtYewJ = *ptr;
				ptr++;
				xFwBuspDlbUTjYwIrRbZjhIjqJOj = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					pznyWQiJPiDQGOuvbsIhWjwQNKRW[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void toRXyHFHTWQefWlJppWDZHRVrpnA(zzpcvdrriRvjvEAadMHZzAdpbEDf P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.xovzsCuhmGMGHYAoxUvpsKsKdDCIA;
				int[] array2 = P_0.SPMVidzwrpjiGmusLhvCNibbgEWK;
				int[] array3 = P_0.TFqmtsGaSGbkcdolXEfcfQwJLWkh;
				int[] array4 = P_0.bvDOlPvliHOMZCCKrorXpqLJcimF;
				int[] array5 = P_0.idzdPLbdTgrafWgctYQAtWeWecON;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.FoZARmvbojxwsQLFpBVqxvvLMtKG[i])
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
					*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(array2[j]);
					ptr++;
				}
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.sajJmIASaVfxkyBQpYMPljbxCkfi);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.bkkqbbmAumTLnLinfimnIMIJcooz);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.hVffyNcwmVJHqDuhRIlAEPEhfkBD);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.swFUhfLhKVeXvHwyineAvlsdhgtYA);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.lqilxxntFrMrCiztHDkBhMNzTBBC);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.zdQgOuxOzvyQYglFYXjzxCveczPv);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.wCJBttcGNeGJeovWAuMlHLoHCgNDb);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.dpWyLhqnlLebxJJOulRqJJpGKEIS);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.wMDQVgQOyfsVSgFRYqZGAqKgJTGL);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(array3[k]);
					ptr++;
				}
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.EfdZzFNmIGMbtKiahZqyZyqBhIJH);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.aqgWQhrgYRnzVpKwfpPsUdGBJqQe);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.WXQxewkENFDPrZfEIiwleWncWjzQ);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.RfITxXmRBqkYLLopKJcKqGyMDsIg);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.FSBqIHgWNZjhneACCGfxXwzvMYzO);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.EXhhWVqaZyUSuIhhPTMFBJeJptyM);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(array4[l]);
					ptr++;
				}
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.fZXemmTwuxwwayyQMQtKkrqCytid);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.OIftGyIlLOgkvULdhUFkLPBAiIHCA);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.EypvxijpmKHUnIvGmNOBPEFEHUFq);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(array5[m]);
					ptr++;
				}
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.UYcgvudvTORwBdzRLWIPtDoCvhqS);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.gIKYccLdyeYUIWjSVQAHSBYwBQmC);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.zRKsUujTTJsWmaVRGCtCSaplhhYjA);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.hSnAadBVdKyqNVOiZmuoHfYRCWKi);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.EGaHVUnncvvFWOiYtwnTLcIhPODp);
				ptr++;
				*ptr = EgDESDNcQHgQxjXgbfAiASIHvGlAb(P_0.FGofhmdZeyPYMLSKIcIPcSCiDvESB);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int yFBMaQCTXnLbNWTApYETWAddyslB = 2;

		private const int RrBDUBGyjOlRMWaiRBAiOvzRVBeuA = 2;

		private const int HSkLFwyPYvzgLcNsCpDKmtbqFTEV = 128;

		private const int fpjQMILoWEdBnPaxfVHXoifSUHce = 32;

		private const int WPKErqWtKGIBCQsoPiPFfTulTeouA = 0;

		private const int PdDQdWyvMapQYMsIcfhEZCoowkin = 264;

		private const int jhqmakxuqjAUgnHiqHtMrjWBcuqE = 272;

		private readonly int erPIlhYebpFKFOJTZdawkwPEKBJG;

		private readonly ButtonLoopSet ujvBqDfLLjqeXBWshDuUCsooaWQvb;

		private readonly DualThreadLowLevelInputEventQueue IxXxkarWbMEQaimkwmAMqTaKOSWx;

		private maqqCdNplXzQZYDtLePFFtvyMSIn hynzcgwlGEuOIjoRnsWgHvlrNMmf;

		private readonly zzpcvdrriRvjvEAadMHZzAdpbEDf sGABjjNoMCzKWXoBpsqjjtcAVewM;

		private readonly zzpcvdrriRvjvEAadMHZzAdpbEDf EQODTGIzQhAuycnrbFPaMyZchakNd;

		private readonly object bOsKgvAnoLAPuHUmOukwWmYapucxA;

		private bool CWAFfMNbdbkvOkcWQEeoFBkGENB;

		public readonly XLCyFVnacsfmCzPCdExtsrFUiHrH dYrXUOGEvcOhNOLbEALYVURaBqhKA;

		private readonly JRxcIiwDIvEHdKUNxBJmJNeZFNAj FDknwShXOhvcnYDMENANNCSvqOvB;

		private bool oIVjkGdfQOAxzhoHVzpSktVYVSkh;

		public bool[] sgltSIzHQdiQWiWjLNoGKTUNJvDC => ujvBqDfLLjqeXBWshDuUCsooaWQvb.Current.effectiveValue;

		public JRxcIiwDIvEHdKUNxBJmJNeZFNAj FdolqVwsiUluSfOPFVxkOJswShzT => FDknwShXOhvcnYDMENANNCSvqOvB;

		public VqbdvMFmWDQOkQspiAnCJiRjjlByA(XLCyFVnacsfmCzPCdExtsrFUiHrH P_0, UpdateLoopSetting P_1)
		{
			dYrXUOGEvcOhNOLbEALYVURaBqhKA = P_0;
			erPIlhYebpFKFOJTZdawkwPEKBJG = P_0.gmfVdhqMXIrfduYDkRPNaFCKPmJN.zqXGMBRtghfrGclgpgSsVLqrBoXH;
			ujvBqDfLLjqeXBWshDuUCsooaWQvb = new ButtonLoopSet(P_1, erPIlhYebpFKFOJTZdawkwPEKBJG);
			IxXxkarWbMEQaimkwmAMqTaKOSWx = new DualThreadLowLevelInputEventQueue((int)((float)MROXnswaFDYJOaQMZFuqDWLdEBUH.QLOtUfyZkbAhGxDQNPvrDkbJpnUT * 0.25f), 128, 32, 2);
			FDknwShXOhvcnYDMENANNCSvqOvB = new JRxcIiwDIvEHdKUNxBJmJNeZFNAj();
			sGABjjNoMCzKWXoBpsqjjtcAVewM = new zzpcvdrriRvjvEAadMHZzAdpbEDf();
			EQODTGIzQhAuycnrbFPaMyZchakNd = new zzpcvdrriRvjvEAadMHZzAdpbEDf();
			bOsKgvAnoLAPuHUmOukwWmYapucxA = new object();
			if (MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm != null)
			{
				MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent += jBZOvSTiUWNlYGeZWAkkbpvMOlDNA;
			}
		}

		public void UDjwgdbDCQWJGBIgzGTRxvTGCpyK()
		{
			ujvBqDfLLjqeXBWshDuUCsooaWQvb.SetUpdateLoop(ReInput.currentUpdateLoop);
			QkYgYcwXeSujMKuQWHCSxleBDlRj();
		}

		public void kiBgjOEwlHuAckuQxmRNfbQfBqWMc()
		{
			ujvBqDfLLjqeXBWshDuUCsooaWQvb.Current.ClearWasTrueThisFrame();
		}

		public void pveRfCdYXkCQqfezxXFqMLwYZZbG()
		{
			jEJXFjbbwOGCmzRhVaXOLVfIauJhA();
			CWAFfMNbdbkvOkcWQEeoFBkGENB = true;
		}

		public void ErgkCWAaQHNAJjCXusglTvXEhbJv()
		{
			CWAFfMNbdbkvOkcWQEeoFBkGENB = false;
			jEJXFjbbwOGCmzRhVaXOLVfIauJhA();
		}

		public void lcoIwbksvwXWLRXGPaXjdvANByCU(VqbdvMFmWDQOkQspiAnCJiRjjlByA P_0)
		{
			if (P_0 == null || P_0 == this || P_0.erPIlhYebpFKFOJTZdawkwPEKBJG != erPIlhYebpFKFOJTZdawkwPEKBJG)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (bOsKgvAnoLAPuHUmOukwWmYapucxA)
			{
				lock (P_0.bOsKgvAnoLAPuHUmOukwWmYapucxA)
				{
					ujvBqDfLLjqeXBWshDuUCsooaWQvb.Import(P_0.ujvBqDfLLjqeXBWshDuUCsooaWQvb);
					FDknwShXOhvcnYDMENANNCSvqOvB.vALWBTVryalJoSPxVJYVVfHzBgSi(P_0.FDknwShXOhvcnYDMENANNCSvqOvB);
					sGABjjNoMCzKWXoBpsqjjtcAVewM.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(P_0.sGABjjNoMCzKWXoBpsqjjtcAVewM);
					EQODTGIzQhAuycnrbFPaMyZchakNd.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(P_0.EQODTGIzQhAuycnrbFPaMyZchakNd);
					if (IxXxkarWbMEQaimkwmAMqTaKOSWx.capacityBytes == P_0.IxXxkarWbMEQaimkwmAMqTaKOSWx.capacityBytes)
					{
						IxXxkarWbMEQaimkwmAMqTaKOSWx.ImportAll(P_0.IxXxkarWbMEQaimkwmAMqTaKOSWx);
					}
					hynzcgwlGEuOIjoRnsWgHvlrNMmf = maqqCdNplXzQZYDtLePFFtvyMSIn.eQhgyRRfzfMWtWxiSExwhXZbxjTH(P_0.hynzcgwlGEuOIjoRnsWgHvlrNMmf, sGABjjNoMCzKWXoBpsqjjtcAVewM);
					CWAFfMNbdbkvOkcWQEeoFBkGENB = P_0.CWAFfMNbdbkvOkcWQEeoFBkGENB;
				}
			}
		}

		public void SCuPIkKtXTXznmNyPXhaXVIQAvPE(int P_0, int P_1, int P_2, float P_3)
		{
			lock (bOsKgvAnoLAPuHUmOukwWmYapucxA)
			{
				hynzcgwlGEuOIjoRnsWgHvlrNMmf = new maqqCdNplXzQZYDtLePFFtvyMSIn(sGABjjNoMCzKWXoBpsqjjtcAVewM, P_0, P_1, P_2, P_3);
			}
		}

		private void jBZOvSTiUWNlYGeZWAkkbpvMOlDNA()
		{
			if (!CWAFfMNbdbkvOkcWQEeoFBkGENB)
			{
				return;
			}
			double realTime;
			try
			{
				dYrXUOGEvcOhNOLbEALYVURaBqhKA.NSDKvNYZpOaVoPbfUGkNHhLUOWOab(sGABjjNoMCzKWXoBpsqjjtcAVewM);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (bOsKgvAnoLAPuHUmOukwWmYapucxA)
			{
				if (hynzcgwlGEuOIjoRnsWgHvlrNMmf != null)
				{
					hynzcgwlGEuOIjoRnsWgHvlrNMmf.tmJsPfRGPDRZDFmhtOtdDptFuqad(realTime);
				}
				if (!sGABjjNoMCzKWXoBpsqjjtcAVewM.dVXKXagslvKTULXUpILDmfJEaVEm(EQODTGIzQhAuycnrbFPaMyZchakNd))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = IxXxkarWbMEQaimkwmAMqTaKOSWx.T_CreateEvent())
					{
						JRxcIiwDIvEHdKUNxBJmJNeZFNAj.toRXyHFHTWQefWlJppWDZHRVrpnA(sGABjjNoMCzKWXoBpsqjjtcAVewM, realTime, newEventWrapper.Event);
					}
					EQODTGIzQhAuycnrbFPaMyZchakNd.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(sGABjjNoMCzKWXoBpsqjjtcAVewM);
				}
			}
		}

		private void QkYgYcwXeSujMKuQWHCSxleBDlRj()
		{
			while (IxXxkarWbMEQaimkwmAMqTaKOSWx.ProcessNewEvents())
			{
				FDknwShXOhvcnYDMENANNCSvqOvB.hXIdKBajLWIpWDHDtgFCgSwpsTBBb(ref IxXxkarWbMEQaimkwmAMqTaKOSWx.currentEvent);
				for (int i = 0; i < erPIlhYebpFKFOJTZdawkwPEKBJG; i++)
				{
					ujvBqDfLLjqeXBWshDuUCsooaWQvb.SetValue(i, FDknwShXOhvcnYDMENANNCSvqOvB.BaDvCgsmiULiqLmtxLBHkTGlpadw[i], IxXxkarWbMEQaimkwmAMqTaKOSWx.currentEvent.GetTimestamp());
				}
			}
		}

		private void jEJXFjbbwOGCmzRhVaXOLVfIauJhA()
		{
			FDknwShXOhvcnYDMENANNCSvqOvB.HPgiCqQBQUKsoAmEQetNIOhbcDiqA();
			lock (bOsKgvAnoLAPuHUmOukwWmYapucxA)
			{
				sGABjjNoMCzKWXoBpsqjjtcAVewM.ONLJfRxESnbPtHUATtxGIRVbLvTFb();
				EQODTGIzQhAuycnrbFPaMyZchakNd.ONLJfRxESnbPtHUATtxGIRVbLvTFb();
				IxXxkarWbMEQaimkwmAMqTaKOSWx.Clear();
			}
			ujvBqDfLLjqeXBWshDuUCsooaWQvb.Clear();
		}

		public void Dispose()
		{
			kQPfFghAwlXLGjPYhBxSucmEtdV(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void vdDiHRJitQHqnIegEvJqSMNOunafA()
		{
			try
			{
				kQPfFghAwlXLGjPYhBxSucmEtdV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void kQPfFghAwlXLGjPYhBxSucmEtdV(bool P_0)
		{
			if (!oIVjkGdfQOAxzhoHVzpSktVYVSkh)
			{
				if (P_0)
				{
					ErgkCWAaQHNAJjCXusglTvXEhbJv();
					IxXxkarWbMEQaimkwmAMqTaKOSWx.Dispose();
				}
				if (MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm != null)
				{
					MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent -= jBZOvSTiUWNlYGeZWAkkbpvMOlDNA;
				}
				oIVjkGdfQOAxzhoHVzpSktVYVSkh = true;
			}
		}

		private static float EgDESDNcQHgQxjXgbfAiASIHvGlAb(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class maqqCdNplXzQZYDtLePFFtvyMSIn
	{
		private zzpcvdrriRvjvEAadMHZzAdpbEDf aKIFtrmRkGOGBibNCGBHAZBTPSxE;

		private RbZIIsuVYDthFgLiHarKuixQkJTs uktbHWsSUYTPkNQEQnHFitdDOyfB;

		private int lJhYPksjMwVJBBaxOpCbNuotvohf;

		private int ddyQidzZFHhdpTqcUJuiacuUoEcJ;

		private int knkbHgsVXCCMckeNTYCNeJqQaioY;

		private float OZDSeeLJQdPiXPmVsaEtPtGGfdSHA;

		public zzpcvdrriRvjvEAadMHZzAdpbEDf EVYogrfUavUmuYIpwbfUnlqLrNbT => aKIFtrmRkGOGBibNCGBHAZBTPSxE;

		public static maqqCdNplXzQZYDtLePFFtvyMSIn eQhgyRRfzfMWtWxiSExwhXZbxjTH(maqqCdNplXzQZYDtLePFFtvyMSIn P_0, zzpcvdrriRvjvEAadMHZzAdpbEDf P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new maqqCdNplXzQZYDtLePFFtvyMSIn(P_0, P_1);
		}

		public maqqCdNplXzQZYDtLePFFtvyMSIn(zzpcvdrriRvjvEAadMHZzAdpbEDf P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			uktbHWsSUYTPkNQEQnHFitdDOyfB = new RbZIIsuVYDthFgLiHarKuixQkJTs(P_0);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE = new zzpcvdrriRvjvEAadMHZzAdpbEDf();
		}

		private maqqCdNplXzQZYDtLePFFtvyMSIn(maqqCdNplXzQZYDtLePFFtvyMSIn P_0, zzpcvdrriRvjvEAadMHZzAdpbEDf P_1)
			: this(P_1, P_0.lJhYPksjMwVJBBaxOpCbNuotvohf, P_0.ddyQidzZFHhdpTqcUJuiacuUoEcJ, P_0.knkbHgsVXCCMckeNTYCNeJqQaioY, P_0.OZDSeeLJQdPiXPmVsaEtPtGGfdSHA)
		{
			fQNsPRZahaQpCstiJLSVEmvOnlRj(P_0);
		}

		private maqqCdNplXzQZYDtLePFFtvyMSIn(int P_0, int P_1, int P_2, float P_3)
		{
			lJhYPksjMwVJBBaxOpCbNuotvohf = P_0;
			ddyQidzZFHhdpTqcUJuiacuUoEcJ = P_1;
			knkbHgsVXCCMckeNTYCNeJqQaioY = P_2;
			OZDSeeLJQdPiXPmVsaEtPtGGfdSHA = P_3;
		}

		public void tmJsPfRGPDRZDFmhtOtdDptFuqad(double P_0)
		{
			uktbHWsSUYTPkNQEQnHFitdDOyfB.fWSseIhemICapRyoPULGbLjUAoHc(P_0);
			if (!uktbHWsSUYTPkNQEQnHFitdDOyfB.ffsVfXHqoZairMUXCSSiUBCJaCNO)
			{
				if (P_0 >= uktbHWsSUYTPkNQEQnHFitdDOyfB.qNxGBmVkvHAVkbZakLCzSVaUbXVm + (double)OZDSeeLJQdPiXPmVsaEtPtGGfdSHA)
				{
					aKIFtrmRkGOGBibNCGBHAZBTPSxE.ONLJfRxESnbPtHUATtxGIRVbLvTFb();
				}
				return;
			}
			zzpcvdrriRvjvEAadMHZzAdpbEDf zzpcvdrriRvjvEAadMHZzAdpbEDf2 = uktbHWsSUYTPkNQEQnHFitdDOyfB.vaWNCcoiBDpzvIEaPUImbVmssgOE;
			zzpcvdrriRvjvEAadMHZzAdpbEDf zzpcvdrriRvjvEAadMHZzAdpbEDf3 = uktbHWsSUYTPkNQEQnHFitdDOyfB.QCpUsUilBvSABIlCoYMVQJzEvrAb;
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.hSnAadBVdKyqNVOiZmuoHfYRCWKi = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.hSnAadBVdKyqNVOiZmuoHfYRCWKi);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.EGaHVUnncvvFWOiYtwnTLcIhPODp = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.EGaHVUnncvvFWOiYtwnTLcIhPODp);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.FGofhmdZeyPYMLSKIcIPcSCiDvESB = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.FGofhmdZeyPYMLSKIcIPcSCiDvESB);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.RfITxXmRBqkYLLopKJcKqGyMDsIg = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.RfITxXmRBqkYLLopKJcKqGyMDsIg);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.FSBqIHgWNZjhneACCGfxXwzvMYzO = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.FSBqIHgWNZjhneACCGfxXwzvMYzO);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.EXhhWVqaZyUSuIhhPTMFBJeJptyM = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.EXhhWVqaZyUSuIhhPTMFBJeJptyM);
			for (int i = 0; i < aKIFtrmRkGOGBibNCGBHAZBTPSxE.bvDOlPvliHOMZCCKrorXpqLJcimF.Length; i++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.bvDOlPvliHOMZCCKrorXpqLJcimF[i] = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.bvDOlPvliHOMZCCKrorXpqLJcimF[i]);
			}
			for (int j = 0; j < aKIFtrmRkGOGBibNCGBHAZBTPSxE.xovzsCuhmGMGHYAoxUvpsKsKdDCIA.Length; j++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j] = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j]);
			}
			for (int k = 0; k < aKIFtrmRkGOGBibNCGBHAZBTPSxE.FoZARmvbojxwsQLFpBVqxvvLMtKG.Length; k++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.FoZARmvbojxwsQLFpBVqxvvLMtKG[k] = zzpcvdrriRvjvEAadMHZzAdpbEDf3.FoZARmvbojxwsQLFpBVqxvvLMtKG[k];
			}
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.UYcgvudvTORwBdzRLWIPtDoCvhqS = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.UYcgvudvTORwBdzRLWIPtDoCvhqS);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.gIKYccLdyeYUIWjSVQAHSBYwBQmC = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.gIKYccLdyeYUIWjSVQAHSBYwBQmC);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.zRKsUujTTJsWmaVRGCtCSaplhhYjA = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.zRKsUujTTJsWmaVRGCtCSaplhhYjA);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.wCJBttcGNeGJeovWAuMlHLoHCgNDb = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.wCJBttcGNeGJeovWAuMlHLoHCgNDb);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.dpWyLhqnlLebxJJOulRqJJpGKEIS = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.dpWyLhqnlLebxJJOulRqJJpGKEIS);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.wMDQVgQOyfsVSgFRYqZGAqKgJTGL = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.wMDQVgQOyfsVSgFRYqZGAqKgJTGL);
			for (int l = 0; l < aKIFtrmRkGOGBibNCGBHAZBTPSxE.idzdPLbdTgrafWgctYQAtWeWecON.Length; l++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.idzdPLbdTgrafWgctYQAtWeWecON[l] = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.idzdPLbdTgrafWgctYQAtWeWecON[l]);
			}
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.sajJmIASaVfxkyBQpYMPljbxCkfi = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.sajJmIASaVfxkyBQpYMPljbxCkfi);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.bkkqbbmAumTLnLinfimnIMIJcooz = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.bkkqbbmAumTLnLinfimnIMIJcooz);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.hVffyNcwmVJHqDuhRIlAEPEhfkBD = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.hVffyNcwmVJHqDuhRIlAEPEhfkBD);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.swFUhfLhKVeXvHwyineAvlsdhgtYA = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.swFUhfLhKVeXvHwyineAvlsdhgtYA);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.lqilxxntFrMrCiztHDkBhMNzTBBC = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.lqilxxntFrMrCiztHDkBhMNzTBBC);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.zdQgOuxOzvyQYglFYXjzxCveczPv = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.zdQgOuxOzvyQYglFYXjzxCveczPv);
			for (int m = 0; m < aKIFtrmRkGOGBibNCGBHAZBTPSxE.SPMVidzwrpjiGmusLhvCNibbgEWK.Length; m++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.SPMVidzwrpjiGmusLhvCNibbgEWK[m] = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.SPMVidzwrpjiGmusLhvCNibbgEWK[m]);
			}
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.EfdZzFNmIGMbtKiahZqyZyqBhIJH = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.EfdZzFNmIGMbtKiahZqyZyqBhIJH);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.aqgWQhrgYRnzVpKwfpPsUdGBJqQe = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.aqgWQhrgYRnzVpKwfpPsUdGBJqQe);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.WXQxewkENFDPrZfEIiwleWncWjzQ = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.WXQxewkENFDPrZfEIiwleWncWjzQ);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.fZXemmTwuxwwayyQMQtKkrqCytid = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.fZXemmTwuxwwayyQMQtKkrqCytid);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.OIftGyIlLOgkvULdhUFkLPBAiIHCA = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.OIftGyIlLOgkvULdhUFkLPBAiIHCA);
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.EypvxijpmKHUnIvGmNOBPEFEHUFq = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.EypvxijpmKHUnIvGmNOBPEFEHUFq);
			for (int n = 0; n < aKIFtrmRkGOGBibNCGBHAZBTPSxE.TFqmtsGaSGbkcdolXEfcfQwJLWkh.Length; n++)
			{
				aKIFtrmRkGOGBibNCGBHAZBTPSxE.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n] = qBFBcNbWGcEBuFHWoWsrXHMpQaih(zzpcvdrriRvjvEAadMHZzAdpbEDf2.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n]);
			}
		}

		public void fQNsPRZahaQpCstiJLSVEmvOnlRj(maqqCdNplXzQZYDtLePFFtvyMSIn P_0)
		{
			aKIFtrmRkGOGBibNCGBHAZBTPSxE.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(P_0.aKIFtrmRkGOGBibNCGBHAZBTPSxE);
			uktbHWsSUYTPkNQEQnHFitdDOyfB.YbdYqHwOEcYiOKUwXcJaOaYkpBtk(P_0.uktbHWsSUYTPkNQEQnHFitdDOyfB);
			lJhYPksjMwVJBBaxOpCbNuotvohf = P_0.lJhYPksjMwVJBBaxOpCbNuotvohf;
			ddyQidzZFHhdpTqcUJuiacuUoEcJ = P_0.ddyQidzZFHhdpTqcUJuiacuUoEcJ;
			knkbHgsVXCCMckeNTYCNeJqQaioY = P_0.knkbHgsVXCCMckeNTYCNeJqQaioY;
			OZDSeeLJQdPiXPmVsaEtPtGGfdSHA = P_0.OZDSeeLJQdPiXPmVsaEtPtGGfdSHA;
		}

		private int qBFBcNbWGcEBuFHWoWsrXHMpQaih(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, lJhYPksjMwVJBBaxOpCbNuotvohf, ddyQidzZFHhdpTqcUJuiacuUoEcJ, -65535, 65535);
		}
	}

	private class RbZIIsuVYDthFgLiHarKuixQkJTs
	{
		private double wQrRwcgssKsSvYJGKlxMmsWhwSxb;

		private zzpcvdrriRvjvEAadMHZzAdpbEDf kzhhFAgyreEeVueAKxAACUldrBMB;

		private zzpcvdrriRvjvEAadMHZzAdpbEDf zjAokrvhVDturcoADLdPUeANstyD;

		private zzpcvdrriRvjvEAadMHZzAdpbEDf NkbhYIfmLSJUUitXFNxLyDtBoHTEb;

		private bool IFfXeVbjgbRXAqQDPveHwVUyrbLX;

		private double ULsBWoxAhubQgvoMpDYCgqDudxVI;

		public zzpcvdrriRvjvEAadMHZzAdpbEDf QCpUsUilBvSABIlCoYMVQJzEvrAb => kzhhFAgyreEeVueAKxAACUldrBMB;

		public zzpcvdrriRvjvEAadMHZzAdpbEDf vaWNCcoiBDpzvIEaPUImbVmssgOE => NkbhYIfmLSJUUitXFNxLyDtBoHTEb;

		public bool ffsVfXHqoZairMUXCSSiUBCJaCNO => IFfXeVbjgbRXAqQDPveHwVUyrbLX;

		public double qNxGBmVkvHAVkbZakLCzSVaUbXVm => ULsBWoxAhubQgvoMpDYCgqDudxVI;

		public RbZIIsuVYDthFgLiHarKuixQkJTs(zzpcvdrriRvjvEAadMHZzAdpbEDf P_0)
		{
			kzhhFAgyreEeVueAKxAACUldrBMB = P_0;
			zjAokrvhVDturcoADLdPUeANstyD = new zzpcvdrriRvjvEAadMHZzAdpbEDf();
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb = new zzpcvdrriRvjvEAadMHZzAdpbEDf();
		}

		public void fWSseIhemICapRyoPULGbLjUAoHc(double P_0)
		{
			wQrRwcgssKsSvYJGKlxMmsWhwSxb = P_0;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.hSnAadBVdKyqNVOiZmuoHfYRCWKi = kzhhFAgyreEeVueAKxAACUldrBMB.hSnAadBVdKyqNVOiZmuoHfYRCWKi - zjAokrvhVDturcoADLdPUeANstyD.hSnAadBVdKyqNVOiZmuoHfYRCWKi;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EGaHVUnncvvFWOiYtwnTLcIhPODp = kzhhFAgyreEeVueAKxAACUldrBMB.EGaHVUnncvvFWOiYtwnTLcIhPODp - zjAokrvhVDturcoADLdPUeANstyD.EGaHVUnncvvFWOiYtwnTLcIhPODp;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FGofhmdZeyPYMLSKIcIPcSCiDvESB = kzhhFAgyreEeVueAKxAACUldrBMB.FGofhmdZeyPYMLSKIcIPcSCiDvESB - zjAokrvhVDturcoADLdPUeANstyD.FGofhmdZeyPYMLSKIcIPcSCiDvESB;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.RfITxXmRBqkYLLopKJcKqGyMDsIg = kzhhFAgyreEeVueAKxAACUldrBMB.RfITxXmRBqkYLLopKJcKqGyMDsIg - zjAokrvhVDturcoADLdPUeANstyD.RfITxXmRBqkYLLopKJcKqGyMDsIg;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FSBqIHgWNZjhneACCGfxXwzvMYzO = kzhhFAgyreEeVueAKxAACUldrBMB.FSBqIHgWNZjhneACCGfxXwzvMYzO - zjAokrvhVDturcoADLdPUeANstyD.FSBqIHgWNZjhneACCGfxXwzvMYzO;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EXhhWVqaZyUSuIhhPTMFBJeJptyM = kzhhFAgyreEeVueAKxAACUldrBMB.EXhhWVqaZyUSuIhhPTMFBJeJptyM - zjAokrvhVDturcoADLdPUeANstyD.EXhhWVqaZyUSuIhhPTMFBJeJptyM;
			for (int i = 0; i < kzhhFAgyreEeVueAKxAACUldrBMB.bvDOlPvliHOMZCCKrorXpqLJcimF.Length; i++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.bvDOlPvliHOMZCCKrorXpqLJcimF[i] = kzhhFAgyreEeVueAKxAACUldrBMB.bvDOlPvliHOMZCCKrorXpqLJcimF[i] - zjAokrvhVDturcoADLdPUeANstyD.bvDOlPvliHOMZCCKrorXpqLJcimF[i];
			}
			for (int j = 0; j < kzhhFAgyreEeVueAKxAACUldrBMB.xovzsCuhmGMGHYAoxUvpsKsKdDCIA.Length; j++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j] = kzhhFAgyreEeVueAKxAACUldrBMB.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j] - zjAokrvhVDturcoADLdPUeANstyD.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j];
			}
			for (int k = 0; k < kzhhFAgyreEeVueAKxAACUldrBMB.FoZARmvbojxwsQLFpBVqxvvLMtKG.Length; k++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FoZARmvbojxwsQLFpBVqxvvLMtKG[k] = kzhhFAgyreEeVueAKxAACUldrBMB.FoZARmvbojxwsQLFpBVqxvvLMtKG[k] != zjAokrvhVDturcoADLdPUeANstyD.FoZARmvbojxwsQLFpBVqxvvLMtKG[k];
			}
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.UYcgvudvTORwBdzRLWIPtDoCvhqS = kzhhFAgyreEeVueAKxAACUldrBMB.UYcgvudvTORwBdzRLWIPtDoCvhqS - zjAokrvhVDturcoADLdPUeANstyD.UYcgvudvTORwBdzRLWIPtDoCvhqS;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.gIKYccLdyeYUIWjSVQAHSBYwBQmC = kzhhFAgyreEeVueAKxAACUldrBMB.gIKYccLdyeYUIWjSVQAHSBYwBQmC - zjAokrvhVDturcoADLdPUeANstyD.gIKYccLdyeYUIWjSVQAHSBYwBQmC;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.zRKsUujTTJsWmaVRGCtCSaplhhYjA = kzhhFAgyreEeVueAKxAACUldrBMB.zRKsUujTTJsWmaVRGCtCSaplhhYjA - zjAokrvhVDturcoADLdPUeANstyD.zRKsUujTTJsWmaVRGCtCSaplhhYjA;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.wCJBttcGNeGJeovWAuMlHLoHCgNDb = kzhhFAgyreEeVueAKxAACUldrBMB.wCJBttcGNeGJeovWAuMlHLoHCgNDb - zjAokrvhVDturcoADLdPUeANstyD.wCJBttcGNeGJeovWAuMlHLoHCgNDb;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.dpWyLhqnlLebxJJOulRqJJpGKEIS = kzhhFAgyreEeVueAKxAACUldrBMB.dpWyLhqnlLebxJJOulRqJJpGKEIS - zjAokrvhVDturcoADLdPUeANstyD.dpWyLhqnlLebxJJOulRqJJpGKEIS;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.wMDQVgQOyfsVSgFRYqZGAqKgJTGL = kzhhFAgyreEeVueAKxAACUldrBMB.wMDQVgQOyfsVSgFRYqZGAqKgJTGL - zjAokrvhVDturcoADLdPUeANstyD.wMDQVgQOyfsVSgFRYqZGAqKgJTGL;
			for (int l = 0; l < kzhhFAgyreEeVueAKxAACUldrBMB.idzdPLbdTgrafWgctYQAtWeWecON.Length; l++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.idzdPLbdTgrafWgctYQAtWeWecON[l] = kzhhFAgyreEeVueAKxAACUldrBMB.idzdPLbdTgrafWgctYQAtWeWecON[l] - zjAokrvhVDturcoADLdPUeANstyD.idzdPLbdTgrafWgctYQAtWeWecON[l];
			}
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.sajJmIASaVfxkyBQpYMPljbxCkfi = kzhhFAgyreEeVueAKxAACUldrBMB.sajJmIASaVfxkyBQpYMPljbxCkfi - zjAokrvhVDturcoADLdPUeANstyD.sajJmIASaVfxkyBQpYMPljbxCkfi;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.bkkqbbmAumTLnLinfimnIMIJcooz = kzhhFAgyreEeVueAKxAACUldrBMB.bkkqbbmAumTLnLinfimnIMIJcooz - zjAokrvhVDturcoADLdPUeANstyD.bkkqbbmAumTLnLinfimnIMIJcooz;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.hVffyNcwmVJHqDuhRIlAEPEhfkBD = kzhhFAgyreEeVueAKxAACUldrBMB.hVffyNcwmVJHqDuhRIlAEPEhfkBD - zjAokrvhVDturcoADLdPUeANstyD.hVffyNcwmVJHqDuhRIlAEPEhfkBD;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.swFUhfLhKVeXvHwyineAvlsdhgtYA = kzhhFAgyreEeVueAKxAACUldrBMB.swFUhfLhKVeXvHwyineAvlsdhgtYA - zjAokrvhVDturcoADLdPUeANstyD.swFUhfLhKVeXvHwyineAvlsdhgtYA;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.lqilxxntFrMrCiztHDkBhMNzTBBC = kzhhFAgyreEeVueAKxAACUldrBMB.lqilxxntFrMrCiztHDkBhMNzTBBC - zjAokrvhVDturcoADLdPUeANstyD.lqilxxntFrMrCiztHDkBhMNzTBBC;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.zdQgOuxOzvyQYglFYXjzxCveczPv = kzhhFAgyreEeVueAKxAACUldrBMB.zdQgOuxOzvyQYglFYXjzxCveczPv - zjAokrvhVDturcoADLdPUeANstyD.zdQgOuxOzvyQYglFYXjzxCveczPv;
			for (int m = 0; m < kzhhFAgyreEeVueAKxAACUldrBMB.SPMVidzwrpjiGmusLhvCNibbgEWK.Length; m++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.SPMVidzwrpjiGmusLhvCNibbgEWK[m] = kzhhFAgyreEeVueAKxAACUldrBMB.SPMVidzwrpjiGmusLhvCNibbgEWK[m] - zjAokrvhVDturcoADLdPUeANstyD.SPMVidzwrpjiGmusLhvCNibbgEWK[m];
			}
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EfdZzFNmIGMbtKiahZqyZyqBhIJH = kzhhFAgyreEeVueAKxAACUldrBMB.EfdZzFNmIGMbtKiahZqyZyqBhIJH - zjAokrvhVDturcoADLdPUeANstyD.EfdZzFNmIGMbtKiahZqyZyqBhIJH;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.aqgWQhrgYRnzVpKwfpPsUdGBJqQe = kzhhFAgyreEeVueAKxAACUldrBMB.aqgWQhrgYRnzVpKwfpPsUdGBJqQe - zjAokrvhVDturcoADLdPUeANstyD.aqgWQhrgYRnzVpKwfpPsUdGBJqQe;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.WXQxewkENFDPrZfEIiwleWncWjzQ = kzhhFAgyreEeVueAKxAACUldrBMB.WXQxewkENFDPrZfEIiwleWncWjzQ - zjAokrvhVDturcoADLdPUeANstyD.WXQxewkENFDPrZfEIiwleWncWjzQ;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.fZXemmTwuxwwayyQMQtKkrqCytid = kzhhFAgyreEeVueAKxAACUldrBMB.fZXemmTwuxwwayyQMQtKkrqCytid - zjAokrvhVDturcoADLdPUeANstyD.fZXemmTwuxwwayyQMQtKkrqCytid;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.OIftGyIlLOgkvULdhUFkLPBAiIHCA = kzhhFAgyreEeVueAKxAACUldrBMB.OIftGyIlLOgkvULdhUFkLPBAiIHCA - zjAokrvhVDturcoADLdPUeANstyD.OIftGyIlLOgkvULdhUFkLPBAiIHCA;
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EypvxijpmKHUnIvGmNOBPEFEHUFq = kzhhFAgyreEeVueAKxAACUldrBMB.EypvxijpmKHUnIvGmNOBPEFEHUFq - zjAokrvhVDturcoADLdPUeANstyD.EypvxijpmKHUnIvGmNOBPEFEHUFq;
			for (int n = 0; n < kzhhFAgyreEeVueAKxAACUldrBMB.TFqmtsGaSGbkcdolXEfcfQwJLWkh.Length; n++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n] = kzhhFAgyreEeVueAKxAACUldrBMB.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n] - zjAokrvhVDturcoADLdPUeANstyD.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n];
			}
			IFfXeVbjgbRXAqQDPveHwVUyrbLX = UroyzBOGmeUUXejlWsZFuRZQGAvU();
			if (IFfXeVbjgbRXAqQDPveHwVUyrbLX)
			{
				ULsBWoxAhubQgvoMpDYCgqDudxVI = P_0;
				zjAokrvhVDturcoADLdPUeANstyD.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(kzhhFAgyreEeVueAKxAACUldrBMB);
			}
		}

		public void YbdYqHwOEcYiOKUwXcJaOaYkpBtk(RbZIIsuVYDthFgLiHarKuixQkJTs P_0)
		{
			wQrRwcgssKsSvYJGKlxMmsWhwSxb = P_0.wQrRwcgssKsSvYJGKlxMmsWhwSxb;
			zjAokrvhVDturcoADLdPUeANstyD.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(P_0.zjAokrvhVDturcoADLdPUeANstyD);
			NkbhYIfmLSJUUitXFNxLyDtBoHTEb.TvnsjcUGSpSJKTfYzfXiCqKfmAamA(P_0.NkbhYIfmLSJUUitXFNxLyDtBoHTEb);
		}

		private bool UroyzBOGmeUUXejlWsZFuRZQGAvU()
		{
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EGaHVUnncvvFWOiYtwnTLcIhPODp != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FGofhmdZeyPYMLSKIcIPcSCiDvESB != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.RfITxXmRBqkYLLopKJcKqGyMDsIg != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FSBqIHgWNZjhneACCGfxXwzvMYzO != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EXhhWVqaZyUSuIhhPTMFBJeJptyM != 0)
			{
				return true;
			}
			for (int i = 0; i < kzhhFAgyreEeVueAKxAACUldrBMB.bvDOlPvliHOMZCCKrorXpqLJcimF.Length; i++)
			{
				if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.bvDOlPvliHOMZCCKrorXpqLJcimF[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < kzhhFAgyreEeVueAKxAACUldrBMB.xovzsCuhmGMGHYAoxUvpsKsKdDCIA.Length; j++)
			{
				if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.xovzsCuhmGMGHYAoxUvpsKsKdDCIA[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < kzhhFAgyreEeVueAKxAACUldrBMB.FoZARmvbojxwsQLFpBVqxvvLMtKG.Length; k++)
			{
				if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.FoZARmvbojxwsQLFpBVqxvvLMtKG[k])
				{
					return true;
				}
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.UYcgvudvTORwBdzRLWIPtDoCvhqS != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.gIKYccLdyeYUIWjSVQAHSBYwBQmC != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.zRKsUujTTJsWmaVRGCtCSaplhhYjA != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.wCJBttcGNeGJeovWAuMlHLoHCgNDb != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.dpWyLhqnlLebxJJOulRqJJpGKEIS != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.wMDQVgQOyfsVSgFRYqZGAqKgJTGL != 0)
			{
				return true;
			}
			for (int l = 0; l < kzhhFAgyreEeVueAKxAACUldrBMB.idzdPLbdTgrafWgctYQAtWeWecON.Length; l++)
			{
				if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.idzdPLbdTgrafWgctYQAtWeWecON[l] != 0)
				{
					return true;
				}
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.sajJmIASaVfxkyBQpYMPljbxCkfi != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.bkkqbbmAumTLnLinfimnIMIJcooz != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.hVffyNcwmVJHqDuhRIlAEPEhfkBD != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.swFUhfLhKVeXvHwyineAvlsdhgtYA != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.lqilxxntFrMrCiztHDkBhMNzTBBC != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.zdQgOuxOzvyQYglFYXjzxCveczPv != 0)
			{
				return true;
			}
			for (int m = 0; m < kzhhFAgyreEeVueAKxAACUldrBMB.SPMVidzwrpjiGmusLhvCNibbgEWK.Length; m++)
			{
				NkbhYIfmLSJUUitXFNxLyDtBoHTEb.SPMVidzwrpjiGmusLhvCNibbgEWK[m] = kzhhFAgyreEeVueAKxAACUldrBMB.SPMVidzwrpjiGmusLhvCNibbgEWK[m] - zjAokrvhVDturcoADLdPUeANstyD.SPMVidzwrpjiGmusLhvCNibbgEWK[m];
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EfdZzFNmIGMbtKiahZqyZyqBhIJH != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.aqgWQhrgYRnzVpKwfpPsUdGBJqQe != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.WXQxewkENFDPrZfEIiwleWncWjzQ != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.fZXemmTwuxwwayyQMQtKkrqCytid != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.OIftGyIlLOgkvULdhUFkLPBAiIHCA != 0)
			{
				return true;
			}
			if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.EypvxijpmKHUnIvGmNOBPEFEHUFq != 0)
			{
				return true;
			}
			for (int n = 0; n < kzhhFAgyreEeVueAKxAACUldrBMB.TFqmtsGaSGbkcdolXEfcfQwJLWkh.Length; n++)
			{
				if (NkbhYIfmLSJUUitXFNxLyDtBoHTEb.TFqmtsGaSGbkcdolXEfcfQwJLWkh[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class FMcqEiprSQYZcLJpSLmSLAcbBUsh
	{
		public enum zvdbpGGVbcKmiLfcrLuDBgtMTTkvA
		{
			Exact = 0,
			Approximate = 1
		}

		public class JAiYTxxAqSZdtfNtAAsQZvZZNWg
		{
			public int nXkMTDxWlyEvEexgbsungZdCPANb;

			public Guid fbyoguCiVzlkCQZeOldQEJSsXzmN;

			public Guid nhGBerKCPOIXQseVTOeYIBIrDbfbA;

			public int sWxoArjpDCuQBzGqqborHUqABiodb;

			public int zdxqocmVHjTjekNLXBFWwbLysWBC;

			public int IEHpetvHRnRoAwwlgZhHJRvaQKde;

			public int tqUuUsNgkxFQRDxahdiigyFyceEgb;

			public bool aKnFnTQriMItUxbZmZNsANyVAbuG(luuKOpfoMKySQQUXqdSrnScCisdo P_0, zvdbpGGVbcKmiLfcrLuDBgtMTTkvA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == nXkMTDxWlyEvEexgbsungZdCPANb)
				{
					return true;
				}
				if (zdxqocmVHjTjekNLXBFWwbLysWBC != P_0.iWNVRoYLKIjDxAhsDQhvHDyMRLltA)
				{
					return false;
				}
				if (IEHpetvHRnRoAwwlgZhHJRvaQKde != P_0.uEhDGSsABnbKgGMGLpnmInKzgzNO)
				{
					return false;
				}
				if (tqUuUsNgkxFQRDxahdiigyFyceEgb != P_0.dkImGUEJAEWZpSRrLZZgjsXBnVlH)
				{
					return false;
				}
				return P_1 switch
				{
					zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Exact => fbyoguCiVzlkCQZeOldQEJSsXzmN == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Approximate => nhGBerKCPOIXQseVTOeYIBIrDbfbA == P_0.utcEvDhYdeKaYMulsPoCFQOSHMjuA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string vvluCkkJbgofJlMTRazvhdZlORbEA()
			{
				string text = "" + "rewiredId = " + nXkMTDxWlyEvEexgbsungZdCPANb + "\n";
				Guid guid = fbyoguCiVzlkCQZeOldQEJSsXzmN;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = nhGBerKCPOIXQseVTOeYIBIrDbfbA;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", sWxoArjpDCuQBzGqqborHUqABiodb.ToString(), "\n"), "hardwareAxisCount = ", zdxqocmVHjTjekNLXBFWwbLysWBC.ToString(), "\n"), "hardwareButtonCount = ", IEHpetvHRnRoAwwlgZhHJRvaQKde.ToString(), "\n"), "hardwareHatCount = ", tqUuUsNgkxFQRDxahdiigyFyceEgb.ToString(), "\n");
			}
		}

		private sealed class phTEnXkkoAPelAgeKvUudXoTuOeD : IEnumerable<JAiYTxxAqSZdtfNtAAsQZvZZNWg>, IEnumerable, IEnumerator<JAiYTxxAqSZdtfNtAAsQZvZZNWg>, IEnumerator, IDisposable
		{
			private int pBwUnBOMzqNIcMjbaqLWmlnYNliB;

			private JAiYTxxAqSZdtfNtAAsQZvZZNWg bfMSOzcAWRgXIzpVVzDwspWbNZNS;

			private int mGTlWOzcAIOxOBpInkKFMAZnoBLF;

			public FMcqEiprSQYZcLJpSLmSLAcbBUsh IonWWeifogkykiVimpTGiwOdEsan;

			private luuKOpfoMKySQQUXqdSrnScCisdo kAbdubDLmUUqtnSpMIIoFMTHWfcFA;

			public luuKOpfoMKySQQUXqdSrnScCisdo DmcfxWqTGUYbZBPzAUvSRjbLkOAo;

			private zvdbpGGVbcKmiLfcrLuDBgtMTTkvA xQHMyKRnGenQLjjZyPVYJhHlwguT;

			public zvdbpGGVbcKmiLfcrLuDBgtMTTkvA yScfxruzwtSKFgINiclKMmIDdoyN;

			private int mqHnjtIcPMtxthjPAueaFOFAgitx;

			private int NLuxblAoJNZLkrqAeSwQdRKcuKW;

			JAiYTxxAqSZdtfNtAAsQZvZZNWg IEnumerator<JAiYTxxAqSZdtfNtAAsQZvZZNWg>.Current
			{
				[DebuggerHidden]
				get
				{
					return bfMSOzcAWRgXIzpVVzDwspWbNZNS;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bfMSOzcAWRgXIzpVVzDwspWbNZNS;
				}
			}

			[DebuggerHidden]
			public phTEnXkkoAPelAgeKvUudXoTuOeD(int P_0)
			{
				pBwUnBOMzqNIcMjbaqLWmlnYNliB = P_0;
				mGTlWOzcAIOxOBpInkKFMAZnoBLF = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				pBwUnBOMzqNIcMjbaqLWmlnYNliB = -2;
			}

			private bool MoveNext()
			{
				int num = pBwUnBOMzqNIcMjbaqLWmlnYNliB;
				FMcqEiprSQYZcLJpSLmSLAcbBUsh ionWWeifogkykiVimpTGiwOdEsan = IonWWeifogkykiVimpTGiwOdEsan;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					pBwUnBOMzqNIcMjbaqLWmlnYNliB = -1;
					goto IL_0083;
				}
				pBwUnBOMzqNIcMjbaqLWmlnYNliB = -1;
				mqHnjtIcPMtxthjPAueaFOFAgitx = ionWWeifogkykiVimpTGiwOdEsan.okJsfUJdcVSPnPcyTIuuVEMahLMn.Count;
				NLuxblAoJNZLkrqAeSwQdRKcuKW = 0;
				goto IL_0093;
				IL_0083:
				NLuxblAoJNZLkrqAeSwQdRKcuKW++;
				goto IL_0093;
				IL_0093:
				if (NLuxblAoJNZLkrqAeSwQdRKcuKW < mqHnjtIcPMtxthjPAueaFOFAgitx)
				{
					if (ionWWeifogkykiVimpTGiwOdEsan.okJsfUJdcVSPnPcyTIuuVEMahLMn[NLuxblAoJNZLkrqAeSwQdRKcuKW].aKnFnTQriMItUxbZmZNsANyVAbuG(kAbdubDLmUUqtnSpMIIoFMTHWfcFA, xQHMyKRnGenQLjjZyPVYJhHlwguT))
					{
						bfMSOzcAWRgXIzpVVzDwspWbNZNS = ionWWeifogkykiVimpTGiwOdEsan.okJsfUJdcVSPnPcyTIuuVEMahLMn[NLuxblAoJNZLkrqAeSwQdRKcuKW];
						pBwUnBOMzqNIcMjbaqLWmlnYNliB = 1;
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
			IEnumerator<JAiYTxxAqSZdtfNtAAsQZvZZNWg> IEnumerable<JAiYTxxAqSZdtfNtAAsQZvZZNWg>.GetEnumerator()
			{
				phTEnXkkoAPelAgeKvUudXoTuOeD phTEnXkkoAPelAgeKvUudXoTuOeD2;
				if (pBwUnBOMzqNIcMjbaqLWmlnYNliB == -2 && mGTlWOzcAIOxOBpInkKFMAZnoBLF == Environment.CurrentManagedThreadId)
				{
					pBwUnBOMzqNIcMjbaqLWmlnYNliB = 0;
					phTEnXkkoAPelAgeKvUudXoTuOeD2 = this;
				}
				else
				{
					phTEnXkkoAPelAgeKvUudXoTuOeD2 = new phTEnXkkoAPelAgeKvUudXoTuOeD(0);
					phTEnXkkoAPelAgeKvUudXoTuOeD2.IonWWeifogkykiVimpTGiwOdEsan = IonWWeifogkykiVimpTGiwOdEsan;
				}
				phTEnXkkoAPelAgeKvUudXoTuOeD2.kAbdubDLmUUqtnSpMIIoFMTHWfcFA = DmcfxWqTGUYbZBPzAUvSRjbLkOAo;
				phTEnXkkoAPelAgeKvUudXoTuOeD2.xQHMyKRnGenQLjjZyPVYJhHlwguT = yScfxruzwtSKFgINiclKMmIDdoyN;
				return phTEnXkkoAPelAgeKvUudXoTuOeD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JAiYTxxAqSZdtfNtAAsQZvZZNWg>)this).GetEnumerator();
			}
		}

		private List<JAiYTxxAqSZdtfNtAAsQZvZZNWg> okJsfUJdcVSPnPcyTIuuVEMahLMn;

		public FMcqEiprSQYZcLJpSLmSLAcbBUsh()
		{
			okJsfUJdcVSPnPcyTIuuVEMahLMn = new List<JAiYTxxAqSZdtfNtAAsQZvZZNWg>();
		}

		public void tHZzqUymchaYPFwtPfOsQDxiwnpE(luuKOpfoMKySQQUXqdSrnScCisdo P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = okJsfUJdcVSPnPcyTIuuVEMahLMn.Count;
			for (int i = 0; i < count; i++)
			{
				if (okJsfUJdcVSPnPcyTIuuVEMahLMn[i].aKnFnTQriMItUxbZmZNsANyVAbuG(P_0, zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Exact))
				{
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].nXkMTDxWlyEvEexgbsungZdCPANb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].fbyoguCiVzlkCQZeOldQEJSsXzmN = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].nhGBerKCPOIXQseVTOeYIBIrDbfbA = P_0.utcEvDhYdeKaYMulsPoCFQOSHMjuA;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].sWxoArjpDCuQBzGqqborHUqABiodb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].zdxqocmVHjTjekNLXBFWwbLysWBC = P_0.iWNVRoYLKIjDxAhsDQhvHDyMRLltA;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].IEHpetvHRnRoAwwlgZhHJRvaQKde = P_0.uEhDGSsABnbKgGMGLpnmInKzgzNO;
					okJsfUJdcVSPnPcyTIuuVEMahLMn[i].tqUuUsNgkxFQRDxahdiigyFyceEgb = P_0.dkImGUEJAEWZpSRrLZZgjsXBnVlH;
					fmzeSstMYOVrAWGgTWDPfAyndDsh(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			okJsfUJdcVSPnPcyTIuuVEMahLMn.Add(new JAiYTxxAqSZdtfNtAAsQZvZZNWg
			{
				nXkMTDxWlyEvEexgbsungZdCPANb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				fbyoguCiVzlkCQZeOldQEJSsXzmN = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				nhGBerKCPOIXQseVTOeYIBIrDbfbA = P_0.utcEvDhYdeKaYMulsPoCFQOSHMjuA,
				sWxoArjpDCuQBzGqqborHUqABiodb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				zdxqocmVHjTjekNLXBFWwbLysWBC = P_0.iWNVRoYLKIjDxAhsDQhvHDyMRLltA,
				IEHpetvHRnRoAwwlgZhHJRvaQKde = P_0.uEhDGSsABnbKgGMGLpnmInKzgzNO,
				tqUuUsNgkxFQRDxahdiigyFyceEgb = P_0.dkImGUEJAEWZpSRrLZZgjsXBnVlH
			});
			fmzeSstMYOVrAWGgTWDPfAyndDsh(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, okJsfUJdcVSPnPcyTIuuVEMahLMn.Count - 1);
		}

		public bool uNzYSLHeBTAbTpikHSvFUGZODpMiA(luuKOpfoMKySQQUXqdSrnScCisdo P_0, zvdbpGGVbcKmiLfcrLuDBgtMTTkvA P_1)
		{
			int count = okJsfUJdcVSPnPcyTIuuVEMahLMn.Count;
			for (int i = 0; i < count; i++)
			{
				if (okJsfUJdcVSPnPcyTIuuVEMahLMn[i].aKnFnTQriMItUxbZmZNsANyVAbuG(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(phTEnXkkoAPelAgeKvUudXoTuOeD))]
		public IEnumerable<JAiYTxxAqSZdtfNtAAsQZvZZNWg> LbnsxDzLxoyPtNlAgaHKFZtUSoDm(luuKOpfoMKySQQUXqdSrnScCisdo P_0, zvdbpGGVbcKmiLfcrLuDBgtMTTkvA P_1)
		{
			return new phTEnXkkoAPelAgeKvUudXoTuOeD(-2)
			{
				IonWWeifogkykiVimpTGiwOdEsan = this,
				DmcfxWqTGUYbZBPzAUvSRjbLkOAo = P_0,
				yScfxruzwtSKFgINiclKMmIDdoyN = P_1
			};
		}

		private void fmzeSstMYOVrAWGgTWDPfAyndDsh(int P_0, Guid P_1, int P_2)
		{
			for (int num = okJsfUJdcVSPnPcyTIuuVEMahLMn.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (okJsfUJdcVSPnPcyTIuuVEMahLMn[num].nXkMTDxWlyEvEexgbsungZdCPANb == P_0 || okJsfUJdcVSPnPcyTIuuVEMahLMn[num].fbyoguCiVzlkCQZeOldQEJSsXzmN == P_1))
				{
					okJsfUJdcVSPnPcyTIuuVEMahLMn.RemoveAt(num);
				}
			}
		}

		public virtual string LGXyoKVveeoIuullDJbqSjLoGLXp()
		{
			string text = "";
			text = text + "Joystick records: " + okJsfUJdcVSPnPcyTIuuVEMahLMn.Count + "\n";
			for (int i = 0; i < okJsfUJdcVSPnPcyTIuuVEMahLMn.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + okJsfUJdcVSPnPcyTIuuVEMahLMn[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class FiwAFwgOgNWitFHTqiuHzZSWBmIgb
	{
		public luuKOpfoMKySQQUXqdSrnScCisdo JTGjPoIkLZWhgOnIgvqFtRTUwfQE;

		public JwOsKFPjPBIlckyhencRQGSXVgXH VEMYdTSsWqamsXHPgfnjZZvMgISF;

		public bool EITJsBPEcmGTbiobZQCwPjqQtkRx
		{
			get
			{
				if (JTGjPoIkLZWhgOnIgvqFtRTUwfQE != null)
				{
					return VEMYdTSsWqamsXHPgfnjZZvMgISF != null;
				}
				return false;
			}
		}

		public FiwAFwgOgNWitFHTqiuHzZSWBmIgb(luuKOpfoMKySQQUXqdSrnScCisdo P_0, JwOsKFPjPBIlckyhencRQGSXVgXH P_1)
		{
			JTGjPoIkLZWhgOnIgvqFtRTUwfQE = P_0;
			VEMYdTSsWqamsXHPgfnjZZvMgISF = P_1;
		}

		public static List<JwOsKFPjPBIlckyhencRQGSXVgXH> RZbiOuekSudeyjRUrnbscRFGApPuB(List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> P_0)
		{
			if (P_0 == null)
			{
				return new List<JwOsKFPjPBIlckyhencRQGSXVgXH>();
			}
			List<JwOsKFPjPBIlckyhencRQGSXVgXH> list = new List<JwOsKFPjPBIlckyhencRQGSXVgXH>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].EITJsBPEcmGTbiobZQCwPjqQtkRx)
				{
					list.Add(P_0[i].VEMYdTSsWqamsXHPgfnjZZvMgISF);
				}
			}
			return list;
		}
	}

	private class KuJgHAcwCiRonAHmNaghXtDyJiZkA
	{
		public XLCyFVnacsfmCzPCdExtsrFUiHrH rKldCMWDEupwQQzzcNriqyBDdqjJ;

		public KuJgHAcwCiRonAHmNaghXtDyJiZkA(XLCyFVnacsfmCzPCdExtsrFUiHrH P_0)
		{
			rKldCMWDEupwQQzzcNriqyBDdqjJ = P_0;
		}
	}

	private class mdUbwTXwpRrEfoBxfOxxjLHrJdOI
	{
		private NdRiAmexVWvVwTHuwkBEqGMveRHCb.lmgBnJPlPScuYnCMwfdJctxqKeMn WNYwmuodQxTqqQkLkQaoxWRKjFkF;

		private NdRiAmexVWvVwTHuwkBEqGMveRHCb.IeBofFVxiLBEPKvLtDAJIsCtAdaw AoykMnRjhNkrHbtBtMYCfcfsDVAU;

		private NativeBuffer sWuXxphclPobgpIARqIjEEXIaElKA;

		private int JHyuVGoZwJNtwZAMdaJbyEuFVosU;

		public mdUbwTXwpRrEfoBxfOxxjLHrJdOI()
		{
			WNYwmuodQxTqqQkLkQaoxWRKjFkF = new NdRiAmexVWvVwTHuwkBEqGMveRHCb.lmgBnJPlPScuYnCMwfdJctxqKeMn
			{
				foxZffKvmebaISAiUiFYMZSNNVjf = (uint)Marshal.SizeOf(typeof(NdRiAmexVWvVwTHuwkBEqGMveRHCb.lmgBnJPlPScuYnCMwfdJctxqKeMn)),
				dnhtdSNneMfzzGTzHJZzYHyjZQWj = true,
				xxueEUJuyZZTSegRHdKgnHiCgeeq = true,
				nWqcLYOfYTpYYRDQqyvpiGYIHUIT = false,
				bSVxIwwNLefroGhhXWoZtRfaerQKA = true,
				wVIRXWGVEKBmvRGunVEqnWSQbkjM = IntPtr.Zero
			};
			AoykMnRjhNkrHbtBtMYCfcfsDVAU = NdRiAmexVWvVwTHuwkBEqGMveRHCb.IeBofFVxiLBEPKvLtDAJIsCtAdaw.RbRYINKsAveGqWdJcBQUuKiReSVEA();
			sWuXxphclPobgpIARqIjEEXIaElKA = new NativeBuffer((int)AoykMnRjhNkrHbtBtMYCfcfsDVAU.qNtdvKhjuSyPxBUQtgiYIyUFuDRKA);
			sWuXxphclPobgpIARqIjEEXIaElKA.Write(AoykMnRjhNkrHbtBtMYCfcfsDVAU.qNtdvKhjuSyPxBUQtgiYIyUFuDRKA, 0);
		}

		public bool aTTNrncISOWBHdqOWGhaaHsRdiEFb()
		{
			int num = TYpOKlYZNtMPiFyVXelebWOjdokQ();
			if (num == JHyuVGoZwJNtwZAMdaJbyEuFVosU)
			{
				return false;
			}
			JHyuVGoZwJNtwZAMdaJbyEuFVosU = num;
			return true;
		}

		public void yBUyVGjEorkCRMSZyHlkCotKnHCu(int P_0)
		{
			JHyuVGoZwJNtwZAMdaJbyEuFVosU = P_0;
		}

		private int TYpOKlYZNtMPiFyVXelebWOjdokQ()
		{
			try
			{
				return IEUIaTGMEWhWxjxHtLvNddZfncnz.BDjEYUbgIZMlgZfoDTldUcYGpNaIA(ref WNYwmuodQxTqqQkLkQaoxWRKjFkF, sWuXxphclPobgpIARqIjEEXIaElKA);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum KXGyEgvKAlBEzlKeqCYObLtyDDCq
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

	private const pmRDleZVtcRYlUxVUfzrdFpkQOVP fBsheIYoeArlxdmpkyVrheadfgOY = pmRDleZVtcRYlUxVUfzrdFpkQOVP.GameControl;

	private const LbziXCvUMpGuSDqUEbtTQoRYShyk LVGIJaJIWJDQzMzOrjNcFnieMpwB = LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly;

	private IntPtr FePtxZSpSYyNXYRTbhoKJNXxdqmd;

	private CGQDElZkrsIdyOndrzkMvJbpsuKb jmAWbSIoCFXzdZeoJNjoqLxsJbCv;

	private List<luuKOpfoMKySQQUXqdSrnScCisdo> CQZnCtbWsiDJVzWbnwpFsaxfdosR;

	private int kiyNOQqeALazKzULqbrDiCLPoYaT;

	private FMcqEiprSQYZcLJpSLmSLAcbBUsh OEFMqSmzuZTijybLEUgiqwGnFvDr;

	private bool wSHaLeGKhRvdDLgOqUhFVtdvHOgS;

	private AHuLsFUDywwjZMRMOCnliKJcVPho PIhQjlstRRLUEZyJFkcHauYXIvuO;

	private UpdateLoopSetting kJnOctHAdccwrCVMcWIaNhnbtnuNA;

	private Action<int, ControllerDataUpdater> whDhYFacDgebDyQeHGlQJNxaZKSG;

	private PlatformInputManager mqvAIUGjLWMvrzGclAnpJxBzaqVDb;

	private TimerRealTime CWOxlFXUkxQCsBWOqWkSeKFmjGZD;

	private global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool> CvObPpGkhhKMdUfNQeRwTLFJNVoyA;

	private mdUbwTXwpRrEfoBxfOxxjLHrJdOI IbseUtFBhkWxRtTJVyXTSVgnruMUA;

	private int mbPYOdCfAECEGkStjnOmlHsGvXoj;

	private int frPdysbpbSpHeaRjCwPoBksdhnbMB;

	private global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb>> VrtTuqitIDxxbCunbOrWaVYGuXpG;

	private readonly object PzuhcBKabpgoRGJcYnZArjfgHfLqA = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> hkhOZPuBnWvMeTpqVdDasOxyDUnk;

	private Func<int> WbOCeXxRRanhaztZzswSYyYSLWSq;

	AHuLsFUDywwjZMRMOCnliKJcVPho EvYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK
	{
		get
		{
			return PIhQjlstRRLUEZyJFkcHauYXIvuO;
		}
		set
		{
			PIhQjlstRRLUEZyJFkcHauYXIvuO = pIhQjlstRRLUEZyJFkcHauYXIvuO;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => kiyNOQqeALazKzULqbrDiCLPoYaT;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => mqvAIUGjLWMvrzGclAnpJxBzaqVDb;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<CGQDElZkrsIdyOndrzkMvJbpsuKb>(jmAWbSIoCFXzdZeoJNjoqLxsJbCv);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public laCHEXrFQKVPafsRtaZTamLraAteb(UpdateLoopSetting P_0, AHuLsFUDywwjZMRMOCnliKJcVPho P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			kJnOctHAdccwrCVMcWIaNhnbtnuNA = P_0;
			PIhQjlstRRLUEZyJFkcHauYXIvuO = P_1;
			FePtxZSpSYyNXYRTbhoKJNXxdqmd = P_2;
			hkhOZPuBnWvMeTpqVdDasOxyDUnk = P_3;
			WbOCeXxRRanhaztZzswSYyYSLWSq = P_4;
			mqvAIUGjLWMvrzGclAnpJxBzaqVDb = this;
			jmAWbSIoCFXzdZeoJNjoqLxsJbCv = new CGQDElZkrsIdyOndrzkMvJbpsuKb();
			whDhYFacDgebDyQeHGlQJNxaZKSG = UpdateControllerData;
			IbseUtFBhkWxRtTJVyXTSVgnruMUA = new mdUbwTXwpRrEfoBxfOxxjLHrJdOI();
			CvObPpGkhhKMdUfNQeRwTLFJNVoyA = new global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool>(true, DlPoJzMyAyJXRPhRptSBixCnnOYn);
			VrtTuqitIDxxbCunbOrWaVYGuXpG = new global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb>>(true, () => EpfzCFhubTDKIYMscRjNoZpRGGee());
			YGDLZhFRBzJkQyeutCDvckCQAENbA();
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
		OEFMqSmzuZTijybLEUgiqwGnFvDr = new FMcqEiprSQYZcLJpSLmSLAcbBUsh();
		CWOxlFXUkxQCsBWOqWkSeKFmjGZD = new TimerRealTime(1.0);
		CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Start();
		eXoGhJOamSdQOCbvuLYkKRTlBlTWA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		hnMbgWkPESeTguFerysWVsUoBgnJ();
		SqiZKcfyVUfIyTkVIDTuFPDdpYBP();
		ZKHSkTWnXdWWjRMBPVZMeioIQwFv();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (VrtTuqitIDxxbCunbOrWaVYGuXpG != null)
		{
			VrtTuqitIDxxbCunbOrWaVYGuXpG.VshDPveQjVqQFgogDGildcmcWyJLc();
		}
		if (CvObPpGkhhKMdUfNQeRwTLFJNVoyA != null)
		{
			CvObPpGkhhKMdUfNQeRwTLFJNVoyA.VshDPveQjVqQFgogDGildcmcWyJLc();
		}
		if (CQZnCtbWsiDJVzWbnwpFsaxfdosR == null)
		{
			return;
		}
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			for (int i = 0; i < CQZnCtbWsiDJVzWbnwpFsaxfdosR.Count; i++)
			{
				if (CQZnCtbWsiDJVzWbnwpFsaxfdosR[i] != null)
				{
					CQZnCtbWsiDJVzWbnwpFsaxfdosR[i].MsBfyrnNAfzNHONLDKelfenvcgZh();
					CQZnCtbWsiDJVzWbnwpFsaxfdosR[i].UiucmEjtAjZvOaWpuxWyTsTsuyCP();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return whDhYFacDgebDyQeHGlQJNxaZKSG;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			for (int i = 0; i < kiyNOQqeALazKzULqbrDiCLPoYaT; i++)
			{
				if (CQZnCtbWsiDJVzWbnwpFsaxfdosR[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					CQZnCtbWsiDJVzWbnwpFsaxfdosR[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		wSHaLeGKhRvdDLgOqUhFVtdvHOgS = true;
		CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		wSHaLeGKhRvdDLgOqUhFVtdvHOgS = true;
		CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Start();
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

	private void hnMbgWkPESeTguFerysWVsUoBgnJ()
	{
		if (CvObPpGkhhKMdUfNQeRwTLFJNVoyA.YASgmbEQfqbFGemfMILquknsdBcZA)
		{
			if (CvObPpGkhhKMdUfNQeRwTLFJNVoyA.CUmiTZTnrHmOILdUvpnQSdUBdzmgA() && !CWOxlFXUkxQCsBWOqWkSeKFmjGZD.running && !VrtTuqitIDxxbCunbOrWaVYGuXpG.YASgmbEQfqbFGemfMILquknsdBcZA)
			{
				if (CvObPpGkhhKMdUfNQeRwTLFJNVoyA.GQeIAxmbSyejgKlIwwQaiAqYidcZA)
				{
					wSHaLeGKhRvdDLgOqUhFVtdvHOgS = true;
				}
				CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Start();
			}
		}
		else if (!CWOxlFXUkxQCsBWOqWkSeKFmjGZD.running)
		{
			CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Start();
		}
		else if (CWOxlFXUkxQCsBWOqWkSeKFmjGZD.Update())
		{
			CvObPpGkhhKMdUfNQeRwTLFJNVoyA.iHiGIFABtyBNGjnHrdGZBnbyaQGe();
		}
	}

	private List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> EpfzCFhubTDKIYMscRjNoZpRGGee()
	{
		List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> list = new List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb>();
		IList<JwOsKFPjPBIlckyhencRQGSXVgXH> list2 = jneIHIgwLDOMVuxeImTjfGiEhdXAA();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				JwOsKFPjPBIlckyhencRQGSXVgXH jwOsKFPjPBIlckyhencRQGSXVgXH = list2[i];
				Guid pyDhcNgRqogBXYMltfkVKgTlhbSI = jwOsKFPjPBIlckyhencRQGSXVgXH.pyDhcNgRqogBXYMltfkVKgTlhbSI;
				XLCyFVnacsfmCzPCdExtsrFUiHrH xLCyFVnacsfmCzPCdExtsrFUiHrH = new XLCyFVnacsfmCzPCdExtsrFUiHrH(jmAWbSIoCFXzdZeoJNjoqLxsJbCv, pyDhcNgRqogBXYMltfkVKgTlhbSI);
				qtjFyTqwYOVjTKDErRwhnfMNCEEI qtjFyTqwYOVjTKDErRwhnfMNCEEI2 = xLCyFVnacsfmCzPCdExtsrFUiHrH.CElaehVUMlHqGjcbRjWuKvIezImN;
				if (PIhQjlstRRLUEZyJFkcHauYXIvuO == null)
				{
					goto IL_00bd;
				}
				string text = jwOsKFPjPBIlckyhencRQGSXVgXH.HySZBGMwhUkvgQxYHLwubwCwnhMF.ToString();
				if (!PIhQjlstRRLUEZyJFkcHauYXIvuO.qYpzCylCJOiVdcWVuBGtbmnETdvGb(qtjFyTqwYOVjTKDErRwhnfMNCEEI2.OAtCEANRPGFAaESPehmUTJhoTWyD, StringTools.SanitizeDeviceString(jwOsKFPjPBIlckyhencRQGSXVgXH.CtmLpENCzrjmcHsdewIXiMiUeIqIA), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (!GfUbVnmkDMGOixRoVBcgiAJcaCppA.XUhxuDINlXgOEbuiInnaedQMcHnKA(InputSource.DirectInput, (ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.hGynDoBRoLVKugHBJNdiomgppFaj, (ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.mYVplrejAZAiyBMuwTOaigakCoZNA, (GfUbVnmkDMGOixRoVBcgiAJcaCppA.LBfSIsVrDyriFGkGTaDGvFkBERnR)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(qtjFyTqwYOVjTKDErRwhnfMNCEEI2.OAtCEANRPGFAaESPehmUTJhoTWyD)) ? MiscTools.CreateGuidHashSHA256(qtjFyTqwYOVjTKDErRwhnfMNCEEI2.OAtCEANRPGFAaESPehmUTJhoTWyD) : jwOsKFPjPBIlckyhencRQGSXVgXH.pyDhcNgRqogBXYMltfkVKgTlhbSI);
				bool flag = false;
				lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
				{
					if (CQZnCtbWsiDJVzWbnwpFsaxfdosR != null)
					{
						for (int j = 0; j < CQZnCtbWsiDJVzWbnwpFsaxfdosR.Count; j++)
						{
							if (CQZnCtbWsiDJVzWbnwpFsaxfdosR[j] != null && CQZnCtbWsiDJVzWbnwpFsaxfdosR[j].iFZBBskpSeyHxBVKshiXJFKMejHg == guid)
							{
								xLCyFVnacsfmCzPCdExtsrFUiHrH = CQZnCtbWsiDJVzWbnwpFsaxfdosR[j].SnPJwYARTUdjlIyKsJvaqdEBSIzP.dYrXUOGEvcOhNOLbEALYVURaBqhKA;
								flag = true;
								break;
							}
						}
					}
				}
				luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = new luuKOpfoMKySQQUXqdSrnScCisdo(new VqbdvMFmWDQOkQspiAnCJiRjjlByA(xLCyFVnacsfmCzPCdExtsrFUiHrH, kJnOctHAdccwrCVMcWIaNhnbtnuNA), hkhOZPuBnWvMeTpqVdDasOxyDUnk);
				luuKOpfoMKySQQUXqdSrnScCisdo2.FXnzTkbkBXXedWInieHbbhaCIngBA = jwOsKFPjPBIlckyhencRQGSXVgXH;
				luuKOpfoMKySQQUXqdSrnScCisdo2.UtzFfPmZNybBrzTTKDXmmZmIgKCB = jwOsKFPjPBIlckyhencRQGSXVgXH.EfDxdqREKkujgVmOqeqGhJEeehPV;
				luuKOpfoMKySQQUXqdSrnScCisdo2.iFZBBskpSeyHxBVKshiXJFKMejHg = guid;
				luuKOpfoMKySQQUXqdSrnScCisdo2.fjmbvQuFJRluCSqpeIFaiSDtqfWB = StringTools.SanitizeDeviceString(jwOsKFPjPBIlckyhencRQGSXVgXH.CtmLpENCzrjmcHsdewIXiMiUeIqIA);
				luuKOpfoMKySQQUXqdSrnScCisdo2.OFyQoTLFJChUlfESstukdbijCoFeb = jwOsKFPjPBIlckyhencRQGSXVgXH.HySZBGMwhUkvgQxYHLwubwCwnhMF;
				luuKOpfoMKySQQUXqdSrnScCisdo2.ZZgoMpRIhzlRHcbFJUjLLiHnHnIb = (KXGyEgvKAlBEzlKeqCYObLtyDDCq)jwOsKFPjPBIlckyhencRQGSXVgXH.pmVwzDGTuzpjQPIJGbNYWRspjRaD;
				JnlKnCaQonRfDbquXIXwuPTBkxpb jnlKnCaQonRfDbquXIXwuPTBkxpb = xLCyFVnacsfmCzPCdExtsrFUiHrH.gmfVdhqMXIrfduYDkRPNaFCKPmJN;
				luuKOpfoMKySQQUXqdSrnScCisdo2.QLtnZYhtHhdqzUVAznhMUDDImAMH = qtjFyTqwYOVjTKDErRwhnfMNCEEI2.mYVplrejAZAiyBMuwTOaigakCoZNA;
				luuKOpfoMKySQQUXqdSrnScCisdo2.SEcfLgAkTAqpwjOwJuAhStSTspxlb = false;
				try
				{
					luuKOpfoMKySQQUXqdSrnScCisdo2.GIxPvEYlCYmtGCrBybGLvZaTbuYX = qtjFyTqwYOVjTKDErRwhnfMNCEEI2.ZjgbmngcrMRzblAhlvbNjhNImtRwA;
				}
				catch (Exception)
				{
					luuKOpfoMKySQQUXqdSrnScCisdo2.GIxPvEYlCYmtGCrBybGLvZaTbuYX = 0;
				}
				luuKOpfoMKySQQUXqdSrnScCisdo2.iWNVRoYLKIjDxAhsDQhvHDyMRLltA = jnlKnCaQonRfDbquXIXwuPTBkxpb.rVFrcEvmoXESZcgHnMJLqiPtXpze;
				luuKOpfoMKySQQUXqdSrnScCisdo2.uEhDGSsABnbKgGMGLpnmInKzgzNO = jnlKnCaQonRfDbquXIXwuPTBkxpb.zqXGMBRtghfrGclgpgSsVLqrBoXH;
				luuKOpfoMKySQQUXqdSrnScCisdo2.dkImGUEJAEWZpSRrLZZgjsXBnVlH = jnlKnCaQonRfDbquXIXwuPTBkxpb.QfKDioekvPLGCSnfDlzCAezCsTBec;
				luuKOpfoMKySQQUXqdSrnScCisdo2.kNKxVkUlZyEtOGCaVmOhtAGMUraS = new DirectInputControllerExtension(jwOsKFPjPBIlckyhencRQGSXVgXH, xLCyFVnacsfmCzPCdExtsrFUiHrH);
				ZYBFrFJwnkcwIWMEYDhTBegfsGWRb(luuKOpfoMKySQQUXqdSrnScCisdo2, qtjFyTqwYOVjTKDErRwhnfMNCEEI2, out luuKOpfoMKySQQUXqdSrnScCisdo2.MaHHqwBmorQaCATdlSSBhtELnQHaA);
				try
				{
					string text2;
					try
					{
						text2 = qtjFyTqwYOVjTKDErRwhnfMNCEEI2.yZVeagLLfLwQfvkUWvzUkRcMoGkx;
					}
					catch
					{
						text2 = luuKOpfoMKySQQUXqdSrnScCisdo2.fjmbvQuFJRluCSqpeIFaiSDtqfWB;
					}
					if (aEhfNBVLsnubZLaAKSdMAjbgjoov.iUBntGZYBmFqxLMnLiYxjPraJzHS((ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.hGynDoBRoLVKugHBJNdiomgppFaj, (ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.mYVplrejAZAiyBMuwTOaigakCoZNA, text2) && aEhfNBVLsnubZLaAKSdMAjbgjoov.ySThzdqvXvUJPAjfzAPlxoozGHUJA((ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.hGynDoBRoLVKugHBJNdiomgppFaj, (ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.mYVplrejAZAiyBMuwTOaigakCoZNA, text2, out var num, out var num2, out var num3))
					{
						luuKOpfoMKySQQUXqdSrnScCisdo2.SnPJwYARTUdjlIyKsJvaqdEBSIzP.SCuPIkKtXTXznmNyPXhaXVIQAvPE(num, num2, num3, aEhfNBVLsnubZLaAKSdMAjbgjoov.LrMGGhsEoLoqZNbCAZRkWYXQZssc((ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.hGynDoBRoLVKugHBJNdiomgppFaj, (ushort)qtjFyTqwYOVjTKDErRwhnfMNCEEI2.mYVplrejAZAiyBMuwTOaigakCoZNA, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<aLSDFxIIAnFGinWoAXLDQXOymMRJ> list3 = xLCyFVnacsfmCzPCdExtsrFUiHrH.FPJBgaJxxjjqpmcPzAFFOkuUiRuSA();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].QEikRsxCylwHAxbliXPPtbpjgMWAA.MfuKxYoSWBOzmTFQkZMEBFQpIhEP & YHfQBlzXCaSKvSbTpixeOhmZfxid.Axis) != YHfQBlzXCaSKvSbTpixeOhmZfxid.All)
							{
								xLCyFVnacsfmCzPCdExtsrFUiHrH.CElaehVUMlHqGjcbRjWuKvIezImN.LrgiEJTZtgkzudaaUmIIjYAxqBvs = new hFBwXspWgUHMXbSilyaWzGyAcelG(-65535, 65535);
							}
						}
					}
					xLCyFVnacsfmCzPCdExtsrFUiHrH.CElaehVUMlHqGjcbRjWuKvIezImN.ndAVriIpItBqWiphabIWfSQpOjVQ = tOWLxuDpOZgOJJcXCYNlLqrxIICf.Absolute;
					xLCyFVnacsfmCzPCdExtsrFUiHrH.gXungyDFSVXiBCWJqGtbDELGYIvJ(FePtxZSpSYyNXYRTbhoKJNXxdqmd, UYARqvDSQWVJmqeufuhIwffGZueO.NonExclusive | UYARqvDSQWVJmqeufuhIwffGZueO.Background);
					xLCyFVnacsfmCzPCdExtsrFUiHrH.yFWBlSAiUeHwYaAAdQRMvZfnNUaGA();
				}
				list.Add(new FiwAFwgOgNWitFHTqiuHzZSWBmIgb(luuKOpfoMKySQQUXqdSrnScCisdo2, jwOsKFPjPBIlckyhencRQGSXVgXH));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void eXoGhJOamSdQOCbvuLYkKRTlBlTWA()
	{
		WWPFCLfVgvjqhgwZAWsgogqDsrDnA(EpfzCFhubTDKIYMscRjNoZpRGGee());
	}

	private void WWPFCLfVgvjqhgwZAWsgogqDsrDnA(List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> P_0)
	{
		List<luuKOpfoMKySQQUXqdSrnScCisdo> list = new List<luuKOpfoMKySQQUXqdSrnScCisdo>();
		mbPYOdCfAECEGkStjnOmlHsGvXoj = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].EITJsBPEcmGTbiobZQCwPjqQtkRx)
			{
				continue;
			}
			try
			{
				luuKOpfoMKySQQUXqdSrnScCisdo jTGjPoIkLZWhgOnIgvqFtRTUwfQE = P_0[i].JTGjPoIkLZWhgOnIgvqFtRTUwfQE;
				jTGjPoIkLZWhgOnIgvqFtRTUwfQE.UMhDjVixKtdCpUIKMTnZlaFJKdWe();
				if (jTGjPoIkLZWhgOnIgvqFtRTUwfQE.jMskMqLGpNhcWruWYVOpOvsfgLzC)
				{
					mbPYOdCfAECEGkStjnOmlHsGvXoj++;
				}
				list.Add(jTGjPoIkLZWhgOnIgvqFtRTUwfQE);
			}
			catch (Exception)
			{
			}
		}
		IbseUtFBhkWxRtTJVyXTSVgnruMUA.yBUyVGjEorkCRMSZyHlkCotKnHCu(mbPYOdCfAECEGkStjnOmlHsGvXoj);
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			List<luuKOpfoMKySQQUXqdSrnScCisdo> cQZnCtbWsiDJVzWbnwpFsaxfdosR = CQZnCtbWsiDJVzWbnwpFsaxfdosR;
			int num2 = kiyNOQqeALazKzULqbrDiCLPoYaT;
			int count = list.Count;
			yDCPPjmvetlypvHuZylcCoLBHKxg(num2, count, cQZnCtbWsiDJVzWbnwpFsaxfdosR, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			ymjopygxaidtKULnzrVfLgxajBAc(cQZnCtbWsiDJVzWbnwpFsaxfdosR, list, false);
			ymjopygxaidtKULnzrVfLgxajBAc(list, cQZnCtbWsiDJVzWbnwpFsaxfdosR, true);
			xaRaqzIjnwcLZOpqpIcGJHelvaNUA(list, cQZnCtbWsiDJVzWbnwpFsaxfdosR);
			CQZnCtbWsiDJVzWbnwpFsaxfdosR = list;
			kiyNOQqeALazKzULqbrDiCLPoYaT = list.Count;
		}
	}

	private void ZYBFrFJwnkcwIWMEYDhTBegfsGWRb(luuKOpfoMKySQQUXqdSrnScCisdo P_0, qtjFyTqwYOVjTKDErRwhnfMNCEEI P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = hhqXWftVSepEXJfDXrNHeTqfcpYy.CGNqcnGMocfMrgtKlXxfHdNgbIXi(P_1.OAtCEANRPGFAaESPehmUTJhoTWyD);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			LleUpypmoUiGbAiZXeXDJpCoDzXr lleUpypmoUiGbAiZXeXDJpCoDzXr = IEUIaTGMEWhWxjxHtLvNddZfncnz.KFFhOKmOUjakJwbCfmsfraHnUXJm(text.ToLower(CultureInfo.InvariantCulture));
			if (lleUpypmoUiGbAiZXeXDJpCoDzXr != null)
			{
				P_0.jMskMqLGpNhcWruWYVOpOvsfgLzC = lleUpypmoUiGbAiZXeXDJpCoDzXr.PDGRktVJzyNVWHKUFtkHtKXJdthcA;
				P_0.YcwUpBDuSGbWawrbSnVwjjGPDBZBA = lleUpypmoUiGbAiZXeXDJpCoDzXr.VrYDeizNDCscbiYsEwezldnkeZZb;
				P_2 = GfUbVnmkDMGOixRoVBcgiAJcaCppA.hjiUIbMcAixefItPwKEhMmwPspqH(lleUpypmoUiGbAiZXeXDJpCoDzXr, P_0.OFyQoTLFJChUlfESstukdbijCoFeb, P_0.fjmbvQuFJRluCSqpeIFaiSDtqfWB, P_0.YcwUpBDuSGbWawrbSnVwjjGPDBZBA);
				lleUpypmoUiGbAiZXeXDJpCoDzXr.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void ZKHSkTWnXdWWjRMBPVZMeioIQwFv()
	{
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			for (int i = 0; i < kiyNOQqeALazKzULqbrDiCLPoYaT; i++)
			{
				try
				{
					luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = CQZnCtbWsiDJVzWbnwpFsaxfdosR[i];
					if (luuKOpfoMKySQQUXqdSrnScCisdo2 != null && luuKOpfoMKySQQUXqdSrnScCisdo2.GPJKLHQxbrcMgznaROIEZBkaSZsV() && (NJWtNkjjVIKTPZjQTKdnhkrQFscK == null || !luuKOpfoMKySQQUXqdSrnScCisdo2.SEcfLgAkTAqpwjOwJuAhStSTspxlb))
					{
						luuKOpfoMKySQQUXqdSrnScCisdo2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<JwOsKFPjPBIlckyhencRQGSXVgXH> jneIHIgwLDOMVuxeImTjfGiEhdXAA()
	{
		try
		{
			IList<JwOsKFPjPBIlckyhencRQGSXVgXH> list = jmAWbSIoCFXzdZeoJNjoqLxsJbCv.nTqzftUbZriLrXFuVscZSEnmNnXI(pmRDleZVtcRYlUxVUfzrdFpkQOVP.GameControl, LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly);
			frPdysbpbSpHeaRjCwPoBksdhnbMB = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			frPdysbpbSpHeaRjCwPoBksdhnbMB = 0;
			return EmptyObjects<JwOsKFPjPBIlckyhencRQGSXVgXH>.EmptyReadOnlyIListT;
		}
	}

	private void YGDLZhFRBzJkQyeutCDvckCQAENbA()
	{
		jmAWbSIoCFXzdZeoJNjoqLxsJbCv.DPbgwxJbiLcyOqFeYJVsOiDLhaTHA();
	}

	private void yDCPPjmvetlypvHuZylcCoLBHKxg(int P_0, int P_1, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_2, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(luuKOpfoMKySQQUXqdSrnScCisdo.LpwfYeXnGcapwQnEXtnMynodmFT);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			JOZiJYAProQFDruRmnOzUjoevBMd(P_1, P_3, P_0, P_2, FMcqEiprSQYZcLJpSLmSLAcbBUsh.zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Exact);
		}
		rUBhUNjeCOnKZiVSNghtVQzMsOkK(P_1, P_3, FMcqEiprSQYZcLJpSLmSLAcbBUsh.zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Exact);
		for (int i = 0; i < P_1; i++)
		{
			luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = P_3[i];
			if (luuKOpfoMKySQQUXqdSrnScCisdo2 != null && luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = ONInhUuOCYFqWinhnhCKtNgBZqRM(P_3);
				luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = WbOCeXxRRanhaztZzswSYyYSLWSq();
				OEFMqSmzuZTijybLEUgiqwGnFvDr.tHZzqUymchaYPFwtPfOsQDxiwnpE(luuKOpfoMKySQQUXqdSrnScCisdo2);
			}
		}
		P_3.Sort(luuKOpfoMKySQQUXqdSrnScCisdo.IEdWFNGsLfbksywIQwgxcVUoaUhR);
	}

	private void cMPhiDriZnveAJaYdTvLUAQgVbys(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0, int P_1, int P_2)
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

	private bool LsReKlEVPHJGnkpZOKtoDuslBNDI(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0, int P_1)
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

	private int ONInhUuOCYFqWinhnhCKtNgBZqRM(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0)
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

	private bool xLWuCAHeVdygRpPZBvjJwxGbBuRe(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0, int P_1)
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

	private void JOZiJYAProQFDruRmnOzUjoevBMd(int P_0, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_1, int P_2, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_3, FMcqEiprSQYZcLJpSLmSLAcbBUsh.zvdbpGGVbcKmiLfcrLuDBgtMTTkvA P_4)
	{
		int num = ((P_4 != FMcqEiprSQYZcLJpSLmSLAcbBUsh.zvdbpGGVbcKmiLfcrLuDBgtMTTkvA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = P_1[i];
			if (luuKOpfoMKySQQUXqdSrnScCisdo2 == null || luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo3 = P_3[j];
				if (luuKOpfoMKySQQUXqdSrnScCisdo3 != null && !xLWuCAHeVdygRpPZBvjJwxGbBuRe(P_1, luuKOpfoMKySQQUXqdSrnScCisdo3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && luuKOpfoMKySQQUXqdSrnScCisdo2.PJzgONkwutyeAjCIyNMcxBGGJijl(luuKOpfoMKySQQUXqdSrnScCisdo3) >= num)
				{
					luuKOpfoMKySQQUXqdSrnScCisdo2.tPYBvNxmHugJVMTVptvehJGRhaNT(luuKOpfoMKySQQUXqdSrnScCisdo3);
					OEFMqSmzuZTijybLEUgiqwGnFvDr.tHZzqUymchaYPFwtPfOsQDxiwnpE(luuKOpfoMKySQQUXqdSrnScCisdo2);
				}
			}
		}
	}

	private void rUBhUNjeCOnKZiVSNghtVQzMsOkK(int P_0, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_1, FMcqEiprSQYZcLJpSLmSLAcbBUsh.zvdbpGGVbcKmiLfcrLuDBgtMTTkvA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = P_1[i];
			if (luuKOpfoMKySQQUXqdSrnScCisdo2 == null || luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			FMcqEiprSQYZcLJpSLmSLAcbBUsh.JAiYTxxAqSZdtfNtAAsQZvZZNWg jAiYTxxAqSZdtfNtAAsQZvZZNWg = null;
			foreach (FMcqEiprSQYZcLJpSLmSLAcbBUsh.JAiYTxxAqSZdtfNtAAsQZvZZNWg item in OEFMqSmzuZTijybLEUgiqwGnFvDr.LbnsxDzLxoyPtNlAgaHKFZtUSoDm(luuKOpfoMKySQQUXqdSrnScCisdo2, P_2))
			{
				if (!xLWuCAHeVdygRpPZBvjJwxGbBuRe(P_1, item.nXkMTDxWlyEvEexgbsungZdCPANb) && item.sWxoArjpDCuQBzGqqborHUqABiodb >= 0)
				{
					jAiYTxxAqSZdtfNtAAsQZvZZNWg = item;
					break;
				}
			}
			if (jAiYTxxAqSZdtfNtAAsQZvZZNWg != null)
			{
				int num = jAiYTxxAqSZdtfNtAAsQZvZZNWg.sWxoArjpDCuQBzGqqborHUqABiodb;
				if (!LsReKlEVPHJGnkpZOKtoDuslBNDI(P_1, num))
				{
					num = (jAiYTxxAqSZdtfNtAAsQZvZZNWg.sWxoArjpDCuQBzGqqborHUqABiodb = ONInhUuOCYFqWinhnhCKtNgBZqRM(P_1));
				}
				luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = jAiYTxxAqSZdtfNtAAsQZvZZNWg.nXkMTDxWlyEvEexgbsungZdCPANb;
				OEFMqSmzuZTijybLEUgiqwGnFvDr.tHZzqUymchaYPFwtPfOsQDxiwnpE(luuKOpfoMKySQQUXqdSrnScCisdo2);
			}
		}
	}

	private void SqiZKcfyVUfIyTkVIDTuFPDdpYBP()
	{
		if (wSHaLeGKhRvdDLgOqUhFVtdvHOgS)
		{
			USjCbqUQvAroVyseROyiZWROXHIf();
		}
		if (VrtTuqitIDxxbCunbOrWaVYGuXpG.YASgmbEQfqbFGemfMILquknsdBcZA && VrtTuqitIDxxbCunbOrWaVYGuXpG.CUmiTZTnrHmOILdUvpnQSdUBdzmgA())
		{
			daWCkbhHhMprUuTLuIDLwCvuSwHf(VrtTuqitIDxxbCunbOrWaVYGuXpG.GQeIAxmbSyejgKlIwwQaiAqYidcZA);
		}
	}

	private void USjCbqUQvAroVyseROyiZWROXHIf()
	{
		wSHaLeGKhRvdDLgOqUhFVtdvHOgS = false;
		if (!VrtTuqitIDxxbCunbOrWaVYGuXpG.YASgmbEQfqbFGemfMILquknsdBcZA)
		{
			VrtTuqitIDxxbCunbOrWaVYGuXpG.iHiGIFABtyBNGjnHrdGZBnbyaQGe();
		}
	}

	private void daWCkbhHhMprUuTLuIDLwCvuSwHf(List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> P_0)
	{
		if (oPsVgOyJwRfVlEqmlYxuEcYnDjXg(FiwAFwgOgNWitFHTqiuHzZSWBmIgb.RZbiOuekSudeyjRUrnbscRFGApPuB(P_0)))
		{
			WWPFCLfVgvjqhgwZAWsgogqDsrDnA(P_0);
		}
	}

	private bool oPsVgOyJwRfVlEqmlYxuEcYnDjXg(IList<JwOsKFPjPBIlckyhencRQGSXVgXH> P_0)
	{
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !mhloyIHhxVkTsejVfmuGyjJXPuxi(P_0[i].pyDhcNgRqogBXYMltfkVKgTlhbSI))
				{
					return true;
				}
			}
			int count2 = CQZnCtbWsiDJVzWbnwpFsaxfdosR.Count;
			for (int j = 0; j < count2; j++)
			{
				if (CQZnCtbWsiDJVzWbnwpFsaxfdosR[j] != null && !fYVwLSTghTabFcSuzKjhTLZxCXMgA(P_0, CQZnCtbWsiDJVzWbnwpFsaxfdosR[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool mhloyIHhxVkTsejVfmuGyjJXPuxi(Guid P_0)
	{
		lock (PzuhcBKabpgoRGJcYnZArjfgHfLqA)
		{
			int count = CQZnCtbWsiDJVzWbnwpFsaxfdosR.Count;
			for (int i = 0; i < count; i++)
			{
				if (CQZnCtbWsiDJVzWbnwpFsaxfdosR[i] != null && CQZnCtbWsiDJVzWbnwpFsaxfdosR[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool fYVwLSTghTabFcSuzKjhTLZxCXMgA(IList<JwOsKFPjPBIlckyhencRQGSXVgXH> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].pyDhcNgRqogBXYMltfkVKgTlhbSI == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ymjopygxaidtKULnzrVfLgxajBAc(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo2 = P_0[i];
			if (luuKOpfoMKySQQUXqdSrnScCisdo2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					luuKOpfoMKySQQUXqdSrnScCisdo luuKOpfoMKySQQUXqdSrnScCisdo3 = P_1[j];
					if (luuKOpfoMKySQQUXqdSrnScCisdo3 != null && luuKOpfoMKySQQUXqdSrnScCisdo2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == luuKOpfoMKySQQUXqdSrnScCisdo3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				wmagiRJqKzrxOeBFjHkTBvLKyKkE(P_0[i], P_2);
			}
		}
	}

	private void wmagiRJqKzrxOeBFjHkTBvLKyKkE(luuKOpfoMKySQQUXqdSrnScCisdo P_0, bool P_1)
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

	private bool DlPoJzMyAyJXRPhRptSBixCnnOYn()
	{
		int num = jmAWbSIoCFXzdZeoJNjoqLxsJbCv.dyKBFfCvIwdJXCWJplnbpVvNKFNL(pmRDleZVtcRYlUxVUfzrdFpkQOVP.GameControl, LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly);
		if (frPdysbpbSpHeaRjCwPoBksdhnbMB != num)
		{
			frPdysbpbSpHeaRjCwPoBksdhnbMB = num;
			return true;
		}
		if (mbPYOdCfAECEGkStjnOmlHsGvXoj > 0 && IbseUtFBhkWxRtTJVyXTSVgnruMUA.aTTNrncISOWBHdqOWGhaaHsRdiEFb())
		{
			return true;
		}
		return false;
	}

	private void xaRaqzIjnwcLZOpqpIcGJHelvaNUA(List<luuKOpfoMKySQQUXqdSrnScCisdo> P_0, List<luuKOpfoMKySQQUXqdSrnScCisdo> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].UiucmEjtAjZvOaWpuxWyTsTsuyCP();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void YABoYnhNaycfjyVpiDCeNKzOuKrR(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<FiwAFwgOgNWitFHTqiuHzZSWBmIgb> pvuCkZfjhMfaiaarPZbqEiFPwptq()
	{
		return EpfzCFhubTDKIYMscRjNoZpRGGee();
	}
}
