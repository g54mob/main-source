using System;
using Loxodon.Framework.Binding.Proxy;

namespace Loxodon.Framework.Binding.Parameters
{
	public class ParameterWrapScriptInvoker : ParameterWrapBase, IInvoker
	{
		private readonly IScriptInvoker invoker;

		public ParameterWrapScriptInvoker(IScriptInvoker invoker, ICommandParameter commandParameter)
			: base(commandParameter)
		{
			if (invoker == null)
			{
				throw new ArgumentNullException("invoker");
			}
			this.invoker = invoker;
		}

		public object Invoke(params object[] args)
		{
			return invoker.Invoke(GetParameterValue());
		}
	}
}
