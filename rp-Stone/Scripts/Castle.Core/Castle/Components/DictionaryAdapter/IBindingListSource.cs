using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IBindingListSource
	{
		IBindingList AsBindingList { get; }
	}
}
