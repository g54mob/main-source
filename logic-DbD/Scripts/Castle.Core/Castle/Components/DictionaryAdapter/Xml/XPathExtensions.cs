using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class XPathExtensions
	{
		public static XPathNavigator CreateNavigatorSafe(this IXPathNavigable source)
		{
			if (source == null)
			{
				throw Error.ArgumentNull("source");
			}
			return source.CreateNavigator();
		}

		public static bool MoveToLastChild(this XPathNavigator navigator)
		{
			if (!navigator.MoveToFirstChild())
			{
				return false;
			}
			while (navigator.MoveToNext())
			{
			}
			return true;
		}

		public static bool MoveToLastAttribute(this XPathNavigator navigator)
		{
			if (!navigator.MoveToFirstAttribute())
			{
				return false;
			}
			while (navigator.MoveToNextAttribute())
			{
			}
			return true;
		}

		public static XPathNavigator GetRootElement(this XPathNavigator navigator)
		{
			navigator = navigator.Clone();
			navigator.MoveToRoot();
			if (navigator.NodeType == XPathNodeType.Root && !navigator.MoveToFirstChild())
			{
				throw Error.InvalidOperation();
			}
			return navigator;
		}

		public static XPathNavigator GetParent(this XPathNavigator navigator)
		{
			navigator = navigator.Clone();
			if (!navigator.MoveToParent())
			{
				throw Error.InvalidOperation();
			}
			return navigator;
		}

		public static void DeleteChildren(this XPathNavigator node)
		{
			while (node.MoveToFirstChild())
			{
				node.DeleteSelf();
			}
			while (node.MoveToFirstAttribute())
			{
				node.DeleteSelf();
			}
		}
	}
}
