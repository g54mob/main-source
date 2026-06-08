using System.Collections.Generic;

public interface IUIModItem : IUIItem
{
	List<IModification> ModificationList { get; }

	void AddModification(IModification mod);
}
