using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDMask : EnemyController
	{
		private MultiTargetTween _onEnterTween;

		protected bool _isInvul;

		private bool _canBreak;

		private bool _alreadyBroken;

		public bool CanBreak
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public void DisappearMask()
		{
		}

		private void BreakMask()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		public void ScriptedDisappear()
		{
		}

		public void BreakOnNextAttack(bool value)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void UpdateDepth()
		{
		}

		protected override void Die()
		{
		}
	}
}
