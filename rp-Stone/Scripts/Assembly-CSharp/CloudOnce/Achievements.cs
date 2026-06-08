using System.Collections.Generic;
using CloudOnce.Internal;

namespace CloudOnce
{
	public static class Achievements
	{
		private static readonly UnifiedAchievement s_journeyBegins = new UnifiedAchievement("JourneyBegins", "JourneyBegins");

		private static readonly UnifiedAchievement s_resourceMagnate = new UnifiedAchievement("ResourceMagnate", "ResourceMagnate");

		private static readonly UnifiedAchievement s_definitelyAKiper = new UnifiedAchievement("DefinitelyAKiper", "DefinitelyAKiper");

		private static readonly UnifiedAchievement s_experienced = new UnifiedAchievement("Experienced", "Experienced");

		private static readonly UnifiedAchievement s_watchOutForTheTail = new UnifiedAchievement("WatchOutForTheTail", "WatchOutForTheTail");

		private static readonly UnifiedAchievement s_getBuffed = new UnifiedAchievement("GetBuffed", "GetBuffed");

		private static readonly UnifiedAchievement s_kamehameha = new UnifiedAchievement("Kamehameha", "Kamehameha");

		private static readonly UnifiedAchievement s_threeTimesACharm = new UnifiedAchievement("ThreeTimesACharm", "ThreeTimesACharm");

		private static readonly UnifiedAchievement s_backpedal = new UnifiedAchievement("Backpedal", "Backpedal");

		private static readonly UnifiedAchievement s_attackSpeedOP = new UnifiedAchievement("AttackSpeedOP", "AttackSpeedOP");

		private static readonly UnifiedAchievement s_pacifist = new UnifiedAchievement("Pacifist", "Pacifist");

		private static readonly UnifiedAchievement s_someBadNews = new UnifiedAchievement("SomeBadNews", "SomeBadNews");

		private static readonly UnifiedAchievement s_handyman = new UnifiedAchievement("Handyman", "Handyman");

		private static readonly UnifiedAchievement s_gameLogic = new UnifiedAchievement("GameLogic", "GameLogic");

		private static readonly UnifiedAchievement s_masterCraftsman = new UnifiedAchievement("MasterCraftsman", "MasterCraftsman");

		private static readonly UnifiedAchievement s_perfectionist = new UnifiedAchievement("Perfectionist", "Perfectionist");

		private static readonly UnifiedAchievement s_professionalLogger = new UnifiedAchievement("ProfessionalLogger", "ProfessionalLogger");

		private static readonly UnifiedAchievement s_bugSquasher = new UnifiedAchievement("BugSquasher", "BugSquasher");

		private static readonly UnifiedAchievement s_mushroomMuncher = new UnifiedAchievement("MushroomMuncher", "MushroomMuncher");

		private static readonly UnifiedAchievement s_boneBreaker = new UnifiedAchievement("BoneBreaker", "BoneBreaker");

		private static readonly UnifiedAchievement s_clockworkCremation = new UnifiedAchievement("ClockworkCremation", "ClockworkCremation");

		private static readonly UnifiedAchievement s_stayCool = new UnifiedAchievement("StayCool", "StayCool");

		private static readonly UnifiedAchievement s_nadaraja = new UnifiedAchievement("Nadaraja", "Nadaraja");

		private static readonly UnifiedAchievement s_dissAngelos = new UnifiedAchievement("DissAngelos", "DissAngelos");

		private static readonly UnifiedAchievement s_exterminator = new UnifiedAchievement("Exterminator", "Exterminator");

		private static readonly UnifiedAchievement s_hoarder = new UnifiedAchievement("Hoarder", "Hoarder");

		private static readonly UnifiedAchievement s_aGoodDeal = new UnifiedAchievement("AGoodDeal", "AGoodDeal");

		private static readonly UnifiedAchievement s_oneForTheBooks = new UnifiedAchievement("OneForTheBooks", "OneForTheBooks");

		private static readonly UnifiedAchievement s_cyanara = new UnifiedAchievement("Cyanara", "Cyanara");

		private static readonly UnifiedAchievement s_enchantedToMeetYa = new UnifiedAchievement("EnchantedToMeetYa", "EnchantedToMeetYa");

		private static readonly UnifiedAchievement s_overTheRainbow = new UnifiedAchievement("OverTheRainbow", "OverTheRainbow");

		private static readonly UnifiedAchievement s_permutationPerfectionist = new UnifiedAchievement("PermutationPerfectionist", "PermutationPerfectionist");

		private static readonly UnifiedAchievement s_scottysNewFriend = new UnifiedAchievement("ScottysNewFriend", "ScottysNewFriend");

		private static readonly UnifiedAchievement s_programmer = new UnifiedAchievement("Programmer", "Programmer");

		private static readonly UnifiedAchievement s_aFKFarmer = new UnifiedAchievement("AFKFarmer", "AFKFarmer");

		private static readonly UnifiedAchievement s_midnightFarmer = new UnifiedAchievement("MidnightFarmer", "MidnightFarmer");

		private static readonly UnifiedAchievement s_shoppingMadness = new UnifiedAchievement("ShoppingMadness", "ShoppingMadness");

		private static readonly UnifiedAchievement s_oneShotOneKill = new UnifiedAchievement("OneShotOneKill", "OneShotOneKill");

		private static readonly UnifiedAchievement s_revenge = new UnifiedAchievement("Revenge", "Revenge");

		private static readonly UnifiedAchievement s_alchemist = new UnifiedAchievement("Alchemist", "Alchemist");

		private static readonly UnifiedAchievement s_finallyAWizard = new UnifiedAchievement("FinallyAWizard", "FinallyAWizard");

		private static readonly UnifiedAchievement s_farewellow = new UnifiedAchievement("Farewellow", "Farewellow");

		private static readonly UnifiedAchievement s_speakImportToEnter = new UnifiedAchievement("SpeakImportToEnter", "SpeakImportToEnter");

		private static readonly UnifiedAchievement s_hansHugs = new UnifiedAchievement("HansHugs", "HansHugs");

		private static readonly UnifiedAchievement s_adventurer = new UnifiedAchievement("Adventurer", "Adventurer");

		private static readonly UnifiedAchievement s_noCheapShots = new UnifiedAchievement("NoCheapShots", "NoCheapShots");

		public static readonly UnifiedAchievement[] All = new UnifiedAchievement[46]
		{
			s_journeyBegins, s_resourceMagnate, s_definitelyAKiper, s_experienced, s_watchOutForTheTail, s_getBuffed, s_kamehameha, s_threeTimesACharm, s_backpedal, s_attackSpeedOP,
			s_pacifist, s_someBadNews, s_handyman, s_gameLogic, s_masterCraftsman, s_perfectionist, s_professionalLogger, s_bugSquasher, s_mushroomMuncher, s_boneBreaker,
			s_clockworkCremation, s_stayCool, s_nadaraja, s_dissAngelos, s_exterminator, s_hoarder, s_aGoodDeal, s_oneForTheBooks, s_cyanara, s_enchantedToMeetYa,
			s_overTheRainbow, s_permutationPerfectionist, s_scottysNewFriend, s_programmer, s_aFKFarmer, s_midnightFarmer, s_shoppingMadness, s_oneShotOneKill, s_revenge, s_alchemist,
			s_finallyAWizard, s_farewellow, s_speakImportToEnter, s_hansHugs, s_adventurer, s_noCheapShots
		};

		private static readonly Dictionary<string, UnifiedAchievement> s_achievementDictionary = new Dictionary<string, UnifiedAchievement>
		{
			{ "JourneyBegins", s_journeyBegins },
			{ "ResourceMagnate", s_resourceMagnate },
			{ "DefinitelyAKiper", s_definitelyAKiper },
			{ "Experienced", s_experienced },
			{ "WatchOutForTheTail", s_watchOutForTheTail },
			{ "GetBuffed", s_getBuffed },
			{ "Kamehameha", s_kamehameha },
			{ "ThreeTimesACharm", s_threeTimesACharm },
			{ "Backpedal", s_backpedal },
			{ "AttackSpeedOP", s_attackSpeedOP },
			{ "Pacifist", s_pacifist },
			{ "SomeBadNews", s_someBadNews },
			{ "Handyman", s_handyman },
			{ "GameLogic", s_gameLogic },
			{ "MasterCraftsman", s_masterCraftsman },
			{ "Perfectionist", s_perfectionist },
			{ "ProfessionalLogger", s_professionalLogger },
			{ "BugSquasher", s_bugSquasher },
			{ "MushroomMuncher", s_mushroomMuncher },
			{ "BoneBreaker", s_boneBreaker },
			{ "ClockworkCremation", s_clockworkCremation },
			{ "StayCool", s_stayCool },
			{ "Nadaraja", s_nadaraja },
			{ "DissAngelos", s_dissAngelos },
			{ "Exterminator", s_exterminator },
			{ "Hoarder", s_hoarder },
			{ "AGoodDeal", s_aGoodDeal },
			{ "OneForTheBooks", s_oneForTheBooks },
			{ "Cyanara", s_cyanara },
			{ "EnchantedToMeetYa", s_enchantedToMeetYa },
			{ "OverTheRainbow", s_overTheRainbow },
			{ "PermutationPerfectionist", s_permutationPerfectionist },
			{ "ScottysNewFriend", s_scottysNewFriend },
			{ "Programmer", s_programmer },
			{ "AFKFarmer", s_aFKFarmer },
			{ "MidnightFarmer", s_midnightFarmer },
			{ "ShoppingMadness", s_shoppingMadness },
			{ "OneShotOneKill", s_oneShotOneKill },
			{ "Revenge", s_revenge },
			{ "Alchemist", s_alchemist },
			{ "FinallyAWizard", s_finallyAWizard },
			{ "Farewellow", s_farewellow },
			{ "SpeakImportToEnter", s_speakImportToEnter },
			{ "HansHugs", s_hansHugs },
			{ "Adventurer", s_adventurer },
			{ "NoCheapShots", s_noCheapShots }
		};

		public static UnifiedAchievement JourneyBegins => s_journeyBegins;

		public static UnifiedAchievement ResourceMagnate => s_resourceMagnate;

		public static UnifiedAchievement DefinitelyAKiper => s_definitelyAKiper;

		public static UnifiedAchievement Experienced => s_experienced;

		public static UnifiedAchievement WatchOutForTheTail => s_watchOutForTheTail;

		public static UnifiedAchievement GetBuffed => s_getBuffed;

		public static UnifiedAchievement Kamehameha => s_kamehameha;

		public static UnifiedAchievement ThreeTimesACharm => s_threeTimesACharm;

		public static UnifiedAchievement Backpedal => s_backpedal;

		public static UnifiedAchievement AttackSpeedOP => s_attackSpeedOP;

		public static UnifiedAchievement Pacifist => s_pacifist;

		public static UnifiedAchievement SomeBadNews => s_someBadNews;

		public static UnifiedAchievement Handyman => s_handyman;

		public static UnifiedAchievement GameLogic => s_gameLogic;

		public static UnifiedAchievement MasterCraftsman => s_masterCraftsman;

		public static UnifiedAchievement Perfectionist => s_perfectionist;

		public static UnifiedAchievement ProfessionalLogger => s_professionalLogger;

		public static UnifiedAchievement BugSquasher => s_bugSquasher;

		public static UnifiedAchievement MushroomMuncher => s_mushroomMuncher;

		public static UnifiedAchievement BoneBreaker => s_boneBreaker;

		public static UnifiedAchievement ClockworkCremation => s_clockworkCremation;

		public static UnifiedAchievement StayCool => s_stayCool;

		public static UnifiedAchievement Nadaraja => s_nadaraja;

		public static UnifiedAchievement DissAngelos => s_dissAngelos;

		public static UnifiedAchievement Exterminator => s_exterminator;

		public static UnifiedAchievement Hoarder => s_hoarder;

		public static UnifiedAchievement AGoodDeal => s_aGoodDeal;

		public static UnifiedAchievement OneForTheBooks => s_oneForTheBooks;

		public static UnifiedAchievement Cyanara => s_cyanara;

		public static UnifiedAchievement EnchantedToMeetYa => s_enchantedToMeetYa;

		public static UnifiedAchievement OverTheRainbow => s_overTheRainbow;

		public static UnifiedAchievement PermutationPerfectionist => s_permutationPerfectionist;

		public static UnifiedAchievement ScottysNewFriend => s_scottysNewFriend;

		public static UnifiedAchievement Programmer => s_programmer;

		public static UnifiedAchievement AFKFarmer => s_aFKFarmer;

		public static UnifiedAchievement MidnightFarmer => s_midnightFarmer;

		public static UnifiedAchievement ShoppingMadness => s_shoppingMadness;

		public static UnifiedAchievement OneShotOneKill => s_oneShotOneKill;

		public static UnifiedAchievement Revenge => s_revenge;

		public static UnifiedAchievement Alchemist => s_alchemist;

		public static UnifiedAchievement FinallyAWizard => s_finallyAWizard;

		public static UnifiedAchievement Farewellow => s_farewellow;

		public static UnifiedAchievement SpeakImportToEnter => s_speakImportToEnter;

		public static UnifiedAchievement HansHugs => s_hansHugs;

		public static UnifiedAchievement Adventurer => s_adventurer;

		public static UnifiedAchievement NoCheapShots => s_noCheapShots;

		public static string GetPlatformID(string internalId)
		{
			if (!s_achievementDictionary.ContainsKey(internalId))
			{
				return string.Empty;
			}
			return s_achievementDictionary[internalId].ID;
		}
	}
}
