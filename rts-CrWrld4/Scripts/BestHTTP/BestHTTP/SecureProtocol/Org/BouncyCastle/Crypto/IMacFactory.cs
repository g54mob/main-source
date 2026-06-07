namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public interface IMacFactory
	{
		object AlgorithmDetails { get; }

		IStreamCalculator CreateCalculator();
	}
}
