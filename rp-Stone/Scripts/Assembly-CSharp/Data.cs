using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class Data
{
	public enum Resource
	{
		None = 0,
		Stone = 1,
		Wood = 2,
		Tar = 3,
		Xi = 4,
		Bronze = 5,
		PalmLeaves = 6,
		Ivory = 7,
		Gold = 8
	}

	[Serializable]
	public class Treasure
	{
		public string id;

		public TreasureItem.Type type;

		public ItemInTreasure[] items;

		public ItemData.Element element;

		public ItemData.Element[] elements;

		public float chanceHumble;

		public float chanceCommon;

		public float chanceGiant;

		public float chanceRare;

		public float chanceEpic;

		public float chanceGold;

		public float chanceCommonPerStar;

		public float chanceGiantPerStar;

		public float chanceRarePerStar;

		public float chanceEpicPerStar;

		public float chanceGoldPerStar;

		public static Treasure FromString(string sjson)
		{
			return new Treasure
			{
				id = SlimJson.Parse(sjson, "id"),
				type = SlimJson.ParseEnum<TreasureItem.Type>(sjson, "type"),
				items = SlimJson.ParseArray(sjson, "items", ItemInTreasure.FromJson),
				element = SlimJson.ParseEnum<ItemData.Element>(sjson, "element"),
				elements = SlimJson.ParseArray(sjson, "elements", ItemData.ParseElement),
				chanceHumble = SlimJson.ParseFloat(sjson, "chanceHumble"),
				chanceCommon = SlimJson.ParseFloat(sjson, "chanceCommon"),
				chanceGiant = SlimJson.ParseFloat(sjson, "chanceGiant"),
				chanceRare = SlimJson.ParseFloat(sjson, "chanceRare"),
				chanceEpic = SlimJson.ParseFloat(sjson, "chanceEpic"),
				chanceGold = SlimJson.ParseFloat(sjson, "chanceGold"),
				chanceCommonPerStar = SlimJson.ParseFloat(sjson, "chanceCommonPerStar"),
				chanceGiantPerStar = SlimJson.ParseFloat(sjson, "chanceGiantPerStar"),
				chanceRarePerStar = SlimJson.ParseFloat(sjson, "chanceRarePerStar"),
				chanceEpicPerStar = SlimJson.ParseFloat(sjson, "chanceEpicPerStar"),
				chanceGoldPerStar = SlimJson.ParseFloat(sjson, "chanceGoldPerStar")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("type", type.ToString());
			SlimJson.AddProperty("items", items);
			SlimJson.AddProperty("element", element.ToString());
			if (elements != null)
			{
				SlimJson.AddProperty("elements", elements);
			}
			SlimJson.AddProperty("chanceHumble", chanceHumble);
			SlimJson.AddProperty("chanceCommon", chanceCommon);
			SlimJson.AddProperty("chanceGiant", chanceGiant);
			SlimJson.AddProperty("chanceRare", chanceRare);
			SlimJson.AddProperty("chanceEpic", chanceEpic);
			SlimJson.AddProperty("chanceGold", chanceGold);
			SlimJson.AddProperty("chanceCommonPerStar", chanceCommonPerStar);
			SlimJson.AddProperty("chanceGiantPerStar", chanceGiantPerStar);
			SlimJson.AddProperty("chanceRarePerStar", chanceRarePerStar);
			SlimJson.AddProperty("chanceEpicPerStar", chanceEpicPerStar);
			SlimJson.AddProperty("chanceGoldPerStar", chanceGoldPerStar);
			return SlimJson.EndSerialization();
		}

		public Treasure Clone()
		{
			return FromString(ToString());
		}
	}

	[Serializable]
	public class ItemInTreasure
	{
		public string id;

		public int level = 1;

		public int countMin = 1;

		public int countMax = 1;

		public ItemData.Rarity.Type rarityType;

		public int rarityBonus;

		public bool showTreasureColor;

		public int rngSeed;

		public ItemData.Element element;

		public static ItemInTreasure FromJson(string sjson)
		{
			ItemInTreasure itemInTreasure = new ItemInTreasure();
			itemInTreasure.id = SlimJson.Parse(sjson, "id");
			if (sjson.Contains("countMin:") || sjson.Contains("rarityType:") || sjson.Contains("element:"))
			{
				itemInTreasure.level = SlimJson.ParseInt(sjson, "level", 1);
				itemInTreasure.countMin = SlimJson.ParseInt(sjson, "countMin", 1);
				itemInTreasure.countMax = SlimJson.ParseInt(sjson, "countMax", 1);
				itemInTreasure.rarityType = SlimJson.ParseEnum<ItemData.Rarity.Type>(sjson, "rarityType");
				itemInTreasure.rarityBonus = SlimJson.ParseInt(sjson, "rarityBonus", -1);
				itemInTreasure.showTreasureColor = SlimJson.ParseBool(sjson, "showTreasureColor");
				itemInTreasure.rngSeed = SlimJson.ParseInt(sjson, "rngSeed");
				itemInTreasure.element = SlimJson.ParseEnum<ItemData.Element>(sjson, "element");
			}
			else
			{
				itemInTreasure.level = SlimJson.ParseInt(sjson, "lv", 1);
				itemInTreasure.countMin = SlimJson.ParseInt(sjson, "min", 1);
				itemInTreasure.countMax = SlimJson.ParseInt(sjson, "max", 1);
				itemInTreasure.rarityType = SlimJson.ParseEnum<ItemData.Rarity.Type>(sjson, "t");
				itemInTreasure.rarityBonus = SlimJson.ParseInt(sjson, "rB", -1);
				itemInTreasure.showTreasureColor = SlimJson.ParseBool(sjson, "showC");
				itemInTreasure.rngSeed = SlimJson.ParseInt(sjson, "rng");
				itemInTreasure.element = SlimJson.ParseEnum<ItemData.Element>(sjson, "e");
			}
			if (itemInTreasure.rarityType == ItemData.Rarity.Type.Common && itemInTreasure.rarityBonus > 0)
			{
				itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(itemInTreasure.rarityBonus);
			}
			return itemInTreasure;
		}

		public static ItemInTreasure FromStonescriptObject(StonescriptObject obj)
		{
			ItemInTreasure itemInTreasure = new ItemInTreasure();
			itemInTreasure.id = obj.Get<string>("id");
			if (obj.Has<int>("level"))
			{
				itemInTreasure.level = obj.Get<int>("level");
			}
			if (obj.Has<int>("countMin"))
			{
				itemInTreasure.countMin = obj.Get<int>("countMin");
			}
			if (obj.Has<int>("countMax"))
			{
				itemInTreasure.countMax = obj.Get<int>("countMax");
			}
			if (obj.Has<string>("rarityType"))
			{
				Enum.TryParse<ItemData.Rarity.Type>(obj.Get<string>("rarityType"), ignoreCase: true, out itemInTreasure.rarityType);
			}
			if (obj.Has<int>("rarityBonus"))
			{
				itemInTreasure.rarityBonus = obj.Get<int>("rarityBonus");
			}
			if (obj.Has<bool>("showTreasureColor"))
			{
				itemInTreasure.showTreasureColor = obj.Get<bool>("showTreasureColor");
			}
			if (obj.Has<int>("rngSeed"))
			{
				itemInTreasure.rngSeed = obj.Get<int>("rngSeed");
			}
			if (obj.Has<string>("element"))
			{
				Enum.TryParse<ItemData.Element>(obj.Get<string>("element"), ignoreCase: true, out itemInTreasure.element);
			}
			if (itemInTreasure.rarityType == ItemData.Rarity.Type.Common && itemInTreasure.rarityBonus > 0)
			{
				itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(itemInTreasure.rarityBonus);
			}
			return itemInTreasure;
		}

		public override string ToString()
		{
			bool identationEnabled = SlimJson.identationEnabled;
			SlimJson.identationEnabled = false;
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (level != 1)
			{
				SlimJson.AddProperty("lv", level);
			}
			if (countMin != 1)
			{
				SlimJson.AddProperty("min", countMin);
			}
			if (countMax != 1)
			{
				SlimJson.AddProperty("max", countMax);
			}
			SlimJson.AddProperty("t", rarityType.ToString());
			if (rarityBonus > 0)
			{
				SlimJson.AddProperty("rB", rarityBonus);
			}
			if (showTreasureColor)
			{
				SlimJson.AddProperty("showC", showTreasureColor);
			}
			if (rngSeed != 0)
			{
				SlimJson.AddProperty("rng", rngSeed);
			}
			SlimJson.AddProperty("e", element.ToString());
			SlimJson.identationEnabled = identationEnabled;
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class TreasureDrop
	{
		public string treasureId;

		public int incidence = 1;

		public static TreasureDrop FromString(string sjson)
		{
			return new TreasureDrop
			{
				treasureId = SlimJson.Parse(sjson, "treasureId"),
				incidence = SlimJson.ParseInt(sjson, "incidence")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			bool identationEnabled = SlimJson.identationEnabled;
			SlimJson.identationEnabled = false;
			SlimJson.AddProperty("treasureId", treasureId);
			SlimJson.AddProperty("incidence", incidence);
			SlimJson.identationEnabled = identationEnabled;
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class TreasureDropCollection
	{
		public string collectionId;

		public TreasureDrop[] drops;

		public static TreasureDropCollection FromString(string sjson)
		{
			return new TreasureDropCollection
			{
				collectionId = SlimJson.Parse(sjson, "collectionId"),
				drops = SlimJson.ParseArray(sjson, "drops", TreasureDrop.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("collectionId", collectionId);
			SlimJson.AddProperty("drops", drops);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class AllTreasureData
	{
		public Treasure[] treasures;

		public TreasureDropCollection[] dropCollections;

		public static AllTreasureData FromString(string sjson)
		{
			return new AllTreasureData
			{
				treasures = SlimJson.ParseArray(sjson, "treasures", Treasure.FromString),
				dropCollections = SlimJson.ParseArray(sjson, "dropCollections", TreasureDropCollection.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("treasures", treasures);
			SlimJson.AddProperty("dropCollections", dropCollections);
			return SlimJson.EndSerialization();
		}
	}

	public class Condition
	{
		public string requiresFlag;

		public string blockedByFlag;

		public string requiresItem;

		public string blockedByItem;

		public static Condition FromString(string sjson)
		{
			return new Condition
			{
				requiresFlag = SlimJson.Parse(sjson, "requiresFlag"),
				blockedByFlag = SlimJson.Parse(sjson, "blockedByFlag"),
				requiresItem = SlimJson.Parse(sjson, "requiresItem"),
				blockedByItem = SlimJson.Parse(sjson, "blockedByItem")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			if (requiresFlag != null)
			{
				SlimJson.AddProperty("requiresFlag", requiresFlag);
			}
			if (blockedByFlag != null)
			{
				SlimJson.AddProperty("blockedByFlag", blockedByFlag);
			}
			if (requiresItem != null)
			{
				SlimJson.AddProperty("requiresItem", requiresItem);
			}
			if (blockedByItem != null)
			{
				SlimJson.AddProperty("blockedByItem", blockedByItem);
			}
			return SlimJson.EndSerialization();
		}

		public bool Evaluate()
		{
			if (ProgressFlags.EvaluateRequiredAndBlockedBy(requiresFlag, blockedByFlag))
			{
				return Inventory.Singleton.EvaluateRequiredAndBlockedBy(requiresItem, blockedByItem);
			}
			return false;
		}
	}

	[Serializable]
	public class Encounter
	{
		public string id;

		public string instanceId;

		public string prefab;

		public int incidence = 1;

		public float random = 1f;

		public int x = int.MinValue;

		public int y = int.MinValue;

		public int level;

		public int points;

		public Condition[] conditions;

		public string args;

		public static Encounter FromString(string sjson)
		{
			Encounter encounter = new Encounter();
			encounter.id = SlimJson.Parse(sjson, "id");
			encounter.instanceId = SlimJson.Parse(sjson, "instanceId");
			encounter.prefab = SlimJson.Parse(sjson, "prefab");
			encounter.incidence = SlimJson.ParseInt(sjson, "incidence");
			encounter.random = SlimJson.ParseFloat(sjson, "random", 1f);
			encounter.x = SlimJson.ParseInt(sjson, "x", int.MinValue);
			encounter.y = SlimJson.ParseInt(sjson, "y", int.MinValue);
			encounter.level = SlimJson.ParseInt(sjson, "level", 1);
			encounter.points = SlimJson.ParseInt(sjson, "points");
			if (SlimJson.HasKey(sjson, "conditions"))
			{
				encounter.conditions = SlimJson.ParseArray(sjson, "conditions", Condition.FromString);
			}
			else
			{
				Condition condition = new Condition();
				condition.requiresFlag = SlimJson.Parse(sjson, "requiresFlag");
				condition.blockedByFlag = SlimJson.Parse(sjson, "blockedByFlag");
				condition.requiresItem = SlimJson.Parse(sjson, "requiresItem");
				condition.blockedByItem = SlimJson.Parse(sjson, "blockedByItem");
				encounter.conditions = new Condition[1] { condition };
			}
			encounter.args = SlimJson.Parse(sjson, "args");
			return encounter;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			if (id != null)
			{
				SlimJson.AddProperty("id", id);
			}
			if (instanceId != null)
			{
				SlimJson.AddProperty("instanceId", instanceId);
			}
			if (prefab != null)
			{
				SlimJson.AddProperty("prefab", prefab);
			}
			SlimJson.AddProperty("incidence", incidence);
			SlimJson.AddProperty("random", random);
			if (x != int.MinValue)
			{
				SlimJson.AddProperty("x", x);
			}
			if (y != int.MinValue)
			{
				SlimJson.AddProperty("y", y);
			}
			if (level != 1)
			{
				SlimJson.AddProperty("level", level);
			}
			if (points > 0)
			{
				SlimJson.AddProperty("points", points);
			}
			if (conditions != null && conditions.Length != 0)
			{
				if (conditions.Length > 1)
				{
					SlimJson.AddProperty("conditions", conditions.ToString());
				}
				else
				{
					Condition condition = conditions[0];
					if (condition.requiresFlag != null)
					{
						SlimJson.AddProperty("requiresFlag", condition.requiresFlag);
					}
					if (condition.blockedByFlag != null)
					{
						SlimJson.AddProperty("blockedByFlag", condition.blockedByFlag);
					}
					if (condition.requiresItem != null)
					{
						SlimJson.AddProperty("requiresItem", condition.requiresItem);
					}
					if (condition.blockedByItem != null)
					{
						SlimJson.AddProperty("blockedByItem", condition.blockedByItem);
					}
				}
			}
			if (args != null)
			{
				SlimJson.AddProperty("args", args);
			}
			return SlimJson.EndSerialization();
		}

		public bool EvaluateConditions()
		{
			if (conditions == null)
			{
				return true;
			}
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].Evaluate())
				{
					return false;
				}
			}
			return true;
		}
	}

	[Serializable]
	public class StoryBit
	{
		public string line1;

		public string line2;

		public string line3;

		public string buttonLabel;

		public static StoryBit FromString(string sjson)
		{
			return new StoryBit
			{
				line1 = SlimJson.Parse(sjson, "line1"),
				line2 = SlimJson.Parse(sjson, "line2"),
				line3 = SlimJson.Parse(sjson, "line3"),
				buttonLabel = SlimJson.Parse(sjson, "buttonLabel")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("line1", line1);
			SlimJson.AddProperty("line2", line2);
			SlimJson.AddProperty("line3", line3);
			SlimJson.AddProperty("buttonLabel", buttonLabel);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Cost
	{
		public Resource resource;

		public int amount;

		public string itemId;

		public int level;

		public string requiresFlag;

		public string blockedByFlag;

		public static Cost FromString(string sjson)
		{
			return new Cost
			{
				resource = SlimJson.ParseEnum<Resource>(sjson, "resource"),
				amount = SlimJson.ParseInt(sjson, "amount"),
				itemId = SlimJson.Parse(sjson, "itemId"),
				level = SlimJson.ParseInt(sjson, "level", 1),
				requiresFlag = SlimJson.Parse(sjson, "requiresFlag"),
				blockedByFlag = SlimJson.Parse(sjson, "blockedByFlag")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("resource", resource.ToString());
			SlimJson.AddProperty("amount", amount);
			SlimJson.AddProperty("itemId", itemId);
			SlimJson.AddProperty("level", level);
			if (requiresFlag != null)
			{
				SlimJson.AddProperty("requiresFlag", requiresFlag);
			}
			if (blockedByFlag != null)
			{
				SlimJson.AddProperty("blockedByFlag", blockedByFlag);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class TimeProgress
	{
		public int durationMilliseconds;

		public int elapsedMilliseconds;

		public bool running;

		public int prevElapsedMilliseconds;

		public void Update(int deltaMilliseconds)
		{
			elapsedMilliseconds = Mathf.Min(elapsedMilliseconds + deltaMilliseconds, durationMilliseconds);
		}

		public bool IsComplete()
		{
			return elapsedMilliseconds >= durationMilliseconds;
		}

		public static TimeProgress FromString(string sjson)
		{
			return new TimeProgress
			{
				durationMilliseconds = SlimJson.ParseInt(sjson, "durationMilliseconds"),
				elapsedMilliseconds = SlimJson.ParseInt(sjson, "elapsedMilliseconds"),
				running = SlimJson.ParseBool(sjson, "running")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("durationMilliseconds", durationMilliseconds);
			SlimJson.AddProperty("elapsedMilliseconds", elapsedMilliseconds);
			SlimJson.AddProperty("running", running);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Range
	{
		public int begin;

		public int end;

		public string requiresFlag;

		public static Range FromString(string sjson)
		{
			return new Range
			{
				begin = SlimJson.ParseInt(sjson, "begin"),
				end = SlimJson.ParseInt(sjson, "end"),
				requiresFlag = SlimJson.Parse(sjson, "requiresFlag")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("begin", begin);
			SlimJson.AddProperty("end", end);
			if (requiresFlag != null)
			{
				SlimJson.AddProperty("requiresFlag", requiresFlag);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class FlagChanges
	{
		public string[] setFlags;

		public string[] unsetFlags;

		public string[] enableQuests;

		public string[] disableQuests;

		public static FlagChanges FromString(string sjson)
		{
			return new FlagChanges
			{
				setFlags = SlimJson.ParseArray(sjson, "setFlags"),
				unsetFlags = SlimJson.ParseArray(sjson, "unsetFlags"),
				enableQuests = SlimJson.ParseArray(sjson, "enableQuests"),
				disableQuests = SlimJson.ParseArray(sjson, "disableQuests")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			if (setFlags != null)
			{
				SlimJson.AddProperty("setFlags", setFlags);
			}
			if (unsetFlags != null)
			{
				SlimJson.AddProperty("unsetFlags", unsetFlags);
			}
			if (enableQuests != null)
			{
				SlimJson.AddProperty("enableQuests", enableQuests);
			}
			if (disableQuests != null)
			{
				SlimJson.AddProperty("disableQuests", disableQuests);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Trigger
	{
		public enum Type
		{
			CompleteQuest = 0,
			StartQuest = 1,
			SubQuest = 2,
			SetFlags = 3,
			UnsetFlags = 4,
			DisablePause = 5,
			EnablePause = 6,
			PlayMusic = 7,
			FadeOutMusic = 8,
			PlayAmbient = 9,
			StopAmbient = 10,
			PauseAI = 11,
			LerpCameraTo = 12,
			JumpCameraTo = 13,
			MoveHeroTo = 14,
			RestoreCamera = 15,
			RestoreHeroAI = 16,
			ShowDialog = 17,
			HideHUD = 18,
			ShowHUD = 19,
			CustomEvent = 20
		}

		public Type type;

		public TriggerCondition condition;

		public string[] instructions;

		public static Trigger FromString(string sjson)
		{
			Trigger trigger = new Trigger();
			trigger.type = SlimJson.ParseEnum<Type>(sjson, "type");
			trigger.condition = SlimJson.Parse(sjson, "condition", TriggerCondition.FromString);
			trigger.instructions = SlimJson.ParseArray(sjson, "instructions");
			if (trigger.condition == null)
			{
				Utils.LogError("Trigger is missing a condition block (will add a blank one) in json: " + sjson);
				trigger.condition = new TriggerCondition();
			}
			return trigger;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("type", type.ToString());
			SlimJson.AddProperty("Condition", condition.ToString());
			SlimJson.AddProperty("instructions", instructions);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class TriggerCondition
	{
		public int x;

		public int section;

		public bool completeQuest;

		public bool leaveQuest;

		public string requiresFlag;

		public string blockedByFlag;

		public string characterDead;

		public string enemyEngaged;

		public int enemyCount;

		public static TriggerCondition FromString(string sjson)
		{
			return new TriggerCondition
			{
				x = SlimJson.ParseInt(sjson, "x", int.MaxValue),
				section = SlimJson.ParseInt(sjson, "section", int.MaxValue),
				completeQuest = SlimJson.ParseBool(sjson, "completeQuest"),
				leaveQuest = SlimJson.ParseBool(sjson, "leaveQuest"),
				requiresFlag = SlimJson.Parse(sjson, "requiresFlag"),
				blockedByFlag = SlimJson.Parse(sjson, "blockedByFlag"),
				characterDead = SlimJson.Parse(sjson, "characterDead"),
				enemyEngaged = SlimJson.Parse(sjson, "enemyEngaged"),
				enemyCount = SlimJson.ParseInt(sjson, "enemyCount", -1)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("x", x);
			SlimJson.AddProperty("section", section);
			if (completeQuest)
			{
				SlimJson.AddProperty("completeQuest", completeQuest);
			}
			if (leaveQuest)
			{
				SlimJson.AddProperty("leaveQuest", leaveQuest);
			}
			if (requiresFlag != null)
			{
				SlimJson.AddProperty("requiresFlag", requiresFlag);
			}
			if (blockedByFlag != null)
			{
				SlimJson.AddProperty("blockedByFlag", blockedByFlag);
			}
			if (characterDead != null)
			{
				SlimJson.AddProperty("characterDead", characterDead);
			}
			if (enemyEngaged != null)
			{
				SlimJson.AddProperty("enemyEngaged", enemyEngaged);
			}
			if (enemyCount >= 0)
			{
				SlimJson.AddProperty("enemyCount", enemyCount);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class QuestSection
	{
		public int rndCount;

		public string[] rndIds;

		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public int minLevel;

		public int maxLevel;

		public ProcGen procGen;

		public Encounter[] fixedEncounters;

		public static QuestSection FromString(string sjson)
		{
			return new QuestSection
			{
				rndCount = SlimJson.ParseInt(sjson, "rndCount"),
				rndIds = SlimJson.ParseArray(sjson, "rndIds"),
				minX = SlimJson.ParseInt(sjson, "minX"),
				maxX = SlimJson.ParseInt(sjson, "maxX"),
				minY = SlimJson.ParseInt(sjson, "minY"),
				maxY = SlimJson.ParseInt(sjson, "maxY"),
				minLevel = SlimJson.ParseInt(sjson, "minLevel"),
				maxLevel = SlimJson.ParseInt(sjson, "maxLevel"),
				procGen = SlimJson.Parse(sjson, "procGen", ProcGen.FromString),
				fixedEncounters = SlimJson.ParseArray(sjson, "fixed", Encounter.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			if (rndCount > 0)
			{
				SlimJson.AddProperty("rndCount", rndCount);
			}
			if (rndIds != null)
			{
				SlimJson.AddProperty("rndIds", rndIds);
			}
			if (minX != 0)
			{
				SlimJson.AddProperty("minX", minX);
			}
			if (maxX > 0)
			{
				SlimJson.AddProperty("maxX", maxX);
			}
			if (minY > 0)
			{
				SlimJson.AddProperty("minY", minY);
			}
			if (maxY > 0)
			{
				SlimJson.AddProperty("maxY", maxY);
			}
			if (minLevel > 0)
			{
				SlimJson.AddProperty("minLevel", minLevel);
			}
			if (maxLevel > 0)
			{
				SlimJson.AddProperty("maxLevel", maxLevel);
			}
			if (procGen != null)
			{
				SlimJson.AddProperty("procGen", procGen.ToString());
			}
			if (fixedEncounters != null)
			{
				SlimJson.AddProperty("fixed", fixedEncounters);
			}
			return SlimJson.EndSerialization();
		}

		public static QuestSection[] Copy(QuestSection[] sectionsToCopy)
		{
			if (sectionsToCopy == null)
			{
				return null;
			}
			QuestSection[] array = new QuestSection[sectionsToCopy.Length];
			for (int i = 0; i < sectionsToCopy.Length; i++)
			{
				array[i] = FromString(sectionsToCopy[i].ToString());
			}
			return array;
		}
	}

	[Serializable]
	public class ProcGen
	{
		public int points;

		public int pointsPerLevel = -1;

		public int maxLevel;

		public string[] excludeIds;

		public static ProcGen FromString(string sjson)
		{
			return new ProcGen
			{
				points = SlimJson.ParseInt(sjson, "points"),
				pointsPerLevel = SlimJson.ParseInt(sjson, "pointsPerLevel", -1),
				maxLevel = SlimJson.ParseInt(sjson, "maxLevel"),
				excludeIds = SlimJson.ParseArray(sjson, "excludeIds")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("points", points);
			SlimJson.AddProperty("pointsPerLevel", pointsPerLevel);
			SlimJson.AddProperty("maxLevel", maxLevel);
			if (excludeIds != null)
			{
				SlimJson.AddProperty("excludeIds", excludeIds);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Quest
	{
		public string name;

		public string overrideName;

		public string id;

		public string sequel;

		public int level;

		public int procGenLevel;

		public string iconId;

		public int seconds = 10;

		public Resource resourceCollected;

		public Cost[] costs;

		public Cost[] rewards;

		public string[] requiredQuests;

		public string[] requiredFlags;

		public string[] requiredItems;

		public FlagChanges onPlay;

		public FlagChanges onLeave;

		public FlagChanges onDeath;

		public FlagChanges onComplete;

		public bool safe;

		public bool oneShot;

		public bool workstation;

		public bool isGate;

		public bool restoreAIonInventoryBack = true;

		public bool customCompletionLogic;

		public bool hideHUD;

		public bool hideTopHUD;

		public bool showNewIndicator = true;

		public string customIndicator;

		public bool markAsSeen;

		public int sort;

		public string background;

		public string foreground;

		public int walkLimitTop;

		public int walkLimitBot;

		public int initialHeroX;

		public int initialHeroZ;

		public int cameraLimitX = int.MaxValue;

		public int cameraLimitSection = int.MaxValue;

		public int minWalkToSpawn = 3;

		public int maxWalkToSpawn = 20;

		public Encounter[] encounters;

		public Encounter[] fixedEncounters;

		public Range[] emptyAreas;

		public Trigger[] triggers;

		public string expectedTreasureId;

		public QuestSection[] sections;

		public StoryBit outro;

		public string progressBar;

		public TimeProgress timeProgress;

		public Quest sequelRoot;

		public Quest sequelNext;

		private Dictionary<string, Encounter> encounterDict;

		private SSNativeObject<Quest> _ssObject;

		public string Name
		{
			get
			{
				if (overrideName == null)
				{
					return name;
				}
				return overrideName;
			}
		}

		public bool isCustomQuest { get; set; }

		public SSNativeObject<Quest> ssObject
		{
			get
			{
				if (_ssObject == null)
				{
					_ssObject = new SSNativeObject<Quest>(this);
				}
				return _ssObject;
			}
			set
			{
				_ssObject = value;
			}
		}

		public static Quest FromString(string sjson)
		{
			Quest quest = new Quest();
			quest.name = SlimJson.Parse(sjson, "name");
			quest.id = SlimJson.Parse(sjson, "id");
			quest.sequel = SlimJson.Parse(sjson, "sequel");
			quest.level = SlimJson.ParseInt(sjson, "level");
			quest.procGenLevel = SlimJson.ParseInt(sjson, "procGenLevel");
			quest.iconId = SlimJson.Parse(sjson, "iconId");
			if (!string.IsNullOrEmpty(quest.iconId))
			{
				Utils.PreloadAsyncPrefab(quest.iconId);
			}
			quest.seconds = SlimJson.ParseInt(sjson, "seconds");
			quest.resourceCollected = SlimJson.ParseEnum<Resource>(sjson, "resourceCollected");
			quest.costs = SlimJson.ParseArray(sjson, "costs", Cost.FromString);
			quest.rewards = SlimJson.ParseArray(sjson, "rewards", Cost.FromString);
			quest.requiredQuests = SlimJson.ParseArray(sjson, "requiredQuests");
			quest.requiredFlags = SlimJson.ParseArray(sjson, "requiredFlags");
			quest.requiredItems = SlimJson.ParseArray(sjson, "requiredItems");
			quest.onPlay = SlimJson.Parse(sjson, "onPlay", FlagChanges.FromString);
			quest.onLeave = SlimJson.Parse(sjson, "onLeave", FlagChanges.FromString);
			quest.onDeath = SlimJson.Parse(sjson, "onDeath", FlagChanges.FromString);
			quest.onComplete = SlimJson.Parse(sjson, "onComplete", FlagChanges.FromString);
			quest.safe = SlimJson.ParseBool(sjson, "safe");
			quest.oneShot = SlimJson.ParseBool(sjson, "oneShot");
			quest.workstation = SlimJson.ParseBool(sjson, "workstation");
			quest.isGate = SlimJson.ParseBool(sjson, "isGate");
			quest.restoreAIonInventoryBack = SlimJson.ParseBool(sjson, "restoreAIonInventoryBack", defaultValue: true);
			quest.customCompletionLogic = SlimJson.ParseBool(sjson, "customCompletionLogic");
			quest.hideHUD = SlimJson.ParseBool(sjson, "hideHUD");
			quest.hideTopHUD = SlimJson.ParseBool(sjson, "hideTopHUD");
			quest.showNewIndicator = SlimJson.ParseBool(sjson, "showNewIndicator", defaultValue: true);
			quest.customIndicator = SlimJson.Parse(sjson, "customIndicator");
			quest.markAsSeen = SlimJson.ParseBool(sjson, "markAsSeen");
			quest.sort = SlimJson.ParseInt(sjson, "sort");
			quest.background = SlimJson.Parse(sjson, "background");
			quest.foreground = SlimJson.Parse(sjson, "foreground");
			quest.walkLimitTop = SlimJson.ParseInt(sjson, "walkLimitTop");
			quest.walkLimitBot = SlimJson.ParseInt(sjson, "walkLimitBot");
			quest.initialHeroX = SlimJson.ParseInt(sjson, "initialHeroX");
			quest.initialHeroZ = SlimJson.ParseInt(sjson, "initialHeroZ");
			quest.cameraLimitX = SlimJson.ParseInt(sjson, "cameraLimitX", int.MaxValue);
			quest.cameraLimitSection = SlimJson.ParseInt(sjson, "cameraLimitSection", int.MaxValue);
			quest.minWalkToSpawn = SlimJson.ParseInt(sjson, "minWalkToSpawn");
			quest.maxWalkToSpawn = SlimJson.ParseInt(sjson, "maxWalkToSpawn");
			quest.encounters = SlimJson.ParseArray(sjson, "encounters", Encounter.FromString);
			quest.fixedEncounters = SlimJson.ParseArray(sjson, "fixedEncounters", Encounter.FromString);
			quest.emptyAreas = SlimJson.ParseArray(sjson, "emptyAreas", Range.FromString);
			quest.triggers = SlimJson.ParseArray(sjson, "triggers", Trigger.FromString);
			quest.expectedTreasureId = SlimJson.Parse(sjson, "expectedTreasureId");
			quest.sections = SlimJson.ParseArray(sjson, "sections", QuestSection.FromString);
			quest.outro = SlimJson.Parse(sjson, "outro", StoryBit.FromString);
			quest.progressBar = SlimJson.Parse(sjson, "progressBar");
			quest.timeProgress = SlimJson.Parse(sjson, "timeProgress", TimeProgress.FromString);
			if (quest.timeProgress == null && (quest.oneShot || quest.workstation) && quest.seconds > 0)
			{
				quest.timeProgress = new TimeProgress();
				quest.timeProgress.durationMilliseconds = quest.seconds * 1000;
				quest.timeProgress.elapsedMilliseconds = 0;
			}
			return quest;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("name", name);
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("sequel", sequel);
			SlimJson.AddProperty("level", level);
			SlimJson.AddProperty("procGenLevel", procGenLevel);
			SlimJson.AddProperty("seconds", seconds);
			SlimJson.AddProperty("resourceCollected", resourceCollected.ToString());
			SlimJson.AddProperty("costs", costs);
			SlimJson.AddProperty("rewards", rewards);
			if (requiredQuests != null)
			{
				SlimJson.AddProperty("requiredQuests", requiredQuests);
			}
			if (requiredFlags != null)
			{
				SlimJson.AddProperty("requiredFlags", requiredFlags);
			}
			if (requiredItems != null)
			{
				SlimJson.AddProperty("requiredItems", requiredItems);
			}
			SlimJson.AddProperty("safe", safe);
			SlimJson.AddProperty("oneShot", oneShot);
			SlimJson.AddProperty("workstation", workstation);
			SlimJson.AddProperty("isGate", isGate);
			SlimJson.AddProperty("restoreAIonInventoryBack", restoreAIonInventoryBack);
			SlimJson.AddProperty("customCompletionLogic", customCompletionLogic);
			SlimJson.AddProperty("hideHUD", hideHUD);
			SlimJson.AddProperty("hideTopHUD", hideTopHUD);
			SlimJson.AddProperty("showNewIndicator", showNewIndicator);
			SlimJson.AddProperty("customIndicator", customIndicator);
			SlimJson.AddProperty("markAsSeen", markAsSeen);
			SlimJson.AddProperty("sort", sort);
			SlimJson.AddProperty("background", background);
			SlimJson.AddProperty("foreground", foreground);
			SlimJson.AddProperty("walkLimitTop", walkLimitTop);
			SlimJson.AddProperty("walkLimitBot", walkLimitBot);
			SlimJson.AddProperty("initialHeroX", initialHeroX);
			SlimJson.AddProperty("initialHeroZ", initialHeroZ);
			if (cameraLimitX != int.MaxValue)
			{
				SlimJson.AddProperty("cameraLimitX", cameraLimitX);
			}
			if (cameraLimitSection != int.MaxValue)
			{
				SlimJson.AddProperty("cameraLimitSection", cameraLimitSection);
			}
			SlimJson.AddProperty("minWalkToSpawn", minWalkToSpawn);
			SlimJson.AddProperty("maxWalkToSpawn", maxWalkToSpawn);
			if (encounters != null)
			{
				SlimJson.AddProperty("encounters", encounters);
			}
			if (fixedEncounters != null)
			{
				SlimJson.AddProperty("fixedEncounters", fixedEncounters);
			}
			if (emptyAreas != null)
			{
				SlimJson.AddProperty("emptyAreas", emptyAreas);
			}
			if (triggers != null)
			{
				SlimJson.AddProperty("triggers", triggers);
			}
			SlimJson.AddProperty("expectedTreasureId", expectedTreasureId);
			if (sections != null)
			{
				SlimJson.AddProperty("sections", sections);
			}
			SlimJson.AddProperty("iconId", iconId);
			if (outro != null)
			{
				SlimJson.AddProperty("outro", outro.ToString());
			}
			SlimJson.AddProperty("progressBar", progressBar);
			if (timeProgress != null)
			{
				SlimJson.AddProperty("timeProgress", timeProgress.ToString());
			}
			return SlimJson.EndSerialization();
		}

		public void CopyUnsetValuesFrom(Quest quest)
		{
			if (name == null)
			{
				name = quest.name;
			}
			if (id == null)
			{
				id = quest.id;
			}
			if (sequel == null)
			{
				sequel = quest.sequel;
			}
			if (level == 0)
			{
				level = quest.level;
			}
			if (iconId == null)
			{
				iconId = quest.iconId;
			}
			if (resourceCollected == Resource.None)
			{
				resourceCollected = quest.resourceCollected;
			}
			if (costs == null)
			{
				costs = quest.costs;
			}
			if (rewards == null)
			{
				rewards = quest.rewards;
			}
			if (requiredQuests == null)
			{
				requiredQuests = quest.requiredQuests;
			}
			if (requiredFlags == null)
			{
				requiredFlags = quest.requiredFlags;
			}
			if (requiredItems == null)
			{
				requiredItems = quest.requiredItems;
			}
			if (onPlay == null)
			{
				onPlay = quest.onPlay;
			}
			if (onComplete == null)
			{
				onComplete = quest.onComplete;
			}
			safe |= quest.safe;
			oneShot |= quest.oneShot;
			workstation |= quest.workstation;
			isGate |= quest.isGate;
			restoreAIonInventoryBack &= quest.restoreAIonInventoryBack;
			customCompletionLogic |= quest.customCompletionLogic;
			hideHUD |= quest.hideHUD;
			hideTopHUD |= quest.hideTopHUD;
			showNewIndicator |= quest.showNewIndicator;
			markAsSeen |= quest.markAsSeen;
			sort = ((sort == 0) ? quest.sort : 0);
			if (background == null)
			{
				background = quest.background;
			}
			if (foreground == null)
			{
				foreground = quest.foreground;
			}
			if (walkLimitTop == 0)
			{
				walkLimitTop = quest.walkLimitTop;
			}
			if (walkLimitBot == 0)
			{
				walkLimitBot = quest.walkLimitBot;
			}
			if (initialHeroX == 0)
			{
				initialHeroX = quest.initialHeroX;
			}
			if (initialHeroZ == 0)
			{
				initialHeroZ = quest.initialHeroZ;
			}
			if (cameraLimitX == int.MaxValue)
			{
				cameraLimitX = quest.cameraLimitX;
			}
			if (cameraLimitSection == int.MaxValue)
			{
				cameraLimitSection = quest.cameraLimitSection;
			}
			if (encounters == null)
			{
				encounters = quest.encounters;
			}
			if (fixedEncounters == null)
			{
				fixedEncounters = quest.fixedEncounters;
			}
			if (emptyAreas == null)
			{
				emptyAreas = quest.emptyAreas;
			}
			if (triggers == null)
			{
				triggers = quest.triggers;
			}
			if (expectedTreasureId == null)
			{
				expectedTreasureId = quest.expectedTreasureId;
			}
			if (sections == null)
			{
				sections = QuestSection.Copy(quest.sections);
			}
			if (progressBar == null)
			{
				progressBar = quest.progressBar;
			}
			if (timeProgress == null)
			{
				timeProgress = quest.timeProgress;
			}
		}

		public Encounter GetEncounter(string encounterId)
		{
			if (encounterDict == null)
			{
				encounterDict = new Dictionary<string, Encounter>();
				if (sequelRoot != null && sequelRoot.encounters != null)
				{
					for (int i = 0; i < sequelRoot.encounters.Length; i++)
					{
						Encounter encounter = sequelRoot.encounters[i];
						if (encounter.id != null)
						{
							encounterDict.Add(encounter.id, encounter);
						}
					}
				}
				if (encounters != null)
				{
					for (int j = 0; j < encounters.Length; j++)
					{
						Encounter encounter2 = encounters[j];
						if (encounter2.id != null)
						{
							if (encounterDict.ContainsKey(encounter2.id))
							{
								encounterDict[encounter2.id] = encounter2;
							}
							else
							{
								encounterDict.Add(encounter2.id, encounter2);
							}
						}
					}
				}
			}
			if (encounterDict.ContainsKey(encounterId))
			{
				return encounterDict[encounterId];
			}
			Utils.LogWarning("No encounter with id " + encounterId + " found for quest " + id + "|" + sequel);
			return null;
		}

		[StonescriptNativeGetter("id")]
		public object Property_GetId()
		{
			return id;
		}

		[StonescriptNativeGetter("name")]
		public object Property_GetName()
		{
			return Name;
		}

		[StonescriptNativeGetter("cameraLimitSection")]
		public object Property_GetCamLimitSection()
		{
			return cameraLimitSection;
		}

		[StonescriptNativeSetter("cameraLimitSection")]
		public void Property_SetCamLimitSection(object value)
		{
			cameraLimitSection = (int)value;
		}

		[StonescriptNativeMethod]
		public object MarkIncompleted(List<object> parameters, InvocationContext ctx)
		{
			QuestController.singleton.MarkAsIncomplete(id);
			return true;
		}

		[StonescriptNativeMethod]
		public object MarkUnplayed(List<object> parameters, InvocationContext ctx)
		{
			QuestController.singleton.MarkAsUnplayed(id);
			return true;
		}

		[StonescriptNativeMethod]
		public object MarkUnseen(List<object> parameters, InvocationContext ctx)
		{
			QuestController.singleton.MarkAsUnseen(id);
			return true;
		}
	}

	[Serializable]
	public class QuestGroup
	{
		public string id;

		public string[] grouped_quest_ids;

		public static QuestGroup FromString(string sjson)
		{
			return new QuestGroup
			{
				id = SlimJson.Parse(sjson, "id"),
				grouped_quest_ids = SlimJson.ParseArray(sjson, "grouped_quest_ids")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (grouped_quest_ids != null)
			{
				SlimJson.AddProperty("grouped_quest_ids", grouped_quest_ids);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class QuestCollection
	{
		public Quest[] quests;

		public QuestGroup[] questGroups;

		public static QuestCollection FromString(string sjson)
		{
			return new QuestCollection
			{
				quests = SlimJson.ParseArray(sjson, "quests", Quest.FromString),
				questGroups = SlimJson.ParseArray(sjson, "questGroups", QuestGroup.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("quests", quests);
			if (questGroups != null)
			{
				SlimJson.AddProperty("questGroups", questGroups);
			}
			return SlimJson.EndSerialization();
		}
	}

	public class QuestStats
	{
		public string questId;

		public int lastPlayedDifficulty;

		public int bestTime;

		public SafeFloat averageTime;

		public SafeFloat averageHPLost;

		public SafeFloat averageHPGained;

		public SafeFloat averageKiGained;

		public SafeFloat averageResGained;

		public SafeFloat averageDamageDealt;

		public SafeFloat averageDevourDamage;

		public SafeFloat averageDevouredAEther;

		public SafeFloat averageDevouredFire;

		public SafeFloat averageDevouredIce;

		public SafeFloat averageDevouredPoison;

		public SafeFloat averageDevouredVigor;

		public void ClearProgress()
		{
			bestTime = 0;
			averageTime = default(SafeFloat);
			averageHPLost = default(SafeFloat);
			averageHPGained = default(SafeFloat);
			averageKiGained = default(SafeFloat);
			averageResGained = default(SafeFloat);
			averageDamageDealt = default(SafeFloat);
			averageDevourDamage = default(SafeFloat);
			averageDevouredAEther = default(SafeFloat);
			averageDevouredFire = default(SafeFloat);
			averageDevouredIce = default(SafeFloat);
			averageDevouredPoison = default(SafeFloat);
			averageDevouredVigor = default(SafeFloat);
		}

		public static QuestStats FromString(string sjson)
		{
			QuestStats questStats = new QuestStats();
			if (SlimJson.HasKey(sjson, "bestTime"))
			{
				questStats.questId = SlimJson.Parse(sjson, "id");
				questStats.lastPlayedDifficulty = SlimJson.ParseInt(sjson, "lastPlayedDifficulty");
				questStats.bestTime = SlimJson.ParseInt(sjson, "bestTime");
				questStats.averageTime = new SafeFloat(SlimJson.ParseFloat(sjson, "averageTime"));
				questStats.averageHPLost = new SafeFloat(SlimJson.ParseFloat(sjson, "averageHPLost"));
				questStats.averageHPGained = new SafeFloat(SlimJson.ParseFloat(sjson, "averageHPGained"));
				questStats.averageKiGained = new SafeFloat(SlimJson.ParseFloat(sjson, "averageKiGained"));
				questStats.averageResGained = new SafeFloat(SlimJson.ParseFloat(sjson, "averageResGained"));
			}
			else
			{
				questStats.questId = SlimJson.Parse(sjson, "id");
				questStats.lastPlayedDifficulty = SlimJson.ParseInt(sjson, "lpDiff");
				questStats.bestTime = SlimJson.ParseInt(sjson, "bT");
				questStats.averageTime = new SafeFloat(SlimJson.ParseFloat(sjson, "aT"));
				questStats.averageHPLost = new SafeFloat(SlimJson.ParseFloat(sjson, "aHl"));
				questStats.averageHPGained = new SafeFloat(SlimJson.ParseFloat(sjson, "aHg"));
				questStats.averageKiGained = new SafeFloat(SlimJson.ParseFloat(sjson, "aKg"));
				questStats.averageResGained = new SafeFloat(SlimJson.ParseFloat(sjson, "aRg"));
				questStats.averageDamageDealt = new SafeFloat(SlimJson.ParseFloat(sjson, "d"));
				questStats.averageDevourDamage = new SafeFloat(SlimJson.ParseFloat(sjson, "Dd"));
				questStats.averageDevouredAEther = new SafeFloat(SlimJson.ParseFloat(sjson, "DA"));
				questStats.averageDevouredFire = new SafeFloat(SlimJson.ParseFloat(sjson, "DF"));
				questStats.averageDevouredIce = new SafeFloat(SlimJson.ParseFloat(sjson, "DI"));
				questStats.averageDevouredPoison = new SafeFloat(SlimJson.ParseFloat(sjson, "DP"));
				questStats.averageDevouredVigor = new SafeFloat(SlimJson.ParseFloat(sjson, "DV"));
			}
			return questStats;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", questId);
			if (lastPlayedDifficulty > 0)
			{
				SlimJson.AddProperty("lpDiff", lastPlayedDifficulty);
			}
			SlimJson.AddProperty("bT", bestTime);
			SlimJson.AddProperty("aT", averageTime.GetValue());
			SlimJson.AddProperty("aHl", averageHPLost.GetValue());
			SlimJson.AddProperty("aHg", averageHPGained.GetValue());
			SlimJson.AddProperty("aKg", averageKiGained.GetValue());
			TryAddSafeFloat("aRg", averageResGained);
			TryAddSafeFloat("d", averageDamageDealt);
			TryAddSafeFloat("Dd", averageDevourDamage);
			TryAddSafeFloat("DA", averageDevouredAEther);
			TryAddSafeFloat("DF", averageDevouredFire);
			TryAddSafeFloat("DI", averageDevouredIce);
			TryAddSafeFloat("DP", averageDevouredPoison);
			TryAddSafeFloat("DV", averageDevouredVigor);
			return SlimJson.EndSerialization();
		}

		private void TryAddSafeFloat(string key, SafeFloat safeVal)
		{
			float value = safeVal.GetValue();
			if (value != 0f)
			{
				SlimJson.AddProperty(key, value);
			}
		}
	}

	[Serializable]
	public class CustomQuest
	{
		public enum Type
		{
			Craft = 0,
			Harvest = 1,
			DefeatFoes = 2,
			Count = 3,
			FindEnchantments = 4,
			GainStar = 5,
			DefeatBoss = 6,
			DefeatWithItem = 7,
			CollectResources = 8,
			SkullGame = 9,
			UsePotion = 10
		}

		public string id;

		public bool isEnabled;

		public DateTime releaseDate;

		public string title;

		public string icon;

		public string intro;

		public bool autoGen = true;

		public int weight = 1;

		public int paramQuantity;

		public int quantityProgress;

		public TreasureDrop rewardTreasure;

		public string rewardResource;

		public bool showReward = true;

		public bool showProgress = true;

		public string[] locReqs = new string[0];

		public string scriptName;

		public string init;

		public Dictionary<string, object> data;

		public string[] unlockQuests = new string[0];

		public bool IsBasic => showProgress;

		public bool IsReleased()
		{
			return DateTime.Now >= releaseDate;
		}

		private static TreasureDrop TreasureDrop_FromString(string sjson)
		{
			if (string.IsNullOrEmpty(sjson))
			{
				return null;
			}
			return TreasureDrop.FromString(sjson);
		}

		public static CustomQuest FromString(string sjson)
		{
			CustomQuest customQuest = new CustomQuest();
			customQuest.id = SlimJson.Parse(sjson, "id");
			customQuest.isEnabled = SlimJson.ParseBool(sjson, "isEnabled");
			if (SlimJson.HasKey(sjson, "releaseDate"))
			{
				customQuest.releaseDate = SlimJson.ParseDateTime(sjson, "releaseDate");
			}
			else
			{
				customQuest.releaseDate = new DateTime(2019, 8, 8);
			}
			customQuest.title = SlimJson.Parse(sjson, "title");
			if (customQuest.title != null)
			{
				customQuest.title = customQuest.title.Trim();
			}
			customQuest.icon = SlimJson.Parse(sjson, "icon");
			customQuest.intro = SlimJson.Parse(sjson, "intro");
			customQuest.scriptName = SlimJson.Parse(sjson, "scriptName");
			customQuest.init = SlimJson.Parse(sjson, "init");
			customQuest.data = SlimJson.ParseDictionary(sjson, "data");
			customQuest.weight = SlimJson.ParseInt(sjson, "weight", 1);
			customQuest.autoGen = SlimJson.ParseBool(sjson, "autoGen", defaultValue: true);
			customQuest.locReqs = SlimJson.ParseArray(sjson, "locReqs");
			customQuest.paramQuantity = SlimJson.ParseInt(sjson, "paramQuantity");
			customQuest.quantityProgress = SlimJson.ParseInt(sjson, "quantityProgress");
			customQuest.rewardTreasure = SlimJson.Parse(sjson, "rewardTreasure", TreasureDrop_FromString);
			customQuest.rewardResource = SlimJson.Parse(sjson, "rewardResource");
			if (customQuest.rewardResource != null)
			{
				customQuest.rewardResource = customQuest.rewardResource.Trim();
			}
			customQuest.unlockQuests = SlimJson.ParseArray(sjson, "unlockQuests");
			customQuest.showReward = SlimJson.ParseBool(sjson, "showReward", defaultValue: true);
			customQuest.showProgress = SlimJson.ParseBool(sjson, "showProgress", defaultValue: true);
			return customQuest;
		}

		public override string ToString()
		{
			throw new NotImplementedException();
		}
	}

	[Serializable]
	public class CustomQuestInstance
	{
		public string customQuestId;

		public CustomQuest def;

		public int instanceId = -1;

		public bool started;

		public bool completed;

		public bool rewardClaimed;

		public TreasureItem reward;

		public bool seen;

		public SSCustomQuest ssQuest;

		public Dictionary<string, object> data;

		public string title;

		public string status;

		public List<string> actions = new List<string>();

		public string progressTitle;

		public int progress;

		public int target;

		public bool loaded;

		public string Title
		{
			get
			{
				if (title == null)
				{
					return def.title;
				}
				return title;
			}
		}

		public string Icon => def.icon;

		public bool IsBasic => def.IsBasic;

		public static CustomQuestInstance FromString(string sjson)
		{
			CustomQuestInstance customQuestInstance = new CustomQuestInstance();
			customQuestInstance.customQuestId = SlimJson.Parse(sjson, "customQuestId");
			customQuestInstance.instanceId = SlimJson.ParseInt(sjson, "instanceId");
			customQuestInstance.data = SlimJson.ParseDictionary(sjson, "data");
			ReplaceListsWithSSArray(customQuestInstance.data);
			customQuestInstance.started = SlimJson.ParseBool(sjson, "started");
			customQuestInstance.progress = SlimJson.ParseInt(sjson, "progress");
			customQuestInstance.target = SlimJson.ParseInt(sjson, "target");
			customQuestInstance.seen = SlimJson.ParseBool(sjson, "seen");
			customQuestInstance.rewardClaimed = SlimJson.ParseBool(sjson, "rewardClaimed");
			customQuestInstance.completed = SlimJson.ParseBool(sjson, "completed");
			customQuestInstance.title = SlimJson.Parse(sjson, "title");
			customQuestInstance.status = SlimJson.Parse(sjson, "status");
			customQuestInstance.progressTitle = SlimJson.Parse(sjson, "progressTitle");
			string[] array = SlimJson.ParseArray(sjson, "actions");
			if (array != null)
			{
				customQuestInstance.actions.AddRange(array);
			}
			return customQuestInstance;
		}

		private static void ReplaceListsWithSSArray(Dictionary<string, object> data)
		{
			if (data == null)
			{
				return;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> datum in data)
			{
				if (datum.Value is List<object>)
				{
					StonescriptArray stonescriptArray = new StonescriptArray(datum.Key);
					stonescriptArray.AddRange(datum.Value as List<object>);
					dictionary.Add(datum.Key, stonescriptArray);
				}
				else if (datum.Value is Dictionary<string, object>)
				{
					ReplaceListsWithSSArray(datum.Value as Dictionary<string, object>);
				}
			}
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				data[item.Key] = item.Value;
			}
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("customQuestId", customQuestId);
			SlimJson.AddProperty("instanceId", instanceId);
			SlimJson.AddProperty("data", data);
			if (started)
			{
				SlimJson.AddProperty("started", started);
			}
			if (seen)
			{
				SlimJson.AddProperty("seen", seen);
			}
			if (title != null)
			{
				SlimJson.AddProperty("title", title);
			}
			SlimJson.AddProperty("status", status);
			if (progressTitle != null)
			{
				SlimJson.AddProperty("progressTitle", progressTitle);
			}
			SlimJson.AddProperty("target", target);
			if (progress != 0)
			{
				SlimJson.AddProperty("progress", progress);
			}
			if (completed)
			{
				SlimJson.AddProperty("completed", completed);
			}
			if (rewardClaimed)
			{
				SlimJson.AddProperty("rewardClaimed", rewardClaimed);
			}
			if (actions != null && actions.Count > 0)
			{
				SlimJson.AddProperty("actions", actions.ToArray());
			}
			return SlimJson.EndSerialization();
		}
	}

	public class WeeklyQuest
	{
		public enum Type
		{
			FindAllStones = 0,
			UpgradeStarOuro = 1,
			UpgradeStarStone = 2,
			UpgradeOuroboros = 3,
			ImproveStars = 4,
			ImproveTime = 5
		}

		public Type type;

		public bool hasSeen;

		public bool completed;

		public string locId;

		public int goal;

		public static WeeklyQuest FromString(string sjson)
		{
			return new WeeklyQuest
			{
				type = SlimJson.ParseEnum<Type>(sjson, "type"),
				hasSeen = SlimJson.ParseBool(sjson, "hasSeen"),
				completed = SlimJson.ParseBool(sjson, "completed"),
				locId = SlimJson.Parse(sjson, "locId"),
				goal = SlimJson.ParseInt(sjson, "goal")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("type", type.ToString());
			SlimJson.AddProperty("hasSeen", hasSeen);
			SlimJson.AddProperty("completed", completed);
			if (locId != null)
			{
				SlimJson.AddProperty("locId", locId);
			}
			if (goal != 0)
			{
				SlimJson.AddProperty("goal", goal);
			}
			return SlimJson.EndSerialization();
		}
	}

	public class EventRewardCollection
	{
		public string checksum;

		public string id;

		private string signature;

		public EventReward[] free;

		public EventReward[] premium;

		public string GetSignature(DateTime eventStartDate)
		{
			if (signature == null)
			{
				return null;
			}
			string yearAbbreviated = Utils.GetYearAbbreviated(eventStartDate);
			return signature.Replace("<YY>", yearAbbreviated);
		}

		public static EventRewardCollection FromString(string sjson)
		{
			return new EventRewardCollection
			{
				checksum = SlimJson.Parse(sjson, "cs"),
				signature = SlimJson.Parse(sjson, "sig"),
				id = SlimJson.Parse(sjson, "id"),
				free = SlimJson.ParseArray(sjson, "f", EventReward.FromString),
				premium = SlimJson.ParseArray(sjson, "p", EventReward.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("cs", checksum);
			SlimJson.AddProperty("sig", signature);
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("f", free);
			SlimJson.AddProperty("p", premium);
			return SlimJson.EndSerialization();
		}
	}

	public class EventReward
	{
		public string itemId;

		public string iconPath;

		public string cosmeticId;

		private string signature;

		public int rarityBonus;

		public int count;

		public int level;

		public ItemData.Element element;

		public int countX;

		public int countY;

		public int rarityX;

		public int rarityY;

		public int levelY;

		public int lockY;

		public int iconX;

		public int iconY;

		public ItemInTreasure[] treasureItems;

		public Item item { get; set; }

		public bool IsSpecialEventTreasure()
		{
			return itemId == "treasure_event";
		}

		public bool IsTreasure()
		{
			return ItemFactory.singleton.IsTreasure(itemId);
		}

		public string GetSignature(DateTime eventStartDate)
		{
			if (signature == null)
			{
				return null;
			}
			string yearAbbreviated = Utils.GetYearAbbreviated(eventStartDate);
			return signature.Replace("<YY>", yearAbbreviated);
		}

		public static EventReward FromString(string sjson)
		{
			return new EventReward
			{
				itemId = SlimJson.Parse(sjson, "id"),
				iconPath = SlimJson.Parse(sjson, "iP"),
				cosmeticId = SlimJson.Parse(sjson, "cosm"),
				signature = SlimJson.Parse(sjson, "sig"),
				rarityBonus = SlimJson.ParseInt(sjson, "r"),
				count = SlimJson.ParseInt(sjson, "c", 1),
				level = SlimJson.ParseInt(sjson, "l", 1),
				element = SlimJson.ParseEnum<ItemData.Element>(sjson, "e"),
				countX = SlimJson.ParseInt(sjson, "cx"),
				countY = SlimJson.ParseInt(sjson, "cy"),
				rarityX = SlimJson.ParseInt(sjson, "rx"),
				rarityY = SlimJson.ParseInt(sjson, "ry"),
				levelY = SlimJson.ParseInt(sjson, "ly"),
				lockY = SlimJson.ParseInt(sjson, "Ly"),
				iconX = SlimJson.ParseInt(sjson, "ix"),
				iconY = SlimJson.ParseInt(sjson, "iy"),
				treasureItems = SlimJson.ParseArray(sjson, "items", ItemInTreasure.FromJson)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			if (itemId != null)
			{
				SlimJson.AddProperty("id", itemId);
			}
			if (iconPath != null)
			{
				SlimJson.AddProperty("iP", iconPath);
			}
			if (cosmeticId != null)
			{
				SlimJson.AddProperty("cosm", cosmeticId);
			}
			if (signature != null)
			{
				SlimJson.AddProperty("sig", signature);
			}
			if (rarityBonus != 0)
			{
				SlimJson.AddProperty("r", rarityBonus);
			}
			if (count != 1)
			{
				SlimJson.AddProperty("c", count);
			}
			if (level != 1)
			{
				SlimJson.AddProperty("l", level);
			}
			if (element != ItemData.Element.Stone)
			{
				SlimJson.AddProperty("e", element.ToString());
			}
			if (countX != 0)
			{
				SlimJson.AddProperty("cx", countX);
			}
			if (countY != 0)
			{
				SlimJson.AddProperty("cy", countY);
			}
			if (rarityX != 0)
			{
				SlimJson.AddProperty("rx", rarityX);
			}
			if (rarityY != 0)
			{
				SlimJson.AddProperty("ry", rarityY);
			}
			if (levelY != 0)
			{
				SlimJson.AddProperty("ly", levelY);
			}
			if (lockY != 0)
			{
				SlimJson.AddProperty("Ly", lockY);
			}
			if (iconX != 0)
			{
				SlimJson.AddProperty("ix", iconX);
			}
			if (iconY != 0)
			{
				SlimJson.AddProperty("iy", iconY);
			}
			if (treasureItems != null)
			{
				SlimJson.AddProperty("items", treasureItems);
			}
			return SlimJson.EndSerialization();
		}
	}
}
