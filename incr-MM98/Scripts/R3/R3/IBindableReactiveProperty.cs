using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace R3
{
	public interface IBindableReactiveProperty : IReadOnlyBindableReactiveProperty, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
	{
		new object? Value { get; set; }

		void OnNext(object? value);
	}
	public interface IBindableReactiveProperty<T> : IBindableReactiveProperty, IReadOnlyBindableReactiveProperty, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable, IReadOnlyBindableReactiveProperty<T>
	{
		new T Value { get; set; }

		void OnNext(T value);

		new IBindableReactiveProperty<T> EnableValidation();

		new IBindableReactiveProperty<T> EnableValidation(Func<T, Exception?> validator);

		new IBindableReactiveProperty<T> EnableValidation<TClass>([CallerMemberName] string? propertyName = null);

		IBindableReactiveProperty<T> EnableValidation(Expression<Func<IBindableReactiveProperty<T>?>> selfSelector);

		new IBindableReactiveProperty<T> ForceValidate();
	}
}
