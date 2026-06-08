using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ProtoBuf.Internal;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	public sealed class AutoCompileTypeModel : TypeModel
	{
		private static readonly Hashtable s_assemblyModels = new Hashtable();

		public static TypeModel Instance { get; } = new AutoCompileTypeModel();

		public new static TypeModel CreateForAssembly<T>()
		{
			return CreateForAssembly(typeof(T).Assembly, null);
		}

		public new static TypeModel CreateForAssembly(Type type)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			return CreateForAssembly(type.Assembly, null);
		}

		public new static TypeModel CreateForAssembly(Assembly assembly)
		{
			return CreateForAssembly(assembly, null);
		}

		public static TypeModel CreateForAssembly(Assembly assembly, RuntimeTypeModel.CompilerOptions options)
		{
			if ((object)assembly == null)
			{
				ThrowHelper.ThrowArgumentNullException("assembly");
			}
			if (options == null)
			{
				TypeModel typeModel = (TypeModel)s_assemblyModels[assembly];
				if (typeModel != null)
				{
					return typeModel;
				}
			}
			return CreateForAssemblyImpl(assembly, options);
		}

		private AutoCompileTypeModel()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private TypeModel ForAssembly(Type type)
		{
			if ((object)type != null)
			{
				return CreateForAssembly(type.Assembly, null);
			}
			return NullModel.Singleton;
		}

		public override string GetSchema(SchemaGenerationOptions options)
		{
			return ForAssembly(options.HasTypes ? options.Types.First() : null).GetSchema(options);
		}

		protected override ISerializer<T> GetSerializer<T>()
		{
			return ForAssembly(typeof(T)).GetSerializerCore<T>(CompatibilityLevel.NotSpecified);
		}

		internal override bool IsKnownType<T>(CompatibilityLevel ambient)
		{
			return ForAssembly(typeof(T)).IsKnownType<T>(ambient);
		}

		private static TypeModel CreateForAssemblyImpl(Assembly assembly, RuntimeTypeModel.CompilerOptions options)
		{
			if ((object)assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			lock (assembly)
			{
				TypeModel typeModel = (TypeModel)s_assemblyModels[assembly];
				if (typeModel != null)
				{
					return typeModel;
				}
				RuntimeTypeModel runtimeTypeModel = null;
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsGenericTypeDefinition && RuntimeTypeModel.IsFullyPublic(type) && type.IsDefined(typeof(ProtoContractAttribute), inherit: true) && (options == null || options.OnIncludeType(type)))
					{
						(runtimeTypeModel ?? (runtimeTypeModel = RuntimeTypeModel.Create("CreateForAssemblyImpl"))).Add(type, applyDefaultBehaviour: true);
					}
				}
				if (runtimeTypeModel == null)
				{
					throw new InvalidOperationException("No types marked [ProtoContract] found in assembly '" + assembly.GetName().Name + "'");
				}
				TypeModel typeModel2 = runtimeTypeModel.Compile(options);
				s_assemblyModels[assembly] = typeModel2;
				return typeModel2;
			}
		}
	}
}
