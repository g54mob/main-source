using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.WorldObjects.Combat.Targets;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class MissileDefenseBaseScript : MonoBehaviour
	{
		private Dictionary<RotatingWeaponScript, List<GroundTarget>> _groundTargetLookup;

		public List<RotatingLaserDefenseScript> DefenseLasers { get; private set; }

		public bool IsHostile { get; set; } = true;

		public List<RotatingMissileLauncherScript> MissileLaunchers { get; private set; }

		public NpcTargetingSystem TargetingSystem { get; private set; }

		public void AddTurret(RotatingMissileLauncherScript turret)
		{
			StartCoroutine(AddTurretCoroutine(turret));
		}

		public void AddTurret(RotatingLaserDefenseScript turret)
		{
			StartCoroutine(AddTurretCoroutine(turret));
		}

		protected virtual void Awake()
		{
			MissileLaunchers = new List<RotatingMissileLauncherScript>();
			DefenseLasers = new List<RotatingLaserDefenseScript>();
			_groundTargetLookup = new Dictionary<RotatingWeaponScript, List<GroundTarget>>();
		}

		protected virtual bool InitiallyHostile()
		{
			return IsHostile;
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.FlightSceneLoaded -= OnFlightSceneLoaded;
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
		}

		protected virtual void Start()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.FlightSceneLoaded += OnFlightSceneLoaded;
			instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
			instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
			instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
			TargetingSystem = new NpcTargetingSystem(1);
			foreach (RotatingMissileLauncherScript missileLauncher in MissileLaunchers)
			{
				RegisterTarget(missileLauncher);
			}
		}

		private IEnumerator AddTurretCoroutine(RotatingMissileLauncherScript turret)
		{
			yield return null;
			yield return null;
			yield return null;
			MissileLaunchers.Add(turret);
			RegisterTarget(turret);
			DamageableBody component = turret.GetComponent<DamageableBody>();
			component.DamageThresholdReached += OnTurretDamageThresholdReached;
			component.DamageReceived += OnTurretDamageReceived;
		}

		private IEnumerator AddTurretCoroutine(RotatingLaserDefenseScript turret)
		{
			yield return null;
			yield return null;
			yield return null;
			DefenseLasers.Add(turret);
			DamageableBody component = turret.GetComponent<DamageableBody>();
			component.DamageThresholdReached += OnTurretDamageThresholdReached;
			component.DamageReceived += OnTurretDamageReceived;
		}

		private void OnFlightSceneLoaded(object sender, EventArgs e)
		{
			IsHostile = InitiallyHostile();
		}

		private void OnPlayerBombFired(object sender, BombFiredEventArgs e)
		{
			if (IsHostile)
			{
				TargetingSystem.AddTarget(new EnemyWeaponBombTarget(e.Bomb, new ExclusiveLock()));
			}
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			TargetingSystem targetingSystem = e.Aircraft.TargetingSystem;
			targetingSystem.MissileFired += OnPlayerMissileFired;
			targetingSystem.RocketFired += OnPlayerRocketFired;
			targetingSystem.BombFired += OnPlayerBombFired;
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			TargetingSystem targetingSystem = e.Aircraft.TargetingSystem;
			targetingSystem.MissileFired -= OnPlayerMissileFired;
			targetingSystem.RocketFired -= OnPlayerRocketFired;
			targetingSystem.BombFired -= OnPlayerBombFired;
		}

		private void OnPlayerMissileFired(object sender, MissileFiredEventArgs e)
		{
			if (IsHostile)
			{
				TargetingSystem.AddTarget(new EnemyWeaponMissileTarget(e.Missile, new ExclusiveLock()));
			}
		}

		private void OnPlayerRocketFired(object sender, RocketFiredEventArgs e)
		{
			if (IsHostile)
			{
				TargetingSystem.AddTarget(new EnemyWeaponRocketTarget(e.Rocket, new ExclusiveLock()));
			}
		}

		private void OnTurretDamageReceived(object sender, DamageEventArgs e)
		{
		}

		private void OnTurretDamageThresholdReached(object sender, DamageThresholdEventArgs e)
		{
			DamageableBody damageableBody = (DamageableBody)sender;
			if (damageableBody == null)
			{
				this.LogError("Unknown event sender");
				return;
			}
			if (!damageableBody.TryGetComponent<RotatingWeaponScript>(out var component))
			{
				this.LogError("Unknown turret");
				return;
			}
			ParticleSystem firstChild = Utilities.GetFirstChild<ParticleSystem>("SmokeDamage", damageableBody.gameObject);
			if (firstChild == null)
			{
				this.LogError("Turret damage particle system not found");
			}
			else if (e.NewThresholdLevel == 2)
			{
				firstChild.Play();
			}
			else
			{
				if (e.NewThresholdLevel != 4)
				{
					return;
				}
				ParticleSystem.MainModule main = firstChild.main;
				main.startLifetime = main.startLifetime.constantMax * 1.5f;
				ParticleSystem.EmissionModule emission = firstChild.emission;
				emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax * 2f);
				component.Disable();
				if (!_groundTargetLookup.TryGetValue(component, out var value))
				{
					return;
				}
				foreach (GroundTarget item in value)
				{
					item.MarkAsDead();
				}
			}
		}

		private void RegisterTarget(RotatingMissileLauncherScript target)
		{
			GroundTarget groundTarget = new GroundTarget("Missile Launcher", target.transform, 10000f, 1);
			FlightSceneScript.Instance.TargetRegistry.RegisterTarget(groundTarget);
			if (!_groundTargetLookup.TryGetValue(target, out var value))
			{
				value = (_groundTargetLookup[target] = new List<GroundTarget>(1));
			}
			value.Add(groundTarget);
		}
	}
}
