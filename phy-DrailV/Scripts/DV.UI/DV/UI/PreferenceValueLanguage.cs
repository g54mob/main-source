using UnityEngine;

namespace DV.UI
{
	public class PreferenceValueLanguage : PreferenceValues<string>
	{
		public const string DUMMY_NAME = "Language";

		private ASettingsProvider provider;

		public PreferenceValueLanguage(ASettingsProvider provider)
			: base("Language", "English", provider.GetCurrentLanguage())
		{
			this.provider = provider;
		}

		public override void Apply()
		{
			Debug.Log($"Applying language '{(object)latestValue}' and restarting the scene");
			provider.ApplyLanguageAndRestart(latestValue);
			base.Apply();
		}

		public override void ImmediateEffectApply()
		{
			if (provider.GetCurrentLanguage() != latestValue)
			{
				Debug.Log($"Applying language '{(object)latestValue}'");
				provider.ApplyLanguage(latestValue);
				base.ImmediateEffectApply();
			}
		}

		public override void RevertChange()
		{
			Debug.Log($"Reverting language from '{(object)latestValue}' to '{(object)originalValue}'");
			base.RevertChange();
			provider.ApplyLanguage(latestValue);
		}
	}
}
