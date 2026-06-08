using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class NullValuesAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public string[] NullValues { get; private set; }

		public NullValuesAttribute(string nullValue)
		{
			NullValues = new string[1] { nullValue };
		}

		public NullValuesAttribute(params string[] nullValues)
		{
			NullValues = nullValues;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.NullValues.Clear();
			memberMap.Data.TypeConverterOptions.NullValues.AddRange(NullValues);
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.NullValues.Clear();
			parameterMap.Data.TypeConverterOptions.NullValues.AddRange(NullValues);
		}
	}
}
