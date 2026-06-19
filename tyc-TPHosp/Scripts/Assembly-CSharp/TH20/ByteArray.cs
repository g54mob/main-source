using FullSerializerSave;

namespace TH20
{
	[fsObject(Converter = typeof(ByteArrayConverter))]
	public struct ByteArray
	{
		public byte[] Bytes;
	}
}
