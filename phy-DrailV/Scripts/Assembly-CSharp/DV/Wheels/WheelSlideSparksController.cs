using System.Collections;
using DV.Hazmat;
using DV.Utils;
using UnityEngine;

namespace DV.Wheels
{
	public class WheelSlideSparksController : MonoBehaviour
	{
		private const string WHEEL_SPARKS_PREFAB = "WheelslipSparks";

		private const float SPARKS_EXISTENCE_SPEED_THRESHOLD = 0.5f;

		private const float MAX_START_SPEED_THRESHOLD = 3f;

		private const float UPDATE_PERIOD = 0.1f;

		private const float SPARK_START_SPEED_MIN = 0.5f;

		private const float SPARK_START_SPEED_MAX = 3f;

		private const float SQR_PARTICLES_PLAYER_RANGE = 2500f;

		private static readonly Vector3 directionForwardSparksRotation = new Vector3(0f, 180f, 0f);

		private static readonly Vector3 directionReverseSparksRotation = Vector3.zero;

		public Transform[] sparkAnchors;

		private ParticleSystem[] sparks;

		private TrainCar car;

		private Coroutine updateSparksCoro;

		private const float maxIgnitionHeight = 5f;

		private const float ignitionSphereRadius = 20f;

		public ParticleSystem[] Sparks
		{
			get
			{
				if (sparks != null)
				{
					return sparks;
				}
				sparks = new ParticleSystem[sparkAnchors.Length];
				Object original = Resources.Load("WheelslipSparks", typeof(GameObject));
				for (int i = 0; i < sparks.Length; i++)
				{
					GameObject gameObject = (GameObject)Object.Instantiate(original, sparkAnchors[i].position, sparkAnchors[i].rotation, sparkAnchors[i]);
					sparks[i] = gameObject.GetComponent<ParticleSystem>();
				}
				return sparks;
			}
		}

		private void Awake()
		{
			car = TrainCar.Resolve(base.gameObject);
			if (sparkAnchors == null || sparkAnchors.Length == 0)
			{
				Debug.LogError("Unexpected state: sparkAnchors setup is null or empty. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			if (car.adhesionController == null)
			{
				Debug.LogError("Unexpected state: Missing AdhesionController, WheelSlideTrainsetObserver can't function. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				car.adhesionController.WheelSlideStateChanged += OnWheelSlideStateChanged;
			}
		}

		private void OnDisable()
		{
			if (updateSparksCoro != null)
			{
				StopSparksCoro();
			}
		}

		private void OnDestroy()
		{
			if (car.adhesionController != null)
			{
				car.adhesionController.WheelSlideStateChanged -= OnWheelSlideStateChanged;
			}
		}

		private void OnWheelSlideStateChanged(bool isWheelSliding)
		{
			if (car.derailed)
			{
				return;
			}
			if (isWheelSliding)
			{
				if (updateSparksCoro != null)
				{
					Debug.LogError(string.Format("Unexpected state: {0}: {1}, but {2} is not null. Something is not right. Ignoring request", "isWheelSliding", isWheelSliding, "updateSparksCoro"));
				}
				else
				{
					updateSparksCoro = StartCoroutine(SparksPSUpdate(0.1f));
				}
			}
			else if (updateSparksCoro == null)
			{
				Debug.LogError(string.Format("Unexpected state: {0}: {1}, but {2} is null. Something is not right. Ignoring request", "isWheelSliding", isWheelSliding, "updateSparksCoro"));
			}
			else
			{
				StopSparksCoro();
			}
		}

		private void StopSparksCoro()
		{
			StopCoroutine(updateSparksCoro);
			updateSparksCoro = null;
			ParticleSystem[] array = Sparks;
			foreach (ParticleSystem particleSystem in array)
			{
				if (particleSystem.isPlaying)
				{
					particleSystem.Stop();
				}
				Object.Destroy(particleSystem.gameObject, 1f);
			}
			sparks = null;
		}

		private IEnumerator SparksPSUpdate(float timeout)
		{
			while (!car.derailed)
			{
				if (PlayerManager.ActiveCamera == null)
				{
					yield return WaitFor.Seconds(timeout);
					continue;
				}
				float sqrMagnitude = (PlayerManager.ActiveCamera.transform.position - car.transform.position).sqrMagnitude;
				float forwardSpeed = car.GetForwardSpeed();
				float num = Mathf.Abs(forwardSpeed);
				if (num < 0.5f || sqrMagnitude > 2500f)
				{
					ParticleSystem[] array = Sparks;
					foreach (ParticleSystem particleSystem in array)
					{
						if (particleSystem.isPlaying)
						{
							particleSystem.Stop();
						}
					}
				}
				else
				{
					Quaternion localRotation = Quaternion.Euler((forwardSpeed >= 0f) ? directionForwardSparksRotation : directionReverseSparksRotation);
					float num2 = NumberUtil.MapClamp(num, 0.5f, 3f, 0.5f, 3f);
					ParticleSystem[] array = Sparks;
					foreach (ParticleSystem particleSystem2 in array)
					{
						particleSystem2.transform.localRotation = localRotation;
						ParticleSystem.MainModule main = particleSystem2.main;
						main.startSpeed = num2;
						if (!particleSystem2.isPlaying)
						{
							particleSystem2.Play();
						}
					}
					Ignite(car.adhesionController.wheelSlide);
				}
				yield return WaitFor.Seconds(timeout);
			}
			StopSparksCoro();
		}

		public void Ignite(float ignitionStrength)
		{
			if ((bool)SingletonBehaviour<HazmatTileManager>.Instance && SingletonBehaviour<HazmatTileManager>.Instance.enabled)
			{
				Igniter.Ignite(base.transform.position, ignitionStrength, 20f, null, 5f);
				Igniter.IgniteTerrain(base.transform.position, ignitionStrength, 5f, 1);
				Igniter.IgniteTerrain(base.transform.position, ignitionStrength, 5f, -1);
				Igniter.IgniteTerrain(base.transform.position, ignitionStrength, 5f, 0, 1);
				Igniter.IgniteTerrain(base.transform.position, ignitionStrength, 5f, 0, -1);
			}
		}
	}
}
