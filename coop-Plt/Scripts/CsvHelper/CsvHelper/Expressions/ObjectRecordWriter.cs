using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper.Expressions
{
	public class ObjectRecordWriter : RecordWriter
	{
		public ObjectRecordWriter(CsvWriter writer)
			: base(writer)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			Type typeForRecord = base.Writer.GetTypeForRecord(record);
			if (base.Writer.Context.Maps[typeForRecord] == null)
			{
				base.Writer.Context.Maps.Add(base.Writer.Context.AutoMap(typeForRecord));
			}
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "record");
			UnaryExpression unaryExpression = Expression.Convert(parameterExpression, typeForRecord);
			MemberMapCollection memberMapCollection = new MemberMapCollection();
			memberMapCollection.AddMembers(base.Writer.Context.Maps[typeForRecord]);
			if (memberMapCollection.Count == 0)
			{
				throw new WriterException(base.Writer.Context, "No properties are mapped for type '" + typeForRecord.FullName + "'.");
			}
			List<Action<T>> list = new List<Action<T>>();
			foreach (MemberMap item in memberMapCollection)
			{
				if (item.Data.WritingConvertExpression != null)
				{
					NewExpression newExpression = Expression.New(typeof(ConvertToStringArgs<T>).GetConstructor(new Type[1] { typeof(T) }), unaryExpression);
					Expression expression = Expression.Invoke(item.Data.WritingConvertExpression, newExpression);
					expression = Expression.Call(Expression.Constant(base.Writer), "WriteField", null, expression);
					list.Add(Expression.Lambda<Action<T>>(expression, new ParameterExpression[1] { parameterExpression }).Compile());
				}
				else
				{
					if (!base.Writer.CanWrite(item))
					{
						continue;
					}
					Expression expression2;
					if (item.Data.IsConstantSet)
					{
						if (item.Data.Constant == null)
						{
							expression2 = Expression.Constant(string.Empty);
						}
						else
						{
							expression2 = Expression.Constant(item.Data.Constant);
							ConstantExpression instance = Expression.Constant(base.Writer.Context.TypeConverterCache.GetConverter(item.Data.Constant.GetType()));
							MethodInfo method = typeof(ITypeConverter).GetMethod("ConvertToString");
							expression2 = Expression.Convert(expression2, typeof(object));
							expression2 = Expression.Call(instance, method, expression2, Expression.Constant(base.Writer), Expression.Constant(item.Data));
						}
					}
					else
					{
						if (item.Data.TypeConverter == null)
						{
							continue;
						}
						expression2 = base.ExpressionManager.CreateGetMemberExpression(unaryExpression, base.Writer.Context.Maps[typeForRecord], item);
						ConstantExpression instance2 = Expression.Constant(item.Data.TypeConverter);
						item.Data.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions
						{
							CultureInfo = base.Writer.Configuration.CultureInfo
						}, base.Writer.Context.TypeConverterOptionsCache.GetOptions(item.Data.Member.MemberType()), item.Data.TypeConverterOptions);
						MethodInfo method2 = typeof(ITypeConverter).GetMethod("ConvertToString");
						expression2 = Expression.Convert(expression2, typeof(object));
						expression2 = Expression.Call(instance2, method2, expression2, Expression.Constant(base.Writer), Expression.Constant(item.Data));
						if (typeForRecord.GetTypeInfo().IsClass)
						{
							expression2 = Expression.Condition(Expression.Equal(unaryExpression, Expression.Constant(null)), Expression.Constant(string.Empty), expression2);
						}
					}
					MethodCallExpression body = Expression.Call(Expression.Constant(base.Writer), "WriteConvertedField", null, expression2, Expression.Constant(item.Data.Type));
					list.Add(Expression.Lambda<Action<T>>(body, new ParameterExpression[1] { parameterExpression }).Compile());
				}
			}
			return CombineDelegates(list) ?? ((Action<T>)delegate
			{
			});
		}
	}
}
