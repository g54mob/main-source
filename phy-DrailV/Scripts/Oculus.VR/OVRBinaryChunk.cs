using System.IO;

public struct OVRBinaryChunk
{
	public Stream chunkStream;

	public uint chunkLength;

	public long chunkStart;
}
