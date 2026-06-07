using Coherence.Connection;

namespace Coherence.Core
{
	public struct InteropNetworkConditions
	{
		public float SendDelaySec;

		public float SendDropRate;

		public float ReceiveDelaySec;

		public float ReceiveDropRate;

		public InteropNetworkConditions(Condition condition)
		{
			SendDelaySec = 0f;
			SendDropRate = 0f;
			ReceiveDelaySec = 0f;
			ReceiveDropRate = 0f;
		}
	}
}
