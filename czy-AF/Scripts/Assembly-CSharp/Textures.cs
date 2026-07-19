using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
	public static List<TextureData> data = new List<TextureData>();

	public static string folder = "";

	public static void AddTexture(string _name, string _folder, Texture2D _texture, bool _custom = false)
	{
		TextureData textureData = new TextureData();
		textureData.name = _name;
		textureData.folder = _folder;
		textureData.custom = _custom;
		textureData.texture = _texture;
		data.Add(textureData);
	}

	public static TextureData GetTexture(string _name)
	{
		foreach (TextureData datum in data)
		{
			if (datum.name == _name)
			{
				return datum;
			}
		}
		return null;
	}

	public static TextureData GetTexture(Texture _texture)
	{
		foreach (TextureData datum in data)
		{
			if (datum.texture == _texture)
			{
				return datum;
			}
		}
		return null;
	}

	public static TextureData GetTextureCombination(string _path)
	{
		string[] array = _path.Split("/"[0]);
		foreach (TextureData datum in data)
		{
			if (datum.folder == array[0] && datum.name == array[1])
			{
				return datum;
			}
		}
		return null;
	}

	public static void LoadFolder(string f = "")
	{
		folder = f;
		ComponentPages component = PanelSwatchesTexture.textureList.GetComponent<ComponentPages>();
		component.Clear();
		if (folder != "")
		{
			component.AddData(new Hashtable
			{
				{ "name", "/back" },
				{ "folder", true },
				{ "tooltip", "Back" }
			});
			component.SetSize(30f);
		}
		else
		{
			component.SetSize(new Vector2(240f, 30f));
		}
		if (folder == "")
		{
			List<string> list = new List<string>();
			foreach (TextureData datum in data)
			{
				if (!list.Contains(datum.folder))
				{
					list.Add(datum.folder);
					component.AddData(new Hashtable
					{
						{ "name", datum.folder },
						{ "tooltip", datum.folder },
						{ "folder", true }
					});
				}
			}
		}
		foreach (TextureData datum2 in data)
		{
			if (datum2.folder == folder)
			{
				component.AddData(new Hashtable
				{
					{ "name", datum2.name },
					{ "tooltip", datum2.name },
					{ "texture", datum2.texture },
					{ "folder", false }
				});
			}
		}
		component.UpdateDisplay();
	}
}
