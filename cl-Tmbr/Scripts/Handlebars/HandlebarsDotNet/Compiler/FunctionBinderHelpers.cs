using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Expressions.Shortcuts;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	internal static class FunctionBinderHelpers
	{
		private static readonly LookupSlim<int, GcDeferredValue<int, ConstructorInfo>, IntegerEqualityComparer> ArgumentsConstructorsMap = new LookupSlim<int, GcDeferredValue<int, ConstructorInfo>, IntegerEqualityComparer>(default(IntegerEqualityComparer));

		private static readonly Func<int, GcDeferredValue<int, ConstructorInfo>> CtorFactory = (int i) => new GcDeferredValue<int, ConstructorInfo>(i, delegate(int count)
		{
			Type typeFromHandle = typeof(object);
			Type[] array = new Type[count];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = typeFromHandle;
			}
			return typeof(Arguments).GetConstructor(array);
		});

		public static ExpressionContainer<Arguments> CreateArguments(IEnumerable<Expression> expressions, CompilationContext compilationContext)
		{
			Expression[] array = (from o in expressions.ApplyOn(delegate(PathExpression path)
				{
					path.Context = PathExpression.ResolutionContext.Parameter;
				})
				select FunctionBuilder.Reduce(o, compilationContext, out var _)).ToArray();
			if (array.Length == 0)
			{
				return ExpressionShortcuts.New(() => new Arguments(0));
			}
			ConstructorInfo value = ArgumentsConstructorsMap.GetOrAdd(array.Length, CtorFactory).Value;
			if ((object)value != null)
			{
				return ExpressionShortcuts.Arg<Arguments>(Expression.New(value, array));
			}
			ExpressionContainer<object[]> arr = ExpressionShortcuts.Array<object>(array);
			return ExpressionShortcuts.New(() => new Arguments((object[])arr));
		}
	}
}
