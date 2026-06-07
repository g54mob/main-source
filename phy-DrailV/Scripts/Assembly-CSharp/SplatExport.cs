using System.IO;
using UnityEngine;

public class SplatExport : MonoBehaviour
{
	public Terrain terrain;

	[Tooltip("e.g. 'path/to/file' will make files 'path/to/file_01.png' to '...file_04.png'")]
	[Header("Export splatmaps from terrain")]
	public string outputFilePath = "path/to/mysplat";

	public void Export()
	{
		if (terrain == null)
		{
			Debug.LogError("Terrain is null", this);
			return;
		}
		Debug.Log("Exporting " + terrain.terrainData.alphamapTextures.Length + " splats:");
		for (int i = 0; i < terrain.terrainData.alphamapTextures.Length; i++)
		{
			string text = "Assets/" + outputFilePath + "_" + i + ".png";
			Debug.Log("  " + (i + 1) + ": " + text);
			byte[] bytes = terrain.terrainData.alphamapTextures[i].EncodeToPNG();
			File.WriteAllBytes(text, bytes);
		}
	}
}
