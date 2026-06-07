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
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class BSxuxkpqlruyakdxPRXoRuCTALKT : PlatformInputManager, ABvzBDZAjyYZQREtNVKEUBATbshn
{
	private class bRGrQSsmGYcQvEIdClixFNgYhPLEA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int fIjGatCwgHuAqlhZQGqCedLkEAVsc;

		private int olFOwsVQMNkRnzVEvUfgyEpHDPvY;

		public Guid agcQnVHWKnURDOabhiuRcSMXEIxEb;

		public string hbfdTPAZktbTCyrucSqyRHNfOlRV;

		public readonly blJFQAJZVzzuBtgglibdVWVaJgpX bLiDqnjPNnYOLopzLuEokFheeLbPA;

		public NmeNOpqJNpvsXZGMMFZCJOCAUrey GkAmoLGUDKsxgfESOdFsuChSEKwK;

		public nCgvUVEDrMuJWQeLQpzrlBKMvXND rgFTFQxxDiooZShnRKUWSHGFmfLs;

		public string LUEzHOdPYwBEukxtpMAJuBNhAYKy;

		public string JePvkTeYhPabLqEeEAEwAeuKtpGQ;

		public int GeuWWYSZESIpexvVGmqZfSRPvVBi;

		public Guid DTCbeGaRwaaHBvwglObfRyPGvFdnA;

		public Guid fFaCsHrgPAfioCVHsmmTxDalGSXSA;

		public Guid vCEjRnEevHALmiUbBVieclavfqCLc;

		public int wpbxZYMKouNzTMsUCPGcvoUocYAv;

		public bool cjfAIiOxGHrPzmjTnlphtwnmhKYj;

		public string KYctGCHGLXyidxEaqpmlCueCwYDf;

		public string DmtjoYRQnWRYmJVRiaDzujiwQoJj;

		public int CJLCCvFhUKesSSEwydLrUSNupCxWA;

		public int eSSbHBEhQxhqYIpZxpIyRppLRaxrA;

		public int SalwCmhPSAVhOwpDnZmMbUgwNwDn;

		public int cTVROwldghlxQaScAeIkXeQWfUGGA;

		public int YZYeogkZhOVlboQappUNJfPSbxOg;

		public bool EcZnpaWAsuTjwZHoQBGOvbBkkMck;

		private float[] PVEEedaluUflovPtlHDTWPFaTUsPA;

		private bool[] nWtyMqsbWhSsLPTIoaIxnmMabnIhA;

		private HardwareJoystickMap_InputManager uIoeHVsdYNKLAvPemcWhpppymLgw;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> XRMJjcnhFEWSIseJqixIEsyczNOnA;

		private bool ykIwMUBsjgffPAFGHiKkkIxdDPyR;

		private bool qHQPaemUHabkdeFIOIsJccmyoMnNA;

		private bool iICPDJVpTDVNBJcHnsfrzzbdCOMV;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return fIjGatCwgHuAqlhZQGqCedLkEAVsc;
			}
			set
			{
				fIjGatCwgHuAqlhZQGqCedLkEAVsc = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return olFOwsVQMNkRnzVEvUfgyEpHDPvY;
			}
			set
			{
				olFOwsVQMNkRnzVEvUfgyEpHDPvY = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (hbfdTPAZktbTCyrucSqyRHNfOlRV != "Unknown Controller")
				{
					return hbfdTPAZktbTCyrucSqyRHNfOlRV;
				}
				if (cjfAIiOxGHrPzmjTnlphtwnmhKYj && !string.IsNullOrEmpty(KYctGCHGLXyidxEaqpmlCueCwYDf))
				{
					return KYctGCHGLXyidxEaqpmlCueCwYDf;
				}
				return JePvkTeYhPabLqEeEAEwAeuKtpGQ;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (olFOwsVQMNkRnzVEvUfgyEpHDPvY < 0)
				{
					return null;
				}
				return olFOwsVQMNkRnzVEvUfgyEpHDPvY;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => DTCbeGaRwaaHBvwglObfRyPGvFdnA;

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

		public bRGrQSsmGYcQvEIdClixFNgYhPLEA(blJFQAJZVzzuBtgglibdVWVaJgpX P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			bLiDqnjPNnYOLopzLuEokFheeLbPA = P_0;
			XRMJjcnhFEWSIseJqixIEsyczNOnA = P_1;
			olFOwsVQMNkRnzVEvUfgyEpHDPvY = -1;
			fIjGatCwgHuAqlhZQGqCedLkEAVsc = -1;
		}

		public void bYjHkUExJLWHYpVsmfsbqZpBHSZH()
		{
			string jePvkTeYhPabLqEeEAEwAeuKtpGQ = JePvkTeYhPabLqEeEAEwAeuKtpGQ;
			Guid guid = fFaCsHrgPAfioCVHsmmTxDalGSXSA;
			vCEjRnEevHALmiUbBVieclavfqCLc = MiscTools.CreateGuidHashSHA1(jePvkTeYhPabLqEeEAEwAeuKtpGQ + guid.ToString());
			CJLCCvFhUKesSSEwydLrUSNupCxWA = SalwCmhPSAVhOwpDnZmMbUgwNwDn;
			eSSbHBEhQxhqYIpZxpIyRppLRaxrA = cTVROwldghlxQaScAeIkXeQWfUGGA + YZYeogkZhOVlboQappUNJfPSbxOg * 8;
			kMoyTlBtpMKezYwyMNAriamwlzti();
			agcQnVHWKnURDOabhiuRcSMXEIxEb = uIoeHVsdYNKLAvPemcWhpppymLgw.hardwareMapIdentifier.guid;
			hbfdTPAZktbTCyrucSqyRHNfOlRV = uIoeHVsdYNKLAvPemcWhpppymLgw.controllerName;
			ykIwMUBsjgffPAFGHiKkkIxdDPyR = ((agcQnVHWKnURDOabhiuRcSMXEIxEb == Guid.Empty) ? true : false);
			PVEEedaluUflovPtlHDTWPFaTUsPA = new float[CJLCCvFhUKesSSEwydLrUSNupCxWA];
			nWtyMqsbWhSsLPTIoaIxnmMabnIhA = new bool[eSSbHBEhQxhqYIpZxpIyRppLRaxrA];
			bLiDqnjPNnYOLopzLuEokFheeLbPA.eZsQOmCRBPUbwSgBJHIqMExAeIxkA();
			Update();
		}

		public void fnorWiJrGRkDgoefCTKMMJsKDhQiA(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0)
		{
			if (P_0 != null)
			{
				olFOwsVQMNkRnzVEvUfgyEpHDPvY = P_0.olFOwsVQMNkRnzVEvUfgyEpHDPvY;
				fIjGatCwgHuAqlhZQGqCedLkEAVsc = P_0.fIjGatCwgHuAqlhZQGqCedLkEAVsc;
				for (int i = 0; i < MathTools.Min(nWtyMqsbWhSsLPTIoaIxnmMabnIhA.Length, P_0.nWtyMqsbWhSsLPTIoaIxnmMabnIhA.Length); i++)
				{
					nWtyMqsbWhSsLPTIoaIxnmMabnIhA[i] = P_0.nWtyMqsbWhSsLPTIoaIxnmMabnIhA[i];
				}
				for (int j = 0; j < MathTools.Min(PVEEedaluUflovPtlHDTWPFaTUsPA.Length, P_0.PVEEedaluUflovPtlHDTWPFaTUsPA.Length); j++)
				{
					PVEEedaluUflovPtlHDTWPFaTUsPA[j] = P_0.PVEEedaluUflovPtlHDTWPFaTUsPA[j];
				}
				qHQPaemUHabkdeFIOIsJccmyoMnNA = P_0.qHQPaemUHabkdeFIOIsJccmyoMnNA;
				bLiDqnjPNnYOLopzLuEokFheeLbPA.PHygztucztfbgZOllsYgjDURxJlc(P_0.bLiDqnjPNnYOLopzLuEokFheeLbPA);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			bLiDqnjPNnYOLopzLuEokFheeLbPA.qmNKevSUohoJykDtHjyIWVGjUDjy();
			bool[] array = bLiDqnjPNnYOLopzLuEokFheeLbPA.NfFBMuGYzYGMFaGOucyWlaCNekqBb;
			int[] kWONEuNtDNvjJSyyBaQgYeCLNNqj = bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.KWONEuNtDNvjJSyyBaQgYeCLNNqj;
			ZkppAlHZClkZzYUuEhMBzCpjuPGN(array, kWONEuNtDNvjJSyyBaQgYeCLNNqj);
			PcUdaGzpjwQwxPSMqgilJobCtSvB(array, kWONEuNtDNvjJSyyBaQgYeCLNNqj);
			bLiDqnjPNnYOLopzLuEokFheeLbPA.yZrBUfdhWqaXovJDqSfREztkEirjA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (CJLCCvFhUKesSSEwydLrUSNupCxWA != dataUpdater.axisCount || eSSbHBEhQxhqYIpZxpIyRppLRaxrA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < CJLCCvFhUKesSSEwydLrUSNupCxWA; i++)
			{
				dataUpdater.axisValues[i] = PVEEedaluUflovPtlHDTWPFaTUsPA[i];
			}
			for (int j = 0; j < eSSbHBEhQxhqYIpZxpIyRppLRaxrA; j++)
			{
				dataUpdater.buttonValues[j] = nWtyMqsbWhSsLPTIoaIxnmMabnIhA[j];
			}
			if (qHQPaemUHabkdeFIOIsJccmyoMnNA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int CQPsZqBqGTNxSdirWfCSZANiXiIr(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0)
		{
			if (P_0.fIjGatCwgHuAqlhZQGqCedLkEAVsc == fIjGatCwgHuAqlhZQGqCedLkEAVsc)
			{
				return 2;
			}
			if (SalwCmhPSAVhOwpDnZmMbUgwNwDn != P_0.SalwCmhPSAVhOwpDnZmMbUgwNwDn)
			{
				return 0;
			}
			if (cTVROwldghlxQaScAeIkXeQWfUGGA != P_0.cTVROwldghlxQaScAeIkXeQWfUGGA)
			{
				return 0;
			}
			if (YZYeogkZhOVlboQappUNJfPSbxOg != P_0.YZYeogkZhOVlboQappUNJfPSbxOg)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.vCEjRnEevHALmiUbBVieclavfqCLc == vCEjRnEevHALmiUbBVieclavfqCLc)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo vxIaIjClhzTReQtkZnYodMNQBPMPA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			rKIbmhWzECpVmWltprCAoEIzEtCJA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			bRiaEqhnakqWFVgxEAKfQHRXOHGmA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(fIjGatCwgHuAqlhZQGqCedLkEAVsc);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool CsJUOiFwZSoZWFCNGCjeEEsNzCgb()
		{
			try
			{
				bLiDqnjPNnYOLopzLuEokFheeLbPA.lZPXLAuOfXcmlhrkpSCiduvZyHGt.OzqWPydqZnCXeEHouBCuZjgwhLnNA();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void SRMnfTwuRJWofvnagwXeIorErELP()
		{
			try
			{
				if (bLiDqnjPNnYOLopzLuEokFheeLbPA.lZPXLAuOfXcmlhrkpSCiduvZyHGt != null)
				{
					bLiDqnjPNnYOLopzLuEokFheeLbPA.lZPXLAuOfXcmlhrkpSCiduvZyHGt.DnPkULQcHkJOjeTDBFfGVUqFIbFS();
				}
			}
			catch
			{
			}
		}

		private void ZkppAlHZClkZzYUuEhMBzCpjuPGN(bool[] P_0, int[] P_1)
		{
			if (CJLCCvFhUKesSSEwydLrUSNupCxWA <= 0)
			{
				return;
			}
			switch (uIoeHVsdYNKLAvPemcWhpppymLgw.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)uIoeHVsdYNKLAvPemcWhpppymLgw.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						JjWiMUgbRYcLmKicLLeqkvrUXtxdA(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)uIoeHVsdYNKLAvPemcWhpppymLgw.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						JjWiMUgbRYcLmKicLLeqkvrUXtxdA(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void PcUdaGzpjwQwxPSMqgilJobCtSvB(bool[] P_0, int[] P_1)
		{
			if (eSSbHBEhQxhqYIpZxpIyRppLRaxrA <= 0)
			{
				return;
			}
			switch (uIoeHVsdYNKLAvPemcWhpppymLgw.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)uIoeHVsdYNKLAvPemcWhpppymLgw.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						eyKtpSuyDWjSZRYXYPHgaEhOJZus(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)uIoeHVsdYNKLAvPemcWhpppymLgw.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						eyKtpSuyDWjSZRYXYPHgaEhOJZus(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void JjWiMUgbRYcLmKicLLeqkvrUXtxdA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= CJLCCvFhUKesSSEwydLrUSNupCxWA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			PVEEedaluUflovPtlHDTWPFaTUsPA[P_1] = NKfDVNaERBEQnZCYwMFSaSEkhslxB(P_0, P_2, P_3);
			if (!qHQPaemUHabkdeFIOIsJccmyoMnNA && PVEEedaluUflovPtlHDTWPFaTUsPA[P_1] != 0f)
			{
				qHQPaemUHabkdeFIOIsJccmyoMnNA = true;
			}
		}

		private void eyKtpSuyDWjSZRYXYPHgaEhOJZus(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= eSSbHBEhQxhqYIpZxpIyRppLRaxrA)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			nWtyMqsbWhSsLPTIoaIxnmMabnIhA[P_1] = tYraRECxWRzSKABKCnTKEfaPgGmrA(P_0, P_2, P_3);
			if (!qHQPaemUHabkdeFIOIsJccmyoMnNA && nWtyMqsbWhSsLPTIoaIxnmMabnIhA[P_1])
			{
				qHQPaemUHabkdeFIOIsJccmyoMnNA = true;
			}
		}

		private float NKfDVNaERBEQnZCYwMFSaSEkhslxB(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return nBNjuvCnWmFOpBpEbQwEpwPkWDbbb((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= cTVROwldghlxQaScAeIkXeQWfUGGA || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= YZYeogkZhOVlboQappUNJfPSbxOg || sourceHat >= 4)
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
					num2 = DIsXOBpLNmYOJPnlsqpXOnKgFPFgA(num, AxisDirection.Horizontal);
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
					num2 = DIsXOBpLNmYOJPnlsqpXOnKgFPFgA(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && GKQZGtKjPGhGztNEaqNaJQeOTySL(customCalculationSourceData[i], out var item))
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

		private float nBNjuvCnWmFOpBpEbQwEpwPkWDbbb(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.xjHtWDOpOUcaeCUUsdmRddSnaTzv, 
				DirectInputAxis.Y => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.qnmZSHIsDlmsRHPQyiMLLVTuixOA, 
				DirectInputAxis.Z => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.exLpPVKthCDSllvPxwfXFIuonCKR, 
				DirectInputAxis.RotationX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.siXcTGEVopuuDeFUhooAraDRYyQL, 
				DirectInputAxis.RotationY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.IxUfvyWlFEEHnhHEwAGkbJCLvrFx, 
				DirectInputAxis.RotationZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.qTtfedfIIOBEhTqJaAQNztXdHydhA, 
				DirectInputAxis.Slider0 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.SWeLBlDjliGMfACBpfaYYmPEybNuA[0], 
				DirectInputAxis.Slider1 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.SWeLBlDjliGMfACBpfaYYmPEybNuA[1], 
				DirectInputAxis.VelocityX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.PmXqmYGEXguWghorbbWMUGDynaNf, 
				DirectInputAxis.VelocityY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.pcZCqgcoOgnrzEVfeZqhRrEmYPVYA, 
				DirectInputAxis.VelocityZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.BSrzdbighnWidpuHOTwDZGpQSgXW, 
				DirectInputAxis.AngularVelocityX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.GEfafnIJZNDqBdRCfvcrFeziFvJmc, 
				DirectInputAxis.AngularVelocityY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.ZRvhbPnUCaSDnbieCzlPAAPPAmFx, 
				DirectInputAxis.AngularVelocityZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.BTdaHsnvXRsYxdhTpjWIqtdAlElw, 
				DirectInputAxis.VelocitySlider0 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.IlDYyPOWhyWzhyaxEeBnYasmXrkH[0], 
				DirectInputAxis.VelocitySlider1 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.IlDYyPOWhyWzhyaxEeBnYasmXrkH[1], 
				DirectInputAxis.AccelerationX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.TaCTlCnZlgsSDqhgYkbsqhtJIHGO, 
				DirectInputAxis.AccelerationY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.njvXSqiHnHUtElKICUiGDiYTtCkj, 
				DirectInputAxis.AccelerationZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.kgDiZKTNXtMucoQnpHRCDFsAHWeEb, 
				DirectInputAxis.AngularAccelerationX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.ByyRuJskgxNQGJUQJcNoHDOeicsX, 
				DirectInputAxis.AngularAccelerationY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.BSTGPucKxHJcAPoiEPVpMnECEAnv, 
				DirectInputAxis.AngularAccelerationZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.owYlwnuhBLsPkWCEnwcMkfRZFnIJA, 
				DirectInputAxis.AccelerationSlider0 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.wSpTqRBawtdNrbZIIoaUsaqUqNz[0], 
				DirectInputAxis.AccelerationSlider1 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.wSpTqRBawtdNrbZIIoaUsaqUqNz[1], 
				DirectInputAxis.ForceX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.jBxEtLHeptKCKCEoTXDgIgUFViAeB, 
				DirectInputAxis.ForceY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.LYMfSVKQzTZMOjOEToxBfrEimlpvB, 
				DirectInputAxis.ForceZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.AXGWhNDsSGQvcGVYOHTWgsuNEWwu, 
				DirectInputAxis.TorqueX => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.SntbGjIXySHfzbPGBzcgwVniefhVA, 
				DirectInputAxis.TorqueY => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.TZKZCuxUQaGiAceiYNanAJLJhemiA, 
				DirectInputAxis.TorqueZ => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.TNMCwdeyXiMqxtyJnsbsAWLJaIbEA, 
				DirectInputAxis.ForceSlider0 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.NnYFMoOmtYgPlvvUmesfGoWHDCDLA[0], 
				DirectInputAxis.ForceSlider1 => bLiDqnjPNnYOLopzLuEokFheeLbPA.WqeCtqCAPyGmZVJPmPbnARmBUJPxB.NnYFMoOmtYgPlvvUmesfGoWHDCDLA[1], 
				_ => 0f, 
			};
		}

		private bool tYraRECxWRzSKABKCnTKEfaPgGmrA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= cTVROwldghlxQaScAeIkXeQWfUGGA || sourceButton >= 128)
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
				float num = nBNjuvCnWmFOpBpEbQwEpwPkWDbbb((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= YZYeogkZhOVlboQappUNJfPSbxOg || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return uFSDjnAMTWbyMucFStytUNDRgsRx(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (clBFpOrENuoKyJCHDBgZJXJpmkPJA(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (GKQZGtKjPGhGztNEaqNaJQeOTySL(customCalculationSourceData[k], out var num2))
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

		private bool uFSDjnAMTWbyMucFStytUNDRgsRx(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (uIoeHVsdYNKLAvPemcWhpppymLgw.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float DIsXOBpLNmYOJPnlsqpXOnKgFPFgA(int P_0, AxisDirection P_1)
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

		private bool clBFpOrENuoKyJCHDBgZJXJpmkPJA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= cTVROwldghlxQaScAeIkXeQWfUGGA || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool GKQZGtKjPGhGztNEaqNaJQeOTySL(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = nBNjuvCnWmFOpBpEbQwEpwPkWDbbb((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType lxLUaeyEwFFBxfHlmpxzqULOOYorA(nCgvUVEDrMuJWQeLQpzrlBKMvXND P_0)
		{
			return P_0 switch
			{
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Keyboard => ControlDeviceType.Keyboard, 
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Joystick => ControlDeviceType.Joystick, 
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Gamepad => ControlDeviceType.Gamepad, 
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Mouse => ControlDeviceType.Mouse, 
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Flight => ControlDeviceType.Flight, 
				nCgvUVEDrMuJWQeLQpzrlBKMvXND.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void kMoyTlBtpMKezYwyMNAriamwlzti()
		{
			uIoeHVsdYNKLAvPemcWhpppymLgw = XRMJjcnhFEWSIseJqixIEsyczNOnA(vxIaIjClhzTReQtkZnYodMNQBPMPA());
			if (uIoeHVsdYNKLAvPemcWhpppymLgw == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			CJLCCvFhUKesSSEwydLrUSNupCxWA = uIoeHVsdYNKLAvPemcWhpppymLgw.axisCount;
			eSSbHBEhQxhqYIpZxpIyRppLRaxrA = uIoeHVsdYNKLAvPemcWhpppymLgw.buttonCount;
		}

		private string kAzocDbjstRLTOgdkQCnsjEPPbAu()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.DirectInput}{((cjfAIiOxGHrPzmjTnlphtwnmhKYj && !string.IsNullOrEmpty(KYctGCHGLXyidxEaqpmlCueCwYDf)) ? KYctGCHGLXyidxEaqpmlCueCwYDf : JePvkTeYhPabLqEeEAEwAeuKtpGQ)}{GeuWWYSZESIpexvVGmqZfSRPvVBi}{fFaCsHrgPAfioCVHsmmTxDalGSXSA}");
		}

		private void rKIbmhWzECpVmWltprCAoEIzEtCJA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = lxLUaeyEwFFBxfHlmpxzqULOOYorA(rgFTFQxxDiooZShnRKUWSHGFmfLs);
			P_0.hardwareIdentifier = kAzocDbjstRLTOgdkQCnsjEPPbAu();
			P_0.hardwareAxisCount = SalwCmhPSAVhOwpDnZmMbUgwNwDn;
			P_0.hardwareButtonCount = cTVROwldghlxQaScAeIkXeQWfUGGA;
			P_0.hardwareHatCount = YZYeogkZhOVlboQappUNJfPSbxOg;
			P_0.hw_productName = JePvkTeYhPabLqEeEAEwAeuKtpGQ;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = GeuWWYSZESIpexvVGmqZfSRPvVBi;
			P_0.hw_pidVid = new PidVid(fFaCsHrgPAfioCVHsmmTxDalGSXSA);
			P_0.hw_isBluetoothDevice = cjfAIiOxGHrPzmjTnlphtwnmhKYj;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(KYctGCHGLXyidxEaqpmlCueCwYDf)) ? KYctGCHGLXyidxEaqpmlCueCwYDf : string.Empty);
			P_0.definitionMatchTag = DmtjoYRQnWRYmJVRiaDzujiwQoJj;
		}

		private void bRiaEqhnakqWFVgxEAKfQHRXOHGmA(BridgedController P_0)
		{
			rKIbmhWzECpVmWltprCAoEIzEtCJA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = uIoeHVsdYNKLAvPemcWhpppymLgw.ToGameHardwareControllerMap();
			P_0.instanceName = LUEzHOdPYwBEukxtpMAJuBNhAYKy;
			P_0.productName = JePvkTeYhPabLqEeEAEwAeuKtpGQ;
			P_0.isXInputDevice = EcZnpaWAsuTjwZHoQBGOvbBkkMck;
			P_0.axisCount = CJLCCvFhUKesSSEwydLrUSNupCxWA;
			P_0.buttonCount = eSSbHBEhQxhqYIpZxpIyRppLRaxrA;
			P_0.unknownControllerHats = XjKeWDQiQpEeWARlrxPYONVGSDBRA();
			P_0.controllerTypeGuid = agcQnVHWKnURDOabhiuRcSMXEIxEb;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private UnknownControllerHat[] XjKeWDQiQpEeWARlrxPYONVGSDBRA()
		{
			if (!ykIwMUBsjgffPAFGHiKkkIxdDPyR)
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

		public void ogrRGoilbpJranQxpKtAkPpTTkaC()
		{
			hkjWeMgcxwBwqdVaKvTuSJaSxAhY(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void gBCAYHljPxMirqVXMhkCIdAzHdegA()
		{
			try
			{
				hkjWeMgcxwBwqdVaKvTuSJaSxAhY(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void hkjWeMgcxwBwqdVaKvTuSJaSxAhY(bool P_0)
		{
			if (!iICPDJVpTDVNBJcHnsfrzzbdCOMV)
			{
				if (P_0 && bLiDqnjPNnYOLopzLuEokFheeLbPA != null)
				{
					bLiDqnjPNnYOLopzLuEokFheeLbPA.Dispose();
				}
				iICPDJVpTDVNBJcHnsfrzzbdCOMV = true;
			}
		}

		public static int UrqLbAIhfgglsxuXspQdIfffNkEU(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, bRGrQSsmGYcQvEIdClixFNgYhPLEA P_1)
		{
			if (P_0.olFOwsVQMNkRnzVEvUfgyEpHDPvY < P_1.olFOwsVQMNkRnzVEvUfgyEpHDPvY)
			{
				return -1;
			}
			if (P_0.olFOwsVQMNkRnzVEvUfgyEpHDPvY > P_1.olFOwsVQMNkRnzVEvUfgyEpHDPvY)
			{
				return 1;
			}
			return 0;
		}

		public static int oTYIONGTWcsnrGXMnwpCtqySozbF(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, bRGrQSsmGYcQvEIdClixFNgYhPLEA P_1)
		{
			if (P_0.wpbxZYMKouNzTMsUCPGcvoUocYAv < P_1.wpbxZYMKouNzTMsUCPGcvoUocYAv)
			{
				return -1;
			}
			if (P_0.wpbxZYMKouNzTMsUCPGcvoUocYAv > P_1.wpbxZYMKouNzTMsUCPGcvoUocYAv)
			{
				return 1;
			}
			return 0;
		}
	}

	private class blJFQAJZVzzuBtgglibdVWVaJgpX : IDisposable
	{
		public class ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA
		{
			public float xjHtWDOpOUcaeCUUsdmRddSnaTzv;

			public float qnmZSHIsDlmsRHPQyiMLLVTuixOA;

			public float exLpPVKthCDSllvPxwfXFIuonCKR;

			public float siXcTGEVopuuDeFUhooAraDRYyQL;

			public float IxUfvyWlFEEHnhHEwAGkbJCLvrFx;

			public float qTtfedfIIOBEhTqJaAQNztXdHydhA;

			public float[] SWeLBlDjliGMfACBpfaYYmPEybNuA;

			public readonly int[] KWONEuNtDNvjJSyyBaQgYeCLNNqj;

			public readonly bool[] nuSVBnnowHwSBoNwXopDMqQDsYgh;

			public float PmXqmYGEXguWghorbbWMUGDynaNf;

			public float pcZCqgcoOgnrzEVfeZqhRrEmYPVYA;

			public float BSrzdbighnWidpuHOTwDZGpQSgXW;

			public float GEfafnIJZNDqBdRCfvcrFeziFvJmc;

			public float ZRvhbPnUCaSDnbieCzlPAAPPAmFx;

			public float BTdaHsnvXRsYxdhTpjWIqtdAlElw;

			public readonly float[] IlDYyPOWhyWzhyaxEeBnYasmXrkH;

			public float TaCTlCnZlgsSDqhgYkbsqhtJIHGO;

			public float njvXSqiHnHUtElKICUiGDiYTtCkj;

			public float kgDiZKTNXtMucoQnpHRCDFsAHWeEb;

			public float ByyRuJskgxNQGJUQJcNoHDOeicsX;

			public float BSTGPucKxHJcAPoiEPVpMnECEAnv;

			public float owYlwnuhBLsPkWCEnwcMkfRZFnIJA;

			public readonly float[] wSpTqRBawtdNrbZIIoaUsaqUqNz;

			public float jBxEtLHeptKCKCEoTXDgIgUFViAeB;

			public float LYMfSVKQzTZMOjOEToxBfrEimlpvB;

			public float AXGWhNDsSGQvcGVYOHTWgsuNEWwu;

			public float SntbGjIXySHfzbPGBzcgwVniefhVA;

			public float TZKZCuxUQaGiAceiYNanAJLJhemiA;

			public float TNMCwdeyXiMqxtyJnsbsAWLJaIbEA;

			public readonly float[] NnYFMoOmtYgPlvvUmesfGoWHDCDLA;

			public ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA()
			{
				SWeLBlDjliGMfACBpfaYYmPEybNuA = new float[2];
				KWONEuNtDNvjJSyyBaQgYeCLNNqj = new int[4];
				nuSVBnnowHwSBoNwXopDMqQDsYgh = new bool[128];
				IlDYyPOWhyWzhyaxEeBnYasmXrkH = new float[2];
				wSpTqRBawtdNrbZIIoaUsaqUqNz = new float[2];
				NnYFMoOmtYgPlvvUmesfGoWHDCDLA = new float[2];
			}

			public void vZjMYlLVCqRywIdDpgvGHBwCjNCLA()
			{
				xjHtWDOpOUcaeCUUsdmRddSnaTzv = 0f;
				qnmZSHIsDlmsRHPQyiMLLVTuixOA = 0f;
				exLpPVKthCDSllvPxwfXFIuonCKR = 0f;
				siXcTGEVopuuDeFUhooAraDRYyQL = 0f;
				IxUfvyWlFEEHnhHEwAGkbJCLvrFx = 0f;
				qTtfedfIIOBEhTqJaAQNztXdHydhA = 0f;
				for (int i = 0; i < SWeLBlDjliGMfACBpfaYYmPEybNuA.Length; i++)
				{
					SWeLBlDjliGMfACBpfaYYmPEybNuA[i] = 0f;
				}
				for (int j = 0; j < KWONEuNtDNvjJSyyBaQgYeCLNNqj.Length; j++)
				{
					KWONEuNtDNvjJSyyBaQgYeCLNNqj[j] = 0;
				}
				for (int k = 0; k < nuSVBnnowHwSBoNwXopDMqQDsYgh.Length; k++)
				{
					nuSVBnnowHwSBoNwXopDMqQDsYgh[k] = false;
				}
				PmXqmYGEXguWghorbbWMUGDynaNf = 0f;
				pcZCqgcoOgnrzEVfeZqhRrEmYPVYA = 0f;
				BSrzdbighnWidpuHOTwDZGpQSgXW = 0f;
				GEfafnIJZNDqBdRCfvcrFeziFvJmc = 0f;
				ZRvhbPnUCaSDnbieCzlPAAPPAmFx = 0f;
				BTdaHsnvXRsYxdhTpjWIqtdAlElw = 0f;
				for (int l = 0; l < IlDYyPOWhyWzhyaxEeBnYasmXrkH.Length; l++)
				{
					IlDYyPOWhyWzhyaxEeBnYasmXrkH[l] = 0f;
				}
				TaCTlCnZlgsSDqhgYkbsqhtJIHGO = 0f;
				njvXSqiHnHUtElKICUiGDiYTtCkj = 0f;
				kgDiZKTNXtMucoQnpHRCDFsAHWeEb = 0f;
				ByyRuJskgxNQGJUQJcNoHDOeicsX = 0f;
				BSTGPucKxHJcAPoiEPVpMnECEAnv = 0f;
				owYlwnuhBLsPkWCEnwcMkfRZFnIJA = 0f;
				for (int m = 0; m < wSpTqRBawtdNrbZIIoaUsaqUqNz.Length; m++)
				{
					wSpTqRBawtdNrbZIIoaUsaqUqNz[m] = 0f;
				}
				jBxEtLHeptKCKCEoTXDgIgUFViAeB = 0f;
				LYMfSVKQzTZMOjOEToxBfrEimlpvB = 0f;
				AXGWhNDsSGQvcGVYOHTWgsuNEWwu = 0f;
				SntbGjIXySHfzbPGBzcgwVniefhVA = 0f;
				TZKZCuxUQaGiAceiYNanAJLJhemiA = 0f;
				TNMCwdeyXiMqxtyJnsbsAWLJaIbEA = 0f;
				for (int n = 0; n < NnYFMoOmtYgPlvvUmesfGoWHDCDLA.Length; n++)
				{
					NnYFMoOmtYgPlvvUmesfGoWHDCDLA[n] = 0f;
				}
			}

			public void ZermbVKbJbMBTBgoiFTuulNnIqKu(ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA P_0)
			{
				xjHtWDOpOUcaeCUUsdmRddSnaTzv = P_0.xjHtWDOpOUcaeCUUsdmRddSnaTzv;
				qnmZSHIsDlmsRHPQyiMLLVTuixOA = P_0.qnmZSHIsDlmsRHPQyiMLLVTuixOA;
				exLpPVKthCDSllvPxwfXFIuonCKR = P_0.exLpPVKthCDSllvPxwfXFIuonCKR;
				siXcTGEVopuuDeFUhooAraDRYyQL = P_0.siXcTGEVopuuDeFUhooAraDRYyQL;
				IxUfvyWlFEEHnhHEwAGkbJCLvrFx = P_0.IxUfvyWlFEEHnhHEwAGkbJCLvrFx;
				qTtfedfIIOBEhTqJaAQNztXdHydhA = P_0.qTtfedfIIOBEhTqJaAQNztXdHydhA;
				for (int i = 0; i < SWeLBlDjliGMfACBpfaYYmPEybNuA.Length; i++)
				{
					SWeLBlDjliGMfACBpfaYYmPEybNuA[i] = P_0.SWeLBlDjliGMfACBpfaYYmPEybNuA[i];
				}
				for (int j = 0; j < KWONEuNtDNvjJSyyBaQgYeCLNNqj.Length; j++)
				{
					KWONEuNtDNvjJSyyBaQgYeCLNNqj[j] = P_0.KWONEuNtDNvjJSyyBaQgYeCLNNqj[j];
				}
				for (int k = 0; k < nuSVBnnowHwSBoNwXopDMqQDsYgh.Length; k++)
				{
					nuSVBnnowHwSBoNwXopDMqQDsYgh[k] = P_0.nuSVBnnowHwSBoNwXopDMqQDsYgh[k];
				}
				PmXqmYGEXguWghorbbWMUGDynaNf = P_0.PmXqmYGEXguWghorbbWMUGDynaNf;
				pcZCqgcoOgnrzEVfeZqhRrEmYPVYA = P_0.pcZCqgcoOgnrzEVfeZqhRrEmYPVYA;
				BSrzdbighnWidpuHOTwDZGpQSgXW = P_0.BSrzdbighnWidpuHOTwDZGpQSgXW;
				GEfafnIJZNDqBdRCfvcrFeziFvJmc = P_0.GEfafnIJZNDqBdRCfvcrFeziFvJmc;
				ZRvhbPnUCaSDnbieCzlPAAPPAmFx = P_0.ZRvhbPnUCaSDnbieCzlPAAPPAmFx;
				BTdaHsnvXRsYxdhTpjWIqtdAlElw = P_0.BTdaHsnvXRsYxdhTpjWIqtdAlElw;
				for (int l = 0; l < IlDYyPOWhyWzhyaxEeBnYasmXrkH.Length; l++)
				{
					IlDYyPOWhyWzhyaxEeBnYasmXrkH[l] = P_0.IlDYyPOWhyWzhyaxEeBnYasmXrkH[l];
				}
				TaCTlCnZlgsSDqhgYkbsqhtJIHGO = P_0.TaCTlCnZlgsSDqhgYkbsqhtJIHGO;
				njvXSqiHnHUtElKICUiGDiYTtCkj = P_0.njvXSqiHnHUtElKICUiGDiYTtCkj;
				kgDiZKTNXtMucoQnpHRCDFsAHWeEb = P_0.kgDiZKTNXtMucoQnpHRCDFsAHWeEb;
				ByyRuJskgxNQGJUQJcNoHDOeicsX = P_0.ByyRuJskgxNQGJUQJcNoHDOeicsX;
				BSTGPucKxHJcAPoiEPVpMnECEAnv = P_0.BSTGPucKxHJcAPoiEPVpMnECEAnv;
				owYlwnuhBLsPkWCEnwcMkfRZFnIJA = P_0.owYlwnuhBLsPkWCEnwcMkfRZFnIJA;
				for (int m = 0; m < wSpTqRBawtdNrbZIIoaUsaqUqNz.Length; m++)
				{
					wSpTqRBawtdNrbZIIoaUsaqUqNz[m] = P_0.wSpTqRBawtdNrbZIIoaUsaqUqNz[m];
				}
				jBxEtLHeptKCKCEoTXDgIgUFViAeB = P_0.jBxEtLHeptKCKCEoTXDgIgUFViAeB;
				LYMfSVKQzTZMOjOEToxBfrEimlpvB = P_0.LYMfSVKQzTZMOjOEToxBfrEimlpvB;
				AXGWhNDsSGQvcGVYOHTWgsuNEWwu = P_0.AXGWhNDsSGQvcGVYOHTWgsuNEWwu;
				SntbGjIXySHfzbPGBzcgwVniefhVA = P_0.SntbGjIXySHfzbPGBzcgwVniefhVA;
				TZKZCuxUQaGiAceiYNanAJLJhemiA = P_0.TZKZCuxUQaGiAceiYNanAJLJhemiA;
				TNMCwdeyXiMqxtyJnsbsAWLJaIbEA = P_0.TNMCwdeyXiMqxtyJnsbsAWLJaIbEA;
				for (int n = 0; n < NnYFMoOmtYgPlvvUmesfGoWHDCDLA.Length; n++)
				{
					NnYFMoOmtYgPlvvUmesfGoWHDCDLA[n] = P_0.NnYFMoOmtYgPlvvUmesfGoWHDCDLA[n];
				}
			}

			public unsafe void YiarfWRmZHbMEgwZwtWdbvbWOrkBA(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						nuSVBnnowHwSBoNwXopDMqQDsYgh[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					wSpTqRBawtdNrbZIIoaUsaqUqNz[k] = *ptr;
					ptr++;
				}
				TaCTlCnZlgsSDqhgYkbsqhtJIHGO = *ptr;
				ptr++;
				njvXSqiHnHUtElKICUiGDiYTtCkj = *ptr;
				ptr++;
				kgDiZKTNXtMucoQnpHRCDFsAHWeEb = *ptr;
				ptr++;
				ByyRuJskgxNQGJUQJcNoHDOeicsX = *ptr;
				ptr++;
				BSTGPucKxHJcAPoiEPVpMnECEAnv = *ptr;
				ptr++;
				owYlwnuhBLsPkWCEnwcMkfRZFnIJA = *ptr;
				ptr++;
				GEfafnIJZNDqBdRCfvcrFeziFvJmc = *ptr;
				ptr++;
				ZRvhbPnUCaSDnbieCzlPAAPPAmFx = *ptr;
				ptr++;
				BTdaHsnvXRsYxdhTpjWIqtdAlElw = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					NnYFMoOmtYgPlvvUmesfGoWHDCDLA[l] = *ptr;
					ptr++;
				}
				jBxEtLHeptKCKCEoTXDgIgUFViAeB = *ptr;
				ptr++;
				LYMfSVKQzTZMOjOEToxBfrEimlpvB = *ptr;
				ptr++;
				AXGWhNDsSGQvcGVYOHTWgsuNEWwu = *ptr;
				ptr++;
				siXcTGEVopuuDeFUhooAraDRYyQL = *ptr;
				ptr++;
				IxUfvyWlFEEHnhHEwAGkbJCLvrFx = *ptr;
				ptr++;
				qTtfedfIIOBEhTqJaAQNztXdHydhA = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					SWeLBlDjliGMfACBpfaYYmPEybNuA[m] = *ptr;
					ptr++;
				}
				SntbGjIXySHfzbPGBzcgwVniefhVA = *ptr;
				ptr++;
				TZKZCuxUQaGiAceiYNanAJLJhemiA = *ptr;
				ptr++;
				TNMCwdeyXiMqxtyJnsbsAWLJaIbEA = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					IlDYyPOWhyWzhyaxEeBnYasmXrkH[n] = *ptr;
					ptr++;
				}
				PmXqmYGEXguWghorbbWMUGDynaNf = *ptr;
				ptr++;
				pcZCqgcoOgnrzEVfeZqhRrEmYPVYA = *ptr;
				ptr++;
				BSrzdbighnWidpuHOTwDZGpQSgXW = *ptr;
				ptr++;
				xjHtWDOpOUcaeCUUsdmRddSnaTzv = *ptr;
				ptr++;
				qnmZSHIsDlmsRHPQyiMLLVTuixOA = *ptr;
				ptr++;
				exLpPVKthCDSllvPxwfXFIuonCKR = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					KWONEuNtDNvjJSyyBaQgYeCLNNqj[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void fxPnQwnMnXJOkxZKRFJlmbooyvaB(hOLISXUwDrSOMvpaDjmGamYaKHaDA P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.rCHURyRdAoajapNUTyZqlWyDfvjr;
				int[] array2 = P_0.COmBpFHGPXnWfRBCvUNRAKryoWpEA;
				int[] array3 = P_0.JpAeSQrMmaGUXIxPrEopiXoIdjXw;
				int[] array4 = P_0.vjxbwfESKzhjginidLUGakiaWMNPc;
				int[] array5 = P_0.wUDSrnSPhOTZMnhYZHwBuycDpKlU;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.BabgiQCGMFCYDBtnZlpzwktASgfoA[i])
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
					*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(array2[j]);
					ptr++;
				}
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.uQTFfyFfSlfIByTwDPkCWozmwcGRA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.pXMkCZTiUEuiEegDZDEoFVYUpSFRA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.ffTmPAXXGzguywpKjCekFRTqRQsl);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.qBlbBPaAwlscGTqAUQCDsKagsACU);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.peEIRXSSBVcxvHHTnhxAeNMcfnaY);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.lNofEYDYZLdVbLDxeGfseyvexPwlB);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.wHdTULrgtMuvDSbwsgsmCugAkAeP);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.lcgarTHSBjtWUmvgEVjtSzrZsujU);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.ibfxAWfIrRanqTdyqtTqLUbtxhXB);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(array3[k]);
					ptr++;
				}
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.KCPnxpqQEkjzObfGNaxvYugOiRaT);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.eyWecBSSojXCiSRaPqBtLRtIOzlR);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.UdkEZUHSpdiwOssyscQwnYtlGRSw);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.FdoMbzNktCfZsAkCittVFdoDSrvtA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.QDRcqrPbmWnvHhHntgIYYwzGBCLe);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(array4[l]);
					ptr++;
				}
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.GVRauKxSrsPPYlMZBCjnCBBJwowW);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.OMDDJIICIyneIUjyGgzQeETJPuueB);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(array5[m]);
					ptr++;
				}
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.ACEXUEIhvyDhoWzTfgiYwyOJJWPd);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.egepiWoENOPlvjsBjQcUTQThQtXy);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.laEaAyWbbFpPsHrsqLXCVfyRNtOA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.zfVFwJCmHgMNitmEtBSjuOCUhszOA);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.KiAlpiCKWFgyjjowDNDECiYqbkwy);
				ptr++;
				*ptr = cmIYiRoWTPtOJlmvHHIDDmTELEOF(P_0.ZQSJcYiQMGpijpZgyqJCHBKYVirL);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private readonly int WfNiemENqFGnYRHHjiMnOblsaQpI;

		private readonly ButtonLoopSet dJcppxexHKneUVslTWAZSwHGUESX;

		private readonly DualThreadLowLevelInputEventQueue FBzaGfqWQYdLAHFNvxgwUWawLADL;

		private BOzfEjYambHvqBVXOgCNtPNjpHuDb NQuAjEEZuTmvwocaKldPefBbSkIBc;

		private readonly hOLISXUwDrSOMvpaDjmGamYaKHaDA sYRJhSegnYsXjLNHGwCCopGZDhTO;

		private readonly hOLISXUwDrSOMvpaDjmGamYaKHaDA NuJwNjIqlIyUOpaoisVfsaUaVcRx;

		private readonly object iBcmUEbdYcCBdeCRtVrluCQmrmhFA;

		private bool WNvNTRHEeaDhZcDzCWblFdPwWaub;

		public readonly TVmjOvMzQEcAxIasZNmofQFDPCSt lZPXLAuOfXcmlhrkpSCiduvZyHGt;

		private readonly ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA CXnExiysPmqZAohlzZJicFjDdDqO;

		private bool thdGWrRlumSnQEFwYgTvYuwmrjWI;

		public bool[] NfFBMuGYzYGMFaGOucyWlaCNekqBb => dJcppxexHKneUVslTWAZSwHGUESX.Current.effectiveValue;

		public ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA WqeCtqCAPyGmZVJPmPbnARmBUJPxB => CXnExiysPmqZAohlzZJicFjDdDqO;

		public blJFQAJZVzzuBtgglibdVWVaJgpX(TVmjOvMzQEcAxIasZNmofQFDPCSt P_0, UpdateLoopSetting P_1)
		{
			lZPXLAuOfXcmlhrkpSCiduvZyHGt = P_0;
			WfNiemENqFGnYRHHjiMnOblsaQpI = P_0.qYRCFXXsnorCIBmlEHrWlxCTPAuU.xNlbavAaABzUlIRMZXWbTUwuNbkWA;
			dJcppxexHKneUVslTWAZSwHGUESX = new ButtonLoopSet(P_1, WfNiemENqFGnYRHHjiMnOblsaQpI);
			FBzaGfqWQYdLAHFNvxgwUWawLADL = new DualThreadLowLevelInputEventQueue((int)((float)TOahviIJXSwhIkcLgNJHhAnDExwT.msYvraZKixRWczNsdUKcrerceHvr * 0.25f), 128, 32, 2);
			CXnExiysPmqZAohlzZJicFjDdDqO = new ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA();
			sYRJhSegnYsXjLNHGwCCopGZDhTO = new hOLISXUwDrSOMvpaDjmGamYaKHaDA();
			NuJwNjIqlIyUOpaoisVfsaUaVcRx = new hOLISXUwDrSOMvpaDjmGamYaKHaDA();
			iBcmUEbdYcCBdeCRtVrluCQmrmhFA = new object();
			if (TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH != null)
			{
				TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH.ThreadUpdateEvent += VlqLsHmuCPAfcWIasYcwlkkExIQi;
			}
		}

		public void qmNKevSUohoJykDtHjyIWVGjUDjy()
		{
			dJcppxexHKneUVslTWAZSwHGUESX.SetUpdateLoop(ReInput.currentUpdateLoop);
			sDSaZrfFlIVbfpQDgnjZeuNhlrHdA();
		}

		public void yZrBUfdhWqaXovJDqSfREztkEirjA()
		{
			dJcppxexHKneUVslTWAZSwHGUESX.Current.ClearWasTrueThisFrame();
		}

		public void eZsQOmCRBPUbwSgBJHIqMExAeIxkA()
		{
			GRWpmwWRuQcvDoFzgEOoUyAAQbPC();
			WNvNTRHEeaDhZcDzCWblFdPwWaub = true;
		}

		public void kONhfWUrTJqcCLHaaAtWgBvmIOsvA()
		{
			WNvNTRHEeaDhZcDzCWblFdPwWaub = false;
			GRWpmwWRuQcvDoFzgEOoUyAAQbPC();
		}

		public void PHygztucztfbgZOllsYgjDURxJlc(blJFQAJZVzzuBtgglibdVWVaJgpX P_0)
		{
			if (P_0 == null || P_0 == this || P_0.WfNiemENqFGnYRHHjiMnOblsaQpI != WfNiemENqFGnYRHHjiMnOblsaQpI)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (iBcmUEbdYcCBdeCRtVrluCQmrmhFA)
			{
				lock (P_0.iBcmUEbdYcCBdeCRtVrluCQmrmhFA)
				{
					dJcppxexHKneUVslTWAZSwHGUESX.Import(P_0.dJcppxexHKneUVslTWAZSwHGUESX);
					CXnExiysPmqZAohlzZJicFjDdDqO.ZermbVKbJbMBTBgoiFTuulNnIqKu(P_0.CXnExiysPmqZAohlzZJicFjDdDqO);
					sYRJhSegnYsXjLNHGwCCopGZDhTO.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(P_0.sYRJhSegnYsXjLNHGwCCopGZDhTO);
					NuJwNjIqlIyUOpaoisVfsaUaVcRx.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(P_0.NuJwNjIqlIyUOpaoisVfsaUaVcRx);
					FBzaGfqWQYdLAHFNvxgwUWawLADL.ImportAll(P_0.FBzaGfqWQYdLAHFNvxgwUWawLADL);
					NQuAjEEZuTmvwocaKldPefBbSkIBc = BOzfEjYambHvqBVXOgCNtPNjpHuDb.jXNwMLvjlTsxsBTqhMoDIJiveTTK(P_0.NQuAjEEZuTmvwocaKldPefBbSkIBc, sYRJhSegnYsXjLNHGwCCopGZDhTO);
					WNvNTRHEeaDhZcDzCWblFdPwWaub = P_0.WNvNTRHEeaDhZcDzCWblFdPwWaub;
				}
			}
		}

		public void atbREJmizQWJZHjvwzjxKojhWBWf(int P_0, int P_1, int P_2, float P_3)
		{
			lock (iBcmUEbdYcCBdeCRtVrluCQmrmhFA)
			{
				NQuAjEEZuTmvwocaKldPefBbSkIBc = new BOzfEjYambHvqBVXOgCNtPNjpHuDb(sYRJhSegnYsXjLNHGwCCopGZDhTO, P_0, P_1, P_2, P_3);
			}
		}

		private void VlqLsHmuCPAfcWIasYcwlkkExIQi()
		{
			if (!WNvNTRHEeaDhZcDzCWblFdPwWaub)
			{
				return;
			}
			double realTime;
			try
			{
				lZPXLAuOfXcmlhrkpSCiduvZyHGt.DwxLMppFmgahDoHtkOqSqDGJeGvG(sYRJhSegnYsXjLNHGwCCopGZDhTO);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (iBcmUEbdYcCBdeCRtVrluCQmrmhFA)
			{
				if (NQuAjEEZuTmvwocaKldPefBbSkIBc != null)
				{
					NQuAjEEZuTmvwocaKldPefBbSkIBc.QrJtMuQiNXlGWzjAAXNlizlGvlLr(realTime);
				}
				if (!sYRJhSegnYsXjLNHGwCCopGZDhTO.zzhvAQFFfJndbkogDwLUtDmLMfjf(NuJwNjIqlIyUOpaoisVfsaUaVcRx))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = FBzaGfqWQYdLAHFNvxgwUWawLADL.T_CreateEvent())
					{
						ZCkGOIiPHAnNEYWRlKkrwAQWTrIdA.fxPnQwnMnXJOkxZKRFJlmbooyvaB(sYRJhSegnYsXjLNHGwCCopGZDhTO, realTime, newEventWrapper.Event);
					}
					NuJwNjIqlIyUOpaoisVfsaUaVcRx.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(sYRJhSegnYsXjLNHGwCCopGZDhTO);
				}
			}
		}

		private void sDSaZrfFlIVbfpQDgnjZeuNhlrHdA()
		{
			while (FBzaGfqWQYdLAHFNvxgwUWawLADL.ProcessNewEvents())
			{
				CXnExiysPmqZAohlzZJicFjDdDqO.YiarfWRmZHbMEgwZwtWdbvbWOrkBA(ref FBzaGfqWQYdLAHFNvxgwUWawLADL.currentEvent);
				for (int i = 0; i < WfNiemENqFGnYRHHjiMnOblsaQpI; i++)
				{
					dJcppxexHKneUVslTWAZSwHGUESX.SetValue(i, CXnExiysPmqZAohlzZJicFjDdDqO.nuSVBnnowHwSBoNwXopDMqQDsYgh[i], FBzaGfqWQYdLAHFNvxgwUWawLADL.currentEvent.GetTimestamp());
				}
			}
		}

		private void GRWpmwWRuQcvDoFzgEOoUyAAQbPC()
		{
			CXnExiysPmqZAohlzZJicFjDdDqO.vZjMYlLVCqRywIdDpgvGHBwCjNCLA();
			lock (iBcmUEbdYcCBdeCRtVrluCQmrmhFA)
			{
				sYRJhSegnYsXjLNHGwCCopGZDhTO.WApNZpEwbLmtQdsxhJwTQLvkHgWc();
				NuJwNjIqlIyUOpaoisVfsaUaVcRx.WApNZpEwbLmtQdsxhJwTQLvkHgWc();
				FBzaGfqWQYdLAHFNvxgwUWawLADL.Clear();
			}
			dJcppxexHKneUVslTWAZSwHGUESX.Clear();
		}

		public void Dispose()
		{
			bQMSVXXkfrhvuDPGXYWmeNacMUxfA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void pFUdGCAFrsbpbIzHmiwPhDAMNMpX()
		{
			try
			{
				bQMSVXXkfrhvuDPGXYWmeNacMUxfA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void bQMSVXXkfrhvuDPGXYWmeNacMUxfA(bool P_0)
		{
			if (!thdGWrRlumSnQEFwYgTvYuwmrjWI)
			{
				if (P_0)
				{
					kONhfWUrTJqcCLHaaAtWgBvmIOsvA();
					FBzaGfqWQYdLAHFNvxgwUWawLADL.Dispose();
				}
				if (TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH != null)
				{
					TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH.ThreadUpdateEvent -= VlqLsHmuCPAfcWIasYcwlkkExIQi;
				}
				thdGWrRlumSnQEFwYgTvYuwmrjWI = true;
			}
		}

		private static float cmIYiRoWTPtOJlmvHHIDDmTELEOF(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class BOzfEjYambHvqBVXOgCNtPNjpHuDb
	{
		private hOLISXUwDrSOMvpaDjmGamYaKHaDA hsdwjEUPBKDNUBpzohnDwvpKrWAGA;

		private zpfeBLaHigqHrEhhhBivuPOFbEqR FMNLEoHpjJtKKfJrMvHVSJmQqopC;

		private int dYyAehnkeMTgOOzLkiMrFdGavDZI;

		private int LMDIsMBEYxfhzbeHgKfJVqGmnfeD;

		private int KHYNOPcwOMfIlZUfmUcHOOrcrkkI;

		private float JAUxpTjJqaVwnMLoQDDbqUaOYjeL;

		public static BOzfEjYambHvqBVXOgCNtPNjpHuDb jXNwMLvjlTsxsBTqhMoDIJiveTTK(BOzfEjYambHvqBVXOgCNtPNjpHuDb P_0, hOLISXUwDrSOMvpaDjmGamYaKHaDA P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new BOzfEjYambHvqBVXOgCNtPNjpHuDb(P_0, P_1);
		}

		public BOzfEjYambHvqBVXOgCNtPNjpHuDb(hOLISXUwDrSOMvpaDjmGamYaKHaDA P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			FMNLEoHpjJtKKfJrMvHVSJmQqopC = new zpfeBLaHigqHrEhhhBivuPOFbEqR(P_0);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA = new hOLISXUwDrSOMvpaDjmGamYaKHaDA();
		}

		private BOzfEjYambHvqBVXOgCNtPNjpHuDb(BOzfEjYambHvqBVXOgCNtPNjpHuDb P_0, hOLISXUwDrSOMvpaDjmGamYaKHaDA P_1)
			: this(P_1, P_0.dYyAehnkeMTgOOzLkiMrFdGavDZI, P_0.LMDIsMBEYxfhzbeHgKfJVqGmnfeD, P_0.KHYNOPcwOMfIlZUfmUcHOOrcrkkI, P_0.JAUxpTjJqaVwnMLoQDDbqUaOYjeL)
		{
			VeODWUnONPBbPILuyFxTffHrsUWh(P_0);
		}

		private BOzfEjYambHvqBVXOgCNtPNjpHuDb(int P_0, int P_1, int P_2, float P_3)
		{
			dYyAehnkeMTgOOzLkiMrFdGavDZI = P_0;
			LMDIsMBEYxfhzbeHgKfJVqGmnfeD = P_1;
			KHYNOPcwOMfIlZUfmUcHOOrcrkkI = P_2;
			JAUxpTjJqaVwnMLoQDDbqUaOYjeL = P_3;
		}

		public void QrJtMuQiNXlGWzjAAXNlizlGvlLr(double P_0)
		{
			FMNLEoHpjJtKKfJrMvHVSJmQqopC.VdyaYMOQaEcBvlqClTMVbABBfPQO(P_0);
			if (!FMNLEoHpjJtKKfJrMvHVSJmQqopC.LLcWkzzfQUYSZfIFXvQMsKjdXWhU)
			{
				if (P_0 >= FMNLEoHpjJtKKfJrMvHVSJmQqopC.IbwEUDamUfjVIVxjktuVsJONgbExA + (double)JAUxpTjJqaVwnMLoQDDbqUaOYjeL)
				{
					hsdwjEUPBKDNUBpzohnDwvpKrWAGA.WApNZpEwbLmtQdsxhJwTQLvkHgWc();
				}
				return;
			}
			hOLISXUwDrSOMvpaDjmGamYaKHaDA hOLISXUwDrSOMvpaDjmGamYaKHaDA2 = FMNLEoHpjJtKKfJrMvHVSJmQqopC.kMNFLeAvJwDZTjnWfFchynjoRnKbA;
			hOLISXUwDrSOMvpaDjmGamYaKHaDA hOLISXUwDrSOMvpaDjmGamYaKHaDA3 = FMNLEoHpjJtKKfJrMvHVSJmQqopC.SJgxzOgsIPMdErXDSPpXBHECHvBz;
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.zfVFwJCmHgMNitmEtBSjuOCUhszOA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.zfVFwJCmHgMNitmEtBSjuOCUhszOA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.KiAlpiCKWFgyjjowDNDECiYqbkwy = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.KiAlpiCKWFgyjjowDNDECiYqbkwy);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.ZQSJcYiQMGpijpZgyqJCHBKYVirL = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.ZQSJcYiQMGpijpZgyqJCHBKYVirL);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.FdoMbzNktCfZsAkCittVFdoDSrvtA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.FdoMbzNktCfZsAkCittVFdoDSrvtA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.QDRcqrPbmWnvHhHntgIYYwzGBCLe = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.QDRcqrPbmWnvHhHntgIYYwzGBCLe);
			for (int i = 0; i < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.vjxbwfESKzhjginidLUGakiaWMNPc.Length; i++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.vjxbwfESKzhjginidLUGakiaWMNPc[i] = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.vjxbwfESKzhjginidLUGakiaWMNPc[i]);
			}
			for (int j = 0; j < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.rCHURyRdAoajapNUTyZqlWyDfvjr.Length; j++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.rCHURyRdAoajapNUTyZqlWyDfvjr[j] = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.rCHURyRdAoajapNUTyZqlWyDfvjr[j]);
			}
			for (int k = 0; k < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.BabgiQCGMFCYDBtnZlpzwktASgfoA.Length; k++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.BabgiQCGMFCYDBtnZlpzwktASgfoA[k] = hOLISXUwDrSOMvpaDjmGamYaKHaDA3.BabgiQCGMFCYDBtnZlpzwktASgfoA[k];
			}
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.ACEXUEIhvyDhoWzTfgiYwyOJJWPd = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.ACEXUEIhvyDhoWzTfgiYwyOJJWPd);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.egepiWoENOPlvjsBjQcUTQThQtXy = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.egepiWoENOPlvjsBjQcUTQThQtXy);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.laEaAyWbbFpPsHrsqLXCVfyRNtOA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.laEaAyWbbFpPsHrsqLXCVfyRNtOA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.wHdTULrgtMuvDSbwsgsmCugAkAeP = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.wHdTULrgtMuvDSbwsgsmCugAkAeP);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.lcgarTHSBjtWUmvgEVjtSzrZsujU = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.lcgarTHSBjtWUmvgEVjtSzrZsujU);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.ibfxAWfIrRanqTdyqtTqLUbtxhXB = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.ibfxAWfIrRanqTdyqtTqLUbtxhXB);
			for (int l = 0; l < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.wUDSrnSPhOTZMnhYZHwBuycDpKlU.Length; l++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l] = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l]);
			}
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.uQTFfyFfSlfIByTwDPkCWozmwcGRA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.uQTFfyFfSlfIByTwDPkCWozmwcGRA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.pXMkCZTiUEuiEegDZDEoFVYUpSFRA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.pXMkCZTiUEuiEegDZDEoFVYUpSFRA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.ffTmPAXXGzguywpKjCekFRTqRQsl = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.ffTmPAXXGzguywpKjCekFRTqRQsl);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.qBlbBPaAwlscGTqAUQCDsKagsACU = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.qBlbBPaAwlscGTqAUQCDsKagsACU);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.peEIRXSSBVcxvHHTnhxAeNMcfnaY = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.peEIRXSSBVcxvHHTnhxAeNMcfnaY);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.lNofEYDYZLdVbLDxeGfseyvexPwlB = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.lNofEYDYZLdVbLDxeGfseyvexPwlB);
			for (int m = 0; m < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.COmBpFHGPXnWfRBCvUNRAKryoWpEA.Length; m++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m] = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m]);
			}
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.KCPnxpqQEkjzObfGNaxvYugOiRaT = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.KCPnxpqQEkjzObfGNaxvYugOiRaT);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.eyWecBSSojXCiSRaPqBtLRtIOzlR = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.eyWecBSSojXCiSRaPqBtLRtIOzlR);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.UdkEZUHSpdiwOssyscQwnYtlGRSw = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.UdkEZUHSpdiwOssyscQwnYtlGRSw);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.GVRauKxSrsPPYlMZBCjnCBBJwowW = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.GVRauKxSrsPPYlMZBCjnCBBJwowW);
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.OMDDJIICIyneIUjyGgzQeETJPuueB = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.OMDDJIICIyneIUjyGgzQeETJPuueB);
			for (int n = 0; n < hsdwjEUPBKDNUBpzohnDwvpKrWAGA.JpAeSQrMmaGUXIxPrEopiXoIdjXw.Length; n++)
			{
				hsdwjEUPBKDNUBpzohnDwvpKrWAGA.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n] = WpcWeawTfblcCOeQlDMUhAcosyseb(hOLISXUwDrSOMvpaDjmGamYaKHaDA2.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n]);
			}
		}

		public void VeODWUnONPBbPILuyFxTffHrsUWh(BOzfEjYambHvqBVXOgCNtPNjpHuDb P_0)
		{
			hsdwjEUPBKDNUBpzohnDwvpKrWAGA.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(P_0.hsdwjEUPBKDNUBpzohnDwvpKrWAGA);
			FMNLEoHpjJtKKfJrMvHVSJmQqopC.gacfFByuHltQHlBWzvTOJdnINPgP(P_0.FMNLEoHpjJtKKfJrMvHVSJmQqopC);
			dYyAehnkeMTgOOzLkiMrFdGavDZI = P_0.dYyAehnkeMTgOOzLkiMrFdGavDZI;
			LMDIsMBEYxfhzbeHgKfJVqGmnfeD = P_0.LMDIsMBEYxfhzbeHgKfJVqGmnfeD;
			KHYNOPcwOMfIlZUfmUcHOOrcrkkI = P_0.KHYNOPcwOMfIlZUfmUcHOOrcrkkI;
			JAUxpTjJqaVwnMLoQDDbqUaOYjeL = P_0.JAUxpTjJqaVwnMLoQDDbqUaOYjeL;
		}

		private int WpcWeawTfblcCOeQlDMUhAcosyseb(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, dYyAehnkeMTgOOzLkiMrFdGavDZI, LMDIsMBEYxfhzbeHgKfJVqGmnfeD, -65535, 65535);
		}
	}

	private class zpfeBLaHigqHrEhhhBivuPOFbEqR
	{
		private double pkAGjCcvxvIdxcZeCtxKawdLfdbac;

		private hOLISXUwDrSOMvpaDjmGamYaKHaDA ZpCGHCcIzKeaCClsYLRUjSuXyoiiA;

		private hOLISXUwDrSOMvpaDjmGamYaKHaDA olTYtvteJdBRnkhsfikzbiNffDohB;

		private hOLISXUwDrSOMvpaDjmGamYaKHaDA eOJwHWFEoIOBQvsMzfshgAGMGwWDA;

		private bool lcvGaYEZNmGXRrNNjvySpOoxaIOV;

		private double XhPOOdsoaOGOorswuALmnhrpblE;

		public hOLISXUwDrSOMvpaDjmGamYaKHaDA SJgxzOgsIPMdErXDSPpXBHECHvBz => ZpCGHCcIzKeaCClsYLRUjSuXyoiiA;

		public hOLISXUwDrSOMvpaDjmGamYaKHaDA kMNFLeAvJwDZTjnWfFchynjoRnKbA => eOJwHWFEoIOBQvsMzfshgAGMGwWDA;

		public bool LLcWkzzfQUYSZfIFXvQMsKjdXWhU => lcvGaYEZNmGXRrNNjvySpOoxaIOV;

		public double IbwEUDamUfjVIVxjktuVsJONgbExA => XhPOOdsoaOGOorswuALmnhrpblE;

		public zpfeBLaHigqHrEhhhBivuPOFbEqR(hOLISXUwDrSOMvpaDjmGamYaKHaDA P_0)
		{
			ZpCGHCcIzKeaCClsYLRUjSuXyoiiA = P_0;
			olTYtvteJdBRnkhsfikzbiNffDohB = new hOLISXUwDrSOMvpaDjmGamYaKHaDA();
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA = new hOLISXUwDrSOMvpaDjmGamYaKHaDA();
		}

		public void VdyaYMOQaEcBvlqClTMVbABBfPQO(double P_0)
		{
			pkAGjCcvxvIdxcZeCtxKawdLfdbac = P_0;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.zfVFwJCmHgMNitmEtBSjuOCUhszOA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.zfVFwJCmHgMNitmEtBSjuOCUhszOA - olTYtvteJdBRnkhsfikzbiNffDohB.zfVFwJCmHgMNitmEtBSjuOCUhszOA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.KiAlpiCKWFgyjjowDNDECiYqbkwy = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.KiAlpiCKWFgyjjowDNDECiYqbkwy - olTYtvteJdBRnkhsfikzbiNffDohB.KiAlpiCKWFgyjjowDNDECiYqbkwy;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ZQSJcYiQMGpijpZgyqJCHBKYVirL = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.ZQSJcYiQMGpijpZgyqJCHBKYVirL - olTYtvteJdBRnkhsfikzbiNffDohB.ZQSJcYiQMGpijpZgyqJCHBKYVirL;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.FdoMbzNktCfZsAkCittVFdoDSrvtA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.FdoMbzNktCfZsAkCittVFdoDSrvtA - olTYtvteJdBRnkhsfikzbiNffDohB.FdoMbzNktCfZsAkCittVFdoDSrvtA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA - olTYtvteJdBRnkhsfikzbiNffDohB.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.QDRcqrPbmWnvHhHntgIYYwzGBCLe = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.QDRcqrPbmWnvHhHntgIYYwzGBCLe - olTYtvteJdBRnkhsfikzbiNffDohB.QDRcqrPbmWnvHhHntgIYYwzGBCLe;
			for (int i = 0; i < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.vjxbwfESKzhjginidLUGakiaWMNPc.Length; i++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.vjxbwfESKzhjginidLUGakiaWMNPc[i] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.vjxbwfESKzhjginidLUGakiaWMNPc[i] - olTYtvteJdBRnkhsfikzbiNffDohB.vjxbwfESKzhjginidLUGakiaWMNPc[i];
			}
			for (int j = 0; j < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.rCHURyRdAoajapNUTyZqlWyDfvjr.Length; j++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.rCHURyRdAoajapNUTyZqlWyDfvjr[j] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.rCHURyRdAoajapNUTyZqlWyDfvjr[j] - olTYtvteJdBRnkhsfikzbiNffDohB.rCHURyRdAoajapNUTyZqlWyDfvjr[j];
			}
			for (int k = 0; k < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.BabgiQCGMFCYDBtnZlpzwktASgfoA.Length; k++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.BabgiQCGMFCYDBtnZlpzwktASgfoA[k] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.BabgiQCGMFCYDBtnZlpzwktASgfoA[k] != olTYtvteJdBRnkhsfikzbiNffDohB.BabgiQCGMFCYDBtnZlpzwktASgfoA[k];
			}
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ACEXUEIhvyDhoWzTfgiYwyOJJWPd = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.ACEXUEIhvyDhoWzTfgiYwyOJJWPd - olTYtvteJdBRnkhsfikzbiNffDohB.ACEXUEIhvyDhoWzTfgiYwyOJJWPd;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.egepiWoENOPlvjsBjQcUTQThQtXy = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.egepiWoENOPlvjsBjQcUTQThQtXy - olTYtvteJdBRnkhsfikzbiNffDohB.egepiWoENOPlvjsBjQcUTQThQtXy;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.laEaAyWbbFpPsHrsqLXCVfyRNtOA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.laEaAyWbbFpPsHrsqLXCVfyRNtOA - olTYtvteJdBRnkhsfikzbiNffDohB.laEaAyWbbFpPsHrsqLXCVfyRNtOA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.wHdTULrgtMuvDSbwsgsmCugAkAeP = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.wHdTULrgtMuvDSbwsgsmCugAkAeP - olTYtvteJdBRnkhsfikzbiNffDohB.wHdTULrgtMuvDSbwsgsmCugAkAeP;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.lcgarTHSBjtWUmvgEVjtSzrZsujU = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.lcgarTHSBjtWUmvgEVjtSzrZsujU - olTYtvteJdBRnkhsfikzbiNffDohB.lcgarTHSBjtWUmvgEVjtSzrZsujU;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ibfxAWfIrRanqTdyqtTqLUbtxhXB = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.ibfxAWfIrRanqTdyqtTqLUbtxhXB - olTYtvteJdBRnkhsfikzbiNffDohB.ibfxAWfIrRanqTdyqtTqLUbtxhXB;
			for (int l = 0; l < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.wUDSrnSPhOTZMnhYZHwBuycDpKlU.Length; l++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l] - olTYtvteJdBRnkhsfikzbiNffDohB.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l];
			}
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.uQTFfyFfSlfIByTwDPkCWozmwcGRA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.uQTFfyFfSlfIByTwDPkCWozmwcGRA - olTYtvteJdBRnkhsfikzbiNffDohB.uQTFfyFfSlfIByTwDPkCWozmwcGRA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.pXMkCZTiUEuiEegDZDEoFVYUpSFRA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.pXMkCZTiUEuiEegDZDEoFVYUpSFRA - olTYtvteJdBRnkhsfikzbiNffDohB.pXMkCZTiUEuiEegDZDEoFVYUpSFRA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ffTmPAXXGzguywpKjCekFRTqRQsl = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.ffTmPAXXGzguywpKjCekFRTqRQsl - olTYtvteJdBRnkhsfikzbiNffDohB.ffTmPAXXGzguywpKjCekFRTqRQsl;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.qBlbBPaAwlscGTqAUQCDsKagsACU = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.qBlbBPaAwlscGTqAUQCDsKagsACU - olTYtvteJdBRnkhsfikzbiNffDohB.qBlbBPaAwlscGTqAUQCDsKagsACU;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.peEIRXSSBVcxvHHTnhxAeNMcfnaY = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.peEIRXSSBVcxvHHTnhxAeNMcfnaY - olTYtvteJdBRnkhsfikzbiNffDohB.peEIRXSSBVcxvHHTnhxAeNMcfnaY;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.lNofEYDYZLdVbLDxeGfseyvexPwlB = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.lNofEYDYZLdVbLDxeGfseyvexPwlB - olTYtvteJdBRnkhsfikzbiNffDohB.lNofEYDYZLdVbLDxeGfseyvexPwlB;
			for (int m = 0; m < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.COmBpFHGPXnWfRBCvUNRAKryoWpEA.Length; m++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m] - olTYtvteJdBRnkhsfikzbiNffDohB.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m];
			}
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.KCPnxpqQEkjzObfGNaxvYugOiRaT = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.KCPnxpqQEkjzObfGNaxvYugOiRaT - olTYtvteJdBRnkhsfikzbiNffDohB.KCPnxpqQEkjzObfGNaxvYugOiRaT;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.eyWecBSSojXCiSRaPqBtLRtIOzlR = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.eyWecBSSojXCiSRaPqBtLRtIOzlR - olTYtvteJdBRnkhsfikzbiNffDohB.eyWecBSSojXCiSRaPqBtLRtIOzlR;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.UdkEZUHSpdiwOssyscQwnYtlGRSw = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.UdkEZUHSpdiwOssyscQwnYtlGRSw - olTYtvteJdBRnkhsfikzbiNffDohB.UdkEZUHSpdiwOssyscQwnYtlGRSw;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA - olTYtvteJdBRnkhsfikzbiNffDohB.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.GVRauKxSrsPPYlMZBCjnCBBJwowW = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.GVRauKxSrsPPYlMZBCjnCBBJwowW - olTYtvteJdBRnkhsfikzbiNffDohB.GVRauKxSrsPPYlMZBCjnCBBJwowW;
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.OMDDJIICIyneIUjyGgzQeETJPuueB = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.OMDDJIICIyneIUjyGgzQeETJPuueB - olTYtvteJdBRnkhsfikzbiNffDohB.OMDDJIICIyneIUjyGgzQeETJPuueB;
			for (int n = 0; n < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.JpAeSQrMmaGUXIxPrEopiXoIdjXw.Length; n++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n] - olTYtvteJdBRnkhsfikzbiNffDohB.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n];
			}
			lcvGaYEZNmGXRrNNjvySpOoxaIOV = VoSBMALDDlvDAWukraYUQAXfmhSX();
			if (lcvGaYEZNmGXRrNNjvySpOoxaIOV)
			{
				XhPOOdsoaOGOorswuALmnhrpblE = P_0;
				olTYtvteJdBRnkhsfikzbiNffDohB.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(ZpCGHCcIzKeaCClsYLRUjSuXyoiiA);
			}
		}

		public void gacfFByuHltQHlBWzvTOJdnINPgP(zpfeBLaHigqHrEhhhBivuPOFbEqR P_0)
		{
			pkAGjCcvxvIdxcZeCtxKawdLfdbac = P_0.pkAGjCcvxvIdxcZeCtxKawdLfdbac;
			olTYtvteJdBRnkhsfikzbiNffDohB.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(P_0.olTYtvteJdBRnkhsfikzbiNffDohB);
			eOJwHWFEoIOBQvsMzfshgAGMGwWDA.HnLLEqjiiVyfJyqDDlxHfKQyyBcB(P_0.eOJwHWFEoIOBQvsMzfshgAGMGwWDA);
		}

		private bool VoSBMALDDlvDAWukraYUQAXfmhSX()
		{
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.KiAlpiCKWFgyjjowDNDECiYqbkwy != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ZQSJcYiQMGpijpZgyqJCHBKYVirL != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.FdoMbzNktCfZsAkCittVFdoDSrvtA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.QDRcqrPbmWnvHhHntgIYYwzGBCLe != 0)
			{
				return true;
			}
			for (int i = 0; i < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.vjxbwfESKzhjginidLUGakiaWMNPc.Length; i++)
			{
				if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.vjxbwfESKzhjginidLUGakiaWMNPc[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.rCHURyRdAoajapNUTyZqlWyDfvjr.Length; j++)
			{
				if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.rCHURyRdAoajapNUTyZqlWyDfvjr[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.BabgiQCGMFCYDBtnZlpzwktASgfoA.Length; k++)
			{
				if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.BabgiQCGMFCYDBtnZlpzwktASgfoA[k])
				{
					return true;
				}
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ACEXUEIhvyDhoWzTfgiYwyOJJWPd != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.egepiWoENOPlvjsBjQcUTQThQtXy != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.laEaAyWbbFpPsHrsqLXCVfyRNtOA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.wHdTULrgtMuvDSbwsgsmCugAkAeP != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.lcgarTHSBjtWUmvgEVjtSzrZsujU != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ibfxAWfIrRanqTdyqtTqLUbtxhXB != 0)
			{
				return true;
			}
			for (int l = 0; l < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.wUDSrnSPhOTZMnhYZHwBuycDpKlU.Length; l++)
			{
				if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.wUDSrnSPhOTZMnhYZHwBuycDpKlU[l] != 0)
				{
					return true;
				}
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.uQTFfyFfSlfIByTwDPkCWozmwcGRA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.pXMkCZTiUEuiEegDZDEoFVYUpSFRA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.ffTmPAXXGzguywpKjCekFRTqRQsl != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.qBlbBPaAwlscGTqAUQCDsKagsACU != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.peEIRXSSBVcxvHHTnhxAeNMcfnaY != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.lNofEYDYZLdVbLDxeGfseyvexPwlB != 0)
			{
				return true;
			}
			for (int m = 0; m < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.COmBpFHGPXnWfRBCvUNRAKryoWpEA.Length; m++)
			{
				eOJwHWFEoIOBQvsMzfshgAGMGwWDA.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m] = ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m] - olTYtvteJdBRnkhsfikzbiNffDohB.COmBpFHGPXnWfRBCvUNRAKryoWpEA[m];
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.KCPnxpqQEkjzObfGNaxvYugOiRaT != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.eyWecBSSojXCiSRaPqBtLRtIOzlR != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.UdkEZUHSpdiwOssyscQwnYtlGRSw != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.GVRauKxSrsPPYlMZBCjnCBBJwowW != 0)
			{
				return true;
			}
			if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.OMDDJIICIyneIUjyGgzQeETJPuueB != 0)
			{
				return true;
			}
			for (int n = 0; n < ZpCGHCcIzKeaCClsYLRUjSuXyoiiA.JpAeSQrMmaGUXIxPrEopiXoIdjXw.Length; n++)
			{
				if (eOJwHWFEoIOBQvsMzfshgAGMGwWDA.JpAeSQrMmaGUXIxPrEopiXoIdjXw[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class yHtBThWQeABFonhmAxtbyDNmFcTT
	{
		public enum sOCoPEFchWyAJmGfzaLrJbrlJEOQA
		{
			Exact = 0,
			Approximate = 1
		}

		public class fpCzLrzrAaUXyCncYcpRuzeIBPrV
		{
			public int VWakOSlVTfuoDgrdFzKSKzlznUuH;

			public Guid GJWlMLClPmPXaSOuCwqzxHpXEBli;

			public Guid PUtLFqNGlENqVoXQoWeIQjQdDJeG;

			public int xRplkszrHVAjJuxZEBnxqHRGERQo;

			public int MRPfHzUHncRnGAfRLHkJtBINvwOQ;

			public int drigryHADJnYZsZLdGxetynoBvEuA;

			public int IrbbSSppubCdQYsNqfnTFNmGelUGb;

			public bool VMiqFrazHzpDIBfZFgsijwelwUUS(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, sOCoPEFchWyAJmGfzaLrJbrlJEOQA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == VWakOSlVTfuoDgrdFzKSKzlznUuH)
				{
					return true;
				}
				if (MRPfHzUHncRnGAfRLHkJtBINvwOQ != P_0.SalwCmhPSAVhOwpDnZmMbUgwNwDn)
				{
					return false;
				}
				if (drigryHADJnYZsZLdGxetynoBvEuA != P_0.cTVROwldghlxQaScAeIkXeQWfUGGA)
				{
					return false;
				}
				if (IrbbSSppubCdQYsNqfnTFNmGelUGb != P_0.YZYeogkZhOVlboQappUNJfPSbxOg)
				{
					return false;
				}
				return P_1 switch
				{
					sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Exact => GJWlMLClPmPXaSOuCwqzxHpXEBli == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Approximate => PUtLFqNGlENqVoXQoWeIQjQdDJeG == P_0.vCEjRnEevHALmiUbBVieclavfqCLc, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string sUZORwstuqJukKaoeQNoXBmgITyF()
			{
				string text = "" + "rewiredId = " + VWakOSlVTfuoDgrdFzKSKzlznUuH + "\n";
				Guid gJWlMLClPmPXaSOuCwqzxHpXEBli = GJWlMLClPmPXaSOuCwqzxHpXEBli;
				string text2 = text + "instanceGuid = " + gJWlMLClPmPXaSOuCwqzxHpXEBli.ToString() + "\n";
				gJWlMLClPmPXaSOuCwqzxHpXEBli = PUtLFqNGlENqVoXQoWeIQjQdDJeG;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + gJWlMLClPmPXaSOuCwqzxHpXEBli.ToString() + "\n", "lastInputManagerId = ", xRplkszrHVAjJuxZEBnxqHRGERQo.ToString(), "\n"), "hardwareAxisCount = ", MRPfHzUHncRnGAfRLHkJtBINvwOQ.ToString(), "\n"), "hardwareButtonCount = ", drigryHADJnYZsZLdGxetynoBvEuA.ToString(), "\n"), "hardwareHatCount = ", IrbbSSppubCdQYsNqfnTFNmGelUGb.ToString(), "\n");
			}
		}

		private sealed class eVrkhiIvzsjulmehewfdGejrQkhb : IEnumerable<fpCzLrzrAaUXyCncYcpRuzeIBPrV>, IEnumerable, IEnumerator<fpCzLrzrAaUXyCncYcpRuzeIBPrV>, IEnumerator, IDisposable
		{
			private int yJBrJSrcqguBIxNzfDDgTRLtFzKBA;

			private fpCzLrzrAaUXyCncYcpRuzeIBPrV HlRpsqLrSMUIYzUSSwfwZXlvZcDc;

			private int wbMcXstfEDtxbiVnCFcZlDAiVGnt;

			public yHtBThWQeABFonhmAxtbyDNmFcTT DGKZYxFyXeEjrEzyhnOjHTvcDkUG;

			private bRGrQSsmGYcQvEIdClixFNgYhPLEA lQykENlIHETtioiTlitqMCxMGZGk;

			public bRGrQSsmGYcQvEIdClixFNgYhPLEA sTpEuGLDIhdLOBNwXhFieTcuCdAdA;

			private sOCoPEFchWyAJmGfzaLrJbrlJEOQA FJqQjhsWDqJcnkKbKUbMNbVyiDwp;

			public sOCoPEFchWyAJmGfzaLrJbrlJEOQA vbsgYpEfWTKBqiSntlDuhWHcVcgmA;

			private int OfhhBWzccUDMQzYngsMlvDfpTteJ;

			private int SQvbnTwAOjQpHBWvaAMKfWqeqAlV;

			fpCzLrzrAaUXyCncYcpRuzeIBPrV IEnumerator<fpCzLrzrAaUXyCncYcpRuzeIBPrV>.Current
			{
				[DebuggerHidden]
				get
				{
					return HlRpsqLrSMUIYzUSSwfwZXlvZcDc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HlRpsqLrSMUIYzUSSwfwZXlvZcDc;
				}
			}

			[DebuggerHidden]
			public eVrkhiIvzsjulmehewfdGejrQkhb(int P_0)
			{
				yJBrJSrcqguBIxNzfDDgTRLtFzKBA = P_0;
				wbMcXstfEDtxbiVnCFcZlDAiVGnt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = yJBrJSrcqguBIxNzfDDgTRLtFzKBA;
				yHtBThWQeABFonhmAxtbyDNmFcTT dGKZYxFyXeEjrEzyhnOjHTvcDkUG = DGKZYxFyXeEjrEzyhnOjHTvcDkUG;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					yJBrJSrcqguBIxNzfDDgTRLtFzKBA = -1;
					goto IL_0083;
				}
				yJBrJSrcqguBIxNzfDDgTRLtFzKBA = -1;
				OfhhBWzccUDMQzYngsMlvDfpTteJ = dGKZYxFyXeEjrEzyhnOjHTvcDkUG.amLCIbCBcMURZIUNjREhoAVBkmRLA.Count;
				SQvbnTwAOjQpHBWvaAMKfWqeqAlV = 0;
				goto IL_0093;
				IL_0083:
				SQvbnTwAOjQpHBWvaAMKfWqeqAlV++;
				goto IL_0093;
				IL_0093:
				if (SQvbnTwAOjQpHBWvaAMKfWqeqAlV < OfhhBWzccUDMQzYngsMlvDfpTteJ)
				{
					if (dGKZYxFyXeEjrEzyhnOjHTvcDkUG.amLCIbCBcMURZIUNjREhoAVBkmRLA[SQvbnTwAOjQpHBWvaAMKfWqeqAlV].VMiqFrazHzpDIBfZFgsijwelwUUS(lQykENlIHETtioiTlitqMCxMGZGk, FJqQjhsWDqJcnkKbKUbMNbVyiDwp))
					{
						HlRpsqLrSMUIYzUSSwfwZXlvZcDc = dGKZYxFyXeEjrEzyhnOjHTvcDkUG.amLCIbCBcMURZIUNjREhoAVBkmRLA[SQvbnTwAOjQpHBWvaAMKfWqeqAlV];
						yJBrJSrcqguBIxNzfDDgTRLtFzKBA = 1;
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
			IEnumerator<fpCzLrzrAaUXyCncYcpRuzeIBPrV> IEnumerable<fpCzLrzrAaUXyCncYcpRuzeIBPrV>.GetEnumerator()
			{
				eVrkhiIvzsjulmehewfdGejrQkhb eVrkhiIvzsjulmehewfdGejrQkhb2;
				if (yJBrJSrcqguBIxNzfDDgTRLtFzKBA == -2 && wbMcXstfEDtxbiVnCFcZlDAiVGnt == Environment.CurrentManagedThreadId)
				{
					yJBrJSrcqguBIxNzfDDgTRLtFzKBA = 0;
					eVrkhiIvzsjulmehewfdGejrQkhb2 = this;
				}
				else
				{
					eVrkhiIvzsjulmehewfdGejrQkhb2 = new eVrkhiIvzsjulmehewfdGejrQkhb(0);
					eVrkhiIvzsjulmehewfdGejrQkhb2.DGKZYxFyXeEjrEzyhnOjHTvcDkUG = DGKZYxFyXeEjrEzyhnOjHTvcDkUG;
				}
				eVrkhiIvzsjulmehewfdGejrQkhb2.lQykENlIHETtioiTlitqMCxMGZGk = sTpEuGLDIhdLOBNwXhFieTcuCdAdA;
				eVrkhiIvzsjulmehewfdGejrQkhb2.FJqQjhsWDqJcnkKbKUbMNbVyiDwp = vbsgYpEfWTKBqiSntlDuhWHcVcgmA;
				return eVrkhiIvzsjulmehewfdGejrQkhb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<fpCzLrzrAaUXyCncYcpRuzeIBPrV>)this).GetEnumerator();
			}
		}

		private List<fpCzLrzrAaUXyCncYcpRuzeIBPrV> amLCIbCBcMURZIUNjREhoAVBkmRLA;

		public yHtBThWQeABFonhmAxtbyDNmFcTT()
		{
			amLCIbCBcMURZIUNjREhoAVBkmRLA = new List<fpCzLrzrAaUXyCncYcpRuzeIBPrV>();
		}

		public void BxTzroBfzTaTwApNswJziUKVlRcl(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = amLCIbCBcMURZIUNjREhoAVBkmRLA.Count;
			for (int i = 0; i < count; i++)
			{
				if (amLCIbCBcMURZIUNjREhoAVBkmRLA[i].VMiqFrazHzpDIBfZFgsijwelwUUS(P_0, sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Exact))
				{
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].VWakOSlVTfuoDgrdFzKSKzlznUuH = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].GJWlMLClPmPXaSOuCwqzxHpXEBli = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].PUtLFqNGlENqVoXQoWeIQjQdDJeG = P_0.vCEjRnEevHALmiUbBVieclavfqCLc;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].xRplkszrHVAjJuxZEBnxqHRGERQo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].MRPfHzUHncRnGAfRLHkJtBINvwOQ = P_0.SalwCmhPSAVhOwpDnZmMbUgwNwDn;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].drigryHADJnYZsZLdGxetynoBvEuA = P_0.cTVROwldghlxQaScAeIkXeQWfUGGA;
					amLCIbCBcMURZIUNjREhoAVBkmRLA[i].IrbbSSppubCdQYsNqfnTFNmGelUGb = P_0.YZYeogkZhOVlboQappUNJfPSbxOg;
					PFryRRtYQnyZiLARfKfyibtreOPM(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			amLCIbCBcMURZIUNjREhoAVBkmRLA.Add(new fpCzLrzrAaUXyCncYcpRuzeIBPrV
			{
				VWakOSlVTfuoDgrdFzKSKzlznUuH = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				GJWlMLClPmPXaSOuCwqzxHpXEBli = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				PUtLFqNGlENqVoXQoWeIQjQdDJeG = P_0.vCEjRnEevHALmiUbBVieclavfqCLc,
				xRplkszrHVAjJuxZEBnxqHRGERQo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				MRPfHzUHncRnGAfRLHkJtBINvwOQ = P_0.SalwCmhPSAVhOwpDnZmMbUgwNwDn,
				drigryHADJnYZsZLdGxetynoBvEuA = P_0.cTVROwldghlxQaScAeIkXeQWfUGGA,
				IrbbSSppubCdQYsNqfnTFNmGelUGb = P_0.YZYeogkZhOVlboQappUNJfPSbxOg
			});
			PFryRRtYQnyZiLARfKfyibtreOPM(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, amLCIbCBcMURZIUNjREhoAVBkmRLA.Count - 1);
		}

		[IteratorStateMachine(typeof(eVrkhiIvzsjulmehewfdGejrQkhb))]
		public IEnumerable<fpCzLrzrAaUXyCncYcpRuzeIBPrV> PvPyHcfmaIXXSTYdoBgcgafLyMtO(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, sOCoPEFchWyAJmGfzaLrJbrlJEOQA P_1)
		{
			return new eVrkhiIvzsjulmehewfdGejrQkhb(-2)
			{
				DGKZYxFyXeEjrEzyhnOjHTvcDkUG = this,
				sTpEuGLDIhdLOBNwXhFieTcuCdAdA = P_0,
				vbsgYpEfWTKBqiSntlDuhWHcVcgmA = P_1
			};
		}

		private void PFryRRtYQnyZiLARfKfyibtreOPM(int P_0, Guid P_1, int P_2)
		{
			for (int num = amLCIbCBcMURZIUNjREhoAVBkmRLA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (amLCIbCBcMURZIUNjREhoAVBkmRLA[num].VWakOSlVTfuoDgrdFzKSKzlznUuH == P_0 || amLCIbCBcMURZIUNjREhoAVBkmRLA[num].GJWlMLClPmPXaSOuCwqzxHpXEBli == P_1))
				{
					amLCIbCBcMURZIUNjREhoAVBkmRLA.RemoveAt(num);
				}
			}
		}

		public virtual string TIqJFhzDDWVffITtamGQMXdmGbGp()
		{
			string text = "";
			text = text + "Joystick records: " + amLCIbCBcMURZIUNjREhoAVBkmRLA.Count + "\n";
			for (int i = 0; i < amLCIbCBcMURZIUNjREhoAVBkmRLA.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + amLCIbCBcMURZIUNjREhoAVBkmRLA[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class DjVBepuGlDEzIydfymfhkvUtjNUc
	{
		public bRGrQSsmGYcQvEIdClixFNgYhPLEA ugwoeJazWecVSWXNlMdCRpdULmhk;

		public NmeNOpqJNpvsXZGMMFZCJOCAUrey UfmOZdpUaZRqmxcqwNvqLmdTnHcW;

		public bool jgANrWPJBgUZpxVzXMEzegDWgPnF
		{
			get
			{
				if (ugwoeJazWecVSWXNlMdCRpdULmhk != null)
				{
					return UfmOZdpUaZRqmxcqwNvqLmdTnHcW != null;
				}
				return false;
			}
		}

		public DjVBepuGlDEzIydfymfhkvUtjNUc(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, NmeNOpqJNpvsXZGMMFZCJOCAUrey P_1)
		{
			ugwoeJazWecVSWXNlMdCRpdULmhk = P_0;
			UfmOZdpUaZRqmxcqwNvqLmdTnHcW = P_1;
		}

		public static List<NmeNOpqJNpvsXZGMMFZCJOCAUrey> doFFBBSlRfgzMbQjIyKaNqczWABA(List<DjVBepuGlDEzIydfymfhkvUtjNUc> P_0)
		{
			if (P_0 == null)
			{
				return new List<NmeNOpqJNpvsXZGMMFZCJOCAUrey>();
			}
			List<NmeNOpqJNpvsXZGMMFZCJOCAUrey> list = new List<NmeNOpqJNpvsXZGMMFZCJOCAUrey>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].jgANrWPJBgUZpxVzXMEzegDWgPnF)
				{
					list.Add(P_0[i].UfmOZdpUaZRqmxcqwNvqLmdTnHcW);
				}
			}
			return list;
		}
	}

	private class KRsZTabdVdWgRKDhMUQCPSicxElu
	{
		private uOLDTpMgRzhirnaDLRchtSQbEFye.LDuJPIsuTOrwwfLUZDjAbjEBCXjP DyrzevXDVgVIGkrPULfmUzJWdeOi;

		private uOLDTpMgRzhirnaDLRchtSQbEFye.KuMndQWFtodmzlhcWygvKjMMsPnN xTcvIKRlHcOvfxlxmjSllZaalSzn;

		private NativeBuffer idGqNaLXzdFSKQpFtGESFBNfFktg;

		private int tOshLBPyXQuNWlAKgrzPNHajeDgW;

		public KRsZTabdVdWgRKDhMUQCPSicxElu()
		{
			DyrzevXDVgVIGkrPULfmUzJWdeOi = new uOLDTpMgRzhirnaDLRchtSQbEFye.LDuJPIsuTOrwwfLUZDjAbjEBCXjP
			{
				UHnnQnfDpvjjWFwXbvWQTvCEZiPnA = (uint)Marshal.SizeOf(typeof(uOLDTpMgRzhirnaDLRchtSQbEFye.LDuJPIsuTOrwwfLUZDjAbjEBCXjP)),
				KUPFsxyEtOhyKZWUikbaFdxoMPfo = true,
				sdjwsHyxjrTIDYkAWIwzjypZmTph = true,
				JhHgNthsEhIPhUUFSbGQdPfKtWojc = false,
				dPWkmZdjxMcfBzyneWRgpjzpqpIv = true,
				ZDVzdkHqsRGWHCzimlRvkLzFOmOx = IntPtr.Zero
			};
			xTcvIKRlHcOvfxlxmjSllZaalSzn = uOLDTpMgRzhirnaDLRchtSQbEFye.KuMndQWFtodmzlhcWygvKjMMsPnN.aimKaVkezuYcNuUBNKezwQtypvwG();
			idGqNaLXzdFSKQpFtGESFBNfFktg = new NativeBuffer((int)xTcvIKRlHcOvfxlxmjSllZaalSzn.aDnXakbMVdTlIEejBEmfDNouQYvTA);
			idGqNaLXzdFSKQpFtGESFBNfFktg.Write(xTcvIKRlHcOvfxlxmjSllZaalSzn.aDnXakbMVdTlIEejBEmfDNouQYvTA, 0);
		}

		public bool LEOdVRuCdwCuxiuVLgCYgsyAfWhab()
		{
			int num = IPjLyDQrjUkhhklklnhViPEBaGGR();
			if (num == tOshLBPyXQuNWlAKgrzPNHajeDgW)
			{
				return false;
			}
			tOshLBPyXQuNWlAKgrzPNHajeDgW = num;
			return true;
		}

		public void IblLoVOxcuCmkTOKvLJgqgvvlftI(int P_0)
		{
			tOshLBPyXQuNWlAKgrzPNHajeDgW = P_0;
		}

		private int IPjLyDQrjUkhhklklnhViPEBaGGR()
		{
			try
			{
				return UGgQLjvmeopnQGcfVJPQeoBwAGKHA.nRkGlqiJEAbldopAYEGsXKlqfNOA(ref DyrzevXDVgVIGkrPULfmUzJWdeOi, idGqNaLXzdFSKQpFtGESFBNfFktg);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum nCgvUVEDrMuJWQeLQpzrlBKMvXND
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

	private IntPtr IHlfaEIBfOqiNOhgWwMvOAxiuydl;

	private SBstrsiLWYqpWzQLDLNlmFTmzMXs FxzhlnuqxUjdjyaLTAFIARGcByPc;

	private List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> ydzCcaIhSvPeEUErQqhuoHdLHVMS;

	private int enlmIdskrMTEepfhTshXNjmZbUof;

	private yHtBThWQeABFonhmAxtbyDNmFcTT ioJyPZJiIHCqGuIpHULJZxcIiafI;

	private bool RyxwtQmxTaujDorLMeyoWDRkEquD;

	private bool dgujDedStuLeLWNJrjYkoJGLTBTaA;

	private UpdateLoopSetting EqHnlRruOUJLMugAWsebfUjjwfL;

	private Action<int, ControllerDataUpdater> HJwQAcdOWVuigcFPczmckTtxpwsC;

	private PlatformInputManager TbNTAvMLCtAkYyVRLANBdkzbndDIb;

	private TimerRealTime HGrhRoyzBpGEFEEXCpISOnTVuLjy;

	private global::npittTMAakxvSluVLkUJndISsJCJ<bool> TkZiiUwpvxjZFvQHdZoJCBYBguRm;

	private KRsZTabdVdWgRKDhMUQCPSicxElu eVTmjnIiqHulJuTneNdgGaklwKED;

	private int gQnNnSpjonmusMEGIASedJRaXxQFA;

	private int XhdurFUmCFjSfVJKcaeYkoAfSWFXA;

	private global::npittTMAakxvSluVLkUJndISsJCJ<List<DjVBepuGlDEzIydfymfhkvUtjNUc>> VOtxcRbXbGkQnTvWLPkwouDdmZNq;

	private readonly object SGpfDOzZJDWMDrEZtoIJFPMqvLeR = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PFOmDTQZdWElhNkwxbiJwGyiqcrJ;

	private Func<int> OqfmDRMZxLMDVsFfcKXNGXIMwnOB;

	bool ABvzBDZAjyYZQREtNVKEUBATbshn.RoRUWKRMsSCDFFFqEaHNhMKgysykA
	{
		set
		{
			dgujDedStuLeLWNJrjYkoJGLTBTaA = flag;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => enlmIdskrMTEepfhTshXNjmZbUof;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => TbNTAvMLCtAkYyVRLANBdkzbndDIb;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<SBstrsiLWYqpWzQLDLNlmFTmzMXs>(FxzhlnuqxUjdjyaLTAFIARGcByPc);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public BSxuxkpqlruyakdxPRXoRuCTALKT(UpdateLoopSetting P_0, bool P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			EqHnlRruOUJLMugAWsebfUjjwfL = P_0;
			dgujDedStuLeLWNJrjYkoJGLTBTaA = P_1;
			IHlfaEIBfOqiNOhgWwMvOAxiuydl = P_2;
			PFOmDTQZdWElhNkwxbiJwGyiqcrJ = P_3;
			OqfmDRMZxLMDVsFfcKXNGXIMwnOB = P_4;
			TbNTAvMLCtAkYyVRLANBdkzbndDIb = this;
			FxzhlnuqxUjdjyaLTAFIARGcByPc = new SBstrsiLWYqpWzQLDLNlmFTmzMXs();
			HJwQAcdOWVuigcFPczmckTtxpwsC = UpdateControllerData;
			eVTmjnIiqHulJuTneNdgGaklwKED = new KRsZTabdVdWgRKDhMUQCPSicxElu();
			TkZiiUwpvxjZFvQHdZoJCBYBguRm = new global::npittTMAakxvSluVLkUJndISsJCJ<bool>(true, YOXTBytOCJdCIqGalZbUCJZaLIOQ);
			VOtxcRbXbGkQnTvWLPkwouDdmZNq = new global::npittTMAakxvSluVLkUJndISsJCJ<List<DjVBepuGlDEzIydfymfhkvUtjNUc>>(true, () => HSwnInzjIzoFLlNSqcYPLoPEyGiM());
			fSqatSElWSyKYbKKfPrLqWrpWjGCA();
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
		ioJyPZJiIHCqGuIpHULJZxcIiafI = new yHtBThWQeABFonhmAxtbyDNmFcTT();
		HGrhRoyzBpGEFEEXCpISOnTVuLjy = new TimerRealTime(1.0);
		HGrhRoyzBpGEFEEXCpISOnTVuLjy.Start();
		NPOkbBQQhexgBsYuVgeKsNdLUsSI();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		qzAqoWJYnikPBSFPqEeyfceJlRjJ();
		AtMHnbelWtrrGOUFzsgoUkSMOBwA();
		NtrGAnBpIMjkQCgpnrgZGOTdphynA();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (VOtxcRbXbGkQnTvWLPkwouDdmZNq != null)
		{
			VOtxcRbXbGkQnTvWLPkwouDdmZNq.ZsTnXJbLVbjRqPCSwHQgfEuNnYwm();
		}
		if (TkZiiUwpvxjZFvQHdZoJCBYBguRm != null)
		{
			TkZiiUwpvxjZFvQHdZoJCBYBguRm.ZsTnXJbLVbjRqPCSwHQgfEuNnYwm();
		}
		if (ydzCcaIhSvPeEUErQqhuoHdLHVMS == null)
		{
			return;
		}
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			for (int i = 0; i < ydzCcaIhSvPeEUErQqhuoHdLHVMS.Count; i++)
			{
				if (ydzCcaIhSvPeEUErQqhuoHdLHVMS[i] != null)
				{
					ydzCcaIhSvPeEUErQqhuoHdLHVMS[i].SRMnfTwuRJWofvnagwXeIorErELP();
					ydzCcaIhSvPeEUErQqhuoHdLHVMS[i].ogrRGoilbpJranQxpKtAkPpTTkaC();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return HJwQAcdOWVuigcFPczmckTtxpwsC;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			for (int i = 0; i < enlmIdskrMTEepfhTshXNjmZbUof; i++)
			{
				if (ydzCcaIhSvPeEUErQqhuoHdLHVMS[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					ydzCcaIhSvPeEUErQqhuoHdLHVMS[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		RyxwtQmxTaujDorLMeyoWDRkEquD = true;
		HGrhRoyzBpGEFEEXCpISOnTVuLjy.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		RyxwtQmxTaujDorLMeyoWDRkEquD = true;
		HGrhRoyzBpGEFEEXCpISOnTVuLjy.Start();
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

	private void qzAqoWJYnikPBSFPqEeyfceJlRjJ()
	{
		if (TkZiiUwpvxjZFvQHdZoJCBYBguRm.QNkWrLdeVAqfzHLJahJtrCjbJhLT)
		{
			if (TkZiiUwpvxjZFvQHdZoJCBYBguRm.OGYjjpkJopdcraeeXRZPVQYSFoHJ() && !HGrhRoyzBpGEFEEXCpISOnTVuLjy.running && !VOtxcRbXbGkQnTvWLPkwouDdmZNq.QNkWrLdeVAqfzHLJahJtrCjbJhLT)
			{
				if (TkZiiUwpvxjZFvQHdZoJCBYBguRm.EyIwVPNagGOHFKJkAaktBCeJeFLT)
				{
					RyxwtQmxTaujDorLMeyoWDRkEquD = true;
				}
				HGrhRoyzBpGEFEEXCpISOnTVuLjy.Start();
			}
		}
		else if (!HGrhRoyzBpGEFEEXCpISOnTVuLjy.running)
		{
			HGrhRoyzBpGEFEEXCpISOnTVuLjy.Start();
		}
		else if (HGrhRoyzBpGEFEEXCpISOnTVuLjy.Update())
		{
			TkZiiUwpvxjZFvQHdZoJCBYBguRm.qAWTketRvCdmkOgJVrHCCVbnLSdx();
		}
	}

	private List<DjVBepuGlDEzIydfymfhkvUtjNUc> HSwnInzjIzoFLlNSqcYPLoPEyGiM()
	{
		List<DjVBepuGlDEzIydfymfhkvUtjNUc> list = new List<DjVBepuGlDEzIydfymfhkvUtjNUc>();
		IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> list2 = GcXhkmiGvReRBQPasSGVDKtuOkcIb();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				NmeNOpqJNpvsXZGMMFZCJOCAUrey nmeNOpqJNpvsXZGMMFZCJOCAUrey = list2[i];
				Guid fTfFNbdDSSLPqvlVRRFMhJFkkRjdb = nmeNOpqJNpvsXZGMMFZCJOCAUrey.fTfFNbdDSSLPqvlVRRFMhJFkkRjdb;
				TVmjOvMzQEcAxIasZNmofQFDPCSt tVmjOvMzQEcAxIasZNmofQFDPCSt = new TVmjOvMzQEcAxIasZNmofQFDPCSt(FxzhlnuqxUjdjyaLTAFIARGcByPc, fTfFNbdDSSLPqvlVRRFMhJFkkRjdb);
				ebVGLfFcuykRsjFkHlmscLAQiInI ebVGLfFcuykRsjFkHlmscLAQiInI2 = tVmjOvMzQEcAxIasZNmofQFDPCSt.MnVXAVaMmRDTbdMZjFuxcTUfryHdb;
				bool flag = false;
				if (!dgujDedStuLeLWNJrjYkoJGLTBTaA)
				{
					goto IL_008c;
				}
				flag = YTThbbQFtIqARDYQTwPJqwGhYwQD.DQTUQCKZbdhwjzgrqKGKRchSTojx(ebVGLfFcuykRsjFkHlmscLAQiInI2.MuDmiqsvxwPaPnKcSVLNEQXncvHcA, StringTools.SanitizeDeviceString(nmeNOpqJNpvsXZGMMFZCJOCAUrey.CcIThwmTsDNNPaZoGiiOvJkXqSXj), string.Empty, nmeNOpqJNpvsXZGMMFZCJOCAUrey.XzcjuqdPVmKDLdysprgdoAWdbHpv);
				if (!flag)
				{
					goto IL_008c;
				}
				goto end_IL_0028;
				IL_008c:
				Guid guid = ((!string.IsNullOrEmpty(ebVGLfFcuykRsjFkHlmscLAQiInI2.MuDmiqsvxwPaPnKcSVLNEQXncvHcA)) ? MiscTools.CreateGuidHashSHA256(ebVGLfFcuykRsjFkHlmscLAQiInI2.MuDmiqsvxwPaPnKcSVLNEQXncvHcA) : nmeNOpqJNpvsXZGMMFZCJOCAUrey.fTfFNbdDSSLPqvlVRRFMhJFkkRjdb);
				bool flag2 = false;
				lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
				{
					if (ydzCcaIhSvPeEUErQqhuoHdLHVMS != null)
					{
						for (int j = 0; j < ydzCcaIhSvPeEUErQqhuoHdLHVMS.Count; j++)
						{
							if (ydzCcaIhSvPeEUErQqhuoHdLHVMS[j] != null && ydzCcaIhSvPeEUErQqhuoHdLHVMS[j].DTCbeGaRwaaHBvwglObfRyPGvFdnA == guid)
							{
								tVmjOvMzQEcAxIasZNmofQFDPCSt = ydzCcaIhSvPeEUErQqhuoHdLHVMS[j].bLiDqnjPNnYOLopzLuEokFheeLbPA.lZPXLAuOfXcmlhrkpSCiduvZyHGt;
								flag2 = true;
								break;
							}
						}
					}
				}
				bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = new bRGrQSsmGYcQvEIdClixFNgYhPLEA(new blJFQAJZVzzuBtgglibdVWVaJgpX(tVmjOvMzQEcAxIasZNmofQFDPCSt, EqHnlRruOUJLMugAWsebfUjjwfL), PFOmDTQZdWElhNkwxbiJwGyiqcrJ);
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.GkAmoLGUDKsxgfESOdFsuChSEKwK = nmeNOpqJNpvsXZGMMFZCJOCAUrey;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.LUEzHOdPYwBEukxtpMAJuBNhAYKy = nmeNOpqJNpvsXZGMMFZCJOCAUrey.EmlbJCmMmMeIRGiuOhCJFqGjvTusB;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.DTCbeGaRwaaHBvwglObfRyPGvFdnA = guid;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.JePvkTeYhPabLqEeEAEwAeuKtpGQ = StringTools.SanitizeDeviceString(nmeNOpqJNpvsXZGMMFZCJOCAUrey.CcIThwmTsDNNPaZoGiiOvJkXqSXj);
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.fFaCsHrgPAfioCVHsmmTxDalGSXSA = nmeNOpqJNpvsXZGMMFZCJOCAUrey.XzcjuqdPVmKDLdysprgdoAWdbHpv;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.rgFTFQxxDiooZShnRKUWSHGFmfLs = (nCgvUVEDrMuJWQeLQpzrlBKMvXND)nmeNOpqJNpvsXZGMMFZCJOCAUrey.lwdKCprwbJIQbcomeaVDfLXmfTPwA;
				NvBRkFFcgHoeEGjCdMcWnxZKsUMN nvBRkFFcgHoeEGjCdMcWnxZKsUMN = tVmjOvMzQEcAxIasZNmofQFDPCSt.qYRCFXXsnorCIBmlEHrWlxCTPAuU;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.GeuWWYSZESIpexvVGmqZfSRPvVBi = ebVGLfFcuykRsjFkHlmscLAQiInI2.crLXZVmyxBVSvQRSerZjqHbWkfB;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.EcZnpaWAsuTjwZHoQBGOvbBkkMck = flag;
				try
				{
					bRGrQSsmGYcQvEIdClixFNgYhPLEA2.wpbxZYMKouNzTMsUCPGcvoUocYAv = ebVGLfFcuykRsjFkHlmscLAQiInI2.XUSELPJpRcGsWlWXVJRKoFsLXgkF;
				}
				catch (Exception)
				{
					bRGrQSsmGYcQvEIdClixFNgYhPLEA2.wpbxZYMKouNzTMsUCPGcvoUocYAv = 0;
				}
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.SalwCmhPSAVhOwpDnZmMbUgwNwDn = nvBRkFFcgHoeEGjCdMcWnxZKsUMN.jMzORmQWMbdpkVsOLwgOrrucazEp;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.cTVROwldghlxQaScAeIkXeQWfUGGA = nvBRkFFcgHoeEGjCdMcWnxZKsUMN.xNlbavAaABzUlIRMZXWbTUwuNbkWA;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.YZYeogkZhOVlboQappUNJfPSbxOg = nvBRkFFcgHoeEGjCdMcWnxZKsUMN.SLqQvYJjPnbYjWJsxPGHtatjjHak;
				RHuPblplgLoskpDlwSusHPlTpMbB(bRGrQSsmGYcQvEIdClixFNgYhPLEA2, ebVGLfFcuykRsjFkHlmscLAQiInI2, out bRGrQSsmGYcQvEIdClixFNgYhPLEA2.DmtjoYRQnWRYmJVRiaDzujiwQoJj);
				try
				{
					string productName;
					try
					{
						productName = ebVGLfFcuykRsjFkHlmscLAQiInI2.kofISIuaVblaOWbqqgDZhOeJfsPq;
					}
					catch
					{
						productName = bRGrQSsmGYcQvEIdClixFNgYhPLEA2.JePvkTeYhPabLqEeEAEwAeuKtpGQ;
					}
					if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.jxKcLAKwUvTsFAXjnhrhQjuaKHJtA, (ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.crLXZVmyxBVSvQRSerZjqHbWkfB, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.jxKcLAKwUvTsFAXjnhrhQjuaKHJtA, (ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.crLXZVmyxBVSvQRSerZjqHbWkfB, productName, out var min, out var max, out var zero))
					{
						bRGrQSsmGYcQvEIdClixFNgYhPLEA2.bLiDqnjPNnYOLopzLuEokFheeLbPA.atbREJmizQWJZHjvwzjxKojhWBWf(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.jxKcLAKwUvTsFAXjnhrhQjuaKHJtA, (ushort)ebVGLfFcuykRsjFkHlmscLAQiInI2.crLXZVmyxBVSvQRSerZjqHbWkfB, productName));
					}
				}
				catch (Exception)
				{
				}
				if (!flag2)
				{
					IList<cmifrNlvyBXuXIoQyzrEFMGvtUuO> list3 = tVmjOvMzQEcAxIasZNmofQFDPCSt.FIhCvOKLXVJZOTFtTxaSbmgZjQTj();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].IPIhNCYKZLyPpYVHEpNKmhjgkbxE.SSKbqaHTsdHnXFaeBStVuCKuyFvFc & UZXqahMfdCepAdfDNKUfbPnbUVDIc.Axis) != UZXqahMfdCepAdfDNKUfbPnbUVDIc.All)
							{
								tVmjOvMzQEcAxIasZNmofQFDPCSt.MnVXAVaMmRDTbdMZjFuxcTUfryHdb.FJYumlqBoGWHFUEMqgvTyMkubiOD = new jmdzOYOJAgcgiCGqPaQBHuqZjCCQA(-65535, 65535);
							}
						}
					}
					tVmjOvMzQEcAxIasZNmofQFDPCSt.MnVXAVaMmRDTbdMZjFuxcTUfryHdb.xNmCVEvpoXaLjfNPCrmNLwEsXNkvA = rcedrWgwufvHmGodkzqkuAvmGejZA.Absolute;
					tVmjOvMzQEcAxIasZNmofQFDPCSt.edCeDWoPkjtoqzCvSgageWPVrmMPA(IHlfaEIBfOqiNOhgWwMvOAxiuydl, EJkAHWmykwaJHLYsFPZJhbCBAaNC.NonExclusive | EJkAHWmykwaJHLYsFPZJhbCBAaNC.Background);
					tVmjOvMzQEcAxIasZNmofQFDPCSt.aYqFHcXuqKZKpdHgTlGFMRbumjPj();
				}
				list.Add(new DjVBepuGlDEzIydfymfhkvUtjNUc(bRGrQSsmGYcQvEIdClixFNgYhPLEA2, nmeNOpqJNpvsXZGMMFZCJOCAUrey));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void NPOkbBQQhexgBsYuVgeKsNdLUsSI()
	{
		zTqgcGdJoFYcRmMVOwHTelxVZPScA(HSwnInzjIzoFLlNSqcYPLoPEyGiM());
	}

	private void zTqgcGdJoFYcRmMVOwHTelxVZPScA(List<DjVBepuGlDEzIydfymfhkvUtjNUc> P_0)
	{
		List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> list = new List<bRGrQSsmGYcQvEIdClixFNgYhPLEA>();
		gQnNnSpjonmusMEGIASedJRaXxQFA = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].jgANrWPJBgUZpxVzXMEzegDWgPnF)
			{
				continue;
			}
			try
			{
				bRGrQSsmGYcQvEIdClixFNgYhPLEA ugwoeJazWecVSWXNlMdCRpdULmhk = P_0[i].ugwoeJazWecVSWXNlMdCRpdULmhk;
				ugwoeJazWecVSWXNlMdCRpdULmhk.bYjHkUExJLWHYpVsmfsbqZpBHSZH();
				if (ugwoeJazWecVSWXNlMdCRpdULmhk.cjfAIiOxGHrPzmjTnlphtwnmhKYj)
				{
					gQnNnSpjonmusMEGIASedJRaXxQFA++;
				}
				list.Add(ugwoeJazWecVSWXNlMdCRpdULmhk);
			}
			catch (Exception)
			{
			}
		}
		eVTmjnIiqHulJuTneNdgGaklwKED.IblLoVOxcuCmkTOKvLJgqgvvlftI(gQnNnSpjonmusMEGIASedJRaXxQFA);
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> list2 = ydzCcaIhSvPeEUErQqhuoHdLHVMS;
			int num2 = enlmIdskrMTEepfhTshXNjmZbUof;
			int count = list.Count;
			CWvQgAssLTlROwPwzCKbfdAvIQBYA(num2, count, list2, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			atPcxsLZFRfosgHZOgdKOlaIYZQN(list2, list, false);
			atPcxsLZFRfosgHZOgdKOlaIYZQN(list, list2, true);
			ATAbKEKdiZEUQvlyKSHavPnVarvlA(list, list2);
			ydzCcaIhSvPeEUErQqhuoHdLHVMS = list;
			enlmIdskrMTEepfhTshXNjmZbUof = list.Count;
		}
	}

	private void RHuPblplgLoskpDlwSusHPlTpMbB(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, ebVGLfFcuykRsjFkHlmscLAQiInI P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = SXgteXWEPLyHbxmQNCQiBhYIujrBA.RrPHxkdLfQdsyuEeqnENTilmyeUC(P_1.MuDmiqsvxwPaPnKcSVLNEQXncvHcA);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			TaGiqOKwYiENMdhhzxzQRMUlWLgnA taGiqOKwYiENMdhhzxzQRMUlWLgnA = UGgQLjvmeopnQGcfVJPQeoBwAGKHA.IfhiFkDHoXTRoeLuPFWmxiFmVeunA(text.ToLower(CultureInfo.InvariantCulture));
			if (taGiqOKwYiENMdhhzxzQRMUlWLgnA != null)
			{
				P_0.cjfAIiOxGHrPzmjTnlphtwnmhKYj = taGiqOKwYiENMdhhzxzQRMUlWLgnA.HeeMXniHWKuhmwsbSEMqqNMcBOwA;
				P_0.KYctGCHGLXyidxEaqpmlCueCwYDf = taGiqOKwYiENMdhhzxzQRMUlWLgnA.XJendKSWzwJQHTyyiCcbgGfpkKcx;
				P_2 = lzpGQZeHakGDDmaDjJrfCidOgxoBA.CzRoBXbUDDJJTueJveBwfDmRAYPP(taGiqOKwYiENMdhhzxzQRMUlWLgnA, P_0.fFaCsHrgPAfioCVHsmmTxDalGSXSA, P_0.JePvkTeYhPabLqEeEAEwAeuKtpGQ, P_0.KYctGCHGLXyidxEaqpmlCueCwYDf);
				taGiqOKwYiENMdhhzxzQRMUlWLgnA.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void NtrGAnBpIMjkQCgpnrgZGOTdphynA()
	{
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			for (int i = 0; i < enlmIdskrMTEepfhTshXNjmZbUof; i++)
			{
				try
				{
					bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = ydzCcaIhSvPeEUErQqhuoHdLHVMS[i];
					if (bRGrQSsmGYcQvEIdClixFNgYhPLEA2 != null && bRGrQSsmGYcQvEIdClixFNgYhPLEA2.CsJUOiFwZSoZWFCNGCjeEEsNzCgb() && (!dgujDedStuLeLWNJrjYkoJGLTBTaA || !bRGrQSsmGYcQvEIdClixFNgYhPLEA2.EcZnpaWAsuTjwZHoQBGOvbBkkMck))
					{
						bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> GcXhkmiGvReRBQPasSGVDKtuOkcIb()
	{
		try
		{
			IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> list = FxzhlnuqxUjdjyaLTAFIARGcByPc.dhYDLFvkhRlJGgJbluKAJtjtthyu(hppHiYuBLSrbOpyrsLdssPhrgBgl.GameControl, ZWJASgfSgFZfrrcyiiPYhRZfDwHYB.AttachedOnly);
			XhdurFUmCFjSfVJKcaeYkoAfSWFXA = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			XhdurFUmCFjSfVJKcaeYkoAfSWFXA = 0;
			return EmptyObjects<NmeNOpqJNpvsXZGMMFZCJOCAUrey>.EmptyReadOnlyIListT;
		}
	}

	private void fSqatSElWSyKYbKKfPrLqWrpWjGCA()
	{
		FxzhlnuqxUjdjyaLTAFIARGcByPc.XVDzIJcHOlAZzfJAsWvxnBRYRGulA();
	}

	private void CWvQgAssLTlROwPwzCKbfdAvIQBYA(int P_0, int P_1, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_2, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(bRGrQSsmGYcQvEIdClixFNgYhPLEA.oTYIONGTWcsnrGXMnwpCtqySozbF);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			txPcIaUNRNZWopKcAzgEYonnWcYD(P_1, P_3, P_0, P_2, yHtBThWQeABFonhmAxtbyDNmFcTT.sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Exact);
		}
		REzfbgiQMsrNFVgCYiiEhbslKIss(P_1, P_3, yHtBThWQeABFonhmAxtbyDNmFcTT.sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Exact);
		for (int i = 0; i < P_1; i++)
		{
			bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = P_3[i];
			if (bRGrQSsmGYcQvEIdClixFNgYhPLEA2 != null && bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = EcyFhItGMGgzOfcheEXaNewkkbdDb(P_3);
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = OqfmDRMZxLMDVsFfcKXNGXIMwnOB();
				ioJyPZJiIHCqGuIpHULJZxcIiafI.BxTzroBfzTaTwApNswJziUKVlRcl(bRGrQSsmGYcQvEIdClixFNgYhPLEA2);
			}
		}
		P_3.Sort(bRGrQSsmGYcQvEIdClixFNgYhPLEA.UrqLbAIhfgglsxuXspQdIfffNkEU);
	}

	private bool ZKAdiDDXPCdVyYcrldfHxdyxMCFp(List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_0, int P_1)
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

	private int EcyFhItGMGgzOfcheEXaNewkkbdDb(List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_0)
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

	private bool gAjpTSHgThOcKSSgrrTZtbWNVuYA(List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_0, int P_1)
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

	private void txPcIaUNRNZWopKcAzgEYonnWcYD(int P_0, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_1, int P_2, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_3, yHtBThWQeABFonhmAxtbyDNmFcTT.sOCoPEFchWyAJmGfzaLrJbrlJEOQA P_4)
	{
		int num = ((P_4 != yHtBThWQeABFonhmAxtbyDNmFcTT.sOCoPEFchWyAJmGfzaLrJbrlJEOQA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = P_1[i];
			if (bRGrQSsmGYcQvEIdClixFNgYhPLEA2 == null || bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA3 = P_3[j];
				if (bRGrQSsmGYcQvEIdClixFNgYhPLEA3 != null && !gAjpTSHgThOcKSSgrrTZtbWNVuYA(P_1, bRGrQSsmGYcQvEIdClixFNgYhPLEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && bRGrQSsmGYcQvEIdClixFNgYhPLEA2.CQPsZqBqGTNxSdirWfCSZANiXiIr(bRGrQSsmGYcQvEIdClixFNgYhPLEA3) >= num)
				{
					bRGrQSsmGYcQvEIdClixFNgYhPLEA2.fnorWiJrGRkDgoefCTKMMJsKDhQiA(bRGrQSsmGYcQvEIdClixFNgYhPLEA3);
					ioJyPZJiIHCqGuIpHULJZxcIiafI.BxTzroBfzTaTwApNswJziUKVlRcl(bRGrQSsmGYcQvEIdClixFNgYhPLEA2);
				}
			}
		}
	}

	private void REzfbgiQMsrNFVgCYiiEhbslKIss(int P_0, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_1, yHtBThWQeABFonhmAxtbyDNmFcTT.sOCoPEFchWyAJmGfzaLrJbrlJEOQA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = P_1[i];
			if (bRGrQSsmGYcQvEIdClixFNgYhPLEA2 == null || bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			yHtBThWQeABFonhmAxtbyDNmFcTT.fpCzLrzrAaUXyCncYcpRuzeIBPrV fpCzLrzrAaUXyCncYcpRuzeIBPrV = null;
			foreach (yHtBThWQeABFonhmAxtbyDNmFcTT.fpCzLrzrAaUXyCncYcpRuzeIBPrV item in ioJyPZJiIHCqGuIpHULJZxcIiafI.PvPyHcfmaIXXSTYdoBgcgafLyMtO(bRGrQSsmGYcQvEIdClixFNgYhPLEA2, P_2))
			{
				if (!gAjpTSHgThOcKSSgrrTZtbWNVuYA(P_1, item.VWakOSlVTfuoDgrdFzKSKzlznUuH) && item.xRplkszrHVAjJuxZEBnxqHRGERQo >= 0)
				{
					fpCzLrzrAaUXyCncYcpRuzeIBPrV = item;
					break;
				}
			}
			if (fpCzLrzrAaUXyCncYcpRuzeIBPrV != null)
			{
				int num = fpCzLrzrAaUXyCncYcpRuzeIBPrV.xRplkszrHVAjJuxZEBnxqHRGERQo;
				if (!ZKAdiDDXPCdVyYcrldfHxdyxMCFp(P_1, num))
				{
					num = (fpCzLrzrAaUXyCncYcpRuzeIBPrV.xRplkszrHVAjJuxZEBnxqHRGERQo = EcyFhItGMGgzOfcheEXaNewkkbdDb(P_1));
				}
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = fpCzLrzrAaUXyCncYcpRuzeIBPrV.VWakOSlVTfuoDgrdFzKSKzlznUuH;
				ioJyPZJiIHCqGuIpHULJZxcIiafI.BxTzroBfzTaTwApNswJziUKVlRcl(bRGrQSsmGYcQvEIdClixFNgYhPLEA2);
			}
		}
	}

	private void AtMHnbelWtrrGOUFzsgoUkSMOBwA()
	{
		if (RyxwtQmxTaujDorLMeyoWDRkEquD)
		{
			nnCMMZxtZGxHWfRAQbZwAkFdIbKl();
		}
		if (VOtxcRbXbGkQnTvWLPkwouDdmZNq.QNkWrLdeVAqfzHLJahJtrCjbJhLT && VOtxcRbXbGkQnTvWLPkwouDdmZNq.OGYjjpkJopdcraeeXRZPVQYSFoHJ())
		{
			fpuvEIZESaGtaygPqGHblbDkHbbL(VOtxcRbXbGkQnTvWLPkwouDdmZNq.EyIwVPNagGOHFKJkAaktBCeJeFLT);
		}
	}

	private void nnCMMZxtZGxHWfRAQbZwAkFdIbKl()
	{
		RyxwtQmxTaujDorLMeyoWDRkEquD = false;
		if (!VOtxcRbXbGkQnTvWLPkwouDdmZNq.QNkWrLdeVAqfzHLJahJtrCjbJhLT)
		{
			VOtxcRbXbGkQnTvWLPkwouDdmZNq.qAWTketRvCdmkOgJVrHCCVbnLSdx();
		}
	}

	private void fpuvEIZESaGtaygPqGHblbDkHbbL(List<DjVBepuGlDEzIydfymfhkvUtjNUc> P_0)
	{
		if (CvvcmMuGaeGrKQnhzFBUbbxyqmTCA(DjVBepuGlDEzIydfymfhkvUtjNUc.doFFBBSlRfgzMbQjIyKaNqczWABA(P_0)))
		{
			zTqgcGdJoFYcRmMVOwHTelxVZPScA(P_0);
		}
	}

	private bool CvvcmMuGaeGrKQnhzFBUbbxyqmTCA(IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> P_0)
	{
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !ASfDEpHaSZTcAcUHOaraLKDgXkkj(P_0[i].fTfFNbdDSSLPqvlVRRFMhJFkkRjdb))
				{
					return true;
				}
			}
			int count2 = ydzCcaIhSvPeEUErQqhuoHdLHVMS.Count;
			for (int j = 0; j < count2; j++)
			{
				if (ydzCcaIhSvPeEUErQqhuoHdLHVMS[j] != null && !GYMorHMWORleBShiizoNMfmWJgQV(P_0, ydzCcaIhSvPeEUErQqhuoHdLHVMS[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool ASfDEpHaSZTcAcUHOaraLKDgXkkj(Guid P_0)
	{
		lock (SGpfDOzZJDWMDrEZtoIJFPMqvLeR)
		{
			int count = ydzCcaIhSvPeEUErQqhuoHdLHVMS.Count;
			for (int i = 0; i < count; i++)
			{
				if (ydzCcaIhSvPeEUErQqhuoHdLHVMS[i] != null && ydzCcaIhSvPeEUErQqhuoHdLHVMS[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool GYMorHMWORleBShiizoNMfmWJgQV(IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].fTfFNbdDSSLPqvlVRRFMhJFkkRjdb == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void atPcxsLZFRfosgHZOgdKOlaIYZQN(List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_0, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA2 = P_0[i];
			if (bRGrQSsmGYcQvEIdClixFNgYhPLEA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					bRGrQSsmGYcQvEIdClixFNgYhPLEA bRGrQSsmGYcQvEIdClixFNgYhPLEA3 = P_1[j];
					if (bRGrQSsmGYcQvEIdClixFNgYhPLEA3 != null && bRGrQSsmGYcQvEIdClixFNgYhPLEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == bRGrQSsmGYcQvEIdClixFNgYhPLEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				hmQbaYAqcSgdwAdMIIaBmpELcxIOc(P_0[i], P_2);
			}
		}
	}

	private void hmQbaYAqcSgdwAdMIIaBmpELcxIOc(bRGrQSsmGYcQvEIdClixFNgYhPLEA P_0, bool P_1)
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

	private bool YOXTBytOCJdCIqGalZbUCJZaLIOQ()
	{
		int num = FxzhlnuqxUjdjyaLTAFIARGcByPc.rTafxJabeGPEmcdtfTJoAqbeQuIyC(hppHiYuBLSrbOpyrsLdssPhrgBgl.GameControl, ZWJASgfSgFZfrrcyiiPYhRZfDwHYB.AttachedOnly);
		if (XhdurFUmCFjSfVJKcaeYkoAfSWFXA != num)
		{
			XhdurFUmCFjSfVJKcaeYkoAfSWFXA = num;
			return true;
		}
		if (gQnNnSpjonmusMEGIASedJRaXxQFA > 0 && eVTmjnIiqHulJuTneNdgGaklwKED.LEOdVRuCdwCuxiuVLgCYgsyAfWhab())
		{
			return true;
		}
		return false;
	}

	private void ATAbKEKdiZEUQvlyKSHavPnVarvlA(List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_0, List<bRGrQSsmGYcQvEIdClixFNgYhPLEA> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].ogrRGoilbpJranQxpKtAkPpTTkaC();
			}
		}
	}

	[CompilerGenerated]
	private List<DjVBepuGlDEzIydfymfhkvUtjNUc> riATDnQBGzwCqNbwSqmMxwKAQHpt()
	{
		return HSwnInzjIzoFLlNSqcYPLoPEyGiM();
	}
}
