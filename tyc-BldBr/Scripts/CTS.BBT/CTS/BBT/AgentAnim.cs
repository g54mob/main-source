using UnityEngine;

namespace CTS.BBT
{
	public static class AgentAnim
	{
		public static readonly AnimKey None = new AnimKey(0);

		public static readonly AnimKey Idle = new AnimKey("Idle");

		[Header("Sitting")]
		public static readonly AnimKey SitHighIdle = new AnimKey("SitHighIdle");

		[Header("Sitting")]
		public static readonly AnimKey SitHighRDown = new AnimKey("SitHighRDown");

		[Header("Sitting")]
		public static readonly AnimKey SitHighRUp = new AnimKey("SitHighRUp");

		[Header("Sitting")]
		public static readonly AnimKey SitHighLDown = new AnimKey("SitHighLDown");

		[Header("Sitting")]
		public static readonly AnimKey SitHighLUp = new AnimKey("SitHighLUp");

		[Header("Sitting")]
		public static readonly AnimKey SitHighBDown = new AnimKey("SitHighBDown");

		[Header("Sitting")]
		public static readonly AnimKey SitHighBUp = new AnimKey("SitHighBUp");

		[Header("Sitting")]
		public static readonly AnimKey SitLowDown = new AnimKey("SitLowDown");

		[Header("Sitting")]
		public static readonly AnimKey SitLowIdle = new AnimKey("SitLowIdle");

		[Header("Sitting")]
		public static readonly AnimKey SitLowUp = new AnimKey("SitLowUp");

		[Header("Sitting")]
		public static readonly AnimKey SitDownWC = new AnimKey("SitDownWC");

		[Header("Damage")]
		public static readonly AnimKey Bite = new AnimKey("Bite");

		[Header("Damage")]
		public static readonly AnimKey Bitten = new AnimKey("Bitten");

		[Header("Damage")]
		public static readonly AnimKey BittenDeath = new AnimKey("BittenDeath");

		[Header("Damage")]
		public static readonly AnimKey Club = new AnimKey("Club");

		[Header("Damage")]
		public static readonly AnimKey GetClubbed = new AnimKey("GetClubbed");

		[Header("Damage")]
		public static readonly AnimKey GetClubbedHighSeat = new AnimKey("GetClubbedHighSeat");

		[Header("Damage")]
		public static readonly AnimKey GetClubbedLowSeat = new AnimKey("GetClubbedLowSeat");

		[Header("Damage")]
		public static readonly AnimKey ReaperDash = new AnimKey("ReaperDash");

		[Header("Grabbing")]
		public static readonly AnimKey GrabObjectRight = new AnimKey("GrabObjectRight");

		[Header("Grabbing")]
		public static readonly AnimKey GrabObjectLeft = new AnimKey("GrabObjectLeft");

		[Header("Grabbing")]
		public static readonly AnimKey DropObjectRight = new AnimKey("DropObjectRight");

		[Header("Grabbing")]
		public static readonly AnimKey DropObjectLeft = new AnimKey("DropObjectLeft");

		[Header("Grabbing")]
		public static readonly AnimKey GrabBodyBag = new AnimKey("GrabBodyBag");

		[Header("Grabbing")]
		public static readonly AnimKey DropBodyHole = new AnimKey("DropBodyHole");

		[Header("Grabbing")]
		public static readonly AnimKey DropBodyMorgue = new AnimKey("DropBodyMorgue");

		[Header("Grabbing")]
		public static readonly AnimKey DropBodyTheDip = new AnimKey("DropBodyTheDip");

		[Header("Grabbing")]
		public static readonly AnimKey DropBody = new AnimKey("DropBody");

		[Header("Grabbing")]
		public static readonly AnimKey ClearPlate = new AnimKey("ClearPlate");

		[Header("Powers")]
		public static readonly AnimKey Hypnosis = new AnimKey("Hypnosis");

		[Header("Powers")]
		public static readonly AnimKey Hypnotised = new AnimKey("Hypnotised");

		[Header("Powers")]
		public static readonly AnimKey MemoryWipe = new AnimKey("MemoryWipe");

		[Header("Powers")]
		public static readonly AnimKey MemoryWiped = new AnimKey("MemoryWiped");

		[Header("Powers")]
		public static readonly AnimKey SwiftHands = new AnimKey("SwiftHands");

		[Header("Powers")]
		public static readonly AnimKey ThrowingMoneyStart = new AnimKey("ThrowingMoneyStart");

		[Header("Powers")]
		public static readonly AnimKey ThrowingMoneyLoop = new AnimKey("ThrowingMoneyLoop");

		[Header("Powers")]
		public static readonly AnimKey ThrowingMoneyEnd = new AnimKey("ThrowingMoneyEnd");

		[Header("Powers")]
		public static readonly AnimKey TamingHunger = new AnimKey("TamingHunger");

		[Header("Powers")]
		public static readonly AnimKey HickeyHum = new AnimKey("HickeyHum");

		[Header("Powers")]
		public static readonly AnimKey HickeyVamp = new AnimKey("HickeyVamp");

		[Header("Powers")]
		public static readonly AnimKey DarknessDisappear = new AnimKey("DarknessDisappear");

		[Header("Fun")]
		public static readonly AnimKey ThrowingDarts = new AnimKey("ThrowingDarts");

		[Header("Fun/Pinball")]
		public static readonly AnimKey PinballEnter = new AnimKey("PinballEnter");

		[Header("Fun/Pinball")]
		public static readonly AnimKey PinballStartGame = new AnimKey("PinballStartGame");

		[Header("Fun/Pinball")]
		public static readonly AnimKey PinballLoop = new AnimKey("PinballLoop");

		[Header("Fun/Pinball")]
		public static readonly AnimKey PinballExit = new AnimKey("PinballExit");

		[Header("Social")]
		public static readonly AnimKey Talk01 = new AnimKey("Talk01");

		[Header("Social")]
		public static readonly AnimKey Talk02 = new AnimKey("Talk02");

		[Header("Social")]
		public static readonly AnimKey Talk03 = new AnimKey("Talk03");

		[Header("Social")]
		public static readonly AnimKey Talk04 = new AnimKey("Talk04");

		[Header("Social")]
		public static readonly AnimKey Talk05 = new AnimKey("Talk05");

		[Header("Social")]
		public static readonly AnimKey DistractedTalk01 = new AnimKey("DistractedTalk01");

		[Header("Social")]
		public static readonly AnimKey talkfight = new AnimKey("Talkfight");

		[Header("Social")]
		public static readonly AnimKey talkfightIT = new AnimKey("TalkfightIT");

		[Header("Social")]
		public static readonly AnimKey Drunktalk = new AnimKey("Drunktalk");

		[Header("Social")]
		public static readonly AnimKey Laughing01 = new AnimKey("Laughing01");

		[Header("Social")]
		public static readonly AnimKey Laughing02 = new AnimKey("Laughing02");

		[Header("Social")]
		public static readonly AnimKey Laughing03 = new AnimKey("Laughing03");

		[Header("Social")]
		public static readonly AnimKey ListenwithPassion = new AnimKey("ListenwithPassion");

		[Header("Social")]
		public static readonly AnimKey PoliticalTalk01 = new AnimKey("PoliticalTalk01");

		[Header("State")]
		public static readonly AnimKey Frozen01 = new AnimKey("Frozen01");

		[Header("State")]
		public static readonly AnimKey Frozen02 = new AnimKey("Frozen02");

		[Header("State")]
		public static readonly AnimKey Frozen03 = new AnimKey("Frozen03");

		[Header("State")]
		public static readonly AnimKey Frozen04 = new AnimKey("Frozen04");

		[Header("State")]
		public static readonly AnimKey Frozen05 = new AnimKey("Frozen05");

		[Header("Cell")]
		public static readonly AnimKey CellHumanAppear = new AnimKey("CellHumanAppear");

		[Header("Machines")]
		public static readonly AnimKey AppearFalling = new AnimKey("AppearFalling");

		[Header("Machines")]
		public static readonly AnimKey TrapFall01 = new AnimKey("TrapFall01");

		[Header("Machines")]
		public static readonly AnimKey TrapFall02 = new AnimKey("TrapFall02");

		[Header("Machines")]
		public static readonly AnimKey Machine04Playing = new AnimKey("Machine04Playing");

		[Header("Machines")]
		public static readonly AnimKey Machine04Win = new AnimKey("Machine04Win");

		[Header("Machines")]
		public static readonly AnimKey Machine04Loose = new AnimKey("Machine04Loose");

		[Header("Machines/BloodySmoker")]
		public static readonly AnimKey BloodySmokerEnd = new AnimKey("BloodySmokerEnd");

		[Header("Machines/BloodySmoker")]
		public static readonly AnimKey BloodySmokerProcess = new AnimKey("BloodySmokerProcess");

		[Header("Machines/BloodySmoker")]
		public static readonly AnimKey BloodySmokerStart = new AnimKey("BloodySmokerStart");

		[Header("Machines/BloodyShaker")]
		public static readonly AnimKey BloodyShakerLoad = new AnimKey("BloodyShakerLoad");

		[Header("Machines/BloodyShaker")]
		public static readonly AnimKey BloodyShakerProcess = new AnimKey("BloodyShakerProcess");

		[Header("Machines/BloodyShaker")]
		public static readonly AnimKey BloodyShakerUnload = new AnimKey("BloodyShakerUnload");

		[Header("Machines/PunchingBall")]
		public static readonly AnimKey PunchingBallWin = new AnimKey("PunchingBallWin");

		[Header("Machines/PunchingBall")]
		public static readonly AnimKey PunchingBallFallBack = new AnimKey("PunchingBallFallBack");

		[Header("Machines/BloodyWineBarrel")]
		public static readonly AnimKey BloodyWineBarrelCustomerEnter = new AnimKey("BloodyWineBarrelCustomerEnter");

		[Header("Machines/BloodyWineBarrel")]
		public static readonly AnimKey BloodyWineBarrelCustomerExit = new AnimKey("BloodyWineBarrelCustomerExit");

		[Header("Machines/BloodyTeaBag")]
		public static readonly AnimKey BloodyTeaBagCustomerEnter = new AnimKey("BloodyTeaBagCustomerEnter");

		[Header("Machines/BloodyTeaBag")]
		public static readonly AnimKey BloodyTeaBagCustomerIdle = new AnimKey("BloodyTeaBagCustomerIdle");

		[Header("Machines/BloodyTeaBag")]
		public static readonly AnimKey BloodyTeaBagCustomerExit = new AnimKey("BloodyTeaBagCustomerExit");

		[Header("Machines/Hypnotic")]
		public static readonly AnimKey HypnoticHumanHypnotized = new AnimKey("HypnoticHumanHypnotized");

		[Header("Machines/DanceTrap")]
		public static readonly AnimKey DanceTrapDance = new AnimKey("DanceTrapDance");

		[Header("Machines/DanceTrap")]
		public static readonly AnimKey DanceTrapFall = new AnimKey("DanceTrapFall");

		[Header("Machines/BloodyRad")]
		public static readonly AnimKey BloodyRadCustomerEnter = new AnimKey("BloodyRadCustomerEnter");

		[Header("Machines/BloodyRad")]
		public static readonly AnimKey BloodyRadCustomerExit = new AnimKey("BloodyRadCustomerExit");

		[Header("Scared")]
		public static readonly AnimKey Scared = new AnimKey("Scared");

		[Header("Scared")]
		public static readonly AnimKey ScaredJumpStart = new AnimKey("ScaredJumpStart");

		[Header("Scared")]
		public static readonly AnimKey ScaredJumpLoop = new AnimKey("ScaredJumpLoop");

		[Header("Scared")]
		public static readonly AnimKey ScaredJumpEnd = new AnimKey("ScaredJumpEnd");

		[Header("Scared")]
		public static readonly AnimKey PanicScaredStart02 = new AnimKey("PanicScaredStart02");

		[Header("Scared")]
		public static readonly AnimKey PanicScaredLoop02 = new AnimKey("PanicScaredLoop02");

		[Header("Scared")]
		public static readonly AnimKey PanicScaredEnd02 = new AnimKey("PanicScaredEnd02");

		[Header("Drink")]
		public static readonly AnimKey Drink = new AnimKey("Drink");

		[Header("Drink")]
		public static readonly AnimKey Drink01 = new AnimKey("Drink01");

		[Header("Drink")]
		public static readonly AnimKey Drink02 = new AnimKey("Drink02");

		[Header("Drink")]
		public static readonly AnimKey Drink03 = new AnimKey("Drink03");

		[Header("Drink")]
		public static readonly AnimKey Drink04 = new AnimKey("Drink04");

		[Header("Drink")]
		public static readonly AnimKey Drink05 = new AnimKey("Drink05");

		[Header("Drink")]
		public static readonly AnimKey Drink06 = new AnimKey("Drink06");

		[Header("Cleaning")]
		public static readonly AnimKey CleanFloor = new AnimKey("CleanFloor");

		[Header("Cleaning")]
		public static readonly AnimKey CleanTableHigh = new AnimKey("CleanTableHigh");

		[Header("Cleaning")]
		public static readonly AnimKey CleanTableLow = new AnimKey("CleanTableLow");

		[Header("Note")]
		public static readonly AnimKey NoteStart = new AnimKey("NoteStart");

		[Header("Note")]
		public static readonly AnimKey NoteIdle = new AnimKey("NoteIdle");

		[Header("Note")]
		public static readonly AnimKey Note = new AnimKey("Note");

		[Header("Note")]
		public static readonly AnimKey NoteEnd = new AnimKey("NoteEnd");

		[Header("MakeDrink")]
		public static readonly AnimKey MakeDrink = new AnimKey("MakeDrink");

		[Header("MakeDrink")]
		public static readonly AnimKey MakeDrink02 = new AnimKey("MakeDrink02");

		[Header("MakeDrink")]
		public static readonly AnimKey MakeDrink03 = new AnimKey("MakeDrink03");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerPlsLoop = new AnimKey("PrisonnerPlsLoop");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerPlsSideLoop = new AnimKey("PrisonnerPlsSideLoop");

		[Header("Prisonner")]
		public static readonly AnimKey GetUpPls = new AnimKey("GetUpPls");

		[Header("Prisonner")]
		public static readonly AnimKey SitDownPls = new AnimKey("SitDownPls");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerBar = new AnimKey("PrisonnerBar");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerHarmonica = new AnimKey("PrisonnerHarmonica");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerHarmonicaGround = new AnimKey("PrisonnerHarmonicaGround");

		[Header("Prisonner")]
		public static readonly AnimKey Prisonnermug = new AnimKey("Prisonnermug");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnermugB = new AnimKey("PrisonnermugB");

		[Header("Prisonner")]
		public static readonly AnimKey PrisonnerHarmonicaStandup = new AnimKey("PrisonnerHarmonicaStandup");

		[Header("Hunter")]
		public static readonly AnimKey CrossbowDraw = new AnimKey("CrossbowDraw");

		[Header("Hunter")]
		public static readonly AnimKey CrossbowShoot = new AnimKey("CrossbowShoot");

		[Header("Hunter")]
		public static readonly AnimKey CrossbowReload = new AnimKey("CrossbowReload");

		[Header("Hunter")]
		public static readonly AnimKey CrossbowSheathe = new AnimKey("CrossbowSheathe");

		[Header("Hunter")]
		public static readonly AnimKey Sabotage = new AnimKey("Sabotage");

		[Header("LookingRightAndLeft")]
		public static readonly AnimKey LookingRightAndLeft01 = new AnimKey("LookingRightAndLeft01");

		[Header("LookingRightAndLeft")]
		public static readonly AnimKey LookingRightAndLeft02 = new AnimKey("LookingRightAndLeft02");

		[Header("LookingRightAndLeft")]
		public static readonly AnimKey LookingRightAndLeft03 = new AnimKey("LookingRightAndLeft03");

		[Header("VampireScare")]
		public static readonly AnimKey VampScare01 = new AnimKey("VampScare01");

		[Header("VampireScare")]
		public static readonly AnimKey VampScare02 = new AnimKey("VampScare02");

		[Header("VampireScare")]
		public static readonly AnimKey VampScare03 = new AnimKey("VampScare03");

		[Header("WorkerComplain")]
		public static readonly AnimKey WorkerComplain01 = new AnimKey("WorkerComplain01");

		[Header("WorkerComplain")]
		public static readonly AnimKey WorkerComplain02 = new AnimKey("WorkerComplain02");

		[Header("WorkerComplain")]
		public static readonly AnimKey WorkerComplain03 = new AnimKey("WorkerComplain03");

		[Header("WorkerOrder")]
		public static readonly AnimKey WorkerOrder01 = new AnimKey("WorkerOrder01");

		[Header("WorkerOrder")]
		public static readonly AnimKey WorkerOrder02 = new AnimKey("WorkerOrder02");

		[Header("WorkerOrder")]
		public static readonly AnimKey WorkerOrder03 = new AnimKey("WorkerOrder03");

		[Header("MachiavellianLaugh")]
		public static readonly AnimKey MachiavellianLaugh01 = new AnimKey("MachiavellianLaugh01");

		[Header("MachiavellianLaugh")]
		public static readonly AnimKey MachiavellianLaugh02 = new AnimKey("MachiavellianLaugh02");

		[Header("MachiavellianLaugh")]
		public static readonly AnimKey MachiavellianLaugh03 = new AnimKey("MachiavellianLaugh03");

		[Header("meditation")]
		public static readonly AnimKey meditation01 = new AnimKey("meditation01");

		[Header("meditation")]
		public static readonly AnimKey meditation02 = new AnimKey("meditation02");

		[Header("meditation")]
		public static readonly AnimKey meditation03 = new AnimKey("meditation03");

		[Header("VampireMakeFun")]
		public static readonly AnimKey VampireMakeFun01 = new AnimKey("VampireMakeFun01");

		[Header("VampireMakeFun")]
		public static readonly AnimKey VampireMakeFun02 = new AnimKey("VampireMakeFun02");

		[Header("VampireMakeFun")]
		public static readonly AnimKey VampireMakeFun03 = new AnimKey("VampireMakeFun03");

		[Header("WorkerSleeping")]
		public static readonly AnimKey WorkerSleeping01 = new AnimKey("WorkerSleeping01");

		[Header("WorkerSleeping")]
		public static readonly AnimKey WorkerSleeping02 = new AnimKey("WorkerSleeping02");

		[Header("WorkerSleeping")]
		public static readonly AnimKey WorkerSleeping03 = new AnimKey("WorkerSleeping03");

		[Header("WorkerSurprised")]
		public static readonly AnimKey WorkerSurprised01 = new AnimKey("WorkerSurprised01");

		[Header("WorkerSurprised")]
		public static readonly AnimKey WorkerSurprised02 = new AnimKey("WorkerSurprised02");

		[Header("WorkerSurprised")]
		public static readonly AnimKey WorkerSurprised03 = new AnimKey("WorkerSurprised03");

		[Header("MagicTrick")]
		public static readonly AnimKey MagicTrick01 = new AnimKey("MagicTrick01");

		[Header("Drunk")]
		public static readonly AnimKey DrunkSlipping = new AnimKey("DrunkSlipping");

		[Header("Drunk")]
		public static readonly AnimKey DrunkSlippingEnd = new AnimKey("DrunkSlippingEnd");

		[Header("Slipping")]
		public static readonly AnimKey SlipOnPuddle = new AnimKey("SlipOnPuddle");

		[Header("Slipping")]
		public static readonly AnimKey SlipScared = new AnimKey("SlipScared");

		[Header("Slipping")]
		public static readonly AnimKey SlipGetUp = new AnimKey("SlipGetUp");

		public static readonly AnimKey Spin = new AnimKey("Spin");

		public static readonly AnimKey Use = new AnimKey("Use");

		public static readonly AnimKey SummonWaiter = new AnimKey("SummonWaiter");

		public static readonly AnimKey Confused = new AnimKey("Confused");

		public static readonly AnimKey Death = new AnimKey("Death");

		public static readonly AnimKey FallDeath = new AnimKey("FallDeath");

		public static readonly AnimKey PassOut = new AnimKey("PassOut");

		public static readonly AnimKey PeeDance = new AnimKey("PeeDance");

		public static readonly AnimKey PeeHimself = new AnimKey("PeeHimself");

		public static readonly AnimKey Vomit = new AnimKey("Vomit");

		public static readonly AnimKey VampireSpawn = new AnimKey("VampireSpawn");

		public static readonly AnimKey GetUp = new AnimKey("GetUp");

		public static readonly AnimKey Disgust01 = new AnimKey("Disgust01");

		public static readonly AnimKey Disgust02 = new AnimKey("Disgust02");

		public static readonly AnimKey Disgust03 = new AnimKey("Disgust03");

		public static readonly AnimKey WinSatisfactionHuman = new AnimKey("WinSatisfactionHuman");

		public static readonly AnimKey LooseSatisfactionHuman = new AnimKey("LooseSatisfactionHuman");

		public static readonly AnimKey WinSatisfactionVamp = new AnimKey("WinSatisfactionVamp");

		public static readonly AnimKey LooseSatisfactionVamp = new AnimKey("LooseSatisfactionVamp");

		public static readonly AnimKey SlippingOnTheBack = new AnimKey("SlippingOnTheBack");
	}
}
