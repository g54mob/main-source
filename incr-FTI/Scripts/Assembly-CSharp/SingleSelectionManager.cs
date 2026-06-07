public class SingleSelectionManager
{
	public delegate void SelectionResponder(EntityId entity, bool nextState);

	public bool allowMultiSelection;

	public readonly SelectionResponder selectionChangeResponder;

	public EntityId singleSelectedElement { get; private set; }

	public SingleSelectionManager(SelectionResponder del)
	{
		selectionChangeResponder = del;
	}

	public void ClearSelection()
	{
		if (singleSelectedElement.type != EntityType.None)
		{
			SetSelectionState(singleSelectedElement, nextState: false);
		}
	}

	public void SetSelectionState(EntityId element, bool nextState)
	{
		if (element.type == EntityType.None)
		{
			return;
		}
		if (nextState)
		{
			if (!singleSelectedElement.Equals(element))
			{
				if (singleSelectedElement.type != EntityType.None && !allowMultiSelection)
				{
					selectionChangeResponder(singleSelectedElement, nextState: false);
				}
				singleSelectedElement = element.GetCopy();
				selectionChangeResponder(singleSelectedElement, nextState: true);
			}
		}
		else
		{
			if (singleSelectedElement.Equals(element))
			{
				singleSelectedElement = EntityId.None;
			}
			selectionChangeResponder(element, nextState: false);
		}
	}
}
