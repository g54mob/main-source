using System.Xml.Linq;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class PayloadDetachedRequirement : ContractRequirement
	{
		private PayloadRequirement _payloadRequirement;

		public PayloadDetachedRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			if (string.IsNullOrEmpty(base.Description))
			{
				base.Description = "Detach the payload";
			}
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			_payloadRequirement = GetParentRequirement<PayloadRequirement>();
			if (_payloadRequirement == null)
			{
				throw new ContractException("PayloadDetached requirement must be a descendant of a Payload requirement.");
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			PayloadRequirement payloadRequirement = _payloadRequirement;
			if (payloadRequirement == null)
			{
				return false;
			}
			return payloadRequirement.Part?.Disconnected == true;
		}
	}
}
