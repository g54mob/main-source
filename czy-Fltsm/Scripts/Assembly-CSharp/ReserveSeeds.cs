using System.Collections;
using System.Collections.Generic;

public class ReserveSeeds : TaskBase
{
	public override TaskType Type => TaskType.ReserverSeeds;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		using ListPool<Item>.List list = ReturnItemsToHaul();
		if (list.Count == 0)
		{
			_assignment.Stop(ProjectFlags.Cancelled);
			yield break;
		}
		while (0 < list.Count && _assignment.AddItemToHaul(list[0], SubInventoryType.Composition))
		{
			list.RemoveAt(0);
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		using ListPool<Item>.List list = ReturnItemsToHaul();
		if (list.Count == 0)
		{
			return ProjectBlocker.SharableEmptyItemList;
		}
		return base.ReturnBlockers(project);
	}

	protected override void OnGUI()
	{
		Header("Reserve Seeds", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Reserve items for decorations.");
	}

	private ListPool<Item>.List ReturnItemsToHaul()
	{
		ListPool<Item>.List list = ListPool<Item>.Get();
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (!buildable.TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable) || buildableExtendable.Decorations.IsNullOrEmpty())
			{
				continue;
			}
			foreach (Decoration decoration in buildableExtendable.Decorations)
			{
				PopulateDecorationItemsToHaul(decoration, list);
			}
		}
		return list;
	}

	private void PopulateDecorationItemsToHaul(Decoration decoration, List<Item> itemsToHaul)
	{
		List<Item> list = decoration.Inventory.ReturnIncomingItems(SubInventoryType.Composition);
		if (list.IsNullOrEmpty())
		{
			return;
		}
		foreach (Item item in list)
		{
			if (item.Project == null)
			{
				itemsToHaul.Add(item);
			}
		}
	}
}
