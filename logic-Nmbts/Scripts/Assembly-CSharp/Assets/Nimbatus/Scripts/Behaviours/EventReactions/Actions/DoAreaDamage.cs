using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class DoAreaDamage : CustomTransformAction
	{
		public int ExplosionRadius;

		public int ExplosionDamage;

		public int ExplosionForce;

		public EDamageReason Reason = EDamageReason.Environment;

		public bool CustomLayerMask;

		[ShowIf("CustomLayerMask", true)]
		public LayerMask LayerMask;

		public override void Execute()
		{
			Vector3 position = GetTransform().position;
			position.z = 0f;
			List<Collider> list = new List<Collider>();
			if (CustomLayerMask)
			{
				list.AddRange(Physics.OverlapSphere(position, ExplosionRadius, LayerMask));
			}
			else
			{
				list.AddRange(Physics.OverlapSphere(position, ExplosionRadius));
			}
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (item != null && item.attachedRigidbody != null && !item.isTrigger && item.gameObject != OwnWorldObject && !hashSet.Contains(item.gameObject))
				{
					item.attachedRigidbody.AddExplosionForce(ExplosionForce, position, ExplosionRadius);
					item.gameObject.SendMessage("TakeDamage", new DamageInformation(ExplosionDamage, Reason, OwnWorldObject), SendMessageOptions.DontRequireReceiver);
					hashSet.Add(item.gameObject);
				}
			}
		}
	}
}
