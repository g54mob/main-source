using System;
using JetBrains.Annotations;
using MessagePipe;
using ObservableCollections;
using R3;

public static class AchievementTracker
{
	[MustDisposeResource]
	public static IDisposable StartTracking(AchievementContext ctx)
	{
		switch (ctx.Data.ID)
		{
		case Achievement.SomethingBig:
			return ctx.State.Metrics.Releases.CombineLatest(ctx.State.Game.Launched, (int x, bool y) => y ? x : 0).TrackAchievementProgress(ctx);
		case Achievement.SequelTime:
			return EventHub.Scene.Subscribe(delegate
			{
				ctx.Achievements.Unlock(ctx.Data);
			}, Array.Empty<MessageHandlerFilter<Prestiged>>());
		case Achievement.ExpansiveCatalogue:
			return ctx.State.Metrics.Releases.TrackAchievementProgress(ctx);
		case Achievement.MillionDollarMMO:
			return ctx.State.Resources.MoneyLifetime.TrackAchievementProgress(ctx);
		case Achievement.MillionDollarStudio:
			return ctx.State.Metrics.MoneyLifetime.TrackAchievementProgress(ctx);
		case Achievement.ScalingInfrastructure:
			return ctx.State.Resources.Nodes.TrackAchievementProgress(ctx);
		case Achievement.GameMarketing:
			return ctx.State.Metrics.MarketingBlastTotalTime.TrackAchievementProgress(ctx);
		case Achievement.OutstandingCredit:
			return EventHub.Scene.Subscribe(OutstandingCreditCheck, Array.Empty<MessageHandlerFilter<OperationFinished>>());
		case Achievement.Entomophagy:
			return ctx.State.Metrics.BugsSquashed.TrackAchievementProgress(ctx);
		case Achievement.AutomatedDebugging:
			return ctx.State.Metrics.BugsStagedAuto.TrackAchievementProgress(ctx);
		case Achievement.Outsourcing:
		case Achievement.EngineeringDepartment:
		case Achievement.ChiefOfStaff:
			return Database.Derived.TotalEngineers.TrackAchievementProgress(ctx);
		case Achievement.DegradedReprovision:
			return ctx.State.Metrics.DatacenterReprovisionedFromDegraded.TrackAchievementProgress(ctx);
		case Achievement.CriticalReprovision:
			return ctx.State.Metrics.DatacenterReprovisionedFromCritical.TrackAchievementProgress(ctx);
		case Achievement.WorldDomination:
			return TrackConstructedDatacenters(ctx);
		case Achievement.DataHoarder:
			return ctx.State.Prestige.Data.TrackAchievementProgress(ctx);
		case Achievement.LoyalAudience:
		case Achievement.CoreAudience:
			return ctx.State.Prestige.Fans.TrackAchievementProgress(ctx);
		case Achievement.Auctioneer:
			return EventHub.Scene.Subscribe(delegate
			{
				ctx.Achievements.Unlock(ctx.Data);
			}, Array.Empty<MessageHandlerFilter<SoldLootItem>>());
		case Achievement.ICanStopAnytime:
			return ctx.State.Metrics.LootchestsOpened.TrackAchievementProgress(ctx);
		case Achievement.BombdusterEasy:
			return ctx.State.Metrics.BombdusterEasyWins.TrackAchievementProgress(ctx);
		case Achievement.BombdusterAdvanced:
			return ctx.State.Metrics.BombdusterAdvancedWins.TrackAchievementProgress(ctx);
		case Achievement.BombdusterExpert:
			return ctx.State.Metrics.BombdusterExpertWins.TrackAchievementProgress(ctx);
		case Achievement.Reinvestment:
			return ctx.State.Metrics.MoneySpendUpgrades.TrackAchievementProgress(ctx);
		case Achievement.FullyUpgraded:
			return EventHub.Scene.Subscribe(delegate
			{
				CheckTotalBought(Achievement.FullyUpgraded, Database.State.Upgrades.Unlocked.Count, CatalogProvider.Upgrades.Count);
			}, Array.Empty<MessageHandlerFilter<UpgradeBought>>());
		case Achievement.FullyResearched:
			return EventHub.Scene.Subscribe(delegate
			{
				CheckTotalBought(Achievement.FullyResearched, Database.State.Research.Unlocked.Count, CatalogProvider.Research.Count);
			}, Array.Empty<MessageHandlerFilter<ResearchBought>>());
		case Achievement.Completionist:
			return Database.State.Achievements.Unlocked.Subscribe(CompletionistCheck);
		default:
			return Disposable.Empty;
		}
	}

	private static void OutstandingCreditCheck(OperationFinished ctx)
	{
		if (ctx.Operation == Operation.LineOfCredit)
		{
			Database.Commands.Achievements.Unlock(Achievement.OutstandingCredit);
		}
	}

	private static void CompletionistCheck(int achievements)
	{
		if (achievements >= CatalogProvider.Achievements.Count - 1)
		{
			Database.Commands.Achievements.Unlock(Achievement.Completionist);
		}
	}

	private static IDisposable TrackConstructedDatacenters(AchievementContext ctx)
	{
		return Observable.Merge<Unit>(from _ in ctx.State.Datacenters.Details.ObserveCountChanged()
			select Unit.Default, ctx.State.Datacenters.StateChanged.Select((Datacenter _) => Unit.Default)).Prepend(Unit.Default).Select(ctx.State.Datacenters, (Unit _, DatabaseState.DatacentersState state) => state.GetConstructedDatacenters())
			.TrackAchievementProgress(ctx);
	}

	private static IDisposable TrackAchievementProgress(this Observable<int> source, AchievementContext ctx)
	{
		return source.AsDouble().TrackAchievementProgress(ctx);
	}

	private static IDisposable TrackAchievementProgress(this Observable<float> source, AchievementContext ctx)
	{
		return source.AsDouble().TrackAchievementProgress(ctx);
	}

	private static IDisposable TrackAchievementProgress(this Observable<double> source, AchievementContext ctx)
	{
		return source.ThrottleLastHalfSecond().DistinctUntilChanged().TakeUntil(ctx.Details.Unlocked.Where((bool x) => x))
			.Subscribe(ctx, delegate(double value, AchievementContext achievementContext)
			{
				achievementContext.Achievements.SetProgress(achievementContext.Data, value);
			});
	}

	private static void CheckTotalBought(Achievement achievement, int current, int target)
	{
		if (current >= target)
		{
			Database.Commands.Achievements.Unlock(achievement);
		}
	}
}
