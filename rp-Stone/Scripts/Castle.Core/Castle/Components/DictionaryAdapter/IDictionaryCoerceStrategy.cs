using System;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryCoerceStrategy
	{
		object Coerce(IDictionaryAdapter adapter, Type type);
	}
}
