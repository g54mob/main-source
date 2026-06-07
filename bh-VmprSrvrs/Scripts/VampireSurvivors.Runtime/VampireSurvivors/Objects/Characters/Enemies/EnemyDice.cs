using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDice : EnemyDiamond
	{
		private static WeightedStore WEIGHTEDSTORE;

		protected Vector2 _initialVelocity;

		private float _grav;

		protected override bool UseStandardLootTable => false;

		protected override float InvulDelay => 0f;

		protected override float ItemChance => 0f;

		protected override float Volume_breaking => 0f;

		protected override float Volume_gotHit => 0f;

		protected override SfxType Sfx_breaking => default(SfxType);

		protected override SfxType Sfx_gotHit => default(SfxType);

		protected override bool ChangeFramesOnHit => false;

		protected override bool DoBaseUpdate => false;

		protected override bool IsImmovable => false;

		protected virtual bool IsAxe => false;

		protected virtual bool IsSnake => false;

		protected virtual uint[] TintProgression => null;

		protected override string _textureName => null;

		protected override string DefaultFrame => null;

		protected override string[] AvailableFrames => null;

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		public override void OnSpawnDone()
		{
		}

		protected virtual void OnHit_ChangeSprite()
		{
		}

		protected virtual void OnHit_ChangeTint()
		{
		}

		protected override void ChangeFrame()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void CustomLoot()
		{
		}

		private void AxeUpdate()
		{
		}

		private void SnakeUpdate()
		{
		}
	}
}
