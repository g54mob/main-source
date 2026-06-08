using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy
{
	public class ModuleScope
	{
		public static readonly string DEFAULT_FILE_NAME = "CastleDynProxy2.dll";

		public static readonly string DEFAULT_ASSEMBLY_NAME = "DynamicProxyGenAssembly2";

		private ModuleBuilder moduleBuilderWithStrongName;

		private ModuleBuilder moduleBuilder;

		private readonly string strongAssemblyName;

		private readonly string weakAssemblyName;

		private readonly string strongModulePath;

		private readonly string weakModulePath;

		private readonly SynchronizedDictionary<CacheKey, Type> typeCache = new SynchronizedDictionary<CacheKey, Type>();

		private readonly object moduleLocker = new object();

		private readonly bool savePhysicalAssembly;

		private readonly bool disableSignedModule;

		private readonly INamingScope namingScope;

		internal INamingScope NamingScope => namingScope;

		internal SynchronizedDictionary<CacheKey, Type> TypeCache => typeCache;

		internal ModuleBuilder StrongNamedModule => moduleBuilderWithStrongName;

		public string StrongNamedModuleName => Path.GetFileName(strongModulePath);

		internal ModuleBuilder WeakNamedModule => moduleBuilder;

		public string WeakNamedModuleName => Path.GetFileName(weakModulePath);

		public ModuleScope()
			: this(savePhysicalAssembly: false, disableSignedModule: false)
		{
		}

		public ModuleScope(bool savePhysicalAssembly)
			: this(savePhysicalAssembly, disableSignedModule: false)
		{
		}

		public ModuleScope(bool savePhysicalAssembly, bool disableSignedModule)
			: this(savePhysicalAssembly, disableSignedModule, DEFAULT_ASSEMBLY_NAME, DEFAULT_FILE_NAME, DEFAULT_ASSEMBLY_NAME, DEFAULT_FILE_NAME)
		{
		}

		public ModuleScope(bool savePhysicalAssembly, bool disableSignedModule, string strongAssemblyName, string strongModulePath, string weakAssemblyName, string weakModulePath)
			: this(savePhysicalAssembly, disableSignedModule, new NamingScope(), strongAssemblyName, strongModulePath, weakAssemblyName, weakModulePath)
		{
		}

		internal ModuleScope(bool savePhysicalAssembly, bool disableSignedModule, INamingScope namingScope, string strongAssemblyName, string strongModulePath, string weakAssemblyName, string weakModulePath)
		{
			this.savePhysicalAssembly = savePhysicalAssembly;
			this.disableSignedModule = disableSignedModule;
			this.namingScope = namingScope;
			this.strongAssemblyName = strongAssemblyName;
			this.strongModulePath = strongModulePath;
			this.weakAssemblyName = weakAssemblyName;
			this.weakModulePath = weakModulePath;
		}

		public static byte[] GetKeyPair()
		{
			using Stream stream = typeof(ModuleScope).Assembly.GetManifestResourceStream("Castle.DynamicProxy.DynProxy.snk");
			if (stream == null)
			{
				throw new MissingManifestResourceException("Should have a Castle.DynamicProxy.DynProxy.snk as an embedded resource, so Dynamic Proxy could sign generated assembly");
			}
			int num = (int)stream.Length;
			byte[] array = new byte[num];
			stream.Read(array, 0, num);
			return array;
		}

		internal ModuleBuilder ObtainDynamicModule(bool isStrongNamed)
		{
			if (isStrongNamed)
			{
				return ObtainDynamicModuleWithStrongName();
			}
			return ObtainDynamicModuleWithWeakName();
		}

		internal ModuleBuilder ObtainDynamicModuleWithStrongName()
		{
			if (disableSignedModule)
			{
				throw new InvalidOperationException("Usage of signed module has been disabled. Use unsigned module or enable signed module.");
			}
			lock (moduleLocker)
			{
				if (moduleBuilderWithStrongName == null)
				{
					moduleBuilderWithStrongName = CreateModule(signStrongName: true);
				}
				return moduleBuilderWithStrongName;
			}
		}

		internal ModuleBuilder ObtainDynamicModuleWithWeakName()
		{
			lock (moduleLocker)
			{
				if (moduleBuilder == null)
				{
					moduleBuilder = CreateModule(signStrongName: false);
				}
				return moduleBuilder;
			}
		}

		private ModuleBuilder CreateModule(bool signStrongName)
		{
			AssemblyName assemblyName = GetAssemblyName(signStrongName);
			string name = (signStrongName ? StrongNamedModuleName : WeakNamedModuleName);
			return AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(name);
		}

		private AssemblyName GetAssemblyName(bool signStrongName)
		{
			AssemblyName assemblyName = new AssemblyName
			{
				Name = (signStrongName ? strongAssemblyName : weakAssemblyName)
			};
			if (signStrongName)
			{
				assemblyName.SetPublicKey(InternalsVisible.DynamicProxyGenAssembly2PublicKey);
			}
			return assemblyName;
		}

		internal TypeBuilder DefineType(bool inSignedModulePreferably, string name, TypeAttributes flags)
		{
			return ObtainDynamicModule(!disableSignedModule && inSignedModulePreferably).DefineType(name, flags);
		}
	}
}
