using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBeelzebubSection : EnemyController
	{
		public PhaserSprite[] _chains;

		private bool _hasExplosions;

		private List<PhaserSprite> explosionSprites;

		private float offsetRadius;

		private List<Timer> explosionTimers;

		private int ExplosionsNumber;

		private bool _isFalling;

		private float _fallTimer;

		private List<PhaserSprite> _flies;

		private float _flyMovementPhaseOffset;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		[Command]
		public void OnlineSetupSection(CoherenceSync boss, bool hasChains, string spriteName, bool isHead)
		{
		}

		public void SetupBeelzebubSection(EnemyBeelzebub parentBoss, bool hasChains, string spriteName, bool isHead)
		{
		}

		private void SetupFlies()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupExplosions()
		{
		}

		private void PlayExplosions()
		{
		}
	}
}
