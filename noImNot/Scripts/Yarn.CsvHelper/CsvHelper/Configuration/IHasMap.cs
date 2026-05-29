using System;
using System.Linq.Expressions;

namespace CsvHelper.Configuration
{
	public interface IHasMap<TClass> : IBuildableClass<TClass>
	{
		IHasMapOptions<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true);
	}
}
