using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class ServerSrpParams
	{
		protected BigInteger m_N;

		protected BigInteger m_g;

		protected BigInteger m_B;

		protected byte[] m_s;

		public virtual BigInteger B => null;

		public virtual BigInteger G => null;

		public virtual BigInteger N => null;

		public virtual byte[] S => null;

		public ServerSrpParams(BigInteger N, BigInteger g, byte[] s, BigInteger B)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static ServerSrpParams Parse(Stream input)
		{
			return null;
		}
	}
}
