using System;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Damage/Projectile Thrower")]
	public class MProjectileThrower : MonoBehaviour, IThrower, IAnimatorListener
	{
		[Header("Projectile")]
		[SerializeField]
		[Tooltip("What projectile will be instantiated")]
		private GameObjectReference m_Projectile = new GameObjectReference();

		[Tooltip("The projectile will be fired on start")]
		public BoolReference FireOnStart;

		[Header("Multipliers")]
		[Tooltip("Multiplier value to Apply to the Projectile Stat Modifier")]
		[FormerlySerializedAs("Multiplier")]
		public FloatReference DamageMultiplier = new FloatReference(1f);

		[Tooltip("Multiplier value to apply to the Projectile Scale")]
		public FloatReference ScaleMultiplier = new FloatReference(1f);

		[Tooltip("Multiplier value to apply to the Projectile Launch Force")]
		public FloatReference ForceMultiplier = new FloatReference(1f);

		[Header("Layer Interaction")]
		[SerializeField]
		private LayerReference hitLayer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[Header("References")]
		[SerializeField]
		[Tooltip("When this parameter is set it will Aim Directly to the Target")]
		private TransformReference m_Target;

		[SerializeField]
		[Tooltip("Transform Reference for to calculate the Thrower Aim Origin Position")]
		private Transform m_AimOrigin;

		[SerializeField]
		[Tooltip("Owner of the Thrower Component. By default it should be the Root GameObject")]
		private GameObjectReference m_Owner;

		[Header("Aimer")]
		[Tooltip("Reference for the Aimer Component")]
		public Aim Aimer;

		[Tooltip("if its set to False. it will use this GameObject Forward Direction")]
		public BoolReference useAimerDirection = new BoolReference(value: true);

		[Hide("Aimer")]
		[Tooltip("Update the Thrower Target from the Aimer component")]
		public bool UpdateTargetFromAimer;

		[Header("Physics Values")]
		[SerializeField]
		[Tooltip("Launch force for the Projectile")]
		private float m_Force = 50f;

		[Range(0f, 90f)]
		[SerializeField]
		[Tooltip("Angle of the Projectile when a Target is assigned")]
		private float m_angle = 45f;

		[SerializeField]
		[Tooltip("Gravity to apply to the Projectile. By default is set to Physics.gravity")]
		private Vector3Reference gravity = new Vector3Reference(Physics.gravity);

		[SerializeField]
		[Tooltip("Apply Gravity after certain distance is reached")]
		private FloatReference m_AfterDistance = new FloatReference(0f);

		[MButton("Fire", true)]
		public bool FireTest;

		private bool m_CalculateTrajectory;

		public Action<bool> Predict { get; set; }

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

		public LayerMask Layer
		{
			get
			{
				return hitLayer.Value;
			}
			set
			{
				hitLayer.Value = value;
			}
		}

		public QueryTriggerInteraction TriggerInteraction
		{
			get
			{
				return triggerInteraction;
			}
			set
			{
				triggerInteraction = value;
			}
		}

		public Vector3 AimOriginPos => m_AimOrigin.position;

		public Transform Target
		{
			get
			{
				return m_Target.Value;
			}
			set
			{
				m_Target.Value = value;
			}
		}

		public GameObject Owner
		{
			get
			{
				return m_Owner.Value;
			}
			set
			{
				m_Owner.Value = value;
			}
		}

		public GameObject Projectile
		{
			get
			{
				return m_Projectile.Value;
			}
			set
			{
				m_Projectile.Value = value;
			}
		}

		public Vector3 Velocity { get; set; }

		public float Power
		{
			get
			{
				return m_Force * (float)ForceMultiplier;
			}
			set
			{
				m_Force = value;
			}
		}

		public float Angle
		{
			get
			{
				return m_angle;
			}
			set
			{
				m_angle = value;
			}
		}

		public bool UseAimerDirection
		{
			get
			{
				return useAimerDirection.Value;
			}
			set
			{
				useAimerDirection.Value = value;
			}
		}

		public Transform AimOrigin => m_AimOrigin;

		public bool CalculateTrajectory
		{
			get
			{
				return m_CalculateTrajectory;
			}
			set
			{
				m_CalculateTrajectory = value;
				Predict?.Invoke(value);
			}
		}

		Transform IAnimatorListener.transform => base.transform;

		private void OnEnable()
		{
			if (Owner == null)
			{
				Owner = base.transform.FindObjectCore().gameObject;
			}
			if (m_AimOrigin == null)
			{
				m_AimOrigin = (Aimer ? Aimer.AimOrigin : base.transform);
			}
			if ((bool)FireOnStart)
			{
				Fire();
			}
			Aimer?.OnSetTarget.AddListener(AimerTarget);
		}

		private void OnDisable()
		{
			Aimer?.OnSetTarget.RemoveListener(AimerTarget);
		}

		private void AimerTarget(Transform target)
		{
			if (UpdateTargetFromAimer)
			{
				Target = target;
			}
		}

		public virtual void SetProjectile(GameObject newProjectile)
		{
			if (Projectile != newProjectile)
			{
				Projectile = newProjectile;
			}
		}

		public virtual void Fire()
		{
			if (base.enabled && !(Projectile == null))
			{
				CalculateVelocity();
				GameObject gameObject = UnityEngine.Object.Instantiate(Projectile, AimOriginPos, Quaternion.identity);
				gameObject.transform.localScale *= (float)ScaleMultiplier;
				Prepare_Projectile(gameObject);
				Predict?.Invoke(obj: false);
			}
		}

		private void FixedUpdate()
		{
			if (CalculateTrajectory)
			{
				CalculateVelocity();
			}
		}

		public void SetTarget(Transform target)
		{
			Target = target;
		}

		public void ClearTarget()
		{
			Target = null;
		}

		public void SetTarget(GameObject target)
		{
			Target = target.transform;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		private void Prepare_Projectile(GameObject p)
		{
			Rigidbody component2;
			if (p.TryGetComponent<IProjectile>(out var component))
			{
				component.Prepare(Owner, Gravity, Velocity, Layer, TriggerInteraction);
				component.AfterDistance = AfterDistance;
				component.SetDamageMultiplier(DamageMultiplier);
				component.Fire();
			}
			else if (p.TryGetComponent<Rigidbody>(out component2))
			{
				component2.AddForce(Velocity, ForceMode.VelocityChange);
			}
		}

		public virtual void SetDamageMultiplier(float m)
		{
			DamageMultiplier = m;
		}

		public virtual void SetScaleMultiplier(float m)
		{
			ScaleMultiplier = m;
		}

		public virtual void SetPowerMultiplier(float m)
		{
			ForceMultiplier = m;
		}

		public virtual void SetForceMultiplier(float m)
		{
			SetPowerMultiplier(m);
		}

		public virtual void SetAimerDirection(float m)
		{
			useAimerDirection.Value = m > 0.5f;
		}

		public virtual void SetAimerDirection(int m)
		{
			useAimerDirection.Value = m == 1;
		}

		public virtual void CalculateVelocity()
		{
			if ((bool)Target)
			{
				Vector3 normalized = (Target.position - AimOriginPos).normalized;
				float num = 90f - Vector3.Angle(normalized, -Gravity) + 0.1f;
				if (num < m_angle)
				{
					num = m_angle;
				}
				Power = MTools.PowerFromAngle(AimOriginPos, Target.position, num);
				Velocity = MTools.VelocityFromPower(AimOriginPos, Power, num, Target.position);
			}
			else if ((bool)Aimer && useAimerDirection.Value)
			{
				Velocity = (Aimer.AimPoint - AimOriginPos).normalized * Power;
			}
			else
			{
				Velocity = base.transform.forward.normalized * Power;
			}
			Predict?.Invoke(obj: true);
		}

		private void Reset()
		{
			m_Owner = new GameObjectReference(base.transform.FindObjectCore().gameObject);
			m_AimOrigin = base.transform;
		}
	}
}
