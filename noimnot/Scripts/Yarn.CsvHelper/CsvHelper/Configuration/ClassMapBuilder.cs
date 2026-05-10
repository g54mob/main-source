using System;
using System.Linq.Expressions;

namespace CsvHelper.Configuration
{
	internal class ClassMapBuilder<TClass> : IHasMap<TClass>, IBuildableClass<TClass>
	{
		private class BuilderClassMap<T> : ClassMap<T>
		{
		}

		private readonly ClassMap<TClass> map;

		public IHasMapOptions<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true)
		{
			return null;
		}

		public ClassMap<TClass> Build()
		{
			return null;
		}
	}
}
