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
		internal CustomController yBVYaZymnHfILCjQopwadWNgxbeH => EeYfqFPkRpVrFkmpuxsjzylIxkOL() as CustomController;

		bool ComponentControl.UTvbNmLtOtvCXnKmzpVoOCmLyTeb => EeYfqFPkRpVrFkmpuxsjzylIxkOL() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal override void OCbTyrEcaxLtyGXBEYyEklZHhUaE()
		{
			base.OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
			{
				tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
				yBVYaZymnHfILCjQopwadWNgxbeH.InputSourceUpdateEvent += WcLroPMwdeKLAKDtUTPbgUAjHaqt;
			}
		}

		internal override void tDIDrACtxdHSRUhHLVoEeNTZdDjmA()
		{
			base.tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
			{
				yBVYaZymnHfILCjQopwadWNgxbeH.InputSourceUpdateEvent -= WcLroPMwdeKLAKDtUTPbgUAjHaqt;
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

		internal void wJuChGHELKYHUkqGfCzcAspJNjWPB(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!UTvbNmLtOtvCXnKmzpVoOCmLyTeb || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.target, P_1, P_2);
					return;
				}
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
			}
			else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForBoolean.target, P_1, P_2);
			}
		}

		internal void wJuChGHELKYHUkqGfCzcAspJNjWPB(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!UTvbNmLtOtvCXnKmzpVoOCmLyTeb || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForBoolean.target, P_1);
			}
			else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.target, P_1);
					return;
				}
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.positiveTarget, P_1);
				wJuChGHELKYHUkqGfCzcAspJNjWPB(customControllerElementTargetSetForFloat.negativeTarget, P_1);
			}
		}

		internal abstract void NSaIxTLXSfKHgYqfDPqUzdSfjLOK();

		private void wJuChGHELKYHUkqGfCzcAspJNjWPB(CustomControllerElementTarget P_0, float P_1, float P_2)
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
				yBVYaZymnHfILCjQopwadWNgxbeH.SetAxisValue(P_0.element, P_1);
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
				yBVYaZymnHfILCjQopwadWNgxbeH.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void wJuChGHELKYHUkqGfCzcAspJNjWPB(CustomControllerElementTarget P_0, bool P_1)
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
				yBVYaZymnHfILCjQopwadWNgxbeH.SetAxisValue(P_0.element, num);
				break;
			}
			case CustomControllerElementSelector.ElementType.Button:
				yBVYaZymnHfILCjQopwadWNgxbeH.SetButtonValue(P_0.element, P_1);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void WcLroPMwdeKLAKDtUTPbgUAjHaqt()
		{
			if (!foxxfopNBfWqtdkSbRJWMrXhhLjd() && uITeqmergHcifeDewaJvLHRSazjqA())
			{
				NSaIxTLXSfKHgYqfDPqUzdSfjLOK();
			}
		}
	}
}
