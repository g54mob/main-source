using System;
using System.Collections;
using DV.Hazmat;
using DV.Utils;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Wheels
{
	public class WheelslipSparksController : MonoBehaviour
	{
		[Serializable]
		public class WheelSparksDefinition
		{
			public PoweredWheel poweredWheel;

			public Transform sparksLeftAnchor;

			public Transform sparksRightAnchor;

			[NonSerialized]
			public ParticleSystem sparksLeftPS;

			[NonSerialized]
			public ParticleSystem sparksRightPS;

			public void Init()
			{
				UnityEngine.Object original = Resources.Load("WheelslipSparks", typeof(GameObject));
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(original, sparksLeftAnchor);
				sparksLeftPS = gameObject.GetComponent<ParticleSystem>();
				GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(original, sparksRightAnchor);
				sparksRightPS = gameObject2.GetComponent<ParticleSystem>();
			}
		}

		private const string WHEEL_SPARKS_PREFAB = "WheelslipSparks";

		private const float UPDATE_PERIOD = 0.1f;

		private const float SPARK_START_SPEED_MIN = 1.5f;

		private const float SPARK_START_SPEED_MAX = 3f;

		public WheelSparksDefinition[] wheelSparks;

		private Vector3 directionForwardSparksRotation = new Vector3(0f, 180f, 0f);

		private Vector3 directionReverseSparksRotation = Vector3.zero;

		private TrainCar car;

		private WheelslipController wheelslipController;

		private Coroutine updateSparksCoro;

		private const float maxIgnitionHeight = 5f;

		private const float ignitionSphereRadius = 20f;

		private void Start()
		{
			car = TrainCar.Resolve(base.gameObject);
			if (!car.adhesionController.wheelslipController.IsSome(out wheelslipController))
			{
				Debug.LogError("Unexpected state: Missing WheelslipController, can't function properly! Destroying self", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (wheelSparks == null || wheelSparks.Length == 0)
			{
				Debug.LogError("Unexpected state: wheelSparks setup is null or empty. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			WheelSparksDefinition[] array = wheelSparks;
			foreach (WheelSparksDefinition wheelSparksDefinition in array)
			{
				if (wheelSparksDefinition.poweredWheel == null || wheelSparksDefinition.sparksLeftAnchor == null || wheelSparksDefinition.sparksRightAnchor == null)
				{
					Debug.LogError("Unexpected state: wheelSparks entry contains nulls. Destroying self.", base.gameObject);
					UnityEngine.Object.Destroy(this);
					return;
				}
				wheelSparksDefinition.Init();
			}
			wheelslipController.WheelslipStateChanged += OnWheelslipStateChanged;
		}

		private void OnDisable()
		{
			if (updateSparksCoro != null)
			{
				StopCoroutine(updateSparksCoro);
				updateSparksCoro = null;
				StopSparksPS();
			}
		}

		private void OnDestroy()
		{
			if (wheelslipController != null)
			{
				wheelslipController.WheelslipStateChanged -= OnWheelslipStateChanged;
			}
		}

		private void OnWheelslipStateChanged(bool isWheelslipping)
		{
			if (car.derailed)
			{
				return;
			}
			if (isWheelslipping)
			{
				if (updateSparksCoro != null)
				{
					Debug.LogError(string.Format("Unexpected state: {0}: {1}, but {2} is not null. Something is not right. Ignoring request", "isWheelslipping", isWheelslipping, "updateSparksCoro"));
				}
				else
				{
					updateSparksCoro = StartCoroutine(SparksPSUpdate(0.1f));
				}
			}
			else if (updateSparksCoro == null)
			{
				Debug.LogError(string.Format("Unexpected state: {0}: {1}, but {2} is null. Something is not right. Ignoring request", "isWheelslipping", isWheelslipping, "updateSparksCoro"));
			}
			else
			{
				StopCoroutine(updateSparksCoro);
				updateSparksCoro = null;
				StopSparksPS();
			}
		}

		private void StopSparksPS()
		{
			WheelSparksDefinition[] array = wheelSparks;
			foreach (WheelSparksDefinition wheelSparksDefinition in array)
			{
				if (wheelSparksDefinition.sparksLeftPS.isPlaying)
				{
					wheelSparksDefinition.sparksLeftPS.Stop();
				}
				if (wheelSparksDefinition.sparksRightPS.isPlaying)
				{
					wheelSparksDefinition.sparksRightPS.Stop();
				}
			}
		}

		private IEnumerator SparksPSUpdate(float timeout)
		{
			while (!car.derailed)
			{
				bool num = car.SimController.tractionPortsFeeder.wheelRpm > 0f;
				float num2 = Mathf.Lerp(1.5f, 3f, wheelslipController.wheelslip);
				Quaternion localRotation = Quaternion.Euler(num ? directionForwardSparksRotation : directionReverseSparksRotation);
				WheelSparksDefinition[] array = wheelSparks;
				foreach (WheelSparksDefinition wheelSparksDefinition in array)
				{
					if (!wheelSparksDefinition.poweredWheel.IsPowered)
					{
						if (wheelSparksDefinition.sparksLeftPS.isPlaying)
						{
							wheelSparksDefinition.sparksLeftPS.Stop();
						}
						if (wheelSparksDefinition.sparksRightPS.isPlaying)
						{
							wheelSparksDefinition.sparksRightPS.Stop();
						}
						continue;
					}
					ParticleSystem sparksLeftPS = wheelSparksDefinition.sparksLeftPS;
					sparksLeftPS.transform.localRotation = localRotation;
					ParticleSystem.MainModule main = sparksLeftPS.main;
					main.startSpeed = num2;
					if (!sparksLeftPS.isPlaying)
					{
						sparksLeftPS.Play();
					}
					ParticleSystem sparksRightPS = wheelSparksDefinition.sparksRightPS;
					sparksRightPS.transform.localRotation = localRotation;
					ParticleSystem.MainModule main2 = sparksRightPS.main;
					main2.startSpeed = num2;
					if (!sparksRightPS.isPlaying)
					{
						sparksRightPS.Play();
					}
				}
				Ignite(wheelslipController.wheelslip);
				yield return WaitFor.Seconds(timeout);
			}
			StopSparksPS();
			updateSparksCoro = null;
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
