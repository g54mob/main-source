namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem
{
	public class PemHeader
	{
		private string name;

		private string val;

		public virtual string Name => null;

		public virtual string Value => null;

		public PemHeader(string name, string val)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		private int GetHashCode(string s)
		{
			return 0;
		}
	}
}
