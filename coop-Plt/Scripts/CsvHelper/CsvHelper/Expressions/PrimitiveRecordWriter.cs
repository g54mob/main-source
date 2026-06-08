using System;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper.Expressions
{
	public class PrimitiveRecordWriter : RecordWriter
	{
		public PrimitiveRecordWriter(CsvWriter writer)
			: base(writer)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			Type typeForRecord = base.Writer.GetTypeForRecord(record);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "record");
			Expression arg = Expression.Convert(parameterExpression, typeof(object));
			ITypeConverter converter = base.Writer.Context.TypeConverterCache.GetConverter(typeForRecord);
			ConstantExpression instance = Expression.Constant(converter);
			MethodInfo method = typeof(ITypeConverter).GetMethod("ConvertToString");
			MemberMapData memberMapData = new MemberMapData(null);
			memberMapData.Index = 0;
			memberMapData.TypeConverter = converter;
			memberMapData.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions(), base.Writer.Context.TypeConverterOptionsCache.GetOptions(typeForRecord));
			MemberMapData memberMapData2 = memberMapData;
			memberMapData2.TypeConverterOptions.CultureInfo = base.Writer.Configuration.CultureInfo;
			arg = Expression.Call(instance, method, arg, Expression.Constant(base.Writer), Expression.Constant(memberMapData2));
			arg = Expression.Call(Expression.Constant(base.Writer), "WriteConvertedField", null, arg, Expression.Constant(typeForRecord));
			return Expression.Lambda<Action<T>>(arg, new ParameterExpression[1] { parameterExpression }).Compile();
		}
	}
}
