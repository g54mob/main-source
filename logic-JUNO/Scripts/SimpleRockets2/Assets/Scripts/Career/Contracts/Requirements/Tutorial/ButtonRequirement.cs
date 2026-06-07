using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements.Tutorial
{
	public class ButtonRequirement : TutorialRequirement
	{
		private bool _highlight;

		public ButtonRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_highlight = xml.GetBoolAttribute("highlight", defaultValue: true);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			base.Evaluate(craftNode);
			base.Step.TutorialPanel.EnableButton(delegate
			{
				MarkAsComplete();
			}, _highlight);
			base.Step.State.Fail();
			return false;
		}
	}
}
