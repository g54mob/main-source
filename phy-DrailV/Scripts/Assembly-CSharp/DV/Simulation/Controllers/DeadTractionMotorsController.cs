using System.Collections;
using System.Collections.Generic;
using DV.Damage;
using DV.Hazmat;
using LocoSim.Attributes;
using LocoSim.Implementations;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class DeadTractionMotorsController : ASimInitializedController
	{
		private const float FIRE_DURATION = 45f;

		private const float FIRE_IGNITION_RADIUS = 5f;

		private const float FIRE_POSITION_RADIUS_OFFSET_MAX = 1.5f;

		private const float FIRE_DAMAGE_INTERVAL = 1f;

		private const float TM_BLOW_PARTICLE_DURATION = 5f;

		private const float TM_BLOW_IGNITION_RADIUS = 6f;

		private const float SPARKS_IGNITION_RADIUS = 3f;

		private const float SPARKS_IGNITION_WAIT_PERIOD = 3f;

		[PortId(null, null, true)]
		public string overheatFuseOffPortId;

		[FuseId]
		public string tmFuseId;

		public GameObject sparksPrefab;

		public GameObject firePrefab;

		[Space]
		public GameObject tmBlowPrefab;

		public Transform tmBlowAnchor;

		private PoweredWheelsManager pwm;

		private Port overheatFuseOffPort;

		private Fuse tmFuse;

		private CarDamageModel carDamageModel;

		private Dictionary<byte, GameObject> ongoingSparkGOs = new Dictionary<byte, GameObject>();

		private Coroutine sparksIgnitionCoro;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			pwm = car.SimController?.poweredWheels;
			if (pwm == null)
			{
				Debug.LogError("Unexpected state: Missing PoweredWheelsManager. DeadTractionMotorsController can't function. Destroying self.");
				Object.Destroy(this);
				return;
			}
			if (simFlow.TryGetFuse(tmFuseId, out tmFuse, canBeNull: true))
			{
				OnFuseChanged(tmFuse.State);
				tmFuse.StateUpdated += OnFuseChanged;
			}
			if (tmBlowPrefab != null)
			{
				if (simFlow.TryGetPort(overheatFuseOffPortId, out overheatFuseOffPort))
				{
					overheatFuseOffPort.ValueUpdatedInternally += OnOverheatFuseOffPortChanged;
				}
				else
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: DeadTractionMotorsController isn't initialized properly!", this);
				}
			}
			carDamageModel = car.CarDamage;
			if (carDamageModel == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: DeadTractionMotorsController missing CarDamageModel reference. Body damage won't be inflicted!", this);
			}
			if (firePrefab != null)
			{
				pwm.PoweredWheelSetOnFire += OnPoweredWheelSetOnFire;
			}
			if (tmBlowPrefab != null && tmBlowAnchor == null)
			{
				Debug.LogError("tmBlowAnchor is null. Please set the anchor!");
			}
		}

		private void Start()
		{
			if (!(sparksPrefab != null))
			{
				return;
			}
			PoweredWheel[] poweredWheels = pwm.poweredWheels;
			foreach (PoweredWheel poweredWheel in poweredWheels)
			{
				if (poweredWheel.IsBroken)
				{
					OnPoweredWheelKilled(poweredWheel);
				}
			}
			pwm.PoweredWheelKilled += OnPoweredWheelKilled;
			pwm.PoweredWheelRepaired += OnPoweredWheelRepaired;
		}

		private void OnDestroy()
		{
			if (tmFuse != null)
			{
				tmFuse.StateUpdated -= OnFuseChanged;
			}
			if (overheatFuseOffPort != null)
			{
				overheatFuseOffPort.ValueUpdatedInternally -= OnOverheatFuseOffPortChanged;
			}
			pwm.PoweredWheelKilled -= OnPoweredWheelKilled;
			pwm.PoweredWheelRepaired -= OnPoweredWheelRepaired;
			pwm.PoweredWheelSetOnFire -= OnPoweredWheelSetOnFire;
			sparksIgnitionCoro = null;
			StopAllCoroutines();
		}

		private void OnOverheatFuseOffPortChanged(float fuseOffDueToOverheating)
		{
			if (AStartGameData.carsAndJobsLoadingFinished && fuseOffDueToOverheating == 1f)
			{
				GameObject obj = Object.Instantiate(tmBlowPrefab, tmBlowAnchor.position, tmBlowAnchor.rotation, base.transform);
				Igniter.Ignite(obj.transform.position, 1f, 6f, null, 4f);
				Object.Destroy(obj, 5f);
			}
		}

		private void OnFuseChanged(bool fuseOn)
		{
			foreach (KeyValuePair<byte, GameObject> ongoingSparkGO in ongoingSparkGOs)
			{
				ongoingSparkGO.Value.SetActive(fuseOn);
			}
			if (fuseOn)
			{
				if (ongoingSparkGOs.Count > 0 && sparksIgnitionCoro == null)
				{
					sparksIgnitionCoro = StartCoroutine(SparksIgnitionCoro());
				}
			}
			else if (sparksIgnitionCoro != null)
			{
				StopCoroutine(sparksIgnitionCoro);
				sparksIgnitionCoro = null;
			}
		}

		private void OnPoweredWheelKilled(PoweredWheel poweredWheel)
		{
			if (ongoingSparkGOs.ContainsKey(poweredWheel.index))
			{
				Debug.LogError(string.Format("Unexpected state: {0} already contains sparks for wheel {1}. Skipping instantiation of new ones.", "ongoingSparkGOs", poweredWheel.index));
				return;
			}
			GameObject gameObject = Object.Instantiate(sparksPrefab, poweredWheel.wheelTransform.position, pwm.transform.rotation, base.transform);
			AudioSource componentInChildren = gameObject.GetComponentInChildren<AudioSource>();
			if (componentInChildren != null)
			{
				componentInChildren.time = Random.value * componentInChildren.clip.length;
			}
			ongoingSparkGOs.Add(poweredWheel.index, gameObject);
			if (tmFuse != null && !tmFuse.State)
			{
				gameObject.SetActive(value: false);
			}
			else if (sparksIgnitionCoro == null)
			{
				sparksIgnitionCoro = StartCoroutine(SparksIgnitionCoro());
			}
		}

		private void OnPoweredWheelRepaired(PoweredWheel poweredWheel)
		{
			if (!ongoingSparkGOs.TryGetValue(poweredWheel.index, out var value))
			{
				Debug.LogError($"Unexpected state: No sparks found for wheel {poweredWheel.index}. Something is bad.", base.gameObject);
				return;
			}
			Object.Destroy(value);
			ongoingSparkGOs.Remove(poweredWheel.index);
			if (sparksIgnitionCoro != null)
			{
				StopCoroutine(sparksIgnitionCoro);
				sparksIgnitionCoro = null;
			}
		}

		private void OnPoweredWheelSetOnFire(PoweredWheel poweredWheel)
		{
			GameObject gameObject = Object.Instantiate(firePrefab, poweredWheel.wheelTransform.position, pwm.transform.rotation, base.transform);
			Vector2 vector = Random.insideUnitCircle * 1.5f;
			gameObject.transform.Translate(vector.x, 0f, vector.y, Space.Self);
			StartCoroutine(FireCoro(gameObject));
		}

		private IEnumerator FireCoro(GameObject fireGO)
		{
			int waitSeconds = Mathf.RoundToInt(45f);
			for (int i = 0; i < waitSeconds; i++)
			{
				yield return WaitFor.Seconds(1f);
				if (fireGO != null)
				{
					Igniter.Ignite(fireGO.transform.position, 1f, 5f, null, 4f);
				}
				else
				{
					Debug.LogError("Unexpected state: fireGO is null. Something is bad, skipping logic ignition.");
				}
				if (!(carDamageModel == null))
				{
					float modifiedFireDamage = carDamageModel.GetModifiedFireDamage(1f);
					carDamageModel.DamageCar(modifiedFireDamage);
				}
			}
			if (fireGO != null)
			{
				Object.Destroy(fireGO);
			}
			else
			{
				Debug.LogError("Unexpected state: fireGO is null. Something is bad.", base.gameObject);
			}
		}

		private IEnumerator SparksIgnitionCoro()
		{
			while (ongoingSparkGOs.Count > 0)
			{
				foreach (KeyValuePair<byte, GameObject> ongoingSparkGO in ongoingSparkGOs)
				{
					Igniter.Ignite(ongoingSparkGO.Value.transform.position, 1f, 3f, null, 4f);
				}
				yield return WaitFor.Seconds(3f);
			}
			Debug.LogError("Unexpected state: Ongoing SparksIgnitionCoro, but ongoingSparkGOs are empty! Killing coro");
			sparksIgnitionCoro = null;
		}
	}
}
