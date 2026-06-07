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
		internal CustomController BrLhsTCJDDhEOtjjAgHezhkdDyDBA => wabUkEZZZJIoUMDQmjwMkPKXcLHJ() as CustomController;

		bool ComponentControl.lgrxeUlsSPQSCicUhAbuoUnLaBDCA => wabUkEZZZJIoUMDQmjwMkPKXcLHJ() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal virtual void LPmsfNmGBmyCteMSKKhmQLHrVBoc()
		{
			base.DMbaaaKznZLdNtHCSKxCxkjgxkVZ();
			if (lgrxeUlsSPQSCicUhAbuoUnLaBDCA)
			{
				xrUDlDfYTKrFCEXzaElDtJTTsamLA();
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.InputSourceUpdateEvent += nqVzkYFdhxwNTBBSlsEUvNzIfKsBA;
			}
		}

		internal virtual void kgENzFDyfeJptTDUHgHsOGbgNVXf()
		{
			base.xrUDlDfYTKrFCEXzaElDtJTTsamLA();
			if (lgrxeUlsSPQSCicUhAbuoUnLaBDCA)
			{
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.InputSourceUpdateEvent -= nqVzkYFdhxwNTBBSlsEUvNzIfKsBA;
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

		internal void RhRZaqQiFdWPJAfrENbBHnpVmOZu(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!lgrxeUlsSPQSCicUhAbuoUnLaBDCA || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					KufDNLKScsEOkqCFcoxmRAuLbdCDA(customControllerElementTargetSetForFloat.target, P_1, P_2);
					return;
				}
				KufDNLKScsEOkqCFcoxmRAuLbdCDA(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
				KufDNLKScsEOkqCFcoxmRAuLbdCDA(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
			}
			else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				KufDNLKScsEOkqCFcoxmRAuLbdCDA(customControllerElementTargetSetForBoolean.target, P_1, P_2);
			}
		}

		internal void nbxQAEEQaUHMwOZkZWHyAtMuHZdd(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!lgrxeUlsSPQSCicUhAbuoUnLaBDCA || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				YrbSLixjHpERhdqVPqAfTDmYODTAb(customControllerElementTargetSetForBoolean.target, P_1);
			}
			else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					YrbSLixjHpERhdqVPqAfTDmYODTAb(customControllerElementTargetSetForFloat.target, P_1);
					return;
				}
				YrbSLixjHpERhdqVPqAfTDmYODTAb(customControllerElementTargetSetForFloat.positiveTarget, P_1);
				YrbSLixjHpERhdqVPqAfTDmYODTAb(customControllerElementTargetSetForFloat.negativeTarget, P_1);
			}
		}

		internal abstract void KnKAmCMLKkarkAAtCBmNwqzHtFDw();

		private void KufDNLKScsEOkqCFcoxmRAuLbdCDA(CustomControllerElementTarget P_0, float P_1, float P_2)
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
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.SetAxisValue(P_0.element, P_1);
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
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void YrbSLixjHpERhdqVPqAfTDmYODTAb(CustomControllerElementTarget P_0, bool P_1)
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
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.SetAxisValue(P_0.element, num);
				break;
			}
			case CustomControllerElementSelector.ElementType.Button:
				BrLhsTCJDDhEOtjjAgHezhkdDyDBA.SetButtonValue(P_0.element, P_1);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void nqVzkYFdhxwNTBBSlsEUvNzIfKsBA()
		{
			if (!sqlETDdrPWvXdhJlnKjPsHvhhNAuA() && NxZqTcOaFYxDkedTdVaCjfSAMJmR())
			{
				KnKAmCMLKkarkAAtCBmNwqzHtFDw();
			}
		}
	}
}
