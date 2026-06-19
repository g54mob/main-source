using System;

namespace Loxodon.Framework.Binding.Parameters
{
	public class ParameterWrapActionInvoker<T> : IInvoker
	{
		private readonly Action<T> handler;

		private readonly ICommandParameter<T> commandParameter;

		public ParameterWrapActionInvoker(Action<T> handler, ICommandParameter<T> commandParameter)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (commandParameter == null)
			{
				throw new ArgumentNullException("commandParameter");
			}
			this.commandParameter = commandParameter;
			this.handler = handler;
		}

		public object Invoke(params object[] args)
		{
			handler(commandParameter.GetValue());
			return null;
		}
	}
}
