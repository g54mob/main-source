using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RoslynCSharp.Compiler;
using Trivial.CodeSecurity;
using UnityEngine;

namespace RoslynCSharp
{
	public class ScriptDomain : IDisposable
	{
		private static List<ScriptDomain> activeDomains = new List<ScriptDomain>();

		private static List<ScriptAssembly> matchedAssemblies = new List<ScriptAssembly>();

		private static ScriptDomain active = null;

		private string name;

		private AppDomain sandbox;

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
			Assembly assembly = sandbox.Load(assemblyName);
			return RegisterAssembly(assembly, fullPath, null, securityMode, isRuntimeCompiled: false);
		}

		public ScriptAssembly LoadAssembly(AssemblyName name, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			Assembly assembly = sandbox.Load(name);
			return RegisterAssembly(assembly, assembly.Location, null, securityMode, isRuntimeCompiled: false);
		}

		public ScriptAssembly LoadAssembly(byte[] assemblyBytes, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			Assembly assembly = sandbox.Load(assemblyBytes);
			return RegisterAssembly(assembly, null, assemblyBytes, securityMode, isRuntimeCompiled: false);
		}

		public AsyncLoadOperation LoadAssemblyAsync(string fullPath, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings)
		{
			CheckDisposed();
			return new AsyncLoadOperation(this, fullPath, securityMode);
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

		public ScriptAssembly CompileAndLoadSource(string cSharpSource, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			lock (this)
			{
				compileResult = sharedCompiler.CompileFromSource(cSharpSource, additionalReferenceAssemblies);
				LogCompilerOutputToConsole();
				return RegisterAssembly(compileResult.OutputAssembly, compileResult.OutputFile, compileResult.OutputAssemblyImage, securityMode, isRuntimeCompiled: true, compileResult);
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
				return RegisterAssembly(compileResult.OutputAssembly, compileResult.OutputFile, compileResult.OutputAssemblyImage, securityMode, isRuntimeCompiled: true, compileResult);
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
				return RegisterAssembly(compileResult.OutputAssembly, compileResult.OutputFile, compileResult.OutputAssemblyImage, securityMode, isRuntimeCompiled: true, compileResult);
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
				return RegisterAssembly(compileResult.OutputAssembly, compileResult.OutputFile, compileResult.OutputAssemblyImage, securityMode, isRuntimeCompiled: true, compileResult);
			}
		}

		public AsyncCompileOperation CompileAndLoadSourceAsync(string cSharpSource, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, isCSharpSource: true, securityMode, new string[1] { cSharpSource }, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadFileAsync(string cSharpFile, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, isCSharpSource: false, securityMode, new string[1] { cSharpFile }, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadSourcesAsync(string[] cSharpSources, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, isCSharpSource: true, securityMode, cSharpSources, additionalReferenceAssemblies);
		}

		public AsyncCompileOperation CompileAndLoadFilesAsync(string[] cSharpFiles, ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings, IMetadataReferenceProvider[] additionalReferenceAssemblies = null)
		{
			CheckDisposed();
			CheckCompiler();
			return new AsyncCompileOperation(this, isCSharpSource: false, securityMode, cSharpFiles, additionalReferenceAssemblies);
		}

		public void Dispose()
		{
			if (sandbox != null)
			{
				if (!sandbox.IsDefaultAppDomain())
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
					loggedHeader = true;
				}
			};
			CompilationError[] errors = compileResult.Errors;
			foreach (CompilationError compilationError in errors)
			{
				if (compilationError.IsError)
				{
					action();
				}
				else if (compilationError.IsWarning)
				{
					action();
				}
				else if (compilationError.IsInfo)
				{
					action();
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

		private ScriptAssembly RegisterAssembly(Assembly assembly, string assemblyPath, byte[] assemblyImage, ScriptSecurityMode securityMode, bool isRuntimeCompiled, CompilationResult compileResult = null)
		{
			if (assembly == null)
			{
				return null;
			}
			securityResult = null;
			ScriptAssembly scriptAssembly = new ScriptAssembly(this, assembly, compileResult);
			scriptAssembly.AssemblyPath = assemblyPath;
			scriptAssembly.AssemblyImage = assemblyImage;
			bool flag = securityMode == ScriptSecurityMode.EnsureSecurity;
			if (securityMode == ScriptSecurityMode.UseSettings)
			{
				flag = RoslynCSharp.Settings.SecurityCheckCode;
			}
			if (flag && !scriptAssembly.SecurityCheckAssembly(RoslynCSharp.Settings.SecurityRestrictions, out securityResult))
			{
				return null;
			}
			if (isRuntimeCompiled)
			{
				scriptAssembly.MarkAsRuntimeCompiled();
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
