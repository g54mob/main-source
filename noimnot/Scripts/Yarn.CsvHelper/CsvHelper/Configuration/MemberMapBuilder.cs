using System;
using System.Linq.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	internal class MemberMapBuilder<TClass, TMember> : IHasMap<TClass>, IBuildableClass<TClass>, IHasMapOptions<TClass, TMember>, IHasTypeConverter<TClass, TMember>, IHasIndex<TClass, TMember>, IHasName<TClass, TMember>, IHasOptional<TClass, TMember>, IHasConvertUsing<TClass, TMember>, IHasDefault<TClass, TMember>, IHasConstant<TClass, TMember>, IHasValidate<TClass, TMember>, IHasTypeConverterOptions<TClass, TMember>, IHasIndexOptions<TClass, TMember>, IHasNameOptions<TClass, TMember>, IHasNameIndex<TClass, TMember>, IHasNameIndexOptions<TClass, TMember>, IHasOptionalOptions<TClass, TMember>, IHasDefaultOptions<TClass, TMember>
	{
		private readonly ClassMap<TClass> classMap;

		private readonly MemberMap<TClass, TMember> memberMap;

		public MemberMapBuilder(ClassMap<TClass> classMap, MemberMap<TClass, TMember> memberMap)
		{
		}

		public IHasMapOptions<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true)
		{
			return null;
		}

		public IHasMap<TClass> ConvertUsing(Func<IReaderRow, TMember> convertExpression)
		{
			return null;
		}

		public IHasMap<TClass> ConvertUsing(Func<TClass, string> convertExpression)
		{
			return null;
		}

		public IHasDefaultOptions<TClass, TMember> Default(TMember defaultValue)
		{
			return null;
		}

		public IHasDefaultOptions<TClass, TMember> Default(string defaultValue)
		{
			return null;
		}

		public IHasIndexOptions<TClass, TMember> Index(int index, int indexEnd = -1)
		{
			return null;
		}

		public IHasNameOptions<TClass, TMember> Name(params string[] names)
		{
			return null;
		}

		public IHasNameIndexOptions<TClass, TMember> NameIndex(int index)
		{
			return null;
		}

		public IHasOptionalOptions<TClass, TMember> Optional()
		{
			return null;
		}

		public IHasTypeConverterOptions<TClass, TMember> TypeConverter(ITypeConverter typeConverter)
		{
			return null;
		}

		public IHasTypeConverterOptions<TClass, TMember> TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			return null;
		}

		public IHasMap<TClass> Constant(TMember value)
		{
			return null;
		}

		public IHasMap<TClass> Validate(Func<string, bool> validateExpression)
		{
			return null;
		}

		public ClassMap<TClass> Build()
		{
			return null;
		}
	}
}
