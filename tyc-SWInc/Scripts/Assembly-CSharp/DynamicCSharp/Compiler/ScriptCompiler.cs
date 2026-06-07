using System;
using UnityEngine;

namespace DynamicCSharp.Compiler
{
	public sealed class ScriptCompiler
	{
		private const string compilerModule = "DynamicCSharp.Compiler.McsMarshal";

		private static readonly object compilerLock = new object();

		private ICompiler compiler;

		private string[] warnings = new string[0];

		private string[] errors = new string[0];

		private byte[] assemblyData;

		private byte[] symbolsData;

		private volatile bool isCompiling;

		public static Type CompilerType
		{
			get
			{
				return typeof(ScriptCompiler).Assembly.GetType("DynamicCSharp.Compiler.McsMarshal");
			}
		}

		public string[] Warnings
		{
			get
			{
				return warnings;
			}
		}

		public bool HasWarnings
		{
			get
			{
				return warnings.Length != 0;
			}
		}

		public string[] Errors
		{
			get
			{
				return errors;
			}
		}

		public bool HasErrors
		{
			get
			{
				return errors.Length != 0;
			}
		}

		public byte[] AssemblyData
		{
			get
			{
				return assemblyData;
			}
		}

		public byte[] SymbolsData
		{
			get
			{
				return symbolsData;
			}
		}

		public bool IsCompiling
		{
			get
			{
				return isCompiling;
			}
		}

		public ScriptCompiler()
		{
			Type compilerType = CompilerType;
			if (compilerType == null)
			{
				throw new ApplicationException("Failed to load the compiler service. Make sure you have installed the compiler package for runtime script compilation. See documentation for help");
			}
			compiler = (ICompiler)Activator.CreateInstance(compilerType);
			if (compiler != null)
			{
				compiler.OutputDirectory = DynamicCSharp.Settings.compilerWorkingDirectory;
				compiler.GenerateSymbols = DynamicCSharp.Settings.debugMode;
			}
		}

		public void PrintWarnings()
		{
			string[] array = warnings;
			for (int i = 0; i < array.Length; i++)
			{
				Debug.LogWarning(array[i]);
			}
		}

		public void PrintErrors()
		{
			string[] array = errors;
			for (int i = 0; i < array.Length; i++)
			{
				Debug.LogError(array[i]);
			}
		}

		public bool CompileFiles(string[] sourceFiles, string outputName, params string[] extraReferences)
		{
			isCompiling = true;
			ResetCompiler();
			ScriptCompilerError[] array = null;
			lock (compilerLock)
			{
				compiler.AddReferences(extraReferences);
				array = compiler.CompileFiles(sourceFiles, outputName);
				assemblyData = compiler.AssemblyData;
				symbolsData = compiler.SymbolsData;
			}
			bool flag = true;
			ScriptCompilerError[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ScriptCompilerError scriptCompilerError = array2[i];
				if (scriptCompilerError.isWarning)
				{
					AddWarning(scriptCompilerError.errorCode, scriptCompilerError.errorText, scriptCompilerError.fileName, scriptCompilerError.line, scriptCompilerError.column);
					continue;
				}
				flag = false;
				AddError(scriptCompilerError.errorCode, scriptCompilerError.errorText, scriptCompilerError.fileName, scriptCompilerError.line, scriptCompilerError.column);
			}
			if (!flag)
			{
				assemblyData = null;
				symbolsData = null;
			}
			isCompiling = false;
			return flag;
		}

		public bool CompileSources(string[] names, string[] sourceContent, string outputName, params string[] extraReferences)
		{
			isCompiling = true;
			ResetCompiler();
			ScriptCompilerError[] array = null;
			lock (compilerLock)
			{
				compiler.AddReferences(extraReferences);
				array = compiler.CompileSource(names, sourceContent, outputName);
				assemblyData = compiler.AssemblyData;
				symbolsData = compiler.SymbolsData;
			}
			bool flag = true;
			ScriptCompilerError[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ScriptCompilerError scriptCompilerError = array2[i];
				if (scriptCompilerError.isWarning)
				{
					AddWarning(scriptCompilerError.errorCode, scriptCompilerError.errorText, scriptCompilerError.fileName, scriptCompilerError.line, scriptCompilerError.column);
					continue;
				}
				flag = false;
				AddError(scriptCompilerError.errorCode, scriptCompilerError.errorText, scriptCompilerError.fileName, scriptCompilerError.line, scriptCompilerError.column);
			}
			if (!flag)
			{
				assemblyData = null;
				symbolsData = null;
			}
			isCompiling = false;
			return flag;
		}

		public AsyncCompileOperation CompileFilesAsync(string[] sourceFiles, string outputName, params string[] extraReferences)
		{
			return new AsyncCompileOperation(this, () => CompileFiles(sourceFiles, outputName, extraReferences));
		}

		public AsyncCompileOperation CompileSourcesAsync(string[] sourceContent, string outputName, params string[] extraReferences)
		{
			return new AsyncCompileOperation(this, () => CompileSources(null, sourceContent, outputName, extraReferences));
		}

		private void AddWarning(string code, string message, string file, int line, int column)
		{
			string text = string.Format("[CS{0}]: {1} in {2} at [{3}, {4}]", code, message, file, line, column);
			if (line == -1 || column == -1)
			{
				text = string.Format("[CS{0}]: {1}", code, message);
			}
			Array.Resize(ref warnings, warnings.Length + 1);
			warnings[warnings.Length - 1] = text;
		}

		private void AddError(string code, string message, string file, int line, int column)
		{
			string text = string.Format("[CS{0}]: {1} in {2} at [{3}, {4}]", code, message, file, line, column);
			if (line == -1 || column == -1)
			{
				text = string.Format("[CS{0}]: {1}", code, message);
			}
			Array.Resize(ref errors, errors.Length + 1);
			errors[errors.Length - 1] = text;
		}

		private void ResetCompiler()
		{
			errors = new string[0];
			warnings = new string[0];
			assemblyData = null;
			symbolsData = null;
		}
	}
}
