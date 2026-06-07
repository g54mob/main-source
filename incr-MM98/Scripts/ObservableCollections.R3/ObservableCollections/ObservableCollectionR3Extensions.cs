using System.Collections.Generic;
using System.Threading;
using R3;

namespace ObservableCollections
{
	public static class ObservableCollectionR3Extensions
	{
		public static Observable<CollectionChangedEvent<T>> ObserveChanged<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionChanged<T>(source, cancellationToken);
		}

		public static Observable<CollectionAddEvent<T>> ObserveAdd<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionAdd<T>(source, cancellationToken);
		}

		public static Observable<CollectionRemoveEvent<T>> ObserveRemove<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionRemove<T>(source, cancellationToken);
		}

		public static Observable<CollectionReplaceEvent<T>> ObserveReplace<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionReplace<T>(source, cancellationToken);
		}

		public static Observable<CollectionMoveEvent<T>> ObserveMove<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionMove<T>(source, cancellationToken);
		}

		public static Observable<CollectionResetEvent<T>> ObserveReset<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionReset<T>(source, cancellationToken);
		}

		public static Observable<Unit> ObserveClear<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionClear<T>(source, cancellationToken);
		}

		public static Observable<(int Index, int Count)> ObserveReverse<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionReverse<T>(source, cancellationToken);
		}

		public static Observable<(int Index, int Count, IComparer<T>? Comparer)> ObserveSort<T>(this IObservableCollection<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionSort<T>(source, cancellationToken);
		}

		public static Observable<int> ObserveCountChanged<T>(this IObservableCollection<T> source, bool notifyCurrentCount = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableCollectionCountChanged<T>(source, notifyCurrentCount, cancellationToken);
		}

		public static Observable<RejectedViewChangedEvent> ObserveRejected<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewRejected<T, TView>(source, cancellationToken);
		}

		public static Observable<ViewChangedEvent<T, TView>> ObserveChanged<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewChanged<T, TView>(source, cancellationToken);
		}

		public static Observable<CollectionAddEvent<(T Value, TView View)>> ObserveAdd<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewAdd<T, TView>(source, cancellationToken);
		}

		public static Observable<CollectionRemoveEvent<(T Value, TView View)>> ObserveRemove<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewRemove<T, TView>(source, cancellationToken);
		}

		public static Observable<CollectionReplaceEvent<(T Value, TView View)>> ObserveReplace<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewReplace<T, TView>(source, cancellationToken);
		}

		public static Observable<CollectionMoveEvent<(T Value, TView View)>> ObserveMove<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewMove<T, TView>(source, cancellationToken);
		}

		public static Observable<CollectionResetEvent<T>> ObserveReset<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewReset<T, TView>(source, cancellationToken);
		}

		public static Observable<Unit> ObserveClear<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewClear<T, TView>(source, cancellationToken);
		}

		public static Observable<(int Index, int Count)> ObserveReverse<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewReverse<T, TView>(source, cancellationToken);
		}

		public static Observable<(int Index, int Count, IComparer<T>? Comparer)> ObserveSort<T, TView>(this ISynchronizedView<T, TView> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewSort<T, TView>(source, cancellationToken);
		}

		public static Observable<int> ObserveCountChanged<T, TView>(this ISynchronizedView<T, TView> source, bool notifyCurrentCount = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new SynchronizedViewCountChanged<T, TView>(source, notifyCurrentCount, cancellationToken);
		}
	}
}
