using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public abstract class ExplosiveWeaponScriptBase<TModifier> : PartModifierScript, IWeapon, IPartCollisionHandler where TModifier : ExplosiveWeaponBaseData
	{
		private bool _active;

		private Func<bool> _activeFunc;

		private string _defaultExplosionPrefabName;

		private TModifier _modifier;

		public virtual int CurrentAmmo
		{
			get
			{
				if (!Launched)
				{
					return 1;
				}
				return 0;
			}
		}

		public virtual TrackedTarget CurrentTarget { get; set; }

		public string CustomName => Modifier.CustomName;

		public virtual bool Detonated { get; protected set; }

		public virtual bool Fired { get; protected set; }

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

		public abstract WeaponFunction Function { get; }

		public virtual bool IsArmed
		{
			get
			{
				if (_active)
				{
					return !IsDamaged;
				}
				return false;
			}
		}

		public bool IsDamaged { get; protected set; }

		public virtual bool IsDestroyed => Detonated;

		public virtual bool Launched => !base.PartScript.ConnectedToMainCockpit;

		public TModifier Modifier
		{
			get
			{
				if (_modifier == null)
				{
					_modifier = (TModifier)base.PartModifier;
				}
				return _modifier;
			}
		}

		public abstract TargetingStyle TargetingStyle { get; }

		public virtual int TotalAmmo => 1;

		public abstract WeaponType Type { get; }

		protected string ExplosionPrefabName
		{
			get
			{
				if (!string.IsNullOrEmpty(Modifier.ExplosionPrefabName))
				{
					return Modifier.ExplosionPrefabName;
				}
				return _defaultExplosionPrefabName;
			}
		}

		protected Vector3? PreviousFrameVelocity { get; set; }

		protected Rigidbody RigidBody { get; set; }

		private Func<bool> ActiveFunc => _activeFunc ?? (_activeFunc = base.Controls.GetActivatorGetter(Modifier.ActivationGroup, base.PartScript, valueIfZero: true));

		public event EventHandler<WeaponFiredEventArgs> WeaponFired;

		protected ExplosiveWeaponScriptBase(string defaultExplosionPrefabName)
		{
			_defaultExplosionPrefabName = defaultExplosionPrefabName;
		}

		public virtual void AdjustFreeFallHeading()
		{
			IRigidBody rigidBody = base.PartScript.Body.RigidBody;
			if (rigidBody.velocity.sqrMagnitude > 400f)
			{
				Vector2 vector = GetAnglesFromForward(base.transform.InverseTransformVector(rigidBody.velocity)) * -1f;
				Quaternion to = rigidBody.rotation * Quaternion.Euler(vector.y, 0f - vector.x, 0f);
				rigidBody.MoveRotation(Quaternion.RotateTowards(rigidBody.rotation, to, 20f * Time.deltaTime));
			}
		}

		public void Detonate(Vector3 blastDirection, ITarget target = null)
		{
			if (!Detonated)
			{
				Detonated = true;
				OnPreExplode();
				base.PartScript.Body.SilentlyDisconnectAndDisablePart(base.PartScript);
				Vector3? impactDirection = (PreviousFrameVelocity.HasValue ? new Vector3?(PreviousFrameVelocity.Value.normalized) : ((Vector3?)null));
				ExplosiveWeaponImpactType impactType = GetImpactType();
				OnExplode(RigidBody, impactDirection, blastDirection, impactType, target);
			}
		}

		public void DisconnectPart()
		{
			List<PartConnection> partConnections = base.PartScript.Part.AttachPoints[0].PartConnections;
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
			CurrentTarget = trackedTarget;
			RigidBody = GetComponentInParent<Rigidbody>();
			OnFire();
			this.WeaponFired?.Invoke(this, new WeaponFiredEventArgs(this, CurrentTarget));
		}

		bool IPartCollisionHandler.OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint)
		{
			if (Detonated || !base.PartScript.PhysicsEnabled)
			{
				return true;
			}
			if (base.gameObject.transform.position.y < GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault() - 3f)
			{
				return true;
			}
			float num = Mathf.Abs(Vector3.Dot(contactPoint.normal, collision.relativeVelocity));
			Rigidbody attachedRigidbody = contactPoint.otherCollider.attachedRigidbody;
			float mass = base.PartScript.Body.RigidBody.mass;
			if (attachedRigidbody != null && attachedRigidbody.mass < mass)
			{
				num *= attachedRigidbody.mass / mass;
			}
			if (num >= Modifier.DetonationImpactForce)
			{
				Detonate(contactPoint.normal, CurrentTarget?.Target);
				return true;
			}
			return false;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			float value = UnityEngine.Random.value;
			if (value < 0.05f)
			{
				Detonate(Vector3.up);
			}
			else if ((double)value < 0.4 && !IsDamaged)
			{
				IsDamaged = true;
				StartCoroutine(DisconnectCoroutine());
			}
			else if ((double)value < 0.8 && !IsDamaged)
			{
				IsDamaged = true;
			}
		}

		public override void OnExplosiveForceApplied(float force, Vector3 forceDirection)
		{
			if (!Detonated && !Fired && force >= Modifier.DetonationExplosiveForce)
			{
				Detonate(Vector3.up);
			}
		}

		public void UpdateOutputs()
		{
		}

		protected virtual void Awake()
		{
		}

		protected Vector2 GetAngles(Vector3 from, Vector3 to)
		{
			Quaternion quaternion = Quaternion.FromToRotation(from, Vector3.forward);
			return GetAnglesFromForward(quaternion * to);
		}

		protected Vector2 GetAnglesFromForward(Vector3 v)
		{
			Vector3 vector = new Vector3(0f, 0f, v.z);
			Vector3 to = new Vector3(v.x, 0f, v.z);
			return new Vector2(y: Vector3.Angle(vector, new Vector3(0f, v.y, v.z)) * Mathf.Sign(v.y), x: Vector3.Angle(vector, to) * Mathf.Sign(v.x));
		}

		protected abstract void OnExplode(Rigidbody responsibleBody, Vector3? impactDirection, Vector3 blastDirection, ExplosiveWeaponImpactType impactType, ITarget target);

		protected abstract void OnFire();

		protected virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = ActiveFunc();
			if (flag != _active)
			{
				_active = flag;
				frame.Craft.TargetingSystem.OnQueueUpdateWeaponsList();
			}
			if (RigidBody != null)
			{
				PreviousFrameVelocity = RigidBody.linearVelocity;
			}
		}

		protected virtual void OnPreExplode()
		{
		}

		protected virtual void OnStart(in CraftUpdateFrameData frame)
		{
		}

		protected virtual void OnUpdate(in CraftUpdateFrameData frame)
		{
			float? seaLevel = GameWorld.Instance.SeaLevel;
			if (seaLevel.HasValue && Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position).y < seaLevel.Value - 20f)
			{
				base.PartScript.Body.SilentlyDisconnectAndDisablePart(base.PartScript);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
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
				Vector3 vector = (attachPoints[0].Normal * -1f).normalized * Modifier.DefaultDetachForce;
				base.PartScript.Body.RigidBody.AddForceAtPosition(vector * 0.01f, base.PartScript.transform.position, ForceMode.Impulse);
			}
			base.PartScript.Aircraft.AircraftStructureChanged();
		}

		private ExplosiveWeaponImpactType GetImpactType()
		{
			ExplosiveWeaponImpactType explosiveWeaponImpactType = ExplosiveWeaponImpactType.Air;
			int layerMask = 9439248;
			float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
			if (floatingOriginSeaLevel.HasValue && base.transform.position.y < floatingOriginSeaLevel.Value + 1f)
			{
				return ExplosiveWeaponImpactType.Water;
			}
			if (Physics.Raycast(new Ray(base.transform.position, Vector3.down), out var hitInfo, 5f, layerMask, QueryTriggerInteraction.Collide))
			{
				return hitInfo.collider.gameObject.layer switch
				{
					20 => ExplosiveWeaponImpactType.Ground, 
					23 => ExplosiveWeaponImpactType.Boat, 
					4 => ExplosiveWeaponImpactType.Water, 
					11 => ExplosiveWeaponImpactType.Structure, 
					_ => ExplosiveWeaponImpactType.Air, 
				};
			}
			return ExplosiveWeaponImpactType.Air;
		}
	}
}
