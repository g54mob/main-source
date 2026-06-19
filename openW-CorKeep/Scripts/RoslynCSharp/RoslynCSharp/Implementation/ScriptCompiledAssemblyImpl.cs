using System;
using RoslynCSharp.Compiler;
using Trivial.CodeSecurity;

namespace RoslynCSharp.Implementation
{
	internal class ScriptCompiledAssemblyImpl : ScriptAssemblyImpl, IScriptCompiledAssembly
	{
		private CompilationResult result;

		private DateTime compiledTime = DateTime.MinValue;

		public override CompilationResult CompileResult => result;

		public override string AssemblyPath => result.OutputFile;

		public override byte[] AssemblyImage => result.OutputAssemblyImage;

		public override bool IsRuntimeCompiled => true;

		public override DateTime RuntimeCompiledTime => compiledTime;

		public void MarkAsRuntimeCompiled(CompilationResult compileResult)
		{
			result = compileResult;
			compiledTime = DateTime.Now;
		}

		protected override CodeSecurityEngine CreateSecurityEngine()
		{
			if (!result.Success)
			{
				return null;
			}
			if (result.OutputAssemblyImage != null)
			{
				return new CodeSecurityEngine(result.OutputAssemblyImage, result.OutputPDBImage);
			}
			if (result.OutputFile != null)
			{
				return new CodeSecurityEngine(result.OutputFile);
			}
			if (result.OutputAssembly != null)
			{
				return new CodeSecurityEngine(result.OutputAssembly.Location);
			}
			return null;
		}
	}
}
