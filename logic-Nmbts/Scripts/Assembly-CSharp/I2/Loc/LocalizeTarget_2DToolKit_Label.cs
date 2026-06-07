using UnityEngine;

namespace I2.Loc
{
	public class LocalizeTarget_2DToolKit_Label : LocalizeTarget<tk2dTextMesh>
	{
		private TextAnchor mOriginalAlignment = TextAnchor.MiddleCenter;

		private bool mInitializeAlignment = true;

		static LocalizeTarget_2DToolKit_Label()
		{
			AutoRegister();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AutoRegister()
		{
			LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<tk2dTextMesh, LocalizeTarget_2DToolKit_Label>
			{
				Name = "2DToolKit Label",
				Priority = 100
			});
		}

		public override eTermType GetPrimaryTermType(Localize cmp)
		{
			return eTermType.Text;
		}

		public override eTermType GetSecondaryTermType(Localize cmp)
		{
			return eTermType.TK2dFont;
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
			secondaryTerm = ((mTarget.font != null) ? mTarget.font.name : string.Empty);
		}

		public override void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation)
		{
			tk2dFont secondaryTranslatedObj = cmp.GetSecondaryTranslatedObj<tk2dFont>(ref mainTranslation, ref secondaryTranslation);
			if (secondaryTranslatedObj != null && mTarget.font != secondaryTranslatedObj)
			{
				mTarget.font = secondaryTranslatedObj.data;
			}
			if (mInitializeAlignment)
			{
				mInitializeAlignment = false;
				mOriginalAlignment = mTarget.anchor;
			}
			if (mainTranslation == null || !(mTarget.text != mainTranslation))
			{
				return;
			}
			if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
			{
				int anchor = (int)mTarget.anchor;
				if (anchor % 3 == 0)
				{
					mTarget.anchor = (LocalizationManager.IsRight2Left ? (mTarget.anchor + 2) : mOriginalAlignment);
				}
				else if (anchor % 3 == 2)
				{
					mTarget.anchor = (LocalizationManager.IsRight2Left ? (mTarget.anchor - 2) : mOriginalAlignment);
				}
			}
			mTarget.text = mainTranslation;
		}
	}
}
