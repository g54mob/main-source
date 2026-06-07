using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs fRKspYdVKdKirSgCQMaVGkveIHsB;

		private float[] QqIMRRahJVUnNIzKXSKzIDIQLoSf;

		private Vector2 GylsRaltRdDmJaKkycXCGVaELBSIA;

		private Vector2 MYNdjrGKZXdpusmlpLsodlsSnnZoA;

		private int gEQgbPhmDOBZDaqyUOcKzDSYCbECA;

		private readonly IUnifiedMouseSource pzcrVqLYiywZrbXPASmfsFPxjadL;

		private static Guid GzdEYyUFJXFtCKCtMbeMRdliNwfe;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Vector2.zero;
				}
				return GylsRaltRdDmJaKkycXCGVaELBSIA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Vector2.zero;
				}
				return MYNdjrGKZXdpusmlpLsodlsSnnZoA;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Vector2.zero;
				}
				return GylsRaltRdDmJaKkycXCGVaELBSIA - MYNdjrGKZXdpusmlpLsodlsSnnZoA;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Guid.Empty;
				}
				return GzdEYyUFJXFtCKCtMbeMRdliNwfe;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			pzcrVqLYiywZrbXPASmfsFPxjadL = P_1;
			GzdEYyUFJXFtCKCtMbeMRdliNwfe = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			CpCVLCxmguYfwaCGdHOlxVqCpGLv();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void KGqFYNuodCrNVPILImutwglvGHCR(UpdateLoopType P_0)
		{
			pzcrVqLYiywZrbXPASmfsFPxjadL.UpdateInputData(EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			flHIGtttxvNnQVLUjNmdvPvlaaau(P_0);
			TzLXJVOEOQbDSeSFaCtqGMiiWlaBA();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (QqIMRRahJVUnNIzKXSKzIDIQLoSf == null)
			{
				QqIMRRahJVUnNIzKXSKzIDIQLoSf = new float[_axisCount];
			}
			if (fRKspYdVKdKirSgCQMaVGkveIHsB == null)
			{
				fRKspYdVKdKirSgCQMaVGkveIHsB = new TimerAbs(1.0);
			}
			if (fRKspYdVKdKirSgCQMaVGkveIHsB.Update() || !fRKspYdVKdKirSgCQMaVGkveIHsB.running)
			{
				fRKspYdVKdKirSgCQMaVGkveIHsB.Start();
				Array.Clear(QqIMRRahJVUnNIzKXSKzIDIQLoSf, 0, QqIMRRahJVUnNIzKXSKzIDIQLoSf.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				QqIMRRahJVUnNIzKXSKzIDIQLoSf[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				QqIMRRahJVUnNIzKXSKzIDIQLoSf[index] += axes[index].valueRaw;
			}
			float num = QqIMRRahJVUnNIzKXSKzIDIQLoSf[index];
			if (MathTools.Abs(num) <= axes[index].FKowYLDhIdlyIzPFQTgaXGyHryB)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			fRKspYdVKdKirSgCQMaVGkveIHsB.running = false;
			return true;
		}

		internal void nCIfUPSbiOoerxPGUoggUrJMSsUu()
		{
			PVFaXVptkwbndlExJKIXMMEteizl();
			if (fRKspYdVKdKirSgCQMaVGkveIHsB != null)
			{
				fRKspYdVKdKirSgCQMaVGkveIHsB.Clear();
			}
			GylsRaltRdDmJaKkycXCGVaELBSIA = Vector2.zero;
			MYNdjrGKZXdpusmlpLsodlsSnnZoA = Vector2.zero;
		}

		internal bool HhnxmkqNwlXOBRtPhjDnLfAAMFsh(bool P_0)
		{
			if (!base.mqVKPhaeRMzKymnkzsnkxIOdysds(P_0))
			{
				return false;
			}
			if (pzcrVqLYiywZrbXPASmfsFPxjadL is IGetSetEnabled)
			{
				(pzcrVqLYiywZrbXPASmfsFPxjadL as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				TzLXJVOEOQbDSeSFaCtqGMiiWlaBA();
				MYNdjrGKZXdpusmlpLsodlsSnnZoA = screenPosition;
			}
			return true;
		}

		private void TzLXJVOEOQbDSeSFaCtqGMiiWlaBA()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != gEQgbPhmDOBZDaqyUOcKzDSYCbECA)
			{
				MYNdjrGKZXdpusmlpLsodlsSnnZoA = GylsRaltRdDmJaKkycXCGVaELBSIA;
				GylsRaltRdDmJaKkycXCGVaELBSIA = pzcrVqLYiywZrbXPASmfsFPxjadL.mousePosition;
				gEQgbPhmDOBZDaqyUOcKzDSYCbECA = currentUnityFrame;
			}
		}
	}
}
