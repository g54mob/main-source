using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex06_CompileFromSource : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod()\r\n            {\r\n                Debug.Log(\"Hello World\");\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			domain.CompileAndLoadSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod()\r\n            {\r\n                Debug.Log(\"Hello World\");\r\n            }\r\n        }");
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
