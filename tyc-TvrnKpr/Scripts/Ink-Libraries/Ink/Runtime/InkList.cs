using System.Collections.Generic;

namespace Ink.Runtime
{
	public class InkList : Dictionary<InkListItem, int>
	{
		public List<ListDefinition> origins;

		private List<string> _originNames;

		public ListDefinition originOfMaxItem => null;

		public List<string> originNames => null;

		public KeyValuePair<InkListItem, int> maxItem => default(KeyValuePair<InkListItem, int>);

		public KeyValuePair<InkListItem, int> minItem => default(KeyValuePair<InkListItem, int>);

		public InkList inverse => null;

		public InkList all => null;

		private List<KeyValuePair<InkListItem, int>> orderedItems => null;

		public InkList()
		{
		}

		public InkList(InkList otherList)
		{
		}

		public InkList(string singleOriginListName, Story originStory)
		{
		}

		public InkList(KeyValuePair<InkListItem, int> singleElement)
		{
		}

		public static InkList FromString(string myListItem, Story originStory)
		{
			return null;
		}

		public void AddItem(InkListItem item)
		{
		}

		public void AddItem(string itemName)
		{
		}

		public bool ContainsItemNamed(string itemName)
		{
			return false;
		}

		public void SetInitialOriginName(string initialOriginName)
		{
		}

		public void SetInitialOriginNames(List<string> initialOriginNames)
		{
		}

		public InkList Union(InkList otherList)
		{
			return null;
		}

		public InkList Intersect(InkList otherList)
		{
			return null;
		}

		public InkList Without(InkList listToRemove)
		{
			return null;
		}

		public bool Contains(InkList otherList)
		{
			return false;
		}

		public bool GreaterThan(InkList otherList)
		{
			return false;
		}

		public bool GreaterThanOrEquals(InkList otherList)
		{
			return false;
		}

		public bool LessThan(InkList otherList)
		{
			return false;
		}

		public bool LessThanOrEquals(InkList otherList)
		{
			return false;
		}

		public InkList MaxAsList()
		{
			return null;
		}

		public InkList MinAsList()
		{
			return null;
		}

		public InkList ListWithSubRange(object minBound, object maxBound)
		{
			return null;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
