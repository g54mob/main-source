using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalLaunchMarketingCampaign : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalLaunchMarketingCampaignDefinition _definition;

		private int _numLaunched;

		public SubGoalLaunchMarketingCampaign(Objective owner, SubGoalLaunchMarketingCampaignDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalLaunchMarketingCampaignDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalLaunchMarketingCampaignDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				MarketingManager marketingManager = Level.MarketingManager;
				marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}
		}

		protected override void OnStart()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			base.OnEnd();
		}

		private void OnCampaignStarted(MarketingCampaignComponent marketingCampaignComponent)
		{
			_numLaunched++;
			UpdateProgress();
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
