using System.Xml.Linq;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class EmptyRequirement : ContractRequirement
	{
		public EmptyRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			return true;
		}
	}
}
