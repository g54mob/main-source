using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "murderweapon_data", menuName = "Database/Murder Weapon")]
public class MurderWeaponPreset : SoCustomComparison
{
	public enum WeaponType
	{
		handgun = 0,
		rifle = 1,
		shotgun = 2,
		blade = 3,
		bluntObject = 4,
		poison = 5,
		strangulation = 6,
		fists = 7
	}

	public enum StatMultiplier
	{
		zero = 0,
		one = 1,
		random = 2,
		combatSkill = 3,
		combatHeft = 4
	}

	public enum EjectBrass
	{
		none = 0,
		onFire = 1,
		onPumpAction = 2,
		revolver = 3
	}

	public enum AttackValue
	{
		range = 0,
		fireDelay = 1,
		accuracy = 2,
		damage = 3
	}

	[Header("Configuration")]
	public WeaponType type;

	public List<InteractablePreset> ammunition;

	[Range(0f, 3f)]
	public int murderDifficultyModifier;

	[Tooltip("Local muzzle position relative to the pivot")]
	[Header("World Items")]
	public Vector3 muzzleOffset;

	[Tooltip("Local brass eject relative to the pivot")]
	public Vector3 brassEjectOffset;

	[Space(7f)]
	public GameObject itemRightOverride;

	public Vector3 itemRightLocalPos;

	public Vector3 itemRightLocalEuler;

	[Space(7f)]
	public GameObject itemLeftOverride;

	public Vector3 itemLeftLocalPos;

	public Vector3 itemLeftLocalEuler;

	[Space(7f)]
	public bool overideUsesCarryAnimation;

	[EnableIf("overideUsesCarryAnimation")]
	public int overrideCarryAnimation;

	[Header("Personal Defence")]
	[Tooltip("If true, citizens may carry this about to defend themselves")]
	public bool usedInPersonalDefence;

	public bool disabled;

	[EnableIf("usedInPersonalDefence")]
	[Range(0f, 10f)]
	public int basePriority;

	[Space(7f)]
	[MinMaxSlider(0f, 1f)]
	public Vector2 socialClassRange;

	[Range(0f, 10f)]
	public int citizenSpawningWithScore;

	[EnableIf("usedInPersonalDefence")]
	public List<MurderPreset.MurdererModifierRule> personalDefenceTraitModifiers;

	[Space(7f)]
	public List<OccupationPreset> jobModifierList;

	public int jobScoreModifier;

	[Tooltip("How this impacts nerve levels of a citizen if drawn")]
	[Space(7f)]
	public float drawnNerveModifier;

	[Tooltip("Chance of bark trigger")]
	public float barkTriggerChance;

	public SpeechController.Bark bark;

	[Tooltip("With this weapon, multiply incoming nerve damage by this")]
	public float incomingNerveDamageMultiplier;

	[Header("Weapon Handling")]
	[Tooltip("At what point during the attack is the trigger executed? Normalized value")]
	[Range(0f, 1f)]
	public float attackTriggerPoint;

	[Tooltip("At what point during the attack is the trigger removed? Normalized value")]
	[Range(0f, 1f)]
	public float attackRemovePoint;

	[Tooltip("How many shots are fired?")]
	public int shots;

	[Space(7f)]
	[Tooltip("Weapon range")]
	public Vector2 weaponMaxRange;

	public float minimumRange;

	public float maximumBulletRange;

	public StatMultiplier weaponRangeLerpSource;

	[Tooltip("Time in seconds between attacks")]
	[Space(7f)]
	public Vector2 fireDelay;

	public StatMultiplier fireDelayLerpSource;

	[Tooltip("Attack accuracy")]
	[Space(7f)]
	public Vector2 attackAccuracy;

	public StatMultiplier attackAccuracyLerpSource;

	[Space(7f)]
	[Tooltip("Attack damage")]
	public Vector2 attackDamage;

	public StatMultiplier attackDamageLerpSource;

	public float applyPoison;

	[Header("FX Prefabs")]
	public InteractablePreset shellCasing;

	public EjectBrass ejectBrassSetting;

	public InteractablePreset bulletHole;

	public InteractablePreset glassBulletHole;

	public InteractablePreset entryWound;

	public GameObject bulletRicochet;

	public GameObject bulletImpactSpray;

	public GameObject muzzleFlash;

	[Range(0f, 1f)]
	public float bloodPoolAmount;

	[Header("Hits")]
	public SpatterPatternPreset forwardSpatter;

	public SpatterPatternPreset backSpatter;

	[Header("Audio")]
	public AudioEvent fireEvent;

	public AudioEvent impactEvent;

	public AudioEvent impactEventBody;

	public AudioEvent impactEventPlayer;

	public float GetAttackValue(AttackValue valueType, Human human)
	{
		return 0f;
	}
}
