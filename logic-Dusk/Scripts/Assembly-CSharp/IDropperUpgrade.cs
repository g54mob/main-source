public interface IDropperUpgrade
{
	DropItemType DropType { get; }

	int DropCost { get; }

	void Drop();

	int Pickup();

	void Teleport(Room room);

	void ExternalAdd();

	bool Detonate(bool sendResponseToConsole);
}
