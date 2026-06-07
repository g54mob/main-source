namespace Gh.Tk
{
	public class FateDecision : NotificationDecision
	{
		public int fateSeed;

		public string fateSkill;

		public string fateSkillDifficulty;

		protected FateDecision()
		{
		}

		public FateDecision(string labelKey, string fateSkill, string fateSkillDifficulty, bool isDisabled = false, bool isHidden = false)
		{
		}
	}
}
