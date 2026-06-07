using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BlueprintGroup : IWorkshopItem
{
	public List<BuildingPrefab> Prefabs;

	public static BlueprintGroup LoadBlueprintGroup(string path)
	{
		string[] files = Directory.GetFiles(path, "*.xml");
		if (files.Length != 0)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			List<BuildingPrefab> list = new List<BuildingPrefab>();
			foreach (string path2 in files)
			{
				try
				{
					BuildingPrefab buildingPrefab = BuildingPrefab.FromXMLNode(XMLParser.ParseXML(File.ReadAllText(path2)));
					buildingPrefab.Name = Path.GetFileNameWithoutExtension(path2);
					list.Add(buildingPrefab);
				}
				catch (Exception ex)
				{
					Debug.Log(ex.ToString());
				}
			}
			if (list.Count > 0)
			{
				return new BlueprintGroup(path, list, Time.realtimeSinceStartup - realtimeSinceStartup);
			}
		}
		throw new Exception("Blueprint has no buildings");
	}

	public void RefreshThumbnail()
	{
		if (!base.CanUpload || GetSteamID().HasValue)
		{
			return;
		}
		try
		{
			List<Texture2D> list = new List<Texture2D>();
			if (Prefabs.Count > 0)
			{
				for (int i = 0; i < Prefabs.Count; i++)
				{
					string path = Path.Combine(FolderPath(), Prefabs[i].Name + ".png");
					if (File.Exists(path))
					{
						Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, false);
						texture2D.LoadImage(File.ReadAllBytes(path));
						texture2D.Apply(false);
						list.Add(texture2D);
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			if (list.Count == 1)
			{
				File.WriteAllBytes(Path.Combine(FolderPath(), "Thumbnail.png"), list[0].EncodeToPNG());
				UnityEngine.Object.Destroy(list[0]);
				return;
			}
			Texture2D texture2D2 = new Texture2D(256, 256, TextureFormat.ARGB32, false);
			texture2D2.SetPixels32(new Color32[65536]);
			texture2D2.Apply(false);
			int num = Mathf.CeilToInt(Mathf.Sqrt(list.Count));
			int num2 = 256 / num;
			for (int j = 0; j < list.Count; j++)
			{
				list[j].ScaleDown(num2, num2);
				int num3 = j % num;
				int num4 = j / num;
				Graphics.CopyTexture(list[j], 0, 0, 0, 0, num2, num2, texture2D2, 0, 0, num3 * num2, 256 - num2 - num4 * num2);
				UnityEngine.Object.Destroy(list[j]);
			}
			texture2D2.Apply(false);
			File.WriteAllBytes(Path.Combine(FolderPath(), "Thumbnail.png"), texture2D2.EncodeToPNG());
			UnityEngine.Object.Destroy(texture2D2);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	public bool IsSingleton()
	{
		if (Prefabs.Count == 1)
		{
			if (!Prefabs[0].Name.Equals(base.ItemTitle))
			{
				return Prefabs[0].Name.Equals("Building");
			}
			return true;
		}
		return false;
	}

	public bool CheckToRemove()
	{
		if (Prefabs.Count == 0)
		{
			Directory.Delete(FolderPath(), true);
			GameData.Blueprints.Remove(this);
		}
		return Prefabs.Count == 0;
	}

	public BlueprintGroup(string path, List<BuildingPrefab> prefabs, float loadTime)
	{
		InitMod(path, loadTime);
		Prefabs = prefabs;
	}

	public override string GetWorkshopType()
	{
		return "Blueprint";
	}

	public override string[] GetValidExts()
	{
		return new string[4] { "xml", "png", "txt", "tyd" };
	}

	public override string[] ExtraTags()
	{
		return new string[0];
	}

	public override string ToString()
	{
		return base.ItemTitle;
	}

	public override string GetActualString()
	{
		return base.ItemTitle;
	}

	public override string GetExtraInfo()
	{
		return "Blueprints".Loc() + ": " + Prefabs.Count;
	}

	public override int GetCount()
	{
		return Prefabs.Count;
	}
}
