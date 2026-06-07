using UnityEngine;
using UnityEngine.Audio;

namespace DV.Audio
{
	[CreateAssetMenu(menuName = "DV/Environment Sound Descriptor")]
	public class EnvironmentSoundDescriptor : ScriptableObject
	{
		[Header("Main")]
		public AudioClip[] clips;

		public bool is3D = true;

		[Range(0f, 1f)]
		public float chanceWeight = 1f;

		public AudioMixerGroup targetMixer;

		[Header("Sound")]
		public AudioRolloffMode rolloffMode;

		public Vector2 distanceRangePosition = new Vector2(10f, 500f);

		public Vector2 distanceRangeVolume = new Vector2(10f, 500f);

		public Vector2 volumeRange = new Vector2(1f, 1f);

		public Vector2 pitchRange = new Vector2(1f, 1f);

		[Header("Repetition")]
		public Vector2Int repeats = new Vector2Int(1, 1);

		public Vector2 repeatGap = new Vector2(0f, 1f);

		public Vector2 cooldown = new Vector2(0f, 0f);

		[Header("Schedule")]
		public bool hasSchedule = true;

		[Range(0f, 23f)]
		public int hourStart;

		[Range(0f, 59f)]
		public int minuteStart;

		[Range(0f, 23f)]
		public int hourEnd = 23;

		[Range(0f, 59f)]
		public int minuteEnd = 59;

		[Header("Positioning")]
		public Vector2 relativeAltitudeRange = new Vector2(0f, 30f);

		public Vector2 absoluteAltitudeRange = new Vector2(0f, 1200f);

		[Header("Conditions")]
		public Vector2 sunlightRange = new Vector2(0f, 1f);

		public Vector2 rainRange = new Vector2(0f, 1f);

		public Vector2 wetnessRange = new Vector2(0f, 1f);

		public Vector2 thunderRange = new Vector2(0f, 1f);

		private int robin = -1;

		public AudioClip Play(AudioSource source, float spatialBlend = 1f, AudioMixerGroup fallbackMixer = null, bool forceMixerGroup = false, float volumeMultiplier = 1f)
		{
			if (clips == null || clips.Length == 0)
			{
				return null;
			}
			if (robin < 0)
			{
				robin = Random.Range(0, clips.Length);
			}
			source.spatialBlend = (is3D ? spatialBlend : 0f);
			source.volume = Random.Range(volumeRange.x, volumeRange.y) * volumeMultiplier;
			source.pitch = Random.Range(pitchRange.x, pitchRange.y);
			source.rolloffMode = rolloffMode;
			source.minDistance = distanceRangeVolume.x;
			source.maxDistance = distanceRangeVolume.y;
			source.outputAudioMixerGroup = ((targetMixer == null || forceMixerGroup) ? fallbackMixer : targetMixer);
			AudioClip audioClip = clips[robin];
			if (!source.enabled || !source.gameObject.activeInHierarchy)
			{
				Debug.LogWarning("[EnvironmentSoundDescriptor] AudioSource " + source.gameObject.GetPath() + " is disabled and it's supposed to play " + clips[robin].name, source);
			}
			source.PlayOneShot(audioClip);
			if (clips.Length > 1)
			{
				robin = (robin + Random.Range(1, clips.Length - 1)) % clips.Length;
			}
			return audioClip;
		}

		public bool Check(int hour, int minute, float distance, float groundLevel, float positionY, float cameraY, float sunlight, float rain, float wetness, float thunder)
		{
			if (distance < distanceRangePosition.x || distance > distanceRangePosition.y)
			{
				return false;
			}
			if (hasSchedule)
			{
				int num = hour * 60 + minute;
				int num2 = hourStart * 60 + minuteStart;
				int num3 = hourEnd * 60 + minuteEnd;
				bool num4;
				if (num3 < num2)
				{
					if (num >= num2)
					{
						goto IL_006f;
					}
					num4 = num > num3;
				}
				else
				{
					if (num < num2)
					{
						goto IL_006d;
					}
					num4 = num > num3;
				}
				if (num4)
				{
					goto IL_006d;
				}
			}
			goto IL_006f;
			IL_006f:
			if (is3D)
			{
				if (positionY < absoluteAltitudeRange.x || positionY > absoluteAltitudeRange.y)
				{
					return false;
				}
				if (positionY - groundLevel < relativeAltitudeRange.x || positionY - groundLevel > relativeAltitudeRange.y)
				{
					return false;
				}
			}
			else
			{
				if (cameraY < absoluteAltitudeRange.x || cameraY > absoluteAltitudeRange.y)
				{
					return false;
				}
				if (cameraY - groundLevel < relativeAltitudeRange.x || cameraY - groundLevel > relativeAltitudeRange.y)
				{
					return false;
				}
			}
			if (sunlight < sunlightRange.x || sunlight > sunlightRange.y)
			{
				return false;
			}
			if (rain < rainRange.x || rain > rainRange.y)
			{
				return false;
			}
			if (wetness < wetnessRange.x || wetness > wetnessRange.y)
			{
				return false;
			}
			if (thunder < thunderRange.x || thunder > thunderRange.y)
			{
				return false;
			}
			return true;
			IL_006d:
			return false;
		}
	}
}
