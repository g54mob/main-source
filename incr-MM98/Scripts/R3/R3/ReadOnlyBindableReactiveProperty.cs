using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace R3
{
	internal sealed class ReadOnlyBindableReactiveProperty<T> : IReadOnlyBindableReactiveProperty<T>, IReadOnlyBindableReactiveProperty, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
	{
		private PropertyChangedEventHandler? propertyChangedCore;

		private EventHandler<DataErrorsChangedEventArgs>? errorsChangedCore;

		public T Value => ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).Value;

		public bool IsValidationEnabled => ((IReadOnlyBindableReactiveProperty)_003Cproperty_003EP).IsValidationEnabled;

		public bool HasErrors => ((INotifyDataErrorInfo)_003Cproperty_003EP).HasErrors;

		object? IReadOnlyBindableReactiveProperty.Value => ((IReadOnlyBindableReactiveProperty)_003Cproperty_003EP).Value;

		public event PropertyChangedEventHandler? PropertyChanged
		{
			add
			{
				propertyChangedCore = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedCore, value);
				((INotifyPropertyChanged)_003Cproperty_003EP).PropertyChanged += PropertyChangedEventHandler;
			}
			remove
			{
				propertyChangedCore = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedCore, value);
				((INotifyPropertyChanged)_003Cproperty_003EP).PropertyChanged -= PropertyChangedEventHandler;
			}
		}

		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged
		{
			add
			{
				errorsChangedCore = (EventHandler<DataErrorsChangedEventArgs>)Delegate.Combine(errorsChangedCore, value);
				((INotifyDataErrorInfo)_003Cproperty_003EP).ErrorsChanged += ErrorsChangedEventHandler;
			}
			remove
			{
				errorsChangedCore = (EventHandler<DataErrorsChangedEventArgs>)Delegate.Remove(errorsChangedCore, value);
				((INotifyDataErrorInfo)_003Cproperty_003EP).ErrorsChanged -= ErrorsChangedEventHandler;
			}
		}

		public ReadOnlyBindableReactiveProperty(BindableReactiveProperty<T> property)
		{
			_003Cproperty_003EP = property;
			base._002Ector();
		}

		private void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
		{
			propertyChangedCore?.Invoke(this, e);
		}

		private void ErrorsChangedEventHandler(object? sender, DataErrorsChangedEventArgs e)
		{
			errorsChangedCore?.Invoke(this, e);
		}

		public Observable<T> AsObservable()
		{
			return ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).AsObservable();
		}

		public void Dispose()
		{
			((IDisposable)_003Cproperty_003EP).Dispose();
		}

		public IReadOnlyBindableReactiveProperty<T> EnableValidation()
		{
			return ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).EnableValidation();
		}

		public IReadOnlyBindableReactiveProperty<T> EnableValidation(Func<T, Exception?> validator)
		{
			return ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).EnableValidation(validator);
		}

		public IReadOnlyBindableReactiveProperty<T> EnableValidation<TClass>([CallerMemberName] string? propertyName = null)
		{
			return ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).EnableValidation<TClass>(propertyName);
		}

		public IReadOnlyBindableReactiveProperty<T> EnableValidation(Expression<Func<IReadOnlyBindableReactiveProperty<T>?>> selfSelector)
		{
			return ((IReadOnlyBindableReactiveProperty<T>)_003Cproperty_003EP).EnableValidation(selfSelector);
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return ((INotifyDataErrorInfo)_003Cproperty_003EP).GetErrors(propertyName);
		}

		public override string? ToString()
		{
			return _003Cproperty_003EP.ToString();
		}

		public IReadOnlyBindableReactiveProperty<T> ForceValidate()
		{
			return _003Cproperty_003EP.ForceValidate();
		}
	}
}
