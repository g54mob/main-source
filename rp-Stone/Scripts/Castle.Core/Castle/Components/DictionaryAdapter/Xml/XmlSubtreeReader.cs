using System;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSubtreeReader : XmlReader
	{
		private readonly string rootLocalName;

		private readonly string rootNamespaceURI;

		private string underlyingNamespaceURI;

		private XmlReader reader;

		public bool IsDisposed => reader == null;

		protected XmlReader Reader
		{
			get
			{
				RequireNotDisposed();
				return reader;
			}
		}

		public override ReadState ReadState
		{
			get
			{
				if (!IsDisposed)
				{
					return reader.ReadState;
				}
				return ReadState.Closed;
			}
		}

		public override int Depth => Reader.Depth;

		public override XmlNodeType NodeType => Reader.NodeType;

		public bool IsAtRootElement
		{
			get
			{
				RequireNotDisposed();
				if (reader.ReadState == ReadState.Interactive && reader.Depth == 0)
				{
					if (reader.NodeType != XmlNodeType.Element)
					{
						return reader.NodeType == XmlNodeType.EndElement;
					}
					return true;
				}
				return false;
			}
		}

		public override bool EOF => Reader.EOF;

		public override string Prefix => Reader.Prefix;

		public override string LocalName
		{
			get
			{
				if (!IsAtRootElement)
				{
					return Reader.LocalName;
				}
				return rootLocalName;
			}
		}

		public override string NamespaceURI
		{
			get
			{
				if (!IsAtRootElement)
				{
					return TranslateNamespaceURI();
				}
				return CaptureNamespaceUri();
			}
		}

		public override string Value => Reader.Value;

		public override bool IsEmptyElement => Reader.IsEmptyElement;

		public override int AttributeCount => Reader.AttributeCount;

		public override string BaseURI => Reader.BaseURI;

		public override XmlNameTable NameTable => Reader.NameTable;

		public XmlSubtreeReader(IXmlNode node, XmlRootAttribute root)
			: this(node, root.ElementName, root.Namespace)
		{
		}

		public XmlSubtreeReader(IXmlNode node, string rootLocalName, string rootNamespaceUri)
		{
			if (node == null)
			{
				throw Error.ArgumentNull("node");
			}
			if (rootLocalName == null)
			{
				throw Error.ArgumentNull("rootLocalName");
			}
			reader = node.ReadSubtree();
			this.rootLocalName = reader.NameTable.Add(rootLocalName);
			rootNamespaceURI = rootNamespaceUri ?? string.Empty;
		}

		protected override void Dispose(bool managed)
		{
			try
			{
				if (managed)
				{
					DisposeReader();
				}
			}
			finally
			{
				base.Dispose(managed);
			}
		}

		private void DisposeReader()
		{
			((IDisposable)Interlocked.Exchange(ref reader, null))?.Dispose();
		}

		private void RequireNotDisposed()
		{
			if (IsDisposed)
			{
				throw Error.ObjectDisposed("XmlSubtreeReader");
			}
		}

		private string CaptureNamespaceUri()
		{
			if (underlyingNamespaceURI == null)
			{
				underlyingNamespaceURI = Reader.NamespaceURI;
			}
			return rootNamespaceURI;
		}

		private string TranslateNamespaceURI()
		{
			string namespaceURI = Reader.NamespaceURI;
			if (!(namespaceURI == underlyingNamespaceURI))
			{
				return namespaceURI;
			}
			return rootNamespaceURI;
		}

		public override bool Read()
		{
			return Reader.Read();
		}

		public override bool MoveToElement()
		{
			return Reader.MoveToElement();
		}

		public override bool MoveToFirstAttribute()
		{
			return Reader.MoveToFirstAttribute();
		}

		public override bool MoveToNextAttribute()
		{
			return Reader.MoveToNextAttribute();
		}

		public override bool MoveToAttribute(string name)
		{
			return Reader.MoveToAttribute(name);
		}

		public override bool MoveToAttribute(string name, string ns)
		{
			return Reader.MoveToAttribute(name, ns);
		}

		public override bool ReadAttributeValue()
		{
			return Reader.ReadAttributeValue();
		}

		public override string GetAttribute(int i)
		{
			return Reader.GetAttribute(i);
		}

		public override string GetAttribute(string name)
		{
			return Reader.GetAttribute(name);
		}

		public override string GetAttribute(string name, string namespaceURI)
		{
			return Reader.GetAttribute(name, namespaceURI);
		}

		public override string LookupNamespace(string prefix)
		{
			return Reader.LookupNamespace(prefix);
		}

		public override void ResolveEntity()
		{
			Reader.ResolveEntity();
		}

		public override void Close()
		{
			if (!IsDisposed)
			{
				reader.Close();
			}
		}
	}
}
