using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs SszgbtHOrYEVZCiavpeHjeUdYEHD;

		private float[] gLMpapAXVdcsBIDLDVjWCKhCGWAi;

		private Vector2 ctCEBnclQdYIFKzGOHbQUiuiWZfF;

		private Vector2 eXXUQvfvptsScDkRpeCjEAKIyECE;

		private int UdgFECMELpAqajvfRtdqroWYJTUh;

		private readonly IUnifiedMouseSource NsRIQHseimotuEJGoIuiBqmlsEN;

		private static Guid IQcFpAKvLgzUgbAfXoMHZXcNPEzT;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				return ctCEBnclQdYIFKzGOHbQUiuiWZfF;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				return eXXUQvfvptsScDkRpeCjEAKIyECE;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				return ctCEBnclQdYIFKzGOHbQUiuiWZfF - eXXUQvfvptsScDkRpeCjEAKIyECE;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return IQcFpAKvLgzUgbAfXoMHZXcNPEzT;
			}
		}

		internal Mouse(string name, IUnifiedMouseSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.axisCount, source.buttonCount, source.hardwareMap, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, source.axisCount, source.buttonCount, null))
		{
			NsRIQHseimotuEJGoIuiBqmlsEN = source;
			IQcFpAKvLgzUgbAfXoMHZXcNPEzT = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			guKElsGLCmgnAbWmxWZxRdTPwg();
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
		}

		internal override void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			NsRIQHseimotuEJGoIuiBqmlsEN.UpdateInputData(ebxBmtwxyRprAbJBnnRdvbVCKbL);
			base.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			DsmHliKiEsrSzauokHlgMyMsJNP();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (gLMpapAXVdcsBIDLDVjWCKhCGWAi == null)
			{
				gLMpapAXVdcsBIDLDVjWCKhCGWAi = new float[_axisCount];
			}
			if (SszgbtHOrYEVZCiavpeHjeUdYEHD == null)
			{
				SszgbtHOrYEVZCiavpeHjeUdYEHD = new TimerAbs(1.0);
			}
			if (SszgbtHOrYEVZCiavpeHjeUdYEHD.Update() || !SszgbtHOrYEVZCiavpeHjeUdYEHD.running)
			{
				SszgbtHOrYEVZCiavpeHjeUdYEHD.Start();
				Array.Clear(gLMpapAXVdcsBIDLDVjWCKhCGWAi, 0, gLMpapAXVdcsBIDLDVjWCKhCGWAi.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				gLMpapAXVdcsBIDLDVjWCKhCGWAi[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				gLMpapAXVdcsBIDLDVjWCKhCGWAi[index] += axes[index].valueRaw;
			}
			float num = gLMpapAXVdcsBIDLDVjWCKhCGWAi[index];
			if (MathTools.Abs(num) <= axes[index].effectivePollingDeadZone)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = ZBMEOTEbHBcUeYYftsfiohhXNEse.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			SszgbtHOrYEVZCiavpeHjeUdYEHD.running = false;
			return true;
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			base.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			if (SszgbtHOrYEVZCiavpeHjeUdYEHD != null)
			{
				SszgbtHOrYEVZCiavpeHjeUdYEHD.Clear();
			}
			ctCEBnclQdYIFKzGOHbQUiuiWZfF = Vector2.zero;
			eXXUQvfvptsScDkRpeCjEAKIyECE = Vector2.zero;
		}

		internal override bool aUkrKZZmuugskAJZrmbqBXhTEuO(bool P_0)
		{
			if (!base.aUkrKZZmuugskAJZrmbqBXhTEuO(P_0))
			{
				return false;
			}
			if (P_0)
			{
				DsmHliKiEsrSzauokHlgMyMsJNP();
				eXXUQvfvptsScDkRpeCjEAKIyECE = screenPosition;
			}
			return true;
		}

		private void DsmHliKiEsrSzauokHlgMyMsJNP()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != UdgFECMELpAqajvfRtdqroWYJTUh)
			{
				eXXUQvfvptsScDkRpeCjEAKIyECE = ctCEBnclQdYIFKzGOHbQUiuiWZfF;
				ctCEBnclQdYIFKzGOHbQUiuiWZfF = NsRIQHseimotuEJGoIuiBqmlsEN.mousePosition;
				UdgFECMELpAqajvfRtdqroWYJTUh = currentUnityFrame;
			}
		}
	}
}
