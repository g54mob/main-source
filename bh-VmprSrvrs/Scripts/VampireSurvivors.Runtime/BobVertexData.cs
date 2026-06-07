using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout((LayoutKind)0, Pack = 2, Size = 12)]
public struct BobVertexData
{
	public Color32 color;

	public Vector2 uv;
}
