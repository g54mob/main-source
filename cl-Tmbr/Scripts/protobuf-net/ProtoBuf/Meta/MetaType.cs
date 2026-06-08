using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using ProtoBuf.Extensions;
using ProtoBuf.Internal;
using ProtoBuf.Internal.Serializers;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	public sealed class MetaType : ISerializerProxy
	{
		internal sealed class Comparer : IComparer, IComparer<MetaType>
		{
			private readonly HashSet<Type> _callstack;

			internal Comparer(HashSet<Type> callstack)
			{
				_callstack = callstack;
			}

			public int Compare(object x, object y)
			{
				return Compare(x as MetaType, y as MetaType);
			}

			public int Compare(MetaType x, MetaType y)
			{
				if (x == y)
				{
					return 0;
				}
				if (x == null)
				{
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				return string.Compare(x.GetSchemaTypeName(_callstack), y.GetSchemaTypeName(_callstack), StringComparison.Ordinal);
			}
		}

		[Flags]
		internal enum AttributeFamily
		{
			None = 0,
			ProtoBuf = 1,
			DataContractSerializer = 2,
			XmlSerializer = 4,
			AutoTuple = 8
		}

		private enum TypeOptions : ushort
		{
			None = 0,
			Pending = 1,
			Frozen = 4,
			PrivateOnApi = 8,
			SkipConstructor = 0x10,
			AutoTuple = 0x40,
			IgnoreListHandling = 0x80,
			IsGroup = 0x100,
			IgnoreUnknownSubTypes = 0x200
		}

		private class ExtraLayerValueMembers : IEnumerable<NullWrappedValueMemberData>, IEnumerable
		{
			private readonly Dictionary<string, Type> _schemaMemberTypeMap = new Dictionary<string, Type>();

			private readonly Dictionary<string, NullWrappedValueMemberData> _wrappedSchemaMembers = new Dictionary<string, NullWrappedValueMemberData>();

			public bool IsEmpty()
			{
				return _wrappedSchemaMembers.Count == 0;
			}

			public NullWrappedValueMemberData Add(string schemaTypeName, ValueMember valueMember)
			{
				if (!_schemaMemberTypeMap.ContainsKey(schemaTypeName))
				{
					NullWrappedValueMemberData nullWrappedValueMemberData = new NullWrappedValueMemberData(valueMember, schemaTypeName);
					_schemaMemberTypeMap[schemaTypeName] = nullWrappedValueMemberData.ItemType;
					_wrappedSchemaMembers[nullWrappedValueMemberData.WrappedSchemaTypeName] = nullWrappedValueMemberData;
					return nullWrappedValueMemberData;
				}
				Type type = _schemaMemberTypeMap[schemaTypeName];
				if (type == valueMember.ItemType)
				{
					NullWrappedValueMemberData nullWrappedValueMemberData2 = new NullWrappedValueMemberData(valueMember, schemaTypeName);
					_wrappedSchemaMembers[nullWrappedValueMemberData2.WrappedSchemaTypeName] = nullWrappedValueMemberData2;
					return nullWrappedValueMemberData2;
				}
				if (string.IsNullOrEmpty(valueMember.Name) || valueMember.Member?.Name == valueMember.Name)
				{
					NullWrappedValueMemberData nullWrappedValueMemberData3 = new NullWrappedValueMemberData(valueMember, schemaTypeName, null, hasSchemaTypeNameCollision: true);
					_wrappedSchemaMembers[nullWrappedValueMemberData3.WrappedSchemaTypeName] = nullWrappedValueMemberData3;
					return nullWrappedValueMemberData3;
				}
				string name = valueMember.Name;
				if (_schemaMemberTypeMap.ContainsKey(name))
				{
					NullWrappedValueMemberData nullWrappedValueMemberData4 = new NullWrappedValueMemberData(valueMember, schemaTypeName, name, hasSchemaTypeNameCollision: true);
					_wrappedSchemaMembers[nullWrappedValueMemberData4.WrappedSchemaTypeName] = nullWrappedValueMemberData4;
					return nullWrappedValueMemberData4;
				}
				NullWrappedValueMemberData nullWrappedValueMemberData5 = new NullWrappedValueMemberData(valueMember, schemaTypeName, name);
				_schemaMemberTypeMap[name] = nullWrappedValueMemberData5.ItemType;
				_wrappedSchemaMembers[nullWrappedValueMemberData5.WrappedSchemaTypeName] = nullWrappedValueMemberData5;
				return nullWrappedValueMemberData5;
			}

			public IEnumerator<NullWrappedValueMemberData> GetEnumerator()
			{
				return _wrappedSchemaMembers.Values.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private MetaType baseType;

		private CompatibilityLevel _compatibilityLevel;

		private List<SubType> _subTypes;

		private CallbackSet callbacks;

		private string name;

		private string origin;

		private MethodInfo factory;

		private readonly RuntimeTypeModel model;

		private IProtoTypeSerializer _serializer;

		private Type constructType;

		internal Type surrogateType;

		internal DataFormat surrogateDataFormat;

		private MethodInfo underlyingToSurrogate;

		private MethodInfo surrogateToUnderlying;

		private List<ValueMember> _fields;

		private List<EnumMember> _enums = new List<EnumMember>();

		private volatile TypeOptions flags;

		private Type _serializerType;

		private List<ProtoReservedAttribute> _reservations;

		IRuntimeProtoSerializerNode ISerializerProxy.Serializer => Serializer;

		public MetaType BaseType => baseType;

		internal RuntimeTypeModel Model => model;

		public CompatibilityLevel CompatibilityLevel
		{
			get
			{
				return _compatibilityLevel;
			}
			set
			{
				if (value != _compatibilityLevel)
				{
					if (HasFields)
					{
						ThrowHelper.ThrowInvalidOperationException($"{CompatibilityLevel} cannot be set once fields have been defined");
					}
					CompatibilityLevelAttribute.AssertValid(value);
					_compatibilityLevel = value;
				}
			}
		}

		public bool IncludeSerializerMethod
		{
			get
			{
				return !HasFlag(TypeOptions.PrivateOnApi);
			}
			set
			{
				SetFlag(TypeOptions.PrivateOnApi, !value, throwIfFrozen: true);
			}
		}

		public bool AsReferenceDefault
		{
			get
			{
				return false;
			}
			[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
			set
			{
				if (value != AsReferenceDefault)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		public bool HasCallbacks
		{
			get
			{
				if (callbacks != null)
				{
					return callbacks.NonTrivial;
				}
				return false;
			}
		}

		public bool HasSubtypes
		{
			get
			{
				if (_subTypes != null)
				{
					return _subTypes.Count != 0;
				}
				return false;
			}
		}

		public int SubtypesCount => _subTypes?.Count ?? 0;

		public CallbackSet Callbacks => callbacks ?? (callbacks = new CallbackSet(this));

		private bool IsValueType => Type.IsValueType;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				ThrowIfFrozen();
				name = value;
			}
		}

		public string Origin
		{
			get
			{
				return origin;
			}
			set
			{
				ThrowIfFrozen();
				origin = value;
			}
		}

		public Type Type { get; }

		internal IProtoTypeSerializer Serializer
		{
			get
			{
				if (_serializer == null)
				{
					int opaqueToken = 0;
					try
					{
						model.TakeLock(ref opaqueToken);
						if (_serializer == null)
						{
							SetFlag(TypeOptions.Frozen, value: true, throwIfFrozen: false);
							_serializer = BuildSerializer();
							if (model.AutoCompile)
							{
								CompileInPlace();
							}
						}
					}
					finally
					{
						model.ReleaseLock(opaqueToken);
					}
				}
				return _serializer;
			}
		}

		public bool UseConstructor
		{
			get
			{
				return !HasFlag(TypeOptions.SkipConstructor);
			}
			set
			{
				SetFlag(TypeOptions.SkipConstructor, !value, throwIfFrozen: true);
			}
		}

		public Type ConstructType
		{
			get
			{
				return constructType;
			}
			set
			{
				ThrowIfFrozen();
				constructType = value;
			}
		}

		internal bool HasSurrogate => (object)surrogateType != null;

		public ValueMember this[int fieldNumber]
		{
			get
			{
				if (HasFields)
				{
					foreach (ValueMember field in Fields)
					{
						if (field.FieldNumber == fieldNumber)
						{
							return field;
						}
					}
				}
				return null;
			}
		}

		public ValueMember this[MemberInfo member]
		{
			get
			{
				if ((object)member == null || !HasFields)
				{
					return null;
				}
				foreach (ValueMember field in Fields)
				{
					if (field.Member == member || field.BackingMember == member)
					{
						return field;
					}
				}
				return null;
			}
		}

		internal bool HasFields
		{
			get
			{
				if (_fields != null)
				{
					return _fields.Count != 0;
				}
				return false;
			}
		}

		internal List<ValueMember> Fields => _fields ?? (_fields = new List<ValueMember>());

		internal List<EnumMember> Enums => _enums ?? (_enums = new List<EnumMember>());

		internal bool HasEnums
		{
			get
			{
				if (_enums != null)
				{
					return _enums.Count != 0;
				}
				return false;
			}
		}

		public bool EnumPassthru
		{
			[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", false)]
			get
			{
				return Type.IsEnum;
			}
			[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", true)]
			set
			{
				if (value != EnumPassthru)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		public bool IgnoreListHandling
		{
			get
			{
				return HasFlag(TypeOptions.IgnoreListHandling);
			}
			set
			{
				SetFlag(TypeOptions.IgnoreListHandling, value, throwIfFrozen: true);
				model.ResetServiceCache(Type);
			}
		}

		public bool IgnoreUnknownSubTypes
		{
			get
			{
				return HasFlag(TypeOptions.IgnoreUnknownSubTypes);
			}
			set
			{
				SetFlag(TypeOptions.IgnoreUnknownSubTypes, value, throwIfFrozen: true);
			}
		}

		internal bool Pending
		{
			get
			{
				return HasFlag(TypeOptions.Pending);
			}
			set
			{
				SetFlag(TypeOptions.Pending, value, throwIfFrozen: false);
			}
		}

		public Type SerializerType
		{
			get
			{
				return _serializerType;
			}
			set
			{
				if (value != _serializerType)
				{
					if (!value.IsClass)
					{
						ThrowHelper.ThrowArgumentException("Custom serializer providers must be classes", "SerializerType");
					}
					ThrowIfFrozen();
					_serializerType = value;
				}
			}
		}

		internal bool IsAutoTuple => HasFlag(TypeOptions.AutoTuple);

		public bool IsGroup
		{
			get
			{
				return HasFlag(TypeOptions.IsGroup);
			}
			set
			{
				SetFlag(TypeOptions.IsGroup, value, throwIfFrozen: true);
			}
		}

		internal bool HasReservations => (_reservations?.Count ?? 0) != 0;

		public override string ToString()
		{
			return Type.ToString();
		}

		private bool IsValidSubType(Type subType)
		{
			if ((object)subType != null && !subType.IsValueType)
			{
				return Type.IsAssignableFrom(subType);
			}
			return false;
		}

		public MetaType AddSubType(int fieldNumber, Type derivedType)
		{
			return AddSubType(fieldNumber, derivedType, DataFormat.Default);
		}

		private static void ThrowSubTypeWithSurrogate(Type type)
		{
			ThrowHelper.ThrowInvalidOperationException("Types with surrogates cannot be used in inheritance hierarchies: " + type.NormalizeName());
		}

		public MetaType AddSubType(int fieldNumber, Type derivedType, DataFormat dataFormat)
		{
			if ((object)derivedType == null)
			{
				throw new ArgumentNullException("derivedType");
			}
			if (fieldNumber < 1)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			if ((!Type.IsClass && !Type.IsInterface) || Type.IsSealed)
			{
				throw new InvalidOperationException("Sub-types can only be added to non-sealed classes: " + Type.NormalizeName());
			}
			if (!IsValidSubType(derivedType))
			{
				throw new ArgumentException(derivedType.NormalizeName() + " is not a valid sub-type of " + Type.NormalizeName(), "derivedType");
			}
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				MetaType metaType = model[derivedType];
				ThrowIfFrozen();
				metaType.ThrowIfFrozen();
				if (IsAutoTuple || metaType.IsAutoTuple)
				{
					ThrowTupleTypeWithInheritance(derivedType);
				}
				if ((object)surrogateType != null)
				{
					ThrowSubTypeWithSurrogate(Type);
				}
				if ((object)metaType.surrogateType != null)
				{
					ThrowSubTypeWithSurrogate(derivedType);
				}
				SubType item = new SubType(fieldNumber, metaType, dataFormat);
				ThrowIfFrozen();
				metaType.SetBaseType(this);
				(_subTypes ?? (_subTypes = new List<SubType>())).Add(item);
				return this;
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		private static void ThrowTupleTypeWithInheritance(Type type)
		{
			ThrowHelper.ThrowInvalidOperationException("Tuple-based types cannot be used in inheritance hierarchies: " + type.NormalizeName());
		}

		private void SetBaseType(MetaType baseType)
		{
			if (baseType == null)
			{
				throw new ArgumentNullException("baseType");
			}
			if (this.baseType == baseType)
			{
				return;
			}
			if (this.baseType != null)
			{
				throw new InvalidOperationException("Type '" + this.baseType.Type.FullName + "' can only participate in one inheritance hierarchy");
			}
			for (MetaType metaType = baseType; metaType != null; metaType = metaType.baseType)
			{
				if (metaType == this)
				{
					throw new InvalidOperationException("Cyclic inheritance of '" + this.baseType.Type.FullName + "' is not allowed");
				}
			}
			this.baseType = baseType;
		}

		public MetaType SetCallbacks(MethodInfo beforeSerialize, MethodInfo afterSerialize, MethodInfo beforeDeserialize, MethodInfo afterDeserialize)
		{
			CheckSetCallbacks();
			CallbackSet callbackSet = Callbacks;
			callbackSet.BeforeSerialize = beforeSerialize;
			callbackSet.AfterSerialize = afterSerialize;
			callbackSet.BeforeDeserialize = beforeDeserialize;
			callbackSet.AfterDeserialize = afterDeserialize;
			return this;
		}

		private void CheckSetCallbacks()
		{
			ThrowIfFrozen();
			ThrowIfAutoTuple();
		}

		public MetaType SetCallbacks(string beforeSerialize, string afterSerialize, string beforeDeserialize, string afterDeserialize)
		{
			CheckSetCallbacks();
			CallbackSet callbackSet = Callbacks;
			callbackSet.BeforeSerialize = ResolveMethod(beforeSerialize, instance: true);
			callbackSet.AfterSerialize = ResolveMethod(afterSerialize, instance: true);
			callbackSet.BeforeDeserialize = ResolveMethod(beforeDeserialize, instance: true);
			callbackSet.AfterDeserialize = ResolveMethod(afterDeserialize, instance: true);
			return this;
		}

		public string GetSchemaTypeName()
		{
			return GetSchemaTypeName(null);
		}

		internal string GetSchemaTypeName(HashSet<Type> callstack)
		{
			if (callstack == null)
			{
				callstack = new HashSet<Type>();
			}
			if (!callstack.Add(Type))
			{
				return Type.Name;
			}
			try
			{
				if ((object)surrogateType != null && !callstack.Contains(surrogateType))
				{
					return model[surrogateType].GetSchemaTypeName(callstack);
				}
				if (!string.IsNullOrEmpty(name))
				{
					return name;
				}
				string text = Type.Name;
				if (Type.IsArray)
				{
					return GetArrayName(Type.GetElementType());
				}
				if (Type.IsGenericType)
				{
					StringBuilder stringBuilder = new StringBuilder(text);
					int num = text.IndexOf('`');
					if (num >= 0)
					{
						stringBuilder.Length = num;
					}
					Type[] genericArguments = Type.GetGenericArguments();
					foreach (Type type in genericArguments)
					{
						stringBuilder.Append('_');
						Type type2 = type;
						MetaType metaType;
						if (model.IsDefined(type2) && (metaType = model[type2]) != null)
						{
							stringBuilder.Append(LastPart(metaType.GetSchemaTypeName(callstack)));
							continue;
						}
						if (type2.IsArray)
						{
							stringBuilder.Append(GetArrayName(type2.GetElementType()));
							continue;
						}
						metaType = null;
						try
						{
							metaType = model.Add(type2);
						}
						catch
						{
						}
						if (metaType != null)
						{
							stringBuilder.Append(metaType.GetSchemaTypeName(callstack));
						}
						else
						{
							stringBuilder.Append(type2.Name);
						}
					}
					return stringBuilder.ToString();
				}
				return text;
			}
			finally
			{
				callstack.Remove(Type);
			}
			string GetArrayName(Type elementType)
			{
				MetaType metaType2;
				string text2 = ((model.IsDefined(elementType) && (metaType2 = model[elementType]) != null) ? metaType2.GetSchemaTypeName(callstack) : elementType.Name);
				return "Array_" + text2;
			}
			static string LastPart(string value)
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					return value;
				}
				int num2 = value.LastIndexOf('.');
				if (num2 >= 0)
				{
					return value.Substring(num2 + 1);
				}
				return value;
			}
		}

		internal string GuessPackage()
		{
			string text = Name;
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			if (text[0] != '.')
			{
				return null;
			}
			return text[..text.LastIndexOf('.')].Trim('.').Trim();
		}

		public MetaType SetFactory(MethodInfo factory)
		{
			RuntimeTypeModel.VerifyFactory(factory, Type);
			ThrowIfFrozen();
			ThrowIfAutoTuple();
			this.factory = factory;
			return this;
		}

		public MetaType SetFactory(string factory)
		{
			return SetFactory(ResolveMethod(factory, instance: false));
		}

		private MethodInfo ResolveMethod(string name, bool instance)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			if (!instance)
			{
				return Helpers.GetStaticMethod(Type, name);
			}
			return Helpers.GetInstanceMethod(Type, name);
		}

		internal static Exception InbuiltType(Type type, Exception innerException = null)
		{
			string message = "Data of this type has inbuilt behaviour, and cannot be added to a model in this way: " + type.FullName;
			if (innerException != null)
			{
				return new ArgumentException(message, innerException);
			}
			return new ArgumentException(message);
		}

		internal MetaType(RuntimeTypeModel model, Type type, MethodInfo factory)
		{
			this.factory = factory;
			if (model == null)
			{
				throw new ArgumentNullException("model");
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			IRuntimeProtoSerializerNode runtimeProtoSerializerNode = model.TryGetBasicTypeSerializer(type);
			if (runtimeProtoSerializerNode != null)
			{
				throw InbuiltType(type);
			}
			Type = type;
			if (type.IsArray)
			{
				SetFlag(TypeOptions.Frozen, value: true, throwIfFrozen: false);
			}
			this.model = model;
		}

		internal void ThrowIfFrozen()
		{
			if ((flags & TypeOptions.Frozen) != TypeOptions.None)
			{
				throw new InvalidOperationException("The type cannot be changed once a serializer has been generated for " + Type.FullName);
			}
		}

		internal Type GetInheritanceRoot()
		{
			if (Type.IsValueType)
			{
				return null;
			}
			MetaType rootType = GetRootType(this);
			if (rootType != this)
			{
				return rootType.Type;
			}
			if (_subTypes != null && _subTypes.Count != 0)
			{
				return rootType.Type;
			}
			return null;
		}

		private SerializerFeatures GetFeatures()
		{
			if (Type.IsEnum)
			{
				return SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;
			}
			if (!Type.IsValueType)
			{
				MetaType rootType = GetRootType(this);
				if (rootType != this)
				{
					return rootType.GetFeatures();
				}
			}
			SerializerFeatures serializerFeatures = SerializerFeatures.CategoryMessage;
			return (SerializerFeatures)((int)serializerFeatures | (IsGroup ? 19 : 18));
		}

		private bool HasRealInheritance()
		{
			if (baseType == null || baseType == this)
			{
				return (_subTypes?.Count ?? 0) > 0;
			}
			return true;
		}

		private IProtoTypeSerializer BuildSerializer()
		{
			if ((object)SerializerType != null)
			{
				return ExternalSerializer.Create(Type, SerializerType);
			}
			Validate();
			RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(Type);
			if (repeatedSerializerStub != null)
			{
				if ((object)surrogateType != null)
				{
					throw new ArgumentException("Repeated data (a list, collection, etc) has inbuilt behaviour and cannot use a surrogate");
				}
				if (_subTypes != null && _subTypes.Count != 0)
				{
					throw new ArgumentException("Repeated data (a list, collection, etc) has inbuilt behaviour and cannot be subclassed");
				}
				ValueMember valueMember = new ValueMember(model, 1, Type, repeatedSerializerStub.ItemType, null, DataFormat.Default)
				{
					CompatibilityLevel = CompatibilityLevel
				};
				return TypeSerializer.Create(Type, new int[1] { 1 }, new IRuntimeProtoSerializerNode[1] { valueMember.Serializer }, null, isRootType: true, useConstructor: true, !IgnoreUnknownSubTypes, null, constructType, factory, GetInheritanceRoot(), GetFeatures());
			}
			bool flag = HasRealInheritance();
			if ((object)surrogateType != null)
			{
				if (flag)
				{
					ThrowSubTypeWithSurrogate(Type);
				}
				WireType defaultWireType;
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = ValueMember.TryGetCoreSerializer(Model, surrogateDataFormat, CompatibilityLevel, surrogateType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
				SerializerFeatures features;
				if (runtimeProtoSerializerNode != null)
				{
					try
					{
						features = ExternalSerializer.Create(surrogateType, typeof(PrimaryTypeProvider)).Features;
					}
					catch (Exception innerException)
					{
						throw InbuiltType(surrogateType, innerException);
					}
				}
				else
				{
					MetaType metaType = model[surrogateType];
					MetaType metaType2;
					while ((metaType2 = metaType.baseType) != null)
					{
						if (metaType.HasRealInheritance())
						{
							ThrowSubTypeWithSurrogate(metaType.Type);
						}
						metaType = metaType2;
					}
					IProtoTypeSerializer serializer = metaType.Serializer;
					features = serializer.Features;
					runtimeProtoSerializerNode = serializer;
				}
				return (IProtoTypeSerializer)Activator.CreateInstance(typeof(SurrogateSerializer<>).MakeGenericType(Type), surrogateType, underlyingToSurrogate, surrogateToUnderlying, runtimeProtoSerializerNode, features);
			}
			if (IsAutoTuple)
			{
				if (flag)
				{
					ThrowTupleTypeWithInheritance(Type);
				}
				MemberInfo[] mappedMembers;
				ConstructorInfo constructorInfo = ResolveTupleConstructor(Type, out mappedMembers) ?? throw new InvalidOperationException();
				return (IProtoTypeSerializer)Activator.CreateInstance(typeof(TupleSerializer<>).MakeGenericType(Type), model, constructorInfo, mappedMembers, GetFeatures(), CompatibilityLevel);
			}
			if (HasFields)
			{
				Fields.TrimExcess();
			}
			if (HasEnums)
			{
				Enums.TrimExcess();
			}
			int num = _fields?.Count ?? 0;
			int num2 = _subTypes?.Count ?? 0;
			int[] array = new int[num + num2];
			IRuntimeProtoSerializerNode[] array2 = new IRuntimeProtoSerializerNode[num + num2];
			int num3 = 0;
			if (num2 != 0)
			{
				foreach (SubType subType in _subTypes)
				{
					if (!subType.DerivedType.IgnoreListHandling && model.TryGetRepeatedProvider(subType.DerivedType.Type) != null)
					{
						ThrowHelper.ThrowArgumentException("Repeated data (a list, collection, etc) has inbuilt behaviour and cannot be used as a subclass");
					}
					array[num3] = subType.FieldNumber;
					array2[num3++] = subType.GetSerializer(Type);
				}
			}
			if (num != 0)
			{
				foreach (ValueMember field in _fields)
				{
					array[num3] = field.FieldNumber;
					array2[num3++] = field.Serializer;
				}
			}
			List<MethodInfo> list = null;
			for (MetaType metaType3 = BaseType; metaType3 != null; metaType3 = metaType3.BaseType)
			{
				MethodInfo methodInfo = (metaType3.HasCallbacks ? metaType3.Callbacks.BeforeDeserialize : null);
				if ((object)methodInfo != null)
				{
					(list ?? (list = new List<MethodInfo>())).Add(methodInfo);
				}
			}
			MethodInfo[] array3 = null;
			if (list != null)
			{
				array3 = new MethodInfo[list.Count];
				list.CopyTo(array3, 0);
				Array.Reverse(array3);
			}
			return TypeSerializer.Create(Type, array, array2, array3, baseType == null, UseConstructor, !IgnoreUnknownSubTypes, callbacks, constructType, factory, GetInheritanceRoot(), GetFeatures());
		}

		private static Type GetBaseType(MetaType type)
		{
			return type.Type.BaseType;
		}

		internal static bool GetAsReferenceDefault(Type type)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsEnum)
			{
				return false;
			}
			AttributeMap[] array = AttributeMap.Create(type, inherit: false);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].AttributeType.FullName == "ProtoBuf.ProtoContractAttribute" && array[i].TryGet("AsReferenceDefault", out var value))
				{
					return (bool)value;
				}
			}
			return false;
		}

		internal void ApplyDefaultBehaviour(CompatibilityLevel ambient)
		{
			TypeAddedEventArgs args = null;
			RuntimeTypeModel.OnBeforeApplyDefaultBehaviour(this, ref args);
			if (args == null || args.ApplyDefaultBehaviour)
			{
				ApplyDefaultBehaviourImpl(ambient);
			}
			RuntimeTypeModel.OnAfterApplyDefaultBehaviour(this, ref args);
		}

		private void ApplyDefaultBehaviourImpl(CompatibilityLevel ambient)
		{
			Type type = GetBaseType(this);
			if ((object)type != null && model.FindWithoutAdd(type) == null && GetContractFamily(model, type, null) != AttributeFamily.None)
			{
				model.FindOrAddAuto(type, demand: true, addWithContractOnly: false, addEvenIfAutoDisabled: false, ambient);
			}
			AttributeMap[] array = AttributeMap.Create(Type, inherit: false);
			AttributeFamily attributeFamily = GetContractFamily(model, Type, array);
			if (attributeFamily == AttributeFamily.AutoTuple)
			{
				SetFlag(TypeOptions.AutoTuple, value: true, throwIfFrozen: true);
			}
			CompatibilityLevel compatibilityLevel = CompatibilityLevel;
			if (compatibilityLevel <= CompatibilityLevel.NotSpecified)
			{
				if (IsAutoTuple)
				{
					compatibilityLevel = ambient;
				}
				if (compatibilityLevel <= CompatibilityLevel.NotSpecified)
				{
					compatibilityLevel = Model.DefaultCompatibilityLevel;
				}
				CompatibilityLevel = TypeCompatibilityHelper.GetTypeCompatibilityLevel(Type, compatibilityLevel);
			}
			bool isEnum = Type.IsEnum;
			if (attributeFamily == AttributeFamily.None && !isEnum)
			{
				return;
			}
			List<string> list = null;
			List<AttributeMap> list2 = null;
			int dataMemberOffset = 0;
			int num = 1;
			bool flag = model.InferTagFromNameDefault;
			ImplicitFields implicitFields = ImplicitFields.None;
			string text = null;
			string text2 = null;
			foreach (AttributeMap attributeMap in array)
			{
				string fullName = attributeMap.AttributeType.FullName;
				object value;
				if (!isEnum && fullName == "ProtoBuf.ProtoIncludeAttribute")
				{
					int fieldNumber = 0;
					if (attributeMap.TryGet("tag", out value))
					{
						fieldNumber = (int)value;
					}
					DataFormat dataFormat = DataFormat.Default;
					if (attributeMap.TryGet("DataFormat", out value))
					{
						dataFormat = (DataFormat)(int)value;
					}
					Type type2 = null;
					try
					{
						if (attributeMap.TryGet("knownTypeName", out value))
						{
							type2 = TypeModel.ResolveKnownType((string)value, Type.Assembly);
						}
						else if (attributeMap.TryGet("knownType", out value))
						{
							type2 = (Type)value;
						}
					}
					catch (Exception innerException)
					{
						throw new InvalidOperationException("Unable to resolve sub-type of: " + Type.FullName, innerException);
					}
					if ((object)type2 == null)
					{
						throw new InvalidOperationException("Unable to resolve sub-type of: " + Type.FullName);
					}
					if (IsValidSubType(type2))
					{
						AddSubType(fieldNumber, type2, dataFormat);
					}
				}
				if (fullName == "ProtoBuf.ProtoPartialIgnoreAttribute" && attributeMap.TryGet("MemberName", out value) && value != null)
				{
					(list ?? (list = new List<string>())).Add((string)value);
				}
				if (!isEnum && fullName == "ProtoBuf.ProtoPartialMemberAttribute")
				{
					(list2 ?? (list2 = new List<AttributeMap>())).Add(attributeMap);
				}
				if (fullName == "ProtoBuf.ProtoContractAttribute")
				{
					if (attributeMap.TryGet("Name", out value))
					{
						text = (string)value;
					}
					if (attributeMap.TryGet("Origin", out value))
					{
						text2 = (string)value;
					}
					if (!Type.IsEnum)
					{
						if (attributeMap.TryGet("DataMemberOffset", out value))
						{
							dataMemberOffset = (int)value;
						}
						if (attributeMap.TryGet("InferTagFromNameHasValue", publicOnly: false, out value) && (bool)value && attributeMap.TryGet("InferTagFromName", out value))
						{
							flag = (bool)value;
						}
						if (attributeMap.TryGet("ImplicitFields", out value) && value != null)
						{
							implicitFields = (ImplicitFields)(int)value;
						}
						if (attributeMap.TryGet("SkipConstructor", out value))
						{
							UseConstructor = !(bool)value;
						}
						if (attributeMap.TryGet("IgnoreListHandling", out value))
						{
							IgnoreListHandling = (bool)value;
						}
						if (attributeMap.TryGet("ImplicitFirstTag", out value) && (int)value > 0)
						{
							num = (int)value;
						}
						if (attributeMap.TryGet("IsGroup", out value))
						{
							IsGroup = (bool)value;
						}
						if (attributeMap.TryGet("IgnoreUnknownSubTypes", out value))
						{
							IgnoreUnknownSubTypes = (bool)value;
						}
						if (attributeMap.TryGet("Surrogate", out value))
						{
							SetSurrogate((Type)value);
						}
						if (attributeMap.TryGet("Serializer", out value))
						{
							SerializerType = (Type)value;
						}
					}
				}
				if (fullName == "System.Runtime.Serialization.DataContractAttribute" && text == null && attributeMap.TryGet("Name", out value))
				{
					text = (string)value;
				}
				if (fullName == "System.Xml.Serialization.XmlTypeAttribute" && text == null && attributeMap.TryGet("TypeName", out value))
				{
					text = (string)value;
				}
				if (fullName == "ProtoBuf.ProtoReservedAttribute" && attributeMap.Target is ProtoReservedAttribute reservation)
				{
					AddReservation(reservation);
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				Name = text;
			}
			if (text2 != null)
			{
				Origin = text2;
			}
			if (implicitFields != ImplicitFields.None)
			{
				attributeFamily &= AttributeFamily.ProtoBuf;
			}
			MethodInfo[] array2 = null;
			List<ProtoMemberAttribute> list3 = new List<ProtoMemberAttribute>();
			List<EnumMember> list4 = new List<EnumMember>();
			MemberInfo[] members = Type.GetMembers(isEnum ? (BindingFlags.Static | BindingFlags.Public) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			MemberInfo[] array3 = members;
			foreach (MemberInfo memberInfo in array3)
			{
				if (memberInfo.DeclaringType != Type || memberInfo.IsDefined(typeof(ProtoIgnoreAttribute), inherit: true) || (list != null && list.Contains(memberInfo.Name)))
				{
					continue;
				}
				bool forced = false;
				if (memberInfo is PropertyInfo propertyInfo)
				{
					if (isEnum)
					{
						continue;
					}
					MemberInfo backingMember = null;
					if (!propertyInfo.CanWrite)
					{
						string text3 = "<" + propertyInfo.Name + ">k__BackingField";
						MemberInfo[] array4 = members;
						foreach (MemberInfo memberInfo2 in array4)
						{
							if (memberInfo2 is FieldInfo && memberInfo2.Name == text3)
							{
								backingMember = memberInfo2;
								break;
							}
						}
					}
					Type effectiveType = propertyInfo.PropertyType;
					bool isPublic = (object)Helpers.GetGetMethod(propertyInfo, nonPublic: false, allowInternal: false) != null;
					bool isField = false;
					ApplyDefaultBehaviour_AddMembers(attributeFamily, isEnum, list2, dataMemberOffset, flag, implicitFields, list3, memberInfo, ref forced, isPublic, isField, ref effectiveType, list4, backingMember);
				}
				else if (memberInfo is FieldInfo { FieldType: var effectiveType2, IsPublic: var isPublic2 } fieldInfo)
				{
					bool isField = true;
					if (!isEnum || fieldInfo.IsStatic)
					{
						ApplyDefaultBehaviour_AddMembers(attributeFamily, isEnum, list2, dataMemberOffset, flag, implicitFields, list3, memberInfo, ref forced, isPublic2, isField, ref effectiveType2, list4);
					}
				}
				else if (memberInfo is MethodInfo methodInfo && !isEnum)
				{
					AttributeMap[] array5 = AttributeMap.Create(methodInfo, inherit: false);
					if (array5 != null && array5.Length != 0)
					{
						CheckForCallback(methodInfo, array5, "ProtoBuf.ProtoBeforeSerializationAttribute", ref array2, 0);
						CheckForCallback(methodInfo, array5, "ProtoBuf.ProtoAfterSerializationAttribute", ref array2, 1);
						CheckForCallback(methodInfo, array5, "ProtoBuf.ProtoBeforeDeserializationAttribute", ref array2, 2);
						CheckForCallback(methodInfo, array5, "ProtoBuf.ProtoAfterDeserializationAttribute", ref array2, 3);
						CheckForCallback(methodInfo, array5, "System.Runtime.Serialization.OnSerializingAttribute", ref array2, 4);
						CheckForCallback(methodInfo, array5, "System.Runtime.Serialization.OnSerializedAttribute", ref array2, 5);
						CheckForCallback(methodInfo, array5, "System.Runtime.Serialization.OnDeserializingAttribute", ref array2, 6);
						CheckForCallback(methodInfo, array5, "System.Runtime.Serialization.OnDeserializedAttribute", ref array2, 7);
					}
				}
			}
			if (flag || implicitFields != ImplicitFields.None)
			{
				list3.Sort();
				int num2 = num;
				foreach (ProtoMemberAttribute item in list3)
				{
					if (!item.TagIsPinned)
					{
						item.Rebase(num2++);
					}
				}
			}
			foreach (ProtoMemberAttribute item2 in list3)
			{
				ValueMember valueMember = ApplyDefaultBehaviour(isEnum, item2);
				if (valueMember != null)
				{
					Add(valueMember);
				}
			}
			foreach (EnumMember item3 in list4)
			{
				Enums.Add(item3);
			}
			if (array2 != null)
			{
				SetCallbacks(Coalesce(array2, 0, 4), Coalesce(array2, 1, 5), Coalesce(array2, 2, 6), Coalesce(array2, 3, 7));
			}
		}

		internal void Assert(CompatibilityLevel expected)
		{
			CompatibilityLevel compatibilityLevel = CompatibilityLevel;
			if (compatibilityLevel != expected)
			{
				ThrowHelper.ThrowInvalidOperationException($"The expected ('{expected}') and actual ('{compatibilityLevel}') compatibility level of '{Type.NormalizeName()}' did not match; the same type cannot be used with different compatibility levels in the same model; this is most commonly an issue with tuple-like types in different contexts");
			}
		}

		private static void ApplyDefaultBehaviour_AddMembers(AttributeFamily family, bool isEnum, List<AttributeMap> partialMembers, int dataMemberOffset, bool inferTagByName, ImplicitFields implicitMode, List<ProtoMemberAttribute> members, MemberInfo member, ref bool forced, bool isPublic, bool isField, ref Type effectiveType, List<EnumMember> enumMembers, MemberInfo backingMember = null)
		{
			switch (implicitMode)
			{
			case ImplicitFields.AllFields:
				if (isField)
				{
					forced = true;
				}
				break;
			case ImplicitFields.AllPublic:
				if (isPublic)
				{
					forced = true;
				}
				break;
			}
			if (effectiveType.IsSubclassOf(typeof(Delegate)))
			{
				effectiveType = null;
			}
			if ((object)effectiveType != null)
			{
				EnumMember enumMember;
				ProtoMemberAttribute protoMemberAttribute = NormalizeProtoMember(member, family, forced, isEnum, partialMembers, dataMemberOffset, inferTagByName, out enumMember, backingMember);
				if (protoMemberAttribute != null)
				{
					members.Add(protoMemberAttribute);
				}
				if (enumMember.HasValue)
				{
					enumMembers.Add(enumMember);
				}
			}
		}

		private static MethodInfo Coalesce(MethodInfo[] arr, int x, int y)
		{
			return arr[x] ?? arr[y];
		}

		internal static AttributeFamily GetContractFamily(RuntimeTypeModel model, Type type, AttributeMap[] attributes)
		{
			AttributeFamily attributeFamily = AttributeFamily.None;
			if (attributes == null)
			{
				attributes = AttributeMap.Create(type, inherit: false);
			}
			for (int i = 0; i < attributes.Length; i++)
			{
				switch (attributes[i].AttributeType.FullName)
				{
				case "ProtoBuf.ProtoContractAttribute":
				{
					bool value = false;
					GetFieldBoolean(ref value, attributes[i], "UseProtoMembersOnly");
					if (value)
					{
						return AttributeFamily.ProtoBuf;
					}
					attributeFamily |= AttributeFamily.ProtoBuf;
					break;
				}
				case "System.Xml.Serialization.XmlTypeAttribute":
					if (!model.AutoAddProtoContractTypesOnly)
					{
						attributeFamily |= AttributeFamily.XmlSerializer;
					}
					break;
				case "System.Runtime.Serialization.DataContractAttribute":
					if (!model.AutoAddProtoContractTypesOnly)
					{
						attributeFamily |= AttributeFamily.DataContractSerializer;
					}
					break;
				}
			}
			if (attributeFamily == AttributeFamily.None && (object)ResolveTupleConstructor(type, out var _) != null)
			{
				attributeFamily |= AttributeFamily.AutoTuple;
			}
			return attributeFamily;
		}

		internal static ConstructorInfo ResolveTupleConstructor(Type type, out MemberInfo[] mappedMembers)
		{
			mappedMembers = null;
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsAbstract)
			{
				return null;
			}
			ConstructorInfo[] constructors = Helpers.GetConstructors(type, nonPublic: false);
			if (constructors.Length == 0 || (constructors.Length == 1 && constructors[0].GetParameters().Length == 0))
			{
				return null;
			}
			MemberInfo[] instanceFieldsAndProperties = Helpers.GetInstanceFieldsAndProperties(type, publicOnly: true);
			List<MemberInfo> list = new List<MemberInfo>();
			bool flag = type.Name.IndexOf("Tuple", StringComparison.OrdinalIgnoreCase) < 0;
			for (int i = 0; i < instanceFieldsAndProperties.Length; i++)
			{
				if (instanceFieldsAndProperties[i] is PropertyInfo propertyInfo)
				{
					if (!propertyInfo.CanRead)
					{
						return null;
					}
					if (flag && propertyInfo.CanWrite && IsPublicSetter(Helpers.GetSetMethod(propertyInfo, nonPublic: false, allowInternal: false)))
					{
						return null;
					}
					list.Add(propertyInfo);
				}
				else if (instanceFieldsAndProperties[i] is FieldInfo fieldInfo)
				{
					if (flag && !fieldInfo.IsInitOnly)
					{
						return null;
					}
					list.Add(fieldInfo);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			MemberInfo[] array = new MemberInfo[list.Count];
			list.CopyTo(array, 0);
			int[] array2 = new int[array.Length];
			int num = 0;
			ConstructorInfo result = null;
			mappedMembers = new MemberInfo[array2.Length];
			for (int j = 0; j < constructors.Length; j++)
			{
				ParameterInfo[] parameters = constructors[j].GetParameters();
				if (parameters.Length != array.Length)
				{
					continue;
				}
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = -1;
				}
				for (int l = 0; l < parameters.Length; l++)
				{
					for (int m = 0; m < array.Length; m++)
					{
						if (string.Compare(parameters[l].Name, array[m].Name, StringComparison.OrdinalIgnoreCase) == 0)
						{
							Type memberType = Helpers.GetMemberType(array[m]);
							if (!(memberType != parameters[l].ParameterType))
							{
								array2[l] = m;
							}
						}
					}
				}
				bool flag2 = false;
				for (int n = 0; n < array2.Length; n++)
				{
					if (array2[n] < 0)
					{
						flag2 = true;
						break;
					}
					mappedMembers[n] = array[array2[n]];
				}
				if (!flag2)
				{
					num++;
					result = constructors[j];
				}
			}
			if (num != 1)
			{
				return null;
			}
			return result;
			static bool IsPublicSetter(MethodInfo method)
			{
				if ((object)method == null)
				{
					return false;
				}
				Type[] array3 = method.ReturnParameter?.GetRequiredCustomModifiers() ?? Type.EmptyTypes;
				for (int num2 = 0; num2 < array3.Length; num2++)
				{
					if (array3[num2]?.FullName == "System.Runtime.CompilerServices.IsExternalInit")
					{
						return false;
					}
				}
				return true;
			}
		}

		private static void CheckForCallback(MethodInfo method, AttributeMap[] attributes, string callbackTypeName, ref MethodInfo[] callbacks, int index)
		{
			for (int i = 0; i < attributes.Length; i++)
			{
				if (attributes[i].AttributeType.FullName == callbackTypeName)
				{
					if (callbacks == null)
					{
						callbacks = new MethodInfo[8];
					}
					else if ((object)callbacks[index] != null)
					{
						Type reflectedType = method.ReflectedType;
						throw new ProtoException("Duplicate " + callbackTypeName + " callbacks on " + reflectedType.FullName);
					}
					callbacks[index] = method;
				}
			}
		}

		private static bool HasFamily(AttributeFamily value, AttributeFamily required)
		{
			return (value & required) == required;
		}

		private static ProtoMemberAttribute NormalizeProtoMember(MemberInfo member, AttributeFamily family, bool forced, bool isEnum, List<AttributeMap> partialMembers, int dataMemberOffset, bool inferByTagName, out EnumMember enumMember, MemberInfo backingMember = null)
		{
			enumMember = default(EnumMember);
			if ((object)member == null || (family == AttributeFamily.None && !isEnum))
			{
				return null;
			}
			int value = int.MinValue;
			int num = ((!inferByTagName) ? 1 : (-1));
			string text = null;
			bool value2 = false;
			bool ignore = false;
			bool flag = false;
			bool value3 = false;
			bool value4 = false;
			bool value5 = false;
			bool value6 = false;
			bool tagIsPinned = false;
			bool value7 = false;
			DataFormat value8 = DataFormat.Default;
			if (isEnum)
			{
				forced = true;
			}
			AttributeMap[] attribs = AttributeMap.Create(member, inherit: true);
			if (isEnum)
			{
				if (GetAttribute(attribs, "ProtoBuf.ProtoIgnoreAttribute") == null)
				{
					AttributeMap attribute = GetAttribute(attribs, "ProtoBuf.ProtoEnumAttribute");
					object rawConstantValue = ((FieldInfo)member).GetRawConstantValue();
					if (attribute != null)
					{
						GetFieldName(ref text, attribute, "Name");
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						text = member.Name;
					}
					enumMember = new EnumMember(rawConstantValue, text);
				}
				return null;
			}
			if (!ignore && !flag)
			{
				AttributeMap attribute = GetAttribute(attribs, "ProtoBuf.ProtoMemberAttribute");
				GetIgnore(ref ignore, attribute, attribs, "ProtoBuf.ProtoIgnoreAttribute");
				if (!ignore && attribute != null)
				{
					GetFieldNumber(ref value, attribute, "Tag");
					GetFieldName(ref text, attribute, "Name");
					GetFieldBoolean(ref value3, attribute, "IsRequired");
					GetFieldBoolean(ref value2, attribute, "IsPacked");
					GetFieldBoolean(ref value7, attribute, "OverwriteList");
					GetDataFormat(ref value8, attribute, "DataFormat");
					GetFieldBoolean(ref value5, attribute, "AsReferenceHasValue", publicOnly: false);
					if (value5)
					{
						value5 = GetFieldBoolean(ref value4, attribute, "AsReference", publicOnly: true);
					}
					GetFieldBoolean(ref value6, attribute, "DynamicType");
					flag = (tagIsPinned = value > 0);
				}
				if (!flag && partialMembers != null)
				{
					foreach (AttributeMap partialMember in partialMembers)
					{
						if (partialMember.TryGet("MemberName", out var value9) && (string)value9 == member.Name)
						{
							GetFieldNumber(ref value, partialMember, "Tag");
							GetFieldName(ref text, partialMember, "Name");
							GetFieldBoolean(ref value3, partialMember, "IsRequired");
							GetFieldBoolean(ref value2, partialMember, "IsPacked");
							GetFieldBoolean(ref value7, attribute, "OverwriteList");
							GetDataFormat(ref value8, partialMember, "DataFormat");
							GetFieldBoolean(ref value5, attribute, "AsReferenceHasValue", publicOnly: false);
							if (value5)
							{
								value5 = GetFieldBoolean(ref value4, partialMember, "AsReference", publicOnly: true);
							}
							GetFieldBoolean(ref value6, partialMember, "DynamicType");
							if (flag = (tagIsPinned = value > 0))
							{
								break;
							}
						}
					}
				}
			}
			if (!ignore && !flag && HasFamily(family, AttributeFamily.DataContractSerializer))
			{
				AttributeMap attribute = GetAttribute(attribs, "System.Runtime.Serialization.DataMemberAttribute");
				if (attribute != null)
				{
					GetFieldNumber(ref value, attribute, "Order");
					GetFieldName(ref text, attribute, "Name");
					GetFieldBoolean(ref value3, attribute, "IsRequired");
					flag = value >= num;
					if (flag)
					{
						value += dataMemberOffset;
					}
				}
			}
			if (!ignore && !flag && HasFamily(family, AttributeFamily.XmlSerializer))
			{
				AttributeMap attribute = GetAttribute(attribs, "System.Xml.Serialization.XmlElementAttribute") ?? GetAttribute(attribs, "System.Xml.Serialization.XmlArrayAttribute");
				GetIgnore(ref ignore, attribute, attribs, "System.Xml.Serialization.XmlIgnoreAttribute");
				if (attribute != null && !ignore)
				{
					GetFieldNumber(ref value, attribute, "Order");
					GetFieldName(ref text, attribute, "ElementName");
					flag = value >= num;
				}
			}
			if (!ignore && !flag && GetAttribute(attribs, "System.NonSerializedAttribute") != null)
			{
				ignore = true;
			}
			if (ignore || (value < num && !forced))
			{
				return null;
			}
			return new ProtoMemberAttribute(value, forced || inferByTagName)
			{
				DataFormat = value8,
				IsPacked = value2,
				OverwriteList = value7,
				IsRequired = value3,
				Name = (string.IsNullOrEmpty(text) ? member.Name : text),
				Member = member,
				BackingMember = backingMember,
				TagIsPinned = tagIsPinned
			};
		}

		private ValueMember ApplyDefaultBehaviour(bool isEnum, ProtoMemberAttribute normalizedAttribute)
		{
			MemberInfo member;
			if (normalizedAttribute == null || (object)(member = normalizedAttribute.Member) == null)
			{
				return null;
			}
			Type memberType = Helpers.GetMemberType(member);
			CompatibilityLevel memberCompatibilityLevel = TypeCompatibilityHelper.GetMemberCompatibilityLevel(member, CompatibilityLevel);
			RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(memberType, memberCompatibilityLevel);
			AttributeMap[] attribs = AttributeMap.Create(member, inherit: true);
			object defaultValue = null;
			if (model.UseImplicitZeroDefaults)
			{
				switch (Helpers.GetTypeCode(memberType))
				{
				case ProtoTypeCode.Boolean:
					defaultValue = false;
					break;
				case ProtoTypeCode.Decimal:
					defaultValue = 0m;
					break;
				case ProtoTypeCode.Single:
					defaultValue = 0f;
					break;
				case ProtoTypeCode.Double:
					defaultValue = 0.0;
					break;
				case ProtoTypeCode.Byte:
					defaultValue = (byte)0;
					break;
				case ProtoTypeCode.Char:
					defaultValue = '\0';
					break;
				case ProtoTypeCode.Int16:
					defaultValue = (short)0;
					break;
				case ProtoTypeCode.Int32:
					defaultValue = 0;
					break;
				case ProtoTypeCode.Int64:
					defaultValue = 0L;
					break;
				case ProtoTypeCode.SByte:
					defaultValue = (sbyte)0;
					break;
				case ProtoTypeCode.UInt16:
					defaultValue = (ushort)0;
					break;
				case ProtoTypeCode.UInt32:
					defaultValue = 0u;
					break;
				case ProtoTypeCode.UInt64:
					defaultValue = 0uL;
					break;
				case ProtoTypeCode.TimeSpan:
					defaultValue = TimeSpan.Zero;
					break;
				case ProtoTypeCode.Guid:
					defaultValue = Guid.Empty;
					break;
				case ProtoTypeCode.IntPtr:
					defaultValue = IntPtr.Zero;
					break;
				case ProtoTypeCode.UIntPtr:
					defaultValue = UIntPtr.Zero;
					break;
				}
			}
			AttributeMap attribute;
			if ((attribute = GetAttribute(attribs, "System.ComponentModel.DefaultValueAttribute")) != null && attribute.TryGet("Value", out var value))
			{
				defaultValue = value;
			}
			ValueMember valueMember = ((isEnum || normalizedAttribute.Tag > 0) ? new ValueMember(model, Type, normalizedAttribute.Tag, member, memberType, repeatedSerializerStub?.ItemType, null, normalizedAttribute.DataFormat, defaultValue) : null);
			if (valueMember != null)
			{
				valueMember.CompatibilityLevel = memberCompatibilityLevel;
				valueMember.BackingMember = normalizedAttribute.BackingMember;
				Type type = Type;
				PropertyInfo propertyInfo = Helpers.GetProperty(type, member.Name + "Specified", nonPublic: true);
				MethodInfo getMethod = Helpers.GetGetMethod(propertyInfo, nonPublic: true, allowInternal: true);
				if ((object)getMethod == null || getMethod.IsStatic)
				{
					propertyInfo = null;
				}
				if ((object)propertyInfo != null)
				{
					valueMember.SetSpecified(getMethod, Helpers.GetSetMethod(propertyInfo, nonPublic: true, allowInternal: true));
				}
				else
				{
					MethodInfo instanceMethod = Helpers.GetInstanceMethod(type, "ShouldSerialize" + member.Name, Type.EmptyTypes);
					if ((object)instanceMethod != null && instanceMethod.ReturnType == typeof(bool))
					{
						valueMember.SetSpecified(instanceMethod, null);
					}
				}
				if (!string.IsNullOrEmpty(normalizedAttribute.Name))
				{
					valueMember.SetName(normalizedAttribute.Name);
				}
				valueMember.IsPacked = normalizedAttribute.IsPacked;
				valueMember.IsRequired = normalizedAttribute.IsRequired;
				valueMember.OverwriteList = normalizedAttribute.OverwriteList;
				if (repeatedSerializerStub != null)
				{
					DataFormat dataFormat = DataFormat.Default;
					DataFormat mapValueFormat = DataFormat.Default;
					bool flag = true;
					if ((attribute = GetAttribute(attribs, "ProtoBuf.ProtoMapAttribute")) != null)
					{
						if (attribute.TryGet("DisableMap", out var value2) && (bool)value2)
						{
							flag = false;
						}
						else
						{
							if (attribute.TryGet("KeyFormat", out value2))
							{
								dataFormat = (DataFormat)value2;
							}
							if (attribute.TryGet("ValueFormat", out value2))
							{
								mapValueFormat = (DataFormat)value2;
							}
						}
					}
					if (flag && repeatedSerializerStub.IsValidProtobufMap(model, valueMember.CompatibilityLevel, dataFormat))
					{
						valueMember.MapKeyFormat = dataFormat;
						valueMember.MapValueFormat = mapValueFormat;
						valueMember.IsMap = true;
					}
				}
				if ((attribute = GetAttribute(attribs, typeof(NullWrappedValueAttribute).FullName)) != null)
				{
					valueMember.NullWrappedValue = true;
					if (attribute.TryGet("AsGroup", out var value3) && value3 is bool nullWrappedValueGroup)
					{
						valueMember.NullWrappedValueGroup = nullWrappedValueGroup;
					}
				}
				if ((attribute = GetAttribute(attribs, typeof(NullWrappedCollectionAttribute).FullName)) != null)
				{
					valueMember.NullWrappedCollection = true;
					if (attribute.TryGet("AsGroup", out var value4) && value4 is bool nullWrappedCollectionGroup)
					{
						valueMember.NullWrappedCollectionGroup = nullWrappedCollectionGroup;
					}
				}
			}
			return valueMember;
		}

		private static void GetDataFormat(ref DataFormat value, AttributeMap attrib, string memberName)
		{
			if (attrib != null && value == DataFormat.Default && attrib.TryGet(memberName, out var value2) && value2 != null)
			{
				value = (DataFormat)value2;
			}
		}

		private static void GetIgnore(ref bool ignore, AttributeMap attrib, AttributeMap[] attribs, string fullName)
		{
			if (!ignore && attrib != null)
			{
				ignore = GetAttribute(attribs, fullName) != null;
			}
		}

		private static void GetFieldBoolean(ref bool value, AttributeMap attrib, string memberName)
		{
			GetFieldBoolean(ref value, attrib, memberName, publicOnly: true);
		}

		private static bool GetFieldBoolean(ref bool value, AttributeMap attrib, string memberName, bool publicOnly)
		{
			if (attrib == null)
			{
				return false;
			}
			if (value)
			{
				return true;
			}
			if (attrib.TryGet(memberName, publicOnly, out var value2) && value2 != null)
			{
				value = (bool)value2;
				return true;
			}
			return false;
		}

		private static void GetFieldNumber(ref int value, AttributeMap attrib, string memberName)
		{
			if (attrib != null && value <= 0 && attrib.TryGet(memberName, out var value2) && value2 != null)
			{
				value = (int)value2;
			}
		}

		private static void GetFieldName(ref string name, AttributeMap attrib, string memberName)
		{
			if (attrib != null && string.IsNullOrEmpty(name) && attrib.TryGet(memberName, out var value) && value != null)
			{
				name = (string)value;
			}
		}

		private static AttributeMap GetAttribute(AttributeMap[] attribs, string fullName)
		{
			foreach (AttributeMap attributeMap in attribs)
			{
				if (attributeMap != null && attributeMap.AttributeType.FullName == fullName)
				{
					return attributeMap;
				}
			}
			return null;
		}

		public MetaType Add(int fieldNumber, string memberName)
		{
			AddField(fieldNumber, memberName, null, null, null);
			return this;
		}

		public ValueMember AddField(int fieldNumber, string memberName)
		{
			return AddField(fieldNumber, memberName, null, null, null);
		}

		public MetaType Add(string memberName)
		{
			Add(GetNextFieldNumber(), memberName);
			return this;
		}

		public void SetSurrogate(Type surrogateType)
		{
			SetSurrogate(surrogateType, null, null, DataFormat.Default);
		}

		internal void SetSurrogate(Type surrogateType, MethodInfo underlyingToSurrogate, MethodInfo surrogateToUnderlying, DataFormat dataFormat)
		{
			if (surrogateType == Type)
			{
				surrogateType = null;
			}
			if ((object)surrogateType != null)
			{
				if (surrogateType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(surrogateType))
				{
					ThrowHelper.ThrowArgumentException("Repeated data (a list, collection, etc) has inbuilt behaviour and cannot be used as a surrogate");
				}
				if ((BaseType != null && BaseType != this) || (_subTypes?.Count ?? 0) > 0)
				{
					ThrowSubTypeWithSurrogate(Type);
				}
				if (surrogateType.IsGenericTypeDefinition)
				{
					if (!Type.IsGenericType)
					{
						ThrowHelper.ThrowArgumentException("Cannot use an open generic type as a surrogate for a non generic type");
					}
					Type[] genericArguments = Type.GetGenericArguments();
					if (genericArguments.Length != surrogateType.GetGenericArguments().Length)
					{
						ThrowHelper.ThrowArgumentException("The generic type parameters of the surrogate must match the generic arguments of the target type");
					}
					surrogateType = surrogateType.MakeGenericType(genericArguments);
				}
			}
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				ThrowIfFrozen();
				this.surrogateType = surrogateType;
				this.underlyingToSurrogate = underlyingToSurrogate;
				this.surrogateToUnderlying = surrogateToUnderlying;
				surrogateDataFormat = dataFormat;
				SetFlag(TypeOptions.AutoTuple, value: false, throwIfFrozen: false);
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		internal MetaType GetSurrogateOrSelf()
		{
			if ((object)surrogateType != null)
			{
				return model[surrogateType];
			}
			return this;
		}

		internal MetaType GetSurrogateOrBaseOrSelf(bool deep)
		{
			if ((object)surrogateType != null)
			{
				return model[surrogateType];
			}
			MetaType metaType = baseType;
			if (metaType != null)
			{
				if (deep)
				{
					MetaType result;
					do
					{
						result = metaType;
						metaType = metaType.baseType;
					}
					while (metaType != null);
					return result;
				}
				return metaType;
			}
			return this;
		}

		private int GetNextFieldNumber()
		{
			int num = 0;
			if (HasFields)
			{
				foreach (ValueMember field in Fields)
				{
					if (field.FieldNumber > num)
					{
						num = field.FieldNumber;
					}
				}
			}
			if (_subTypes != null)
			{
				foreach (SubType subType in _subTypes)
				{
					if (subType.FieldNumber > num)
					{
						num = subType.FieldNumber;
					}
				}
			}
			return num + 1;
		}

		public MetaType Add(params string[] memberNames)
		{
			if (memberNames == null)
			{
				throw new ArgumentNullException("memberNames");
			}
			int nextFieldNumber = GetNextFieldNumber();
			for (int i = 0; i < memberNames.Length; i++)
			{
				Add(nextFieldNumber++, memberNames[i]);
			}
			return this;
		}

		public MetaType Add(int fieldNumber, string memberName, object defaultValue)
		{
			AddField(fieldNumber, memberName, null, null, defaultValue);
			return this;
		}

		public MetaType Add(int fieldNumber, string memberName, Type itemType, Type defaultType)
		{
			AddField(fieldNumber, memberName, itemType, defaultType, null);
			return this;
		}

		public ValueMember AddField(int fieldNumber, string memberName, Type itemType, Type defaultType)
		{
			return AddField(fieldNumber, memberName, itemType, defaultType, null);
		}

		private void ThrowIfAutoTuple()
		{
			if (IsAutoTuple)
			{
				Throw();
			}
			static void Throw()
			{
				throw new InvalidOperationException("This operation is not supported for tuple-like types; to disable tuple-like type discovery, use applyDefaultBehaviour: false when first adding the type to the model.");
			}
		}

		private ValueMember AddField(int fieldNumber, string memberName, Type itemType, Type defaultType, object defaultValue)
		{
			MemberInfo memberInfo = null;
			MemberInfo[] member = Type.GetMember(memberName, Type.IsEnum ? (BindingFlags.Static | BindingFlags.Public) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			if (member != null && member.Length == 1)
			{
				memberInfo = member[0];
			}
			if ((object)memberInfo == null)
			{
				throw new ArgumentException("Unable to determine member: " + memberName, "memberName");
			}
			ThrowIfAutoTuple();
			PropertyInfo propertyInfo = null;
			Type type;
			switch (memberInfo.MemberType)
			{
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)memberInfo;
				type = fieldInfo.FieldType;
				break;
			}
			case MemberTypes.Property:
				propertyInfo = (PropertyInfo)memberInfo;
				type = propertyInfo.PropertyType;
				break;
			default:
				throw new NotSupportedException(memberInfo.MemberType.ToString());
			}
			RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(type);
			if ((object)itemType != null && repeatedSerializerStub?.ItemType != itemType)
			{
				ThrowHelper.ThrowInvalidOperationException("Expected item type of " + repeatedSerializerStub?.ItemType.NormalizeName());
			}
			MemberInfo memberInfo2 = null;
			if ((object)propertyInfo != null && !propertyInfo.CanWrite)
			{
				MemberInfo[] member2 = Type.GetMember("<" + ((PropertyInfo)memberInfo).Name + ">k__BackingField", Type.IsEnum ? (BindingFlags.Static | BindingFlags.Public) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				if (member2 != null && member2.Length == 1 && member2[0] is FieldInfo)
				{
					memberInfo2 = member2[0];
				}
			}
			if (repeatedSerializerStub != null)
			{
				if ((object)defaultType != null && defaultType != repeatedSerializerStub.ForType)
				{
					ThrowHelper.ThrowNotSupportedException("Default types for collections are not currently supported; recommendation: initialize the colleciton in the type");
				}
				defaultType = repeatedSerializerStub.ForType;
			}
			ValueMember valueMember = new ValueMember(model, Type, fieldNumber, memberInfo2 ?? memberInfo, type, repeatedSerializerStub?.ItemType, defaultType, DataFormat.Default, defaultValue)
			{
				CompatibilityLevel = CompatibilityLevel
			};
			if ((object)memberInfo2 != null)
			{
				valueMember.SetName(memberInfo.Name);
			}
			Add(valueMember);
			return valueMember;
		}

		private void Add(ValueMember member)
		{
			if (Type.IsEnum)
			{
				ThrowHelper.ThrowInvalidOperationException("Enums should use SetEnumValues to customize the enum definitions");
			}
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				ThrowIfFrozen();
				Fields.Add(member);
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		public ValueMember[] GetFields()
		{
			if (!HasFields)
			{
				return Array.Empty<ValueMember>();
			}
			ValueMember[] array = Fields.ToArray();
			Array.Sort(array, ValueMember.Comparer.Default);
			return array;
		}

		public EnumMember[] GetEnumValues()
		{
			if (!HasEnums)
			{
				return Array.Empty<EnumMember>();
			}
			EnumMember[] array = Enums.ToArray();
			Array.Sort(array);
			return array;
		}

		public void SetEnumValues(EnumMember[] values)
		{
			if (!Type.IsEnum)
			{
				ThrowHelper.ThrowInvalidOperationException("Only enums should use SetEnumValues");
			}
			if (values == null)
			{
				ThrowHelper.ThrowArgumentNullException("values");
			}
			EnumMember[] collection = Array.ConvertAll(values, (EnumMember val) => val.Normalize(Type));
			foreach (EnumMember enumMember in values)
			{
				enumMember.Validate();
			}
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				ThrowIfFrozen();
				Enums.Clear();
				Enums.AddRange(collection);
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		internal bool IsValidEnum()
		{
			return IsValidEnum(_enums);
		}

		internal static bool IsValidEnum(IList<EnumMember> values)
		{
			if (values == null || values.Count == 0)
			{
				return false;
			}
			foreach (EnumMember value in values)
			{
				if (!value.TryGetInt32().HasValue)
				{
					return false;
				}
			}
			return true;
		}

		public SubType[] GetSubtypes()
		{
			if (_subTypes == null || _subTypes.Count == 0)
			{
				return Array.Empty<SubType>();
			}
			SubType[] array = _subTypes.ToArray();
			Array.Sort(array, SubType.Comparer.Default);
			return array;
		}

		internal IEnumerable<Type> GetAllGenericArguments()
		{
			return GetAllGenericArguments(Type);
		}

		private static IEnumerable<Type> GetAllGenericArguments(Type type)
		{
			Type[] genericArguments = type.GetGenericArguments();
			Type[] array = genericArguments;
			foreach (Type arg in array)
			{
				yield return arg;
				foreach (Type allGenericArgument in GetAllGenericArguments(arg))
				{
					yield return allGenericArgument;
				}
			}
		}

		public void CompileInPlace()
		{
			IProtoTypeSerializer serializer = Serializer;
			if (!(serializer is ICompiledSerializer) && !serializer.ExpectedType.IsEnum && model.TryGetRepeatedProvider(Type) == null)
			{
				ICompiledSerializer compiledSerializer = CompiledSerializer.Wrap(serializer, model);
				if (serializer != compiledSerializer)
				{
					_serializer = (IProtoTypeSerializer)compiledSerializer;
					Model.ResetServiceCache(Type);
				}
			}
		}

		internal bool IsDefined(int fieldNumber)
		{
			if (HasFields)
			{
				foreach (ValueMember field in Fields)
				{
					if (field.FieldNumber == fieldNumber)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool HasFlag(TypeOptions flag)
		{
			return (flags & flag) == flag;
		}

		private void SetFlag(TypeOptions flag, bool value, bool throwIfFrozen)
		{
			if (throwIfFrozen && HasFlag(flag) != value)
			{
				ThrowIfFrozen();
			}
			if (value)
			{
				flags |= flag;
			}
			else
			{
				flags &= (TypeOptions)(ushort)(~(int)flag);
			}
		}

		internal static MetaType GetRootType(MetaType source)
		{
			while (source._serializer != null)
			{
				MetaType metaType = source.baseType;
				if (metaType == null)
				{
					return source;
				}
				source = metaType;
			}
			RuntimeTypeModel runtimeTypeModel = source.model;
			int opaqueToken = 0;
			try
			{
				runtimeTypeModel.TakeLock(ref opaqueToken);
				MetaType metaType2;
				while ((metaType2 = source.baseType) != null)
				{
					source = metaType2;
				}
				return source;
			}
			finally
			{
				runtimeTypeModel.ReleaseLock(opaqueToken);
			}
		}

		internal bool IsPrepared()
		{
			return _serializer is CompiledSerializer;
		}

		internal static StringBuilder NewLine(StringBuilder builder, int indent)
		{
			return builder.AppendLine().Append(' ', indent * 3);
		}

		internal void WriteSchema(HashSet<Type> callstack, StringBuilder builder, int indent, HashSet<string> imports, ProtoSyntax syntax, string package, SchemaGenerationFlags flags)
		{
			if ((object)surrogateType != null)
			{
				return;
			}
			bool multipleNamespaceSupport = (flags & SchemaGenerationFlags.MultipleNamespaceSupport) != 0;
			bool flag = (flags & SchemaGenerationFlags.IncludeEnumNamePrefix) != 0;
			RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(Type);
			if (repeatedSerializerStub != null)
			{
				NewLine(builder, indent).Append("message ").Append(GetSchemaTypeName(callstack)).Append(" {");
				if (repeatedSerializerStub.IsValidProtobufMap(model, CompatibilityLevel, DataFormat.Default))
				{
					repeatedSerializerStub.ResolveMapTypes(out var keyType, out var valueType);
					NewLine(builder, indent + 1).Append("map<").Append(model.GetSchemaTypeName(callstack, keyType, DataFormat.Default, CompatibilityLevel, asReference: false, dynamicType: false, imports)).Append(", ")
						.Append(model.GetSchemaTypeName(callstack, valueType, DataFormat.Default, CompatibilityLevel, asReference: false, dynamicType: false, imports))
						.Append("> items = 1;");
				}
				else
				{
					NewLine(builder, indent + 1).Append("repeated ").Append(model.GetSchemaTypeName(callstack, repeatedSerializerStub.ItemType, DataFormat.Default, CompatibilityLevel, asReference: false, dynamicType: false, imports)).Append(" items = 1;");
				}
				NewLine(builder, indent).Append('}');
				return;
			}
			if (IsAutoTuple)
			{
				if ((object)ResolveTupleConstructor(Type, out var mappedMembers) == null)
				{
					return;
				}
				NewLine(builder, indent).Append("message ").Append(GetSchemaTypeName(callstack)).Append(" {");
				AddNamespace(imports);
				for (int i = 0; i < mappedMembers.Length; i++)
				{
					Type effectiveType;
					if (mappedMembers[i] is PropertyInfo propertyInfo)
					{
						effectiveType = propertyInfo.PropertyType;
					}
					else
					{
						if (!(mappedMembers[i] is FieldInfo fieldInfo))
						{
							throw new NotSupportedException("Unknown member type: " + mappedMembers[i].GetType().Name);
						}
						effectiveType = fieldInfo.FieldType;
					}
					NewLine(builder, indent + 1).Append((syntax == ProtoSyntax.Proto2) ? "optional " : "").Append(model.GetSchemaTypeName(callstack, effectiveType, DataFormat.Default, CompatibilityLevel, asReference: false, dynamicType: false, imports)).Append(' ')
						.Append(mappedMembers[i].Name)
						.Append(" = ")
						.Append(i + 1)
						.Append(';');
				}
				NewLine(builder, indent).Append('}');
				return;
			}
			if (Type.IsEnum)
			{
				EnumMember[] enumValues = GetEnumValues();
				string value = (flag ? (GetSchemaTypeName(callstack) + "_") : "");
				bool flag2 = IsValidEnum(enumValues);
				if (!flag2)
				{
					NewLine(builder, indent).Append("/* for context only");
				}
				NewLine(builder, indent).Append("enum ").Append(GetSchemaTypeName(callstack)).Append(" {");
				AddNamespace(imports);
				if (Type.IsDefined(typeof(FlagsAttribute), inherit: true))
				{
					NewLine(builder, indent + 1).Append("// this is a composite/flags enumeration");
				}
				bool flag3 = false;
				HashSet<int> hashSet = new HashSet<int>();
				EnumMember[] array = enumValues;
				foreach (EnumMember enumMember in array)
				{
					int? num = enumMember.TryGetInt32();
					if (num.HasValue && !hashSet.Add(num.Value))
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					NewLine(builder, indent + 1).Append("option allow_alias = true;");
				}
				bool flag4 = false;
				EnumMember[] array2 = enumValues;
				for (int k = 0; k < array2.Length; k++)
				{
					EnumMember enumMember2 = array2[k];
					int? num2 = enumMember2.TryGetInt32();
					if (num2.HasValue && num2.Value == 0)
					{
						NewLine(builder, indent + 1).Append(value).Append(enumMember2.Name).Append(" = 0;");
						flag4 = true;
					}
				}
				if (syntax == ProtoSyntax.Proto3 && !flag4)
				{
					NewLine(builder, indent + 1).Append(value).Append("ZERO").Append(" = 0;")
						.Append(" // proto3 requires a zero value as the first item (it can be named anything)");
				}
				EnumMember[] array3 = enumValues;
				for (int l = 0; l < array3.Length; l++)
				{
					EnumMember enumMember3 = array3[l];
					int? num3 = enumMember3.TryGetInt32();
					if (num3.HasValue)
					{
						if (num3.Value != 0)
						{
							NewLine(builder, indent + 1).Append(value).Append(enumMember3.Name).Append(" = ")
								.Append(num3.Value)
								.Append(';');
						}
					}
					else
					{
						NewLine(builder, indent + 1).Append("// ").Append(value).Append(enumMember3.Name)
							.Append(" = ")
							.Append(enumMember3.Value)
							.Append(';')
							.Append(" // note: enums should be valid 32-bit integers");
					}
				}
				if (HasReservations)
				{
					AppendReservations();
				}
				NewLine(builder, indent).Append('}');
				if (!flag2)
				{
					NewLine(builder, indent).Append("*/");
				}
				return;
			}
			ExtraLayerValueMembers extraLayerValueMembers = new ExtraLayerValueMembers();
			ValueMember[] fields = GetFields();
			int length = builder.Length;
			NewLine(builder, indent).Append("message ").Append(GetSchemaTypeName(callstack)).Append(" {");
			AddNamespace(imports);
			ValueMember[] array4 = fields;
			foreach (ValueMember member in array4)
			{
				bool hasOption = false;
				string schemaTypeName2;
				string altName;
				if (member.IsMap)
				{
					if (member.NullWrappedCollection || member.NullWrappedValue)
					{
						throw new NotSupportedException("Schema generation for null-wrapped maps and maps with null-wrapped values is not currently implemented; poke @mgravell with a big stick if you need this!");
					}
					repeatedSerializerStub = model.TryGetRepeatedProvider(member.MemberType);
					repeatedSerializerStub.ResolveMapTypes(out var keyType2, out var valueType2);
					string schemaTypeName = model.GetSchemaTypeName(callstack, keyType2, member.MapKeyFormat, CompatibilityLevel, asReference: false, dynamicType: false, imports);
					schemaTypeName2 = model.GetSchemaTypeName(callstack, valueType2, member.MapValueFormat, CompatibilityLevel, member.AsReference, member.DynamicType, imports);
					NewLine(builder, indent + 1).Append("map<").Append(schemaTypeName).Append(',')
						.Append(schemaTypeName2)
						.Append("> ")
						.Append(member.Name)
						.Append(" = ")
						.Append(member.FieldNumber)
						.Append(';');
				}
				else if (member.RequiresExtraLayerInSchema())
				{
					schemaTypeName2 = member.GetSchemaTypeName(callstack, applyNetObjectProxy: true, imports, out altName);
					NullWrappedValueMemberData nullWrappedValueMemberData = extraLayerValueMembers.Add(schemaTypeName2, member);
					WriteValueMember(nullWrappedValueMemberData.WrappedSchemaTypeName, nullWrappedValueMemberData.HasGroupModifier);
				}
				else
				{
					bool considerWrappersProtoTypes = member.HasExtendedNullSupport();
					schemaTypeName2 = member.GetSchemaTypeName(callstack, applyNetObjectProxy: true, imports, out altName, considerWrappersProtoTypes);
					WriteValueMember(schemaTypeName2, member.RequiresGroupModifier);
				}
				if (schemaTypeName2 == ".bcl.NetObjectProxy" && member.AsReference && !member.DynamicType)
				{
					builder.Append(" // reference-tracked ").Append(member.GetSchemaTypeName(callstack, applyNetObjectProxy: false, imports, out var _));
				}
				void WriteValueMember(string schemaModelTypeName, bool hasGroupModifier = false)
				{
					if (member.NullWrappedCollection)
					{
						throw new NotSupportedException("Schema generation for null-wrapped collections is not currently implemented; poke @mgravell with a big stick if you need this!");
					}
					string value3 = (((object)member.ItemType != null) ? "repeated " : ((syntax != ProtoSyntax.Proto2) ? "" : (member.IsRequired ? "required " : "optional ")));
					NewLine(builder, indent + 1).Append(value3);
					if (hasGroupModifier)
					{
						builder.Append("group ");
					}
					else if (member.DataFormat == DataFormat.Group)
					{
						builder.Append("group ");
					}
					builder.Append(schemaModelTypeName).Append(' ').Append(member.Name)
						.Append(" = ")
						.Append(member.FieldNumber);
					if (syntax == ProtoSyntax.Proto2 && member.DefaultValue != null && !member.IsRequired)
					{
						if (member.DefaultValue is string)
						{
							AddOption(builder, ref hasOption).Append("default = \"").Append(member.DefaultValue).Append('"');
						}
						else if (!(member.DefaultValue is TimeSpan))
						{
							if (member.DefaultValue is bool flag5)
							{
								AddOption(builder, ref hasOption).Append(flag5 ? "default = true" : "default = false");
							}
							else
							{
								object defaultValue = member.DefaultValue;
								if (defaultValue is Enum && defaultValue.GetType() == member.MemberType && model.IsDefined(member.MemberType, member.CompatibilityLevel))
								{
									MetaType metaType = model[member.MemberType];
									foreach (EnumMember @enum in metaType.Enums)
									{
										if (!string.IsNullOrWhiteSpace(@enum.Name) && defaultValue.Equals(@enum.Value))
										{
											defaultValue = @enum.Name;
											break;
										}
									}
								}
								AddOption(builder, ref hasOption).Append("default = ").Append(member.DefaultValue);
							}
						}
					}
					if (CanPack(member.ItemType))
					{
						if (syntax == ProtoSyntax.Proto2)
						{
							if (member.IsPacked)
							{
								AddOption(builder, ref hasOption).Append("packed = true");
							}
						}
						else if (!member.IsPacked)
						{
							AddOption(builder, ref hasOption).Append("packed = false");
						}
					}
					if (member.AsReference)
					{
						imports.Add("protobuf-net/protogen.proto");
						AddOption(builder, ref hasOption).Append("(.protobuf_net.fieldopt).asRef = true");
					}
					if (member.DynamicType)
					{
						imports.Add("protobuf-net/protogen.proto");
						AddOption(builder, ref hasOption).Append("(.protobuf_net.fieldopt).dynamicType = true");
					}
					CloseOption(builder, ref hasOption).Append(';');
					if (syntax != ProtoSyntax.Proto2 && member.DefaultValue != null && !member.IsRequired && !IsImplicitDefault(member.DefaultValue))
					{
						builder.Append(" // default value could not be applied: ").Append(member.DefaultValue);
					}
					if (!string.IsNullOrWhiteSpace(altName))
					{
						builder.Append(" // declared as invalid enum: ").Append(altName);
					}
				}
			}
			if (_subTypes != null && _subTypes.Count != 0)
			{
				SubType[] array5 = _subTypes.ToArray();
				Array.Sort(array5, SubType.Comparer.Default);
				string[] array6 = new string[array5.Length];
				for (int n = 0; n < array5.Length; n++)
				{
					array6[n] = array5[n].DerivedType.GetSchemaTypeName(callstack);
				}
				string text = "subtype";
				while (Array.IndexOf(array6, text) >= 0)
				{
					text = "_" + text;
				}
				NewLine(builder, indent + 1).Append("oneof ").Append(text).Append(" {");
				if ((flags & SchemaGenerationFlags.PreserveSubType) != SchemaGenerationFlags.None)
				{
					imports.Add("protobuf-net/protogen.proto");
					NewLine(builder, indent + 2).Append("option (.protobuf_net.oneofopt).isSubType = true;");
				}
				for (int num4 = 0; num4 < array5.Length; num4++)
				{
					string value2 = array6[num4];
					NewLine(builder, indent + 2).Append(value2).Append(' ').Append(value2)
						.Append(" = ")
						.Append(array5[num4].FieldNumber)
						.Append(';');
				}
				NewLine(builder, indent + 1).Append('}');
			}
			if (HasReservations)
			{
				AppendReservations();
			}
			NewLine(builder, indent).Append('}');
			AddExtraLayerSchemaModels(extraLayerValueMembers, length);
			void AddExtraLayerSchemaModels(ExtraLayerValueMembers extraLayerValueMembers2, int pos)
			{
				if (extraLayerValueMembers2.IsEmpty())
				{
					return;
				}
				foreach (NullWrappedValueMemberData item in extraLayerValueMembers2)
				{
					NullWrappedValueMemberData wrappedValueMember = item;
					if (wrappedValueMember.HasSchemaTypeNameCollision)
					{
						builder.NewLine(ref pos, indent).Insert("// warning: duplicate message name; you can use [ProtoContract(Name = \"...\")] to supply an alternative schema name", ref pos);
					}
					builder.NewLine(ref pos, indent).Insert("message ", ref pos).Insert(wrappedValueMember.WrappedSchemaTypeName, ref pos)
						.Insert(" {", ref pos);
					builder.NewLine(ref pos, indent + 1);
					WriteWrappedFieldPayload();
					builder.Insert(";", ref pos);
					builder.NewLine(ref pos, indent).Insert("}", ref pos);
					void WriteWrappedFieldPayload()
					{
						builder.Insert("optional ", ref pos).Insert(wrappedValueMember.SchemaTypeName, ref pos).Insert(" value = 1", ref pos);
					}
				}
			}
			void AddNamespace(HashSet<string> hashSet2)
			{
				if (multipleNamespaceSupport && !IsAutoTuple && !string.IsNullOrWhiteSpace(Type.Namespace) && !(Type.Namespace == package))
				{
					hashSet2.Add("protobuf-net/protogen.proto");
					NewLine(builder, indent + 1).Append("option (.protobuf_net.");
					if (Type.IsEnum)
					{
						builder.Append("enumopt");
					}
					else
					{
						builder.Append("msgopt");
					}
					builder.Append(").namespace = \"" + Type.Namespace + "\";");
				}
			}
			void AppendReservations()
			{
				foreach (ProtoReservedAttribute reservation in _reservations)
				{
					NewLine(builder, indent + 1).Append("reserved ");
					if (reservation.From != 0)
					{
						builder.Append(reservation.From);
						if (reservation.To != reservation.From)
						{
							builder.Append(" to ").Append(reservation.To);
						}
					}
					else
					{
						builder.Append('"').Append(reservation.Name).Append('"');
					}
					builder.Append(';');
					if (!string.IsNullOrWhiteSpace(reservation.Comment))
					{
						builder.Append(" /* ").Append(reservation.Comment).Append(" */");
					}
				}
			}
		}

		private static StringBuilder AddOption(StringBuilder builder, ref bool hasOption)
		{
			if (hasOption)
			{
				return builder.Append(", ");
			}
			hasOption = true;
			return builder.Append(" [");
		}

		private static StringBuilder CloseOption(StringBuilder builder, ref bool hasOption)
		{
			if (hasOption)
			{
				hasOption = false;
				return builder.Append(']');
			}
			return builder;
		}

		private static bool IsImplicitDefault(object value)
		{
			try
			{
				if (value == null)
				{
					return false;
				}
				switch (Helpers.GetTypeCode(value.GetType()))
				{
				case ProtoTypeCode.Boolean:
					return !(bool)value;
				case ProtoTypeCode.Byte:
					return (byte)value == 0;
				case ProtoTypeCode.Char:
					return (char)value == '\0';
				case ProtoTypeCode.DateTime:
					return (DateTime)value == default(DateTime);
				case ProtoTypeCode.Decimal:
					return (decimal)value == 0m;
				case ProtoTypeCode.Double:
					return (double)value == 0.0;
				case ProtoTypeCode.Int16:
					return (short)value == 0;
				case ProtoTypeCode.Int32:
					return (int)value == 0;
				case ProtoTypeCode.Int64:
					return (long)value == 0;
				case ProtoTypeCode.SByte:
					return (sbyte)value == 0;
				case ProtoTypeCode.Single:
					return (float)value == 0f;
				case ProtoTypeCode.String:
					return value != null && ((string)value).Length == 0;
				case ProtoTypeCode.TimeSpan:
					return (TimeSpan)value == TimeSpan.Zero;
				case ProtoTypeCode.UInt16:
					return (ushort)value == 0;
				case ProtoTypeCode.UInt32:
					return (uint)value == 0;
				case ProtoTypeCode.UInt64:
					return (ulong)value == 0;
				case ProtoTypeCode.IntPtr:
					return (IntPtr)value == IntPtr.Zero;
				case ProtoTypeCode.UIntPtr:
					return (UIntPtr)value == UIntPtr.Zero;
				}
			}
			catch
			{
			}
			return false;
		}

		private static bool CanPack(Type type)
		{
			if ((object)type == null)
			{
				return false;
			}
			ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
			if ((uint)(typeCode - 3) <= 11u)
			{
				return true;
			}
			return false;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void ApplyFieldOffset(int offset)
		{
			if (Type.IsEnum)
			{
				throw new InvalidOperationException("Cannot apply field-offset to an enum");
			}
			if (offset == 0)
			{
				return;
			}
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				ThrowIfFrozen();
				List<ValueMember> fields = _fields;
				List<SubType> subTypes = _subTypes;
				if (fields != null)
				{
					foreach (ValueMember item in fields)
					{
						AssertValidFieldNumber(item.FieldNumber + offset);
					}
				}
				if (subTypes != null)
				{
					foreach (SubType item2 in subTypes)
					{
						AssertValidFieldNumber(item2.FieldNumber + offset);
					}
				}
				if (fields != null)
				{
					foreach (ValueMember item3 in fields)
					{
						item3.FieldNumber += offset;
					}
				}
				if (subTypes == null)
				{
					return;
				}
				foreach (SubType item4 in subTypes)
				{
					item4.FieldNumber += offset;
				}
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		internal static void AssertValidFieldNumber(int fieldNumber)
		{
			if (fieldNumber < 1)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
		}

		public MetaType AddReservation(int field, string comment = null)
		{
			return AddReservation(new ProtoReservedAttribute(field, comment));
		}

		public MetaType AddReservation(int from, int to, string comment = null)
		{
			return AddReservation(new ProtoReservedAttribute(from, to, comment));
		}

		public MetaType AddReservation(string field, string comment = null)
		{
			return AddReservation(new ProtoReservedAttribute(field, comment));
		}

		private MetaType AddReservation(ProtoReservedAttribute reservation)
		{
			reservation.Verify();
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				ThrowIfFrozen();
				if (_reservations == null)
				{
					_reservations = new List<ProtoReservedAttribute>();
				}
				_reservations.Add(reservation);
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
			return this;
		}

		internal void Validate()
		{
			ValidateReservations();
		}

		internal void ValidateReservations()
		{
			if (!HasReservations || (!HasFields && !HasSubtypes && !HasEnums))
			{
				return;
			}
			foreach (ProtoReservedAttribute reservation in _reservations)
			{
				if (reservation.From != 0)
				{
					if (_fields != null)
					{
						foreach (ValueMember field in _fields)
						{
							if (field.FieldNumber >= reservation.From && field.FieldNumber <= reservation.To)
							{
								throw new InvalidOperationException($"Field {field.FieldNumber} is reserved and cannot be used for data member '{field.Name}'{CommentSuffix(reservation)}.");
							}
						}
					}
					if (_enums != null)
					{
						foreach (EnumMember @enum in _enums)
						{
							int? num = @enum.TryGetInt32();
							if (num.HasValue && num.Value >= reservation.From && num.Value <= reservation.To)
							{
								throw new InvalidOperationException($"Field {num.Value} is reserved and cannot be used for enum value '{@enum.Name}'{CommentSuffix(reservation)}.");
							}
						}
					}
					if (_subTypes == null)
					{
						continue;
					}
					foreach (SubType subType in _subTypes)
					{
						if (subType.FieldNumber >= reservation.From && subType.FieldNumber <= reservation.To)
						{
							throw new InvalidOperationException($"Field {subType.FieldNumber} is reserved and cannot be used for sub-type '{subType.DerivedType.Type.NormalizeName()}'{CommentSuffix(reservation)}.");
						}
					}
					continue;
				}
				if (_fields != null)
				{
					foreach (ValueMember field2 in _fields)
					{
						if (field2.Name == reservation.Name)
						{
							throw new InvalidOperationException($"Field '{field2.Name}' is reserved and cannot be used for data member {field2.FieldNumber}{CommentSuffix(reservation)}.");
						}
					}
				}
				if (_enums != null)
				{
					foreach (EnumMember enum2 in _enums)
					{
						if (enum2.Name == reservation.Name)
						{
							throw new InvalidOperationException($"Field '{enum2.Name}' is reserved and cannot be used for enum value {enum2.Value}{CommentSuffix(reservation)}.");
						}
					}
				}
				if (_subTypes == null)
				{
					continue;
				}
				foreach (SubType subType2 in _subTypes)
				{
					string text = subType2.DerivedType.Name;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = subType2.DerivedType.Type.Name;
					}
					if (text == reservation.Name)
					{
						throw new InvalidOperationException($"Field '{text}' is reserved and cannot be used for sub-type {subType2.FieldNumber}{CommentSuffix(reservation)}.");
					}
				}
			}
			static string CommentSuffix(ProtoReservedAttribute reservation)
			{
				string comment = reservation.Comment;
				if (string.IsNullOrWhiteSpace(comment))
				{
					return "";
				}
				return " (" + comment.Trim() + ")";
			}
		}
	}
}
