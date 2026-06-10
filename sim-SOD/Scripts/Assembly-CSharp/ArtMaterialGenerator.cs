using NaughtyAttributes;
using UnityEngine;

public class ArtMaterialGenerator : MonoBehaviour
{
	[Header("Pointers")]
	public string textureSourceDirectory;

	public string materialOutputDirectory;

	public string presetOutputDirectory;

	public ArtPreset presetTemplate;

	public Material materialTemplate;

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateMaterialsAndPresets()
	{
	}

	public static void SetTextureImporterFormat(Texture2D texture, bool isReadable)
	{
	}
}
