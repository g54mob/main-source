using System;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class CreateSpeedrunCompletedPopup : StartOfNightSystem
	{
		protected override async void OnUpdate()
		{
			if (!Require<CSpeedrun>(out var comp) || !Require<SDay>(out var comp2) || comp2.Day != 15 || !Require<SSpeedrunDuration>(out var comp3))
			{
				return;
			}
			int year = comp.Year;
			int week = comp.Week;
			(int, int) tuple = SpeedrunHelpers.CurrentLeaderboardYearAndWeek();
			int now_year = tuple.Item1;
			int now_week = tuple.Item2;
			bool is_still_valid = now_week == week && now_year == year;
			SpeedrunScore score = SpeedrunScore.FromSeconds(comp3.Seconds);
			var (previous_best, ok) = await SpeedrunHelpers.GetScore(base.EntityManager, year, week, skip_percentile: true);
			if (is_still_valid || Has<SIsDebugSpeedrun>())
			{
				await SpeedrunHelpers.SubmitScore(base.EntityManager, now_year, now_week, score);
			}
			try
			{
				base.PopupUtilities.RequestManagedPopup(PopupType.SpeedrunCompleted, new CPopupSpeedrunCompleted
				{
					ThisRunMilliseconds = score.Milliseconds,
					PreviousBestMilliseconds = (ok ? previous_best.DurationMilliseconds : 0)
				});
			}
			catch (ObjectDisposedException)
			{
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
