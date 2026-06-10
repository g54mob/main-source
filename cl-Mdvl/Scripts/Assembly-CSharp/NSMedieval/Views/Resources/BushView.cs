using NSEipix.Base;
using NSMedieval.Scripts.Pooler;

namespace NSMedieval.Views.Resources
{
	public class BushView : PlantMapResourceView
	{
		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				if (base.transform != null && MonoSingleton<ParticleSystemPool>.IsInstantiated())
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles((!string.IsNullOrEmpty(deathParticleId)) ? deathParticleId : "shrub_destroy", base.transform.position);
				}
				base.Dispose();
			}
		}
	}
}
