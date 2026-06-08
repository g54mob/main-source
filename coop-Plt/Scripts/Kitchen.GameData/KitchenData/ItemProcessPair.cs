using System;

namespace KitchenData
{
	public readonly struct ItemProcessPair : IEquatable<ItemProcessPair>
	{
		public readonly int Item;

		public readonly int Process;

		public readonly bool OnlyWhenWrapped;

		public ItemProcessPair(int item, int process, bool only_when_wrapped)
		{
			Item = item;
			Process = process;
			OnlyWhenWrapped = only_when_wrapped;
		}

		public bool Equals(ItemProcessPair other)
		{
			if (Item == other.Item && Process == other.Process)
			{
				return OnlyWhenWrapped == other.OnlyWhenWrapped;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((-1269987733 * -1521134295 + Item.GetHashCode()) * -1521134295 + Process.GetHashCode()) * -1521134295 + OnlyWhenWrapped.GetHashCode();
		}
	}
}
