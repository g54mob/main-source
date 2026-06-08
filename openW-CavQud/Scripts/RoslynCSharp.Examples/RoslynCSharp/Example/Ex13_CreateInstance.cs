using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex13_CreateInstance : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCode = "\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            public Example() { }\r\n\r\n            public Example(string arg)\r\n            {\r\n                Debug.Log(\"Example_ctor: \" + arg);\r\n            }\r\n        }\r\n\r\n        class ExampleBehaviour : MonoBehaviour\r\n        {\r\n            void Start()\r\n            {\r\n                Debug.Log(\"ExampleBehaviour: Start\");\r\n            }\r\n        }\r\n\r\n        class ExampleScriptable : ScriptableObject\r\n        {\r\n            void OnEnable()\r\n            {\r\n                Debug.Log(\"ExampleScriptable: OnEnable\");\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptAssembly scriptAssembly = domain.CompileAndLoadSource("\r\n        using UnityEngine;\r\n        class Example\r\n        {\r\n            public Example() { }\r\n\r\n            public Example(string arg)\r\n            {\r\n                Debug.Log(\"Example_ctor: \" + arg);\r\n            }\r\n        }\r\n\r\n        class ExampleBehaviour : MonoBehaviour\r\n        {\r\n            void Start()\r\n            {\r\n                Debug.Log(\"ExampleBehaviour: Start\");\r\n            }\r\n        }\r\n\r\n        class ExampleScriptable : ScriptableObject\r\n        {\r\n            void OnEnable()\r\n            {\r\n                Debug.Log(\"ExampleScriptable: OnEnable\");\r\n            }\r\n        }");
			ScriptType scriptType = scriptAssembly.FindType("Example");
			ScriptType scriptType2 = scriptAssembly.FindSubTypeOf<MonoBehaviour>("ExampleBehaviour");
			ScriptType scriptType3 = scriptAssembly.FindSubTypeOf<ScriptableObject>("ExampleScriptable");
			scriptType.CreateInstance();
			scriptType.CreateInstance(null, "Hello World");
			ScriptProxy scriptProxy = scriptType2.CreateInstance(base.gameObject);
			Debug.Log(scriptProxy.IsMonoBehaviour);
			Debug.Log(scriptProxy.IsUnityObject);
			scriptType3.CreateInstance();
			Debug.Log(scriptType3.IsScriptableObject);
			Debug.Log(scriptType3.IsUnityObject);
		}
	}
}
