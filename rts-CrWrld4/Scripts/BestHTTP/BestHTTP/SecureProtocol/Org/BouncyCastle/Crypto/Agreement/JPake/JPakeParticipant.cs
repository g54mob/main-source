using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.JPake
{
	public class JPakeParticipant
	{
		public static readonly int STATE_INITIALIZED;

		public static readonly int STATE_ROUND_1_CREATED;

		public static readonly int STATE_ROUND_1_VALIDATED;

		public static readonly int STATE_ROUND_2_CREATED;

		public static readonly int STATE_ROUND_2_VALIDATED;

		public static readonly int STATE_KEY_CALCULATED;

		public static readonly int STATE_ROUND_3_CREATED;

		public static readonly int STATE_ROUND_3_VALIDATED;

		private string participantId;

		private char[] password;

		private IDigest digest;

		private readonly SecureRandom random;

		private readonly BigInteger p;

		private readonly BigInteger q;

		private readonly BigInteger g;

		private string partnerParticipantId;

		private BigInteger x1;

		private BigInteger x2;

		private BigInteger gx1;

		private BigInteger gx2;

		private BigInteger gx3;

		private BigInteger gx4;

		private BigInteger b;

		private int state;

		public virtual int State => 0;

		public JPakeParticipant(string participantId, char[] password)
		{
		}

		public JPakeParticipant(string participantId, char[] password, JPakePrimeOrderGroup group)
		{
		}

		public JPakeParticipant(string participantId, char[] password, JPakePrimeOrderGroup group, IDigest digest, SecureRandom random)
		{
		}

		public virtual JPakeRound1Payload CreateRound1PayloadToSend()
		{
			return null;
		}

		public virtual void ValidateRound1PayloadReceived(JPakeRound1Payload round1PayloadReceived)
		{
		}

		public virtual JPakeRound2Payload CreateRound2PayloadToSend()
		{
			return null;
		}

		public virtual void ValidateRound2PayloadReceived(JPakeRound2Payload round2PayloadReceived)
		{
		}

		public virtual BigInteger CalculateKeyingMaterial()
		{
			return null;
		}

		public virtual JPakeRound3Payload CreateRound3PayloadToSend(BigInteger keyingMaterial)
		{
			return null;
		}

		public virtual void ValidateRound3PayloadReceived(JPakeRound3Payload round3PayloadReceived, BigInteger keyingMaterial)
		{
		}
	}
}
