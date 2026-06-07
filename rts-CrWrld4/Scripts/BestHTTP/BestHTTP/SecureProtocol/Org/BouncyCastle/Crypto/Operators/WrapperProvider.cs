namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	internal interface WrapperProvider
	{
		object CreateWrapper(bool forWrapping, ICipherParameters parameters);
	}
}
