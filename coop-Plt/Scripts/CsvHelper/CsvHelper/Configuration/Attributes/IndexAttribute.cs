using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class IndexAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public int Index { get; private set; }

		public int IndexEnd { get; private set; }

		public IndexAttribute(int index, int indexEnd = -1)
		{
			Index = index;
			IndexEnd = indexEnd;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.Index = Index;
			memberMap.Data.IndexEnd = IndexEnd;
			memberMap.Data.IsIndexSet = true;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.Index = Index;
			parameterMap.Data.IsIndexSet = true;
		}
	}
}
