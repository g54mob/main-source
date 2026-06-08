using System;
using System.Linq.Expressions;

namespace Moq.Behaviors
{
	internal sealed class RaiseEvent : Behavior
	{
		private Mock mock;

		private LambdaExpression expression;

		private Delegate eventArgsFunc;

		private object[] eventArgsParams;

		public RaiseEvent(Mock mock, LambdaExpression expression, Delegate eventArgsFunc, object[] eventArgsParams)
		{
			this.mock = mock;
			this.expression = expression;
			this.eventArgsFunc = eventArgsFunc;
			this.eventArgsParams = eventArgsParams;
		}

		public override void Execute(Invocation invocation)
		{
			object[] arguments;
			if (eventArgsParams != null)
			{
				arguments = eventArgsParams;
			}
			else
			{
				Type type = eventArgsFunc.GetType();
				arguments = ((!type.IsGenericType || type.GetGenericArguments().Length != 1) ? new object[2]
				{
					mock.Object,
					eventArgsFunc.InvokePreserveStack(invocation.Arguments)
				} : new object[2]
				{
					mock.Object,
					eventArgsFunc.InvokePreserveStack()
				});
			}
			Mock.RaiseEvent(mock, expression, expression.Split(), arguments);
		}
	}
}
