using JetBrains.Annotations;

namespace VampireSurvivors.Framework.Particles
{
	[UsedImplicitly]
	public class GravityWellConfig
	{
		public float? _x;

		public float? _y;

		public float _power;

		public float _epsilon;

		public float _gravity;

		public bool _usePauseSystem;

		public bool requiresLateUpdate;

		public bool preCacheParticles;
	}
}
