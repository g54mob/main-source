using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class OptionalAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.IsOptional = true;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.IsOptional = true;
		}
	}
}
