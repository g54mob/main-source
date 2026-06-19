using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class VehicleController : NetworkEntityBehaviourBase
{
	public struct KickedComp : IEntityStruct, IEntityTyped
	{
		public int frameKicked;
	}

	public enum ControlType
	{
		Standard = 0,
		Simplified = 1
	}

	public struct VehicleInput
	{
		public Vector3 steering;

		public float acceleration;

		public float brake;

		public float drift;
	}

	[Header("Object References")]
	public PlayerAnimation playerAnimation;

	public Rigidbody rb;

	public PlayerEffects playerEffects;

	public BoxCollider playerCrashCollider;

	public PlayerUpgrades playerUpgrades;

	public float reverseVelocityThreshold = 0.1f;

	public float playerCrashSpeedThreshold = 2f;

	[Min(0f)]
	public float playerCrashOutDirChangeDebounce = 1f;

	public float minSteeringInputToDrift = 0.1f;

	public float minDriftSteeringAngleDeg = 15f;

	public float minSpeedToDrift = 1f;

	public float minDriftInputToDrift = 0.1f;

	public float gasPower = 1f;

	public float brakePower = 1f;

	public float maxSpeedForward = 12f;

	public float maxSpeedReverse = 6f;

	public float drag = 0.1f;

	public float coldStorageDrag = 0.75f;

	public float coldStorageDragWithChains = 1f;

	[Header("Handling")]
	public AnimationCurve handlingCurve;

	public AnimationCurve coldStorageHandlingCurve;

	public float turnSpeed = 1f;

	public float driftTurnSpeed = 1f;

	public float driftTurnMultiplier = 0.1f;

	public float driftTurnOutStrength = 1f;

	public float turnTractionRecoverySpeed = 1f;

	public float groundTractionRecoverySpeed = 1f;

	[Header("Simplified Steering")]
	public float gasSteeringMaxDeg = 90f;

	public float reverseSteeringMinDegForward = 145f;

	public float reverseSteeringMinDegReverse = 90f;

	public NitroController nitroController;

	[Header("Kick")]
	public Collider kickCollider;

	public Vector2 kickForce = new Vector2(4f, 10f);

	[Min(0f)]
	public float kickForce2StackHighMultiplier = 2f;

	[Min(0f)]
	public float kickForce3StackHighMultiplier = 2.5f;

	[Min(0f)]
	public float kickForce4StackHighMultiplier = 2.75f;

	[Min(0f)]
	public float kickForceUpwardsModifierDegrees = 25f;

	[Min(0f)]
	public float kickMaxSpeed = 14f;

	[Min(0f)]
	public float kickMaxLookOutAhead = 0.5f;

	[Range(0f, 1f)]
	public float kickVehicleSpeedMultiplier = 0.65f;

	[Range(0f, 1f)]
	public float kickVehicleSpeedSlowsPlayerMultiplier = 0.1f;

	public AnimationCurve kickLookOutAheadCurve = AnimationCurve.Linear(0f, 1f, 0f, 1f);

	public AnimationCurve kickCurve = AnimationCurve.Linear(0f, 1f, 0f, 1f);

	[Min(0f)]
	public float kickDebounce = 0.5f;

	[Min(0f)]
	public float kickForceActivationThreshold = 8f;

	public Vector3 gForce = Vector3.zero;

	private Vector3 _previousVelocity = Vector3.zero;

	private ObjectQuery<VehicleController> vehicleQuery;

	private Transform _kickColliderTransform;

	private ControlType _controlType;

	private Vector3 _lastPosition;

	private static List<Collider> _colliders;

	private static List<ILocalPlayerKicked> _localPlayerKicks;

	private static List<Material> _materials;

	private static readonly int INVERTREVERSE_SETTING_ID;

	public VehicleInput input;

	public Vector2 initialSteerInputDir = Vector2.zero;

	public float travelSign = 1f;

	public float driftSign = 1f;

	public bool drifting;

	public bool wasDrifting;

	[SyncVar]
	public bool trailsEnabled;

	public float turnTraction = 1f;

	public float groundTraction = 1f;

	public bool coldStorage;

	[Header("Visuals")]
	public GameObject collisionParticles;

	public ParticleSystem crashoutVfx;

	public TrailRenderer[] trailRenderers;

	public ParticleSystem[] driftParticles;

	public Material skidMaterial;

	public Material skidMaterialIce;

	[Header("Audio")]
	public EventReference engineRef;

	public EventReference engineUpgradedRef;

	public EventReference skrrNoiseRef;

	public EventReference skrrNoiseIceRef;

	[SyncVar]
	public bool syncReversing;

	public StudioEventEmitter reversingSfxEmitter;

	private bool _crashingOut;

	public float crashoutMaxSpeed = 17f;

	public float crashoutTurnSpeed = 200f;

	public Vector2 crashoutRandomDirTimeRangeSec = Vector2.zero;

	public float crashoutCoworkerVisionRange = 30f;

	private float _crashoutRandomDirTimer;

	private Vector3 _crashoutRandomDir = Vector3.zero;

	private bool _crashoutForward;

	private Timer _crashoutDirChangeTimer;

	[SyncVar]
	public bool slippingOutSync;

	private float _slippingTimer;

	public float minSlippingTimeSeconds = 0.5f;

	public float minSlipoutExitVelocity = 0.75f;

	public float slipOutDrag = 0.5f;

	public float slipOutTurnSpeed = 300f;

	public StudioEventEmitter slipOutSFX;

	[SyncVar]
	public Vector3 velocitySync = Vector3.zero;

	public Vector3 previousFoward = Vector3.forward;

	public float timeAtLastCollision;

	private EventInstance engineInstance;

	private EventInstance engineUpgradedInstance;

	private EventInstance skrrNoiseInstance;

	private EventInstance skrrNoiseIceInstance;

	public float distanceDrifted { get; private set; }

	public bool NetworktrailsEnabled
	{
		get
		{
			return trailsEnabled;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref trailsEnabled, 1uL, null);
		}
	}

	public bool NetworksyncReversing
	{
		get
		{
			return syncReversing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncReversing, 2uL, null);
		}
	}

	public bool NetworkslippingOutSync
	{
		get
		{
			return slippingOutSync;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref slippingOutSync, 4uL, null);
		}
	}

	public Vector3 NetworkvelocitySync
	{
		get
		{
			return velocitySync;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref velocitySync, 8uL, null);
		}
	}

	public Vector3 GetSteeringInput()
	{
		Vector2 vector = AggroInputManager.input.Game.Steering.ReadValue<Vector2>();
		if (vector.magnitude > 0.1f)
		{
			switch (_controlType)
			{
			case ControlType.Standard:
				if (vector.x == 0f)
				{
					return base.transform.forward;
				}
				return base.transform.right * vector.x;
			case ControlType.Simplified:
				return new Vector3(vector.x, 0f, vector.y).normalized * vector.magnitude;
			}
		}
		return base.transform.forward;
	}

	public float GetTurnDirForVisual()
	{
		Vector2 vector = AggroInputManager.input.Game.Steering.ReadValue<Vector2>();
		if (vector.magnitude > 0.1f)
		{
			switch (_controlType)
			{
			case ControlType.Standard:
				return vector.x;
			case ControlType.Simplified:
			{
				Vector3 normalized = new Vector3(vector.x, 0f, vector.y).normalized;
				float num = Mathf.Sign(Vector3.SignedAngle(base.transform.forward, normalized, Vector3.up));
				return (1f - Vector3.Dot(base.transform.forward, normalized)) * num;
			}
			}
		}
		return 0f;
	}

	private float GetAccelerationInput()
	{
		Vector2 vector = AggroInputManager.input.Game.Steering.ReadValue<Vector2>();
		Vector3 vector2 = new Vector3(vector.x, 0f, vector.y);
		float num = 0f;
		float num2 = 0f;
		switch (_controlType)
		{
		case ControlType.Standard:
			num2 = Mathf.Clamp01(vector.y);
			if (rb.velocity.magnitude * travelSign < reverseVelocityThreshold)
			{
				num = 0f - AggroInputManager.input.Game.Brake.ReadValue<float>();
			}
			if (Mathf.Abs(num) > 0f || vector.magnitude < 0.15f)
			{
				num2 = 0f;
			}
			return num2 + num;
		case ControlType.Simplified:
		{
			if (rb.velocity.magnitude * travelSign < reverseVelocityThreshold)
			{
				num = 0f - AggroInputManager.input.Game.Brake.ReadValue<float>();
			}
			float f = Vector3.SignedAngle(vector2, base.transform.forward, Vector3.up);
			float num3 = gasSteeringMaxDeg;
			if (Mathf.Abs(f) < num3)
			{
				num2 = vector.magnitude;
			}
			if (Mathf.Abs(num) > 0f || vector.magnitude < 0.15f)
			{
				num2 = 0f;
			}
			return num2 + num;
		}
		default:
			return 0f;
		}
	}

	private float GetBrakeInput()
	{
		float result = 0f;
		switch (_controlType)
		{
		case ControlType.Standard:
			if (rb.velocity.magnitude * travelSign > reverseVelocityThreshold)
			{
				result = AggroInputManager.input.Game.Brake.ReadValue<float>();
			}
			return result;
		case ControlType.Simplified:
			if (rb.velocity.magnitude * travelSign > reverseVelocityThreshold)
			{
				result = AggroInputManager.input.Game.Brake.ReadValue<float>();
			}
			return result;
		default:
			return 0f;
		}
	}

	private float GetDriftInput()
	{
		float num = 0f;
		num = AggroInputManager.input.Game.Drift.ReadValue<float>();
		if (_crashingOut || slippingOutSync || AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
		{
			num = 0f;
		}
		return num;
	}

	private bool CheckForDrifting()
	{
		bool flag = AggroInputManager.input.Game.Steering.ReadValue<Vector2>().magnitude > minSteeringInputToDrift;
		bool flag2 = rb.velocity.magnitude > minSpeedToDrift;
		bool flag3 = input.drift > minDriftInputToDrift;
		bool flag4 = travelSign > 0f;
		bool flag5 = Vector3.Angle(input.steering, base.transform.forward) > minDriftSteeringAngleDeg;
		if (coldStorage)
		{
			if ((flag3 && drifting && flag2) || (flag4 && flag2 && flag3 && flag5))
			{
				return true;
			}
		}
		else if ((flag4 && flag2 && flag3 && drifting) || (flag5 && flag4 && flag2 && flag3 && flag))
		{
			return true;
		}
		return false;
	}

	private float GetCrashoutAcceleration()
	{
		if (_crashoutForward)
		{
			return 1f;
		}
		return -1f;
	}

	private Vector3 GetCrashoutSteering()
	{
		if (!_crashingOut || base.entity.GetObject<NitroController>().nitroActiveSync)
		{
			return base.transform.forward;
		}
		List<VehicleController> list = new List<VehicleController>();
		vehicleQuery.Run();
		foreach (VehicleController item in vehicleQuery)
		{
			if (!item.GetComponent<PlayerStress>().crashingOut)
			{
				list.Add(item);
			}
		}
		if (_crashoutRandomDirTimer <= 0f)
		{
			_crashoutRandomDirTimer = UnityEngine.Random.Range(crashoutRandomDirTimeRangeSec.x, crashoutRandomDirTimeRangeSec.y);
			Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
			_crashoutRandomDir = new Vector3(normalized.x, 0f, normalized.y);
		}
		_crashoutRandomDirTimer -= Time.deltaTime;
		if (list.Count > 0)
		{
			VehicleController vehicleController = null;
			float num = float.PositiveInfinity;
			foreach (VehicleController item2 in list)
			{
				if (!(item2 == this))
				{
					float num2 = Vector3.Distance(item2.rb.position, rb.position);
					if (num2 < num)
					{
						num = num2;
						vehicleController = item2;
					}
				}
			}
			Vector3 vector = ((!(vehicleController != null)) ? base.transform.forward : (vehicleController.rb.position - rb.position).normalized);
			if ((double)Vector3.Dot(base.transform.forward, vector) > 0.0 && num < crashoutCoworkerVisionRange)
			{
				return Vector3.Lerp(base.transform.forward, vector, 1.5f * Time.deltaTime);
			}
			return _crashoutRandomDir;
		}
		return _crashoutRandomDir;
	}

	private float SetTurnTraction()
	{
		if (drifting || slippingOutSync)
		{
			turnTraction = 0f;
		}
		else
		{
			turnTraction += turnTractionRecoverySpeed * Time.deltaTime;
			turnTraction = Mathf.Clamp01(turnTraction);
		}
		return turnTraction;
	}

	private float GetGroundTraction()
	{
		if (slippingOutSync)
		{
			return 0f;
		}
		if (coldStorage)
		{
			return 0.2f;
		}
		return Mathf.Lerp(groundTraction, 1f, groundTractionRecoverySpeed * Time.deltaTime);
	}

	private void OnDriftStart()
	{
		float num = Vector3.SignedAngle(input.steering, base.transform.forward, Vector3.up);
		driftSign = ((num <= 0f) ? 1f : (-1f));
	}

	private void OnDriftStop()
	{
	}

	private void ApplySteering()
	{
		bool value = AggroSettings.GetSetting<ToggleSetting>(INVERTREVERSE_SETTING_ID).value;
		if (slippingOutSync)
		{
			Quaternion to = Quaternion.LookRotation(base.transform.right, base.transform.up);
			Quaternion rotation = Quaternion.RotateTowards(rb.rotation, to, slipOutTurnSpeed * rb.velocity.magnitude * Time.deltaTime);
			rb.rotation = rotation;
			return;
		}
		float num = 1f;
		num = ((!coldStorage) ? handlingCurve.Evaluate(rb.velocity.magnitude / maxSpeedForward) : coldStorageHandlingCurve.Evaluate(rb.velocity.magnitude / maxSpeedForward));
		float num2 = Vector3.SignedAngle(input.steering.normalized, base.transform.forward, Vector3.up);
		float num3 = Vector3.SignedAngle(input.steering.normalized, -base.transform.forward, Vector3.up);
		float num4 = 0f;
		Quaternion quaternion2 = quaternion.identity;
		Quaternion a = quaternion.identity;
		if (drifting && !_crashingOut)
		{
			float num5 = (coldStorage ? (driftTurnSpeed * 1f) : driftTurnSpeed);
			switch (_controlType)
			{
			case ControlType.Standard:
				num4 = (num5 - Mathf.Sign(num2) * driftSign * input.steering.magnitude * num5 * driftTurnMultiplier) * Time.fixedDeltaTime;
				quaternion2 = Quaternion.LookRotation(base.transform.right * driftSign, base.transform.up);
				a = Quaternion.RotateTowards(rb.rotation, quaternion2, num4);
				break;
			case ControlType.Simplified:
			{
				float value2 = Vector3.Dot(input.steering.normalized, base.transform.forward);
				value2 = Mathf.Clamp01(value2) * 2f - 1f;
				num4 = (num5 - value2 * num5 * driftTurnMultiplier) * Time.fixedDeltaTime;
				quaternion2 = Quaternion.LookRotation(base.transform.right * driftSign, base.transform.up);
				a = Quaternion.RotateTowards(rb.rotation, quaternion2, num4);
				break;
			}
			}
		}
		else
		{
			Quaternion to2 = Quaternion.LookRotation((driftSign > 0f) ? base.transform.right : (-base.transform.right));
			num4 = driftTurnOutStrength * Time.fixedDeltaTime;
			a = Quaternion.RotateTowards(rb.rotation, to2, num4);
		}
		float num6 = 0f;
		Quaternion identity = Quaternion.identity;
		Quaternion b = Quaternion.identity;
		switch (_controlType)
		{
		case ControlType.Standard:
			identity = Quaternion.LookRotation(input.steering.normalized, Vector3.up);
			num6 = turnSpeed * input.steering.magnitude * num * Time.deltaTime;
			if (input.acceleration < 0f && value)
			{
				num6 *= -1f;
			}
			b = Quaternion.RotateTowards(rb.rotation, identity, num6 * num);
			break;
		case ControlType.Simplified:
		{
			if (!(travelSign > 0f))
			{
				_ = reverseSteeringMinDegReverse;
			}
			else
			{
				_ = reverseSteeringMinDegForward;
			}
			float num7 = ((!value) ? ((input.acceleration >= 0f) ? 1f : (-1f)) : 1f);
			num6 = ((!coldStorage) ? (num7 * Mathf.Min(Mathf.Abs((num7 >= 0f) ? num2 : num3), turnSpeed * num * Time.deltaTime)) : (turnSpeed * Time.deltaTime));
			b = ((!(input.steering.normalized != Vector3.zero)) ? Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(base.transform.forward, Vector3.up), num6 * num) : Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(input.steering.normalized, Vector3.up), num6 * num));
			break;
		}
		}
		Quaternion quaternion3 = quaternion.identity;
		if (_crashingOut)
		{
			Vector3 crashoutSteering = GetCrashoutSteering();
			float maxDegreesDelta = crashoutTurnSpeed * Time.deltaTime;
			quaternion3 = Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(crashoutSteering.normalized, Vector3.up), maxDegreesDelta);
		}
		Quaternion quaternion4 = Quaternion.Slerp(a, b, turnTraction);
		rb.rotation = PhysicsUtil.ConstrainUpRight(_crashingOut ? quaternion3 : quaternion4);
		previousFoward = base.transform.forward;
	}

	private void ApplyAcceleration()
	{
		Vector3 b = rb.velocity.magnitude * travelSign * base.transform.forward;
		if (!coldStorage)
		{
			rb.velocity = Vector3.Lerp(rb.velocity, b, groundTraction);
		}
		float num = 0f;
		if (nitroController.nitroActiveSync)
		{
			num = nitroController.nitroPower * Time.deltaTime;
		}
		else
		{
			if (drifting)
			{
				input.acceleration = Mathf.Clamp(input.acceleration, 0.3f, 1f);
			}
			num = input.acceleration * gasPower * Time.deltaTime;
		}
		if (!drifting)
		{
			num *= 1f - input.brake;
		}
		if (_crashingOut)
		{
			num = GetCrashoutAcceleration();
		}
		float vehicleSpeedMultiplier = playerEffects.GetVehicleSpeedMultiplier();
		num *= vehicleSpeedMultiplier;
		if (coldStorage)
		{
			float num2 = (nitroController.nitroActiveSync ? nitroController.maxNitroSpeed : maxSpeedForward);
			num2 *= vehicleSpeedMultiplier;
			if (_crashingOut)
			{
				num2 = crashoutMaxSpeed;
			}
			if (rb.velocity.magnitude < num2 && !slippingOutSync)
			{
				rb.velocity += num * 1f * base.transform.forward;
			}
			bool flag = playerUpgrades.HasUpgrade(PlayerUpgrade.Traction);
			rb.velocity *= 1f - (drifting ? ((flag ? coldStorageDragWithChains : coldStorageDrag) * 1.2f) : (flag ? coldStorageDragWithChains : coldStorageDrag)) * Time.deltaTime;
			UpdateKickForce();
			return;
		}
		if (!slippingOutSync)
		{
			if (nitroController.nitroActiveSync)
			{
				vehicleSpeedMultiplier = math.max(1f, vehicleSpeedMultiplier);
				float num3 = ((travelSign > 0f) ? nitroController.maxNitroSpeed : maxSpeedReverse);
				num3 *= vehicleSpeedMultiplier;
				if (_crashingOut)
				{
					num3 = crashoutMaxSpeed;
				}
				if (rb.velocity.magnitude < num3)
				{
					rb.velocity += num * base.transform.forward;
				}
				else
				{
					rb.velocity *= 1f - drag * Time.deltaTime;
				}
			}
			else
			{
				float num4 = ((travelSign > 0f) ? maxSpeedForward : maxSpeedReverse);
				num4 *= vehicleSpeedMultiplier;
				if (drifting)
				{
					num4 *= 1.2f;
				}
				if (_crashingOut)
				{
					num4 = crashoutMaxSpeed;
				}
				if (rb.velocity.magnitude < num4 && Mathf.Abs(num) > 0f)
				{
					rb.velocity += num * base.transform.forward;
				}
				else
				{
					rb.velocity *= 1f - drag * Time.deltaTime;
				}
			}
			if (rb.velocity.magnitude < 0.3f && input.brake == 0f && input.acceleration == 0f)
			{
				rb.velocity = Vector3.zero;
			}
		}
		else
		{
			rb.velocity *= 1f - slipOutDrag * Time.deltaTime;
		}
		UpdateKickForce();
	}

	private void ApplyBrake()
	{
		if (!slippingOutSync)
		{
			rb.velocity -= rb.velocity.normalized * (input.brake * brakePower * Time.deltaTime);
		}
	}

	protected override void OnUpdatePresentation()
	{
		_materials.Clear();
		TrailRenderer[] array = trailRenderers;
		foreach (TrailRenderer obj in array)
		{
			_materials.Add(coldStorage ? skidMaterialIce : skidMaterial);
			obj.emitting = trailsEnabled;
			obj.SetMaterials(_materials);
		}
		ParticleSystem[] array2 = driftParticles;
		for (int i = 0; i < array2.Length; i++)
		{
			ParticleSystem.EmissionModule emission = array2[i].emission;
			emission.enabled = trailsEnabled;
		}
		if (trailsEnabled)
		{
			AudioManager.CheckSetPlayState(skrrNoiseInstance, !coldStorage);
			AudioManager.CheckSetPlayState(skrrNoiseIceInstance, coldStorage);
		}
		else
		{
			AudioManager.CheckStop(skrrNoiseInstance);
			AudioManager.CheckStop(skrrNoiseIceInstance);
		}
		AudioManager.CheckSetPlayState(engineInstance, !playerUpgrades.HasUpgrade(PlayerUpgrade.SpeedUp));
		AudioManager.CheckSetPlayState(engineUpgradedInstance, playerUpgrades.HasUpgrade(PlayerUpgrade.SpeedUp));
		engineInstance.setParameterByName("speed", math.saturate(velocitySync.magnitude / maxSpeedForward));
		engineUpgradedInstance.setParameterByName("speed", math.saturate(velocitySync.magnitude / maxSpeedForward));
		int num = 0;
		switch (base.entity.GetObject<PlayerEffects>().activeLiquidTrailEffect)
		{
		case AoEEffects.LiquidTrailEffect.Oil:
			num = 2;
			break;
		case AoEEffects.LiquidTrailEffect.Water:
			num = 1;
			break;
		case AoEEffects.LiquidTrailEffect.Ooze:
			num = 3;
			break;
		}
		skrrNoiseInstance.setParameterByName("skree", num);
		AudioManager.CheckSet3DAttributes(engineInstance, base.entity.transform, velocitySync);
		AudioManager.CheckSet3DAttributes(engineUpgradedInstance, base.entity.transform, velocitySync);
		AudioManager.CheckSet3DAttributes(skrrNoiseInstance, base.entity.transform, velocitySync);
		AudioManager.CheckSet3DAttributes(skrrNoiseIceInstance, base.entity.transform, velocitySync);
		if (syncReversing)
		{
			reversingSfxEmitter.EventInstance.getPlaybackState(out var state);
			if (state != PLAYBACK_STATE.PLAYING)
			{
				reversingSfxEmitter.Play();
			}
		}
		else
		{
			reversingSfxEmitter.Stop();
		}
		if (base.isLocalPlayer)
		{
			NetworksyncReversing = travelSign < 0f && AggroInputManager.input.Game.Brake.ReadValue<float>() > 0.1f;
			switch (AggroInputManager.mode)
			{
			case InputMode.Gamepad:
				_controlType = ControlType.Simplified;
				break;
			case InputMode.KBM:
				_controlType = ControlType.Standard;
				break;
			}
			input.steering = GetSteeringInput();
			input.acceleration = GetAccelerationInput();
			input.brake = GetBrakeInput();
			input.drift = GetDriftInput();
			NetworktrailsEnabled = drifting || (Mathf.Abs(input.acceleration) > 0.1f && input.brake > 0.1f) || slippingOutSync;
		}
	}

	protected override void OnEntityCreated()
	{
		_kickColliderTransform = kickCollider.transform;
		vehicleQuery = base.entityManager.CreateObjectQuery<VehicleController>();
		input.steering = base.transform.forward;
		engineInstance = RuntimeManager.CreateInstance(engineRef);
		engineUpgradedInstance = RuntimeManager.CreateInstance(engineUpgradedRef);
		skrrNoiseInstance = RuntimeManager.CreateInstance(skrrNoiseRef);
		skrrNoiseIceInstance = RuntimeManager.CreateInstance(skrrNoiseIceRef);
		AudioManager.CheckResult(engineInstance.setParameterByName("doppler", 1f));
		AudioManager.CheckResult(engineUpgradedInstance.setParameterByName("doppler", 1f));
		AudioManager.CheckResult(skrrNoiseInstance.setParameterByName("doppler", 1f));
		AudioManager.CheckResult(skrrNoiseIceInstance.setParameterByName("doppler", 1f));
	}

	protected override void OnEntityDestroyed()
	{
		AudioManager.CheckStop(engineInstance);
		AudioManager.CheckStop(engineUpgradedInstance);
		AudioManager.CheckStop(skrrNoiseInstance);
		AudioManager.CheckStop(skrrNoiseIceInstance);
		engineInstance.release();
		engineUpgradedInstance.release();
		skrrNoiseInstance.release();
		skrrNoiseIceInstance.release();
	}

	public override void OnStartLocalPlayer()
	{
		AudioManager.CheckResult(engineInstance.setParameterByName("doppler", 0f));
		AudioManager.CheckResult(engineUpgradedInstance.setParameterByName("doppler", 0f));
		AudioManager.CheckResult(skrrNoiseInstance.setParameterByName("doppler", 0f));
		AudioManager.CheckResult(skrrNoiseIceInstance.setParameterByName("doppler", 0f));
	}

	protected override void OnUpdateSimulationEarly()
	{
		coldStorage = NetworkAggroManagerBase<ModifierManager>.ManagerExists() && NetworkAggroManagerBase<ModifierManager>.instance.HasFlags(ModifierFlags.Icy);
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (slippingOutSync)
		{
			if (_slippingTimer < 0f && rb.velocity.magnitude < minSlipoutExitVelocity)
			{
				NetworkslippingOutSync = false;
			}
		}
		else if (NetworkslippingOutSync = _slippingTimer > 0f)
		{
			NetworkslippingOutSync = true;
		}
		_slippingTimer -= Time.deltaTime;
		travelSign = (((double)Vector3.Dot(base.transform.forward, rb.velocity.normalized) >= 0.0) ? 1f : (-1f));
		drifting = CheckForDrifting();
		turnTraction = SetTurnTraction();
		groundTraction = GetGroundTraction();
		_previousVelocity = rb.velocity;
		if (drifting && !wasDrifting)
		{
			OnDriftStart();
		}
		if (!drifting && wasDrifting)
		{
			OnDriftStop();
		}
		_crashoutDirChangeTimer.DecrementTimer();
		ApplySteering();
		ApplyAcceleration();
		ApplyBrake();
		Vector3 movingSideWalkVelocity = BeltUtil.GetMovingSideWalkVelocity(rb.position);
		if (movingSideWalkVelocity.sqrMagnitude > 0f)
		{
			rb.MovePosition(rb.position + movingSideWalkVelocity * Time.fixedDeltaTime);
		}
		Vector3 velocity = rb.velocity;
		velocity.y = 0f;
		rb.velocity = velocity;
		NetworkvelocitySync = velocity;
		wasDrifting = drifting;
		gForce = rb.velocity - _previousVelocity;
		_lastPosition = rb.position;
	}

	protected override void OnUpdateSimulationLate()
	{
		if (base.isLocalPlayer && drifting)
		{
			float magnitude = (rb.position - _lastPosition).magnitude;
			distanceDrifted += magnitude;
			Aggro.Core.Platform.AddStat("stat_drift_distance", magnitude);
		}
	}

	private void UpdateKickForce()
	{
		float magnitude = base.entity.rigidbody.velocity.magnitude;
		Vector3 vector = Vector3.zero;
		if (magnitude > 0f)
		{
			vector = base.entity.rigidbody.velocity / magnitude;
		}
		float time = math.saturate(math.unlerp(0f, kickMaxSpeed, magnitude));
		float num = kickLookOutAheadCurve.Evaluate(time);
		Vector3 vector2 = base.entity.rigidbody.position + vector * (num * kickMaxLookOutAhead);
		_kickColliderTransform.position = vector2;
		int num2 = TimeUtil.FramesForTime(kickDebounce);
		bool flag = false;
		bool flag2 = false;
		_colliders.Clear();
		PhysicsUtil.OverlapCollider(kickCollider, _kickColliderTransform, _colliders, 16384);
		for (int i = 0; i < _colliders.Count; i++)
		{
			Collider collider = _colliders[i];
			if (!collider.TryGetEntity(out var e))
			{
				continue;
			}
			Rigidbody rigidbody = e.rigidbody;
			if ((e.TryGetStruct<KickedComp>(out var comp) && TimeUtil.frame - comp.frameKicked < num2) || rigidbody.isKinematic || (e.TryGetObject<Grabbable>(out var obj) && obj.syncHeldInHolder))
			{
				continue;
			}
			Vector3 velocity = rigidbody.velocity;
			if (!(math.dot(vector, velocity) < 0f) && !(Vector3.Project(velocity, vector).sqrMagnitude < magnitude * magnitude))
			{
				continue;
			}
			comp.frameKicked = TimeUtil.frame;
			e.SetOrAddStruct(comp);
			float num3 = math.lerp(kickForce.x, kickForce.y, kickCurve.Evaluate(time));
			if (num3 >= kickForceActivationThreshold && e.TryGetObject<BoxActivator>(out var obj2))
			{
				ActivationContext context = new ActivationContext
				{
					type = ActivationContextType.Kicked,
					causer = base.entity
				};
				obj2.RequestActivate(context);
				_localPlayerKicks.Clear();
				e.GetObjects(_localPlayerKicks);
				for (int j = 0; j < _localPlayerKicks.Count; j++)
				{
					_localPlayerKicks[j].OnLocalPlayerKicked(base.entity);
				}
			}
			Vector3 normalized = (e.rigidbody.position - vector2).normalized;
			normalized = Quaternion.AngleAxis(kickForceUpwardsModifierDegrees, MathUtil.GetOrtho(normalized, Vector3.up)) * normalized;
			normalized *= num3;
			if (e.TryGetObject<Grabbable>(out obj) && obj.isInStack)
			{
				switch (obj.GetStackCount())
				{
				case 2:
					normalized *= kickForce2StackHighMultiplier;
					break;
				case 3:
					normalized *= kickForce3StackHighMultiplier;
					break;
				case 4:
					normalized *= kickForce4StackHighMultiplier;
					break;
				default:
					Debug.LogError($"Unexpected stack count! ({obj.GetStackCount()})", obj);
					break;
				case 1:
					break;
				}
			}
			Vector3 position = collider.ClosestPoint(vector2);
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.AddForceAtPosition(normalized, position, ForceMode.Impulse);
			if (!base.isServer)
			{
				CmdAddKickForce(e, normalized, position);
			}
			flag = true;
			if (e.tags.Has(CCTags.TAG_SLOWSPLAYER))
			{
				flag2 = true;
			}
		}
		if (flag)
		{
			if (flag2)
			{
				rb.velocity = vector * (magnitude * kickVehicleSpeedSlowsPlayerMultiplier);
			}
			else
			{
				rb.velocity = vector * (magnitude * kickVehicleSpeedMultiplier);
			}
		}
	}

	[Command]
	private void CmdAddKickForce(Entity e, Vector3 force, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		writer.WriteVector3(force);
		writer.WriteVector3(position);
		SendCommandInternal("System.Void VehicleController::CmdAddKickForce(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3)", -659471789, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	public void RpcTakeForce(Vector3 force)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(force);
		SendTargetRPCInternal(null, "System.Void VehicleController::RpcTakeForce(UnityEngine.Vector3)", 1819876373, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcSlipOut(bool isBananaSlip)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(isBananaSlip);
		SendTargetRPCInternal(null, "System.Void VehicleController::RpcSlipOut(System.Boolean)", -207672871, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void RequestSlipOut(bool isBananaSlip)
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerSlipOut(isBananaSlip);
		}
		else
		{
			RpcSlipOut(isBananaSlip);
		}
	}

	public void LocalPlayerSlipOut(bool isBananaSlip)
	{
		_slippingTimer = minSlippingTimeSeconds;
		NetworkslippingOutSync = true;
		playerAnimation.PlaySlipOut();
		slipOutSFX.Play();
		base.entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
		if (isBananaSlip)
		{
			Aggro.Core.Platform.AddStat("stat_banana_slips", 1);
		}
	}

	public void LocalPlayerTakeForce(Vector3 force)
	{
		force.y = 0f;
		float num = Vector3.Dot(base.transform.forward, force.normalized);
		if (MathF.Abs(num) > 0.8f)
		{
			base.transform.rotation = Quaternion.LookRotation(force.normalized * ((num > 0f) ? 1f : (-1f)), Vector3.up);
		}
		rb.velocity += force;
		groundTraction = 0f;
	}

	public void CrashingOut()
	{
		_crashingOut = true;
		_crashoutDirChangeTimer.SetTimer(playerCrashOutDirChangeDebounce);
		_crashoutForward = true;
	}

	public void CrashingOutFinished()
	{
		_crashingOut = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!base.isLocalPlayer || !_crashoutDirChangeTimer.IsFinished())
		{
			return;
		}
		Vector3 forward = base.entity.transform.forward;
		if (_crashoutForward)
		{
			if (Vector3.Dot(forward, collision.impulse) < 0f)
			{
				_crashoutDirChangeTimer.SetTimer(playerCrashOutDirChangeDebounce);
				_crashoutForward = false;
			}
		}
		else if (Vector3.Dot(forward, collision.impulse) > 0f)
		{
			_crashoutDirChangeTimer.SetTimer(playerCrashOutDirChangeDebounce);
			_crashoutForward = true;
		}
	}

	static VehicleController()
	{
		_colliders = new List<Collider>();
		_localPlayerKicks = new List<ILocalPlayerKicked>();
		_materials = new List<Material>();
		INVERTREVERSE_SETTING_ID = AggroSettings.IdToHash("game-invertReverse");
		RemoteProcedureCalls.RegisterCommand(typeof(VehicleController), "System.Void VehicleController::CmdAddKickForce(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CmdAddKickForce__Entity__Vector3__Vector3, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(VehicleController), "System.Void VehicleController::RpcTakeForce(UnityEngine.Vector3)", InvokeUserCode_RpcTakeForce__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(VehicleController), "System.Void VehicleController::RpcSlipOut(System.Boolean)", InvokeUserCode_RpcSlipOut__Boolean);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddKickForce__Entity__Vector3__Vector3(Entity e, Vector3 force, Vector3 position)
	{
		if (e.Exists() && !e.rigidbody.isKinematic)
		{
			e.rigidbody.velocity = Vector3.zero;
			e.rigidbody.angularVelocity = Vector3.zero;
			e.rigidbody.AddForceAtPosition(force, position, ForceMode.Impulse);
		}
	}

	protected static void InvokeUserCode_CmdAddKickForce__Entity__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddKickForce called on client.");
		}
		else
		{
			((VehicleController)obj).UserCode_CmdAddKickForce__Entity__Vector3__Vector3(reader.ReadEntity(), reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcTakeForce__Vector3(Vector3 force)
	{
		LocalPlayerTakeForce(force);
	}

	protected static void InvokeUserCode_RpcTakeForce__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcTakeForce called on server.");
		}
		else
		{
			((VehicleController)obj).UserCode_RpcTakeForce__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_RpcSlipOut__Boolean(bool isBananaSlip)
	{
		LocalPlayerSlipOut(isBananaSlip);
	}

	protected static void InvokeUserCode_RpcSlipOut__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcSlipOut called on server.");
		}
		else
		{
			((VehicleController)obj).UserCode_RpcSlipOut__Boolean(reader.ReadBool());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(trailsEnabled);
			writer.WriteBool(syncReversing);
			writer.WriteBool(slippingOutSync);
			writer.WriteVector3(velocitySync);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(trailsEnabled);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(syncReversing);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(slippingOutSync);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVector3(velocitySync);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref trailsEnabled, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncReversing, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref slippingOutSync, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref velocitySync, null, reader.ReadVector3());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref trailsEnabled, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncReversing, null, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref slippingOutSync, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref velocitySync, null, reader.ReadVector3());
		}
	}
}
