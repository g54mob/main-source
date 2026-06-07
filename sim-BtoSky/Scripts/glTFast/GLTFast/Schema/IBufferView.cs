namespace GLTFast.Schema
{
	public interface IBufferView
	{
		int Buffer { get; }

		int ByteOffset { get; }

		int ByteLength { get; }

		int ByteStride { get; }
	}
}
