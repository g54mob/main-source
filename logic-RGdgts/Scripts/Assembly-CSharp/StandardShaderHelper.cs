using UnityEngine;

public static class StandardShaderHelper
{
	public enum BlendMode
	{
		Opaque = 0,
		Cutout = 1,
		Fade = 2,
		Transparent = 3
	}

	public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
	{
	}
}
