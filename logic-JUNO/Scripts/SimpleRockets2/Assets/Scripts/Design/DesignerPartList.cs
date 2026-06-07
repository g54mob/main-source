using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.State;
using Jundroo.ModTools;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerPartList
	{
		private PartTypeList _partTypes;

		public DesignerPart DroodDesignerPart { get; private set; }

		public List<DesignerPart> Parts { get; private set; }

		private DirectoryInfo SubassemblyDirectoy => new DirectoryInfo(Path.Combine(Game.PersistentDataPath, "UserData/Subassemblies/"));

		public DesignerPartList(PartTypeList partTypes)
		{
			_partTypes = partTypes;
			Parts = new List<DesignerPart>();
		}

		public void AddDesignerPart(XElement designerPartElement)
		{
			AddDesignerPart(LoadDesignerPart(designerPartElement, null));
		}

		public void CreateSubassembly(string name, Assembly assembly, ICraftScript craftScript)
		{
			Vector3 zero = Vector3.zero;
			foreach (PartData part in assembly.Parts)
			{
				zero += part.PartScript.Transform.position;
			}
			Dictionary<PartData, PartData> dictionary = new Dictionary<PartData, PartData>();
			Assembly assembly2 = craftScript.Data.Assembly;
			zero /= (float)assembly.Parts.Count;
			foreach (PartData part2 in assembly.Parts)
			{
				part2.PartScript.Transform.position -= zero;
				if (part2.CommandPod != null && !assembly.ContainsPart(part2.CommandPod))
				{
					dictionary[part2] = part2.CommandPod;
					part2.CommandPod = null;
				}
				foreach (PartConnection partConnection in part2.PartConnections)
				{
					assembly.AddPartConnection(partConnection);
				}
				foreach (PartCollision partCollision in assembly2.GetPartCollisions(part2))
				{
					assembly.AddPartCollision(partCollision);
				}
			}
			DesignerPart designerPart = new DesignerPart();
			designerPart.Category = DesignerPartCategories.GetCategory("Sub Assemblies", create: false);
			designerPart.AssemblyElement = assembly.GenerateXml(craftScript.Transform, subAssembly: true, Game.Instance.Settings.Game.Designer.OptimizeCraftXml);
			designerPart.ShowInDesigner = true;
			designerPart.Description = string.Empty;
			designerPart.Name = name;
			designerPart.AssemblyElement.SetAttributeValue("xmlVersion", 15);
			AddSubassemblyPart(designerPart);
			SaveSubassembly(designerPart);
			foreach (KeyValuePair<PartData, PartData> item in dictionary)
			{
				item.Key.CommandPod = item.Value;
			}
			foreach (PartData part3 in assembly.Parts)
			{
				part3.PartScript.Transform.position += zero;
				foreach (PartConnection partConnection2 in part3.PartConnections)
				{
					partConnection2.SetAssembly(assembly2);
				}
				foreach (PartCollision partCollision2 in assembly.GetPartCollisions(part3))
				{
					assembly2.AddPartCollision(partCollision2);
				}
			}
		}

		public void DeleteSubassembly(DesignerPart subassemblyPart)
		{
			Parts.Remove(subassemblyPart);
			try
			{
				File.Delete(subassemblyPart.SubassemblyFilePath);
			}
			catch (Exception)
			{
				Debug.Log("Failed to delete sub assembly: " + subassemblyPart.Name);
			}
		}

		public bool Load()
		{
			foreach (DesignerPart part in Game.Instance.CachedDesignerParts.Parts)
			{
				Parts.Add(part);
			}
			DroodDesignerPart = Parts.Where((DesignerPart x) => x.Name == "Drood").First();
			if (Game.IsCareer)
			{
				FileInfo[] files = new DirectoryInfo(CareerState.CheckOverridePath(Game.Instance.GameState.Career.ResourcesAbsolutePath, "Payloads/")).GetFiles("*.xml");
				foreach (FileInfo fileInfo in files)
				{
					try
					{
						string xml = File.ReadAllText(fileInfo.FullName);
						foreach (DesignerPart item in LoadXml(xml))
						{
							AddDesignerPart(item);
						}
					}
					catch (Exception ex)
					{
						Debug.LogError("Could not load payload part " + fileInfo.FullName + ": " + ex.ToString());
					}
				}
			}
			bool flag = false;
			if (SubassemblyDirectoy.Exists)
			{
				FileInfo[] files = SubassemblyDirectoy.GetFiles("*.xml");
				foreach (FileInfo fileInfo2 in files)
				{
					try
					{
						string xml2 = File.ReadAllText(fileInfo2.FullName);
						foreach (DesignerPart item2 in LoadXml(xml2, "Sub Assemblies"))
						{
							item2.SubassemblyFilePath = fileInfo2.FullName;
							AddSubassemblyPart(item2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						flag = true;
					}
				}
			}
			return !flag;
		}

		public void LoadCachedSubassemblies()
		{
			try
			{
				FileInfo[] files = SubassemblyDirectoy.GetFiles("*.xml");
				foreach (FileInfo fileInfo in files)
				{
					try
					{
						string text = File.ReadAllText(fileInfo.FullName);
						PartLoader.LoadDesignerParts(new string[1] { text }, null);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError("An error occurred loading cached subassembly: " + fileInfo);
					}
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError("An error occurred loading cached subassemblies.");
			}
		}

		public DesignerPart LoadDesignerPart(XElement designerPartElement, ILoadedMod mod)
		{
			DesignerPart designerPart = new DesignerPart();
			designerPart.Mod = mod;
			designerPart.Name = ((string)designerPartElement.Attribute("name")) ?? string.Empty;
			designerPart.Description = ((string)designerPartElement.Attribute("description")) ?? string.Empty;
			designerPart.DisplayOrder = designerPartElement.GetIntAttribute("order");
			designerPart.ShowInDesigner = designerPartElement.GetBoolAttribute("showInDesigner", defaultValue: true);
			designerPart.IconType = Utilities.GetEnumAttribute(designerPartElement, "iconType", DesignerPartIconType.Auto);
			designerPart.IconPath = (string)designerPartElement.Attribute("iconPath");
			designerPart.Category = DesignerPartCategories.GetCategory((string)designerPartElement.Attribute("category"), create: true);
			designerPart.SnapshotDistanceScaler = Utilities.GetFloatAttribute(designerPartElement, "snapshotDistanceScaler", 1f);
			designerPart.SnapshotPartRotation = Utilities.GetVectorAttribute(designerPartElement, "snapshotPartRotation", Vector3.zero);
			designerPart.SnapshotPartOffset = Utilities.GetVectorAttribute(designerPartElement, "snapshotPartOffset", Vector3.zero);
			designerPart.SnapshotRotation = Utilities.GetVectorAttribute(designerPartElement, "snapshotRotation", Vector3.zero);
			designerPart.AssemblyElement = designerPartElement.Element("Assembly");
			if (designerPart.AssemblyElement == null)
			{
				throw new Exception("DesignerPart '" + designerPart.Name + "' is missing the 'Assembly' element.");
			}
			float num = 0f;
			long num2 = 0L;
			List<PartType> list = new List<PartType>((!designerPart.IsSubassembly) ? 1 : 10);
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 15, _partTypes);
			bool flag = false;
			foreach (PartData part in assembly.Parts)
			{
				if (!list.Contains(part.PartType))
				{
					list.Add(part.PartType);
				}
				if (part.Payload?.PayloadId != null)
				{
					dictionary[part.Payload.PayloadId] = true;
				}
				num += part.Mass;
				num2 += part.Price;
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (!modifier.StaticPriceAndMass)
					{
						flag = true;
					}
				}
			}
			designerPart.Mass = num;
			designerPart.Price = num2;
			designerPart.PartTypes = list;
			designerPart.PayloadIds = dictionary.Keys.ToList();
			designerPart.VariableProperties = flag && designerPart.PayloadIds.Count == 0;
			if (assembly.Parts.Count == 0)
			{
				throw new Exception("The designer part '" + designerPart.Name + "' could not be loaded because it contains no parts that could be loaded.");
			}
			return designerPart;
		}

		private void AddDesignerPart(DesignerPart designerPart)
		{
			try
			{
				Parts.Add(designerPart);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
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

		private IEnumerable<DesignerPart> LoadXml(string xml, string category = null)
		{
			List<DesignerPart> list = new List<DesignerPart>();
			XDocument xDocument = XDocument.Parse(xml);
			try
			{
				foreach (XElement item in xDocument.Element("DesignerParts").Elements("DesignerPart"))
				{
					try
					{
						if (category == null || !(category != (string)item?.Attribute("category")))
						{
							list.Add(LoadDesignerPart(item, null));
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						string text = ((string)item?.Attribute("name")) ?? string.Empty;
						Debug.Log("An error occurred trying to load designer part '" + text + "'.");
					}
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError("An error occurred trying to load designer parts.");
			}
			return list;
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
			subassembly.SubassemblyFilePath = Utilities.FindUniqueFilename(SubassemblyDirectoy.FullName, subassembly.Name, ".xml");
			xDocument.Save(subassembly.SubassemblyFilePath);
		}
	}
}
