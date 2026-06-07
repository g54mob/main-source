using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.JPake
{
	public class JPakeRound2Payload
	{
		private readonly string participantId;

		private readonly BigInteger a;

		private readonly BigInteger[] knowledgeProofForX2s;

		public virtual string ParticipantId => null;

		public virtual BigInteger A => null;

		public virtual BigInteger[] KnowledgeProofForX2s => null;

		public JPakeRound2Payload(string participantId, BigInteger a, BigInteger[] knowledgeProofForX2s)
		{
		}
	}
}
