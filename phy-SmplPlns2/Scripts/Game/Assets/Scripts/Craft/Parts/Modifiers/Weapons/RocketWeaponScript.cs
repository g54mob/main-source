using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class RocketWeaponScript : PartModifierScript, IWeapon, IPartCollisionHandler
	{
		private Func<bool> _activateFunc;

		private bool _active = true;

		private PartDamageEffect _damageEffect;

		private bool _launchedViaDetacher;

		private RocketWeaponData _modifier;

		private RocketScript _rocketScript;

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

		public bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableRockets && base.PartScript.ConnectedToMainCockpit)
				{
					return _active;
				}
				return false;
			}
		}

		public bool IsDamaged { get; protected set; }

		public bool IsDestroyed => false;

		public bool LaunchedViaDetacher
		{
			get
			{
				return _launchedViaDetacher;
			}
			set
			{
				if (!_rocketScript.IsLaunched && value)
				{
					_launchedViaDetacher = true;
					Fire(null);
				}
			}
		}

		public RocketWeaponData Modifier
		{
			get
			{
				if (_modifier == null)
				{
					_modifier = (RocketWeaponData)base.PartModifier;
				}
				return _modifier;
			}
		}

		public TargetingStyle TargetingStyle => TargetingStyle.None;

		public int TotalAmmo { get; private set; }

		public WeaponType Type => WeaponType.Rocket;

		private Func<bool> ActivateFunc => _activateFunc ?? (_activateFunc = base.Controls.GetActivatorGetter(Modifier.ActivationGroup, base.PartScript, valueIfZero: true));

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void DisconnectPart()
		{
			if (base.PartScript.Aircraft.RemoteAircraft)
			{
				return;
			}
			List<PartConnection> partConnections = base.PartScript.Part.PartConnections;
			if (partConnections.Count == 0)
			{
				Debug.LogError("No connections were found when one was expected");
				return;
			}
			if (partConnections.Count > 1)
			{
				Debug.LogError("More than one connection was found when only one was expected");
				return;
			}
			DetacherScript modifier = partConnections[0].GetOtherPart(base.PartScript.Part).PartScript.GetModifier<DetacherScript>();
			if (modifier != null)
			{
				modifier.Detach();
			}
			else
			{
				DisconnectNonDetacherPart();
			}
		}

		public void Fire(TrackedTarget trackedTarget)
		{
			if (base.PartScript.Aircraft.DisableRockets)
			{
				return;
			}
			base.PartScript.PrimaryPartCollider.enabled = false;
			if (!LaunchedViaDetacher)
			{
				DisconnectPart();
			}
			if (!IsDamaged && !_rocketScript.IsLaunched)
			{
				_rocketScript.SelfDestructTimer = Modifier.SelfDestructTimer;
				_rocketScript.BurnTime = Modifier.BurnTimer;
				_rocketScript.Launch(base.PartScript.Body.RigidBody.velocity, Vector3.zero, base.PartScript, isRocketPod: false, trackedTarget);
				if (_modifier.Fins == RocketWeaponData.FinMode.Deployed)
				{
					base.transform.Find("Mesh/Fins").gameObject.SetActive(value: true);
				}
				base.PartScript.Aircraft.TargetingSystem.OnRocketFired(_rocketScript, trackedTarget?.Target);
			}
		}

		bool IPartCollisionHandler.OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint)
		{
			if (_rocketScript != null)
			{
				return _rocketScript.IsLaunched;
			}
			return false;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			float value = UnityEngine.Random.value;
			if (value < 0.05f)
			{
				_rocketScript.Explode();
			}
			else if (value < 0.15f && _damageEffect == null)
			{
				_damageEffect = base.PartScript.Aircraft.DamageEffects.CreateFireSmall(base.PartScript, null);
				_damageEffect.RequiresFuel = false;
				StartCoroutine(DelayedExplosionCoroutine());
			}
			else if ((double)value < 0.4)
			{
				IsDamaged = true;
				StartCoroutine(DisconnectCoroutine());
			}
			else if ((double)value < 0.6)
			{
				IsDamaged = true;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
		}

		private IEnumerator DelayedExplosionCoroutine()
		{
			yield return new WaitForSeconds(5f + 15f * UnityEngine.Random.value);
			_damageEffect.DestroyEffect();
			_damageEffect = null;
			_rocketScript.Explode();
		}

		private IEnumerator DisconnectCoroutine()
		{
			yield return null;
			if (base.PartScript.Part.PartConnections.Count > 0)
			{
				DisconnectPart();
			}
		}

		private void DisconnectNonDetacherPart()
		{
			List<AttachPointData> attachPoints = base.PartScript.Part.AttachPoints;
			if (attachPoints.Count == 0)
			{
				Debug.LogError("No attachment points were found. Unable to detach part");
				return;
			}
			if (attachPoints.Count > 1)
			{
				Debug.LogError("More than one attach point was found when only one was expected. Unable to detach part.");
				return;
			}
			List<BodyJoint> joints = base.PartScript.Body.Joints;
			if (joints.Count == 0)
			{
				Debug.LogError("No joints were found. Unable to detach part.");
				return;
			}
			if (joints.Count > 1)
			{
				Debug.LogError("More than one joint was found when only one was expected. Unable to detach part.");
				return;
			}
			BodyJoint bodyJoint = joints[0];
			if (!bodyJoint.PartConnection.IsDestroyed)
			{
				bodyJoint.Break(playSound: false);
				Vector3 vector = (attachPoints[0].Normal * -1f).normalized * 0f;
				base.PartScript.Body.RigidBody.AddForceAtPosition(vector * 0.01f, base.PartScript.transform.position, ForceMode.Impulse);
			}
			base.PartScript.Aircraft.AircraftStructureChanged();
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

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			TotalAmmo = 1;
			CurrentAmmo = 1;
			_rocketScript = GetComponent<RocketScript>();
			_rocketScript.IsLaserGuided = Modifier.IsLaserGuided;
			return UniTask.CompletedTask;
		}
	}
}
