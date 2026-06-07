using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential)]
public class LuaVector
{
	public float x;

	public float y;

	public float z;

	public static implicit operator Vector2(LuaVector v)
	{
		return default(Vector2);
	}

	public static implicit operator Vector3(LuaVector v)
	{
		return default(Vector3);
	}

	public static implicit operator Vector2Int(LuaVector v)
	{
		return default(Vector2Int);
	}

	public static implicit operator Vector3Int(LuaVector v)
	{
		return default(Vector3Int);
	}
}
