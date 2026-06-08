using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex12_StaticProperties : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static string exampleField = \"Hello World\";\r\n\r\n            static string ExampleProperty\r\n            {\r\n                get { return exampleField; }\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static string exampleField = \"Hello World\";\r\n\r\n            static string ExampleProperty\r\n            {\r\n                get { return exampleField; }\r\n            }\r\n        }");
			string text = (string)scriptType.PropertiesStatic["ExampleProperty"];
			Debug.Log(text == "Hello World");
			scriptType.PropertiesStatic["ExampleProperty"] = "Goodbye World";
			text = (string)scriptType.SafePropertiesStatic["ExampleProperty"];
			scriptType.SafePropertiesStatic["ExampleProperty"] = text;
		}
	}
}
