using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UniJSON
{
	public static class GenericExpressionCallFactory
	{
		public static Action<S, A0> Create<S, A0>(MethodInfo m)
		{
			ParameterExpression parameterExpression = Expression.Parameter(m.DeclaringType, m.Name);
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			Expression[] arguments = array;
			return (Action<S, A0>)Expression.Lambda(Expression.Call(parameterExpression, m, arguments), new ParameterExpression[1] { parameterExpression }.Concat(array).ToArray()).Compile();
		}

		public static Action<S, A0, A1> Create<S, A0, A1>(MethodInfo m)
		{
			ParameterExpression parameterExpression = Expression.Parameter(m.DeclaringType, m.Name);
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			Expression[] arguments = array;
			return (Action<S, A0, A1>)Expression.Lambda(Expression.Call(parameterExpression, m, arguments), new ParameterExpression[1] { parameterExpression }.Concat(array).ToArray()).Compile();
		}

		public static Action<S, A0, A1, A2> Create<S, A0, A1, A2>(MethodInfo m)
		{
			ParameterExpression parameterExpression = Expression.Parameter(m.DeclaringType, m.Name);
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			Expression[] arguments = array;
			return (Action<S, A0, A1, A2>)Expression.Lambda(Expression.Call(parameterExpression, m, arguments), new ParameterExpression[1] { parameterExpression }.Concat(array).ToArray()).Compile();
		}

		public static Action<A0> CreateWithThis<S, A0>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				if (instance != null)
				{
					throw new ArgumentException();
				}
			}
			else if (instance == null)
			{
				throw new ArgumentNullException();
			}
			ConstantExpression instance2 = Expression.Constant(instance, typeof(S));
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			MethodCallExpression body;
			if (m.IsStatic)
			{
				Expression[] arguments = array;
				body = Expression.Call(m, arguments);
			}
			else
			{
				Expression[] arguments = array;
				body = Expression.Call(instance2, m, arguments);
			}
			return (Action<A0>)Expression.Lambda(body, array).Compile();
		}

		public static Action<A0, A1> CreateWithThis<S, A0, A1>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				if (instance != null)
				{
					throw new ArgumentException();
				}
			}
			else if (instance == null)
			{
				throw new ArgumentNullException();
			}
			ConstantExpression instance2 = Expression.Constant(instance, typeof(S));
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			MethodCallExpression body;
			if (m.IsStatic)
			{
				Expression[] arguments = array;
				body = Expression.Call(m, arguments);
			}
			else
			{
				Expression[] arguments = array;
				body = Expression.Call(instance2, m, arguments);
			}
			return (Action<A0, A1>)Expression.Lambda(body, array).Compile();
		}

		public static Action<A0, A1, A2> CreateWithThis<S, A0, A1, A2>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				if (instance != null)
				{
					throw new ArgumentException();
				}
			}
			else if (instance == null)
			{
				throw new ArgumentNullException();
			}
			ConstantExpression instance2 = Expression.Constant(instance, typeof(S));
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			MethodCallExpression body;
			if (m.IsStatic)
			{
				Expression[] arguments = array;
				body = Expression.Call(m, arguments);
			}
			else
			{
				Expression[] arguments = array;
				body = Expression.Call(instance2, m, arguments);
			}
			return (Action<A0, A1, A2>)Expression.Lambda(body, array).Compile();
		}

		public static Action<A0, A1, A2, A3> CreateWithThis<S, A0, A1, A2, A3>(MethodInfo m, S instance)
		{
			if (m.IsStatic)
			{
				if (instance != null)
				{
					throw new ArgumentException();
				}
			}
			else if (instance == null)
			{
				throw new ArgumentNullException();
			}
			ConstantExpression instance2 = Expression.Constant(instance, typeof(S));
			ParameterExpression[] array = (from x in m.GetParameters()
				select Expression.Parameter(x.ParameterType, x.Name)).ToArray();
			MethodCallExpression body;
			if (m.IsStatic)
			{
				Expression[] arguments = array;
				body = Expression.Call(m, arguments);
			}
			else
			{
				Expression[] arguments = array;
				body = Expression.Call(instance2, m, arguments);
			}
			return (Action<A0, A1, A2, A3>)Expression.Lambda(body, array).Compile();
		}
	}
}
