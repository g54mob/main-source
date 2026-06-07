using System;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public class ContextualParameterInfo : ContextualType
	{
		private string? _name;

		public ParameterInfo ParameterInfo { get; }

		public string Name => _name ?? (_name = ParameterInfo.Name);

		internal ContextualParameterInfo(ParameterInfo parameterInfo, ref int nullableFlagsIndex, byte[]? nullableFlags)
			: base(parameterInfo.ParameterType, GetContextualAttributes(parameterInfo), null, ref nullableFlagsIndex, nullableFlags, (!parameterInfo.Member.DeclaringType.IsNested) ? new NullableFlagsSource[2]
			{
				NullableFlagsSource.Create(parameterInfo.Member),
				NullableFlagsSource.Create(parameterInfo.Member.DeclaringType, parameterInfo.Member.DeclaringType.GetTypeInfo().Assembly)
			} : new NullableFlagsSource[3]
			{
				NullableFlagsSource.Create(parameterInfo.Member),
				NullableFlagsSource.Create(parameterInfo.Member.DeclaringType),
				NullableFlagsSource.Create(parameterInfo.Member.DeclaringType.DeclaringType, parameterInfo.Member.DeclaringType.GetTypeInfo().Assembly)
			})
		{
			ParameterInfo = parameterInfo;
		}

		public override string ToString()
		{
			return Name + " (Parameter) - " + base.ToString();
		}

		private static Attribute[] GetContextualAttributes(ParameterInfo parameterInfo)
		{
			try
			{
				object[] customAttributes = parameterInfo.GetCustomAttributes(inherit: true);
				if (customAttributes.Length == 0)
				{
					return ArrayExt.Empty<Attribute>();
				}
				return customAttributes.OfType<Attribute>().ToArray();
			}
			catch
			{
				return parameterInfo.GetCustomAttributes(inherit: false).OfType<Attribute>().ToArray();
			}
		}
	}
}
