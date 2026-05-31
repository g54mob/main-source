using System;

namespace MyBox.Internal
{
	[Serializable]
	public class Optional<T> : OptionalParent
	{
		public bool IsSet;

		public T Value;
	}
}
