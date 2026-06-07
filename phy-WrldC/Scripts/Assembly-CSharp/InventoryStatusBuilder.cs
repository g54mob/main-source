using System.Xml;

public static class InventoryStatusBuilder
{
	private const string TAG_INVENTORY = "inventory";

	private const string TAG_ITEM = "item";

	private const string ATTR_BLOCK_ID = "blockId";

	private const string ATTR_QUANTITY = "quantity";

	public static InventoryStatusModel CreateInventoryStatus(string levelPath, SchematicCollection schematicCollection)
	{
		InventoryStatusModel inventoryStatusModel = new InventoryStatusModel();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(levelPath);
		InventoryParse(inventoryStatusModel, xmlDocument["inventory"], schematicCollection);
		return inventoryStatusModel;
	}

	private static void InventoryParse(InventoryStatusModel newInventoryStatusModel, XmlNode xmlInfo, SchematicCollection schematicCollection)
	{
		foreach (XmlNode childNode in xmlInfo.ChildNodes)
		{
			if (!(childNode.Name != "item"))
			{
				string value = childNode.Attributes["blockId"].Value;
				int maxQuantity = int.Parse(childNode.Attributes["quantity"].Value);
				InventoryStatusItem inventoryStatusItem = new InventoryStatusItem(schematicCollection.GetSchematic(value), maxQuantity);
				newInventoryStatusModel.AddBlockItem(inventoryStatusItem);
			}
		}
	}
}
