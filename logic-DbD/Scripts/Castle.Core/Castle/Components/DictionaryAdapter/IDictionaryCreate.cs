using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryCreate
	{
		T Create<T>();

		object Create(Type type);

		T Create<T>(IDictionary dictionary);

		object Create(Type type, IDictionary dictionary);

		T Create<T>(Action<T> init);

		T Create<T>(IDictionary dictionary, Action<T> init);
	}
}
