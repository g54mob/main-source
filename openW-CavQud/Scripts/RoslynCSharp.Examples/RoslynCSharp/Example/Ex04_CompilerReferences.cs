using System;
using System.Collections.Generic;
using System.Reflection;
using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex04_CompilerReferences : MonoBehaviour
	{
		private ScriptDomain domain;

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			if (!domain.IsCompilerServiceInitialized)
			{
				throw new InvalidOperationException("Compiler service is not initialized");
			}
			Assembly assembly = typeof(HashSet<>).Assembly;
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromAssembly(assembly));
			string assemblyNameOrFilePath = "path/to/reference/assembly.dll";
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromNameOrFile(assemblyNameOrFilePath));
		}
	}
}
