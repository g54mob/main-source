using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class Gost3410ParametersGenerator
	{
		private int size;

		private int typeproc;

		private SecureRandom init_random;

		public void Init(int size, int typeProcedure, SecureRandom random)
		{
		}

		private int procedure_A(int x0, int c, BigInteger[] pq, int size)
		{
			return 0;
		}

		private long procedure_Aa(long x0, long c, BigInteger[] pq, int size)
		{
			return 0L;
		}

		private void procedure_B(int x0, int c, BigInteger[] pq)
		{
		}

		private void procedure_Bb(long x0, long c, BigInteger[] pq)
		{
		}

		private BigInteger procedure_C(BigInteger p, BigInteger q)
		{
			return null;
		}

		public Gost3410Parameters GenerateParameters()
		{
			return null;
		}
	}
}
