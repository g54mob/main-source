using RoslynCSharp.Compiler;

namespace RoslynCSharp
{
	public interface IScriptCompiledAssembly
	{
		void MarkAsRuntimeCompiled(CompilationResult compileResult);
	}
}
