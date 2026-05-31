using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class CollectionWrapper<T> : CollectionWrapperBase
	{
		public T[] Value;
	}
}
