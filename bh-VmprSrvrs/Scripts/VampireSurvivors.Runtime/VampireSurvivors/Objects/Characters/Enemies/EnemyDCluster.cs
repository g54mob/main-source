using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDCluster : EnemyDMask
	{
		private bool _canEmitParticles;

		private MultiTargetTween _onEnterTween;

		private ParticleSystem _pfxEmitter;

		private Timer _particlesTimer;

		private float _particlesDelay;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
