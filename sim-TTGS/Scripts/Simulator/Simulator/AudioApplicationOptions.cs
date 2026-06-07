using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("Application Settings/Audio", Scope.Project)]
	public class AudioApplicationOptions : CustomApplicationOptions<AudioApplicationOptions>
	{
		[SerializeField]
		private VolumeOption m_volumeOption;

		[SerializeField]
		private PlayerPrefBool m_soundInBackground;

		public static VolumeOption VolumeOption => CustomSettings<AudioApplicationOptions>.I.m_volumeOption;

		public static PlayerPrefBool SoundInBackground => CustomSettings<AudioApplicationOptions>.I.m_soundInBackground;

		public void Update()
		{
			Application.runInBackground = m_soundInBackground;
		}

		public override void Load()
		{
			m_volumeOption.Load();
			m_soundInBackground.Load();
			Update();
		}

		public override void ResetSettings()
		{
			m_volumeOption.Reset();
			m_soundInBackground.Reset();
			Update();
		}
	}
}
