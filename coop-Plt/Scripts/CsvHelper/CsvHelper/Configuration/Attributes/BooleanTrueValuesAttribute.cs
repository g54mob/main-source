using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class BooleanTrueValuesAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public string[] TrueValues { get; private set; }

		public BooleanTrueValuesAttribute(string trueValue)
		{
			TrueValues = new string[1] { trueValue };
		}

		public BooleanTrueValuesAttribute(params string[] trueValues)
		{
			TrueValues = trueValues;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.BooleanTrueValues.Clear();
			memberMap.Data.TypeConverterOptions.BooleanTrueValues.AddRange(TrueValues);
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.BooleanTrueValues.Clear();
			parameterMap.Data.TypeConverterOptions.BooleanTrueValues.AddRange(TrueValues);
		}
	}
}
