using System;

namespace CsvHelper.Configuration
{
	public interface IHasValidate<TClass, TMember> : IBuildableClass<TClass>
	{
		IHasMap<TClass> Validate(Func<string, bool> validateExpression);
	}
}
