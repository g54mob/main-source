using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Member = {Data.Member}, Names = {string.Join(\",\", Data.Names)}, Index = {Data.Index}, Ignore = {Data.Ignore}, Member = {Data.Member}, TypeConverter = {Data.TypeConverter}")]
	public abstract class MemberMap
	{
		public virtual MemberMapData Data { get; protected set; }

		public virtual MemberMapTypeConverterOption TypeConverterOption { get; protected set; }

		public static MemberMap CreateGeneric(Type classType, MemberInfo member)
		{
			Type type = typeof(MemberMap<, >).MakeGenericType(classType, member.MemberType());
			return (MemberMap)ObjectResolver.Current.Resolve(type, member);
		}

		public virtual MemberMap Name(params string[] names)
		{
			if (names == null || names.Length == 0)
			{
				throw new ArgumentNullException("names");
			}
			Data.Names.Clear();
			Data.Names.AddRange(names);
			Data.IsNameSet = true;
			return this;
		}

		public virtual MemberMap NameIndex(int index)
		{
			Data.NameIndex = index;
			return this;
		}

		public virtual MemberMap Index(int index, int indexEnd = -1)
		{
			Data.Index = index;
			Data.IsIndexSet = true;
			Data.IndexEnd = indexEnd;
			return this;
		}

		public virtual MemberMap Ignore()
		{
			Data.Ignore = true;
			return this;
		}

		public virtual MemberMap Ignore(bool ignore)
		{
			Data.Ignore = ignore;
			return this;
		}

		public virtual MemberMap Default(object defaultValue, bool useOnConversionFailure = false)
		{
			if (defaultValue == null && Data.Member.MemberType().IsValueType)
			{
				throw new ArgumentException("Member of type '" + Data.Member.MemberType().FullName + "' can't have a default value of null.");
			}
			if (defaultValue != null && defaultValue.GetType() != Data.Member.MemberType())
			{
				throw new ArgumentException("Default of type '" + defaultValue.GetType().FullName + "' does not match member of type '" + Data.Member.MemberType().FullName + "'.");
			}
			Data.Default = defaultValue;
			Data.IsDefaultSet = true;
			Data.UseDefaultOnConversionFailure = useOnConversionFailure;
			return this;
		}

		public virtual MemberMap Constant(object constantValue)
		{
			if (constantValue == null && Data.Member.MemberType().IsValueType)
			{
				throw new ArgumentException("Member of type '" + Data.Member.MemberType().FullName + "' can't have a constant value of null.");
			}
			if (constantValue != null && constantValue.GetType() != Data.Member.MemberType())
			{
				throw new ArgumentException("Constant of type '" + constantValue.GetType().FullName + "' does not match member of type '" + Data.Member.MemberType().FullName + "'.");
			}
			Data.Constant = constantValue;
			Data.IsConstantSet = true;
			return this;
		}

		public virtual MemberMap TypeConverter(ITypeConverter typeConverter)
		{
			Data.TypeConverter = typeConverter;
			return this;
		}

		public virtual MemberMap TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			TypeConverter(ObjectResolver.Current.Resolve<TConverter>(new object[0]));
			return this;
		}

		public virtual MemberMap Optional()
		{
			Data.IsOptional = true;
			return this;
		}

		public virtual MemberMap Validate(Validate validateExpression)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "field");
			Expression<Validate> validateExpression2 = Expression.Lambda<Validate>(Expression.Call(Expression.Constant(validateExpression.Target), validateExpression.Method, parameterExpression), new ParameterExpression[1] { parameterExpression });
			Data.ValidateExpression = validateExpression2;
			return this;
		}
	}
	public class MemberMap<TClass, TMember> : MemberMap
	{
		public MemberMap(MemberInfo member)
		{
			TypeConverterOption = new MemberMapTypeConverterOption(this);
			Data = new MemberMapData(member);
		}

		public new virtual MemberMap<TClass, TMember> Name(params string[] names)
		{
			if (names == null || names.Length == 0)
			{
				throw new ArgumentNullException("names");
			}
			Data.Names.Clear();
			Data.Names.AddRange(names);
			Data.IsNameSet = true;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> NameIndex(int index)
		{
			Data.NameIndex = index;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> Index(int index, int indexEnd = -1)
		{
			Data.Index = index;
			Data.IsIndexSet = true;
			Data.IndexEnd = indexEnd;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> Ignore()
		{
			Data.Ignore = true;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> Ignore(bool ignore)
		{
			Data.Ignore = ignore;
			return this;
		}

		public virtual MemberMap<TClass, TMember> Default(TMember defaultValue, bool useOnConversionFailure = false)
		{
			Data.Default = defaultValue;
			Data.IsDefaultSet = true;
			Data.UseDefaultOnConversionFailure = useOnConversionFailure;
			return this;
		}

		public virtual MemberMap<TClass, TMember> Default(string defaultValue, bool useOnConversionFailure = false)
		{
			Data.Default = defaultValue;
			Data.IsDefaultSet = true;
			Data.UseDefaultOnConversionFailure = useOnConversionFailure;
			return this;
		}

		public virtual MemberMap<TClass, TMember> Constant(TMember constantValue)
		{
			Data.Constant = constantValue;
			Data.IsConstantSet = true;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> TypeConverter(ITypeConverter typeConverter)
		{
			Data.TypeConverter = typeConverter;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			TypeConverter(ObjectResolver.Current.Resolve<TConverter>(new object[0]));
			return this;
		}

		public virtual MemberMap<TClass, TMember> Convert(ConvertFromString<TMember> convertFromStringFunction)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ConvertFromStringArgs), "args");
			Expression<ConvertFromString<TMember>> readingConvertExpression = Expression.Lambda<ConvertFromString<TMember>>(Expression.Call(Expression.Constant(convertFromStringFunction.Target), convertFromStringFunction.Method, parameterExpression), new ParameterExpression[1] { parameterExpression });
			Data.ReadingConvertExpression = readingConvertExpression;
			return this;
		}

		public virtual MemberMap<TClass, TMember> Convert(ConvertToString<TClass> convertToStringFunction)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ConvertToStringArgs<TClass>), "args");
			Expression<ConvertToString<TClass>> writingConvertExpression = Expression.Lambda<ConvertToString<TClass>>(Expression.Call(Expression.Constant(convertToStringFunction.Target), convertToStringFunction.Method, parameterExpression), new ParameterExpression[1] { parameterExpression });
			Data.WritingConvertExpression = writingConvertExpression;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> Optional()
		{
			Data.IsOptional = true;
			return this;
		}

		public new virtual MemberMap<TClass, TMember> Validate(Validate validateExpression)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ValidateArgs), "args");
			Expression<Validate> validateExpression2 = Expression.Lambda<Validate>(Expression.Call(Expression.Constant(validateExpression.Target), validateExpression.Method, parameterExpression), new ParameterExpression[1] { parameterExpression });
			Data.ValidateExpression = validateExpression2;
			return this;
		}
	}
}
