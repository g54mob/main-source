using System.Collections;
using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex08_CompileAsync : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod()\r\n            {\r\n                Debug.Log(\"Hello World\");\r\n            }\r\n        }";

		public IEnumerator Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			AsyncCompileOperation compileRequest = domain.CompileAndLoadSourceAsync("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod()\r\n            {\r\n                Debug.Log(\"Hello World\");\r\n            }\r\n        }");
			yield return compileRequest;
			if (compileRequest.IsSuccessful)
			{
				yield break;
			}
			CompilationError[] errors = compileRequest.CompileDomain.CompileResult.Errors;
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
