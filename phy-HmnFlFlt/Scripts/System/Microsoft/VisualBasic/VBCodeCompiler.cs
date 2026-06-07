using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.VisualBasic
{
	internal class VBCodeCompiler : VBCodeGenerator, ICodeCompiler
	{
		public CompilerResults CompileAssemblyFromDom(CompilerParameters options, CodeCompileUnit e)
		{
			return CompileAssemblyFromDomBatch(options, new CodeCompileUnit[1] { e });
		}

		public CompilerResults CompileAssemblyFromDomBatch(CompilerParameters options, CodeCompileUnit[] ea)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			try
			{
				return CompileFromDomBatch(options, ea);
			}
			finally
			{
				options.TempFiles.Delete();
			}
		}

		public CompilerResults CompileAssemblyFromFile(CompilerParameters options, string fileName)
		{
			return CompileAssemblyFromFileBatch(options, new string[1] { fileName });
		}

		public CompilerResults CompileAssemblyFromFileBatch(CompilerParameters options, string[] fileNames)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			try
			{
				return CompileFromFileBatch(options, fileNames);
			}
			finally
			{
				options.TempFiles.Delete();
			}
		}

		public CompilerResults CompileAssemblyFromSource(CompilerParameters options, string source)
		{
			return CompileAssemblyFromSourceBatch(options, new string[1] { source });
		}

		public CompilerResults CompileAssemblyFromSourceBatch(CompilerParameters options, string[] sources)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			try
			{
				return CompileFromSourceBatch(options, sources);
			}
			finally
			{
				options.TempFiles.Delete();
			}
		}

		private static string BuildArgs(CompilerParameters options, string[] fileNames)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("/quiet ");
			if (options.GenerateExecutable)
			{
				stringBuilder.Append("/target:exe ");
			}
			else
			{
				stringBuilder.Append("/target:library ");
			}
			if (options.TreatWarningsAsErrors)
			{
				stringBuilder.Append("/warnaserror ");
			}
			if (options.OutputAssembly == null || options.OutputAssembly.Length == 0)
			{
				string extension = (options.GenerateExecutable ? "exe" : "dll");
				options.OutputAssembly = GetTempFileNameWithExtension(options.TempFiles, extension, !options.GenerateInMemory);
			}
			stringBuilder.AppendFormat("/out:\"{0}\" ", options.OutputAssembly);
			bool flag = false;
			if (options.ReferencedAssemblies != null)
			{
				StringEnumerator enumerator = options.ReferencedAssemblies.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						if (string.Compare(current, "Microsoft.VisualBasic", true, CultureInfo.InvariantCulture) == 0)
						{
							flag = true;
						}
						stringBuilder.AppendFormat("/r:\"{0}\" ", current);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (!flag)
			{
				stringBuilder.Append("/r:\"Microsoft.VisualBasic.dll\" ");
			}
			if (options.CompilerOptions != null)
			{
				stringBuilder.Append(options.CompilerOptions);
				stringBuilder.Append(" ");
			}
			foreach (string arg in fileNames)
			{
				stringBuilder.AppendFormat(" \"{0}\" ", arg);
			}
			return stringBuilder.ToString();
		}

		private static CompilerError CreateErrorFromString(string error_string)
		{
			CompilerError compilerError = new CompilerError();
			Match match = new Regex("^(\\s*(?<file>.*)?\\((?<line>\\d*)(,(?<column>\\d*))?\\)\\s+)?:\\s*(?<level>Error|Warning)?\\s*(?<number>.*):\\s(?<message>.*)", RegexOptions.ExplicitCapture | RegexOptions.Compiled).Match(error_string);
			if (!match.Success)
			{
				return null;
			}
			if (string.Empty != match.Result("${file}"))
			{
				compilerError.FileName = match.Result("${file}").Trim();
			}
			if (string.Empty != match.Result("${line}"))
			{
				compilerError.Line = int.Parse(match.Result("${line}"));
			}
			if (string.Empty != match.Result("${column}"))
			{
				compilerError.Column = int.Parse(match.Result("${column}"));
			}
			if (match.Result("${level}").Trim() == "Warning")
			{
				compilerError.IsWarning = true;
			}
			compilerError.ErrorNumber = match.Result("${number}");
			compilerError.ErrorText = match.Result("${message}");
			return compilerError;
		}

		private static string GetTempFileNameWithExtension(TempFileCollection temp_files, string extension, bool keepFile)
		{
			return temp_files.AddExtension(extension, keepFile);
		}

		private static string GetTempFileNameWithExtension(TempFileCollection temp_files, string extension)
		{
			return temp_files.AddExtension(extension);
		}

		private CompilerResults CompileFromFileBatch(CompilerParameters options, string[] fileNames)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (fileNames == null)
			{
				throw new ArgumentNullException("fileNames");
			}
			CompilerResults compilerResults = new CompilerResults(options.TempFiles);
			Process process = new Process();
			string text = "";
			if (Path.DirectorySeparatorChar == '\\')
			{
				process.StartInfo.FileName = MonoToolsLocator.Mono;
				process.StartInfo.Arguments = MonoToolsLocator.VBCompiler + " " + BuildArgs(options, fileNames);
			}
			else
			{
				process.StartInfo.FileName = MonoToolsLocator.VBCompiler;
				process.StartInfo.Arguments = BuildArgs(options, fileNames);
			}
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			try
			{
				process.Start();
			}
			catch (Exception ex)
			{
				Win32Exception ex2 = ex as Win32Exception;
				if (ex2 != null)
				{
					throw new SystemException(string.Format("Error running {0}: {1}", process.StartInfo.FileName, Win32Exception.GetErrorMessage(ex2.NativeErrorCode)));
				}
				throw;
			}
			try
			{
				text = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
			}
			finally
			{
				compilerResults.NativeCompilerReturnValue = process.ExitCode;
				process.Close();
			}
			bool flag = true;
			if (compilerResults.NativeCompilerReturnValue == 1)
			{
				flag = false;
				string[] array = text.Split(Environment.NewLine.ToCharArray());
				for (int i = 0; i < array.Length; i++)
				{
					CompilerError compilerError = CreateErrorFromString(array[i]);
					if (compilerError != null)
					{
						compilerResults.Errors.Add(compilerError);
					}
				}
			}
			if ((!flag && !compilerResults.Errors.HasErrors) || (compilerResults.NativeCompilerReturnValue != 0 && compilerResults.NativeCompilerReturnValue != 1))
			{
				flag = false;
				CompilerError value = new CompilerError(string.Empty, 0, 0, "VBNC_CRASH", text);
				compilerResults.Errors.Add(value);
			}
			if (flag)
			{
				if (options.GenerateInMemory)
				{
					using (FileStream fileStream = File.OpenRead(options.OutputAssembly))
					{
						byte[] array2 = new byte[fileStream.Length];
						fileStream.Read(array2, 0, array2.Length);
						compilerResults.CompiledAssembly = Assembly.Load(array2, null);
						fileStream.Close();
					}
				}
				else
				{
					compilerResults.CompiledAssembly = Assembly.LoadFrom(options.OutputAssembly);
					compilerResults.PathToAssembly = options.OutputAssembly;
				}
			}
			else
			{
				compilerResults.CompiledAssembly = null;
			}
			return compilerResults;
		}

		private CompilerResults CompileFromDomBatch(CompilerParameters options, CodeCompileUnit[] ea)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (ea == null)
			{
				throw new ArgumentNullException("ea");
			}
			string[] array = new string[ea.Length];
			StringCollection referencedAssemblies = options.ReferencedAssemblies;
			for (int i = 0; i < ea.Length; i++)
			{
				CodeCompileUnit codeCompileUnit = ea[i];
				array[i] = GetTempFileNameWithExtension(options.TempFiles, i + ".vb");
				FileStream fileStream = new FileStream(array[i], FileMode.OpenOrCreate);
				StreamWriter streamWriter = new StreamWriter(fileStream);
				if (codeCompileUnit.ReferencedAssemblies != null)
				{
					StringEnumerator enumerator = codeCompileUnit.ReferencedAssemblies.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							string current = enumerator.Current;
							if (!referencedAssemblies.Contains(current))
							{
								referencedAssemblies.Add(current);
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				((ICodeGenerator)this).GenerateCodeFromCompileUnit(codeCompileUnit, (TextWriter)streamWriter, new CodeGeneratorOptions());
				streamWriter.Close();
				fileStream.Close();
			}
			return CompileAssemblyFromFileBatch(options, array);
		}

		private CompilerResults CompileFromSourceBatch(CompilerParameters options, string[] sources)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			string[] array = new string[sources.Length];
			for (int i = 0; i < sources.Length; i++)
			{
				array[i] = GetTempFileNameWithExtension(options.TempFiles, i + ".vb");
				FileStream fileStream = new FileStream(array[i], FileMode.OpenOrCreate);
				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					streamWriter.Write(sources[i]);
					streamWriter.Close();
				}
				fileStream.Close();
			}
			return CompileFromFileBatch(options, array);
		}
	}
}
