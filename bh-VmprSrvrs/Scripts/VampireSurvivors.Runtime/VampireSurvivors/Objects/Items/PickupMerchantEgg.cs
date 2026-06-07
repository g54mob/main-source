using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items
{
	public class PickupMerchantEgg : Pickup
	{
		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
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

		private void GenerateParticleSystem()
		{
		}
	}
}
