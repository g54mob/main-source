using System;

namespace TH20
{
	public abstract class AdvisorTrigger : IComparable<AdvisorTrigger>
	{
		[DontSave]
		protected App App;

		[DontSave]
		protected Level Level;

		[DontSave]
		protected AdvisorMenu AdvisorMenu;

		[DontSave]
		protected Advisor Advisor;

		private readonly AdvisorTriggerDefinition _definition;

		public Advisor.PriorityLevel Priority { get; private set; }

		public float CooldownTimeRemaining { get; private set; }

		protected AdvisorTrigger(AdvisorTriggerDefinition definition)
		{
			_definition = definition;
		}

		public virtual void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			App = app;
			Level = level;
			Advisor = advisor;
			AdvisorMenu = advisorMenu;
		}

		public virtual void OnUnregister()
		{
		}

		protected abstract Advisor.PriorityLevel GetMessagePriority();

		protected virtual AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			return new AdvisorMessageDefinition
			{
				Message = (_definition.MessageLocalised.IsNull() ? string.Empty : _definition.MessageLocalised.Translation),
				Icon = _definition.MessageIcon,
				Duration = _definition.MessageLifetime,
				DisplayType = _definition.DisplayType,
				ShowIndefinitely = false,
				UserCanDismiss = true,
				OverrideAnimationGraph = null,
				FeatureRequired = _definition.FeatureRequired
			};
		}

		public void DecrementCooldownTimer(float deltaTime)
		{
			CooldownTimeRemaining -= deltaTime;
		}

		public bool AreTriggerConditionsMet()
		{
			Priority = GetMessagePriority();
			return Priority != Advisor.PriorityLevel.DontShow;
		}

		public void TriggerAdvice()
		{
			if (Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.HideAll && (Priority <= Advisor.PriorityLevel.VeryHigh || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyVeryHighPriority) && (Priority <= Advisor.PriorityLevel.High || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyHighPriorityAndAbove) && (Priority <= Advisor.PriorityLevel.Medium || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ExcludeLowPriority))
			{
				CooldownTimeRemaining = _definition.CooldownSeconds;
				AdvisorMenu.ShowAdvisorMessage(ConstructAdvisorMessage());
			}
		}

		public int CompareTo(AdvisorTrigger other)
		{
			return Priority.CompareTo(other.Priority);
		}
	}
}
