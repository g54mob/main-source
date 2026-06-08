using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

namespace RoslynCSharp.Compiler
{
	public class RoslynCSharpCompiler
	{
		private AppDomain loadAssemblyDomain;

		private CSharpParseOptions parseOptions;

		private CSharpCompilationOptions compileOptions;

		private string outputDirectory = "";

		private string outputName;

		private string outputPDBExtension = ".dll.pdb";

		private bool allowUnsafe;

		private bool allowOptimize = true;

		private bool allowConcurrentCompile = true;

		private bool generateInMemory = true;

		private bool generateSymbols;

		private int warningLevel = 4;

		private LanguageVersion languageVersion;

		private OutputKind outputKind = OutputKind.DynamicallyLinkedLibrary;

		private Platform targetPlatform;

		private DebugInformationFormat debugSymbolType = DebugInformationFormat.PortablePdb;

		private ObservableCollection<string> defineSymbols = new ObservableCollection<string>();

		private ObservableCollection<IMetadataReferenceProvider> referenceAssemblies = new ObservableCollection<IMetadataReferenceProvider>();

		private List<MetadataReference> referenceBuilder = new List<MetadataReference>();

		private List<Exception> referenceExceptions = new List<Exception>();

		private CompilationResult lastCompileResult;

		public static bool loadCompiledAssemblies = true;

		public static readonly IMetadataReferenceProvider[] defaultReferenceAssemblies = new IMetadataReferenceProvider[1]
		{
			new AssemblyReferenceFromAssemblyObject(typeof(object).Assembly)
		};

		public string OutputDirectory
		{
			get
			{
				return outputDirectory;
			}
			set
			{
				outputDirectory = value;
			}
		}

		public string OutputName
		{
			get
			{
				return outputName;
			}
			set
			{
				outputName = value;
			}
		}

		public string OutputPDBExtension
		{
			get
			{
				return outputPDBExtension;
			}
			set
			{
				outputPDBExtension = value;
			}
		}

		public bool AllowUnsafe
		{
			get
			{
				return allowUnsafe;
			}
			set
			{
				allowUnsafe = value;
				UpdateCompilerOptions();
			}
		}

		public bool AllowOptimize
		{
			get
			{
				return allowOptimize;
			}
			set
			{
				allowOptimize = value;
				UpdateCompilerOptions();
			}
		}

		public bool AllowConcurrentCompile
		{
			get
			{
				return allowConcurrentCompile;
			}
			set
			{
				allowConcurrentCompile = value;
				UpdateCompilerOptions();
			}
		}

		public bool GenerateInMemory
		{
			get
			{
				return generateInMemory;
			}
			set
			{
				generateInMemory = value;
			}
		}

		public bool GenerateSymbols
		{
			get
			{
				return generateSymbols;
			}
			set
			{
				generateSymbols = value;
			}
		}

		public int WarningLevel
		{
			get
			{
				return warningLevel;
			}
			set
			{
				warningLevel = value;
				UpdateCompilerOptions();
			}
		}

		public LanguageVersion LanguageVersion
		{
			get
			{
				return languageVersion;
			}
			set
			{
				languageVersion = value;
				UpdateParserOptions();
			}
		}

		public OutputKind OutputKind
		{
			get
			{
				return outputKind;
			}
			set
			{
				outputKind = value;
				UpdateCompilerOptions();
			}
		}

		public Platform TargetPlatform
		{
			get
			{
				return targetPlatform;
			}
			set
			{
				targetPlatform = value;
				UpdateCompilerOptions();
			}
		}

		public IList<string> DefineSymbols => defineSymbols;

		public IList<IMetadataReferenceProvider> ReferenceAssemblies => referenceAssemblies;

		public string DefaultOutputExtension
		{
			get
			{
				switch (outputKind)
				{
				default:
					return string.Empty;
				case OutputKind.ConsoleApplication:
				case OutputKind.WindowsApplication:
				case OutputKind.NetModule:
					return ".exe";
				case OutputKind.DynamicallyLinkedLibrary:
					return ".dll";
				}
			}
		}

		public CompilationResult LastCompileResult => lastCompileResult;

		public DebugInformationFormat DebugSymbolType
		{
			get
			{
				return debugSymbolType;
			}
			set
			{
				debugSymbolType = value;
			}
		}

		public RoslynCSharpCompiler(bool includeDefaultReferenceAssemblies = true, bool generateInMemory = true, OutputKind outputKind = OutputKind.DynamicallyLinkedLibrary, LanguageVersion languageVersion = LanguageVersion.Default, AppDomain loadAssemblyDomain = null)
		{
			this.generateInMemory = generateInMemory;
			this.outputKind = outputKind;
			this.languageVersion = languageVersion;
			this.loadAssemblyDomain = loadAssemblyDomain;
			UpdateParserOptions();
			UpdateCompilerOptions();
			defineSymbols.CollectionChanged += delegate
			{
				UpdateParserOptions();
			};
		}

		public RoslynCSharpCompiler(string outputName, bool includeDefaultReferenceAssemblies = true, bool generateInMemory = true, OutputKind outputKing = OutputKind.DynamicallyLinkedLibrary, LanguageVersion languageVersion = LanguageVersion.Default, AppDomain loadAssemblyDomain = null)
		{
			this.outputName = outputName;
			this.generateInMemory = generateInMemory;
			outputKind = OutputKind;
			this.languageVersion = LanguageVersion;
			this.loadAssemblyDomain = loadAssemblyDomain;
			if (includeDefaultReferenceAssemblies)
			{
				IMetadataReferenceProvider[] array = defaultReferenceAssemblies;
				foreach (IMetadataReferenceProvider item in array)
				{
					referenceAssemblies.Add(item);
				}
			}
			UpdateParserOptions();
			UpdateCompilerOptions();
			defineSymbols.CollectionChanged += delegate
			{
				UpdateParserOptions();
			};
		}

		public CompilationResult CompileFromSource(string cSharpSource, IMetadataReferenceProvider[] additionalAssemblyReferences = null)
		{
			if (cSharpSource == null)
			{
				throw new ArgumentNullException("cSharpSource");
			}
			SyntaxTree[] syntaxTrees = ParseSource(cSharpSource, parseOptions);
			return CompileFromSyntaxTree(syntaxTrees, additionalAssemblyReferences);
		}

		public CompilationResult CompileFromSources(string[] cSharpSources, IMetadataReferenceProvider[] additionalAssemblyReferences = null)
		{
			for (int i = 0; i < cSharpSources.Length; i++)
			{
				if (cSharpSources[i] == null)
				{
					throw new ArgumentNullException($"Source array element '{i}' is null");
				}
			}
			SyntaxTree[] syntaxTrees = ParseSources(cSharpSources, parseOptions);
			return CompileFromSyntaxTree(syntaxTrees, additionalAssemblyReferences);
		}

		public CompilationResult CompileFromFile(string cSharpFile, IMetadataReferenceProvider[] additionalAssemblyReferences = null)
		{
			if (cSharpFile == null)
			{
				throw new ArgumentNullException("cSharpFile");
			}
			SyntaxTree[] syntaxTrees = ParseFile(cSharpFile, parseOptions);
			return CompileFromSyntaxTree(syntaxTrees, additionalAssemblyReferences);
		}

		public CompilationResult CompileFromFiles(string[] cSharpFiles, IMetadataReferenceProvider[] additionalAssemblyReferences = null)
		{
			for (int i = 0; i < cSharpFiles.Length; i++)
			{
				if (cSharpFiles[i] == null)
				{
					throw new ArgumentNullException($"Source array element '{i}' is null");
				}
			}
			SyntaxTree[] syntaxTrees = ParseFiles(cSharpFiles, parseOptions);
			return CompileFromSyntaxTree(syntaxTrees, additionalAssemblyReferences);
		}

		private CompilationResult CompileFromSyntaxTree(SyntaxTree[] syntaxTrees, IMetadataReferenceProvider[] additionalAsemblyReferences)
		{
			string text = null;
			string text2 = outputName;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = Guid.NewGuid().ToString();
			}
			if (!Path.HasExtension(text2))
			{
				text2 += DefaultOutputExtension;
			}
			text = ((!string.IsNullOrEmpty(outputDirectory)) ? Path.Combine(outputDirectory, text2) : text2);
			Exception error = null;
			MetadataReference[] references = UpdateReferences(additionalAsemblyReferences, out error);
			if (error != null)
			{
				throw error;
			}
			Compilation emitObject = CreateCompilationObject(text2, references, syntaxTrees, compileOptions);
			DirectoryInfo parent = Directory.GetParent(text);
			if (!generateInMemory && !parent.Exists)
			{
				parent.Create();
			}
			Stream stream = (generateInMemory ? ((Stream)new MemoryStream()) : ((Stream)new FileStream(text, FileMode.OpenOrCreate, FileAccess.ReadWrite)));
			Stream stream2 = null;
			if (generateSymbols)
			{
				string path = Path.ChangeExtension(text, outputPDBExtension);
				stream2 = (generateInMemory ? ((Stream)new MemoryStream()) : ((Stream)new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)));
			}
			using (stream)
			{
				using (stream2)
				{
					return lastCompileResult = EmitCompilationObject(emitObject, stream, stream2, loadCompiledAssemblies, loadAssemblyDomain, debugSymbolType);
				}
			}
		}

		private void UpdateParserOptions()
		{
			parseOptions = new CSharpParseOptions(languageVersion, DocumentationMode.Parse, SourceCodeKind.Regular, defineSymbols);
		}

		private void UpdateCompilerOptions()
		{
			OptimizationLevel optimizationLevel = (allowOptimize ? OptimizationLevel.Release : OptimizationLevel.Debug);
			compileOptions = new CSharpCompilationOptions(outputKind, reportSuppressedDiagnostics: false, null, null, null, null, optimizationLevel, checkOverflow: false, allowUnsafe, null, null, default(ImmutableArray<byte>), null, targetPlatform, ReportDiagnostic.Default, warningLevel, null, allowConcurrentCompile, deterministic: false, null, null, null, null, null, publicSign: false, MetadataImportOptions.Public);
		}

		private MetadataReference[] UpdateReferences(IMetadataReferenceProvider[] additionalReferences, out Exception error)
		{
			error = null;
			referenceBuilder.Clear();
			referenceExceptions.Clear();
			UpdateReferencesFromProviderSource(referenceAssemblies, referenceBuilder, referenceExceptions);
			if (additionalReferences != null)
			{
				UpdateReferencesFromProviderSource(additionalReferences, referenceBuilder, referenceExceptions);
			}
			if (referenceExceptions.Count > 0)
			{
				error = new AssemblyReferenceException(referenceExceptions);
			}
			return referenceBuilder.ToArray();
		}

		private void UpdateReferencesFromProviderSource(IEnumerable<IMetadataReferenceProvider> providerSource, IList<MetadataReference> references, IList<Exception> exceptions)
		{
			foreach (IMetadataReferenceProvider item in providerSource)
			{
				if (item.TryResolveReference(out var reference, out var error))
				{
					references.Add(reference);
				}
				else
				{
					exceptions.Add(error);
				}
			}
		}

		public static SyntaxTree[] ParseSource(string cSharpSource, CSharpParseOptions parseOptions = null)
		{
			return ParseSources(new string[1] { cSharpSource }, parseOptions);
		}

		public static SyntaxTree[] ParseSources(string[] cSharpSources, CSharpParseOptions parseOptions = null)
		{
			if (cSharpSources.Length == 0)
			{
				return new SyntaxTree[0];
			}
			SyntaxTree[] array = new SyntaxTree[cSharpSources.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = CSharpSyntaxTree.ParseText(cSharpSources[i], parseOptions, "", Encoding.Default);
			}
			return array;
		}

		public static SyntaxTree[] ParseFile(string cSharpFile, CSharpParseOptions parseOptions = null)
		{
			return ParseFiles(new string[1] { cSharpFile }, parseOptions);
		}

		public static SyntaxTree[] ParseFiles(string[] cSharpFiles, CSharpParseOptions parseOptions = null)
		{
			if (cSharpFiles.Length == 0)
			{
				return new SyntaxTree[0];
			}
			SyntaxTree[] array = new SyntaxTree[cSharpFiles.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (!File.Exists(cSharpFiles[i]))
				{
					throw new IOException($"The specified C# source file '{cSharpFiles[i]}' does not exist");
				}
				using Stream stream = File.OpenRead(cSharpFiles[i]);
				using TextReader reader = new StreamReader(stream);
				array[i] = CSharpSyntaxTree.ParseText(SourceText.From(reader, (int)stream.Length, Encoding.Default), parseOptions, cSharpFiles[i]);
			}
			return array;
		}

		public static Compilation CreateCompilationObject(string assemblyName, string[] references, SyntaxTree[] syntaxTrees, CSharpCompilationOptions options = null)
		{
			if (string.IsNullOrEmpty(assemblyName))
			{
				throw new ArgumentException("A valid assembly name must be provided");
			}
			if (syntaxTrees == null || syntaxTrees.Length == 0)
			{
				throw new ArgumentException("You must provide at least one syntax tree for the creation of a compilation object");
			}
			if (references == null)
			{
				references = new string[0];
			}
			MetadataReference[] array = new MetadataReference[references.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MetadataReference.CreateFromFile(references[i]);
			}
			return CreateCompilationObject(assemblyName, array, syntaxTrees, options);
		}

		public static Compilation CreateCompilationObject(string assemblyName, MetadataReference[] references, SyntaxTree[] syntaxTrees, CSharpCompilationOptions options = null)
		{
			if (string.IsNullOrEmpty(assemblyName))
			{
				throw new ArgumentException("A valid assembly name must be provided");
			}
			if (syntaxTrees == null || syntaxTrees.Length == 0)
			{
				throw new ArgumentException("You must provide at least one syntax tree for the creation of a compilation object");
			}
			if (references == null)
			{
				references = new MetadataReference[0];
			}
			return CSharpCompilation.Create(assemblyName, syntaxTrees, references, options);
		}

		public static CompilationResult EmitCompilationObject(Compilation emitObject, Stream targetStream, Stream targetPDBStream = null, bool loadCompiledAssembly = true, AppDomain loadAssemblyDomain = null, DebugInformationFormat debugFormat = DebugInformationFormat.PortablePdb)
		{
			if (emitObject == null)
			{
				throw new ArgumentNullException("emitObject");
			}
			if (targetStream == null)
			{
				throw new ArgumentNullException("targetStream");
			}
			long position = targetStream.Position;
			_ = targetPDBStream?.Position;
			EmitOptions options = null;
			if (targetPDBStream != null)
			{
				options = new EmitOptions(metadataOnly: false, debugFormat, null, null, 0, 0uL, highEntropyVirtualAddressSpace: false, default(SubsystemVersion), null, tolerateErrors: false, includePrivateMembers: true, default(ImmutableArray<InstrumentationKind>), null);
			}
			EmitResult emitResult = emitObject.Emit(targetStream, targetPDBStream, null, null, null, options);
			CompilationResult compilationResult = new CompilationResult(emitResult.Success, emitResult.Diagnostics);
			if (targetStream is FileStream)
			{
				FileStream fileStream = targetStream as FileStream;
				compilationResult.OutputFile = fileStream.Name;
				fileStream.Flush();
			}
			if (compilationResult.Success)
			{
				if (targetPDBStream != null)
				{
					if (targetPDBStream is FileStream)
					{
						compilationResult.OutputPDBFile = (targetPDBStream as FileStream).Name;
					}
					if (targetPDBStream.CanSeek)
					{
						long position2 = targetPDBStream.Position;
						targetPDBStream.Seek(position, SeekOrigin.Begin);
						byte[] array = new byte[position2 - position];
						targetPDBStream.Read(array, 0, array.Length);
						compilationResult.OutputPDBImage = array;
					}
					targetPDBStream.Dispose();
				}
				LoadAssemblyImageFromStream(targetStream, position, compilationResult);
				targetStream.Dispose();
				if (loadCompiledAssembly)
				{
					AppDomain appDomain = AppDomain.CurrentDomain;
					if (loadAssemblyDomain != null)
					{
						appDomain = loadAssemblyDomain;
					}
					if (!string.IsNullOrEmpty(compilationResult.OutputFile))
					{
						AssemblyName assemblyName = new AssemblyName();
						assemblyName.CodeBase = compilationResult.OutputFile;
						compilationResult.OutputAssembly = appDomain.Load(assemblyName);
					}
					else
					{
						compilationResult.OutputAssembly = appDomain.Load(compilationResult.OutputAssemblyImage);
					}
				}
			}
			return compilationResult;
		}

		private static void LoadAssemblyImageFromStream(Stream targetStream, long streamStart, CompilationResult result)
		{
			if (!targetStream.CanSeek)
			{
				throw new IOException("Unable to load assembly definition because the specified output stream is not seekable");
			}
			long position = targetStream.Position;
			targetStream.Seek(streamStart, SeekOrigin.Begin);
			byte[] array = new byte[position - streamStart];
			targetStream.Read(array, 0, array.Length);
			result.OutputAssemblyImage = array;
		}
	}
}
