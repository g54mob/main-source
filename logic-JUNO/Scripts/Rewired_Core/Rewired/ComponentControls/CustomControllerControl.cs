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
		internal CustomController HAJXbtYsLsLeqHUzHNVDqcdyIGMdA => aIdRCmPaDeGXwbkKhErvDnPFSYEkb() as CustomController;

		bool ComponentControl.fWzcsqpjMiHugIFEsnxLnuyMnmGF => aIdRCmPaDeGXwbkKhErvDnPFSYEkb() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal virtual void VoyGgLGiGTrtcFKALFAAsPOudnYcb()
		{
			base.HAvmCSbdxkijLlEaJbzuvcLzMOvB();
			if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				zCjnzoEBxLKqWxdjJrurUSAyOlmA();
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.InputSourceUpdateEvent += pSXiwsZrBWAnlbQRkQKroaCXaOlD;
			}
		}

		internal virtual void mKKrHnZUpVCHPdRTGsFNRlarfpEJ()
		{
			base.zCjnzoEBxLKqWxdjJrurUSAyOlmA();
			if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.InputSourceUpdateEvent -= pSXiwsZrBWAnlbQRkQKroaCXaOlD;
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

		internal void BBGcGGKBcUWfsejCFzcKGieWiGAc(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!fWzcsqpjMiHugIFEsnxLnuyMnmGF || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					MMvARfSWkDvFCIhLddhLjMlMgHLBb(customControllerElementTargetSetForFloat.target, P_1, P_2);
					return;
				}
				MMvARfSWkDvFCIhLddhLjMlMgHLBb(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
				MMvARfSWkDvFCIhLddhLjMlMgHLBb(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
			}
			else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				MMvARfSWkDvFCIhLddhLjMlMgHLBb(customControllerElementTargetSetForBoolean.target, P_1, P_2);
			}
		}

		internal void rlvXCcQLgbaIWkqoMoWXBPgIbtqRB(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!fWzcsqpjMiHugIFEsnxLnuyMnmGF || P_0 == null)
			{
				return;
			}
			if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
			{
				OGpFHKteDCQCVYoRGMnWGCjLdtAj(customControllerElementTargetSetForBoolean.target, P_1);
			}
			else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					OGpFHKteDCQCVYoRGMnWGCjLdtAj(customControllerElementTargetSetForFloat.target, P_1);
					return;
				}
				OGpFHKteDCQCVYoRGMnWGCjLdtAj(customControllerElementTargetSetForFloat.positiveTarget, P_1);
				OGpFHKteDCQCVYoRGMnWGCjLdtAj(customControllerElementTargetSetForFloat.negativeTarget, P_1);
			}
		}

		internal abstract void MTAeqcUFQJDzMFepPZcuSraWQpUDA();

		private void MMvARfSWkDvFCIhLddhLjMlMgHLBb(CustomControllerElementTarget P_0, float P_1, float P_2)
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
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.SetAxisValue(P_0.element, P_1);
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
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void OGpFHKteDCQCVYoRGMnWGCjLdtAj(CustomControllerElementTarget P_0, bool P_1)
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
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.SetAxisValue(P_0.element, num);
				break;
			}
			case CustomControllerElementSelector.ElementType.Button:
				HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.SetButtonValue(P_0.element, P_1);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void pSXiwsZrBWAnlbQRkQKroaCXaOlD()
		{
			if (!aRhZbmfBYfGRahvrizgOWqeldBib() && PBRHZQINZfANWEOTugUlepRFdGfJ())
			{
				MTAeqcUFQJDzMFepPZcuSraWQpUDA();
			}
		}
	}
}
