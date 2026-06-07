using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Research
{
	public class TechTree
	{
		public const string PartItemPrefix = "Part.";

		public const string XmlElementName = "TechTree";

		private DesignerPartList _designerParts;

		private bool _isStockCareer;

		private Dictionary<string, TechItem> _items = new Dictionary<string, TechItem>();

		private Dictionary<string, TechItemValue> _itemValues = new Dictionary<string, TechItemValue>();

		private bool _logErrors;

		private Dictionary<string, TechNode> _nodeLookup = new Dictionary<string, TechNode>();

		private Dictionary<string, bool> _partTypes = new Dictionary<string, bool>();

		public IReadOnlyCollection<TechNode> AllNodes => _nodeLookup.Values;

		public bool IsStockCareer => _isStockCareer;

		public int NumTechNodesPlayerCanAfford => NumNodesPlayerCanAfford(RootNode);

		public int ResearchPoints { get; set; }

		public TechNode RootNode { get; private set; }

		public TechTree(XElement techTreeXml, DesignerPartList designerParts, bool isStockCareer)
		{
			_logErrors = techTreeXml.GetBoolAttribute("debug");
			List<string> list = new List<string>();
			_isStockCareer = isStockCareer;
			_designerParts = designerParts;
			if (designerParts != null)
			{
				foreach (DesignerPart part in designerParts.Parts)
				{
					if ((part.Mod == null || !isStockCareer) && !part.IsSubassembly)
					{
						TechItem techItem = new TechItem(GetDesignerPartItemId(part), part.Name)
						{
							Description = part.Description + "\n\n<b>Price: " + Units.GetPriceString(part.Price) + "\nMass: " + Units.GetMassString(part.Mass) + "</b>"
						};
						if (part.VariableProperties && !Device.IsMobileBuild)
						{
							techItem.Description += "\n<size=30%>\n</size><size=50%>Base mass and price, subject to change based on the part configuration.</size>";
						}
						techItem.IconType = TechItem.TechItemIconType.File;
						techItem.IconPath = part.CalculateIconPath();
						techItem.Visible = true;
						techItem.ValidationEnabled = part.ShowInDesigner;
						techItem.InitialValue = "false";
						AddItem(techItem);
					}
				}
			}
			foreach (XElement item2 in techTreeXml.Element("Items").Elements("Item"))
			{
				try
				{
					TechItem item = new TechItem(item2);
					AddItem(item);
				}
				catch (Exception ex)
				{
					list.Add(ex.Message);
				}
			}
			foreach (XElement item3 in techTreeXml.Element("Nodes").Elements("Node").ToList())
			{
				try
				{
					TechNode techNode = new TechNode(item3, this);
					_nodeLookup[techNode.Id] = techNode;
					if (RootNode == null)
					{
						RootNode = techNode;
					}
					else if (techNode.Parent == null)
					{
						LogError("Node " + techNode.Id + " has no parent. Only one root node is allowed in a tech tree");
					}
				}
				catch (Exception ex2)
				{
					list.Add($"Failed to load node: {ex2.Message}. Node XML:\n{item3}");
					break;
				}
			}
			Validate(list);
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("TechTree");
			xElement.SetAttributeValue("researchPoints", ResearchPoints);
			foreach (TechNode node in RootNode.GetNodes((TechNode n) => n.Researched))
			{
				xElement.Add(new XElement("Node", new XAttribute("id", node.Id)));
			}
			return xElement;
		}

		public string GetDesignerPartItemId(DesignerPart part)
		{
			return "Part." + part.Name;
		}

		public TechItem GetItem(string id)
		{
			if (_items.TryGetValue(id, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException("Could not find Tech Item with ID " + id);
		}

		public TechItemValue GetItemValue(string itemId)
		{
			if (_itemValues.ContainsKey(itemId))
			{
				return _itemValues[itemId];
			}
			LogError("Could not find Tech Item with ID " + itemId);
			return null;
		}

		public TechNode GetNode(string id)
		{
			if (_nodeLookup.TryGetValue(id, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException("Could not find Node with ID " + id);
		}

		public bool HasItem(string id)
		{
			return _items.ContainsKey(id);
		}

		public bool IsDesignerPartAvailable(DesignerPart designerPart)
		{
			string itemId = "Part." + designerPart.Name;
			return GetItemValue(itemId)?.ValueAsBool ?? false;
		}

		public bool IsPartTypeAvailable(PartType partType)
		{
			if (_partTypes.TryGetValue(partType.Id, out var value))
			{
				return value;
			}
			return false;
		}

		public bool ItemValueExists(string itemId)
		{
			return _itemValues.ContainsKey(itemId);
		}

		public void LoadStatusFromXml(XElement xml)
		{
			if (xml != null)
			{
				ResearchPoints = xml.GetIntAttribute("researchPoints");
				foreach (XElement item in xml.Elements("Node"))
				{
					string value = item.Attribute("id").Value;
					try
					{
						GetNode(value).Researched = true;
					}
					catch (Exception arg)
					{
						LogError($"Could not restore status for node with ID '{value}':\n{arg}");
					}
				}
			}
			else
			{
				ResearchPoints = 0;
			}
			RootNode.Researched = true;
			RefreshItemStatus();
		}

		public void RefreshItemStatus()
		{
			_itemValues.Clear();
			_partTypes.Clear();
			foreach (KeyValuePair<string, TechItem> item in _items)
			{
				TechItemValue itemValue = new TechItemValue(item.Value, item.Value.InitialValue, null, null);
				UpdateTechItemValue(itemValue, null);
			}
			Queue<TechNode> queue = new Queue<TechNode>();
			queue.Enqueue(RootNode);
			while (queue.Count > 0)
			{
				TechNode techNode = queue.Dequeue();
				foreach (TechItemValue item2 in techNode.Items)
				{
					UpdateTechItemValue(item2, techNode);
				}
				foreach (TechNode child in techNode.Children)
				{
					if (child.Researched)
					{
						queue.Enqueue(child);
					}
				}
			}
			CheckTechTreeAchievements();
		}

		public void UnlockAllNodes()
		{
			UnlockNodeTree(RootNode);
			RefreshItemStatus();
		}

		private static bool IsBetter(TechItemValue itemValue, TechItemValue existing)
		{
			if (itemValue.ValueType != existing.ValueType)
			{
				throw new Exception("ValueTypes do not match.");
			}
			if (itemValue.ValueType == TechItemValue.ItemValueType.Float)
			{
				return itemValue.ValueAsFloat > existing.ValueAsFloat;
			}
			if (itemValue.ValueType == TechItemValue.ItemValueType.Bool)
			{
				if (itemValue.ValueAsBool)
				{
					return !existing.ValueAsBool;
				}
				return false;
			}
			throw new Exception($"Item's ValueType is not supported: {itemValue.ValueType}");
		}

		private static void UnlockNodeTree(TechNode root)
		{
			root.Researched = true;
			foreach (TechNode child in root.Children)
			{
				UnlockNodeTree(child);
			}
		}

		private void AddItem(TechItem item)
		{
			_items[item.Id] = item;
		}

		private void CheckTechTreeAchievements()
		{
			if (!IsStockCareer)
			{
				return;
			}
			bool[] array = new bool[7];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = true;
			}
			int num = -1;
			bool flag = false;
			bool flag2 = false;
			foreach (TechNode allNode in AllNodes)
			{
				if (allNode.Researched)
				{
					num++;
					if (allNode.Tier == 1)
					{
						if (allNode.Name == "Backyard Scientist")
						{
							flag = true;
						}
						else if (allNode.Name == "RC Enthusiast")
						{
							flag2 = true;
						}
					}
				}
				else
				{
					array[allNode.Tier] = false;
				}
			}
			if (flag)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeBackyardScientist);
			}
			if (flag2)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeRCEnthusiast);
			}
			if (num >= 10)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeUnlockedNodes1);
			}
			if (num >= 25)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeUnlockedNodes2);
			}
			if (num >= 50)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeUnlockedNodes3);
			}
			if (array[2])
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeTier2);
			}
			if (array[3])
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeTier3);
			}
			if (array[4])
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeTier4);
			}
			if (array[5])
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeTier5);
			}
			if (array[6])
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeTier6);
			}
		}

		private void LogError(string message)
		{
			if (_logErrors)
			{
				Debug.LogError(message);
			}
		}

		private int NumNodesPlayerCanAfford(TechNode node)
		{
			if (!node.Researched && ResearchPoints >= node.Cost)
			{
				return 1;
			}
			if (node.Researched)
			{
				int num = 0;
				{
					foreach (TechNode child in node.Children)
					{
						num += NumNodesPlayerCanAfford(child);
					}
					return num;
				}
			}
			return 0;
		}

		private void UpdateTechItemValue(TechItemValue itemValue, TechNode context)
		{
			try
			{
				bool flag = false;
				string id = itemValue.TechItem.Id;
				if (_itemValues.TryGetValue(id, out var value))
				{
					if (IsBetter(itemValue, value))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					return;
				}
				_itemValues[id] = itemValue;
				string designerPartName = itemValue.TechItem.DesignerPartName;
				if (designerPartName == null)
				{
					return;
				}
				List<DesignerPart> list = _designerParts.Parts.Where((DesignerPart x) => x.Name == designerPartName).ToList();
				if (list.Count > 1)
				{
					list = list.Where((DesignerPart x) => x.ShowInDesigner).ToList();
					if (list.Count > 1)
					{
						LogError("Multiple designer parts listed under the name " + designerPartName + " from node " + context?.Id);
					}
				}
				foreach (PartData part in new Assembly(list.First().AssemblyElement, 15, Game.Instance.PartTypes).Parts)
				{
					if (_partTypes.ContainsKey(part.PartType.Id) && _partTypes[part.PartType.Id] != itemValue.ValueAsBool && !itemValue.ValueAsBool)
					{
						Debug.Log("Duplicate Part Type " + part.PartType.Id + " from part " + designerPartName + " from node " + context?.Id);
					}
					_partTypes[part.PartType.Id] = itemValue.ValueAsBool;
				}
			}
			catch (Exception ex)
			{
				LogError("Failed to update tech item " + itemValue?.TechItem?.Id + " from node " + context?.Id + ": " + ex.ToString());
			}
		}

		private void Validate(List<string> errorMessages)
		{
			try
			{
				Dictionary<string, TechItemValue> itemLookup = new Dictionary<string, TechItemValue>();
				foreach (KeyValuePair<string, TechItem> item2 in _items)
				{
					itemLookup[item2.Key] = null;
				}
				RootNode.GetNodes(delegate(TechNode n)
				{
					if (n.Items.Where((TechItemValue x) => x.Visible).Count() > 0)
					{
						foreach (TechItemValue item3 in n.Items)
						{
							string id = item3.TechItem.Id;
							if (itemLookup[id] != null && itemLookup[id].ValueType != item3.ValueType)
							{
								errorMessages.Add($"Node {n.Id} uses {item3.ValueType} but previous value type was {itemLookup[id].ValueType}");
							}
							itemLookup[id] = item3;
						}
					}
					else
					{
						errorMessages.Add("Node " + n.Id + " has no visible items");
					}
					return false;
				});
				foreach (KeyValuePair<string, TechItemValue> item4 in itemLookup)
				{
					if (item4.Value == null)
					{
						TechItem item = GetItem(item4.Key);
						if (item.ValidationEnabled && (item.InitialValue == "false" || item.InitialValue == "0"))
						{
							errorMessages.Add("Item '" + item4.Key + "' is not referenced by any nodes.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				errorMessages.Add(ex.ToString());
			}
			if (errorMessages.Count > 0)
			{
				string text = string.Join("\n", errorMessages);
				LogError($"Tech Tree has {errorMessages.Count} errors:\n" + text);
			}
		}
	}
}
