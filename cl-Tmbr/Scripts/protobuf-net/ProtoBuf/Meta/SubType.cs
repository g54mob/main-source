using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Internal.Serializers;

namespace ProtoBuf.Meta
{
	public sealed class SubType
	{
		internal sealed class Comparer : IComparer, IComparer<SubType>
		{
			public static readonly Comparer Default = new Comparer();

			public int Compare(object x, object y)
			{
				return Compare(x as SubType, y as SubType);
			}

			public int Compare(SubType x, SubType y)
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

		private readonly MetaType derivedType;

		private readonly DataFormat dataFormat;

		private IRuntimeProtoSerializerNode serializer;

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

		public MetaType DerivedType => derivedType;

		private void ThrowIfFrozen()
		{
			if (serializer != null)
			{
				throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
			}
		}

		public SubType(int fieldNumber, MetaType derivedType, DataFormat format)
		{
			if (fieldNumber <= 0)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			_fieldNumber = fieldNumber;
			this.derivedType = derivedType ?? throw new ArgumentNullException("derivedType");
			dataFormat = format;
		}

		internal IRuntimeProtoSerializerNode GetSerializer(Type parentType)
		{
			return serializer ?? (serializer = BuildSerializer(parentType));
		}

		private IRuntimeProtoSerializerNode BuildSerializer(Type parentType)
		{
			WireType wireType = WireType.String;
			if (dataFormat == DataFormat.Group)
			{
				wireType = WireType.StartGroup;
			}
			IRuntimeProtoSerializerNode tail = SubItemSerializer.Create(derivedType.Type, derivedType, parentType);
			return new TagDecorator(_fieldNumber, wireType, strict: false, tail);
		}
	}
}
