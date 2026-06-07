using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements.Tutorial
{
	public class PauseRequirement : TutorialRequirement
	{
		private bool _value;

		public PauseRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_value = xml.GetBoolAttribute("value", defaultValue: true);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			base.Evaluate(craftNode);
			if (_value)
			{
				return base.Step.State?.SetPauseIfFailed(value: true) != null;
			}
			return base.Step.State?.SetPauseIfFailed(value: false)?.EnsureNotPaused() != null;
		}
	}
}
