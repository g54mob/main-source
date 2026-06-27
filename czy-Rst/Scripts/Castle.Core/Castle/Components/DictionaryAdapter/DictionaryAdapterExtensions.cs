using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public static class DictionaryAdapterExtensions
	{
		public static IVirtual AsVirtual(this IDictionaryAdapter dictionaryAdapter)
		{
			return dictionaryAdapter.This.Descriptor?.Getters.OfType<IVirtual>().FirstOrDefault();
		}
	}
}
