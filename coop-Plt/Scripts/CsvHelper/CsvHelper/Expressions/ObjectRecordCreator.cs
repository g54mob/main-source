using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CsvHelper.Configuration;

namespace CsvHelper.Expressions
{
	public class ObjectRecordCreator : RecordCreator
	{
		public ObjectRecordCreator(CsvReader reader)
			: base(reader)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			if (base.Reader.Context.Maps[recordType] == null)
			{
				base.Reader.Context.Maps.Add(base.Reader.Context.AutoMap(recordType));
			}
			ClassMap classMap = base.Reader.Context.Maps[recordType];
			Expression body;
			if (classMap.ParameterMaps.Count > 0)
			{
				List<Expression> list = new List<Expression>();
				base.ExpressionManager.CreateConstructorArgumentExpressionsForMapping(classMap, list);
				GetConstructorArgs args = new GetConstructorArgs(classMap.ClassType);
				body = Expression.New(base.Reader.Configuration.GetConstructor(args), list);
			}
			else
			{
				List<MemberAssignment> list2 = new List<MemberAssignment>();
				base.ExpressionManager.CreateMemberAssignmentsForMapping(classMap, list2);
				if (list2.Count == 0)
				{
					throw new ReaderException(base.Reader.Context, "No members are mapped for type '" + recordType.FullName + "'.");
				}
				body = base.ExpressionManager.CreateInstanceAndAssignMembers(recordType, list2);
			}
			return Expression.Lambda(typeof(Func<>).MakeGenericType(recordType), body).Compile();
		}
	}
}
