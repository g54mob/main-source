namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlPositionComparer
	{
		private struct ComparandIterator
		{
			public IXmlNode Node;

			public XmlName Name;

			public CompiledXPathNode Step;

			public bool MoveNext()
			{
				if (Step == null)
				{
					if (Node == null)
					{
						return Stop();
					}
					return ConsumeNode();
				}
				return ConsumeStep();
			}

			private bool ConsumeNode()
			{
				bool result = true;
				CompiledXPath path = Node.Path;
				if (path != null)
				{
					result = ConsumeFirstStep(path);
				}
				else
				{
					Name = Node.Name;
				}
				Node = Node.Parent;
				return result;
			}

			private bool Stop()
			{
				Name = XmlName.Empty;
				return false;
			}

			private bool ConsumeFirstStep(CompiledXPath path)
			{
				if (!path.IsCreatable)
				{
					return false;
				}
				Step = path.LastStep;
				return ConsumeStep();
			}

			private bool ConsumeStep()
			{
				Name = new XmlName(Step.LocalName, Node.LookupNamespaceUri(Step.Prefix));
				Step = Step.PreviousNode;
				return true;
			}
		}

		public static readonly XmlPositionComparer Instance = new XmlPositionComparer();

		public bool Equals(IXmlNode nodeA, IXmlNode nodeB)
		{
			XmlNameComparer xmlNameComparer = XmlNameComparer.Default;
			ComparandIterator comparandIterator = new ComparandIterator
			{
				Node = nodeA
			};
			ComparandIterator comparandIterator2 = new ComparandIterator
			{
				Node = nodeB
			};
			do
			{
				if (comparandIterator.Node.IsReal && comparandIterator2.Node.IsReal)
				{
					return comparandIterator.Node.UnderlyingPositionEquals(comparandIterator2.Node);
				}
				if (!comparandIterator.MoveNext() || !comparandIterator2.MoveNext())
				{
					return false;
				}
			}
			while (xmlNameComparer.Equals(comparandIterator.Name, comparandIterator2.Name));
			return false;
		}
	}
}
