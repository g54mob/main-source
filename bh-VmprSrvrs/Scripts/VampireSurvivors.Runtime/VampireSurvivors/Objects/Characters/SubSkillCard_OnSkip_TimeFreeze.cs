using Coherence.Toolkit;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnSkip_TimeFreeze : CharacterSkillCard_Base
	{
		public SubSkillCard_OnSkip_TimeFreeze(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerLevelUpSkipped()
		{
		}

		[Command]
		public void TriggerTimeStop(long startingSimFrame)
		{
		}

		private void TimeStop()
		{
		}
	}
}
