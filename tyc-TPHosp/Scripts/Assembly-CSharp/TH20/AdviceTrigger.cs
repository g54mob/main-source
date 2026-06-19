using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class AdviceTrigger : IComparable<AdviceTrigger>
	{
		protected App App;

		protected Level Level;

		protected AdvisorMenu AdvisorMenu;

		protected Advisor Advisor;

		[SerializeField]
		public float CooldownSeconds;

		[FullInspector.InspectorName("Message")]
		[SerializeField]
		protected LocalisedString MessageLocalised;

		[SerializeField]
		protected Sprite MessageIcon;

		[SerializeField]
		protected float MessageLifetime;

		[SerializeField]
		protected AdvisorDisplayType DisplayType;

		public Advisor.PriorityLevel CurrentPriorityLevel { get; private set; }

		public float CooldownTimeRemaining { get; private set; }

		public int CompareTo(AdviceTrigger other)
		{
			return CurrentPriorityLevel.CompareTo(other.CurrentPriorityLevel);
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

		public virtual void OnActivatedUpdate(float deltaTime)
		{
		}

		protected virtual AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			return new AdvisorMessageDefinition
			{
				Message = MessageLocalised.Translation,
				Icon = MessageIcon,
				Duration = MessageLifetime,
				DisplayType = DisplayType,
				ShowIndefinitely = false,
				UserCanDismiss = true,
				OverrideAnimationGraph = null
			};
		}

		public abstract Advisor.PriorityLevel GetMessagePriority();

		public void DecrementCooldownTimer(float deltaTime)
		{
			CooldownTimeRemaining -= deltaTime;
		}

		public bool AreTriggerConditionsMet()
		{
			CurrentPriorityLevel = GetMessagePriority();
			return CurrentPriorityLevel != Advisor.PriorityLevel.DontShow;
		}

		public void TriggerAdvice()
		{
			if (Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.HideAll && (CurrentPriorityLevel >= Advisor.PriorityLevel.VeryHigh || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyVeryHighPriority) && (CurrentPriorityLevel >= Advisor.PriorityLevel.High || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ShowOnlyHighPriorityAndAbove) && (CurrentPriorityLevel >= Advisor.PriorityLevel.Medium || Level.UserPreferences.Game.AdvisorFilter != Preferences.GamePreferences.AdvisorFilterOption.ExcludeLowPriority))
			{
				CooldownTimeRemaining = CooldownSeconds;
				AdvisorMenu.ShowAdvisorMessage(ConstructAdvisorMessage());
			}
		}
	}
}
