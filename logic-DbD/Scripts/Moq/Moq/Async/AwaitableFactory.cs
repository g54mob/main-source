using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Moq.Async
{
	internal static class AwaitableFactory
	{
		private static readonly Dictionary<Type, Func<Type, IAwaitableFactory>> Providers;

		static AwaitableFactory()
		{
			Providers = new Dictionary<Type, Func<Type, IAwaitableFactory>>
			{
				[typeof(Task)] = (Type awaitableType) => TaskFactory.Instance,
				[typeof(ValueTask)] = (Type awaitableType) => ValueTaskFactory.Instance,
				[typeof(Task<>)] = (Type awaitableType) => Create(typeof(TaskFactory<>), awaitableType),
				[typeof(ValueTask<>)] = (Type awaitableType) => Create(typeof(ValueTaskFactory<>), awaitableType)
			};
		}

		private static IAwaitableFactory Create(Type awaitableFactoryType, Type awaitableType)
		{
			return (IAwaitableFactory)Activator.CreateInstance(awaitableFactoryType.MakeGenericType(awaitableType.GetGenericArguments()));
		}

		public static IAwaitableFactory TryGet(Type type)
		{
			Type key = (type.IsConstructedGenericType ? type.GetGenericTypeDefinition() : type);
			if (Providers.TryGetValue(key, out Func<Type, IAwaitableFactory> value))
			{
				return value(type);
			}
			return null;
		}
	}
	internal abstract class AwaitableFactory<TAwaitable> : IAwaitableFactory
	{
		Type IAwaitableFactory.ResultType => typeof(void);

		public abstract TAwaitable CreateCompleted();

		object IAwaitableFactory.CreateCompleted(object result)
		{
			return CreateCompleted();
		}

		public abstract TAwaitable CreateFaulted(Exception exception);

		object IAwaitableFactory.CreateFaulted(Exception exception)
		{
			return CreateFaulted(exception);
		}

		public abstract TAwaitable CreateFaulted(IEnumerable<Exception> exceptions);

		object IAwaitableFactory.CreateFaulted(IEnumerable<Exception> exceptions)
		{
			return CreateFaulted(exceptions);
		}

		Expression IAwaitableFactory.CreateResultExpression(Expression awaitableExpression)
		{
			return new AwaitExpression(awaitableExpression, this);
		}

		bool IAwaitableFactory.TryGetResult(object awaitable, out object result)
		{
			result = null;
			return false;
		}
	}
	internal abstract class AwaitableFactory<TAwaitable, TResult> : IAwaitableFactory
	{
		public Type ResultType => typeof(TResult);

		public abstract TAwaitable CreateCompleted(TResult result);

		object IAwaitableFactory.CreateCompleted(object result)
		{
			return CreateCompleted((TResult)result);
		}

		public abstract TAwaitable CreateFaulted(Exception exception);

		object IAwaitableFactory.CreateFaulted(Exception exception)
		{
			return CreateFaulted(exception);
		}

		public abstract TAwaitable CreateFaulted(IEnumerable<Exception> exceptions);

		object IAwaitableFactory.CreateFaulted(IEnumerable<Exception> exceptions)
		{
			return CreateFaulted(exceptions);
		}

		public abstract bool TryGetResult(TAwaitable awaitable, out TResult result);

		public abstract Expression CreateResultExpression(Expression awaitableExpression);

		bool IAwaitableFactory.TryGetResult(object awaitable, out object result)
		{
			if (TryGetResult((TAwaitable)awaitable, out var result2))
			{
				result = result2;
				return true;
			}
			result = null;
			return false;
		}
	}
}
