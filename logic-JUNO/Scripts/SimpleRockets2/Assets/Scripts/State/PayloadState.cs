using System.Xml.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Contracts.Requirements;

namespace Assets.Scripts.State
{
	public class PayloadState
	{
		private IContractContext _contracts;

		public PayloadState(IContractContext contracts, XElement xml)
		{
			_contracts = contracts;
		}

		public static int GetNumPayloadsRequiredForContract(Contract contract, string payloadId)
		{
			int num = 0;
			foreach (ContractRequirement requirement in contract.Requirements)
			{
				if (requirement is ISupportsPayload supportsPayload && supportsPayload.PayloadId == payloadId)
				{
					num += supportsPayload.NumPayloadParts;
				}
			}
			return num;
		}

		public int NumPayloadsAvailableToLaunch(string payloadId)
		{
			int num = 0;
			foreach (Contract item in _contracts.Active)
			{
				num += GetNumPayloadsRequiredForContract(item, payloadId);
			}
			return num;
		}
	}
}
