namespace Coherence.Core
{
	internal struct CoherenceContextInitResult
	{
		public unsafe CoherenceContext* Context;

		public CoherenceContextInitError ErrorCode;
	}
}
