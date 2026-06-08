using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Moq
{
	internal sealed class EmptyDefaultValueProvider : LookupOrFallbackDefaultValueProvider
	{
		internal override DefaultValue Kind => DefaultValue.Empty;

		internal EmptyDefaultValueProvider()
		{
			Register(typeof(Array), CreateArray);
			Register(typeof(IEnumerable), CreateEnumerable);
			Register(typeof(IEnumerable<>), CreateEnumerableOf);
			Register(typeof(IQueryable), CreateQueryable);
			Register(typeof(IQueryable<>), CreateQueryableOf);
		}

		private static object CreateArray(Type type, Mock mock)
		{
			Type elementType = type.GetElementType();
			int[] lengths = new int[type.GetArrayRank()];
			return Array.CreateInstance(elementType, lengths);
		}

		private static object CreateEnumerable(Type type, Mock mock)
		{
			return new object[0];
		}

		private static object CreateEnumerableOf(Type type, Mock mock)
		{
			Type elementType = type.GetGenericArguments()[0];
			return Array.CreateInstance(elementType, 0);
		}

		private static object CreateQueryable(Type type, Mock mock)
		{
			return new object[0].AsQueryable();
		}

		private static object CreateQueryableOf(Type type, Mock mock)
		{
			Type type2 = type.GetGenericArguments()[0];
			Array array = Array.CreateInstance(type2, 0);
			MethodInfo methodInfo = typeof(Queryable).GetMethods("AsQueryable").Single((MethodInfo x) => x.IsGenericMethod).MakeGenericMethod(type2);
			object[] parameters = new Array[1] { array };
			return methodInfo.Invoke(null, parameters);
		}
	}
}
