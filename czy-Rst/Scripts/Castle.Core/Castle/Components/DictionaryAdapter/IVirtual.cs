using System;

namespace Castle.Components.DictionaryAdapter
{
	public interface IVirtual
	{
		bool IsReal { get; }

		event EventHandler Realized;

		void Realize();
	}
	public interface IVirtual<T> : IVirtual
	{
		new T Realize();

		void AddSite(IVirtualSite<T> site);

		void RemoveSite(IVirtualSite<T> site);
	}
}
