namespace RoslynCSharp.Compiler
{
	public interface IAssemblyProcessor
	{
		void OnProcessAssembly(AssemblyOutput assembly);
	}
}
