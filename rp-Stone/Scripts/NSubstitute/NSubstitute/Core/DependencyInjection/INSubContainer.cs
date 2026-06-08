namespace NSubstitute.Core.DependencyInjection
{
	public interface INSubContainer : INSubResolver
	{
		IConfigurableNSubContainer Customize();

		INSubResolver CreateScope();
	}
}
