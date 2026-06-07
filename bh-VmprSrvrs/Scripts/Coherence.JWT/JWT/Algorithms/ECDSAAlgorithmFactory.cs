namespace JWT.Algorithms
{
	public sealed class ECDSAAlgorithmFactory : HMACSHAAlgorithmFactory
	{
		protected override IJwtAlgorithm Create(JwtAlgorithmName algorithm)
		{
			return null;
		}
	}
}
