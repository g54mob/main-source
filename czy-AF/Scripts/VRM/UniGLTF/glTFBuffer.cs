using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFBuffer : JsonSerializableBase
	{
		private IBytesBuffer Storage;

		public string uri;

		[JsonSchema(Required = true, Minimum = 1.0)]
		public int byteLength;

		public object extensions;

		public object extras;

		public string name;

		public void OpenStorage(IStorage storage)
		{
			Storage = new ArraySegmentByteBuffer(storage.Get(uri));
		}

		public glTFBuffer()
		{
		}

		public glTFBuffer(IBytesBuffer storage)
		{
			Storage = storage;
		}

		public glTFBufferView Append<T>(T[] array, glBufferTarget target) where T : struct
		{
			return Append(new ArraySegment<T>(array), target);
		}

		public glTFBufferView Append<T>(ArraySegment<T> segment, glBufferTarget target) where T : struct
		{
			glTFBufferView result = Storage.Extend(segment, target);
			byteLength = Storage.GetBytes().Count;
			return result;
		}

		public ArraySegment<byte> GetBytes()
		{
			return Storage.GetBytes();
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (!string.IsNullOrEmpty(uri))
			{
				f.KeyValue(() => uri);
			}
			f.KeyValue(() => byteLength);
		}
	}
}
