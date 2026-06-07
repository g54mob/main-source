namespace Gh.Tk.UI.Dialogs
{
	public class AchievementTrophy3DUIView : TrophyDisplay3DUIView
	{
		private Achievement _achievement;

		public void SetData(Achievement achievement, DissolveArea3DUIView dissolveMats)
		{
		}

		public Achievement GetAchievement()
		{
			return null;
		}

		protected override TooltipData CreateTooltip()
		{
			return null;
		}

		protected override Trophy3DUIView CreateTrophyInternal()
		{
			return null;
		}

		protected override TrophyPlaque3DUIView CreatePlaqueInternal()
		{
			return null;
		}

		protected override bool IsTrophyEnabled()
		{
			return false;
		}
	}
}
