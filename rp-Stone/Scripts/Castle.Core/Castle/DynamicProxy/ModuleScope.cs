using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Serialization;

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

		[Obsolete]
		private readonly Lock cacheLock;

		private readonly object moduleLocker = new object();

		private readonly bool savePhysicalAssembly;

		private readonly bool disableSignedModule;

		private readonly INamingScope namingScope;

		public INamingScope NamingScope => namingScope;

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Lock Lock => cacheLock;

		internal SynchronizedDictionary<CacheKey, Type> TypeCache => typeCache;

		public ModuleBuilder StrongNamedModule => moduleBuilderWithStrongName;

		public string StrongNamedModuleName => Path.GetFileName(strongModulePath);

		public string StrongNamedModuleDirectory
		{
			get
			{
				string directoryName = Path.GetDirectoryName(strongModulePath);
				if (string.IsNullOrEmpty(directoryName))
				{
					return null;
				}
				return directoryName;
			}
		}

		public ModuleBuilder WeakNamedModule => moduleBuilder;

		public string WeakNamedModuleName => Path.GetFileName(weakModulePath);

		public string WeakNamedModuleDirectory
		{
			get
			{
				string directoryName = Path.GetDirectoryName(weakModulePath);
				if (directoryName == string.Empty)
				{
					return null;
				}
				return directoryName;
			}
		}

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

		public ModuleScope(bool savePhysicalAssembly, bool disableSignedModule, INamingScope namingScope, string strongAssemblyName, string strongModulePath, string weakAssemblyName, string weakModulePath)
		{
			this.savePhysicalAssembly = savePhysicalAssembly;
			this.disableSignedModule = disableSignedModule;
			this.namingScope = namingScope;
			this.strongAssemblyName = strongAssemblyName;
			this.strongModulePath = strongModulePath;
			this.weakAssemblyName = weakAssemblyName;
			this.weakModulePath = weakModulePath;
			cacheLock = Lock.CreateFor(typeCache.Lock);
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Type GetFromCache(CacheKey key)
		{
			typeCache.TryGetValueWithoutTakingLock(key, out var value);
			return value;
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RegisterInCache(CacheKey key, Type type)
		{
			typeCache.AddOrUpdateWithoutTakingLock(key, type);
		}

		public static byte[] GetKeyPair()
		{
			using Stream stream = typeof(ModuleScope).GetTypeInfo().Assembly.GetManifestResourceStream("Castle.DynamicProxy.DynProxy.snk");
			if (stream == null)
			{
				throw new MissingManifestResourceException("Should have a Castle.DynamicProxy.DynProxy.snk as an embedded resource, so Dynamic Proxy could sign generated assembly");
			}
			int num = (int)stream.Length;
			byte[] array = new byte[num];
			stream.Read(array, 0, num);
			return array;
		}

		public ModuleBuilder ObtainDynamicModule(bool isStrongNamed)
		{
			if (isStrongNamed)
			{
				return ObtainDynamicModuleWithStrongName();
			}
			return ObtainDynamicModuleWithWeakName();
		}

		public ModuleBuilder ObtainDynamicModuleWithStrongName()
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

		public ModuleBuilder ObtainDynamicModuleWithWeakName()
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
			string text = (signStrongName ? StrongNamedModuleName : WeakNamedModuleName);
			if (savePhysicalAssembly)
			{
				AssemblyBuilder assemblyBuilder;
				try
				{
					assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave, signStrongName ? StrongNamedModuleDirectory : WeakNamedModuleDirectory);
				}
				catch (ArgumentException ex)
				{
					if (!signStrongName && !ex.StackTrace.Contains("ComputePublicKey"))
					{
						throw;
					}
					throw new ArgumentException($"There was an error creating dynamic assembly for your proxies - you don't have permissions required to sign the assembly. To workaround it you can enforce generating non-signed assembly only when creating {GetType()}. Alternatively ensure that your account has all the required permissions.", ex);
				}
				return assemblyBuilder.DefineDynamicModule(text, text, emitSymbolInfo: false);
			}
			return AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(text);
		}

		private AssemblyName GetAssemblyName(bool signStrongName)
		{
			AssemblyName assemblyName = new AssemblyName
			{
				Name = (signStrongName ? strongAssemblyName : weakAssemblyName)
			};
			if (signStrongName)
			{
				assemblyName.KeyPair = new StrongNameKeyPair(GetKeyPair());
			}
			return assemblyName;
		}

		public string SaveAssembly()
		{
			if (!savePhysicalAssembly)
			{
				return null;
			}
			if (StrongNamedModule != null && WeakNamedModule != null)
			{
				throw new InvalidOperationException("Both a strong-named and a weak-named assembly have been generated.");
			}
			if (StrongNamedModule != null)
			{
				return SaveAssembly(strongNamed: true);
			}
			if (WeakNamedModule != null)
			{
				return SaveAssembly(strongNamed: false);
			}
			return null;
		}

		public string SaveAssembly(bool strongNamed)
		{
			if (!savePhysicalAssembly)
			{
				return null;
			}
			AssemblyBuilder assemblyBuilder;
			string assemblyFileName;
			string fullyQualifiedName;
			if (strongNamed)
			{
				if (StrongNamedModule == null)
				{
					throw new InvalidOperationException("No strong-named assembly has been generated.");
				}
				assemblyBuilder = (AssemblyBuilder)StrongNamedModule.Assembly;
				assemblyFileName = StrongNamedModuleName;
				fullyQualifiedName = StrongNamedModule.FullyQualifiedName;
			}
			else
			{
				if (WeakNamedModule == null)
				{
					throw new InvalidOperationException("No weak-named assembly has been generated.");
				}
				assemblyBuilder = (AssemblyBuilder)WeakNamedModule.Assembly;
				assemblyFileName = WeakNamedModuleName;
				fullyQualifiedName = WeakNamedModule.FullyQualifiedName;
			}
			if (File.Exists(fullyQualifiedName))
			{
				File.Delete(fullyQualifiedName);
			}
			AddCacheMappings(assemblyBuilder);
			assemblyBuilder.Save(assemblyFileName);
			return fullyQualifiedName;
		}

		private void AddCacheMappings(AssemblyBuilder builder)
		{
			Dictionary<CacheKey, string> mappings = new Dictionary<CacheKey, string>();
			typeCache.ForEach(delegate(CacheKey key, Type value)
			{
				if (builder.Equals(value.Assembly))
				{
					mappings.Add(key, value.FullName);
				}
			});
			CacheMappingsAttribute.ApplyTo(builder, mappings);
		}

		public void LoadAssemblyIntoCache(Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			CacheMappingsAttribute[] obj = (CacheMappingsAttribute[])assembly.GetCustomAttributes(typeof(CacheMappingsAttribute), inherit: false);
			if (obj.Length == 0)
			{
				throw new ArgumentException($"The given assembly '{assembly.FullName}' does not contain any cache information for generated types.", "assembly");
			}
			foreach (KeyValuePair<CacheKey, string> deserializedMapping in obj[0].GetDeserializedMappings())
			{
				Type type = assembly.GetType(deserializedMapping.Value);
				if (type != null)
				{
					typeCache.AddOrUpdateWithoutTakingLock(deserializedMapping.Key, type);
				}
			}
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypeBuilder DefineType(bool inSignedModulePreferably, string name, TypeAttributes flags)
		{
			return ObtainDynamicModule(!disableSignedModule && inSignedModulePreferably).DefineType(name, flags);
		}
	}
}
