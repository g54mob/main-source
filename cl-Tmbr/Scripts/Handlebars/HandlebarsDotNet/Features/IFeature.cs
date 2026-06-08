namespace HandlebarsDotNet.Features
{
	public interface IFeature
	{
		void OnCompiling(ICompiledHandlebarsConfiguration configuration);

		void CompilationCompleted();
	}
}
