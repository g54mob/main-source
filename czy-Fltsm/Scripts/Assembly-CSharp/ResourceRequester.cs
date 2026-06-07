using System.Collections.Generic;

public class ResourceRequester
{
	private SubInventory _importInventory;

	private List<ProjectAssignment> _assignments;

	private List<Item> _assignedItems;

	public Inventory Inventory { get; private set; }

	public AssignmentType AssignmentType { get; private set; }

	public int Priority { get; private set; }

	public List<CountedItemProperty> RequestedItems { get; private set; }

	public ResourceRequester(Inventory inventory, AssignmentType assignmentType)
	{
		Inventory = inventory;
		AssignmentType = assignmentType;
		RequestedItems = new List<CountedItemProperty>();
		_assignments = new List<ProjectAssignment>();
		_assignedItems = new List<Item>();
	}

	public void Clear()
	{
		foreach (CountedItemProperty requestedItem in RequestedItems)
		{
			requestedItem.Amount = 0;
		}
	}

	public void RequestItems(ItemProperties itemProperties, int amount)
	{
		foreach (CountedItemProperty requestedItem in RequestedItems)
		{
			if (requestedItem.ItemProperties == itemProperties)
			{
				requestedItem.Amount += amount;
				return;
			}
		}
		RequestedItems.Add(new CountedItemProperty(itemProperties, amount));
	}

	public void RequestItems(CountedItemProperty[] countedItems)
	{
		foreach (CountedItemProperty countedItemProperty in countedItems)
		{
			RequestItems(countedItemProperty.ItemProperties, countedItemProperty.Amount);
		}
	}

	public void AddAssignment(ProjectAssignment assignment)
	{
		_assignments.Add(assignment);
	}

	public void RemoveAssignment(ProjectAssignment assignment)
	{
		_assignments.Remove(assignment);
	}

	private List<Item> ReturnAssignedItems()
	{
		_assignedItems.Clear();
		foreach (ProjectAssignment assignment in _assignments)
		{
			foreach (ItemToHaul item in assignment.ItemsToHaul)
			{
				if (item.State != ItemToHaul.HaulState.Finished)
				{
					_assignedItems.Add(item.Item);
				}
			}
		}
		return _assignedItems;
	}
}
