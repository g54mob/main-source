using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter
{
	public abstract class VirtualObject<TNode> : IVirtual<TNode>, IVirtual
	{
		private List<IVirtualSite<TNode>> sites;

		public abstract bool IsReal { get; }

		public event EventHandler Realized;

		protected VirtualObject()
		{
		}

		protected VirtualObject(IVirtualSite<TNode> site)
		{
			sites = new List<IVirtualSite<TNode>> { site };
		}

		protected void AddSite(IVirtualSite<TNode> site)
		{
			if (sites != null)
			{
				sites.Add(site);
			}
		}

		void IVirtual<TNode>.AddSite(IVirtualSite<TNode> site)
		{
			AddSite(site);
		}

		protected void RemoveSite(IVirtualSite<TNode> site)
		{
			if (sites != null)
			{
				int num = sites.IndexOf(site);
				if (num != -1)
				{
					sites.RemoveAt(num);
				}
			}
		}

		void IVirtual<TNode>.RemoveSite(IVirtualSite<TNode> site)
		{
			RemoveSite(site);
		}

		public TNode Realize()
		{
			if (TryRealize(out var node))
			{
				if (sites != null)
				{
					int count = sites.Count;
					for (int i = 0; i < count; i++)
					{
						sites[i].OnRealizing(node);
					}
					sites = null;
				}
				OnRealized();
			}
			return node;
		}

		void IVirtual.Realize()
		{
			Realize();
		}

		protected abstract bool TryRealize(out TNode node);

		protected virtual void OnRealized()
		{
			EventHandler eventHandler = this.Realized;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
				this.Realized = null;
			}
		}
	}
}
