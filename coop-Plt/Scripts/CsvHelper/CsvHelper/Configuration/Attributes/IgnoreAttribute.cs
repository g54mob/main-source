using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class IgnoreAttribute : Attribute, IMemberMapper, IMemberReferenceMapper, IParameterMapper
	{
		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.Ignore = true;
		}

		public void ApplyTo(MemberReferenceMap referenceMap)
		{
			foreach (MemberMap memberMap in referenceMap.Data.Mapping.MemberMaps)
			{
				ApplyTo(memberMap);
			}
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.Ignore = true;
		}
	}
}
