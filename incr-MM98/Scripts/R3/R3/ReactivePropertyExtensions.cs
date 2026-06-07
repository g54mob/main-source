using System.Collections.Generic;

namespace R3
{
	public static class ReactivePropertyExtensions
	{
		public static ReadOnlyReactiveProperty<T> ToReadOnlyReactiveProperty<T>(this Observable<T> source, T initialValue = default(T))
		{
			return source.ToReadOnlyReactiveProperty(EqualityComparer<T>.Default, initialValue);
		}

		public static ReadOnlyReactiveProperty<T> ToReadOnlyReactiveProperty<T>(this Observable<T> source, IEqualityComparer<T>? equalityComparer, T initialValue = default(T))
		{
			return new ConnectedReactiveProperty<T>(source, initialValue, equalityComparer);
		}

		public static BindableReactiveProperty<T> ToBindableReactiveProperty<T>(this Observable<T> source, T initialValue = default(T))
		{
			return new BindableReactiveProperty<T>(source, initialValue, EqualityComparer<T>.Default);
		}

		public static BindableReactiveProperty<T> ToBindableReactiveProperty<T>(this Observable<T> source, IEqualityComparer<T>? equalityComparer, T initialValue = default(T))
		{
			return new BindableReactiveProperty<T>(source, initialValue, equalityComparer);
		}

		public static IReadOnlyBindableReactiveProperty<T> ToReadOnlyBindableReactiveProperty<T>(this Observable<T> source, T initialValue = default(T))
		{
			return new ReadOnlyBindableReactiveProperty<T>(new BindableReactiveProperty<T>(source, initialValue, EqualityComparer<T>.Default));
		}

		public static IReadOnlyBindableReactiveProperty<T> ToReadOnlyBindableReactiveProperty<T>(this Observable<T> source, IEqualityComparer<T>? equalityComparer, T initialValue = default(T))
		{
			return new ReadOnlyBindableReactiveProperty<T>(new BindableReactiveProperty<T>(source, initialValue, equalityComparer));
		}
	}
}
