using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Audio Set", menuName = "SimpleSiege/Audio Set")]
public class AudioSet : ScriptableObject
{
	[Serializable]
	public class ClipArray
	{
		public AudioClip[] clips;

		public AudioClip GetRandomClip()
		{
			return clips[UnityEngine.Random.Range(0, clips.Length)];
		}
	}

	[Header("MIXER GROUPS")]
	public AudioMixerGroup mixGroupFX;

	[Header("DAY/NIGHT")]
	[SerializeField]
	private AudioClip nightSurvived;

	[SerializeField]
	private AudioClip buildingRepair;

	[Header("BUILDING")]
	[SerializeField]
	private AudioClip coinslotFill;

	[SerializeField]
	private AudioClip lastCoinslotFill;

	[SerializeField]
	private AudioClip coinslotInteractionStart;

	[SerializeField]
	private AudioClip payBackground;

	[SerializeField]
	private AudioClip buildingBuild;

	[SerializeField]
	private AudioClip buildingUpgrade;

	[SerializeField]
	private ClipArray towerShot;

	[SerializeField]
	private ClipArray ballistaShot;

	[SerializeField]
	private AudioClip enemySpawn;

	[SerializeField]
	private ClipArray defaultOnFootStep;

	[SerializeField]
	private ClipArray giantStep;

	[SerializeField]
	private ClipArray flyingSmall;

	[SerializeField]
	private ClipArray flyingBig;

	[SerializeField]
	private ClipArray flyingWizzard;

	[SerializeField]
	private ClipArray siegeRoll;

	[SerializeField]
	private ClipArray racerRoll;

	[SerializeField]
	private ClipArray squishyBounce;

	[SerializeField]
	private ClipArray exploderRoll;

	[SerializeField]
	private ClipArray monsterRiderGallop;

	[SerializeField]
	private ClipArray slimeStep;

	[SerializeField]
	private ClipArray windboatFly;

	[SerializeField]
	private ClipArray steamCastle;

	[SerializeField]
	private ClipArray firestorm;

	[SerializeField]
	private ClipArray defaultSwordAttack;

	[SerializeField]
	private ClipArray flailAttack;

	[SerializeField]
	private ClipArray pointySpearAttack;

	[SerializeField]
	private ClipArray massiveBluntAttack;

	[SerializeField]
	private ClipArray flyerSpit;

	[SerializeField]
	private ClipArray flatbowShot;

	[SerializeField]
	private ClipArray crossbowShow;

	[SerializeField]
	private ClipArray catapultShot;

	[SerializeField]
	private ClipArray ram;

	[SerializeField]
	private ClipArray racerBite;

	[SerializeField]
	private ClipArray hunterlingBite;

	[SerializeField]
	private ClipArray slimeSpit;

	[SerializeField]
	private ClipArray spiderBite;

	[SerializeField]
	private ClipArray fireSpit;

	[SerializeField]
	private ClipArray healingProjectile;

	[SerializeField]
	private ClipArray flyingWizardCast;

	[SerializeField]
	private ClipArray windboatShot;

	[SerializeField]
	private ClipArray heavyMechanicalHit;

	[SerializeField]
	private ClipArray defaultHumanoidOnFootDamage;

	[SerializeField]
	private ClipArray bigOrganicDamage;

	[SerializeField]
	private ClipArray smallOrganicDamage;

	[SerializeField]
	private ClipArray siegeDamage;

	[SerializeField]
	private ClipArray defaultHumanoidOnFootDeath;

	[SerializeField]
	private ClipArray bigOrganicDeath;

	[SerializeField]
	private ClipArray siegeDeath;

	[SerializeField]
	private ClipArray exploderDeath;

	[SerializeField]
	private ClipArray unitBuildingCollpse;

	[SerializeField]
	private ClipArray eismolochAppear;

	[SerializeField]
	private ClipArray eismolochSpawnUnits;

	[SerializeField]
	private ClipArray eismolochScream;

	[SerializeField]
	private ClipArray playerSword;

	[SerializeField]
	private ClipArray playerSwordBigHit;

	[SerializeField]
	private ClipArray playerBow;

	[SerializeField]
	private ClipArray playerBowStab;

	[SerializeField]
	private ClipArray playerBowStabMiss;

	[SerializeField]
	private ClipArray playerCantUseActiveAbility;

	[SerializeField]
	private ClipArray assasinsTrainingWeaponTimedPerfectly;

	[SerializeField]
	private ClipArray activeAbilityCooldownReadyToUse;

	[SerializeField]
	private ClipArray playerSpear;

	[SerializeField]
	private ClipArray playerLightningWand;

	[SerializeField]
	private ClipArray playerLightningWandActiveAbility;

	[SerializeField]
	private ClipArray playerShadowCodex;

	[SerializeField]
	private ClipArray playerFalchion;

	[SerializeField]
	private ClipArray playerTrapPlace;

	[SerializeField]
	private ClipArray playerTrapHit;

	[SerializeField]
	private ClipArray playerPotionThrow;

	[SerializeField]
	private ClipArray playerPotionHit;

	[SerializeField]
	private ClipArray playerPotionActive;

	[SerializeField]
	private ClipArray playerAxeHit;

	[SerializeField]
	private ClipArray playerAxeActive;

	[SerializeField]
	private ClipArray playerBloodwandHit;

	[SerializeField]
	private ClipArray playerBloodwandActive;

	[SerializeField]
	private ClipArray playerDeath;

	[SerializeField]
	private ClipArray playerDamage;

	[SerializeField]
	private AudioClip playerRevive;

	[SerializeField]
	private ClipArray addedUnitToCommanding;

	[SerializeField]
	private ClipArray placeCommandingUnits;

	[SerializeField]
	private ClipArray holdPosition;

	[SerializeField]
	private ClipArray catapultImpact;

	[SerializeField]
	private ClipArray buttonSelect;

	[SerializeField]
	private ClipArray buttonApply;

	[SerializeField]
	private ClipArray buttonApplyHero;

	[SerializeField]
	private ClipArray coinCollect;

	[SerializeField]
	private AudioClip nightCallStart;

	[SerializeField]
	private AudioClip nightCallComplete;

	[SerializeField]
	private AudioClip victory;

	[SerializeField]
	private AudioClip defeat;

	[SerializeField]
	private AudioClip pointLockInMinor;

	[SerializeField]
	private AudioClip pointLockInMajor;

	[SerializeField]
	private AudioClip pointScreenBuildA;

	[SerializeField]
	private AudioClip pointScreenBuildB;

	[SerializeField]
	private AudioClip pointScreenBuildC;

	[SerializeField]
	private AudioClip pointFillStart;

	[SerializeField]
	private AudioClip pointFill;

	[SerializeField]
	private AudioClip newHighscore;

	[SerializeField]
	private AudioClip levelUp;

	[SerializeField]
	private AudioClip showWaveCount;

	[SerializeField]
	private AudioClip closeWaveCount;

	[SerializeField]
	private AudioClip showTooltip;

	public AudioClip NightSurvived => nightSurvived;

	public AudioClip BuildingRepair => buildingRepair;

	public AudioClip CoinslotFill => coinslotFill;

	public AudioClip LastCoinslotFill => lastCoinslotFill;

	public AudioClip CoinslotInteractionStart => coinslotInteractionStart;

	public AudioClip PayBackground => payBackground;

	public AudioClip BuildingBuild => buildingBuild;

	public AudioClip BuildingUpgrade => buildingUpgrade;

	public ClipArray TowerShot => towerShot;

	public ClipArray BallistaShot => ballistaShot;

	public AudioClip EnemySpawn => enemySpawn;

	public ClipArray DefaultOnFootStep => defaultOnFootStep;

	public ClipArray GiantStep => giantStep;

	public ClipArray FlyingSmall => flyingSmall;

	public ClipArray FlyingBig => flyingBig;

	public ClipArray FlyingWizzard => flyingWizzard;

	public ClipArray SiegeRoll => siegeRoll;

	public ClipArray RacerRoll => racerRoll;

	public ClipArray SquishyBounce => squishyBounce;

	public ClipArray ExploderRoll => exploderRoll;

	public ClipArray MonsterRiderGallop => monsterRiderGallop;

	public ClipArray SlimeStep => slimeStep;

	public ClipArray WindboatFly => windboatFly;

	public ClipArray Steamcastle => steamCastle;

	public ClipArray Firestorm => firestorm;

	public ClipArray DefaultSwordAttack => defaultSwordAttack;

	public ClipArray FlailAttack => flailAttack;

	public ClipArray PointySpearAttack => pointySpearAttack;

	public ClipArray MassiveBluntAttack => massiveBluntAttack;

	public ClipArray FlyerSpit => flyerSpit;

	public ClipArray FlatbowShot => flatbowShot;

	public ClipArray CrossbowShot => crossbowShow;

	public ClipArray CatapultShot => catapultShot;

	public ClipArray Ram => ram;

	public ClipArray RacerBite => racerBite;

	public ClipArray HunterlingBite => hunterlingBite;

	public ClipArray SlimeSpit => slimeSpit;

	public ClipArray SpiderBite => spiderBite;

	public ClipArray FireSpit => fireSpit;

	public ClipArray HealingProjectile => healingProjectile;

	public ClipArray FlyingWizardCast => flyingWizardCast;

	public ClipArray WindboatShot => windboatShot;

	public ClipArray HeavyMechanicalHit => heavyMechanicalHit;

	public ClipArray DefaultHumanoidOnFootDamage => defaultHumanoidOnFootDamage;

	public ClipArray BigOrganicDamage => bigOrganicDamage;

	public ClipArray SmallOrganicDamage => smallOrganicDamage;

	public ClipArray SiegeDamage => siegeDamage;

	public ClipArray DefaultHumanoidOnFootDeath => defaultHumanoidOnFootDeath;

	public ClipArray BigOrganicDeath => bigOrganicDeath;

	public ClipArray SiegeDeath => siegeDeath;

	public ClipArray ExploderDeath => exploderDeath;

	public ClipArray UnitBuildingCollpse => unitBuildingCollpse;

	public ClipArray EismolochAppear => eismolochAppear;

	public ClipArray EismolochSpawnUnits => eismolochSpawnUnits;

	public ClipArray EismolochScream => eismolochScream;

	public ClipArray PlayerSword => playerSword;

	public ClipArray PlayerSwordBigHit => playerSwordBigHit;

	public ClipArray PlayerBow => playerBow;

	public ClipArray PlayerBowStab => playerBowStab;

	public ClipArray PlayerBowStabMiss => playerBowStabMiss;

	public ClipArray PlayerCantUseActiveAbility => playerCantUseActiveAbility;

	public ClipArray AssasinsTrainingWeaponTimedPerfectly => assasinsTrainingWeaponTimedPerfectly;

	public ClipArray ActiveAbilityCooldownReadyToUse => activeAbilityCooldownReadyToUse;

	public ClipArray PlayerSpear => playerSpear;

	public ClipArray PlayerLightningWand => playerLightningWand;

	public ClipArray PlayerLightningWandActiveAbility => playerLightningWandActiveAbility;

	public ClipArray PlayerShadowCodex => playerShadowCodex;

	public ClipArray PlayerFalchion => playerFalchion;

	public ClipArray PlayerTrapPlace => playerTrapPlace;

	public ClipArray PlayerTrapHit => playerTrapHit;

	public ClipArray PlayerPotionThrow => playerPotionThrow;

	public ClipArray PlayerPotionHit => playerPotionHit;

	public ClipArray PlayerPotionActive => playerPotionActive;

	public ClipArray PlayerAxeHit => playerAxeHit;

	public ClipArray PlayerAxeActive => playerAxeActive;

	public ClipArray PlayerBloodwandHit => playerBloodwandHit;

	public ClipArray PlayerBloodwandActive => playerBloodwandActive;

	public ClipArray PlayerDeath => playerDeath;

	public ClipArray PlayerDamage => playerDamage;

	public AudioClip PlayerRevive => playerRevive;

	public ClipArray AddedUnitToCommanding => addedUnitToCommanding;

	public ClipArray PlaceCommandingUnits => placeCommandingUnits;

	public ClipArray HoldPosition => holdPosition;

	public ClipArray CatapultImpact => catapultImpact;

	public ClipArray ButtonSelect => buttonSelect;

	public ClipArray ButtonApply => buttonApply;

	public ClipArray ButtonApplyHero => buttonApplyHero;

	public ClipArray CoinCollect => coinCollect;

	public AudioClip NightCallStart => nightCallStart;

	public AudioClip NightCallComplete => nightCallComplete;

	public AudioClip Victory => victory;

	public AudioClip Defeat => defeat;

	public AudioClip PointLockInMinor => pointLockInMinor;

	public AudioClip PointLockInMajor => pointLockInMajor;

	public AudioClip PointScreenBuildA => pointScreenBuildA;

	public AudioClip PointScreenBuildB => pointScreenBuildB;

	public AudioClip PointScreenBuildC => pointScreenBuildC;

	public AudioClip PointFillStart => pointFillStart;

	public AudioClip PointFill => pointFill;

	public AudioClip NewHighscore => newHighscore;

	public AudioClip LevelUp => levelUp;

	public AudioClip ShowWaveCount => showWaveCount;

	public AudioClip CloseWaveCount => closeWaveCount;

	public AudioClip ShowTooltip => showTooltip;
}
