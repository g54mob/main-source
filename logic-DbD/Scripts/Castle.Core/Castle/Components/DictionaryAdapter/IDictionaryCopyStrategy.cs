using System;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryCopyStrategy
	{
		bool Copy(IDictionaryAdapter source, IDictionaryAdapter target, ref Func<PropertyDescriptor, bool> selector);
	}
}
