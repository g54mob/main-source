using System;
using Components.Particles.SingleShot;

namespace Infrastructure.Project.Registration.Native
{
	public abstract class SingleShotParticlesGroup<T> : NativeMappedPrefabsGroupHandler<T, SingleShotParticleSystem> where T : Enum
	{
	}
}
