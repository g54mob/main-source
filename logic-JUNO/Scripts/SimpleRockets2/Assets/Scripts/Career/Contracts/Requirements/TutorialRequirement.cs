using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public abstract class TutorialRequirement : ContractRequirement
	{
		public override bool DefaultListedInMenu => false;

		public override RequirementVisibilityType DefaultVisibility => RequirementVisibilityType.Hidden;

		public bool ShowStepTextImmediately { get; set; }

		public TutorialStepRequirement Step { get; private set; }

		public string StepText { get; }

		protected string Text { get; set; }

		public TutorialRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			Text = xml.GetStringAttribute("text");
			StepText = xml.GetStringAttribute("stepText");
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			Step = GetParentRequirement<TutorialStepRequirement>();
			if (Step == null)
			{
				throw new ContractException("This requirement requires a TutorialRequirement ancestor.");
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (Text != null)
			{
				ShowText(Text);
			}
			if (StepText != null)
			{
				Step.State.SetStepText(StepText);
				if (ShowStepTextImmediately)
				{
					Step.State.TutorialPanel.StepText = StepText;
				}
			}
			return true;
		}

		private void ShowText(string text)
		{
			base.FlightContext.FlightTutorialPanel.InstructionText = text;
		}
	}
}
