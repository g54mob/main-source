using System;
using System.Collections.Generic;

public interface IPlacementArea
{
	event Action<SortableBox> BoxAdded;

	event Action<SortableBox> BoxRemoved;

	bool CanBeAdded(SortableBox box);

	void AddBox(SortableBox box);

	void RemoveBox(SortableBox box);

	void Sort();

	IEnumerable<SortableBox> GetBoxes();
}
