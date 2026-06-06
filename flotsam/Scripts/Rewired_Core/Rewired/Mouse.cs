using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs EccTZodABnVrwljxsuZMWFHOWSIc;

		private float[] vEihrraGrVTvObTJzaeCAGzaLSPJ;

		private Vector2 rwHMqUrkYxYvYZAxMuxlTiVgQFJT;

		private Vector2 pAjCUDcYKDwevpRqHKOLnnBwVnSwA;

		private int LvyGAzjiMCEEEFxnsyMntqdmztXR;

		private readonly IUnifiedMouseSource IvYlkYVJbebQyUQCuraQcMuVlvgx;

		private static Guid tKHfAEEiGNWaVhtNiPLnDQCKXxeI;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Vector2.zero;
				}
				return rwHMqUrkYxYvYZAxMuxlTiVgQFJT;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Vector2.zero;
				}
				return pAjCUDcYKDwevpRqHKOLnnBwVnSwA;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Vector2.zero;
				}
				return rwHMqUrkYxYvYZAxMuxlTiVgQFJT - pAjCUDcYKDwevpRqHKOLnnBwVnSwA;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Guid.Empty;
				}
				return tKHfAEEiGNWaVhtNiPLnDQCKXxeI;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			IvYlkYVJbebQyUQCuraQcMuVlvgx = P_1;
			tKHfAEEiGNWaVhtNiPLnDQCKXxeI = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			jcuaGkxKxwRQhPfLTgjWpYLcOGCK();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void htEklxyAaOuSMsPCupWUksULABBY(UpdateLoopType P_0)
		{
			IvYlkYVJbebQyUQCuraQcMuVlvgx.UpdateInputData(vAJlxjrsCepUBGzroHjWcArmXQkU);
			QJtejDrikfTcXiOVZAOExcIHSejO(P_0);
			gWxtylKlHMgKFXqYOuLHGLXSRvdY();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (vEihrraGrVTvObTJzaeCAGzaLSPJ == null)
			{
				vEihrraGrVTvObTJzaeCAGzaLSPJ = new float[_axisCount];
			}
			if (EccTZodABnVrwljxsuZMWFHOWSIc == null)
			{
				EccTZodABnVrwljxsuZMWFHOWSIc = new TimerAbs(1.0);
			}
			if (EccTZodABnVrwljxsuZMWFHOWSIc.Update() || !EccTZodABnVrwljxsuZMWFHOWSIc.running)
			{
				EccTZodABnVrwljxsuZMWFHOWSIc.Start();
				Array.Clear(vEihrraGrVTvObTJzaeCAGzaLSPJ, 0, vEihrraGrVTvObTJzaeCAGzaLSPJ.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				vEihrraGrVTvObTJzaeCAGzaLSPJ[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				vEihrraGrVTvObTJzaeCAGzaLSPJ[index] += axes[index].valueRaw;
			}
			float num = vEihrraGrVTvObTJzaeCAGzaLSPJ[index];
			if (MathTools.Abs(num) <= axes[index].QotXiKTAnzsOoreyziOokgBIJBeF)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = JEexZOPzSUUjNTHjvxywblgJdFqE.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			EccTZodABnVrwljxsuZMWFHOWSIc.running = false;
			return true;
		}

		internal void GOwtPbIgjQFtiEgDyyWPQtumayPq()
		{
			cubHyftKveceaSGovHckWjlTpqaN();
			if (EccTZodABnVrwljxsuZMWFHOWSIc != null)
			{
				EccTZodABnVrwljxsuZMWFHOWSIc.Clear();
			}
			rwHMqUrkYxYvYZAxMuxlTiVgQFJT = Vector2.zero;
			pAjCUDcYKDwevpRqHKOLnnBwVnSwA = Vector2.zero;
		}

		internal bool cINMMKiFYzIDAuUuHDaCLgOsICdW(bool P_0)
		{
			if (!base.JErfaHktCKVFtNnhTKDJdWzTRcaq(P_0))
			{
				return false;
			}
			if (IvYlkYVJbebQyUQCuraQcMuVlvgx is IGetSetEnabled)
			{
				(IvYlkYVJbebQyUQCuraQcMuVlvgx as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				gWxtylKlHMgKFXqYOuLHGLXSRvdY();
				pAjCUDcYKDwevpRqHKOLnnBwVnSwA = screenPosition;
			}
			return true;
		}

		private void gWxtylKlHMgKFXqYOuLHGLXSRvdY()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != LvyGAzjiMCEEEFxnsyMntqdmztXR)
			{
				pAjCUDcYKDwevpRqHKOLnnBwVnSwA = rwHMqUrkYxYvYZAxMuxlTiVgQFJT;
				rwHMqUrkYxYvYZAxMuxlTiVgQFJT = IvYlkYVJbebQyUQCuraQcMuVlvgx.mousePosition;
				LvyGAzjiMCEEEFxnsyMntqdmztXR = currentUnityFrame;
			}
		}
	}
}
