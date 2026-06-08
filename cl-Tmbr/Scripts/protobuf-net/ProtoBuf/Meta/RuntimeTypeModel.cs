using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ProtoBuf.Compiler;
using ProtoBuf.Internal;
using ProtoBuf.Internal.Serializers;
using ProtoBuf.Serializers;
using ProtoBuf.WellKnownTypes;

namespace ProtoBuf.Meta
{
	public sealed class RuntimeTypeModel : TypeModel
	{
		private enum RuntimeTypeModelOptions
		{
			None = 0,
			InternStrings = 1,
			IncludeDateTimeKind = 2,
			SkipZeroLengthPackedArrays = 4,
			AllowPackedEncodingAtRoot = 8,
			TypeModelMask = 15,
			InferTagFromNameDefault = 1024,
			IsDefaultModel = 2048,
			Frozen = 4096,
			AutoAddMissingTypes = 8192,
			AutoCompile = 16384,
			UseImplicitZeroDefaults = 32768,
			AllowParseableTypes = 65536,
			AutoAddProtoContractTypesOnly = 131072
		}

		internal static class CommonImports
		{
			public const string Bcl = "protobuf-net/bcl.proto";

			public const string WrappersProto = "google/protobuf/wrappers.proto";

			public const string Timestamp = "google/protobuf/timestamp.proto";

			public const string Duration = "google/protobuf/duration.proto";

			public const string Protogen = "protobuf-net/protogen.proto";

			public const string Empty = "google/protobuf/empty.proto";
		}

		private sealed class BasicType
		{
			public Type Type { get; }

			public IRuntimeProtoSerializerNode Serializer { get; }

			public BasicType(Type type, IRuntimeProtoSerializerNode serializer)
			{
				Type = type;
				Serializer = serializer;
			}
		}

		internal sealed class SerializerPair : IComparable
		{
			public readonly int MetaKey;

			public readonly int BaseKey;

			public readonly MetaType Type;

			public readonly MethodBuilder Serialize;

			public readonly MethodBuilder Deserialize;

			public readonly ILGenerator SerializeBody;

			public readonly ILGenerator DeserializeBody;

			int IComparable.CompareTo(object obj)
			{
				if (obj == null)
				{
					throw new ArgumentNullException("obj");
				}
				SerializerPair serializerPair = (SerializerPair)obj;
				if (BaseKey == MetaKey)
				{
					if (serializerPair.BaseKey == serializerPair.MetaKey)
					{
						return MetaKey.CompareTo(serializerPair.MetaKey);
					}
					return 1;
				}
				if (serializerPair.BaseKey == serializerPair.MetaKey)
				{
					return -1;
				}
				int num = BaseKey.CompareTo(serializerPair.BaseKey);
				if (num == 0)
				{
					num = MetaKey.CompareTo(serializerPair.MetaKey);
				}
				return num;
			}

			public SerializerPair(int metaKey, int baseKey, MetaType type, MethodBuilder serialize, MethodBuilder deserialize, ILGenerator serializeBody, ILGenerator deserializeBody)
			{
				MetaKey = metaKey;
				BaseKey = baseKey;
				Serialize = serialize;
				Deserialize = deserialize;
				SerializeBody = serializeBody;
				DeserializeBody = deserializeBody;
				Type = type;
			}
		}

		public sealed class CompilerOptions
		{
			internal const string NoPersistence = "Assembly persistence not supported on this runtime";

			public string TargetFrameworkName { get; set; }

			public string TargetFrameworkDisplayName { get; set; }

			public string TypeName { get; set; }

			[Obsolete("Assembly persistence not supported on this runtime")]
			public string OutputPath { get; set; }

			public string ImageRuntimeVersion { get; set; }

			public int MetaDataVersion { get; set; }

			public string AssemblyCompanyName { get; set; }

			public string AssemblyCopyright { get; set; }

			public string AssemblyDescription { get; set; }

			public string AssemblyProductName { get; set; }

			public string AssemblyTitle { get; set; }

			public string AssemblyTrademark { get; set; }

			public Version AssemblyVersion { get; set; }

			public Version AssemblyProductVersion { get; set; }

			public Accessibility Accessibility { get; set; }

			public event Func<Type, bool> IncludeType;

			public void SetFrameworkOptions(MetaType from)
			{
				if (from == null)
				{
					throw new ArgumentNullException("from");
				}
				AttributeMap[] array = AttributeMap.Create(from.Type.Assembly);
				AttributeMap[] array2 = array;
				foreach (AttributeMap attributeMap in array2)
				{
					if (attributeMap.AttributeType.FullName == "System.Runtime.Versioning.TargetFrameworkAttribute")
					{
						if (attributeMap.TryGet("FrameworkName", out var value))
						{
							TargetFrameworkName = (string)value;
						}
						if (attributeMap.TryGet("FrameworkDisplayName", out value))
						{
							TargetFrameworkDisplayName = (string)value;
						}
						break;
					}
				}
			}

			internal bool OnIncludeType(Type type)
			{
				return this.IncludeType?.Invoke(type) ?? true;
			}
		}

		public enum Accessibility
		{
			Public = 0,
			Internal = 1
		}

		private RuntimeTypeModelOptions _options;

		private CompatibilityLevel _defaultCompatibilityLevel = CompatibilityLevel.Level200;

		private static readonly BasicList.MatchPredicate BasicTypeFinder = (object value, object ctx) => ((BasicType)value).Type == (Type)ctx;

		private static readonly BasicList.MatchPredicate MetaTypeFinder = (object value, object ctx) => ((MetaType)value).Type == (Type)ctx;

		private readonly BasicList types = new BasicList();

		private readonly BasicList basicTypes = new BasicList();

		private readonly Hashtable _serviceCache = new Hashtable();

		private int metadataTimeoutMilliseconds = 5000;

		private int contentionCounter = 1;

		private MethodInfo defaultFactory;

		private readonly string _name;

		private static readonly object s_ModelSyncLock = new object();

		private Hashtable _externalProviders;

		public override TypeModelOptions Options => (TypeModelOptions)(_options & RuntimeTypeModelOptions.TypeModelMask);

		internal CompilerContextScope Scope { get; } = CompilerContextScope.CreateInProcess();

		public bool InferTagFromNameDefault
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.InferTagFromNameDefault);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.InferTagFromNameDefault, value);
			}
		}

		public bool AutoAddProtoContractTypesOnly
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.AutoAddProtoContractTypesOnly);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.AutoAddProtoContractTypesOnly, value);
			}
		}

		public bool UseImplicitZeroDefaults
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.UseImplicitZeroDefaults);
			}
			set
			{
				if (!value && GetOption(RuntimeTypeModelOptions.IsDefaultModel))
				{
					ThrowDefaultUseImplicitZeroDefaults();
				}
				SetOption(RuntimeTypeModelOptions.UseImplicitZeroDefaults, value);
			}
		}

		public bool AllowParseableTypes
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.AllowParseableTypes);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.AllowParseableTypes, value);
			}
		}

		public bool IncludeDateTimeKind
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.IncludeDateTimeKind);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.IncludeDateTimeKind, value);
			}
		}

		public bool SkipZeroLengthPackedArrays
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.SkipZeroLengthPackedArrays);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.SkipZeroLengthPackedArrays, value);
			}
		}

		public bool AllowPackedEncodingAtRoot
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.AllowPackedEncodingAtRoot);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.AllowPackedEncodingAtRoot, value);
			}
		}

		public bool InternStrings
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.InternStrings);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.InternStrings, value);
			}
		}

		public static RuntimeTypeModel Default => (TypeModel.DefaultModel as RuntimeTypeModel) ?? CreateDefaultModelInstance();

		public CompatibilityLevel DefaultCompatibilityLevel
		{
			get
			{
				return _defaultCompatibilityLevel;
			}
			set
			{
				if (value != _defaultCompatibilityLevel)
				{
					CompatibilityLevelAttribute.AssertValid(value);
					ThrowIfFrozen();
					if (GetOption(RuntimeTypeModelOptions.IsDefaultModel))
					{
						ThrowHelper.ThrowInvalidOperationException("The default compatibility level of the default model cannot be changed");
					}
					if (types.Any())
					{
						ThrowHelper.ThrowInvalidOperationException("The default compatibility level of cannot be changed once types have been added");
					}
					_defaultCompatibilityLevel = value;
				}
			}
		}

		public MetaType this[Type type] => (MetaType)types[FindOrAddAuto(type, demand: true, addWithContractOnly: false, addEvenIfAutoDisabled: false, DefaultCompatibilityLevel)];

		public bool AutoCompile
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.AutoCompile);
			}
			set
			{
				SetOption(RuntimeTypeModelOptions.AutoCompile, value);
			}
		}

		public bool AutoAddMissingTypes
		{
			get
			{
				return GetOption(RuntimeTypeModelOptions.AutoAddMissingTypes);
			}
			set
			{
				if (!value && GetOption(RuntimeTypeModelOptions.IsDefaultModel))
				{
					ThrowDefaultAutoAddMissingTypes();
				}
				ThrowIfFrozen();
				SetOption(RuntimeTypeModelOptions.AutoAddMissingTypes, value);
			}
		}

		public int MetadataTimeoutMilliseconds
		{
			get
			{
				return metadataTimeoutMilliseconds;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("MetadataTimeoutMilliseconds");
				}
				metadataTimeoutMilliseconds = value;
			}
		}

		public event EventHandler<TypeAddedEventArgs> BeforeApplyDefaultBehaviour;

		public event EventHandler<TypeAddedEventArgs> AfterApplyDefaultBehaviour;

		public event LockContentedEventHandler LockContended;

		public static void Initialize()
		{
			_ = Default;
		}

		private bool GetOption(RuntimeTypeModelOptions option)
		{
			return (_options & option) != 0;
		}

		private void SetOption(RuntimeTypeModelOptions option, bool value)
		{
			if (value)
			{
				_options |= option;
			}
			else
			{
				_options &= ~option;
			}
		}

		public IEnumerable GetTypes()
		{
			return types;
		}

		public override string GetSchema(SchemaGenerationOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			ProtoSyntax protoSyntax = Serializer.GlobalOptions.Normalize(options.Syntax);
			List<MetaType> requiredTypes = new List<MetaType>();
			List<Type> list = null;
			HashSet<Type> forceGenerationTypes = null;
			string package = options.Package;
			string origin = options.Origin;
			HashSet<string> imports = new HashSet<string>(StringComparer.Ordinal);
			if (!options.HasTypes && !options.HasServices)
			{
				BasicList.NodeEnumerator enumerator = types.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MetaType metaType = (MetaType)enumerator.Current;
					MetaType surrogateOrBaseOrSelf = metaType.GetSurrogateOrBaseOrSelf(deep: false);
					AddMetaType(surrogateOrBaseOrSelf);
				}
			}
			else
			{
				if (options.HasTypes)
				{
					foreach (Type type2 in options.Types)
					{
						Type type = Nullable.GetUnderlyingType(type2) ?? type2;
						if (ValueMember.TryGetCoreSerializer(this, DataFormat.Default, DefaultCompatibilityLevel, type, out var _, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) != null)
						{
							(list ?? (list = new List<Type>())).Add(type);
							continue;
						}
						bool flag = options.Types.Count == 1;
						MetaType metaType2 = AddType(type, flag, flag);
					}
				}
				if (options.HasServices)
				{
					foreach (Service service in options.Services)
					{
						foreach (ServiceMethod method in service.Methods)
						{
							AddType(method.InputType, forceOutput: true, inferPackageAndOrigin: false);
							AddType(method.OutputType, forceOutput: true, inferPackageAndOrigin: false);
						}
					}
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (package == null)
			{
				IEnumerable<MetaType> enumerable;
				if (!options.HasTypes && !options.HasServices)
				{
					enumerable = types.Cast<MetaType>();
				}
				else
				{
					IEnumerable<MetaType> enumerable2 = requiredTypes;
					enumerable = enumerable2;
				}
				IEnumerable<MetaType> enumerable3 = enumerable;
				foreach (MetaType item in enumerable3)
				{
					if (TryGetRepeatedProvider(item.Type) != null)
					{
						continue;
					}
					string text = item.Type.Namespace;
					if (!string.IsNullOrEmpty(text) && !text.StartsWith("System."))
					{
						if (package == null)
						{
							package = text;
						}
						else if (!(package == text))
						{
							package = null;
							break;
						}
					}
				}
			}
			switch (protoSyntax)
			{
			case ProtoSyntax.Proto2:
				stringBuilder.AppendLine("syntax = \"proto2\";");
				break;
			case ProtoSyntax.Proto3:
				stringBuilder.AppendLine("syntax = \"proto3\";");
				break;
			default:
				throw new ArgumentOutOfRangeException("syntax");
			}
			if (!string.IsNullOrEmpty(package))
			{
				stringBuilder.Append("package ").Append(package).Append(';')
					.AppendLine();
			}
			foreach (MetaType item2 in requiredTypes)
			{
				_ = item2.Serializer;
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			HashSet<Type> callstack = new HashSet<Type>();
			MetaType[] array = new MetaType[requiredTypes.Count];
			requiredTypes.CopyTo(array, 0);
			Array.Sort(array, new MetaType.Comparer(callstack));
			if (list != null)
			{
				foreach (Type item3 in list)
				{
					stringBuilder2.AppendLine().Append("message ").Append(item3.Name)
						.Append(" {");
					MetaType.NewLine(stringBuilder2, 1).Append((protoSyntax == ProtoSyntax.Proto2) ? "optional " : "").Append(GetSchemaTypeName(callstack, item3, DataFormat.Default, DefaultCompatibilityLevel, asReference: false, dynamicType: false, imports))
						.Append(" value = 1;")
						.AppendLine()
						.Append('}');
				}
			}
			foreach (MetaType metaType3 in array)
			{
				if ((object)metaType3.SerializerType == null && (IsOutputForcedFor(metaType3.Type) || TryGetRepeatedProvider(metaType3.Type) == null))
				{
					metaType3.WriteSchema(callstack, stringBuilder2, 0, imports, protoSyntax, package, options.Flags);
				}
			}
			if (options.HasServices)
			{
				foreach (Service service2 in options.Services)
				{
					MetaType.NewLine(stringBuilder2, 0).Append("service ").Append(service2.Name)
						.Append(" {");
					foreach (ServiceMethod method2 in service2.Methods)
					{
						string schemaTypeName = GetSchemaTypeName(callstack, method2.InputType, DataFormat.Default, DefaultCompatibilityLevel, asReference: false, dynamicType: false, imports);
						string schemaTypeName2 = GetSchemaTypeName(callstack, method2.OutputType, DataFormat.Default, DefaultCompatibilityLevel, asReference: false, dynamicType: false, imports);
						MetaType.NewLine(stringBuilder2, 1).Append("rpc ").Append(method2.Name)
							.Append(" (")
							.Append(method2.ClientStreaming ? "stream " : "")
							.Append(schemaTypeName)
							.Append(") returns (")
							.Append(method2.ServerStreaming ? "stream " : "")
							.Append(schemaTypeName2)
							.Append(");");
					}
					MetaType.NewLine(stringBuilder2, 0).Append('}');
				}
			}
			foreach (string item4 in imports.OrderBy((string _) => _))
			{
				if (string.IsNullOrWhiteSpace(item4))
				{
					continue;
				}
				stringBuilder.Append("import \"").Append(item4).Append("\";");
				if (!(item4 == "protobuf-net/bcl.proto"))
				{
					if (item4 == "protobuf-net/protogen.proto")
					{
						stringBuilder.Append(" // custom protobuf-net options");
					}
				}
				else
				{
					stringBuilder.Append(" // schema for protobuf-net's handling of core .NET types");
				}
				stringBuilder.AppendLine();
			}
			return stringBuilder.Append(stringBuilder2).AppendLine().ToString();
			void AddMetaType(MetaType toAdd)
			{
				if (!string.IsNullOrWhiteSpace(toAdd.Origin) && toAdd.Origin != origin)
				{
					imports.Add(toAdd.Origin);
				}
				else if (!requiredTypes.Contains(toAdd))
				{
					requiredTypes.Add(toAdd);
					CascadeDependents(requiredTypes, toAdd, imports, origin);
				}
			}
			MetaType AddType(Type type2, bool forceOutput, bool inferPackageAndOrigin)
			{
				if (forceOutput && (object)type2 != null)
				{
					(forceGenerationTypes ?? (forceGenerationTypes = new HashSet<Type>())).Add(type2);
				}
				int num = FindOrAddAuto(type2, demand: false, addWithContractOnly: false, addEvenIfAutoDisabled: false, DefaultCompatibilityLevel);
				if (num < 0)
				{
					throw new ArgumentException("The type specified is not a contract-type: '" + type2.NormalizeName() + "'", "type");
				}
				MetaType surrogateOrBaseOrSelf2 = ((MetaType)types[num]).GetSurrogateOrBaseOrSelf(deep: false);
				if (inferPackageAndOrigin)
				{
					if (origin == null && !string.IsNullOrWhiteSpace(surrogateOrBaseOrSelf2.Origin))
					{
						origin = surrogateOrBaseOrSelf2.Origin;
					}
					string text2;
					if (package == null && !string.IsNullOrWhiteSpace(text2 = surrogateOrBaseOrSelf2.GuessPackage()))
					{
						package = text2;
					}
				}
				AddMetaType(surrogateOrBaseOrSelf2);
				return surrogateOrBaseOrSelf2;
			}
			bool IsOutputForcedFor(Type item)
			{
				return forceGenerationTypes?.Contains(item) ?? false;
			}
		}

		private void CascadeRepeated(List<MetaType> list, RepeatedSerializerStub provider, CompatibilityLevel ambient, DataFormat keyFormat, HashSet<string> imports, string origin)
		{
			if (provider.IsMap)
			{
				provider.ResolveMapTypes(out var keyType, out var valueType);
				TryGetCoreSerializer(list, keyType, ambient, imports, origin);
				TryGetCoreSerializer(list, valueType, ambient, imports, origin);
				if (!provider.IsValidProtobufMap(this, ambient, keyFormat))
				{
					TryGetCoreSerializer(list, provider.ItemType, ambient, imports, origin);
				}
			}
			else
			{
				TryGetCoreSerializer(list, provider.ItemType, ambient, imports, origin);
			}
		}

		private void CascadeDependents(List<MetaType> list, MetaType metaType, HashSet<string> imports, string origin)
		{
			RepeatedSerializerStub repeatedSerializerStub = TryGetRepeatedProvider(metaType.Type);
			if (repeatedSerializerStub != null)
			{
				CascadeRepeated(list, repeatedSerializerStub, metaType.CompatibilityLevel, DataFormat.Default, imports, origin);
				return;
			}
			if (metaType.IsAutoTuple)
			{
				if ((object)MetaType.ResolveTupleConstructor(metaType.Type, out var mappedMembers) != null)
				{
					for (int i = 0; i < mappedMembers.Length; i++)
					{
						Type itemType = null;
						if (mappedMembers[i] is PropertyInfo propertyInfo)
						{
							itemType = propertyInfo.PropertyType;
						}
						else if (mappedMembers[i] is FieldInfo fieldInfo)
						{
							itemType = fieldInfo.FieldType;
						}
						TryGetCoreSerializer(list, itemType, metaType.CompatibilityLevel, imports, origin);
					}
				}
			}
			else
			{
				foreach (ValueMember field in metaType.Fields)
				{
					repeatedSerializerStub = TryGetRepeatedProvider(field.MemberType);
					if (repeatedSerializerStub != null)
					{
						CascadeRepeated(list, repeatedSerializerStub, field.CompatibilityLevel, field.MapKeyFormat, imports, origin);
						if (repeatedSerializerStub.IsMap && !field.IsMap)
						{
							TryGetCoreSerializer(list, repeatedSerializerStub.ItemType, field.CompatibilityLevel, imports, origin);
						}
					}
					else
					{
						TryGetCoreSerializer(list, field.MemberType, field.CompatibilityLevel, imports, origin);
					}
				}
			}
			foreach (Type allGenericArgument in metaType.GetAllGenericArguments())
			{
				repeatedSerializerStub = TryGetRepeatedProvider(allGenericArgument);
				if (repeatedSerializerStub != null)
				{
					CascadeRepeated(list, repeatedSerializerStub, metaType.CompatibilityLevel, DataFormat.Default, imports, origin);
				}
				else
				{
					TryGetCoreSerializer(list, allGenericArgument, metaType.CompatibilityLevel, imports, origin);
				}
			}
			MetaType surrogateOrSelf;
			if (metaType.HasSubtypes)
			{
				SubType[] subtypes = metaType.GetSubtypes();
				foreach (SubType subType in subtypes)
				{
					surrogateOrSelf = subType.DerivedType.GetSurrogateOrSelf();
					if (!list.Contains(surrogateOrSelf))
					{
						list.Add(surrogateOrSelf);
						CascadeDependents(list, surrogateOrSelf, imports, origin);
					}
				}
			}
			surrogateOrSelf = metaType.BaseType;
			if (surrogateOrSelf != null)
			{
				surrogateOrSelf = surrogateOrSelf.GetSurrogateOrSelf();
			}
			if (surrogateOrSelf != null && !list.Contains(surrogateOrSelf))
			{
				list.Add(surrogateOrSelf);
				CascadeDependents(list, surrogateOrSelf, imports, origin);
			}
		}

		private void TryGetCoreSerializer(List<MetaType> list, Type itemType, CompatibilityLevel ambient, HashSet<string> imports, string origin)
		{
			IRuntimeProtoSerializerNode runtimeProtoSerializerNode = ValueMember.TryGetCoreSerializer(this, DataFormat.Default, CompatibilityLevel.NotSpecified, itemType, out var defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
			if (runtimeProtoSerializerNode != null)
			{
				return;
			}
			int num = FindOrAddAuto(itemType, demand: false, addWithContractOnly: false, addEvenIfAutoDisabled: false, ambient);
			if (num < 0)
			{
				return;
			}
			MetaType metaType = (MetaType)types[num];
			if (metaType.HasSurrogate)
			{
				runtimeProtoSerializerNode = ValueMember.TryGetCoreSerializer(this, metaType.surrogateDataFormat, metaType.CompatibilityLevel, metaType.surrogateType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
				if (runtimeProtoSerializerNode != null)
				{
					return;
				}
			}
			MetaType surrogateOrBaseOrSelf = metaType.GetSurrogateOrBaseOrSelf(deep: false);
			if (!string.IsNullOrWhiteSpace(surrogateOrBaseOrSelf.Origin) && surrogateOrBaseOrSelf.Origin != origin)
			{
				imports.Add(surrogateOrBaseOrSelf.Origin);
			}
			else if (!list.Contains(surrogateOrBaseOrSelf))
			{
				list.Add(surrogateOrBaseOrSelf);
				CascadeDependents(list, surrogateOrBaseOrSelf, imports, origin);
			}
		}

		internal RuntimeTypeModel(bool isDefault, string name)
		{
			AutoAddMissingTypes = true;
			UseImplicitZeroDefaults = true;
			SetOption(RuntimeTypeModelOptions.IsDefaultModel, isDefault);
			try
			{
				AutoCompile = EnableAutoCompile();
			}
			catch
			{
			}
			if (!string.IsNullOrWhiteSpace(name))
			{
				_name = name;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool EnableAutoCompile()
		{
			try
			{
				DynamicMethod dynamicMethod = new DynamicMethod("CheckCompilerAvailable", typeof(bool), new Type[1] { typeof(int) });
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Ldc_I4, 42);
				iLGenerator.Emit(OpCodes.Ceq);
				iLGenerator.Emit(OpCodes.Ret);
				Predicate<int> predicate = (Predicate<int>)dynamicMethod.CreateDelegate(typeof(Predicate<int>));
				return predicate(42);
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal MetaType FindWithAmbientCompatibility(Type type, CompatibilityLevel ambient)
		{
			MetaType metaType = (MetaType)types[FindOrAddAuto(type, demand: true, addWithContractOnly: false, addEvenIfAutoDisabled: false, ambient)];
			if (metaType != null && metaType.IsAutoTuple && metaType.CompatibilityLevel != ambient)
			{
				throw new InvalidOperationException($"The tuple-like type {type.NormalizeName()} must use a single compatibility level, but '{ambient}' and '{metaType.CompatibilityLevel}' are both observed; this usually means it is being used in different contexts in the same model.");
			}
			return metaType;
		}

		internal MetaType FindWithoutAdd(Type type)
		{
			type = DynamicStub.GetEffectiveType(type);
			BasicList.NodeEnumerator enumerator = types.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MetaType metaType = (MetaType)enumerator.Current;
				if (metaType.Type == type)
				{
					if (metaType.Pending)
					{
						WaitOnLock();
					}
					return metaType;
				}
			}
			return null;
		}

		private void WaitOnLock()
		{
			int opaqueToken = 0;
			try
			{
				TakeLock(ref opaqueToken);
			}
			finally
			{
				ReleaseLock(opaqueToken);
			}
		}

		internal IRuntimeProtoSerializerNode TryGetBasicTypeSerializer(Type type)
		{
			int num = basicTypes.IndexOf(BasicTypeFinder, type);
			if (num >= 0)
			{
				return ((BasicType)basicTypes[num]).Serializer;
			}
			lock (basicTypes)
			{
				num = basicTypes.IndexOf(BasicTypeFinder, type);
				if (num >= 0)
				{
					return ((BasicType)basicTypes[num]).Serializer;
				}
				WireType defaultWireType;
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = ((MetaType.GetContractFamily(this, type, null) == MetaType.AttributeFamily.None) ? ValueMember.TryGetCoreSerializer(this, DataFormat.Default, CompatibilityLevel.NotSpecified, type, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) : null);
				if (runtimeProtoSerializerNode != null)
				{
					basicTypes.Add(new BasicType(type, runtimeProtoSerializerNode));
				}
				return runtimeProtoSerializerNode;
			}
		}

		internal int FindOrAddAuto(Type type, bool demand, bool addWithContractOnly, bool addEvenIfAutoDisabled, CompatibilityLevel ambient)
		{
			type = DynamicStub.GetEffectiveType(type);
			int num = types.IndexOf(MetaTypeFinder, type);
			if (num >= 0)
			{
				MetaType metaType = (MetaType)types[num];
				if (metaType.Pending)
				{
					WaitOnLock();
				}
				return num;
			}
			bool flag = AutoAddMissingTypes || addEvenIfAutoDisabled;
			if (!type.IsEnum && TryGetBasicTypeSerializer(type) != null)
			{
				if (flag && !addWithContractOnly)
				{
					throw MetaType.InbuiltType(type);
				}
				return -1;
			}
			if (num < 0)
			{
				int opaqueToken = 0;
				bool flag2 = false;
				try
				{
					TakeLock(ref opaqueToken);
					MetaType metaType;
					if ((metaType = RecogniseCommonTypes(type)) == null)
					{
						MetaType.AttributeFamily contractFamily = MetaType.GetContractFamily(this, type, null);
						if (contractFamily == MetaType.AttributeFamily.AutoTuple)
						{
							flag = (addEvenIfAutoDisabled = true);
						}
						if (!flag || (!type.IsEnum && addWithContractOnly && contractFamily == MetaType.AttributeFamily.None))
						{
							if (demand)
							{
								TypeModel.ThrowUnexpectedType(type, this);
							}
							return num;
						}
						metaType = Create(type);
					}
					metaType.Pending = true;
					int num2 = types.IndexOf(MetaTypeFinder, type);
					if (num2 < 0)
					{
						ThrowIfFrozen();
						num = types.Add(metaType);
						flag2 = true;
					}
					else
					{
						num = num2;
					}
					if (flag2)
					{
						metaType.ApplyDefaultBehaviour(ambient);
						metaType.Pending = false;
					}
				}
				finally
				{
					ReleaseLock(opaqueToken);
				}
			}
			return num;
		}

		private MetaType RecogniseCommonTypes(Type type)
		{
			return null;
		}

		private MetaType Create(Type type)
		{
			ThrowIfFrozen();
			return new MetaType(this, type, defaultFactory);
		}

		public MetaType Add<T>(bool applyDefaultBehaviour = true, CompatibilityLevel compatibilityLevel = CompatibilityLevel.NotSpecified)
		{
			return Add(typeof(T), applyDefaultBehaviour, compatibilityLevel);
		}

		public MetaType Add(Type type, bool applyDefaultBehaviour)
		{
			return Add(type, applyDefaultBehaviour, CompatibilityLevel.NotSpecified);
		}

		public MetaType Add(Type type, bool applyDefaultBehaviour = true, CompatibilityLevel compatibilityLevel = CompatibilityLevel.NotSpecified)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type == typeof(object))
			{
				throw new ArgumentException("You cannot reconfigure " + type.FullName);
			}
			type = DynamicStub.GetEffectiveType(type);
			MetaType metaType = FindWithoutAdd(type);
			if (metaType != null)
			{
				if (compatibilityLevel != CompatibilityLevel.NotSpecified)
				{
					metaType.Assert(compatibilityLevel);
				}
				return metaType;
			}
			int opaqueToken = 0;
			try
			{
				metaType = RecogniseCommonTypes(type);
				if (metaType != null)
				{
					if (!applyDefaultBehaviour)
					{
						throw new ArgumentException("Default behaviour must be observed for certain types with special handling; " + type.FullName, "applyDefaultBehaviour");
					}
					applyDefaultBehaviour = false;
				}
				if (metaType == null)
				{
					metaType = Create(type);
				}
				metaType.CompatibilityLevel = compatibilityLevel;
				metaType.Pending = true;
				TakeLock(ref opaqueToken);
				if (FindWithoutAdd(type) != null)
				{
					throw new ArgumentException("Duplicate type", "type");
				}
				ThrowIfFrozen();
				types.Add(metaType);
				if (applyDefaultBehaviour)
				{
					metaType.ApplyDefaultBehaviour(CompatibilityLevel.NotSpecified);
				}
				metaType.Pending = false;
				return metaType;
			}
			finally
			{
				ReleaseLock(opaqueToken);
			}
		}

		internal static void OnBeforeApplyDefaultBehaviour(MetaType metaType, ref TypeAddedEventArgs args)
		{
			OnApplyDefaultBehaviour(metaType?.Model?.BeforeApplyDefaultBehaviour, metaType, ref args);
		}

		internal static void OnAfterApplyDefaultBehaviour(MetaType metaType, ref TypeAddedEventArgs args)
		{
			OnApplyDefaultBehaviour(metaType?.Model?.AfterApplyDefaultBehaviour, metaType, ref args);
		}

		private static void OnApplyDefaultBehaviour(EventHandler<TypeAddedEventArgs> handler, MetaType metaType, ref TypeAddedEventArgs args)
		{
			if (handler != null)
			{
				if (args == null)
				{
					args = new TypeAddedEventArgs(metaType);
				}
				handler(metaType.Model, args);
			}
		}

		private void ThrowIfFrozen()
		{
			if (GetOption(RuntimeTypeModelOptions.Frozen))
			{
				throw new InvalidOperationException("The model cannot be changed once frozen");
			}
		}

		public void Freeze()
		{
			if (GetOption(RuntimeTypeModelOptions.IsDefaultModel))
			{
				ThrowDefaultFrozen();
			}
			SetOption(RuntimeTypeModelOptions.Frozen, value: true);
		}

		protected override ISerializer<T> GetSerializer<T>()
		{
			return GetServices<T>(CompatibilityLevel.NotSpecified) as ISerializer<T>;
		}

		internal override ISerializer<T> GetSerializerCore<T>(CompatibilityLevel ambient)
		{
			return GetServices<T>(ambient) as ISerializer<T>;
		}

		internal override bool IsKnownType<T>(CompatibilityLevel ambient)
		{
			if (_serviceCache[typeof(T)] == null)
			{
				return FindOrAddAuto(typeof(T), demand: false, addWithContractOnly: true, addEvenIfAutoDisabled: false, ambient) >= 0;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private object GetServices<T>(CompatibilityLevel ambient)
		{
			return _serviceCache[typeof(T)] ?? GetServicesSlow(typeof(T), ambient);
		}

		internal void ResetServiceCache(Type type)
		{
			if ((object)type != null)
			{
				lock (_serviceCache)
				{
					_serviceCache.Remove(type);
				}
			}
		}

		private object GetServicesSlow(Type type, CompatibilityLevel ambient)
		{
			if ((object)type == null)
			{
				return null;
			}
			object obj;
			lock (_serviceCache)
			{
				obj = _serviceCache[type];
				if (obj != null)
				{
					return obj;
				}
			}
			obj = GetServicesImpl(this, type, ambient);
			if (obj != null)
			{
				try
				{
					_ = this[type];
				}
				catch
				{
				}
				lock (_serviceCache)
				{
					_serviceCache[type] = obj;
				}
			}
			return obj;
			static object GetServicesImpl(RuntimeTypeModel model, Type type2, CompatibilityLevel ambient2)
			{
				if (type2.IsEnum)
				{
					return EnumSerializers.GetSerializer(type2);
				}
				Type underlyingType = Nullable.GetUnderlyingType(type2);
				if ((object)underlyingType != null)
				{
					return model.GetServicesSlow(underlyingType, ambient2);
				}
				RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(type2);
				if (repeatedSerializerStub != null)
				{
					return repeatedSerializerStub.Serializer;
				}
				int num = model.FindOrAddAuto(type2, demand: false, addWithContractOnly: true, addEvenIfAutoDisabled: false, ambient2);
				if (num >= 0)
				{
					MetaType metaType = (MetaType)model.types[num];
					IProtoTypeSerializer serializer = metaType.Serializer;
					if (serializer is IExternalSerializer externalSerializer)
					{
						return externalSerializer.Service;
					}
					return serializer;
				}
				return null;
			}
		}

		public override string ToString()
		{
			return _name ?? base.ToString();
		}

		internal ProtoSerializer<TActual> GetSerializer<TActual>(IRuntimeProtoSerializerNode serializer, bool compiled)
		{
			if (serializer == null)
			{
				throw new ArgumentNullException("serializer");
			}
			if (compiled)
			{
				return CompilerContext.BuildSerializer<TActual>(Scope, serializer, this);
			}
			return delegate(ref ProtoWriter.State state, TActual val)
			{
				serializer.Write(ref state, val);
			};
		}

		public void CompileInPlace()
		{
			BasicList.NodeEnumerator enumerator = types.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MetaType metaType = (MetaType)enumerator.Current;
				metaType.CompileInPlace();
			}
		}

		private void BuildAllSerializers()
		{
			for (int i = 0; i < types.Count; i++)
			{
				MetaType metaType = (MetaType)types[i];
				if (GetServicesSlow(metaType.Type, metaType.CompatibilityLevel) == null)
				{
					throw new InvalidOperationException("No serializer available for " + metaType.Type.NormalizeName());
				}
			}
		}

		internal static ILGenerator Override(TypeBuilder type, string name)
		{
			Type[] genericArgs;
			return Override(type, name, out genericArgs);
		}

		internal static ILGenerator Override(TypeBuilder type, string name, out Type[] genericArgs)
		{
			MethodInfo method;
			try
			{
				method = type.BaseType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if ((object)method == null)
				{
					throw new ArgumentException("Unable to resolve '" + name + "'");
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Unable to resolve '" + name + "': " + ex.Message, "name", ex);
			}
			ParameterInfo[] parameters = method.GetParameters();
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = parameters[i].ParameterType;
			}
			MethodBuilder methodBuilder = type.DefineMethod(method.Name, (method.Attributes & ~(MethodAttributes.VtableLayoutMask | MethodAttributes.Abstract)) | MethodAttributes.Final, method.CallingConvention, method.ReturnType, array);
			if (method.IsGenericMethodDefinition)
			{
				genericArgs = method.GetGenericArguments();
				string[] names = Array.ConvertAll(genericArgs, (Type x) => x.Name);
				methodBuilder.DefineGenericParameters(names);
			}
			else
			{
				genericArgs = Type.EmptyTypes;
			}
			for (int num = 0; num < parameters.Length; num++)
			{
				methodBuilder.DefineParameter(num + 1, parameters[num].Attributes, parameters[num].Name);
			}
			ILGenerator iLGenerator = methodBuilder.GetILGenerator();
			type.DefineMethodOverride(methodBuilder, method);
			return iLGenerator;
		}

		public TypeModel Compile(CompilerOptions options = null)
		{
			if (options == null)
			{
				options = new CompilerOptions();
			}
			string text = options.TypeName;
			string outputPath = options.OutputPath;
			BuildAllSerializers();
			Freeze();
			bool flag = !string.IsNullOrEmpty(outputPath);
			if (string.IsNullOrEmpty(text))
			{
				if (flag)
				{
					throw new ArgumentNullException("typeName");
				}
				text = "CompiledModel_" + Guid.NewGuid().ToString();
			}
			string text2;
			string name;
			if (outputPath == null)
			{
				text2 = text;
				name = text2 + ".dll";
			}
			else
			{
				text2 = new FileInfo(Path.GetFileNameWithoutExtension(outputPath)).Name;
				name = text2 + Path.GetExtension(outputPath);
			}
			AssemblyName name2 = new AssemblyName
			{
				Name = text2,
				Version = options.AssemblyVersion
			};
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(name2, AssemblyBuilderAccess.RunAndCollect);
			ModuleBuilder module = assemblyBuilder.DefineDynamicModule(name);
			CompilerContextScope scope = CompilerContextScope.CreateForModule(this, module, isFullEmit: true, text2);
			WriteAssemblyAttributes(options, text2, assemblyBuilder);
			TypeBuilder typeBuilder = WriteBasicTypeModel("___PBN_Services___" + text, module, typeof(object), @internal: true);
			WriteSerializers(scope, typeBuilder);
			WriteEnumsAndProxies(typeBuilder);
			Type serviceType = typeBuilder.CreateType();
			TypeBuilder typeBuilder2 = WriteBasicTypeModel(text, module, typeof(TypeModel), options.Accessibility == Accessibility.Internal);
			WriteConstructorsAndOverrides(typeBuilder2, serviceType);
			Type type = typeBuilder2.CreateType();
			if (!string.IsNullOrEmpty(outputPath))
			{
				throw new NotSupportedException("Assembly persistence not supported on this runtime");
			}
			return (TypeModel)Activator.CreateInstance(type, nonPublic: true);
		}

		private void WriteConstructorsAndOverrides(TypeBuilder type, Type serviceType)
		{
			TypeModelOptions options = Options;
			ILGenerator iLGenerator;
			if (options != TypeModelOptions.None)
			{
				iLGenerator = Override(type, "get_Options");
				CompilerContext.LoadValue(iLGenerator, (int)options);
				iLGenerator.Emit(OpCodes.Ret);
			}
			iLGenerator = Override(type, "GetSerializer", out var genericArgs);
			Type type2 = genericArgs.Single();
			MethodInfo methodInfo = typeof(SerializerCache).GetMethod("Get").MakeGenericMethod(serviceType, type2);
			iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
			iLGenerator.Emit(OpCodes.Ret);
			type.DefineDefaultConstructor(MethodAttributes.Public);
		}

		private void WriteEnumsAndProxies(TypeBuilder type)
		{
			for (int i = 0; i < types.Count; i++)
			{
				MetaType metaType = (MetaType)types[i];
				Type type2 = metaType.Type;
				RepeatedSerializerStub repeatedSerializerStub;
				if (type2.IsEnum)
				{
					MemberInfo provider = EnumSerializers.GetProvider(type2);
					AddProxy(type, type2, provider, includeNullable: true);
				}
				else if (ShouldEmitCustomSerializerProxy(metaType.SerializerType))
				{
					AddProxy(type, type2, metaType.SerializerType, includeNullable: false);
				}
				else if ((repeatedSerializerStub = TryGetRepeatedProvider(type2)) != null)
				{
					AddProxy(type, type2, repeatedSerializerStub.Provider, includeNullable: false);
				}
			}
			static bool ShouldEmitCustomSerializerProxy(Type serializerType)
			{
				if ((object)serializerType == null)
				{
					return false;
				}
				if (IsFullyPublic(serializerType))
				{
					return true;
				}
				return serializerType.Assembly != typeof(PrimaryTypeProvider).Assembly;
			}
		}

		internal static MemberInfo GetUnderlyingProvider(MemberInfo provider, Type forType)
		{
			MemberInfo memberInfo = provider;
			if (!(memberInfo is PropertyInfo propertyInfo))
			{
				if (memberInfo is Type { IsClass: not false, IsAbstract: false } type && (object)type.GetConstructor(Type.EmptyTypes) != null)
				{
					provider = typeof(SerializerCache).GetMethod("Get", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(type, forType);
				}
			}
			else
			{
				provider = propertyInfo.GetGetMethod(nonPublic: true);
			}
			return provider;
		}

		internal static void EmitProvider(MemberInfo provider, ILGenerator il)
		{
			if (!(provider is FieldInfo fieldInfo))
			{
				if (provider is MethodInfo { IsStatic: not false } methodInfo)
				{
					il.EmitCall(OpCodes.Call, methodInfo, null);
					return;
				}
			}
			else if (fieldInfo.IsStatic)
			{
				il.Emit(OpCodes.Ldsfld, fieldInfo);
				return;
			}
			ThrowHelper.ThrowInvalidOperationException($"Invalid provider: {provider}");
		}

		internal RepeatedSerializerStub TryGetRepeatedProvider(Type type, CompatibilityLevel ambient = CompatibilityLevel.NotSpecified)
		{
			if ((object)type == null)
			{
				return null;
			}
			RepeatedSerializerStub repeatedSerializerStub = RepeatedSerializers.TryGetRepeatedProvider(type, _externalProviders);
			if (repeatedSerializerStub != null)
			{
				int num = FindOrAddAuto(type, demand: false, addWithContractOnly: true, addEvenIfAutoDisabled: false, ambient);
				if (num >= 0 && ((MetaType)types[num]).IgnoreListHandling)
				{
					return null;
				}
			}
			return repeatedSerializerStub;
		}

		private static void AddProxy(TypeBuilder building, Type proxying, MemberInfo provider, bool includeNullable)
		{
			provider = GetUnderlyingProvider(provider, proxying);
			if ((object)provider != null)
			{
				Type interfaceType = typeof(ISerializerProxy<>).MakeGenericType(proxying);
				building.AddInterfaceImplementation(interfaceType);
				ILGenerator iLGenerator = CompilerContextScope.Implement(building, interfaceType, "get_Serializer");
				EmitProvider(provider, iLGenerator);
				iLGenerator.Emit(OpCodes.Ret);
				if (includeNullable)
				{
					interfaceType = typeof(ISerializerProxy<>).MakeGenericType(typeof(Nullable<>).MakeGenericType(proxying));
					building.AddInterfaceImplementation(interfaceType);
					iLGenerator = CompilerContextScope.Implement(building, interfaceType, "get_Serializer");
					EmitProvider(provider, iLGenerator);
					iLGenerator.Emit(OpCodes.Ret);
				}
			}
		}

		private void WriteSerializers(CompilerContextScope scope, TypeBuilder type)
		{
			Dictionary<SerializerFeatures, MethodInfo> featuresLookup = new Dictionary<SerializerFeatures, MethodInfo>();
			for (int i = 0; i < types.Count; i++)
			{
				MetaType metaType = (MetaType)types[i];
				IProtoTypeSerializer serializer = metaType.Serializer;
				Type type2 = metaType.Type;
				metaType.Validate();
				if (type2.IsEnum || (object)metaType.SerializerType != null || TryGetRepeatedProvider(metaType.Type) != null)
				{
					continue;
				}
				if (!IsFullyPublic(type2, out var cause))
				{
					ThrowHelper.ThrowInvalidOperationException("Non-public type cannot be used with full dll compilation: " + cause.NormalizeName());
				}
				Type inheritanceRoot = metaType.GetInheritanceRoot();
				Type type3 = typeof(ISerializer<>).MakeGenericType(type2);
				type.AddInterfaceImplementation(type3);
				ILGenerator il = CompilerContextScope.Implement(type, type3, "Read");
				using (CompilerContext compilerContext = new CompilerContext(scope, il, isStatic: false, CompilerContext.SignatureType.ReaderScope_Input, this, type2, "Read"))
				{
					if (serializer.HasInheritance)
					{
						serializer.EmitReadRoot(compilerContext, compilerContext.InputValue);
					}
					else
					{
						serializer.EmitRead(compilerContext, compilerContext.InputValue);
						compilerContext.LoadValue(compilerContext.InputValue);
					}
					compilerContext.Return();
				}
				il = CompilerContextScope.Implement(type, type3, "Write");
				using (CompilerContext compilerContext2 = new CompilerContext(scope, il, isStatic: false, CompilerContext.SignatureType.WriterScope_Input, this, type2, "Write"))
				{
					if (serializer.HasInheritance)
					{
						serializer.EmitWriteRoot(compilerContext2, compilerContext2.InputValue);
					}
					else
					{
						serializer.EmitWrite(compilerContext2, compilerContext2.InputValue);
					}
					compilerContext2.Return();
				}
				MethodInfo getMethod = type3.GetProperty("Features").GetGetMethod();
				type.DefineMethodOverride(GetFeaturesMethod(serializer.Features), getMethod);
				if (serializer.HasInheritance)
				{
					type3 = typeof(ISubTypeSerializer<>).MakeGenericType(type2);
					type.AddInterfaceImplementation(type3);
					il = CompilerContextScope.Implement(type, type3, "WriteSubType");
					using (CompilerContext compilerContext3 = new CompilerContext(scope, il, isStatic: false, CompilerContext.SignatureType.WriterScope_Input, this, type2, "WriteSubType"))
					{
						serializer.EmitWrite(compilerContext3, compilerContext3.InputValue);
						compilerContext3.Return();
					}
					il = CompilerContextScope.Implement(type, type3, "ReadSubType");
					using CompilerContext compilerContext4 = new CompilerContext(scope, il, isStatic: false, CompilerContext.SignatureType.ReaderScope_Input, this, typeof(SubTypeState<>).MakeGenericType(type2), "ReadSubType");
					serializer.EmitRead(compilerContext4, compilerContext4.InputValue);
					compilerContext4.Return();
				}
				if (serializer.ShouldEmitCreateInstance)
				{
					type3 = typeof(IFactory<>).MakeGenericType(type2);
					type.AddInterfaceImplementation(type3);
					il = CompilerContextScope.Implement(type, type3, "Create");
					using CompilerContext compilerContext5 = new CompilerContext(scope, il, isStatic: false, CompilerContext.SignatureType.Context, this, typeof(ISerializationContext), "Create");
					serializer.EmitCreateInstance(compilerContext5, callNoteObject: false);
					compilerContext5.Return();
				}
			}
			MethodInfo GetFeaturesMethod(SerializerFeatures features)
			{
				if (!featuresLookup.TryGetValue(features, out var value))
				{
					int num = (int)features;
					string name = "Features_" + num.ToString(CultureInfo.InvariantCulture);
					MethodBuilder methodBuilder = type.DefineMethod(name, MethodAttributes.Private | MethodAttributes.Virtual, typeof(SerializerFeatures), Type.EmptyTypes);
					ILGenerator iLGenerator = methodBuilder.GetILGenerator();
					CompilerContext.LoadValue(iLGenerator, (int)features);
					iLGenerator.Emit(OpCodes.Ret);
					return featuresLookup[features] = methodBuilder;
				}
				return value;
			}
		}

		private static TypeBuilder WriteBasicTypeModel(string typeName, ModuleBuilder module, Type baseType, bool @internal)
		{
			TypeAttributes typeAttributes = (baseType.Attributes & ~(TypeAttributes.Abstract | TypeAttributes.Serializable)) | TypeAttributes.Sealed;
			if (@internal)
			{
				typeAttributes &= ~TypeAttributes.Public;
			}
			return module.DefineType(typeName, typeAttributes, baseType);
		}

		private void WriteAssemblyAttributes(CompilerOptions options, string assemblyName, AssemblyBuilder asm)
		{
			if (!string.IsNullOrEmpty(options.TargetFrameworkName))
			{
				Type type = null;
				try
				{
					type = TypeModel.ResolveKnownType("System.Runtime.Versioning.TargetFrameworkAttribute", typeof(string).Assembly);
				}
				catch
				{
				}
				if ((object)type != null)
				{
					PropertyInfo[] namedProperties;
					object[] propertyValues;
					if (string.IsNullOrEmpty(options.TargetFrameworkDisplayName))
					{
						namedProperties = Array.Empty<PropertyInfo>();
						propertyValues = Array.Empty<object>();
					}
					else
					{
						namedProperties = new PropertyInfo[1] { type.GetProperty("FrameworkDisplayName") };
						propertyValues = new object[1] { options.TargetFrameworkDisplayName };
					}
					CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(type.GetConstructor(new Type[1] { typeof(string) }), new object[1] { options.TargetFrameworkName }, namedProperties, propertyValues);
					asm.SetCustomAttribute(customAttribute);
				}
			}
			Type type2 = null;
			try
			{
				type2 = typeof(InternalsVisibleToAttribute);
			}
			catch
			{
			}
			if ((object)type2 != null)
			{
				List<string> list = new List<string>();
				List<Assembly> list2 = new List<Assembly>();
				BasicList.NodeEnumerator enumerator = types.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MetaType metaType = (MetaType)enumerator.Current;
					Assembly assembly = metaType.Type.Assembly;
					if (list2.IndexOf(assembly) >= 0)
					{
						continue;
					}
					list2.Add(assembly);
					AttributeMap[] array = AttributeMap.Create(assembly);
					for (int i = 0; i < array.Length; i++)
					{
						if (!(array[i].AttributeType != type2))
						{
							array[i].TryGet("AssemblyName", out var value);
							string text = value as string;
							if (!(text == assemblyName) && !string.IsNullOrEmpty(text) && list.IndexOf(text) < 0)
							{
								list.Add(text);
								CustomAttributeBuilder customAttribute2 = new CustomAttributeBuilder(type2.GetConstructor(new Type[1] { typeof(string) }), new object[1] { text });
								asm.SetCustomAttribute(customAttribute2);
							}
						}
					}
				}
			}
			WriteAssemblyInfoAttributes(options, asm);
			static void WriteAssemblyInfoAttribute<TAttribute>(CompilerOptions compilerOptions, AssemblyBuilder assemblyBuilder, string text2) where TAttribute : Attribute
			{
				if (!string.IsNullOrEmpty(text2))
				{
					Type typeFromHandle = typeof(TAttribute);
					Type[] array2 = new Type[1] { typeof(string) };
					ConstructorInfo constructor = typeFromHandle.GetConstructor(array2);
					CustomAttributeBuilder customAttribute3 = new CustomAttributeBuilder(constructor, new object[1] { text2 });
					assemblyBuilder.SetCustomAttribute(customAttribute3);
				}
			}
			static void WriteAssemblyInfoAttributes(CompilerOptions compilerOptions, AssemblyBuilder asm2)
			{
				WriteAssemblyInfoAttribute<AssemblyFileVersionAttribute>(compilerOptions, asm2, compilerOptions.AssemblyVersion?.ToString());
				WriteAssemblyInfoAttribute<AssemblyCompanyAttribute>(compilerOptions, asm2, compilerOptions.AssemblyCompanyName);
				WriteAssemblyInfoAttribute<AssemblyCopyrightAttribute>(compilerOptions, asm2, compilerOptions.AssemblyCopyright);
				WriteAssemblyInfoAttribute<AssemblyDescriptionAttribute>(compilerOptions, asm2, compilerOptions.AssemblyDescription);
				WriteAssemblyInfoAttribute<AssemblyProductAttribute>(compilerOptions, asm2, compilerOptions.AssemblyProductName);
				WriteAssemblyInfoAttribute<AssemblyTitleAttribute>(compilerOptions, asm2, compilerOptions.AssemblyTitle);
				WriteAssemblyInfoAttribute<AssemblyTrademarkAttribute>(compilerOptions, asm2, compilerOptions.AssemblyTrademark);
				WriteAssemblyInfoAttribute<AssemblyInformationalVersionAttribute>(compilerOptions, asm2, compilerOptions.AssemblyProductVersion?.ToString());
			}
		}

		internal bool IsPrepared(Type type)
		{
			return FindWithoutAdd(type)?.IsPrepared() ?? false;
		}

		internal void TakeLock(ref int opaqueToken)
		{
			opaqueToken = 0;
			if (Monitor.TryEnter(types, metadataTimeoutMilliseconds))
			{
				opaqueToken = GetContention();
				return;
			}
			AddContention();
			throw new TimeoutException("Timeout while inspecting metadata; this may indicate a deadlock. This can often be avoided by preparing necessary serializers during application initialization, rather than allowing multiple threads to perform the initial metadata inspection; please also see the LockContended event");
		}

		private int GetContention()
		{
			return Interlocked.CompareExchange(ref contentionCounter, 0, 0);
		}

		private void AddContention()
		{
			Interlocked.Increment(ref contentionCounter);
		}

		internal void ReleaseLock(int opaqueToken)
		{
			if (opaqueToken == 0)
			{
				return;
			}
			Monitor.Exit(types);
			if (opaqueToken == GetContention())
			{
				return;
			}
			LockContentedEventHandler lockContentedEventHandler = this.LockContended;
			if (lockContentedEventHandler != null)
			{
				string stackTrace;
				try
				{
					throw new ProtoException();
				}
				catch (Exception ex)
				{
					stackTrace = ex.StackTrace;
				}
				lockContentedEventHandler(this, new LockContentedEventArgs(stackTrace));
			}
		}

		internal string GetSchemaTypeName(HashSet<Type> callstack, Type effectiveType, DataFormat dataFormat, CompatibilityLevel compatibilityLevel, bool asReference, bool dynamicType, HashSet<string> imports)
		{
			string altName;
			return GetSchemaTypeName(callstack, effectiveType, dataFormat, compatibilityLevel, asReference, dynamicType, imports, out altName);
		}

		private static bool IsWrappersProtoType(Type type, out string name, HashSet<string> imports)
		{
			name = null;
			if (type == typeof(double?))
			{
				name = ".google.protobuf.DoubleValue";
			}
			if (type == typeof(float?))
			{
				name = ".google.protobuf.FloatValue";
			}
			if (type == typeof(long?))
			{
				name = ".google.protobuf.Int64Value";
			}
			if (type == typeof(ulong?))
			{
				name = ".google.protobuf.UInt64Value";
			}
			if (type == typeof(int?))
			{
				name = ".google.protobuf.Int32Value";
			}
			if (type == typeof(uint?))
			{
				name = ".google.protobuf.UInt32Value";
			}
			if (type == typeof(bool?))
			{
				name = ".google.protobuf.BoolValue";
			}
			if (type == typeof(string))
			{
				name = ".google.protobuf.StringValue";
			}
			if (type == typeof(byte[]))
			{
				name = ".google.protobuf.BytesValue";
			}
			if (name == null)
			{
				return false;
			}
			imports.Add("google/protobuf/wrappers.proto");
			return true;
		}

		private static bool IsWellKnownType(Type type, out string name, HashSet<string> imports)
		{
			if (TypeHelper.IsBytesLike(type))
			{
				name = "bytes";
				return true;
			}
			if (type == typeof(Timestamp))
			{
				imports.Add("google/protobuf/timestamp.proto");
				name = ".google.protobuf.Timestamp";
				return true;
			}
			if (type == typeof(Duration))
			{
				imports.Add("google/protobuf/duration.proto");
				name = ".google.protobuf.Duration";
				return true;
			}
			if (type == typeof(Empty))
			{
				imports.Add("google/protobuf/empty.proto");
				name = ".google.protobuf.Empty";
				return true;
			}
			name = null;
			return false;
		}

		internal string GetSchemaTypeName(HashSet<Type> callstack, Type effectiveType, DataFormat dataFormat, CompatibilityLevel compatibilityLevel, bool asReference, bool dynamicType, HashSet<string> imports, out string altName, bool considerWrappersProtoTypes = false)
		{
			altName = null;
			if (considerWrappersProtoTypes && IsWrappersProtoType(effectiveType, out var name, imports))
			{
				return name;
			}
			compatibilityLevel = ValueMember.GetEffectiveCompatibilityLevel(compatibilityLevel, dataFormat);
			effectiveType = DynamicStub.GetEffectiveType(effectiveType);
			if (IsWellKnownType(effectiveType, out var name2, imports))
			{
				return name2;
			}
			WireType defaultWireType;
			IRuntimeProtoSerializerNode runtimeProtoSerializerNode = ValueMember.TryGetCoreSerializer(this, dataFormat, compatibilityLevel, effectiveType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
			if (runtimeProtoSerializerNode == null)
			{
				if (asReference || dynamicType)
				{
					imports.Add("protobuf-net/bcl.proto");
					return ".bcl.NetObjectProxy";
				}
				MetaType metaType = this[effectiveType];
				if (metaType.HasSurrogate && ValueMember.TryGetCoreSerializer(this, metaType.surrogateDataFormat, metaType.CompatibilityLevel, metaType.surrogateType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) != null)
				{
					return GetSchemaTypeName(callstack, metaType.surrogateType, metaType.surrogateDataFormat, metaType.CompatibilityLevel, asReference: false, dynamicType: false, imports);
				}
				MetaType surrogateOrBaseOrSelf = metaType.GetSurrogateOrBaseOrSelf(deep: true);
				if (IsWellKnownType(surrogateOrBaseOrSelf.Type, out name2, imports))
				{
					return name2;
				}
				string schemaTypeName = surrogateOrBaseOrSelf.GetSchemaTypeName(callstack);
				if (metaType.Type.IsEnum && !metaType.IsValidEnum())
				{
					altName = schemaTypeName;
					schemaTypeName = GetSchemaTypeName(callstack, Enum.GetUnderlyingType(metaType.Type), dataFormat, CompatibilityLevel.NotSpecified, asReference, dynamicType, imports);
				}
				return schemaTypeName;
			}
			if (runtimeProtoSerializerNode is ParseableSerializer)
			{
				if (asReference)
				{
					imports.Add("protobuf-net/bcl.proto");
				}
				if (!asReference)
				{
					return "string";
				}
				return ".bcl.NetObjectProxy";
			}
			switch (Helpers.GetTypeCode(effectiveType))
			{
			case ProtoTypeCode.Boolean:
				return "bool";
			case ProtoTypeCode.Single:
				return "float";
			case ProtoTypeCode.Double:
				return "double";
			case ProtoTypeCode.String:
				if (asReference)
				{
					imports.Add("protobuf-net/bcl.proto");
				}
				if (!asReference)
				{
					return "string";
				}
				return ".bcl.NetObjectProxy";
			case ProtoTypeCode.Char:
			case ProtoTypeCode.Byte:
			case ProtoTypeCode.UInt16:
			case ProtoTypeCode.UInt32:
				if (dataFormat == DataFormat.FixedSize)
				{
					return "fixed32";
				}
				return "uint32";
			case ProtoTypeCode.SByte:
			case ProtoTypeCode.Int16:
			case ProtoTypeCode.Int32:
				return dataFormat switch
				{
					DataFormat.ZigZag => "sint32", 
					DataFormat.FixedSize => "sfixed32", 
					_ => "int32", 
				};
			case ProtoTypeCode.UInt64:
			case ProtoTypeCode.UIntPtr:
				if (dataFormat == DataFormat.FixedSize)
				{
					return "fixed64";
				}
				return "uint64";
			case ProtoTypeCode.Int64:
			case ProtoTypeCode.IntPtr:
				return dataFormat switch
				{
					DataFormat.ZigZag => "sint64", 
					DataFormat.FixedSize => "sfixed64", 
					_ => "int64", 
				};
			case ProtoTypeCode.DateTime:
				if (dataFormat == DataFormat.FixedSize)
				{
					return "sint64";
				}
				if (compatibilityLevel >= CompatibilityLevel.Level240)
				{
					imports.Add("google/protobuf/timestamp.proto");
					return ".google.protobuf.Timestamp";
				}
				imports.Add("protobuf-net/bcl.proto");
				return ".bcl.DateTime";
			case ProtoTypeCode.TimeSpan:
				if (dataFormat == DataFormat.FixedSize)
				{
					return "sint64";
				}
				if (compatibilityLevel >= CompatibilityLevel.Level240)
				{
					imports.Add("google/protobuf/duration.proto");
					return ".google.protobuf.Duration";
				}
				imports.Add("protobuf-net/bcl.proto");
				return ".bcl.TimeSpan";
			case ProtoTypeCode.Decimal:
				if (compatibilityLevel < CompatibilityLevel.Level300)
				{
					imports.Add("protobuf-net/bcl.proto");
					return ".bcl.Decimal";
				}
				return "string";
			case ProtoTypeCode.Guid:
				if (compatibilityLevel < CompatibilityLevel.Level300)
				{
					imports.Add("protobuf-net/bcl.proto");
					return ".bcl.Guid";
				}
				if (dataFormat != DataFormat.FixedSize)
				{
					return "string";
				}
				return "bytes";
			case ProtoTypeCode.Type:
				return "string";
			case ProtoTypeCode.Uri:
				return "string";
			default:
				throw new NotSupportedException("No .proto map found for: " + effectiveType.FullName);
			}
		}

		public void SetDefaultFactory(MethodInfo methodInfo)
		{
			VerifyFactory(methodInfo, null);
			defaultFactory = methodInfo;
		}

		internal static void VerifyFactory(MethodInfo factory, Type type)
		{
			if ((object)factory != null)
			{
				if ((object)type != null && type.IsValueType)
				{
					throw new InvalidOperationException();
				}
				if (!factory.IsStatic)
				{
					throw new ArgumentException("A factory-method must be static", "factory");
				}
				if ((object)type != null && factory.ReturnType != type && factory.ReturnType != typeof(object))
				{
					throw new ArgumentException("The factory-method must return object" + (((object)type == null) ? "" : (" or " + type.FullName)), "factory");
				}
				if (!CallbackSet.CheckCallbackParameters(factory))
				{
					throw new ArgumentException("Invalid factory signature in " + factory.DeclaringType.FullName + "." + factory.Name, "factory");
				}
			}
		}

		public static RuntimeTypeModel Create([CallerMemberName] string name = null)
		{
			return new RuntimeTypeModel(isDefault: false, name);
		}

		internal static bool IsFullyPublic(Type type)
		{
			Type cause;
			return IsFullyPublic(type, out cause);
		}

		internal static bool IsFullyPublic(Type type, out Type cause)
		{
			Type type2 = type;
			while ((object)type != null)
			{
				if (type.IsGenericType)
				{
					Type[] genericArguments = type.GetGenericArguments();
					Type[] array = genericArguments;
					foreach (Type type3 in array)
					{
						if (!IsFullyPublic(type3))
						{
							cause = type3;
							return false;
						}
					}
				}
				cause = type;
				if (type.IsNestedPublic)
				{
					type = type.DeclaringType;
					continue;
				}
				return type.IsPublic;
			}
			cause = type2;
			return false;
		}

		public new static TypeModel CreateForAssembly<T>()
		{
			return AutoCompileTypeModel.CreateForAssembly<T>();
		}

		public new static TypeModel CreateForAssembly(Type type)
		{
			return AutoCompileTypeModel.CreateForAssembly(type);
		}

		public new static TypeModel CreateForAssembly(Assembly assembly)
		{
			return AutoCompileTypeModel.CreateForAssembly(assembly);
		}

		public void MakeDefault()
		{
			lock (s_ModelSyncLock)
			{
				RuntimeTypeModel runtimeTypeModel = TypeModel.DefaultModel as RuntimeTypeModel;
				if (this == runtimeTypeModel)
				{
					return;
				}
				try
				{
					SetOption(RuntimeTypeModelOptions.IsDefaultModel, value: true);
					if (!UseImplicitZeroDefaults)
					{
						ThrowDefaultUseImplicitZeroDefaults();
					}
					if (!AutoAddMissingTypes)
					{
						ThrowDefaultAutoAddMissingTypes();
					}
					if (GetOption(RuntimeTypeModelOptions.Frozen))
					{
						ThrowDefaultFrozen();
					}
					TypeModel.SetDefaultModel(this);
				}
				finally
				{
					TypeModel defaultModel = TypeModel.DefaultModel;
					if (this != defaultModel)
					{
						SetOption(RuntimeTypeModelOptions.IsDefaultModel, value: false);
					}
					if (runtimeTypeModel != null && runtimeTypeModel != defaultModel)
					{
						runtimeTypeModel.SetOption(RuntimeTypeModelOptions.IsDefaultModel, value: false);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowDefaultAutoAddMissingTypes()
		{
			throw new InvalidOperationException("The default model must allow missing types");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowDefaultUseImplicitZeroDefaults()
		{
			throw new InvalidOperationException("UseImplicitZeroDefaults cannot be disabled on the default model");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowDefaultFrozen()
		{
			throw new InvalidOperationException("The default model cannot be frozen");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static RuntimeTypeModel CreateDefaultModelInstance()
		{
			lock (s_ModelSyncLock)
			{
				RuntimeTypeModel runtimeTypeModel = TypeModel.DefaultModel as RuntimeTypeModel;
				if (runtimeTypeModel == null)
				{
					runtimeTypeModel = new RuntimeTypeModel(isDefault: true, "(default)");
					TypeModel.SetDefaultModel(runtimeTypeModel);
				}
				return runtimeTypeModel;
			}
		}

		public RuntimeTypeModel SetSurrogate<TUnderlying, TSurrogate>(Func<TUnderlying, TSurrogate> underlyingToSurrogate = null, Func<TSurrogate, TUnderlying> surrogateToUnderlying = null, DataFormat dataFormat = DataFormat.Default, CompatibilityLevel compatibilityLevel = CompatibilityLevel.NotSpecified)
		{
			Add<TUnderlying>(applyDefaultBehaviour: true, compatibilityLevel).SetSurrogate(typeof(TSurrogate), GetMethod(underlyingToSurrogate, "underlyingToSurrogate"), GetMethod(surrogateToUnderlying, "surrogateToUnderlying"), dataFormat);
			return this;
			static MethodInfo GetMethod(Delegate value, string paramName)
			{
				if ((object)value == null)
				{
					return null;
				}
				Delegate[] invocationList = value.GetInvocationList();
				if (invocationList.Length != 1)
				{
					ThrowHelper.ThrowArgumentException("A unicast delegate was expected.", paramName);
				}
				value = invocationList[0];
				object target = value.Target;
				if (target != null)
				{
					string text = "A delegate to a static method was expected.";
					if (target.GetType().IsDefined(typeof(CompilerGeneratedAttribute)))
					{
						text = text + " The conversion '" + target.GetType().NormalizeName() + "." + value.Method.Name + "' is compiler-generated (possibly a lambda); an explicit static method should be used instead.";
					}
					ThrowHelper.ThrowArgumentException(text, paramName);
				}
				return value.Method;
			}
		}

		public RuntimeTypeModel AddSerializer(Type collectionType, Type serializerType)
		{
			Type type = collectionType;
			if (type.IsGenericType)
			{
				type = type.GetGenericTypeDefinition();
			}
			lock (_serviceCache)
			{
				if (_externalProviders == null)
				{
					_externalProviders = new Hashtable();
				}
			}
			if (!_externalProviders.ContainsKey(type))
			{
				RepeatedSerializers.Add(type, (Type root, Type current, Type[] targs) => RepeatedSerializers.Resolve(serializerType, "Create", targs), exactOnly: true, _externalProviders);
			}
			return this;
		}
	}
}
