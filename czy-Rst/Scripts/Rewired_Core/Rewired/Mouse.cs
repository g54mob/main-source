using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs NGHzJGgoZtzbATtdPWZRlPSzfoxy;

		private float[] mePHpchjHNzjnARJOMLQexwRChmWA;

		private Vector2 cmociXyTRzMHppBtpSEfqOAHFzwHA;

		private Vector2 odKKTSBJRHOeQfxyinGFInGTPprg;

		private int GNTYosmSVIkmdrBvZjxjYYqDTTgg;

		private readonly IUnifiedMouseSource TnxdsVKEisoeFieODARWBxvsUTDP;

		private static Guid stiDjHDuNNxseBrTHDalckNnptNeA;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Vector2.zero;
				}
				return cmociXyTRzMHppBtpSEfqOAHFzwHA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Vector2.zero;
				}
				return odKKTSBJRHOeQfxyinGFInGTPprg;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Vector2.zero;
				}
				return cmociXyTRzMHppBtpSEfqOAHFzwHA - odKKTSBJRHOeQfxyinGFInGTPprg;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Guid.Empty;
				}
				return stiDjHDuNNxseBrTHDalckNnptNeA;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			TnxdsVKEisoeFieODARWBxvsUTDP = P_1;
			stiDjHDuNNxseBrTHDalckNnptNeA = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			yAFKgfmSqcdzYvwLywJEIeWPEynEA();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void qonvywnatQgbpYHQZbfCLkVgKfet(UpdateLoopType P_0)
		{
			TnxdsVKEisoeFieODARWBxvsUTDP.UpdateInputData(ucqtfsuOTseRsybfPGjEFawPmfNK);
			TSIxZIyTztOcgIdRmpQWGcNoDGCV(P_0);
			xlKehiTGuEwrmzIgtgzDnSVhJVWe();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (mePHpchjHNzjnARJOMLQexwRChmWA == null)
			{
				mePHpchjHNzjnARJOMLQexwRChmWA = new float[_axisCount];
			}
			if (NGHzJGgoZtzbATtdPWZRlPSzfoxy == null)
			{
				NGHzJGgoZtzbATtdPWZRlPSzfoxy = new TimerAbs(1.0);
			}
			if (NGHzJGgoZtzbATtdPWZRlPSzfoxy.Update() || !NGHzJGgoZtzbATtdPWZRlPSzfoxy.running)
			{
				NGHzJGgoZtzbATtdPWZRlPSzfoxy.Start();
				Array.Clear(mePHpchjHNzjnARJOMLQexwRChmWA, 0, mePHpchjHNzjnARJOMLQexwRChmWA.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				mePHpchjHNzjnARJOMLQexwRChmWA[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				mePHpchjHNzjnARJOMLQexwRChmWA[index] += axes[index].valueRaw;
			}
			float num = mePHpchjHNzjnARJOMLQexwRChmWA[index];
			if (MathTools.Abs(num) <= axes[index].XpSsNXWTRdqOFZzqKORsXwzttbRs)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = UzVdrXbKoYScsNhLYrSoTUeynXDBb.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			NGHzJGgoZtzbATtdPWZRlPSzfoxy.running = false;
			return true;
		}

		internal void NTJqriDhgUiDVIsRJtbTqflVtQwTA()
		{
			pMAKFseXyurQXsyyUSZmzSuwdMXR();
			if (NGHzJGgoZtzbATtdPWZRlPSzfoxy != null)
			{
				NGHzJGgoZtzbATtdPWZRlPSzfoxy.Clear();
			}
			cmociXyTRzMHppBtpSEfqOAHFzwHA = Vector2.zero;
			odKKTSBJRHOeQfxyinGFInGTPprg = Vector2.zero;
		}

		internal bool pwsbAVdRVbwchYuwchyCccRJggAR(bool P_0)
		{
			if (!base.SXQqxQnpROfgArPviygPWFsoFYZS(P_0))
			{
				return false;
			}
			if (TnxdsVKEisoeFieODARWBxvsUTDP is IGetSetEnabled)
			{
				(TnxdsVKEisoeFieODARWBxvsUTDP as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				xlKehiTGuEwrmzIgtgzDnSVhJVWe();
				odKKTSBJRHOeQfxyinGFInGTPprg = screenPosition;
			}
			return true;
		}

		private void xlKehiTGuEwrmzIgtgzDnSVhJVWe()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != GNTYosmSVIkmdrBvZjxjYYqDTTgg)
			{
				odKKTSBJRHOeQfxyinGFInGTPprg = cmociXyTRzMHppBtpSEfqOAHFzwHA;
				cmociXyTRzMHppBtpSEfqOAHFzwHA = TnxdsVKEisoeFieODARWBxvsUTDP.mousePosition;
				GNTYosmSVIkmdrBvZjxjYYqDTTgg = currentUnityFrame;
			}
		}
	}
}
