using System.Collections.Generic;

namespace ModApi.State
{
	public interface ICareerState
	{
		long Money { get; }

		Dictionary<int, string> GetContractNamesAndIDsForPayloadId(string payloadId);
	}
}
