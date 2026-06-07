using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class BypassRequirement : ContractRequirement
	{
		private ContractRequirement _bypassRequirement;

		private string _bypassRequirementId;

		public override string DisplayValue => string.Empty;

		public BypassRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_bypassRequirementId = xml.GetStringAttribute("bypassRequirementId");
			base.VisibilityType = RequirementVisibilityType.Hidden;
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			_bypassRequirement = base.Contract.GetRequirementById(_bypassRequirementId);
			if (_bypassRequirement == null)
			{
				throw new ContractException("Bypass requirement could not find requirement with ID " + _bypassRequirementId);
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_bypassRequirement.IsBypassed = true;
			return true;
		}
	}
}
