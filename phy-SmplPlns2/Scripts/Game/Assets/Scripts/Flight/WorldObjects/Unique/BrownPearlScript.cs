using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.WorldObjects.Combat;
using Assets.Scripts.Flight.WorldObjects.Combat.Targets;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Sea;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique
{
	public class BrownPearlScript : MonoBehaviour
	{
		[SerializeField]
		private float _canonAccuracy = 1f;

		[SerializeField]
		private float _canonFireMaxDelay = 10f;

		[SerializeField]
		private float _canonFireMinDelay = 2f;

		private int _canonIndex;

		[SerializeField]
		private float _canonMaxSpeed = 500f;

		[SerializeField]
		private float _canonMaxTurningPerSecondDeg = 45f;

		private AntiAircraftPlaceholderMissileScript[] _canons;

		private float _fireTimer = 10f;

		[SerializeField]
		private float _maxTurnAngle = 60f;

		private float _startHeading;

		private float _time;

		[SerializeField]
		private float _topSpeed = 7f;

		private TrackedTarget _trackedTarget;

		[SerializeField]
		private float _turnRate = 1f;

		[SerializeField]
		private ParticleSystem _waterTrail;

		private float _waterTrailDefaultEmissionRate;

		private ParticleSystem.EmissionModule _waterTrailEmission;

		private ParticleSystem.MainModule _waterTrailMain;

		public bool IsDisabled { get; private set; }

		public bool IsSinkable => SinkableShip != null;

		public Transform OrphanedParticleEffectsParent { get; private set; }

		public Target PlayerTarget { get; private set; }

		public SinkableShipScript SinkableShip { get; protected set; }

		protected Rigidbody RigidBody { get; set; }

		protected float TopSpeed => _topSpeed;

		protected ParticleSystem WaterTrail => _waterTrail;

		protected static int GetAircraftTargetIndex(List<EnemyWeaponTarget> targets, AircraftScript aircraft)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				if (targets[i].Aircraft == aircraft)
				{
					return i;
				}
			}
			return -1;
		}

		protected virtual void Awake()
		{
			RigidBody = GetComponent<Rigidbody>();
			SinkableShip = GetComponent<SinkableShipScript>();
			_waterTrailEmission = WaterTrail.emission;
			_waterTrailMain = WaterTrail.main;
		}

		protected virtual void DamageThresholdReached(object sender, DamageLevelEventArgs e)
		{
			if (e.NewLevel.Level >= 4 && !IsDisabled)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("You have defeated the Brown Pearl!");
				IsDisabled = true;
			}
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript.Instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
		}

		protected virtual void Start()
		{
			FlightSceneScript.Instance.FlightUI.ShowMessage("Ye have made a grave mistake!");
			_waterTrailDefaultEmissionRate = _waterTrailEmission.rateOverTime.constantMax;
			RigidBody.linearVelocity = base.transform.forward * TopSpeed;
			if (SinkableShip != null)
			{
				SinkableShip.DamageReceiver.DamageLevelChanged += DamageThresholdReached;
			}
			OrphanedParticleEffectsParent = new GameObject("OrphanedParticleEffects").transform;
			OrphanedParticleEffectsParent.SetParent(base.transform, worldPositionStays: false);
			_canons = GetComponentsInChildren<AntiAircraftPlaceholderMissileScript>(includeInactive: true);
			_startHeading = base.transform.rotation.eulerAngles.y;
			FlightSceneScript.Instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
			FlightSceneScript.Instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
		}

		protected virtual void Update()
		{
			if (PauseManager.Paused)
			{
				return;
			}
			Vector3 linearVelocity = RigidBody.linearVelocity;
			Vector3 v = linearVelocity;
			float? y = 0f;
			float magnitude = v.Copy(null, y).magnitude;
			if (!IsSinkable || !SinkableShip.Sinking)
			{
				if (!IsDisabled)
				{
					_time += Time.deltaTime;
					float y2 = _startHeading + Mathf.Sin(_time * _turnRate) * _maxTurnAngle;
					base.transform.rotation = Quaternion.Euler(0f, y2, 0f);
				}
				Rigidbody rigidBody = RigidBody;
				Vector3 v2 = base.transform.forward * magnitude;
				y = linearVelocity.y;
				rigidBody.linearVelocity = v2.Copy(null, y);
			}
			UpdateWaterTrail(magnitude);
			float magnitude2 = (base.transform.position - PlayerTarget.Position).magnitude;
			if (!IsDisabled && PlayerTarget != null && magnitude2 < 10000f)
			{
				_fireTimer -= Time.deltaTime;
				if (_fireTimer <= 0f)
				{
					_fireTimer = Random.Range(_canonFireMinDelay, _canonFireMaxDelay);
					_canonIndex++;
					if (_canonIndex >= _canons.Length)
					{
						_canonIndex = 0;
					}
					Fire(_canons[_canonIndex]);
				}
			}
			if (magnitude2 > 25000f)
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			}
		}

		protected virtual void UpdateWaterTrail(float shipSpeed)
		{
			float num = Mathf.Min(TopSpeed, shipSpeed);
			_waterTrailMain.startSpeed = num;
			_waterTrailEmission.rateOverTime = new ParticleSystem.MinMaxCurve(num / TopSpeed * _waterTrailDefaultEmissionRate);
			if (num <= 1f || (SinkableShip != null && SinkableShip.TotalDistanceSunk > 2f))
			{
				_waterTrailEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
				if (_waterTrailEmission.enabled && WaterTrail.particleCount == 0)
				{
					_waterTrailEmission.enabled = false;
				}
			}
			else if (!_waterTrailEmission.enabled)
			{
				_waterTrailEmission.enabled = true;
			}
		}

		private void Fire(AntiAircraftPlaceholderMissileScript canon)
		{
			AntiAircraftMissileScript antiAircraftMissileScript = canon.Fire(_trackedTarget, OrphanedParticleEffectsParent, deactivatePlaceholder: false);
			antiAircraftMissileScript.LeadAccuracy = _canonAccuracy;
			antiAircraftMissileScript.MaxSpeed = _canonMaxSpeed;
			antiAircraftMissileScript.AltitudeGainTime = 0f;
			antiAircraftMissileScript.MaxTurningPerSecondDeg = _canonMaxTurningPerSecondDeg;
			antiAircraftMissileScript.DieWhenFallingBehind = false;
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (PlayerTarget == null)
			{
				PlayerTarget = e.Aircraft.Target;
				_trackedTarget = new TrackedTarget(PlayerTarget, AggressionLevel.Hostile);
			}
		}
	}
}
