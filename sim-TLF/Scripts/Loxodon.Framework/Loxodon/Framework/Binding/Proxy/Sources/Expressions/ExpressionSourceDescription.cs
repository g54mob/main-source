using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Loxodon.Framework.Binding.Proxy.Sources.Expressions
{
	public class ExpressionSourceDescription : SourceDescription
	{
		private LambdaExpression expression;

		private Type returnType;

		public LambdaExpression Expression
		{
			get
			{
				return expression;
			}
			set
			{
				expression = value;
				Type type = expression.GetType().GetGenericArguments()[0];
				if (!typeof(Delegate).IsAssignableFrom(type))
				{
					throw new NotSupportedException();
				}
				MethodInfo method = type.GetMethod("Invoke");
				returnType = method.ReturnType;
				ParameterInfo[] parameters = method.GetParameters();
				IsStatic = ((parameters == null || parameters.Length == 0) ? true : false);
			}
		}

		public Type ReturnType => returnType;

		public override string ToString()
		{
			if (expression != null)
			{
				return "Expression:" + expression.ToString();
			}
			return "Expression:null";
		}
	}
}
