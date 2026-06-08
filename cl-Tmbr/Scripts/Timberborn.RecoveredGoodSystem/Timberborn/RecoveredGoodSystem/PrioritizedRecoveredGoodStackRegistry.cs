using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Timberborn.PrioritySystem;
using Timberborn.SingletonSystem;

namespace Timberborn.RecoveredGoodSystem
{
	internal class PrioritizedRecoveredGoodStackRegistry : ILoadableSingleton
	{
		private readonly Dictionary<Priority, SortedList<int, RecoveredGoodStack>> _recoveredGoodStacks = new Dictionary<Priority, SortedList<int, RecoveredGoodStack>>();

		private readonly Dictionary<Priority, ReadOnlyCollection<RecoveredGoodStack>> _recoveredGoodStacksAsReadOnly = new Dictionary<Priority, ReadOnlyCollection<RecoveredGoodStack>>();

		public ReadOnlyCollection<RecoveredGoodStack> GetRecoveredGoodStacks(Priority priority)
		{
			return _recoveredGoodStacksAsReadOnly[priority];
		}

		public void Load()
		{
			ImmutableArray<Priority>.Enumerator enumerator = Priorities.Ascending.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Priority current = enumerator.Current;
				SortedList<int, RecoveredGoodStack> sortedList = new SortedList<int, RecoveredGoodStack>();
				_recoveredGoodStacks[current] = sortedList;
				_recoveredGoodStacksAsReadOnly[current] = new ReadOnlyCollection<RecoveredGoodStack>(sortedList.Values);
			}
		}

		public void AddStack(RecoveredGoodStack recoveredGoodStack, Priority priority, int order)
		{
			_recoveredGoodStacks[priority].Add(order, recoveredGoodStack);
		}

		public void RemoveStack(Priority priority, int order)
		{
			_recoveredGoodStacks[priority].Remove(order);
		}
	}
}
