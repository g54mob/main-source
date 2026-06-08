using System;

namespace CloudOnce.Internal
{
	public class UnexpectedCollectionElementTypeException : Exception
	{
		public UnexpectedCollectionElementTypeException(string key, Type type)
			: base($"Unexpected type at index {key}, expected {type} ")
		{
		}
	}
}
