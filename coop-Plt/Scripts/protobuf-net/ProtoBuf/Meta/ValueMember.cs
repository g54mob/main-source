using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using ProtoBuf.Internal;
using ProtoBuf.Internal.Serializers;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	public class ValueMember
	{
		internal sealed class Comparer : IComparer, IComparer<ValueMember>
		{
			public static readonly Comparer Default = new Comparer();

			public int Compare(object x, object y)
			{
				return Compare(x as ValueMember, y as ValueMember);
			}

			public int Compare(ValueMember x, ValueMember y)
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
				return x.FieldNumber.CompareTo(y.FieldNumber);
			}
		}

		private int _fieldNumber;

		private MemberInfo backingMember;

		private object _defaultValue;

		private CompatibilityLevel _compatibilityLevel;

		private readonly RuntimeTypeModel model;

		private IRuntimeProtoSerializerNode serializer;

		private DataFormat dataFormat;

		private DataFormat mapKeyFormat;

		private DataFormat mapValueFormat;

		private MethodInfo getSpecified;

		private MethodInfo setSpecified;

		private string name;

		private const byte OPTIONS_IsStrict = 1;

		private const byte OPTIONS_IsPacked = 2;

		private const byte OPTIONS_IsRequired = 4;

		private const byte OPTIONS_OverwriteList = 8;

		private const byte OPTIONS_IsMap = 64;

		private byte flags;

		internal const string SupportNullNotImplemented = "Nullable list elements are not currently implemented";

		public int FieldNumber
		{
			get
			{
				return _fieldNumber;
			}
			internal set
			{
				if (_fieldNumber != value)
				{
					MetaType.AssertValidFieldNumber(value);
					ThrowIfFrozen();
					_fieldNumber = value;
				}
			}
		}

		public MemberInfo Member { get; }

		public MemberInfo BackingMember
		{
			get
			{
				return backingMember;
			}
			set
			{
				if (backingMember != value)
				{
					ThrowIfFrozen();
					backingMember = value;
				}
			}
		}

		public Type ItemType { get; }

		public Type MemberType { get; }

		public Type DefaultType { get; }

		public Type ParentType { get; }

		public object DefaultValue
		{
			get
			{
				return _defaultValue;
			}
			set
			{
				if (_defaultValue != value)
				{
					ThrowIfFrozen();
					_defaultValue = value;
				}
			}
		}

		public CompatibilityLevel CompatibilityLevel
		{
			get
			{
				return _compatibilityLevel;
			}
			set
			{
				if (_compatibilityLevel != value)
				{
					ThrowIfFrozen();
					CompatibilityLevelAttribute.AssertValid(value);
					_compatibilityLevel = value;
				}
			}
		}

		internal IRuntimeProtoSerializerNode Serializer => serializer ?? (serializer = BuildSerializer());

		public DataFormat DataFormat
		{
			get
			{
				return dataFormat;
			}
			set
			{
				if (value != dataFormat)
				{
					ThrowIfFrozen();
					dataFormat = value;
				}
			}
		}

		public bool IsStrict
		{
			get
			{
				return HasFlag(1);
			}
			set
			{
				SetFlag(1, value, throwIfFrozen: true);
			}
		}

		public bool IsPacked
		{
			get
			{
				return HasFlag(2);
			}
			set
			{
				SetFlag(2, value, throwIfFrozen: true);
			}
		}

		public bool OverwriteList
		{
			get
			{
				return HasFlag(8);
			}
			set
			{
				SetFlag(8, value, throwIfFrozen: true);
			}
		}

		public bool IsRequired
		{
			get
			{
				return HasFlag(4);
			}
			set
			{
				SetFlag(4, value, throwIfFrozen: true);
			}
		}

		public bool AsReference
		{
			get
			{
				return false;
			}
			[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
			set
			{
				if (value != AsReference)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		public bool DynamicType
		{
			get
			{
				return false;
			}
			[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
			set
			{
				if (value != DynamicType)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		public bool IsMap
		{
			get
			{
				return HasFlag(64);
			}
			set
			{
				SetFlag(64, value, throwIfFrozen: true);
			}
		}

		public DataFormat MapKeyFormat
		{
			get
			{
				return mapKeyFormat;
			}
			set
			{
				if (mapKeyFormat != value)
				{
					ThrowIfFrozen();
					mapKeyFormat = value;
				}
			}
		}

		public DataFormat MapValueFormat
		{
			get
			{
				return mapValueFormat;
			}
			set
			{
				if (mapValueFormat != value)
				{
					ThrowIfFrozen();
					mapValueFormat = value;
				}
			}
		}

		public string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(name))
				{
					return name;
				}
				return Member.Name;
			}
			set
			{
				SetName(value);
			}
		}

		public bool SupportNull
		{
			get
			{
				return false;
			}
			[Obsolete("Nullable list elements are not currently implemented", true)]
			set
			{
				if (value != SupportNull)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		internal static CompatibilityLevel GetEffectiveCompatibilityLevel(CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			if (compatibilityLevel <= CompatibilityLevel.Level200)
			{
				if (dataFormat == DataFormat.WellKnown)
				{
					return CompatibilityLevel.Level240;
				}
				return CompatibilityLevel.Level200;
			}
			return compatibilityLevel;
		}

		public ValueMember(RuntimeTypeModel model, Type parentType, int fieldNumber, MemberInfo member, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat, object defaultValue)
			: this(model, fieldNumber, memberType, itemType, defaultType, dataFormat)
		{
			if ((object)parentType == null)
			{
				throw new ArgumentNullException("parentType");
			}
			if (fieldNumber < 1 && !parentType.IsEnum)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			Member = member ?? throw new ArgumentNullException("member");
			ParentType = parentType;
			if (fieldNumber < 1 && !parentType.IsEnum)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			if (defaultValue != null && defaultValue.GetType() != memberType)
			{
				defaultValue = ParseDefaultValue(memberType, defaultValue);
			}
			_defaultValue = defaultValue;
		}

		internal ValueMember(RuntimeTypeModel model, int fieldNumber, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat)
		{
			FieldNumber = fieldNumber;
			MemberType = memberType ?? throw new ArgumentNullException("memberType");
			ItemType = itemType;
			if ((object)defaultType == null && (object)itemType != null)
			{
				defaultType = memberType;
			}
			DefaultType = defaultType;
			this.model = model ?? throw new ArgumentNullException("model");
			this.dataFormat = dataFormat;
		}

		internal object GetRawEnumValue()
		{
			return ((FieldInfo)Member).GetRawConstantValue();
		}

		private static object ParseDefaultValue(Type type, object value)
		{
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if ((object)underlyingType != null)
			{
				type = underlyingType;
			}
			if (value is string text)
			{
				if (type.IsEnum)
				{
					return Enum.Parse(type, text, ignoreCase: true);
				}
				switch (Helpers.GetTypeCode(type))
				{
				case ProtoTypeCode.Boolean:
					return bool.Parse(text);
				case ProtoTypeCode.Byte:
					return byte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Char:
					if (text.Length == 1)
					{
						return text[0];
					}
					throw new FormatException("Single character expected: \"" + text + "\"");
				case ProtoTypeCode.DateTime:
					return DateTime.Parse(text, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Decimal:
					return decimal.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Double:
					return double.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int16:
					return short.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int32:
					return int.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int64:
					return long.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.SByte:
					return sbyte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Single:
					return float.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.String:
					return text;
				case ProtoTypeCode.UInt16:
					return ushort.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.UInt32:
					return uint.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.UInt64:
					return ulong.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.TimeSpan:
					return TimeSpan.Parse(text);
				case ProtoTypeCode.Uri:
					return text;
				case ProtoTypeCode.Guid:
					return new Guid(text);
				}
			}
			if (type.IsEnum)
			{
				return Enum.ToObject(type, value);
			}
			return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
		}

		public void SetSpecified(MethodInfo getSpecified, MethodInfo setSpecified)
		{
			if (this.getSpecified != getSpecified || this.setSpecified != setSpecified)
			{
				if ((object)getSpecified != null && (getSpecified.ReturnType != typeof(bool) || getSpecified.IsStatic || getSpecified.GetParameters().Length != 0))
				{
					throw new ArgumentException("Invalid pattern for checking member-specified", "getSpecified");
				}
				ParameterInfo[] parameters;
				if ((object)setSpecified != null && (setSpecified.ReturnType != typeof(void) || setSpecified.IsStatic || (parameters = setSpecified.GetParameters()).Length != 1 || parameters[0].ParameterType != typeof(bool)))
				{
					throw new ArgumentException("Invalid pattern for setting member-specified", "setSpecified");
				}
				ThrowIfFrozen();
				this.getSpecified = getSpecified;
				this.setSpecified = setSpecified;
			}
		}

		private void ThrowIfFrozen()
		{
			if (serializer != null)
			{
				throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
			}
		}

		internal static IRuntimeProtoSerializerNode CreateMap(RepeatedSerializerStub repeated, RuntimeTypeModel model, DataFormat dataFormat, CompatibilityLevel compatibilityLevel, DataFormat keyFormat, DataFormat valueFormat, bool asReference, bool dynamicType, bool isMap, bool overwriteList, int fieldNumber)
		{
			CompatibilityLevel effectiveCompatibilityLevel = GetEffectiveCompatibilityLevel(compatibilityLevel, keyFormat);
			CompatibilityLevel effectiveCompatibilityLevel2 = GetEffectiveCompatibilityLevel(compatibilityLevel, valueFormat);
			repeated.ResolveMapTypes(out var keyType, out var valueType);
			TryGetCoreSerializer(model, keyFormat, effectiveCompatibilityLevel, FlattenRepeated(model, keyType), out var defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: true);
			TryGetCoreSerializer(model, valueFormat, effectiveCompatibilityLevel2, FlattenRepeated(model, valueType), out var defaultWireType2, asReference, dynamicType, overwriteList: false, allowComplexTypes: true);
			WireType wireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
			SerializerFeatures serializerFeatures = wireType.AsFeatures();
			if (!isMap)
			{
				serializerFeatures |= SerializerFeatures.OptionFailOnDuplicateKey;
			}
			if (overwriteList)
			{
				serializerFeatures |= SerializerFeatures.OptionClearCollection;
			}
			return MapDecorator.Create(repeated, keyType, valueType, fieldNumber, serializerFeatures, defaultWireType.AsFeatures(), effectiveCompatibilityLevel, keyFormat, defaultWireType2.AsFeatures(), effectiveCompatibilityLevel2, valueFormat);
			static Type FlattenRepeated(RuntimeTypeModel runtimeTypeModel, Type type)
			{
				if ((object)type == null)
				{
					return type;
				}
				RepeatedSerializerStub repeatedSerializerStub = ((runtimeTypeModel == null) ? RepeatedSerializers.TryGetRepeatedProvider(type) : runtimeTypeModel.TryGetRepeatedProvider(type));
				if (repeatedSerializerStub != null)
				{
					return repeatedSerializerStub.ItemType;
				}
				return type;
			}
		}

		private IRuntimeProtoSerializerNode BuildSerializer()
		{
			int opaqueToken = 0;
			try
			{
				model.TakeLock(ref opaqueToken);
				MemberInfo memberInfo = backingMember ?? Member;
				RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(MemberType);
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode;
				if (repeatedSerializerStub != null)
				{
					if (repeatedSerializerStub.IsMap)
					{
						runtimeProtoSerializerNode = CreateMap(repeatedSerializerStub, model, DataFormat, CompatibilityLevel, MapKeyFormat, MapValueFormat, AsReference, DynamicType, IsMap, OverwriteList, FieldNumber);
					}
					else
					{
						if (SupportNull)
						{
							ThrowHelper.ThrowNotSupportedException("null items in lists");
						}
						TryGetCoreSerializer(model, DataFormat, CompatibilityLevel, repeatedSerializerStub.ItemType, out var defaultWireType, AsReference, DynamicType, OverwriteList, allowComplexTypes: true);
						SerializerFeatures serializerFeatures = defaultWireType.AsFeatures();
						if (!IsPacked)
						{
							serializerFeatures |= SerializerFeatures.OptionPackedDisabled;
						}
						if (OverwriteList)
						{
							serializerFeatures |= SerializerFeatures.OptionClearCollection;
						}
						runtimeProtoSerializerNode = RepeatedDecorator.Create(repeatedSerializerStub, FieldNumber, serializerFeatures, CompatibilityLevel, DataFormat);
					}
				}
				else
				{
					runtimeProtoSerializerNode = TryGetCoreSerializer(model, DataFormat, CompatibilityLevel, MemberType, out var defaultWireType2, AsReference, DynamicType, OverwriteList, allowComplexTypes: true);
					if (runtimeProtoSerializerNode == null)
					{
						throw new InvalidOperationException("No serializer defined for type: " + MemberType.ToString());
					}
					runtimeProtoSerializerNode = new TagDecorator(FieldNumber, defaultWireType2, IsStrict, runtimeProtoSerializerNode);
					if (_defaultValue != null && !IsRequired && (object)getSpecified == null)
					{
						runtimeProtoSerializerNode = new DefaultValueDecorator(_defaultValue, runtimeProtoSerializerNode);
					}
					if (MemberType == typeof(Uri))
					{
						runtimeProtoSerializerNode = new UriDecorator(runtimeProtoSerializerNode);
					}
				}
				if ((object)memberInfo != null)
				{
					if (memberInfo is PropertyInfo property)
					{
						runtimeProtoSerializerNode = new PropertyDecorator(ParentType, property, runtimeProtoSerializerNode);
					}
					else
					{
						if (!(memberInfo is FieldInfo field))
						{
							throw new InvalidOperationException();
						}
						runtimeProtoSerializerNode = new FieldDecorator(ParentType, field, runtimeProtoSerializerNode);
					}
					if ((object)getSpecified != null || (object)setSpecified != null)
					{
						runtimeProtoSerializerNode = new MemberSpecifiedDecorator(getSpecified, setSpecified, runtimeProtoSerializerNode);
					}
				}
				return runtimeProtoSerializerNode;
			}
			finally
			{
				model.ReleaseLock(opaqueToken);
			}
		}

		private static WireType GetIntWireType(DataFormat format, int width)
		{
			switch (format)
			{
			case DataFormat.ZigZag:
				return WireType.SignedVariant;
			case DataFormat.FixedSize:
				if (width != 32)
				{
					return WireType.Fixed64;
				}
				return WireType.Fixed32;
			case DataFormat.TwosComplement:
			case DataFormat.WellKnown:
				return WireType.Variant;
			case DataFormat.Default:
				return WireType.Variant;
			default:
				throw new InvalidOperationException();
			}
		}

		private static WireType GetDateTimeWireType(DataFormat format)
		{
			switch (format)
			{
			case DataFormat.Group:
				return WireType.StartGroup;
			case DataFormat.FixedSize:
				return WireType.Fixed64;
			case DataFormat.Default:
			case DataFormat.WellKnown:
				return WireType.String;
			default:
				throw new InvalidOperationException();
			}
		}

		internal static IRuntimeProtoSerializerNode TryGetCoreSerializer(RuntimeTypeModel model, DataFormat dataFormat, CompatibilityLevel compatibilityLevel, Type type, out WireType defaultWireType, bool asReference, bool dynamicType, bool overwriteList, bool allowComplexTypes)
		{
			compatibilityLevel = GetEffectiveCompatibilityLevel(compatibilityLevel, dataFormat);
			type = DynamicStub.GetEffectiveType(type);
			if (type.IsEnum)
			{
				if (allowComplexTypes && model != null)
				{
					defaultWireType = WireType.Variant;
					return new EnumMemberSerializer(type);
				}
				defaultWireType = WireType.None;
				return null;
			}
			switch (Helpers.GetTypeCode(type))
			{
			case ProtoTypeCode.Int32:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return Int32Serializer.Instance;
			case ProtoTypeCode.UInt32:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return UInt32Serializer.Instance;
			case ProtoTypeCode.Int64:
				defaultWireType = GetIntWireType(dataFormat, 64);
				return Int64Serializer.Instance;
			case ProtoTypeCode.UInt64:
				defaultWireType = GetIntWireType(dataFormat, 64);
				return UInt64Serializer.Instance;
			case ProtoTypeCode.String:
				defaultWireType = WireType.String;
				if (asReference)
				{
					ThrowHelper.ThrowNotSupportedException("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited");
					return null;
				}
				return StringSerializer.Instance;
			case ProtoTypeCode.Single:
				defaultWireType = WireType.Fixed32;
				return SingleSerializer.Instance;
			case ProtoTypeCode.Double:
				defaultWireType = WireType.Fixed64;
				return DoubleSerializer.Instance;
			case ProtoTypeCode.Boolean:
				defaultWireType = WireType.Variant;
				return BooleanSerializer.Instance;
			case ProtoTypeCode.DateTime:
				defaultWireType = GetDateTimeWireType(dataFormat);
				return DateTimeSerializer.Create(compatibilityLevel, model);
			case ProtoTypeCode.Decimal:
				defaultWireType = WireType.String;
				return DecimalSerializer.Create(compatibilityLevel);
			case ProtoTypeCode.Byte:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return ByteSerializer.Instance;
			case ProtoTypeCode.SByte:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return SByteSerializer.Instance;
			case ProtoTypeCode.Char:
				defaultWireType = WireType.Variant;
				return CharSerializer.Instance;
			case ProtoTypeCode.Int16:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return Int16Serializer.Instance;
			case ProtoTypeCode.UInt16:
				defaultWireType = GetIntWireType(dataFormat, 32);
				return UInt16Serializer.Instance;
			case ProtoTypeCode.TimeSpan:
				defaultWireType = GetDateTimeWireType(dataFormat);
				return TimeSpanSerializer.Create(compatibilityLevel);
			case ProtoTypeCode.Guid:
				defaultWireType = ((dataFormat == DataFormat.Group && compatibilityLevel < CompatibilityLevel.Level300) ? WireType.StartGroup : WireType.String);
				return GuidSerializer.Create(compatibilityLevel, dataFormat);
			case ProtoTypeCode.Uri:
				defaultWireType = WireType.String;
				return StringSerializer.Instance;
			case ProtoTypeCode.ByteArray:
				defaultWireType = WireType.String;
				return new BlobSerializer(overwriteList);
			case ProtoTypeCode.Type:
				defaultWireType = WireType.String;
				return SystemTypeSerializer.Instance;
			default:
			{
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = (model.AllowParseableTypes ? ParseableSerializer.TryCreate(type) : null);
				if (runtimeProtoSerializerNode != null)
				{
					defaultWireType = WireType.String;
					return runtimeProtoSerializerNode;
				}
				if (allowComplexTypes && model != null)
				{
					MetaType metaType = null;
					if (model.IsDefined(type, compatibilityLevel))
					{
						metaType = model.FindWithAmbientCompatibility(type, compatibilityLevel);
						if (dataFormat == DataFormat.Default && metaType.IsGroup)
						{
							dataFormat = DataFormat.Group;
						}
					}
					if (asReference || dynamicType)
					{
						ThrowHelper.ThrowNotSupportedException("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited");
						defaultWireType = WireType.Variant;
						return null;
					}
					if (metaType != null)
					{
						IProtoTypeSerializer protoTypeSerializer;
						if (metaType.HasSurrogate && (protoTypeSerializer = metaType.Serializer).Features.GetCategory() == SerializerFeatures.CategoryScalar)
						{
							dataFormat = metaType.surrogateDataFormat;
							if (TryGetCoreSerializer(model, dataFormat, metaType.CompatibilityLevel, metaType.surrogateType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) == null)
							{
								defaultWireType = protoTypeSerializer.Features.GetWireType();
							}
							return protoTypeSerializer;
						}
						return SubItemSerializer.Create(type, metaType, ref dataFormat, out defaultWireType);
					}
				}
				defaultWireType = WireType.None;
				return null;
			}
			}
		}

		internal void SetName(string name)
		{
			if (name != this.name)
			{
				ThrowIfFrozen();
				this.name = name;
			}
		}

		private bool HasFlag(byte flag)
		{
			return (flags & flag) == flag;
		}

		private void SetFlag(byte flag, bool value, bool throwIfFrozen)
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
				flags = (byte)(flags & ~flag);
			}
		}

		internal string GetSchemaTypeName(HashSet<Type> callstack, bool applyNetObjectProxy, HashSet<string> imports, out string altName)
		{
			Type effectiveType = ItemType ?? MemberType;
			return model.GetSchemaTypeName(callstack, effectiveType, DataFormat, CompatibilityLevel, applyNetObjectProxy && AsReference, applyNetObjectProxy && DynamicType, imports, out altName);
		}
	}
}
