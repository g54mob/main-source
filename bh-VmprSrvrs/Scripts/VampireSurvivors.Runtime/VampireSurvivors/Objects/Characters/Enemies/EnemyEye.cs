using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyEye : EnemyController
	{
		private Circle _explosionCircle;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private float _totalTime;

		private const float Radius = 16f;

		private const float EmitInterval = 0.030000001f;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
