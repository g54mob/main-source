using UnityEngine;

namespace I2.Loc
{
	public class LocalizeTarget_NGUI_Label : LocalizeTarget<UILabel>
	{
		private NGUIText.Alignment mAlignment_RTL = NGUIText.Alignment.Right;

		private NGUIText.Alignment mAlignment_LTR = NGUIText.Alignment.Left;

		private bool mAlignmentWasRTL;

		private bool mInitializeAlignment = true;

		static LocalizeTarget_NGUI_Label()
		{
			AutoRegister();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AutoRegister()
		{
			LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<UILabel, LocalizeTarget_NGUI_Label>
			{
				Name = "NGUI Label",
				Priority = 100
			});
		}

		public override eTermType GetPrimaryTermType(Localize cmp)
		{
			return eTermType.Text;
		}

		public override eTermType GetSecondaryTermType(Localize cmp)
		{
			return eTermType.UIFont;
		}

		public override bool CanUseSecondaryTerm()
		{
			return true;
		}

		public override bool AllowMainTermToBeRTL()
		{
			return true;
		}

		public override bool AllowSecondTermToBeRTL()
		{
			return false;
		}

		public override void GetFinalTerms(Localize cmp, string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			primaryTerm = (mTarget ? mTarget.text : null);
			secondaryTerm = ((mTarget.ambigiousFont != null) ? mTarget.ambigiousFont.name : string.Empty);
		}

		public override void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation)
		{
			Font secondaryTranslatedObj = cmp.GetSecondaryTranslatedObj<Font>(ref mainTranslation, ref secondaryTranslation);
			if (secondaryTranslatedObj != null)
			{
				if (secondaryTranslatedObj != mTarget.ambigiousFont)
				{
					mTarget.ambigiousFont = secondaryTranslatedObj;
				}
			}
			else
			{
				UIFont secondaryTranslatedObj2 = cmp.GetSecondaryTranslatedObj<UIFont>(ref mainTranslation, ref secondaryTranslation);
				if (secondaryTranslatedObj2 != null && mTarget.ambigiousFont != secondaryTranslatedObj2)
				{
					mTarget.ambigiousFont = secondaryTranslatedObj2;
				}
			}
			if (mInitializeAlignment)
			{
				mInitializeAlignment = false;
				mAlignment_LTR = (mAlignment_RTL = mTarget.alignment);
				if (LocalizationManager.IsRight2Left && mAlignment_RTL == NGUIText.Alignment.Right)
				{
					mAlignment_LTR = NGUIText.Alignment.Left;
				}
				if (!LocalizationManager.IsRight2Left && mAlignment_LTR == NGUIText.Alignment.Left)
				{
					mAlignment_RTL = NGUIText.Alignment.Right;
				}
			}
			UIInput uIInput = NGUITools.FindInParents<UIInput>(mTarget.gameObject);
			if (uIInput != null && uIInput.label == mTarget)
			{
				if (mainTranslation != null && uIInput.defaultText != mainTranslation)
				{
					if (cmp.CorrectAlignmentForRTL && (uIInput.label.alignment == NGUIText.Alignment.Left || uIInput.label.alignment == NGUIText.Alignment.Right))
					{
						uIInput.label.alignment = (LocalizationManager.IsRight2Left ? mAlignment_RTL : mAlignment_LTR);
					}
					uIInput.defaultText = mainTranslation;
				}
			}
			else if (mainTranslation != null && mTarget.text != mainTranslation)
			{
				if (cmp.CorrectAlignmentForRTL && (mTarget.alignment == NGUIText.Alignment.Left || mTarget.alignment == NGUIText.Alignment.Right))
				{
					mTarget.alignment = (LocalizationManager.IsRight2Left ? mAlignment_RTL : mAlignment_LTR);
				}
				mTarget.text = mainTranslation;
			}
		}
	}
}
