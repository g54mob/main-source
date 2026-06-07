public class InventoryTab : InventoryTabBase
{
	protected override (string icon, string baseId) GetIconAndTooltipTextId(string categoryName)
	{
		string item = "\uf100";
		string item2 = "inventory.blocks";
		switch (categoryName)
		{
		case "Structure":
			item = "\uf292";
			item2 = "inventory.structural";
			break;
		case "Brains":
			item = "\uf004";
			item2 = "inventory.brains";
			break;
		case "Motors":
			item = "\uf1b9";
			item2 = "inventory.motors";
			break;
		case "Weapons":
			item = "\uf1e2";
			item2 = "inventory.weapons";
			break;
		case "Util":
			item = "\uf0ad";
			item2 = "inventory.util";
			break;
		case "Debug":
			item = "\uf188";
			item2 = "inventory.debug";
			break;
		case "User":
			item = "\uf007";
			item2 = "inventory.user";
			break;
		}
		return (icon: item, baseId: item2);
	}
}
