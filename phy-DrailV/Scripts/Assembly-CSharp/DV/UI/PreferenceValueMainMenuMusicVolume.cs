using UnityEngine;

namespace DV.UI
{
	public class PreferenceValueMainMenuMusicVolume : PrefDV<float>
	{
		private ASettingsProvider provider;

		public PreferenceValueMainMenuMusicVolume(ASettingsProvider provider, string name, float defaultValue, float initialValue)
			: base(name, defaultValue, initialValue)
		{
			this.provider = provider;
			UpdateVolume();
		}

		public override void Apply()
		{
			UpdateVolume();
			base.Apply();
		}

		public override void ImmediateEffectApply()
		{
			UpdateVolume();
			base.ImmediateEffectApply();
		}

		public override void RevertChange()
		{
			base.RevertChange();
			UpdateVolume();
		}

		private void UpdateVolume()
		{
			AudioSource mainMenuAudioSource = provider.GetMainMenuAudioSource();
			if ((bool)mainMenuAudioSource)
			{
				mainMenuAudioSource.volume = latestValue;
			}
		}
	}
}
