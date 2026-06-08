using System.Collections.Generic;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XPathBufferedNodeIterator : XPathNodeIterator
	{
		private readonly IList<XPathNavigator> items;

		private int index;

		public override int CurrentPosition => index;

		public override int Count => items.Count - 1;

		public bool IsEmpty => items.Count == 1;

		public override XPathNavigator Current => items[index];

		public XPathBufferedNodeIterator(XPathNodeIterator iterator)
		{
			items = new List<XPathNavigator>();
			do
			{
				items.Add(iterator.Current.Clone());
			}
			while (iterator.MoveNext());
		}

		private XPathBufferedNodeIterator(XPathBufferedNodeIterator iterator)
		{
			items = iterator.items;
			index = iterator.index;
		}

		public void Reset()
		{
			index = 0;
		}

		public override bool MoveNext()
		{
			if (++index < items.Count)
			{
				return true;
			}
			if (index > items.Count)
			{
				index--;
			}
			return false;
		}

		public void MoveToEnd()
		{
			index = items.Count;
		}

		public override XPathNodeIterator Clone()
		{
			return new XPathBufferedNodeIterator(this);
		}
	}
}
