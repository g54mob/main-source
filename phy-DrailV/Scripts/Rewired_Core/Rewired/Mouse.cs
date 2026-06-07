using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs NQnfjgRuFrgOQpIiuJBsPFKhnQjW;

		private float[] nnYqsyMGvKVlUJnBGjUjlavrNCuU;

		private Vector2 bSSATaJnwShFMgcULfMbPBkJqZJhA;

		private Vector2 zVLTYmtZDKRTtSPJgjeAnFSjIEko;

		private int PDqjYXWexCmphigzGgSFjBGbpLuSA;

		private readonly IUnifiedMouseSource CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		private static Guid TlqexZaxrTHNzaLvGPdgSakcLMHEb;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				return bSSATaJnwShFMgcULfMbPBkJqZJhA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				return zVLTYmtZDKRTtSPJgjeAnFSjIEko;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				return bSSATaJnwShFMgcULfMbPBkJqZJhA - zVLTYmtZDKRTtSPJgjeAnFSjIEko;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return TlqexZaxrTHNzaLvGPdgSakcLMHEb;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = P_1;
			TlqexZaxrTHNzaLvGPdgSakcLMHEb = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			pggOEkcvhxxBuBDIbrJuSafugeIK();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal override void tglbagDKhFNyJrooYNWfohsJFQmi(UpdateLoopType P_0)
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk.UpdateInputData(fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			base.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			IRcefrIWkFaLqhridkUHdgITyRpN();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (nnYqsyMGvKVlUJnBGjUjlavrNCuU == null)
			{
				nnYqsyMGvKVlUJnBGjUjlavrNCuU = new float[_axisCount];
			}
			if (NQnfjgRuFrgOQpIiuJBsPFKhnQjW == null)
			{
				NQnfjgRuFrgOQpIiuJBsPFKhnQjW = new TimerAbs(1.0);
			}
			if (NQnfjgRuFrgOQpIiuJBsPFKhnQjW.Update() || !NQnfjgRuFrgOQpIiuJBsPFKhnQjW.running)
			{
				NQnfjgRuFrgOQpIiuJBsPFKhnQjW.Start();
				Array.Clear(nnYqsyMGvKVlUJnBGjUjlavrNCuU, 0, nnYqsyMGvKVlUJnBGjUjlavrNCuU.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				nnYqsyMGvKVlUJnBGjUjlavrNCuU[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				nnYqsyMGvKVlUJnBGjUjlavrNCuU[index] += axes[index].valueRaw;
			}
			float num = nnYqsyMGvKVlUJnBGjUjlavrNCuU[index];
			if (MathTools.Abs(num) <= axes[index].ZgDzvulGLNTUslBWphultbDIfPTbA)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = AWCbIECppuLDtCThiwONsElGeIEub.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			NQnfjgRuFrgOQpIiuJBsPFKhnQjW.running = false;
			return true;
		}

		internal override void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			base.wJjPIIRJfHhEbGedUconecGfiwzgB();
			if (NQnfjgRuFrgOQpIiuJBsPFKhnQjW != null)
			{
				NQnfjgRuFrgOQpIiuJBsPFKhnQjW.Clear();
			}
			bSSATaJnwShFMgcULfMbPBkJqZJhA = Vector2.zero;
			zVLTYmtZDKRTtSPJgjeAnFSjIEko = Vector2.zero;
		}

		internal override bool vSypfONnKVpDpZlTyTmFsHtqFCqP(bool P_0)
		{
			if (!base.vSypfONnKVpDpZlTyTmFsHtqFCqP(P_0))
			{
				return false;
			}
			if (CLFHWOuPSRLahPSSrSHZoiqMbYrk is IGetSetEnabled)
			{
				(CLFHWOuPSRLahPSSrSHZoiqMbYrk as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				IRcefrIWkFaLqhridkUHdgITyRpN();
				zVLTYmtZDKRTtSPJgjeAnFSjIEko = screenPosition;
			}
			return true;
		}

		private void IRcefrIWkFaLqhridkUHdgITyRpN()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != PDqjYXWexCmphigzGgSFjBGbpLuSA)
			{
				zVLTYmtZDKRTtSPJgjeAnFSjIEko = bSSATaJnwShFMgcULfMbPBkJqZJhA;
				bSSATaJnwShFMgcULfMbPBkJqZJhA = CLFHWOuPSRLahPSSrSHZoiqMbYrk.mousePosition;
				PDqjYXWexCmphigzGgSFjBGbpLuSA = currentUnityFrame;
			}
		}
	}
}
