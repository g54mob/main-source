using System.IO;
using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex17_ReferenceCompiledCode : MonoBehaviour
	{
		private ScriptDomain domain;

		private const string sourceCodeA = "\r\n        using UnityEngine;\r\n        public class Example\r\n        {\r\n            public void LogToConsole(string arg)\r\n            {\r\n                Debug.Log(arg);\r\n            }\r\n        }";

		private const string sourceCodeB = "\r\n        using UnityEngine;\r\n        public class ReferenceExample\r\n        {\r\n            public static void SayHello()\r\n            {\r\n                Example refClass = new Example();\r\n                refClass.LogToConsole(\"Hello World\");\r\n            }\r\n        }";

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptAssembly scriptAssembly = domain.CompileAndLoadSource("\r\n        using UnityEngine;\r\n        public class Example\r\n        {\r\n            public void LogToConsole(string arg)\r\n            {\r\n                Debug.Log(arg);\r\n            }\r\n        }");
			domain.CompileAndLoadSource("\r\n        using UnityEngine;\r\n        public class ReferenceExample\r\n        {\r\n            public static void SayHello()\r\n            {\r\n                Example refClass = new Example();\r\n                refClass.LogToConsole(\"Hello World\");\r\n            }\r\n        }", ScriptSecurityMode.UseSettings, new IMetadataReferenceProvider[1] { scriptAssembly }).MainType.SafeCallStatic("SayHello");
			AssemblyReference.FromAssembly(typeof(object).Assembly);
			AssemblyReference.FromImage(File.ReadAllBytes("C:/Assemblies/MyAssembly.dll"));
			AssemblyReference.FromStream(File.OpenRead("C:/Assemblies/MyAssembly.dll"));
			AssemblyReference.FromNameOrFile("mscorlib");
			AssemblyReference.FromNameOrFile("C:/Assemblies/MyAssembly.dll");
		}
	}
}
