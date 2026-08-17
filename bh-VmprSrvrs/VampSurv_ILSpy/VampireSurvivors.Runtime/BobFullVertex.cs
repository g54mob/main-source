using System.Runtime.InteropServices;
using Unity.Mathematics;

[StructLayout((LayoutKind)0, Pack = 2, Size = 32)]
public struct BobFullVertex
{
	public float3 pos;

	public half4 normal;

	public BobVertexData add;
}
