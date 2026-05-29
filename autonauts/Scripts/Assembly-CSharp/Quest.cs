using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class Quest
{
	public enum ID
	{
		TutorialBasics = 0,
		TutorialBotWorkshop = 1,
		TutorialFoundation = 2,
		TutorialLumber = 3,
		TutorialRobotics = 4,
		TutorialRobotics2 = 5,
		TutorialRobotics3 = 6,
		TutorialScripting = 7,
		TutorialScripting2 = 8,
		TutorialScripting3 = 9,
		TutorialScripting4 = 10,
		TutorialScripting5 = 11,
		TutorialStart = 12,
		TutorialTeaching = 13,
		TutorialTeaching2 = 14,
		TutorialTeaching3 = 15,
		TutorialTools = 16,
		TutorialTools2 = 17,
		TutorialTools3 = 18,
		TutorialBerries = 19,
		TutorialMushrooms = 20,
		AcademyBasics = 21,
		AcademyForestry = 22,
		AcademyBaking = 23,
		AcademyBeekeeping = 24,
		AcademyColonisation = 25,
		AcademyColonisation2 = 26,
		AcademyColonisation3 = 27,
		AcademyColonisation4 = 28,
		AcademyColonisation5 = 29,
		AcademyColonisation6 = 30,
		AcademyColonisation7 = 31,
		AcademyColonisation8 = 32,
		AcademyConstruction = 33,
		AcademyCooking = 34,
		AcademyFarmingCereal = 35,
		AcademyFarmingDairy = 36,
		AcademyFarmingFruit = 37,
		AcademyFarmingFruit2 = 38,
		AcademyFarmingFruit3 = 39,
		AcademyFarmingMushrooms = 40,
		AcademyFarmingPoultry = 41,
		AcademyFarmingSheep = 42,
		AcademyFarmingVegetables = 43,
		AcademyFarmingVegetables2 = 44,
		AcademyFishing = 45,
		AcademyFishing2 = 46,
		AcademyFlowers = 47,
		AcademyForestry2 = 48,
		AcademyForestry3 = 49,
		AcademyLeeching = 50,
		AcademyLumber2 = 51,
		AcademyMasonry = 52,
		AcademyMetal = 53,
		AcademyMetal2 = 54,
		AcademyMining = 55,
		AcademyMining2 = 56,
		AcademyPottery = 57,
		AcademyPower = 58,
		AcademyPower2 = 59,
		AcademyRobotics = 60,
		AcademyRobotics2 = 61,
		AcademyScience = 62,
		AcademySilk = 63,
		AcademyTextiles = 64,
		AcademyTools = 65,
		AcademyTransportation = 66,
		AcademyTransportation2 = 67,
		ResearchLevel1 = 68,
		ResearchLevel2 = 69,
		ResearchLevel3 = 70,
		ResearchLevel4 = 71,
		ResearchLevel5 = 72,
		ResearchLevel6 = 73,
		ResearchBees = 74,
		ResearchCommunication = 75,
		ResearchCommunication2 = 76,
		ResearchConstruction = 77,
		ResearchConstruction2 = 78,
		ResearchConstructionCrude = 79,
		ResearchConstructionCrude2 = 80,
		ResearchConstructionCrude3 = 81,
		ResearchConstructionParts = 82,
		ResearchConstructionParts2 = 83,
		ResearchCooking = 84,
		ResearchCooking2 = 85,
		ResearchCooking3 = 86,
		ResearchCookingBaking = 87,
		ResearchCookingBaking2 = 88,
		ResearchCookingCrude = 89,
		ResearchCookingCrude2 = 90,
		ResearchCookingCrude3 = 91,
		ResearchCulture = 92,
		ResearchFarmingCrude = 93,
		ResearchFarmingDairy = 94,
		ResearchFarmingLivestock = 95,
		ResearchFarmingLivestock2 = 96,
		ResearchFarmingPoultry = 97,
		ResearchFarmingSheep = 98,
		ResearchFibre = 99,
		ResearchForestry = 100,
		ResearchHealth = 101,
		ResearchHealth2 = 102,
		ResearchHealth3 = 103,
		ResearchLumber = 104,
		ResearchLumberCrude = 105,
		ResearchMasonryCrude = 106,
		ResearchMetalCrude = 107,
		ResearchMetalCrude2 = 108,
		ResearchMetalGood = 109,
		ResearchMiningCrude = 110,
		ResearchAnimalBreedingCrude = 111,
		ResearchAnimalBreeding2 = 112,
		ResearchPlantBreedingCrude = 113,
		ResearchPottery = 114,
		ResearchPotteryCrude = 115,
		ResearchPower = 116,
		ResearchPower2 = 117,
		ResearchPowerCrude = 118,
		ResearchPowerFuel = 119,
		ResearchPowerFuel2 = 120,
		ResearchRobotics = 121,
		ResearchRobotics2 = 122,
		ResearchRobotics3 = 123,
		ResearchShelter = 124,
		ResearchShelter2 = 125,
		ResearchShelter3 = 126,
		ResearchShelter4 = 127,
		ResearchShelter5 = 128,
		ResearchShelterCrude = 129,
		ResearchStorageCrude = 130,
		ResearchStorage = 131,
		ResearchTextiles = 132,
		ResearchTextiles2 = 133,
		ResearchTextiles3 = 134,
		ResearchTextilesCrude = 135,
		ResearchToolsCrude = 136,
		ResearchToys = 137,
		ResearchToys2 = 138,
		ResearchToys3 = 139,
		ResearchToys4 = 140,
		ResearchTransportation = 141,
		ResearchTransportation2 = 142,
		ResearchTransportation3 = 143,
		ResearchWasteCrude = 144,
		GlueFirstFreeBot = 145,
		GlueSecondFreeBot = 146,
		GlueBasics = 147,
		GlueForestry = 148,
		GlueFirstIndustries = 149,
		GlueFinal = 150,
		GlueBotServer = 151,
		GlueSpacePort = 152,
		GlueGameComplete = 153,
		GlueTranscendenceComplete = 154,
		Total = 155
	}

	public enum Category
	{
		Axe = 0,
		Shovel = 1,
		Hoe = 2,
		Scythe = 3,
		Flail = 4,
		Pickaxe = 5,
		Cog = 6,
		Wheel = 7,
		Worker = 8,
		Workbench = 9,
		Bucket = 10,
		CookingPot = 11,
		BotDrive = 12,
		BotFrame = 13,
		BotHead = 14,
		Research = 15,
		Total = 16
	}

	public enum Type
	{
		Normal = 0,
		Research = 1,
		Industry = 2,
		Infrastructure = 3,
		Important = 4,
		Tutorial = 5,
		Lesson = 6,
		Academy = 7,
		Glue = 8,
		FreeBot = 9,
		Total = 10
	}

	public enum ResearchType
	{
		Bash = 0,
		Heat = 1,
		Chop = 2,
		Rub = 3,
		Mix = 4,
		Squeeze = 5,
		Total = 6
	}

	public enum State
	{
		Unavailable = 0,
		Incompletable = 1,
		Available = 2,
		Completed = 3,
		Total = 4
	}

	public ID m_ID;

	public Category m_Category;

	public Type m_Type;

	public string m_Title;

	public string m_Description;

	public string m_StartText;

	public string m_EndText;

	public CeremonyManager.CeremonyType m_CeremonyType;

	public List<ID> m_QuestsRequired;

	public List<QuestEvent> m_EventsRequired;

	public ObjectType m_ObjectTypeRequired;

	public ResearchType m_ResearchType;

	public string m_IconName;

	public Color m_Colour;

	public List<ObjectType> m_BuildingsUnlocked;

	public List<ObjectType> m_ObjectsUnlocked;

	public List<ID> m_QuestsUnlocked;

	public List<ID> m_ReliesOn;

	public bool m_Started;

	public bool m_Active;

	public bool m_Simple;

	public bool m_Complete;

	public bool m_MajorNode;

	public bool m_ShowUnlockedQuests;

	public bool m_Or;

	public bool m_AnyOrder;

	public BaseClass m_CompletedObject;

	public bool m_Idea;

	public string m_IdeaTitleText;

	public List<QuestEvent> m_IdeaEventRequired;

	public bool m_DontShowInTechTree;

	public bool m_DontShowInActiveList;

	public bool m_CompleteAnimation;

	public string[] m_CompleteFrames;

	public bool m_ProgressStarted;

	public int m_Importantance;

	public string m_InfoText;

	public BaseClass m_LastParentObject;

	public IndustryLevel m_IndustryLevel;

	public bool m_EventsLocked;

	public bool m_Pinned;

	private bool m_ReliesOnComplete;

	public static bool GetIsTypeResearch(ID NewID)
	{
		return QuestManager.Instance.GetQuest(NewID).m_Type == Type.Research;
	}

	public Quest()
	{
		m_QuestsRequired = new List<ID>();
		m_EventsRequired = new List<QuestEvent>();
		m_BuildingsUnlocked = new List<ObjectType>();
		m_ObjectsUnlocked = new List<ObjectType>();
		m_QuestsUnlocked = new List<ID>();
		m_ReliesOn = new List<ID>();
		m_Active = false;
		m_Started = false;
		m_Simple = false;
		m_CeremonyType = CeremonyManager.CeremonyType.Total;
		m_Or = false;
		m_AnyOrder = false;
		m_Complete = false;
		m_Idea = false;
		m_IdeaEventRequired = new List<QuestEvent>();
		m_CompleteAnimation = false;
		m_DontShowInTechTree = false;
		m_DontShowInActiveList = false;
		m_IconName = "";
		m_ObjectTypeRequired = ObjectTypeList.m_Total;
		m_ResearchType = ResearchType.Total;
		m_ProgressStarted = false;
		m_Importantance = 0;
		m_Pinned = false;
	}

	public void SetInfo(ID NewID, Category NewCategory, string IdeaTitle, string Title, string Description, string StartText, string EndText, CeremonyManager.CeremonyType NewCeremonyType, Type NewType)
	{
		m_ID = NewID;
		m_Category = NewCategory;
		m_Type = NewType;
		m_Title = Title;
		m_IdeaTitleText = IdeaTitle;
		m_Description = Description;
		m_StartText = StartText;
		m_EndText = EndText;
		m_CeremonyType = NewCeremonyType;
	}

	public void SetOr()
	{
		m_Or = true;
	}

	public void SetAnyOrder()
	{
		m_AnyOrder = true;
	}

	public void Save(JSONNode Node)
	{
		JSONUtils.Set(Node, "Name", QuestManager.Instance.m_Data.GetQuestNameFromID(m_ID));
		JSONUtils.Set(Node, "Active", m_Active);
		JSONUtils.Set(Node, "Started", m_Started);
		JSONUtils.Set(Node, "Pinned", m_Pinned);
		JSONUtils.Set(Node, "Complete", m_Complete);
		JSONArray jSONArray = (JSONArray)(Node["Events"] = new JSONArray());
		int num = 0;
		foreach (QuestEvent item in m_EventsRequired)
		{
			JSONNode jSONNode2 = new JSONObject();
			JSONUtils.Set(jSONNode2, "Type", QuestEvent.GetNameFromType(item.m_Type));
			if (item.m_BotOnly)
			{
				JSONUtils.Set(jSONNode2, "B", 1);
			}
			else
			{
				JSONUtils.Set(jSONNode2, "B", 0);
			}
			JSONUtils.Set(jSONNode2, "Extra", item.GetExtraDataAsString());
			JSONUtils.Set(jSONNode2, "Progress", item.m_Progress);
			jSONArray[num] = jSONNode2;
			num++;
		}
	}

	public void Load(JSONNode Node)
	{
		m_Active = JSONUtils.GetAsBool(Node, "Active", false);
		m_Started = JSONUtils.GetAsBool(Node, "Started", false);
		m_Pinned = JSONUtils.GetAsBool(Node, "Pinned", false);
		m_Complete = JSONUtils.GetAsBool(Node, "Complete", false);
		if (m_Complete)
		{
			foreach (QuestEvent item in m_EventsRequired)
			{
				item.SetProgress(item.m_Required);
			}
		}
		else
		{
			JSONArray asArray = Node["Events"].AsArray;
			int num = 0;
			for (int i = 0; i < asArray.Count; i++)
			{
				JSONNode node = asArray[i];
				QuestEvent.Type typeFromName = QuestEvent.GetTypeFromName(JSONUtils.GetAsString(node, "Type", ""));
				bool botOnly = false;
				if (JSONUtils.GetAsInt(node, "B", 0) != 0)
				{
					botOnly = true;
				}
				string asString = JSONUtils.GetAsString(node, "Extra", "");
				object extraDataFromString = QuestEvent.GetExtraDataFromString(typeFromName, asString);
				if (typeFromName == QuestEvent.Type.Total)
				{
					continue;
				}
				foreach (QuestEvent item2 in m_EventsRequired)
				{
					if (!item2.DoesTypeMatch(typeFromName, botOnly, extraDataFromString))
					{
						continue;
					}
					int asInt = JSONUtils.GetAsInt(node, "Progress", 0);
					if (item2.m_Type != QuestEvent.Type.FolkTranscended)
					{
						item2.SetProgress(asInt);
						if (asInt == item2.m_Required)
						{
							num++;
						}
					}
					else
					{
						item2.m_Progress = asInt;
					}
					break;
				}
			}
			if (num == asArray.Count)
			{
				m_Complete = true;
				foreach (QuestEvent item3 in m_EventsRequired)
				{
					item3.SetProgress(item3.m_Required);
				}
			}
		}
		GetIsComplete();
	}

	public void SetActive()
	{
		m_Active = true;
	}

	public void AddRequiredQuest(ID NewQuest)
	{
		m_QuestsRequired.Add(NewQuest);
	}

	public void AddEvent(QuestEvent.Type NewEvent, bool BotOnly, object ExtraData, int Required, string Description = "")
	{
		m_EventsRequired.Add(new QuestEvent(NewEvent, BotOnly, ExtraData, Required, Description));
	}

	public void AddBuildingUnlocked(ObjectType NewBuilding)
	{
		m_BuildingsUnlocked.Add(NewBuilding);
	}

	public void AddObjectUnlocked(ObjectType NewObject)
	{
		m_ObjectsUnlocked.Add(NewObject);
	}

	public void AddQuestUnlocked(ID NewQuest)
	{
		m_QuestsUnlocked.Add(NewQuest);
	}

	public void AddReliesOn(ID NewQuest)
	{
		m_ReliesOn.Add(NewQuest);
	}

	public void AddIdea(QuestEvent.Type NewEvent, int Required)
	{
		m_Idea = true;
		m_IdeaEventRequired.Add(new QuestEvent(NewEvent, false, 0, Required));
	}

	public void AddCompleteAnimation(string Frame1, string Frame2)
	{
		m_CompleteAnimation = true;
		m_CompleteFrames = new string[2];
		m_CompleteFrames[0] = Frame1;
		m_CompleteFrames[1] = Frame2;
	}

	public bool GetIdeaComplete()
	{
		foreach (QuestEvent item in m_IdeaEventRequired)
		{
			if (m_Or)
			{
				if (item.m_Complete)
				{
					return true;
				}
			}
			else if (!item.m_Complete)
			{
				return false;
			}
		}
		if (m_Or)
		{
			return false;
		}
		return true;
	}

	public void DontShowInActiveList()
	{
		m_DontShowInActiveList = true;
	}

	public void DontShowInTechTree()
	{
		m_DontShowInTechTree = true;
	}

	public bool GetDisplay()
	{
		if (!m_Active)
		{
			return false;
		}
		if (m_Type == Type.Research || m_Type == Type.Tutorial || m_Type == Type.Important || m_Type == Type.Lesson)
		{
			return false;
		}
		if (m_DontShowInActiveList)
		{
			return false;
		}
		return true;
	}

	public bool GetIsStarted()
	{
		foreach (QuestEvent item in m_EventsRequired)
		{
			if (item.m_Progress != 0)
			{
				return true;
			}
		}
		foreach (QuestEvent item2 in m_IdeaEventRequired)
		{
			if (item2.m_Progress != 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsRequiredQuest(ID NewQuestID)
	{
		return m_QuestsRequired.Contains(NewQuestID);
	}

	public bool GetIsComplete()
	{
		if (!m_Started)
		{
			return false;
		}
		foreach (ID item in m_QuestsRequired)
		{
			Quest quest = QuestManager.Instance.GetQuest(item);
			if (quest == null)
			{
				return false;
			}
			if (!quest.GetIsComplete())
			{
				return false;
			}
		}
		if (m_ID == ID.GlueFinal)
		{
			bool flag = false;
			foreach (QuestEvent item2 in m_EventsRequired)
			{
				ID iD = (ID)item2.m_ExtraData;
				if (item2.m_Complete)
				{
					if (iD == ID.AcademyFarmingFruit || iD == ID.AcademyFarmingMushrooms)
					{
						flag = true;
					}
				}
				else if (iD == ID.AcademyColonisation)
				{
					return false;
				}
			}
			if (!flag)
			{
				return false;
			}
			return true;
		}
		bool flag2 = false;
		foreach (QuestEvent item3 in m_EventsRequired)
		{
			if (!m_Or)
			{
				if (!item3.m_Complete)
				{
					return false;
				}
			}
			else if (item3.m_Complete)
			{
				flag2 = true;
				break;
			}
		}
		if (m_Or && !flag2)
		{
			return false;
		}
		m_Complete = true;
		return true;
	}

	public float GetCompletePercent()
	{
		if (m_Complete)
		{
			return 1f;
		}
		float num = 0f;
		if (!m_Or)
		{
			foreach (QuestEvent item in m_EventsRequired)
			{
				num += (float)item.m_Progress / (float)item.m_Required;
			}
			num /= (float)m_EventsRequired.Count;
		}
		else
		{
			foreach (QuestEvent item2 in m_EventsRequired)
			{
				float num2 = (float)item2.m_Progress / (float)item2.m_Required;
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	private void CheckIdeaSpecialCase(QuestEvent.Type NewType)
	{
		if (!m_Or)
		{
			return;
		}
		List<QuestEvent> list = new List<QuestEvent>();
		foreach (QuestEvent item in m_IdeaEventRequired)
		{
			if (item.m_Type != NewType)
			{
				list.Add(item);
			}
		}
		foreach (QuestEvent item2 in list)
		{
			m_IdeaEventRequired.Remove(item2);
		}
		list.Clear();
		foreach (QuestEvent item3 in m_EventsRequired)
		{
			if (item3.m_Type != NewType)
			{
				list.Add(item3);
			}
		}
		foreach (QuestEvent item4 in list)
		{
			m_EventsRequired.Remove(item4);
		}
	}

	public int CheckEvent(QuestEvent.Type NewType, bool Bot, object ExtraData, BaseClass ParentObject, int Value = 1, QuestEvent SpecificEvent = null)
	{
		int result = 0;
		foreach (QuestEvent item in m_EventsRequired)
		{
			bool botOnly = Bot;
			if (!item.m_BotOnly)
			{
				botOnly = false;
			}
			if (item.DoesTypeMatch(NewType, botOnly, ExtraData) && item.AddEvent(Value))
			{
				result = 1;
				if (item.m_Complete)
				{
					result = 2;
				}
				m_LastParentObject = ParentObject;
				m_ProgressStarted = true;
				break;
			}
		}
		return result;
	}

	public bool IsEventRequired(QuestEvent.Type NewType, bool BotOnly, object ExtraData)
	{
		foreach (QuestEvent item in m_EventsRequired)
		{
			if (item.DoesTypeMatch(NewType, BotOnly, ExtraData))
			{
				return true;
			}
		}
		return false;
	}

	public void Complete()
	{
		foreach (QuestEvent item in m_EventsRequired)
		{
			item.m_Progress = item.m_Required;
			item.m_Complete = true;
		}
		m_Complete = true;
		m_Active = true;
	}

	public string GetIconName()
	{
		if (m_Idea && !GetIsComplete())
		{
			return "Quests/QuestIdea";
		}
		if (m_IconName != "")
		{
			return m_IconName;
		}
		if (m_Type == Type.Research)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_ObjectTypeRequired);
		}
		if (m_BuildingsUnlocked.Count > 0)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_BuildingsUnlocked[0]);
		}
		if (m_ObjectsUnlocked.Count > 0)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_ObjectsUnlocked[0]);
		}
		return "";
	}

	public string GetIconNameForChart()
	{
		if (m_IconName != "")
		{
			return m_IconName;
		}
		if (m_Type == Type.Research)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_ObjectTypeRequired);
		}
		if (m_BuildingsUnlocked.Count > 0)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_BuildingsUnlocked[0]);
		}
		if (m_ObjectsUnlocked.Count > 0)
		{
			return "Icons/" + ObjectTypeList.Instance.GetIconNameFromIdentifier(m_ObjectsUnlocked[0]);
		}
		return "";
	}

	public bool GetActiveAndReliedCompleted()
	{
		if (!m_Active)
		{
			return false;
		}
		return m_ReliesOnComplete;
	}

	public State GetState()
	{
		State state = State.Available;
		if (GetActiveAndReliedCompleted() && m_Complete)
		{
			return State.Completed;
		}
		if (m_Active)
		{
			if (AreAnyEventsLocked())
			{
				return State.Incompletable;
			}
			return State.Available;
		}
		return State.Unavailable;
	}

	public void Reset()
	{
		foreach (QuestEvent item in m_EventsRequired)
		{
			item.m_Progress = 0;
			item.m_Complete = false;
		}
		m_Complete = false;
		m_Started = false;
		m_Active = false;
	}

	public List<ObjectType> GetObjectsLocked()
	{
		List<ObjectType> list = new List<ObjectType>();
		foreach (QuestEvent item in m_EventsRequired)
		{
			if (!item.CanBeCompleted())
			{
				list.Add(item.m_LockedObject);
			}
		}
		return list;
	}

	public List<QuestEvent> GetEventsLocked()
	{
		List<QuestEvent> list = new List<QuestEvent>();
		foreach (QuestEvent item in m_EventsRequired)
		{
			if (!item.CanBeCompleted())
			{
				list.Add(item);
			}
		}
		return list;
	}

	public bool AreAnyEventsLocked()
	{
		return m_EventsLocked;
	}

	public bool UnlocksResearch()
	{
		foreach (ID item in m_QuestsUnlocked)
		{
			if (QuestManager.Instance.GetQuest(item).m_Type == Type.Research)
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateEventsCompletable()
	{
		m_EventsLocked = false;
		foreach (QuestEvent item in m_EventsRequired)
		{
			item.UpdateCanBeCompleted(this);
			if (!item.CanBeCompleted())
			{
				m_EventsLocked = true;
			}
		}
		m_ReliesOnComplete = true;
		foreach (ID item2 in m_ReliesOn)
		{
			if (!QuestManager.Instance.GetQuestComplete(item2))
			{
				m_ReliesOnComplete = false;
			}
		}
	}

	public QuestEvent GetFirstAvailableEvent()
	{
		foreach (QuestEvent item in m_EventsRequired)
		{
			if (!item.m_Locked && !item.m_Complete)
			{
				return item;
			}
		}
		return null;
	}
}
