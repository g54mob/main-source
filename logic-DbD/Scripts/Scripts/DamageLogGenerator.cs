using System;
using System.Collections.Generic;
using System.Linq;

public class DamageLogGenerator
{
	public enum Location
	{
		City = 0,
		Grasslands = 1,
		Swamplands = 2,
		Forests = 3
	}

	public enum Enemies
	{
		Skeleton = 0,
		Corrupted = 1,
		Slimehead = 2,
		SlimeFather = 3,
		Peasant = 4
	}

	public enum Weapons
	{
		Sword = 0,
		Dagger = 1,
		Mace = 2,
		Axe = 3
	}

	public enum WeaponEffects
	{
		Burning = 4,
		Poisoned = 2,
		Electrified = 1,
		Rusted = -2,
		None = 0
	}

	public enum WeaponRarity
	{
		Rare = 0,
		Special = 1,
		Uncommon = 2,
		None = 3
	}

	private class Entity
	{
		public int health;

		public int minDamage;

		public int maxDamage;

		protected Entity(int health, int minDamage, int maxDamage)
		{
			this.health = health;
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
		}

		public virtual string WeaponUsed()
		{
			return "";
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
		}

		public int GetDamage()
		{
			return CreateTablesHelpers.RANDY.Next(minDamage, maxDamage + 1);
		}

		public bool IsDead()
		{
			return health <= 0;
		}
	}

	private class PlayerCharacter : Entity
	{
		public Weapons weapon;

		public WeaponEffects effect;

		public WeaponRarity rarity;

		public Character.Class playerClass;

		public string username;

		public PlayerCharacter(string username, Character.Class playerClass, Weapons weapon, WeaponEffects effect, WeaponRarity rarity)
			: base(100, (int)(GetClassDamage(playerClass).Item1 + weaponDamages[weapon].Item1 + effect), (int)(GetClassDamage(playerClass).Item2 + weaponDamages[weapon].Item2 + effect))
		{
			this.playerClass = playerClass;
			this.username = username;
			this.weapon = weapon;
			this.effect = effect;
			this.rarity = rarity;
		}

		public PlayerCharacter(string username, Character.Class playerClass, WeaponRarity rarity)
			: this(username, playerClass, GetRandomWeapon(), GetRandomWeaponEffect(), rarity)
		{
			while (effect == WeaponEffects.Burning && rarity == WeaponRarity.Rare)
			{
				effect = GetRandomWeaponEffect();
			}
		}

		public PlayerCharacter(string username, Character.Class playerClass)
			: this(username, playerClass, GetRandomWeapon(), GetRandomWeaponEffect(), GetRandomWeaponRarity())
		{
			while ((effect == WeaponEffects.Burning && rarity == WeaponRarity.Rare) || (weapon == Weapons.Dagger && effect == WeaponEffects.None && rarity == WeaponRarity.Rare))
			{
				effect = GetRandomWeaponEffect();
				rarity = GetRandomWeaponRarity();
			}
		}

		public override string ToString()
		{
			return username;
		}

		public override string WeaponUsed()
		{
			return GetWeaponString(rarity, effect, weapon);
		}

		public void Heal()
		{
			if (health >= 90)
			{
				health = 100;
			}
			else
			{
				health += 10;
			}
		}

		private static Weapons GetRandomWeapon()
		{
			return CreateTablesHelpers.GetRandomValue(weaponDamages.Keys);
		}

		private static WeaponEffects GetRandomWeaponEffect()
		{
			if (CreateTablesHelpers.RANDY.Next(100) <= 30)
			{
				return CreateTablesHelpers.GetRandomValue(allEffects);
			}
			return WeaponEffects.None;
		}

		private static WeaponRarity GetRandomWeaponRarity()
		{
			int num = CreateTablesHelpers.RANDY.Next(100);
			if (num <= 1)
			{
				return WeaponRarity.Rare;
			}
			if (num <= 5)
			{
				return WeaponRarity.Special;
			}
			if (num <= 15)
			{
				return WeaponRarity.Uncommon;
			}
			return WeaponRarity.None;
		}
	}

	private class SkeletalWarrior : Entity
	{
		private static int id = 10417;

		public SkeletalWarrior()
			: base(75, 18, 22)
		{
			id++;
		}

		public override string ToString()
		{
			return $"Skeletal Warrior #{id}";
		}

		public override string WeaponUsed()
		{
			return "Cursed Sword";
		}

		public int getId()
		{
			return id;
		}
	}

	private class Corrupted : Entity
	{
		private static int id = 8132;

		public Corrupted()
			: base(100, 16, 18)
		{
			id++;
		}

		public override string ToString()
		{
			return $"Corrupted #{id}";
		}

		public override string WeaponUsed()
		{
			return "Cursed Scythe";
		}

		public int getId()
		{
			return id;
		}
	}

	private class Slimehead : Entity
	{
		private static int id = 7436;

		public Slimehead()
			: base(35, 8, 12)
		{
			id++;
		}

		public override string ToString()
		{
			return $"Slimehead #{id}";
		}

		public override string WeaponUsed()
		{
			return "Slime Swipe";
		}

		public int getId()
		{
			return id;
		}
	}

	private class SlimeFather : Entity
	{
		private static int id = 6324;

		public SlimeFather()
			: base(60, 12, 15)
		{
			id++;
		}

		public override string ToString()
		{
			return $"Slime Father #{id}";
		}

		public override string WeaponUsed()
		{
			return "Slime Spit";
		}

		public int getId()
		{
			return id;
		}
	}

	private class Peasant : Entity
	{
		private static int id = 12190;

		public Peasant()
			: base(25, 2, 3)
		{
			id++;
		}

		public override string ToString()
		{
			return $"Lost Peasant #{id}";
		}

		public override string WeaponUsed()
		{
			return "Rusted Pitchfork";
		}

		public int getId()
		{
			return id;
		}
	}

	private class PlayerLocations
	{
		private const int NUMBER_OF_LOCATIONS = 4;

		private HashSet<string>[] locationPopulations;

		private Dictionary<string, Location> playerLocations;

		public PlayerLocations()
		{
			locationPopulations = new HashSet<string>[4];
			for (int i = 0; i < 4; i++)
			{
				locationPopulations[i] = new HashSet<string>();
			}
			playerLocations = new Dictionary<string, Location>();
		}

		public void AddPlayer(string player)
		{
			locationPopulations[0].Add(player);
			playerLocations[player] = Location.City;
		}

		public Location MovePlayer(string player)
		{
			Location location = GetLocation(player);
			Location randomValue = CreateTablesHelpers.GetRandomValue(locationMap[location]);
			locationPopulations[(int)location].Remove(player);
			locationPopulations[(int)randomValue].Add(player);
			playerLocations[player] = randomValue;
			return randomValue;
		}

		public Location GetLocation(string player)
		{
			if (!playerLocations.ContainsKey(player))
			{
				throw new ArgumentException("Cannot find player=" + player + " in locations cache");
			}
			return playerLocations[player];
		}

		public void RemovePlayer(string player)
		{
			Location location = GetLocation(player);
			locationPopulations[(int)location].Remove(player);
			playerLocations.Remove(player);
		}

		public HashSet<string> GetPlayersFromLocation(Location location)
		{
			return new HashSet<string>(locationPopulations[(int)location]);
		}
	}

	private const int MAX_ACTIVITIES = 5;

	private const int START_TIME = 600;

	private const int END_TIME = 2100;

	public static WeaponEffects[] allEffects = new WeaponEffects[4]
	{
		WeaponEffects.Rusted,
		WeaponEffects.Electrified,
		WeaponEffects.Poisoned,
		WeaponEffects.Burning
	};

	private static Dictionary<Character.Class, (int, int)> classDamages = new Dictionary<Character.Class, (int, int)>
	{
		[Character.Class.Bard] = (6, 8),
		[Character.Class.Warrior] = (10, 12),
		[Character.Class.Wizard] = (3, 4),
		[Character.Class.Rogue] = (8, 10)
	};

	private static Dictionary<Weapons, (int, int)> weaponDamages = new Dictionary<Weapons, (int, int)>
	{
		[Weapons.Sword] = (6, 8),
		[Weapons.Dagger] = (2, 4),
		[Weapons.Mace] = (3, 5),
		[Weapons.Axe] = (4, 6)
	};

	private static Dictionary<Location, HashSet<Enemies>> locationEnemies = new Dictionary<Location, HashSet<Enemies>>
	{
		[Location.Grasslands] = new HashSet<Enemies> { Enemies.Peasant },
		[Location.Swamplands] = new HashSet<Enemies>
		{
			Enemies.Slimehead,
			Enemies.SlimeFather
		},
		[Location.Forests] = new HashSet<Enemies>
		{
			Enemies.Corrupted,
			Enemies.Skeleton
		}
	};

	private static Dictionary<Location, HashSet<Location>> locationMap = new Dictionary<Location, HashSet<Location>>
	{
		[Location.City] = new HashSet<Location>
		{
			Location.Grasslands,
			Location.Swamplands
		},
		[Location.Grasslands] = new HashSet<Location>
		{
			Location.City,
			Location.Forests
		},
		[Location.Swamplands] = new HashSet<Location> { Location.City },
		[Location.Forests] = new HashSet<Location> { Location.Grasslands }
	};

	public static string GetWeaponString(WeaponRarity rarity, WeaponEffects effects, Weapons weapon)
	{
		string text = "";
		if (rarity != WeaponRarity.None)
		{
			text += $"{rarity} ";
		}
		if (effects != WeaponEffects.None)
		{
			text += $"{effects} ";
		}
		return text + $"{weapon}";
	}

	public static List<DamageLog> Generate(Dictionary<string, Character> characters, Dictionary<string, HashSet<string>> membersToGuilds)
	{
		List<DamageLog> list = new List<DamageLog>();
		HashSet<string> hashSet = new HashSet<string>
		{
			"xCalibur32", "sefrgswrg", "goldtooth", "grinch", "moneyman", "jmeister", "peasant100", "BUDDY", "avacados", "SMARTY",
			"bobert"
		};
		PlayerLocations playerLocations = new PlayerLocations();
		Dictionary<string, PlayerCharacter> dictionary = new Dictionary<string, PlayerCharacter>();
		Dictionary<int, HashSet<string>> dictionary2 = new Dictionary<int, HashSet<string>>();
		Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
		foreach (string key in characters.Keys)
		{
			if (!hashSet.Contains(key) && (!membersToGuilds.ContainsKey(key) || (!membersToGuilds[key].Contains("PL") && !membersToGuilds[key].Contains("BO") && !membersToGuilds[key].Contains("RARE") && (!membersToGuilds[key].Contains("$") || characters[key].type != Character.Class.Bard) && !CreateTablesHelpers.IsPercentChance(60))))
			{
				dictionary[key] = new PlayerCharacter(key, characters[key].type);
				playerLocations.AddPlayer(key);
				dictionary3[key] = CreateTablesHelpers.RANDY.Next(3, 5);
				int startTime = GetStartTime();
				AddActivityTime(dictionary2, startTime, key);
			}
		}
		for (int i = 600; i < 2100; i++)
		{
			AddSpecificLogs(list, i);
			if (!dictionary2.ContainsKey(i))
			{
				continue;
			}
			foreach (string item in dictionary2[i])
			{
				PlayerCharacter playerCharacter = dictionary[item];
				if (!playerCharacter.IsDead())
				{
					Location location = playerLocations.GetLocation(item);
					switch (location)
					{
					case Location.City:
						MoveToLocation(playerLocations, list, i, playerCharacter);
						break;
					case Location.Forests:
						DoPlayerActivity(location, 80, playerLocations, list, i, playerCharacter, dictionary, membersToGuilds);
						break;
					case Location.Swamplands:
						DoPlayerActivity(location, 75, playerLocations, list, i, playerCharacter, dictionary, membersToGuilds);
						break;
					case Location.Grasslands:
						DoPlayerActivity(location, 20, playerLocations, list, i, playerCharacter, dictionary, membersToGuilds);
						break;
					}
					dictionary3[item]--;
					if (dictionary3[item] > 0 && !playerCharacter.IsDead())
					{
						int time = CreateTablesHelpers.AddTime(i, CreateTablesHelpers.RANDY.Next(5, 25));
						AddActivityTime(dictionary2, time, item);
					}
				}
			}
		}
		return list;
	}

	private static void AddActivityTime(Dictionary<int, HashSet<string>> activityTimes, int time, string player)
	{
		if (!activityTimes.ContainsKey(time))
		{
			activityTimes[time] = new HashSet<string>();
		}
		activityTimes[time].Add(player);
	}

	private static void DoPlayerActivity(Location currentLocation, short percentCombatChance, PlayerLocations locations, List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter, Dictionary<string, PlayerCharacter> playerObjectsMap, Dictionary<string, HashSet<string>> membersToGuilds)
	{
		if (CreateTablesHelpers.IsPercentChance(percentCombatChance))
		{
			GenerateCombatWithPlayers(damageLog, time, currentCharacter, currentLocation, locations, playerObjectsMap, membersToGuilds);
		}
		else
		{
			MoveToLocation(locations, damageLog, time, currentCharacter);
		}
		if (!currentCharacter.IsDead() && currentCharacter.health < 90 && CreateTablesHelpers.IsPercentChance(20))
		{
			currentCharacter.Heal();
		}
	}

	private static void MoveToLocation(PlayerLocations locations, List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter)
	{
		Location currentLocation = locations.MovePlayer(currentCharacter.username);
		GenerateCombat(damageLog, time, currentCharacter, currentLocation, locations);
	}

	private static void GenerateCombat(List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter, Location currentLocation, PlayerLocations locations)
	{
		if (currentLocation != Location.City)
		{
			Enemies randomValue = CreateTablesHelpers.GetRandomValue(locationEnemies[currentLocation]);
			GenerateCombat(damageLog, time, currentCharacter, randomValue, locations);
		}
	}

	private static void GenerateCombatWithPlayers(List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter, Location currentLocation, PlayerLocations locations, Dictionary<string, PlayerCharacter> playerObjectsMap, Dictionary<string, HashSet<string>> membersToGuilds)
	{
		if (currentLocation == Location.City)
		{
			return;
		}
		if (CreateTablesHelpers.IsPercentChance(50))
		{
			HashSet<string> playersFromLocation = locations.GetPlayersFromLocation(currentLocation);
			playersFromLocation.Remove(currentCharacter.username);
			if (playersFromLocation.Count > 0)
			{
				string randomValue = CreateTablesHelpers.GetRandomValue(playersFromLocation);
				if (!InSameGuild(currentCharacter.username, randomValue))
				{
					PlayerCharacter character = playerObjectsMap[randomValue];
					GenerateCombat(damageLog, time, currentCharacter, character, locations);
				}
			}
		}
		else
		{
			Enemies randomValue2 = CreateTablesHelpers.GetRandomValue(locationEnemies[currentLocation]);
			GenerateCombat(damageLog, time, currentCharacter, randomValue2, locations);
		}
		bool InSameGuild(string char1, string char2)
		{
			if (!membersToGuilds.ContainsKey(char1) || !membersToGuilds.ContainsKey(char2))
			{
				return false;
			}
			return membersToGuilds[char1].Intersect(membersToGuilds[char2]).Count() >= 1;
		}
	}

	private static void GenerateCombat(List<DamageLog> damageLog, int time, PlayerCharacter character1, PlayerCharacter character2, PlayerLocations locations)
	{
		bool doubleDamage = character1.playerClass == Character.Class.Rogue;
		while (!character1.IsDead() && !character2.IsDead())
		{
			AddDamageLog(damageLog, time, character1, character2, doubleDamage);
			if (!character2.IsDead())
			{
				AddDamageLog(damageLog, time, character2, character1);
			}
			doubleDamage = false;
			if (character2.IsDead())
			{
				locations.RemovePlayer(character2.username);
			}
			else if (character1.IsDead())
			{
				locations.RemovePlayer(character1.username);
			}
		}
	}

	private static void GenerateCombat(List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter, Enemies enemy, PlayerLocations locations)
	{
		GenerateCombat(damageLog, time, currentCharacter, enemy);
		if (currentCharacter.IsDead())
		{
			locations.RemovePlayer(currentCharacter.username);
		}
	}

	private static void GenerateCombat(List<DamageLog> damageLog, int time, PlayerCharacter currentCharacter, Enemies enemy)
	{
		Entity enemyObject = GetEnemyObject(enemy);
		bool doubleDamage = currentCharacter.playerClass == Character.Class.Rogue;
		while (!enemyObject.IsDead() && !currentCharacter.IsDead())
		{
			AddDamageLog(damageLog, time, currentCharacter, enemyObject, doubleDamage);
			if (!enemyObject.IsDead())
			{
				AddDamageLog(damageLog, time, enemyObject, currentCharacter);
			}
			doubleDamage = false;
		}
	}

	private static void AddDamageLog(List<DamageLog> damageLog, int time, Entity damageDealer, Entity damageTaker, bool doubleDamage = false)
	{
		int num = damageDealer.GetDamage();
		if (doubleDamage)
		{
			num *= 2;
		}
		DamageLog item = new DamageLog(time, damageTaker.ToString(), num, damageDealer.WeaponUsed());
		damageLog.Add(item);
		damageTaker.TakeDamage(num);
	}

	private static Entity GetEnemyObject(Enemies enemy)
	{
		return enemy switch
		{
			Enemies.Skeleton => new SkeletalWarrior(), 
			Enemies.Corrupted => new Corrupted(), 
			Enemies.Slimehead => new Slimehead(), 
			Enemies.SlimeFather => new SlimeFather(), 
			Enemies.Peasant => new Peasant(), 
			_ => throw new NotImplementedException(), 
		};
	}

	private static (int, int) GetClassDamage(Character.Class characterClass)
	{
		return characterClass switch
		{
			Character.Class.Warrior => (10, 12), 
			Character.Class.Rogue => (8, 10), 
			Character.Class.Wizard => (3, 4), 
			Character.Class.Bard => (6, 8), 
			_ => throw new NotImplementedException(), 
		};
	}

	private static void AddSpecificLogs(List<DamageLog> damageLog, int time)
	{
		if (time == 1331 || time == 1344 || time == 1348 || time == 1351)
		{
			PlayerCharacter playerCharacter = new PlayerCharacter("xCalibur32", Character.Class.Warrior, Weapons.Sword, WeaponEffects.Burning, WeaponRarity.Rare);
			switch (time)
			{
			case 1331:
			{
				Peasant peasant = new Peasant();
				damageLog.Add(new DamageLog(time, peasant.ToString(), 23, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 2, peasant.WeaponUsed()));
				damageLog.Add(new DamageLog(time, peasant.ToString(), 24, playerCharacter.WeaponUsed()));
				break;
			}
			case 1344:
			{
				Corrupted corrupted = new Corrupted();
				damageLog.Add(new DamageLog(time, corrupted.ToString(), 23, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 18, corrupted.WeaponUsed()));
				damageLog.Add(new DamageLog(time, corrupted.ToString(), 21, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 17, corrupted.WeaponUsed()));
				damageLog.Add(new DamageLog(time, corrupted.ToString(), 22, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 18, corrupted.WeaponUsed()));
				damageLog.Add(new DamageLog(time, corrupted.ToString(), 20, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 16, corrupted.WeaponUsed()));
				damageLog.Add(new DamageLog(time, corrupted.ToString(), 24, playerCharacter.WeaponUsed()));
				break;
			}
			case 1348:
			{
				SkeletalWarrior skeletalWarrior = new SkeletalWarrior();
				damageLog.Add(new DamageLog(time, skeletalWarrior.ToString(), 24, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 22, skeletalWarrior.WeaponUsed()));
				damageLog.Add(new DamageLog(time, skeletalWarrior.ToString(), 22, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 20, skeletalWarrior.WeaponUsed()));
				damageLog.Add(new DamageLog(time, skeletalWarrior.ToString(), 21, playerCharacter.WeaponUsed()));
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 21, skeletalWarrior.WeaponUsed()));
				damageLog.Add(new DamageLog(time, skeletalWarrior.ToString(), 20, playerCharacter.WeaponUsed()));
				break;
			}
			case 1351:
				damageLog.Add(new DamageLog(time, playerCharacter.ToString(), 9, GetWeaponString(WeaponRarity.Rare, WeaponEffects.Rusted, Weapons.Dagger)));
				break;
			}
		}
		if (time == 1330 || time == 1812 || time == 1813 || time == 1814)
		{
			if (time == 1330)
			{
				PlayerCharacter currentCharacter = new PlayerCharacter("goldtooth", Character.Class.Warrior, Weapons.Axe, WeaponEffects.Poisoned, WeaponRarity.Rare);
				Enemies randomValue = CreateTablesHelpers.GetRandomValue(locationEnemies[Location.Swamplands]);
				GenerateCombat(damageLog, time, currentCharacter, randomValue);
			}
			else if (time <= 1814)
			{
				PlayerCharacter currentCharacter2 = new PlayerCharacter("goldtooth", Character.Class.Warrior, Weapons.Sword, WeaponEffects.Burning, WeaponRarity.Rare);
				GenerateCombat(damageLog, time, currentCharacter2, Enemies.Peasant);
			}
		}
		if (time == 1145 || time == 1150 || time == 1417)
		{
			PlayerCharacter currentCharacter3 = new PlayerCharacter("jmeister", Character.Class.Bard, Weapons.Sword, WeaponEffects.Electrified, WeaponRarity.None);
			switch (time)
			{
			case 1145:
				GenerateCombat(damageLog, time, currentCharacter3, Enemies.Peasant);
				break;
			case 1150:
				GenerateCombat(damageLog, time, currentCharacter3, Enemies.Skeleton);
				break;
			case 1417:
				GenerateCombat(damageLog, time, currentCharacter3, Enemies.Peasant);
				break;
			}
		}
		if (time == 1003 || time == 1012 || time == 1232)
		{
			PlayerCharacter currentCharacter4 = new PlayerCharacter("BUDDY", Character.Class.Bard, Weapons.Sword, WeaponEffects.Poisoned, WeaponRarity.Special);
			switch (time)
			{
			case 1003:
				GenerateCombat(damageLog, time, currentCharacter4, Enemies.Peasant);
				break;
			case 1012:
				GenerateCombat(damageLog, time, currentCharacter4, Enemies.Skeleton);
				break;
			case 1232:
				GenerateCombat(damageLog, time, currentCharacter4, Enemies.Peasant);
				break;
			}
		}
		if (time == 1247 || time == 1249 || time == 1243 || time == 1246 || time == 1420 || time == 1422)
		{
			if (time == 1243 || time == 1246)
			{
				PlayerCharacter currentCharacter5 = new PlayerCharacter("grinch", Character.Class.Warrior, Weapons.Sword, WeaponEffects.None, WeaponRarity.Rare);
				switch (time)
				{
				case 1243:
					GenerateCombat(damageLog, time, currentCharacter5, Enemies.Peasant);
					break;
				case 1246:
					GenerateCombat(damageLog, time, currentCharacter5, Enemies.Corrupted);
					break;
				case 1420:
					GenerateCombat(damageLog, time, currentCharacter5, Enemies.Peasant);
					break;
				}
			}
			if (time == 1247 || time == 1249)
			{
				PlayerCharacter currentCharacter6 = new PlayerCharacter("moneyman", Character.Class.Warrior, Weapons.Mace, WeaponEffects.Burning, WeaponRarity.Rare);
				switch (time)
				{
				case 1247:
					GenerateCombat(damageLog, time, currentCharacter6, Enemies.Peasant);
					break;
				case 1249:
					GenerateCombat(damageLog, time, currentCharacter6, Enemies.Skeleton);
					break;
				case 1422:
					GenerateCombat(damageLog, time, currentCharacter6, Enemies.Peasant);
					break;
				}
			}
		}
		if (time == 1328 || time == 1329 || time == 1342 || time == 1343)
		{
			if (time == 1328 || time == 1343)
			{
				PlayerCharacter currentCharacter7 = new PlayerCharacter("peasant100", Character.Class.Bard, Weapons.Axe, WeaponEffects.None, WeaponRarity.None);
				switch (time)
				{
				case 1328:
					GenerateCombat(damageLog, time, currentCharacter7, Enemies.Peasant);
					break;
				case 1343:
					GenerateCombat(damageLog, time, currentCharacter7, Enemies.Skeleton);
					break;
				}
			}
			if (time == 1329 || time == 1342)
			{
				PlayerCharacter currentCharacter8 = new PlayerCharacter("SMARTY", Character.Class.Wizard, Weapons.Sword, WeaponEffects.None, WeaponRarity.None);
				switch (time)
				{
				case 1329:
					GenerateCombat(damageLog, time, currentCharacter8, Enemies.Peasant);
					break;
				case 1342:
					GenerateCombat(damageLog, time, currentCharacter8, Enemies.Skeleton);
					break;
				}
			}
		}
		if (time == 1210 || time == 1214)
		{
			PlayerCharacter currentCharacter9 = new PlayerCharacter("biggun", Character.Class.Bard, Weapons.Sword, WeaponEffects.None, WeaponRarity.None);
			GenerateCombat(damageLog, time, currentCharacter9, Enemies.Peasant);
		}
		if (time == 1427 || time == 1434)
		{
			PlayerCharacter currentCharacter10 = new PlayerCharacter("babyBoo", Character.Class.Bard, Weapons.Axe, WeaponEffects.Burning, WeaponRarity.None);
			switch (time)
			{
			case 1427:
				GenerateCombat(damageLog, time, currentCharacter10, Enemies.Peasant);
				break;
			case 1434:
				GenerateCombat(damageLog, time, currentCharacter10, Enemies.Skeleton);
				break;
			}
		}
		if (time == 1310 || time == 1323)
		{
			PlayerCharacter currentCharacter11 = new PlayerCharacter("pastabro", Character.Class.Bard, Weapons.Dagger, WeaponEffects.Burning, WeaponRarity.None);
			switch (time)
			{
			case 1310:
				GenerateCombat(damageLog, time, currentCharacter11, Enemies.Peasant);
				break;
			case 1323:
				GenerateCombat(damageLog, time, currentCharacter11, CreateTablesHelpers.GetRandomValue(locationEnemies[Location.Swamplands]));
				break;
			}
		}
		if (time == 1353)
		{
			PlayerCharacter currentCharacter12 = new PlayerCharacter("Blabby", Character.Class.Bard, Weapons.Axe, WeaponEffects.None, WeaponRarity.None);
			GenerateCombat(damageLog, time, currentCharacter12, Enemies.Peasant);
		}
	}

	private static int GetStartTime()
	{
		int num = CreateTablesHelpers.RANDY.Next(100);
		if (num <= 50)
		{
			return CreateTablesHelpers.GetRandomTime(14, 20);
		}
		if (num <= 85)
		{
			return CreateTablesHelpers.GetRandomTime(10, 14);
		}
		return CreateTablesHelpers.GetRandomTime(6, 10);
	}
}
