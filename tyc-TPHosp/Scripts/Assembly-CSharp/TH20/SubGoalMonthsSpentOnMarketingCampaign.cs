using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalMonthsSpentOnMarketingCampaign : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionMarketingCampaignMonthsSpentOn _definition;

		private int _numMonths;

		public SubGoalMonthsSpentOnMarketingCampaign(Objective owner, SubGoalDefinitionMarketingCampaignMonthsSpentOn definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionMarketingCampaignMonthsSpentOn;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionMarketingCampaignMonthsSpentOn)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				MarketingManager marketingManager = Level.MarketingManager;
				marketingManager.OnCampaignUpdated = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignUpdated, new Action<MarketingCampaignComponent>(OnCampaignUpdated));
			}
		}

		protected override void OnStart()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignUpdated = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignUpdated, new Action<MarketingCampaignComponent>(OnCampaignUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignUpdated = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignUpdated, new Action<MarketingCampaignComponent>(OnCampaignUpdated));
			base.OnEnd();
		}

		private void OnCampaignUpdated(MarketingCampaignComponent marketingCampaignComponent)
		{
			_numMonths++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numMonths >= _definition.Months;
		}

		public override float PercentComplete()
		{
			return (float)_numMonths / (float)_definition.Months;
		}

		public override int Score()
		{
			return _numMonths;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numMonths} / {_definition.Months}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
