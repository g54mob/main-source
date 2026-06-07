namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class SimpleLookupTable : AbstractECLookupTable
	{
		private readonly ECPoint[] points;

		public override int Size => 0;

		private static ECPoint[] Copy(ECPoint[] points, int off, int len)
		{
			return null;
		}

		public SimpleLookupTable(ECPoint[] points, int off, int len)
		{
		}

		public override ECPoint Lookup(int index)
		{
			return null;
		}

		public override ECPoint LookupVar(int index)
		{
			return null;
		}
	}
}
