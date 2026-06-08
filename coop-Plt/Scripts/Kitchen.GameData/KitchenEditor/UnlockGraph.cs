using System;
using System.Collections.Generic;
using System.Linq;
using KitchenData;
using KitchenEditor.Reference;
using UnityEngine;
using XNode;

namespace KitchenEditor
{
	[CreateAssetMenu(fileName = "UnlockGraph", menuName = "Kitchen/Graphs/Unlock Graph")]
	public class UnlockGraph : NodeGraph
	{
		public void AddData(IGameDataObjectMap map)
		{
			foreach (Node node2 in nodes)
			{
				if (!(node2 is UnlockReferenceNode unlockReferenceNode))
				{
					if (!(node2 is AddMenuItem addMenuItem))
					{
						continue;
					}
					List<NodePort> list = node2.DynamicInputs.ToList();
					if (list.Count != addMenuItem.IngredientUnlocks.Count)
					{
						Debug.LogWarning($"{addMenuItem.Item} has improper number of ingredient unlocks and ports");
					}
					for (int i = 0; i < list.Count; i++)
					{
						NodePort nodePort = list[i];
						Item ingredient = addMenuItem.IngredientUnlocks[i];
						if (nodePort.GetConnection(0)?.node is UnlockReferenceNode { Item: Dish item } && addMenuItem.Item is ItemGroup menuItem)
						{
							map.Get(item).UnlocksIngredients.Add(new Dish.IngredientUnlock
							{
								Ingredient = ingredient,
								MenuItem = menuItem
							});
						}
					}
					continue;
				}
				try
				{
					Unlock unlock = map.Get(unlockReferenceNode.Item);
					foreach (NodePort connection in unlockReferenceNode.GetOutputPort("Unlocks").GetConnections())
					{
						Node node = connection.node;
						if (unlock is Dish dish && node is AddMenuItem addMenuItem2 && node.GetInputPort("UnlockedBy") == connection)
						{
							dish.UnlocksMenuItems.Add(new Dish.MenuItem
							{
								Item = addMenuItem2.Item,
								Phase = addMenuItem2.Phase,
								Weight = addMenuItem2.Weight,
								DynamicMenuType = addMenuItem2.DynamicMenuType,
								DynamicMenuIngredient = addMenuItem2.DynamicMenuIngredient
							});
						}
					}
					foreach (NodePort connection2 in unlockReferenceNode.GetInputPort("Prerequisites").GetConnections())
					{
						if (connection2 != null && connection2.node is UnlockReferenceNode unlockReferenceNode3)
						{
							unlock.Requires.Add(unlockReferenceNode3.Item);
						}
					}
					foreach (NodePort connection3 in unlockReferenceNode.GetInputPort("Blockers").GetConnections())
					{
						if (connection3 != null && connection3.node is UnlockReferenceNode unlockReferenceNode4)
						{
							unlock.BlockedBy.Add(unlockReferenceNode4.Item);
						}
					}
				}
				catch (Exception message)
				{
					Debug.LogError("Failed while building " + unlockReferenceNode.name + " in " + base.name);
					Debug.LogError(message);
				}
			}
		}
	}
}
