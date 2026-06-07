using System.Xml;
using System.Xml.Linq;

public static class QuickInventoryBuilder
{
	private const string TAG_QUICK_INVENTORY = "quickInventory";

	private const string TAG_TAB = "tab";

	private const string TAG_SLOT = "slot";

	private const string ATTR_ITEM_ID = "item_id";

	private static bool shouldResave;

	public static QuickInventoryModel CreateQuickInventory(string levelPath, CreationCollectionsManager collections)
	{
		shouldResave = false;
		QuickInventoryModel quickInventoryModel = new QuickInventoryModel();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(levelPath);
		QuickInventoryParse(xmlDocument["quickInventory"], quickInventoryModel, collections);
		if (shouldResave)
		{
			SaveXml(quickInventoryModel, levelPath);
		}
		return quickInventoryModel;
	}

	public static void PopulateQuickInventoryModel(QuickInventoryModel quickInventoryModel, string levelPath, CreationCollectionsManager collections)
	{
		shouldResave = false;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(levelPath);
		QuickInventoryParse(xmlDocument["quickInventory"], quickInventoryModel, collections);
		if (shouldResave)
		{
			SaveXml(quickInventoryModel, levelPath);
		}
	}

	private static void QuickInventoryParse(XmlNode xmlInfo, QuickInventoryModel newQuickInventoryModel, CreationCollectionsManager collections)
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
					CreationModel creationModel = collections.GetCreationModel(value);
					if (creationModel != null)
					{
						newQuickInventoryModel.AddItem(i, creationModel);
					}
					else
					{
						shouldResave = true;
					}
				}
			}
		}
	}

	public static void SaveXml(QuickInventoryModel quickInventoryModel, string path)
	{
		XDocument xDocument = new XDocument();
		XElement xElement = new XElement("quickInventory");
		for (int i = 0; i < quickInventoryModel.TabCount(); i++)
		{
			XElement xElement2 = new XElement("tab");
			foreach (CreationModel allItem in quickInventoryModel.GetAllItems(i))
			{
				XElement xElement3 = new XElement("slot");
				xElement3.Add(new XAttribute("item_id", allItem.Id));
				xElement2.Add(xElement3);
			}
			xElement.Add(xElement2);
		}
		xDocument.Add(xElement);
		xDocument.Save(path);
	}
}
