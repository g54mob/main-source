using System;
using System.Collections.Specialized;

namespace ObservableCollections
{
	public static class SynchronizedViewExtensions
	{
		public static void AttachFilter<T, TView>(this ISynchronizedView<T, TView> source, Func<T, bool> filter)
		{
			source.AttachFilter(new SynchronizedViewValueOnlyFilter<T, TView>(filter));
		}

		public static void AttachFilter<T, TView>(this ISynchronizedView<T, TView> source, Func<T, TView, bool> filter)
		{
			source.AttachFilter(new SynchronizedViewFilter<T, TView>(filter));
		}

		public static bool IsNullFilter<T, TView>(this ISynchronizedViewFilter<T, TView> filter)
		{
			return filter == SynchronizedViewFilter<T, TView>.Null;
		}

		internal static bool IsMatch<T, TView>(this ISynchronizedViewFilter<T, TView> filter, (T, TView) item)
		{
			return filter.IsMatch(item.Item1, item.Item2);
		}

		internal static void InvokeOnAdd<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, (T value, TView view) value, int index)
		{
			collection.InvokeOnAdd(ref filteredCount, ev, ev2, value.value, value.view, index);
		}

		internal static void InvokeOnAdd<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, T value, TView view, int index)
		{
			if (collection.Filter.IsMatch(value, view))
			{
				filteredCount++;
				if (ev != null)
				{
					ev(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Add, isSingleItem: true, (Value: value, View: view), default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), index));
				}
			}
			else
			{
				ev2?.Invoke(RejectedViewChangedAction.Add, index, -1);
			}
		}

		internal static void InvokeOnAddRange<T, TView>(this ISynchronizedView<T, TView> collection, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, ReadOnlySpan<T> values, ReadOnlySpan<TView> views, bool isMatchAll, ReadOnlySpan<bool> matches, int index)
		{
			SynchronizedViewChangedEventArgs<T, TView> e;
			if (isMatchAll)
			{
				if (ev != null)
				{
					ReadOnlySpan<T> newValues = values;
					ReadOnlySpan<TView> newViews = views;
					int newStartingIndex = index;
					e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Add, isSingleItem: false, default((T, TView)), default((T, TView)), newValues, newViews, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), newStartingIndex);
					ev(in e);
				}
				return;
			}
			for (int i = 0; i < matches.Length; i++)
			{
				if (matches[i])
				{
					(T, TView) newItem = (values[i], views[i]);
					if (ev != null)
					{
						int newStartingIndex = index;
						e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Add, isSingleItem: true, newItem, default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), newStartingIndex);
						ev(in e);
					}
				}
				else
				{
					ev2?.Invoke(RejectedViewChangedAction.Add, index, -1);
				}
				index++;
			}
		}

		internal static void InvokeOnRemove<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, (T value, TView view) value, int oldIndex)
		{
			collection.InvokeOnRemove(ref filteredCount, ev, ev2, value.value, value.view, oldIndex);
		}

		internal static void InvokeOnRemove<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, T value, TView view, int oldIndex)
		{
			if (collection.Filter.IsMatch(value, view))
			{
				filteredCount--;
				if (ev != null)
				{
					(T, TView) oldItem = (value, view);
					ev(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Remove, isSingleItem: true, default((T, TView)), oldItem, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, oldIndex));
				}
			}
			else
			{
				ev2?.Invoke(RejectedViewChangedAction.Remove, oldIndex, -1);
			}
		}

		internal static void InvokeOnRemoveRange<T, TView>(this ISynchronizedView<T, TView> collection, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, ReadOnlySpan<T> values, ReadOnlySpan<TView> views, bool isMatchAll, ReadOnlySpan<bool> matches, int index)
		{
			SynchronizedViewChangedEventArgs<T, TView> e;
			if (isMatchAll)
			{
				if (ev != null)
				{
					ReadOnlySpan<T> oldValues = values;
					ReadOnlySpan<TView> oldViews = views;
					int oldStartingIndex = index;
					e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Remove, isSingleItem: false, default((T, TView)), default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), oldValues, oldViews, -1, oldStartingIndex);
					ev(in e);
				}
				return;
			}
			for (int i = 0; i < matches.Length; i++)
			{
				if (matches[i])
				{
					(T, TView) tuple = (values[i], views[i]);
					if (ev != null)
					{
						(T, TView) oldItem = tuple;
						int oldStartingIndex = index;
						e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Remove, isSingleItem: true, default((T, TView)), oldItem, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, oldStartingIndex);
						ev(in e);
					}
				}
				else
				{
					ev2?.Invoke(RejectedViewChangedAction.Remove, index, -1);
				}
			}
		}

		internal static void InvokeOnMove<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, (T value, TView view) value, int index, int oldIndex)
		{
			collection.InvokeOnMove(ref filteredCount, ev, ev2, value.value, value.view, index, oldIndex);
		}

		internal static void InvokeOnMove<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, Action<RejectedViewChangedAction, int, int>? ev2, T value, TView view, int index, int oldIndex)
		{
			if (collection.Filter.IsMatch(value, view))
			{
				if (ev != null)
				{
					ev(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Move, isSingleItem: true, (Value: value, View: view), default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), index, oldIndex));
				}
			}
			else
			{
				ev2?.Invoke(RejectedViewChangedAction.Move, index, oldIndex);
			}
		}

		internal static void InvokeOnReplace<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, (T value, TView view) value, (T value, TView view) oldValue, int index, int oldIndex = -1)
		{
			collection.InvokeOnReplace(ref filteredCount, ev, value.value, value.view, oldValue.value, oldValue.view, index, oldIndex);
		}

		internal static void InvokeOnReplace<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev, T value, TView view, T oldValue, TView oldView, int index, int oldIndex = -1)
		{
			bool flag = collection.Filter.IsMatch(oldValue, oldView);
			bool flag2 = collection.Filter.IsMatch(value, view);
			SynchronizedViewChangedEventArgs<T, TView> e;
			if (flag && flag2)
			{
				if (ev != null)
				{
					(T, TView) newItem = (value, view);
					(T, TView) oldItem = (oldValue, oldView);
					int newStartingIndex = index;
					int oldStartingIndex = ((oldIndex >= 0) ? oldIndex : index);
					e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Replace, isSingleItem: true, newItem, oldItem, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), newStartingIndex, oldStartingIndex);
					ev(in e);
				}
			}
			else if (flag)
			{
				filteredCount--;
				if (ev != null)
				{
					(T, TView) oldItem2 = (value, view);
					int newStartingIndex = oldIndex;
					e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Remove, isSingleItem: true, default((T, TView)), oldItem2, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, newStartingIndex);
					ev(in e);
				}
			}
			else if (flag2)
			{
				filteredCount++;
				if (ev != null)
				{
					(T, TView) newItem2 = (value, view);
					int newStartingIndex = index;
					e = new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Add, isSingleItem: true, newItem2, default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), newStartingIndex);
					ev(in e);
				}
			}
		}

		internal static void InvokeOnReset<T, TView>(this ISynchronizedView<T, TView> collection, ref int filteredCount, NotifyViewChangedEventHandler<T, TView>? ev)
		{
			filteredCount = 0;
			ev?.Invoke(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
		}

		internal static void InvokeOnReverseOrSort<T, TView>(this ISynchronizedView<T, TView> collection, NotifyViewChangedEventHandler<T, TView>? ev, SortOperation<T> sortOperation)
		{
			if (ev != null)
			{
				ev(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true, default((T, TView)), default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, -1, sortOperation));
			}
		}
	}
}
