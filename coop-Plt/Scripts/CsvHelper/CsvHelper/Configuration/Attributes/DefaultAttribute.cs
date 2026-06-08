using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class DefaultAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public object Default { get; private set; }

		public DefaultAttribute(object defaultValue)
		{
			Default = defaultValue;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.Default = Default;
			memberMap.Data.IsDefaultSet = true;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.Default = Default;
			parameterMap.Data.IsDefaultSet = true;
		}
	}
}
