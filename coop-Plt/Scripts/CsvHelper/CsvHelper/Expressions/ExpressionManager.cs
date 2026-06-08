using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper.Expressions
{
	public class ExpressionManager
	{
		private readonly CsvReader reader;

		private readonly CsvWriter writer;

		public ExpressionManager(CsvReader reader)
		{
			this.reader = reader;
		}

		public ExpressionManager(CsvWriter writer)
		{
			this.writer = writer;
		}

		public virtual void CreateConstructorArgumentExpressionsForMapping(ClassMap map, List<Expression> argumentExpressions)
		{
			foreach (ParameterMap parameterMap in map.ParameterMaps)
			{
				if (parameterMap.Data.IsConstantSet)
				{
					UnaryExpression item = Expression.Convert(Expression.Constant(parameterMap.Data.Constant), parameterMap.Data.Parameter.ParameterType);
					argumentExpressions.Add(item);
					continue;
				}
				if (parameterMap.Data.Ignore)
				{
					Expression item2 = (parameterMap.Data.IsDefaultSet ? Expression.Convert(Expression.Constant(parameterMap.Data.Default), parameterMap.Data.Parameter.ParameterType) : ((!parameterMap.Data.Parameter.HasDefaultValue) ? ((Expression)Expression.Default(parameterMap.Data.Parameter.ParameterType)) : ((Expression)Expression.Convert(Expression.Constant(parameterMap.Data.Parameter.DefaultValue), parameterMap.Data.Parameter.ParameterType))));
					argumentExpressions.Add(item2);
					continue;
				}
				if (parameterMap.ConstructorTypeMap != null)
				{
					List<Expression> list = new List<Expression>();
					CreateConstructorArgumentExpressionsForMapping(parameterMap.ConstructorTypeMap, list);
					GetConstructorArgs args = new GetConstructorArgs(parameterMap.ConstructorTypeMap.ClassType);
					NewExpression item3 = Expression.New(reader.Configuration.GetConstructor(args), list);
					argumentExpressions.Add(item3);
					continue;
				}
				if (parameterMap.ReferenceMap != null)
				{
					List<MemberAssignment> assignments = new List<MemberAssignment>();
					CreateMemberAssignmentsForMapping(parameterMap.ReferenceMap.Data.Mapping, assignments);
					BlockExpression item4 = CreateInstanceAndAssignMembers(parameterMap.ReferenceMap.Data.Parameter.ParameterType, assignments);
					argumentExpressions.Add(item4);
					continue;
				}
				int num;
				if (parameterMap.Data.IsNameSet || (reader.Configuration.HasHeaderRecord && !parameterMap.Data.IsIndexSet))
				{
					num = reader.GetFieldIndex(parameterMap.Data.Names.ToArray(), parameterMap.Data.NameIndex, parameterMap.Data.IsOptional);
					if (num == -1)
					{
						if (parameterMap.Data.IsDefaultSet || parameterMap.Data.IsOptional)
						{
							Expression item5 = CreateDefaultExpression(parameterMap, Expression.Constant(string.Empty));
							argumentExpressions.Add(item5);
						}
						continue;
					}
				}
				else
				{
					if (!parameterMap.Data.IsIndexSet && parameterMap.Data.IsOptional)
					{
						Expression item6 = CreateDefaultExpression(parameterMap, Expression.Constant(string.Empty));
						argumentExpressions.Add(item6);
						continue;
					}
					num = parameterMap.Data.Index;
				}
				MethodInfo getMethod = typeof(IReaderRow).GetProperty("Item", typeof(string), new Type[1] { typeof(int) }).GetGetMethod();
				Expression fieldExpression = Expression.Call(Expression.Constant(reader), getMethod, Expression.Constant(num, typeof(int)));
				fieldExpression = ((!parameterMap.Data.IsDefaultSet) ? CreateTypeConverterExpression(parameterMap, fieldExpression) : CreateDefaultExpression(parameterMap, fieldExpression));
				argumentExpressions.Add(fieldExpression);
			}
		}

		public virtual void CreateMemberAssignmentsForMapping(ClassMap mapping, List<MemberAssignment> assignments)
		{
			foreach (MemberMap memberMap in mapping.MemberMaps)
			{
				Expression expression = CreateGetFieldExpression(memberMap);
				if (expression != null)
				{
					assignments.Add(Expression.Bind(memberMap.Data.Member, expression));
				}
			}
			foreach (MemberReferenceMap referenceMap in mapping.ReferenceMaps)
			{
				if (reader.CanRead(referenceMap))
				{
					Expression expression2;
					if (referenceMap.Data.Mapping.ParameterMaps.Count > 0)
					{
						List<Expression> list = new List<Expression>();
						CreateConstructorArgumentExpressionsForMapping(referenceMap.Data.Mapping, list);
						GetConstructorArgs args = new GetConstructorArgs(referenceMap.Data.Mapping.ClassType);
						expression2 = Expression.New(reader.Configuration.GetConstructor(args), list);
					}
					else
					{
						List<MemberAssignment> assignments2 = new List<MemberAssignment>();
						CreateMemberAssignmentsForMapping(referenceMap.Data.Mapping, assignments2);
						expression2 = CreateInstanceAndAssignMembers(referenceMap.Data.Member.MemberType(), assignments2);
					}
					assignments.Add(Expression.Bind(referenceMap.Data.Member, expression2));
				}
			}
		}

		public virtual Expression CreateGetFieldExpression(MemberMap memberMap)
		{
			if (memberMap.Data.ReadingConvertExpression != null)
			{
				return Expression.Convert(Expression.Invoke(memberMap.Data.ReadingConvertExpression, Expression.Constant(new ConvertFromStringArgs(reader))), memberMap.Data.Member.MemberType());
			}
			if (!reader.CanRead(memberMap))
			{
				return null;
			}
			if (memberMap.Data.IsConstantSet)
			{
				return Expression.Convert(Expression.Constant(memberMap.Data.Constant), memberMap.Data.Member.MemberType());
			}
			if (memberMap.Data.TypeConverter == null)
			{
				return null;
			}
			int num;
			if (memberMap.Data.IsNameSet || (reader.Configuration.HasHeaderRecord && !memberMap.Data.IsIndexSet))
			{
				num = reader.GetFieldIndex(memberMap.Data.Names.ToArray(), memberMap.Data.NameIndex, memberMap.Data.IsOptional);
				if (num == -1)
				{
					if (memberMap.Data.IsDefaultSet)
					{
						return CreateDefaultExpression(memberMap, Expression.Constant(string.Empty));
					}
					return null;
				}
			}
			else
			{
				num = memberMap.Data.Index;
			}
			MethodInfo getMethod = typeof(IReaderRow).GetProperty("Item", typeof(string), new Type[1] { typeof(int) }).GetGetMethod();
			Expression expression = Expression.Call(Expression.Constant(reader), getMethod, Expression.Constant(num, typeof(int)));
			if (memberMap.Data.ValidateExpression != null)
			{
				NewExpression newExpression = Expression.New(typeof(ValidateArgs).GetConstructor(new Type[1] { typeof(string) }), expression);
				UnaryExpression test = Expression.IsFalse(Expression.Invoke(memberMap.Data.ValidateExpression, newExpression));
				UnaryExpression ifTrue = Expression.Throw(Expression.New((from c in typeof(FieldValidationException).GetConstructors()
					orderby c.GetParameters().Length
					select c).First(), Expression.Constant(reader.Context), expression));
				expression = Expression.Block(Expression.IfThen(test, ifTrue), expression);
			}
			if (memberMap.Data.IsDefaultSet)
			{
				return CreateDefaultExpression(memberMap, expression);
			}
			return CreateTypeConverterExpression(memberMap, expression);
		}

		public virtual Expression CreateGetMemberExpression(Expression recordExpression, ClassMap mapping, MemberMap memberMap)
		{
			if (mapping.MemberMaps.Any((MemberMap mm) => mm == memberMap))
			{
				if (memberMap.Data.Member is PropertyInfo)
				{
					return Expression.Property(recordExpression, (PropertyInfo)memberMap.Data.Member);
				}
				if (memberMap.Data.Member is FieldInfo)
				{
					return Expression.Field(recordExpression, (FieldInfo)memberMap.Data.Member);
				}
			}
			foreach (MemberReferenceMap referenceMap in mapping.ReferenceMaps)
			{
				MemberExpression memberExpression = referenceMap.Data.Member.GetMemberExpression(recordExpression);
				Expression expression = CreateGetMemberExpression(memberExpression, referenceMap.Data.Mapping, memberMap);
				if (expression != null)
				{
					if (referenceMap.Data.Member.MemberType().GetTypeInfo().IsValueType)
					{
						return expression;
					}
					BinaryExpression test = Expression.Equal(memberExpression, Expression.Constant(null));
					bool isValueType = memberMap.Data.Member.MemberType().GetTypeInfo().IsValueType;
					bool flag = isValueType && memberMap.Data.Member.MemberType().GetTypeInfo().IsGenericType;
					Type type;
					if (isValueType && !flag && !writer.Configuration.UseNewObjectForNullReferenceMembers)
					{
						type = typeof(Nullable<>).MakeGenericType(memberMap.Data.Member.MemberType());
						expression = Expression.Convert(expression, type);
					}
					else
					{
						type = memberMap.Data.Member.MemberType();
					}
					Expression ifTrue = ((isValueType && !flag) ? ((Expression)Expression.New(type)) : ((Expression)Expression.Constant(null, type)));
					return Expression.Condition(test, ifTrue, expression);
				}
			}
			return null;
		}

		public virtual BlockExpression CreateInstanceAndAssignMembers(Type recordType, List<MemberAssignment> assignments)
		{
			List<Expression> list = new List<Expression>();
			MethodInfo method = typeof(IObjectResolver).GetMethod("Resolve", new Type[2]
			{
				typeof(Type),
				typeof(object[])
			});
			UnaryExpression unaryExpression = Expression.Convert(Expression.Call(Expression.Constant(ObjectResolver.Current), method, Expression.Constant(recordType), Expression.Constant(new object[0])), recordType);
			ParameterExpression variableExpression = Expression.Variable(unaryExpression.Type, "instance");
			list.Add(Expression.Assign(variableExpression, unaryExpression));
			list.AddRange(assignments.Select((MemberAssignment b) => Expression.Assign(Expression.MakeMemberAccess(variableExpression, b.Member), b.Expression)));
			list.Add(variableExpression);
			return Expression.Block(new ParameterExpression[1] { variableExpression }, list);
		}

		public virtual Expression CreateTypeConverterExpression(MemberMap memberMap, Expression fieldExpression)
		{
			memberMap.Data.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions
			{
				CultureInfo = reader.Configuration.CultureInfo
			}, reader.Context.TypeConverterOptionsCache.GetOptions(memberMap.Data.Member.MemberType()), memberMap.Data.TypeConverterOptions);
			return Expression.Convert(Expression.Call(Expression.Constant(memberMap.Data.TypeConverter), "ConvertFromString", null, fieldExpression, Expression.Constant(reader), Expression.Constant(memberMap.Data)), memberMap.Data.Member.MemberType());
		}

		public virtual Expression CreateTypeConverterExpression(ParameterMap parameterMap, Expression fieldExpression)
		{
			parameterMap.Data.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions
			{
				CultureInfo = reader.Configuration.CultureInfo
			}, reader.Context.TypeConverterOptionsCache.GetOptions(parameterMap.Data.Parameter.ParameterType), parameterMap.Data.TypeConverterOptions);
			MemberMapData memberMapData = new MemberMapData(null)
			{
				Constant = parameterMap.Data.Constant,
				Default = parameterMap.Data.Default,
				Ignore = parameterMap.Data.Ignore,
				Index = parameterMap.Data.Index,
				IsConstantSet = parameterMap.Data.IsConstantSet,
				IsDefaultSet = parameterMap.Data.IsDefaultSet,
				IsIndexSet = parameterMap.Data.IsIndexSet,
				IsNameSet = parameterMap.Data.IsNameSet,
				NameIndex = parameterMap.Data.NameIndex,
				TypeConverter = parameterMap.Data.TypeConverter,
				TypeConverterOptions = parameterMap.Data.TypeConverterOptions
			};
			memberMapData.Names.AddRange(parameterMap.Data.Names);
			return Expression.Convert(Expression.Call(Expression.Constant(parameterMap.Data.TypeConverter), "ConvertFromString", null, fieldExpression, Expression.Constant(reader), Expression.Constant(memberMapData)), parameterMap.Data.Parameter.ParameterType);
		}

		public virtual Expression CreateDefaultExpression(MemberMap memberMap, Expression fieldExpression)
		{
			Expression ifFalse = CreateTypeConverterExpression(memberMap, fieldExpression);
			Expression expression = ((!(memberMap.Data.Member.MemberType() != typeof(string)) || memberMap.Data.Default == null || !(memberMap.Data.Default.GetType() == typeof(string))) ? ((Expression)Expression.Constant(memberMap.Data.Default)) : ((Expression)Expression.Call(Expression.Constant(memberMap.Data.TypeConverter), "ConvertFromString", null, Expression.Constant(memberMap.Data.Default), Expression.Constant(reader), Expression.Constant(memberMap.Data))));
			expression = Expression.Convert(expression, memberMap.Data.Member.MemberType());
			fieldExpression = Expression.Condition(Expression.Equal(Expression.Convert(Expression.Coalesce(fieldExpression, Expression.Constant(string.Empty)), typeof(string)), Expression.Constant(string.Empty, typeof(string))), expression, ifFalse);
			return fieldExpression;
		}

		public virtual Expression CreateDefaultExpression(ParameterMap parameterMap, Expression fieldExpression)
		{
			Expression ifFalse = CreateTypeConverterExpression(parameterMap, fieldExpression);
			fieldExpression = Expression.Condition(ifTrue: (!(parameterMap.Data.Parameter.ParameterType != typeof(string)) || parameterMap.Data.Default == null || !(parameterMap.Data.Default.GetType() == typeof(string))) ? Expression.Convert(Expression.Constant(parameterMap.Data.Default), parameterMap.Data.Parameter.ParameterType) : CreateTypeConverterExpression(parameterMap, Expression.Constant(parameterMap.Data.Default)), test: Expression.Equal(Expression.Convert(Expression.Coalesce(fieldExpression, Expression.Constant(string.Empty)), typeof(string)), Expression.Constant(string.Empty, typeof(string))), ifFalse: ifFalse);
			return fieldExpression;
		}
	}
}
