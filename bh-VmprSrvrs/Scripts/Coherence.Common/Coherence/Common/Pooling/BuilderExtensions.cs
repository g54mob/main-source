namespace Coherence.Common.Pooling
{
	internal static class BuilderExtensions
	{
		public static Pool<T>.PoolBuilder WithReusables<T>(this Pool<T>.PoolBuilder builder) where T : IReusable
		{
			return null;
		}
	}
}
