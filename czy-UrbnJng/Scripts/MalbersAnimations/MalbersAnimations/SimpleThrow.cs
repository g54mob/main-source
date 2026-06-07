using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Damage/Simple Throw")]
	public class SimpleThrow : MonoBehaviour, IAnimatorListener, IThrower
	{
		[Tooltip("Gameobject with a rigidbody to throw")]
		public GameObject projectile;

		[RequiredField]
		[Tooltip("Origin of the trhower")]
		public Transform throwOrigin;

		[Delayed]
		public float MinForce = 20f;

		[Delayed]
		public float MaxForce = 50f;

		[Range(0f, 1f)]
		[Tooltip("0 = Min Force, 1 = Max Force")]
		public float ForceRange = 1f;

		[SerializeField]
		private LayerReference hitLayer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[SerializeField]
		[Tooltip("Gravity to apply to the Projectile. By default is set to Physics.gravity")]
		private Vector3Reference gravity = new Vector3Reference(Physics.gravity);

		[SerializeField]
		[Tooltip("Apply Gravity after certain distance is reached")]
		private FloatReference m_AfterDistance = new FloatReference(0f);

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

		public Action<bool> Predict { get; set; } = delegate
		{
		};

		public Vector3 AimOriginPos => throwOrigin.position;

		public Transform AimOrigin => throwOrigin;

		public Vector3 Velocity => throwOrigin.forward * Mathf.Lerp(MinForce, MaxForce, ForceRange);

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

		public GameObject Owner => base.transform.gameObject;

		Transform IAnimatorListener.transform => base.transform;

		public void Throw()
		{
			Throw(projectile);
		}

		public void Fire()
		{
			Throw(projectile);
		}

		public void Throw(GameObject b)
		{
			if (b == null)
			{
				return;
			}
			projectile = b;
			GameObject gameObject = projectile;
			if (projectile.IsPrefab())
			{
				gameObject = UnityEngine.Object.Instantiate(projectile);
			}
			if ((bool)gameObject)
			{
				gameObject.transform.position = throwOrigin.position;
				gameObject.transform.parent = null;
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				Collider component2 = gameObject.GetComponent<Collider>();
				if ((bool)component2)
				{
					component2.enabled = true;
					component2.isTrigger = false;
				}
				if ((bool)component)
				{
					component.isKinematic = false;
					component.AddForce(Velocity, ForceMode.VelocityChange);
				}
				if (!projectile.IsPrefab())
				{
					projectile = null;
				}
			}
			Predict(obj: false);
		}

		public void SetForceRange(float value)
		{
			ForceRange = Mathf.Clamp01(value);
			if ((bool)projectile)
			{
				Predict(obj: true);
			}
		}

		public void SetProjectile(GameObject b)
		{
			projectile = b;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		private void OnValidate()
		{
			MinForce = Mathf.Min(MinForce, MaxForce);
		}
	}
}
