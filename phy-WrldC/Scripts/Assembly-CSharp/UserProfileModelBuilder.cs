using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EncryptString;

public static class UserProfileModelBuilder
{
	private const string TAG_USER_PROFILE = "user_profile";

	private const string TAG_CAMPAIGN_LEVEL_STATUS = "campaign_level_status";

	private const string TAG_USER_LEVEL_STATUS = "user_level_status";

	private const string TAG_WORKSHOP_LEVEL_STATUS = "workshop_level_status";

	private const string TAG_SANDBOX_LEVEL_STATUS = "sandbox_level_status";

	private const string TAG_TUTORIAL_LEVEL_STATUS = "tutorial_level_status";

	private const string TAG_LEVEL = "level";

	private const string ATTR_ID = "id";

	private const string ATTR_ALL_BOTH_COLLECTABLES = "both";

	private const string ATTR_ALL_GOLD_COLLECTABLES = "gold";

	private const string ATTR_ALL_SILVER_COLLECTABLES = "silver";

	private const string TAG_BEST_TIME = "best_time";

	private const string TAG_LOWEST_BLOCKS = "lowest_blocks";

	private const string TAG_LOWEST_COST = "lowest_cost";

	private const string TAG_LOWEST_WEIGHT = "lowest_weight";

	private const string TAG_BEST_TIME_CREATION_ID = "b_t_c_id";

	private const string TAG_LOWEST_BLOCKS_CREATION_ID = "l_b_c_id";

	private const string TAG_LOWEST_COST_CREATION_ID = "l_c_c_id";

	private const string TAG_LOWEST_WEIGHT_CREATION_ID = "l_w_c_id";

	private const string SUFIX_BOTH_RECORD = "_3";

	private const string SUFIX_GOLD_RECORD = "_2";

	private const string SUFIX_SILVER_RECORD = "_1";

	private const string SUFIX_NONE_RECORD = "";

	public static void SaveXmlFile(UserProfileModel userProfileModel, string filePath, bool isFileEncrypted)
	{
		string text = SaveXDocument(userProfileModel).ToString();
		if (isFileEncrypted)
		{
			text = StringCipher.Encrypt(text, Util.PassPhrase);
		}
		File.WriteAllText(filePath, text, Encoding.UTF8);
	}

	private static XDocument SaveXDocument(UserProfileModel userProfileModel)
	{
		XElement xElement = new XElement("user_profile");
		XElement xElement2 = new XElement("campaign_level_status");
		XElement xElement3 = new XElement("user_level_status");
		XElement xElement4 = new XElement("workshop_level_status");
		XElement xElement5 = new XElement("sandbox_level_status");
		XElement xElement6 = new XElement("tutorial_level_status");
		AddLevelStatus(userProfileModel.CampaignLevelStatusList, xElement2);
		AddLevelStatus(userProfileModel.UserLevelStatusList, xElement3);
		AddLevelStatus(userProfileModel.WorkshopLevelStatusList, xElement4);
		AddLevelStatus(userProfileModel.SandboxLevelStatusList, xElement5);
		AddLevelStatus(userProfileModel.TutorialLevelStatusList, xElement6);
		xElement.Add(xElement2);
		xElement.Add(xElement3);
		xElement.Add(xElement4);
		xElement.Add(xElement5);
		xElement.Add(xElement6);
		XDocument xDocument = new XDocument();
		xDocument.Add(xElement);
		return xDocument;
	}

	private static void AddLevelStatus(GenericCollection<LevelStatus> levelStatusList, XElement xLevelContainerStatus)
	{
		List<LevelStatus> list = new List<LevelStatus>();
		foreach (LevelStatus allItem in levelStatusList.GetAllItems())
		{
			if (allItem.LevelMode == null)
			{
				list.Add(allItem);
				continue;
			}
			XElement xElement = new XElement("level");
			xElement.Add(new XAttribute("id", allItem.GetId()));
			xElement.Add(new XAttribute("both", allItem.AllBothCollectables));
			xElement.Add(new XAttribute("gold", allItem.AllGoldCollectables));
			xElement.Add(new XAttribute("silver", allItem.AllSilverCollectables));
			AddLevelRecords(xElement, allItem.LowestTimeRecords, "best_time", "b_t_c_id");
			AddLevelRecords(xElement, allItem.LowestBlocksRecords, "lowest_blocks", "l_b_c_id");
			AddLevelRecords(xElement, allItem.LowestCostRecords, "lowest_cost", "l_c_c_id");
			AddLevelRecords(xElement, allItem.LowestWeightRecords, "lowest_weight", "l_w_c_id");
			xLevelContainerStatus.Add(xElement);
		}
		list.ForEach(delegate(LevelStatus levelStatus)
		{
			levelStatusList.RemoveItem(levelStatus);
		});
	}

	private static void AddLevelRecords(XElement xLevelStatus, LevelStatus.RecordsValues recordsValues, string recordTag, string recordCreationIdTag)
	{
		AddRecord(recordsValues.BothStarValue, recordsValues.BothCreationId, "_3");
		AddRecord(recordsValues.GoldStarValue, recordsValues.GoldCreationId, "_2");
		AddRecord(recordsValues.SilverStarValue, recordsValues.SilverCreationId, "_1");
		AddRecord(recordsValues.NoneStarValue, recordsValues.NoneCreationId, "");
		void AddRecord(float recordValue, string creationId, string sufix)
		{
			if (recordValue < float.PositiveInfinity)
			{
				XElement xElement = new XElement(recordTag + sufix);
				xElement.Add(recordValue);
				xLevelStatus.Add(xElement);
				if (!string.IsNullOrEmpty(creationId))
				{
					XElement xElement2 = new XElement(recordCreationIdTag + sufix);
					xElement2.Add(creationId);
					xLevelStatus.Add(xElement2);
				}
			}
		}
	}

	public static UserProfileModel LoadXmlFile(string filePath, GenericCollectionModel<LevelModel> levelModelCollection, bool isFileEncrypted)
	{
		XDocument doc = ((!isFileEncrypted) ? XDocument.Load(filePath) : XDocument.Parse(StringCipher.Decrypt(File.ReadAllText(filePath, Encoding.UTF8), Util.PassPhrase)));
		return LoadXDocument(doc, levelModelCollection);
	}

	private static UserProfileModel LoadXDocument(XDocument doc, GenericCollectionModel<LevelModel> levelModelCollection)
	{
		XElement xElement = doc.Element("user_profile");
		XElement xLevelContainerStatus = xElement.Element("campaign_level_status");
		XElement xLevelContainerStatus2 = xElement.Element("user_level_status");
		XElement xLevelContainerStatus3 = xElement.Element("workshop_level_status");
		XElement xLevelContainerStatus4 = xElement.Element("sandbox_level_status");
		XElement xLevelContainerStatus5 = xElement.Element("tutorial_level_status");
		UserProfileModel userProfileModel = new UserProfileModel();
		LoadLevelStatus(levelModelCollection, userProfileModel.CampaignLevelStatusList, xLevelContainerStatus);
		LoadLevelStatus(levelModelCollection, userProfileModel.UserLevelStatusList, xLevelContainerStatus2);
		LoadLevelStatus(levelModelCollection, userProfileModel.WorkshopLevelStatusList, xLevelContainerStatus3);
		LoadLevelStatus(levelModelCollection, userProfileModel.SandboxLevelStatusList, xLevelContainerStatus4);
		LoadLevelStatus(levelModelCollection, userProfileModel.TutorialLevelStatusList, xLevelContainerStatus5);
		return userProfileModel;
	}

	private static void LoadLevelStatus(GenericCollectionModel<LevelModel> levelModelCollection, GenericCollection<LevelStatus> levelStatusList, XElement xLevelContainerStatus)
	{
		if (xLevelContainerStatus == null)
		{
			return;
		}
		foreach (XElement item2 in xLevelContainerStatus.Elements("level"))
		{
			string attributeAsString = item2.GetAttributeAsString("id");
			LevelModel item = levelModelCollection.GetItem(attributeAsString);
			if (item != null)
			{
				LevelStatusFixer(item2);
				bool attributeAsBool = item2.GetAttributeAsBool("both");
				bool attributeAsBool2 = item2.GetAttributeAsBool("gold");
				bool attributeAsBool3 = item2.GetAttributeAsBool("silver");
				float childTagValueAsFloat = item2.GetChildTagValueAsFloat("best_time", float.PositiveInfinity);
				LevelStatus levelStatus = new LevelStatus(item)
				{
					BestTime = childTagValueAsFloat,
					AllBothCollectables = attributeAsBool,
					AllGoldCollectables = attributeAsBool2,
					AllSilverCollectables = attributeAsBool3
				};
				LoadLevelRecords(item2, levelStatus.LowestTimeRecords, "best_time", "b_t_c_id");
				LoadLevelRecords(item2, levelStatus.LowestBlocksRecords, "lowest_blocks", "l_b_c_id");
				LoadLevelRecords(item2, levelStatus.LowestCostRecords, "lowest_cost", "l_c_c_id");
				LoadLevelRecords(item2, levelStatus.LowestWeightRecords, "lowest_weight", "l_w_c_id");
				levelStatusList.AddItem(levelStatus);
			}
		}
	}

	private static void LoadLevelRecords(XElement xLevelStatus, LevelStatus.RecordsValues recordsValues, string tagName, string creationIdTagName)
	{
		recordsValues.BothStarValue = xLevelStatus.GetChildTagValueAsFloat(tagName + "_3", float.PositiveInfinity);
		recordsValues.GoldStarValue = xLevelStatus.GetChildTagValueAsFloat(tagName + "_2", float.PositiveInfinity);
		recordsValues.SilverStarValue = xLevelStatus.GetChildTagValueAsFloat(tagName + "_1", float.PositiveInfinity);
		recordsValues.NoneStarValue = xLevelStatus.GetChildTagValueAsFloat(tagName, float.PositiveInfinity);
		recordsValues.BothCreationId = xLevelStatus.GetChildTagValueAsString(creationIdTagName + "_3");
		recordsValues.GoldCreationId = xLevelStatus.GetChildTagValueAsString(creationIdTagName + "_2");
		recordsValues.SilverCreationId = xLevelStatus.GetChildTagValueAsString(creationIdTagName + "_1");
		recordsValues.NoneCreationId = xLevelStatus.GetChildTagValueAsString(creationIdTagName);
	}

	private static void LevelStatusFixer(XElement xLevelStatus)
	{
		XElement[] array = xLevelStatus.Elements("l_w_c_id").ToArray();
		if (array.Length == 2)
		{
			string value = array[0].Value;
			array[0].Remove();
			XElement xElement = new XElement("l_b_c_id");
			xElement.Add(value);
			xLevelStatus.Add(xElement);
		}
	}
}
