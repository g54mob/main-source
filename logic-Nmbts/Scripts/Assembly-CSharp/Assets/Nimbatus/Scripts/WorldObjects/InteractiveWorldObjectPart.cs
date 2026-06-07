using System;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Combat;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects
{
	[RequireComponent(typeof(HealthPool))]
	public class InteractiveWorldObjectPart : SerializedMonoBehaviour
	{
		public bool HasExplosion;

		[ShowIf("HasExplosion", true)]
		public NimbatusParticleEffect ExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public bool HasFrozenExplosion;

		[ShowIf("HasFrozenExplosion", true)]
		public NimbatusParticleEffect FrozenExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public bool HasBurningExplosion;

		[ShowIf("HasBurningExplosion", true)]
		public NimbatusParticleEffect BurningExplosionEffect;

		[ShowIf("HasExplosion", true)]
		public Transform ExplosionTransform;

		public bool DestroyParentWhenDead;

		internal HealthPool HealthPool;

		internal InteractiveWorldObject ParentObject;

		public void Init(InteractiveWorldObject parent)
		{
			ParentObject = parent;
		}

		protected virtual void Awake()
		{
			HealthPool = GetComponent<HealthPool>();
		}

		public void OnEnable()
		{
			HealthPool.HasDied += HealthPool_HasDied;
		}

		public void OnDisable()
		{
			HealthPool.HasDied -= HealthPool_HasDied;
		}

		private void HealthPool_HasDied(object sender, EventArgs e)
		{
			if (HasExplosion)
			{
				Transform trans = ((ExplosionTransform != null) ? ExplosionTransform : base.transform);
				if (HealthPool.CurrentState == EChemicalState.Frozen && FrozenExplosionEffect != null && HasFrozenExplosion)
				{
					FrozenExplosionEffect.PlayEffect(trans);
				}
				else if (HealthPool.CurrentState == EChemicalState.Burning && BurningExplosionEffect != null && HasBurningExplosion)
				{
					BurningExplosionEffect.PlayEffect(trans);
				}
				else if (ExplosionEffect != null)
				{
					ExplosionEffect.PlayEffect(trans);
				}
			}
			ParentObject.UnregisterPart(this);
		}
	}
}
