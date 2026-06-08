using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace HandlebarsDotNet.Compiler
{
	internal class HashParameterBinder : HandlebarsExpressionVisitor
	{
		protected override Expression VisitHashParametersExpression(HashParametersExpression hpex)
		{
			MethodInfo method = typeof(HashParameterDictionary).GetMethod("Add", new Type[2]
			{
				typeof(string),
				typeof(object)
			});
			List<ElementInit> list = new List<ElementInit>();
			foreach (KeyValuePair<string, Expression> parameter in hpex.Parameters)
			{
				list.Add(Expression.ElementInit(method, Expression.Constant(parameter.Key), Visit(parameter.Value)));
			}
			return Expression.ListInit(Expression.New(typeof(HashParameterDictionary).GetConstructor(new Type[0])), list);
		}
	}
}
