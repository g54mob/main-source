using System.Collections.Generic;

namespace Rhizomatic
{
	public class Context
	{
		public Context parent;

		public List<Context> children;

		public List<object> contents;

		public bool disposed { get; private set; }

		public Context()
		{
		}

		public Context(Context parent)
		{
		}

		public Context(Context parent, object content)
		{
		}

		public T Of<T>()
		{
			return default(T);
		}

		public T Put<T>(T content)
		{
			return default(T);
		}

		public T Get<T>()
		{
			return default(T);
		}

		public Context AppendToContext()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
