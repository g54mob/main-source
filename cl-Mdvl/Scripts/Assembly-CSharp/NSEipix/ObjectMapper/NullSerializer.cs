using System;

namespace NSEipix.ObjectMapper
{
	public sealed class NullSerializer<T> : ISerializer<T>
	{
		public static NullSerializer<T> Instance { get; } = new NullSerializer<T>();

		private NullSerializer()
		{
		}

		public void Serialize(T obj)
		{
		}

		public T Deserialize()
		{
			return default(T);
		}

		public T[] DeserializeDirectory(string path)
		{
			throw new NotImplementedException();
		}
	}
}
