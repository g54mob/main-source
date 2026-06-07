using System;

namespace DV.Logic.Job
{
	[Serializable]
	public class StationsChainData
	{
		public string chainOriginYardId;

		public string chainDestinationYardId;

		public StationsChainData(string chainOriginYardId, string chainDestinationYardId)
		{
			this.chainOriginYardId = chainOriginYardId;
			this.chainDestinationYardId = chainDestinationYardId;
		}
	}
}
