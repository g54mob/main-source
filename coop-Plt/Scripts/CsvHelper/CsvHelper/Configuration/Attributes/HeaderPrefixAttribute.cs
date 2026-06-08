using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class HeaderPrefixAttribute : Attribute, IMemberReferenceMapper, IParameterReferenceMapper
	{
		public string Prefix { get; private set; }

		public HeaderPrefixAttribute()
		{
		}

		public HeaderPrefixAttribute(string prefix)
		{
			Prefix = prefix;
		}

		public void ApplyTo(MemberReferenceMap referenceMap)
		{
			referenceMap.Data.Prefix = Prefix ?? (referenceMap.Data.Member.Name + ".");
		}

		public void ApplyTo(ParameterReferenceMap referenceMap)
		{
			referenceMap.Data.Prefix = Prefix ?? (referenceMap.Data.Parameter.Name + ".");
		}
	}
}
