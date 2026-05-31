using UnityEngine;

public class InventoryController : MonoBehaviour
{
	public GameObject Granny;

	public GameObject gameController;

	public GameObject mittenRing;

	public GameObject dropPoint;

	public GameObject dropPointFreezeTrap;

	public GameObject dropObjectButton;

	public GameObject arrowButton;

	public GameObject sprayButton;

	public GameObject useRemoteButton;

	public bool placeObject;

	public GameObject placeObjectButton;

	public bool plankaHighlighted;

	public GameObject highlightedPlanka;

	public GameObject highlightedPlankaTrigger;

	public GameObject plankaHole;

	private Transform dropObject;

	private Rigidbody objectRB;

	public float dropForce;

	public GameObject tb1;

	public Transform newtb1;

	public bool havetb1;

	public GameObject tb2;

	public Transform newtb2;

	public bool havetb2;

	public GameObject tb3;

	public Transform newtb3;

	public bool havetb3;

	public GameObject tb4;

	public Transform newtb4;

	public bool havetb4;

	public GameObject avbitare;

	public Transform newAvbitare;

	public bool haveAvbitare;

	public GameObject hammare;

	public Transform newHammare;

	public bool haveHammare;

	public GameObject vas;

	public Transform newvas;

	public bool havevas;

	public GameObject vas2;

	public Transform newvas2;

	public bool havevas2;

	public GameObject safeKey;

	public Transform newsafeKey;

	public bool havesafeKey;

	public GameObject exitKey;

	public Transform newexitKey;

	public bool haveexitKey;

	public GameObject hanglockKey;

	public Transform newhanglockKey;

	public bool havehanglockKey;

	public GameObject padlockCode;

	public Transform newpadlockCode;

	public bool havepadlockCode;

	public GameObject armborst;

	public Transform newarmborst;

	public bool havearmborst;

	public Transform newArrow;

	public bool haveArrow;

	public bool armborstArrowOK;

	public GameObject shootArrowRay;

	public GameObject weaponKey;

	public Transform newweaponKey;

	public bool haveweaponKey;

	public GameObject screwdriver;

	public Transform newscrewdriver;

	public bool havescrewdriver;

	public GameObject planka;

	public Transform newplanka;

	public bool haveplanka;

	public GameObject battery;

	public Transform newbattery;

	public bool havebattery;

	public GameObject playhouseKey;

	public Transform newplayhouseKey;

	public bool haveplayhouseKey;

	public GameObject carKey;

	public Transform newcarKey;

	public bool havecarKey;

	public GameObject melon;

	public Transform newmelon;

	public bool havemelon;

	public GameObject teddy;

	public Transform newteddy;

	public bool haveteddy;

	public GameObject kugg1;

	public Transform newkugg1;

	public bool havekugg1;

	public GameObject kugg2;

	public Transform newkugg2;

	public bool havekugg2;

	public GameObject message;

	public Transform newmessage;

	public bool havemessage;

	public GameObject brunnsvev;

	public Transform newbrunnsvev;

	public bool havebrunnsvev;

	public GameObject oldShotgun;

	public GameObject oldShotgunAnim;

	public Transform newoldShotgun;

	public bool haveoldShotgun;

	public bool oldShotgunLoaded;

	public GameObject shootButton;

	public GameObject shootRay;

	public GameObject ammo;

	public GameObject gunDel1;

	public Transform newgunDel1;

	public bool havegunDel1;

	public GameObject gunDel2;

	public Transform newgunDel2;

	public bool havegunDel2;

	public GameObject gunDel3;

	public Transform newgunDel3;

	public bool havegunDel3;

	public GameObject topplock;

	public Transform newtopplock;

	public bool havetopplock;

	public GameObject carbattery;

	public Transform newcarbattery;

	public bool havecarbattery;

	public GameObject gascan;

	public Transform newgascan;

	public bool havegascan;

	public GameObject wrench;

	public Transform newwrench;

	public bool havewrench;

	public GameObject sparkplug;

	public Transform newsparkplug;

	public bool havesparkplug;

	public GameObject meat;

	public Transform newmeat;

	public bool havemeat;

	public GameObject specialkey;

	public Transform newspecialkey;

	public bool havespecialkey;

	public GameObject book;

	public Transform newbook;

	public bool havebook;

	public GameObject pepperspray;

	public Transform newpepperspray;

	public bool havepepperspray;

	public GameObject remote;

	public Transform newremote;

	public bool haveremote;

	public GameObject birdSeed;

	public Transform newbirdSeed;

	public bool havebirdSeed;

	public GameObject freezeTrap;

	public Transform newfreezeTrap;

	public bool havefreezeTrap;

	public GameObject wheelCrank;

	public Transform newwheelCrank;

	public bool havewheelCrank;

	public GameObject rustyPadlockKey;

	public Transform newrustyPadlockKey;

	public bool haverustyPadlockKey;

	public GameObject woodenStick;

	public Transform newwoodenStick;

	public bool havewoodenStick;

	public GameObject spiderKey;

	public Transform newspiderKey;

	public bool havespiderKey;

	public GameObject chainCutter;

	public Transform newchainCutter;

	public bool havechainCutter;

	public GameObject deadRat;

	public Transform newdeadRat;

	public bool havedeadRat;

	public GameObject christmasBall;

	public Transform newchristmasBall;

	public bool havechristmasBall;

	public GameObject christmasKulaBomb;

	public Transform newchristmasKulaBomb;

	public bool havechristmasKulaBomb;

	public GameObject NeedShotgunText;

	public GameObject NeedhangLockKeyText;

	public GameObject NeedpadlockCodeText;

	public GameObject NeedhammerText;

	public GameObject NeedsafeKeyText;

	public GameObject NeedAvbitarTongText;

	public GameObject NeedHusnyckelText;

	public GameObject NeedCrossbowText;

	public GameObject NeedweaponKeyText;

	public GameObject NeedscrewdriverText;

	public GameObject NeedbatteryText;

	public GameObject NeedplayhouseKeyText;

	public GameObject cutThingsHereText;

	public GameObject NeedWinchhandleText;

	public GameObject NeedFindSwitchText;

	public GameObject missinTavelbitarText;

	public GameObject NeedcarKeyText;

	public GameObject NeedCarBatteryText;

	public GameObject NeedSparkPlugText;

	public GameObject emptyPlateText;

	public GameObject emptyBowlText;

	public GameObject NeedEnginePartText;

	public GameObject NeedWrenchText;

	public GameObject NeedGasolineText;

	public GameObject NeedSpecialKeyText;

	public GameObject NeedRemoteControlText;

	public GameObject CantopenDoorYetText;

	public GameObject SomethingMissingHereText;

	public GameObject somethingInsideMelonText;

	public GameObject ShotgunLoadedText;

	public GameObject MaybePutSomethingHereText;

	public GameObject MaybeUsePlanksText;

	public GameObject hangLockKeyText;

	public GameObject padlockCodeText;

	public GameObject hammerText;

	public GameObject safeKeyText;

	public GameObject AvbitarTongText;

	public GameObject HusnyckelText;

	public GameObject CrossbowText;

	public GameObject TranquilizerDartText;

	public GameObject weaponKeyText;

	public GameObject screwdriverText;

	public GameObject plankText;

	public GameObject batteryText;

	public GameObject tavelbitText;

	public GameObject playhouseKeyText;

	public GameObject melonText;

	public GameObject teddyText;

	public GameObject cogwheelText;

	public GameObject winchhandleText;

	public GameObject PartOfShotgunText;

	public GameObject ShotgunText;

	public GameObject AmmoText;

	public GameObject carKeyText;

	public GameObject EnginePartText;

	public GameObject SparkPlugText;

	public GameObject GasolineCanText;

	public GameObject CarBatteryText;

	public GameObject WrenchText;

	public GameObject MeatText;

	public GameObject specialKeyText;

	public GameObject bookText;

	public GameObject peppersprayText;

	public GameObject RemoteControlText;

	public GameObject BirdSeedText;

	public GameObject freezeTrapText;

	public GameObject wheelCrankText;

	public GameObject rustyPadlockKeyText;

	public GameObject woodenStickText;

	public GameObject spiderKeyText;

	public GameObject chainCutterText;

	public GameObject NeedSpiderKeyText;

	public GameObject needAChainCutterText;

	public GameObject NeedkindofleverText;

	public GameObject needRustyPadlockKeyText;

	public GameObject needAWheelCrankText;

	public GameObject deadRatText;

	public bool textPickUpOn;

	public float texttimer1;

	private void Update()
	{
	}

	public virtual void CheckInventory()
	{
	}

	public virtual void placePlankaHole()
	{
	}

	public virtual void NoText()
	{
	}

	public virtual void textTimer1()
	{
	}

	public virtual void NoObjectText()
	{
	}

	public virtual void PlanktextTimer()
	{
	}
}
