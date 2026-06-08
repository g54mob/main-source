using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public sealed class CompilationResult : IMetadataReferenceProvider
	{
		private bool success;

		private string outputFile;

		private string outputPDBFile;

		private byte[] outputAssemblyImage;

		private byte[] outputPDBImage;

		private Assembly outputAssembly;

		private CompilationError[] errors;

		public MetadataReference Reference
		{
			get
			{
				if (!success)
				{
					throw new InvalidDataException("Cannot get matadata reference from compliation result because the compile was unsuccessful");
				}
				if (outputFile != null)
				{
					return new AssemblyReferenceFromFile(outputFile).Reference;
				}
				if (outputAssemblyImage != null)
				{
					return new AssemblyReferenceFromImage(outputAssemblyImage).Reference;
				}
				return null;
			}
		}

		public bool Success => success;

		public string OutputFile
		{
			get
			{
				return outputFile;
			}
			internal set
			{
				outputFile = value;
			}
		}

		public string OutputPDBFile
		{
			get
			{
				return outputPDBFile;
			}
			internal set
			{
				outputPDBFile = value;
			}
		}

		public byte[] OutputAssemblyImage
		{
			get
			{
				return outputAssemblyImage;
			}
			internal set
			{
				outputAssemblyImage = value;
			}
		}

		public byte[] OutputPDBImage
		{
			get
			{
				return outputPDBImage;
			}
			internal set
			{
				outputPDBImage = value;
			}
		}

		public Assembly OutputAssembly
		{
			get
			{
				return outputAssembly;
			}
			internal set
			{
				outputAssembly = value;
			}
		}

		public CompilationError[] Errors => errors;

		public int ErrorCount
		{
			get
			{
				int num = 0;
				CompilationError[] array = errors;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].IsError)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int WarningCount
		{
			get
			{
				int num = 0;
				CompilationError[] array = errors;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].IsWarning)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int InfoCount
		{
			get
			{
				int num = 0;
				CompilationError[] array = errors;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].IsInfo)
					{
						num++;
					}
				}
				return num;
			}
		}

		internal CompilationResult(bool success, IEnumerable<Diagnostic> diagnostics)
		{
			this.success = success;
			CreateErrors(diagnostics);
		}

		public Assembly LoadCompiledAssembly(AppDomain loadDomain = null)
		{
			if (!success)
			{
				return null;
			}
			if (outputAssembly != null)
			{
				return outputAssembly;
			}
			if (loadDomain == null)
			{
				loadDomain = AppDomain.CurrentDomain;
			}
			if (!string.IsNullOrEmpty(outputFile))
			{
				outputAssembly = loadDomain.Load(outputFile);
			}
			else if (outputAssemblyImage != null)
			{
				outputAssembly = loadDomain.Load(outputAssemblyImage);
			}
			return outputAssembly;
		}

		private void CreateErrors(IEnumerable<Diagnostic> diagnostics)
		{
			List<CompilationError> list = new List<CompilationError>();
			foreach (Diagnostic diagnostic in diagnostics)
			{
				string id = diagnostic.Id;
				if (!(id == "CS1701") && !(id == "CS1702") && diagnostic.Severity != DiagnosticSeverity.Hidden)
				{
					list.Add(new CompilationError(diagnostic));
				}
			}
			errors = list.ToArray();
		}
	}
}
