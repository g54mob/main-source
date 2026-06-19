using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Loxodon.Framework.Binding.Expressions;
using Loxodon.Framework.Binding.Paths;
using Loxodon.Framework.Binding.Proxy.Sources.Object;

namespace Loxodon.Framework.Binding.Proxy.Sources.Expressions
{
	public class ExpressionSourceProxyFactory : TypedSourceProxyFactory<ExpressionSourceDescription>
	{
		private ISourceProxyFactory factory;

		private IExpressionPathFinder pathFinder;

		public ExpressionSourceProxyFactory(ISourceProxyFactory factory, IExpressionPathFinder pathFinder)
		{
			this.factory = factory;
			this.pathFinder = pathFinder;
		}

		protected override bool TryCreateProxy(object source, ExpressionSourceDescription description, out ISourceProxy proxy)
		{
			proxy = null;
			LambdaExpression expression = description.Expression;
			List<ISourceProxy> list = new List<ISourceProxy>();
			foreach (Path item in pathFinder.FindPaths(expression))
			{
				if (item.IsStatic || (source != null && (!(item[0] is MemberNode memberNode) || !(memberNode.MemberInfo != null) || memberNode.MemberInfo.DeclaringType.IsAssignableFrom(source.GetType()))))
				{
					ISourceProxy sourceProxy = factory.CreateProxy(source, new ObjectSourceDescription
					{
						Path = item
					});
					if (sourceProxy != null)
					{
						list.Add(sourceProxy);
					}
				}
			}
			try
			{
				Delegate obj = expression.Compile();
				Type type = obj.ReturnType();
				Type type2 = obj.ParameterType();
				if (type2 != null)
				{
					proxy = (ISourceProxy)Activator.CreateInstance(typeof(ExpressionSourceProxy<, >).MakeGenericType(type2, type), source, obj, list);
				}
				else
				{
					proxy = (ISourceProxy)Activator.CreateInstance(typeof(ExpressionSourceProxy<>).MakeGenericType(type), obj, list);
				}
			}
			catch (Exception)
			{
				Func<object[], object> func = expression.DynamicCompile();
				proxy = new ExpressionSourceProxy(description.IsStatic ? null : source, func, description.ReturnType, list);
			}
			if (proxy != null)
			{
				return true;
			}
			return false;
		}
	}
}
