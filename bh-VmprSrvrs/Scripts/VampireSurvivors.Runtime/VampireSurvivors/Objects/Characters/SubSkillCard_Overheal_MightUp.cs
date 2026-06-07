using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_Overheal_MightUp : CharacterSkillCard_Base
	{
		private float overhealTriggerValue;

		private Timer overHealTimer;

		private bool canOverheal;

		private float overhealDelay;

		public SubSkillCard_Overheal_MightUp(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		private void CharacterHealed(float value, float rawValue)
		{
		}

		protected void OnOverhealTriggered(float value, float rawValue)
		{
		}
	}
}
