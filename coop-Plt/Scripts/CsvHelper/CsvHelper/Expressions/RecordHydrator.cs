using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;

namespace CsvHelper.Expressions
{
	public class RecordHydrator
	{
		private readonly CsvReader reader;

		private readonly ExpressionManager expressionManager;

		private readonly Dictionary<Type, Delegate> hydrateRecordActions = new Dictionary<Type, Delegate>();

		public RecordHydrator(CsvReader reader)
		{
			this.reader = reader;
			expressionManager = ObjectResolver.Current.Resolve<ExpressionManager>(new object[1] { reader });
		}

		public void Hydrate<T>(T record)
		{
			try
			{
				GetHydrateRecordAction<T>()(record);
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		protected virtual Action<T> GetHydrateRecordAction<T>()
		{
			Type typeFromHandle = typeof(T);
			if (!hydrateRecordActions.TryGetValue(typeFromHandle, out var value))
			{
				value = (hydrateRecordActions[typeFromHandle] = CreateHydrateRecordAction<T>());
			}
			return (Action<T>)value;
		}

		protected virtual Action<T> CreateHydrateRecordAction<T>()
		{
			Type typeFromHandle = typeof(T);
			if (reader.Context.Maps[typeFromHandle] == null)
			{
				reader.Context.Maps.Add(reader.Context.AutoMap(typeFromHandle));
			}
			ClassMap classMap = reader.Context.Maps[typeFromHandle];
			ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "record");
			List<Expression> list = new List<Expression>();
			foreach (MemberMap memberMap in classMap.MemberMaps)
			{
				Expression expression = expressionManager.CreateGetFieldExpression(memberMap);
				if (expression != null)
				{
					Expression.Parameter(memberMap.Data.Member.MemberType(), "member");
					BinaryExpression item = Expression.Assign(Expression.MakeMemberAccess(parameterExpression, memberMap.Data.Member), expression);
					list.Add(item);
				}
			}
			foreach (MemberReferenceMap referenceMap in classMap.ReferenceMaps)
			{
				if (reader.CanRead(referenceMap))
				{
					List<MemberAssignment> assignments = new List<MemberAssignment>();
					expressionManager.CreateMemberAssignmentsForMapping(referenceMap.Data.Mapping, assignments);
					BlockExpression right = expressionManager.CreateInstanceAndAssignMembers(referenceMap.Data.Member.MemberType(), assignments);
					Expression.Parameter(referenceMap.Data.Member.MemberType(), "referenceMember");
					BinaryExpression item2 = Expression.Assign(Expression.MakeMemberAccess(parameterExpression, referenceMap.Data.Member), right);
					list.Add(item2);
				}
			}
			return Expression.Lambda<Action<T>>(Expression.Block(list), new ParameterExpression[1] { parameterExpression }).Compile();
		}
	}
}
