using System;
using I2.Loc;

namespace TH20
{
	public class SubGoalCompleteMarketingCampaign : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionMarketingCampaignComplete _definition;

		private bool _complete;

		private int _numCompleted;

		public SubGoalCompleteMarketingCampaign(Objective owner, SubGoalDefinitionMarketingCampaignComplete definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionMarketingCampaignComplete;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionMarketingCampaignComplete)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				MarketingManager marketingManager = Level.MarketingManager;
				marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			}
		}

		protected override void OnStart()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			MarketingManager marketingManager = Level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			base.OnEnd();
		}

		private void OnCampaignEnded(MarketingCampaignComponent marketingCampaignComponent, bool cancelled)
		{
			if (!cancelled && _definition.IsValidCampaign(marketingCampaignComponent.ActiveCampaign))
			{
				_numCompleted++;
				if (_definition.NumCampaigns == 0 || _numCompleted == _definition.NumCampaigns)
				{
					_complete = true;
				}
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _complete;
		}

		public override float PercentComplete()
		{
			if (_definition.NumCampaigns != 0)
			{
				return (float)_numCompleted / (float)_definition.NumCampaigns;
			}
			return Completed() ? 1 : 0;
		}

		public override int Score()
		{
			if (_definition.NumCampaigns != 0)
			{
				return _numCompleted;
			}
			if (!Completed())
			{
				return 0;
			}
			return 1;
		}

		public override string ProgressText()
		{
			if (_definition.NumCampaigns != 0)
			{
				if (!Completed())
				{
					return $"{_numCompleted} / {_definition.NumCampaigns}";
				}
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			if (!Completed())
			{
				return "";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
