using System.Threading;
using R3;

namespace ObservableCollections
{
	public static class ObservableDictionaryR3Extensions
	{
		public static Observable<DictionaryAddEvent<TKey, TValue>> ObserveDictionaryAdd<TKey, TValue>(this IReadOnlyObservableDictionary<TKey, TValue> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableDictionaryAdd<TKey, TValue>(source, cancellationToken);
		}

		public static Observable<DictionaryRemoveEvent<TKey, TValue>> ObserveDictionaryRemove<TKey, TValue>(this IReadOnlyObservableDictionary<TKey, TValue> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableDictionaryRemove<TKey, TValue>(source, cancellationToken);
		}

		public static Observable<DictionaryReplaceEvent<TKey, TValue>> ObserveDictionaryReplace<TKey, TValue>(this IReadOnlyObservableDictionary<TKey, TValue> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ObservableDictionaryReplace<TKey, TValue>(source, cancellationToken);
		}
	}
}
