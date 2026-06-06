using System;

namespace ZLinq.Linq
{
	internal struct FromEnumerableContent
	{
		public object Source;

		public int Index;

		public FromEnumerableContent(object source)
		{
			Index = 0;
			Source = source;
		}

		public void ThrowIfNoEnumerable()
		{
			if (Index < 0)
			{
				Throw();
			}
			static void Throw()
			{
				throw new InvalidOperationException("The enumerable is no longer available.");
			}
		}
	}
}
