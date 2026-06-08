using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex10_StaticMethods : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }");
			scriptType.CallStatic("ExampleMethod", "World");
			scriptType.SafeCallStatic("ExampleMethod", "Safe World");
		}
	}
}
