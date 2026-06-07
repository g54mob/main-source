using System.Collections.Generic;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations
{
	[DefaultExecutionOrder(1000)]
	[AddComponentMenu("Malbers/Damage/Explosion Force")]
	public class MExplosion : MDamager
	{
		[Tooltip("The Explosion will happen on Start ")]
		public bool ExplodeOnStart;

		[Tooltip("Value needed for the AddExplosionForce method default = 0 ")]
		public float upwardsModifier;

		[Tooltip("Radius of the Explosion")]
		public float radius = 10f;

		[Tooltip("Life of the explosion, after this time has elapsed the Explosion gameobject will be destroyed ")]
		public float life = 10f;

		public int ColliderSize = 50;

		public AnimationCurve DamageCurve = new AnimationCurve(MTools.DefaultCurveLinearInverse);

		[HideInInspector]
		public int Editor_Tabs1;

		private Collider[] colliders;

		private void Start()
		{
			colliders = new Collider[ColliderSize];
			if (ExplodeOnStart)
			{
				Explode();
			}
		}

		public virtual void Explode()
		{
			Physics.OverlapSphereNonAlloc(base.transform.position, radius, colliders, base.Layer, triggerInteraction);
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < colliders.Length; i++)
			{
				Collider collider = colliders[i];
				if (collider == null)
				{
					return;
				}
				if ((bool)dontHitOwner && (bool)Owner && collider.transform.IsChildOf(Owner.transform))
				{
					continue;
				}
				Rigidbody attachedRigidbody = collider.attachedRigidbody;
				GameObject gameObject = collider.transform.FindObjectCore().gameObject;
				if (gameObject.layer != collider.gameObject.layer)
				{
					gameObject = MTools.FindRealParentByLayer(collider.transform);
				}
				if (!list.Contains(gameObject))
				{
					float num = Vector3.Distance(base.transform.position, collider.bounds.center);
					float num2 = DamageCurve.Evaluate(num / radius);
					if (attachedRigidbody != null && attachedRigidbody.useGravity)
					{
						collider.attachedRigidbody.AddExplosionForce(Force * num2, base.transform.position, radius, upwardsModifier, forceMode);
					}
					Debugging("Apply Explosion", collider);
					list.Add(gameObject);
					if (statModifier.ID != null)
					{
						StatModifier stat = new StatModifier(statModifier)
						{
							Value = statModifier.Value * num2
						};
						TryDamage(collider.gameObject, stat);
						TryInteract(collider.gameObject);
					}
				}
				collider = null;
			}
			Object.Destroy(base.gameObject, life);
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, radius);
		}
	}
}
