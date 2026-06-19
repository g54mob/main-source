using TH20.EventAwardRemixBadge;
using TH20.EventAwardStar;

namespace TH20.Analytics
{
	[DontSave]
	public class MetagameMapAnalytics : MustCallDestroy, TH20.EventAwardStar.Interface, IGameEventCallback, TH20.EventAwardRemixBadge.Interface
	{
		private readonly Metagame _metagame;

		private readonly AnalyticsManager _analyticsManager;

		public MetagameMapAnalytics(Metagame metagame, AnalyticsManager analyticsManager)
		{
			_metagame = metagame;
			_analyticsManager = analyticsManager;
			_metagame.OnStarAwarded.Add(this);
		}

		public override void Destroy()
		{
			_metagame.OnStarAwarded.Remove(this);
			base.Destroy();
		}

		void TH20.EventAwardStar.Interface.OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			Level currentLevel = _metagame.CurrentLevel;
			if (currentLevel != null)
			{
				GameDate gameDate = currentLevel.TimelineManager.CurrentGameDate;
				GameEvent gameEvent = new GameEvent(_analyticsManager.Config.AwardStarInfo).AddLevelHeader(currentLevel).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: true).AddParam("starIndex", (int)starIndex);
				_analyticsManager.RecordEvent(gameEvent);
			}
		}

		void TH20.EventAwardRemixBadge.Interface.OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			Level currentLevel = _metagame.CurrentLevel;
			if (currentLevel != null)
			{
				GameDate gameDate = currentLevel.TimelineManager.CurrentGameDate;
				GameEvent gameEvent = new GameEvent(_analyticsManager.Config.AwardRemixBadgeInfo).AddLevelHeader(currentLevel).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: true);
				_analyticsManager.RecordEvent(gameEvent);
			}
		}
	}
}
