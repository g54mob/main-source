using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class FurnitureMod : IWorkshopItem
{
	public List<string> Issues;

	public List<GameObject> Furniture;

	public List<GameObject> RoomSegments;

	public List<Mesh> Meshes;

	public List<Texture2D> Textures;

	public List<Material> Materials;

	public List<ValueTuple<string, string, string>> Replacements = new List<ValueTuple<string, string, string>>();

	public bool AnyAutoBounds;

	public bool Temp;

	public FurnitureMod(string root, List<GameObject> furniture, List<GameObject> roomSegments, List<Mesh> meshes, List<Texture2D> textures, List<Material> mats, List<ValueTuple<string, string, string>> replacements, List<string> issues, bool autoBoundsUsed, float loadTime)
	{
		InitMod(root, loadTime);
		Furniture = furniture;
		RoomSegments = roomSegments;
		Meshes = meshes;
		Textures = textures;
		Materials = mats;
		AnyAutoBounds = autoBoundsUsed;
		Issues = issues;
		Replacements = replacements;
	}

	public FurnitureMod(string root)
	{
		InitMod(root, 0f);
		Furniture = new List<GameObject>();
		RoomSegments = new List<GameObject>();
		Meshes = new List<Mesh>();
		Textures = new List<Texture2D>();
		Materials = new List<Material>();
		Issues = new List<string>();
		AnyAutoBounds = false;
		Temp = true;
	}

	public void ClearGPU()
	{
		for (int i = 0; i < Meshes.Count; i++)
		{
			UnityEngine.Object.Destroy(Meshes[i]);
		}
		Meshes.Clear();
		for (int j = 0; j < Materials.Count; j++)
		{
			UnityEngine.Object.Destroy(Materials[j]);
		}
		Materials.Clear();
		for (int k = 0; k < Textures.Count; k++)
		{
			UnityEngine.Object.Destroy(Textures[k]);
		}
		Textures.Clear();
	}

	public override string GetWorkshopType()
	{
		return "Furniture";
	}

	public override string[] GetValidExts()
	{
		return new string[5] { "xml", "png", "obj", "txt", "tyd" };
	}

	public override string[] ExtraTags()
	{
		return Array.Empty<string>();
	}

	public override string GetActualString()
	{
		return base.ItemTitle;
	}

	public override bool PrepareForUpload(out bool hasShownError)
	{
		if (AnyAutoBounds)
		{
			hasShownError = true;
			WindowManager.Instance.ShowMessageBox("AutoBoundsError".Loc(), true, DialogWindow.DialogType.Error);
			return false;
		}
		return base.PrepareForUpload(out hasShownError);
	}

	public override bool GenerateLocalization()
	{
		string text = Path.Combine(base.Root, "Localization");
		if (!Directory.Exists(text))
		{
			Debug.Log(Directory.CreateDirectory(text).Name);
		}
		string text2 = Path.Combine(text, "English");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		List<GameObject> list = new List<GameObject>();
		list.AddRange(Furniture);
		list.AddRange(RoomSegments);
		FurnitureLoader.ExportFurnLocalization(list, Path.Combine(text2, "Furniture.tyd"));
		return true;
	}

	private bool CheckVerts(Mesh m, StringBuilder sb)
	{
		if (m != null && m.vertexCount > 800)
		{
			sb.AppendLine((m.name + " has " + m.vertexCount + " vertices!").FontColor(Color.red));
			return true;
		}
		return false;
	}

	public override string GetExtraInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Issues != null)
		{
			for (int i = 0; i < Issues.Count; i++)
			{
				stringBuilder.AppendLine(Issues[i].FontColor(Color.red));
			}
		}
		foreach (IGrouping<string, GameObject> item in from x in Furniture
			group x by x.GetComponent<Furniture>().Type)
		{
			stringBuilder.AppendLine(item.Count() + " x " + item.Key);
		}
		foreach (IGrouping<string, GameObject> item2 in from x in RoomSegments
			group x by x.GetComponent<RoomSegment>().Type)
		{
			stringBuilder.AppendLine(item2.Count() + " x " + item2.Key);
		}
		return stringBuilder.ToString();
	}

	public override int GetCount()
	{
		return Furniture.Count + RoomSegments.Count;
	}
}
