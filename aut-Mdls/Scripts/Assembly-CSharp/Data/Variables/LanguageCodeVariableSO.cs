using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/LanguageCodeVariable", fileName = "LanguageCodeVariable", order = 0)]
	public class LanguageCodeVariableSO : VariableSO<LanguageCode>
	{
		public override void SetValue(LanguageCode value)
		{
			if (Application.isPlaying && value != LocalizationUtility.CurrentLanguage)
			{
				if (value == LanguageCode.N)
				{
					LocalizationUtility.SetLanguageFromSystem(LanguageCode.EN);
					base.SetValue(LocalizationUtility.CurrentLanguage);
				}
				else
				{
					LocalizationUtility.SetLanguage(value);
					base.SetValue(value);
				}
			}
		}

		protected override void OnEnable()
		{
			SetValue(Value);
		}

		protected override void OnDisable()
		{
		}
	}
}
