using System.Collections.Generic;
using System.IO;
using Dummiesman;
using UnityEngine;

public class MTLLoader
{
	public List<string> SearchPaths = new List<string>
	{
		"%FileName%_Textures",
		string.Empty
	};

	private FileInfo _objFileInfo;

	public virtual Texture2D TextureLoadFunction(string path, bool isNormalMap)
	{
		foreach (string searchPath in SearchPaths)
		{
			string text = Path.Combine((_objFileInfo != null) ? searchPath.Replace("%FileName%", Path.GetFileNameWithoutExtension(_objFileInfo.Name)) : searchPath, path);
			if (File.Exists(text))
			{
				Texture2D texture2D = ImageLoader.LoadTexture(text);
				if (isNormalMap)
				{
					ImageUtils.ConvertToNormalMap(texture2D);
				}
				return texture2D;
			}
		}
		return null;
	}

	private Texture2D TryLoadTexture(string texturePath, bool normalMap = false)
	{
		texturePath = texturePath.Replace('\\', Path.DirectorySeparatorChar);
		texturePath = texturePath.Replace('/', Path.DirectorySeparatorChar);
		return TextureLoadFunction(texturePath, normalMap);
	}

	public Dictionary<string, Material> Load(Stream input)
	{
		StringReader stringReader = new StringReader(new StreamReader(input).ReadToEnd());
		Dictionary<string, Material> dictionary = new Dictionary<string, Material>();
		Material material = null;
		for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text2 = text.Clean();
				string[] array = text2.Split(' ');
				if (array.Length >= 2 && text2[0] != '#')
				{
					if (array[0] == "newmtl")
					{
						string text3 = text2.Substring(7);
						Material material2 = new Material(Shader.Find("Default"))
						{
							name = text3
						};
						material2.SetFloat("_Metallic", 0.5f);
						material2.SetFloat("_Glossiness", 0f);
						material2.SetInt("_Overwrite", 1);
						dictionary[text3] = material2;
						material = material2;
					}
					else if (!(material == null))
					{
						if (array[0] == "Kd" || array[0] == "kd")
						{
							material.SetColor("_Color", OBJLoaderHelper.ColorFromStrArray(array));
						}
						else if (array[0] == "map_Kd" || array[0] == "map_kd")
						{
							string text4 = text2.Substring(7);
							Texture2D texture2D = TryLoadTexture(text4);
							material.SetTexture("_MainTex", texture2D);
							if (texture2D != null && (texture2D.format == TextureFormat.DXT5 || texture2D.format == TextureFormat.ARGB32))
							{
								OBJLoaderHelper.EnableMaterialTransparency(material);
							}
							if (Path.GetExtension(text4).ToLower() == ".dds")
							{
								material.mainTextureScale = new Vector2(1f, -1f);
							}
						}
					}
				}
			}
		}
		return dictionary;
	}

	public Dictionary<string, Material> Load(string path)
	{
		_objFileInfo = new FileInfo(path);
		SearchPaths.Add(_objFileInfo.Directory.FullName);
		using FileStream input = new FileStream(path, FileMode.Open);
		return Load(input);
	}
}
