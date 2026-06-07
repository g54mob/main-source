using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Settings
{
	[CreateAssetMenu(fileName = "Scriptable Game Settings", menuName = "Scriptable Game Settings/New Game Settings")]
	public class GameSettings : ScriptableObject
	{
		[Header("Post Processing Settings")]
		public bool IsPostProcessingEnabled = true;

		[Header("Audio")]
		[Range(0f, 1f)]
		public float MasterVolumeRate = 0.66f;

		[Header("SFX Settings")]
		public bool IsSFXEnabled = true;

		[Range(0f, 1f)]
		public float SFXVolumeRate = 0.66f;

		[Range(0f, 1f)]
		public float AmbienceVolume = 0.66f;

		[Header("Music Settings")]
		public bool IsMusicEnabled = true;

		[Range(0f, 1f)]
		public float MusicVolumeRate = 0.66f;

		[Header("Input")]
		[Range(0.1f, 2f)]
		public float InputSensitivity = 0.66f;

		public void TogglePostProcessing()
		{
			IsPostProcessingEnabled = !IsPostProcessingEnabled;
		}

		public void ToggleSFX()
		{
			IsSFXEnabled = !IsSFXEnabled;
		}

		public void ToggleMusic()
		{
			IsMusicEnabled = !IsMusicEnabled;
		}

		public void SetMusicStatus(bool status)
		{
			IsMusicEnabled = status;
		}

		public void SetSFXStatus(bool status)
		{
			IsSFXEnabled = status;
		}

		public void SetMasterVolume(float modificationValue)
		{
			MasterVolumeRate = Mathf.Clamp(modificationValue, 0f, 1f);
		}

		public void SetSFXVolume(float modificationValue)
		{
			SFXVolumeRate = Mathf.Clamp(modificationValue, 0f, 1f);
		}

		public void SetMusicVolume(float modificationValue)
		{
			MusicVolumeRate = Mathf.Clamp(modificationValue, 0f, 1f);
		}

		public float GetMusicVolume()
		{
			return MusicVolumeRate * MasterVolumeRate;
		}

		public void SetInputSensitivity(float modificationValue)
		{
			InputSensitivity = Mathf.Clamp(modificationValue, 0.1f, 2f);
		}

		public void InitSaveSystem()
		{
			SaveSystem.Init();
		}

		public void SaveGameSettings()
		{
			SaveSystem.SaveJsonFile(SaveSystem.SAVE_FOLDER, "GameSettings", JsonUtility.ToJson(this));
		}

		public void LoadGameSettings()
		{
			JsonUtility.FromJsonOverwrite(SaveSystem.LoadJsonFile(SaveSystem.SAVE_FOLDER, "GameSettings"), this);
		}

		public void ResetGameSettings()
		{
			IsPostProcessingEnabled = true;
			MasterVolumeRate = 0.66f;
			IsSFXEnabled = true;
			SFXVolumeRate = 0.66f;
			AmbienceVolume = 0.66f;
			IsMusicEnabled = true;
			MusicVolumeRate = 0.66f;
			InputSensitivity = 0.66f;
		}
	}
}
