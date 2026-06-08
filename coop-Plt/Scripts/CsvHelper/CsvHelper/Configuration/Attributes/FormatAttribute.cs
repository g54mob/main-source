using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class FormatAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public string[] Formats { get; private set; }

		public FormatAttribute(string format)
		{
			Formats = new string[1] { format };
		}

		public FormatAttribute(params string[] formats)
		{
			Formats = formats;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.TypeConverterOptions.Formats = Formats;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.TypeConverterOptions.Formats = Formats;
		}
	}
}
