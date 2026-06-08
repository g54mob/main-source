using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class Item : MonoBehaviour
{
	[Serializable]
	public class Description
	{
		public string line1;

		public string line2;

		public string line3;
	}

	public string id;

	public string displayName;

	public int level = 1;

	public int complexity;

	public bool isSocketed;

	public bool procGenAbilities;

	public bool isLost;

	public bool appearInDrops;

	public string iconPath;

	public string hudSymbol;

	public bool canCraftOnAnvil = true;

	public bool canMutateOnMoondial;

	public bool canBoostLostItem;

	public bool showBasicStats = true;

	public bool showLevelInTitle = true;

	public int collectionGoal = -1;

	public int sortValue;

	public List<string> tags;

	public ItemData.Element element;

	public string[] preloadDependencies;

	public ItemData.Stat[] baseStats;

	public ItemData.Ability[] baseAbilities;

	public string[] baseAbilityIds;

	[SerializeField]
	private ItemData.Rarity _rarity;

	public bool hasInteracted;

	private SafeInt _count;

	private SafeInt _lostCount;

	private SafeInt _lostBoosts;

	public Description description;

	private Character owner;

	private StatModController _statModController;

	private bool abilitiesLoaded;

	public List<string> extraAbilityIds { get; set; }

	public List<ItemData.Ability> abilities { get; set; }

	public ItemData.Rarity rarity
	{
		get
		{
			return _rarity;
		}
		set
		{
			_rarity = value;
			OnRarityChanged();
		}
	}

	public int rngSeed { get; set; }

	public int count
	{
		get
		{
			return _count.GetValue();
		}
		set
		{
			_count = new SafeInt(value);
		}
	}

	public int lostCount
	{
		get
		{
			return _lostCount.GetValue();
		}
		set
		{
			_lostCount = new SafeInt(value);
		}
	}

	public int lostBoostsUsed
	{
		get
		{
			return _lostBoosts.GetValue();
		}
		set
		{
			_lostBoosts = new SafeInt(value);
		}
	}

	public bool isShiny { get; set; }

	public string nameTag { get; set; }

	public bool isNamed => !string.IsNullOrEmpty(nameTag);

	public string signature { get; set; }

	public bool isSigned => !string.IsNullOrEmpty(signature);

	public string cosmeticId { get; set; }

	public Cosmetic cosmetic { get; set; }

	public Character Owner
	{
		get
		{
			return owner;
		}
		set
		{
			owner = value;
		}
	}

	public StatModController statModController => _statModController;

	public StonescriptObject ssObject
	{
		get
		{
			SSScriptableObject sSScriptableObject = GetComponent<SSScriptableObject>();
			if (sSScriptableObject == null)
			{
				sSScriptableObject = base.gameObject.AddComponent<SSScriptableObject>();
			}
			return sSScriptableObject.Target;
		}
	}

	public event Action<Item> OnExecute;

	public virtual void SetHasInteracted(bool value)
	{
		hasInteracted = value;
	}

	protected virtual void Execute()
	{
		FireOnExecute();
	}

	protected void FireOnExecute()
	{
		if (this.OnExecute != null)
		{
			this.OnExecute(this);
		}
	}

	public virtual string GetGroupId()
	{
		if (isLost)
		{
			return id;
		}
		string text = id + "_lv" + level;
		if (element != ItemData.Element.Stone)
		{
			text = text + "_" + element;
		}
		int num = 0;
		while (extraAbilityIds != null && num < extraAbilityIds.Count)
		{
			text = text + "," + extraAbilityIds[num];
			num++;
		}
		if (GetRarityType() != ItemData.Rarity.Type.Common && rarity != null)
		{
			text = text + "_" + rarity.type.ToString() + rarity.levelBonus + ":" + rarity.selectedAbilityIndex + "q" + rarity.quality;
		}
		if (isShiny)
		{
			text += "S";
		}
		if (isNamed)
		{
			text = text + "_" + nameTag;
		}
		if (isSigned)
		{
			text = text + "_" + signature;
		}
		return text;
	}

	public virtual string GetName()
	{
		string text;
		if (isNamed)
		{
			text = nameTag;
		}
		else
		{
			text = Te.xt(displayName);
			string newValue = Te.xt(ItemData.ReplacementTidForElement(element));
			text = text.Replace("<element>", newValue);
		}
		if (rarity != null && rarity.levelBonus > 0)
		{
			text = text + " +" + rarity.levelBonus;
		}
		return text;
	}

	public void ForEachStatModController(Action<StatModController> function)
	{
		if (Owner != null && Owner.statModController != null)
		{
			function(Owner.statModController);
		}
		if (statModController != null)
		{
			function(statModController);
		}
	}

	public Cosmetic GetCosmetic()
	{
		if (cosmetic == null && !string.IsNullOrEmpty(cosmeticId))
		{
			cosmetic = CosmeticController.singleton.FindInventoryCosmetic(this);
		}
		if (cosmetic != null)
		{
			return cosmetic;
		}
		return null;
	}

	public virtual ItemData.Rarity.Type GetRarityType()
	{
		if (rarity == null)
		{
			return ItemData.Rarity.Type.Common;
		}
		return rarity.type;
	}

	public int GetRarityBonus()
	{
		if (rarity == null)
		{
			return 0;
		}
		return rarity.levelBonus;
	}

	public virtual AsciiSprite GetIcon()
	{
		Cosmetic cosmetic = GetCosmetic();
		if (cosmetic != null)
		{
			return cosmetic.GetCosmeticIcon(this);
		}
		ItemData.Rarity.Type rarityType = GetRarityType();
		AsciiSprite sharedIcon = IconLoader.Singleton.GetSharedIcon(iconPath, 'o', ItemData.CharForElement(element), rarityType, isShiny);
		if (sharedIcon == null)
		{
			Utils.LogError("couldn't load icon for item " + id);
		}
		return sharedIcon;
	}

	public virtual string GetDescription()
	{
		return null;
	}

	public virtual Color GetLabelColor()
	{
		Cosmetic cosmetic = GetCosmetic();
		if (cosmetic != null)
		{
			return cosmetic.GetCosmeticLabelColor(this);
		}
		return ItemData.Rarity.GetColorForRarity(GetRarityType());
	}

	public int ComputeRerollCost()
	{
		if (EventController.singleton.IsEventActive("free_rerolls"))
		{
			return 0;
		}
		int num = 1000 + GetRarityBonus() * 100;
		if (HamartiaEventController.IsEventActive())
		{
			num /= 10;
		}
		return num;
	}

	public int ComputeSplitApartCost()
	{
		if (EventController.singleton.IsEventActive("free_rerolls"))
		{
			return 0;
		}
		if (ItemFactory.GetLevelDisplayIntegerForItem(this) <= 1)
		{
			return 0;
		}
		return GetRarityBonus() * 200;
	}

	public static Item FromString(string sjson)
	{
		return ItemFactory.singleton.ItemFromString(sjson);
	}

	public override string ToString()
	{
		return ItemFactory.singleton.ItemToString(this);
	}

	public string SerializeData(bool includeNameTag = true)
	{
		SlimJson.BeginSerialization();
		if (hasInteracted)
		{
			SlimJson.AddProperty("hI", property: true);
		}
		if (level != 1)
		{
			SlimJson.AddProperty("lv", level);
		}
		if (element != ItemData.Element.Stone)
		{
			SlimJson.AddProperty("el", element.ToString());
		}
		if (extraAbilityIds != null)
		{
			SlimJson.AddProperty("abs", extraAbilityIds.ToArray());
		}
		if (rarity != null)
		{
			SlimJson.AddProperty("ra", rarity.ToString());
		}
		SlimJson.AddProperty("rng", rngSeed);
		if (isShiny)
		{
			SlimJson.AddProperty("sh", property: true);
		}
		if (isLost)
		{
			SlimJson.AddProperty("lC", lostCount);
			SlimJson.AddProperty("lBU", lostBoostsUsed);
		}
		if (isNamed && includeNameTag)
		{
			SlimJson.AddProperty("tag", nameTag);
		}
		if (isSigned)
		{
			SlimJson.AddProperty("sig", signature);
		}
		if (cosmeticId != null)
		{
			SlimJson.AddProperty("c", cosmeticId);
		}
		SerializeMore();
		return SlimJson.EndSerialization();
	}

	public void ParseData(string sjson)
	{
		if (SlimJson.HasKey(sjson, "has_interacted"))
		{
			hasInteracted = SlimJson.ParseBool(sjson, "has_interacted");
			level = SlimJson.ParseInt(sjson, "level", 1);
			for (int i = ItemFactory.GetLevelDisplayIntegerForItem(this); i < 1; i++)
			{
				level *= 2;
			}
			element = SlimJson.ParseEnum<ItemData.Element>(sjson, "element");
			string[] array = SlimJson.ParseArray(sjson, "abilityIds");
			if (array != null)
			{
				extraAbilityIds = new List<string>(array);
			}
			rarity = SlimJson.Parse(sjson, "rarity", ItemData.Rarity.FromString);
			rngSeed = SlimJson.ParseInt(sjson, "rngSeed");
			isShiny = SlimJson.HasKey(sjson, "isShiny");
			if (isLost)
			{
				lostCount = SlimJson.ParseInt(sjson, "lostCount", 1);
				lostBoostsUsed = SlimJson.ParseInt(sjson, "lostBoostsUsed");
			}
			string text = SlimJson.Parse(sjson, "nameTag");
			if (text != null)
			{
				nameTag = text;
			}
			string text2 = SlimJson.Parse(sjson, "signature");
			if (text2 != null)
			{
				signature = text2;
			}
		}
		else
		{
			hasInteracted = SlimJson.ParseBool(sjson, "hI");
			level = SlimJson.ParseInt(sjson, "lv", 1);
			for (int j = ItemFactory.GetLevelDisplayIntegerForItem(this); j < 1; j++)
			{
				level *= 2;
			}
			element = SlimJson.ParseEnum<ItemData.Element>(sjson, "el");
			string[] array2 = SlimJson.ParseArray(sjson, "abs");
			if (array2 != null)
			{
				extraAbilityIds = new List<string>(array2);
			}
			rarity = SlimJson.Parse(sjson, "ra", ItemData.Rarity.FromString);
			rngSeed = SlimJson.ParseInt(sjson, "rng");
			isShiny = SlimJson.HasKey(sjson, "sh");
			if (isLost)
			{
				lostCount = SlimJson.ParseInt(sjson, "lC", 1);
				lostBoostsUsed = SlimJson.ParseInt(sjson, "lBU");
			}
			string text3 = SlimJson.Parse(sjson, "tag");
			if (text3 != null)
			{
				nameTag = text3;
			}
			string text4 = SlimJson.Parse(sjson, "sig");
			if (text4 != null)
			{
				signature = text4;
			}
			cosmeticId = SlimJson.Parse(sjson, "c");
		}
		ParseMore(sjson);
	}

	public virtual void SerializeMore()
	{
	}

	public virtual void ParseMore(string sjson)
	{
	}

	public int GetTotalAbilityCount()
	{
		int num = 0;
		for (int i = 0; i < baseStats.Length; i++)
		{
			if (baseStats[i].canBeEnchanted)
			{
				num++;
			}
		}
		for (int j = 0; j < baseAbilities.Length; j++)
		{
			if (baseAbilities[j].canBeEnchanted)
			{
				num++;
			}
		}
		for (int k = 0; k < baseAbilityIds.Length; k++)
		{
			ItemData.Ability abilityById = ItemFactory.singleton.GetAbilityById(baseAbilityIds[k]);
			if (abilityById != null && abilityById.canBeEnchanted)
			{
				num++;
			}
		}
		if (extraAbilityIds != null)
		{
			for (int l = 0; l < extraAbilityIds.Count; l++)
			{
				ItemData.Ability abilityById2 = ItemFactory.singleton.GetAbilityById(extraAbilityIds[l]);
				if (abilityById2 != null && abilityById2.canBeEnchanted)
				{
					num++;
				}
			}
		}
		WeaponActivatedAbility component = GetComponent<WeaponActivatedAbility>();
		if (component != null)
		{
			for (int m = 0; m < component.abilityStats.Length; m++)
			{
				if (component.abilityStats[m].canBeEnchanted)
				{
					num++;
				}
			}
		}
		return num;
	}

	public void LoadAbilities()
	{
		if (abilitiesLoaded)
		{
			return;
		}
		int num = -1;
		if (rarity != null)
		{
			int totalAbilityCount = GetTotalAbilityCount();
			num = ((totalAbilityCount < 1) ? rarity.selectedStatSeed : (rarity.selectedStatSeed % totalAbilityCount));
			rarity.selectedAbilityIndex = num;
		}
		int num2 = 0;
		for (int i = 0; i < baseStats.Length; i++)
		{
			bool applyRarity = false;
			if (baseStats[i].canBeEnchanted)
			{
				applyRarity = num2 == num;
				num2++;
			}
			ItemData.Ability ability = MakeBaseAbilityFromStat(baseStats[i]);
			LoadAbility(ability, applyRarity);
		}
		for (int j = 0; j < baseAbilities.Length; j++)
		{
			bool applyRarity2 = false;
			if (baseAbilities[j].canBeEnchanted)
			{
				applyRarity2 = num2 == num;
				num2++;
			}
			LoadAbility(baseAbilities[j], applyRarity2);
		}
		for (int k = 0; k < baseAbilityIds.Length; k++)
		{
			bool applyRarity3 = false;
			ItemData.Ability abilityById = ItemFactory.singleton.GetAbilityById(baseAbilityIds[k]);
			if (abilityById != null && abilityById.canBeEnchanted)
			{
				applyRarity3 = num2 == num;
				num2++;
			}
			LoadAbilityById(baseAbilityIds[k], applyRarity3);
		}
		if (extraAbilityIds != null)
		{
			for (int l = 0; l < extraAbilityIds.Count; l++)
			{
				bool applyRarity4 = false;
				ItemData.Ability abilityById2 = ItemFactory.singleton.GetAbilityById(extraAbilityIds[l]);
				if (abilityById2 != null && abilityById2.canBeEnchanted)
				{
					applyRarity4 = num2 == num;
					num2++;
				}
				LoadAbilityById(extraAbilityIds[l], applyRarity4);
			}
		}
		WeaponActivatedAbility component = GetComponent<WeaponActivatedAbility>();
		if (component != null)
		{
			for (int m = 0; m < component.abilityStats.Length; m++)
			{
				ItemData.Ability ability2 = component.abilityStats[m];
				if (ability2.canBeEnchanted)
				{
					ability2.applyRarity = num2 == num;
					num2++;
					ability2.stat.TryInitDataHeavyStat(id);
				}
			}
		}
		Character.OnCharacterEquippedWeapon += HandleCharacterEquippedWeapon;
		Character.OnCharacterUnequippedWeapon += HandleCharacterUnequippedWeapon;
		Character.OnCharacterAttackEnded += HandleCharacterAttackEnded;
		abilitiesLoaded = true;
	}

	private ItemData.Ability MakeBaseAbilityFromStat(ItemData.Stat stat)
	{
		ItemData.Ability ability = new ItemData.Ability();
		ability.id = "base_ability_" + ((abilities != null) ? abilities.Count : 0);
		if (stat.type == ItemData.Stat.Type.ArmorPerSecond || stat.type == ItemData.Stat.Type.MaxArmor || stat.type == ItemData.Stat.Type.EvadeChance || stat.type == ItemData.Stat.Type.Health)
		{
			ability.applyWhen = ItemData.Ability.ApplyWhen.Equip;
			ability.applyTo = ItemData.Ability.ApplyTo.Character;
		}
		else
		{
			ability.applyWhen = ItemData.Ability.ApplyWhen.Start;
			ability.applyTo = ItemData.Ability.ApplyTo.Item;
		}
		ability.applySubAbility = false;
		ability.stat = stat;
		for (int i = 0; i < stat.customParams.Length; i++)
		{
			string text = stat.customParams[i];
			if (text.StartsWith("sibling:"))
			{
				ability.sibling = text.Substring(8);
				break;
			}
		}
		return ability;
	}

	private void LoadAbilityById(string abilityId, bool applyRarity)
	{
		ItemData.Ability abilityById = ItemFactory.singleton.GetAbilityById(abilityId);
		if (abilityById != null)
		{
			abilityById = abilityById.Clone();
			LoadAbility(abilityById, applyRarity);
		}
	}

	private void LoadAbility(ItemData.Ability ability, bool applyRarity)
	{
		if (ability == null || (!applyRarity && ability.stat != null && ability.stat.rareStatOnly))
		{
			return;
		}
		if (abilities == null)
		{
			abilities = new List<ItemData.Ability>();
		}
		bool flag = applyRarity;
		if (!applyRarity && ability.sibling != null)
		{
			for (int i = 0; i < abilities.Count; i++)
			{
				if (ability.sibling == abilities[i].id)
				{
					applyRarity = abilities[i].applyRarity;
					break;
				}
			}
		}
		if (applyRarity)
		{
			for (int j = 0; j < abilities.Count; j++)
			{
				if (!(abilities[j].id == ability.id) && !(abilities[j].id == ability.sibling && flag))
				{
					continue;
				}
				abilities[j].applyRarity = true;
				if (!(statModController != null))
				{
					continue;
				}
				for (int k = 0; k < statModController.statModifiers.Count; k++)
				{
					if (statModController.statModifiers[k].abilityData == abilities[j])
					{
						statModController.statModifiers[k].rarity = rarity;
					}
				}
			}
		}
		abilities.Add(ability);
		ability.applyRarity = applyRarity;
		if (ability.applyWhen == ItemData.Ability.ApplyWhen.Start)
		{
			ApplyAbility(ability);
		}
		else if (ability.applyWhen != ItemData.Ability.ApplyWhen.Equip && ability.applyWhen != ItemData.Ability.ApplyWhen.AttackEnd)
		{
			_ = ability.applyWhen;
			_ = 3;
		}
	}

	private void ApplyAbility(ItemData.Ability abilityData)
	{
		if (abilityData.stat == null)
		{
			Utils.LogError("Stat modifier block is missing in ability " + abilityData.id);
			return;
		}
		if (string.IsNullOrEmpty(abilityData.stat.prefab))
		{
			Utils.LogError("Invalid stat modifier prefab path for ability " + abilityData.id + " on item " + this?.ToString() + ". Will use 'stat_basic'");
			abilityData.stat.prefab = "stat_basic";
		}
		if (abilityData.stat.type == ItemData.Stat.Type.ChanceToApply)
		{
			float levelDisplayValueForItem = ItemFactory.GetLevelDisplayValueForItem(this);
			float num = abilityData.stat.Compute(levelDisplayValueForItem);
			if (num > 0f && UnityEngine.Random.Range(0f, 100f) > num)
			{
				return;
			}
		}
		abilityData.stat.TryInitDataHeavyStat(id);
		ItemData.Ability subAbility = abilityData.subAbility;
		StatModifier component = Utils.InstantiatePrefab("Weapons/StatModifiers/" + (abilityData.applySubAbility ? subAbility.stat.prefab : abilityData.stat.prefab)).GetComponent<StatModifier>();
		component.abilityData = abilityData;
		component.statData = (abilityData.applySubAbility ? subAbility.stat : abilityData.stat);
		component.sourceItem = this;
		component.character = Owner;
		if (abilityData.applyRarity)
		{
			component.rarity = rarity;
		}
		if (abilityData.applySubAbility && abilityData.stat != null && abilityData.stat.type == ItemData.Stat.Type.SubAbilityDuration)
		{
			float levelDisplayValueForItem2 = ItemFactory.GetLevelDisplayValueForItem(this);
			component.ticDuration = Mathf.CeilToInt(abilityData.stat.Compute(levelDisplayValueForItem2, 30f));
			component.cleansable = true;
		}
		else
		{
			component.cleansable = false;
		}
		if (abilityData.applyTo == ItemData.Ability.ApplyTo.Item)
		{
			InitStatModController();
			statModController.AddStatModifier(component);
		}
		else if (abilityData.applyTo == ItemData.Ability.ApplyTo.Character)
		{
			if (Owner != null && owner.Alive)
			{
				Owner.AddStatModifier(component);
			}
			else
			{
				Utils.LogError("Failed to apply modifier for ability " + abilityData.id + ". The item " + this?.ToString() + " has no Owner at this point.");
			}
		}
		else if (abilityData.applyTo == ItemData.Ability.ApplyTo.Bullet)
		{
			Weapon weapon = this as Weapon;
			if (weapon != null)
			{
				if (weapon.statModifiersToApply == null)
				{
					weapon.statModifiersToApply = new List<StatModifier>();
				}
				float levelDisplayValueForItem3 = ItemFactory.GetLevelDisplayValueForItem(this);
				component.ticDuration = Mathf.CeilToInt(abilityData.stat.Compute(levelDisplayValueForItem3, 30f));
				weapon.statModifiersToApply.Add(component);
			}
		}
		component.Init();
	}

	private void CleanupAbility(ItemData.Ability abilityData)
	{
		ForEachStatModController(delegate(StatModController controller)
		{
			for (int i = 0; i < controller.statModifiers.Count; i++)
			{
				StatModifier statModifier = controller.statModifiers[i];
				if (statModifier.abilityData == abilityData)
				{
					statModifier.End();
				}
			}
		});
	}

	private void InitStatModController()
	{
		if (_statModController == null)
		{
			_statModController = base.gameObject.AddComponent<StatModController>();
		}
	}

	private void HandleCharacterEquippedWeapon(Character character, Weapon weapon)
	{
		if (!(weapon == this) || !(character == Owner) || abilities == null)
		{
			return;
		}
		for (int i = 0; i < abilities.Count; i++)
		{
			if (abilities[i].applyWhen == ItemData.Ability.ApplyWhen.Equip)
			{
				ApplyAbility(abilities[i]);
			}
		}
	}

	private void HandleCharacterUnequippedWeapon(Character character, Weapon weapon)
	{
		if (!(weapon == this) || !(character == Owner) || abilities == null)
		{
			return;
		}
		for (int i = 0; i < abilities.Count; i++)
		{
			if (abilities[i].applyWhen == ItemData.Ability.ApplyWhen.Equip)
			{
				CleanupAbility(abilities[i]);
			}
		}
	}

	private void HandleCharacterAttackEnded(Character character, Character target, Weapon weapon)
	{
		if (abilities == null)
		{
			return;
		}
		for (int i = 0; i < abilities.Count; i++)
		{
			ItemData.Ability ability = abilities[i];
			if ((ability.applyWhen == ItemData.Ability.ApplyWhen.AttackEnd && weapon == this && character == Owner && character != null) || (ability.applyWhen == ItemData.Ability.ApplyWhen.AttackedByEnemy && target == Owner && target != null))
			{
				ApplyAbility(abilities[i]);
			}
		}
	}

	public int GetNextLostCountGoal()
	{
		int num = lostCount;
		int num2 = 1;
		int num3 = 32;
		int num4 = ItemFactory.GetLevelDisplayIntegerForItem(this) - 5;
		while (num2 <= num3)
		{
			if (num < num2 || num4 <= 0)
			{
				return num2;
			}
			num2 *= 2;
			num4--;
		}
		return num3;
	}

	public int ComputeGearPoints()
	{
		int num = 0;
		num += ItemFactory.GetLevelDisplayIntegerForItem(this);
		num += GetRarityBonus() * GetRarityBonus();
		if (isShiny)
		{
			num += 10;
		}
		if (isNamed)
		{
			num += 50;
		}
		return num;
	}

	public int GetLostBoostPoints()
	{
		LostBoostPoints component = GetComponent<LostBoostPoints>();
		if ((bool)component)
		{
			return component.GetLostBoostPoints();
		}
		return 0;
	}

	private void PreloadDependencies()
	{
		for (int i = 0; i < preloadDependencies.Length; i++)
		{
			Utils.PreloadAsyncPrefab(preloadDependencies[i]);
		}
	}

	protected virtual void Awake()
	{
		_count = new SafeInt(1);
		if (isLost)
		{
			_lostCount = new SafeInt(1);
		}
		else
		{
			_lostCount = new SafeInt(0);
		}
		_lostBoosts = new SafeInt(0);
		PreloadDependencies();
	}

	protected virtual void OnDestroy()
	{
		Character.OnCharacterEquippedWeapon -= HandleCharacterEquippedWeapon;
		Character.OnCharacterUnequippedWeapon -= HandleCharacterUnequippedWeapon;
		Character.OnCharacterAttackEnded -= HandleCharacterAttackEnded;
	}

	protected virtual void OnRarityChanged()
	{
	}

	[StonescriptNativeGetter("id")]
	public object Property_GetId()
	{
		return id;
	}

	[StonescriptNativeGetter("name")]
	public object Property_GetName()
	{
		return GetName();
	}

	[StonescriptNativeGetter("groupId")]
	public object Property_GetGroupId()
	{
		return GetGroupId();
	}

	[StonescriptNativeGetter("count")]
	public object Property_GetCount()
	{
		return count;
	}

	[StonescriptNativeGetter("level")]
	public object Property_GetLevel()
	{
		return level;
	}

	[StonescriptNativeGetter("displayLevel")]
	public object Property_GetDisplayLevel()
	{
		return ItemFactory.GetLevelDisplayIntegerForItem(this) - 1;
	}

	[StonescriptNativeGetter("complexity")]
	public object Property_GetComplexity()
	{
		return complexity;
	}

	[StonescriptNativeGetter("isSocketed")]
	public object Property_GetIsSocketed()
	{
		return isSocketed;
	}

	[StonescriptNativeGetter("element")]
	public object Property_GetElement()
	{
		return element.ToString();
	}

	[StonescriptNativeGetter("rarity")]
	public object Property_GetRarity()
	{
		return _rarity?.type.ToString();
	}

	[StonescriptNativeGetter("rarityLevel")]
	public object Property_GetRarityLevel()
	{
		return (_rarity != null) ? _rarity.levelBonus : 0;
	}

	[StonescriptNativeGetter("rarityQuality")]
	public object Property_GetRarityQuality()
	{
		return (_rarity != null) ? _rarity.quality : 0;
	}

	[StonescriptNativeGetter("owner")]
	public object Property_GetOwner()
	{
		return owner?.ssObject;
	}

	[StonescriptNativeGetter("stars")]
	public object Property_GetStars()
	{
		return ItemFactory.GetLevelDisplayIntegerForItem(this) - 1;
	}

	[StonescriptNativeGetter("sjson")]
	public object Property_GetSjson()
	{
		return SerializeData();
	}
}
