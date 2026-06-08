using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class NameAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public string[] Names { get; private set; }

		public NameAttribute(string name)
		{
			Names = new string[1] { name };
		}

		public NameAttribute(params string[] names)
		{
			if (names == null || names.Length == 0)
			{
				throw new ArgumentNullException("names");
			}
			Names = names;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.Names.Clear();
			memberMap.Data.Names.AddRange(Names);
			memberMap.Data.IsNameSet = true;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.Names.Clear();
			parameterMap.Data.Names.AddRange(Names);
			parameterMap.Data.IsNameSet = true;
		}
	}
}
