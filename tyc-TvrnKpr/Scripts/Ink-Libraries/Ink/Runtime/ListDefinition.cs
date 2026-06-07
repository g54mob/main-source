using System.Collections.Generic;

namespace Ink.Runtime
{
	public class ListDefinition
	{
		private Dictionary<InkListItem, int> _items;

		private string _name;

		private Dictionary<string, int> _itemNameToValues;

		public string name => null;

		public Dictionary<InkListItem, int> items => null;

		public int ValueForItem(InkListItem item)
		{
			return 0;
		}

		public bool ContainsItem(InkListItem item)
		{
			return false;
		}

		public bool ContainsItemWithName(string itemName)
		{
			return false;
		}

		public bool TryGetItemWithValue(int val, out InkListItem item)
		{
			item = default(InkListItem);
			return false;
		}

		public bool TryGetValueForItem(InkListItem item, out int intVal)
		{
			intVal = default(int);
			return false;
		}

		public ListDefinition(string name, Dictionary<string, int> items)
		{
		}
	}
}
