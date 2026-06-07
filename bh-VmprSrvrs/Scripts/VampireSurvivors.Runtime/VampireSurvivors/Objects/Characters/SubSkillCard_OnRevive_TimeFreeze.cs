using Coherence.Toolkit;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnRevive_TimeFreeze : CharacterSkillCard_Base
	{
		public SubSkillCard_OnRevive_TimeFreeze(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
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
