using System;
using System.Collections.Generic;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class CollectionWrapperList<T> : CollectionWrapperBase
	{
		public List<T> Value = new List<T>();
	}
}
