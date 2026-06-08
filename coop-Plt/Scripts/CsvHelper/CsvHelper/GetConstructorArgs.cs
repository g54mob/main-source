using System;

namespace CsvHelper
{
	public readonly struct GetConstructorArgs
	{
		public readonly Type ClassType;

		public GetConstructorArgs(Type classType)
		{
			ClassType = classType;
		}
	}
}
