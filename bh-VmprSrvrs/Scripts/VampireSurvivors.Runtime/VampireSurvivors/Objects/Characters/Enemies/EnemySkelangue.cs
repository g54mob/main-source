using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySkelangue : EnemyController
	{
		private int _lives;

		private const string UndieAnimName = "Undie";

		private List<Sprite> _frames;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnDeathAnimationComplete()
		{
		}

		private void OnUndieAnimComplete()
		{
		}

		public override void Despawn()
		{
		}
	}
}
