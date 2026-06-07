using DV.Utils;
using DV.WeatherSystem;
using DV.WorldTools;
using UnityEngine;
using UnityEngine.Audio;

namespace DV.Audio
{
	public class EnvironmentSoundZone : MonoBehaviour
	{
		[Header("Zone")]
		public int sourcesCount = 4;

		public float cutoffDistance = 250f;

		public bool groundRelativeY;

		public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

		[Header("Audio")]
		public AudioMixerGroup defaultMixerGroup;

		public EnvironmentSoundDescriptor[] sounds;

		private EnvironmentSoundSystem.DetailPlayback[] details;

		private float[] cooldowns;

		private int detailRobin;

		public bool InRange { get; private set; }

		private void Awake()
		{
			details = new EnvironmentSoundSystem.DetailPlayback[sourcesCount];
			EnvironmentSoundSystem.InitializeSources(base.transform, details);
			cooldowns = new float[sounds.Length];
		}

		public void Tick(float deltaTime)
		{
			for (int i = 0; i < cooldowns.Length; i++)
			{
				if (cooldowns[i] > 0f)
				{
					cooldowns[i] -= deltaTime;
				}
			}
			for (int j = 0; j < details.Length; j++)
			{
				details[j].Update(deltaTime);
			}
			if (PlayerManager.ActiveCamera != null && sounds.Length != 0)
			{
				Vector3 position = PlayerManager.ActiveCamera.transform.position;
				Vector3 vector = base.transform.TransformPoint(bounds.center);
				if ((position - vector).sqrMagnitude > cutoffDistance * cutoffDistance)
				{
					InRange = false;
					return;
				}
				InRange = true;
				Vector3 position2 = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
				position2 = base.transform.TransformPoint(position2);
				float pointSample = HeightMapProvider.GetPointSample(position2);
				if (groundRelativeY)
				{
					position2.y = pointSample + Random.Range(bounds.min.y, bounds.max.y) * base.transform.lossyScale.y;
				}
				float num = Vector3.Distance(position, position2);
				int hour = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime.Hour;
				int minute = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime.Minute;
				float sunlight = Mathf.Clamp01(SingletonBehaviour<WeatherDriver>.Instance.GlobalSunIntensityFactor);
				float rain = SingletonBehaviour<WeatherDriver>.Instance.RainValue;
				float wetness = SingletonBehaviour<WeatherDriver>.Instance.WetnessValue;
				float thunder = SingletonBehaviour<WeatherDriver>.Instance.ThunderValue;
				int num2 = Random.Range(0, sounds.Length);
				for (int k = 0; k < sounds.Length; k++)
				{
					int num3 = (k + num2) % sounds.Length;
					EnvironmentSoundDescriptor environmentSoundDescriptor = sounds[num3];
					if (cooldowns[k] > 0f || Random.value > environmentSoundDescriptor.chanceWeight || !environmentSoundDescriptor.Check(hour, minute, num, pointSample, position2.y, position.y, sunlight, rain, wetness, thunder))
					{
						continue;
					}
					for (int l = 0; l < details.Length; l++)
					{
						if (!details[detailRobin].IsBusy)
						{
							break;
						}
						detailRobin = (detailRobin + 1) % details.Length;
					}
					if (!details[detailRobin].IsBusy)
					{
						float spatialBlend = Mathf.Clamp01(Mathf.InverseLerp(8f, 20f, num));
						AudioClip audioClip = details[detailRobin].Play(environmentSoundDescriptor, position2, spatialBlend, defaultMixerGroup);
						cooldowns[k] = Random.Range(environmentSoundDescriptor.cooldown.x, environmentSoundDescriptor.cooldown.y);
						if (SingletonBehaviour<EnvironmentSoundSystem>.Instance.enableLogging && (bool)audioClip)
						{
							Debug.Log("ZONE " + base.gameObject.name + " PLAY [" + environmentSoundDescriptor.name + " / " + audioClip.name + "] @ " + position2);
						}
					}
					break;
				}
			}
			else
			{
				InRange = false;
			}
		}

		private void OnEnable()
		{
			if ((bool)SingletonBehaviour<EnvironmentSoundSystem>.Instance)
			{
				SingletonBehaviour<EnvironmentSoundSystem>.Instance.Register(this);
			}
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading && (bool)SingletonBehaviour<EnvironmentSoundSystem>.Instance)
			{
				SingletonBehaviour<EnvironmentSoundSystem>.Instance.Unregister(this);
			}
		}

		public int CountPlayingSources()
		{
			int num = 0;
			for (int i = 0; i < details.Length; i++)
			{
				if (details[i].source.enabled && details[i].source.gameObject.activeInHierarchy && details[i].source.isPlaying)
				{
					num++;
				}
			}
			return num;
		}
	}
}
