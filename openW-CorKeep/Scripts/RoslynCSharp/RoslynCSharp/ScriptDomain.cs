using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RoslynCSharp.Compiler;
using RoslynCSharp.Implementation;
using RoslynCSharp.Project;
using Trivial.CodeSecurity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoslynCSharp
{
	public class ScriptDomain : IDisposable
	{
		private static List<ScriptDomain> activeDomains = new List<ScriptDomain>();

		private static List<ScriptAssembly> matchedAssemblies = new List<ScriptAssembly>();

		private static ScriptDomain active = null;

		private string name;

		private AppDomain sandbox;

		private ScriptExecution execution = new ScriptExecution();

		private List<ScriptAssembly> loadedAssemblies = new List<ScriptAssembly>();

		private RoslynCSharpCompiler sharedCompiler;

		private CodeSecurityReport securityResult;

		private CompilationResult compileResult;

		public static ScriptDomain Active => active;

		public string Name
		{
			get
			{
				CheckDisposed();
				return name;
			}
		}

		public AppDomain SandboxDomain
		{
			get
			{
				CheckDisposed();
				return sandbox;
			}
		}

		public ScriptExecution Execution => execution;

		public ScriptAssembly[] Assemblies
		{
			get
			{
				CheckDisposed();
				lock (this)
				{
					return loadedAssemblies.ToArray();
				}
			}
		}

		public ScriptAssembly[] CompiledAssemblies
		{
			get
			{
				CheckDisposed();
				matchedAssemblies.Clear();
				lock (this)
				{
					foreach (ScriptAssembly loadedAssembly in loadedAssemblies)
					{
						if (loadedAssembly.IsRuntimeCompiled)
						{
							matchedAssemblies.Add(loadedAssembly);
						}
					}
				}
				return matchedAssemblies.ToArray();
			}
		}

		public IEnumerable<ScriptAssembly> EnumerateAssemblies
		{
			get
			{
				CheckDisposed();
				lock (this)
				{
					return loadedAssemblies;
				}
			}
		}

		public IEnumerable<ScriptAssembly> EnumerateCompiledAssemblies
		{
			get
			{
				CheckDisposed();
				lock (this)
				{
					foreach (ScriptAssembly loadedAssembly in loadedAssemblies)
					{
						if (loadedAssembly.IsRuntimeCompiled)
						{
							yield return loadedAssembly;
						}
					}
				}
			}
		}

		public RoslynCSharpCompiler RoslynCompilerService
		{
			get
			{
				CheckDisposed();
				return sharedCompiler;
			}
		}

		public CompilationResult CompileResult
		{
			get
			{
				CheckDisposed();
				return compileResult;
			}
		}

		public CodeSecurityReport SecurityResult => securityResult;

		public bool IsCompilerServiceInitialized
		{
			get
			{
				CheckDisposed();
				return sharedCompiler != null;
			}
		}

		public bool IsDisposed => sandbox == null;

		private ScriptDomain(string name, AppDomain sandboxDomain = null)
		{
			this.name = name;
			sandbox = sandboxDomain;
			if (sandboxDomain == null)
			{
				sandbox = AppDomain.CurrentDomain;
			}
			activeDomains.Add(this);
		}

		public ScriptAssembly LoadAssemblyFromResources(string resourcePath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			TextAsset textAsset = Resources.Load<TextAsset>(resourcePath);
			if (textAsset == null)
			{
				throw new DllNotFoundException($"Failed to load dll from resources path '{resourcePath}'");
			}
			return LoadAssembly(textAsset.bytes, securityMode);
		}

		public ScriptAssembly LoadAssembly(string fullPath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			AssemblyName assemblyName = AssemblyName.GetAssemblyName(fullPath);
			Assembly systemAssembly = sandbox.Load(assemblyName);
			return RegisterAssemblyPath(systemAssembly, securityMode, fullPath);
		}

		public ScriptAssembly LoadAssemblyWithSymbols(string assemblyPath, string symbolsPath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			byte[] rawAssembly = File.ReadAllBytes(assemblyPath);
			byte[] rawSymbolStore = File.ReadAllBytes(symbolsPath);
			Assembly systemAssembly = sandbox.Load(rawAssembly, rawSymbolStore);
			return RegisterAssemblyPath(systemAssembly, securityMode, assemblyPath, symbolsPath);
		}

		public ScriptAssembly LoadAssembly(AssemblyName name, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			Assembly systemAssembly = sandbox.Load(name);
			return RegisterAssembly(systemAssembly, securityMode);
		}

		public ScriptAssembly LoadAssembly(byte[] assemblyBytes, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			Assembly systemAssembly = sandbox.Load(assemblyBytes);
			return RegisterAssemblyImage(systemAssembly, securityMode, assemblyBytes);
		}

		public ScriptAssembly LoadAssemblyWithSymbols(byte[] assemblyBytes, byte[] symbolBytes, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			Assembly systemAssembly = sandbox.Load(assemblyBytes, symbolBytes);
			return RegisterAssemblyImage(systemAssembly, securityMode, assemblyBytes, symbolBytes);
		}

		public AsyncLoadOperation LoadAssemblyAsync(string fullPath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, fullPath, securityMode);
		}

		public AsyncLoadOperation LoadAssemblyWithSymbolsAsync(string assemblyPath, string symbolsPath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, assemblyPath, securityMode, symbolsPath);
		}

		public AsyncLoadOperation LoadAssemblyAsync(AssemblyName name, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, name, securityMode);
		}

		public AsyncLoadOperation LoadAssemblyAsync(byte[] assemblyBytes, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, assemblyBytes, securityMode);
		}

		public AsyncLoadOperation LoadAssemblyWithSymbolsAsync(byte[] assemblyBytes, byte[] symbolBytes, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, assemblyBytes, securityMode, symbolBytes);
		}

		public bool TryLoadAssembly(string fullPath, out ScriptAssembly result, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			try
			{
				result = LoadAssembly(fullPath, securityMode);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public bool TryLoadAssembly(AssemblyName name, out ScriptAssembly result, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			try
			{
				result = LoadAssembly(name, securityMode);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public bool TryLoadAssembly(byte[] data, out ScriptAssembly result, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			try
			{
				result = LoadAssembly(data, securityMode);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public ScriptType CompileAndLoadMainSource(string cSharpSource, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			ScriptAssembly scriptAssembly = CompileAndLoadSource(cSharpSource, securityMode, additionalReferenceAssemblies);
			if (scriptAssembly != null && scriptAssembly.MainType != null)
			{
				return scriptAssembly.MainType;
			}
			return null;
		}

		public ScriptType CompileAndLoadMainFile(string cSharpFile, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			ScriptAssembly scriptAssembly = CompileAndLoadFile(cSharpFile, securityMode, additionalReferenceAssemblies);
			if (scriptAssembly != null && scriptAssembly.MainType != null)
			{
				return scriptAssembly.MainType;
			}
			return null;
		}

		public ScriptType CompileAndLoadMainSyntaxTree(CSharpSyntaxTree syntaxTree, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			ScriptAssembly scriptAssembly = CompileAndLoadSyntaxTree(syntaxTree, securityMode, additionalReferenceAssemblies);
			if (scriptAssembly != null && scriptAssembly.MainType != null)
			{
				return scriptAssembly.MainType;
			}
			return null;
		}

		public ScriptAssembly CompileAndLoadSource(string cSharpSource, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromSource(cSharpSource, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadFile(string cSharpFile, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromFile(cSharpFile, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadDirectory(string directoryPath, string searchPattern = "*.cs", SearchOption searchOption = SearchOption.TopDirectoryOnly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			string[] files = Directory.GetFiles(directoryPath, searchPattern, searchOption);
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromFiles(files, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadSyntaxTree(CSharpSyntaxTree syntaxTree, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromSyntaxTree(new SyntaxTree[1] { syntaxTree }, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadSources(string[] cSharpSources, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromSources(cSharpSources, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadFiles(string[] cSharpFiles, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromFiles(cSharpFiles, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadSyntaxTrees(CSharpSyntaxTree[] syntaxTrees, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromSyntaxTree(syntaxTrees, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadCSharpProject(string cSharpProjectFile, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				CompileFromCSharpProject(cSharpProjectFile, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public ScriptAssembly CompileAndLoadCSharpProject(CSharpProject cSharpProject, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				CompileFromCSharpProject(cSharpProject, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				Assembly systemAssembly = compileResult.LoadCompiledAssembly(sandbox);
				return RegisterAssembly<ScriptCompiledAssemblyImpl>(systemAssembly, securityMode, CompileResult);
			}
		}

		public AsyncCompileOperation CompileAndLoadSourceAsync(string cSharpSource, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileSource, securityMode, new string[1] { cSharpSource }, null, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadFileAsync(string cSharpFile, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileFile, securityMode, new string[1] { cSharpFile }, null, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadSyntaxTreeAsync(CSharpSyntaxTree syntaxTree, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileSyntaxTree, securityMode, null, new CSharpSyntaxTree[1] { syntaxTree }, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadSourcesAsync(string[] cSharpSources, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileSource, securityMode, cSharpSources, null, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadFilesAsync(string[] cSharpFiles, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileFile, securityMode, cSharpFiles, null, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadSyntaxTreesAsync(CSharpSyntaxTree[] syntaxTrees, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, AsyncCompileOperation.CompileType.CompileSyntaxTree, securityMode, null, syntaxTrees, additionalReferenceAssemblies);
		}

		public void CompileFromSource(string cSharpSource, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromSource(cSharpSource, additionalReferenceAssemblies);
		}

		public void CompileFromSources(string[] cSharpSources, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromSources(cSharpSources, additionalReferenceAssemblies);
		}

		public void CompileFromFile(string cSharpFile, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromFile(cSharpFile, additionalReferenceAssemblies);
		}

		public void CompileFromFiles(string[] cSharpFiles, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromFiles(cSharpFiles, additionalReferenceAssemblies);
		}

		public void CompileFromSyntaxTree(CSharpSyntaxTree syntaxTree, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromSyntaxTree(new SyntaxTree[1] { syntaxTree }, additionalReferenceAssemblies);
		}

		public void CompileFromSyntaxTrees(CSharpSyntaxTree[] syntaxTrees, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromSyntaxTree(syntaxTrees, additionalReferenceAssemblies);
		}

		public void CompileFromCSharpProject(string cSharpProjectFile, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CSharpProjectFile project = CSharpProjectFile.ParseFile(cSharpProjectFile);
			CompileFromCSharpProject(project, additionalReferenceAssemblies);
		}

		public void CompileFromCSharpProject(CSharpProject project, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			compileResult = sharedCompiler.CompileFromFiles(project.Sources.ToArray(), project.GetMetadataReferences());
		}

		public void StaticBroadcast(string methodName)
		{
			foreach (ScriptAssembly enumerateAssembly in EnumerateAssemblies)
			{
				foreach (ScriptType item in enumerateAssembly.EnumerateAllTypes())
				{
					item.SafeCallStatic(methodName);
				}
			}
		}

		public void StaticBroadcast(string methodName, params object[] args)
		{
			foreach (ScriptAssembly enumerateAssembly in EnumerateAssemblies)
			{
				foreach (ScriptType item in enumerateAssembly.EnumerateAllTypes())
				{
					item.SafeCallStatic(methodName, args);
				}
			}
		}

		public void BroadcastActiveScene(string methodName)
		{
			Broadcast(SceneManager.GetActiveScene(), methodName);
		}

		public void BroadcastActiveScene(string methodName, params object[] args)
		{
			Broadcast(SceneManager.GetActiveScene(), methodName, args);
		}

		public void BroadcastActiveScene(Type baseType, string methodName)
		{
			Broadcast(SceneManager.GetActiveScene(), baseType, methodName);
		}

		public void BroadcastActiveScene(Type baseType, string methodName, params object[] args)
		{
			Broadcast(SceneManager.GetActiveScene(), baseType, methodName, args);
		}

		public void BroadcastAllScenes(string methodName)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Broadcast(SceneManager.GetSceneAt(i), methodName);
			}
		}

		public void BroadcastAllScenes(string methodName, params object[] args)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Broadcast(SceneManager.GetSceneAt(i), methodName, args);
			}
		}

		public void BroadcastAllScenes(Type baseType, string methodName)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Broadcast(SceneManager.GetSceneAt(i), baseType, methodName);
			}
		}

		public void BroadcastAllScenes(Type baseType, string methodName, params object[] args)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Broadcast(SceneManager.GetSceneAt(i), baseType, methodName, args);
			}
		}

		public void Broadcast(Scene targetScene, string methodName)
		{
			foreach (ScriptProxy behaviourProxy in execution.BehaviourProxies)
			{
				MonoBehaviour instanceAs = behaviourProxy.GetInstanceAs<MonoBehaviour>(throwOnError: true);
				if (targetScene.name == instanceAs.gameObject.scene.name)
				{
					behaviourProxy.SafeCall(methodName);
				}
			}
		}

		public void Broadcast(Scene targetScene, string methodName, params object[] args)
		{
			foreach (ScriptProxy behaviourProxy in execution.BehaviourProxies)
			{
				MonoBehaviour instanceAs = behaviourProxy.GetInstanceAs<MonoBehaviour>(throwOnError: true);
				if (targetScene.name == instanceAs.gameObject.scene.name)
				{
					behaviourProxy.SafeCall(methodName, args);
				}
			}
		}

		public void Broadcast(Scene targetScene, Type baseType, string methodName)
		{
			if (!typeof(MonoBehaviour).IsAssignableFrom(baseType))
			{
				return;
			}
			foreach (ScriptProxy behaviourProxy in execution.BehaviourProxies)
			{
				if (behaviourProxy.ScriptType.IsSubTypeOf(baseType))
				{
					MonoBehaviour instanceAs = behaviourProxy.GetInstanceAs<MonoBehaviour>(throwOnError: true);
					if (targetScene.name == instanceAs.gameObject.scene.name)
					{
						behaviourProxy.SafeCall(methodName);
					}
				}
			}
		}

		public void Broadcast(Scene targetScene, Type baseType, string methodName, params object[] args)
		{
			if (!typeof(MonoBehaviour).IsAssignableFrom(baseType))
			{
				return;
			}
			foreach (ScriptProxy behaviourProxy in execution.BehaviourProxies)
			{
				if (behaviourProxy.ScriptType.IsSubTypeOf(baseType))
				{
					MonoBehaviour instanceAs = behaviourProxy.GetInstanceAs<MonoBehaviour>(throwOnError: true);
					if (targetScene.name == instanceAs.gameObject.scene.name)
					{
						behaviourProxy.SafeCall(methodName, args);
					}
				}
			}
		}

		public void BroadcastInstance(Type baseType, string methodName)
		{
			foreach (ScriptProxy instanceProxy in execution.InstanceProxies)
			{
				if (instanceProxy.ScriptType.IsSubTypeOf(baseType))
				{
					instanceProxy.SafeCall(methodName);
				}
			}
		}

		public void BroadcastInstance(Type baseType, string methodName, params object[] args)
		{
			foreach (ScriptProxy instanceProxy in execution.InstanceProxies)
			{
				if (instanceProxy.ScriptType.IsSubTypeOf(baseType))
				{
					instanceProxy.SafeCall(methodName, args);
				}
			}
		}

		public void Dispose()
		{
			if (sandbox != null)
			{
				bool flag = false;
				if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor)
				{
					flag = true;
				}
				if (!sandbox.IsDefaultAppDomain() && !flag)
				{
					AppDomain.Unload(sandbox);
				}
				activeDomains.Remove(this);
				lock (this)
				{
					loadedAssemblies.Clear();
				}
				sandbox = null;
				sharedCompiler = null;
				securityResult = null;
				compileResult = null;
			}
		}

		public void InitializeCompilerService()
		{
			if (sharedCompiler == null)
			{
				sharedCompiler = new RoslynCSharpCompiler(includeDefaultReferenceAssemblies: true, generateInMemory: true, OutputKind.DynamicallyLinkedLibrary, LanguageVersion.Default, sandbox);
				ApplyCompilerServiceSettings();
			}
		}

		public void ApplyCompilerServiceSettings()
		{
			if (sharedCompiler == null)
			{
				return;
			}
			RoslynCSharp settings = RoslynCSharp.Settings;
			sharedCompiler.AllowUnsafe = settings.AllowUnsafeCode;
			sharedCompiler.AllowOptimize = settings.AllowOptimizeCode;
			sharedCompiler.AllowConcurrentCompile = settings.AllowConcurrentCompile;
			sharedCompiler.Deterministic = settings.Deterministic;
			sharedCompiler.GenerateInMemory = settings.GenerateInMemory;
			sharedCompiler.GenerateSymbols = settings.GenerateSymbols;
			sharedCompiler.WarningLevel = settings.WarningLevel;
			sharedCompiler.LanguageVersion = settings.LanguageVersion;
			sharedCompiler.TargetPlatform = settings.TargetPlatform;
			sharedCompiler.ReferenceAssemblies.Clear();
			foreach (string reference in settings.References)
			{
				sharedCompiler.ReferenceAssemblies.Add(AssemblyReference.FromNameOrFile(reference));
			}
			sharedCompiler.DefineSymbols.Clear();
			foreach (string defineSymbol in settings.DefineSymbols)
			{
				sharedCompiler.DefineSymbols.Add(defineSymbol);
			}
		}

		public void LogCompilerOutputToConsole()
		{
			if (compileResult == null)
			{
				return;
			}
			bool loggedHeader = false;
			Action action = delegate
			{
				if (!loggedHeader)
				{
					RoslynCSharp.Log("__Roslyn Compile Output__");
					loggedHeader = true;
				}
			};
			CompilationError[] errors = compileResult.Errors;
			foreach (CompilationError compilationError in errors)
			{
				if (compilationError.IsError)
				{
					action();
					RoslynCSharp.LogError(compilationError.ToString());
				}
				else if (compilationError.IsWarning)
				{
					action();
					RoslynCSharp.LogWarning(compilationError.ToString());
				}
				else if (compilationError.IsInfo)
				{
					action();
					RoslynCSharp.Log(compilationError.ToString());
				}
			}
		}

		private void CheckDisposed()
		{
			if (sandbox == null)
			{
				throw new ObjectDisposedException("The 'ScriptDomain' has already been disposed");
			}
		}

		private void CheckCompiler()
		{
			if (sharedCompiler == null)
			{
				throw new Exception("The compiler service has not been initialized");
			}
		}

		public ScriptAssembly RegisterAssembly(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, CompilationResult compileResult = null)
		{
			return RegisterAssembly<ScriptAssemblyImpl>(systemAssembly, securityMode, compileResult);
		}

		public ScriptAssembly RegisterAssembly<T>(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, CompilationResult compileResult = null) where T : ScriptAssembly, new()
		{
			if (systemAssembly == null)
			{
				return null;
			}
			string text = compileResult?.OutputFile;
			string text2 = compileResult?.OutputPDBFile;
			byte[] array = ((text != null && File.Exists(text)) ? File.ReadAllBytes(text) : null);
			byte[] assemblySymbolsImage = ((text2 != null && File.Exists(text2)) ? File.ReadAllBytes(text2) : null);
			if (text == null && array == null)
			{
				try
				{
					text = systemAssembly.Location;
				}
				catch (NotSupportedException)
				{
				}
			}
			return RegisterAssemblyImpl(ScriptAssembly.CreateScriptAssembly<T>(this, systemAssembly, text, text2, array, assemblySymbolsImage, compileResult), securityMode);
		}

		public ScriptAssembly RegisterAssemblyPath(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, string assemblyPath = null, string assemblySymbolsPath = null, CompilationResult compileResult = null)
		{
			return RegisterAssemblyPath<ScriptAssemblyImpl>(systemAssembly, securityMode, assemblyPath, assemblySymbolsPath, compileResult);
		}

		public ScriptAssembly RegisterAssemblyPath<T>(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, string assemblyPath = null, string assemblySymbolsPath = null, CompilationResult compileResult = null) where T : ScriptAssembly, new()
		{
			if (systemAssembly == null)
			{
				return null;
			}
			byte[] assemblyImage = ((assemblyPath != null && File.Exists(assemblyPath)) ? File.ReadAllBytes(assemblyPath) : null);
			byte[] assemblySymbolsImage = ((assemblySymbolsPath != null && File.Exists(assemblySymbolsPath)) ? File.ReadAllBytes(assemblySymbolsPath) : null);
			return RegisterAssemblyImpl(ScriptAssembly.CreateScriptAssembly<T>(this, systemAssembly, assemblyPath, assemblySymbolsPath, assemblyImage, assemblySymbolsImage, compileResult), securityMode);
		}

		public ScriptAssembly RegisterAssemblyImage(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, byte[] assemblyImage = null, byte[] assemblySymbolsImage = null, CompilationResult compileResult = null)
		{
			return RegisterAssemblyImage<ScriptAssemblyImpl>(systemAssembly, securityMode, assemblyImage, assemblySymbolsImage, compileResult);
		}

		public ScriptAssembly RegisterAssemblyImage<T>(Assembly systemAssembly, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, byte[] assemblyImage = null, byte[] assemblySymbolsImage = null, CompilationResult compileResult = null) where T : ScriptAssembly, new()
		{
			if (systemAssembly == null)
			{
				return null;
			}
			return RegisterAssemblyImpl(ScriptAssembly.CreateScriptAssembly<T>(this, systemAssembly, null, null, assemblyImage, assemblySymbolsImage, compileResult), securityMode);
		}

		private ScriptAssembly RegisterAssemblyImpl(ScriptAssembly scriptAssembly, ScriptSecurityMode securityMode)
		{
			bool flag = securityMode == ScriptSecurityMode.EnsureSecurity;
			if (securityMode == ScriptSecurityMode.UseSettings)
			{
				flag = RoslynCSharp.Settings.SecurityCheckCode;
			}
			if (flag)
			{
				CodeSecurityRestrictions securityRestrictions = RoslynCSharp.Settings.SecurityRestrictions;
				securityRestrictions.AllowPInvoke = RoslynCSharp.Settings.AllowPInvoke;
				if (!scriptAssembly.SecurityCheckAssembly(securityRestrictions, out securityResult))
				{
					RoslynCSharp.LogError(securityResult.GetSummaryText());
					RoslynCSharp.LogError(securityResult.GetAllText(reportAllOccurences: true));
					return null;
				}
				RoslynCSharp.Log(securityResult.GetSummaryText());
			}
			lock (this)
			{
				loadedAssemblies.Add(scriptAssembly);
				return scriptAssembly;
			}
		}

		public static ScriptDomain CreateDomain(string domainName, bool initCompiler = true, bool makeActiveDomain = true, AppDomain sandboxDomain = null)
		{
			ScriptDomain scriptDomain = new ScriptDomain(domainName, sandboxDomain);
			RoslynCSharp.LoadResources();
			if (initCompiler)
			{
				scriptDomain.InitializeCompilerService();
			}
			if (makeActiveDomain)
			{
				MakeDomainActive(scriptDomain);
			}
			return scriptDomain;
		}

		public static ScriptDomain FindDomain(string domainName)
		{
			foreach (ScriptDomain activeDomain in activeDomains)
			{
				if (activeDomain.name == domainName)
				{
					return activeDomain;
				}
			}
			return null;
		}

		public static void MakeDomainActive(ScriptDomain domain)
		{
			if (domain == null)
			{
				throw new ArgumentNullException("domain");
			}
			active = domain;
		}

		public static void MakeDomainActive(string domainName)
		{
			ScriptDomain scriptDomain = FindDomain(domainName);
			if (scriptDomain != null)
			{
				MakeDomainActive(scriptDomain);
			}
		}
	}
}
