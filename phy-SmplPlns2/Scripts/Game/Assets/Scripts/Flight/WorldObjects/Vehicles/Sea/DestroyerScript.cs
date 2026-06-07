using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.WorldObjects.Combat;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class DestroyerScript : MonoBehaviour
	{
		private List<NetworkFlightObjectDamageReceiverScript> _damageReceivers;

		private bool _isSinking;

		private ushort _teamId = 2;

		private TeamObjectScript _teamObject;

		[SerializeField]
		private float _topSpeed = 7f;

		[SerializeField]
		private ParticleSystem _waterTrail;

		private float _waterTrailDefaultEmissionRate;

		private ParticleSystem.EmissionModule _waterTrailEmission;

		private ParticleSystem.MainModule _waterTrailMain;

		public bool IsSinkable => SinkableShip != null;

		public SinkableShipScript SinkableShip { get; protected set; }

		public NpcTargetingSystem TargetingSystem { get; private set; }

		protected Rigidbody RigidBody { get; set; }

		protected float TopSpeed => _topSpeed;

		protected ParticleSystem WaterTrail => _waterTrail;

		protected List<INpcWeaponSystem> WeaponSystems { get; set; }

		protected virtual void Awake()
		{
			RigidBody = GetComponent<Rigidbody>();
			SinkableShip = GetComponent<SinkableShipScript>();
			_waterTrailEmission = WaterTrail.emission;
			_waterTrailMain = WaterTrail.main;
			_damageReceivers = new List<NetworkFlightObjectDamageReceiverScript>();
			NetworkFlightObjectDamageReceiverScript[] componentsInChildren = GetComponentsInChildren<NetworkFlightObjectDamageReceiverScript>(includeInactive: true);
			foreach (NetworkFlightObjectDamageReceiverScript networkFlightObjectDamageReceiverScript in componentsInChildren)
			{
				_damageReceivers.Add(networkFlightObjectDamageReceiverScript);
				networkFlightObjectDamageReceiverScript.DamageLevelChanged += OnWeaponDamageLevelChanged;
			}
			_teamObject = GetComponent<TeamObjectScript>();
			if (_teamObject != null)
			{
				_teamObject.TeamChanged += OnTeamChanged;
			}
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
			}
			TargetingSystem.OnDestroy();
			if (SinkableShip != null)
			{
				SinkableShip.StartedSinking -= StartedSinking;
			}
			if (_damageReceivers != null)
			{
				foreach (NetworkFlightObjectDamageReceiverScript damageReceiver in _damageReceivers)
				{
					damageReceiver.DamageLevelChanged -= OnWeaponDamageLevelChanged;
				}
			}
			if (_waterTrail != null && _waterTrail.gameObject != null)
			{
				UnityEngine.Object.Destroy(_waterTrail.gameObject);
				_waterTrail = null;
			}
			if (_teamObject != null)
			{
				_teamObject.TeamChanged -= OnTeamChanged;
			}
		}

		protected virtual void Start()
		{
			if (WaterTrail != null)
			{
				_waterTrailDefaultEmissionRate = _waterTrailEmission.rateOverTime.constantMax;
			}
			RigidBody.centerOfMass = Vector3.zero;
			RigidBody.inertiaTensorRotation = Quaternion.identity;
			RigidBody.inertiaTensor = Vector3.zero;
			RigidBody.linearVelocity = base.transform.forward * TopSpeed;
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded += OnPlayerLoaded;
				instance.RaiseLocalPlayerLoaded(OnPlayerLoaded);
			}
			if (SinkableShip != null)
			{
				SinkableShip.StartedSinking += StartedSinking;
			}
			TargetingSystem = new NpcTargetingSystem(_teamId);
			WeaponSystems = GetComponentsInChildren<INpcWeaponSystem>(includeInactive: true).ToList();
			foreach (INpcWeaponSystem weaponSystem in WeaponSystems)
			{
				weaponSystem.InitializeTargetingSystem(TargetingSystem);
				weaponSystem.Arm();
			}
		}

		protected virtual void Update()
		{
			if (!PauseManager.Paused)
			{
				Vector3 linearVelocity = RigidBody.linearVelocity;
				Vector3 v = linearVelocity;
				float? y = 0f;
				float magnitude = v.Copy(null, y).magnitude;
				if (!IsSinkable || !SinkableShip.Sinking)
				{
					Rigidbody rigidBody = RigidBody;
					Vector3 v2 = base.transform.forward * magnitude;
					y = linearVelocity.y;
					rigidBody.linearVelocity = v2.Copy(null, y);
				}
				UpdateWaterTrail(magnitude);
				TargetingSystem.Update(base.transform.position);
			}
		}

		protected virtual void UpdateWaterTrail(float shipSpeed)
		{
			if (WaterTrail == null)
			{
				return;
			}
			float num = Mathf.Min(TopSpeed, shipSpeed);
			bool num2 = num <= 1f || _isSinking;
			_waterTrailMain.startSpeed = num;
			_waterTrailEmission.rateOverTime = new ParticleSystem.MinMaxCurve(num / TopSpeed * _waterTrailDefaultEmissionRate);
			if (num2)
			{
				_waterTrailEmission.rateOverTime = 0f;
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

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				ReinitializeWaterTrail();
			}
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			_teamId = e.NewTeamId;
			if (TargetingSystem != null)
			{
				TargetingSystem.TeamId = e.NewTeamId;
			}
		}

		private void OnWeaponDamageLevelChanged(object sender, DamageLevelEventArgs e)
		{
			INpcWeaponSystem npcWeaponSystem = e.Receiver.ReferenceObject?.GetComponent<INpcWeaponSystem>();
			bool flag = npcWeaponSystem != null;
			if (flag && e.NewLevel.Level >= 1)
			{
				npcWeaponSystem.Disable();
			}
			else if (!flag && e.NewLevel.Level >= 4)
			{
				for (int i = 0; i < WeaponSystems.Count; i++)
				{
					WeaponSystems[i].Disable();
				}
			}
		}

		private void ReinitializeWaterTrail()
		{
			if (_isSinking)
			{
				if (WaterTrail != null)
				{
					WaterTrail.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
				}
				return;
			}
			float num = ((TopSpeed <= 0f) ? 0f : TopSpeed);
			if (WaterTrail != null)
			{
				_waterTrailMain.startSpeed = num;
				_waterTrailEmission.rateOverTime = _waterTrailDefaultEmissionRate;
				if (num > 0f)
				{
					WaterTrail.Simulate(90f, withChildren: true, restart: true);
					WaterTrail.Play(withChildren: true);
				}
			}
		}

		private void StartedSinking(object sender, EventArgs e)
		{
			_isSinking = true;
			if (WaterTrail != null)
			{
				WaterTrail.transform.parent = base.transform.parent;
			}
		}
	}
}
