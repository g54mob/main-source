using UnityEngine;

public class SplatTextureReplace : MonoBehaviour
{
	public Terrain terrain;

	[Header("Terrain textures (up to 16)")]
	public Texture2D[] textures;

	public void MakeTerrainTextures()
	{
		if (!Validate())
		{
			return;
		}
		int num = terrain.terrainData.terrainLayers.Length;
		if (textures.Length <= num)
		{
			Debug.Log("Asked to replace " + textures.Length + " textures but terrain already has " + num + ", aborting");
		}
		else
		{
			TerrainLayer[] array = new TerrainLayer[textures.Length];
			for (int i = 0; i < textures.Length; i++)
			{
				array[i] = new TerrainLayer
				{
					diffuseTexture = textures[i]
				};
			}
			terrain.terrainData.terrainLayers = array;
		}
	}

	private bool Validate()
	{
		if (terrain == null)
		{
			Debug.LogError("Terrain is null");
			return false;
		}
		if (textures == null || textures.Length == 0 || textures.Length > 16)
		{
			Debug.LogError("Number of textures must be between 1 and 16 (inclusive)");
			return false;
		}
		for (int i = 0; i < textures.Length; i++)
		{
			string text = SplatImport.ValidateTexture(textures[i], checkFormat: false, checkPow2: false, checkReadable: false);
			if (!string.IsNullOrEmpty(text))
			{
				Debug.LogError("Texture " + (i + 1) + " not valid: " + text);
				return false;
			}
		}
		return true;
	}
}
