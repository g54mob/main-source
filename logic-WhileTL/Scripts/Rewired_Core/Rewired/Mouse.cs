using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs mhdubwpxbldeFMGFZfiEIxAcOtfC;

		private float[] EQQpgpuHREYTmuUrrwvFaUwqKaeF;

		private Vector2 IjYAEdNZIIrgmPNomOmDKnVCEFLBA;

		private Vector2 YmBZIlLSvMypLnbwJRCemKxeWyqJ;

		private int suyFGYaVbEYjHZZNbyvfIxUiZDaC;

		private readonly IUnifiedMouseSource vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		private static Guid yokikIRxPHuRDmPVzFwYrBTdCeXH;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				return IjYAEdNZIIrgmPNomOmDKnVCEFLBA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				return YmBZIlLSvMypLnbwJRCemKxeWyqJ;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				return IjYAEdNZIIrgmPNomOmDKnVCEFLBA - YmBZIlLSvMypLnbwJRCemKxeWyqJ;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return yokikIRxPHuRDmPVzFwYrBTdCeXH;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			vPTVBGMeTSLLhqcGnbvGjLFkMncb = P_1;
			yokikIRxPHuRDmPVzFwYrBTdCeXH = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			WCmnBnYePrGAMdoiUNBATVOhqgEEA();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			vPTVBGMeTSLLhqcGnbvGjLFkMncb.UpdateInputData(WlduKdCdymfJzhLxPcswpRugJOzgb);
			base.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			jimueuwQOFoMRSEcIsxKovxCBpEB();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (EQQpgpuHREYTmuUrrwvFaUwqKaeF == null)
			{
				EQQpgpuHREYTmuUrrwvFaUwqKaeF = new float[_axisCount];
			}
			if (mhdubwpxbldeFMGFZfiEIxAcOtfC == null)
			{
				mhdubwpxbldeFMGFZfiEIxAcOtfC = new TimerAbs(1.0);
			}
			if (mhdubwpxbldeFMGFZfiEIxAcOtfC.Update() || !mhdubwpxbldeFMGFZfiEIxAcOtfC.running)
			{
				mhdubwpxbldeFMGFZfiEIxAcOtfC.Start();
				Array.Clear(EQQpgpuHREYTmuUrrwvFaUwqKaeF, 0, EQQpgpuHREYTmuUrrwvFaUwqKaeF.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				EQQpgpuHREYTmuUrrwvFaUwqKaeF[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				EQQpgpuHREYTmuUrrwvFaUwqKaeF[index] += axes[index].valueRaw;
			}
			float num = EQQpgpuHREYTmuUrrwvFaUwqKaeF[index];
			if (MathTools.Abs(num) <= axes[index].yPNbebGHfNNuYBAoGSUXYkgODJVPB)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = jnGTQDFeNsixRwgRJcghDqCbQWSP.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			mhdubwpxbldeFMGFZfiEIxAcOtfC.running = false;
			return true;
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			base.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			if (mhdubwpxbldeFMGFZfiEIxAcOtfC != null)
			{
				mhdubwpxbldeFMGFZfiEIxAcOtfC.Clear();
			}
			IjYAEdNZIIrgmPNomOmDKnVCEFLBA = Vector2.zero;
			YmBZIlLSvMypLnbwJRCemKxeWyqJ = Vector2.zero;
		}

		internal override bool CPoVkJzroBtMRwmbFEndkvOzAAwfb(bool P_0)
		{
			if (!base.CPoVkJzroBtMRwmbFEndkvOzAAwfb(P_0))
			{
				return false;
			}
			if (vPTVBGMeTSLLhqcGnbvGjLFkMncb is IGetSetEnabled)
			{
				(vPTVBGMeTSLLhqcGnbvGjLFkMncb as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				jimueuwQOFoMRSEcIsxKovxCBpEB();
				YmBZIlLSvMypLnbwJRCemKxeWyqJ = screenPosition;
			}
			return true;
		}

		private void jimueuwQOFoMRSEcIsxKovxCBpEB()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != suyFGYaVbEYjHZZNbyvfIxUiZDaC)
			{
				YmBZIlLSvMypLnbwJRCemKxeWyqJ = IjYAEdNZIIrgmPNomOmDKnVCEFLBA;
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA = vPTVBGMeTSLLhqcGnbvGjLFkMncb.mousePosition;
				suyFGYaVbEYjHZZNbyvfIxUiZDaC = currentUnityFrame;
			}
		}
	}
}
