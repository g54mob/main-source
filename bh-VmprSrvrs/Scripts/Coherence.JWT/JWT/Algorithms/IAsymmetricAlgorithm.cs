namespace JWT.Algorithms
{
	public interface IAsymmetricAlgorithm : IJwtAlgorithm
	{
		bool Verify(byte[] bytesToSign, byte[] signature);
	}
}
