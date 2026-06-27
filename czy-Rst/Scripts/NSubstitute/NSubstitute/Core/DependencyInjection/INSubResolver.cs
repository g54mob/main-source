namespace NSubstitute.Core.DependencyInjection
{
	public interface INSubResolver
	{
		T Resolve<T>() where T : notnull;
	}
}
