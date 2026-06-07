using DV.UIFramework;
using DV.Utils;
using UnityEngine;
using UnityEngine.Audio;

public class UnderwaterPlayerSplash : NullCheckingMonoBehaviour
{
	private const float VOLUME_THRESHOLD = 0.01f;

	private const float WATER_STEPS_PER_SECOND = 2f;

	private const float DISTANCE_BETWEEN_WATER_STEPS = 0.16f;

	private const string WATER_SPLASH_HUMAN_WALK = "WaterSplashHumanWalk";

	private const string WATER_SPLASH_HUMAN = "WaterSplashHuman";

	[SerializeField]
	[NullCheck]
	private AudioMixerGroup mixer;

	[SerializeField]
	private Transform cameraTransformOverride;

	private Camera cam;

	private Transform camTransform;

	private AudioSource underwaterSource;

	private float lastStepTime;

	private float lastTransformY;

	private float lastCameraY;

	private Vector3 lastSwimSplashPosition;

	protected override void Awake()
	{
		base.Awake();
		underwaterSource = base.gameObject.AddComponent<AudioSource>();
		underwaterSource.clip = SingletonBehaviour<AudioManager>.Instance.underwaterClip;
		underwaterSource.loop = true;
		underwaterSource.volume = 0f;
		underwaterSource.spatialBlend = 0f;
		underwaterSource.outputAudioMixerGroup = mixer;
		underwaterSource.enabled = false;
	}

	private void OnEnable()
	{
		if ((bool)camTransform)
		{
			lastTransformY = base.transform.position.y;
			lastCameraY = camTransform.position.y;
		}
	}

	private void OnDisable()
	{
		underwaterSource.volume = 0f;
	}

	private void Start()
	{
		cam = PlayerManager.PlayerCamera;
		camTransform = (cameraTransformOverride ? cameraTransformOverride : cam.transform);
		lastTransformY = base.transform.position.y;
		lastCameraY = camTransform.position.y;
	}

	private void Update()
	{
		Vector3 position = camTransform.position;
		Vector3 position2 = base.transform.position;
		if (cam.enabled)
		{
			float waterLevel = LevelInfo.WaterLevel;
			underwaterSource.volume = Mathf.Lerp(underwaterSource.volume, (position.y < waterLevel) ? 1 : 0, 3f * Time.deltaTime);
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
			if (lastTransformY > waterLevel && position2.y < waterLevel)
			{
				lastStepTime = Time.time;
				float value = (lastTransformY - position2.y) * Time.deltaTime * 1000f;
				SingletonBehaviour<AudioManager>.Instance.waterSplashHumanClip.Play(position2, NumberUtil.MapClamp(value, 0f, 5f, 0.03f, 1f), NumberUtil.MapClamp(value, 0f, 5f, 0.8f, 1.3f));
				if ((bool)SingletonBehaviour<ParticlePool>.Instance)
				{
					SingletonBehaviour<ParticlePool>.Instance.SpawnParticleOnWater("WaterSplashHuman", position2);
				}
			}
			else if (lastCameraY < waterLevel && position.y > waterLevel)
			{
				SingletonBehaviour<AudioManager>.Instance.waterSplashSwimoutClip.Play(position2, Random.Range(0.9f, 1.2f), Random.Range(0.9f, 1.2f));
				if ((bool)SingletonBehaviour<ParticlePool>.Instance)
				{
					SingletonBehaviour<ParticlePool>.Instance.SpawnParticleOnWater("WaterSplashHumanWalk", position2);
				}
			}
			else if (lastCameraY > waterLevel && position.y < waterLevel)
			{
				SingletonBehaviour<AudioManager>.Instance.waterSplashSwimoutClip.Play(position2, Random.Range(0.9f, 1.2f), Random.Range(0.9f, 1.2f));
				if ((bool)SingletonBehaviour<ParticlePool>.Instance)
				{
					SingletonBehaviour<ParticlePool>.Instance.SpawnParticleOnWater("WaterSplashHumanWalk", position2);
				}
			}
			else if (position2.y < waterLevel && position.y > waterLevel)
			{
				Vector3 vector = position2 - WorldMover.currentMove;
				vector.y = 0f;
				if (Vector3.SqrMagnitude(vector - lastSwimSplashPosition) > 0.16f)
				{
					if (Time.time - lastStepTime > 0.5f)
					{
						lastStepTime = Time.time;
						SingletonBehaviour<AudioManager>.Instance.waterSplashSwimoutClip.Play(position2, Random.Range(0.1f, 0.3f), Random.Range(0.6f, 1.2f));
						if ((bool)SingletonBehaviour<ParticlePool>.Instance)
						{
							SingletonBehaviour<ParticlePool>.Instance.SpawnParticleOnWater("WaterSplashHumanWalk", position2);
						}
					}
					lastSwimSplashPosition = vector;
				}
			}
		}
		else
		{
			underwaterSource.volume = 0f;
			underwaterSource.enabled = false;
		}
		lastTransformY = position2.y;
		lastCameraY = position.y;
	}
}
