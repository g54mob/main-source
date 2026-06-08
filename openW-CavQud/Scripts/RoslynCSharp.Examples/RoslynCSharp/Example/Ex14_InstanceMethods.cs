using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex14_InstanceMethods : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }");
			ScriptProxy scriptProxy = scriptType.CreateInstance();
			scriptProxy = scriptType.CreateInstance();
			scriptProxy.Call("ExampleMethod", "World");
			scriptProxy.SafeCall("ExampleMethod", "Safe World");
		}
	}
}
