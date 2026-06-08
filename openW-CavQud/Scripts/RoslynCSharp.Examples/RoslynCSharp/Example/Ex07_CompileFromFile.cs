using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex07_CompileFromFile : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceFile = "path/to/source/file.cs";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			domain.CompileAndLoadFile("path/to/source/file.cs");
			if (domain.CompileResult.Success)
			{
				return;
			}
			CompilationError[] errors = domain.CompileResult.Errors;
			foreach (CompilationError compilationError in errors)
			{
				if (compilationError.IsError)
				{
					Debug.LogError(compilationError.ToString());
				}
				else if (compilationError.IsWarning)
				{
					Debug.LogWarning(compilationError.ToString());
				}
			}
		}
	}
}
