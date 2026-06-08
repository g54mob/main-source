using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CsvHelper
{
	public class ObjectCreator
	{
		private enum MatchType
		{
			None = 0,
			Exact = 1,
			Fuzzy = 2
		}

		private readonly Dictionary<int, Func<object[], object>> cache = new Dictionary<int, Func<object[], object>>();

		public T CreateInstance<T>(params object[] args)
		{
			return (T)CreateInstance(typeof(T), args);
		}

		public object CreateInstance(Type type, params object[] args)
		{
			return GetFunc(type, args)(args);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Func<object[], object> GetFunc(Type type, object[] args)
		{
			Type[] argTypes = GetArgTypes(args);
			int constructorCacheKey = GetConstructorCacheKey(type, argTypes);
			if (!cache.TryGetValue(constructorCacheKey, out var value))
			{
				value = (cache[constructorCacheKey] = CreateInstanceFunc(type, argTypes));
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Type[] GetArgTypes(object[] args)
		{
			Type[] array = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = args[i]?.GetType() ?? typeof(object);
			}
			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetConstructorCacheKey(Type type, Type[] args)
		{
			int num = 17;
			num = num * 31 + type.GetHashCode();
			for (int i = 0; i < args.Length; i++)
			{
				num = num * 31 + args[i].GetHashCode();
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Func<object[], object> CreateInstanceFunc(Type type, Type[] argTypes)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object[]), "args");
			Expression body;
			if (type.IsValueType)
			{
				if (argTypes.Length != 0)
				{
					throw GetConstructorNotFoundException(type, argTypes);
				}
				body = Expression.Convert(Expression.Default(type), typeof(object));
			}
			else
			{
				ConstructorInfo constructor = GetConstructor(type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), type, argTypes);
				ParameterInfo[] parameters = constructor.GetParameters();
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					array[i] = parameters[i].ParameterType;
				}
				List<Expression> list = new List<Expression>();
				for (int j = 0; j < array.Length; j++)
				{
					Type type2 = array[j];
					UnaryExpression item = Expression.Convert(Expression.ArrayIndex(parameterExpression, Expression.Constant(j)), type2);
					list.Add(item);
				}
				body = Expression.New(constructor, list);
			}
			return Expression.Lambda<Func<object[], object>>(body, new ParameterExpression[1] { parameterExpression }).Compile();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ConstructorInfo GetConstructor(ConstructorInfo[] constructors, Type type, Type[] argTypes)
		{
			MatchType matchType = MatchType.Exact;
			List<ConstructorInfo> list = new List<ConstructorInfo>();
			for (int i = 0; i < constructors.Length; i++)
			{
				ConstructorInfo constructorInfo = constructors[i];
				ParameterInfo[] parameters = constructors[i].GetParameters();
				if (parameters.Length != argTypes.Length)
				{
					continue;
				}
				for (int j = 0; j < parameters.Length && j < argTypes.Length; j++)
				{
					Type parameterType = parameters[j].ParameterType;
					Type type2 = argTypes[j];
					if (type2 == parameterType)
					{
						matchType = MatchType.Exact;
						continue;
					}
					if (!parameterType.IsValueType && (parameterType.IsAssignableFrom(type2) || type2 == typeof(object)))
					{
						matchType = MatchType.Fuzzy;
						continue;
					}
					matchType = MatchType.None;
					break;
				}
				switch (matchType)
				{
				case MatchType.Exact:
					return constructorInfo;
				case MatchType.Fuzzy:
					list.Add(constructorInfo);
					break;
				}
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			if (list.Count > 1)
			{
				throw new AmbiguousMatchException();
			}
			throw GetConstructorNotFoundException(type, argTypes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static MissingMethodException GetConstructorNotFoundException(Type type, Type[] argTypes)
		{
			string text = type.FullName + "(" + string.Join(", ", argTypes.Select((Type a) => a.FullName)) + ")";
			throw new MissingMethodException("Constructor '" + text + "' was not found.");
		}
	}
}
