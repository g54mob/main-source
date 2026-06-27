using System;
using System.Linq.Expressions;
using FluentAssertions.Common;

namespace FluentAssertions.Specialized
{
	public class MemberExecutionTime<T> : ExecutionTime
	{
		public MemberExecutionTime(T subject, Expression<Action<T>> action, StartTimer createTimer)
			: base(delegate
			{
				action.Compile()(subject);
			}, "(" + action.Body?.ToString() + ")", createTimer)
		{
		}
	}
}
