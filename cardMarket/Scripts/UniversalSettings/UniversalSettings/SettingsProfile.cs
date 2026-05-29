using System;
using UnityEngine;

namespace UniversalSettings
{
	[Serializable]
	[CreateAssetMenu(menuName = "Universal Settings/Settings Profile", fileName = "Settings Profile")]
	public class SettingsProfile : ScriptableObject
	{
		public const int MAX_RENDERER_FEATURES = 30;

		public const int MAX_AUDIO_MIXERS = 10;

		public const int MAX_CUSTOM_BOOLEAN = 11;

		public const int MAX_CUSTOM_FLOAT = 10;

		public const int MAX_CUSTOM_INTEGER = 10;

		public int fpsIndex = 9999;

		public int resolutionIndex = 9999;

		public int refreshRateIndex;

		public int antiAliasingIndex = 9999;

		public int shadowModeIndex = 9999;

		public int shadowDistanceIndex = 9999;

		public int shadowResolutionIndex = 9999;

		public int textureResolutionIndex;

		public float brightness = 0.5f;

		public bool fullscreen = true;

		public bool vsync;

		public bool postProcessing = true;

		public bool[] postProcessingEffect;

		public bool[] rendererFeatures;

		public float masterVolume = 1f;

		public float[] audioMixerVolume;

		public bool[] customBoolean;

		public float[] customFloat;

		public int[] customInteger;

		public SettingsProfile()
		{
			UpdateStruct();
		}

		public void UpdateStruct()
		{
			int num = Enum.GetNames(typeof(PostProcessingEffect)).Length;
			if (postProcessingEffect == null || postProcessingEffect.Length != num)
			{
				postProcessingEffect = new bool[num];
				for (int i = 0; i < num; i++)
				{
					postProcessingEffect[i] = true;
				}
			}
			if (rendererFeatures == null || rendererFeatures.Length != 30)
			{
				rendererFeatures = new bool[30];
				for (int j = 0; j < 30; j++)
				{
					rendererFeatures[j] = true;
				}
			}
			if (audioMixerVolume == null || audioMixerVolume.Length != 10)
			{
				audioMixerVolume = new float[10];
				for (int k = 0; k < 10; k++)
				{
					audioMixerVolume[k] = 1f;
				}
			}
			if (customBoolean == null || customBoolean.Length != 11)
			{
				customBoolean = new bool[11];
			}
			if (customFloat == null || customFloat.Length != 10)
			{
				customFloat = new float[10];
			}
			if (customInteger == null || customInteger.Length != 10)
			{
				customInteger = new int[10];
			}
		}

		internal FullScreenMode GetFullScreenMode()
		{
			if (fullscreen)
			{
				return FullScreenMode.FullScreenWindow;
			}
			return FullScreenMode.Windowed;
		}

		public bool CompareGraphicQuality(SettingsProfile other)
		{
			UpdateStruct();
			other.UpdateStruct();
			if (other.antiAliasingIndex != antiAliasingIndex)
			{
				return false;
			}
			if (other.shadowModeIndex != shadowModeIndex)
			{
				return false;
			}
			if (other.shadowDistanceIndex != shadowDistanceIndex)
			{
				return false;
			}
			if (other.shadowResolutionIndex != shadowResolutionIndex)
			{
				return false;
			}
			if (other.textureResolutionIndex != textureResolutionIndex)
			{
				return false;
			}
			if (other.postProcessing != postProcessing)
			{
				return false;
			}
			for (int i = 0; i < postProcessingEffect.Length; i++)
			{
				if (other.postProcessingEffect[i] != postProcessingEffect[i])
				{
					return false;
				}
			}
			for (int j = 0; j < 30; j++)
			{
				if (other.rendererFeatures[j] != rendererFeatures[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
