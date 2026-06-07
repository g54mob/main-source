using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_GoldCount_AddPassiveSlots : CharacterSkillCard_Base
	{
		protected override int[] bonusTresholds => null;

		public SubSkillCard_GoldCount_AddPassiveSlots(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void Update()
		{
		}

		protected override void OnGoldCountReached()
		{
		}
	}
}
