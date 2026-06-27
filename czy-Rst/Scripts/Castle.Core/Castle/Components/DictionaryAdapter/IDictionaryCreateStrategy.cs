using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryCreateStrategy
	{
		object Create(IDictionaryAdapter adapter, Type type, IDictionary dictionary);
	}
}
