using System;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("GenericAction")]
	public class GenericActionRequirement : TutorialRequirement
	{
		public Action OnStepStartedAction { get; set; }

		public Func<TutorialRequirementState> OnUpdateAction { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public GenericActionRequirement()
		{
		}

		public GenericActionRequirement(Action onStepStartedAction)
		{
			OnStepStartedAction = onStepStartedAction;
		}

		public GenericActionRequirement(Func<TutorialRequirementState> onUpdateAction)
		{
			OnUpdateAction = onUpdateAction;
		}

		public GenericActionRequirement(Action onStepStartedAction, Func<TutorialRequirementState> onUpdateAction)
		{
			OnStepStartedAction = onStepStartedAction;
			OnUpdateAction = onUpdateAction;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			OnStepStartedAction?.Invoke();
		}

		protected override void GenerateXml(XElement xml)
		{
			throw new NotSupportedException("The '" + typeof(GenericActionRequirement).FullName + "' tutorial requirement does not support serialization.");
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			if (OnUpdateAction == null)
			{
				return TutorialRequirementState.RequirementMet;
			}
			return OnUpdateAction();
		}

		protected override void RestoreFromXml(XElement xml)
		{
			throw new NotSupportedException("The '" + typeof(GenericActionRequirement).FullName + "' tutorial requirement does not support serialization.");
		}
	}
}
