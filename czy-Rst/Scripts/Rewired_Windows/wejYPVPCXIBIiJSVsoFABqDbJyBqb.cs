using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class wejYPVPCXIBIiJSVsoFABqDbJyBqb : PlatformInputManager
{
	private class OvKnylRiBSjYybvxjhoipFVegJmN : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int IAMeiHfGjZkPKWrVFGSaozQfeXbh;

		private int ITMSPsvVUHGGccpTYeIZIfRpHPRe;

		public Guid YydBwwGuZmfqOUzBsRJEEqRpwIhtA;

		public string DnUWjDnSIJNKLuvyaoqRLHIhAXft;

		public FbLBdpdENtbItJFSSeBTXLBvWCbvA YaLYkgxCJiZIAEzVVogxQkzRmqOg;

		public string KmjGFXaQuXDxpJECbOrHWHpbCUUp;

		public string hpKtoNxsKXsfkCTTCiLPHCqZOCKf;

		public Guid IwnYvihbNDoUzuOiirAUQLENhQXDA;

		public PidVid xXZDrSoChrbxYRJjdfZhaqhXkcvmA;

		public Guid DKIALbjBultuSLbkhrJwHTkzFseqA;

		public int HUVSoDjwPOSueXmrAYkhslcLaEHn;

		public int JbHjjwzXudFLsTPpjoXFpVohTEMq;

		public int xNyBLAjpcqnbrVyphdPCfocdvLEu;

		public int StrobeDhKMiAsQhNvLqGXWbXicey;

		public int oVNbSerhnzIQFxDPBHpEjohVbwMuA;

		public int NHpKHJVJLmKKvbuIyIPQfOHZYrT;

		public bool BfJyhNzRGqPclKvGmhrpjQvkQeyJ;

		public int EUSKAtwIhxKYRlQillLbfZxlunhl;

		private float[] NFulnBwPTMlDnqRStNELowfhLucl;

		private float[] TYWYlGTJDsMLrKbpfUNmRKmbnHeK;

		private bool[] yEzAyXsbgACSNTGhDuVSXUATnAbg;

		private HardwareJoystickMap_InputManager qWZwymUzJzfwTIoGvaQgPBaVfsbk;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HqJtBCzoKZeEPrtEIXQcgCPNAELH;

		private bool FNxljrVDTIzClZyCIJhtkdnWWYsP;

		private bool ntKGQuILQuAWriKqIScuKWamdKXzA;

		[CompilerGenerated]
		private Controller.Extension VtiijlRmgwTNDRAGVIVzhPqHrohQA;

		private bool PSOQGoKsrhanVPVBUGAVzQCqEUDM;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return IAMeiHfGjZkPKWrVFGSaozQfeXbh;
			}
			set
			{
				IAMeiHfGjZkPKWrVFGSaozQfeXbh = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return ITMSPsvVUHGGccpTYeIZIfRpHPRe;
			}
			set
			{
				ITMSPsvVUHGGccpTYeIZIfRpHPRe = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(DnUWjDnSIJNKLuvyaoqRLHIhAXft != "Unknown Controller"))
				{
					return hpKtoNxsKXsfkCTTCiLPHCqZOCKf;
				}
				return DnUWjDnSIJNKLuvyaoqRLHIhAXft;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (ITMSPsvVUHGGccpTYeIZIfRpHPRe < 0)
				{
					return null;
				}
				return ITMSPsvVUHGGccpTYeIZIfRpHPRe;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => IwnYvihbNDoUzuOiirAUQLENhQXDA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid
		{
			get
			{
				if (YaLYkgxCJiZIAEzVVogxQkzRmqOg == null)
				{
					return Guid.Empty;
				}
				return YaLYkgxCJiZIAEzVVogxQkzRmqOg.drTbqMMJKTjYKOMkpGEXgxtMIvkG;
			}
		}

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return VtiijlRmgwTNDRAGVIVzhPqHrohQA;
			}
			[CompilerGenerated]
			set
			{
				VtiijlRmgwTNDRAGVIVzhPqHrohQA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (BfJyhNzRGqPclKvGmhrpjQvkQeyJ)
			{
				YaLYkgxCJiZIAEzVVogxQkzRmqOg.vbJLIJCPMdrAshaGLmODcnXvSAKT(motorIndex, amount, false);
			}
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (BfJyhNzRGqPclKvGmhrpjQvkQeyJ)
			{
				YaLYkgxCJiZIAEzVVogxQkzRmqOg.nRVbMDkGFOkNZZbOAquQaHCFgXEg();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public OvKnylRiBSjYybvxjhoipFVegJmN(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			HqJtBCzoKZeEPrtEIXQcgCPNAELH = P_0;
			ITMSPsvVUHGGccpTYeIZIfRpHPRe = -1;
			IAMeiHfGjZkPKWrVFGSaozQfeXbh = -1;
		}

		public void polnUpRiEyTGJauiFmxWKqSoMjBN()
		{
			DKIALbjBultuSLbkhrJwHTkzFseqA = MiscTools.CreateGuidHashSHA1(hpKtoNxsKXsfkCTTCiLPHCqZOCKf + xXZDrSoChrbxYRJjdfZhaqhXkcvmA.ToProductGuid().ToString());
			JbHjjwzXudFLsTPpjoXFpVohTEMq = StrobeDhKMiAsQhNvLqGXWbXicey;
			xNyBLAjpcqnbrVyphdPCfocdvLEu = oVNbSerhnzIQFxDPBHpEjohVbwMuA + NHpKHJVJLmKKvbuIyIPQfOHZYrT * 8;
			QjLrYrfnTeSmJHznZoivFnlHnyag();
			YydBwwGuZmfqOUzBsRJEEqRpwIhtA = qWZwymUzJzfwTIoGvaQgPBaVfsbk.hardwareMapIdentifier.guid;
			DnUWjDnSIJNKLuvyaoqRLHIhAXft = qWZwymUzJzfwTIoGvaQgPBaVfsbk.controllerName;
			FNxljrVDTIzClZyCIJhtkdnWWYsP = ((YydBwwGuZmfqOUzBsRJEEqRpwIhtA == Guid.Empty) ? true : false);
			NFulnBwPTMlDnqRStNELowfhLucl = new float[JbHjjwzXudFLsTPpjoXFpVohTEMq];
			TYWYlGTJDsMLrKbpfUNmRKmbnHeK = new float[xNyBLAjpcqnbrVyphdPCfocdvLEu];
			yEzAyXsbgACSNTGhDuVSXUATnAbg = new bool[xNyBLAjpcqnbrVyphdPCfocdvLEu];
			if (xNyBLAjpcqnbrVyphdPCfocdvLEu > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)qWZwymUzJzfwTIoGvaQgPBaVfsbk.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						yEzAyXsbgACSNTGhDuVSXUATnAbg[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void udyAJTBcWSodahiTCQSpdWRlImYrb(OvKnylRiBSjYybvxjhoipFVegJmN P_0)
		{
			if (P_0 != null)
			{
				ITMSPsvVUHGGccpTYeIZIfRpHPRe = P_0.ITMSPsvVUHGGccpTYeIZIfRpHPRe;
				IAMeiHfGjZkPKWrVFGSaozQfeXbh = P_0.IAMeiHfGjZkPKWrVFGSaozQfeXbh;
				for (int i = 0; i < MathTools.Min(TYWYlGTJDsMLrKbpfUNmRKmbnHeK.Length, P_0.TYWYlGTJDsMLrKbpfUNmRKmbnHeK.Length); i++)
				{
					TYWYlGTJDsMLrKbpfUNmRKmbnHeK[i] = P_0.TYWYlGTJDsMLrKbpfUNmRKmbnHeK[i];
				}
				for (int j = 0; j < MathTools.Min(yEzAyXsbgACSNTGhDuVSXUATnAbg.Length, P_0.yEzAyXsbgACSNTGhDuVSXUATnAbg.Length); j++)
				{
					yEzAyXsbgACSNTGhDuVSXUATnAbg[j] = P_0.yEzAyXsbgACSNTGhDuVSXUATnAbg[j];
				}
				for (int k = 0; k < MathTools.Min(NFulnBwPTMlDnqRStNELowfhLucl.Length, P_0.NFulnBwPTMlDnqRStNELowfhLucl.Length); k++)
				{
					NFulnBwPTMlDnqRStNELowfhLucl[k] = P_0.NFulnBwPTMlDnqRStNELowfhLucl[k];
				}
				ntKGQuILQuAWriKqIScuKWamdKXzA = P_0.ntKGQuILQuAWriKqIScuKWamdKXzA;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			yNeNdRgcyhQJASTHbMDlIpUYgjTCA();
			seejulFHjIJMNGhVhUdEZMDPIAjyA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (JbHjjwzXudFLsTPpjoXFpVohTEMq != dataUpdater.axisCount || xNyBLAjpcqnbrVyphdPCfocdvLEu != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < JbHjjwzXudFLsTPpjoXFpVohTEMq; i++)
			{
				dataUpdater.axisValues[i] = NFulnBwPTMlDnqRStNELowfhLucl[i];
			}
			for (int j = 0; j < xNyBLAjpcqnbrVyphdPCfocdvLEu; j++)
			{
				if (yEzAyXsbgACSNTGhDuVSXUATnAbg[j])
				{
					dataUpdater.buttonPressureValues[j] = TYWYlGTJDsMLrKbpfUNmRKmbnHeK[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = TYWYlGTJDsMLrKbpfUNmRKmbnHeK[j] > 0f;
				}
			}
			if (ntKGQuILQuAWriKqIScuKWamdKXzA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int geVfVFDFlCNCQEybzFTNjjlNwuPG(OvKnylRiBSjYybvxjhoipFVegJmN P_0)
		{
			if (P_0.IAMeiHfGjZkPKWrVFGSaozQfeXbh == IAMeiHfGjZkPKWrVFGSaozQfeXbh)
			{
				return 2;
			}
			if (StrobeDhKMiAsQhNvLqGXWbXicey != P_0.StrobeDhKMiAsQhNvLqGXWbXicey)
			{
				return 0;
			}
			if (oVNbSerhnzIQFxDPBHpEjohVbwMuA != P_0.oVNbSerhnzIQFxDPBHpEjohVbwMuA)
			{
				return 0;
			}
			if (NHpKHJVJLmKKvbuIyIPQfOHZYrT != P_0.NHpKHJVJLmKKvbuIyIPQfOHZYrT)
			{
				return 0;
			}
			if (P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA == IwnYvihbNDoUzuOiirAUQLENhQXDA)
			{
				return 2;
			}
			if (P_0.DKIALbjBultuSLbkhrJwHTkzFseqA == DKIALbjBultuSLbkhrJwHTkzFseqA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo lHyHYdXqFKJLZZYvlnjUBLhxGdlT()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			bAuDSEQxvoqLchXrUXduFtdPasve(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			MnKdgEhrnopMQAyRRKFFDzooQSnBb(bridgedController);
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
			return new ControllerDisconnectedEventArgs(IAMeiHfGjZkPKWrVFGSaozQfeXbh);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void yNeNdRgcyhQJASTHbMDlIpUYgjTCA()
		{
			if (JbHjjwzXudFLsTPpjoXFpVohTEMq <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)qWZwymUzJzfwTIoGvaQgPBaVfsbk.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					uSbIMvjAbTjsaGBwdJnIJhHHoMiAb(axes_orig[i], i);
				}
			}
		}

		private void seejulFHjIJMNGhVhUdEZMDPIAjyA()
		{
			if (xNyBLAjpcqnbrVyphdPCfocdvLEu <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)qWZwymUzJzfwTIoGvaQgPBaVfsbk.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					bgQzUhCNRpuBOQDxfiUZkUWpTvSg(buttons_orig[i], i);
				}
			}
		}

		private void uSbIMvjAbTjsaGBwdJnIJhHHoMiAb(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= JbHjjwzXudFLsTPpjoXFpVohTEMq)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			NFulnBwPTMlDnqRStNELowfhLucl[P_1] = fHArggCrgbtlblNJUkmEqzvbTWXB(P_0);
			if (!ntKGQuILQuAWriKqIScuKWamdKXzA && NFulnBwPTMlDnqRStNELowfhLucl[P_1] != 0f)
			{
				ntKGQuILQuAWriKqIScuKWamdKXzA = true;
			}
		}

		private void bgQzUhCNRpuBOQDxfiUZkUWpTvSg(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= xNyBLAjpcqnbrVyphdPCfocdvLEu)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			TYWYlGTJDsMLrKbpfUNmRKmbnHeK[P_1] = lCNzVIChHQdTAeCoAQuOaGaOvske(P_0);
			if (!ntKGQuILQuAWriKqIScuKWamdKXzA && TYWYlGTJDsMLrKbpfUNmRKmbnHeK[P_1] != 0f)
			{
				ntKGQuILQuAWriKqIScuKWamdKXzA = true;
			}
		}

		private float fHArggCrgbtlblNJUkmEqzvbTWXB(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return CqRwDjtKQhSEqlDBTIUajWeabQTb(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= oVNbSerhnzIQFxDPBHpEjohVbwMuA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!YaLYkgxCJiZIAEzVVogxQkzRmqOg.hFBqqlkUCQOcvKJUPOnUrmAtuRMs(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= NHpKHJVJLmKKvbuIyIPQfOHZYrT || sourceHat >= 4)
				{
					return 0f;
				}
				int num = YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = fpSIyxUKfVrtQcnwiLOPWAbnHANc(num, AxisDirection.Horizontal);
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
					num2 = fpSIyxUKfVrtQcnwiLOPWAbnHANc(num, AxisDirection.Vertical);
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
			return 0f;
		}

		private float CqRwDjtKQhSEqlDBTIUajWeabQTb(int P_0)
		{
			if (P_0 < 0 || P_0 >= YaLYkgxCJiZIAEzVVogxQkzRmqOg.mVbAXPOWefHsQKpgibrFkviQsYioA)
			{
				return 0f;
			}
			return YaLYkgxCJiZIAEzVVogxQkzRmqOg.XDinlDxkuERfwtogoiMtgxuKTMRX(P_0);
		}

		private float lCNzVIChHQdTAeCoAQuOaGaOvske(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (YaLYkgxCJiZIAEzVVogxQkzRmqOg.hFBqqlkUCQOcvKJUPOnUrmAtuRMs(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!YaLYkgxCJiZIAEzVVogxQkzRmqOg.hFBqqlkUCQOcvKJUPOnUrmAtuRMs(P_0.requiredButtons[j]))
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= oVNbSerhnzIQFxDPBHpEjohVbwMuA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!YaLYkgxCJiZIAEzVVogxQkzRmqOg.hFBqqlkUCQOcvKJUPOnUrmAtuRMs(sourceButton))
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = CqRwDjtKQhSEqlDBTIUajWeabQTb(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return num2;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= NHpKHJVJLmKKvbuIyIPQfOHZYrT || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return TNScNxDwXllYuLxXtbUNMywnVLKrA(YaLYkgxCJiZIAEzVVogxQkzRmqOg.gesYKkHqqWiwrsBMlRvAsFRYQUNX(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float TNScNxDwXllYuLxXtbUNMywnVLKrA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (qWZwymUzJzfwTIoGvaQgPBaVfsbk.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
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
				return 1f;
			}
			return 0f;
		}

		private float fpSIyxUKfVrtQcnwiLOPWAbnHANc(int P_0, AxisDirection P_1)
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

		private void QjLrYrfnTeSmJHznZoivFnlHnyag()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = lHyHYdXqFKJLZZYvlnjUBLhxGdlT();
			qWZwymUzJzfwTIoGvaQgPBaVfsbk = HqJtBCzoKZeEPrtEIXQcgCPNAELH(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (qWZwymUzJzfwTIoGvaQgPBaVfsbk == null || qWZwymUzJzfwTIoGvaQgPBaVfsbk.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (YaLYkgxCJiZIAEzVVogxQkzRmqOg.bUnkJBLPawAykpSJUbIuSYtZqZdF)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					qWZwymUzJzfwTIoGvaQgPBaVfsbk = HqJtBCzoKZeEPrtEIXQcgCPNAELH(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (qWZwymUzJzfwTIoGvaQgPBaVfsbk == null || qWZwymUzJzfwTIoGvaQgPBaVfsbk.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					qWZwymUzJzfwTIoGvaQgPBaVfsbk = HqJtBCzoKZeEPrtEIXQcgCPNAELH(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (qWZwymUzJzfwTIoGvaQgPBaVfsbk == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", YaLYkgxCJiZIAEzVVogxQkzRmqOg.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.vendorId.ToString("x4"), YaLYkgxCJiZIAEzVVogxQkzRmqOg.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.InsertParentKey(0, key);
				qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (YaLYkgxCJiZIAEzVVogxQkzRmqOg.bUnkJBLPawAykpSJUbIuSYtZqZdF && (flag2 || qWZwymUzJzfwTIoGvaQgPBaVfsbk.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", YaLYkgxCJiZIAEzVVogxQkzRmqOg.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.vendorId.ToString("x4"), YaLYkgxCJiZIAEzVVogxQkzRmqOg.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.parentKeys[0])) ? qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.InsertParentKey(0, key2);
				qWZwymUzJzfwTIoGvaQgPBaVfsbk.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			JbHjjwzXudFLsTPpjoXFpVohTEMq = qWZwymUzJzfwTIoGvaQgPBaVfsbk.axisCount;
			xNyBLAjpcqnbrVyphdPCfocdvLEu = qWZwymUzJzfwTIoGvaQgPBaVfsbk.buttonCount;
		}

		private string SdfKxQkCuHpgndMiCRiCJvKfrmoE()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{YaLYkgxCJiZIAEzVVogxQkzRmqOg.agXfFGjAzlpCcJtjOaahmezCwKYFA}{hpKtoNxsKXsfkCTTCiLPHCqZOCKf}{xXZDrSoChrbxYRJjdfZhaqhXkcvmA.ToString()}");
		}

		private void bAuDSEQxvoqLchXrUXduFtdPasve(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = YaLYkgxCJiZIAEzVVogxQkzRmqOg.CPKVNAxMLrCfEwcwfCZcgivOtgxk;
			P_0.deviceType = (ControlDeviceType)YaLYkgxCJiZIAEzVVogxQkzRmqOg.agXfFGjAzlpCcJtjOaahmezCwKYFA;
			P_0.hardwareIdentifier = SdfKxQkCuHpgndMiCRiCJvKfrmoE();
			P_0.hardwareAxisCount = StrobeDhKMiAsQhNvLqGXWbXicey;
			P_0.hardwareButtonCount = oVNbSerhnzIQFxDPBHpEjohVbwMuA;
			P_0.hardwareHatCount = NHpKHJVJLmKKvbuIyIPQfOHZYrT;
			if (YaLYkgxCJiZIAEzVVogxQkzRmqOg.bUnkJBLPawAykpSJUbIuSYtZqZdF)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = hpKtoNxsKXsfkCTTCiLPHCqZOCKf;
			P_0.hw_deviceGuid = IwnYvihbNDoUzuOiirAUQLENhQXDA;
			P_0.hw_productId = xXZDrSoChrbxYRJjdfZhaqhXkcvmA.productId;
			P_0.hw_vendorId = xXZDrSoChrbxYRJjdfZhaqhXkcvmA.vendorId;
			P_0.hw_pidVid = xXZDrSoChrbxYRJjdfZhaqhXkcvmA;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = hpKtoNxsKXsfkCTTCiLPHCqZOCKf;
			P_0.hw_supportsVibration = BfJyhNzRGqPclKvGmhrpjQvkQeyJ;
			P_0.hw_localVibrationMotorCount = EUSKAtwIhxKYRlQillLbfZxlunhl;
		}

		private void MnKdgEhrnopMQAyRRKFFDzooQSnBb(BridgedController P_0)
		{
			bAuDSEQxvoqLchXrUXduFtdPasve(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = qWZwymUzJzfwTIoGvaQgPBaVfsbk.ToGameHardwareControllerMap();
			P_0.instanceName = KmjGFXaQuXDxpJECbOrHWHpbCUUp;
			P_0.productName = hpKtoNxsKXsfkCTTCiLPHCqZOCKf;
			P_0.axisCount = JbHjjwzXudFLsTPpjoXFpVohTEMq;
			P_0.buttonCount = xNyBLAjpcqnbrVyphdPCfocdvLEu;
			P_0.isButtonPressureSensitive = new bool[xNyBLAjpcqnbrVyphdPCfocdvLEu];
			Array.Copy(yEzAyXsbgACSNTGhDuVSXUATnAbg, P_0.isButtonPressureSensitive, xNyBLAjpcqnbrVyphdPCfocdvLEu);
			P_0.unknownControllerHats = nAXRSIJnfABTLJhwodkSAudMDncw();
			P_0.controllerTypeGuid = YydBwwGuZmfqOUzBsRJEEqRpwIhtA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void UaogPSNYaCDDygPiuYFdAvpHirQk()
		{
			for (int i = 0; i < xNyBLAjpcqnbrVyphdPCfocdvLEu; i++)
			{
				TYWYlGTJDsMLrKbpfUNmRKmbnHeK[i] = 0f;
			}
			for (int j = 0; j < JbHjjwzXudFLsTPpjoXFpVohTEMq; j++)
			{
				NFulnBwPTMlDnqRStNELowfhLucl[j] = 0f;
			}
		}

		private UnknownControllerHat[] nAXRSIJnfABTLJhwodkSAudMDncw()
		{
			if (!FNxljrVDTIzClZyCIJhtkdnWWYsP)
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

		public void Dispose()
		{
			GooVRgaBbQsotjNKlcYpUrhozFgk(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void XBcGGZrsSeoNkcqfiEUDeOuojCUF()
		{
			try
			{
				GooVRgaBbQsotjNKlcYpUrhozFgk(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void GooVRgaBbQsotjNKlcYpUrhozFgk(bool P_0)
		{
			if (!PSOQGoKsrhanVPVBUGAVzQCqEUDM)
			{
				if (P_0 && YaLYkgxCJiZIAEzVVogxQkzRmqOg != null)
				{
					YaLYkgxCJiZIAEzVVogxQkzRmqOg.Dispose();
				}
				PSOQGoKsrhanVPVBUGAVzQCqEUDM = true;
			}
		}

		public static int uVhohJKAdVCEjaRHLZsRgheEJgGTA(OvKnylRiBSjYybvxjhoipFVegJmN P_0, OvKnylRiBSjYybvxjhoipFVegJmN P_1)
		{
			if (P_0.ITMSPsvVUHGGccpTYeIZIfRpHPRe < P_1.ITMSPsvVUHGGccpTYeIZIfRpHPRe)
			{
				return -1;
			}
			if (P_0.ITMSPsvVUHGGccpTYeIZIfRpHPRe > P_1.ITMSPsvVUHGGccpTYeIZIfRpHPRe)
			{
				return 1;
			}
			return 0;
		}

		public static int RKcZbMpSMvTuIffzQqpkAdVJocYq(OvKnylRiBSjYybvxjhoipFVegJmN P_0, OvKnylRiBSjYybvxjhoipFVegJmN P_1)
		{
			if (P_0.HUVSoDjwPOSueXmrAYkhslcLaEHn < P_1.HUVSoDjwPOSueXmrAYkhslcLaEHn)
			{
				return -1;
			}
			if (P_0.HUVSoDjwPOSueXmrAYkhslcLaEHn > P_1.HUVSoDjwPOSueXmrAYkhslcLaEHn)
			{
				return 1;
			}
			return 0;
		}
	}

	private class qfqImqBDwDlcGmyrOeqtpZhJFbtf
	{
		public enum MOzKIOASSkXRPLUhAyWYxNoAhsEk
		{
			Exact = 0,
			Approximate = 1
		}

		public class ooJYnzWNeaAouqKExsSjvTlHsEXn
		{
			public int pueXICebkQLEOdCPxcjSfTGnglLcA;

			public Guid wxjxcckKQhUflsDxwLGzatRbjJNC;

			public Guid UntDafLdlASetFjsdHcOocZZvlVe;

			public int rgCrfCOrrHVLRlOFLepJhRhzwmqtA;

			public int IijdwNgNtgyOBVTkhKbIEbTWMoflA;

			public int ixbcOtzgtJMYUKlDPVqSSMhReTzEA;

			public int XJQofROazOmoVgGHLDVAWfusescG;

			public int qiULAXeOYhMqmhVBQOqWdOuWyxkB;

			public int kQEvQoAOYTMoMZlNMNyORnwXrBU;

			public bool OeqchvMwdPFNHkOwydeuGXOveOAzA(OvKnylRiBSjYybvxjhoipFVegJmN P_0, MOzKIOASSkXRPLUhAyWYxNoAhsEk P_1)
			{
				if (IijdwNgNtgyOBVTkhKbIEbTWMoflA != P_0.StrobeDhKMiAsQhNvLqGXWbXicey)
				{
					return false;
				}
				if (ixbcOtzgtJMYUKlDPVqSSMhReTzEA != P_0.oVNbSerhnzIQFxDPBHpEjohVbwMuA)
				{
					return false;
				}
				if (XJQofROazOmoVgGHLDVAWfusescG != P_0.NHpKHJVJLmKKvbuIyIPQfOHZYrT)
				{
					return false;
				}
				if (qiULAXeOYhMqmhVBQOqWdOuWyxkB != P_0.xNyBLAjpcqnbrVyphdPCfocdvLEu)
				{
					return false;
				}
				if (kQEvQoAOYTMoMZlNMNyORnwXrBU != P_0.JbHjjwzXudFLsTPpjoXFpVohTEMq)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == pueXICebkQLEOdCPxcjSfTGnglLcA)
				{
					return true;
				}
				return P_1 switch
				{
					MOzKIOASSkXRPLUhAyWYxNoAhsEk.Exact => wxjxcckKQhUflsDxwLGzatRbjJNC == P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA, 
					MOzKIOASSkXRPLUhAyWYxNoAhsEk.Approximate => UntDafLdlASetFjsdHcOocZZvlVe == P_0.DKIALbjBultuSLbkhrJwHTkzFseqA, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class OoyBWrtAOIeOaIHmTMSqtBnEIJNz : IEnumerable<ooJYnzWNeaAouqKExsSjvTlHsEXn>, IEnumerable, IEnumerator<ooJYnzWNeaAouqKExsSjvTlHsEXn>, IEnumerator, IDisposable
		{
			private int ramdPNKJNryDWcNFxQpfPqDAqGbh;

			private ooJYnzWNeaAouqKExsSjvTlHsEXn SIJcDPweSPRUfdDrfExadqlOXSGs;

			private int ZkutFbZINUBXMxJaOpmVyqIkOwCQ;

			public qfqImqBDwDlcGmyrOeqtpZhJFbtf micFcYMXvBkJGYDIFFfNdtpdyMz;

			private OvKnylRiBSjYybvxjhoipFVegJmN ietcUfHGsXWZtIMaAGPeHhHImETbb;

			public OvKnylRiBSjYybvxjhoipFVegJmN DJXYQtdfVjMQnYWjVrXXjdpSKUvy;

			private MOzKIOASSkXRPLUhAyWYxNoAhsEk FjWweyAVnWGMzVHSvhbBnFDqLwNC;

			public MOzKIOASSkXRPLUhAyWYxNoAhsEk kxLFtlFEbQSDYqLMoyCyLtJMLfijA;

			private int ovWEYEpGtwYvjzEtJJCMvHKbbUMA;

			private int gVaQxJYbPRxjNJuHgTxzDAOBVCEp;

			ooJYnzWNeaAouqKExsSjvTlHsEXn IEnumerator<ooJYnzWNeaAouqKExsSjvTlHsEXn>.Current
			{
				[DebuggerHidden]
				get
				{
					return SIJcDPweSPRUfdDrfExadqlOXSGs;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SIJcDPweSPRUfdDrfExadqlOXSGs;
				}
			}

			[DebuggerHidden]
			public OoyBWrtAOIeOaIHmTMSqtBnEIJNz(int P_0)
			{
				ramdPNKJNryDWcNFxQpfPqDAqGbh = P_0;
				ZkutFbZINUBXMxJaOpmVyqIkOwCQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ramdPNKJNryDWcNFxQpfPqDAqGbh;
				qfqImqBDwDlcGmyrOeqtpZhJFbtf qfqImqBDwDlcGmyrOeqtpZhJFbtf2 = micFcYMXvBkJGYDIFFfNdtpdyMz;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ramdPNKJNryDWcNFxQpfPqDAqGbh = -1;
					goto IL_0083;
				}
				ramdPNKJNryDWcNFxQpfPqDAqGbh = -1;
				ovWEYEpGtwYvjzEtJJCMvHKbbUMA = qfqImqBDwDlcGmyrOeqtpZhJFbtf2.CKQGNmGTJIlaxNFRPeiyhZqaenZS.Count;
				gVaQxJYbPRxjNJuHgTxzDAOBVCEp = 0;
				goto IL_0093;
				IL_0083:
				gVaQxJYbPRxjNJuHgTxzDAOBVCEp++;
				goto IL_0093;
				IL_0093:
				if (gVaQxJYbPRxjNJuHgTxzDAOBVCEp < ovWEYEpGtwYvjzEtJJCMvHKbbUMA)
				{
					if (qfqImqBDwDlcGmyrOeqtpZhJFbtf2.CKQGNmGTJIlaxNFRPeiyhZqaenZS[gVaQxJYbPRxjNJuHgTxzDAOBVCEp].OeqchvMwdPFNHkOwydeuGXOveOAzA(ietcUfHGsXWZtIMaAGPeHhHImETbb, FjWweyAVnWGMzVHSvhbBnFDqLwNC))
					{
						SIJcDPweSPRUfdDrfExadqlOXSGs = qfqImqBDwDlcGmyrOeqtpZhJFbtf2.CKQGNmGTJIlaxNFRPeiyhZqaenZS[gVaQxJYbPRxjNJuHgTxzDAOBVCEp];
						ramdPNKJNryDWcNFxQpfPqDAqGbh = 1;
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
			IEnumerator<ooJYnzWNeaAouqKExsSjvTlHsEXn> IEnumerable<ooJYnzWNeaAouqKExsSjvTlHsEXn>.GetEnumerator()
			{
				OoyBWrtAOIeOaIHmTMSqtBnEIJNz ooyBWrtAOIeOaIHmTMSqtBnEIJNz;
				if (ramdPNKJNryDWcNFxQpfPqDAqGbh == -2 && ZkutFbZINUBXMxJaOpmVyqIkOwCQ == Environment.CurrentManagedThreadId)
				{
					ramdPNKJNryDWcNFxQpfPqDAqGbh = 0;
					ooyBWrtAOIeOaIHmTMSqtBnEIJNz = this;
				}
				else
				{
					ooyBWrtAOIeOaIHmTMSqtBnEIJNz = new OoyBWrtAOIeOaIHmTMSqtBnEIJNz(0);
					ooyBWrtAOIeOaIHmTMSqtBnEIJNz.micFcYMXvBkJGYDIFFfNdtpdyMz = micFcYMXvBkJGYDIFFfNdtpdyMz;
				}
				ooyBWrtAOIeOaIHmTMSqtBnEIJNz.ietcUfHGsXWZtIMaAGPeHhHImETbb = DJXYQtdfVjMQnYWjVrXXjdpSKUvy;
				ooyBWrtAOIeOaIHmTMSqtBnEIJNz.FjWweyAVnWGMzVHSvhbBnFDqLwNC = kxLFtlFEbQSDYqLMoyCyLtJMLfijA;
				return ooyBWrtAOIeOaIHmTMSqtBnEIJNz;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ooJYnzWNeaAouqKExsSjvTlHsEXn>)this).GetEnumerator();
			}
		}

		private List<ooJYnzWNeaAouqKExsSjvTlHsEXn> CKQGNmGTJIlaxNFRPeiyhZqaenZS;

		public qfqImqBDwDlcGmyrOeqtpZhJFbtf()
		{
			CKQGNmGTJIlaxNFRPeiyhZqaenZS = new List<ooJYnzWNeaAouqKExsSjvTlHsEXn>();
		}

		public void zzYfAKdECbsAxokILUxlbkTjwjqZ(OvKnylRiBSjYybvxjhoipFVegJmN P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = CKQGNmGTJIlaxNFRPeiyhZqaenZS.Count;
			for (int i = 0; i < count; i++)
			{
				if (CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].OeqchvMwdPFNHkOwydeuGXOveOAzA(P_0, MOzKIOASSkXRPLUhAyWYxNoAhsEk.Exact))
				{
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].pueXICebkQLEOdCPxcjSfTGnglLcA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].wxjxcckKQhUflsDxwLGzatRbjJNC = P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].UntDafLdlASetFjsdHcOocZZvlVe = P_0.DKIALbjBultuSLbkhrJwHTkzFseqA;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].rgCrfCOrrHVLRlOFLepJhRhzwmqtA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].IijdwNgNtgyOBVTkhKbIEbTWMoflA = P_0.StrobeDhKMiAsQhNvLqGXWbXicey;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].ixbcOtzgtJMYUKlDPVqSSMhReTzEA = P_0.oVNbSerhnzIQFxDPBHpEjohVbwMuA;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].XJQofROazOmoVgGHLDVAWfusescG = P_0.NHpKHJVJLmKKvbuIyIPQfOHZYrT;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].qiULAXeOYhMqmhVBQOqWdOuWyxkB = P_0.xNyBLAjpcqnbrVyphdPCfocdvLEu;
					CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].kQEvQoAOYTMoMZlNMNyORnwXrBU = P_0.JbHjjwzXudFLsTPpjoXFpVohTEMq;
					YpatoIgXzFtpQwwbRwUiZQdReSSN(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA, i);
					return;
				}
			}
			CKQGNmGTJIlaxNFRPeiyhZqaenZS.Add(new ooJYnzWNeaAouqKExsSjvTlHsEXn
			{
				pueXICebkQLEOdCPxcjSfTGnglLcA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				wxjxcckKQhUflsDxwLGzatRbjJNC = P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA,
				UntDafLdlASetFjsdHcOocZZvlVe = P_0.DKIALbjBultuSLbkhrJwHTkzFseqA,
				rgCrfCOrrHVLRlOFLepJhRhzwmqtA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				IijdwNgNtgyOBVTkhKbIEbTWMoflA = P_0.StrobeDhKMiAsQhNvLqGXWbXicey,
				ixbcOtzgtJMYUKlDPVqSSMhReTzEA = P_0.oVNbSerhnzIQFxDPBHpEjohVbwMuA,
				XJQofROazOmoVgGHLDVAWfusescG = P_0.NHpKHJVJLmKKvbuIyIPQfOHZYrT,
				qiULAXeOYhMqmhVBQOqWdOuWyxkB = P_0.xNyBLAjpcqnbrVyphdPCfocdvLEu,
				kQEvQoAOYTMoMZlNMNyORnwXrBU = P_0.JbHjjwzXudFLsTPpjoXFpVohTEMq
			});
			YpatoIgXzFtpQwwbRwUiZQdReSSN(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.IwnYvihbNDoUzuOiirAUQLENhQXDA, CKQGNmGTJIlaxNFRPeiyhZqaenZS.Count - 1);
		}

		public bool ouEzGtKlTEamivIjIEgZiXbvMraPA(OvKnylRiBSjYybvxjhoipFVegJmN P_0, MOzKIOASSkXRPLUhAyWYxNoAhsEk P_1)
		{
			int count = CKQGNmGTJIlaxNFRPeiyhZqaenZS.Count;
			for (int i = 0; i < count; i++)
			{
				if (CKQGNmGTJIlaxNFRPeiyhZqaenZS[i].OeqchvMwdPFNHkOwydeuGXOveOAzA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(OoyBWrtAOIeOaIHmTMSqtBnEIJNz))]
		public IEnumerable<ooJYnzWNeaAouqKExsSjvTlHsEXn> ilqQEjvOMpcULfkAblrknaHwenPDb(OvKnylRiBSjYybvxjhoipFVegJmN P_0, MOzKIOASSkXRPLUhAyWYxNoAhsEk P_1)
		{
			return new OoyBWrtAOIeOaIHmTMSqtBnEIJNz(-2)
			{
				micFcYMXvBkJGYDIFFfNdtpdyMz = this,
				DJXYQtdfVjMQnYWjVrXXjdpSKUvy = P_0,
				kxLFtlFEbQSDYqLMoyCyLtJMLfijA = P_1
			};
		}

		private void YpatoIgXzFtpQwwbRwUiZQdReSSN(int P_0, Guid P_1, int P_2)
		{
			for (int num = CKQGNmGTJIlaxNFRPeiyhZqaenZS.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (CKQGNmGTJIlaxNFRPeiyhZqaenZS[num].pueXICebkQLEOdCPxcjSfTGnglLcA == P_0 || CKQGNmGTJIlaxNFRPeiyhZqaenZS[num].wxjxcckKQhUflsDxwLGzatRbjJNC == P_1))
				{
					CKQGNmGTJIlaxNFRPeiyhZqaenZS.RemoveAt(num);
				}
			}
		}
	}

	private const bool ArPiAZCPTvHlbSXMEJyBXIjkbhTA = true;

	private djfqOwFTxRTNDADdwfoljxtTEjiI kMmhpiftgvOJzHGnJTKtKzKoMGJV;

	private List<OvKnylRiBSjYybvxjhoipFVegJmN> ddRgSETXAxodWfpHIRPOcInzWhUC;

	private int hPYEhFElhhxJECtpMyDuzPWMGyaL;

	private qfqImqBDwDlcGmyrOeqtpZhJFbtf forGXIWgBhDlaavEKrEarDgODrxTA;

	private bool qINzlWhPLSGaJYsOkHdpzJBLgmQU;

	private ConfigVars TQUCsBgyNgmcEUJIBTMCVZoxcDcYA;

	private Action<int, ControllerDataUpdater> QETOrqepLMXoXseKXVKMpfqPQgLI;

	private PlatformInputManager kWqNJwQZTyBNwqkgSttlakSQiXWi;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> AtFVzKDyCNiaqFePfGcKZuNkIgncA;

	private readonly Func<int> pxCJAykadidUowOEpLJLPwTxFmHt;

	private Func<PidVid, bool> hNmcYFEhcImZKZJgFBcACeEKAgLKB;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => hPYEhFElhhxJECtpMyDuzPWMGyaL;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => kWqNJwQZTyBNwqkgSttlakSQiXWi;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => kMmhpiftgvOJzHGnJTKtKzKoMGJV;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.WindowsGamingInput;

	protected djfqOwFTxRTNDADdwfoljxtTEjiI znQReEJgawEgumbxaqvDLcbUCATkA => kMmhpiftgvOJzHGnJTKtKzKoMGJV;

	public wejYPVPCXIBIiJSVsoFABqDbJyBqb(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			TQUCsBgyNgmcEUJIBTMCVZoxcDcYA = P_0;
			AtFVzKDyCNiaqFePfGcKZuNkIgncA = P_1;
			pxCJAykadidUowOEpLJLPwTxFmHt = P_2;
			hNmcYFEhcImZKZJgFBcACeEKAgLKB = P_3;
			kWqNJwQZTyBNwqkgSttlakSQiXWi = this;
			kMmhpiftgvOJzHGnJTKtKzKoMGJV = new djfqOwFTxRTNDADdwfoljxtTEjiI(P_0, true, false, false);
			kMmhpiftgvOJzHGnJTKtKzKoMGJV.Rewired_002EInterfaces_002EIInputSource_002EDeviceChangedEvent += SystemDeviceConnected;
			QETOrqepLMXoXseKXVKMpfqPQgLI = UpdateControllerData;
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
		forGXIWgBhDlaavEKrEarDgODrxTA = new qfqImqBDwDlcGmyrOeqtpZhJFbtf();
		kMmhpiftgvOJzHGnJTKtKzKoMGJV.mldXsXYIHdHmmIOKMeAAQXFOLSsQA();
		fxtyBctrtzeiGDcfbekctKOgEMDGb();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (kMmhpiftgvOJzHGnJTKtKzKoMGJV != null)
		{
			kMmhpiftgvOJzHGnJTKtKzKoMGJV.Update();
		}
		if (qINzlWhPLSGaJYsOkHdpzJBLgmQU)
		{
			eWyaANTUQoSfdWgcFwIfrNWZfriAA();
		}
		if (kMmhpiftgvOJzHGnJTKtKzKoMGJV != null)
		{
			kMmhpiftgvOJzHGnJTKtKzKoMGJV.UpdateDevices(updateLoop);
		}
		xVTEaSFbFAjaJevwHOiNkyRFVsngA();
		if (kMmhpiftgvOJzHGnJTKtKzKoMGJV != null)
		{
			kMmhpiftgvOJzHGnJTKtKzKoMGJV.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (ddRgSETXAxodWfpHIRPOcInzWhUC != null)
		{
			int count = ddRgSETXAxodWfpHIRPOcInzWhUC.Count;
			for (int i = 0; i < count; i++)
			{
				if (ddRgSETXAxodWfpHIRPOcInzWhUC[i] != null)
				{
					ddRgSETXAxodWfpHIRPOcInzWhUC[i].Dispose();
				}
			}
		}
		if (kMmhpiftgvOJzHGnJTKtKzKoMGJV != null)
		{
			kMmhpiftgvOJzHGnJTKtKzKoMGJV.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return QETOrqepLMXoXseKXVKMpfqPQgLI;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < hPYEhFElhhxJECtpMyDuzPWMGyaL; i++)
		{
			if (ddRgSETXAxodWfpHIRPOcInzWhUC[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				ddRgSETXAxodWfpHIRPOcInzWhUC[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		qINzlWhPLSGaJYsOkHdpzJBLgmQU = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		qINzlWhPLSGaJYsOkHdpzJBLgmQU = true;
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
		return kMmhpiftgvOJzHGnJTKtKzKoMGJV.URaPYhIAiihfqtyMUvbqFrjGwTGx;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return kMmhpiftgvOJzHGnJTKtKzKoMGJV.VNXfsIIDOWTbTpxnYfSmCGUgJNQrA;
	}

	protected bool gBYmVbMCvLbpMpGoQWOzSzIfglwM(PidVid P_0)
	{
		return hNmcYFEhcImZKZJgFBcACeEKAgLKB(P_0);
	}

	private void fxtyBctrtzeiGDcfbekctKOgEMDGb()
	{
		jZYRDgdIvZknBAfKxcaCekoGzou(lQptXqCBuNjfewmPQlzsaGsGMmVg());
	}

	private void jZYRDgdIvZknBAfKxcaCekoGzou(IList<FbLBdpdENtbItJFSSeBTXLBvWCbvA> P_0)
	{
		int num = 0;
		List<OvKnylRiBSjYybvxjhoipFVegJmN> list = ddRgSETXAxodWfpHIRPOcInzWhUC;
		int num2 = hPYEhFElhhxJECtpMyDuzPWMGyaL;
		ddRgSETXAxodWfpHIRPOcInzWhUC = new List<OvKnylRiBSjYybvxjhoipFVegJmN>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				FbLBdpdENtbItJFSSeBTXLBvWCbvA fbLBdpdENtbItJFSSeBTXLBvWCbvA = P_0[i];
				OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN = new OvKnylRiBSjYybvxjhoipFVegJmN(AtFVzKDyCNiaqFePfGcKZuNkIgncA);
				ovKnylRiBSjYybvxjhoipFVegJmN.YaLYkgxCJiZIAEzVVogxQkzRmqOg = fbLBdpdENtbItJFSSeBTXLBvWCbvA;
				ovKnylRiBSjYybvxjhoipFVegJmN.IwnYvihbNDoUzuOiirAUQLENhQXDA = fbLBdpdENtbItJFSSeBTXLBvWCbvA.PTanXcxCpdOkoSsaVfScvbWRzJrb;
				ovKnylRiBSjYybvxjhoipFVegJmN.KmjGFXaQuXDxpJECbOrHWHpbCUUp = fbLBdpdENtbItJFSSeBTXLBvWCbvA.utzWgnDQlqYhpZrKDUTtChzEzwsE;
				ovKnylRiBSjYybvxjhoipFVegJmN.hpKtoNxsKXsfkCTTCiLPHCqZOCKf = fbLBdpdENtbItJFSSeBTXLBvWCbvA.utzWgnDQlqYhpZrKDUTtChzEzwsE;
				ovKnylRiBSjYybvxjhoipFVegJmN.xXZDrSoChrbxYRJjdfZhaqhXkcvmA = fbLBdpdENtbItJFSSeBTXLBvWCbvA.EkSkBRZXDxzwXtaRFDsXSjRMTqNr;
				ovKnylRiBSjYybvxjhoipFVegJmN.HUVSoDjwPOSueXmrAYkhslcLaEHn = fbLBdpdENtbItJFSSeBTXLBvWCbvA.IVMnhdSJNHXsSYPXAqMgdVFdRVBE;
				ovKnylRiBSjYybvxjhoipFVegJmN.StrobeDhKMiAsQhNvLqGXWbXicey = fbLBdpdENtbItJFSSeBTXLBvWCbvA.mVbAXPOWefHsQKpgibrFkviQsYioA;
				ovKnylRiBSjYybvxjhoipFVegJmN.oVNbSerhnzIQFxDPBHpEjohVbwMuA = fbLBdpdENtbItJFSSeBTXLBvWCbvA.qKqKIFGHVNQaHDfYagpuVQmActnY;
				ovKnylRiBSjYybvxjhoipFVegJmN.NHpKHJVJLmKKvbuIyIPQfOHZYrT = fbLBdpdENtbItJFSSeBTXLBvWCbvA.wKzWmPahHdblmJHYnWVsUrpDlNM;
				ovKnylRiBSjYybvxjhoipFVegJmN.BfJyhNzRGqPclKvGmhrpjQvkQeyJ = fbLBdpdENtbItJFSSeBTXLBvWCbvA.zmHQwDLUGvxhDsjFnOnTPHqCyTeG;
				ovKnylRiBSjYybvxjhoipFVegJmN.EUSKAtwIhxKYRlQillLbfZxlunhl = fbLBdpdENtbItJFSSeBTXLBvWCbvA.DJBARxXWuflCqagYBXIkTtdSCDOX;
				ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = fbLBdpdENtbItJFSSeBTXLBvWCbvA.yyfyCJNhwvvovsjCRhetKJweWKyOA;
				ovKnylRiBSjYybvxjhoipFVegJmN.YaLYkgxCJiZIAEzVVogxQkzRmqOg = fbLBdpdENtbItJFSSeBTXLBvWCbvA;
				ovKnylRiBSjYybvxjhoipFVegJmN.polnUpRiEyTGJauiFmxWKqSoMjBN();
				ddRgSETXAxodWfpHIRPOcInzWhUC.Add(ovKnylRiBSjYybvxjhoipFVegJmN);
				num++;
			}
		}
		hPYEhFElhhxJECtpMyDuzPWMGyaL = num;
		wRpWyiNHasKxOzvfmOsaNNjDzYGm(num2, num, list, ddRgSETXAxodWfpHIRPOcInzWhUC);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(ddRgSETXAxodWfpHIRPOcInzWhUC[j]));
			}
		}
		PWfoYCdVxHnmalhaojSxDAnlesuo(list, ddRgSETXAxodWfpHIRPOcInzWhUC, false);
		PWfoYCdVxHnmalhaojSxDAnlesuo(ddRgSETXAxodWfpHIRPOcInzWhUC, list, true);
	}

	private void xVTEaSFbFAjaJevwHOiNkyRFVsngA()
	{
		for (int i = 0; i < hPYEhFElhhxJECtpMyDuzPWMGyaL; i++)
		{
			ddRgSETXAxodWfpHIRPOcInzWhUC[i]?.Update();
		}
	}

	private IList<FbLBdpdENtbItJFSSeBTXLBvWCbvA> lQptXqCBuNjfewmPQlzsaGsGMmVg()
	{
		return kMmhpiftgvOJzHGnJTKtKzKoMGJV.GetJoysticks<FbLBdpdENtbItJFSSeBTXLBvWCbvA>();
	}

	private void wRpWyiNHasKxOzvfmOsaNNjDzYGm(int P_0, int P_1, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_2, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(OvKnylRiBSjYybvxjhoipFVegJmN.RKcZbMpSMvTuIffzQqpkAdVJocYq);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			fJDGyUXVHwEbBkprVCciQfTsYSde(P_1, P_3, P_0, P_2, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk.Exact);
			fJDGyUXVHwEbBkprVCciQfTsYSde(P_1, P_3, P_0, P_2, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk.Approximate);
		}
		CatipZZKApHTtCBehKAmRUFLqKBZA(P_1, P_3, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk.Exact);
		CatipZZKApHTtCBehKAmRUFLqKBZA(P_1, P_3, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN = P_3[i];
			if (ovKnylRiBSjYybvxjhoipFVegJmN != null && ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = fMjEJIpgHibXhNgROoMujRlKgcII(P_3);
				ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = pxCJAykadidUowOEpLJLPwTxFmHt();
				forGXIWgBhDlaavEKrEarDgODrxTA.zzYfAKdECbsAxokILUxlbkTjwjqZ(ovKnylRiBSjYybvxjhoipFVegJmN);
			}
		}
		P_3.Sort(OvKnylRiBSjYybvxjhoipFVegJmN.uVhohJKAdVCEjaRHLZsRgheEJgGTA);
	}

	private void noLeCCCxrUzCfpDUinFbEktBcvPjc(List<OvKnylRiBSjYybvxjhoipFVegJmN> P_0, int P_1, int P_2)
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

	private bool xtaInbGmjnaNiRGUlucCTykKChtb(List<OvKnylRiBSjYybvxjhoipFVegJmN> P_0, int P_1)
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

	private int fMjEJIpgHibXhNgROoMujRlKgcII(List<OvKnylRiBSjYybvxjhoipFVegJmN> P_0)
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

	private bool qPuEbaEJqWlgTwRMdIKCbmhkcpZjc(List<OvKnylRiBSjYybvxjhoipFVegJmN> P_0, int P_1)
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

	private void fJDGyUXVHwEbBkprVCciQfTsYSde(int P_0, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_1, int P_2, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_3, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk P_4)
	{
		int num = ((P_4 != qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN = P_1[i];
			if (ovKnylRiBSjYybvxjhoipFVegJmN == null || ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN2 = P_3[j];
				if (ovKnylRiBSjYybvxjhoipFVegJmN2 != null && !qPuEbaEJqWlgTwRMdIKCbmhkcpZjc(P_1, ovKnylRiBSjYybvxjhoipFVegJmN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && ovKnylRiBSjYybvxjhoipFVegJmN.geVfVFDFlCNCQEybzFTNjjlNwuPG(ovKnylRiBSjYybvxjhoipFVegJmN2) >= num)
				{
					ovKnylRiBSjYybvxjhoipFVegJmN.udyAJTBcWSodahiTCQSpdWRlImYrb(ovKnylRiBSjYybvxjhoipFVegJmN2);
					forGXIWgBhDlaavEKrEarDgODrxTA.zzYfAKdECbsAxokILUxlbkTjwjqZ(ovKnylRiBSjYybvxjhoipFVegJmN);
				}
			}
		}
	}

	private void CatipZZKApHTtCBehKAmRUFLqKBZA(int P_0, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_1, qfqImqBDwDlcGmyrOeqtpZhJFbtf.MOzKIOASSkXRPLUhAyWYxNoAhsEk P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN = P_1[i];
			if (ovKnylRiBSjYybvxjhoipFVegJmN == null || ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			qfqImqBDwDlcGmyrOeqtpZhJFbtf.ooJYnzWNeaAouqKExsSjvTlHsEXn ooJYnzWNeaAouqKExsSjvTlHsEXn = null;
			foreach (qfqImqBDwDlcGmyrOeqtpZhJFbtf.ooJYnzWNeaAouqKExsSjvTlHsEXn item in forGXIWgBhDlaavEKrEarDgODrxTA.ilqQEjvOMpcULfkAblrknaHwenPDb(ovKnylRiBSjYybvxjhoipFVegJmN, P_2))
			{
				if (!qPuEbaEJqWlgTwRMdIKCbmhkcpZjc(P_1, item.pueXICebkQLEOdCPxcjSfTGnglLcA) && item.rgCrfCOrrHVLRlOFLepJhRhzwmqtA >= 0)
				{
					ooJYnzWNeaAouqKExsSjvTlHsEXn = item;
					break;
				}
			}
			if (ooJYnzWNeaAouqKExsSjvTlHsEXn != null)
			{
				int num = ooJYnzWNeaAouqKExsSjvTlHsEXn.rgCrfCOrrHVLRlOFLepJhRhzwmqtA;
				if (!xtaInbGmjnaNiRGUlucCTykKChtb(P_1, num))
				{
					num = (ooJYnzWNeaAouqKExsSjvTlHsEXn.rgCrfCOrrHVLRlOFLepJhRhzwmqtA = fMjEJIpgHibXhNgROoMujRlKgcII(P_1));
				}
				ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				ovKnylRiBSjYybvxjhoipFVegJmN.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ooJYnzWNeaAouqKExsSjvTlHsEXn.pueXICebkQLEOdCPxcjSfTGnglLcA;
				forGXIWgBhDlaavEKrEarDgODrxTA.zzYfAKdECbsAxokILUxlbkTjwjqZ(ovKnylRiBSjYybvxjhoipFVegJmN);
			}
		}
	}

	private void eWyaANTUQoSfdWgcFwIfrNWZfriAA()
	{
		kMmhpiftgvOJzHGnJTKtKzKoMGJV.mldXsXYIHdHmmIOKMeAAQXFOLSsQA();
		IList<FbLBdpdENtbItJFSSeBTXLBvWCbvA> list = lQptXqCBuNjfewmPQlzsaGsGMmVg();
		if (yjNhoRQtcvujPwfmYjGaBsrfEPYX(list))
		{
			jZYRDgdIvZknBAfKxcaCekoGzou(list);
		}
		qINzlWhPLSGaJYsOkHdpzJBLgmQU = false;
	}

	private bool yjNhoRQtcvujPwfmYjGaBsrfEPYX(IList<FbLBdpdENtbItJFSSeBTXLBvWCbvA> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !zGMpwSaLcKHKrRTSmDVSYqPLInLB(P_0[i].PTanXcxCpdOkoSsaVfScvbWRzJrb))
			{
				return true;
			}
		}
		int count2 = ddRgSETXAxodWfpHIRPOcInzWhUC.Count;
		for (int j = 0; j < count2; j++)
		{
			if (ddRgSETXAxodWfpHIRPOcInzWhUC[j] != null && !HqQAaVLawgrSVfqwbNmOdOYlrwFD(P_0, ddRgSETXAxodWfpHIRPOcInzWhUC[j].IwnYvihbNDoUzuOiirAUQLENhQXDA))
			{
				return true;
			}
		}
		return false;
	}

	private bool zGMpwSaLcKHKrRTSmDVSYqPLInLB(Guid P_0)
	{
		int count = ddRgSETXAxodWfpHIRPOcInzWhUC.Count;
		for (int i = 0; i < count; i++)
		{
			if (ddRgSETXAxodWfpHIRPOcInzWhUC[i] != null && ddRgSETXAxodWfpHIRPOcInzWhUC[i].IwnYvihbNDoUzuOiirAUQLENhQXDA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool HqQAaVLawgrSVfqwbNmOdOYlrwFD(IList<FbLBdpdENtbItJFSSeBTXLBvWCbvA> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].PTanXcxCpdOkoSsaVfScvbWRzJrb == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void PWfoYCdVxHnmalhaojSxDAnlesuo(List<OvKnylRiBSjYybvxjhoipFVegJmN> P_0, List<OvKnylRiBSjYybvxjhoipFVegJmN> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN = P_0[i];
			if (ovKnylRiBSjYybvxjhoipFVegJmN == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					OvKnylRiBSjYybvxjhoipFVegJmN ovKnylRiBSjYybvxjhoipFVegJmN2 = P_1[j];
					if (ovKnylRiBSjYybvxjhoipFVegJmN2 != null && ovKnylRiBSjYybvxjhoipFVegJmN.IwnYvihbNDoUzuOiirAUQLENhQXDA == ovKnylRiBSjYybvxjhoipFVegJmN2.IwnYvihbNDoUzuOiirAUQLENhQXDA)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				WvRaVxaohxjvqPwetpRNsBAoEaWI(P_0[i], P_2);
			}
		}
	}

	private void WvRaVxaohxjvqPwetpRNsBAoEaWI(OvKnylRiBSjYybvxjhoipFVegJmN P_0, bool P_1)
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
}
