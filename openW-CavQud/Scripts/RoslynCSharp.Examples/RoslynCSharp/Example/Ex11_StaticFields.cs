using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex11_StaticFields : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static string exampleField = \"Hello World\";\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptType scriptType = domain.CompileAndLoadMainSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            static string exampleField = \"Hello World\";\r\n        }");
			string text = (string)scriptType.FieldsStatic["exampleField"];
			Debug.Log(text == "Hello World");
			scriptType.FieldsStatic["exampleField"] = "Goodbye World";
			text = (string)scriptType.SafeFieldsStatic["exampleField"];
			scriptType.SafeFieldsStatic["exampleField"] = text;
		}
	}
}
