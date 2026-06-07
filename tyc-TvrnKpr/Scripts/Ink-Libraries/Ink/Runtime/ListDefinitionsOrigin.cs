using System.Collections.Generic;

namespace Ink.Runtime
{
	public class ListDefinitionsOrigin
	{
		private Dictionary<string, ListDefinition> _lists;

		private Dictionary<string, ListValue> _allUnambiguousListValueCache;

		public List<ListDefinition> lists => null;

		public ListDefinitionsOrigin(List<ListDefinition> lists)
		{
		}

		public bool TryListGetDefinition(string name, out ListDefinition def)
		{
			def = null;
			return false;
		}

		public ListValue FindSingleItemListWithName(string name)
		{
			return null;
		}
	}
}
