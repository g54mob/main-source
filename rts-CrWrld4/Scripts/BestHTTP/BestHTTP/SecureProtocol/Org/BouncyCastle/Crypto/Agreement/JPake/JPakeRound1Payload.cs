using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.JPake
{
	public class JPakeRound1Payload
	{
		private readonly string participantId;

		private readonly BigInteger gx1;

		private readonly BigInteger gx2;

		private readonly BigInteger[] knowledgeProofForX1;

		private readonly BigInteger[] knowledgeProofForX2;

		public virtual string ParticipantId => null;

		public virtual BigInteger Gx1 => null;

		public virtual BigInteger Gx2 => null;

		public virtual BigInteger[] KnowledgeProofForX1 => null;

		public virtual BigInteger[] KnowledgeProofForX2 => null;

		public JPakeRound1Payload(string participantId, BigInteger gx1, BigInteger gx2, BigInteger[] knowledgeProofForX1, BigInteger[] knowledgeProofForX2)
		{
		}
	}
}
