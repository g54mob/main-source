using System.Collections.Generic;
using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics.Blitters;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBulletW : EnemyController
	{
		private float _elapsed;

		private float _gravity;

		private float _wave1Alpha;

		private List<Bob> _wave1Group;

		private Blitter _blitter;

		private Tween _waveTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void Dismiss()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void ProcessWiggle()
		{
		}

		private void MakeBlitter()
		{
		}

		private void UpdateBlitter()
		{
		}

		protected override void UpdateDepth()
		{
		}
	}
}
