using System;

namespace Coherence.Connection
{
	[Serializable]
	public struct Condition
	{
		public float sendDelaySec;

		public float sendDropRate;

		public float receiveDelaySec;

		public float receiveDropRate;

		public float sendDuplicateRateSec;

		public float packetTamperRate;

		public float tamperRate;

		public float tamperStart;

		public float tamperStartDeviation;
	}
}
