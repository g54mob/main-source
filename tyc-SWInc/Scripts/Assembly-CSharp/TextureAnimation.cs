using UnityEngine;

public static class TextureAnimation
{
	public static int GetHeight(Animation anim, int fps)
	{
		return 1;
	}

	public static int GetWidth(SkinnedMeshRenderer rend)
	{
		return rend.sharedMesh.vertexCount * 2;
	}

	public static Color TransformToPixel(Vector3 d, float range)
	{
		return new Color(Mathf.Clamp01((d.x + range / 2f) / range), Mathf.Clamp01((d.y + range / 2f) / range), Mathf.Clamp01((d.z + range / 2f) / range), 1f);
	}

	public static void CreateAnimationTexture(Animation anim, SkinnedMeshRenderer mesh, int fps, out Texture2D tex, out TextureAnimationData data)
	{
		data = ScriptableObject.CreateInstance<TextureAnimationData>();
		int height = GetHeight(anim, fps);
		int width = GetWidth(mesh);
		tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
	}
}
