using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemySusBoss : EnemyController
	{
		private EnemySusBossTentacle _leftTentacle;

		private EnemySusBossTentacle _leftTentacle2;

		private EnemySusBossTentacle _rightTentacle;

		private EnemySusBossTentacle _rightTentacle2;

		private List<EnemyController> _meattList;

		private PhaserSprite[] _miniTentacles;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		private PhaserSprite CreateMiniTentacle(string type)
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void OnMeatSpawned(EnemyController enemy)
		{
		}
	}
}
