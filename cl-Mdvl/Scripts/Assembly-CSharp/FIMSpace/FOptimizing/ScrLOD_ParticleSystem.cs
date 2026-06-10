using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_ParticleSystem : ScrLOD_Base
	{
		[SerializeField]
		private LODI_ParticleSystem settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_ParticleSystem()
		{
			settings = new LODI_ParticleSystem();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_ParticleSystem>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_ParticleSystem scrLOD_ParticleSystem = ScriptableObject.CreateInstance<ScrLOD_ParticleSystem>();
			scrLOD_ParticleSystem.settings = settings.GetCopy() as LODI_ParticleSystem;
			return scrLOD_ParticleSystem;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			ParticleSystem particleSystem = target as ParticleSystem;
			if (!particleSystem)
			{
				particleSystem = target.GetComponentInChildren<ParticleSystem>();
			}
			if ((bool)particleSystem && !optimizer.ContainsComponent(particleSystem))
			{
				return new ScriptableLODsController(optimizer, particleSystem, -1, "Particles", this);
			}
			return null;
		}
	}
}
