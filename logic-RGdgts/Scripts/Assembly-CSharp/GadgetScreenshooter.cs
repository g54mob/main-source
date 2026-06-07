using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GadgetScreenshooter : MonoBehaviour
{
	public struct Result
	{
		public Texture2D colorMap;

		public Texture2D normalMap;

		public Texture2D shaded;

		public void Dispose()
		{
		}
	}

	private static Vector3 screenshootPosition;

	private static Camera screenshootCamera;

	public static GraphicsFormat graphicFormat;

	public const int border = 24;

	private static Material renderShadedMaterial;

	private static Material blitMaterial;

	private static Camera GetScreenShootCamera()
	{
		return null;
	}

	public static Result GetScreenshoot(Gadget gadget, Texture2D colorTexture = null, Texture2D normalTexture = null, Texture2D shadedTexture = null)
	{
		return default(Result);
	}

	public static void GenerateShaded(Texture2D colorTexture, Texture2D normalTexture, Texture2D shadedTexture)
	{
	}

	public static Texture2D GetWorkshopPreview(Texture2D shadedTexture, Texture2D backgroundTexture, int width, int height)
	{
		return null;
	}
}
