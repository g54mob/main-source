using System;
using System.Collections.Generic;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class ReorderableList<T> : ReorderableBase
	{
		public List<T> Collection;
	}
}
