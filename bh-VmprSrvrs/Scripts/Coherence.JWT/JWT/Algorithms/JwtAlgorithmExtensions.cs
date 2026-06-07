namespace JWT.Algorithms
{
	public static class JwtAlgorithmExtensions
	{
		public static bool IsAsymmetric(this IJwtAlgorithm alg)
		{
			return false;
		}
	}
}
