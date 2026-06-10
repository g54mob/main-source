using System;
using Unity.VisualScripting;

[Serializable]
public struct SpecialInteraction
{
	[Flags]
	public enum Frequency
	{
		None = 0,
		WhenSpawned = 1,
		EveryTurn = 2,
		WhenDies = 4
	}

	[Flags]
	public enum OthersLabels
	{
		None = 0,
		Monster = 1,
		Animal = 2,
		Building = 4,
		Metallic = 8,
		Wooden = 0x10,
		Human = 0x20,
		Mage = 0x40,
		Fabric = 0x80
	}

	[Flags]
	public enum SpecialEffects
	{
		None = 0,
		DoubleHP = 1,
		DoubleAttack = 2,
		DoubleMana = 4
	}

	public Frequency frequency;

	public OthersLabels othersLabels;

	public SpecialEffects specialEffects;

	[Serialize]
	public Wizcard wizcardToSpawn;

	public int extraAttack;

	public int extraHealth;

	public int bonusDamage;
}
