public class QuestEvent
{
	public enum Type
	{
		Make = 0,
		MakeConverter = 1,
		Pickup = 2,
		Store = 3,
		Build = 4,
		CompleteMission = 5,
		CompleteTutorial = 6,
		CompleteAnyMission = 7,
		MakeAnyPorridge = 8,
		MakeTop = 9,
		MakeHat = 10,
		MakeWorkerWithFrameMk1 = 11,
		MakeWorkerWithHeadMk1 = 12,
		MakeWorkerWithDriveMk1 = 13,
		MakeWorkerMk2 = 14,
		MakeCrudeTool = 15,
		MakeCrudeMetalTool = 16,
		MakeStructuralPart = 17,
		MakePlank = 18,
		UseRockingChairTop = 19,
		UseRockingChairHat = 20,
		PickupAnything = 21,
		DropAnything = 22,
		StoreLiquid = 23,
		StoreParticulate = 24,
		StoreFood = 25,
		AddToStoragePalette = 26,
		StorageUsed = 27,
		Take = 28,
		ScytheWheat = 29,
		ScytheWheatWithScytheCrude = 30,
		ScytheWheatWithScythe = 31,
		ScytheCotton = 32,
		ScytheBullrushes = 33,
		ScytheGrass = 34,
		ScythePumpkin = 35,
		ScytheFlower = 36,
		UseRockSharpOnCrops = 37,
		FlailWheat = 38,
		UseFlailCrude = 39,
		UseFlail = 40,
		FlailBush = 41,
		ThreshWheat = 42,
		ThreshWheatWithStick = 43,
		ThreshCottonBalls = 44,
		ThreshBullrushesStems = 45,
		Chop = 46,
		ChopTree = 47,
		ChopTreeWithRock = 48,
		ChopTreeWithAxeCrude = 49,
		ChopTreeWithWoodAxe = 50,
		ChopLog = 51,
		ChopPlank = 52,
		ChopPole = 53,
		ProcessWood = 54,
		Shovel = 55,
		ShovelWithShovelCrude = 56,
		ShovelWithShovel = 57,
		Dig = 58,
		DigWeed = 59,
		DigMushroom = 60,
		DigSoil = 61,
		DigCarrot = 62,
		HoeWithHoeCrude = 63,
		HoeWithHoe = 64,
		Hoe = 65,
		MineWithPickaxeCrude = 66,
		MineStone = 67,
		MineStoneDeposits = 68,
		MineClay = 69,
		UsePickaxe = 70,
		MineIron = 71,
		MineCoal = 72,
		MineTallBoulder = 73,
		MineArea = 74,
		ChiselWithChiselCrude = 75,
		UseBucketCrude = 76,
		UseBucket = 77,
		FillBucket = 78,
		FillBucketSand = 79,
		FillBucketSandOrSoil = 80,
		FillBucketHoney = 81,
		DredgeWithCrudeDredger = 82,
		LeechCaught = 83,
		BashPumpkin = 84,
		BashBoulderWithRock = 85,
		BashBush = 86,
		BashAppleTree = 87,
		BashCoconutTree = 88,
		PlantTreeSeed = 89,
		PlantBerries = 90,
		PlantWheat = 91,
		PlantCotton = 92,
		PlantBullrushes = 93,
		PlantMushroom = 94,
		PlantSeedling = 95,
		PlantMulberrySeed = 96,
		PlantSeedlingMulberry = 97,
		PlantCropSeed = 98,
		PlantManure = 99,
		PlantPumpkinSeeds = 100,
		PlantFertiliser = 101,
		PlantApple = 102,
		PlantCarrotSeed = 103,
		PlantCoconut = 104,
		Carry = 105,
		Move = 106,
		MoveWater = 107,
		MoveCanoe = 108,
		MoveWheelbarrow = 109,
		MoveCart = 110,
		UseClayStationCrude = 111,
		UseOvenCrude = 112,
		UseWorkbench = 113,
		UseWater = 114,
		CatchBait = 115,
		CatchFish = 116,
		ForageFood = 117,
		MilkCow = 118,
		MilkCowInMilkingShed = 119,
		ShearSheep = 120,
		ShearSheepInShearingShed = 121,
		UpgradeBot = 122,
		Research = 123,
		CompleteResearch = 124,
		Stack20Objects = 125,
		MakeFolkHeart = 126,
		FolkDied = 127,
		RainOnFolk = 128,
		FeedFolk = 129,
		ClotheFolk = 130,
		ToyFolk = 131,
		MedicineFolk = 132,
		EducateFolk = 133,
		ArtFolk = 134,
		FolkTranscended = 135,
		MakeFolkHappy = 136,
		MakeFolkHoused = 137,
		BeeMakesHoney = 138,
		ChickenCoopMakeEgg = 139,
		FeedChicken = 140,
		BirdEatCrops = 141,
		Pen5Animals = 142,
		PenCows = 143,
		PenSheep = 144,
		PenChooks = 145,
		GrowWheat = 146,
		GrowTree = 147,
		GrowMushroom = 148,
		GrowFlower = 149,
		CreateTreeSeed = 150,
		StowWhistleCrude = 151,
		UseWhistle = 152,
		GiveAxeToBot = 153,
		GiveBotAnything = 154,
		TakeBotAnything = 155,
		BuildAnything = 156,
		PlotUncovered = 157,
		RechargeBot = 158,
		TeachChopTree = 159,
		TeachPickupLog = 160,
		TeachAddToStoragePalette = 161,
		SelectBot = 162,
		ClickRecord = 163,
		ClickRepeat = 164,
		ClickPlay = 165,
		ClickStop = 166,
		ClickObject = 167,
		Group3Bots = 168,
		BotTeach = 169,
		EditSearchArea = 170,
		UseMaxArea = 171,
		UseObjectArea = 172,
		ObjectAreaSelect = 173,
		EndEditSearchArea = 174,
		RolloverBoulder = 175,
		RolloverBush = 176,
		RolloverCrops = 177,
		BurnWood = 178,
		Land = 179,
		Communicate = 180,
		UpdateStoredSticks = 181,
		UpdateFedFolk = 182,
		UpdateHousedFolk = 183,
		UseObject = 184,
		Stow = 185,
		Recall = 186,
		SelectBlueprint = 187,
		AddBlueprint = 188,
		EditMode = 189,
		EndEditMode = 190,
		EngageConverter = 191,
		ConverterSelectObject = 192,
		CloseBrain = 193,
		SelectAutopedia = 194,
		MoveCamera = 195,
		ZoomCamera = 196,
		RecentreCamera = 197,
		UntilBuildingFullChosen = 198,
		UntilHandsEmptyChosen = 199,
		SelectAutopediaObjects = 200,
		SelectAutopediaFood = 201,
		SelectAutopediaObjectType = 202,
		AltHover = 203,
		BotServerComplete = 204,
		SpacePortComplete = 205,
		Total = 206
	}

	private static string[] m_TypeNames;

	public Type m_Type;

	public bool m_BotOnly;

	public object m_ExtraData;

	public int m_Required;

	public int m_Progress;

	public bool m_Complete;

	public bool m_Completable;

	public ObjectType m_LockedObject;

	public string m_Description;

	public bool m_Locked;

	public QuestEvent(Type NewType, bool BotOnly, object ExtraData, int Required, string Description = "")
	{
		m_Type = NewType;
		m_BotOnly = BotOnly;
		m_ExtraData = ExtraData;
		m_Required = Required;
		m_Progress = 0;
		m_Complete = false;
		m_Locked = false;
		m_Description = Description;
	}

	public bool AddEvent(int Value)
	{
		if (m_Locked && m_Type != Type.Build)
		{
			return false;
		}
		if (m_Progress < m_Required)
		{
			int progress = m_Progress;
			if (m_Type == Type.UpdateStoredSticks)
			{
				m_Progress = StorageTypeManager.Instance.GetStored(ObjectType.Stick);
			}
			else if (m_Type == Type.UpdateFedFolk)
			{
				m_Progress = FolkManager.Instance.GetFedFolk();
			}
			else if (m_Type == Type.UpdateHousedFolk)
			{
				m_Progress = FolkManager.Instance.GetHousedFolk();
			}
			else if (m_Type == Type.MakeFolkHappy)
			{
				m_Progress = FolkManager.Instance.GetHappy();
			}
			else if (m_Type == Type.MakeFolkHoused)
			{
				m_Progress = FolkManager.Instance.GetHoused();
			}
			else if (m_Type == Type.PenCows || m_Type == Type.PenSheep || m_Type == Type.PenChooks)
			{
				m_Progress = Value;
			}
			else
			{
				m_Progress += Value;
			}
			if (m_Type == Type.Research && CheatManager.Instance.m_CheapResearch)
			{
				m_Progress = m_Required;
			}
			if (m_Progress >= m_Required)
			{
				m_Progress = m_Required;
				m_Complete = true;
			}
			else if (progress >= m_Progress)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public void SetProgress(int Progress)
	{
		m_Progress = Progress;
		if (m_Progress >= m_Required)
		{
			m_Progress = m_Required;
			m_Complete = true;
		}
	}

	public void Reset()
	{
		m_Progress = 0;
		m_Complete = false;
	}

	public string GetExtraDataAsString()
	{
		if (DoesTypeNeedExtraDataObject(m_Type))
		{
			return ObjectTypeList.Instance.GetSaveNameFromIdentifier((ObjectType)m_ExtraData);
		}
		if (DoesTypeNeedExtraDataMission(m_Type))
		{
			return QuestData.Instance.GetQuestNameFromID((Quest.ID)m_ExtraData);
		}
		if (DoesTypeNeedExtraDataTileType(m_Type))
		{
			return Tile.GetNameFromType((Tile.TileType)m_ExtraData);
		}
		return "";
	}

	public static object GetExtraDataFromString(Type TestEvent, string ExtraData)
	{
		if (DoesTypeNeedExtraDataObject(TestEvent))
		{
			return ObjectTypeList.Instance.GetIdentifierFromSaveName(ExtraData);
		}
		if (DoesTypeNeedExtraDataMission(TestEvent))
		{
			return QuestData.Instance.GetQuestIDFromName(ExtraData);
		}
		if (DoesTypeNeedExtraDataTileType(TestEvent))
		{
			return Tile.GetTypeFromName(ExtraData);
		}
		return null;
	}

	public void SetExtraDataFromString(string ExtraData)
	{
		m_ExtraData = GetExtraDataFromString(m_Type, ExtraData);
	}

	public bool DoesTypeMatch(Type TestEvent, bool BotOnly, object ExtraData)
	{
		if (m_Type != TestEvent)
		{
			return false;
		}
		if (DoesTypeNeedExtraDataObject(m_Type) && (ObjectType)ExtraData != (ObjectType)m_ExtraData)
		{
			return false;
		}
		if (DoesTypeNeedExtraDataMission(TestEvent) && (Quest.ID)ExtraData != (Quest.ID)m_ExtraData)
		{
			return false;
		}
		if (DoesTypeNeedExtraDataTileType(TestEvent) && (Tile.TileType)ExtraData != (Tile.TileType)m_ExtraData)
		{
			return false;
		}
		return true;
	}

	public string GetDisplayString()
	{
		string nameFromType = GetNameFromType(m_Type);
		return TextManager.Instance.Get(nameFromType, GetExtraDataString());
	}

	public string GetExtraDataString()
	{
		if (DoesTypeNeedExtraDataObject(m_Type))
		{
			return ObjectTypeList.Instance.GetHumanReadableNameFromIdentifier((ObjectType)m_ExtraData);
		}
		if (DoesTypeNeedExtraDataMission(m_Type))
		{
			string tag = ((Quest.ID)m_ExtraData/*cast due to .constrained prefix*/).ToString();
			return TextManager.Instance.Get(tag);
		}
		if (DoesTypeNeedExtraDataTileType(m_Type))
		{
			string nameFromType = Tile.GetNameFromType((Tile.TileType)m_ExtraData);
			return TextManager.Instance.Get(nameFromType);
		}
		return "";
	}

	public static bool DoesTypeNeedBuildingObjects(Type NewType)
	{
		if (NewType == Type.Build || NewType == Type.EngageConverter)
		{
			return true;
		}
		return false;
	}

	public static bool DoesTypeNeedExtraDataObject(Type NewType)
	{
		if (NewType == Type.Make || NewType == Type.Pickup || NewType == Type.Build || NewType == Type.Store || NewType == Type.StorageUsed || NewType == Type.ClickObject || NewType == Type.EngageConverter || NewType == Type.ConverterSelectObject || NewType == Type.GiveBotAnything || NewType == Type.SelectBlueprint || NewType == Type.AddBlueprint || NewType == Type.ObjectAreaSelect || NewType == Type.Take || NewType == Type.MakeConverter || NewType == Type.SelectAutopediaObjectType)
		{
			return true;
		}
		return false;
	}

	public static bool DoesTypeNeedExtraDataMission(Type NewType)
	{
		if (NewType == Type.CompleteMission)
		{
			return true;
		}
		return false;
	}

	public static bool DoesTypeNeedExtraDataTileType(Type NewType)
	{
		if (NewType == Type.MineArea)
		{
			return true;
		}
		return false;
	}

	public bool DoesTypeNeedExtraDataObject()
	{
		return DoesTypeNeedExtraDataObject(m_Type);
	}

	public bool DoesTypeNeedExtraDataMission()
	{
		return DoesTypeNeedExtraDataMission(m_Type);
	}

	public bool DoesTypeNeedExtraDataTileType()
	{
		return DoesTypeNeedExtraDataTileType(m_Type);
	}

	public static void Init()
	{
		int num = 206;
		m_TypeNames = new string[num];
		for (int i = 0; i < num; i++)
		{
			string[] typeNames = m_TypeNames;
			int num2 = i;
			Type type = (Type)i;
			typeNames[num2] = "Event" + type;
		}
	}

	public static string GetNameFromType(Type NewType)
	{
		return m_TypeNames[(int)NewType];
	}

	public static Type GetTypeFromName(string Name)
	{
		for (int i = 0; i < m_TypeNames.Length; i++)
		{
			if (m_TypeNames[i] == Name)
			{
				return (Type)i;
			}
		}
		return Type.Total;
	}

	public void UpdateCanBeCompleted(Quest Parent)
	{
		m_LockedObject = ObjectTypeList.m_Total;
		m_Completable = true;
		if (DoesTypeNeedExtraDataObject())
		{
			if (m_ExtraData == null)
			{
				ErrorMessage.LogError(string.Concat("Bad data for Quest ", Parent.m_ID, " Event ", m_Type));
			}
			m_LockedObject = (ObjectType)m_ExtraData;
			if (m_LockedObject != ObjectTypeList.m_Total && m_LockedObject != ObjectType.Nothing)
			{
				if (QuestManager.Instance.GetIsObjectLocked(m_LockedObject) || QuestManager.Instance.GetIsBuildingLocked(m_LockedObject))
				{
					m_Completable = false;
				}
				else
				{
					IngredientRequirement[] ingredientsFromIdentifier = ObjectTypeList.Instance.GetIngredientsFromIdentifier(m_LockedObject);
					for (int i = 0; i < ingredientsFromIdentifier.Length; i++)
					{
						IngredientRequirement ingredientRequirement = ingredientsFromIdentifier[i];
						if (QuestManager.Instance.GetIsObjectLocked(ingredientRequirement.m_Type))
						{
							m_Completable = false;
						}
					}
				}
			}
		}
		if (m_Type != Type.Research)
		{
			return;
		}
		m_LockedObject = ObjectType.ResearchStationCrude;
		if (QuestManager.Instance.GetIsBuildingLocked(m_LockedObject))
		{
			m_Completable = false;
		}
		if (Parent.m_ObjectTypeRequired != ObjectTypeList.m_Total && Parent.m_ObjectTypeRequired != ObjectType.Nothing)
		{
			m_LockedObject = Parent.m_ObjectTypeRequired;
			if (QuestManager.Instance.GetIsObjectLocked(m_LockedObject))
			{
				m_Completable = false;
			}
		}
	}

	public bool CanBeCompleted()
	{
		return m_Completable;
	}
}
