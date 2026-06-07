using System.Collections;
using MalbersAnimations.Controller;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Damage/Projectile")]
	[SelectionBase]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/mdamager/mprojectile")]
	public class MProjectile : MDamager, IProjectile, IMLayer
	{
		public ImpactBehaviour impactBehaviour;

		public ProjectileRotation rotation;

		[Tooltip("Rotation ammount around trajectory axis when the projectile is set to Follow Trajectory")]
		public float TrajectoryRoll;

		public float Penetration = 0.1f;

		[SerializeField]
		[Tooltip("Keep Projectile Damage Values, The throwable wont affect the Damage Values")]
		protected BoolReference m_KeepDamageValues = new BoolReference(value: false);

		[SerializeField]
		[Tooltip("Gravity applied to the projectile, if gravity is zero the projectile will go straight. If the Projectile is thrown by a Projectile Thrower.It will inherit the gravity from it")]
		protected Vector3Reference gravity = new Vector3Reference(Physics.gravity);

		[SerializeField]
		[Tooltip("Apply Gravity after certain distance is reached")]
		private FloatReference m_AfterDistance = new FloatReference(0f);

		[Tooltip("Life of the Projectile on the air, if it has not touch anything on this time it will destroy it self")]
		public FloatReference Life = new FloatReference(10f);

		[Tooltip("Life of the Projectile After Impact. If the projectile is not destroyed on impact, then wait this time to do it. (0 -> Ignores it) ")]
		public FloatReference LifeImpact = new FloatReference(0f);

		[Tooltip("Multiplier of the Force to Apply to the object the projectile impact ")]
		public FloatReference PushMultiplier = new FloatReference(1f);

		[Tooltip("Torque for the rotation of the projectile")]
		public FloatReference torque = new FloatReference(50f);

		[Tooltip("Axis Torque for the rotation of the projectile")]
		public Vector3 torqueAxis = Vector3.up;

		[Tooltip("Offset to position the projectile when is Instantiated on the weapon. E.g. (Arrow in the Bow) ")]
		public Vector3 m_PosOffset;

		[Tooltip("Offset to rotation the projectile when is Instantiated on the weapon. E.g. (Arrow in the Bow) ")]
		public Vector3 m_RotOffset;

		[Tooltip("Offset to scale the projectile when is Instantiated on the weapon. E.g. (Arrow in the Bow) ")]
		public Vector3 m_ScaleOffset;

		[Tooltip("Use Spherecast to predict the trajectory")]
		public bool useRadius;

		[Tooltip("Radius of the projectile to cast a ray to find targets better")]
		public FloatReference Radius = new FloatReference(0.01f);

		public UnityEvent OnFire = new UnityEvent();

		[Tooltip("Reference for the Projectile Rigidbody")]
		public Rigidbody rb;

		[Tooltip("Reference for the Projectile collider")]
		public Collider m_collider;

		public float DragOnImpact = 1f;

		protected Vector3 Prev_pos;

		protected bool doRayCast;

		[HideInInspector]
		public int Editor_Tabs1;

		public float AfterDistance
		{
			get
			{
				return m_AfterDistance.Value;
			}
			set
			{
				m_AfterDistance.Value = value;
			}
		}

		public Vector3 Velocity { get; set; }

		public bool HasImpacted { get; set; }

		public bool IsFlying { get; set; }

		public Vector3 Gravity
		{
			get
			{
				return gravity.Value;
			}
			set
			{
				gravity.Value = value;
			}
		}

		public bool KeepDamageValues
		{
			get
			{
				return m_KeepDamageValues.Value;
			}
			set
			{
				m_KeepDamageValues.Value = value;
			}
		}

		public Vector3 TargetHitPosition { get; set; }

		public bool FollowTrajectory => rotation == ProjectileRotation.FollowTrajectory;

		public bool DestroyOnImpact => impactBehaviour == ImpactBehaviour.DestroyOnImpact;

		public bool StickOnSurface => impactBehaviour == ImpactBehaviour.StickOnSurface;

		public Vector3 PosOffset
		{
			get
			{
				return m_PosOffset;
			}
			set
			{
				m_PosOffset = value;
			}
		}

		public Vector3 RotOffset
		{
			get
			{
				return m_RotOffset;
			}
			set
			{
				m_RotOffset = value;
			}
		}

		protected virtual void Awake()
		{
			if (!rb)
			{
				rb = GetComponent<Rigidbody>();
			}
			if (!m_collider)
			{
				m_collider = GetComponentInChildren<Collider>();
			}
			m_audio = GetComponent<AudioSource>();
			if (!m_audio)
			{
				m_audio = base.gameObject.AddComponent<AudioSource>();
			}
			m_audio.spatialBlend = 1f;
			m_audio.maxDistance = 50f;
		}

		protected virtual void Initialize()
		{
			HasImpacted = false;
			if ((float)Life > 0f)
			{
				Invoke("DestroyProjectile", Life);
			}
		}

		public virtual void Prepare(GameObject Owner, Vector3 Gravity, Vector3 ProjectileVelocity, LayerMask HitLayer, QueryTriggerInteraction triggerInteraction)
		{
			base.Layer = HitLayer;
			base.TriggerInteraction = triggerInteraction;
			this.Owner = Owner;
			this.Gravity = Gravity;
			Velocity = ProjectileVelocity;
			MaxForce = Velocity.magnitude;
			MinForce = Velocity.magnitude;
			Debugging("Projectile Prepared", this);
		}

		public virtual void Fire(Vector3 ProjectileVelocity)
		{
			Velocity = ProjectileVelocity;
			MaxForce = Velocity.magnitude;
			MinForce = Velocity.magnitude;
			Fire();
		}

		public virtual void Fire()
		{
			Initialize();
			base.gameObject.SetActive(value: true);
			Enabled = true;
			if (Velocity == Vector3.zero)
			{
				Velocity = base.transform.forward;
				MaxForce = 1f;
				MinForce = 1f;
			}
			doRayCast = true;
			if ((bool)m_collider && (bool)rb)
			{
				EnableCollider(0.1f);
				doRayCast = m_collider.isTrigger;
			}
			if ((bool)rb)
			{
				EnableRigidBody();
				rb.velocity = Vector3.zero;
				if (rotation == ProjectileRotation.Random)
				{
					rb.AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * torque, ForceMode.Acceleration);
				}
				else if (rotation == ProjectileRotation.Axis)
				{
					rb.AddTorque(torqueAxis * torque.Value, ForceMode.Impulse);
				}
				rb.AddForce(Velocity, ForceMode.VelocityChange);
			}
			StartCoroutine(FlyingProjectile());
			OnFire.Invoke();
			Debugging("Projectile Fired", this);
		}

		public void EnableCollider(float time)
		{
			Invoke("Enable_Collider", time);
		}

		protected virtual void Enable_Collider()
		{
			if ((bool)m_collider)
			{
				m_collider.enabled = true;
			}
		}

		protected virtual void DestroyProjectile()
		{
			if (!HasImpacted)
			{
				Debugging($"Life time elapsed [{Life}]. Destroy Projectile", null);
				Object.Destroy(base.gameObject);
			}
		}

		protected virtual void OnCollisionEnter(Collision other)
		{
			if ((!rb || !rb.isKinematic) && !HasImpacted && !IsInvalid(other.collider) && base.enabled)
			{
				if (Prev_pos == Vector3.zero)
				{
					Prev_pos = base.transform.position;
				}
				ProjectileImpact(other.rigidbody, other.collider, other.contacts[0].point, (other.collider.bounds.center - m_collider.transform.position).normalized);
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (!HasImpacted && !IsInvalid(other) && base.enabled)
			{
				if (Prev_pos == Vector3.zero)
				{
					Prev_pos = base.transform.position;
				}
				ProjectileImpact(other.attachedRigidbody, other, Prev_pos, (other.bounds.center - m_collider.transform.position).normalized);
			}
		}

		protected virtual void OnDisable()
		{
			StopAllCoroutines();
		}

		protected virtual IEnumerator FlyingProjectile()
		{
			Vector3 start = (Prev_pos = base.transform.position);
			float deltatime = Time.fixedDeltaTime;
			WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
			base.Direction = Velocity.normalized;
			int step = 1;
			Vector3 RotationAround = Vector3.zero;
			if (rotation == ProjectileRotation.Random)
			{
				RotationAround = new Vector3(Random.value, Random.value, Random.value).normalized;
			}
			else if (rotation == ProjectileRotation.Axis)
			{
				RotationAround = torqueAxis.normalized;
			}
			float TraveledDistance = 0f;
			int NoGravityStep = 0;
			while (!HasImpacted && base.enabled)
			{
				float num = deltatime * (float)step;
				float num2 = deltatime * (float)(step - NoGravityStep);
				Vector3 vector = start + Velocity * num + num2 * num2 * Gravity / 2f;
				if (!rb)
				{
					base.transform.position = Prev_pos;
					if (rotation == ProjectileRotation.Random || rotation == ProjectileRotation.Axis)
					{
						base.transform.Rotate(RotationAround, (float)torque * deltatime, Space.World);
					}
				}
				else
				{
					rb.MovePosition(Prev_pos);
				}
				base.Direction = vector - Prev_pos;
				Debug.DrawLine(Prev_pos, vector, Color.yellow);
				if ((float)Radius > 0f)
				{
					MDebug.DrawWireSphere(Prev_pos, Color.yellow, Radius);
					MDebug.DrawWireSphere(vector, Color.yellow, Radius);
				}
				float maxDistance = Vector3.Distance(vector, Prev_pos);
				if (Physics.SphereCast(Prev_pos, Radius, base.Direction, out var hit, maxDistance, base.Layer, triggerInteraction) && !IsInvalid(hit.collider))
				{
					yield return waitForFixedUpdate;
					ProjectileImpact(hit.rigidbody, hit.collider, hit.point, hit.normal);
					yield break;
				}
				if (FollowTrajectory)
				{
					base.transform.rotation = Quaternion.LookRotation(base.Direction, base.transform.up);
					if (TrajectoryRoll != 0f)
					{
						base.transform.Rotate(base.Direction, TrajectoryRoll * deltatime, Space.World);
					}
				}
				if (TraveledDistance < AfterDistance)
				{
					TraveledDistance += base.Direction.magnitude;
					NoGravityStep++;
				}
				Prev_pos = vector;
				step++;
				yield return waitForFixedUpdate;
				hit = default(RaycastHit);
			}
			Debug.Log("exit one");
			yield return null;
		}

		public virtual void ProjectileImpact(Rigidbody targetRB, Collider collider, Vector3 HitPosition, Vector3 normal)
		{
			if (!Enabled)
			{
				return;
			}
			Debugging("<color=yellow> <b>[Projectile Impact] </b> [" + collider.name + "] </color>", this);
			HasImpacted = true;
			base.HitPosition = HitPosition;
			StopAllCoroutines();
			if (MissAttack())
			{
				Debugging("Destroy Projectile Missed", null);
				Object.Destroy(base.gameObject);
				return;
			}
			if (!m_collider || m_collider.isTrigger)
			{
				DisableRigidBody();
				if ((bool)rb)
				{
					rb.constraints = RigidbodyConstraints.FreezeAll;
				}
			}
			TryInteract(collider.gameObject);
			damagee = collider.GetComponentInParent<IMDamage>();
			if (damagee != null)
			{
				damagee.HitCollider = collider;
			}
			TryDamage(damagee, statModifier);
			targetRB?.AddForceAtPosition((float)PushMultiplier * Velocity.magnitude * base.Direction.normalized, HitPosition, forceMode);
			OnHit.Invoke(collider.transform);
			OnHitPosition.Invoke(HitPosition);
			Animator componentInParent = collider.gameObject.GetComponentInParent<Animator>();
			Transform avatarRoot = collider.transform;
			if (componentInParent != null)
			{
				avatarRoot = componentInParent.avatarRoot;
			}
			Transform closestTransform = collider.transform;
			if (!(collider is MeshCollider) && !(collider is TerrainCollider) && !collider.gameObject.isStatic && (bool)componentInParent)
			{
				closestTransform = MTools.GetClosestTransform(HitPosition, avatarRoot, base.Layer);
				if (closestTransform != collider.transform)
				{
					Collider component = closestTransform.GetComponent<Collider>();
					if (component != null && !component.isTrigger && !(component is MeshCollider))
					{
						HitPosition = component.ClosestPoint(HitPosition);
					}
					else
					{
						Vector3 position = closestTransform.position;
						Vector3 a = ((closestTransform.parent != null) ? closestTransform.parent.position : position);
						Vector3 a2 = ((closestTransform.childCount > 0) ? closestTransform.GetChild(0).position : position);
						Vector3 vector = MTools.ClosestPointOnLine(HitPosition, a2, position);
						Vector3 vector2 = MTools.ClosestPointOnLine(HitPosition, a, position);
						float num = Vector3.Distance(vector, position);
						float num2 = Vector3.Distance(vector2, position);
						HitPosition = ((num < num2) ? vector : vector2);
					}
				}
			}
			TryHitEffectProjectile(HitPosition, normal, closestTransform);
			switch (impactBehaviour)
			{
			case ImpactBehaviour.StickOnSurface:
				Stick_On_Surface(closestTransform, HitPosition);
				break;
			case ImpactBehaviour.DestroyOnImpact:
				Debugging("DestroyOnImpact", null);
				Object.Destroy(base.gameObject);
				return;
			case ImpactBehaviour.ActivateRigidBody:
				EnableRigidBody();
				Enable_Collider();
				if ((bool)rb)
				{
					rb.drag = DragOnImpact;
				}
				Debugging("Activate Rigid Body", null);
				break;
			}
			if ((float)LifeImpact > 0f && impactBehaviour != ImpactBehaviour.DestroyOnImpact)
			{
				Object.Destroy(base.gameObject, LifeImpact.Value);
			}
			Enabled = false;
		}

		protected virtual void EnableRigidBody()
		{
			if ((bool)rb)
			{
				rb.useGravity = true;
				rb.isKinematic = false;
				rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
				rb.constraints = RigidbodyConstraints.None;
			}
		}

		protected virtual void DisableRigidBody()
		{
			if ((bool)rb)
			{
				rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				rb.useGravity = false;
				rb.isKinematic = true;
			}
		}

		public void PrepareDamage(StatModifier modifier, float CriticalChance, float CriticalMultiplier, StatElement element)
		{
			if (!KeepDamageValues)
			{
				statModifier = new StatModifier(modifier);
				base.CriticalChance = CriticalChance;
				base.CriticalMultiplier = CriticalMultiplier;
				base.element = element;
			}
		}

		protected virtual void Stick_On_Surface(Transform collider, Vector3 HitPosition)
		{
			Debugging("Stick on Surface [" + collider.name + "]", this);
			MDebug.DrawWireSphere(HitPosition, Color.red, 0.05f);
			base.transform.position += base.transform.forward * Penetration;
			base.transform.SetParentScaleFixer(collider, HitPosition);
			DisableRigidBody();
		}

		protected virtual void TryHitEffectProjectile(Vector3 HitPosition, Vector3 Normal, Transform hitTransform)
		{
			GameObject gameObject = base.HitEffect;
			if (damagee != null && hitEffects != null && hitEffects.Count > 0)
			{
				EffectType effectType = hitEffects.Find((EffectType x) => x.surface == damagee.Surface);
				if (effectType != null)
				{
					if (effectType.effect.Value != null)
					{
						gameObject = effectType.effect.Value;
					}
					if (effectType.sound != null)
					{
						hitSound = effectType.sound;
					}
				}
			}
			if (gameObject != null)
			{
				Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, Normal);
				if (debug)
				{
					MDebug.DrawWireSphere(HitPosition, Color.red, 0.05f, 1f);
				}
				Debugging($"<color=yellow> <b>[HitEffect] </b> [{gameObject.name}] , {HitPosition} </color>", this);
				if (gameObject.IsPrefab())
				{
					GameObject gameObject2 = Object.Instantiate(gameObject, HitPosition, quaternion);
					Transform transform = gameObject2.transform.SetParentScaleFixer(hitTransform, HitPosition);
					CheckHitEffect(gameObject2);
					if (DestroyHitEffect > 0f)
					{
						Object.Destroy(gameObject2, DestroyHitEffect);
						if ((bool)transform)
						{
							Object.Destroy(transform.gameObject, DestroyHitEffect);
						}
					}
				}
				else
				{
					gameObject.transform.SetPositionAndRotation(HitPosition, quaternion);
					CheckHitEffect(gameObject);
				}
				gameObject.SetActive(value: true);
			}
			if (!(m_audio != null))
			{
				return;
			}
			if (impactBehaviour == ImpactBehaviour.DestroyOnImpact)
			{
				if ((bool)gameObject)
				{
					AudioSource audioSource = gameObject.GetComponent<AudioSource>();
					if (audioSource == null)
					{
						audioSource = gameObject.AddComponent<AudioSource>();
					}
					if (audioSource.enabled && audioSource.isActiveAndEnabled && audioSource.gameObject.activeInHierarchy)
					{
						audioSource.clip = hitSound.Value;
						audioSource.spatialBlend = 1f;
						audioSource.Play();
					}
				}
			}
			else
			{
				PlaySound(hitSound.Value);
			}
		}
	}
}
