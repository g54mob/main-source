using System.Xml.Linq;

namespace Assets.Scripts.Career.Contracts.Requirements.Tutorial
{
	public class StepTextRequirement : TutorialRequirement
	{
		public StepTextRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			base.ShowStepTextImmediately = true;
		}
	}
}
