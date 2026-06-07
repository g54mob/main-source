using ModApi.Levels;

namespace Assets.Scripts.Levels.Requirements
{
	public class TutorialRequirement : LevelRequirement
	{
		public TutorialRequirement(ILevel level)
			: base(level)
		{
			base.Name = "Follows Instructions";
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			base.DisplayValue = "So far...";
		}

		private void UpdateName()
		{
		}
	}
}
