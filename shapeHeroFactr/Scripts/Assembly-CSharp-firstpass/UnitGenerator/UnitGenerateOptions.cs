using System;

namespace UnitGenerator
{
	[Flags]
	internal enum UnitGenerateOptions
	{
		None = 0,
		ImplicitOperator = 1,
		ParseMethod = 2,
		MinMaxMethod = 4,
		ArithmeticOperator = 8,
		ValueArithmeticOperator = 0x10,
		Comparable = 0x20,
		Validate = 0x40,
		JsonConverter = 0x80,
		MessagePackFormatter = 0x100,
		DapperTypeHandler = 0x200,
		EntityFrameworkValueConverter = 0x400,
		WithoutComparisonOperator = 0x800,
		JsonConverterDictionaryKeySupport = 0x1000
	}
}
