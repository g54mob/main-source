using System;
using System.IO;
using System.Security.Cryptography;
using Trivial.CodeSecurity.CodeEvaluation;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public sealed class CodeSecurityEngine : IDisposable
	{
		private static byte[] assemblyDefinitionBytes;

		private Stream loadStream;

		private Stream loadSymbolStream;

		private AssemblyDefinition definition;

		private CodeSecurityRestrictions restrictions;

		private byte[] definitionBytes;

		public string CheckAssemblyName => definition.Name.FullName;

		static CodeSecurityEngine()
		{
			string location = typeof(CodeSecurityEngine).Assembly.Location;
			try
			{
				assemblyDefinitionBytes = File.ReadAllBytes(location);
			}
			catch
			{
			}
		}

		public CodeSecurityEngine(string assemblyDefinitionFile)
		{
			if (assemblyDefinitionFile == null)
			{
				throw new ArgumentNullException("assemblyDefinitionFile");
			}
			loadStream = File.OpenRead(assemblyDefinitionFile);
			InitializeFromStream(loadStream);
		}

		public CodeSecurityEngine(byte[] assemblyImage, byte[] assemblySymbolsImage = null)
		{
			if (assemblyImage == null)
			{
				throw new ArgumentNullException("assemblyImage");
			}
			loadStream = new MemoryStream(assemblyImage);
			if (assemblySymbolsImage != null)
			{
				loadSymbolStream = new MemoryStream(assemblySymbolsImage);
			}
			InitializeFromStream(loadStream, loadSymbolStream);
		}

		public CodeSecurityEngine(Stream assemblyDefinitionStream, Stream symbolStream = null)
		{
			if (assemblyDefinitionStream == null)
			{
				throw new ArgumentNullException("assemblyDefinitionStream");
			}
			InitializeFromStream(assemblyDefinitionStream, symbolStream);
		}

		public void Dispose()
		{
			if (definition != null)
			{
				definition.Dispose();
				definition = null;
				if (loadStream != null)
				{
					loadStream.Dispose();
					loadStream = null;
				}
				if (loadSymbolStream != null)
				{
					loadSymbolStream.Dispose();
					loadSymbolStream = null;
				}
			}
		}

		public bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions)
		{
			CheckDisposed();
			CodeSecurityReport report;
			return SecurityCheckAssembly((ICodeSecurityValidator)restrictions, out report);
		}

		public bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions, out CodeSecurityReport report)
		{
			CheckDisposed();
			this.restrictions = restrictions;
			return SecurityCheckAssembly((ICodeSecurityValidator)restrictions, out report);
		}

		public bool SecurityCheckAssembly(ICodeSecurityValidator validator)
		{
			CheckDisposed();
			CodeSecurityReport report;
			return SecurityCheckAssembly(validator, out report);
		}

		public bool SecurityCheckAssembly(ICodeSecurityValidator validator, out CodeSecurityReport report)
		{
			CheckDisposed();
			report = new CodeSecurityReport(definition, restrictions);
			CodeSecurityContext context = new CodeSecurityContext(definition, report, validator);
			ModuleChecker moduleChecker = new ModuleChecker();
			foreach (ModuleDefinition module in definition.Modules)
			{
				moduleChecker.SecurityCheckModuleReferences(context, module);
				moduleChecker.SecurityCheckModuleCode(context, module);
			}
			return report.IsSecurityVerified;
		}

		public byte[] GenerateSecurityHash()
		{
			CheckDisposed();
			if (definitionBytes == null)
			{
				throw new InvalidOperationException("Cannot generate security hash because the assembly data was not captured on initialize. Make sure you pass a seekable stream to the constructor");
			}
			try
			{
				byte[] array = new SHA256Managed().ComputeHash(definitionBytes);
				byte[] array2 = SafeGenerateAssemblySecurityHash();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] |= array2[i];
				}
			}
			catch
			{
			}
			return null;
		}

		public static byte[] GenerateAssemblySecurityHash()
		{
			if (assemblyDefinitionBytes == null)
			{
				throw new InvalidOperationException("Cannot generate security hash because the location of the calling assembly could not be determined at runtime");
			}
			return SafeGenerateAssemblySecurityHash();
		}

		internal static byte[] SafeGenerateAssemblySecurityHash()
		{
			if (assemblyDefinitionBytes == null)
			{
				return null;
			}
			try
			{
				return new SHA256Managed().ComputeHash(assemblyDefinitionBytes);
			}
			catch
			{
			}
			return null;
		}

		private void InitializeFromStream(Stream loadStream, Stream symbolsStream = null)
		{
			CaptureAssemblyFromStream(loadStream);
			ReaderParameters readerParameters = new ReaderParameters();
			readerParameters.ReadSymbols = true;
			definition = AssemblyDefinition.ReadAssembly(loadStream, readerParameters);
			if (definition == null)
			{
				throw new Exception("Failed to read assembly definition for code evaluation");
			}
		}

		private void CaptureAssemblyFromStream(Stream inputStream)
		{
			if (inputStream.CanSeek)
			{
				long position = inputStream.Position;
				MemoryStream memoryStream = new MemoryStream();
				byte[] array = new byte[4096];
				int num = 0;
				while ((num = inputStream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, num);
				}
				definitionBytes = memoryStream.ToArray();
				memoryStream.Dispose();
				inputStream.Seek(position, SeekOrigin.Begin);
			}
		}

		private void CheckDisposed()
		{
			if (definition == null)
			{
				throw new ObjectDisposedException("The code security engine has already been disposed");
			}
		}
	}
}
