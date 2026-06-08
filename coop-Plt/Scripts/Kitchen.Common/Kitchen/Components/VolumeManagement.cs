using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kitchen.Components
{
	public static class VolumeManagement
	{
		public static List<float> VolumeValues = new List<float> { 0f, 0.0625f, 0.25f, 0.5f, 1f, 1.25f, 1.5f, 2f };

		public static List<float> MusicVolumeValues = new List<float> { 0f, 0.005f, 0.02f, 0.04f, 0.049999997f, 0.074999996f, 0.099999994f, 0.14999999f };

		public static bool SoundIsPaused;

		public static float OverallVolume => 1f;

		public static float MusicVolume => Preferences.Get<float>(Pref.MusicVolume);

		public static float EffectVolume => Preferences.Get<float>(Pref.EffectVolume);

		public static List<string> VolumeLevels
		{
			get
			{
				List<string> list = new List<string>();
				for (int i = 0; i < VolumeValues.Count; i++)
				{
					_ = VolumeValues[i];
					string text = string.Concat(Enumerable.Repeat("<sprite name=\"pip_filled\"> ", i));
					string text2 = string.Concat(Enumerable.Repeat("<sprite name=\"pip_empty\"> ", VolumeValues.Count - i - 1));
					list.Add("<size=1.7><voffset=-0.5><mspace=1em>" + text + text2);
				}
				return list;
			}
		}

		public static float GetVolume(SoundCategory cat = SoundCategory.Generic)
		{
			switch (cat)
			{
			case SoundCategory.Effects:
				return EffectVolume * OverallVolume;
			case SoundCategory.Music:
				return MusicVolume * OverallVolume;
			case SoundCategory.Generic:
				return OverallVolume;
			default:
				Debug.LogWarning($"Tried to get volume for an unknown category {cat}");
				return 0f;
			}
		}

		public static void SetVolume(SoundCategory cat, float value)
		{
			switch (cat)
			{
			case SoundCategory.Effects:
				Preferences.Set(Pref.EffectVolume, value);
				break;
			case SoundCategory.Music:
				Preferences.Set(Pref.MusicVolume, value);
				break;
			case SoundCategory.Generic:
				Preferences.Set(Pref.OverallVolume, value);
				break;
			}
		}
	}
}
