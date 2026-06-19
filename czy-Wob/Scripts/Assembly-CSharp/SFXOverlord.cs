using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public static class SFXOverlord
{
	private static List<LockReason> sfxLocks = new List<LockReason>();

	private static float categoryFadeOutTime = 1f;

	private static float categoryFadeInTime = 1f;

	private static float sfxVolume = 1f;

	private static float musicVolume = 1f;

	private static bool volumesStored = false;

	private static bool volumeOverride = false;

	private static float musicVolumeOverride = -1f;

	private static Dictionary<string, float> categoryVolumes = new Dictionary<string, float>();

	public static void LockInWorldSFX(LockReason reason)
	{
		if (!sfxLocks.Contains(reason))
		{
			if (sfxLocks.Count == 0)
			{
				_LockInWorldSFX();
			}
			sfxLocks.Add(reason);
		}
	}

	public static void UnlockInWorldSFX(LockReason reason)
	{
		if (!(SingletonMonoBehaviour<AudioController>.Instance == null) && sfxLocks.Contains(reason))
		{
			sfxLocks.Remove(reason);
			if (sfxLocks.Count == 0)
			{
				_UnlockInWorldSFX();
			}
		}
	}

	public static void RemoveAllSFXLocks()
	{
		sfxLocks.Clear();
		_UnlockInWorldSFX();
	}

	public static float GetSFXVolume()
	{
		return sfxVolume;
	}

	public static float GetMusicVolume()
	{
		return musicVolume;
	}

	public static void SetSFXVolume(float volume)
	{
		if (!volumesStored)
		{
			StoreVolumes();
		}
		sfxVolume = Mathf.Clamp(volume, 0f, 1f);
		AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
		for (int i = 0; i < component.AudioCategories.Length; i++)
		{
			string name = component.AudioCategories[i].Name;
			if (!IsCategoryMusic(name))
			{
				AudioController.SetCategoryVolume(name, categoryVolumes[name] * sfxVolume);
			}
		}
	}

	public static void SetMusicVolumeOverride(bool enabled, float overrideValue)
	{
		if (volumeOverride != enabled || musicVolumeOverride != overrideValue)
		{
			volumeOverride = enabled;
			musicVolumeOverride = overrideValue;
			SetMusicVolume(musicVolume);
		}
	}

	public static void SetMusicVolume(float volume)
	{
		if (!volumesStored)
		{
			StoreVolumes();
		}
		float num = volume;
		if (volumeOverride && musicVolumeOverride < volume)
		{
			num = musicVolumeOverride;
		}
		bool flag = false;
		if (musicVolume <= 0f && num > 0f)
		{
			flag = true;
		}
		musicVolume = Mathf.Clamp(volume, 0f, 1f);
		float num2 = Mathf.Clamp(num, 0f, 1f);
		AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
		for (int i = 0; i < component.AudioCategories.Length; i++)
		{
			string name = component.AudioCategories[i].Name;
			if (IsCategoryMusic(name))
			{
				AudioController.SetCategoryVolume(name, categoryVolumes[name] * num2);
			}
		}
		if (flag && SingletonMonoBehaviour<AudioController>.Instance != null)
		{
			SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().RefreshLocation();
		}
	}

	private static void StoreVolumes()
	{
		if (!volumesStored)
		{
			volumesStored = true;
			AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
			for (int i = 0; i < component.AudioCategories.Length; i++)
			{
				string name = component.AudioCategories[i].Name;
				categoryVolumes[name] = AudioController.GetCategoryVolume(name);
			}
		}
	}

	private static bool IsCategoryInWorldSFX(string categoryName)
	{
		return categoryName.Substring(0, 3) == "SFX";
	}

	private static bool IsCategoryMusic(string categoryName)
	{
		return categoryName.Substring(0, 5) == "Music";
	}

	private static void _LockInWorldSFX()
	{
		AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
		for (int i = 0; i < component.AudioCategories.Length; i++)
		{
			string name = component.AudioCategories[i].Name;
			if (IsCategoryInWorldSFX(name))
			{
				AudioController.FadeOutCategory(name, categoryFadeOutTime);
			}
		}
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetSFXLockState(val: true);
	}

	private static void _UnlockInWorldSFX()
	{
		AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
		for (int i = 0; i < component.AudioCategories.Length; i++)
		{
			string name = component.AudioCategories[i].Name;
			if (IsCategoryInWorldSFX(name))
			{
				AudioController.FadeInCategory(name, categoryFadeInTime);
			}
		}
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetSFXLockState(val: false);
	}
}
