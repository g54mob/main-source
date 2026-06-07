using System;
using System.IO;
using System.Reflection;
using System.Security;
using DynamicCSharp.Compiler;
using DynamicCSharp.Security;
using UnityEngine;

namespace DynamicCSharp
{
	public class ScriptDomain
	{
		public enum HackLevel
		{
			DENY = 0,
			WARN = 1,
			ALLOW = 2
		}

		private static ScriptDomain domain;

		private AppDomain sandbox;

		private AssemblyChecker checker;

		private ScriptCompiler compilerService;

		internal static ScriptDomain Active
		{
			get
			{
				return domain;
			}
		}

		public ScriptCompiler CompilerService
		{
			get
			{
				return compilerService;
			}
		}

		private ScriptDomain(string name)
		{
			domain = this;
			sandbox = AppDomain.CurrentDomain;
			checker = new AssemblyChecker();
		}

		public ScriptAssembly LoadAssemblyFromResources(string resourcePath)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(resourcePath);
			if (textAsset == null)
			{
				throw new DllNotFoundException(string.Format("Failed to load dll from resources path '{0}'", resourcePath));
			}
			return LoadAssembly(textAsset.bytes);
		}

		public ScriptAssembly LoadAssembly(string fullPath, bool canHack)
		{
			CheckDisposed();
			if (!File.Exists(fullPath))
			{
				throw new DllNotFoundException(string.Format("Failed to load dll at '{0}'", fullPath));
			}
			byte[] data = File.ReadAllBytes(fullPath);
			byte[] symbols = null;
			if (DynamicCSharp.Settings.debugMode && File.Exists(fullPath = ".mdb"))
			{
				symbols = File.ReadAllBytes(fullPath + ".mdb");
			}
			return LoadAssembly(data, symbols, (!canHack) ? HackLevel.WARN : HackLevel.ALLOW);
		}

		public ScriptAssembly LoadAssembly(AssemblyName name)
		{
			CheckDisposed();
			Assembly rawAssembly = sandbox.Load(name);
			return new ScriptAssembly(this, rawAssembly);
		}

		public ScriptAssembly LoadAssembly(byte[] data, byte[] symbols = null, HackLevel allowHack = HackLevel.ALLOW)
		{
			CheckDisposed();
			if (DynamicCSharp.Settings.securityCheckCode)
			{
				SecurityCheckAssembly(data, allowHack, true);
			}
			Assembly assembly = null;
			assembly = ((symbols != null && DynamicCSharp.Settings.debugMode) ? sandbox.Load(data, symbols) : sandbox.Load(data));
			if (assembly == null)
			{
				return null;
			}
			return new ScriptAssembly(this, assembly);
		}

		public bool TryLoadAssembly(string fullPath, out ScriptAssembly result)
		{
			try
			{
				result = LoadAssembly(fullPath, true);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public bool TryLoadAssembly(AssemblyName name, out ScriptAssembly result)
		{
			try
			{
				result = LoadAssembly(name);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public bool TryLoadAssembly(byte[] data, out ScriptAssembly result)
		{
			try
			{
				result = LoadAssembly(data);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		public ScriptType CompileAndLoadScriptFile(string file)
		{
			CheckCompiler();
			string[] sourceFiles = new string[1] { file };
			if (!compilerService.CompileFiles(sourceFiles, Path.GetFileNameWithoutExtension(file), DynamicCSharp.Settings.assemblyReferences))
			{
				compilerService.PrintErrors();
				return null;
			}
			if (compilerService.HasWarnings)
			{
				compilerService.PrintWarnings();
			}
			ScriptAssembly scriptAssembly = LoadAssembly(compilerService.AssemblyData, compilerService.SymbolsData);
			if (scriptAssembly == null)
			{
				return null;
			}
			return scriptAssembly.MainType;
		}

		public ScriptAssembly CompileAndLoadScriptFiles(string outputName, params string[] files)
		{
			CheckCompiler();
			if (!compilerService.CompileFiles(files, outputName, DynamicCSharp.Settings.assemblyReferences))
			{
				return null;
			}
			bool hasWarning = compilerService.HasWarnings;
			return LoadAssembly(compilerService.AssemblyData, compilerService.SymbolsData, HackLevel.DENY);
		}

		public ScriptType CompileAndLoadScriptSource(string source)
		{
			CheckCompiler();
			string[] sourceContent = new string[1] { source };
			if (!compilerService.CompileSources(null, sourceContent, "Dynamic", DynamicCSharp.Settings.assemblyReferences))
			{
				return null;
			}
			bool hasWarning = compilerService.HasWarnings;
			ScriptAssembly scriptAssembly = LoadAssembly(compilerService.AssemblyData, compilerService.SymbolsData);
			if (scriptAssembly == null)
			{
				return null;
			}
			return scriptAssembly.MainType;
		}

		public ScriptAssembly CompileAndLoadScriptSources(string outputName, string[] names, string[] sources, HackLevel level)
		{
			CheckCompiler();
			if (!compilerService.CompileSources(names, sources, outputName, DynamicCSharp.Settings.assemblyReferences))
			{
				return null;
			}
			bool hasWarning = compilerService.HasWarnings;
			return LoadAssembly(compilerService.AssemblyData, compilerService.SymbolsData, level);
		}

		public AsyncCompileLoadOperation CompileAndLoadScriptFilesAsync(string outputName, params string[] files)
		{
			CheckCompiler();
			string[] references = DynamicCSharp.Settings.assemblyReferences;
			return new AsyncCompileLoadOperation(this, delegate
			{
				bool result = compilerService.CompileFiles(files, outputName, references);
				bool hasError = compilerService.HasErrors;
				bool hasWarning = compilerService.HasWarnings;
				return result;
			});
		}

		public AsyncCompileLoadOperation CompileAndLoadScriptSourcesAsync(string outputName, params string[] sources)
		{
			CheckCompiler();
			string[] references = DynamicCSharp.Settings.assemblyReferences;
			return new AsyncCompileLoadOperation(this, delegate
			{
				bool result = compilerService.CompileSources(null, sources, outputName, references);
				bool hasError = compilerService.HasErrors;
				bool hasWarning = compilerService.HasWarnings;
				return result;
			});
		}

		public bool SecurityCheckAssembly(string fullpath, HackLevel allowHack, bool throwOnError = false)
		{
			try
			{
				byte[] assemblyData = new byte[0];
				using (BinaryReader binaryReader = new BinaryReader(File.Open(fullpath, FileMode.Open)))
				{
					assemblyData = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
				}
				checker.SecurityCheckAssembly(assemblyData, allowHack);
				if (checker.HasErrors)
				{
					throw new SecurityException(checker.Errors[0].ToString());
				}
			}
			catch (Exception)
			{
				if (throwOnError)
				{
					throw;
				}
				return false;
			}
			return true;
		}

		public bool SecurityCheckAssembly(AssemblyName name, HackLevel allowHack, bool throwOnError = false)
		{
			try
			{
				byte[] assemblyData = new byte[0];
				using (BinaryReader binaryReader = new BinaryReader(File.Open(name.CodeBase, FileMode.Open)))
				{
					assemblyData = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
				}
				checker.SecurityCheckAssembly(assemblyData, allowHack);
				if (checker.HasErrors)
				{
					throw new SecurityException(checker.Errors[0].ToString());
				}
			}
			catch (Exception)
			{
				if (throwOnError)
				{
					throw;
				}
				return false;
			}
			return true;
		}

		public bool SecurityCheckAssembly(byte[] assemblyData, HackLevel allowHack, bool throwOnError = false)
		{
			try
			{
				if (assemblyData == null)
				{
					throw new ArgumentNullException("assemblyData");
				}
				checker.SecurityCheckAssembly(assemblyData, allowHack);
				if (checker.HasErrors)
				{
					throw new SecurityException(checker.Errors[0].ToString());
				}
			}
			catch (Exception)
			{
				if (throwOnError)
				{
					throw;
				}
				return false;
			}
			return true;
		}

		internal void CreateCompilerService()
		{
			compilerService = new ScriptCompiler();
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
			if (compilerService == null)
			{
				throw new Exception("The compiler service has not been initialized");
			}
		}

		public static ScriptDomain CreateDomain(string domainName, bool initCompiler)
		{
			ScriptDomain scriptDomain = new ScriptDomain("DynamicCSharp");
			if (initCompiler)
			{
				scriptDomain.CreateCompilerService();
			}
			return scriptDomain;
		}
	}
}
