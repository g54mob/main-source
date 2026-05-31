using System;

namespace __Project__.Scripts.Meta
{
	[Serializable]
	public class TypedWrapper<T>
	{
		public string __type;

		public T value;
	}
}
