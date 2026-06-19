using UnityEngine;

namespace Pug.UnityExtensions
{
	public class ParticleSystemHandle
	{
		public ParticleSystem particleSystem;

		public ParticleSystem.MainModule main;

		public ParticleSystem.ShapeModule shape;

		public ParticleSystem.EmissionModule emission;

		public ParticleSystemRenderer renderer;

		public static ParticleSystemHandle Create(ParticleSystem p)
		{
			return new ParticleSystemHandle
			{
				particleSystem = p,
				main = p.main,
				emission = p.emission,
				shape = p.shape,
				renderer = p.GetComponent<ParticleSystemRenderer>()
			};
		}
	}
}
