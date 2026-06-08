using System;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper.Expressions
{
	public class PrimitiveRecordCreator : RecordCreator
	{
		public PrimitiveRecordCreator(CsvReader reader)
			: base(reader)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			MethodInfo getMethod = typeof(IReaderRow).GetProperty("Item", typeof(string), new Type[1] { typeof(int) }).GetGetMethod();
			Expression expression = Expression.Call(Expression.Constant(base.Reader), getMethod, Expression.Constant(0, typeof(int)));
			MemberMapData memberMapData = new MemberMapData(null)
			{
				Index = 0,
				TypeConverter = base.Reader.Context.TypeConverterCache.GetConverter(recordType)
			};
			memberMapData.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions
			{
				CultureInfo = base.Reader.Configuration.CultureInfo
			}, base.Reader.Context.TypeConverterOptionsCache.GetOptions(recordType));
			expression = Expression.Call(Expression.Constant(memberMapData.TypeConverter), "ConvertFromString", null, expression, Expression.Constant(base.Reader), Expression.Constant(memberMapData));
			expression = Expression.Convert(expression, recordType);
			return Expression.Lambda(typeof(Func<>).MakeGenericType(recordType), expression).Compile();
		}
	}
}
