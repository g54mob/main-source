using System.Xml;
using System.Xml.Linq;

public static class LEQuickInventoryBuilder
{
	private const string TAG_QUICK_INVENTORY = "quickInventory";

	private const string TAG_TAB = "tab";

	private const string TAG_SLOT = "slot";

	private const string ATTR_ITEM_ID = "item_id";

	private static bool shouldResave;

	public static LEQuickInventoryModel CreateQuickInventory(string filePath, LevelPartCollectionsManager collections)
	{
		shouldResave = false;
		LEQuickInventoryModel lEQuickInventoryModel = new LEQuickInventoryModel();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(filePath);
		QuickInventoryParse(xmlDocument["quickInventory"], lEQuickInventoryModel, collections);
		if (shouldResave)
		{
			SaveXml(lEQuickInventoryModel, filePath);
		}
		return lEQuickInventoryModel;
	}

	private static void QuickInventoryParse(XmlNode xmlInfo, LEQuickInventoryModel newQuickInventoryModel, LevelPartCollectionsManager collections)
	{
		for (int i = 0; i < xmlInfo.ChildNodes.Count; i++)
		{
			XmlNode xmlNode = xmlInfo.ChildNodes[i];
			if (xmlNode.Name != "tab")
			{
				continue;
			}
			newQuickInventoryModel.AddTab();
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				if (!(childNode.Name != "slot"))
				{
					string value = childNode.Attributes["item_id"].Value;
					CustomLevelObjectsModel customLevelObjectsModel = collections.GetCustomLevelObjectsModel(value);
					if (customLevelObjectsModel == null)
					{
						shouldResave = true;
					}
					else
					{
						newQuickInventoryModel.AddItem(i, customLevelObjectsModel);
					}
				}
			}
		}
	}

	public static void SaveXml(LEQuickInventoryModel quickInventoryModel, string path)
	{
		XDocument xDocument = new XDocument();
		XElement xElement = new XElement("quickInventory");
		for (int i = 0; i < quickInventoryModel.TabCount(); i++)
		{
			XElement xElement2 = new XElement("tab");
			foreach (CustomLevelObjectsModel allItem in quickInventoryModel.GetAllItems(i))
			{
				XElement xElement3 = new XElement("slot");
				string value = allItem.Id;
				if (allItem.Origin == CustomLevelObjectsModel.OriginEnum.Part && allItem.LevelObjectModelsCount() > 0)
				{
					value = allItem.GetAllLevelObjectModels()[0].ResourceName;
				}
				xElement3.Add(new XAttribute("item_id", value));
				xElement2.Add(xElement3);
			}
			xElement.Add(xElement2);
		}
		xDocument.Add(xElement);
		xDocument.Save(path);
	}
}
