using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportMeshDialog : MonoBehaviour
{
	private class MeshData
	{
		public Mesh mesh;

		public string name;

		public MeshData(Mesh mesh, string name)
		{
		}
	}

	private class TextureData
	{
		public Texture2D texture;

		public string name;

		public TextureData(Texture2D texture, string name)
		{
		}
	}

	public InputField nameInputField;

	public Text message;

	public Toggle prefixName;

	public Toggle colorsFromMaterials;

	private List<MeshData> meshes;

	private List<TextureData> textures;

	private static int MAX_TEXTURE_SIZE;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OnAdd()
	{
	}

	public void LoadModelFromFile()
	{
	}

	private void DestroyMeshes()
	{
	}

	private void DestroyTextures()
	{
	}

	private void CreateMeshAndTextureFromModel(string filePath)
	{
	}

	public static Texture2D GetReadableAndSizedTexture(Texture2D tex, bool duplicate)
	{
		return null;
	}

	private void SmashSubmeshes(Mesh mesh, Material[] materials)
	{
	}

	private void ExtractMeshAndTexture(GameObject go, out int meshCount, out int textureCount)
	{
		meshCount = default(int);
		textureCount = default(int);
	}

	private static Texture2D DuplicateTexture(Texture2D source)
	{
		return null;
	}

	private void CreateMeshAndTextureFromVox(string filePath)
	{
	}

	private void LoadModelFileBrowserOutput(string path)
	{
	}

	private void LoadVoxFileBrowserOutput(string[] paths)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
