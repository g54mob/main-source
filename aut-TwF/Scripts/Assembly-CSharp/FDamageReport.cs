using System.Collections.Generic;

public class FDamageReport : ISavable
{
	[Savable("healthDamage", true, false)]
	private float healthDamage;

	[Savable("armorDamage", true, false)]
	private float armorDamage;

	[Savable("shieldDamage", true, false)]
	private float shieldDamage;

	public float TotalDamage => HealthDamage + ArmorDamage + ShieldDamage;

	public float HealthDamage
	{
		get
		{
			return healthDamage;
		}
		set
		{
			healthDamage = value;
		}
	}

	public float ArmorDamage
	{
		get
		{
			return armorDamage;
		}
		set
		{
			armorDamage = value;
		}
	}

	public float ShieldDamage
	{
		get
		{
			return shieldDamage;
		}
		set
		{
			shieldDamage = value;
		}
	}

	public FDamageReport()
	{
	}

	public FDamageReport(float healthDamage, float armorDamage, float shieldDamage)
	{
		HealthDamage = healthDamage;
		ArmorDamage = armorDamage;
		ShieldDamage = shieldDamage;
	}

	public void AddDamageReport(FDamageReport damageReportToAdd)
	{
		HealthDamage += damageReportToAdd.HealthDamage;
		ArmorDamage += damageReportToAdd.ArmorDamage;
		ShieldDamage += damageReportToAdd.ShieldDamage;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
