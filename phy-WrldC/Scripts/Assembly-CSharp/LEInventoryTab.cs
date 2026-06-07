public class LEInventoryTab : InventoryTabBase
{
	protected override (string icon, string baseId) GetIconAndTooltipTextId(string categoryName)
	{
		string item = "\uf100";
		string item2 = "inventory.blocks";
		switch (categoryName)
		{
		case "Structure":
			item = "\uf292";
			item2 = "le_inventory.structure";
			break;
		case "Object":
			item = "\uf1b2";
			item2 = "le_inventory.object";
			break;
		case "Button":
			item = "\uf0fe";
			item2 = "le_inventory.button";
			break;
		case "Active":
			item = "\uf013";
			item2 = "le_inventory.active";
			break;
		case "User":
			item = "\uf007";
			item2 = "inventory.user";
			break;
		}
		return (icon: item, baseId: item2);
	}
}
