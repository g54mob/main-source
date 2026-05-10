using System;

namespace CsvHelper.Configuration
{
	public interface IHasConvertUsing<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasMap<TClass> ConvertUsing(Func<IReaderRow, TMember> convertExpression);

		IHasMap<TClass> ConvertUsing(Func<TClass, string> convertExpression);
	}
}
