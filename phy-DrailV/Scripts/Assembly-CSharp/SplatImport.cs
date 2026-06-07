using System;
using UnityEngine;

public class SplatImport : MonoBehaviour
{
	public Terrain terrain;

	[Header("Import (replace) terrain splatmaps")]
	public Texture2D[] splats;

	public void Import()
	{
		if (Validate())
		{
			for (int i = 0; i < splats.Length; i++)
			{
				Replace(splats[i], terrain.terrainData.alphamapTextures[i]);
			}
		}
	}

	private bool Validate()
	{
		if (terrain == null)
		{
			Debug.LogError("Terrain is null");
			return false;
		}
		if (splats == null || splats.Length == 0 || splats.Length > 4)
		{
			Debug.LogError("Number of splat textures must be between 1 and 4 (inclusive)");
			return false;
		}
		for (int i = 0; i < splats.Length; i++)
		{
			string text = ValidateTexture(splats[i], checkFormat: true, checkPow2: true, checkReadable: true);
			if (!string.IsNullOrEmpty(text))
			{
				Debug.LogError("Texture " + (i + 1) + " not valid: " + text);
				return false;
			}
		}
		return true;
	}

	public static string ValidateTexture(Texture2D input, bool checkFormat, bool checkPow2, bool checkReadable)
	{
		if (input == null)
		{
			return "Texture is null";
		}
		if (checkFormat && input.format != TextureFormat.RGBA32 && input.format != TextureFormat.ARGB32 && input.format != TextureFormat.RGB24)
		{
			return "Wrong texture format, must be RGBA 32 bit format - you can fix this by changing texture import settings to Advanced and setting the format manually";
		}
		if (checkPow2 && Mathf.ClosestPowerOfTwo(input.width) != input.width)
		{
			return "Texture dimensions must be a power of two";
		}
		if (checkReadable)
		{
			try
			{
				input.GetPixels();
			}
			catch (Exception)
			{
				return "Error when reading from texture, setting 'Read/Write Enabled' in import settings should fix this";
			}
		}
		return null;
	}

	private void Replace(Texture2D input, Texture2D terrainSplatToReplace)
	{
		Color[] pixels = input.GetPixels();
		terrainSplatToReplace.Resize(input.width, input.height, input.format, hasMipMap: true);
		terrainSplatToReplace.SetPixels(pixels);
		terrainSplatToReplace.Apply();
	}
}
