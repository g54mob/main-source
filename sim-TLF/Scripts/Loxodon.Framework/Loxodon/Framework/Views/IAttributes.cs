using System;
using System.Collections;

namespace Loxodon.Framework.Views
{
	public interface IAttributes
	{
		object Get(Type type);

		T Get<T>();

		void Add(Type type, object target);

		void Add<T>(T target);

		object Remove(Type type);

		T Remove<T>();

		IEnumerator GetEnumerator();
	}
}
