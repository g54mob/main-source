using DV.Utils;
using UnityEngine;
using UnityEngine.Audio;

public class UnderwaterExternalCameraAudio : MonoBehaviour
{
	private const string WATER_SPLASH_HUMAN_WALK = "WaterSplashHumanWalk";

	private const float VOLUME_THRESHOLD = 0.01f;

	public Camera cam;

	public AudioMixerGroup mixer;

	private AudioSource underwaterSource;

	private void Awake()
	{
		underwaterSource = base.gameObject.AddComponent<AudioSource>();
		underwaterSource.clip = SingletonBehaviour<AudioManager>.Instance.underwaterClip;
		underwaterSource.loop = true;
		underwaterSource.volume = 0f;
		underwaterSource.spatialBlend = 0f;
		underwaterSource.outputAudioMixerGroup = mixer;
		underwaterSource.enabled = false;
	}

	private void OnDisable()
	{
		underwaterSource.volume = 0f;
	}

	private void Update()
	{
		underwaterSource.volume = Mathf.Lerp(underwaterSource.volume, (cam.transform.position.y < LevelInfo.WaterLevel) ? 1 : 0, 3f * Time.deltaTime);
		bool num = underwaterSource.enabled;
		bool flag = underwaterSource.volume > 0.01f;
		if (num != flag)
		{
			underwaterSource.enabled = flag;
			if (flag)
			{
				underwaterSource.PlayRandomTime();
			}
		}
	}
}
