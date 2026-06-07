using System;
using System.Diagnostics;
using System.Linq;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class ResourcePathAttribute : RequireTypeAttribute
	{
		public readonly EStr EStr;

		public override SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public override string GroupBy => "__LABEL_FIELD__";

		public Type CompType => RequiredTypes[0];

		public ResourcePathAttribute(EStr eStr, bool freeSign, bool customPicker, Type compType, params Type[] requiredTypes)
			: base(EPick.Assets, freeSign, customPicker, requiredTypes.Prepend(compType).ToArray())
		{
			EStr = eStr;
		}

		public ResourcePathAttribute(bool freeSign, bool customPicker, Type compType, params Type[] requiredTypes)
			: this(EStr.Resource, freeSign, customPicker, compType, requiredTypes)
		{
		}

		public ResourcePathAttribute(bool freeSign, Type compType, params Type[] requiredTypes)
			: this(EStr.Resource, freeSign, customPicker: true, compType, requiredTypes)
		{
		}

		public ResourcePathAttribute(EStr eStr, bool freeSign, Type compType, params Type[] requiredTypes)
			: this(eStr, freeSign, customPicker: true, compType, requiredTypes)
		{
		}

		public ResourcePathAttribute(EStr eStr, Type compType, params Type[] requiredTypes)
			: this(eStr, freeSign: false, customPicker: true, compType, requiredTypes)
		{
		}

		public ResourcePathAttribute(Type compType, params Type[] requiredTypes)
			: this(EStr.Resource, freeSign: false, customPicker: true, compType, requiredTypes)
		{
		}
	}
}
