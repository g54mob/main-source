using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class RocketPodScript : PartModifierScript, IWeapon
	{
		private Func<bool> _activateFunc;

		private bool _active = true;

		private PartDamageEffect _damageEffect;

		private List<RocketScript> _failedRockets = new List<RocketScript>();

		private RocketPodData _modifier;

		private List<RocketScript> _rockets = new List<RocketScript>();

		public int CurrentAmmo { get; private set; }

		public TrackedTarget CurrentTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CustomName => Modifier.CustomName;

		public float FireDelay
		{
			get
			{
				return _modifier.FireDelay;
			}
			private set
			{
				_modifier.FireDelay = value;
			}
		}

		public WeaponFunction Function => WeaponFunction.AirToSurface;

		public virtual bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableRockets)
				{
					return _active;
				}
				return false;
			}
		}

		public bool IsDestroyed => false;

		public RocketPodData Modifier
		{
			get
			{
				if (_modifier == null)
				{
					_modifier = (RocketPodData)base.PartModifier;
				}
				return _modifier;
			}
		}

		public TargetingStyle TargetingStyle => TargetingStyle.None;

		public int TotalAmmo { get; private set; }

		public WeaponType Type => WeaponType.RocketPod;

		private Func<bool> ActivateFunc => _activateFunc ?? (_activateFunc = base.Controls.GetActivatorGetter(Modifier.ActivationGroup, base.PartScript, valueIfZero: true));

		public void Fire(TrackedTarget trackedTarget)
		{
			base.PartScript.PartGroup.DecombineMesh();
			if (_rockets.Count <= 0)
			{
				return;
			}
			RocketScript rocketScript = _rockets[0];
			_rockets.RemoveAt(0);
			CurrentAmmo--;
			if (base.PartScript.PartDamage > 0f && UnityEngine.Random.value < base.PartScript.PartDamage / base.PartScript.MaxHealth)
			{
				_failedRockets.Add(rocketScript);
				return;
			}
			rocketScript.enabled = true;
			BodyScript body = base.PartScript.Body;
			rocketScript.IsLaserGuided = Modifier.IsLaserGuided;
			rocketScript.Launch(body.Velocity, Vector3.zero, base.PartScript, isRocketPod: true, trackedTarget);
			if (body.RigidBody != null)
			{
				body.RigidBody.mass -= 0.049999997f;
			}
			base.PartScript.Aircraft.TargetingSystem.OnRocketFired(rocketScript, trackedTarget?.Target);
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light && _damageEffect == null && UnityEngine.Random.value < 0.1f)
			{
				_damageEffect = base.PartScript.Aircraft.DamageEffects.CreateFireSmall(base.PartScript, null);
				_damageEffect.RequiresFuel = false;
				StartCoroutine(DelayedExplosionCoroutine());
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
		}

		private IEnumerator DelayedExplosionCoroutine()
		{
			yield return new WaitForSeconds(5f + 15f * UnityEngine.Random.value);
			_damageEffect.DestroyEffect();
			_damageEffect = null;
			base.PartScript.PartGroup.DecombineMesh();
			if (_rockets.Count > 0)
			{
				_rockets[0].Explode();
			}
			else if (_failedRockets.Count > 0)
			{
				_failedRockets[0].Explode();
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = ActivateFunc();
			if (_active != flag)
			{
				_active = flag;
				base.PartScript.Aircraft.TargetingSystem.OnQueueUpdateWeaponsList();
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				RocketScript[] componentsInChildren = GetComponentsInChildren<RocketScript>();
				foreach (RocketScript rocketScript in componentsInChildren)
				{
					_rockets.Add(rocketScript);
					rocketScript.Owner = base.PartScript.Aircraft;
					rocketScript.enabled = false;
				}
				TotalAmmo = _rockets.Count;
				CurrentAmmo = TotalAmmo;
			}
		}
	}
}
