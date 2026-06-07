using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class dxtTGgzBQXNrKPngRZEZyZBogkbP : PlatformInputManager, EvYpgWgAiaVrxrmiqwIIXwlPQUow
{
	private class tcOIEORCozOZGnGHlBBtbFyLFlxY : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private enum vDHkDJkEsPlgFZjBiCDtrSSoctro
		{
			None = 0,
			Valid = 1,
			Invalid = 2,
			PendingRemoval = 3
		}

		private int loHHVowCkLHpBENNfMXJhGXnWgRmA;

		private int NNacwALtNcxfpZUUTFDaSgRAcotv;

		public Guid QHKJRpTNJBnSVmWdIgCGlJRIatho;

		public string GKuSQyjyrNTAfUBQuvciSMmceBPaA;

		private readonly GFzeCCkaUHxzLqMmAXGJQcvsbFsv UCdyxjrbqNKoGqjrqfmYkvAZbKTBA;

		private readonly DeviceType ebsyRBLhQXTXWcGWbVVChgTrGEwK;

		public string UAGxtKsNjtdJAbJDZBNbkoGSvvsm;

		public string wfuVmdrtjPuvnZHykcsyehCpHJdnA;

		public string XiAHOVgMbVAEubcqpSniKMFrGIUFA;

		public int LZvfHXfmnqYDCJUKIrgjKcqITbon;

		public int CBUcBGCeQHuIwkwlSmaKpKAFmQuV;

		public Guid bgLNjuJYWhGWPKOQbxUCBaAzXqfM;

		public Guid HHyRwCpdPYMrztfjuTRDvcXEDLVhA;

		public Guid HbgRExITcCMBiwDTjfQHeZlAnaETA;

		public int pezbeIyrFIhXmrTcgcvdBLxkUyNv;

		public int MUynsGjcfMjTVDxfOHOouARUZNTK;

		public int SUFeceTNdOupeRLaGwUuhxxAQUVi;

		public int twarqJdHGKMHGMzosuZxbFIhbmEU;

		public int QgcvHbBdmOcFellWhaBpJIfQWjoL;

		public int YckIFyziCQcFqvzLxbCpyhsOklSM;

		public bool CLiDYQYjBAJnBtAasPrFLLQxCJPR;

		public bool MKBEhyIOZEbyPleVzQVmQplSfQbS;

		public bool bohNIInnsduaDMgKLDMCmxIRelbJA;

		public int HPuGTptdSLCboClcDtjIfCtfZFTbA;

		private float[] aIQzXxQcEKSCqkcvZshUNQrcOHKi;

		private float[] yDRgUMFwQxcrdQfigSxfCkmRTKpJ;

		private bool[] nFSdjJiacSdeBHAfdHyPrRFCmJhRB;

		private HardwareJoystickMap_InputManager CRFxqiwqqGjyHzJwNpHehrifFRGc;

		private AdYqxsvyKqsMtDQSffNaPkmWadDA merKQxTNkYlBjIjmxHigSoyXKBKV;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> IhxjOupVqxIiDfVoPVhaanzEqgZR;

		private bool gLhgsrwaayhOWEjkzKkMHvWWzEawA;

		private bool LwPiTZjKmkedQdNZQVGgKmSwPvOI;

		private bool CUPQRqvBAjieNwkFBUunypCmsGNM;

		[CompilerGenerated]
		private Action m_CBufRacrRUhYIckLGeVRVhPQkLAnB;

		[CompilerGenerated]
		private Action<bool> m_TrIEZGxGKaeadlvheRFelQcwhENP;

		[CompilerGenerated]
		private Controller.Extension IaQTLPRYwuDZwzNaocXzXnWppwed;

		private bool TlhAVrdDUitAjidfqFRFPtGrjiAzA;

		public bool mLsSkvuzWXPgogGPwKaerOTuIkZd
		{
			get
			{
				if (UCdyxjrbqNKoGqjrqfmYkvAZbKTBA == null)
				{
					return false;
				}
				return UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.EsivdIFkKegfviNHPBmLeAzWGwWCb != null;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return loHHVowCkLHpBENNfMXJhGXnWgRmA;
			}
			set
			{
				loHHVowCkLHpBENNfMXJhGXnWgRmA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return NNacwALtNcxfpZUUTFDaSgRAcotv;
			}
			set
			{
				NNacwALtNcxfpZUUTFDaSgRAcotv = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (GKuSQyjyrNTAfUBQuvciSMmceBPaA != "Unknown Controller")
				{
					return GKuSQyjyrNTAfUBQuvciSMmceBPaA;
				}
				if (MKBEhyIOZEbyPleVzQVmQplSfQbS && !string.IsNullOrEmpty(XiAHOVgMbVAEubcqpSniKMFrGIUFA))
				{
					return XiAHOVgMbVAEubcqpSniKMFrGIUFA;
				}
				return wfuVmdrtjPuvnZHykcsyehCpHJdnA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (NNacwALtNcxfpZUUTFDaSgRAcotv < 0)
				{
					return null;
				}
				return NNacwALtNcxfpZUUTFDaSgRAcotv;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return IaQTLPRYwuDZwzNaocXzXnWppwed;
			}
			[CompilerGenerated]
			set
			{
				IaQTLPRYwuDZwzNaocXzXnWppwed = value;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => bgLNjuJYWhGWPKOQbxUCBaAzXqfM;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		public bool AdEKyrJZmgOHBFtYmLwRLGQAGNNq
		{
			get
			{
				if (!TlhAVrdDUitAjidfqFRFPtGrjiAzA && UCdyxjrbqNKoGqjrqfmYkvAZbKTBA != null)
				{
					return UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.UKYpYtGSFXwPyzhtganWoERsyXVS;
				}
				return false;
			}
		}

		public bool BzZEZTdAcehOuljgNMiquJOwDdYwA => !CUPQRqvBAjieNwkFBUunypCmsGNM;

		public event Action CBufRacrRUhYIckLGeVRVhPQkLAnB
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_CBufRacrRUhYIckLGeVRVhPQkLAnB;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_CBufRacrRUhYIckLGeVRVhPQkLAnB, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_CBufRacrRUhYIckLGeVRVhPQkLAnB;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_CBufRacrRUhYIckLGeVRVhPQkLAnB, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action<bool> TrIEZGxGKaeadlvheRFelQcwhENP
		{
			[CompilerGenerated]
			add
			{
				Action<bool> action = this.m_TrIEZGxGKaeadlvheRFelQcwhENP;
				Action<bool> action2;
				do
				{
					action2 = action;
					Action<bool> value2 = (Action<bool>)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_TrIEZGxGKaeadlvheRFelQcwhENP, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<bool> action = this.m_TrIEZGxGKaeadlvheRFelQcwhENP;
				Action<bool> action2;
				do
				{
					action2 = action;
					Action<bool> value2 = (Action<bool>)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_TrIEZGxGKaeadlvheRFelQcwhENP, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = AdEKyrJZmgOHBFtYmLwRLGQAGNNq;
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = AdEKyrJZmgOHBFtYmLwRLGQAGNNq;
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public tcOIEORCozOZGnGHlBBtbFyLFlxY(GFzeCCkaUHxzLqMmAXGJQcvsbFsv P_0, DeviceType P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			UCdyxjrbqNKoGqjrqfmYkvAZbKTBA = P_0;
			ebsyRBLhQXTXWcGWbVVChgTrGEwK = P_1;
			IhxjOupVqxIiDfVoPVhaanzEqgZR = P_2;
			NNacwALtNcxfpZUUTFDaSgRAcotv = -1;
			loHHVowCkLHpBENNfMXJhGXnWgRmA = -1;
			CUPQRqvBAjieNwkFBUunypCmsGNM = true;
			if (P_0 != null && P_0.EsivdIFkKegfviNHPBmLeAzWGwWCb != null)
			{
				CUPQRqvBAjieNwkFBUunypCmsGNM = P_0.EsivdIFkKegfviNHPBmLeAzWGwWCb.IsInitialized;
				P_0.EsivdIFkKegfviNHPBmLeAzWGwWCb.ErrorEvent += qxEcYzcJHiOgwVLpofimeONFIzxgc;
				P_0.EsivdIFkKegfviNHPBmLeAzWGwWCb.InitializedEvent += CTqAnzbAtmjioEKqvuDKLChQHqAd;
			}
		}

		public void cofaIViPJDnSCAjlRKIVIntQcWwbb()
		{
			if (!AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				return;
			}
			string obj = ((!string.IsNullOrEmpty(XiAHOVgMbVAEubcqpSniKMFrGIUFA)) ? XiAHOVgMbVAEubcqpSniKMFrGIUFA : wfuVmdrtjPuvnZHykcsyehCpHJdnA);
			Guid hHyRwCpdPYMrztfjuTRDvcXEDLVhA = HHyRwCpdPYMrztfjuTRDvcXEDLVhA;
			HbgRExITcCMBiwDTjfQHeZlAnaETA = MiscTools.CreateGuidHashSHA1(obj + hHyRwCpdPYMrztfjuTRDvcXEDLVhA.ToString());
			MUynsGjcfMjTVDxfOHOouARUZNTK = twarqJdHGKMHGMzosuZxbFIhbmEU;
			SUFeceTNdOupeRLaGwUuhxxAQUVi = QgcvHbBdmOcFellWhaBpJIfQWjoL + YckIFyziCQcFqvzLxbCpyhsOklSM * 8;
			SneEAnmSBilkAQVUSzORzhdiBdnA();
			QHKJRpTNJBnSVmWdIgCGlJRIatho = CRFxqiwqqGjyHzJwNpHehrifFRGc.hardwareMapIdentifier.guid;
			GKuSQyjyrNTAfUBQuvciSMmceBPaA = CRFxqiwqqGjyHzJwNpHehrifFRGc.controllerName;
			gLhgsrwaayhOWEjkzKkMHvWWzEawA = QHKJRpTNJBnSVmWdIgCGlJRIatho == Guid.Empty;
			aIQzXxQcEKSCqkcvZshUNQrcOHKi = new float[MUynsGjcfMjTVDxfOHOouARUZNTK];
			yDRgUMFwQxcrdQfigSxfCkmRTKpJ = new float[SUFeceTNdOupeRLaGwUuhxxAQUVi];
			nFSdjJiacSdeBHAfdHyPrRFCmJhRB = new bool[SUFeceTNdOupeRLaGwUuhxxAQUVi];
			if (CRFxqiwqqGjyHzJwNpHehrifFRGc != null && SUFeceTNdOupeRLaGwUuhxxAQUVi > 0)
			{
				switch (CRFxqiwqqGjyHzJwNpHehrifFRGc.map.platform)
				{
				case InputPlatform.WindowsRawInput:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							nFSdjJiacSdeBHAfdHyPrRFCmJhRB[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				case InputPlatform.WindowsDirectInput:
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							nFSdjJiacSdeBHAfdHyPrRFCmJhRB[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			merKQxTNkYlBjIjmxHigSoyXKBKV = UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.zeKnungAQHNsmgJDLErFJHBMUNwe;
			Update();
		}

		public void veDHkhYQlhgSHEiRMhBwKVJVxmQvA(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0)
		{
			if (AdEKyrJZmgOHBFtYmLwRLGQAGNNq && P_0 != null)
			{
				NNacwALtNcxfpZUUTFDaSgRAcotv = P_0.NNacwALtNcxfpZUUTFDaSgRAcotv;
				loHHVowCkLHpBENNfMXJhGXnWgRmA = P_0.loHHVowCkLHpBENNfMXJhGXnWgRmA;
				for (int i = 0; i < MathTools.Min(yDRgUMFwQxcrdQfigSxfCkmRTKpJ.Length, P_0.yDRgUMFwQxcrdQfigSxfCkmRTKpJ.Length); i++)
				{
					yDRgUMFwQxcrdQfigSxfCkmRTKpJ[i] = P_0.yDRgUMFwQxcrdQfigSxfCkmRTKpJ[i];
				}
				for (int j = 0; j < MathTools.Min(nFSdjJiacSdeBHAfdHyPrRFCmJhRB.Length, P_0.nFSdjJiacSdeBHAfdHyPrRFCmJhRB.Length); j++)
				{
					nFSdjJiacSdeBHAfdHyPrRFCmJhRB[j] = P_0.nFSdjJiacSdeBHAfdHyPrRFCmJhRB[j];
				}
				for (int k = 0; k < MathTools.Min(aIQzXxQcEKSCqkcvZshUNQrcOHKi.Length, P_0.aIQzXxQcEKSCqkcvZshUNQrcOHKi.Length); k++)
				{
					aIQzXxQcEKSCqkcvZshUNQrcOHKi[k] = P_0.aIQzXxQcEKSCqkcvZshUNQrcOHKi[k];
				}
				LwPiTZjKmkedQdNZQVGgKmSwPvOI = P_0.LwPiTZjKmkedQdNZQVGgKmSwPvOI;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				bool[] array = UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.fMvoddvLKADYDxhEtImxPIqUBYaj;
				int[] array2 = UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.iNZAlcTuJdKxgpvgzJhhytQGEdGu;
				OxVgBozpbGZfrutAUHXRUKvDlQrO(array, array2);
				TvPoDaJMDpScjmwAgPGhYXzKnIhq(array, array2);
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
			if (!AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				return;
			}
			if (MUynsGjcfMjTVDxfOHOouARUZNTK != dataUpdater.axisCount || SUFeceTNdOupeRLaGwUuhxxAQUVi != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < MUynsGjcfMjTVDxfOHOouARUZNTK; i++)
			{
				dataUpdater.axisValues[i] = aIQzXxQcEKSCqkcvZshUNQrcOHKi[i];
			}
			for (int j = 0; j < SUFeceTNdOupeRLaGwUuhxxAQUVi; j++)
			{
				if (nFSdjJiacSdeBHAfdHyPrRFCmJhRB[j])
				{
					dataUpdater.buttonPressureValues[j] = yDRgUMFwQxcrdQfigSxfCkmRTKpJ[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = yDRgUMFwQxcrdQfigSxfCkmRTKpJ[j] > 0f;
				}
			}
			if (LwPiTZjKmkedQdNZQVGgKmSwPvOI && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int eXUNDHtBfQoKeQfAPcMDejFFvPew(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0)
		{
			if (!AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				return 0;
			}
			if (P_0.loHHVowCkLHpBENNfMXJhGXnWgRmA == loHHVowCkLHpBENNfMXJhGXnWgRmA)
			{
				return 2;
			}
			if (twarqJdHGKMHGMzosuZxbFIhbmEU != P_0.twarqJdHGKMHGMzosuZxbFIhbmEU)
			{
				return 0;
			}
			if (QgcvHbBdmOcFellWhaBpJIfQWjoL != P_0.QgcvHbBdmOcFellWhaBpJIfQWjoL)
			{
				return 0;
			}
			if (YckIFyziCQcFqvzLxbCpyhsOklSM != P_0.YckIFyziCQcFqvzLxbCpyhsOklSM)
			{
				return 0;
			}
			if (mLsSkvuzWXPgogGPwKaerOTuIkZd != P_0.mLsSkvuzWXPgogGPwKaerOTuIkZd)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.HbgRExITcCMBiwDTjfQHeZlAnaETA == HbgRExITcCMBiwDTjfQHeZlAnaETA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo DOwpGpwkdVcZNeGinONwEXwoTxaB()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			rBsfcEtTfAOvWbtjnuFBgwZwBpLp(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			eFQWawBEJMtYTKUPUoHkAjnHDPeW(bridgedController);
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
			return new ControllerDisconnectedEventArgs(loHHVowCkLHpBENNfMXJhGXnWgRmA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void OxVgBozpbGZfrutAUHXRUKvDlQrO(bool[] P_0, int[] P_1)
		{
			if (MUynsGjcfMjTVDxfOHOouARUZNTK <= 0)
			{
				return;
			}
			switch (CRFxqiwqqGjyHzJwNpHehrifFRGc.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						GczFDefXcNOXUAnEqFpzjWaaMnZCA(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						GczFDefXcNOXUAnEqFpzjWaaMnZCA(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						wqhZHGjnAttMhDbXWDRelbxmDpDz(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void TvPoDaJMDpScjmwAgPGhYXzKnIhq(bool[] P_0, int[] P_1)
		{
			if (SUFeceTNdOupeRLaGwUuhxxAQUVi <= 0)
			{
				return;
			}
			switch (CRFxqiwqqGjyHzJwNpHehrifFRGc.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						nLxbcnKHsTktNjYXGTKCVINrfjZx(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						nLxbcnKHsTktNjYXGTKCVINrfjZx(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)CRFxqiwqqGjyHzJwNpHehrifFRGc.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						RZfAaUTlspmzfXSlSVUJNEltaYRO(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void GczFDefXcNOXUAnEqFpzjWaaMnZCA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= MUynsGjcfMjTVDxfOHOouARUZNTK)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			aIQzXxQcEKSCqkcvZshUNQrcOHKi[P_1] = DmVdxpyXzpckhJvSuhwQFzmMhfLPA(P_0, P_2, P_3);
			if (!LwPiTZjKmkedQdNZQVGgKmSwPvOI && aIQzXxQcEKSCqkcvZshUNQrcOHKi[P_1] != 0f)
			{
				LwPiTZjKmkedQdNZQVGgKmSwPvOI = true;
			}
		}

		private void nLxbcnKHsTktNjYXGTKCVINrfjZx(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= SUFeceTNdOupeRLaGwUuhxxAQUVi)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			yDRgUMFwQxcrdQfigSxfCkmRTKpJ[P_1] = ZwhjZzXderiXdjAdJNwxEzrkJQBE(P_0, P_2, P_3);
			if (!LwPiTZjKmkedQdNZQVGgKmSwPvOI && yDRgUMFwQxcrdQfigSxfCkmRTKpJ[P_1] != 0f)
			{
				LwPiTZjKmkedQdNZQVGgKmSwPvOI = true;
			}
		}

		private float DmVdxpyXzpckhJvSuhwQFzmMhfLPA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Axis axis))
						{
							return 0f;
						}
						num = axis.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				return tTErtXaISPzXsfeiRCCFMNpGcpqm((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QgcvHbBdmOcFellWhaBpJIfQWjoL || sourceButton >= 256)
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
				if (sourceHat < 0 || sourceHat >= YckIFyziCQcFqvzLxbCpyhsOklSM || sourceHat >= 4)
				{
					return 0f;
				}
				int num2 = P_2[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = sEvvLYbZopdLNzObYJwyRZjNTIJA(num2, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num3 = sEvvLYbZopdLNzObYJwyRZjNTIJA(num2, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num3 *= -1f;
				}
				return num3;
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && HDEUnDKgxCnjMhwawsZmXRVTiWCD(customCalculationSourceData[i], out var item))
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

		private float tTErtXaISPzXsfeiRCCFMNpGcpqm(RawInputAxis P_0, int P_1)
		{
			return BZieZiIQemsPNbtptWekuhVjFMTB((merKQxTNkYlBjIjmxHigSoyXKBKV as fliORgAWnNfkUHOriNcTSiLVhTfIA).dkiEOycbUxIqSCIWcDNwiLENHlMjb(P_0, P_1));
		}

		private float ZwhjZzXderiXdjAdJNwxEzrkJQBE(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
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
						if (!P_1[P_0.requiredButtons[j]])
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
				if (sourceButton < 0 || sourceButton >= QgcvHbBdmOcFellWhaBpJIfQWjoL || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Button button))
						{
							return 0f;
						}
						num = button.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				float num2 = tTErtXaISPzXsfeiRCCFMNpGcpqm((RawInputAxis)sourceAxis, num);
				float num3 = MathTools.Abs(num2);
				if (num3 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
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
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= YckIFyziCQcFqvzLxbCpyhsOklSM || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
						if (XhGWWRhDjZdNbgaPSPXtMhFZUABx(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (HDEUnDKgxCnjMhwawsZmXRVTiWCD(customCalculationSourceData[k], out var num4))
						{
							customCalculation.AddData((num4 != 0f) ? 1f : 0f);
						}
						break;
					}
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
				if ((float)customCalculation.Result == 0f)
				{
					return 0f;
				}
				return 1f;
			}
			return 0f;
		}

		private float BZieZiIQemsPNbtptWekuhVjFMTB(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float VkQhakhHssZWeqPUcXXYQVFgPaC(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (CRFxqiwqqGjyHzJwNpHehrifFRGc.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float sEvvLYbZopdLNzObYJwyRZjNTIJA(int P_0, AxisDirection P_1)
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

		private bool XhGWWRhDjZdNbgaPSPXtMhFZUABx(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= QgcvHbBdmOcFellWhaBpJIfQWjoL || sourceButton >= 256)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool HDEUnDKgxCnjMhwawsZmXRVTiWCD(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = tTErtXaISPzXsfeiRCCFMNpGcpqm((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
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

		private ControlDeviceType EYXKjWAuLFxyaWEzTckJbJPvtFtiA(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.Keyboard, 
				DeviceType.Joystick => ControlDeviceType.Joystick, 
				DeviceType.Gamepad => ControlDeviceType.Gamepad, 
				DeviceType.Mouse => ControlDeviceType.Mouse, 
				DeviceType.MultiAxisController => ControlDeviceType.Joystick, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void wqhZHGjnAttMhDbXWDRelbxmDpDz(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= MUynsGjcfMjTVDxfOHOouARUZNTK)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			aIQzXxQcEKSCqkcvZshUNQrcOHKi[P_1] = bRZiBMfLVpTWgrlJukSICDKqNMPU(P_0, P_2, P_3);
			if (!LwPiTZjKmkedQdNZQVGgKmSwPvOI && aIQzXxQcEKSCqkcvZshUNQrcOHKi[P_1] != 0f)
			{
				LwPiTZjKmkedQdNZQVGgKmSwPvOI = true;
			}
		}

		private void RZfAaUTlspmzfXSlSVUJNEltaYRO(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= SUFeceTNdOupeRLaGwUuhxxAQUVi)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			yDRgUMFwQxcrdQfigSxfCkmRTKpJ[P_1] = ShvLflHCpqfzvinfwKFrYMLFGKLY(P_0, P_2, P_3);
			if (!LwPiTZjKmkedQdNZQVGgKmSwPvOI && yDRgUMFwQxcrdQfigSxfCkmRTKpJ[P_1] != 0f)
			{
				LwPiTZjKmkedQdNZQVGgKmSwPvOI = true;
			}
		}

		private float bRZiBMfLVpTWgrlJukSICDKqNMPU(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= twarqJdHGKMHGMzosuZxbFIhbmEU || sourceAxis >= 56)
				{
					return 0f;
				}
				return QQdvFOzOiLwGgIAMGdPuJxTuyxHmA(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QgcvHbBdmOcFellWhaBpJIfQWjoL || sourceButton >= 256)
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
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= YckIFyziCQcFqvzLxbCpyhsOklSM || sourceHat >= 4)
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
					num2 = sEvvLYbZopdLNzObYJwyRZjNTIJA(num, AxisDirection.Horizontal);
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
					num2 = sEvvLYbZopdLNzObYJwyRZjNTIJA(num, AxisDirection.Vertical);
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

		private float QQdvFOzOiLwGgIAMGdPuJxTuyxHmA(int P_0)
		{
			return (merKQxTNkYlBjIjmxHigSoyXKBKV as qOWNeWiQdvONIuaeCdEikuUBUJEl).FEwzcuOSWJbRpUsfxTtQBSrREWUG(P_0);
		}

		private float ShvLflHCpqfzvinfwKFrYMLFGKLY(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QgcvHbBdmOcFellWhaBpJIfQWjoL || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= twarqJdHGKMHGMzosuZxbFIhbmEU || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = QQdvFOzOiLwGgIAMGdPuJxTuyxHmA(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
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
				return 1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= YckIFyziCQcFqvzLxbCpyhsOklSM || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return VkQhakhHssZWeqPUcXXYQVFgPaC(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private bool ANNGyJmTuIbZhOMCRbethcfYOHuf(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
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

		private float kUTbJVpQLDWvYbfeOngwoxAbxtGW(int P_0, AxisDirection P_1)
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

		private void SneEAnmSBilkAQVUSzORzhdiBdnA()
		{
			CRFxqiwqqGjyHzJwNpHehrifFRGc = IhxjOupVqxIiDfVoPVhaanzEqgZR(DOwpGpwkdVcZNeGinONwEXwoTxaB());
			if (CRFxqiwqqGjyHzJwNpHehrifFRGc == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			MUynsGjcfMjTVDxfOHOouARUZNTK = CRFxqiwqqGjyHzJwNpHehrifFRGc.axisCount;
			SUFeceTNdOupeRLaGwUuhxxAQUVi = CRFxqiwqqGjyHzJwNpHehrifFRGc.buttonCount;
		}

		private string GtAAfWDHsYjqTBTPzsMvvXcaqLyT()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.hcMjwYYUDThlaovzHzjEosTJeDVU, (MKBEhyIOZEbyPleVzQVmQplSfQbS && !string.IsNullOrEmpty(XiAHOVgMbVAEubcqpSniKMFrGIUFA)) ? XiAHOVgMbVAEubcqpSniKMFrGIUFA : wfuVmdrtjPuvnZHykcsyehCpHJdnA, LZvfHXfmnqYDCJUKIrgjKcqITbon.ToString("X4"), CBUcBGCeQHuIwkwlSmaKpKAFmQuV.ToString("X4")));
		}

		private void rBsfcEtTfAOvWbtjnuFBgwZwBpLp(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.hcMjwYYUDThlaovzHzjEosTJeDVU;
			P_0.deviceType = EYXKjWAuLFxyaWEzTckJbJPvtFtiA(ebsyRBLhQXTXWcGWbVVChgTrGEwK);
			P_0.hardwareIdentifier = GtAAfWDHsYjqTBTPzsMvvXcaqLyT();
			P_0.hardwareAxisCount = twarqJdHGKMHGMzosuZxbFIhbmEU;
			P_0.hardwareButtonCount = QgcvHbBdmOcFellWhaBpJIfQWjoL;
			P_0.hardwareHatCount = YckIFyziCQcFqvzLxbCpyhsOklSM;
			P_0.hw_productName = wfuVmdrtjPuvnZHykcsyehCpHJdnA;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_vendorId = CBUcBGCeQHuIwkwlSmaKpKAFmQuV;
			P_0.hw_productId = LZvfHXfmnqYDCJUKIrgjKcqITbon;
			P_0.hw_pidVid = new PidVid(HHyRwCpdPYMrztfjuTRDvcXEDLVhA);
			P_0.hw_isBluetoothDevice = MKBEhyIOZEbyPleVzQVmQplSfQbS;
			P_0.hw_bluetoothDeviceName = XiAHOVgMbVAEubcqpSniKMFrGIUFA;
			P_0.hw_supportsVibration = bohNIInnsduaDMgKLDMCmxIRelbJA;
			P_0.hw_localVibrationMotorCount = HPuGTptdSLCboClcDtjIfCtfZFTbA;
			P_0.definitionMatchTag = UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.WGVcseBuHNOxlhHmrKTuEgZVlKQjA;
		}

		private void eFQWawBEJMtYTKUPUoHkAjnHDPeW(BridgedController P_0)
		{
			rBsfcEtTfAOvWbtjnuFBgwZwBpLp(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = CRFxqiwqqGjyHzJwNpHehrifFRGc.ToGameHardwareControllerMap();
			P_0.instanceName = UAGxtKsNjtdJAbJDZBNbkoGSvvsm;
			P_0.productName = wfuVmdrtjPuvnZHykcsyehCpHJdnA;
			P_0.isXInputDevice = CLiDYQYjBAJnBtAasPrFLLQxCJPR;
			P_0.axisCount = MUynsGjcfMjTVDxfOHOouARUZNTK;
			P_0.buttonCount = SUFeceTNdOupeRLaGwUuhxxAQUVi;
			P_0.isButtonPressureSensitive = new bool[SUFeceTNdOupeRLaGwUuhxxAQUVi];
			Array.Copy(nFSdjJiacSdeBHAfdHyPrRFCmJhRB, P_0.isButtonPressureSensitive, SUFeceTNdOupeRLaGwUuhxxAQUVi);
			P_0.unknownControllerHats = XBKYCACOoiEYDfTkrEZqxYnJRqhEA();
			P_0.controllerTypeGuid = QHKJRpTNJBnSVmWdIgCGlJRIatho;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void sMLfcFbcejTbpktSvAeejzMbWkobB()
		{
			for (int i = 0; i < SUFeceTNdOupeRLaGwUuhxxAQUVi; i++)
			{
				yDRgUMFwQxcrdQfigSxfCkmRTKpJ[i] = 0f;
			}
			for (int j = 0; j < MUynsGjcfMjTVDxfOHOouARUZNTK; j++)
			{
				aIQzXxQcEKSCqkcvZshUNQrcOHKi[j] = 0f;
			}
		}

		private UnknownControllerHat[] XBKYCACOoiEYDfTkrEZqxYnJRqhEA()
		{
			if (!gLhgsrwaayhOWEjkzKkMHvWWzEawA)
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

		private void qxEcYzcJHiOgwVLpofimeONFIzxgc(HIDDeviceDriver.DnxCacaTXSZEpeSgtDxoenPsQrOsA P_0)
		{
			if (HIDDeviceDriver.IsCriticalError(P_0))
			{
				this.CBufRacrRUhYIckLGeVRVhPQkLAnB?.Invoke();
			}
		}

		private void CTqAnzbAtmjioEKqvuDKLChQHqAd()
		{
			bool flag = BzZEZTdAcehOuljgNMiquJOwDdYwA;
			CUPQRqvBAjieNwkFBUunypCmsGNM = true;
			MZCpCBPwqEIKHjbTofaErhbVjHmBA(flag);
		}

		private void MZCpCBPwqEIKHjbTofaErhbVjHmBA(bool P_0)
		{
			if (P_0 != BzZEZTdAcehOuljgNMiquJOwDdYwA)
			{
				this.TrIEZGxGKaeadlvheRFelQcwhENP?.Invoke(BzZEZTdAcehOuljgNMiquJOwDdYwA);
			}
		}

		public void ezaBXmgFDFqkDcAZhNADXZDqqWSNb()
		{
			lEiDJSNSxsVClQZzSLwlCpbKrLgu(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void QuXITXcFRFqvxpAKDFamkLlClQbg()
		{
			try
			{
				lEiDJSNSxsVClQZzSLwlCpbKrLgu(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void lEiDJSNSxsVClQZzSLwlCpbKrLgu(bool P_0)
		{
			if (!TlhAVrdDUitAjidfqFRFPtGrjiAzA)
			{
				if (P_0 && UCdyxjrbqNKoGqjrqfmYkvAZbKTBA != null && UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.EsivdIFkKegfviNHPBmLeAzWGwWCb != null)
				{
					UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.EsivdIFkKegfviNHPBmLeAzWGwWCb.ErrorEvent -= qxEcYzcJHiOgwVLpofimeONFIzxgc;
					UCdyxjrbqNKoGqjrqfmYkvAZbKTBA.EsivdIFkKegfviNHPBmLeAzWGwWCb.InitializedEvent -= CTqAnzbAtmjioEKqvuDKLChQHqAd;
				}
				TlhAVrdDUitAjidfqFRFPtGrjiAzA = true;
			}
		}

		public static int VkBILeCeWHoFHomeintkcFEITwUO(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, tcOIEORCozOZGnGHlBBtbFyLFlxY P_1)
		{
			if (P_0.NNacwALtNcxfpZUUTFDaSgRAcotv < P_1.NNacwALtNcxfpZUUTFDaSgRAcotv)
			{
				return -1;
			}
			if (P_0.NNacwALtNcxfpZUUTFDaSgRAcotv > P_1.NNacwALtNcxfpZUUTFDaSgRAcotv)
			{
				return 1;
			}
			return 0;
		}

		public static int KIGPYrwBkUSUlzrWWVWLAyvZGqge(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, tcOIEORCozOZGnGHlBBtbFyLFlxY P_1)
		{
			if (P_0.pezbeIyrFIhXmrTcgcvdBLxkUyNv < P_1.pezbeIyrFIhXmrTcgcvdBLxkUyNv)
			{
				return -1;
			}
			if (P_0.pezbeIyrFIhXmrTcgcvdBLxkUyNv > P_1.pezbeIyrFIhXmrTcgcvdBLxkUyNv)
			{
				return 1;
			}
			return 0;
		}
	}

	private class JPUoLKKeichBXITUOfRUYnPAvXZbA
	{
		public enum vcFQhQeuGhxTlXcBMgLYsFWWEAmO
		{
			Exact = 0,
			Approximate = 1
		}

		public class vxICUPnDSEcAYmdAPRenNKhHOESE
		{
			public int AKGdpFjUqixiDTSRpNIFgBnQqFLab;

			public Guid UHdFkrWSWabcXpnNbOwYQCnLWOrp;

			public Guid vhpQokMDGOgAFUssmRwcYRMLdnpd;

			public int eNjjznmfCzetpCEeFCXYaTcBQNso;

			public int NqnUnpfOstXZIjBhwGJMqpHVDerbA;

			public int lWmBEVFoPonaRuoFIddQLMPSWLil;

			public int kxtPNsZejjIEtNQzjKTyYnZSuLyh;

			public int UaVFZKmIMTcjBDpPcxMDTSFkeFeN;

			public int fGaFRFjGpMmQsdZwHwlDbyXgjSrC;

			public bool ZKeeJcBoixpVOWNQORsVNRAUltTK;

			public bool VisepBEJDisufYNYdEbHssWWDKgwA(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, vcFQhQeuGhxTlXcBMgLYsFWWEAmO P_1)
			{
				if (NqnUnpfOstXZIjBhwGJMqpHVDerbA != P_0.twarqJdHGKMHGMzosuZxbFIhbmEU)
				{
					return false;
				}
				if (lWmBEVFoPonaRuoFIddQLMPSWLil != P_0.QgcvHbBdmOcFellWhaBpJIfQWjoL)
				{
					return false;
				}
				if (kxtPNsZejjIEtNQzjKTyYnZSuLyh != P_0.YckIFyziCQcFqvzLxbCpyhsOklSM)
				{
					return false;
				}
				if (UaVFZKmIMTcjBDpPcxMDTSFkeFeN != P_0.SUFeceTNdOupeRLaGwUuhxxAQUVi)
				{
					return false;
				}
				if (fGaFRFjGpMmQsdZwHwlDbyXgjSrC != P_0.MUynsGjcfMjTVDxfOHOouARUZNTK)
				{
					return false;
				}
				if (ZKeeJcBoixpVOWNQORsVNRAUltTK != P_0.mLsSkvuzWXPgogGPwKaerOTuIkZd)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == AKGdpFjUqixiDTSRpNIFgBnQqFLab)
				{
					return true;
				}
				return P_1 switch
				{
					vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Exact => UHdFkrWSWabcXpnNbOwYQCnLWOrp == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Approximate => vhpQokMDGOgAFUssmRwcYRMLdnpd == P_0.HbgRExITcCMBiwDTjfQHeZlAnaETA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string kXjhDhPoKMfrbKeWoccXhnTCCEPMB()
			{
				string text = "" + "rewiredId = " + AKGdpFjUqixiDTSRpNIFgBnQqFLab + "\n";
				Guid uHdFkrWSWabcXpnNbOwYQCnLWOrp = UHdFkrWSWabcXpnNbOwYQCnLWOrp;
				string text2 = text + "instanceGuid = " + uHdFkrWSWabcXpnNbOwYQCnLWOrp.ToString() + "\n";
				uHdFkrWSWabcXpnNbOwYQCnLWOrp = vhpQokMDGOgAFUssmRwcYRMLdnpd;
				return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + uHdFkrWSWabcXpnNbOwYQCnLWOrp.ToString() + "\n", "lastInputManagerId = ", eNjjznmfCzetpCEeFCXYaTcBQNso.ToString(), "\n"), "hardwareAxisCount = ", NqnUnpfOstXZIjBhwGJMqpHVDerbA.ToString(), "\n"), "hardwareButtonCount = ", lWmBEVFoPonaRuoFIddQLMPSWLil.ToString(), "\n"), "hardwareHatCount = ", kxtPNsZejjIEtNQzjKTyYnZSuLyh.ToString(), "\n"), "gameButtonCount = ", UaVFZKmIMTcjBDpPcxMDTSFkeFeN.ToString(), "\n"), "gameAxisCount = ", fGaFRFjGpMmQsdZwHwlDbyXgjSrC.ToString(), "\n"), "hasDriver = ", ZKeeJcBoixpVOWNQORsVNRAUltTK.ToString(), "\n");
			}
		}

		private sealed class piQytVknsFgpXJdZHMdqyLewbuyDA : IEnumerable<vxICUPnDSEcAYmdAPRenNKhHOESE>, IEnumerable, IEnumerator<vxICUPnDSEcAYmdAPRenNKhHOESE>, IEnumerator, IDisposable
		{
			private int XxiLwZLJKMRPYnqwnPgfWqgJrDyu;

			private vxICUPnDSEcAYmdAPRenNKhHOESE onnzfFyRwCOSBDPAnsqwLAXOSLvL;

			private int UGhYFQSGSULTtXBnJrXiZAcVhwMv;

			public JPUoLKKeichBXITUOfRUYnPAvXZbA nljBeftYjambsEXPfkGJMiuEoqEh;

			private tcOIEORCozOZGnGHlBBtbFyLFlxY LrTNmcApWbHwDvQxitFSbpkJGbTgA;

			public tcOIEORCozOZGnGHlBBtbFyLFlxY tJOCGzqHxCodOsEXurNAqgttetLl;

			private vcFQhQeuGhxTlXcBMgLYsFWWEAmO MpfgzPZmtyZfFbKTCJvEfWWFndXu;

			public vcFQhQeuGhxTlXcBMgLYsFWWEAmO xbUvDGfMwbQmtQgjDyKYURMUqagC;

			private int unMKFgqIotidEYhmHRSUCecENtOf;

			private int KUagXAchrWFKoZClwUfcAfIgOshEb;

			vxICUPnDSEcAYmdAPRenNKhHOESE IEnumerator<vxICUPnDSEcAYmdAPRenNKhHOESE>.Current
			{
				[DebuggerHidden]
				get
				{
					return onnzfFyRwCOSBDPAnsqwLAXOSLvL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return onnzfFyRwCOSBDPAnsqwLAXOSLvL;
				}
			}

			[DebuggerHidden]
			public piQytVknsFgpXJdZHMdqyLewbuyDA(int P_0)
			{
				XxiLwZLJKMRPYnqwnPgfWqgJrDyu = P_0;
				UGhYFQSGSULTtXBnJrXiZAcVhwMv = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				XxiLwZLJKMRPYnqwnPgfWqgJrDyu = -2;
			}

			private bool MoveNext()
			{
				int xxiLwZLJKMRPYnqwnPgfWqgJrDyu = XxiLwZLJKMRPYnqwnPgfWqgJrDyu;
				JPUoLKKeichBXITUOfRUYnPAvXZbA jPUoLKKeichBXITUOfRUYnPAvXZbA = nljBeftYjambsEXPfkGJMiuEoqEh;
				if (xxiLwZLJKMRPYnqwnPgfWqgJrDyu != 0)
				{
					if (xxiLwZLJKMRPYnqwnPgfWqgJrDyu != 1)
					{
						return false;
					}
					XxiLwZLJKMRPYnqwnPgfWqgJrDyu = -1;
					goto IL_0083;
				}
				XxiLwZLJKMRPYnqwnPgfWqgJrDyu = -1;
				unMKFgqIotidEYhmHRSUCecENtOf = jPUoLKKeichBXITUOfRUYnPAvXZbA.OUnemfTlUGMLAIWHsSHpSelYTvMu.Count;
				KUagXAchrWFKoZClwUfcAfIgOshEb = 0;
				goto IL_0093;
				IL_0083:
				KUagXAchrWFKoZClwUfcAfIgOshEb++;
				goto IL_0093;
				IL_0093:
				if (KUagXAchrWFKoZClwUfcAfIgOshEb < unMKFgqIotidEYhmHRSUCecENtOf)
				{
					if (jPUoLKKeichBXITUOfRUYnPAvXZbA.OUnemfTlUGMLAIWHsSHpSelYTvMu[KUagXAchrWFKoZClwUfcAfIgOshEb].VisepBEJDisufYNYdEbHssWWDKgwA(LrTNmcApWbHwDvQxitFSbpkJGbTgA, MpfgzPZmtyZfFbKTCJvEfWWFndXu))
					{
						onnzfFyRwCOSBDPAnsqwLAXOSLvL = jPUoLKKeichBXITUOfRUYnPAvXZbA.OUnemfTlUGMLAIWHsSHpSelYTvMu[KUagXAchrWFKoZClwUfcAfIgOshEb];
						XxiLwZLJKMRPYnqwnPgfWqgJrDyu = 1;
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
			IEnumerator<vxICUPnDSEcAYmdAPRenNKhHOESE> IEnumerable<vxICUPnDSEcAYmdAPRenNKhHOESE>.GetEnumerator()
			{
				piQytVknsFgpXJdZHMdqyLewbuyDA piQytVknsFgpXJdZHMdqyLewbuyDA2;
				if (XxiLwZLJKMRPYnqwnPgfWqgJrDyu == -2 && UGhYFQSGSULTtXBnJrXiZAcVhwMv == Environment.CurrentManagedThreadId)
				{
					XxiLwZLJKMRPYnqwnPgfWqgJrDyu = 0;
					piQytVknsFgpXJdZHMdqyLewbuyDA2 = this;
				}
				else
				{
					piQytVknsFgpXJdZHMdqyLewbuyDA2 = new piQytVknsFgpXJdZHMdqyLewbuyDA(0);
					piQytVknsFgpXJdZHMdqyLewbuyDA2.nljBeftYjambsEXPfkGJMiuEoqEh = nljBeftYjambsEXPfkGJMiuEoqEh;
				}
				piQytVknsFgpXJdZHMdqyLewbuyDA2.LrTNmcApWbHwDvQxitFSbpkJGbTgA = tJOCGzqHxCodOsEXurNAqgttetLl;
				piQytVknsFgpXJdZHMdqyLewbuyDA2.MpfgzPZmtyZfFbKTCJvEfWWFndXu = xbUvDGfMwbQmtQgjDyKYURMUqagC;
				return piQytVknsFgpXJdZHMdqyLewbuyDA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<vxICUPnDSEcAYmdAPRenNKhHOESE>)this).GetEnumerator();
			}
		}

		private List<vxICUPnDSEcAYmdAPRenNKhHOESE> OUnemfTlUGMLAIWHsSHpSelYTvMu;

		public JPUoLKKeichBXITUOfRUYnPAvXZbA()
		{
			OUnemfTlUGMLAIWHsSHpSelYTvMu = new List<vxICUPnDSEcAYmdAPRenNKhHOESE>();
		}

		public void vVLQlaYHGFeSKkPdOSyHDvMVWGPgb(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = OUnemfTlUGMLAIWHsSHpSelYTvMu.Count;
			for (int i = 0; i < count; i++)
			{
				if (OUnemfTlUGMLAIWHsSHpSelYTvMu[i].VisepBEJDisufYNYdEbHssWWDKgwA(P_0, vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Exact))
				{
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].AKGdpFjUqixiDTSRpNIFgBnQqFLab = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].UHdFkrWSWabcXpnNbOwYQCnLWOrp = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].vhpQokMDGOgAFUssmRwcYRMLdnpd = P_0.HbgRExITcCMBiwDTjfQHeZlAnaETA;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].eNjjznmfCzetpCEeFCXYaTcBQNso = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].NqnUnpfOstXZIjBhwGJMqpHVDerbA = P_0.twarqJdHGKMHGMzosuZxbFIhbmEU;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].lWmBEVFoPonaRuoFIddQLMPSWLil = P_0.QgcvHbBdmOcFellWhaBpJIfQWjoL;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].kxtPNsZejjIEtNQzjKTyYnZSuLyh = P_0.YckIFyziCQcFqvzLxbCpyhsOklSM;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].UaVFZKmIMTcjBDpPcxMDTSFkeFeN = P_0.SUFeceTNdOupeRLaGwUuhxxAQUVi;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].fGaFRFjGpMmQsdZwHwlDbyXgjSrC = P_0.MUynsGjcfMjTVDxfOHOouARUZNTK;
					OUnemfTlUGMLAIWHsSHpSelYTvMu[i].ZKeeJcBoixpVOWNQORsVNRAUltTK = P_0.mLsSkvuzWXPgogGPwKaerOTuIkZd;
					SlGBPYciutvgGaIkAQyRxRJdVSOt(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			OUnemfTlUGMLAIWHsSHpSelYTvMu.Add(new vxICUPnDSEcAYmdAPRenNKhHOESE
			{
				AKGdpFjUqixiDTSRpNIFgBnQqFLab = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				UHdFkrWSWabcXpnNbOwYQCnLWOrp = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				vhpQokMDGOgAFUssmRwcYRMLdnpd = P_0.HbgRExITcCMBiwDTjfQHeZlAnaETA,
				eNjjznmfCzetpCEeFCXYaTcBQNso = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				NqnUnpfOstXZIjBhwGJMqpHVDerbA = P_0.twarqJdHGKMHGMzosuZxbFIhbmEU,
				lWmBEVFoPonaRuoFIddQLMPSWLil = P_0.QgcvHbBdmOcFellWhaBpJIfQWjoL,
				kxtPNsZejjIEtNQzjKTyYnZSuLyh = P_0.YckIFyziCQcFqvzLxbCpyhsOklSM,
				UaVFZKmIMTcjBDpPcxMDTSFkeFeN = P_0.SUFeceTNdOupeRLaGwUuhxxAQUVi,
				fGaFRFjGpMmQsdZwHwlDbyXgjSrC = P_0.MUynsGjcfMjTVDxfOHOouARUZNTK,
				ZKeeJcBoixpVOWNQORsVNRAUltTK = P_0.mLsSkvuzWXPgogGPwKaerOTuIkZd
			});
			SlGBPYciutvgGaIkAQyRxRJdVSOt(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, OUnemfTlUGMLAIWHsSHpSelYTvMu.Count - 1);
		}

		public bool WNqBpwHGktDfuiHgeYIhukSLqyde(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, vcFQhQeuGhxTlXcBMgLYsFWWEAmO P_1)
		{
			int count = OUnemfTlUGMLAIWHsSHpSelYTvMu.Count;
			for (int i = 0; i < count; i++)
			{
				if (OUnemfTlUGMLAIWHsSHpSelYTvMu[i].VisepBEJDisufYNYdEbHssWWDKgwA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(piQytVknsFgpXJdZHMdqyLewbuyDA))]
		public IEnumerable<vxICUPnDSEcAYmdAPRenNKhHOESE> yHyTpFngdXdEvHtXJHoRIjBRpuYWA(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, vcFQhQeuGhxTlXcBMgLYsFWWEAmO P_1)
		{
			return new piQytVknsFgpXJdZHMdqyLewbuyDA(-2)
			{
				nljBeftYjambsEXPfkGJMiuEoqEh = this,
				tJOCGzqHxCodOsEXurNAqgttetLl = P_0,
				xbUvDGfMwbQmtQgjDyKYURMUqagC = P_1
			};
		}

		private void SlGBPYciutvgGaIkAQyRxRJdVSOt(int P_0, Guid P_1, int P_2)
		{
			for (int num = OUnemfTlUGMLAIWHsSHpSelYTvMu.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (OUnemfTlUGMLAIWHsSHpSelYTvMu[num].AKGdpFjUqixiDTSRpNIFgBnQqFLab == P_0 || OUnemfTlUGMLAIWHsSHpSelYTvMu[num].UHdFkrWSWabcXpnNbOwYQCnLWOrp == P_1))
				{
					OUnemfTlUGMLAIWHsSHpSelYTvMu.RemoveAt(num);
				}
			}
		}

		public virtual string VfVZrRPdcHAqPQmPlCtzEDlxnWZl()
		{
			string text = "";
			text = text + "Joystick records: " + OUnemfTlUGMLAIWHsSHpSelYTvMu.Count + "\n";
			for (int i = 0; i < OUnemfTlUGMLAIWHsSHpSelYTvMu.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + OUnemfTlUGMLAIWHsSHpSelYTvMu[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private struct qrSAODhmoGfjsOJCHQDHhiMAHpGyA
	{
		public tcOIEORCozOZGnGHlBBtbFyLFlxY HIfBYkcoHFdSFaGHdbtLpPhOVMDqc;

		public bool dpOvMrNeYBfymRcVlmcYEqbNLsfI;

		public qrSAODhmoGfjsOJCHQDHhiMAHpGyA(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, bool P_1)
		{
			HIfBYkcoHFdSFaGHdbtLpPhOVMDqc = P_0;
			dpOvMrNeYBfymRcVlmcYEqbNLsfI = P_1;
		}
	}

	private sealed class TxauYJUxripoULEjacoOoohpSPzn
	{
		public tcOIEORCozOZGnGHlBBtbFyLFlxY UkxTtnMRRfgZjZWuwKmFZnduvVqS;

		public dxtTGgzBQXNrKPngRZEZyZBogkbP MLCxIBPmvKnnrIkpvAlVVifsJJBX;

		internal void xVaZAMXNLozHbqArsAGLSrmUvZOj(bool P_0)
		{
			MLCxIBPmvKnnrIkpvAlVVifsJJBX.eRuFfpvybxpaOFqQCgPWbPNeOcdGA(UkxTtnMRRfgZjZWuwKmFZnduvVqS, P_0);
		}
	}

	private BqakktYRwNvnDKTTjDQXbTstkBmA GeapBAebWtCuAFudbOlXPGnNuBKJA;

	private List<tcOIEORCozOZGnGHlBBtbFyLFlxY> OpcDfyZXHcKjlAfCsKvXqFsGAjZm;

	private int zRyfIZskZPXCyqvbsIoZkYSghMAE;

	private JPUoLKKeichBXITUOfRUYnPAvXZbA cXboOkqHpOxpsbYzbjmAFCjoAooz;

	private bool ZcQyxPvDlEAlThEUkcyTrhJbublrA;

	private TimerRealTime imCGfrNaCUTccCnlwDrUUdEENElv;

	private global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool> gRXoLUThVPENEbgbjQPnkTukwhhH;

	private global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool> mAHZHmfzioNSqcxZfgHRditVRsJK;

	private int emEjWwksqJEaohvyLfBcstmwPrHQ;

	private int gqcBNHkHBZODUMLSSHSFdcRabcOOc;

	private readonly Queue<qrSAODhmoGfjsOJCHQDHhiMAHpGyA> lOftYzlYKCXAuHJfuAQEqFvZEIFr;

	private ConfigVars TTakdEpiRmmvmAVuqPvQsrchzTrD;

	private AHuLsFUDywwjZMRMOCnliKJcVPho bWeHbNTMIKTDjfmMFJcAQLPviUwEA;

	private Action<int, ControllerDataUpdater> AHngrHBpjhWjPtftPLNVQabgGoxiA;

	private PlatformInputManager EjmitdrjXWorWUgDGVedBAdotiFX;

	private readonly wumjSNCZpiDBQIOgHXuMVdOhecvz LlZpWlwTjJRfwQMgnIFgnEtuxqgT;

	private readonly gnWOnWzmgxFJvyBjJGkrgQPpkQDO NfmRgGQNsqqxZjAGljQFaGfnVZmrA;

	private readonly bool RcVuEnAPgIznXAZiAxLhOAxdEEdcA;

	private readonly bool ecgbaxnBeDZbODUGQSeyUgTiWuiB;

	private readonly bool fnTdDIaeqInTEXGSNLKdfJjeoSnGc;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> OIkdxnFDbAGTTulmAsKtbUCogSBD;

	private readonly Func<int> eOBmMyPJeLLthOIfvDaawrXIfJGi;

	AHuLsFUDywwjZMRMOCnliKJcVPho EvYpgWgAiaVrxrmiqwIIXwlPQUow.NJWtNkjjVIKTPZjQTKdnhkrQFscK
	{
		get
		{
			return bWeHbNTMIKTDjfmMFJcAQLPviUwEA;
		}
		set
		{
			NJWtNkjjVIKTPZjQTKdnhkrQFscK = aHuLsFUDywwjZMRMOCnliKJcVPho;
			GeapBAebWtCuAFudbOlXPGnNuBKJA.JRZeTJdnkgzWRCPjWbgXFAQNzZtj = aHuLsFUDywwjZMRMOCnliKJcVPho;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => zRyfIZskZPXCyqvbsIoZkYSghMAE;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => EjmitdrjXWorWUgDGVedBAdotiFX;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => GeapBAebWtCuAFudbOlXPGnNuBKJA;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.RawInput;

	public dxtTGgzBQXNrKPngRZEZyZBogkbP(ConfigVars P_0, AHuLsFUDywwjZMRMOCnliKJcVPho P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, bool P_4, bool P_5, bool P_6, bool P_7)
	{
		try
		{
			TTakdEpiRmmvmAVuqPvQsrchzTrD = P_0;
			bWeHbNTMIKTDjfmMFJcAQLPviUwEA = P_1;
			OIkdxnFDbAGTTulmAsKtbUCogSBD = P_2;
			eOBmMyPJeLLthOIfvDaawrXIfJGi = P_3;
			RcVuEnAPgIznXAZiAxLhOAxdEEdcA = P_4;
			ecgbaxnBeDZbODUGQSeyUgTiWuiB = P_5;
			fnTdDIaeqInTEXGSNLKdfJjeoSnGc = P_6;
			EjmitdrjXWorWUgDGVedBAdotiFX = this;
			UpdateLoopSetting updateLoop = P_0.updateLoop;
			if (P_6)
			{
				NfmRgGQNsqqxZjAGljQFaGfnVZmrA = new gnWOnWzmgxFJvyBjJGkrgQPpkQDO(updateLoop);
			}
			if (P_5)
			{
				LlZpWlwTjJRfwQMgnIFgnEtuxqgT = new wumjSNCZpiDBQIOgHXuMVdOhecvz(updateLoop);
			}
			GeapBAebWtCuAFudbOlXPGnNuBKJA = new BqakktYRwNvnDKTTjDQXbTstkBmA(P_0, P_1, P_4, P_7, LlZpWlwTjJRfwQMgnIFgnEtuxqgT, NfmRgGQNsqqxZjAGljQFaGfnVZmrA);
			AHngrHBpjhWjPtftPLNVQabgGoxiA = UpdateControllerData;
			gRXoLUThVPENEbgbjQPnkTukwhhH = new global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool>(true, mKDeFtsJcIfpsFrcQMWsinapJUIbA);
			mAHZHmfzioNSqcxZfgHRditVRsJK = new global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool>(true, GeapBAebWtCuAFudbOlXPGnNuBKJA.YCNUTXhXEbmbEbrpVctUSvCBirNt);
			lOftYzlYKCXAuHJfuAQEqFvZEIFr = new Queue<qrSAODhmoGfjsOJCHQDHhiMAHpGyA>();
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
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA || GeapBAebWtCuAFudbOlXPGnNuBKJA.uWmnGvNFeOKDkakgoEEdlNhWUueY)
		{
			imCGfrNaCUTccCnlwDrUUdEENElv = new TimerRealTime(1.0);
			imCGfrNaCUTccCnlwDrUUdEENElv.Start();
		}
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA)
		{
			cXboOkqHpOxpsbYzbjmAFCjoAooz = new JPUoLKKeichBXITUOfRUYnPAvXZbA();
			aPzOTuyBbVSGQKpqYIVlaZElnjSp();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA || GeapBAebWtCuAFudbOlXPGnNuBKJA.uWmnGvNFeOKDkakgoEEdlNhWUueY)
		{
			NUxddpmJQcGphrxwNvnlPtQOOBrE();
		}
		if (GeapBAebWtCuAFudbOlXPGnNuBKJA != null)
		{
			GeapBAebWtCuAFudbOlXPGnNuBKJA.Update();
		}
		oHlYfZaiVDlhPcuemdIWgKTkCAUHA();
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA)
		{
			if (GeapBAebWtCuAFudbOlXPGnNuBKJA != null)
			{
				GeapBAebWtCuAFudbOlXPGnNuBKJA.UpdateDevices(updateLoop);
			}
			YRdGzINBtwvZTNeSHlxYFXDRfaVP();
			if (GeapBAebWtCuAFudbOlXPGnNuBKJA != null)
			{
				GeapBAebWtCuAFudbOlXPGnNuBKJA.UpdateFinished();
			}
		}
		if (ecgbaxnBeDZbODUGQSeyUgTiWuiB)
		{
			LlZpWlwTjJRfwQMgnIFgnEtuxqgT.skwNgQPHpQzSxlaATGqBBCDfxaVH(updateLoop);
		}
		if (fnTdDIaeqInTEXGSNLKdfJjeoSnGc)
		{
			NfmRgGQNsqqxZjAGljQFaGfnVZmrA.QFolINQnnncNzFWuYVgnuUAazhxv(updateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (mAHZHmfzioNSqcxZfgHRditVRsJK != null)
		{
			mAHZHmfzioNSqcxZfgHRditVRsJK.VshDPveQjVqQFgogDGildcmcWyJLc();
		}
		if (gRXoLUThVPENEbgbjQPnkTukwhhH != null)
		{
			gRXoLUThVPENEbgbjQPnkTukwhhH.VshDPveQjVqQFgogDGildcmcWyJLc();
		}
		if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm != null)
		{
			int count = OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Count;
			for (int i = 0; i < count; i++)
			{
				if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i] != null)
				{
					OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i].ezaBXmgFDFqkDcAZhNADXZDqqWSNb();
				}
			}
		}
		if (NfmRgGQNsqqxZjAGljQFaGfnVZmrA != null)
		{
			NfmRgGQNsqqxZjAGljQFaGfnVZmrA.Dispose();
		}
		if (LlZpWlwTjJRfwQMgnIFgnEtuxqgT != null)
		{
			LlZpWlwTjJRfwQMgnIFgnEtuxqgT.Dispose();
		}
		if (GeapBAebWtCuAFudbOlXPGnNuBKJA != null)
		{
			GeapBAebWtCuAFudbOlXPGnNuBKJA.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return AHngrHBpjhWjPtftPLNVQabgGoxiA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!RcVuEnAPgIznXAZiAxLhOAxdEEdcA)
		{
			return;
		}
		for (int i = 0; i < zRyfIZskZPXCyqvbsIoZkYSghMAE; i++)
		{
			if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		GeapBAebWtCuAFudbOlXPGnNuBKJA.SystemDeviceConnected();
		ZcQyxPvDlEAlThEUkcyTrhJbublrA = true;
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA || GeapBAebWtCuAFudbOlXPGnNuBKJA.uWmnGvNFeOKDkakgoEEdlNhWUueY)
		{
			imCGfrNaCUTccCnlwDrUUdEENElv.Start();
		}
		if (fnTdDIaeqInTEXGSNLKdfJjeoSnGc)
		{
			NfmRgGQNsqqxZjAGljQFaGfnVZmrA.dpcLiTAkZVaACZQgQMXnzDcIJEXG(true);
		}
		if (ecgbaxnBeDZbODUGQSeyUgTiWuiB)
		{
			LlZpWlwTjJRfwQMgnIFgnEtuxqgT.cxJYvOAvssABidjLnGGCUgIvwDzq(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		GeapBAebWtCuAFudbOlXPGnNuBKJA.SystemDeviceDisconnected();
		ZcQyxPvDlEAlThEUkcyTrhJbublrA = true;
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA || GeapBAebWtCuAFudbOlXPGnNuBKJA.uWmnGvNFeOKDkakgoEEdlNhWUueY)
		{
			imCGfrNaCUTccCnlwDrUUdEENElv.Start();
		}
		if (fnTdDIaeqInTEXGSNLKdfJjeoSnGc)
		{
			NfmRgGQNsqqxZjAGljQFaGfnVZmrA.dpcLiTAkZVaACZQgQMXnzDcIJEXG(false);
		}
		if (ecgbaxnBeDZbODUGQSeyUgTiWuiB)
		{
			LlZpWlwTjJRfwQMgnIFgnEtuxqgT.cxJYvOAvssABidjLnGGCUgIvwDzq(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = RcVuEnAPgIznXAZiAxLhOAxdEEdcA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return LlZpWlwTjJRfwQMgnIFgnEtuxqgT;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return NfmRgGQNsqqxZjAGljQFaGfnVZmrA;
	}

	public void ATwyXfLTCfAUthyhzNjiOhCAEvxBA(OHRjBiOQHgDSIYOkYVxJaSngpGAe P_0, qdwEOjvddVQxAcoocPZTRVGPdkJF P_1)
	{
	}

	private void NUxddpmJQcGphrxwNvnlPtQOOBrE()
	{
		if (gRXoLUThVPENEbgbjQPnkTukwhhH.YASgmbEQfqbFGemfMILquknsdBcZA)
		{
			if (gRXoLUThVPENEbgbjQPnkTukwhhH.CUmiTZTnrHmOILdUvpnQSdUBdzmgA() && !imCGfrNaCUTccCnlwDrUUdEENElv.running && !mAHZHmfzioNSqcxZfgHRditVRsJK.YASgmbEQfqbFGemfMILquknsdBcZA)
			{
				if (gRXoLUThVPENEbgbjQPnkTukwhhH.GQeIAxmbSyejgKlIwwQaiAqYidcZA)
				{
					ZcQyxPvDlEAlThEUkcyTrhJbublrA = true;
				}
				imCGfrNaCUTccCnlwDrUUdEENElv.Start();
			}
		}
		else if (!imCGfrNaCUTccCnlwDrUUdEENElv.running)
		{
			imCGfrNaCUTccCnlwDrUUdEENElv.Start();
		}
		else if (imCGfrNaCUTccCnlwDrUUdEENElv.Update())
		{
			gRXoLUThVPENEbgbjQPnkTukwhhH.iHiGIFABtyBNGjnHrdGZBnbyaQGe();
		}
	}

	private void aPzOTuyBbVSGQKpqYIVlaZElnjSp()
	{
		qDbcNpTzBEDMVvMMSKxSrUlspQwV(RqdvNEqZpicwprZWFLoSvHcDxRgB());
	}

	private void qDbcNpTzBEDMVvMMSKxSrUlspQwV(IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> P_0)
	{
		int num = 0;
		List<tcOIEORCozOZGnGHlBBtbFyLFlxY> opcDfyZXHcKjlAfCsKvXqFsGAjZm = OpcDfyZXHcKjlAfCsKvXqFsGAjZm;
		int num2 = zRyfIZskZPXCyqvbsIoZkYSghMAE;
		OpcDfyZXHcKjlAfCsKvXqFsGAjZm = new List<tcOIEORCozOZGnGHlBBtbFyLFlxY>();
		emEjWwksqJEaohvyLfBcstmwPrHQ = 0;
		List<tcOIEORCozOZGnGHlBBtbFyLFlxY> list = new List<tcOIEORCozOZGnGHlBBtbFyLFlxY>();
		new List<tcOIEORCozOZGnGHlBBtbFyLFlxY>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (opcDfyZXHcKjlAfCsKvXqFsGAjZm[num3] != null && !opcDfyZXHcKjlAfCsKvXqFsGAjZm[num3].AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				list.Add(opcDfyZXHcKjlAfCsKvXqFsGAjZm[num3]);
				opcDfyZXHcKjlAfCsKvXqFsGAjZm[num3].ezaBXmgFDFqkDcAZhNADXZDqqWSNb();
				opcDfyZXHcKjlAfCsKvXqFsGAjZm.RemoveAt(num3);
			}
		}
		num2 = opcDfyZXHcKjlAfCsKvXqFsGAjZm?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			TxauYJUxripoULEjacoOoohpSPzn txauYJUxripoULEjacoOoohpSPzn = new TxauYJUxripoULEjacoOoohpSPzn();
			txauYJUxripoULEjacoOoohpSPzn.MLCxIBPmvKnnrIkpvAlVVifsJJBX = this;
			if (P_0[i] == null)
			{
				continue;
			}
			GFzeCCkaUHxzLqMmAXGJQcvsbFsv gFzeCCkaUHxzLqMmAXGJQcvsbFsv = P_0[i];
			if (gFzeCCkaUHxzLqMmAXGJQcvsbFsv != null && gFzeCCkaUHxzLqMmAXGJQcvsbFsv.UKYpYtGSFXwPyzhtganWoERsyXVS)
			{
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS = new tcOIEORCozOZGnGHlBBtbFyLFlxY(gFzeCCkaUHxzLqMmAXGJQcvsbFsv, gFzeCCkaUHxzLqMmAXGJQcvsbFsv.ghGDQestAGYUNKYdRaWNXafVGvwI, OIkdxnFDbAGTTulmAsKtbUCogSBD);
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.bgLNjuJYWhGWPKOQbxUCBaAzXqfM = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.phjbIzJwpfaHndTsqJBOtHvTTudeA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.UAGxtKsNjtdJAbJDZBNbkoGSvvsm = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.VhebEQKXpmCJgYSzUThqlsfqMoVkA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.wfuVmdrtjPuvnZHykcsyehCpHJdnA = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.VhebEQKXpmCJgYSzUThqlsfqMoVkA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.HHyRwCpdPYMrztfjuTRDvcXEDLVhA = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.vSXXdZFcWHtbAwOjUQJqVgkyjHVT;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.LZvfHXfmnqYDCJUKIrgjKcqITbon = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.ZPmGRXCxBEwOQOdOWCuUXGtyzwneA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.CBUcBGCeQHuIwkwlSmaKpKAFmQuV = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.ZmTpVjBHdSymNuhkHzqHwAFRNBHe;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.pezbeIyrFIhXmrTcgcvdBLxkUyNv = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.LGwBfQCIhoIxOGcsfvaRYuoqkeDVA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.twarqJdHGKMHGMzosuZxbFIhbmEU = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.uCKAvRYcsaaXxcxYMNIAjYSlGYYuA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.QgcvHbBdmOcFellWhaBpJIfQWjoL = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.YkHEMGjoxxtiIEKFQuSelHBSQytyA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.YckIFyziCQcFqvzLxbCpyhsOklSM = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.kZsWpxnWNKvqMhPhWInkvoUuLxKi;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.CLiDYQYjBAJnBtAasPrFLLQxCJPR = false;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.MKBEhyIOZEbyPleVzQVmQplSfQbS = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.RYehePePOJhoDoBdQdzwgDtYfmccb;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.XiAHOVgMbVAEubcqpSniKMFrGIUFA = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.WBMgidYMSTZBedYHaRzndjzWWXzi;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.bohNIInnsduaDMgKLDMCmxIRelbJA = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.nddhyZJRMiSvlPXVkssUnNBhRgFc;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.HPuGTptdSLCboClcDtjIfCtfZFTbA = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.QCfhpAPLYGBFkqhxmfmQbpSyRTanA;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = gFzeCCkaUHxzLqMmAXGJQcvsbFsv.poehLVjxTCUmWJulNQWVVDEBfczr;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.CBufRacrRUhYIckLGeVRVhPQkLAnB += HrGdoTLDjinrUeJXDzGMqnECCeMD;
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.TrIEZGxGKaeadlvheRFelQcwhENP += txauYJUxripoULEjacoOoohpSPzn.xVaZAMXNLozHbqArsAGLSrmUvZOj;
				gFzeCCkaUHxzLqMmAXGJQcvsbFsv.vxAebkHmVZCbhNjZXXsFPZJWBHOK();
				txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.cofaIViPJDnSCAjlRKIVIntQcWwbb();
				OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Add(txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS);
				num++;
				if (txauYJUxripoULEjacoOoohpSPzn.UkxTtnMRRfgZjZWuwKmFZnduvVqS.MKBEhyIOZEbyPleVzQVmQplSfQbS)
				{
					emEjWwksqJEaohvyLfBcstmwPrHQ++;
				}
			}
		}
		zRyfIZskZPXCyqvbsIoZkYSghMAE = num;
		YOGSpoXWEVgJnYHsFFaoKBecCjgCA(num2, num, opcDfyZXHcKjlAfCsKvXqFsGAjZm, OpcDfyZXHcKjlAfCsKvXqFsGAjZm);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(OpcDfyZXHcKjlAfCsKvXqFsGAjZm[j]));
			}
		}
		list.ForEach(delegate(tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2)
		{
			sScvfVuMUIgNLbzmCeVkymfbDabY(tcOIEORCozOZGnGHlBBtbFyLFlxY2, false, false);
		});
		ZuRAmYWFljsvAzleZaBkaUjjjByWA(opcDfyZXHcKjlAfCsKvXqFsGAjZm, OpcDfyZXHcKjlAfCsKvXqFsGAjZm, false);
		ZuRAmYWFljsvAzleZaBkaUjjjByWA(OpcDfyZXHcKjlAfCsKvXqFsGAjZm, opcDfyZXHcKjlAfCsKvXqFsGAjZm, true);
		for (int num4 = 0; num4 < num2; num4++)
		{
			if (opcDfyZXHcKjlAfCsKvXqFsGAjZm[num4] != null)
			{
				opcDfyZXHcKjlAfCsKvXqFsGAjZm[num4].ezaBXmgFDFqkDcAZhNADXZDqqWSNb();
			}
		}
	}

	private void YRdGzINBtwvZTNeSHlxYFXDRfaVP()
	{
		for (int i = 0; i < zRyfIZskZPXCyqvbsIoZkYSghMAE; i++)
		{
			tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2 = OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i];
			if (tcOIEORCozOZGnGHlBBtbFyLFlxY2 != null && (bWeHbNTMIKTDjfmMFJcAQLPviUwEA == null || !tcOIEORCozOZGnGHlBBtbFyLFlxY2.CLiDYQYjBAJnBtAasPrFLLQxCJPR))
			{
				tcOIEORCozOZGnGHlBBtbFyLFlxY2.Update();
			}
		}
	}

	private bool EYnFVUfrQQkRWaAzBHIdVmWOfznIA(baTMToGcxOTuKlJYdnlAPIYTrwdQ P_0)
	{
		try
		{
			return P_0.YVlvuueoRIuPGvVVtTYKYiZFwCbI();
		}
		catch
		{
			return false;
		}
	}

	private IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> RqdvNEqZpicwprZWFLoSvHcDxRgB()
	{
		return GeapBAebWtCuAFudbOlXPGnNuBKJA.GetJoysticks<GFzeCCkaUHxzLqMmAXGJQcvsbFsv>();
	}

	private void YOGSpoXWEVgJnYHsFFaoKBecCjgCA(int P_0, int P_1, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_2, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(tcOIEORCozOZGnGHlBBtbFyLFlxY.KIGPYrwBkUSUlzrWWVWLAyvZGqge);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			CWByVkIFhGiBAAkgyHwmuNIQcDMb(P_1, P_3, P_0, P_2, JPUoLKKeichBXITUOfRUYnPAvXZbA.vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Exact);
		}
		CJCfrnaFczjMcVzaLWBlComWACtgb(P_1, P_3, JPUoLKKeichBXITUOfRUYnPAvXZbA.vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Exact);
		for (int i = 0; i < P_1; i++)
		{
			tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2 = P_3[i];
			if (tcOIEORCozOZGnGHlBBtbFyLFlxY2 != null && tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = WdgQTPXLuysNxupwczRsMnsRoRxM(P_3);
				tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = eOBmMyPJeLLthOIfvDaawrXIfJGi();
				cXboOkqHpOxpsbYzbjmAFCjoAooz.vVLQlaYHGFeSKkPdOSyHDvMVWGPgb(tcOIEORCozOZGnGHlBBtbFyLFlxY2);
			}
		}
		P_3.Sort(tcOIEORCozOZGnGHlBBtbFyLFlxY.VkBILeCeWHoFHomeintkcFEITwUO);
	}

	private void ETtAJJztZOfEkbySaDtzoNqWwLOH(List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_0, int P_1, int P_2)
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

	private bool PvJkWAaCTYcVIFpqtfeAghqryHhh(List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_0, int P_1)
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

	private int WdgQTPXLuysNxupwczRsMnsRoRxM(List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_0)
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

	private bool mMsApqIEirlyIScsVYWOpOexaTgnA(List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_0, int P_1)
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

	private void CWByVkIFhGiBAAkgyHwmuNIQcDMb(int P_0, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_1, int P_2, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_3, JPUoLKKeichBXITUOfRUYnPAvXZbA.vcFQhQeuGhxTlXcBMgLYsFWWEAmO P_4)
	{
		int num = ((P_4 != JPUoLKKeichBXITUOfRUYnPAvXZbA.vcFQhQeuGhxTlXcBMgLYsFWWEAmO.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2 = P_1[i];
			if (tcOIEORCozOZGnGHlBBtbFyLFlxY2 == null || tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY3 = P_3[j];
				if (tcOIEORCozOZGnGHlBBtbFyLFlxY3 != null && !mMsApqIEirlyIScsVYWOpOexaTgnA(P_1, tcOIEORCozOZGnGHlBBtbFyLFlxY3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && tcOIEORCozOZGnGHlBBtbFyLFlxY2.eXUNDHtBfQoKeQfAPcMDejFFvPew(tcOIEORCozOZGnGHlBBtbFyLFlxY3) >= num)
				{
					tcOIEORCozOZGnGHlBBtbFyLFlxY2.veDHkhYQlhgSHEiRMhBwKVJVxmQvA(tcOIEORCozOZGnGHlBBtbFyLFlxY3);
					cXboOkqHpOxpsbYzbjmAFCjoAooz.vVLQlaYHGFeSKkPdOSyHDvMVWGPgb(tcOIEORCozOZGnGHlBBtbFyLFlxY2);
				}
			}
		}
	}

	private void CJCfrnaFczjMcVzaLWBlComWACtgb(int P_0, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_1, JPUoLKKeichBXITUOfRUYnPAvXZbA.vcFQhQeuGhxTlXcBMgLYsFWWEAmO P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2 = P_1[i];
			if (tcOIEORCozOZGnGHlBBtbFyLFlxY2 == null || tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			JPUoLKKeichBXITUOfRUYnPAvXZbA.vxICUPnDSEcAYmdAPRenNKhHOESE vxICUPnDSEcAYmdAPRenNKhHOESE = null;
			foreach (JPUoLKKeichBXITUOfRUYnPAvXZbA.vxICUPnDSEcAYmdAPRenNKhHOESE item in cXboOkqHpOxpsbYzbjmAFCjoAooz.yHyTpFngdXdEvHtXJHoRIjBRpuYWA(tcOIEORCozOZGnGHlBBtbFyLFlxY2, P_2))
			{
				if (!mMsApqIEirlyIScsVYWOpOexaTgnA(P_1, item.AKGdpFjUqixiDTSRpNIFgBnQqFLab) && item.eNjjznmfCzetpCEeFCXYaTcBQNso >= 0)
				{
					vxICUPnDSEcAYmdAPRenNKhHOESE = item;
					break;
				}
			}
			if (vxICUPnDSEcAYmdAPRenNKhHOESE != null)
			{
				int num = vxICUPnDSEcAYmdAPRenNKhHOESE.eNjjznmfCzetpCEeFCXYaTcBQNso;
				if (!PvJkWAaCTYcVIFpqtfeAghqryHhh(P_1, num))
				{
					num = (vxICUPnDSEcAYmdAPRenNKhHOESE.eNjjznmfCzetpCEeFCXYaTcBQNso = WdgQTPXLuysNxupwczRsMnsRoRxM(P_1));
				}
				tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = vxICUPnDSEcAYmdAPRenNKhHOESE.AKGdpFjUqixiDTSRpNIFgBnQqFLab;
				cXboOkqHpOxpsbYzbjmAFCjoAooz.vVLQlaYHGFeSKkPdOSyHDvMVWGPgb(tcOIEORCozOZGnGHlBBtbFyLFlxY2);
			}
		}
	}

	private void oHlYfZaiVDlhPcuemdIWgKTkCAUHA()
	{
		while (lOftYzlYKCXAuHJfuAQEqFvZEIFr.Count > 0)
		{
			qrSAODhmoGfjsOJCHQDHhiMAHpGyA qrSAODhmoGfjsOJCHQDHhiMAHpGyA2 = lOftYzlYKCXAuHJfuAQEqFvZEIFr.Dequeue();
			if (qrSAODhmoGfjsOJCHQDHhiMAHpGyA2.dpOvMrNeYBfymRcVlmcYEqbNLsfI)
			{
				if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Contains(qrSAODhmoGfjsOJCHQDHhiMAHpGyA2.HIfBYkcoHFdSFaGHdbtLpPhOVMDqc))
				{
					sScvfVuMUIgNLbzmCeVkymfbDabY(qrSAODhmoGfjsOJCHQDHhiMAHpGyA2.HIfBYkcoHFdSFaGHdbtLpPhOVMDqc, true, false);
				}
			}
			else
			{
				sScvfVuMUIgNLbzmCeVkymfbDabY(qrSAODhmoGfjsOJCHQDHhiMAHpGyA2.HIfBYkcoHFdSFaGHdbtLpPhOVMDqc, false, true);
			}
		}
		if (GeapBAebWtCuAFudbOlXPGnNuBKJA.ROGOBoGTVfHmeHFDXxiosPKcFKB(true))
		{
			ZcQyxPvDlEAlThEUkcyTrhJbublrA = true;
		}
		if (ZcQyxPvDlEAlThEUkcyTrhJbublrA)
		{
			ZOvOIUTSBvIfeBHSdXUJbLaofipp();
		}
		if ((RcVuEnAPgIznXAZiAxLhOAxdEEdcA || GeapBAebWtCuAFudbOlXPGnNuBKJA.uWmnGvNFeOKDkakgoEEdlNhWUueY) && mAHZHmfzioNSqcxZfgHRditVRsJK.YASgmbEQfqbFGemfMILquknsdBcZA && mAHZHmfzioNSqcxZfgHRditVRsJK.CUmiTZTnrHmOILdUvpnQSdUBdzmgA())
		{
			eItVmZzxbIAFljoJbPEfpUWiJnbk();
		}
	}

	private void ZOvOIUTSBvIfeBHSdXUJbLaofipp()
	{
		ZcQyxPvDlEAlThEUkcyTrhJbublrA = false;
		if (!mAHZHmfzioNSqcxZfgHRditVRsJK.YASgmbEQfqbFGemfMILquknsdBcZA)
		{
			GeapBAebWtCuAFudbOlXPGnNuBKJA.HLIbQFHJAvhIOoSHFyFgDoFiSlpiA();
			mAHZHmfzioNSqcxZfgHRditVRsJK.iHiGIFABtyBNGjnHrdGZBnbyaQGe();
		}
	}

	private void eItVmZzxbIAFljoJbPEfpUWiJnbk()
	{
		GeapBAebWtCuAFudbOlXPGnNuBKJA.yyJqFsDWScnOwhetGAWUZwnCuGJD();
		if (RcVuEnAPgIznXAZiAxLhOAxdEEdcA)
		{
			IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> list = RqdvNEqZpicwprZWFLoSvHcDxRgB();
			if (AtXRnAEOYzyxsNMVuTygyFTFXoxQ(list))
			{
				qDbcNpTzBEDMVvMMSKxSrUlspQwV(list);
			}
		}
	}

	private bool AtXRnAEOYzyxsNMVuTygyFTFXoxQ(IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> P_0)
	{
		for (int i = 0; i < OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Count; i++)
		{
			if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i] != null && !OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i].AdEKyrJZmgOHBFtYmLwRLGQAGNNq)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !AoYChvEdTvwVZGZVNTDOlyACENwr(P_0[j].phjbIzJwpfaHndTsqJBOtHvTTudeA) && P_0[j].UKYpYtGSFXwPyzhtganWoERsyXVS)
			{
				return true;
			}
		}
		int count2 = OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Count;
		for (int k = 0; k < count2; k++)
		{
			if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm[k] != null && (!UGivqXdBUhiqJZdsIFiRFgaXHHTE(P_0, OpcDfyZXHcKjlAfCsKvXqFsGAjZm[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid) || !OpcDfyZXHcKjlAfCsKvXqFsGAjZm[k].AdEKyrJZmgOHBFtYmLwRLGQAGNNq))
			{
				return true;
			}
		}
		return false;
	}

	private bool AoYChvEdTvwVZGZVNTDOlyACENwr(Guid P_0)
	{
		int count = OpcDfyZXHcKjlAfCsKvXqFsGAjZm.Count;
		for (int i = 0; i < count; i++)
		{
			if (OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i] != null && OpcDfyZXHcKjlAfCsKvXqFsGAjZm[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool UGivqXdBUhiqJZdsIFiRFgaXHHTE(IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].phjbIzJwpfaHndTsqJBOtHvTTudeA == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ZuRAmYWFljsvAzleZaBkaUjjjByWA(List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_0, List<tcOIEORCozOZGnGHlBBtbFyLFlxY> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY2 = P_0[i];
			if (tcOIEORCozOZGnGHlBBtbFyLFlxY2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					tcOIEORCozOZGnGHlBBtbFyLFlxY tcOIEORCozOZGnGHlBBtbFyLFlxY3 = P_1[j];
					if (tcOIEORCozOZGnGHlBBtbFyLFlxY3 != null && tcOIEORCozOZGnGHlBBtbFyLFlxY2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == tcOIEORCozOZGnGHlBBtbFyLFlxY3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				sScvfVuMUIgNLbzmCeVkymfbDabY(P_0[i], P_2, false);
			}
		}
	}

	private void sScvfVuMUIgNLbzmCeVkymfbDabY(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, bool P_1, bool P_2)
	{
		if (!P_2 && P_0.BzZEZTdAcehOuljgNMiquJOwDdYwA)
		{
			return;
		}
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

	private bool mKDeFtsJcIfpsFrcQMWsinapJUIbA()
	{
		try
		{
			int num = 0;
			QTuQcRcLMwIPBReYViUMBbOLXJOb.KVbdoOMttsviDJmulaXhZpFduHsL(null, ref num, qxcVmGprUKQYlnqWDgYoPbSYiwBQ.pPOQOWVFBwzWqtWRDdWyKPxFBEfO<vdTfpntROrYfsHgrrUOEDVdOhXdj>());
			if (gqcBNHkHBZODUMLSSHSFdcRabcOOc != num)
			{
				gqcBNHkHBZODUMLSSHSFdcRabcOOc = num;
				return true;
			}
		}
		catch (Exception)
		{
		}
		if (emEjWwksqJEaohvyLfBcstmwPrHQ > 0 && GeapBAebWtCuAFudbOlXPGnNuBKJA.wUigRmqDoOGJhfjjehkTxouTXrogA())
		{
			return true;
		}
		return false;
	}

	private void HrGdoTLDjinrUeJXDzGMqnECCeMD()
	{
		ZcQyxPvDlEAlThEUkcyTrhJbublrA = true;
	}

	private void eRuFfpvybxpaOFqQCgPWbPNeOcdGA(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0, bool P_1)
	{
		lOftYzlYKCXAuHJfuAQEqFvZEIFr.Enqueue(new qrSAODhmoGfjsOJCHQDHhiMAHpGyA(P_0, !P_1));
	}

	[Conditional("DEBUGTHIS")]
	private void rmgcPxacGkuDEsmKhKsiEXfbfoDKc(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void ZsvhVsTgbINtzRAhbSVnwymkOxEF(tcOIEORCozOZGnGHlBBtbFyLFlxY P_0)
	{
		sScvfVuMUIgNLbzmCeVkymfbDabY(P_0, false, false);
	}
}
