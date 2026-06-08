using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex15_InstanceFields : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            string exampleField = \"Hello World\";\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            string exampleField = \"Hello World\";\r\n        }");
			scriptType.CreateInstance();
			ScriptProxy scriptProxy = scriptType.CreateInstance();
			string text = (string)scriptProxy.Fields["exampleField"];
			Debug.Log(text == "Hello World");
			scriptProxy.Fields["exampleField"] = "Goodbye World";
			text = (string)scriptProxy.SafeFields["exampleField"];
			scriptProxy.SafeFields["exampleField"] = text;
		}
	}
}
