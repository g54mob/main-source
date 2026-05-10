using System.Xml;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class XmlReaderIterator
	{
		internal class Node
		{
			private XmlReader reader;

			private int depth;

			private string name;

			public string Name => null;

			public string this[string attrib] => null;

			public int Depth => 0;

			public Node(XmlReader reader)
			{
			}

			public SVGPropertySheet GetAttributes()
			{
				return null;
			}

			public SVGFormatException GetException(string message)
			{
				return null;
			}

			public SVGFormatException GetUnsupportedAttribValException(string attrib)
			{
				return null;
			}
		}

		private XmlReader reader;

		private bool currentElementVisited;

		public XmlReaderIterator(XmlReader reader)
		{
		}

		public bool GoToRoot(string tagName)
		{
			return false;
		}

		public Node VisitCurrent()
		{
			return null;
		}

		public bool IsEmptyElement()
		{
			return false;
		}

		public bool GoToNextChild(Node node)
		{
			return false;
		}

		public void SkipCurrentChildTree(Node node)
		{
		}

		public string ReadTextWithinElement()
		{
			return null;
		}
	}
}
