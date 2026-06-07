namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public abstract class X9ECParametersHolder
	{
		private X9ECParameters parameters;

		public X9ECParameters Parameters => null;

		protected abstract X9ECParameters CreateParameters();
	}
}
