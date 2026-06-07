namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public interface IDecryptorBuilderProvider
	{
		ICipherBuilder CreateDecryptorBuilder(object algorithmDetails);
	}
}
