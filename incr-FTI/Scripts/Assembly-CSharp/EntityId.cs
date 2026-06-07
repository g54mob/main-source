using System;

public readonly struct EntityId : IEquatable<EntityId>
{
	public readonly int intId;

	public readonly EntityType type;

	public const int customItemOffset = 1000000;

	public static EntityId None => new EntityId(0, EntityType.None);

	public object AsObject => type switch
	{
		EntityType.Building => AsBuilding, 
		EntityType.Item => AsItem, 
		EntityType.Recipe => AsRecipe, 
		EntityType.Structure => AsStructure, 
		EntityType.ItemConveyor => AsItemConveyor, 
		EntityType.NaturalResource => AsNaturalResource, 
		EntityType.Farming => AsFarming, 
		EntityType.Mining => AsMining, 
		EntityType.Quest => AsQuest, 
		EntityType.MenuPanel => AsMenuPanel, 
		EntityType.Research => AsResearch, 
		EntityType.FarmingTool => AsFarmingTool, 
		EntityType.Upgrade => AsUpgrade, 
		EntityType.Perk => AsPerk, 
		EntityType.Biome => AsBiome, 
		EntityType.Specialty => AsSpecialty, 
		EntityType.HarvestRecipe => AsHarvestRecipe, 
		_ => null, 
	};

	public BuildingType AsBuilding => (BuildingType)intId;

	public StructureType AsStructure => (StructureType)intId;

	public RecipeType AsRecipe => (RecipeType)intId;

	public ItemType AsItemConveyor => (ItemType)intId;

	public ItemType AsItem => (ItemType)intId;

	public NaturalResource AsNaturalResource => (NaturalResource)intId;

	public NaturalResource AsFarming => (NaturalResource)intId;

	public NaturalResource AsMining => (NaturalResource)intId;

	public QuestType AsQuest => (QuestType)intId;

	public UpgradeType AsUpgrade => (UpgradeType)intId;

	public PerkType AsPerk => (PerkType)intId;

	public BiomeType AsBiome => (BiomeType)intId;

	public MenuPanelType AsMenuPanel => (MenuPanelType)intId;

	public ResearchType AsResearch => (ResearchType)intId;

	public FarmingToolType AsFarmingTool => (FarmingToolType)intId;

	public Specialty AsSpecialty => (Specialty)intId;

	public HarvestRecipeType AsHarvestRecipe => (HarvestRecipeType)intId;

	public BuildingCategory AsBuildingCategory => (BuildingCategory)intId;

	public bool isCustom => intId >= 1000000;

	public EntityId(int id, EntityType type)
	{
		intId = id;
		this.type = type;
	}

	public EntityId GetCopy()
	{
		return new EntityId(intId, type);
	}

	public override bool Equals(object other)
	{
		if (other is EntityId other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(EntityId other)
	{
		if (intId == other.intId)
		{
			return type == other.type;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return intId + (int)type * 1000;
	}

	public static EntityId FromObject(object obj)
	{
		if (!(obj is EntityId entityId))
		{
			if (!(obj is ItemType t))
			{
				if (!(obj is BuildingType b))
				{
					if (!(obj is RecipeType t2))
					{
						if (!(obj is StructureType s))
						{
							if (!(obj is HarvestRecipeType t3))
							{
								if (!(obj is NaturalResource t4))
								{
									if (obj is QuestType t5)
									{
										return FromQuest(t5);
									}
									return default(EntityId);
								}
								return FromNaturalResource(t4);
							}
							return FromHarvestRecipe(t3);
						}
						return FromStructure(s);
					}
					return FromRecipe(t2);
				}
				return FromBuilding(b);
			}
			return FromItem(t);
		}
		return entityId.GetCopy();
	}

	public static EntityId FromGeneric(int i)
	{
		return new EntityId(i, EntityType.Generic);
	}

	public static EntityId FromCategory(BuildingCategory t)
	{
		return new EntityId((int)t, EntityType.BuildingCategory);
	}

	public static EntityId FromItem(ItemType t)
	{
		return new EntityId((int)t, EntityType.Item);
	}

	public static EntityId FromBuilding(BuildingType b)
	{
		return new EntityId((int)b, EntityType.Building);
	}

	public static EntityId FromRecipe(RecipeType t)
	{
		return new EntityId((int)t, EntityType.Recipe);
	}

	public static EntityId FromBuildingCategory(BuildingCategory t)
	{
		return new EntityId((int)t, EntityType.BuildingCategory);
	}

	public static EntityId FromSpecialty(Specialty t)
	{
		return new EntityId((int)t, EntityType.Specialty);
	}

	public static EntityId FromStructure(StructureType s)
	{
		return new EntityId((int)s, EntityType.Structure);
	}

	public static EntityId FromQuest(QuestType t)
	{
		return new EntityId((int)t, EntityType.Quest);
	}

	public static EntityId FromUpgrade(UpgradeType t)
	{
		return new EntityId((int)t, EntityType.Upgrade);
	}

	public static EntityId FromPerk(PerkType t)
	{
		return new EntityId((int)t, EntityType.Perk);
	}

	public static EntityId FromBiome(BiomeType t)
	{
		return new EntityId((int)t, EntityType.Biome);
	}

	public static EntityId FromResearch(ResearchType t)
	{
		return new EntityId((int)t, EntityType.Research);
	}

	public static EntityId FromFarmingTool(FarmingToolType t)
	{
		return new EntityId((int)t, EntityType.FarmingTool);
	}

	public static EntityId FromMenuPanel(MenuPanelType t)
	{
		return new EntityId((int)t, EntityType.MenuPanel);
	}

	public static EntityId FromItemConveyor(ItemType t)
	{
		return new EntityId((int)t, EntityType.ItemConveyor);
	}

	public static EntityId FromFarming(NaturalResource t)
	{
		return new EntityId((int)t, EntityType.Farming);
	}

	public static EntityId FromMining(NaturalResource t)
	{
		return new EntityId((int)t, EntityType.Mining);
	}

	public static EntityId FromNaturalResource(ItemType t)
	{
		return new EntityId((int)Item.NaturalResourceFromItem(t), EntityType.NaturalResource);
	}

	public static EntityId FromHarvestRecipe(HarvestRecipeType t)
	{
		return new EntityId((int)t, EntityType.HarvestRecipe);
	}

	public static EntityId FromNaturalResource(NaturalResource t)
	{
		return new EntityId((int)t, EntityType.NaturalResource);
	}

	public bool TryAsBuilding(out BuildingType b)
	{
		if (type == EntityType.Building)
		{
			b = (BuildingType)intId;
			return true;
		}
		b = BuildingType.None;
		return false;
	}

	public bool TryAsStructure(out StructureType s)
	{
		if (type == EntityType.Structure)
		{
			s = (StructureType)intId;
			return true;
		}
		s = StructureType.None;
		return false;
	}

	public bool TryAsRecipe(out RecipeType r)
	{
		if (type == EntityType.Recipe)
		{
			r = (RecipeType)intId;
			return true;
		}
		r = RecipeType.None;
		return false;
	}

	public bool TryAsBiome(out BiomeType t)
	{
		if (type == EntityType.Biome)
		{
			t = (BiomeType)intId;
			return true;
		}
		t = BiomeType.None;
		return false;
	}

	public bool TryAsItem(out ItemType i)
	{
		if (type == EntityType.Item)
		{
			i = (ItemType)intId;
			return true;
		}
		i = ItemType.None;
		return false;
	}

	public bool TryAsConveyor(out ItemType i)
	{
		if (type == EntityType.ItemConveyor)
		{
			i = (ItemType)intId;
			return true;
		}
		i = ItemType.None;
		return false;
	}

	public bool TryAsSpecialty(out Specialty t)
	{
		if (type == EntityType.Specialty)
		{
			t = (Specialty)intId;
			return true;
		}
		t = Specialty.None;
		return false;
	}

	public bool TryAsBuildingCategory(out BuildingCategory c)
	{
		if (type == EntityType.BuildingCategory)
		{
			c = (BuildingCategory)intId;
			return true;
		}
		c = BuildingCategory.None;
		return false;
	}

	public bool TryAsMenuPanel(out MenuPanelType p)
	{
		if (type == EntityType.MenuPanel)
		{
			p = (MenuPanelType)intId;
			return true;
		}
		p = MenuPanelType.None;
		return false;
	}

	public bool TryAsFarmingTool(out FarmingToolType i)
	{
		if (type == EntityType.FarmingTool)
		{
			i = (FarmingToolType)intId;
			return true;
		}
		i = FarmingToolType.None;
		return false;
	}

	public bool TryAsResearch(out ResearchType i)
	{
		if (type == EntityType.Research)
		{
			i = (ResearchType)intId;
			return true;
		}
		i = ResearchType.None;
		return false;
	}

	public bool TryAsQuest(out QuestType i)
	{
		if (type == EntityType.Quest)
		{
			i = (QuestType)intId;
			return true;
		}
		i = QuestType.None;
		return false;
	}

	public bool TryAsUpgrade(out UpgradeType i)
	{
		if (type == EntityType.Upgrade)
		{
			i = (UpgradeType)intId;
			return true;
		}
		i = UpgradeType.None;
		return false;
	}

	public bool TryAsPerk(out PerkType i)
	{
		if (type == EntityType.Perk)
		{
			i = (PerkType)intId;
			return true;
		}
		i = PerkType.None;
		return false;
	}

	public bool TryAsFarming(out NaturalResource i)
	{
		if (type == EntityType.Farming)
		{
			i = (NaturalResource)intId;
			return true;
		}
		i = NaturalResource.None;
		return false;
	}

	public bool TryAsMining(out NaturalResource i)
	{
		if (type == EntityType.Mining)
		{
			i = (NaturalResource)intId;
			return true;
		}
		i = NaturalResource.None;
		return false;
	}

	public bool TryAsNaturalResource(out NaturalResource i)
	{
		if (type == EntityType.NaturalResource)
		{
			i = (NaturalResource)intId;
			return true;
		}
		i = NaturalResource.None;
		return false;
	}

	public bool TryAsHarvestRecipe(out HarvestRecipeType i)
	{
		if (type == EntityType.HarvestRecipe)
		{
			i = (HarvestRecipeType)intId;
			return true;
		}
		i = HarvestRecipeType.None;
		return false;
	}

	public override string ToString()
	{
		if (TryAsBuilding(out var b))
		{
			return "Entity Building " + b;
		}
		if (TryAsBuildingCategory(out var c))
		{
			return "Entity Category " + c;
		}
		if (TryAsSpecialty(out var t))
		{
			return "Entity Specialty " + t;
		}
		return "Id:" + intId + "/" + type.ToString() + " = " + AsObject;
	}

	public bool IsItem(ItemType testItem)
	{
		if (TryAsItem(out var i))
		{
			return i == testItem;
		}
		return false;
	}

	public ItemType AsGenericItem()
	{
		if (type == EntityType.Item || type == EntityType.ItemConveyor)
		{
			return (ItemType)intId;
		}
		return ItemType.None;
	}

	public bool UsesTooltipPanel()
	{
		if (type == EntityType.MenuPanel)
		{
			return false;
		}
		if (TryAsItem(out var i))
		{
			return i != ItemType.UtilityQuestCoin;
		}
		return true;
	}
}
