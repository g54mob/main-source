using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Research
{
	public class TechNode
	{
		private List<TechNode> _children = new List<TechNode>();

		private List<TechItemValue> _items = new List<TechItemValue>();

		public IReadOnlyList<TechNode> Children => _children;

		public int Cost { get; set; }

		public string Id { get; set; }

		public bool IsFeatured { get; }

		public IReadOnlyList<TechItemValue> Items => _items;

		public string Name { get; set; }

		public TechNode Parent { get; private set; }

		public string RequiredContractID { get; }

		public bool Researched { get; set; }

		public int Tier { get; private set; }

		public int TierOffset { get; }

		public TechNode(XElement xml, TechTree techTree)
		{
			Id = xml.GetStringAttribute("id");
			Name = xml.GetStringAttribute("name");
			Cost = xml.GetIntAttribute("cost");
			RequiredContractID = xml.GetStringAttribute("contract");
			TierOffset = Mathf.Max(0, xml.GetIntAttribute("tierOffset"));
			IsFeatured = xml.GetBoolAttribute("featured");
			Researched = xml.GetBoolAttribute("researched");
			string stringAttribute = xml.GetStringAttribute("parent");
			if (!string.IsNullOrEmpty(stringAttribute))
			{
				SetParent(techTree, techTree.GetNode(stringAttribute));
			}
			foreach (XElement item2 in xml.Elements("Item"))
			{
				string stringAttribute2 = item2.GetStringAttribute("id");
				bool boolAttribute = item2.GetBoolAttribute("optional");
				if (techTree.HasItem(stringAttribute2))
				{
					TechItemValue item = new TechItemValue(techTree.GetItem(stringAttribute2), item2.GetStringAttribute("value"), item2.GetStringAttribute("valueFormat"), item2.GetBoolAttributeOrNull("visible"), item2.GetFloatAttributeOrNull("partScale"), item2.GetVector3AttributeOrNull("partRotation"));
					_items.Add(item);
				}
				else if (!boolAttribute)
				{
					throw new KeyNotFoundException("Tech Node '" + Id + "' could not find Tech Item with ID '" + stringAttribute2 + "'");
				}
			}
		}

		public List<TechNode> GetNodes(Func<TechNode, bool> predicate)
		{
			List<TechNode> list = new List<TechNode>();
			GetNodesRecursive(predicate, list);
			return list;
		}

		public void SetParent(TechTree techTree, TechNode parent)
		{
			if (Parent != null)
			{
				throw new NotSupportedException("Tech nodes cannot change parents");
			}
			Parent = parent;
			Parent._children.Add(this);
			UpdateTier(techTree);
		}

		private void GetNodesRecursive(Func<TechNode, bool> predicate, List<TechNode> nodes)
		{
			if (predicate(this))
			{
				nodes.Add(this);
			}
			foreach (TechNode child in _children)
			{
				child.GetNodesRecursive(predicate, nodes);
			}
		}

		private void UpdateTier(TechTree techTree)
		{
			int num = -1 + TierOffset;
			for (TechNode parent = Parent; parent != null; parent = parent.Parent)
			{
				num = num + 1 + parent.TierOffset;
			}
			if (techTree.IsStockCareer && (num < -1 || num > 6))
			{
				Debug.LogError("Tech node tier out of range. Did the tech tree change and the tier calculation code not get updated to match?");
			}
			Tier = Math.Max(0, num);
		}
	}
}
