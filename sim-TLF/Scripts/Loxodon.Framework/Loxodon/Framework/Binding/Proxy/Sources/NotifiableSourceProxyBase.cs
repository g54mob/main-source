using System;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Sources
{
	public abstract class NotifiableSourceProxyBase : SourceProxyBase, INotifiable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(NotifiableSourceProxyBase));

		protected readonly object _lock = new object();

		protected EventHandler valueChanged;

		public virtual event EventHandler ValueChanged
		{
			add
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Combine(valueChanged, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Remove(valueChanged, value);
				}
			}
		}

		public NotifiableSourceProxyBase(object source)
			: base(source)
		{
		}

		protected virtual void RaiseValueChanged()
		{
			try
			{
				if (valueChanged != null)
				{
					valueChanged(this, EventArgs.Empty);
				}
			}
			catch (Exception message)
			{
				if (log.IsWarnEnabled)
				{
					log.Warn(message);
				}
			}
		}
	}
}
