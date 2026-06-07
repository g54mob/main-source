using System;

namespace JWT.Algorithms
{
	public sealed class DelegateAlgorithmFactory : IAlgorithmFactory
	{
		private readonly Func<JwtDecoderContext, IJwtAlgorithm> _algFactory;

		public DelegateAlgorithmFactory(Func<JwtDecoderContext, IJwtAlgorithm> algFactory)
		{
		}

		public DelegateAlgorithmFactory(Func<IJwtAlgorithm> algFactory)
		{
		}

		public DelegateAlgorithmFactory(IAlgorithmFactory algFactory)
		{
		}

		public DelegateAlgorithmFactory(IJwtAlgorithm algorithm)
		{
		}

		public IJwtAlgorithm Create(JwtDecoderContext context)
		{
			return null;
		}
	}
}
