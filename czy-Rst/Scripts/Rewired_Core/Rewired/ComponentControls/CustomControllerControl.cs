using System;
using Rewired.ComponentControls.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class CustomControllerControl : ComponentControl
	{
		internal CustomController GsoZbMPaQLTBrRsfvicmEcjMgUcgA => jhYECROEMZNsxuaWZgOAkBVcaKmGb() as CustomController;

		bool ComponentControl.sBSyLdyBEZqxqMQAUOeeTuCypwge => jhYECROEMZNsxuaWZgOAkBVcaKmGb() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal virtual void CoPWsupLNkdAvQXWpAljrUIAFjko()
		{
			base.USEuUjubaDLUifCGdCzGVsQJWggG();
			if (sBSyLdyBEZqxqMQAUOeeTuCypwge)
			{
				oSbbeYZAlAddfrbvTGLFoGMuOsPK();
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.InputSourceUpdateEvent += yeIyTIKclCbirxCEOvOeKytBiDib;
			}
		}

		internal virtual void jcjdhAAdqcPbMjgHcqJkjiuTMpoO()
		{
			base.oSbbeYZAlAddfrbvTGLFoGMuOsPK();
			if (sBSyLdyBEZqxqMQAUOeeTuCypwge)
			{
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.InputSourceUpdateEvent -= yeIyTIKclCbirxCEOvOeKytBiDib;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(CustomController);
		}

		internal void AXiqrbJHOthQgiWhbUsFiQksmOuF(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!sBSyLdyBEZqxqMQAUOeeTuCypwge || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					DJGLCMNZleyuLGHNFCEmoptsRCvH(customControllerElementTargetSetForFloat.target, P_1, P_2);
					return;
				}
				DJGLCMNZleyuLGHNFCEmoptsRCvH(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
				DJGLCMNZleyuLGHNFCEmoptsRCvH(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
			}
			else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				DJGLCMNZleyuLGHNFCEmoptsRCvH(customControllerElementTargetSetForBoolean.target, P_1, P_2);
			}
		}

		internal void yIGACPdPxKNbFAccDkxmGzqfXbQjc(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!sBSyLdyBEZqxqMQAUOeeTuCypwge || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				HqAHkpoMNztAQOKTuzNdydjbJluW(customControllerElementTargetSetForBoolean.target, P_1);
			}
			else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					HqAHkpoMNztAQOKTuzNdydjbJluW(customControllerElementTargetSetForFloat.target, P_1);
					return;
				}
				HqAHkpoMNztAQOKTuzNdydjbJluW(customControllerElementTargetSetForFloat.positiveTarget, P_1);
				HqAHkpoMNztAQOKTuzNdydjbJluW(customControllerElementTargetSetForFloat.negativeTarget, P_1);
			}
		}

		internal abstract void NsfNqBHBZwoEXumfzfRFFUgqVdio();

		private void DJGLCMNZleyuLGHNFCEmoptsRCvH(CustomControllerElementTarget P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			switch (P_0.element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Axis:
				switch (P_0.valueRange)
				{
				case CustomControllerElementTarget.ValueRange.Full:
					if (P_0.invert)
					{
						P_1 *= -1f;
					}
					break;
				case CustomControllerElementTarget.ValueRange.Positive:
					if (P_1 < 0f)
					{
						P_1 = 0f;
					}
					if (P_0.valueContribution == Pole.Negative)
					{
						P_1 *= -1f;
					}
					break;
				case CustomControllerElementTarget.ValueRange.Negative:
					if (P_1 > 0f)
					{
						P_1 = 0f;
					}
					if (P_0.valueContribution == Pole.Positive)
					{
						P_1 *= -1f;
					}
					break;
				}
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.SetAxisValue(P_0.element, P_1);
				break;
			case CustomControllerElementSelector.ElementType.Button:
				switch (P_0.valueRange)
				{
				case CustomControllerElementTarget.ValueRange.Positive:
					if (P_1 < 0f)
					{
						P_1 = 0f;
					}
					break;
				case CustomControllerElementTarget.ValueRange.Negative:
					if (P_1 > 0f)
					{
						P_1 = 0f;
					}
					break;
				}
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void HqAHkpoMNztAQOKTuzNdydjbJluW(CustomControllerElementTarget P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			switch (P_0.element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Axis:
			{
				float num = (P_1 ? 1f : 0f);
				if (P_0.valueRange == CustomControllerElementTarget.ValueRange.Full)
				{
					if (P_0.invert)
					{
						num *= -1f;
					}
				}
				else if (P_0.valueContribution == Pole.Negative)
				{
					num *= -1f;
				}
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.SetAxisValue(P_0.element, num);
				break;
			}
			case CustomControllerElementSelector.ElementType.Button:
				GsoZbMPaQLTBrRsfvicmEcjMgUcgA.SetButtonValue(P_0.element, P_1);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void yeIyTIKclCbirxCEOvOeKytBiDib()
		{
			if (!bsOJSOyOeEjUEpfUOQkBksJExGnD() && GlaXMdVzEWtLRKxLWJPCCCZtpeXE())
			{
				NsfNqBHBZwoEXumfzfRFFUgqVdio();
			}
		}
	}
}
