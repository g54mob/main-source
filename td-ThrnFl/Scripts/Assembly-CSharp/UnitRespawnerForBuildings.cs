using System.Collections.Generic;
using UnityEngine;

public class UnitRespawnerForBuildings : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public Hp hp;

	public List<Hp> units;

	public List<float> timeToRespawnAUnitDependingOnLevel = new List<float>();

	private float timeTillNextRespawn;

	public BuildSlot myBuildSlot;

	public TaggedObject taggedObject;

	public ProductionBar productionBar;

	private BlacksmithUpgrades blacksmithUpgrades;

	[Header("Quick arrange units:")]
	public Transform copyUnitPositionsFrom;

	private bool gladiatorSchool;

	private bool elliteWarriors;

	private float gladiatorSchoolSpeed;

	private float elliteWarriorSpeed;

	private float totalTrainingSpeed = 1f;

	[SerializeField]
	private Equippable gladiatorSchoolPerk;

	[SerializeField]
	private Equippable elliteWarriorsPerk;

	private bool godOfDeathActive;

	private bool night;

	private bool experienceGainActive;

	private float experienceGainMulti = 1f;

	private float[] currentlyAppliedExperienceBoosts;

	private float currentExperienceMulti = 1f;

	private float ResetCooldownTime => timeToRespawnAUnitDependingOnLevel[Mathf.Clamp(myBuildSlot.Level, 0, timeToRespawnAUnitDependingOnLevel.Count - 1)];

	private void Start()
	{
		PerkManager instance = PerkManager.instance;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		blacksmithUpgrades = BlacksmithUpgrades.instance;
		godOfDeathActive = instance.GodOfDeathActive;
		timeTillNextRespawn = ResetCooldownTime;
		productionBar.UpdateVisual(0f);
		gladiatorSchool = PerkManager.IsEquipped(gladiatorSchoolPerk);
		elliteWarriors = PerkManager.IsEquipped(elliteWarriorsPerk);
		gladiatorSchoolSpeed = instance.gladiatorSchool_TrainingSpeedMultiplyer;
		elliteWarriorSpeed = instance.elliteWarriors_TrainingSpeedMultiplyer;
		totalTrainingSpeed = 1f * (gladiatorSchool ? gladiatorSchoolSpeed : 1f) * (elliteWarriors ? elliteWarriorSpeed : 1f);
		experienceGainActive = instance.ExperienceGainEquipped;
		experienceGainMulti = instance.experienceGainPercentage;
		currentlyAppliedExperienceBoosts = new float[units.Count];
		for (int i = 0; i < currentlyAppliedExperienceBoosts.Length; i++)
		{
			currentlyAppliedExperienceBoosts[i] = 1f;
		}
	}

	private void Update()
	{
		if (godOfDeathActive)
		{
			return;
		}
		if (hp.KnockedOut)
		{
			productionBar.UpdateVisual(0f);
			return;
		}
		bool flag = AtLeastOneUnitIsKnockedOut();
		if ((flag || gladiatorSchool) && night)
		{
			timeTillNextRespawn -= Time.deltaTime * blacksmithUpgrades.unitRespawnSpeedMulti;
			productionBar.UpdateVisual(1f - timeTillNextRespawn / ResetCooldownTime * totalTrainingSpeed);
			if (flag && timeTillNextRespawn <= 0f)
			{
				timeTillNextRespawn = ResetCooldownTime;
				timeTillNextRespawn /= totalTrainingSpeed;
				RespawnAKnockedOutUnit();
			}
		}
		else
		{
			timeTillNextRespawn = ResetCooldownTime;
			timeTillNextRespawn /= totalTrainingSpeed;
			productionBar.UpdateVisual(0f);
		}
	}

	private bool AtLeastOneUnitIsKnockedOut()
	{
		for (int i = 0; i < units.Count; i++)
		{
			Hp hp = units[i];
			if (hp.gameObject.activeInHierarchy && hp.KnockedOut)
			{
				return true;
			}
		}
		return false;
	}

	private void RespawnAKnockedOutUnit()
	{
		for (int i = 0; i < units.Count; i++)
		{
			Hp hp = units[i];
			if (!hp.gameObject.activeInHierarchy || !hp.KnockedOut)
			{
				continue;
			}
			hp.Revive();
			PathfindMovementPlayerunit component = hp.GetComponent<PathfindMovementPlayerunit>();
			Vector3 position = taggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(component.HomePositionOriginal);
			hp.transform.position = position;
			component.SnapToNavmesh();
			if (!experienceGainActive)
			{
				break;
			}
			currentExperienceMulti *= experienceGainMulti;
			currentExperienceMulti = Mathf.Clamp(currentExperienceMulti, 1f, 3f);
			float num = currentExperienceMulti / currentlyAppliedExperienceBoosts[i];
			hp.ScaleHp(num);
			if (hp.AutoAttacks != null)
			{
				AutoAttack[] autoAttacks = hp.AutoAttacks;
				for (int j = 0; j < autoAttacks.Length; j++)
				{
					autoAttacks[j].DamageMultiplyer *= num;
				}
			}
			currentlyAppliedExperienceBoosts[i] = currentExperienceMulti;
			break;
		}
	}

	void DayNightCycle.IDaytimeSensitive.OnDuskEarly()
	{
		timeTillNextRespawn = ResetCooldownTime;
		timeTillNextRespawn /= totalTrainingSpeed;
		night = true;
		if (!experienceGainActive)
		{
			return;
		}
		for (int i = 0; i < units.Count; i++)
		{
			Hp hp = units[i];
			float num = 1f / currentlyAppliedExperienceBoosts[i];
			hp.ScaleHp(num);
			if (hp.AutoAttacks != null)
			{
				AutoAttack[] autoAttacks = hp.AutoAttacks;
				for (int j = 0; j < autoAttacks.Length; j++)
				{
					autoAttacks[j].DamageMultiplyer *= num;
				}
			}
			currentlyAppliedExperienceBoosts[i] = 1f;
		}
		currentExperienceMulti = 1f;
	}

	void DayNightCycle.IDaytimeSensitive.OnDusk()
	{
	}

	void DayNightCycle.IDaytimeSensitive.OnDawn_AfterSunrise()
	{
	}

	void DayNightCycle.IDaytimeSensitive.OnDawn_BeforeSunrise()
	{
		night = false;
	}
}
