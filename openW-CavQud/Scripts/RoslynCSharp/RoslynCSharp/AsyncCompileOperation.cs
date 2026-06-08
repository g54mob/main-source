using RoslynCSharp.Compiler;

namespace RoslynCSharp
{
	public sealed class AsyncCompileOperation : AsyncOperation
	{
		private enum CompileType
		{
			CompileSource = 0,
			CompileFile = 1
		}

		private object assemblyAccessLock = new object();

		private ScriptDomain compileDomain;

		private ScriptAssembly compileResult;

		private ScriptSecurityMode securityMode;

		private bool isSecurityVerified;

		private CompileType sourceCompileType;

		private string[] sourceOrFiles;

		private IMetadataReferenceProvider[] additionalReferences;

		public ScriptDomain CompileDomain
		{
			get
			{
				lock (compileDomain)
				{
					return compileDomain;
				}
			}
		}

		public ScriptType CompiledType
		{
			get
			{
				lock (assemblyAccessLock)
				{
					if (compileResult == null)
					{
						return null;
					}
					return compileResult.MainType;
				}
			}
		}

		public ScriptAssembly CompiledAssembly
		{
			get
			{
				lock (assemblyAccessLock)
				{
					return compileResult;
				}
			}
		}

		public bool IsSecurityVerified => isSecurityVerified;

		internal AsyncCompileOperation(ScriptDomain domain, bool isCSharpSource, ScriptSecurityMode securityMode, string[] sourceOrFiles, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileDomain = domain;
			sourceCompileType = ((!isCSharpSource) ? CompileType.CompileFile : CompileType.CompileSource);
			this.securityMode = securityMode;
			this.sourceOrFiles = sourceOrFiles;
			additionalReferences = additionalReferenceAssemblies;
		}

		protected override void RunAsyncOperation()
		{
			ScriptAssembly scriptAssembly = null;
			lock (compileDomain)
			{
				switch (sourceCompileType)
				{
				case CompileType.CompileSource:
					scriptAssembly = ((sourceOrFiles.Length != 1) ? compileDomain.CompileAndLoadSources(sourceOrFiles, securityMode, additionalReferences) : compileDomain.CompileAndLoadSource(sourceOrFiles[0], securityMode, additionalReferences));
					break;
				case CompileType.CompileFile:
					scriptAssembly = ((sourceOrFiles.Length != 1) ? compileDomain.CompileAndLoadFiles(sourceOrFiles, securityMode, additionalReferences) : compileDomain.CompileAndLoadFile(sourceOrFiles[0], securityMode, additionalReferences));
					break;
				}
				lock (assemblyAccessLock)
				{
					compileResult = scriptAssembly;
				}
				isSuccessful = compileDomain.CompileResult.Success;
				isSecurityVerified = compileDomain.SecurityResult != null && compileDomain.SecurityResult.IsSecurityVerified;
			}
		}
	}
}
