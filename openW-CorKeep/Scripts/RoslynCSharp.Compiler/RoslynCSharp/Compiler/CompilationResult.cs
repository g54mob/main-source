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

		private AssemblyOutput assembly = new AssemblyOutput();

		private CompilationError[] errors;

		public MetadataReference CompilerReference
		{
			get
			{
				if (!success)
				{
					throw new InvalidDataException("Cannot get matadata reference from compliation result because the compile was unsuccessful");
				}
				if (OutputFile != null)
				{
					return new AssemblyReferenceFromFile(OutputFile).CompilerReference;
				}
				if (OutputAssemblyImage != null)
				{
					return new AssemblyReferenceFromImage(OutputAssemblyImage).CompilerReference;
				}
				return null;
			}
		}

		public bool Success => success;

		public string OutputFile
		{
			get
			{
				return assembly.AssemblyFilePath;
			}
			internal set
			{
				assembly.AssemblyFilePath = value;
			}
		}

		public string OutputPDBFile
		{
			get
			{
				return assembly.AssemblyPDBFilePath;
			}
			internal set
			{
				assembly.AssemblyPDBFilePath = value;
			}
		}

		public byte[] OutputAssemblyImage
		{
			get
			{
				return assembly.AssemblyImage;
			}
			internal set
			{
				assembly.AssemblyImage = value;
			}
		}

		public byte[] OutputPDBImage
		{
			get
			{
				return assembly.AssemblyPDBImage;
			}
			internal set
			{
				assembly.AssemblyPDBImage = value;
			}
		}

		public Assembly OutputAssembly
		{
			get
			{
				return assembly.OutputAssembly;
			}
			internal set
			{
				assembly.OutputAssembly = value;
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

		internal AssemblyOutput AssemblyOutput => assembly;

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
			if (OutputAssembly != null)
			{
				return OutputAssembly;
			}
			if (loadDomain == null)
			{
				loadDomain = AppDomain.CurrentDomain;
			}
			if (!string.IsNullOrEmpty(OutputFile))
			{
				if (string.IsNullOrEmpty(OutputPDBFile))
				{
					AssemblyName assemblyName = AssemblyName.GetAssemblyName(OutputFile);
					OutputAssembly = loadDomain.Load(assemblyName);
				}
				else
				{
					OutputAssembly = loadDomain.Load(OutputAssemblyImage, OutputPDBImage);
				}
			}
			else if (OutputAssemblyImage != null)
			{
				if (OutputPDBImage == null)
				{
					OutputAssembly = loadDomain.Load(OutputAssemblyImage);
				}
				else
				{
					OutputAssembly = loadDomain.Load(OutputAssemblyImage, OutputPDBImage);
				}
			}
			return OutputAssembly;
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
