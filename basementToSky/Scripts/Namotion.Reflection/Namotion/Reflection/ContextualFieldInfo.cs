using System;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public class ContextualFieldInfo : ContextualAccessorInfo
	{
		private string? _name;

		public FieldInfo FieldInfo { get; }

		public override MemberInfo MemberInfo => FieldInfo;

		public override ContextualType AccessorType => FieldType;

		public ContextualType FieldType { get; private set; }

		public override string Name => _name ?? (_name = FieldInfo.Name);

		internal ContextualFieldInfo(FieldInfo fieldInfo, ref int nullableFlagsIndex, byte[]? nullableFlags)
		{
			FieldInfo = fieldInfo;
			NullableFlagsSource[] customAttributeProviders = ((!fieldInfo.DeclaringType.IsNested) ? new NullableFlagsSource[1] { NullableFlagsSource.Create(fieldInfo.DeclaringType, fieldInfo.DeclaringType.GetTypeInfo().Assembly) } : new NullableFlagsSource[2]
			{
				NullableFlagsSource.Create(fieldInfo.DeclaringType),
				NullableFlagsSource.Create(fieldInfo.DeclaringType.DeclaringType, fieldInfo.DeclaringType.GetTypeInfo().Assembly)
			});
			FieldType = new ContextualType(fieldInfo.FieldType, fieldInfo.GetCustomAttributes(inherit: true).OfType<Attribute>().ToArray(), null, ref nullableFlagsIndex, nullableFlags, customAttributeProviders);
		}

		public override object? GetValue(object? obj)
		{
			return FieldInfo.GetValue(obj);
		}

		public override void SetValue(object? obj, object? value)
		{
			FieldInfo.SetValue(obj, value);
		}
	}
}
