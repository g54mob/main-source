using System;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
	public enum ItemType
	{
		Item = 0,
		Axe = 1,
		Pickaxe = 2,
		Sword = 3,
		Shield = 4,
		Shovel = 5,
		Storage = 6,
		Station = 7,
		Food = 8,
		Bow = 9
	}

	public enum ProcessType
	{
		Smelt = 0,
		Cook = 1,
		None = 2
	}

	[Serializable]
	public enum ItemTag
	{
		None = 0,
		Fuel = 1,
		Food = 2,
		LeftHanded = 3,
		Helmet = 4,
		Torso = 5,
		Legs = 6,
		Feet = 7,
		Arrow = 8,
		Armor = 9,
		Gem = 10
	}

	public enum ItemRarity
	{
		Common = 0,
		Uncommon = 1,
		Rare = 2
	}

	[Serializable]
	public class CraftRequirement
	{
		public InventoryItem item;

		public int amount;
	}

	[Header("Basic")]
	public bool important;

	public int id;

	public new string name;

	public string description;

	public ItemType type;

	public int tier;

	[Header("Visuals")]
	public Sprite sprite;

	public Material material;

	public Mesh mesh;

	public Vector3 rotationOffset;

	public Vector3 positionOffset;

	public float scale = 1f;

	[Header("Inventory details")]
	public bool stackable = true;

	public int amount;

	public int max = 69;

	[Header("Weapon")]
	public int resourceDamage = 1;

	public int attackDamage = 1;

	public float attackSpeed = 1f;

	public float attackRange;

	public float sharpness;

	[Header("Crafting")]
	public bool craftable;

	public bool unlockWithFirstRequirementOnly;

	public CraftRequirement[] requirements;

	public int craftAmount;

	public InventoryItem stationRequirement;

	[Header("Building")]
	public bool buildable;

	public bool grid;

	public GameObject prefab;

	public Vector3 buildRotation;

	[Header("Processing")]
	public bool processable;

	public ProcessType processType;

	public InventoryItem processedItem;

	public float processTime;

	[Header("Food")]
	public float heal;

	public float hunger;

	public float stamina;

	[Header("Other")]
	public int armor;

	public bool swingFx;

	public BowComponent bowComponent;

	public ArmorComponent armorComponent;

	[Header("Fuel")]
	public ItemFuel fuel;

	[Header("Meta")]
	public ItemTag tag;

	public ItemRarity rarity;

	public MobType.Weakness[] attackTypes;

	public void Copy(InventoryItem item, int amount)
	{
		name = item.name;
		description = item.description;
		sprite = item.sprite;
		this.amount = amount;
		max = item.max;
		stackable = item.stackable;
		material = item.material;
		mesh = item.mesh;
		id = item.id;
		attackRange = item.attackRange;
		resourceDamage = item.resourceDamage;
		tier = item.tier;
		type = item.type;
		attackSpeed = item.attackSpeed;
		craftable = item.craftable;
		requirements = item.requirements;
		craftAmount = item.craftAmount;
		unlockWithFirstRequirementOnly = item.unlockWithFirstRequirementOnly;
		buildable = item.buildable;
		grid = item.grid;
		prefab = item.prefab;
		attackDamage = item.attackDamage;
		rotationOffset = item.rotationOffset;
		positionOffset = item.positionOffset;
		scale = item.scale;
		buildRotation = item.buildRotation;
		processable = item.processable;
		processType = item.processType;
		processedItem = item.processedItem;
		tag = item.tag;
		heal = item.heal;
		hunger = item.hunger;
		stamina = item.stamina;
		armor = item.armor;
		armorComponent = item.armorComponent;
		bowComponent = item.bowComponent;
		swingFx = item.swingFx;
		processTime = item.processTime;
		if ((bool)item.fuel)
		{
			fuel = UnityEngine.Object.Instantiate(item.fuel);
		}
		rarity = item.rarity;
		attackTypes = item.attackTypes;
		important = item.important;
	}

	public bool IsArmour()
	{
		if (tag != ItemTag.Helmet && tag != ItemTag.Torso && tag != ItemTag.Legs)
		{
			return tag == ItemTag.Feet;
		}
		return true;
	}

	public Color GetOutlineColor()
	{
		switch (rarity)
		{
		case ItemRarity.Common:
			return Color.white;
		case ItemRarity.Uncommon:
			return Color.green;
		case ItemRarity.Rare:
			return Color.red;
		default:
			return Color.white;
		}
	}

	public bool Compare(InventoryItem other)
	{
		if (other == null)
		{
			return false;
		}
		return id == other.id;
	}

	public string GetAmount()
	{
		if (!stackable || amount == 1)
		{
			return "";
		}
		return amount.ToString();
	}
}
