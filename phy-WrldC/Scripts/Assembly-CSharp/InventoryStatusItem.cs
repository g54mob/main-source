public class InventoryStatusItem
{
	public Schematic Schematic { get; set; }

	public int MaxQuantity { get; set; }

	public int CurrentQuantity { get; set; }

	public InventoryStatusItem(Schematic schematic, int maxQuantity)
	{
		Schematic = schematic;
		MaxQuantity = maxQuantity;
		CurrentQuantity = 0;
	}
}
