using System;
using System.Collections.Generic;
using FluentAssertions.Types;

namespace FluentAssertions
{
	public static class TypeEnumerableExtensions
	{
		public static IEnumerable<Type> ThatAreDecoratedWith<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
		{
			return new TypeSelector(types).ThatAreDecoratedWith<TAttribute>();
		}

		public static IEnumerable<Type> ThatAreDecoratedWithOrInherit<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
		{
			return new TypeSelector(types).ThatAreDecoratedWithOrInherit<TAttribute>();
		}

		public static IEnumerable<Type> ThatAreNotDecoratedWith<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
		{
			return new TypeSelector(types).ThatAreNotDecoratedWith<TAttribute>();
		}

		public static IEnumerable<Type> ThatAreNotDecoratedWithOrInherit<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
		{
			return new TypeSelector(types).ThatAreNotDecoratedWithOrInherit<TAttribute>();
		}

		public static IEnumerable<Type> ThatAreInNamespace(this IEnumerable<Type> types, string @namespace)
		{
			return new TypeSelector(types).ThatAreInNamespace(@namespace);
		}

		public static IEnumerable<Type> ThatAreUnderNamespace(this IEnumerable<Type> types, string @namespace)
		{
			return new TypeSelector(types).ThatAreUnderNamespace(@namespace);
		}

		public static IEnumerable<Type> ThatDeriveFrom<T>(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatDeriveFrom<T>();
		}

		public static IEnumerable<Type> ThatImplement<T>(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatImplement<T>();
		}

		public static IEnumerable<Type> ThatAreClasses(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatAreClasses();
		}

		public static IEnumerable<Type> ThatAreNotClasses(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatAreNotClasses();
		}

		public static IEnumerable<Type> ThatAreStatic(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatAreStatic();
		}

		public static IEnumerable<Type> ThatAreNotStatic(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).ThatAreNotStatic();
		}

		public static IEnumerable<Type> ThatSatisfy(this IEnumerable<Type> types, Func<Type, bool> predicate)
		{
			return new TypeSelector(types).ThatSatisfy(predicate);
		}

		public static IEnumerable<Type> UnwrapTaskTypes(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).UnwrapTaskTypes();
		}

		public static IEnumerable<Type> UnwrapEnumerableTypes(this IEnumerable<Type> types)
		{
			return new TypeSelector(types).UnwrapEnumerableTypes();
		}
	}
}
