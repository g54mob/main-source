using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace R3
{
	public interface IReadOnlyBindableReactiveProperty : INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
	{
		object? Value { get; }

		bool IsValidationEnabled { get; }
	}
	public interface IReadOnlyBindableReactiveProperty<T> : IReadOnlyBindableReactiveProperty, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
	{
		new T Value { get; }

		IReadOnlyBindableReactiveProperty<T> EnableValidation();

		IReadOnlyBindableReactiveProperty<T> EnableValidation(Func<T, Exception?> validator);

		IReadOnlyBindableReactiveProperty<T> EnableValidation<TClass>([CallerMemberName] string? propertyName = null);

		IReadOnlyBindableReactiveProperty<T> EnableValidation(Expression<Func<IReadOnlyBindableReactiveProperty<T>?>> selfSelector);

		Observable<T> AsObservable();

		IReadOnlyBindableReactiveProperty<T> ForceValidate();
	}
}
