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
			this.classMap = classMap;
			this.memberMap = memberMap;
		}

		public IHasMapOptions<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true)
		{
			return new MemberMapBuilder<TClass, TMember>(classMap, classMap.Map(expression, useExistingMap));
		}

		public IHasMap<TClass> ConvertUsing(ConvertFromString<TMember> convertExpression)
		{
			memberMap.Convert(convertExpression);
			return this;
		}

		public IHasMap<TClass> ConvertUsing(ConvertToString<TClass> convertExpression)
		{
			memberMap.Convert(convertExpression);
			return this;
		}

		public IHasDefaultOptions<TClass, TMember> Default(TMember defaultValue)
		{
			memberMap.Default(defaultValue);
			return this;
		}

		public IHasDefaultOptions<TClass, TMember> Default(string defaultValue)
		{
			memberMap.Default(defaultValue);
			return this;
		}

		public IHasIndexOptions<TClass, TMember> Index(int index, int indexEnd = -1)
		{
			memberMap.Index(index, indexEnd);
			return this;
		}

		public IHasNameOptions<TClass, TMember> Name(params string[] names)
		{
			memberMap.Name(names);
			return this;
		}

		public IHasNameIndexOptions<TClass, TMember> NameIndex(int index)
		{
			memberMap.NameIndex(index);
			return this;
		}

		public IHasOptionalOptions<TClass, TMember> Optional()
		{
			memberMap.Optional();
			return this;
		}

		public IHasTypeConverterOptions<TClass, TMember> TypeConverter(ITypeConverter typeConverter)
		{
			memberMap.TypeConverter(typeConverter);
			return this;
		}

		public IHasTypeConverterOptions<TClass, TMember> TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			memberMap.TypeConverter<TConverter>();
			return this;
		}

		public IHasMap<TClass> Constant(TMember value)
		{
			memberMap.Constant(value);
			return this;
		}

		public IHasMap<TClass> Validate(Validate validateExpression)
		{
			memberMap.Validate(validateExpression);
			return this;
		}

		public ClassMap<TClass> Build()
		{
			return classMap;
		}
	}
}
