using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex09_FindTypes : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example : MonoBehaviour\r\n        {\r\n            static void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptAssembly scriptAssembly = domain.CompileAndLoadSource("\r\n        using UnityEngine;\r\n        class Example : MonoBehaviour\r\n        {\r\n            static void ExampleMethod(string input)\r\n            {\r\n                Debug.Log(\"Hello \" + input);\r\n            }\r\n        }");
			bool includeNonPublic = true;
			ScriptType[] array = scriptAssembly.FindAllTypes(includeNonPublic);
			foreach (ScriptType scriptType in array)
			{
				Debug.Log("FindAllTypes: " + scriptType.FullName);
			}
			foreach (ScriptType item in scriptAssembly.EnumerateAllTypes(includeNonPublic))
			{
				Debug.Log("EnumerateAllTypes: " + item.FullName);
			}
			foreach (ScriptType item2 in scriptAssembly.EnumerateAllSubTypesOf<MonoBehaviour>(includeNonPublic))
			{
				Debug.Log("EnumerateSubTypesOf<MonoBehaviour>: " + item2.FullName);
			}
			scriptAssembly.EnumerateAllMonoBehaviourTypes(includeNonPublic);
			scriptAssembly.EnumerateAllScriptableObjectTypes(includeNonPublic);
			scriptAssembly.EnumerateAllUnityTypes(includeNonPublic);
		}
	}
}
