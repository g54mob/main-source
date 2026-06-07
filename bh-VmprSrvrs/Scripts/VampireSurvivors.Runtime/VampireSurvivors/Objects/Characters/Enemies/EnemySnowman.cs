using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySnowman : EnemyDiamond
	{
		private static WeightedStore WEIGHTEDSTORE;

		private readonly string _defaultFrame_Default;

		private readonly string[] _availableFrames_Default;

		private readonly string _defaultFrame_XL;

		private readonly string[] _availableFrames_XL;

		protected override bool UseStandardLootTable => false;

		protected override float InvulDelay => 0f;

		protected override float ItemChance => 0f;

		protected override float Volume_breaking => 0f;

		protected override float Volume_gotHit => 0f;

		protected override SfxType Sfx_breaking => default(SfxType);

		protected override SfxType Sfx_gotHit => default(SfxType);

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void OnSpawnDone()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void CustomLoot()
		{
		}
	}
}
