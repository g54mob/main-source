namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public interface IMacDerivationFunction : IDerivationFunction
	{
		IMac GetMac();
	}
}
