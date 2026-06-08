using System;

namespace CsvHelper
{
	public readonly struct ShouldUseConstructorParametersArgs
	{
		public readonly Type ParameterType;

		public ShouldUseConstructorParametersArgs(Type parameterType)
		{
			ParameterType = parameterType;
		}
	}
}
