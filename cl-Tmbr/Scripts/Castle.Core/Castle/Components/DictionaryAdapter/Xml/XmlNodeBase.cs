using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public abstract class XmlNodeBase : IRealizableSource, IVirtual
	{
		protected Type type;

		private readonly IXmlNode parent;

		private readonly IXmlNamespaceSource namespaces;

		public virtual bool IsReal => true;

		public virtual Type ClrType => type;

		public IXmlNode Parent => parent;

		public IXmlNamespaceSource Namespaces => namespaces;

		public virtual CompiledXPath Path => null;

		public virtual event EventHandler Realized
		{
			add
			{
			}
			remove
			{
			}
		}

		protected XmlNodeBase(IXmlNamespaceSource namespaces, IXmlNode parent)
		{
			if (namespaces == null)
			{
				throw Error.ArgumentNull("namespaces");
			}
			this.namespaces = namespaces;
			this.parent = parent;
		}

		IRealizable<T> IRealizableSource.AsRealizable<T>()
		{
			return this as IRealizable<T>;
		}

		protected virtual void Realize()
		{
		}

		void IVirtual.Realize()
		{
			Realize();
		}
	}
}
