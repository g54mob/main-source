namespace JWT.Algorithms
{
	public interface IAlgorithmFactory
	{
		IJwtAlgorithm Create(JwtDecoderContext context);
	}
}
