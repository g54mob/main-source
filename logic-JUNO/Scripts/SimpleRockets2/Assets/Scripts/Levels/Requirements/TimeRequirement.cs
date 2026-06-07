using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class TimeRequirement : LevelRequirement
	{
		public double MaximumSeconds { get; set; }

		public TimeRequirement(ILevel level, float maximumSeconds)
			: base(level)
		{
			MaximumSeconds = maximumSeconds;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			base.DisplayValue = Units.GetRelativeTimeString(base.Level.Timer.ElapsedSeconds);
			if (base.Level.Timer.ElapsedSeconds <= MaximumSeconds)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Fail;
			}
		}

		private void UpdateName()
		{
			base.Name = "Time < " + Units.GetRelativeTimeString(MaximumSeconds);
		}
	}
}
