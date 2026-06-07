namespace JWT.Algorithms
{
	public abstract class JwtAlgorithmFactory : IAlgorithmFactory
	{
		public virtual IJwtAlgorithm Create(JwtDecoderContext context)
		{
			return null;
		}

		protected abstract IJwtAlgorithm Create(JwtAlgorithmName algorithm);
	}
}
