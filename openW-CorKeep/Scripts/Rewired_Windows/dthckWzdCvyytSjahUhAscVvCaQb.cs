using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Platforms.Windows.XInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class dthckWzdCvyytSjahUhAscVvCaQb : PlatformInputManager, tfBBbpYawsTqFdIUEKOlukvpcHoaA
{
	private class yqAxqAlnBRGEMOozeADaxHAkyChi : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool bXkjJNLZpMCYQyqmaHdtUlSSLbSL;

		private int SFRbNaCgYIzKHIyJyjasSKtCOXAGb;

		private readonly int fRKnBJhtNCiynDMUSthYAhHLAvST;

		public Guid iweGTMxnrAfiujJZkGcUAPVhlAVL;

		public string vbQekgCxdLbJDIfRhwhxFPSEORxqA;

		public string hXtpiiXIlVNtxcYzmACxRcOgJxjg;

		public Guid nltJEmZwglpsXbmxrVGHrLxEDbgJ;

		public Rewired.Libraries.SharpDX.XInput.DeviceType udaMleajsAfTKJVUQcAniCbHwnoac;

		public XInputDeviceSubType VnNQLrrmUtEZYEvvoQubXVmRDIFgA;

		public bool yhTDwKMgpQiOQaFUxlRUUFHgmFyn;

		public bool dwdMLHHiSjkXxfJYAOHKLKGmBQJt;

		public bool wiiQFTAuvUjkJAGIRBgTaISxTCkFA;

		public bool giyxCsODTxvaYkpPvYedXzKlQeCd;

		private int BJQnbpwBdTAOiGitnxWszEOfBjjX;

		private int SXvlmgYfxdXNOxXgsHwjsOtLIkrP;

		private int bfzRRzyiFaljGlvxqaJKxvUSuAzW;

		private int aJjtaIZwrPFLaVmldHoOBjQfwETSA;

		private readonly float[] aNhpXMKudrDKJURhGNLWBgVCaRNAA;

		private readonly bool[] eQJEXxGsnkAcPgtxhcNfRoafrYLZb;

		private HardwareJoystickMap_InputManager AuOQtYCQEALzcjwsXeSKTCYZdsJK;

		public readonly iUVRQWivcUcvaWpmaoyYGuTThrFS yRqdrNmDbEdbTsUZnsFoyzplfvmp;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZNUraDZBDvPSKuAnaMTvAaMUOWXG;

		private Action alDtpyZlKzCJMqKLWvCachSZIlr;

		private readonly LocalizedString nnQCdGARwcgOdqFkercamcTQuOPSA;

		private bool QYYDQkhojjeedxOKDtCrmmEEaAsAb;

		private bool YENlIbvHJVnsbEJpuMGdgrOYfYEV;

		private bool wIzLLupFBMBwWyUKTzzYRJnTzDif;

		public string okgFosfrkBAEOdkxcxuPdeYjXMssB
		{
			get
			{
				string text = ChzxGIcFyuAeDdQROIoOBiiBHfoUb;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int num = fRKnBJhtNCiynDMUSthYAhHLAvST;
				return text + " " + num;
			}
		}

		public string ChzxGIcFyuAeDdQROIoOBiiBHfoUb
		{
			get
			{
				if (!NspkgpUEWXXsPFnuSxrBXpgalMDq)
				{
					return string.Empty;
				}
				return VnNQLrrmUtEZYEvvoQubXVmRDIFgA.ToString();
			}
		}

		public bool NspkgpUEWXXsPFnuSxrBXpgalMDq
		{
			get
			{
				if (yRqdrNmDbEdbTsUZnsFoyzplfvmp == null || !giyxCsODTxvaYkpPvYedXzKlQeCd)
				{
					return false;
				}
				if (QYYDQkhojjeedxOKDtCrmmEEaAsAb && !eYeTqmtxFeQwpeDDycINAeCrDrbuA(nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Asynchronous))
				{
					DRMuMzeJzawcFSEmMigagCvzjFOG();
				}
				return QYYDQkhojjeedxOKDtCrmmEEaAsAb;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return SFRbNaCgYIzKHIyJyjasSKtCOXAGb;
			}
			set
			{
				SFRbNaCgYIzKHIyJyjasSKtCOXAGb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => fRKnBJhtNCiynDMUSthYAhHLAvST;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => hXtpiiXIlVNtxcYzmACxRcOgJxjg;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => fRKnBJhtNCiynDMUSthYAhHLAvST;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (yRqdrNmDbEdbTsUZnsFoyzplfvmp == null)
				{
					return null;
				}
				return yRqdrNmDbEdbTsUZnsFoyzplfvmp.lVcUAZuEBoQwNLGKiGWJYnMhxAGQ;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => nltJEmZwglpsXbmxrVGHrLxEDbgJ;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.RUTJDqAbNzjapgvisFhfvAdYnMoyA(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.LgvawPzGNUDyiaXZekOaOmKgVwNkA();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(nnQCdGARwcgOdqFkercamcTQuOPSA, AuOQtYCQEALzcjwsXeSKTCYZdsJK.deviceLocalizationInfo.parentKeys, "controller", vbQekgCxdLbJDIfRhwhxFPSEORxqA, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(fRKnBJhtNCiynDMUSthYAhHLAvST + 1).ToString()}";
				nnQCdGARwcgOdqFkercamcTQuOPSA.cachedValue = value;
			}
			return true;
		}

		public yqAxqAlnBRGEMOozeADaxHAkyChi(int P_0, bool P_1, iUVRQWivcUcvaWpmaoyYGuTThrFS P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			yRqdrNmDbEdbTsUZnsFoyzplfvmp = P_2;
			bXkjJNLZpMCYQyqmaHdtUlSSLbSL = P_1;
			fRKnBJhtNCiynDMUSthYAhHLAvST = P_0;
			ZNUraDZBDvPSKuAnaMTvAaMUOWXG = P_3;
			alDtpyZlKzCJMqKLWvCachSZIlr = P_4;
			SFRbNaCgYIzKHIyJyjasSKtCOXAGb = -1;
			BJQnbpwBdTAOiGitnxWszEOfBjjX = 6;
			SXvlmgYfxdXNOxXgsHwjsOtLIkrP = 15;
			bfzRRzyiFaljGlvxqaJKxvUSuAzW = BJQnbpwBdTAOiGitnxWszEOfBjjX;
			aJjtaIZwrPFLaVmldHoOBjQfwETSA = SXvlmgYfxdXNOxXgsHwjsOtLIkrP;
			aNhpXMKudrDKJURhGNLWBgVCaRNAA = new float[BJQnbpwBdTAOiGitnxWszEOfBjjX];
			eQJEXxGsnkAcPgtxhcNfRoafrYLZb = new bool[SXvlmgYfxdXNOxXgsHwjsOtLIkrP];
			nnQCdGARwcgOdqFkercamcTQuOPSA = new LocalizedString();
			bhGbzGhOoSJOAfEyaOPfOmhwuoXC();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.GIvEgcpyuAKFPdGFtaCqCxYryNikA();
			bool[] array = yRqdrNmDbEdbTsUZnsFoyzplfvmp.qaIIWLVWryEwNmnZGBylwTGaLyRd;
			pIFHWRRspPAZxhDBkbjhQwvUQLzV(array, ref yRqdrNmDbEdbTsUZnsFoyzplfvmp.wayAdifhfFDvFivyEdIjZMKhJJxkA);
			LivPegJmakLyWOyGdABwloICkiwA(array, ref yRqdrNmDbEdbTsUZnsFoyzplfvmp.wayAdifhfFDvFivyEdIjZMKhJJxkA);
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.fGsgNhGFnjjlFKQuHlSYznHYfVNHA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void ujYhiYgHFLnyFDRgmlwgTBZRWCNj(bool P_0)
		{
			if (yRqdrNmDbEdbTsUZnsFoyzplfvmp != null)
			{
				wiiQFTAuvUjkJAGIRBgTaISxTCkFA = P_0;
			}
		}

		public bool eYeTqmtxFeQwpeDDycINAeCrDrbuA(nWOiPPRVPKmKBBmSXrkkRYZldNeQ P_0)
		{
			osRxgWZXLlBXWjeOMIgWqOnbRYTR(gvKdivDthMpRrZaFCTFCOYwBfsNT(P_0));
			return QYYDQkhojjeedxOKDtCrmmEEaAsAb;
		}

		public bool gvKdivDthMpRrZaFCTFCOYwBfsNT(nWOiPPRVPKmKBBmSXrkkRYZldNeQ P_0)
		{
			if (yRqdrNmDbEdbTsUZnsFoyzplfvmp == null)
			{
				return false;
			}
			return yRqdrNmDbEdbTsUZnsFoyzplfvmp.dESCsTUzfJOKQlmLzBeVgKhqgslYA(P_0);
		}

		public void osRxgWZXLlBXWjeOMIgWqOnbRYTR(bool P_0)
		{
			QYYDQkhojjeedxOKDtCrmmEEaAsAb = P_0;
		}

		public void fGPDRswvLETqoNxopBUkmMuRctwHA()
		{
			if (!giyxCsODTxvaYkpPvYedXzKlQeCd || KpxeVDLsBzeUDbZbYOKaSiBxDyJFA())
			{
				bhGbzGhOoSJOAfEyaOPfOmhwuoXC();
			}
			if (giyxCsODTxvaYkpPvYedXzKlQeCd && QYYDQkhojjeedxOKDtCrmmEEaAsAb)
			{
				yRqdrNmDbEdbTsUZnsFoyzplfvmp.CcPYJtxgrbbHJkhjHiHvGrbgTmEu();
			}
		}

		public void ogvHnphmBJNrOAjexhJHufsgtFmp()
		{
			SFRbNaCgYIzKHIyJyjasSKtCOXAGb = -1;
			giyxCsODTxvaYkpPvYedXzKlQeCd = false;
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.mLayRFHvyNqayoWtIOHNRQpKnFHS();
			Array.Clear(aNhpXMKudrDKJURhGNLWBgVCaRNAA, 0, aNhpXMKudrDKJURhGNLWBgVCaRNAA.Length);
			Array.Clear(eQJEXxGsnkAcPgtxhcNfRoafrYLZb, 0, eQJEXxGsnkAcPgtxhcNfRoafrYLZb.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (BJQnbpwBdTAOiGitnxWszEOfBjjX != dataUpdater.axisCount || SXvlmgYfxdXNOxXgsHwjsOtLIkrP != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < BJQnbpwBdTAOiGitnxWszEOfBjjX; i++)
			{
				dataUpdater.axisValues[i] = aNhpXMKudrDKJURhGNLWBgVCaRNAA[i];
			}
			for (int j = 0; j < SXvlmgYfxdXNOxXgsHwjsOtLIkrP; j++)
			{
				dataUpdater.buttonValues[j] = eQJEXxGsnkAcPgtxhcNfRoafrYLZb[j];
			}
			if (YENlIbvHJVnsbEJpuMGdgrOYfYEV && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo giJHyywLhAGmwQpdQfEvKdojYudB()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			eAnSqVDnMFHANmLOjBFcHAzIYexw(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			JsDKXbxDBtVjSrntGGEiFmvQJjabb(bridgedController);
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
			return new ControllerDisconnectedEventArgs(SFRbNaCgYIzKHIyJyjasSKtCOXAGb);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void bhGbzGhOoSJOAfEyaOPfOmhwuoXC()
		{
			if (yRqdrNmDbEdbTsUZnsFoyzplfvmp == null || !eYeTqmtxFeQwpeDDycINAeCrDrbuA(nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Synchronous))
			{
				return;
			}
			try
			{
				lEpyAmfxGyOTsObToGeBEPuYSBwT();
				KkCedRUBGjrnSczYvIhPFYMUDQuP kkCedRUBGjrnSczYvIhPFYMUDQuP = yRqdrNmDbEdbTsUZnsFoyzplfvmp.CtwhuyyQIAolqaPHmDaKOAqjCzGz.SdChKnAjcYSzHExsmQoihKJhadFJ(ddrNxChsiLuVtQynDItAHKGwFiuaA.Any);
				udaMleajsAfTKJVUQcAniCbHwnoac = kkCedRUBGjrnSczYvIhPFYMUDQuP.drRPaCsEOnDGPCElmzxYHgtBkjEJ;
				VnNQLrrmUtEZYEvvoQubXVmRDIFgA = (XInputDeviceSubType)kkCedRUBGjrnSczYvIhPFYMUDQuP.UuufXcGQVQfYNpwoxWXOjOlzAcLqA;
				if (yRqdrNmDbEdbTsUZnsFoyzplfvmp.CtwhuyyQIAolqaPHmDaKOAqjCzGz.OKyBvjMQBBGYNVCFokYgeFRAXipD(default(EnTOzHRkIdPCTFPEBBSpMiCrzLkt)).oLBhnQcUjvdSAINRjPwmrtkMabon)
				{
					yhTDwKMgpQiOQaFUxlRUUFHgmFyn = true;
				}
				dwdMLHHiSjkXxfJYAOHKLKGmBQJt = (kkCedRUBGjrnSczYvIhPFYMUDQuP.JifhRmjEoeaFnfasWqWatpjfKMNK & cWPzEoZClnBVVktPJZXkSmvPSmvG.VoiceSupported) == cWPzEoZClnBVVktPJZXkSmvPSmvG.VoiceSupported;
				TtagfZvkPdCekUfBWjRzoKHOLZHU();
				iweGTMxnrAfiujJZkGcUAPVhlAVL = AuOQtYCQEALzcjwsXeSKTCYZdsJK.hardwareMapIdentifier.guid;
				if (bXkjJNLZpMCYQyqmaHdtUlSSLbSL)
				{
					vbQekgCxdLbJDIfRhwhxFPSEORxqA = StringTools.AddSpacesToCamelCase(VnNQLrrmUtEZYEvvoQubXVmRDIFgA.ToString());
				}
				else
				{
					vbQekgCxdLbJDIfRhwhxFPSEORxqA = "XInput " + VnNQLrrmUtEZYEvvoQubXVmRDIFgA;
				}
				hXtpiiXIlVNtxcYzmACxRcOgJxjg = $"{vbQekgCxdLbJDIfRhwhxFPSEORxqA} {(fRKnBJhtNCiynDMUSthYAhHLAvST + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(VnNQLrrmUtEZYEvvoQubXVmRDIFgA.ToString());
				AuOQtYCQEALzcjwsXeSKTCYZdsJK.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				nnQCdGARwcgOdqFkercamcTQuOPSA.Clear();
				yRqdrNmDbEdbTsUZnsFoyzplfvmp.CcPYJtxgrbbHJkhjHiHvGrbgTmEu();
				nltJEmZwglpsXbmxrVGHrLxEDbgJ = MiscTools.CreateGuidHashSHA1(string.Concat(udaMleajsAfTKJVUQcAniCbHwnoac, VnNQLrrmUtEZYEvvoQubXVmRDIFgA, fRKnBJhtNCiynDMUSthYAhHLAvST));
				giyxCsODTxvaYkpPvYedXzKlQeCd = true;
			}
			catch (Exception)
			{
				giyxCsODTxvaYkpPvYedXzKlQeCd = false;
				QYYDQkhojjeedxOKDtCrmmEEaAsAb = false;
				nltJEmZwglpsXbmxrVGHrLxEDbgJ = Guid.Empty;
			}
		}

		private bool KpxeVDLsBzeUDbZbYOKaSiBxDyJFA()
		{
			try
			{
				if (VnNQLrrmUtEZYEvvoQubXVmRDIFgA != (XInputDeviceSubType)yRqdrNmDbEdbTsUZnsFoyzplfvmp.CtwhuyyQIAolqaPHmDaKOAqjCzGz.SdChKnAjcYSzHExsmQoihKJhadFJ(ddrNxChsiLuVtQynDItAHKGwFiuaA.Any).UuufXcGQVQfYNpwoxWXOjOlzAcLqA)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void lEpyAmfxGyOTsObToGeBEPuYSBwT()
		{
			dwdMLHHiSjkXxfJYAOHKLKGmBQJt = false;
			yhTDwKMgpQiOQaFUxlRUUFHgmFyn = false;
			wiiQFTAuvUjkJAGIRBgTaISxTCkFA = false;
			giyxCsODTxvaYkpPvYedXzKlQeCd = false;
		}

		private void DRMuMzeJzawcFSEmMigagCvzjFOG()
		{
			if (alDtpyZlKzCJMqKLWvCachSZIlr != null)
			{
				alDtpyZlKzCJMqKLWvCachSZIlr();
			}
			yRqdrNmDbEdbTsUZnsFoyzplfvmp.mLayRFHvyNqayoWtIOHNRQpKnFHS();
		}

		private void pIFHWRRspPAZxhDBkbjhQwvUQLzV(bool[] P_0, ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)AuOQtYCQEALzcjwsXeSKTCYZdsJK.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= BJQnbpwBdTAOiGitnxWszEOfBjjX)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				aNhpXMKudrDKJURhGNLWBgVCaRNAA[i] = JYaDRvtdkEvhCQqgOPrJrUBRkEbE(axes_orig[i], P_0, ref P_1);
				if (!YENlIbvHJVnsbEJpuMGdgrOYfYEV && aNhpXMKudrDKJURhGNLWBgVCaRNAA[i] != 0f)
				{
					YENlIbvHJVnsbEJpuMGdgrOYfYEV = true;
				}
			}
		}

		private void LivPegJmakLyWOyGdABwloICkiwA(bool[] P_0, ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)AuOQtYCQEALzcjwsXeSKTCYZdsJK.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= SXvlmgYfxdXNOxXgsHwjsOtLIkrP)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				eQJEXxGsnkAcPgtxhcNfRoafrYLZb[i] = zYEeVXOAbFiFIqWedvMBHVdCmwBA(buttons_orig[i], P_0, ref P_1);
				if (!YENlIbvHJVnsbEJpuMGdgrOYfYEV && eQJEXxGsnkAcPgtxhcNfRoafrYLZb[i])
				{
					YENlIbvHJVnsbEJpuMGdgrOYfYEV = true;
				}
			}
		}

		private float JYaDRvtdkEvhCQqgOPrJrUBRkEbE(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return rIWMynZaAezpzLTwMnGseaAghzep(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!VkmUpxRfkmabBVVWlannggbUXtKF(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float rIWMynZaAezpzLTwMnGseaAghzep(XInputAxis P_0, ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => iUVRQWivcUcvaWpmaoyYGuTThrFS.rVMMGASzCkPEsIAeIiERncUZINEx(P_1.ChFfsPaAQTONjpJWGdWsMLcQqLqrA), 
				XInputAxis.LeftThumbY => iUVRQWivcUcvaWpmaoyYGuTThrFS.rVMMGASzCkPEsIAeIiERncUZINEx(P_1.nbSzTDEZOLpTmmFfwMdfifApaNRW), 
				XInputAxis.RightThumbX => iUVRQWivcUcvaWpmaoyYGuTThrFS.rVMMGASzCkPEsIAeIiERncUZINEx(P_1.OeOhtbcWrmKsEquUIZOdGOURhyyx), 
				XInputAxis.RightThumbY => iUVRQWivcUcvaWpmaoyYGuTThrFS.rVMMGASzCkPEsIAeIiERncUZINEx(P_1.eDPlRilVaynUFcwehupnUXymeneA), 
				XInputAxis.LeftTrigger => iUVRQWivcUcvaWpmaoyYGuTThrFS.EwWDqPKRhbXijhbPMWzPQQVPjQKjA(P_1.YbtvPVOoDEHWDBVkbRcllkCrqaTz), 
				XInputAxis.RightTrigger => iUVRQWivcUcvaWpmaoyYGuTThrFS.EwWDqPKRhbXijhbPMWzPQQVPjQKjA(P_1.TrGGTObIsXboJyzyyfVTbRuEPEAXA), 
				_ => 0f, 
			};
		}

		private bool zYEeVXOAbFiFIqWedvMBHVdCmwBA(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return VkmUpxRfkmabBVVWlannggbUXtKF(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = rIWMynZaAezpzLTwMnGseaAghzep(P_0.sourceAxis, ref P_2);
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
			return false;
		}

		private bool VkmUpxRfkmabBVVWlannggbUXtKF(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void TtagfZvkPdCekUfBWjRzoKHOLZHU()
		{
			AuOQtYCQEALzcjwsXeSKTCYZdsJK = ZNUraDZBDvPSKuAnaMTvAaMUOWXG(giJHyywLhAGmwQpdQfEvKdojYudB());
			if (AuOQtYCQEALzcjwsXeSKTCYZdsJK == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			BJQnbpwBdTAOiGitnxWszEOfBjjX = AuOQtYCQEALzcjwsXeSKTCYZdsJK.axisCount;
			SXvlmgYfxdXNOxXgsHwjsOtLIkrP = AuOQtYCQEALzcjwsXeSKTCYZdsJK.buttonCount;
		}

		private bool zkNAwsFbeCfxHMvwEJXoUXkePcvq(ref EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_0)
		{
			if (P_0.ElNgolIhwBSfKIBrwXIriUbYJdhV > 0 || P_0.PehirlkKoPPgMNmqKSQeKPBmXBgAA > 0)
			{
				return true;
			}
			return false;
		}

		private void DMnFdCrZaNuKggIgflrQnMeTYTUl(ref EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_0)
		{
			P_0.ElNgolIhwBSfKIBrwXIriUbYJdhV = 0;
			P_0.PehirlkKoPPgMNmqKSQeKPBmXBgAA = 0;
		}

		private void ktdzIEcrvrprBwvEZfpkNNqJGvch(ref EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_0, ref EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_1)
		{
			P_1.ElNgolIhwBSfKIBrwXIriUbYJdhV = P_0.ElNgolIhwBSfKIBrwXIriUbYJdhV;
			P_1.PehirlkKoPPgMNmqKSQeKPBmXBgAA = P_0.PehirlkKoPPgMNmqKSQeKPBmXBgAA;
		}

		private string QuxCdCdPtpfJbCRiGkktCluWceCIA()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{udaMleajsAfTKJVUQcAniCbHwnoac.ToString()}{VnNQLrrmUtEZYEvvoQubXVmRDIFgA.ToString()}");
		}

		private void eAnSqVDnMFHANmLOjBFcHAzIYexw(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = QuxCdCdPtpfJbCRiGkktCluWceCIA();
			P_0.hardwareAxisCount = bfzRRzyiFaljGlvxqaJKxvUSuAzW;
			P_0.hardwareButtonCount = aJjtaIZwrPFLaVmldHoOBjQfwETSA;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = ChzxGIcFyuAeDdQROIoOBiiBHfoUb;
			P_0.hw_supportsVoice = dwdMLHHiSjkXxfJYAOHKLKGmBQJt;
			P_0.hw_supportsVibration = yhTDwKMgpQiOQaFUxlRUUFHgmFyn;
			P_0.hw_localVibrationMotorCount = (yhTDwKMgpQiOQaFUxlRUUFHgmFyn ? 2 : 0);
			P_0.hw_xInputSubType = VnNQLrrmUtEZYEvvoQubXVmRDIFgA;
		}

		private void JsDKXbxDBtVjSrntGGEiFmvQJjabb(BridgedController P_0)
		{
			eAnSqVDnMFHANmLOjBFcHAzIYexw(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = AuOQtYCQEALzcjwsXeSKTCYZdsJK.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + okgFosfrkBAEOdkxcxuPdeYjXMssB;
			P_0.productName = "XInput " + ChzxGIcFyuAeDdQROIoOBiiBHfoUb;
			P_0.isXInputDevice = true;
			P_0.axisCount = BJQnbpwBdTAOiGitnxWszEOfBjjX;
			P_0.buttonCount = SXvlmgYfxdXNOxXgsHwjsOtLIkrP;
			P_0.controllerTypeGuid = iweGTMxnrAfiujJZkGcUAPVhlAVL;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			dvQEZqrXkHgpgiTZpAkQKcUfcWWP(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void qtyDDrFOImkbCQsElaReRGRgJuWA()
		{
			try
			{
				dvQEZqrXkHgpgiTZpAkQKcUfcWWP(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void dvQEZqrXkHgpgiTZpAkQKcUfcWWP(bool P_0)
		{
			if (wIzLLupFBMBwWyUKTzzYRJnTzDif)
			{
				return;
			}
			if (P_0)
			{
				if (NspkgpUEWXXsPFnuSxrBXpgalMDq)
				{
					yRqdrNmDbEdbTsUZnsFoyzplfvmp.KLsVneQGvosBxGpbKKIyIFHgQYbE();
				}
				if (yRqdrNmDbEdbTsUZnsFoyzplfvmp != null)
				{
					yRqdrNmDbEdbTsUZnsFoyzplfvmp.Dispose();
				}
			}
			wIzLLupFBMBwWyUKTzzYRJnTzDif = true;
		}
	}

	private class iLRxQrDopoTLStVOdcfxvzBputqv
	{
		private class IxsXiyqCoRfaSbzGhntOobgdeRYZ
		{
			public bool UHHuaileodSsjEadaCgIvWvSPjqW;

			public int bQYVXsitldZpujcCoJhoZinWPsEv;

			public XInputDeviceSubType gBDAxnGJURHcMitixOcvvPpZXxDCA;

			public void JBosFRshJCXNUdxemrxTEVNwWMHk(yqAxqAlnBRGEMOozeADaxHAkyChi P_0, bool P_1)
			{
				UHHuaileodSsjEadaCgIvWvSPjqW = P_1;
				bQYVXsitldZpujcCoJhoZinWPsEv = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				gBDAxnGJURHcMitixOcvvPpZXxDCA = P_0.VnNQLrrmUtEZYEvvoQubXVmRDIFgA;
			}

			public IxsXiyqCoRfaSbzGhntOobgdeRYZ(int P_0, XInputDeviceSubType P_1)
			{
				bQYVXsitldZpujcCoJhoZinWPsEv = P_0;
				gBDAxnGJURHcMitixOcvvPpZXxDCA = P_1;
			}
		}

		private List<IxsXiyqCoRfaSbzGhntOobgdeRYZ> sHlQaocXCaExhtXqvdpdTtGBPtFw;

		public iLRxQrDopoTLStVOdcfxvzBputqv()
		{
			sHlQaocXCaExhtXqvdpdTtGBPtFw = new List<IxsXiyqCoRfaSbzGhntOobgdeRYZ>();
		}

		public void VmGNLFESOUZlOMSjeuagpgedbJuE(yqAxqAlnBRGEMOozeADaxHAkyChi P_0, bool P_1)
		{
			if (hIXmkiwwiDPDDkKfXVuTXFnxCJyd(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.VnNQLrrmUtEZYEvvoQubXVmRDIFgA, true) < 0)
			{
				IxsXiyqCoRfaSbzGhntOobgdeRYZ ixsXiyqCoRfaSbzGhntOobgdeRYZ = new IxsXiyqCoRfaSbzGhntOobgdeRYZ(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.VnNQLrrmUtEZYEvvoQubXVmRDIFgA);
				ixsXiyqCoRfaSbzGhntOobgdeRYZ.UHHuaileodSsjEadaCgIvWvSPjqW = P_1;
				sHlQaocXCaExhtXqvdpdTtGBPtFw.Add(ixsXiyqCoRfaSbzGhntOobgdeRYZ);
			}
		}

		public void YfdBCdKxhvGiNDCrTWOCJURfOsJS(int P_0, yqAxqAlnBRGEMOozeADaxHAkyChi P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < sHlQaocXCaExhtXqvdpdTtGBPtFw.Count)
			{
				sHlQaocXCaExhtXqvdpdTtGBPtFw[P_0].JBosFRshJCXNUdxemrxTEVNwWMHk(P_1, P_2);
			}
		}

		public int ixmZcxpIefLMrxkoIKeAQgWsGbxl(XInputDeviceSubType P_0, bool P_1)
		{
			int count = sHlQaocXCaExhtXqvdpdTtGBPtFw.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !sHlQaocXCaExhtXqvdpdTtGBPtFw[i].UHHuaileodSsjEadaCgIvWvSPjqW) && sHlQaocXCaExhtXqvdpdTtGBPtFw[i].gBDAxnGJURHcMitixOcvvPpZXxDCA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int hIXmkiwwiDPDDkKfXVuTXFnxCJyd(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = sHlQaocXCaExhtXqvdpdTtGBPtFw.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !sHlQaocXCaExhtXqvdpdTtGBPtFw[i].UHHuaileodSsjEadaCgIvWvSPjqW) && sHlQaocXCaExhtXqvdpdTtGBPtFw[i].bQYVXsitldZpujcCoJhoZinWPsEv == P_0 && sHlQaocXCaExhtXqvdpdTtGBPtFw[i].gBDAxnGJURHcMitixOcvvPpZXxDCA == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int uLBoQQcuermdpNYQBLpiTqECCoNfA(int P_0)
		{
			if (P_0 < 0 || P_0 >= sHlQaocXCaExhtXqvdpdTtGBPtFw.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return sHlQaocXCaExhtXqvdpdTtGBPtFw[P_0].bQYVXsitldZpujcCoJhoZinWPsEv;
		}

		public void vGuuwOHSdiCCkPnazrSpxCgRHgQR(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < sHlQaocXCaExhtXqvdpdTtGBPtFw.Count)
			{
				sHlQaocXCaExhtXqvdpdTtGBPtFw[P_0].UHHuaileodSsjEadaCgIvWvSPjqW = P_1;
			}
		}
	}

	private class OKDKWSKRNoSzctSXuqEEGtNlZDaE
	{
		public bool oirRYzbaYiHRppgLiTIoTgnyBJGG;

		private double qdzmFNxxwYiGmnFLYbRodoAZvTgj;

		public float HWmfPHJDQxeRxhdHZhuoajMiuhOob;

		public OKDKWSKRNoSzctSXuqEEGtNlZDaE()
		{
		}

		public OKDKWSKRNoSzctSXuqEEGtNlZDaE(float P_0)
		{
			HWmfPHJDQxeRxhdHZhuoajMiuhOob = P_0;
		}

		public void TpqbTIzVqqycHwGYpePGCVBWTrMA()
		{
			oirRYzbaYiHRppgLiTIoTgnyBJGG = true;
			qdzmFNxxwYiGmnFLYbRodoAZvTgj = (double)HWmfPHJDQxeRxhdHZhuoajMiuhOob + ReInput.unscaledTime;
		}

		public void IuiQfHTrdipBkxsOIlmXTHpzgPhh(float P_0)
		{
			oirRYzbaYiHRppgLiTIoTgnyBJGG = true;
			HWmfPHJDQxeRxhdHZhuoajMiuhOob = P_0;
			qdzmFNxxwYiGmnFLYbRodoAZvTgj = (double)HWmfPHJDQxeRxhdHZhuoajMiuhOob + ReInput.unscaledTime;
		}

		public bool oYBuomNWkBlBSWALCFGKGPohlKTy()
		{
			if (!oirRYzbaYiHRppgLiTIoTgnyBJGG)
			{
				return false;
			}
			if (ReInput.unscaledTime >= qdzmFNxxwYiGmnFLYbRodoAZvTgj)
			{
				oirRYzbaYiHRppgLiTIoTgnyBJGG = false;
				return true;
			}
			return false;
		}

		public void zDqfHoJNYOiTIMXjTzkesuYMkjzs()
		{
			oirRYzbaYiHRppgLiTIoTgnyBJGG = false;
			qdzmFNxxwYiGmnFLYbRodoAZvTgj = 0.0;
		}

		public void JplNCuiAwXWwDcDYGNTTBqUSpRwR(float P_0)
		{
			HWmfPHJDQxeRxhdHZhuoajMiuhOob = P_0;
		}

		public OKDKWSKRNoSzctSXuqEEGtNlZDaE CCYItRGYsvzclmZlyntDgBkvaqeuA()
		{
			return (OKDKWSKRNoSzctSXuqEEGtNlZDaE)MemberwiseClone();
		}
	}

	public class iUVRQWivcUcvaWpmaoyYGuTThrFS : IDisposable
	{
		public readonly vGGTrJYhTUTICHVqMwYNbLNmpYAI CtwhuyyQIAolqaPHmDaKOAqjCzGz;

		private readonly Controller.Extension KhAKdTMvqiAKmBQLwWoREFPdYVgH;

		public tSKGrXdRrweIRabtOUkjDjrHCHgxB wayAdifhfFDvFivyEdIjZMKhJJxkA;

		private bool GOvBeNcwlLHABPWhiWNSGJFNTLMq;

		private readonly ButtonLoopSet hSFnGuJevNzVzDnCOipeORJBAaNBA;

		private tSKGrXdRrweIRabtOUkjDjrHCHgxB rrpGavfgBZPtxCMghsyoDPPquzPE;

		private bool bAwauhvNsOacJirRSnbTkwsxIUFL;

		private DualThreadLowLevelInputEventQueue USIOmVLCGHwhRCbiSJGpTPbmWSGH;

		private readonly object aVHphFAQAxhcwXijJvrmpphNCjlS;

		private RingBuffer<EnTOzHRkIdPCTFPEBBSpMiCrzLkt> loSMrZyExgXbSLpeUNiQGBDqFkiiA = new RingBuffer<EnTOzHRkIdPCTFPEBBSpMiCrzLkt>(5);

		private RingBuffer<EnTOzHRkIdPCTFPEBBSpMiCrzLkt> XZGAWsYNIXeogLemIqsZJFJPmWT = new RingBuffer<EnTOzHRkIdPCTFPEBBSpMiCrzLkt>(5);

		private readonly object JKrvVllnhjRjrLsPKwRrllrsqno = new object();

		private readonly object qhtJNiTIeSZOxcQSvaMhgRBpCyDm = new object();

		private EnTOzHRkIdPCTFPEBBSpMiCrzLkt QvHWHtoMxrwMgHUVeUtOdvGmmMfh;

		private double CsPlNXLeeLNrpOSHdahQBeAaPuAK;

		private bool llihafEwehNsZtJuKUSDVgWwrHhV;

		public Controller.Extension lVcUAZuEBoQwNLGKiGWJYnMhxAGQ => KhAKdTMvqiAKmBQLwWoREFPdYVgH;

		public bool[] qaIIWLVWryEwNmnZGBylwTGaLyRd => hSFnGuJevNzVzDnCOipeORJBAaNBA.Current.effectiveValue;

		public iUVRQWivcUcvaWpmaoyYGuTThrFS(int P_0, UpdateLoopSetting P_1)
		{
			CtwhuyyQIAolqaPHmDaKOAqjCzGz = new vGGTrJYhTUTICHVqMwYNbLNmpYAI((FAUgkFgzaaCssQXBvJVZLiuaMpOIb)P_0);
			hSFnGuJevNzVzDnCOipeORJBAaNBA = new ButtonLoopSet(P_1, 15);
			aVHphFAQAxhcwXijJvrmpphNCjlS = new object();
			USIOmVLCGHwhRCbiSJGpTPbmWSGH = new DualThreadLowLevelInputEventQueue((int)((float)rGfCWQcoVBNNMLBCPGciUTleuQNNA.jBtHaTgeNpmGYIOhRQexVaFAnUZE * 0.25f), 15, 6, 0);
			KhAKdTMvqiAKmBQLwWoREFPdYVgH = new XInputControllerExtension(this);
		}

		public void GIvEgcpyuAKFPdGFtaCqCxYryNikA()
		{
			hSFnGuJevNzVzDnCOipeORJBAaNBA.SetUpdateLoop(ReInput.currentUpdateLoop);
			bnWXZytGezthDCRQhqBiJmOJgJrfA(ref wayAdifhfFDvFivyEdIjZMKhJJxkA);
		}

		public void fGsgNhGFnjjlFKQuHlSYznHYfVNHA()
		{
			ANhDkOhCvLJUERwYglDupfbRZVvbA();
			hSFnGuJevNzVzDnCOipeORJBAaNBA.Current.ClearWasTrueThisFrame();
		}

		public void CcPYJtxgrbbHJkhjHiHvGrbgTmEu()
		{
			KDmQOfpqHjzxvLdcMddKjWqCOefS();
			GOvBeNcwlLHABPWhiWNSGJFNTLMq = true;
			bAwauhvNsOacJirRSnbTkwsxIUFL = CtwhuyyQIAolqaPHmDaKOAqjCzGz.ZVizaChOLvQLBsBSFqQDtCFAqnkQ;
		}

		public void mLayRFHvyNqayoWtIOHNRQpKnFHS()
		{
			GOvBeNcwlLHABPWhiWNSGJFNTLMq = false;
			bAwauhvNsOacJirRSnbTkwsxIUFL = false;
			KDmQOfpqHjzxvLdcMddKjWqCOefS();
		}

		public bool dESCsTUzfJOKQlmLzBeVgKhqgslYA(nWOiPPRVPKmKBBmSXrkkRYZldNeQ P_0)
		{
			return P_0 switch
			{
				nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Synchronous => bAwauhvNsOacJirRSnbTkwsxIUFL = CtwhuyyQIAolqaPHmDaKOAqjCzGz.ZVizaChOLvQLBsBSFqQDtCFAqnkQ, 
				nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Asynchronous => bAwauhvNsOacJirRSnbTkwsxIUFL, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void RUTJDqAbNzjapgvisFhfvAdYnMoyA(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				QvHWHtoMxrwMgHUVeUtOdvGmmMfh.ElNgolIhwBSfKIBrwXIriUbYJdhV = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				QvHWHtoMxrwMgHUVeUtOdvGmmMfh.PehirlkKoPPgMNmqKSQeKPBmXBgAA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			qGoHwTwKZplGQuWKcqExFgepgLMHA();
		}

		public void LgvawPzGNUDyiaXZekOaOmKgVwNkA()
		{
			QvHWHtoMxrwMgHUVeUtOdvGmmMfh.ElNgolIhwBSfKIBrwXIriUbYJdhV = 0;
			QvHWHtoMxrwMgHUVeUtOdvGmmMfh.PehirlkKoPPgMNmqKSQeKPBmXBgAA = 0;
			qGoHwTwKZplGQuWKcqExFgepgLMHA();
		}

		public void KLsVneQGvosBxGpbKKIyIFHgQYbE()
		{
			QvHWHtoMxrwMgHUVeUtOdvGmmMfh.ElNgolIhwBSfKIBrwXIriUbYJdhV = 0;
			QvHWHtoMxrwMgHUVeUtOdvGmmMfh.PehirlkKoPPgMNmqKSQeKPBmXBgAA = 0;
			lock (qhtJNiTIeSZOxcQSvaMhgRBpCyDm)
			{
				lock (JKrvVllnhjRjrLsPKwRrllrsqno)
				{
					loSMrZyExgXbSLpeUNiQGBDqFkiiA.Clear();
					XZGAWsYNIXeogLemIqsZJFJPmWT.Clear();
					xiPXKjBRHCmywJnRgebEuAnqROQd(CtwhuyyQIAolqaPHmDaKOAqjCzGz, QvHWHtoMxrwMgHUVeUtOdvGmmMfh, ref CsPlNXLeeLNrpOSHdahQBeAaPuAK);
				}
			}
		}

		public void NwpcqdiRcGSPujMDtsTQZmCZLZGZA()
		{
			if (!GOvBeNcwlLHABPWhiWNSGJFNTLMq || !bAwauhvNsOacJirRSnbTkwsxIUFL)
			{
				return;
			}
			DthKZXUAHQnsCHloLMbBfxPrIUcV dthKZXUAHQnsCHloLMbBfxPrIUcV;
			double realTime;
			try
			{
				if (!CtwhuyyQIAolqaPHmDaKOAqjCzGz.HDHgAAdpaqgsMsTXFiSIYfjZhoGs(out dthKZXUAHQnsCHloLMbBfxPrIUcV))
				{
					bAwauhvNsOacJirRSnbTkwsxIUFL = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				bAwauhvNsOacJirRSnbTkwsxIUFL = false;
				return;
			}
			lock (aVHphFAQAxhcwXijJvrmpphNCjlS)
			{
				if (!fpxZpmzZzdgpQQgHdhrxffsNpZTcA(dthKZXUAHQnsCHloLMbBfxPrIUcV.hrVNHqsPgXSiwKSupjHkRevaZTwj, rrpGavfgBZPtxCMghsyoDPPquzPE))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = USIOmVLCGHwhRCbiSJGpTPbmWSGH.T_CreateEvent())
					{
						RUmuqywToUPJJdzkwDZbpHQbmCnC(ref dthKZXUAHQnsCHloLMbBfxPrIUcV.hrVNHqsPgXSiwKSupjHkRevaZTwj, realTime, newEventWrapper.Event);
					}
					rrpGavfgBZPtxCMghsyoDPPquzPE = dthKZXUAHQnsCHloLMbBfxPrIUcV.hrVNHqsPgXSiwKSupjHkRevaZTwj;
				}
			}
		}

		public void DinTTuYcVfitWXbhWkknrkQDAEUgA()
		{
			if (!GOvBeNcwlLHABPWhiWNSGJFNTLMq || !bAwauhvNsOacJirRSnbTkwsxIUFL || ReInput.realTime < CsPlNXLeeLNrpOSHdahQBeAaPuAK + 0.009999999776482582)
			{
				return;
			}
			lock (qhtJNiTIeSZOxcQSvaMhgRBpCyDm)
			{
				lock (JKrvVllnhjRjrLsPKwRrllrsqno)
				{
					MiscTools.Swap(ref loSMrZyExgXbSLpeUNiQGBDqFkiiA, ref XZGAWsYNIXeogLemIqsZJFJPmWT);
				}
				PkfdyWDyNZvBuVySqAZVhoppxeIx(XZGAWsYNIXeogLemIqsZJFJPmWT, CtwhuyyQIAolqaPHmDaKOAqjCzGz, ref CsPlNXLeeLNrpOSHdahQBeAaPuAK);
			}
		}

		private void ANhDkOhCvLJUERwYglDupfbRZVvbA()
		{
			LsepCJJUpFrFnsDQCbqjuFLbVuEE();
		}

		private void LsepCJJUpFrFnsDQCbqjuFLbVuEE()
		{
			if (!(ReInput.realTime < CsPlNXLeeLNrpOSHdahQBeAaPuAK + 1.5) && (!Mathf.Approximately((int)QvHWHtoMxrwMgHUVeUtOdvGmmMfh.ElNgolIhwBSfKIBrwXIriUbYJdhV, 0f) || !Mathf.Approximately((int)QvHWHtoMxrwMgHUVeUtOdvGmmMfh.PehirlkKoPPgMNmqKSQeKPBmXBgAA, 0f)))
			{
				qGoHwTwKZplGQuWKcqExFgepgLMHA();
			}
		}

		private void qGoHwTwKZplGQuWKcqExFgepgLMHA()
		{
			lock (JKrvVllnhjRjrLsPKwRrllrsqno)
			{
				loSMrZyExgXbSLpeUNiQGBDqFkiiA.Enqueue(QvHWHtoMxrwMgHUVeUtOdvGmmMfh);
			}
		}

		private static void PkfdyWDyNZvBuVySqAZVhoppxeIx(RingBuffer<EnTOzHRkIdPCTFPEBBSpMiCrzLkt> P_0, vGGTrJYhTUTICHVqMwYNbLNmpYAI P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				xiPXKjBRHCmywJnRgebEuAnqROQd(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void xiPXKjBRHCmywJnRgebEuAnqROQd(vGGTrJYhTUTICHVqMwYNbLNmpYAI P_0, EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_1, ref double P_2)
		{
			try
			{
				P_0.OKyBvjMQBBGYNVCFokYgeFRAXipD(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void bnWXZytGezthDCRQhqBiJmOJgJrfA(ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_0)
		{
			while (USIOmVLCGHwhRCbiSJGpTPbmWSGH.ProcessNewEvents())
			{
				ZxDlPoPKWhdBbgDLCETDcGiFJNzQB(ref P_0, ref USIOmVLCGHwhRCbiSJGpTPbmWSGH.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					hSFnGuJevNzVzDnCOipeORJBAaNBA.SetValue(i, XdppyxAPeLHvvGUgSjliOKfQZDXX((int)P_0.sqNgWaqABXqFjBjmSkWyzUdATxfm, i), USIOmVLCGHwhRCbiSJGpTPbmWSGH.currentEvent.GetTimestamp());
				}
			}
		}

		private void RUmuqywToUPJJdzkwDZbpHQbmCnC(ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int sqNgWaqABXqFjBjmSkWyzUdATxfm = (int)P_0.sqNgWaqABXqFjBjmSkWyzUdATxfm;
			P_2.SetButtonsBitMask((sqNgWaqABXqFjBjmSkWyzUdATxfm & 0x7FF) | ((sqNgWaqABXqFjBjmSkWyzUdATxfm & (sqNgWaqABXqFjBjmSkWyzUdATxfm & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, rVMMGASzCkPEsIAeIiERncUZINEx(P_0.ChFfsPaAQTONjpJWGdWsMLcQqLqrA));
			P_2.SetAxisValue(1, rVMMGASzCkPEsIAeIiERncUZINEx(P_0.nbSzTDEZOLpTmmFfwMdfifApaNRW));
			P_2.SetAxisValue(2, rVMMGASzCkPEsIAeIiERncUZINEx(P_0.OeOhtbcWrmKsEquUIZOdGOURhyyx));
			P_2.SetAxisValue(3, rVMMGASzCkPEsIAeIiERncUZINEx(P_0.eDPlRilVaynUFcwehupnUXymeneA));
			P_2.SetAxisValue(4, EwWDqPKRhbXijhbPMWzPQQVPjQKjA(P_0.YbtvPVOoDEHWDBVkbRcllkCrqaTz));
			P_2.SetAxisValue(5, EwWDqPKRhbXijhbPMWzPQQVPjQKjA(P_0.TrGGTObIsXboJyzyyfVTbRuEPEAXA));
		}

		private void ZxDlPoPKWhdBbgDLCETDcGiFJNzQB(ref tSKGrXdRrweIRabtOUkjDjrHCHgxB P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.sqNgWaqABXqFjBjmSkWyzUdATxfm = (qGSpbqvOjqFzvFGZqoPNBhUQsabp)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.ChFfsPaAQTONjpJWGdWsMLcQqLqrA = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.nbSzTDEZOLpTmmFfwMdfifApaNRW = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.OeOhtbcWrmKsEquUIZOdGOURhyyx = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.eDPlRilVaynUFcwehupnUXymeneA = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.YbtvPVOoDEHWDBVkbRcllkCrqaTz = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.TrGGTObIsXboJyzyyfVTbRuEPEAXA = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool XdppyxAPeLHvvGUgSjliOKfQZDXX(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void KDmQOfpqHjzxvLdcMddKjWqCOefS()
		{
			lock (aVHphFAQAxhcwXijJvrmpphNCjlS)
			{
				wayAdifhfFDvFivyEdIjZMKhJJxkA = default(tSKGrXdRrweIRabtOUkjDjrHCHgxB);
				rrpGavfgBZPtxCMghsyoDPPquzPE = default(tSKGrXdRrweIRabtOUkjDjrHCHgxB);
				hSFnGuJevNzVzDnCOipeORJBAaNBA.Clear();
				USIOmVLCGHwhRCbiSJGpTPbmWSGH.Clear();
			}
		}

		public void Dispose()
		{
			xuuYRABqzjtUUuFFLiTSspnaGvFf(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void EhwpSSEhewgCEgjecEtbrcrGPyIBb()
		{
			try
			{
				xuuYRABqzjtUUuFFLiTSspnaGvFf(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void xuuYRABqzjtUUuFFLiTSspnaGvFf(bool P_0)
		{
			if (!llihafEwehNsZtJuKUSDVgWwrHhV)
			{
				if (P_0)
				{
					USIOmVLCGHwhRCbiSJGpTPbmWSGH.Dispose();
				}
				llihafEwehNsZtJuKUSDVgWwrHhV = true;
			}
		}

		public static float rVMMGASzCkPEsIAeIiERncUZINEx(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float EwWDqPKRhbXijhbPMWzPQQVPjQKjA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool fpxZpmzZzdgpQQgHdhrxffsNpZTcA(tSKGrXdRrweIRabtOUkjDjrHCHgxB P_0, tSKGrXdRrweIRabtOUkjDjrHCHgxB P_1)
		{
			if (P_0.sqNgWaqABXqFjBjmSkWyzUdATxfm == P_1.sqNgWaqABXqFjBjmSkWyzUdATxfm && P_0.YbtvPVOoDEHWDBVkbRcllkCrqaTz == P_1.YbtvPVOoDEHWDBVkbRcllkCrqaTz && P_0.TrGGTObIsXboJyzyyfVTbRuEPEAXA == P_1.TrGGTObIsXboJyzyyfVTbRuEPEAXA && P_0.ChFfsPaAQTONjpJWGdWsMLcQqLqrA == P_1.ChFfsPaAQTONjpJWGdWsMLcQqLqrA && P_0.nbSzTDEZOLpTmmFfwMdfifApaNRW == P_1.nbSzTDEZOLpTmmFfwMdfifApaNRW && P_0.OeOhtbcWrmKsEquUIZOdGOURhyyx == P_1.OeOhtbcWrmKsEquUIZOdGOURhyyx)
			{
				return P_0.eDPlRilVaynUFcwehupnUXymeneA == P_1.eDPlRilVaynUFcwehupnUXymeneA;
			}
			return false;
		}
	}

	public enum nWOiPPRVPKmKBBmSXrkkRYZldNeQ
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int ejgtnCpOtYhMvWAmnmbsVbJsOAgs = 4;

	public const int IauWeNdTFHlGyQsNBMkxHoCMfRNJ = 32768;

	public const int CqOfcjgmqejUgINuPFoOqwUKudLZ = -32768;

	public const int ZcecxHjqoVduQYAXhChWBUAzjhkhb = 255;

	public const int iDNCrdyGYSGSJwNYWgXJPjhzEIAFA = 0;

	public const int VlXysaSXxPbJbBavMPyFQchlXuyK = 18;

	public const int KwebNKEaUzNYcLaVQdHDtfokKbGGb = 14;

	public const int VDvGMNOXogxEgympJnfomLsCHKNQ = 6;

	public const int uBMLLniaFqIkLCNqixEANHOtEnqQ = 15;

	private yqAxqAlnBRGEMOozeADaxHAkyChi[] ZyZbSlFeTnuUoblorqgbdJMcUtvG;

	private bool KCgAWucbNzyTfBgEaBfRABjBKAPt;

	private OKDKWSKRNoSzctSXuqEEGtNlZDaE oCXFCYwmNCOWsUyBVokCekczpxDC;

	private iLRxQrDopoTLStVOdcfxvzBputqv EwIBAuGdYApbqrTamFbjvreQGnxY;

	private global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool> YTduJSRqkaiCPbXEdKuWRapYcMZHb;

	private bool[] iCJSdDhuHEhaHWeUlcYAgxnFfOPRA;

	private bool[] uNRLltQnhcEMlIGFXCJzApdSZkLk;

	private bool KHlRjRrvehFBjwcKEvqiXDhezdiF;

	private readonly bool HPgpPAnbDWrtSGUuFAyqXdeLDWjg;

	private readonly UpdateLoopSetting gVgndFUEsbdxHoulLPmZyKYoUcHT;

	private UpdateLoopType YkQnuaTnrBBHduvYyKLUqupjxoQM;

	private UpdateLoopType HqAuGTRxQOphcYwuLJpZpeCZLrUr;

	private Action<int, ControllerDataUpdater> AXNpEtbAgfveYPiMeYGcOqRoUxWG;

	private bool dESteNhbNEGtXGjggkaJcqPCXqsU;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> DyWdiqIdSpYlGmqTFFTmDzuarKKAB;

	private Func<int> wbodmQerSpAFWYAjOpfLVvvAyciP;

	private Func<PidVid, bool> fYfaiGHtByGlHpRnmtawIliAWIUsA;

	private static Guid[] hFxcbchgLjoeqHTDugXIdupGmpHWB;

	private static string[] tUDZbTUYaSVsYhFedscCCEIhIpWj;

	private static string[] eKsoIgsDffcDNDmuAoPOLIMpYcVwA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].NspkgpUEWXXsPFnuSxrBXpgalMDq)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.XInput;

	BfkroJQJTBQveeRAQgPngoAAkNXDA tfBBbpYawsTqFdIUEKOlukvpcHoaA.LOvasvOmEsbxrYXtJjcXioULXOUC => BfkroJQJTBQveeRAQgPngoAAkNXDA.XInput;

	public dthckWzdCvyytSjahUhAscVvCaQb(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		HPgpPAnbDWrtSGUuFAyqXdeLDWjg = P_0;
		gVgndFUEsbdxHoulLPmZyKYoUcHT = P_1;
		fYfaiGHtByGlHpRnmtawIliAWIUsA = P_4;
		dESteNhbNEGtXGjggkaJcqPCXqsU = true;
		try
		{
			if (!EJqfQyyvppiQRwtOQClnSRtsWpmI.DUXFlHeQoyoXAsxLPqhsXZxLdSxE(out var osmjxKLuEDgHrYkWJcPKjDxVvElW, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (osmjxKLuEDgHrYkWJcPKjDxVvElW < OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			DyWdiqIdSpYlGmqTFFTmDzuarKKAB = P_2;
			wbodmQerSpAFWYAjOpfLVvvAyciP = P_3;
			KHlRjRrvehFBjwcKEvqiXDhezdiF = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(gVgndFUEsbdxHoulLPmZyKYoUcHT, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					HqAuGTRxQOphcYwuLJpZpeCZLrUr = list[num2];
				}
			}
			YTduJSRqkaiCPbXEdKuWRapYcMZHb = new global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool>(true, PnxISoAluOunHwbblpQCtpjFHDdf);
			iCJSdDhuHEhaHWeUlcYAgxnFfOPRA = new bool[4];
			uNRLltQnhcEMlIGFXCJzApdSZkLk = new bool[4];
			AXNpEtbAgfveYPiMeYGcOqRoUxWG = UpdateControllerData;
			if (KHlRjRrvehFBjwcKEvqiXDhezdiF)
			{
				liIlqUCscWWEEisvAokwPpOGrIrq();
			}
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
		if (dESteNhbNEGtXGjggkaJcqPCXqsU)
		{
			oCXFCYwmNCOWsUyBVokCekczpxDC = new OKDKWSKRNoSzctSXuqEEGtNlZDaE(1f);
		}
		EwIBAuGdYApbqrTamFbjvreQGnxY = new iLRxQrDopoTLStVOdcfxvzBputqv();
		if (ZyZbSlFeTnuUoblorqgbdJMcUtvG == null)
		{
			ZyZbSlFeTnuUoblorqgbdJMcUtvG = new yqAxqAlnBRGEMOozeADaxHAkyChi[4];
			for (int i = 0; i < 4; i++)
			{
				iUVRQWivcUcvaWpmaoyYGuTThrFS iUVRQWivcUcvaWpmaoyYGuTThrFS2 = new iUVRQWivcUcvaWpmaoyYGuTThrFS(i, gVgndFUEsbdxHoulLPmZyKYoUcHT);
				rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent += iUVRQWivcUcvaWpmaoyYGuTThrFS2.NwpcqdiRcGSPujMDtsTQZmCZLZGZA;
				rGfCWQcoVBNNMLBCPGciUTleuQNNA.IQHdtlmEcHWkbcxkRQYEKZGhVkzr.ThreadUpdateEvent += iUVRQWivcUcvaWpmaoyYGuTThrFS2.DinTTuYcVfitWXbhWkknrkQDAEUgA;
				ZyZbSlFeTnuUoblorqgbdJMcUtvG[i] = new yqAxqAlnBRGEMOozeADaxHAkyChi(i, KHlRjRrvehFBjwcKEvqiXDhezdiF, iUVRQWivcUcvaWpmaoyYGuTThrFS2, DyWdiqIdSpYlGmqTFFTmDzuarKKAB, SystemDeviceDisconnected);
			}
		}
		xPOEsmwhVJZxTdmlyxCMKnjGPFfD(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		YkQnuaTnrBBHduvYyKLUqupjxoQM = currentUpdateLoop;
		inqGTycSgblHHgWxmOooJUkHJEPm();
		for (int i = 0; i < 4; i++)
		{
			if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[i] != null && ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].NspkgpUEWXXsPFnuSxrBXpgalMDq)
			{
				ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (YTduJSRqkaiCPbXEdKuWRapYcMZHb != null)
		{
			YTduJSRqkaiCPbXEdKuWRapYcMZHb.mkQAsPQkdBLuRVdsGBfjsPGJgaIJ();
		}
		if (ZyZbSlFeTnuUoblorqgbdJMcUtvG != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[i] != null)
				{
					if (rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb != null)
					{
						rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent -= ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].yRqdrNmDbEdbTsUZnsFoyzplfvmp.NwpcqdiRcGSPujMDtsTQZmCZLZGZA;
					}
					if (rGfCWQcoVBNNMLBCPGciUTleuQNNA.IQHdtlmEcHWkbcxkRQYEKZGhVkzr != null)
					{
						rGfCWQcoVBNNMLBCPGciUTleuQNNA.IQHdtlmEcHWkbcxkRQYEKZGhVkzr.ThreadUpdateEvent -= ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].yRqdrNmDbEdbTsUZnsFoyzplfvmp.DinTTuYcVfitWXbhWkknrkQDAEUgA;
					}
					ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].Dispose();
				}
			}
		}
		EJqfQyyvppiQRwtOQClnSRtsWpmI.KhHczRVRCYffckxXhBrPoDtwmFLg();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return AXNpEtbAgfveYPiMeYGcOqRoUxWG;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		ZyZbSlFeTnuUoblorqgbdJMcUtvG[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		xPOEsmwhVJZxTdmlyxCMKnjGPFfD(true);
		pcczuxgCBsapWbyqmLcVLoPIEKVfA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		xPOEsmwhVJZxTdmlyxCMKnjGPFfD(true);
		pcczuxgCBsapWbyqmLcVLoPIEKVfA();
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

	bool tfBBbpYawsTqFdIUEKOlukvpcHoaA.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (fYfaiGHtByGlHpRnmtawIliAWIUsA(pidVid))
		{
			return false;
		}
		return xJqlOvayEkTLXMNRTeypBWPsmdWM(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool XMAuSofcjVJarwNvrtQixlYFMWtC()
	{
		if (YkQnuaTnrBBHduvYyKLUqupjxoQM != HqAuGTRxQOphcYwuLJpZpeCZLrUr)
		{
			return false;
		}
		bool num = oCXFCYwmNCOWsUyBVokCekczpxDC.oYBuomNWkBlBSWALCFGKGPohlKTy();
		if (num)
		{
			xPOEsmwhVJZxTdmlyxCMKnjGPFfD(true);
		}
		return num;
	}

	private void xPOEsmwhVJZxTdmlyxCMKnjGPFfD(bool P_0)
	{
		KCgAWucbNzyTfBgEaBfRABjBKAPt = P_0;
		if (dESteNhbNEGtXGjggkaJcqPCXqsU)
		{
			oCXFCYwmNCOWsUyBVokCekczpxDC.TpqbTIzVqqycHwGYpePGCVBWTrMA();
		}
	}

	private void pcczuxgCBsapWbyqmLcVLoPIEKVfA()
	{
		if (YTduJSRqkaiCPbXEdKuWRapYcMZHb != null)
		{
			YTduJSRqkaiCPbXEdKuWRapYcMZHb.xnbcVceCutMoVtiQkYEiIptfhcNmA();
		}
	}

	private void liIlqUCscWWEEisvAokwPpOGrIrq()
	{
		_ = new vGGTrJYhTUTICHVqMwYNbLNmpYAI().ZVizaChOLvQLBsBSFqQDtCFAqnkQ;
	}

	private void inqGTycSgblHHgWxmOooJUkHJEPm()
	{
		bool flag = false;
		if (dESteNhbNEGtXGjggkaJcqPCXqsU)
		{
			flag = XMAuSofcjVJarwNvrtQixlYFMWtC();
		}
		if (!flag && KCgAWucbNzyTfBgEaBfRABjBKAPt)
		{
			gfsGTsKllNAmnfSVifgGAOrboOiqd(wgTPixhCGhlDAJiEhacKJVPOZpKmA());
			xPOEsmwhVJZxTdmlyxCMKnjGPFfD(false);
			pcczuxgCBsapWbyqmLcVLoPIEKVfA();
			return;
		}
		if (KCgAWucbNzyTfBgEaBfRABjBKAPt)
		{
			BTHojwkbqUFGXTTWVAiYBATqWsrOA();
		}
		if (YTduJSRqkaiCPbXEdKuWRapYcMZHb.rYnfxXQpvqMpOJxdAcMymuXfVPdJ && YTduJSRqkaiCPbXEdKuWRapYcMZHb.hRRQBhRlrNLlIwAAvCWMAegGhfdIA())
		{
			XVrfKSLFUuEDkjutUPnaPVNVzppT();
		}
	}

	private void BTHojwkbqUFGXTTWVAiYBATqWsrOA()
	{
		KCgAWucbNzyTfBgEaBfRABjBKAPt = false;
		if (!YTduJSRqkaiCPbXEdKuWRapYcMZHb.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
		{
			YTduJSRqkaiCPbXEdKuWRapYcMZHb.ZRNxDcQZRiFYRKxfnaKLNAFnscDt();
		}
	}

	private void XVrfKSLFUuEDkjutUPnaPVNVzppT()
	{
		lock (iCJSdDhuHEhaHWeUlcYAgxnFfOPRA)
		{
			Array.Copy(iCJSdDhuHEhaHWeUlcYAgxnFfOPRA, uNRLltQnhcEMlIGFXCJzApdSZkLk, 4);
		}
		gfsGTsKllNAmnfSVifgGAOrboOiqd(uNRLltQnhcEMlIGFXCJzApdSZkLk);
	}

	private bool PnxISoAluOunHwbblpQCtpjFHDdf()
	{
		lock (iCJSdDhuHEhaHWeUlcYAgxnFfOPRA)
		{
			for (int i = 0; i < 4; i++)
			{
				if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[i] != null)
				{
					iCJSdDhuHEhaHWeUlcYAgxnFfOPRA[i] = ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].gvKdivDthMpRrZaFCTFCOYwBfsNT(nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] wgTPixhCGhlDAJiEhacKJVPOZpKmA()
	{
		for (int i = 0; i < 4; i++)
		{
			uNRLltQnhcEMlIGFXCJzApdSZkLk[i] = ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].gvKdivDthMpRrZaFCTFCOYwBfsNT(nWOiPPRVPKmKBBmSXrkkRYZldNeQ.Synchronous);
		}
		return uNRLltQnhcEMlIGFXCJzApdSZkLk;
	}

	private void gfsGTsKllNAmnfSVifgGAOrboOiqd(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[i] != null && ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].wiiQFTAuvUjkJAGIRBgTaISxTCkFA)
			{
				bool flag = P_0[i];
				ZyZbSlFeTnuUoblorqgbdJMcUtvG[i].osRxgWZXLlBXWjeOMIgWqOnbRYTR(flag);
				if (!flag)
				{
					IoWYVsyzCACcWDwGBikOGgnPrfUs(ZyZbSlFeTnuUoblorqgbdJMcUtvG[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[j] != null && !ZyZbSlFeTnuUoblorqgbdJMcUtvG[j].wiiQFTAuvUjkJAGIRBgTaISxTCkFA)
			{
				bool flag2 = P_0[j];
				ZyZbSlFeTnuUoblorqgbdJMcUtvG[j].osRxgWZXLlBXWjeOMIgWqOnbRYTR(flag2);
				if (flag2 && !IoWYVsyzCACcWDwGBikOGgnPrfUs(ZyZbSlFeTnuUoblorqgbdJMcUtvG[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (ZyZbSlFeTnuUoblorqgbdJMcUtvG[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					ZyZbSlFeTnuUoblorqgbdJMcUtvG[k].ujYhiYgHFLnyFDRgmlwgTBZRWCNj(P_0[k]);
				}
			}
		}
	}

	private bool IoWYVsyzCACcWDwGBikOGgnPrfUs(yqAxqAlnBRGEMOozeADaxHAkyChi P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.fGPDRswvLETqoNxopBUkmMuRctwHA();
			if (!P_0.giyxCsODTxvaYkpPvYedXzKlQeCd)
			{
				return false;
			}
			int num = EwIBAuGdYApbqrTamFbjvreQGnxY.ixmZcxpIefLMrxkoIKeAQgWsGbxl(P_0.VnNQLrrmUtEZYEvvoQubXVmRDIFgA, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = EwIBAuGdYApbqrTamFbjvreQGnxY.uLBoQQcuermdpNYQBLpiTqECCoNfA(num);
				EwIBAuGdYApbqrTamFbjvreQGnxY.YfdBCdKxhvGiNDCrTWOCJURfOsJS(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = wbodmQerSpAFWYAjOpfLVvvAyciP();
				EwIBAuGdYApbqrTamFbjvreQGnxY.VmGNLFESOUZlOMSjeuagpgedbJuE(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = EwIBAuGdYApbqrTamFbjvreQGnxY.hIXmkiwwiDPDDkKfXVuTXFnxCJyd(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.VnNQLrrmUtEZYEvvoQubXVmRDIFgA, true);
			if (num2 >= 0)
			{
				EwIBAuGdYApbqrTamFbjvreQGnxY.vGuuwOHSdiCCkPnazrSpxCgRHgQR(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.ogvHnphmBJNrOAjexhJHufsgtFmp();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static dthckWzdCvyytSjahUhAscVvCaQb()
	{
		hFxcbchgLjoeqHTDugXIdupGmpHWB = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		tUDZbTUYaSVsYhFedscCCEIhIpWj = new string[1] { "Xbox Bluetooth Gamepad" };
		eKsoIgsDffcDNDmuAoPOLIMpYcVwA = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool xJqlOvayEkTLXMNRTeypBWPsmdWM(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(hFxcbchgLjoeqHTDugXIdupGmpHWB, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < tUDZbTUYaSVsYhFedscCCEIhIpWj.Length; i++)
			{
				if (P_1.Equals(tUDZbTUYaSVsYhFedscCCEIhIpWj[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < eKsoIgsDffcDNDmuAoPOLIMpYcVwA.Length; j++)
			{
				if (Regex.IsMatch(P_2, eKsoIgsDffcDNDmuAoPOLIMpYcVwA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
