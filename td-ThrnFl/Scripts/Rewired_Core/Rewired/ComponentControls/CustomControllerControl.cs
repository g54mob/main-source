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
		internal CustomController kehARxYYCBsbPQqXelIPlFVDezIE => BqDzxgPEIVLpZbYXMXRjqpdlsvAF() as CustomController;

		bool ComponentControl.OPBVHezjFVpJBDXXXJwLabYlHTYR => BqDzxgPEIVLpZbYXMXRjqpdlsvAF() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal virtual void cWTJDgsNiclLqNNsXcOxUkTHFEXA()
		{
			base.yMFFBQAzgLfmUacPqgBfPeOEneEtA();
			if (OPBVHezjFVpJBDXXXJwLabYlHTYR)
			{
				KGwGMnCEMITMZwqyMMLmHNafbmhAc();
				kehARxYYCBsbPQqXelIPlFVDezIE.InputSourceUpdateEvent += CmvTZyJLwllESslLVEstffYeIOtib;
			}
		}

		internal virtual void DUioYfVwaovScwgKjEAVfYGUBNCPA()
		{
			base.KGwGMnCEMITMZwqyMMLmHNafbmhAc();
			if (OPBVHezjFVpJBDXXXJwLabYlHTYR)
			{
				kehARxYYCBsbPQqXelIPlFVDezIE.InputSourceUpdateEvent -= CmvTZyJLwllESslLVEstffYeIOtib;
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

		internal void eRrfNGgQMniYEStsyLPyHwUxcEUZ(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!OPBVHezjFVpJBDXXXJwLabYlHTYR || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					vuFjwdIExkCBljHWCvLJfHVfcxJGb(customControllerElementTargetSetForFloat.target, P_1, P_2);
					return;
				}
				vuFjwdIExkCBljHWCvLJfHVfcxJGb(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
				vuFjwdIExkCBljHWCvLJfHVfcxJGb(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
			}
			else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				vuFjwdIExkCBljHWCvLJfHVfcxJGb(customControllerElementTargetSetForBoolean.target, P_1, P_2);
			}
		}

		internal void INHrWkOpdWMKfjbanmhDSaOYBMem(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!OPBVHezjFVpJBDXXXJwLabYlHTYR || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				hfZayYvuSnbWggNEbSeQJHXoIDMIb(customControllerElementTargetSetForBoolean.target, P_1);
			}
			else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					hfZayYvuSnbWggNEbSeQJHXoIDMIb(customControllerElementTargetSetForFloat.target, P_1);
					return;
				}
				hfZayYvuSnbWggNEbSeQJHXoIDMIb(customControllerElementTargetSetForFloat.positiveTarget, P_1);
				hfZayYvuSnbWggNEbSeQJHXoIDMIb(customControllerElementTargetSetForFloat.negativeTarget, P_1);
			}
		}

		internal abstract void tZgaXeGVTeudxrYwanWoqCGlBZYw();

		private void vuFjwdIExkCBljHWCvLJfHVfcxJGb(CustomControllerElementTarget P_0, float P_1, float P_2)
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
				kehARxYYCBsbPQqXelIPlFVDezIE.SetAxisValue(P_0.element, P_1);
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
				kehARxYYCBsbPQqXelIPlFVDezIE.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void hfZayYvuSnbWggNEbSeQJHXoIDMIb(CustomControllerElementTarget P_0, bool P_1)
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
				kehARxYYCBsbPQqXelIPlFVDezIE.SetAxisValue(P_0.element, num);
				break;
			}
			case CustomControllerElementSelector.ElementType.Button:
				kehARxYYCBsbPQqXelIPlFVDezIE.SetButtonValue(P_0.element, P_1);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void CmvTZyJLwllESslLVEstffYeIOtib()
		{
			if (!ZnXagxitKQCMwbkcjJHaQZKYHTZMb() && kxzKiGOSSGHSvNhOTCCxvpjgSZtV())
			{
				tZgaXeGVTeudxrYwanWoqCGlBZYw();
			}
		}
	}
}
