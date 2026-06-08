using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex16_InstanceProperties : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            string exampleField = \"Hello World\";\r\n\r\n            string ExampleProperty\r\n            {\r\n                get { return exampleField; }\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            string exampleField = \"Hello World\";\r\n\r\n            string ExampleProperty\r\n            {\r\n                get { return exampleField; }\r\n            }\r\n        }");
			scriptType.CreateInstance();
			ScriptProxy scriptProxy = scriptType.CreateInstance();
			string text = (string)scriptProxy.Properties["ExampleProperty"];
			Debug.Log(text == "Hello World");
			scriptProxy.Properties["ExampleProperty"] = "Goodbye World";
			text = (string)scriptProxy.SafeProperties["ExampleProperty"];
			scriptProxy.SafeProperties["ExampleProperty"] = text;
		}
	}
}
