using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	public class ClosureBuilder : IDisposable
	{
		private sealed class ClosureBuilderPool : InternalObjectPool<ClosureBuilder, Policy>
		{
			public ClosureBuilderPool(Policy policy)
				: base(policy)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct Policy : IInternalObjectPoolPolicy<ClosureBuilder>
		{
			public ClosureBuilder Create()
			{
				return new ClosureBuilder();
			}

			public bool Return(ClosureBuilder item)
			{
				return true;
			}
		}

		private readonly List<KeyValuePair<ConstantExpression, PathInfo>> _pathInfos = new List<KeyValuePair<ConstantExpression, PathInfo>>();

		private readonly List<KeyValuePair<ConstantExpression, TemplateDelegate>> _templateDelegates = new List<KeyValuePair<ConstantExpression, TemplateDelegate>>();

		private readonly List<KeyValuePair<ConstantExpression, DecoratorDelegate>> _decoratorDelegates = new List<KeyValuePair<ConstantExpression, DecoratorDelegate>>();

		private readonly List<KeyValuePair<ConstantExpression, ChainSegment[]>> _blockParams = new List<KeyValuePair<ConstantExpression, ChainSegment[]>>();

		private readonly List<KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<HelperOptions>>>> _helpers = new List<KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<HelperOptions>>>>();

		private readonly List<KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<BlockHelperOptions>>>> _blockHelpers = new List<KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<BlockHelperOptions>>>>();

		private readonly List<KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<DecoratorOptions>>>> _decorators = new List<KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<DecoratorOptions>>>>();

		private readonly List<KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>>> _blockDecorators = new List<KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>>>();

		private readonly List<KeyValuePair<ConstantExpression, object>> _other = new List<KeyValuePair<ConstantExpression, object>>();

		private static readonly ClosureBuilderPool Pool = new ClosureBuilderPool(default(Policy));

		public void Add(ConstantExpression constantExpression)
		{
			if (constantExpression.Type == typeof(PathInfo))
			{
				_pathInfos.Add(new KeyValuePair<ConstantExpression, PathInfo>(constantExpression, (PathInfo)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(Ref<IHelperDescriptor<HelperOptions>>))
			{
				_helpers.Add(new KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<HelperOptions>>>(constantExpression, (Ref<IHelperDescriptor<HelperOptions>>)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(Ref<IHelperDescriptor<BlockHelperOptions>>))
			{
				_blockHelpers.Add(new KeyValuePair<ConstantExpression, Ref<IHelperDescriptor<BlockHelperOptions>>>(constantExpression, (Ref<IHelperDescriptor<BlockHelperOptions>>)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(Ref<IDecoratorDescriptor<DecoratorOptions>>))
			{
				_decorators.Add(new KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<DecoratorOptions>>>(constantExpression, (Ref<IDecoratorDescriptor<DecoratorOptions>>)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(Ref<IDecoratorDescriptor<BlockDecoratorOptions>>))
			{
				_blockDecorators.Add(new KeyValuePair<ConstantExpression, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>>(constantExpression, (Ref<IDecoratorDescriptor<BlockDecoratorOptions>>)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(TemplateDelegate))
			{
				_templateDelegates.Add(new KeyValuePair<ConstantExpression, TemplateDelegate>(constantExpression, (TemplateDelegate)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(DecoratorDelegate))
			{
				_decoratorDelegates.Add(new KeyValuePair<ConstantExpression, DecoratorDelegate>(constantExpression, (DecoratorDelegate)constantExpression.Value));
			}
			else if (constantExpression.Type == typeof(ChainSegment[]))
			{
				_blockParams.Add(new KeyValuePair<ConstantExpression, ChainSegment[]>(constantExpression, (ChainSegment[])constantExpression.Value));
			}
			else
			{
				_other.Add(new KeyValuePair<ConstantExpression, object>(constantExpression, constantExpression.Value));
			}
		}

		public KeyValuePair<ParameterExpression, Dictionary<Expression, Expression>> Build(out Closure closure)
		{
			Type typeFromHandle = typeof(Closure);
			ConstructorInfo constructorInfo = typeFromHandle.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Single();
			List<object> list = new List<object>();
			BuildKnownValues(list, _pathInfos, 4);
			BuildKnownValues(list, _helpers, 4);
			BuildKnownValues(list, _blockHelpers, 4);
			BuildKnownValues(list, _templateDelegates, 4);
			BuildKnownValues(list, _blockParams, 1);
			BuildKnownValues(list, _decorators, 4);
			BuildKnownValues(list, _blockDecorators, 4);
			BuildKnownValues(list, _decoratorDelegates, 4);
			list.Add(_other.Select((KeyValuePair<ConstantExpression, object> o) => o.Value).ToArray());
			closure = (Closure)constructorInfo.Invoke(list.ToArray());
			Dictionary<Expression, Expression> dictionary = new Dictionary<Expression, Expression>();
			ParameterExpression parameterExpression = Expression.Variable(typeof(Closure), "closure");
			BuildKnownValuesExpressions(parameterExpression, dictionary, _pathInfos, "PI", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _helpers, "HD", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _blockHelpers, "BHD", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _templateDelegates, "TD", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _blockParams, "BP", 1);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _decorators, "DD", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _blockDecorators, "BDD", 4);
			BuildKnownValuesExpressions(parameterExpression, dictionary, _decoratorDelegates, "DDD", 4);
			FieldInfo field = typeFromHandle.GetField("A");
			MemberExpression array = Expression.Field(parameterExpression, field);
			for (int num = 0; num < _other.Count; num++)
			{
				IndexExpression value = Expression.ArrayAccess(array, Expression.Constant(num));
				dictionary.Add(_other[num].Key, value);
			}
			return new KeyValuePair<ParameterExpression, Dictionary<Expression, Expression>>(parameterExpression, dictionary);
		}

		private static void BuildKnownValues<T>(List<object> arguments, List<KeyValuePair<ConstantExpression, T>> knowValues, int fieldsCount) where T : class
		{
			for (int i = 0; i < fieldsCount; i++)
			{
				arguments.Add(knowValues.ElementAtOrDefault(i).Value);
			}
			arguments.Add((knowValues.Count > fieldsCount) ? (from o in knowValues.Skip(fieldsCount)
				select o.Value).ToArray() : null);
		}

		private static void BuildKnownValuesExpressions<T>(Expression closure, Dictionary<Expression, Expression> expressions, List<KeyValuePair<ConstantExpression, T>> knowValues, string prefix, int fieldsCount) where T : class
		{
			Type typeFromHandle = typeof(Closure);
			for (int i = 0; i < fieldsCount && i < knowValues.Count; i++)
			{
				FieldInfo field = typeFromHandle.GetField($"{prefix}{i}");
				expressions.Add(knowValues[i].Key, Expression.Field(closure, field));
			}
			FieldInfo field2 = typeFromHandle.GetField(prefix + "A");
			MemberExpression array = Expression.Field(closure, field2);
			int num = fieldsCount;
			int num2 = 0;
			while (num < knowValues.Count)
			{
				IndexExpression value = Expression.ArrayAccess(array, Expression.Constant(num2));
				expressions.Add(knowValues[num].Key, value);
				num++;
				num2++;
			}
		}

		private ClosureBuilder()
		{
		}

		public static ClosureBuilder Create()
		{
			return Pool.Get();
		}

		public void Dispose()
		{
			_pathInfos.Clear();
			_templateDelegates.Clear();
			_decoratorDelegates.Clear();
			_blockParams.Clear();
			_helpers.Clear();
			_blockHelpers.Clear();
			_decorators.Clear();
			_blockDecorators.Clear();
			_other.Clear();
			Pool.Return(this);
		}
	}
}
