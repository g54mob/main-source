using Coherence;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Items
{
	public class PickupMerchant : NetworkPickup
	{
		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		protected override bool UsesOrderedCommand => false;

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public void RunAway(Vector2 velocity)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void UpdateDepth()
		{
		}

		public override void GetTaken()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestMerchantTake(CoherenceSync openingPlayer)
		{
		}

		[Command]
		public void PerformMerchantTake(long startingSimFrame, CoherenceSync openingPlayer, byte[] serializedWeapons, byte[] serializedItems)
		{
		}

		public override void GetOnlineTaken()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
