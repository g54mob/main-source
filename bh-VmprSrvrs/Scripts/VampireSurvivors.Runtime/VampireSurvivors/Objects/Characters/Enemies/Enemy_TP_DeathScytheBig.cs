using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_DeathScytheBig : EnemyController
	{
		private float _chaseTimer;

		private bool _hasHit;

		private bool _startedSwing;

		private MultiTargetTween _warningTween;

		private MultiTargetTween _swingTween;

		private MultiTargetTween _swingFadeATween;

		private MultiTargetTween _swingFadeBTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private CharacterController FindBestPlayerTarget()
		{
			return null;
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		public void Cleanup()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		private float2 SwingTargetPos()
		{
			return default(float2);
		}

		private void DoSwing()
		{
		}

		private void SingleWarning(float2 position)
		{
		}

		private bool DoHit(CharacterController player)
		{
			return false;
		}

		public override void OnPlayerOverlap(CharacterController player)
		{
		}

		private void SummonDirecter()
		{
		}

		private void RemoveAllWeaponsFromEachPlayer()
		{
		}

		private void GiveEveryoneWhipsBecauseWhyNot()
		{
		}

		private void RemoveAllFollowers()
		{
		}

		private void KillAndUseUpRevivals()
		{
		}

		private void KillAndDirecterRevives()
		{
		}

		private void BlockByDirecter()
		{
		}
	}
}
