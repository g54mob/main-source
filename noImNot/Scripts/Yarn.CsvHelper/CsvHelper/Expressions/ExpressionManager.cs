using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CsvHelper.Configuration;

namespace CsvHelper.Expressions
{
	public class ExpressionManager
	{
		private readonly CsvReader reader;

		private readonly CsvWriter writer;

		public ExpressionManager(CsvReader reader)
		{
		}

		public ExpressionManager(CsvWriter writer)
		{
		}

		public virtual void CreateConstructorArgumentExpressionsForMapping(ClassMap map, List<Expression> argumentExpressions)
		{
		}

		public virtual void CreateMemberAssignmentsForMapping(ClassMap mapping, List<MemberAssignment> assignments)
		{
		}

		public virtual Expression CreateGetFieldExpression(MemberMap memberMap)
		{
			return null;
		}

		public virtual Expression CreateGetMemberExpression(Expression recordExpression, ClassMap mapping, MemberMap memberMap)
		{
			return null;
		}

		public virtual BlockExpression CreateInstanceAndAssignMembers(Type recordType, List<MemberAssignment> assignments)
		{
			return null;
		}

		public virtual Expression CreateTypeConverterExpression(MemberMap memberMap, Expression fieldExpression)
		{
			return null;
		}

		public virtual Expression CreateDefaultExpression(MemberMap memberMap, Expression fieldExpression)
		{
			return null;
		}
	}
}
