using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevConsole;
using Tyd;
using UnityEngine;

public class RoomMaterialPack : IWorkshopItem
{
	public RoomMaterialController.WallMaterial[] Materials;

	public static HashSet<string> Categories = new HashSet<string> { "Floor", "Interior", "Exterior", "Roof", "Path" };

	public RoomMaterialPack()
	{
		Materials = new RoomMaterialController.WallMaterial[0];
	}

	private RoomMaterialPack(string root, XMLParser.XMLNode rootNode, bool fromLocal)
	{
		InitMod(root, 0f);
		Materials = rootNode.Children.Select(ParseXML).ToArray();
		if (!fromLocal)
		{
			for (int i = 0; i < Materials.Length; i++)
			{
				Materials[i].FromSteam = true;
			}
		}
	}

	public override string GetExtraInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (IGrouping<string, RoomMaterialController.WallMaterial> item in from x in Materials
			group x by x.Category)
		{
			stringBuilder.AppendLine(item.Count() + " x " + item.Key.Loc());
		}
		return stringBuilder.ToString();
	}

	private RoomMaterialPack(string root, List<TydNode> tyds, bool fromLocal)
	{
		InitMod(root, 0f);
		Materials = tyds.OfType<TydTable>().Select(ParseTYD).ToArray();
		if (!fromLocal)
		{
			for (int i = 0; i < Materials.Length; i++)
			{
				Materials[i].FromSteam = true;
			}
		}
	}

	private RoomMaterialController.WallMaterial ParseTYD(TydCollection node)
	{
		string childValue = node.GetChildValue("Category");
		if (!Categories.Contains(childValue))
		{
			throw new Exception("Got non existent category: " + childValue);
		}
		bool childValue2 = node.GetChildValue("Skirting", false, childValue.Equals("Interior"));
		List<RoomMaterialController.WallMaterial.ColorPreset> list = new List<RoomMaterialController.WallMaterial.ColorPreset>();
		TydList child = node.GetChild<TydList>("Presets");
		if (child != null)
		{
			foreach (TydList item2 in child.Nodes.OfType<TydList>())
			{
				int num = 0;
				RoomMaterialController.WallMaterial.ColorPreset item = default(RoomMaterialController.WallMaterial.ColorPreset);
				foreach (TydString item3 in item2.Nodes.OfType<TydString>())
				{
					Color color;
					if (ColorUtility.TryParseHtmlString("#" + item3.Value.Replace("#", ""), out color))
					{
						if (num == 0)
						{
							item.Color1 = color;
						}
						else
						{
							item.Color2 = color;
						}
						num++;
						if (num > 1)
						{
							break;
						}
					}
				}
				if (num > 0)
				{
					list.Add(item);
				}
			}
		}
		Color forcedSecondaryColor = Color.black;
		string childValue3 = node.GetChildValue("ForcedSecondaryColor", false);
		Color color2;
		if (childValue3 != null && ColorUtility.TryParseHtmlString("#" + childValue3.Replace("#", ""), out color2))
		{
			forcedSecondaryColor = color2;
		}
		return new RoomMaterialController.WallMaterial(node.Name, childValue, GetTexturePath(node, "Base"), GetTexturePath(node, "Bump"), GetTexturePath(node, "Extra"), childValue2, node.GetChildValue("SecondaryColorEnabled", false, false), forcedSecondaryColor, node.GetChildValue("FloorType", false, "Carpet").ToEnum(Room.FloorType.Carpet), list, this);
	}

	private RoomMaterialController.WallMaterial ParseXML(XMLParser.XMLNode node)
	{
		string value = node.GetNode("Category").Value;
		if (!Categories.Contains(value))
		{
			throw new Exception("Got non existent category: " + value);
		}
		return new RoomMaterialController.WallMaterial(node.Name, value, GetTexturePath(node, "Base"), GetTexturePath(node, "Bump"), GetTexturePath(node, "Extra"), node.GetNodeValueOptional<bool>("Skirting") ?? value.Equals("Interior"), false, Color.black, node.GetNodeValue("FloorType", "Carpet").ToEnum(Room.FloorType.Carpet), new List<RoomMaterialController.WallMaterial.ColorPreset>(), this);
	}

	private string GetTexturePath(TydCollection node, string name)
	{
		string childValue = node.GetChildValue(name, false);
		if (childValue != null)
		{
			return Path.Combine(base.Root, childValue);
		}
		return null;
	}

	private string GetTexturePath(XMLParser.XMLNode node, string name)
	{
		string nodeValue = node.GetNodeValue(name);
		if (nodeValue != null)
		{
			return Path.Combine(base.Root, nodeValue);
		}
		return null;
	}

	public static IWorkshopItem LoadPack(string root, bool fromLocal, ref bool errors)
	{
		string text = Path.Combine(root, "materials.xml");
		string text2 = Path.Combine(root, "materials.tyd");
		string text3 = Path.GetFileNameWithoutExtension(root);
		string text4 = null;
		if (File.Exists(text2))
		{
			try
			{
				return new RoomMaterialPack(root, TydFromText.Parse(Utilities.ReadOnlyReadAllText(text2)), fromLocal);
			}
			catch (Exception ex)
			{
				text4 = "Failed loading material pack " + text3 + ":\n" + ex.ToString();
				if (fromLocal)
				{
					Debug.LogException(new Exception(text4));
				}
			}
		}
		else if (File.Exists(text))
		{
			try
			{
				XMLParser.XMLNode xMLNode = XMLParser.ParseXML(Utilities.ReadOnlyReadAllText(text));
				text3 = xMLNode.TryGetAttribute("Name", text3);
				return new RoomMaterialPack(root, xMLNode, fromLocal);
			}
			catch (Exception ex2)
			{
				text4 = "Failed loading material pack " + text3 + ":\n" + ex2.ToString();
				if (fromLocal)
				{
					Debug.LogException(new Exception(text4));
				}
			}
		}
		else
		{
			text4 = "Failed loading material pack " + text3 + " due to missing materials.tyd";
			if (fromLocal)
			{
				Debug.LogError(text4);
			}
		}
		errors = true;
		if (!fromLocal && Options.ConsoleOnError && !DevConsole.Console.isOpen)
		{
			DevConsole.Console.Open();
		}
		return new FailMod("Material", root, text4);
	}

	public override string GetWorkshopType()
	{
		return "Material";
	}

	public override string[] GetValidExts()
	{
		return new string[4] { "png", "xml", "txt", "tyd" };
	}

	public override string[] ExtraTags()
	{
		return Materials.Select((RoomMaterialController.WallMaterial x) => x.Category).Distinct().ToArray();
	}

	public override string GetActualString()
	{
		return base.ItemTitle;
	}

	public override int GetCount()
	{
		return Materials.Length;
	}
}
