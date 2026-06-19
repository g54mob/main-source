using Microsoft.CodeAnalysis.CSharp;
using RoslynCSharp.Compiler;

namespace RoslynCSharp
{
	public sealed class AsyncCompileOperation : AsyncOperation
	{
		internal enum CompileType
		{
			CompileSource = 0,
			CompileFile = 1,
			CompileSyntaxTree = 2
		}

		private object assemblyAccessLock = new object();

		private ScriptDomain compileDomain;

		private ScriptAssembly compileResult;

		private ScriptSecurityMode securityMode;

		private bool isSecurityVerified;

		private CompileType sourceCompileType;

		private string[] sourceOrFiles;

		private CSharpSyntaxTree[] syntaxTrees;

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

		internal AsyncCompileOperation(ScriptDomain domain, CompileType compileMode, ScriptSecurityMode securityMode, string[] sourceOrFiles, CSharpSyntaxTree[] syntaxTrees, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileDomain = domain;
			sourceCompileType = compileMode;
			this.securityMode = securityMode;
			this.sourceOrFiles = sourceOrFiles;
			this.syntaxTrees = syntaxTrees;
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
				case CompileType.CompileSyntaxTree:
					scriptAssembly = ((syntaxTrees.Length != 1) ? compileDomain.CompileAndLoadSyntaxTrees(syntaxTrees, securityMode, additionalReferences) : compileDomain.CompileAndLoadSyntaxTree(syntaxTrees[0], securityMode, additionalReferences));
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
