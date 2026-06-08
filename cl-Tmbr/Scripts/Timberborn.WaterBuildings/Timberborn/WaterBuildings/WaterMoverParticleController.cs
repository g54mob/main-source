using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.EntitySystem;
using Timberborn.Particles;
using Timberborn.TickSystem;

namespace Timberborn.WaterBuildings
{
	internal class WaterMoverParticleController : TickableComponent, IAwakableComponent, IInitializableEntity
	{
		private WaterMover _waterMover;

		private ParticlesRunner _particlesRunner;

		public void Awake()
		{
			_waterMover = GetComponent<WaterMover>();
		}

		public void InitializeEntity()
		{
			ImmutableArray<string> attachmentIds = GetComponent<WaterMoverParticleControllerSpec>().AttachmentIds;
			_particlesRunner = GetComponent<ParticlesCache>().GetParticlesRunner(attachmentIds);
		}

		public override void Tick()
		{
			if (_waterMover.CanMoveWater)
			{
				_particlesRunner.Play();
			}
			else
			{
				_particlesRunner.Stop();
			}
		}
	}
}
