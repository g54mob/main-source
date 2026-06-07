using System.Runtime.InteropServices;

public struct ovrAvatarMeshVertexV2
{
	public float x;

	public float y;

	public float z;

	public float nx;

	public float ny;

	public float nz;

	public float tx;

	public float ty;

	public float tz;

	public float tw;

	public float u;

	public float v;

	public float r;

	public float g;

	public float b;

	public float a;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] blendIndices;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public float[] blendWeights;
}
