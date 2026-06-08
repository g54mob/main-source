using System;
using NSubstitute.Exceptions;

namespace NSubstitute.Core.Arguments
{
	public static class ArgumentMatcher
	{
		private class GenericToNonGenericMatcherProxy<T> : IArgumentMatcher
		{
			protected readonly IArgumentMatcher<T> _matcher;

			public GenericToNonGenericMatcherProxy(IArgumentMatcher<T> matcher)
			{
				_matcher = matcher;
			}

			public bool IsSatisfiedBy(object? argument)
			{
				return _matcher.IsSatisfiedBy((T)argument);
			}
		}

		private class GenericToNonGenericMatcherProxyWithDescribe<T> : GenericToNonGenericMatcherProxy<T>, IDescribeNonMatches
		{
			public GenericToNonGenericMatcherProxyWithDescribe(IArgumentMatcher<T> matcher)
				: base(matcher)
			{
				if (!(matcher is IDescribeNonMatches))
				{
					throw new SubstituteInternalException("Should implement IDescribeNonMatches type.");
				}
			}

			public string DescribeFor(object? argument)
			{
				return ((IDescribeNonMatches)_matcher).DescribeFor(argument);
			}
		}

		private class DefaultValueContainer<T>
		{
			public T? Value;
		}

		public static ref T? Enqueue<T>(IArgumentMatcher<T> argumentMatcher)
		{
			if (argumentMatcher == null)
			{
				throw new ArgumentNullException("argumentMatcher");
			}
			GenericToNonGenericMatcherProxy<T> genericToNonGenericMatcherProxy = ((!(argumentMatcher is IDescribeNonMatches)) ? new GenericToNonGenericMatcherProxy<T>(argumentMatcher) : new GenericToNonGenericMatcherProxyWithDescribe<T>(argumentMatcher));
			IArgumentMatcher matcher = genericToNonGenericMatcherProxy;
			return ref EnqueueArgSpecification<T>(new ArgumentSpecification(typeof(T), matcher));
		}

		internal static ref T? Enqueue<T>(IArgumentMatcher argumentMatcher)
		{
			return ref EnqueueArgSpecification<T>(new ArgumentSpecification(typeof(T), argumentMatcher));
		}

		internal static ref T? Enqueue<T>(IArgumentMatcher argumentMatcher, Action<object?> action)
		{
			return ref EnqueueArgSpecification<T>(new ArgumentSpecification(typeof(T), argumentMatcher, action));
		}

		private static ref T? EnqueueArgSpecification<T>(IArgumentSpecification specification)
		{
			SubstitutionContext.Current.ThreadContext.EnqueueArgumentSpecification(specification);
			return ref new DefaultValueContainer<T>().Value;
		}
	}
}
