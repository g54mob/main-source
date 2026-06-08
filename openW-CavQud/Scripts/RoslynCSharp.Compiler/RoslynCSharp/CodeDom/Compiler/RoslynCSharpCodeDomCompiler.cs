using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RoslynCSharp.Compiler;

namespace RoslynCSharp.CodeDom.Compiler
{
	public class RoslynCSharpCodeDomCompiler : ICodeCompiler
	{
		private string outputDirectory = string.Empty;

		public string OutputDirectory
		{
			get
			{
				return outputDirectory;
			}
			set
			{
				outputDirectory = value;
				if (outputDirectory == null)
				{
					outputDirectory = string.Empty;
				}
			}
		}

		public CompilerResults CompileAssemblyFromFile(CompilerParameters parameters, string fileName)
		{
			CSharpParseOptions parseOptions = GetParseOptions(parameters);
			CSharpCompilationOptions compilationOptions = GetCompilationOptions(parameters);
			SyntaxTree[] syntaxTrees = RoslynCSharpCompiler.ParseFile(fileName, parseOptions);
			string[] compilationReferences = GetCompilationReferences(parameters);
			Compilation emitObject = RoslynCSharpCompiler.CreateCompilationObject(parameters.OutputAssembly, compilationReferences, syntaxTrees, compilationOptions);
			using Stream targetStream = GetOutputStream(parameters);
			CompilationResult result = RoslynCSharpCompiler.EmitCompilationObject(emitObject, targetStream);
			return GetCompilerResults(result);
		}

		public CompilerResults CompileAssemblyFromFileBatch(CompilerParameters parameters, string[] fileNames)
		{
			CSharpParseOptions parseOptions = GetParseOptions(parameters);
			CSharpCompilationOptions compilationOptions = GetCompilationOptions(parameters);
			SyntaxTree[] syntaxTrees = RoslynCSharpCompiler.ParseFiles(fileNames, parseOptions);
			string[] compilationReferences = GetCompilationReferences(parameters);
			Compilation emitObject = RoslynCSharpCompiler.CreateCompilationObject(parameters.OutputAssembly, compilationReferences, syntaxTrees, compilationOptions);
			using Stream targetStream = GetOutputStream(parameters);
			CompilationResult result = RoslynCSharpCompiler.EmitCompilationObject(emitObject, targetStream);
			return GetCompilerResults(result);
		}

		public CompilerResults CompileAssemblyFromSource(CompilerParameters parameters, string source)
		{
			CSharpParseOptions parseOptions = GetParseOptions(parameters);
			CSharpCompilationOptions compilationOptions = GetCompilationOptions(parameters);
			SyntaxTree[] syntaxTrees = RoslynCSharpCompiler.ParseSource(source, parseOptions);
			string[] compilationReferences = GetCompilationReferences(parameters);
			Compilation emitObject = RoslynCSharpCompiler.CreateCompilationObject(parameters.OutputAssembly, compilationReferences, syntaxTrees, compilationOptions);
			using Stream targetStream = GetOutputStream(parameters);
			CompilationResult result = RoslynCSharpCompiler.EmitCompilationObject(emitObject, targetStream);
			return GetCompilerResults(result);
		}

		public CompilerResults CompileAssemblyFromSourceBatch(CompilerParameters parameters, string[] sources)
		{
			CSharpParseOptions parseOptions = GetParseOptions(parameters);
			CSharpCompilationOptions compilationOptions = GetCompilationOptions(parameters);
			SyntaxTree[] syntaxTrees = RoslynCSharpCompiler.ParseSources(sources, parseOptions);
			string[] compilationReferences = GetCompilationReferences(parameters);
			Compilation emitObject = RoslynCSharpCompiler.CreateCompilationObject(parameters.OutputAssembly, compilationReferences, syntaxTrees, compilationOptions);
			using Stream targetStream = GetOutputStream(parameters);
			CompilationResult result = RoslynCSharpCompiler.EmitCompilationObject(emitObject, targetStream);
			return GetCompilerResults(result);
		}

		public CompilerResults CompileAssemblyFromDom(CompilerParameters options, CodeCompileUnit compilationUnit)
		{
			throw new NotSupportedException("Use compile from file or compile from source");
		}

		public CompilerResults CompileAssemblyFromDomBatch(CompilerParameters options, CodeCompileUnit[] compilationUnits)
		{
			throw new NotSupportedException("Use compile from file or compile from source");
		}

		private CSharpParseOptions GetParseOptions(CompilerParameters parameters)
		{
			string parameterOption = GetParameterOption(parameters, "/languageversion");
			LanguageVersion languageVersion = LanguageVersion.Default;
			if (parameterOption != null && decimal.TryParse(parameterOption, out var result))
			{
				foreach (LanguageVersion value in Enum.GetValues(typeof(LanguageVersion)))
				{
					string text = value.ToString();
					if (text.Contains("CSharp"))
					{
						text = text.Replace("CSharp", string.Empty);
						if (result.ToString().Replace(".", "_") == text)
						{
							languageVersion = value;
							break;
						}
					}
				}
			}
			string parameterOption2 = GetParameterOption(parameters, "/define");
			List<string> list = new List<string>();
			if (parameterOption2 != null)
			{
				string[] array = parameterOption2.Split(new char[1] { ';' });
				foreach (string text2 in array)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						list.Add(text2);
					}
				}
			}
			return new CSharpParseOptions(languageVersion, DocumentationMode.None, SourceCodeKind.Regular, list);
		}

		private CSharpCompilationOptions GetCompilationOptions(CompilerParameters parameters)
		{
			int outputKind = (parameters.GenerateExecutable ? 1 : 2);
			OptimizationLevel optimizationLevel = ((GetParameterOption(parameters, "/optimize") != null) ? OptimizationLevel.Release : OptimizationLevel.Debug);
			bool allowUnsafe = GetParameterOption(parameters, "/unsafe") != null;
			Platform platform = Platform.AnyCpu;
			bool concurrentBuild = true;
			return new CSharpCompilationOptions((OutputKind)outputKind, reportSuppressedDiagnostics: false, null, null, null, null, optimizationLevel, checkOverflow: false, allowUnsafe, null, null, default(ImmutableArray<byte>), null, platform, ReportDiagnostic.Default, parameters.WarningLevel, null, concurrentBuild, deterministic: false, null, null, null, null, null, publicSign: false, MetadataImportOptions.Public);
		}

		private CompilerResults GetCompilerResults(CompilationResult result)
		{
			CompilerResults compilerResults = new CompilerResults(null);
			compilerResults.NativeCompilerReturnValue = 0;
			compilerResults.PathToAssembly = result.OutputFile;
			compilerResults.CompiledAssembly = result.OutputAssembly;
			CompilationError[] errors = result.Errors;
			foreach (CompilationError compilationError in errors)
			{
				if (!compilationError.IsInfo)
				{
					CompilerError compilerError = new CompilerError(compilationError.SourceFile, compilationError.SourceLine, compilationError.SourceColumn, compilationError.Code, compilationError.Message);
					compilerError.IsWarning = compilationError.IsWarning;
					compilerResults.Errors.Add(compilerError);
				}
			}
			return compilerResults;
		}

		private Stream GetOutputStream(CompilerParameters parameters)
		{
			Stream stream = null;
			if (parameters.GenerateInMemory)
			{
				return new MemoryStream();
			}
			string text = ".dll";
			if (parameters.GenerateExecutable)
			{
				text = ".exe";
			}
			return new FileStream(Path.Combine(outputDirectory, parameters.OutputAssembly + text), FileMode.Create);
		}

		private string[] GetCompilationReferences(CompilerParameters parameters)
		{
			string[] array = new string[parameters.ReferencedAssemblies.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = parameters.ReferencedAssemblies[i];
			}
			return array;
		}

		private string GetParameterOption(CompilerParameters parameters, string targetOption)
		{
			string[] array = parameters.CompilerOptions.Split(new char[1] { ' ' });
			foreach (string text in array)
			{
				if (text.IndexOf(targetOption) == 0)
				{
					int num = text.IndexOf(':');
					if (num >= 0)
					{
						return text.Remove(0, num);
					}
					return text;
				}
			}
			return null;
		}
	}
}
