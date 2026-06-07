using System;
using UnityEngine;

[Serializable]
public class PickUp : MonoBehaviour
{
	public LayerMask layerMask;

	public GameObject gameController;

	public GameObject Granny;

	public Transform GrannyStartPos;

	public GameObject SeeRay;

	public GameObject player;

	public bool playerTaken;

	public bool pickUp;

	public bool readyPickUp;

	public bool dropObject;

	public bool placeObject;

	public float rayThick;

	public float rayThickDelat;

	public GameObject dropPoint;

	public GameObject dropPointPlanka;

	public GameObject dropObjectButton;

	public GameObject placeObjectButton;

	public GameObject soundHolder;

	public GameObject SpraysoundHolder;

	public GameObject mittenRing;

	public GameObject avklipptKabelCellar;

	public GameObject avklipptKabelVind;

	public GameObject KabelVind;

	public GameObject avklipptKabel;

	public GameObject fan;

	public GameObject fanCollider;

	public bool playSound;

	public AudioClip klippKabel;

	public AudioClip taBortPlanka;

	public AudioClip doorLocked;

	public AudioClip safeDoordoorLocked;

	public AudioClip safeDoorOpen;

	public AudioClip vapenDoorOpen;

	public AudioClip hitCam;

	public AudioClip plockaUppObject;

	public AudioClip plockaUppNyckel;

	public AudioClip plockaUppCrossbow;

	public AudioClip placeBattery;

	public AudioClip pickUpTeddy;

	public AudioClip placebrunnsvev;

	public AudioClip placeMelon;

	public AudioClip drarIspak;

	public AudioClip meatPlate;

	public AudioClip vind2Dooropen;

	public AudioClip vind2Lockopen;

	public AudioClip pickUpGascan;

	public AudioClip skruva;

	public AudioClip fillSeed;

	public AudioClip openSpiderLucka;

	public AudioClip cutChain;

	public AudioClip openSpinLock;

	public AudioClip snurraWheelCrank;

	public GameObject LampaDoor1;

	public GameObject LampaDoor2;

	public GameObject doorRayHolder;

	public GameObject Bom;

	public GameObject DdoorLock;

	public GameObject arrowButton;

	public GameObject arrowArmborst;

	public GameObject Armborstladdad;

	public GameObject ArmborstOladdad;

	public GameObject avbitare;

	public Transform newAvbitare;

	public GameObject hammare;

	public Transform newHammare;

	public GameObject vas;

	public Transform newvas;

	public GameObject vas2;

	public Transform newvas2;

	public GameObject safeKey;

	public Transform newsafeKey;

	public GameObject exitKey;

	public Transform newexitKey;

	public GameObject hanglockKey;

	public Transform newhanglockKey;

	public GameObject padlockCode;

	public Transform newpadlockCode;

	public GameObject armborst;

	public Transform newarmborst;

	public Transform newArrow;

	public GameObject shootArrowRay;

	public GameObject weaponKey;

	public Transform newweaponKey;

	public GameObject screwdriver;

	public Transform newscrewdriver;

	public GameObject planka;

	public Transform newplanka;

	public GameObject battery;

	public Transform newbattery;

	public GameObject playhouseKey;

	public Transform newplayhouseKey;

	public GameObject carKey;

	public Transform newcarKey;

	public GameObject melon;

	public Transform newmelon;

	public GameObject teddy;

	public Transform newteddy;

	public GameObject kugg1;

	public Transform newkugg1;

	public GameObject kugg2;

	public Transform newkugg2;

	public GameObject message;

	public Transform newmessage;

	public GameObject brunnsvev;

	public Transform newbrunnsvev;

	public GameObject oldShotgun;

	public GameObject oldShotgunAnim;

	public Transform newoldShotgun;

	public bool oldShotgunLoaded;

	public GameObject shootButton;

	public GameObject shootRay;

	public GameObject ammo;

	public GameObject gunDel1;

	public Transform newgunDel1;

	public GameObject gunDel2;

	public Transform newgunDel2;

	public GameObject gunDel3;

	public Transform newgunDel3;

	public GameObject topplock;

	public Transform newtopplock;

	public GameObject topplockInPlace;

	public GameObject carbattery;

	public Transform newcarbattery;

	public GameObject carbatteryInPlace;

	public GameObject gascan;

	public Transform newgascan;

	public GameObject wrench;

	public Transform newwrench;

	public GameObject sparkplug;

	public Transform newsparkplug;

	public GameObject sparkPlugInPlace;

	public GameObject sparkPlugCable;

	public GameObject meat;

	public Transform newmeat;

	public GameObject spider;

	public GameObject meatOnPlate;

	public GameObject spiderTrigger;

	public GameObject specialkey;

	public Transform newspecialkey;

	public GameObject specialkeyLock;

	public GameObject specialkeyDoor;

	public GameObject specialkeyInPlace;

	public GameObject book;

	public Transform newbook;

	public GameObject pepperspray;

	public Transform newpepperspray;

	public GameObject remote;

	public Transform newremote;

	public GameObject birdSeed;

	public Transform newbirdSeed;

	public GameObject deadRat;

	public Transform newdeadRat;

	public GameObject christmasKula;

	public Transform newchristmasKula;

	public GameObject christmasKulaBomb;

	public Transform newchristmasKulaBomb;

	public GameObject freezeTrap;

	public Transform newfreezeTrap;

	public GameObject wheelCrank;

	public Transform newwheelCrank;

	public GameObject wheelCrankInPlace;

	public GameObject rustyPadlockKey;

	public Transform newrustyPadlockKey;

	public GameObject woodenStick;

	public Transform newwoodenStick;

	public GameObject woodenStickInPlace;

	public GameObject spiderKey;

	public Transform newspiderKey;

	public GameObject chainCutter;

	public Transform newchainCutter;

	public GameObject sprayButton;

	public GameObject sprayParticle;

	public GameObject useRemoteButton;

	public GameObject oldMomRigidbody;

	public GameObject bookInPlace;

	public GameObject MomSound;

	public GameObject StartCrawlMomTrigger;

	public bool plankaHighlighted;

	public GameObject highlightedPlanka;

	public GameObject highlightedPlankaTrigger;

	public GameObject plankaHole;

	public GameObject skruvPlatta;

	public GameObject skruvPlattaOutside;

	public bool textBort;

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

	public GameObject deadRatText;

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

	public GameObject NeedWinchhandleText;

	public GameObject NeedFindSwitchText;

	public GameObject NeedcarKeyText;

	public GameObject NeedCarBatteryText;

	public GameObject NeedSparkPlugText;

	public GameObject NeedEnginePartText;

	public GameObject NeedWrenchText;

	public GameObject NeedGasolineText;

	public GameObject NeedSpecialKeyText;

	public GameObject NeedRemoteControlText;

	public GameObject needASpiderKeyText;

	public GameObject needAChainCutterText;

	public GameObject NeedkindofleverText;

	public GameObject needRustyPadlockKeyText;

	public GameObject needAWheelCrankText;

	public GameObject ShotgunLoadedText;

	public GameObject cutThingsHereText;

	public GameObject missinTavelbitarText;

	public GameObject emptyPlateText;

	public GameObject emptyBowlText;

	public GameObject MaybePutSomethingHereText;

	public GameObject CantopenDoorYetText;

	public GameObject somethingInsideMelonText;

	public GameObject SomethingMissingHereText;

	public GameObject kamera;

	public GameObject kameraBroken;

	public GameObject galler;

	public GameObject gallerColliders;

	public bool playerInPrison;

	public GameObject prisonDoor;

	public GameObject batteryOnPlace;

	public GameObject batterySpak;

	public GameObject tb1;

	public Transform newtb1;

	public GameObject tb2;

	public Transform newtb2;

	public GameObject tb3;

	public Transform newtb3;

	public GameObject tb4;

	public Transform newtb4;

	public GameObject playhouseDoor;

	public GameObject giljoCutArea;

	public GameObject melonInPlace;

	public GameObject giljotin;

	public bool haveSeenMelonText;

	public bool kugg1OK;

	public bool kugg2OK;

	public GameObject playHouseLucka;

	public GameObject kugg1inPlace;

	public GameObject kugg2inPlace;

	public GameObject brunnsvevInPlace;

	public GameObject brunnsvevsHolder;

	public GameObject extremeLockOn;

	public GameObject extremeLockOff;

	public GameObject crow;

	public GameObject CrossBowLocker;

	public GameObject AllSyringe;

	public GameObject luckaSpiderCellar;

	public GameObject ironDoorsHolder;

	public GameObject ironDoorsController;

	public GameObject spiderCellarGallerHolder;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void closeTexts()
	{
	}

	public virtual void closeObjTexts()
	{
	}

	public virtual void audio()
	{
	}
}
