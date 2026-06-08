using System.Collections.Generic;
using KitchenData;
using KitchenEditor.Reference;
using UnityEngine;
using XNode;

namespace KitchenEditor
{
	[CreateAssetMenu(fileName = "ProcessGraph", menuName = "Kitchen/Graphs/Process Graph")]
	public class ProcessGraph : NodeGraph
	{
		public void AddData(IGameDataObjectMap map)
		{
			foreach (Node node in nodes)
			{
				if (node is ItemReferenceNode itemReferenceNode)
				{
					try
					{
						Item item = map.Get(itemReferenceNode.Item);
						foreach (NodePort connection in itemReferenceNode.GetPort("Item").GetConnections())
						{
							if (connection.node is ApplyProcessNode applyProcessNode)
							{
								item.DerivedProcesses.Add(applyProcessNode.Build(map));
							}
						}
					}
					catch (KeyNotFoundException)
					{
						Debug.LogError("Failed to look up " + itemReferenceNode.Item.name);
						throw;
					}
				}
				if (!(node is ItemGroupReferenceNode itemGroupReferenceNode))
				{
					continue;
				}
				ItemGroup itemGroup = map.Get(itemGroupReferenceNode.Item);
				foreach (NodePort connection2 in itemGroupReferenceNode.GetPort("Item").GetConnections())
				{
					if (connection2.node is ApplyProcessNode applyProcessNode2)
					{
						itemGroup.DerivedProcesses.Add(applyProcessNode2.Build(map));
					}
				}
				foreach (NodePort connection3 in itemGroupReferenceNode.GetPort("Sets").GetConnections())
				{
					if (connection3.node is ItemSetNode itemSetNode)
					{
						itemGroup.DerivedSets.Add(itemSetNode.Build(map));
					}
				}
			}
		}
	}
}
