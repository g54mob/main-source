using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;

namespace Costura
{
	internal static class AssemblyLoader
	{
		private static object nullCacheLock = new object();

		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		private static int isAttached;

		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			Assembly[] array = assemblies;
			foreach (Assembly assembly in array)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(CultureToString(name2.CultureInfo), CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				using (Stream stream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using DeflateStream source = new DeflateStream(stream, CompressionMode.Decompress);
					MemoryStream memoryStream = new MemoryStream();
					CopyTo(source, memoryStream);
					memoryStream.Position = 0L;
					return memoryStream;
				}
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			if (resourceNames.TryGetValue(name, out var value))
			{
				return LoadStream(value);
			}
			return null;
		}

		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = ReadStream(stream);
			}
			using (Stream stream2 = LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			lock (nullCacheLock)
			{
				if (nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName);
			if (assembly == null)
			{
				lock (nullCacheLock)
				{
					nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		static AssemblyLoader()
		{
			assemblyNames.Add("costura", "costura.costura.dll.compressed");
			symbolNames.Add("costura", "costura.costura.pdb.compressed");
			assemblyNames.Add("microsoft.csharp", "costura.microsoft.csharp.dll.compressed");
			assemblyNames.Add("microsoft.extensions.dependencyinjection.abstractions", "costura.microsoft.extensions.dependencyinjection.abstractions.dll.compressed");
			assemblyNames.Add("microsoft.extensions.logging.abstractions", "costura.microsoft.extensions.logging.abstractions.dll.compressed");
			assemblyNames.Add("microsoft.extensions.logging", "costura.microsoft.extensions.logging.dll.compressed");
			assemblyNames.Add("microsoft.extensions.options", "costura.microsoft.extensions.options.dll.compressed");
			assemblyNames.Add("microsoft.extensions.primitives", "costura.microsoft.extensions.primitives.dll.compressed");
			assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			assemblyNames.Add("serilog", "costura.serilog.dll.compressed");
			assemblyNames.Add("serilog.extensions.logging", "costura.serilog.extensions.logging.dll.compressed");
			symbolNames.Add("serilog", "costura.serilog.pdb.compressed");
			assemblyNames.Add("system.collections.concurrent", "costura.system.collections.concurrent.dll.compressed");
			assemblyNames.Add("system.collections.nongeneric", "costura.system.collections.nongeneric.dll.compressed");
			assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
			assemblyNames.Add("system.io.filesystem.primitives", "costura.system.io.filesystem.primitives.dll.compressed");
			assemblyNames.Add("system.linq", "costura.system.linq.dll.compressed");
			assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
			assemblyNames.Add("system.runtime.numerics", "costura.system.runtime.numerics.dll.compressed");
			assemblyNames.Add("system.security.cryptography.openssl", "costura.system.security.cryptography.openssl.dll.compressed");
			assemblyNames.Add("system.security.cryptography.primitives", "costura.system.security.cryptography.primitives.dll.compressed");
			assemblyNames.Add("system.threading", "costura.system.threading.dll.compressed");
			assemblyNames.Add("twitchlib.api.core", "costura.twitchlib.api.core.dll.compressed");
			assemblyNames.Add("twitchlib.api.core.enums", "costura.twitchlib.api.core.enums.dll.compressed");
			assemblyNames.Add("twitchlib.api.core.interfaces", "costura.twitchlib.api.core.interfaces.dll.compressed");
			assemblyNames.Add("twitchlib.api.core.models", "costura.twitchlib.api.core.models.dll.compressed");
			assemblyNames.Add("twitchlib.api", "costura.twitchlib.api.dll.compressed");
			assemblyNames.Add("twitchlib.api.helix", "costura.twitchlib.api.helix.dll.compressed");
			assemblyNames.Add("twitchlib.api.helix.models", "costura.twitchlib.api.helix.models.dll.compressed");
			assemblyNames.Add("twitchlib.api.v5", "costura.twitchlib.api.v5.dll.compressed");
			assemblyNames.Add("twitchlib.api.v5.models", "costura.twitchlib.api.v5.models.dll.compressed");
			assemblyNames.Add("twitchlib.client", "costura.twitchlib.client.dll.compressed");
			assemblyNames.Add("twitchlib.client.enums", "costura.twitchlib.client.enums.dll.compressed");
			assemblyNames.Add("twitchlib.client.models", "costura.twitchlib.client.models.dll.compressed");
			assemblyNames.Add("twitchlib.communication", "costura.twitchlib.communication.dll.compressed");
			assemblyNames.Add("twitchlib.pubsub", "costura.twitchlib.pubsub.dll.compressed");
			assemblyNames.Add("unityeditor", "costura.unityeditor.dll.compressed");
		}

		public static void Attach()
		{
			if (Interlocked.Exchange(ref isAttached, 1) != 1)
			{
				AppDomain currentDomain = AppDomain.CurrentDomain;
				currentDomain.AssemblyResolve += ResolveAssembly;
			}
		}
	}
}
