using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class pVCnQGEndlyOQtYMurDRbysLyjGd : PlatformInputManager
{
	private class LegDxKOTNFfkQiBNJLSuGqVeMiYRA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int ivdpqTutyqWHvnxlxOVIewSqbgoI;

		private int DgqMmbZjJflDLLSnTyDTaFyRgMTL;

		public Guid LhGiITDikgnqpqTKPcZalHInoFAH;

		public string hddqfqTooodUegecKzjEVhnLiUEbb;

		public XAZzsMQMImLcZRwmVzOOEmMtHEOJ icfElNCROiUdklDnZtPjcPBmyRfJ;

		public nMnRnyDPJhCGZnsNacgXSeyxTprn gfjdOrcrndEjFAQGHcfefNNGhkcZb;

		public string frheGpikWrEkNngdebgzrNebctNt;

		public string KluEOAopmaJIUENPqTiYFAKzTgaCA;

		public int cPAMITqshIbveNEvZOZpFOpoGNEK;

		public int jKXUyTglLQYKMHpczNPNwCVYfgkm;

		public Guid SsJDozFcGQSZLAiuOMbKvLwRNXrj;

		public PidVid dLcgUelWjyiqZHnlkReiuRwyhAUe;

		public Guid syaCwnOBhVHOsJkuTuGDwrGWttXZ;

		public int JFLpabExXYIdnrnCkUJiSgONGIBhA;

		public int mAVkHOuZUTQJRzQCtHrCTYkgMGrr;

		public int HdBjkdozZiihukfYQisuZfjPlviS;

		public int CNUANMjfVJoKjdSFAPJLOSjbuaxXb;

		public int MPCBiZXqJBqheyQMHPalgJShhMIW;

		public int YYQoAjceYPMvuANImiQOkgivuGGAA;

		public bool rcNdtndgguIHbVNCPOeaCkBHoEjo;

		public bool MuyeIobOiveDyHyWaZIfDzTnhSwT;

		public int LyxUsAMJYAIrCgTLnjMyyYiJalnl;

		private float[] DfBaezxmPvQAvWUJuqdRUDWewHSb;

		private bool[] NeweaVaFTAyMlPaHDrJhCWYcitI;

		private HardwareJoystickMap_InputManager wrwJlllnQhRPhHvFrEaSqwXOkGQb;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HtLESBlEThmFrQpsHtPthRloTaZG;

		private bool kMbnYpeXcPIklvoELvUSfbuJcONM;

		private bool bZTobtxJWtYdsQOpVPydmTeXUYKi;

		[CompilerGenerated]
		private Controller.Extension wxifiYNJTdLvCHSbFfefKusONUTYA;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return ivdpqTutyqWHvnxlxOVIewSqbgoI;
			}
			set
			{
				ivdpqTutyqWHvnxlxOVIewSqbgoI = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return DgqMmbZjJflDLLSnTyDTaFyRgMTL;
			}
			set
			{
				DgqMmbZjJflDLLSnTyDTaFyRgMTL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => hddqfqTooodUegecKzjEVhnLiUEbb;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (DgqMmbZjJflDLLSnTyDTaFyRgMTL < 0)
				{
					return null;
				}
				return DgqMmbZjJflDLLSnTyDTaFyRgMTL;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => SsJDozFcGQSZLAiuOMbKvLwRNXrj;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return wxifiYNJTdLvCHSbFfefKusONUTYA;
			}
			[CompilerGenerated]
			set
			{
				wxifiYNJTdLvCHSbFfefKusONUTYA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			icfElNCROiUdklDnZtPjcPBmyRfJ.CxjwxXdAXqPmIguRfcPlDGeioFoK(motorIndex, amount, false);
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

		public LegDxKOTNFfkQiBNJLSuGqVeMiYRA(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			HtLESBlEThmFrQpsHtPthRloTaZG = P_0;
			DgqMmbZjJflDLLSnTyDTaFyRgMTL = -1;
			ivdpqTutyqWHvnxlxOVIewSqbgoI = -1;
		}

		public void rJuZaIbwAyuhHHhiuetcWNggaRGT()
		{
			syaCwnOBhVHOsJkuTuGDwrGWttXZ = MiscTools.CreateGuidHashSHA1(frheGpikWrEkNngdebgzrNebctNt + dLcgUelWjyiqZHnlkReiuRwyhAUe.ToProductGuid().ToString());
			mAVkHOuZUTQJRzQCtHrCTYkgMGrr = CNUANMjfVJoKjdSFAPJLOSjbuaxXb;
			HdBjkdozZiihukfYQisuZfjPlviS = MPCBiZXqJBqheyQMHPalgJShhMIW + YYQoAjceYPMvuANImiQOkgivuGGAA * 8;
			XZbRUlTiIstSdeRybnGrgnlvBCXT();
			LhGiITDikgnqpqTKPcZalHInoFAH = wrwJlllnQhRPhHvFrEaSqwXOkGQb.hardwareMapIdentifier.guid;
			hddqfqTooodUegecKzjEVhnLiUEbb = wrwJlllnQhRPhHvFrEaSqwXOkGQb.controllerName;
			kMbnYpeXcPIklvoELvUSfbuJcONM = ((LhGiITDikgnqpqTKPcZalHInoFAH == Guid.Empty) ? true : false);
			DfBaezxmPvQAvWUJuqdRUDWewHSb = new float[mAVkHOuZUTQJRzQCtHrCTYkgMGrr];
			NeweaVaFTAyMlPaHDrJhCWYcitI = new bool[HdBjkdozZiihukfYQisuZfjPlviS];
			Update();
		}

		public void HisIsdwREcvHEGKOiCjiGDlzcrIfA(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0)
		{
			if (P_0 != null)
			{
				DgqMmbZjJflDLLSnTyDTaFyRgMTL = P_0.DgqMmbZjJflDLLSnTyDTaFyRgMTL;
				ivdpqTutyqWHvnxlxOVIewSqbgoI = P_0.ivdpqTutyqWHvnxlxOVIewSqbgoI;
				for (int i = 0; i < MathTools.Min(NeweaVaFTAyMlPaHDrJhCWYcitI.Length, P_0.NeweaVaFTAyMlPaHDrJhCWYcitI.Length); i++)
				{
					NeweaVaFTAyMlPaHDrJhCWYcitI[i] = P_0.NeweaVaFTAyMlPaHDrJhCWYcitI[i];
				}
				for (int j = 0; j < MathTools.Min(DfBaezxmPvQAvWUJuqdRUDWewHSb.Length, P_0.DfBaezxmPvQAvWUJuqdRUDWewHSb.Length); j++)
				{
					DfBaezxmPvQAvWUJuqdRUDWewHSb[j] = P_0.DfBaezxmPvQAvWUJuqdRUDWewHSb[j];
				}
				bZTobtxJWtYdsQOpVPydmTeXUYKi = P_0.bZTobtxJWtYdsQOpVPydmTeXUYKi;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			DAGSZeFbDhfQoKXZHFkKblmkQhzdA();
			WivDQNNGJaTlbSqjIxkTNxCIMRaK();
			if (!bZTobtxJWtYdsQOpVPydmTeXUYKi && icfElNCROiUdklDnZtPjcPBmyRfJ.guZdRDHtevbfroueBYrNAqDFlMEc)
			{
				bZTobtxJWtYdsQOpVPydmTeXUYKi = true;
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (mAVkHOuZUTQJRzQCtHrCTYkgMGrr != dataUpdater.axisCount || HdBjkdozZiihukfYQisuZfjPlviS != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < mAVkHOuZUTQJRzQCtHrCTYkgMGrr; i++)
			{
				dataUpdater.axisValues[i] = DfBaezxmPvQAvWUJuqdRUDWewHSb[i];
			}
			for (int j = 0; j < HdBjkdozZiihukfYQisuZfjPlviS; j++)
			{
				dataUpdater.buttonValues[j] = NeweaVaFTAyMlPaHDrJhCWYcitI[j];
			}
			if (bZTobtxJWtYdsQOpVPydmTeXUYKi && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int dNbMrFxiBRvKSbwxWbzanznhabot(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0)
		{
			if (P_0.ivdpqTutyqWHvnxlxOVIewSqbgoI == ivdpqTutyqWHvnxlxOVIewSqbgoI)
			{
				return 2;
			}
			if (CNUANMjfVJoKjdSFAPJLOSjbuaxXb != P_0.CNUANMjfVJoKjdSFAPJLOSjbuaxXb)
			{
				return 0;
			}
			if (MPCBiZXqJBqheyQMHPalgJShhMIW != P_0.MPCBiZXqJBqheyQMHPalgJShhMIW)
			{
				return 0;
			}
			if (YYQoAjceYPMvuANImiQOkgivuGGAA != P_0.YYQoAjceYPMvuANImiQOkgivuGGAA)
			{
				return 0;
			}
			if (P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj == SsJDozFcGQSZLAiuOMbKvLwRNXrj)
			{
				return 2;
			}
			if (P_0.syaCwnOBhVHOsJkuTuGDwrGWttXZ == syaCwnOBhVHOsJkuTuGDwrGWttXZ)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo POwILpAexluZiVBuKXNlJsfmFIoN()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			cFuFYGOcwuLOhnmDiFUmbBRMtHQi(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			CPMTqUXeuZBRnEBoakRdRYEYyORSA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(ivdpqTutyqWHvnxlxOVIewSqbgoI);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void DAGSZeFbDhfQoKXZHFkKblmkQhzdA()
		{
			if (mAVkHOuZUTQJRzQCtHrCTYkgMGrr <= 0 || wrwJlllnQhRPhHvFrEaSqwXOkGQb.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)wrwJlllnQhRPhHvFrEaSqwXOkGQb.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					NdLyTUdyrxASyfEuSNdpTPBCQIee(axes_orig[i], i);
				}
			}
		}

		private void WivDQNNGJaTlbSqjIxkTNxCIMRaK()
		{
			if (HdBjkdozZiihukfYQisuZfjPlviS <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)wrwJlllnQhRPhHvFrEaSqwXOkGQb.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					qKnXfYAoAcNBnuRuxmWXfgEJnVRD(buttons_orig[i], i);
				}
			}
		}

		private void NdLyTUdyrxASyfEuSNdpTPBCQIee(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= mAVkHOuZUTQJRzQCtHrCTYkgMGrr)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			DfBaezxmPvQAvWUJuqdRUDWewHSb[P_1] = PeLNYJUCiuLZRduDwPzkJaHDgrpU(P_0);
		}

		private void qKnXfYAoAcNBnuRuxmWXfgEJnVRD(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= HdBjkdozZiihukfYQisuZfjPlviS)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			NeweaVaFTAyMlPaHDrJhCWYcitI[P_1] = YNmaaeFrveDwsYiikipKvRcIKDTaA(P_0);
		}

		private float PeLNYJUCiuLZRduDwPzkJaHDgrpU(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= CNUANMjfVJoKjdSFAPJLOSjbuaxXb || sourceAxis >= 56)
				{
					return 0f;
				}
				return icfElNCROiUdklDnZtPjcPBmyRfJ.wrHBytMpIembXkGKitkRsUTAKnOs(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= MPCBiZXqJBqheyQMHPalgJShhMIW || sourceButton >= 256)
				{
					return 0f;
				}
				if (!icfElNCROiUdklDnZtPjcPBmyRfJ.uOSBAMcEGUxqqIQujeRrJrxKvBpY(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= YYQoAjceYPMvuANImiQOkgivuGGAA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = tFFGolYRXzzjGrhHKnsqEwYLGqAk(num, AxisDirection.Horizontal);
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
					num2 = tFFGolYRXzzjGrhHKnsqEwYLGqAk(num, AxisDirection.Vertical);
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

		private bool YNmaaeFrveDwsYiikipKvRcIKDTaA(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (icfElNCROiUdklDnZtPjcPBmyRfJ.uOSBAMcEGUxqqIQujeRrJrxKvBpY(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!icfElNCROiUdklDnZtPjcPBmyRfJ.uOSBAMcEGUxqqIQujeRrJrxKvBpY(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= MPCBiZXqJBqheyQMHPalgJShhMIW || sourceButton >= 256)
				{
					return false;
				}
				return icfElNCROiUdklDnZtPjcPBmyRfJ.uOSBAMcEGUxqqIQujeRrJrxKvBpY(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= CNUANMjfVJoKjdSFAPJLOSjbuaxXb || sourceAxis >= 56)
				{
					return false;
				}
				float num = icfElNCROiUdklDnZtPjcPBmyRfJ.wrHBytMpIembXkGKitkRsUTAKnOs(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= YYQoAjceYPMvuANImiQOkgivuGGAA || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return grSBkccizDjplDjYgiVCJFuXjoXsB(icfElNCROiUdklDnZtPjcPBmyRfJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool grSBkccizDjplDjYgiVCJFuXjoXsB(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (wrwJlllnQhRPhHvFrEaSqwXOkGQb.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float tFFGolYRXzzjGrhHKnsqEwYLGqAk(int P_0, AxisDirection P_1)
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

		private ControlDeviceType TMSDiqDavHSIBVtDGHdRUkTZBpcsA(nMnRnyDPJhCGZnsNacgXSeyxTprn P_0)
		{
			return P_0 switch
			{
				nMnRnyDPJhCGZnsNacgXSeyxTprn.Joystick => ControlDeviceType.Joystick, 
				nMnRnyDPJhCGZnsNacgXSeyxTprn.Gamepad => ControlDeviceType.Gamepad, 
				nMnRnyDPJhCGZnsNacgXSeyxTprn.Keyboard => ControlDeviceType.Keyboard, 
				nMnRnyDPJhCGZnsNacgXSeyxTprn.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void XZbRUlTiIstSdeRybnGrgnlvBCXT()
		{
			wrwJlllnQhRPhHvFrEaSqwXOkGQb = HtLESBlEThmFrQpsHtPthRloTaZG(POwILpAexluZiVBuKXNlJsfmFIoN());
			if (wrwJlllnQhRPhHvFrEaSqwXOkGQb == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (wrwJlllnQhRPhHvFrEaSqwXOkGQb.useSystemName)
			{
				if (!string.IsNullOrEmpty(KluEOAopmaJIUENPqTiYFAKzTgaCA))
				{
					string text = Regex.Replace(KluEOAopmaJIUENPqTiYFAKzTgaCA, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						wrwJlllnQhRPhHvFrEaSqwXOkGQb.controllerName = text;
					}
				}
				if (wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", icfElNCROiUdklDnZtPjcPBmyRfJ.EfhgrkzUAAoIeDZDOKpHGfScDnIbA.vendorId.ToString("x4"), icfElNCROiUdklDnZtPjcPBmyRfJ.EfhgrkzUAAoIeDZDOKpHGfScDnIbA.productId.ToString("x4"));
					wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(icfElNCROiUdklDnZtPjcPBmyRfJ.DBefJrSEzHzyielMHrAAzCXtkntp))
					{
						wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, icfElNCROiUdklDnZtPjcPBmyRfJ.DBefJrSEzHzyielMHrAAzCXtkntp));
					}
					if (!string.IsNullOrEmpty(icfElNCROiUdklDnZtPjcPBmyRfJ.DBefJrSEzHzyielMHrAAzCXtkntp))
					{
						wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.additionalIdentifyingInformation = $"{icfElNCROiUdklDnZtPjcPBmyRfJ.DBefJrSEzHzyielMHrAAzCXtkntp} [{text2}]";
					}
					else
					{
						wrwJlllnQhRPhHvFrEaSqwXOkGQb.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			mAVkHOuZUTQJRzQCtHrCTYkgMGrr = wrwJlllnQhRPhHvFrEaSqwXOkGQb.axisCount;
			HdBjkdozZiihukfYQisuZfjPlviS = wrwJlllnQhRPhHvFrEaSqwXOkGQb.buttonCount;
		}

		private string VTfxDxzsBHjlLFlZTDKWLQAsPXKj()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{icfElNCROiUdklDnZtPjcPBmyRfJ.BWecDgkvBWLCkxXkKOnXEMAgfdAhb}{frheGpikWrEkNngdebgzrNebctNt}{cPAMITqshIbveNEvZOZpFOpoGNEK}{dLcgUelWjyiqZHnlkReiuRwyhAUe.ToProductGuid()}");
		}

		private void cFuFYGOcwuLOhnmDiFUmbBRMtHQi(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = icfElNCROiUdklDnZtPjcPBmyRfJ.BWecDgkvBWLCkxXkKOnXEMAgfdAhb;
			P_0.deviceType = TMSDiqDavHSIBVtDGHdRUkTZBpcsA(gfjdOrcrndEjFAQGHcfefNNGhkcZb);
			P_0.hardwareIdentifier = VTfxDxzsBHjlLFlZTDKWLQAsPXKj();
			P_0.hardwareAxisCount = CNUANMjfVJoKjdSFAPJLOSjbuaxXb;
			P_0.hardwareButtonCount = MPCBiZXqJBqheyQMHPalgJShhMIW;
			P_0.hardwareHatCount = YYQoAjceYPMvuANImiQOkgivuGGAA;
			P_0.hw_productName = frheGpikWrEkNngdebgzrNebctNt;
			P_0.hw_deviceGuid = SsJDozFcGQSZLAiuOMbKvLwRNXrj;
			P_0.hw_productId = cPAMITqshIbveNEvZOZpFOpoGNEK;
			P_0.hw_pidVid = dLcgUelWjyiqZHnlkReiuRwyhAUe;
			P_0.hw_isBluetoothDevice = rcNdtndgguIHbVNCPOeaCkBHoEjo;
			P_0.hw_bluetoothDeviceName = frheGpikWrEkNngdebgzrNebctNt;
			P_0.hw_systemDeviceName = frheGpikWrEkNngdebgzrNebctNt;
			P_0.hw_supportsVibration = MuyeIobOiveDyHyWaZIfDzTnhSwT;
			P_0.hw_isSDL2Gamepad = icfElNCROiUdklDnZtPjcPBmyRfJ.RmizJeorYZMRzqDdKKEINFzlgANB == nMnRnyDPJhCGZnsNacgXSeyxTprn.Gamepad;
			P_0.hw_localVibrationMotorCount = LyxUsAMJYAIrCgTLnjMyyYiJalnl;
		}

		private void CPMTqUXeuZBRnEBoakRdRYEYyORSA(BridgedController P_0)
		{
			cFuFYGOcwuLOhnmDiFUmbBRMtHQi(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = wrwJlllnQhRPhHvFrEaSqwXOkGQb.ToGameHardwareControllerMap();
			P_0.instanceName = frheGpikWrEkNngdebgzrNebctNt;
			P_0.productName = frheGpikWrEkNngdebgzrNebctNt;
			P_0.axisCount = mAVkHOuZUTQJRzQCtHrCTYkgMGrr;
			P_0.buttonCount = HdBjkdozZiihukfYQisuZfjPlviS;
			P_0.unknownControllerHats = DMGYRYLzrDrqyXiXgDXFWmUJEveFA();
			P_0.controllerTypeGuid = LhGiITDikgnqpqTKPcZalHInoFAH;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void yOWtsfUnqtUxGNrIKxvuQKEqnBlf()
		{
			for (int i = 0; i < HdBjkdozZiihukfYQisuZfjPlviS; i++)
			{
				NeweaVaFTAyMlPaHDrJhCWYcitI[i] = false;
			}
			for (int j = 0; j < mAVkHOuZUTQJRzQCtHrCTYkgMGrr; j++)
			{
				DfBaezxmPvQAvWUJuqdRUDWewHSb[j] = 0f;
			}
		}

		private UnknownControllerHat[] DMGYRYLzrDrqyXiXgDXFWmUJEveFA()
		{
			if (!kMbnYpeXcPIklvoELvUSfbuJcONM)
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

		public static int sYjaPCwBhoJjqOqjNhxLzXmmSSGJ(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_1)
		{
			if (P_0.DgqMmbZjJflDLLSnTyDTaFyRgMTL < P_1.DgqMmbZjJflDLLSnTyDTaFyRgMTL)
			{
				return -1;
			}
			if (P_0.DgqMmbZjJflDLLSnTyDTaFyRgMTL > P_1.DgqMmbZjJflDLLSnTyDTaFyRgMTL)
			{
				return 1;
			}
			return 0;
		}

		public static int ThFKyKKvzQkeHTaJrJNLDoJdtRmh(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_1)
		{
			if (P_0.JFLpabExXYIdnrnCkUJiSgONGIBhA < P_1.JFLpabExXYIdnrnCkUJiSgONGIBhA)
			{
				return -1;
			}
			if (P_0.JFLpabExXYIdnrnCkUJiSgONGIBhA > P_1.JFLpabExXYIdnrnCkUJiSgONGIBhA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class BHArJHgVtcONgFmINnFcINDcHXebA
	{
		public enum zdSaUxPdKteqnIliKZJhyOotHNdIA
		{
			Exact = 0,
			Approximate = 1
		}

		public class iirBQyXpdfBSHoaeMjdCCyFvqGdcA
		{
			public int YxCPgIDlgaAabWHthvgLIhwiXJHo;

			public Guid VsLJbYgexmwGITSrwGcmxEUZNcHG;

			public Guid qJYrlZfvYgmsNjeXKQreNkvntNAw;

			public int xoxEGiiRsJybyKRhBkxTEwaKrZGg;

			public int zBRugziPnWProHeBonTMpCwKigUF;

			public int mTRSdOjZCnjiIWsuWcPKclFofBDX;

			public int txybduvEknSXbEOeMtjiUIbjFJqKA;

			public bool gGCxzplXulkzMpFWbKlzSRejskBM(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, zdSaUxPdKteqnIliKZJhyOotHNdIA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == YxCPgIDlgaAabWHthvgLIhwiXJHo)
				{
					return true;
				}
				if (zBRugziPnWProHeBonTMpCwKigUF != P_0.CNUANMjfVJoKjdSFAPJLOSjbuaxXb)
				{
					return false;
				}
				if (mTRSdOjZCnjiIWsuWcPKclFofBDX != P_0.MPCBiZXqJBqheyQMHPalgJShhMIW)
				{
					return false;
				}
				if (txybduvEknSXbEOeMtjiUIbjFJqKA != P_0.YYQoAjceYPMvuANImiQOkgivuGGAA)
				{
					return false;
				}
				return P_1 switch
				{
					zdSaUxPdKteqnIliKZJhyOotHNdIA.Exact => VsLJbYgexmwGITSrwGcmxEUZNcHG == P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj, 
					zdSaUxPdKteqnIliKZJhyOotHNdIA.Approximate => qJYrlZfvYgmsNjeXKQreNkvntNAw == P_0.syaCwnOBhVHOsJkuTuGDwrGWttXZ, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class VakIgyeiwRvikfUQLohpgkkdvYMJc : IEnumerable<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>, IEnumerable, IEnumerator<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>, IEnumerator, IDisposable
		{
			private int OvHeWwKGulhKGdrSitCXKLgVxcIg;

			private iirBQyXpdfBSHoaeMjdCCyFvqGdcA cTuIgQSKUzCXjRPxDWXUxvKdFERe;

			private int wTvpmmLuSKqpJaFTNYvWZoyFGSDHA;

			public BHArJHgVtcONgFmINnFcINDcHXebA XajpkDmBtFeVtfUDDSlMgybGpSgnb;

			private LegDxKOTNFfkQiBNJLSuGqVeMiYRA mALzbBvJxstyrwEUxnoiBSwvcfWS;

			public LegDxKOTNFfkQiBNJLSuGqVeMiYRA mGKGssFWqLKwmMgAPeIiQgDbAKJl;

			private zdSaUxPdKteqnIliKZJhyOotHNdIA dEaWVTtVkYfgFVngNuRVrAUBhfMc;

			public zdSaUxPdKteqnIliKZJhyOotHNdIA SCHXcYqfEOFlZtChkqBbzjAXkJfx;

			private int jdqeejcUuqsbLvcDJigyufhhffzyA;

			private int kXKqEaeqPmvUzJVJNmbbGnqkrNDm;

			iirBQyXpdfBSHoaeMjdCCyFvqGdcA IEnumerator<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>.Current
			{
				[DebuggerHidden]
				get
				{
					return cTuIgQSKUzCXjRPxDWXUxvKdFERe;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cTuIgQSKUzCXjRPxDWXUxvKdFERe;
				}
			}

			[DebuggerHidden]
			public VakIgyeiwRvikfUQLohpgkkdvYMJc(int P_0)
			{
				OvHeWwKGulhKGdrSitCXKLgVxcIg = P_0;
				wTvpmmLuSKqpJaFTNYvWZoyFGSDHA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int ovHeWwKGulhKGdrSitCXKLgVxcIg = OvHeWwKGulhKGdrSitCXKLgVxcIg;
				BHArJHgVtcONgFmINnFcINDcHXebA xajpkDmBtFeVtfUDDSlMgybGpSgnb = XajpkDmBtFeVtfUDDSlMgybGpSgnb;
				if (ovHeWwKGulhKGdrSitCXKLgVxcIg != 0)
				{
					if (ovHeWwKGulhKGdrSitCXKLgVxcIg != 1)
					{
						return false;
					}
					OvHeWwKGulhKGdrSitCXKLgVxcIg = -1;
					goto IL_0083;
				}
				OvHeWwKGulhKGdrSitCXKLgVxcIg = -1;
				jdqeejcUuqsbLvcDJigyufhhffzyA = xajpkDmBtFeVtfUDDSlMgybGpSgnb.jUuisVvECiFJQbkBVCmfITAKeAoh.Count;
				kXKqEaeqPmvUzJVJNmbbGnqkrNDm = 0;
				goto IL_0093;
				IL_0083:
				kXKqEaeqPmvUzJVJNmbbGnqkrNDm++;
				goto IL_0093;
				IL_0093:
				if (kXKqEaeqPmvUzJVJNmbbGnqkrNDm < jdqeejcUuqsbLvcDJigyufhhffzyA)
				{
					if (xajpkDmBtFeVtfUDDSlMgybGpSgnb.jUuisVvECiFJQbkBVCmfITAKeAoh[kXKqEaeqPmvUzJVJNmbbGnqkrNDm].gGCxzplXulkzMpFWbKlzSRejskBM(mALzbBvJxstyrwEUxnoiBSwvcfWS, dEaWVTtVkYfgFVngNuRVrAUBhfMc))
					{
						cTuIgQSKUzCXjRPxDWXUxvKdFERe = xajpkDmBtFeVtfUDDSlMgybGpSgnb.jUuisVvECiFJQbkBVCmfITAKeAoh[kXKqEaeqPmvUzJVJNmbbGnqkrNDm];
						OvHeWwKGulhKGdrSitCXKLgVxcIg = 1;
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
			IEnumerator<iirBQyXpdfBSHoaeMjdCCyFvqGdcA> IEnumerable<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>.GetEnumerator()
			{
				VakIgyeiwRvikfUQLohpgkkdvYMJc vakIgyeiwRvikfUQLohpgkkdvYMJc;
				if (OvHeWwKGulhKGdrSitCXKLgVxcIg == -2 && wTvpmmLuSKqpJaFTNYvWZoyFGSDHA == Environment.CurrentManagedThreadId)
				{
					OvHeWwKGulhKGdrSitCXKLgVxcIg = 0;
					vakIgyeiwRvikfUQLohpgkkdvYMJc = this;
				}
				else
				{
					vakIgyeiwRvikfUQLohpgkkdvYMJc = new VakIgyeiwRvikfUQLohpgkkdvYMJc(0);
					vakIgyeiwRvikfUQLohpgkkdvYMJc.XajpkDmBtFeVtfUDDSlMgybGpSgnb = XajpkDmBtFeVtfUDDSlMgybGpSgnb;
				}
				vakIgyeiwRvikfUQLohpgkkdvYMJc.mALzbBvJxstyrwEUxnoiBSwvcfWS = mGKGssFWqLKwmMgAPeIiQgDbAKJl;
				vakIgyeiwRvikfUQLohpgkkdvYMJc.dEaWVTtVkYfgFVngNuRVrAUBhfMc = SCHXcYqfEOFlZtChkqBbzjAXkJfx;
				return vakIgyeiwRvikfUQLohpgkkdvYMJc;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>)this).GetEnumerator();
			}
		}

		private List<iirBQyXpdfBSHoaeMjdCCyFvqGdcA> jUuisVvECiFJQbkBVCmfITAKeAoh;

		public BHArJHgVtcONgFmINnFcINDcHXebA()
		{
			jUuisVvECiFJQbkBVCmfITAKeAoh = new List<iirBQyXpdfBSHoaeMjdCCyFvqGdcA>();
		}

		public void LiJmIfBjhPEfUAqhjzACbmCrbYaM(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = jUuisVvECiFJQbkBVCmfITAKeAoh.Count;
			for (int i = 0; i < count; i++)
			{
				if (jUuisVvECiFJQbkBVCmfITAKeAoh[i].gGCxzplXulkzMpFWbKlzSRejskBM(P_0, zdSaUxPdKteqnIliKZJhyOotHNdIA.Exact))
				{
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].YxCPgIDlgaAabWHthvgLIhwiXJHo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].VsLJbYgexmwGITSrwGcmxEUZNcHG = P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].qJYrlZfvYgmsNjeXKQreNkvntNAw = P_0.syaCwnOBhVHOsJkuTuGDwrGWttXZ;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].xoxEGiiRsJybyKRhBkxTEwaKrZGg = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].zBRugziPnWProHeBonTMpCwKigUF = P_0.CNUANMjfVJoKjdSFAPJLOSjbuaxXb;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].mTRSdOjZCnjiIWsuWcPKclFofBDX = P_0.MPCBiZXqJBqheyQMHPalgJShhMIW;
					jUuisVvECiFJQbkBVCmfITAKeAoh[i].txybduvEknSXbEOeMtjiUIbjFJqKA = P_0.YYQoAjceYPMvuANImiQOkgivuGGAA;
					jVYseTiIXFAdrFUjsDDiZKomfSWe(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj, i);
					return;
				}
			}
			jUuisVvECiFJQbkBVCmfITAKeAoh.Add(new iirBQyXpdfBSHoaeMjdCCyFvqGdcA
			{
				YxCPgIDlgaAabWHthvgLIhwiXJHo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				VsLJbYgexmwGITSrwGcmxEUZNcHG = P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj,
				qJYrlZfvYgmsNjeXKQreNkvntNAw = P_0.syaCwnOBhVHOsJkuTuGDwrGWttXZ,
				xoxEGiiRsJybyKRhBkxTEwaKrZGg = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				zBRugziPnWProHeBonTMpCwKigUF = P_0.CNUANMjfVJoKjdSFAPJLOSjbuaxXb,
				mTRSdOjZCnjiIWsuWcPKclFofBDX = P_0.MPCBiZXqJBqheyQMHPalgJShhMIW,
				txybduvEknSXbEOeMtjiUIbjFJqKA = P_0.YYQoAjceYPMvuANImiQOkgivuGGAA
			});
			jVYseTiIXFAdrFUjsDDiZKomfSWe(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.SsJDozFcGQSZLAiuOMbKvLwRNXrj, jUuisVvECiFJQbkBVCmfITAKeAoh.Count - 1);
		}

		public bool BSWvdtceCnkNEEsIccFWWBChdNfG(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, zdSaUxPdKteqnIliKZJhyOotHNdIA P_1)
		{
			int count = jUuisVvECiFJQbkBVCmfITAKeAoh.Count;
			for (int i = 0; i < count; i++)
			{
				if (jUuisVvECiFJQbkBVCmfITAKeAoh[i].gGCxzplXulkzMpFWbKlzSRejskBM(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(VakIgyeiwRvikfUQLohpgkkdvYMJc))]
		public IEnumerable<iirBQyXpdfBSHoaeMjdCCyFvqGdcA> fnfDujELFzDAQJpHJJfrKGfDHEOF(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, zdSaUxPdKteqnIliKZJhyOotHNdIA P_1)
		{
			return new VakIgyeiwRvikfUQLohpgkkdvYMJc(-2)
			{
				XajpkDmBtFeVtfUDDSlMgybGpSgnb = this,
				mGKGssFWqLKwmMgAPeIiQgDbAKJl = P_0,
				SCHXcYqfEOFlZtChkqBbzjAXkJfx = P_1
			};
		}

		private void jVYseTiIXFAdrFUjsDDiZKomfSWe(int P_0, Guid P_1, int P_2)
		{
			for (int num = jUuisVvECiFJQbkBVCmfITAKeAoh.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (jUuisVvECiFJQbkBVCmfITAKeAoh[num].YxCPgIDlgaAabWHthvgLIhwiXJHo == P_0 || jUuisVvECiFJQbkBVCmfITAKeAoh[num].VsLJbYgexmwGITSrwGcmxEUZNcHG == P_1))
				{
					jUuisVvECiFJQbkBVCmfITAKeAoh.RemoveAt(num);
				}
			}
		}
	}

	internal const bool yqpXsAdZsGtZuQkDBWboBaeOPZnb = true;

	private IInputSource XLZHHtlAnVTLTNRLCctLVFmhDFcI;

	private List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> CssTKmVnbReAHEQQVavHqbmlYutB;

	private int GKAagddqTuSVlixyUgeCKvKdnnbQA;

	private BHArJHgVtcONgFmINnFcINDcHXebA waDlmQhWhNOjoqEfGBUwYKSFiTbx;

	private bool XacaZdjVRKBTncTJmfkaUmCoDyWMA;

	private Action<int, ControllerDataUpdater> NHZtnVwrRrzkeOuTwXqzqGCmVyoh;

	private PlatformInputManager XWBxjEUeuShjaoqNqTIRfQzwbjVF;

	private readonly bool ywAaOjdObEhleuxuybEJiDMDlzzsA;

	private readonly bool usNCQJGqbMTbKQKGcqqWmjdbvkQQ;

	private readonly bool qSEgcoHMBvayMIJNVtXavWbeaPQE;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> FCcLplTYkXofBDDjWFbTRnAiPNQH;

	private readonly Func<int> HPKyappZHdrQiQAhWQxMYSJqyAjJ;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => GKAagddqTuSVlixyUgeCKvKdnnbQA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => XWBxjEUeuShjaoqNqTIRfQzwbjVF;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => XLZHHtlAnVTLTNRLCctLVFmhDFcI;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.SDL2;

	public pVCnQGEndlyOQtYMurDRbysLyjGd(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			FCcLplTYkXofBDDjWFbTRnAiPNQH = P_1;
			HPKyappZHdrQiQAhWQxMYSJqyAjJ = P_2;
			ywAaOjdObEhleuxuybEJiDMDlzzsA = P_3;
			usNCQJGqbMTbKQKGcqqWmjdbvkQQ = P_4;
			qSEgcoHMBvayMIJNVtXavWbeaPQE = P_5;
			XWBxjEUeuShjaoqNqTIRfQzwbjVF = this;
			XLZHHtlAnVTLTNRLCctLVFmhDFcI = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			NHZtnVwrRrzkeOuTwXqzqGCmVyoh = UpdateControllerData;
			XLZHHtlAnVTLTNRLCctLVFmhDFcI.DeviceChangedEvent += dGWrSeUNukPdFixtpWmPsnfDUhdA;
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
		if (ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			waDlmQhWhNOjoqEfGBUwYKSFiTbx = new BHArJHgVtcONgFmINnFcINDcHXebA();
			lkWrJNsTUjepRWpBdUOUKtDiFJxO();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (XLZHHtlAnVTLTNRLCctLVFmhDFcI != null)
		{
			XLZHHtlAnVTLTNRLCctLVFmhDFcI.Update();
		}
		if (ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			if (XacaZdjVRKBTncTJmfkaUmCoDyWMA)
			{
				QMQbGUmHZmInKKkWkLxfLpgqWved();
			}
			if (XLZHHtlAnVTLTNRLCctLVFmhDFcI != null)
			{
				for (int i = 0; i < GKAagddqTuSVlixyUgeCKvKdnnbQA; i++)
				{
					CssTKmVnbReAHEQQVavHqbmlYutB[i]?.icfElNCROiUdklDnZtPjcPBmyRfJ.SQEvZnxFJxmfctNuqxfbhSKrNDFg(updateLoop);
				}
				XLZHHtlAnVTLTNRLCctLVFmhDFcI.UpdateDevices(updateLoop);
			}
			osbgEdGVZWYDbUZfmSefXxzdWIzP();
			if (XLZHHtlAnVTLTNRLCctLVFmhDFcI != null)
			{
				XLZHHtlAnVTLTNRLCctLVFmhDFcI.UpdateFinished();
				for (int j = 0; j < GKAagddqTuSVlixyUgeCKvKdnnbQA; j++)
				{
					CssTKmVnbReAHEQQVavHqbmlYutB[j]?.icfElNCROiUdklDnZtPjcPBmyRfJ.uUvaTpQKkJckAsqXqfLgjHVtDLYL();
				}
			}
		}
		_ = usNCQJGqbMTbKQKGcqqWmjdbvkQQ;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (CssTKmVnbReAHEQQVavHqbmlYutB != null)
		{
			int count = CssTKmVnbReAHEQQVavHqbmlYutB.Count;
			for (int i = 0; i < count; i++)
			{
				if (CssTKmVnbReAHEQQVavHqbmlYutB[i] != null)
				{
					CssTKmVnbReAHEQQVavHqbmlYutB[i].icfElNCROiUdklDnZtPjcPBmyRfJ?.LzThNhMXDfgQrDaVdKmKVUhOEUmQ();
				}
			}
		}
		if (XLZHHtlAnVTLTNRLCctLVFmhDFcI != null)
		{
			XLZHHtlAnVTLTNRLCctLVFmhDFcI.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NHZtnVwrRrzkeOuTwXqzqGCmVyoh;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			return;
		}
		for (int i = 0; i < GKAagddqTuSVlixyUgeCKvKdnnbQA; i++)
		{
			if (CssTKmVnbReAHEQQVavHqbmlYutB[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				CssTKmVnbReAHEQQVavHqbmlYutB[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			XacaZdjVRKBTncTJmfkaUmCoDyWMA = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			XacaZdjVRKBTncTJmfkaUmCoDyWMA = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = ywAaOjdObEhleuxuybEJiDMDlzzsA;
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

	private void lkWrJNsTUjepRWpBdUOUKtDiFJxO()
	{
		TgROlfQvvbanGpLjCMnZAGWkVyoK(mPUUmQsHuqwTUyUPbgCrjTBcaBnA());
	}

	private void TgROlfQvvbanGpLjCMnZAGWkVyoK(IList<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> P_0)
	{
		int num = 0;
		List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> cssTKmVnbReAHEQQVavHqbmlYutB = CssTKmVnbReAHEQQVavHqbmlYutB;
		int gKAagddqTuSVlixyUgeCKvKdnnbQA = GKAagddqTuSVlixyUgeCKvKdnnbQA;
		CssTKmVnbReAHEQQVavHqbmlYutB = new List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				XAZzsMQMImLcZRwmVzOOEmMtHEOJ xAZzsMQMImLcZRwmVzOOEmMtHEOJ = P_0[i];
				LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA = new LegDxKOTNFfkQiBNJLSuGqVeMiYRA(FCcLplTYkXofBDDjWFbTRnAiPNQH);
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.icfElNCROiUdklDnZtPjcPBmyRfJ = xAZzsMQMImLcZRwmVzOOEmMtHEOJ;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.SsJDozFcGQSZLAiuOMbKvLwRNXrj = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.swXcZdUoysXoJxTNpcqKgwvRSzcs;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.frheGpikWrEkNngdebgzrNebctNt = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.DBefJrSEzHzyielMHrAAzCXtkntp;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.KluEOAopmaJIUENPqTiYFAKzTgaCA = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.SrlGyVRmaklovgeTiCQRIolBCUFP;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.dLcgUelWjyiqZHnlkReiuRwyhAUe = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.EfhgrkzUAAoIeDZDOKpHGfScDnIbA;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.cPAMITqshIbveNEvZOZpFOpoGNEK = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.mFdQfsxTgmzXWGhPeDbNPdZRBkCK;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.jKXUyTglLQYKMHpczNPNwCVYfgkm = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.PGqJGdaLxNXjoTOGWwNgiZShwnsL;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.gfjdOrcrndEjFAQGHcfefNNGhkcZb = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.RmizJeorYZMRzqDdKKEINFzlgANB;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.JFLpabExXYIdnrnCkUJiSgONGIBhA = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.FuazTfBEgBksQnjVWQekdSorKnmi;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.CNUANMjfVJoKjdSFAPJLOSjbuaxXb = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.xHNfwioLhxUhgxfwkpRRqwjAQCUd;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.MPCBiZXqJBqheyQMHPalgJShhMIW = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.BJetBysKtJNcJXJCjbAEKPMjBXcvA;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.YYQoAjceYPMvuANImiQOkgivuGGAA = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.yOGmorjMedujUoVLuHGDRIOGisKEA;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.rcNdtndgguIHbVNCPOeaCkBHoEjo = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.JiJPOcBxPAlxfqqAfaFSehizEKsv;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.MuyeIobOiveDyHyWaZIfDzTnhSwT = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.pxdxJPcqanerFcFjsSexgdEretKaA;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.LyxUsAMJYAIrCgTLnjMyyYiJalnl = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.moomLpRJsVzVtAzUHdeyoaJBWMHG;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = xAZzsMQMImLcZRwmVzOOEmMtHEOJ.PhSSEajxNPWWgSGcvWWBJCqutJdo;
				xAZzsMQMImLcZRwmVzOOEmMtHEOJ.NQJpFfsMYgvXvDKEqTvqlEyQwGeu();
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.rJuZaIbwAyuhHHhiuetcWNggaRGT();
				CssTKmVnbReAHEQQVavHqbmlYutB.Add(legDxKOTNFfkQiBNJLSuGqVeMiYRA);
				num++;
			}
		}
		GKAagddqTuSVlixyUgeCKvKdnnbQA = num;
		SZIHLkKyrHbvCHjMGaPigFEoqvKFb(gKAagddqTuSVlixyUgeCKvKdnnbQA, num, cssTKmVnbReAHEQQVavHqbmlYutB, CssTKmVnbReAHEQQVavHqbmlYutB);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(CssTKmVnbReAHEQQVavHqbmlYutB[j]));
			}
		}
		khObgAioMvTxeRyxgUUZBgYBaWeG(cssTKmVnbReAHEQQVavHqbmlYutB, CssTKmVnbReAHEQQVavHqbmlYutB, false);
		khObgAioMvTxeRyxgUUZBgYBaWeG(CssTKmVnbReAHEQQVavHqbmlYutB, cssTKmVnbReAHEQQVavHqbmlYutB, true);
	}

	private void osbgEdGVZWYDbUZfmSefXxzdWIzP()
	{
		for (int i = 0; i < GKAagddqTuSVlixyUgeCKvKdnnbQA; i++)
		{
			CssTKmVnbReAHEQQVavHqbmlYutB[i]?.Update();
		}
	}

	private bool AlZoJhAMUJEPbDsZuCZcdiOcBiNYb(rEXGaKhLHwvFBakzfgVQFrCIIsrYb P_0)
	{
		try
		{
			return P_0.IyYoJlFrXGoLEiXuVnxzxMEfcOFp();
		}
		catch
		{
			return false;
		}
	}

	private IList<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> mPUUmQsHuqwTUyUPbgCrjTBcaBnA()
	{
		return XLZHHtlAnVTLTNRLCctLVFmhDFcI.GetJoysticks<XAZzsMQMImLcZRwmVzOOEmMtHEOJ>();
	}

	private void SZIHLkKyrHbvCHjMGaPigFEoqvKFb(int P_0, int P_1, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_2, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(LegDxKOTNFfkQiBNJLSuGqVeMiYRA.ThFKyKKvzQkeHTaJrJNLDoJdtRmh);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			OkQQxMWJOYctXaUBzDbSXETtTXwe(P_1, P_3, P_0, P_2, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA.Exact);
			OkQQxMWJOYctXaUBzDbSXETtTXwe(P_1, P_3, P_0, P_2, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA.Approximate);
		}
		tZjyQSLjKKVmqrGwJOShdMxbJVdl(P_1, P_3, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA.Exact);
		tZjyQSLjKKVmqrGwJOShdMxbJVdl(P_1, P_3, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA = P_3[i];
			if (legDxKOTNFfkQiBNJLSuGqVeMiYRA != null && legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = zjpCbUmjrvdyYkLJzomyzeBkyxqU(P_3);
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = HPKyappZHdrQiQAhWQxMYSJqyAjJ();
				waDlmQhWhNOjoqEfGBUwYKSFiTbx.LiJmIfBjhPEfUAqhjzACbmCrbYaM(legDxKOTNFfkQiBNJLSuGqVeMiYRA);
			}
		}
		P_3.Sort(LegDxKOTNFfkQiBNJLSuGqVeMiYRA.sYjaPCwBhoJjqOqjNhxLzXmmSSGJ);
	}

	private void qzgwNFjFLshDyxljTcjcQATfxSD(List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_0, int P_1, int P_2)
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

	private bool FNPJOkZluptyNKOcqVeXiLeEPlUb(List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_0, int P_1)
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

	private int zjpCbUmjrvdyYkLJzomyzeBkyxqU(List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_0)
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

	private bool iVbgBhnEKOIcxFfplERPYGhEjgnEb(List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_0, int P_1)
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

	private void OkQQxMWJOYctXaUBzDbSXETtTXwe(int P_0, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_1, int P_2, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_3, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA P_4)
	{
		int num = ((P_4 != BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA = P_1[i];
			if (legDxKOTNFfkQiBNJLSuGqVeMiYRA == null || legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA2 = P_3[j];
				if (legDxKOTNFfkQiBNJLSuGqVeMiYRA2 != null && !iVbgBhnEKOIcxFfplERPYGhEjgnEb(P_1, legDxKOTNFfkQiBNJLSuGqVeMiYRA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && legDxKOTNFfkQiBNJLSuGqVeMiYRA.dNbMrFxiBRvKSbwxWbzanznhabot(legDxKOTNFfkQiBNJLSuGqVeMiYRA2) >= num)
				{
					legDxKOTNFfkQiBNJLSuGqVeMiYRA.HisIsdwREcvHEGKOiCjiGDlzcrIfA(legDxKOTNFfkQiBNJLSuGqVeMiYRA2);
					waDlmQhWhNOjoqEfGBUwYKSFiTbx.LiJmIfBjhPEfUAqhjzACbmCrbYaM(legDxKOTNFfkQiBNJLSuGqVeMiYRA);
				}
			}
		}
	}

	private void tZjyQSLjKKVmqrGwJOShdMxbJVdl(int P_0, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_1, BHArJHgVtcONgFmINnFcINDcHXebA.zdSaUxPdKteqnIliKZJhyOotHNdIA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA = P_1[i];
			if (legDxKOTNFfkQiBNJLSuGqVeMiYRA == null || legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			BHArJHgVtcONgFmINnFcINDcHXebA.iirBQyXpdfBSHoaeMjdCCyFvqGdcA iirBQyXpdfBSHoaeMjdCCyFvqGdcA = null;
			foreach (BHArJHgVtcONgFmINnFcINDcHXebA.iirBQyXpdfBSHoaeMjdCCyFvqGdcA item in waDlmQhWhNOjoqEfGBUwYKSFiTbx.fnfDujELFzDAQJpHJJfrKGfDHEOF(legDxKOTNFfkQiBNJLSuGqVeMiYRA, P_2))
			{
				if (!iVbgBhnEKOIcxFfplERPYGhEjgnEb(P_1, item.YxCPgIDlgaAabWHthvgLIhwiXJHo) && item.xoxEGiiRsJybyKRhBkxTEwaKrZGg >= 0)
				{
					iirBQyXpdfBSHoaeMjdCCyFvqGdcA = item;
					break;
				}
			}
			if (iirBQyXpdfBSHoaeMjdCCyFvqGdcA != null)
			{
				int num = iirBQyXpdfBSHoaeMjdCCyFvqGdcA.xoxEGiiRsJybyKRhBkxTEwaKrZGg;
				if (!FNPJOkZluptyNKOcqVeXiLeEPlUb(P_1, num))
				{
					num = (iirBQyXpdfBSHoaeMjdCCyFvqGdcA.xoxEGiiRsJybyKRhBkxTEwaKrZGg = zjpCbUmjrvdyYkLJzomyzeBkyxqU(P_1));
				}
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				legDxKOTNFfkQiBNJLSuGqVeMiYRA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = iirBQyXpdfBSHoaeMjdCCyFvqGdcA.YxCPgIDlgaAabWHthvgLIhwiXJHo;
				waDlmQhWhNOjoqEfGBUwYKSFiTbx.LiJmIfBjhPEfUAqhjzACbmCrbYaM(legDxKOTNFfkQiBNJLSuGqVeMiYRA);
			}
		}
	}

	private void QMQbGUmHZmInKKkWkLxfLpgqWved()
	{
		IList<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> list = mPUUmQsHuqwTUyUPbgCrjTBcaBnA();
		TgROlfQvvbanGpLjCMnZAGWkVyoK(list);
		XacaZdjVRKBTncTJmfkaUmCoDyWMA = false;
	}

	private bool bmNZpvWSoglOzWpOzwOPCdwzGDwY(IList<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !FuxMoaJlnjZWCUVUNVFPWFdyiLsJ(P_0[i].swXcZdUoysXoJxTNpcqKgwvRSzcs))
			{
				return true;
			}
		}
		int count2 = CssTKmVnbReAHEQQVavHqbmlYutB.Count;
		for (int j = 0; j < count2; j++)
		{
			if (CssTKmVnbReAHEQQVavHqbmlYutB[j] != null && !aHIwRgdSftabmimnstWEGytCmeNh(P_0, CssTKmVnbReAHEQQVavHqbmlYutB[j].SsJDozFcGQSZLAiuOMbKvLwRNXrj))
			{
				return true;
			}
		}
		return false;
	}

	private bool FuxMoaJlnjZWCUVUNVFPWFdyiLsJ(Guid P_0)
	{
		int count = CssTKmVnbReAHEQQVavHqbmlYutB.Count;
		for (int i = 0; i < count; i++)
		{
			if (CssTKmVnbReAHEQQVavHqbmlYutB[i] != null && CssTKmVnbReAHEQQVavHqbmlYutB[i].SsJDozFcGQSZLAiuOMbKvLwRNXrj == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool aHIwRgdSftabmimnstWEGytCmeNh(IList<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].swXcZdUoysXoJxTNpcqKgwvRSzcs == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void khObgAioMvTxeRyxgUUZBgYBaWeG(List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_0, List<LegDxKOTNFfkQiBNJLSuGqVeMiYRA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA = P_0[i];
			if (legDxKOTNFfkQiBNJLSuGqVeMiYRA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					LegDxKOTNFfkQiBNJLSuGqVeMiYRA legDxKOTNFfkQiBNJLSuGqVeMiYRA2 = P_1[j];
					if (legDxKOTNFfkQiBNJLSuGqVeMiYRA2 != null && legDxKOTNFfkQiBNJLSuGqVeMiYRA.SsJDozFcGQSZLAiuOMbKvLwRNXrj == legDxKOTNFfkQiBNJLSuGqVeMiYRA2.SsJDozFcGQSZLAiuOMbKvLwRNXrj)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				JvLLgLGKNAyDFDkJXbnvqqtZYDhM(P_0[i], P_2);
			}
		}
	}

	private void JvLLgLGKNAyDFDkJXbnvqqtZYDhM(LegDxKOTNFfkQiBNJLSuGqVeMiYRA P_0, bool P_1)
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

	private void dGWrSeUNukPdFixtpWmPsnfDUhdA()
	{
		if (ywAaOjdObEhleuxuybEJiDMDlzzsA)
		{
			XacaZdjVRKBTncTJmfkaUmCoDyWMA = true;
		}
		SystemDeviceConnected();
	}
}
