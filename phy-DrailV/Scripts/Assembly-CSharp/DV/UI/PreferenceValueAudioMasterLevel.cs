using UnityEngine;

namespace DV.UI
{
	public class PreferenceValueAudioMasterLevel : PrefDV<float>
	{
		public PreferenceValueAudioMasterLevel(string name, float defaultValue, float initialValue)
			: base(name, defaultValue, initialValue)
		{
			UpdateMasterVolume();
		}

		public override void ImmediateEffectApply()
		{
			UpdateMasterVolume();
			base.ImmediateEffectApply();
		}

		public override void RevertChange()
		{
			base.RevertChange();
			UpdateMasterVolume();
		}

		private void UpdateMasterVolume()
		{
			AudioListener.volume = latestValue;
		}
	}
}
