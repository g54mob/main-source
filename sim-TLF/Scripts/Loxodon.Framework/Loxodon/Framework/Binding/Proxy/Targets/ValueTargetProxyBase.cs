using System;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public abstract class ValueTargetProxyBase : TargetProxyBase, IModifiable, IObtainable, INotifiable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ValueTargetProxyBase));

		private bool disposed;

		private bool subscribed;

		protected readonly object _lock = new object();

		protected EventHandler valueChanged;

		public event EventHandler ValueChanged
		{
			add
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Combine(valueChanged, value);
					if (valueChanged != null && !subscribed)
					{
						Subscribe();
					}
				}
			}
			remove
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Remove(valueChanged, value);
					if (valueChanged == null && subscribed)
					{
						Unsubscribe();
					}
				}
			}
		}

		public ValueTargetProxyBase(object target)
			: base(target)
		{
		}

		protected void Subscribe()
		{
			try
			{
				if (!subscribed)
				{
					object obj = Target;
					if (obj != null)
					{
						subscribed = true;
						DoSubscribeForValueChange(obj);
					}
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0} Subscribe Exception:{1}", targetName, ex);
				}
			}
		}

		protected virtual void DoSubscribeForValueChange(object target)
		{
		}

		protected void Unsubscribe()
		{
			try
			{
				if (subscribed)
				{
					object obj = Target;
					if (obj != null)
					{
						subscribed = false;
						DoUnsubscribeForValueChange(obj);
					}
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0} Unsubscribe Exception:{1}", targetName, ex);
				}
			}
		}

		protected virtual void DoUnsubscribeForValueChange(object target)
		{
		}

		public abstract object GetValue();

		public abstract TValue GetValue<TValue>();

		public abstract void SetValue<TValue>(TValue value);

		public abstract void SetValue(object value);

		protected void RaiseValueChanged()
		{
			try
			{
				valueChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				log.WarnFormat("{0}", ex);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				disposed = true;
				lock (_lock)
				{
					Unsubscribe();
				}
				base.Dispose(disposing);
			}
		}
	}
}
