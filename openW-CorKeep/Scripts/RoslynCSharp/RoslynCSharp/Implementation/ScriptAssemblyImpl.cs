using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using RoslynCSharp.Compiler;

namespace RoslynCSharp.Implementation
{
	internal class ScriptAssemblyImpl : ScriptAssembly
	{
		private ScriptDomain domain;

		private Assembly systemAssembly;

		public override ScriptDomain Domain => domain;

		public override Assembly SystemAssembly => systemAssembly;

		public override MetadataReference CompilerReference
		{
			get
			{
				if (AssemblyImage != null)
				{
					return AssemblyReference.FromImage(AssemblyImage).CompilerReference;
				}
				return AssemblyReference.FromNameOrFile(AssemblyPath).CompilerReference;
			}
		}

		public override bool IsRuntimeCompiled => false;

		public override DateTime RuntimeCompiledTime => DateTime.MinValue;

		public override CompilationResult CompileResult => null;

		protected override void ConstructInstance(ScriptDomain domain, Assembly systemAssembly)
		{
			this.domain = domain;
			this.systemAssembly = systemAssembly;
			if (!string.IsNullOrEmpty(systemAssembly.Location) && File.Exists(systemAssembly.Location))
			{
				assemblyImage = File.ReadAllBytes(systemAssembly.Location);
			}
		}

		protected override ScriptType CreateRootScriptType(Type systemType)
		{
			return ScriptType.CreateScriptType<ScriptTypeImpl>(this, null, systemType);
		}
	}
}
