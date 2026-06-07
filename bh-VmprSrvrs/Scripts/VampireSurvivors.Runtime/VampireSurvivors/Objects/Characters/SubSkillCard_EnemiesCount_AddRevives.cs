using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_EnemiesCount_AddRevives : CharacterSkillCard_Base
	{
		protected override int[] bonusTresholds => null;

		public SubSkillCard_EnemiesCount_AddRevives(ArcanaType type)
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
