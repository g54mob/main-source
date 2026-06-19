using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Observables;
using Loxodon.Log;

namespace Loxodon.Framework.ViewModels
{
	public abstract class ViewModelBase : ObservableObject, IViewModel, IDisposable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ViewModelBase));

		private IMessenger messenger;

		public virtual IMessenger Messenger
		{
			get
			{
				return messenger;
			}
			set
			{
				messenger = value;
			}
		}

		public ViewModelBase()
			: this(null)
		{
		}

		public ViewModelBase(IMessenger messenger)
		{
			this.messenger = messenger;
		}

		protected void Broadcast<T>(T oldValue, T newValue, string propertyName)
		{
			try
			{
				Messenger?.Publish(new PropertyChangedMessage<T>(this, oldValue, newValue, propertyName));
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Set property '{0}', broadcast messages failure.Exception:{1}", propertyName, ex);
				}
			}
		}

		protected bool Set<T>(ref T field, T newValue, Expression<Func<T>> propertyExpression, bool broadcast)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			T oldValue = field;
			field = newValue;
			string propertyName = ParserPropertyName(propertyExpression);
			RaisePropertyChanged(propertyName);
			if (broadcast)
			{
				Broadcast(oldValue, newValue, propertyName);
			}
			return true;
		}

		protected bool Set<T>(ref T field, T newValue, string propertyName, bool broadcast)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			T oldValue = field;
			field = newValue;
			RaisePropertyChanged(propertyName);
			if (broadcast)
			{
				Broadcast(oldValue, newValue, propertyName);
			}
			return true;
		}

		protected bool Set<T>(ref T field, T newValue, PropertyChangedEventArgs eventArgs, bool broadcast)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			T oldValue = field;
			field = newValue;
			RaisePropertyChanged(eventArgs);
			if (broadcast)
			{
				Broadcast(oldValue, newValue, eventArgs.PropertyName);
			}
			return true;
		}

		~ViewModelBase()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
