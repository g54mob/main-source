using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class NameIndexAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public int NameIndex { get; private set; }

		public NameIndexAttribute(int nameIndex)
		{
			NameIndex = nameIndex;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.NameIndex = NameIndex;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.NameIndex = NameIndex;
		}
	}
}
