using UnityEngine;
using UnityEngine.Rendering;

public struct LuaPixelData
{
	public int width;

	public int height;

	private ulong ptr;

	private static CommandBuffer command;

	private static uint lastRequestId;

	public Texture2D InstantiateTexture()
	{
		return null;
	}
}
