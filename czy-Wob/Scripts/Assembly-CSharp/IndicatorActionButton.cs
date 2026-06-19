using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorActionButton : MonoBehaviour
{
	public TextMeshProUGUI buttonText;

	public IndicatorAction buttonAction;

	public Image buttonIcon;

	public Image iconHolder;

	public GameObject tutorialArrow;

	public Color moreButtonColor_text;

	public Color moreButtonColor_default;

	public Color moreButtonColor_highlight;

	public Color specialActionButtonColor_text;

	public Color specialActionButtonColor_default;

	public Color specialActionButtonColor_highlight;

	public Color destroyColor_default;

	public Color destroyColor_highlight;

	public Color pupateColor_default;

	public Color pupateColor_highlight;

	public Color scoldColor_default;

	public Color scoldColor_highlight;

	public Color praiseColor_default;

	public Color praiseColor_highlight;

	private bool isDogAction;

	private bool isDogSelfAction;

	private SaveableDog associatedDog;

	private Vector3 associatedPosition;

	private ObjectIndicatorPens indicatorRef;

	private string scoldSound = "contextMenu_scold";

	private string praiseSound = "contextMenu_praise";

	private string dogCommandSound = "contextMenu_dogCommand";

	private string clickDefaultSound = "contextMenu_click_default";

	private PenFocus penFocusRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private GhostManager ghostManagerRef;

	private ConstructionManager constructionRef;

	public void SetIndicatorRef(ObjectIndicatorPens indicator)
	{
		indicatorRef = indicator;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		ghostManagerRef = registrationScript.GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
	}

	public void SetAction(IndicatorAction actionRef)
	{
		if (tutorialArrow != null)
		{
			tutorialArrow.SetActive(value: false);
		}
		buttonAction = actionRef;
		if (buttonText != null)
		{
			buttonText.text = GetTextForAction(buttonAction);
		}
		CheckIsDogAction();
		CheckIsDogSelfAction();
		if (isDogAction)
		{
			CheckActiveDog();
		}
		AssignIcon();
		if (actionRef == IndicatorAction.PAGE_ADVANCE)
		{
			GetComponent<CoreButtonUnityGUI>().colors = new ColorBlock
			{
				colorMultiplier = 1f,
				normalColor = moreButtonColor_default,
				disabledColor = moreButtonColor_default,
				pressedColor = moreButtonColor_highlight,
				highlightedColor = moreButtonColor_highlight
			};
			buttonText.color = moreButtonColor_text;
		}
		else if (!IsDogAction() && buttonText != null)
		{
			CoreButtonUnityGUI component = GetComponent<CoreButtonUnityGUI>();
			ColorBlock colors = new ColorBlock
			{
				colorMultiplier = 1f
			};
			if (buttonAction == IndicatorAction.SCOLD)
			{
				colors.normalColor = scoldColor_default;
				colors.disabledColor = scoldColor_default;
				colors.pressedColor = scoldColor_highlight;
				colors.highlightedColor = scoldColor_highlight;
			}
			else if (buttonAction == IndicatorAction.PRAISE)
			{
				colors.normalColor = praiseColor_default;
				colors.disabledColor = praiseColor_default;
				colors.pressedColor = praiseColor_highlight;
				colors.highlightedColor = praiseColor_highlight;
			}
			else if (buttonAction == IndicatorAction.DESTROY)
			{
				colors.normalColor = destroyColor_default;
				colors.disabledColor = destroyColor_default;
				colors.pressedColor = destroyColor_highlight;
				colors.highlightedColor = destroyColor_highlight;
			}
			else if (buttonAction == IndicatorAction.PUPATE_DOG)
			{
				colors.normalColor = pupateColor_default;
				colors.disabledColor = pupateColor_default;
				colors.pressedColor = pupateColor_highlight;
				colors.highlightedColor = pupateColor_highlight;
			}
			else
			{
				colors.normalColor = specialActionButtonColor_default;
				colors.disabledColor = specialActionButtonColor_default;
				colors.pressedColor = specialActionButtonColor_highlight;
				colors.highlightedColor = specialActionButtonColor_highlight;
			}
			component.colors = colors;
			buttonText.color = moreButtonColor_text;
		}
	}

	public bool IsDogAction()
	{
		return isDogAction;
	}

	private void CheckActiveDog()
	{
		associatedDog = dogRegRef.GetSelectedDog();
	}

	private void CheckIsDogAction()
	{
		string text = buttonAction.ToString();
		isDogAction = text.Length > 2 && text.Substring(0, 3) == "DOG";
	}

	private void CheckIsDogSelfAction()
	{
		string text = buttonAction.ToString();
		isDogSelfAction = text.Length > 7 && text.Substring(0, 8) == "DOG_SELF";
	}

	private void AssignIcon()
	{
		if (buttonAction == IndicatorAction.PUPATE_DOG)
		{
			if (iconHolder != null)
			{
				iconHolder.gameObject.SetActive(value: true);
				iconHolder.color = pupateColor_default;
			}
			if (tutorialArrow != null && TutorialController.GetCurrentState() == TutorialState.MUTATION_PROMPT)
			{
				tutorialArrow.SetActive(value: true);
			}
		}
		else if (iconHolder != null)
		{
			iconHolder.gameObject.SetActive(value: false);
		}
	}

	public static string GetTextForAction(IndicatorAction actionRef)
	{
		switch (actionRef)
		{
		case IndicatorAction.COLLECT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_COLLECT;
		case IndicatorAction.CLEAN_UP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_CLEAN;
		case IndicatorAction.PUT_AWAY:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PUTAWAY;
		case IndicatorAction.BANISH_GHOST:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_BANISH;
		case IndicatorAction.DESTROY:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DESTROY;
		case IndicatorAction.STORE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_STORE;
		case IndicatorAction.DOG_GRAB:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_GRAB;
		case IndicatorAction.DOG_BITE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_BITE;
		case IndicatorAction.DOG_SELF_DROP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DROP;
		case IndicatorAction.DOG_THROW:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_THROW;
		case IndicatorAction.DOG_EAT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT;
		case IndicatorAction.DOG_EAT_POOP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT;
		case IndicatorAction.DOG_EAT_DIRT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT;
		case IndicatorAction.DOG_GHOST_EAT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT;
		case IndicatorAction.DOG_WALK_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_COME;
		case IndicatorAction.DOG_DIG_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DIG;
		case IndicatorAction.DOG_SLEEP_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SLEEP;
		case IndicatorAction.DOG_SELF_SIT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SIT;
		case IndicatorAction.DOG_SELF_SPEAK:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SPEAK;
		case IndicatorAction.DOG_SELF_SLEEP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SLEEP;
		case IndicatorAction.DEN_LOOK_INSIDE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_LOOKINSIDE;
		case IndicatorAction.UPGRADE_DEN:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DENUPGRADE;
		case IndicatorAction.DEN_EXPEL:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EXPELDOGS;
		case IndicatorAction.DEN_EXPEL_OBJECTS:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EXPELITEMS;
		case IndicatorAction.EXPEL_FROM_DEN:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EXPEL;
		case IndicatorAction.CAPSULE_OPEN:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_OPENCAPSULE;
		case IndicatorAction.PAGE_ADVANCE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_MORE;
		case IndicatorAction.SCOLD:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SCOLD;
		case IndicatorAction.PRAISE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PRAISE;
		case IndicatorAction.MEMORIALIZE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_MEMORIALIZE;
		case IndicatorAction.CRACK_CORE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_CRACKOPEN;
		case IndicatorAction.VIEW_MEMORIAL:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_VIEW;
		case IndicatorAction.SUMMON_GHOST:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_CALLFORTH;
		case IndicatorAction.REMOVE_CORE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_REMOVECORE;
		case IndicatorAction.FILL_IN:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_CLEAR;
		case IndicatorAction.DOG_BURY_OBJECT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_BURYOBJECT;
		case IndicatorAction.DOG_DIG_UP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DIGUP;
		case IndicatorAction.PLANT_SEED:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PLANTSEED;
		case IndicatorAction.TV_TURN_ON:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNON;
		case IndicatorAction.TV_TURN_OFF:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNOFF;
		case IndicatorAction.MUSIC_TURN_ON:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNON;
		case IndicatorAction.MUSIC_TURN_OFF:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNOFF;
		case IndicatorAction.DOG_TV_WATCH:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_WATCHTV;
		case IndicatorAction.FAN_TURN_ON:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNON;
		case IndicatorAction.FAN_TURN_OFF:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_TURNOFF;
		case IndicatorAction.STACK_SPIN:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SPIN;
		case IndicatorAction.PUPATE_DOG:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PUPATE;
		case IndicatorAction.DOG_SELF_LEVITATE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_LEVITATE;
		case IndicatorAction.DOG_OBJECT_LEVITATE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_LEVITATE;
		case IndicatorAction.DOG_SELF_ROLLOVER:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_ROLLOVER;
		case IndicatorAction.DOG_SELF_PLAY_DEAD:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PLAYDEAD;
		case IndicatorAction.DOG_SELF_FLY:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_FLY;
		case IndicatorAction.GIFT_UNWRAP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_GIFT_UNWRAP;
		case IndicatorAction.SHAKE_SNOWGLOBE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SNOWGLOBE_SHAKE;
		case IndicatorAction.GET_SAMPLE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SAMPLES_GET;
		case IndicatorAction.PICK_FRUIT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_CACTUS_PICK;
		case IndicatorAction.HATCH_EGG:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_HATCH_EGG;
		case IndicatorAction.PAGE_BACK:
			return "[ERROR :3c]";
		default:
			return "ERROR";
		}
	}

	public static string GetSuccessTextForAction(IndicatorAction actionRef, bool targetIsDog)
	{
		switch (actionRef)
		{
		case IndicatorAction.DOG_GRAB:
			if (targetIsDog)
			{
				return ScriptLocalization.BehaviorsAndCommands.ACTN_GRAB_DOG_SUCCESS;
			}
			return ScriptLocalization.BehaviorsAndCommands.ACTN_GRAB_OBJ_SUCCESS;
		case IndicatorAction.DOG_BITE:
			if (targetIsDog)
			{
				return ScriptLocalization.BehaviorsAndCommands.ACTN_BITE_DOG_SUCCESS;
			}
			return ScriptLocalization.BehaviorsAndCommands.ACTN_BITE_OBJ_SUCCESS;
		case IndicatorAction.DOG_THROW:
			if (targetIsDog)
			{
				return ScriptLocalization.BehaviorsAndCommands.ACTN_THROW_DOG_SUCCESS;
			}
			return ScriptLocalization.BehaviorsAndCommands.ACTN_THROW_OBJ_SUCCESS;
		case IndicatorAction.DOG_EAT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT_OBJ_SUCCESS;
		case IndicatorAction.DOG_EAT_POOP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT_OBJ_SUCCESS;
		case IndicatorAction.DOG_EAT_DIRT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT_OBJ_SUCCESS;
		case IndicatorAction.DOG_GHOST_EAT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_EAT_OBJ_SUCCESS;
		case IndicatorAction.DOG_WALK_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_COME_SUCCESS;
		case IndicatorAction.DOG_DIG_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DIG_SUCCESS;
		case IndicatorAction.DOG_SLEEP_HERE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SLEEP_SUCCESS;
		case IndicatorAction.DOG_SELF_SIT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SIT_SUCCESS;
		case IndicatorAction.DOG_SELF_SPEAK:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SPEAK_SUCCESS;
		case IndicatorAction.DOG_SELF_SLEEP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_SLEEP_SUCCESS;
		case IndicatorAction.DOG_BURY_OBJECT:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_BURYOBJECT_OBJ_SUCCESS;
		case IndicatorAction.DOG_DIG_UP:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_DIGUP_OBJ_SUCCESS;
		case IndicatorAction.DOG_TV_WATCH:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_WATCHTV_SUCCESS;
		case IndicatorAction.DOG_SELF_LEVITATE:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_LEVITATE_SELF_SUCCESS;
		case IndicatorAction.DOG_SELF_FLY:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_FLY_SUCCESS;
		case IndicatorAction.DOG_OBJECT_LEVITATE:
			if (targetIsDog)
			{
				return ScriptLocalization.BehaviorsAndCommands.ACTN_LEVITATE_DOG_SUCCESS;
			}
			return ScriptLocalization.BehaviorsAndCommands.ACTN_LEVITATE_OBJ_SUCCESS;
		case IndicatorAction.DOG_SELF_ROLLOVER:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_ROLLOVER_SUCCESS;
		case IndicatorAction.DOG_SELF_PLAY_DEAD:
			return ScriptLocalization.BehaviorsAndCommands.ACTN_PLAYDEAD_SUCCESS;
		case IndicatorAction.PAGE_BACK:
			return "[ERROR :3c]";
		default:
			return "ERROR";
		}
	}

	public void OnClick()
	{
		RunAction();
		if (buttonAction != IndicatorAction.PAGE_ADVANCE && buttonAction != IndicatorAction.PAGE_BACK)
		{
			indicatorRef.CloseContextMenu();
		}
		if (isDogAction)
		{
			AudioController.Play(dogCommandSound);
		}
		AudioController.Play(clickDefaultSound);
	}

	public void ReportMouseOverContextButton()
	{
		indicatorRef.ReportMouseOverContextButton(isDogAction, isDogSelfAction);
		if (iconHolder != null)
		{
			iconHolder.color = pupateColor_highlight;
		}
	}

	public void ReportMouseOffContextButton()
	{
		indicatorRef.ReportMouseOffContextButton();
		if (iconHolder != null)
		{
			iconHolder.color = pupateColor_default;
		}
	}

	private void RunAction()
	{
		GameObject indicatedObject = indicatorRef.GetIndicatedObject();
		if (buttonAction != IndicatorAction.PAGE_ADVANCE && buttonAction != IndicatorAction.PAGE_BACK && buttonAction != IndicatorAction.CRACK_CORE)
		{
			Object.Instantiate(position: (!(indicatedObject != null)) ? indicatorRef.GetAssociatedPosition() : ObjectUtil.GetObjCenter(indicatedObject), original: indicatorRef.actionParticles, rotation: Quaternion.identity);
		}
		DogAI dogAI = null;
		if (indicatedObject != null)
		{
			dogAI = indicatedObject.GetComponent<DogAI>();
		}
		switch (buttonAction)
		{
		case IndicatorAction.COLLECT:
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			if (indicatedObject.CompareTag(Tags.EGG))
			{
				indicatedObject.GetComponent<DogEgg>().CollectEgg();
			}
			else if (indicatedObject.CompareTag(Tags.SEED_PACKET))
			{
				indicatedObject.GetComponent<SeedPacket>().CollectSeeds();
			}
			else if (indicatedObject.CompareTag(Tags.DEN_UPGRADE))
			{
				indicatedObject.GetComponent<DenUpgrade>().CollectUpgrade();
			}
			break;
		case IndicatorAction.CLEAN_UP:
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			indicatedObject.GetComponent<DogPoop>().CleanUp();
			break;
		case IndicatorAction.PUT_AWAY:
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			Object.Destroy(indicatedObject);
			break;
		case IndicatorAction.BANISH_GHOST:
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			ghostManagerRef.BanishGhost(indicatedObject);
			break;
		case IndicatorAction.DESTROY:
		{
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			RegisterTaggedObject component = indicatedObject.GetComponent<RegisterTaggedObject>();
			if (component != null)
			{
				component.SetSafeDestroy();
			}
			Object.Destroy(indicatedObject);
			break;
		}
		case IndicatorAction.STORE:
			grabberRef.OnObjectRemovedByPlayer(indicatedObject);
			Object.Destroy(indicatedObject);
			break;
		case IndicatorAction.DOG_GRAB:
			RunCommand();
			break;
		case IndicatorAction.DOG_BITE:
			RunCommand();
			break;
		case IndicatorAction.DOG_SELF_DROP:
			indicatedObject.GetComponent<MouthController>().DropObject();
			dogAI.SetGracePeriodTimer();
			break;
		case IndicatorAction.DOG_THROW:
			RunCommand();
			break;
		case IndicatorAction.DOG_EAT:
			RunCommand();
			break;
		case IndicatorAction.DOG_EAT_POOP:
			RunCommand();
			break;
		case IndicatorAction.DOG_EAT_DIRT:
			RunCommand();
			break;
		case IndicatorAction.DOG_GHOST_EAT:
			RunCommand();
			break;
		case IndicatorAction.DOG_WALK_HERE:
			WalkToPoint();
			break;
		case IndicatorAction.DOG_DIG_HERE:
			DigAtLocation();
			break;
		case IndicatorAction.DOG_SLEEP_HERE:
			SleepAtPoint();
			break;
		case IndicatorAction.DOG_SELF_SIT:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_SELF_SPEAK:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_SELF_SLEEP:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DEN_LOOK_INSIDE:
			penFocusRef.FocusOnDen(indicatedObject);
			break;
		case IndicatorAction.UPGRADE_DEN:
			indicatedObject.GetComponent<DogDen>().OpenUpgradeUI();
			break;
		case IndicatorAction.DEN_EXPEL:
			indicatedObject.GetComponent<DogDen>().ExpelDogs();
			break;
		case IndicatorAction.DEN_EXPEL_OBJECTS:
			indicatedObject.GetComponent<DogDen>().ExpelAllObjects();
			break;
		case IndicatorAction.EXPEL_FROM_DEN:
			DenInteriorManager.ExpelObjectFromDen(indicatedObject);
			break;
		case IndicatorAction.CAPSULE_OPEN:
			indicatedObject.GetComponent<Capsule>().Open();
			break;
		case IndicatorAction.PAGE_ADVANCE:
			indicatorRef.AdvanceActionPage();
			break;
		case IndicatorAction.PAGE_BACK:
			indicatorRef.RetreatActionPage();
			break;
		case IndicatorAction.SCOLD:
			ScoldDog();
			dogAI.SetGracePeriodTimer();
			break;
		case IndicatorAction.PRAISE:
			PraiseDog();
			break;
		case IndicatorAction.MEMORIALIZE:
			indicatedObject.GetComponent<DogCore>().Memorialize();
			break;
		case IndicatorAction.CRACK_CORE:
			indicatedObject.GetComponent<DogCore>().Crack();
			break;
		case IndicatorAction.VIEW_MEMORIAL:
			indicatedObject.GetComponent<DogMemorial>().DisplayMemorialGUI();
			break;
		case IndicatorAction.SUMMON_GHOST:
			indicatedObject.GetComponent<DogMemorial>().SummonGhost();
			break;
		case IndicatorAction.REMOVE_CORE:
			indicatedObject.GetComponent<DogMemorial>().RemoveCore();
			break;
		case IndicatorAction.FILL_IN:
			indicatedObject.GetComponent<Hole>().FillIn();
			break;
		case IndicatorAction.PLANT_SEED:
			indicatedObject.GetComponent<Hole>().OpenSeedGUI();
			break;
		case IndicatorAction.DOG_BURY_OBJECT:
			RunCommand();
			break;
		case IndicatorAction.DOG_DIG_UP:
			RunCommand();
			break;
		case IndicatorAction.TV_TURN_ON:
			indicatedObject.GetComponent<InteractableTV>().TurnOn();
			break;
		case IndicatorAction.TV_TURN_OFF:
			indicatedObject.GetComponent<InteractableTV>().TurnOff();
			break;
		case IndicatorAction.MUSIC_TURN_ON:
			indicatedObject.GetComponent<InteractableMusicPlayer>().TurnOn();
			break;
		case IndicatorAction.MUSIC_TURN_OFF:
			indicatedObject.GetComponent<InteractableMusicPlayer>().TurnOff();
			break;
		case IndicatorAction.FAN_TURN_ON:
			indicatedObject.GetComponent<IndustrialFan>().TurnOn();
			break;
		case IndicatorAction.FAN_TURN_OFF:
			indicatedObject.GetComponent<IndustrialFan>().TurnOff();
			break;
		case IndicatorAction.DOG_TV_WATCH:
			RunCommand();
			break;
		case IndicatorAction.STACK_SPIN:
			indicatedObject.GetComponent<InteractableDogStack>().Spin();
			break;
		case IndicatorAction.PUPATE_DOG:
			indicatedObject.GetComponent<CocoonController>().EnterCocoon();
			break;
		case IndicatorAction.DOG_SELF_LEVITATE:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_SELF_FLY:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_SELF_ROLLOVER:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_SELF_PLAY_DEAD:
			RunCommand(targeted: false);
			break;
		case IndicatorAction.DOG_OBJECT_LEVITATE:
			RunCommand();
			break;
		case IndicatorAction.GIFT_UNWRAP:
			indicatedObject.GetComponent<InteractableGift>().Unwrap();
			break;
		case IndicatorAction.SHAKE_SNOWGLOBE:
			indicatedObject.GetComponent<InteractableSnowglobe>().ShakeGlobe();
			break;
		case IndicatorAction.GET_SAMPLE:
			indicatedObject.GetComponent<InteractableSamplesTable>().GetSample();
			break;
		case IndicatorAction.PICK_FRUIT:
			indicatedObject.GetComponent<InteractablePricklyPear>().PickFruit();
			break;
		case IndicatorAction.HATCH_EGG:
			indicatedObject.GetComponent<DogEgg>().HatchEgg();
			break;
		}
	}

	private void RunCommand(bool targeted = true, GameObject customTarget = null, Vector2Int? associatedGridSquare = null, ulong? associatedRoomUID = null)
	{
		DogAI component = dogRegRef.GetDogFromID(associatedDog.dogID).GetComponent<DogAI>();
		GameObject target = null;
		if (targeted)
		{
			target = ((!(customTarget != null)) ? indicatorRef.GetIndicatedObject() : customTarget);
		}
		if (component.TryRunIndicatorBehavior(buttonAction, target) && associatedGridSquare.HasValue)
		{
			DogBehaviorBase currentBehavior = component.GetCurrentBehavior();
			currentBehavior.StoreRoomUID(associatedRoomUID.Value);
			currentBehavior.StoreGridSquare(associatedGridSquare.Value);
		}
	}

	private void PraiseDog()
	{
		AudioController.Play(praiseSound);
		indicatorRef.GetIndicatedObject().GetComponent<DoggyBrain>().OnDogPraised();
	}

	private void ScoldDog()
	{
		AudioController.Play(scoldSound);
		indicatorRef.GetIndicatedObject().GetComponent<DoggyBrain>().OnDogScolded();
	}

	private void DigAtLocation()
	{
		associatedPosition = indicatorRef.GetAssociatedPosition();
		ulong UID = 0uL;
		GameObject dogFromID = dogRegRef.GetDogFromID(associatedDog.dogID);
		if (!constructionRef.StoreRoomUIDForPosition(associatedPosition, ref UID))
		{
			dogFromID.GetComponent<DogIndicatorController>().OnCommandIgnored();
			return;
		}
		RoomBase component = constructionRef.GetObjectForUID(UID).GetComponent<RoomBase>();
		Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(associatedPosition, component);
		if (!dogFromID.GetComponent<DogDenController>().CanDigHole(component, gridSquareForPositionAndRoom))
		{
			dogFromID.GetComponent<DogIndicatorController>().OnCommandIgnored(ScriptLocalization.BehaviorsAndCommands.CMND_DIG_FAIL);
		}
		else
		{
			RunCommand(targeted: true, null, gridSquareForPositionAndRoom, UID);
		}
	}

	private void WalkToPoint()
	{
		associatedPosition = indicatorRef.GetAssociatedPosition();
		dogRegRef.GetDogFromID(associatedDog.dogID).GetComponent<DogAI>().TryRunIndicatorBehavior(buttonAction, null, associatedPosition);
	}

	private void SleepAtPoint()
	{
		associatedPosition = indicatorRef.GetAssociatedPosition();
		dogRegRef.GetDogFromID(associatedDog.dogID).GetComponent<DogAI>().TryRunIndicatorBehavior(buttonAction, null, associatedPosition);
	}

	public bool IsValid()
	{
		GameObject indicatedObject = indicatorRef.GetIndicatedObject();
		if (isDogAction)
		{
			CheckActiveDog();
			if (associatedDog == null || associatedDog.inCocoon)
			{
				return false;
			}
			bool flag = false;
			if (indicatedObject != null && indicatedObject.CompareTag(Tags.DOG))
			{
				flag = dogRegRef.GetSaveableDogFromDog(indicatedObject).dogID == associatedDog.dogID;
				if (flag != isDogSelfAction)
				{
					return false;
				}
			}
			if (buttonAction == IndicatorAction.DOG_SELF_DROP)
			{
				if (!indicatedObject.GetComponent<MouthController>().IsCarryingObject())
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_BURY_OBJECT)
			{
				if (indicatedObject.GetComponent<Hole>().GetCurrentHoleStage() != HoleStage.EMPTY)
				{
					return false;
				}
				if (!dogRegRef.GetDogFromID(associatedDog.dogID).GetComponent<DogAI>().GetBehaviorForIndicatorAction(buttonAction)
					.HeldObjectTagsValid())
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_DIG_UP)
			{
				if (indicatedObject.GetComponent<Hole>().GetCurrentHoleStage() != HoleStage.FILLED)
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_TV_WATCH)
			{
				if (!indicatedObject.GetComponent<InteractableTV>().IsCurrentlyOn())
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_EAT || buttonAction == IndicatorAction.DOG_EAT_DIRT || buttonAction == IndicatorAction.DOG_EAT_POOP)
			{
				if (associatedDog.isGhost)
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_GHOST_EAT || buttonAction == IndicatorAction.DOG_SELF_LEVITATE || buttonAction == IndicatorAction.DOG_OBJECT_LEVITATE)
			{
				if (!associatedDog.isGhost)
				{
					return false;
				}
				if (buttonAction == IndicatorAction.DOG_OBJECT_LEVITATE && flag)
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_SELF_FLY)
			{
				if (dogRegRef.GetDogFromID(associatedDog.dogID).GetComponent<DogLooks>().GetWingType() == WingType.NO_WINGS)
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_DIG_HERE)
			{
				Vector3 pos = indicatorRef.GetAssociatedPosition();
				ulong UID = 0uL;
				GameObject dogFromID = dogRegRef.GetDogFromID(associatedDog.dogID);
				if (!constructionRef.StoreRoomUIDForPosition(pos, ref UID))
				{
					return false;
				}
				RoomBase component = constructionRef.GetObjectForUID(UID).GetComponent<RoomBase>();
				Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(pos, component);
				if (!dogFromID.GetComponent<DogDenController>().CanDigHole(component, gridSquareForPositionAndRoom))
				{
					return false;
				}
			}
			else if (buttonAction == IndicatorAction.DOG_SELF_PLAY_DEAD && associatedDog.brain.dogAge != DogAge.ANCIENT)
			{
				return false;
			}
			return true;
		}
		if (buttonAction == IndicatorAction.PLANT_SEED)
		{
			if (indicatedObject.GetComponent<Hole>().GetCurrentHoleStage() != HoleStage.EMPTY)
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.TV_TURN_ON)
		{
			if (indicatedObject.GetComponent<InteractableTV>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.TV_TURN_OFF)
		{
			if (!indicatedObject.GetComponent<InteractableTV>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.MUSIC_TURN_ON)
		{
			if (indicatedObject.GetComponent<InteractableMusicPlayer>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.MUSIC_TURN_OFF)
		{
			if (!indicatedObject.GetComponent<InteractableMusicPlayer>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.FAN_TURN_ON)
		{
			if (indicatedObject.GetComponent<IndustrialFan>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.FAN_TURN_OFF)
		{
			if (!indicatedObject.GetComponent<IndustrialFan>().IsCurrentlyOn())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.DEN_LOOK_INSIDE || buttonAction == IndicatorAction.UPGRADE_DEN || buttonAction == IndicatorAction.DEN_EXPEL || buttonAction == IndicatorAction.DEN_EXPEL_OBJECTS)
		{
			DogDen component2 = indicatedObject.GetComponent<DogDen>();
			if (!component2.IsCompleted())
			{
				return false;
			}
			if (buttonAction == IndicatorAction.DEN_EXPEL && component2.GetNumberOfCurrentOccupants() == 0)
			{
				return false;
			}
			ulong uID = component2.GetComponent<PlacedObjectID>().GetUID();
			if (buttonAction == IndicatorAction.DEN_EXPEL_OBJECTS && DenInteriorManager.GetAllContainedObjects(uID, TagsEnum.ALL, dogsAllowed: false).Count == 0)
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.EXPEL_FROM_DEN)
		{
			if (!DenInteriorManager.IsObjectInsideOfAnyDenInterior(indicatedObject))
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.PUPATE_DOG)
		{
			if (!indicatedObject.GetComponent<DoggyBrain>().IsReadyForCocoon())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.SUMMON_GHOST)
		{
			if (GoalsController.GetStatusForID(GhostManager.ghostGoalID) != GoalStatus.CLAIMED)
			{
				return false;
			}
			ulong uID2 = indicatedObject.GetComponent<PlacedObjectID>().GetUID();
			if (ghostManagerRef.IsGhostSpawnedForMemorial(uID2) || ghostManagerRef.IsGhostSpawningForMemorial(uID2))
			{
				return false;
			}
			if (dogRegRef.GetNumberOfOwnedAndLoadingDogsIncludingGhosts() >= dogRegRef.GetMaxDogs())
			{
				return false;
			}
		}
		else if (buttonAction == IndicatorAction.HATCH_EGG && !indicatedObject.GetComponent<DogEgg>().CanHatch())
		{
			return false;
		}
		return true;
	}
}
