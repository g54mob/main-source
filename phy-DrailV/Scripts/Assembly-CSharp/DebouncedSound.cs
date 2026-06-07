using DV.Utils;
using UnityEngine;

public class DebouncedSound : MonoBehaviour
{
	public const float DEBOUNCE_SECONDS = 0.1f;

	public const float VOLUME_BOOST_FACTOR = 3f;

	public const float MIN_SPEED_THRESHOLD = 0.01f;

	public const float MAX_SPEED_THRESHOLD = 3f;

	public void PlayDebounced(AudioClip clip, Vector3 worldPoint, float volume)
	{
		float value;
		if (!SingletonBehaviour<AudioManager>.Instance)
		{
			Debug.LogWarning("DebouncedSound couldn't find an AudioManager instance, will do nothing", this);
		}
		else if (!SingletonBehaviour<AudioManager>.Instance.debouncedSoundPlayTimes.TryGetValue(clip, out value) || !(Time.timeSinceLevelLoad - value < 0.1f))
		{
			SingletonBehaviour<AudioManager>.Instance.debouncedSoundPlayTimes[clip] = Time.timeSinceLevelLoad;
			clip.Play(worldPoint, volume * 3f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.cabGroup);
		}
	}
}
