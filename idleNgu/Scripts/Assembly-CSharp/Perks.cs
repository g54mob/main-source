using System;

[Serializable]
public class Perks
{
	public Perk statPerk;

	public Perk advStat1;

	public Perk lootPerk;

	public Perk energyPower1;

	public Perk magicPower1;

	public Perk energyBar1;

	public Perk magicBar1;

	public Perk discount1;

	public Perk cooldown1;

	public Perk goldBoost1;

	public Perk recycleBonus1;

	public Perk paralyze;

	public Perk wandoos1;

	public Perk yggdrasil1;

	public PlayerTime respecTime;

	public Perks()
	{
		respecTime = new PlayerTime();
		statPerk = new Perk();
		advStat1 = new Perk();
		lootPerk = new Perk();
		energyPower1 = new Perk();
		magicPower1 = new Perk();
		energyBar1 = new Perk();
		magicBar1 = new Perk();
		discount1 = new Perk();
		cooldown1 = new Perk();
		goldBoost1 = new Perk();
		recycleBonus1 = new Perk();
		paralyze = new Perk();
		wandoos1 = new Perk();
		yggdrasil1 = new Perk();
	}

	public void respec()
	{
		statPerk.respec();
		advStat1.respec();
		lootPerk.respec();
		energyPower1.respec();
		magicPower1.respec();
		energyBar1.respec();
		magicBar1.respec();
		discount1.respec();
		cooldown1.respec();
		goldBoost1.respec();
		recycleBonus1.respec();
		paralyze.respec();
	}

	public void updateBaseStats()
	{
		if (statPerk == null)
		{
			statPerk = new Perk();
		}
		if (lootPerk == null)
		{
			lootPerk = new Perk();
		}
		if (energyPower1 == null)
		{
			energyPower1 = new Perk();
		}
		if (magicPower1 == null)
		{
			magicPower1 = new Perk();
		}
		if (energyBar1 == null)
		{
			energyBar1 = new Perk();
		}
		if (advStat1 == null)
		{
			advStat1 = new Perk();
		}
		if (magicBar1 == null)
		{
			magicBar1 = new Perk();
		}
		if (discount1 == null)
		{
			discount1 = new Perk();
		}
		if (cooldown1 == null)
		{
			cooldown1 = new Perk();
		}
		if (goldBoost1 == null)
		{
			goldBoost1 = new Perk();
		}
		if (recycleBonus1 == null)
		{
			recycleBonus1 = new Perk();
		}
		if (paralyze == null)
		{
			paralyze = new Perk();
		}
		if (wandoos1 == null)
		{
			wandoos1 = new Perk();
		}
		if (yggdrasil1 == null)
		{
			wandoos1 = new Perk();
		}
	}
}
