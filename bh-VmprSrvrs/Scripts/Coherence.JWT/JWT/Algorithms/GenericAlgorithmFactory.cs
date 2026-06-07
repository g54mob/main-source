namespace JWT.Algorithms
{
	public sealed class GenericAlgorithmFactory<TAlgo> : IAlgorithmFactory where TAlgo : IJwtAlgorithm, new()
	{
		public IJwtAlgorithm Create(JwtDecoderContext context)
		{
			return null;
		}
	}
}
