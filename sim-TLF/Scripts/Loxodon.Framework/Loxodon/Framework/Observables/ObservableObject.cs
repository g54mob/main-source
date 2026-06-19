using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Loxodon.Log;

namespace Loxodon.Framework.Observables
{
	[Serializable]
	public abstract class ObservableObject : INotifyPropertyChanged
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ObservableObject));

		private static readonly PropertyChangedEventArgs NULL_EVENT_ARGS = new PropertyChangedEventArgs(null);

		private static readonly Dictionary<string, PropertyChangedEventArgs> PROPERTY_EVENT_ARGS = new Dictionary<string, PropertyChangedEventArgs>();

		private readonly object _lock = new object();

		private PropertyChangedEventHandler propertyChanged;

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				lock (_lock)
				{
					propertyChanged = (PropertyChangedEventHandler)Delegate.Combine(propertyChanged, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					propertyChanged = (PropertyChangedEventHandler)Delegate.Remove(propertyChanged, value);
				}
			}
		}

		private static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
		{
			if (propertyName == null)
			{
				return NULL_EVENT_ARGS;
			}
			if (PROPERTY_EVENT_ARGS.TryGetValue(propertyName, out var value))
			{
				return value;
			}
			value = new PropertyChangedEventArgs(propertyName);
			PROPERTY_EVENT_ARGS[propertyName] = value;
			return value;
		}

		protected virtual void RaisePropertyChanged(string propertyName = null)
		{
			RaisePropertyChanged(GetPropertyChangedEventArgs(propertyName));
		}

		protected virtual void RaisePropertyChanged(PropertyChangedEventArgs eventArgs)
		{
			try
			{
				if (propertyChanged != null)
				{
					propertyChanged(this, eventArgs);
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Set property '{0}', raise PropertyChanged failure.Exception:{1}", eventArgs.PropertyName, ex);
				}
			}
		}

		protected virtual void RaisePropertyChanged(params PropertyChangedEventArgs[] eventArgs)
		{
			foreach (PropertyChangedEventArgs e in eventArgs)
			{
				try
				{
					if (propertyChanged != null)
					{
						propertyChanged(this, e);
					}
				}
				catch (Exception ex)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Set property '{0}', raise PropertyChanged failure.Exception:{1}", e.PropertyName, ex);
					}
				}
			}
		}

		protected virtual string ParserPropertyName(LambdaExpression propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}
			PropertyInfo obj = ((propertyExpression.Body as MemberExpression) ?? throw new ArgumentException("Invalid argument", "propertyExpression")).Member as PropertyInfo;
			if (obj == null)
			{
				throw new ArgumentException("Argument is not a property", "propertyExpression");
			}
			return obj.Name;
		}

		[Conditional("DEBUG")]
		protected void VerifyPropertyType(Type type)
		{
			if (type.IsValueType)
			{
				log.Debug("Please use Set(field,newValue) instead of Set<T>(field,newValue) to avoid value types being boxed.");
			}
		}

		protected bool Set<T>(ref T field, T newValue, Expression<Func<T>> propertyExpression)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			field = newValue;
			string propertyName = ParserPropertyName(propertyExpression);
			RaisePropertyChanged(propertyName);
			return true;
		}

		protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			field = newValue;
			RaisePropertyChanged(propertyName);
			return true;
		}

		protected bool Set<T>(ref T field, T newValue, PropertyChangedEventArgs eventArgs)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}
			field = newValue;
			RaisePropertyChanged(eventArgs);
			return true;
		}

		[Obsolete]
		protected bool SetValue<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) where T : IEquatable<T>
		{
			if ((field != null && field.Equals(newValue)) || (field == null && newValue == null))
			{
				return false;
			}
			field = newValue;
			RaisePropertyChanged(propertyName);
			return true;
		}

		[Obsolete]
		protected bool SetValue<T>(ref T field, T newValue, PropertyChangedEventArgs eventArgs) where T : IEquatable<T>
		{
			if ((field != null && field.Equals(newValue)) || (field == null && newValue == null))
			{
				return false;
			}
			field = newValue;
			RaisePropertyChanged(eventArgs);
			return true;
		}
	}
}
