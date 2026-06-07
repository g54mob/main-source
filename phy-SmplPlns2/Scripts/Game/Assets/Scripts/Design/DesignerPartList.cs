using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Mods;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerPartList
	{
		public List<PartCategoryInfo> Categories { get; private set; }

		public List<DesignerPart> Parts { get; private set; }

		private DirectoryInfo SubassemblyDirectoy => new DirectoryInfo(GameData.GetPath("SubAssemblies"));

		public event EventHandler SubassemblyCreated;

		public DesignerPartList()
		{
			Parts = new List<DesignerPart>();
			Categories = new List<PartCategoryInfo>();
		}

		public void CreateSubassembly(string name, Assembly assembly)
		{
			Vector3 zero = Vector3.zero;
			foreach (PartData part in assembly.Parts)
			{
				zero += part.PartScript.transform.position;
			}
			zero /= (float)assembly.Parts.Count;
			foreach (PartData part2 in assembly.Parts)
			{
				part2.PartScript.transform.position -= zero;
			}
			DesignerPart designerPart = new DesignerPart();
			designerPart.Category = "Sub Assemblies";
			designerPart.AssemblyElement = assembly.GenerateXml(createRigidBodyGroups: false);
			designerPart.Description = string.Empty;
			designerPart.Icon = "IconSubAssembly";
			designerPart.Name = name;
			Parts.Add(designerPart);
			SaveSubassembly(designerPart);
			foreach (PartData part3 in assembly.Parts)
			{
				part3.PartScript.transform.position += zero;
			}
			this.SubassemblyCreated?.Invoke(this, new EventArgs());
		}

		public void DeleteSubassembly(DesignerPart subassemblyPart)
		{
			Parts.Remove(subassemblyPart);
			try
			{
				CloudStorageManager.Delete(subassemblyPart.SubassemblyFilePath);
			}
			catch (Exception)
			{
				Debug.Log("Failed to delete sub assembly: " + subassemblyPart.Name);
			}
		}

		public void Load()
		{
			foreach (DesignerPart part in Game.Instance.CachedDesignerParts.Parts)
			{
				Parts.Add(part);
			}
			foreach (PartCategoryInfo category in Game.Instance.CachedDesignerParts.Categories)
			{
				Categories.Add(category);
			}
			UpgradeSubassemblies();
			bool flag = false;
			if (SubassemblyDirectoy.Exists)
			{
				FileInfo[] files = SubassemblyDirectoy.GetFiles("*.xml");
				foreach (FileInfo fileInfo in files)
				{
					try
					{
						string xml = File.ReadAllText(fileInfo.FullName);
						foreach (DesignerPart item in LoadXml(xml))
						{
							item.SubassemblyFilePath = fileInfo.FullName;
							AddSubassemblyPart(item);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						flag = true;
					}
				}
			}
			if (flag)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "One or more subassemblies could not be loaded.";
			}
		}

		public DesignerPart LoadDesignerPart(XElement designerPartElement, LoadedMod mod)
		{
			DesignerPart designerPart = new DesignerPart();
			designerPart.Mod = mod;
			designerPart.Description = designerPartElement.Attribute("description").Value;
			designerPart.Category = designerPartElement.Attribute("category").Value;
			designerPart.StudioScale = designerPartElement.GetFloatAttribute("studioScale", 1f);
			designerPart.StudioOffset = designerPartElement.GetVector3Attribute("studioOffset", Vector3.zero);
			designerPart.StudioRotation = designerPartElement.GetVector3Attribute("studioRotation", Vector3.zero);
			designerPart.IsLegacy = designerPartElement.GetBoolAttribute("legacy");
			designerPart.Header = designerPartElement.Attribute("header")?.Value;
			PartCategoryInfo partCategoryInfo = Categories.FirstOrDefault((PartCategoryInfo x) => x.Name == designerPart.Category);
			if (partCategoryInfo == null && !designerPart.IsLegacy)
			{
				partCategoryInfo = new PartCategoryInfo(designerPart.Category);
				Categories.Add(partCategoryInfo);
			}
			if (mod != null && string.IsNullOrEmpty(partCategoryInfo.IconPath))
			{
				string text = (string)designerPartElement.Attribute("categoryIcon");
				if (!string.IsNullOrEmpty(text))
				{
					partCategoryInfo.IconPath = text;
					partCategoryInfo.Mod = mod;
				}
			}
			designerPart.AssemblyElement = designerPartElement.Element("Assembly");
			if (designerPart.AssemblyElement == null)
			{
				throw new Exception($"DesignerPart is missing Assembly element.");
			}
			designerPart.Name = designerPartElement.Attribute("name").Value;
			designerPart.Icon = designerPartElement.GetStringAttribute("icon", string.Empty);
			if (string.IsNullOrEmpty(designerPart.Icon))
			{
				designerPart.Icon = designerPart.Name;
			}
			float num = 0f;
			float num2 = 0f;
			foreach (PartData part in new Assembly(designerPart.AssemblyElement, 23, CraftLoadContext.Designer).Parts)
			{
				EngineData modifier = part.GetModifier<EngineData>();
				if (modifier != null && modifier.EngineType != "Prop")
				{
					num2 += modifier.Power;
				}
				num += part.EmptyMass;
			}
			designerPart.EngineThrust = num2;
			designerPart.Mass = num;
			return designerPart;
		}

		public void LoadDesignerPartsFile()
		{
			string xml = File.ReadAllText(Game.Instance.GetPathForDocument("DesignerParts.xml"));
			Parts.AddRange(LoadXml(xml));
		}

		public IEnumerable<DesignerPart> LoadXml(string xml)
		{
			List<DesignerPart> list = new List<DesignerPart>();
			XDocument xDocument = XDocument.Parse(xml);
			XElement xElement = null;
			try
			{
				foreach (XElement item in xDocument.Element("DesignerParts").Elements("DesignerPart"))
				{
					xElement = item;
					DesignerPart designerPart = LoadDesignerPart(item, null);
					if (!designerPart.IsLegacy)
					{
						list.Add(designerPart);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Failed to load designer part: " + xElement);
			}
			return list;
		}

		private void AddSubassemblyPart(DesignerPart subassemblyPart)
		{
			for (int i = 0; i < Parts.Count; i++)
			{
				if (subassemblyPart.Name.ToLower().CompareTo(Parts[i].Name.ToLower()) < 0)
				{
					Parts.Insert(i, subassemblyPart);
					return;
				}
			}
			Parts.Add(subassemblyPart);
		}

		private void SaveSubassembly(DesignerPart subassembly)
		{
			if (!SubassemblyDirectoy.Exists)
			{
				SubassemblyDirectoy.Create();
			}
			XDocument xDocument = new XDocument();
			XElement xElement = new XElement("DesignerParts");
			xDocument.Add(xElement);
			XElement content = subassembly.GenerateXml();
			xElement.Add(content);
			string path = Guid.NewGuid().ToString() + ".xml";
			subassembly.SubassemblyFilePath = Path.Combine(SubassemblyDirectoy.FullName, path);
			CloudStorageManager.Save(subassembly.SubassemblyFilePath, xDocument);
		}

		private void UpgradeSubassemblies()
		{
			try
			{
				string pathForDocument = Game.Instance.GetPathForDocument("SubAssemblies.xml");
				if (!File.Exists(pathForDocument))
				{
					return;
				}
				string xml = File.ReadAllText(pathForDocument);
				foreach (DesignerPart item in LoadXml(xml))
				{
					SaveSubassembly(item);
				}
				string pathForDocument2 = Game.Instance.GetPathForDocument("SubAssemblies.xml.bak");
				File.Move(pathForDocument, pathForDocument2);
				Debug.Log("Upgraded SubAssemblies.xml");
			}
			catch (Exception ex)
			{
				Debug.Log("Failed to upgrade subassemblies: " + ex.ToString());
			}
		}
	}
}
