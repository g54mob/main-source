using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeneGames.Airplane
{
	[RequireComponent(typeof(Rigidbody))]
	public class SimpleAirPlaneController : MonoBehaviour
	{
		public enum AirplaneState
		{
			Flying = 0,
			Landing = 1,
			Takeoff = 2
		}

		public Action crashAction;

		private List<SimpleAirPlaneCollider> airPlaneColliders = new List<SimpleAirPlaneCollider>();

		private float maxSpeed = 0.6f;

		private float speedMultiplier;

		private float currentYawSpeed;

		private float currentPitchSpeed;

		private float currentRollSpeed;

		private float currentSpeed;

		private float currentEngineLightIntensity;

		private float currentEngineSoundPitch;

		private float lastEngineSpeed;

		private bool planeIsDead;

		private Rigidbody rb;

		private Runway currentRunway;

		private float inputH;

		private float inputV;

		private bool inputTurbo;

		private bool inputYawLeft;

		private bool inputYawRight;

		public AirplaneState airplaneState;

		[Header("Wing trail effects")]
		[Range(0.01f, 1f)]
		[SerializeField]
		private float trailThickness = 0.045f;

		[SerializeField]
		private TrailRenderer[] wingTrailEffects;

		[Header("Rotating speeds")]
		[Range(5f, 500f)]
		[SerializeField]
		private float yawSpeed = 50f;

		[Range(5f, 500f)]
		[SerializeField]
		private float pitchSpeed = 100f;

		[Range(5f, 500f)]
		[SerializeField]
		private float rollSpeed = 200f;

		[Header("Rotating speeds multiplers when turbo is used")]
		[Range(0.1f, 5f)]
		[SerializeField]
		private float yawTurboMultiplier = 0.3f;

		[Range(0.1f, 5f)]
		[SerializeField]
		private float pitchTurboMultiplier = 0.5f;

		[Range(0.1f, 5f)]
		[SerializeField]
		private float rollTurboMultiplier = 1f;

		[Header("Moving speed")]
		[Range(5f, 100f)]
		[SerializeField]
		private float defaultSpeed = 10f;

		[Range(10f, 200f)]
		[SerializeField]
		private float turboSpeed = 20f;

		[Range(0.1f, 50f)]
		[SerializeField]
		private float accelerating = 10f;

		[Range(0.1f, 50f)]
		[SerializeField]
		private float deaccelerating = 5f;

		[Header("Turbo settings")]
		[Range(0f, 100f)]
		[SerializeField]
		private float turboHeatingSpeed;

		[Range(0f, 100f)]
		[SerializeField]
		private float turboCooldownSpeed;

		[Header("Turbo heat values")]
		[Tooltip("Real-time information about the turbo's current temperature (do not change in the editor)")]
		[Range(0f, 100f)]
		[SerializeField]
		private float turboHeat;

		[Tooltip("You can set this to determine when the turbo should cease overheating and become operational again")]
		[Range(0f, 100f)]
		[SerializeField]
		private float turboOverheatOver;

		[SerializeField]
		private bool turboOverheat;

		[Header("Sideway force")]
		[Range(0.1f, 15f)]
		[SerializeField]
		private float sidewaysMovement = 15f;

		[Range(0.001f, 0.05f)]
		[SerializeField]
		private float sidewaysMovementXRot = 0.012f;

		[Range(0.1f, 5f)]
		[SerializeField]
		private float sidewaysMovementYRot = 1.5f;

		[Range(-1f, 1f)]
		[SerializeField]
		private float sidewaysMovementYPos = 0.1f;

		[Header("Engine sound settings")]
		[SerializeField]
		private AudioSource engineSoundSource;

		[SerializeField]
		private float maxEngineSound = 1f;

		[SerializeField]
		private float defaultSoundPitch = 1f;

		[SerializeField]
		private float turboSoundPitch = 1.5f;

		[Header("Engine propellers settings")]
		[Range(10f, 10000f)]
		[SerializeField]
		private float propelSpeedMultiplier = 100f;

		[SerializeField]
		private GameObject[] propellers;

		[Header("Turbine light settings")]
		[Range(0.1f, 20f)]
		[SerializeField]
		private float turbineLightDefault = 1f;

		[Range(0.1f, 20f)]
		[SerializeField]
		private float turbineLightTurbo = 5f;

		[SerializeField]
		private Light[] turbineLights;

		[Header("Colliders")]
		[SerializeField]
		private Transform crashCollidersRoot;

		[Header("Takeoff settings")]
		[Tooltip("How far must the plane be from the runway before it can be controlled again")]
		[SerializeField]
		private float takeoffLenght = 30f;

		private void Start()
		{
			maxSpeed = defaultSpeed;
			currentSpeed = defaultSpeed;
			ChangeSpeedMultiplier(1f);
			rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			rb.useGravity = false;
			rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			SetupColliders(crashCollidersRoot);
		}

		private void Update()
		{
			AudioSystem();
			HandleInputs();
			switch (airplaneState)
			{
			case AirplaneState.Flying:
				FlyingUpdate();
				break;
			case AirplaneState.Landing:
				LandingUpdate();
				break;
			case AirplaneState.Takeoff:
				TakeoffUpdate();
				break;
			}
		}

		private void FlyingUpdate()
		{
			UpdatePropellersAndLights();
			if (!planeIsDead)
			{
				Movement();
				SidewaysForceCalculation();
			}
			else
			{
				ChangeWingTrailEffectThickness(0f);
			}
			if (!planeIsDead && HitSometing())
			{
				Crash();
			}
		}

		private void SidewaysForceCalculation()
		{
			float num = sidewaysMovement * sidewaysMovementXRot;
			float num2 = sidewaysMovement * sidewaysMovementYRot;
			float num3 = sidewaysMovement * sidewaysMovementYPos;
			if (base.transform.localEulerAngles.z > 270f && base.transform.localEulerAngles.z < 360f)
			{
				float num4 = (base.transform.localEulerAngles.z - 270f) / 90f;
				float num5 = 1f - num4;
				base.transform.Rotate(Vector3.up * (num5 * num2) * Time.deltaTime);
				base.transform.Rotate(Vector3.right * ((0f - num5) * num) * currentPitchSpeed * Time.deltaTime);
				base.transform.Translate(base.transform.up * (num5 * num3) * Time.deltaTime);
			}
			if (base.transform.localEulerAngles.z > 0f && base.transform.localEulerAngles.z < 90f)
			{
				float num6 = base.transform.localEulerAngles.z / 90f;
				base.transform.Rotate(-Vector3.up * (num6 * num2) * Time.deltaTime);
				base.transform.Rotate(Vector3.right * ((0f - num6) * num) * currentPitchSpeed * Time.deltaTime);
				base.transform.Translate(base.transform.up * (num6 * num3) * Time.deltaTime);
			}
			if (base.transform.localEulerAngles.z > 90f && base.transform.localEulerAngles.z < 180f)
			{
				float num7 = (base.transform.localEulerAngles.z - 90f) / 90f;
				float num8 = 1f - num7;
				base.transform.Translate(base.transform.up * (num8 * num3) * Time.deltaTime);
				base.transform.Rotate(Vector3.right * ((0f - num8) * num) * currentPitchSpeed * Time.deltaTime);
			}
			if (base.transform.localEulerAngles.z > 180f && base.transform.localEulerAngles.z < 270f)
			{
				float num9 = (base.transform.localEulerAngles.z - 180f) / 90f;
				base.transform.Translate(base.transform.up * (num9 * num3) * Time.deltaTime);
				base.transform.Rotate(Vector3.right * ((0f - num9) * num) * currentPitchSpeed * Time.deltaTime);
			}
		}

		private void Movement()
		{
			base.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
			lastEngineSpeed = currentSpeed;
			base.transform.Rotate(Vector3.forward * (0f - inputH) * currentRollSpeed * Time.deltaTime);
			base.transform.Rotate(Vector3.right * inputV * currentPitchSpeed * Time.deltaTime);
			if (inputYawRight)
			{
				base.transform.Rotate(Vector3.up * currentYawSpeed * Time.deltaTime);
			}
			else if (inputYawLeft)
			{
				base.transform.Rotate(-Vector3.up * currentYawSpeed * Time.deltaTime);
			}
			if (currentSpeed < maxSpeed)
			{
				currentSpeed += accelerating * Time.deltaTime;
			}
			else
			{
				currentSpeed -= deaccelerating * Time.deltaTime;
			}
			if (inputTurbo && !turboOverheat)
			{
				if (turboHeat > 100f)
				{
					turboHeat = 100f;
					turboOverheat = true;
				}
				else
				{
					turboHeat += Time.deltaTime * turboHeatingSpeed;
				}
				maxSpeed = turboSpeed;
				currentYawSpeed = yawSpeed * yawTurboMultiplier;
				currentPitchSpeed = pitchSpeed * pitchTurboMultiplier;
				currentRollSpeed = rollSpeed * rollTurboMultiplier;
				currentEngineLightIntensity = turbineLightTurbo;
				ChangeWingTrailEffectThickness(trailThickness);
				currentEngineSoundPitch = turboSoundPitch;
				return;
			}
			if (turboHeat > 0f)
			{
				turboHeat -= Time.deltaTime * turboCooldownSpeed;
			}
			else
			{
				turboHeat = 0f;
			}
			if (turboOverheat && turboHeat <= turboOverheatOver)
			{
				turboOverheat = false;
			}
			maxSpeed = defaultSpeed * speedMultiplier;
			currentYawSpeed = yawSpeed;
			currentPitchSpeed = pitchSpeed;
			currentRollSpeed = rollSpeed;
			currentEngineLightIntensity = turbineLightDefault;
			ChangeWingTrailEffectThickness(0f);
			currentEngineSoundPitch = defaultSoundPitch;
		}

		public void AddLandingRunway(Runway _landingThisRunway)
		{
			currentRunway = _landingThisRunway;
		}

		private void LandingUpdate()
		{
			UpdatePropellersAndLights();
			ChangeWingTrailEffectThickness(0f);
			currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime);
			base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), 2f * Time.deltaTime);
		}

		private void TakeoffUpdate()
		{
			UpdatePropellersAndLights();
			foreach (SimpleAirPlaneCollider airPlaneCollider in airPlaneColliders)
			{
				airPlaneCollider.collideSometing = false;
			}
			if (currentSpeed < turboSpeed)
			{
				currentSpeed += accelerating * 2f * Time.deltaTime;
			}
			base.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
			if (Vector3.Distance(base.transform.position, currentRunway.transform.position) > takeoffLenght)
			{
				currentRunway = null;
				airplaneState = AirplaneState.Flying;
			}
		}

		private void AudioSystem()
		{
			if (engineSoundSource == null)
			{
				return;
			}
			if (airplaneState == AirplaneState.Flying)
			{
				engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, currentEngineSoundPitch, 10f * Time.deltaTime);
				if (planeIsDead)
				{
					engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 10f * Time.deltaTime);
				}
				else
				{
					engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, maxEngineSound, 1f * Time.deltaTime);
				}
			}
			else if (airplaneState == AirplaneState.Landing)
			{
				engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, defaultSoundPitch, 1f * Time.deltaTime);
				engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 1f * Time.deltaTime);
			}
			else if (airplaneState == AirplaneState.Takeoff)
			{
				engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, turboSoundPitch, 1f * Time.deltaTime);
				engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, maxEngineSound, 1f * Time.deltaTime);
			}
		}

		private void UpdatePropellersAndLights()
		{
			if (!planeIsDead)
			{
				if (propellers.Length != 0)
				{
					RotatePropellers(propellers, currentSpeed * propelSpeedMultiplier);
				}
				if (turbineLights.Length != 0)
				{
					ControlEngineLights(turbineLights, currentEngineLightIntensity);
				}
			}
			else
			{
				if (propellers.Length != 0)
				{
					RotatePropellers(propellers, 0f);
				}
				if (turbineLights.Length != 0)
				{
					ControlEngineLights(turbineLights, 0f);
				}
			}
		}

		private void SetupColliders(Transform _root)
		{
			if (!(_root == null))
			{
				Collider[] componentsInChildren = _root.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].isTrigger = true;
					GameObject obj = componentsInChildren[i].gameObject;
					SimpleAirPlaneCollider simpleAirPlaneCollider = obj.AddComponent<SimpleAirPlaneCollider>();
					airPlaneColliders.Add(simpleAirPlaneCollider);
					simpleAirPlaneCollider.controller = this;
					Rigidbody rigidbody = obj.AddComponent<Rigidbody>();
					rigidbody.useGravity = false;
					rigidbody.isKinematic = true;
					rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				}
			}
		}

		private void RotatePropellers(GameObject[] _rotateThese, float _speed)
		{
			for (int i = 0; i < _rotateThese.Length; i++)
			{
				_rotateThese[i].transform.Rotate(Vector3.forward * (0f - _speed) * Time.deltaTime);
			}
		}

		private void ControlEngineLights(Light[] _lights, float _intensity)
		{
			for (int i = 0; i < _lights.Length; i++)
			{
				if (!planeIsDead)
				{
					_lights[i].intensity = Mathf.Lerp(_lights[i].intensity, _intensity, 10f * Time.deltaTime);
				}
				else
				{
					_lights[i].intensity = Mathf.Lerp(_lights[i].intensity, 0f, 10f * Time.deltaTime);
				}
			}
		}

		private void ChangeWingTrailEffectThickness(float _thickness)
		{
			for (int i = 0; i < wingTrailEffects.Length; i++)
			{
				wingTrailEffects[i].startWidth = Mathf.Lerp(wingTrailEffects[i].startWidth, _thickness, Time.deltaTime * 10f);
			}
		}

		private bool HitSometing()
		{
			for (int i = 0; i < airPlaneColliders.Count; i++)
			{
				if (!airPlaneColliders[i].collideSometing)
				{
					continue;
				}
				foreach (SimpleAirPlaneCollider airPlaneCollider in airPlaneColliders)
				{
					airPlaneCollider.collideSometing = false;
				}
				return true;
			}
			return false;
		}

		public virtual void Crash()
		{
			crashAction?.Invoke();
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			rb.AddForce(base.transform.forward * lastEngineSpeed, ForceMode.VelocityChange);
			for (int i = 0; i < airPlaneColliders.Count; i++)
			{
				airPlaneColliders[i].GetComponent<Collider>().isTrigger = false;
				UnityEngine.Object.Destroy(airPlaneColliders[i].GetComponent<Rigidbody>());
			}
			planeIsDead = true;
		}

		public float PercentToMaxSpeed()
		{
			return currentSpeed * speedMultiplier / turboSpeed;
		}

		public bool PlaneIsDead()
		{
			return planeIsDead;
		}

		public bool UsingTurbo()
		{
			if (maxSpeed == turboSpeed)
			{
				return true;
			}
			return false;
		}

		public float CurrentSpeed()
		{
			return currentSpeed * speedMultiplier;
		}

		public float TurboHeatValue()
		{
			return turboHeat;
		}

		public bool TurboOverheating()
		{
			return turboOverheat;
		}

		public void ChangeSpeedMultiplier(float _speedMultiplier)
		{
			if (_speedMultiplier < 0f)
			{
				_speedMultiplier = 0f;
			}
			if (_speedMultiplier > 1f)
			{
				_speedMultiplier = 1f;
			}
			speedMultiplier = _speedMultiplier;
		}

		private void HandleInputs()
		{
			inputH = Input.GetAxis("Horizontal");
			inputV = Input.GetAxis("Vertical");
			inputYawLeft = Input.GetKey(KeyCode.Q);
			inputYawRight = Input.GetKey(KeyCode.E);
			inputTurbo = Input.GetKey(KeyCode.LeftShift);
		}
	}
}
