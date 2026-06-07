using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnForceImpact : NimbatusEvent
	{
		public float ForceThreshold;

		public bool ThresholdHasRange;

		[ShowIf("ThresholdHasRange", true)]
		public float ForceThresholdMin;

		[ShowIf("ThresholdHasRange", true)]
		public float ForceThresholdMax;

		public bool CustomLayers;

		[ShowIf("CustomLayers", true)]
		public LayerMask Layers;

		protected override void Subscribe()
		{
			OwnWorldObject.OnCollision += OwnWorldObject_OnCollision;
		}

		private void OwnWorldObject_OnCollision(Collision col)
		{
			if (Time.time - OwnWorldObject.StartingTime < 2f)
			{
				return;
			}
			if (ThresholdHasRange)
			{
				ForceThreshold = Random.Range(ForceThresholdMin, ForceThresholdMax);
			}
			if (!CustomLayers)
			{
				if (BaseSingleton<CollisionLayerManager>.Instance.IsLayer(BaseSingleton<CollisionLayerManager>.Instance.EnemyForceDamageLayer, col.gameObject.layer) && col.impulse.magnitude > ForceThreshold)
				{
					RaiseEvent();
				}
			}
			else if (BaseSingleton<CollisionLayerManager>.Instance.IsLayer(Layers, col.gameObject.layer) && col.impulse.magnitude > ForceThreshold)
			{
				RaiseEvent();
			}
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnCollision -= OwnWorldObject_OnCollision;
		}
	}
}
