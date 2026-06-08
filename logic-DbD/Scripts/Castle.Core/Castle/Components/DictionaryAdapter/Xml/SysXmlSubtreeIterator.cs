using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class SysXmlSubtreeIterator : SysXmlNode, IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		private enum State
		{
			Initial = 0,
			Current = 1,
			End = 2
		}

		private State state;

		public SysXmlSubtreeIterator(IXmlNode parent, IXmlNamespaceSource namespaces)
			: base(namespaces, parent)
		{
			if (parent == null)
			{
				throw Error.ArgumentNull("parent");
			}
			IRealizable<XmlNode> realizable = parent.RequireRealizable<XmlNode>();
			if (realizable.IsReal)
			{
				node = realizable.Value;
			}
			type = typeof(object);
		}

		public bool MoveNext()
		{
			return state switch
			{
				State.Initial => MoveToInitial(), 
				State.Current => MoveToSubsequent(), 
				_ => false, 
			};
		}

		private bool MoveToInitial()
		{
			if (node == null)
			{
				return false;
			}
			state = State.Current;
			return true;
		}

		private bool MoveToSubsequent()
		{
			if (MoveToElement(node.FirstChild))
			{
				return true;
			}
			while (node != null)
			{
				if (MoveToElement(node.NextSibling))
				{
					return true;
				}
				node = node.ParentNode;
			}
			state = State.End;
			return false;
		}

		private bool MoveToElement(XmlNode node)
		{
			while (node != null)
			{
				if (node.NodeType == XmlNodeType.Element)
				{
					return SetNext(node);
				}
				node = node.NextSibling;
			}
			return false;
		}

		private bool SetNext(XmlNode node)
		{
			base.node = node;
			return true;
		}

		public override IXmlNode Save()
		{
			return new SysXmlNode(node, type, base.Namespaces);
		}
	}
}
