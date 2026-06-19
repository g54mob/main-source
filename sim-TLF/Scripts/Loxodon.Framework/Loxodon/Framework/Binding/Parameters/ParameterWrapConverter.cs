using System;
using Loxodon.Framework.Binding.Converters;
using Loxodon.Framework.Binding.Proxy;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Commands;

namespace Loxodon.Framework.Binding.Parameters
{
	public class ParameterWrapConverter : AbstractConverter
	{
		private readonly ICommandParameter commandParameter;

		public ParameterWrapConverter(ICommandParameter commandParameter)
		{
			if (commandParameter == null)
			{
				throw new ArgumentNullException("commandParameter");
			}
			this.commandParameter = commandParameter;
		}

		public override object Convert(object value)
		{
			if (value == null)
			{
				return null;
			}
			if (value is Delegate)
			{
				return new ParameterWrapDelegateInvoker(value as Delegate, commandParameter);
			}
			if (value is ICommand)
			{
				return new ParameterWrapCommand(value as ICommand, commandParameter);
			}
			if (value is IScriptInvoker)
			{
				return new ParameterWrapScriptInvoker(value as IScriptInvoker, commandParameter);
			}
			if (value is IProxyInvoker)
			{
				return new ParameterWrapProxyInvoker(value as IProxyInvoker, commandParameter);
			}
			if (value is IInvoker)
			{
				return new ParameterWrapInvoker(value as IInvoker, commandParameter);
			}
			throw new NotSupportedException($"Unsupported type \"{value.GetType()}\".");
		}

		public override object ConvertBack(object value)
		{
			throw new NotSupportedException();
		}
	}
	public class ParameterWrapConverter<T> : AbstractConverter
	{
		private readonly ICommandParameter<T> commandParameter;

		public ParameterWrapConverter(ICommandParameter<T> commandParameter)
		{
			if (commandParameter == null)
			{
				throw new ArgumentNullException("commandParameter");
			}
			this.commandParameter = commandParameter;
		}

		public override object Convert(object value)
		{
			if (value == null)
			{
				return null;
			}
			if (value is IInvoker<T> invoker)
			{
				return new ParameterWrapInvoker<T>(invoker, commandParameter);
			}
			if (value is ICommand<T> wrappedCommand)
			{
				return new ParameterWrapCommand<T>(wrappedCommand, commandParameter);
			}
			if (value is Action<T> handler)
			{
				return new ParameterWrapActionInvoker<T>(handler, commandParameter);
			}
			if (value is Delegate)
			{
				return new ParameterWrapDelegateInvoker(value as Delegate, commandParameter);
			}
			if (value is ICommand)
			{
				return new ParameterWrapCommand(value as ICommand, commandParameter);
			}
			if (value is IScriptInvoker)
			{
				return new ParameterWrapScriptInvoker(value as IScriptInvoker, commandParameter);
			}
			if (value is IProxyInvoker)
			{
				return new ParameterWrapProxyInvoker(value as IProxyInvoker, commandParameter);
			}
			if (value is IInvoker)
			{
				return new ParameterWrapInvoker(value as IInvoker, commandParameter);
			}
			throw new NotSupportedException($"Unsupported type \"{value.GetType()}\".");
		}

		public override object ConvertBack(object value)
		{
			throw new NotSupportedException();
		}
	}
}
