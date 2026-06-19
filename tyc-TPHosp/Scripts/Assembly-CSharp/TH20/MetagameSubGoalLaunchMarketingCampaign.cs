using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameSubGoalLaunchMarketingCampaign : MetagameObjectiveSubGoal
	{
		private readonly MetagameSubGoalLaunchMarketingCampaignDefinition _definition;

		private int _numLaunched;

		public MetagameSubGoalLaunchMarketingCampaign(Objective owner, MetagameSubGoalLaunchMarketingCampaignDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(levelEventsIntermediary.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(levelEventsIntermediary.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(levelEventsIntermediary2.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(levelEventsIntermediary.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}
			base.Destroy();
		}

		private void OnCampaignStarted(MarketingCampaignComponent marketingCampaignComponent)
		{
			_numLaunched++;
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.MarketingCampaignsRun, _numLaunched);
		}

		protected override bool HasCompleted()
		{
			return _numLaunched >= _definition.NumCampaigns;
		}

		public override float PercentComplete()
		{
			return (float)_numLaunched / (float)_definition.NumCampaigns;
		}

		public override int Score()
		{
			return _numLaunched;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numLaunched} / {_definition.NumCampaigns}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
