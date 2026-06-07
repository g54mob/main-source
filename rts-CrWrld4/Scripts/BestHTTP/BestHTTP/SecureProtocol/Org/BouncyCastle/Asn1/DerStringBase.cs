namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class DerStringBase : Asn1Object, IAsn1String
	{
		public abstract string GetString();

		public override string ToString()
		{
			return null;
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}
	}
}
