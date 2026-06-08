using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class BooleanFalseValuesAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public string[] FalseValues { get; private set; }

		public BooleanFalseValuesAttribute(string falseValue)
		{
			FalseValues = new string[1] { falseValue };
		}

		public BooleanFalseValuesAttribute(params string[] falseValues)
		{
			FalseValues = falseValues;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.BooleanFalseValues.Clear();
			memberMap.Data.TypeConverterOptions.BooleanFalseValues.AddRange(FalseValues);
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.BooleanFalseValues.Clear();
			parameterMap.Data.TypeConverterOptions.BooleanFalseValues.AddRange(FalseValues);
		}
	}
}
