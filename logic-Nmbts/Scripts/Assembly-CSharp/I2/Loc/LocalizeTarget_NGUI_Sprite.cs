using UnityEngine;

namespace I2.Loc
{
	public class LocalizeTarget_NGUI_Sprite : LocalizeTarget<UISprite>
	{
		static LocalizeTarget_NGUI_Sprite()
		{
			AutoRegister();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AutoRegister()
		{
			LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<UISprite, LocalizeTarget_NGUI_Sprite>
			{
				Name = "NGUI UISprite",
				Priority = 100
			});
		}

		public override eTermType GetPrimaryTermType(Localize cmp)
		{
			return eTermType.Sprite;
		}

		public override eTermType GetSecondaryTermType(Localize cmp)
		{
			return eTermType.UIAtlas;
		}

		public override bool CanUseSecondaryTerm()
		{
			return true;
		}

		public override bool AllowMainTermToBeRTL()
		{
			return false;
		}

		public override bool AllowSecondTermToBeRTL()
		{
			return false;
		}

		public override void GetFinalTerms(Localize cmp, string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			primaryTerm = (mTarget ? mTarget.spriteName : null);
			secondaryTerm = ((mTarget.atlas is NGUIAtlas) ? ((NGUIAtlas)mTarget.atlas).name : string.Empty);
		}

		public override void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation)
		{
			if (!(mTarget.spriteName == mainTranslation))
			{
				UIAtlas secondaryTranslatedObj = cmp.GetSecondaryTranslatedObj<UIAtlas>(ref mainTranslation, ref secondaryTranslation);
				bool flag = false;
				if (secondaryTranslatedObj != null && mTarget.atlas != secondaryTranslatedObj)
				{
					mTarget.atlas = secondaryTranslatedObj;
					flag = true;
				}
				if (mTarget.spriteName != mainTranslation && mTarget.atlas.GetSprite(mainTranslation) != null)
				{
					mTarget.spriteName = mainTranslation;
					flag = true;
				}
				if (flag)
				{
					mTarget.MakePixelPerfect();
				}
			}
		}
	}
}
