using System;

namespace ProtoBuf.Meta
{
	internal class NullWrappedValueMemberData
	{
		private readonly string _originalSchemaTypeName;

		private readonly string _alternativeTypeName;

		private readonly bool _hasSchemaTypeNameCollision;

		private readonly ValueMember _valueMember;

		public string SchemaTypeName => _originalSchemaTypeName;

		public string WrappedSchemaTypeName
		{
			get
			{
				string text = ((!string.IsNullOrEmpty(_alternativeTypeName)) ? _alternativeTypeName : _originalSchemaTypeName);
				if (_valueMember.SupportNull)
				{
					return "WrappedAsSupportNull" + text;
				}
				if (_valueMember.NullWrappedValueGroup)
				{
					return "WrappedAsGroup" + text;
				}
				return "Wrapped" + text;
			}
		}

		public bool HasSchemaTypeNameCollision
		{
			get
			{
				if (_hasSchemaTypeNameCollision)
				{
					return !HasKnownTypeSchema();
				}
				return false;
			}
		}

		public Type ItemType => _valueMember.ItemType;

		public bool HasGroupModifier => _valueMember.RequiresGroupModifier;

		public NullWrappedValueMemberData(ValueMember valueMember, string originalSchemaTypeName, string alternativeTypeName = null, bool hasSchemaTypeNameCollision = false)
		{
			_originalSchemaTypeName = originalSchemaTypeName;
			_alternativeTypeName = alternativeTypeName;
			_hasSchemaTypeNameCollision = hasSchemaTypeNameCollision;
			_valueMember = valueMember;
		}

		private bool HasKnownTypeSchema()
		{
			switch (_originalSchemaTypeName)
			{
			case "int32":
			case "int64":
			case "double":
			case "string":
			case "uint32":
			case "uint64":
			case "bool":
				return true;
			default:
				return false;
			}
		}
	}
}
