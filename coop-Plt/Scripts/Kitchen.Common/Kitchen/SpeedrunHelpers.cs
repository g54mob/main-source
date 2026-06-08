using System;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;
using KitchenMods;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public static class SpeedrunHelpers
	{
		public static bool IsStatsRoomUnlocked(EntityContext ctx)
		{
			if (ctx.Has<SPlayerLevel>())
			{
				return ctx.Get<SPlayerLevel>().Level >= 3;
			}
			return false;
		}

		public static string LeaderboardName(int year, int week)
		{
			return $"{year:0000}_{week:00}";
		}

		public static (int year, int week) CurrentLeaderboardYearAndWeek()
		{
			int num = Mathf.FloorToInt((float)((DateTime.UtcNow - new DateTime(2025, 1, 6, 0, 0, 0, DateTimeKind.Utc)).TotalDays / 7.0));
			EventLog.Platform.Report(PlatformEvent.CurrentLeaderboardKey, num);
			return (year: 0, week: num);
		}

		public static bool IsValidSpeedrun(SBestSpeedrun cached_run)
		{
			if (cached_run.DurationMilliseconds == 0)
			{
				return false;
			}
			(int, int) tuple = CurrentLeaderboardYearAndWeek();
			if (cached_run.Year != tuple.Item1 || cached_run.Week != tuple.Item2)
			{
				return false;
			}
			return true;
		}

		public static LeaderboardKey GetCurrentLeaderboard()
		{
			(int, int) tuple = CurrentLeaderboardYearAndWeek();
			return new LeaderboardKey(tuple.Item1, tuple.Item2);
		}

		public static async Task<bool> SubmitScore(EntityContext ctx, int year, int week, SpeedrunScore score)
		{
			if (!ctx.Require<SBestSpeedrun>(out var comp) || year != comp.Year || week != comp.Week || comp.DurationMilliseconds == 0 || score.Milliseconds < comp.DurationMilliseconds)
			{
				comp.Year = year;
				comp.Week = week;
				comp.DurationMilliseconds = score.Milliseconds;
				comp.Percentile = 1f;
				if (!ctx.RequireEntity<SBestSpeedrun>(out var comp2))
				{
					comp2 = ctx.CreateEntity();
					ctx.Add<SBestSpeedrun>(comp2);
				}
				ctx.Ensure<CPersistThroughSceneChanges>(comp2);
				ctx.Set(comp2, comp);
			}
			if (ctx.Has<SModdedRun>())
			{
				return true;
			}
			await Platform.Current.SubmitScore(new LeaderboardKey(year, week), score.Milliseconds);
			return true;
		}

		public static async Task<(SBestSpeedrun, bool)> GetScore(EntityContext ctx)
		{
			var (year, week) = CurrentLeaderboardYearAndWeek();
			return await GetScore(ctx, year, week);
		}

		public static async Task<(SBestSpeedrun, bool)> GetScore(EntityContext ctx, int year, int week, bool skip_percentile = false)
		{
			SBestSpeedrun speedrun = default(SBestSpeedrun);
			if (!ctx.Require<SBestSpeedrun>(out var comp) || comp.Year != year || comp.Week != week)
			{
				comp.DurationMilliseconds = -1;
			}
			(int, float) tuple = await Platform.Current.GetScore(new LeaderboardKey(year, week), comp.DurationMilliseconds, ModPreload.IsModded, skip_percentile);
			if (tuple.Item1 < 0)
			{
				if (ctx.Require<SBestSpeedrun>(out var comp2) && comp2.Year == year && comp2.Week == week)
				{
					return (comp2, true);
				}
				return (speedrun, false);
			}
			speedrun.Week = week;
			speedrun.Year = year;
			(speedrun.DurationMilliseconds, speedrun.Percentile) = tuple;
			return (speedrun, true);
		}
	}
}
