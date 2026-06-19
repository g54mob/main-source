using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class Emote : PoolableSimple
{
	public enum EmoteType
	{
		__illegal__ = -1,
		[Obsolete]
		EatingFull = 0,
		WaterCanEmpty = 1,
		NothingHappens = 2,
		QuestionMark = 3,
		Hungry = 4,
		ObjectNeedsEnergy = 5,
		NeedHigherMiningSkill = 6,
		BedOccupied = 7,
		CannotSleepWhenNearbyEnemies = 8,
		NothingWasFound = 9,
		StopHurtingMe = 10,
		LarvaEmote = 11,
		UnlockedInEarlyAccess = 12,
		CantLeaveWhileItsMoving = 13,
		FishDoesntBite = 14,
		RequiresDrill = 15,
		NoNearbyGroundToStandOn = 16,
		PlaceHandOnWall = 17,
		DontHaveTheRequiredComponents = 18,
		NotFullyCharged = 19,
		NoOtherPortals = 20,
		ExclamationMark = 21,
		NeedAncientForge = 22,
		TheAncientForge = 23,
		PetIsAlreadyMaxLevel = 24,
		PetIsTooFarAway = 25,
		IDontHaveAPet = 26,
		ObjectIsIndestructible = 27,
		ObjectIsImmune = 28,
		ThisWillTakeAWhile = 29,
		ThisWillTakeForever = 30,
		AlreadyScanned = 31,
		AllPlayersMustBeGathered = 32,
		NotEnoughMana = 33,
		WaypointActivated = 34,
		EnemiesScaledUp = 35,
		EnemiesScaledDown = 36,
		NoSeeds = 37,
		TutorialBreakWood = 38,
		TutorialCraftTorch = 39,
		TutorialCraftMiningPick = 40,
		TutorialCraftWorkbench = 41,
		TutorialSmeltOre = 42,
		NoMinionToCommand = 43,
		ItsPowerRemainsSealed = 44,
		NoEnemyNearBait = 45,
		__max__ = 46
	}

	public enum EmoteIcon
	{
		__illegal__ = -1,
		Exclamation = 0,
		__max__ = 1
	}

	[Serializable]
	public class EmoteIconSpriteSheet
	{
		public EmoteIcon emote;

		public Texture2D spriteSheet;
	}

	private readonly string[] EatingFullEmotes = new string[2] { "Emotes/StomachFull", "Emotes/WontFitInStomach" };

	private readonly string[] WaterCanEmptyEmotes = new string[2] { "Emotes/ItsEmpty", "Emotes/OutOfWater" };

	private readonly string[] NothingHappensEmotes = new string[2] { "Emotes/NothingHappens", "Emotes/ItDoesntDoAnything" };

	private readonly string[] QuestionmarkEmote = new string[1] { "Emotes/Questionmark" };

	private readonly string[] HungryEmote = new string[2] { "Emotes/IShouldEat", "Emotes/ImHungry" };

	private readonly string[] ObjectNeedsEnergyEmote = new string[2] { "Emotes/LooksLikeItNeedsEnergy", "Emotes/PoweredDown" };

	private readonly string[] NeedHigherMiningSkillEmote = new string[2] { "Emotes/NeedHigherMiningSkill", "Emotes/MiningSkillTooLow" };

	private readonly string[] BedOccupiedEmotes = new string[1] { "Emotes/ThisIsNotMyBed" };

	private readonly string[] CannotSleepWhenNearbyEnemiesEmotes = new string[1] { "Emotes/CantSleepWhenEnemiesNear" };

	private readonly string[] NothingWasFoundEmotes = new string[1] { "Emotes/NothingWasFound" };

	private readonly string[] StopHurtingMeEmotes = new string[2] { "Emotes/StopHurtingMe", "Emotes/Ouch" };

	private readonly string[] LarvaEmotes = new string[3] { "Emotes/LarvaEmote1", "Emotes/LarvaEmote2", "Emotes/LarvaEmote3" };

	private readonly string[] UnlockedInEarlyAccess = new string[1] { "Emotes/UnlockedInEarlyAccess" };

	private readonly string[] CantLeaveWhileItsMovingEmotes = new string[1] { "Emotes/CantLeaveWhileItsMoving" };

	private readonly string[] FishDoesntBite = new string[2] { "Emotes/TheFishArentBiting", "Emotes/INeedBetterToolsForTheseWaters" };

	private readonly string[] RequiresDrill = new string[2] { "Emotes/INeedADrillForThis", "Emotes/ItsTooHardINeedADrill" };

	private readonly string[] NoNearbyGroundToStandOn = new string[1] { "Emotes/NoNearbyGroundToStandOn" };

	private readonly string[] PlaceHandOnWall = new string[1] { "Emotes/ShouldPlaceHandOnWall" };

	private readonly string[] DontHaveTheRequiredComponents = new string[1] { "Emotes/IDontHaveTheRequiredComponents" };

	private readonly string[] NotFullyCharged = new string[1] { "Emotes/NotFullyCharged" };

	private readonly string[] NoOtherPortals = new string[1] { "Emotes/NoOtherPortals" };

	private readonly string[] NeedAncientForge = new string[1] { "Emotes/NeedAncientForge" };

	private readonly string[] TheAncientForge = new string[1] { "Emotes/TheAncientForge" };

	private readonly string[] PetIsAlreadyMaxLevel = new string[1] { "Emotes/PetIsAlreadyMaxLevel" };

	private readonly string[] PetIsTooFarAway = new string[1] { "Emotes/PetIsTooFarAway" };

	private readonly string[] IDontHaveAPet = new string[1] { "Emotes/IDontHaveAPet" };

	private readonly string[] ObjectIsIndestructible = new string[2] { "Emotes/ObjectIsIndestructible", "Emotes/ICantDestroyThisObject" };

	private readonly string[] ObjectIsImmune = new string[1] { "Emotes/ObjectIsImmuneToDamage" };

	private readonly string[] ThisWillTakeAWhile = new string[1] { "Emotes/ThisWillTakeAWhile" };

	private readonly string[] ThisWillTakeForever = new string[1] { "Emotes/ThisWillTakeForever" };

	private readonly string[] AlreadyScannedEmotes = new string[1] { "Emotes/AlreadyScanned" };

	private readonly string[] AllPlayersMustBeGatheredEmotes = new string[1] { "Emotes/IShouldGatherMyFriends" };

	private readonly string[] NotEnoughMana = new string[1] { "Emotes/NotEnoughMana" };

	private readonly string[] WaypointActivated = new string[1] { "Emotes/WaypointActivated" };

	private readonly string[] EnemiesScaledUp = new string[1] { "Emotes/EnemiesScaledUp" };

	private readonly string[] EnemiesScaledDown = new string[1] { "Emotes/EnemiesScaledDown" };

	private readonly string[] NoSeeds = new string[1] { "Emotes/NoSeeds" };

	private readonly string[] TutorialBreakWood = new string[1] { "Emotes/TutorialBreakWood" };

	private readonly string[] TutorialCraftTorch = new string[1] { "Emotes/TutorialCraftTorch" };

	private readonly string[] TutorialCraftMiningPick = new string[1] { "Emotes/TutorialCraftMiningPick" };

	private readonly string[] TutorialCraftWorkbench = new string[1] { "Emotes/TutorialCraftWorkbench" };

	private readonly string[] TutorialSmeltOre = new string[1] { "Emotes/TutorialSmeltOre" };

	private readonly string[] NoMinionToCommand = new string[1] { "Emotes/NoMinionToCommand" };

	private readonly string[] ItsPowerRemainsSealed = new string[1] { "Emotes/ItsPowerRemainsSealedDesc" };

	private readonly string[] NoEnemyNearBaitEmotes = new string[1] { "Emotes/NoEnemyNearBait" };

	[HideInInspector]
	public EmoteType emoteTypeInput;

	[HideInInspector]
	public EmoteIcon emoteIconInput;

	[HideInInspector]
	public Vector3 emotePosition;

	[HideInInspector]
	public bool randomizePosition;

	private Transform transformToFollow;

	public PugText text;

	public PugTextEffectFade fadeEffect;

	public Animator animator;

	public SpriteSheetSkin iconSkin;

	public List<EmoteIconSpriteSheet> iconSpriteSheets;

	private string textToPrint;

	private TimerSimple durationTimer;

	private TimerSimple fadeTimer;

	private static TimerSimple emoteCooldown = new TimerSimple(0.5f);

	private static EmoteType lastEmote = EmoteType.__illegal__;

	private static EmoteIcon lastEmoteIcon = EmoteIcon.__illegal__;

	private Texture2D GetEmoteIconSpriteSheet(EmoteIcon emoteIcon)
	{
		foreach (EmoteIconSpriteSheet iconSpriteSheet in iconSpriteSheets)
		{
			if (iconSpriteSheet.emote == emoteIcon)
			{
				return iconSpriteSheet.spriteSheet;
			}
		}
		return null;
	}

	private static float GetCooldown(EmoteType emoteType, float defaultDuration = 0.5f)
	{
		if (emoteType == EmoteType.NotEnoughMana)
		{
			return 5f;
		}
		return defaultDuration;
	}

	public static Emote SpawnEmoteText(Vector3 position, EmoteType emoteType, bool randomizePosition = true, bool shortBounce = false, bool dontAllowSpam = true)
	{
		if ((lastEmote == emoteType && emoteCooldown.isRunning && !emoteCooldown.isTimerElapsed && dontAllowSpam) || Manager.prefs.hideInGameUI)
		{
			return null;
		}
		lastEmote = emoteType;
		emoteCooldown.Start(0.5f);
		Emote freeComponent = Manager.memory.GetFreeComponent<Emote>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transformToFollow = null;
			freeComponent.emoteIconInput = EmoteIcon.__illegal__;
			freeComponent.emoteTypeInput = emoteType;
			freeComponent.emotePosition = position;
			freeComponent.randomizePosition = randomizePosition;
			freeComponent.fadeTimer.Stop();
			if (shortBounce)
			{
				freeComponent.animator.SetTrigger(-1884439050);
			}
			else
			{
				freeComponent.animator.SetTrigger(346641107);
			}
			freeComponent.OnOccupied();
			float num = math.max(5f / 6f, (float)freeComponent.text.displayedTextString.Length * 5f / 60f);
			freeComponent.durationTimer.Start(num);
			float cooldown = GetCooldown(emoteType, num);
			emoteCooldown.Start(cooldown);
		}
		else
		{
			Debug.LogError("failed to instantiate healthFullText");
		}
		return freeComponent;
	}

	public static Emote SpawnEmoteIcon(Vector3 offset, EmoteIcon emoteIcon, Transform transformToFollow, bool randomizePosition = true, bool dontAllowSpam = true)
	{
		if ((lastEmoteIcon == emoteIcon && emoteCooldown.isRunning && !emoteCooldown.isTimerElapsed && dontAllowSpam) || Manager.prefs.hideInGameUI)
		{
			return null;
		}
		lastEmoteIcon = emoteIcon;
		emoteCooldown.Start(0.5f);
		Emote freeComponent = Manager.memory.GetFreeComponent<Emote>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transformToFollow = transformToFollow;
			freeComponent.emoteTypeInput = EmoteType.__illegal__;
			freeComponent.emoteIconInput = emoteIcon;
			freeComponent.emotePosition = offset;
			freeComponent.randomizePosition = randomizePosition;
			freeComponent.fadeTimer.Stop();
			freeComponent.animator.SetTrigger(-1458138319);
			freeComponent.OnOccupied();
			float newLifespan = math.max(5f / 6f, (float)freeComponent.text.displayedTextString.Length * 5f / 60f);
			freeComponent.durationTimer.Start(newLifespan);
			emoteCooldown.Start(newLifespan);
		}
		else
		{
			Debug.LogError("failed to instantiate healthFullText");
		}
		return freeComponent;
	}

	public override void OnOccupied()
	{
		Vector3 vector = new Vector3(0f, 3f, -3f);
		Vector2 vector2 = UnityEngine.Random.insideUnitCircle * 0.33f;
		Vector3 vector3 = (randomizePosition ? new Vector3(vector2.x, vector2.y, 0f) : Vector3.zero);
		Vector3 v = emotePosition + vector + vector3;
		v = v.RoundToMultiple(0.0625f);
		base.transform.position = v;
		iconSkin.gameObject.SetActive(value: false);
		int num = 0;
		if (emoteTypeInput != EmoteType.__illegal__)
		{
			switch (emoteTypeInput)
			{
			case EmoteType.WaterCanEmpty:
				num = UnityEngine.Random.Range(0, WaterCanEmptyEmotes.Length);
				textToPrint = WaterCanEmptyEmotes[num];
				break;
			case EmoteType.NothingHappens:
				num = UnityEngine.Random.Range(0, NothingHappensEmotes.Length);
				textToPrint = NothingHappensEmotes[num];
				break;
			case EmoteType.QuestionMark:
				num = UnityEngine.Random.Range(0, QuestionmarkEmote.Length);
				textToPrint = QuestionmarkEmote[num];
				break;
			case EmoteType.Hungry:
				num = UnityEngine.Random.Range(0, HungryEmote.Length);
				textToPrint = HungryEmote[num];
				break;
			case EmoteType.ObjectNeedsEnergy:
				num = UnityEngine.Random.Range(0, ObjectNeedsEnergyEmote.Length);
				textToPrint = ObjectNeedsEnergyEmote[num];
				break;
			case EmoteType.NeedHigherMiningSkill:
				num = UnityEngine.Random.Range(0, NeedHigherMiningSkillEmote.Length);
				textToPrint = NeedHigherMiningSkillEmote[num];
				break;
			case EmoteType.BedOccupied:
				num = UnityEngine.Random.Range(0, BedOccupiedEmotes.Length);
				textToPrint = BedOccupiedEmotes[num];
				break;
			case EmoteType.CannotSleepWhenNearbyEnemies:
				num = UnityEngine.Random.Range(0, CannotSleepWhenNearbyEnemiesEmotes.Length);
				textToPrint = CannotSleepWhenNearbyEnemiesEmotes[num];
				break;
			case EmoteType.NothingWasFound:
				num = UnityEngine.Random.Range(0, NothingWasFoundEmotes.Length);
				textToPrint = NothingWasFoundEmotes[num];
				break;
			case EmoteType.StopHurtingMe:
				num = UnityEngine.Random.Range(0, StopHurtingMeEmotes.Length);
				textToPrint = StopHurtingMeEmotes[num];
				break;
			case EmoteType.LarvaEmote:
				num = UnityEngine.Random.Range(0, LarvaEmotes.Length);
				textToPrint = LarvaEmotes[num];
				break;
			case EmoteType.UnlockedInEarlyAccess:
				num = UnityEngine.Random.Range(0, UnlockedInEarlyAccess.Length);
				textToPrint = UnlockedInEarlyAccess[num];
				break;
			case EmoteType.CantLeaveWhileItsMoving:
				num = UnityEngine.Random.Range(0, CantLeaveWhileItsMovingEmotes.Length);
				textToPrint = CantLeaveWhileItsMovingEmotes[num];
				break;
			case EmoteType.FishDoesntBite:
				num = UnityEngine.Random.Range(0, FishDoesntBite.Length);
				textToPrint = FishDoesntBite[num];
				break;
			case EmoteType.RequiresDrill:
				num = UnityEngine.Random.Range(0, RequiresDrill.Length);
				textToPrint = RequiresDrill[num];
				break;
			case EmoteType.NoNearbyGroundToStandOn:
				num = UnityEngine.Random.Range(0, NoNearbyGroundToStandOn.Length);
				textToPrint = NoNearbyGroundToStandOn[num];
				break;
			case EmoteType.PlaceHandOnWall:
				num = UnityEngine.Random.Range(0, PlaceHandOnWall.Length);
				textToPrint = PlaceHandOnWall[num];
				break;
			case EmoteType.DontHaveTheRequiredComponents:
				num = UnityEngine.Random.Range(0, DontHaveTheRequiredComponents.Length);
				textToPrint = DontHaveTheRequiredComponents[num];
				break;
			case EmoteType.NotFullyCharged:
				num = UnityEngine.Random.Range(0, NotFullyCharged.Length);
				textToPrint = NotFullyCharged[num];
				break;
			case EmoteType.NoOtherPortals:
				num = UnityEngine.Random.Range(0, NoOtherPortals.Length);
				textToPrint = NoOtherPortals[num];
				break;
			case EmoteType.NeedAncientForge:
				num = UnityEngine.Random.Range(0, NeedAncientForge.Length);
				textToPrint = NeedAncientForge[num];
				break;
			case EmoteType.TheAncientForge:
				num = UnityEngine.Random.Range(0, TheAncientForge.Length);
				textToPrint = TheAncientForge[num];
				break;
			case EmoteType.ExclamationMark:
				textToPrint = "!";
				text.localize = false;
				break;
			case EmoteType.PetIsAlreadyMaxLevel:
				num = UnityEngine.Random.Range(0, PetIsAlreadyMaxLevel.Length);
				textToPrint = PetIsAlreadyMaxLevel[num];
				break;
			case EmoteType.PetIsTooFarAway:
				num = UnityEngine.Random.Range(0, PetIsTooFarAway.Length);
				textToPrint = PetIsTooFarAway[num];
				break;
			case EmoteType.IDontHaveAPet:
				num = UnityEngine.Random.Range(0, IDontHaveAPet.Length);
				textToPrint = IDontHaveAPet[num];
				break;
			case EmoteType.ObjectIsIndestructible:
				num = UnityEngine.Random.Range(0, ObjectIsIndestructible.Length);
				textToPrint = ObjectIsIndestructible[num];
				break;
			case EmoteType.ObjectIsImmune:
				num = UnityEngine.Random.Range(0, ObjectIsImmune.Length);
				textToPrint = ObjectIsImmune[num];
				break;
			case EmoteType.ThisWillTakeAWhile:
				num = UnityEngine.Random.Range(0, ThisWillTakeAWhile.Length);
				textToPrint = ThisWillTakeAWhile[num];
				break;
			case EmoteType.ThisWillTakeForever:
				num = UnityEngine.Random.Range(0, ThisWillTakeForever.Length);
				textToPrint = ThisWillTakeForever[num];
				break;
			case EmoteType.AlreadyScanned:
				num = UnityEngine.Random.Range(0, AlreadyScannedEmotes.Length);
				textToPrint = AlreadyScannedEmotes[num];
				break;
			case EmoteType.AllPlayersMustBeGathered:
				num = UnityEngine.Random.Range(0, AllPlayersMustBeGatheredEmotes.Length);
				textToPrint = AllPlayersMustBeGatheredEmotes[num];
				break;
			case EmoteType.NotEnoughMana:
				num = UnityEngine.Random.Range(0, NotEnoughMana.Length);
				textToPrint = NotEnoughMana[num];
				break;
			case EmoteType.WaypointActivated:
				num = UnityEngine.Random.Range(0, WaypointActivated.Length);
				textToPrint = WaypointActivated[num];
				break;
			case EmoteType.EnemiesScaledDown:
				num = UnityEngine.Random.Range(0, WaypointActivated.Length);
				textToPrint = EnemiesScaledDown[num];
				break;
			case EmoteType.EnemiesScaledUp:
				num = UnityEngine.Random.Range(0, WaypointActivated.Length);
				textToPrint = EnemiesScaledUp[num];
				break;
			case EmoteType.NoSeeds:
				num = UnityEngine.Random.Range(0, WaypointActivated.Length);
				textToPrint = NoSeeds[num];
				break;
			case EmoteType.TutorialBreakWood:
				num = UnityEngine.Random.Range(0, TutorialBreakWood.Length);
				textToPrint = TutorialBreakWood[num];
				break;
			case EmoteType.TutorialCraftTorch:
				num = UnityEngine.Random.Range(0, TutorialCraftTorch.Length);
				textToPrint = TutorialCraftTorch[num];
				break;
			case EmoteType.TutorialCraftMiningPick:
				num = UnityEngine.Random.Range(0, TutorialCraftMiningPick.Length);
				textToPrint = TutorialCraftMiningPick[num];
				break;
			case EmoteType.TutorialCraftWorkbench:
				num = UnityEngine.Random.Range(0, TutorialCraftWorkbench.Length);
				textToPrint = TutorialCraftWorkbench[num];
				break;
			case EmoteType.TutorialSmeltOre:
				num = UnityEngine.Random.Range(0, TutorialSmeltOre.Length);
				textToPrint = TutorialSmeltOre[num];
				break;
			case EmoteType.NoMinionToCommand:
				num = UnityEngine.Random.Range(0, NoMinionToCommand.Length);
				textToPrint = NoMinionToCommand[num];
				break;
			case EmoteType.ItsPowerRemainsSealed:
				num = UnityEngine.Random.Range(0, ItsPowerRemainsSealed.Length);
				textToPrint = ItsPowerRemainsSealed[num];
				break;
			case EmoteType.NoEnemyNearBait:
				num = UnityEngine.Random.Range(0, NoEnemyNearBaitEmotes.Length);
				textToPrint = NoEnemyNearBaitEmotes[num];
				break;
			default:
				textToPrint = $"<missing {emoteTypeInput} in Emote switch case>";
				text.localize = false;
				break;
			}
			text.Render(textToPrint, rewindEffectAnims: true);
		}
		else
		{
			Texture2D emoteIconSpriteSheet = GetEmoteIconSpriteSheet(emoteIconInput);
			if (emoteIconSpriteSheet != null)
			{
				iconSkin.SetTemporarySkin(emoteIconSpriteSheet);
			}
		}
	}

	private void LateUpdate()
	{
		if (durationTimer.isRunning && durationTimer.isTimerElapsed)
		{
			durationTimer.Stop();
			StartFadeOut();
		}
		if (fadeTimer.isRunning && fadeTimer.isTimerElapsed)
		{
			fadeTimer.Stop();
			Free();
		}
		if (transformToFollow != null)
		{
			base.transform.position = transformToFollow.position + emotePosition;
		}
	}

	public void StartFadeOut()
	{
		fadeEffect.FadeOut();
		fadeTimer.Start(fadeEffect.fadeOutTime);
	}

	public override void OnFree()
	{
		base.OnFree();
		text.localize = true;
		text.transform.position = Vector3.zero;
		text.transform.localScale = Vector3.zero;
		transformToFollow = null;
	}
}
