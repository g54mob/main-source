using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public struct AudioSettingsSaveData
	{
		public float _masterVolume;

		public float _musicVolume;

		public float _sfxVolume;

		public AudioSettingsSaveData(float masterVolume, float musicVolume, float sfxVolume)
		{
			_masterVolume = masterVolume;
			_musicVolume = musicVolume;
			_sfxVolume = sfxVolume;
		}
	}
}
