using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace UIScripts.UIReferences.LineagePanel
{
	public struct SpeciesColumn
	{
		public float weight;

		public List<LineageSpeciesNode> nodes;

		public float topY;

		public float bottomY;

		private readonly bool isParent;

		public readonly bool isTemplate;

		public readonly Species rootSpecies;

		public float width => nodes.Max((LineageSpeciesNode n) => n.assignedWidth);

		public SpeciesColumn(LineageSpeciesNode node)
		{
			nodes = new List<LineageSpeciesNode> { node };
			weight = node.weight;
			topY = node.topHeight;
			bottomY = node.bottomHeight;
			isParent = node.children.Count((LineageSpeciesNode s) => s.willRender) > 0;
			isTemplate = !node.hasParent;
			rootSpecies = node.species.rootSpecies;
		}

		public bool CheckToInsertNode(LineageSpeciesNode node)
		{
			if (isParent || isTemplate || node.species.rootSpecies != rootSpecies)
			{
				return false;
			}
			bool flag = true;
			foreach (LineageSpeciesNode node2 in nodes)
			{
				flag &= node.bottomHeight - 25f > node2.topHeight || node.topHeight < node2.bottomHeight - 25f;
			}
			if (!flag)
			{
				return false;
			}
			topY = Mathf.Max(topY, node.topHeight);
			bottomY = Mathf.Min(bottomY, node.bottomHeight);
			weight = Mathf.Max(weight, node.weight);
			nodes.Add(node);
			return true;
		}

		public void SetWidth(float assignedWidth)
		{
			foreach (LineageSpeciesNode node in nodes)
			{
				node.assignedWidth = assignedWidth;
			}
		}

		public void SetPlacement(float posX)
		{
			foreach (LineageSpeciesNode node in nodes)
			{
				node.UpdatePlacement(posX, node.assignedWidth);
			}
		}
	}
}
