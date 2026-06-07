using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_EnemiesCount_AddAmount : CharacterSkillCard_Base
	{
		protected override int[] bonusTresholds => null;

		public SubSkillCard_EnemiesCount_AddAmount(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void Update()
		{
		}

		protected override void OnEnemiesCountReached()
		{
		}
	}
}
