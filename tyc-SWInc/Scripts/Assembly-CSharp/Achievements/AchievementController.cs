using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using StatementParser;
using Steamworks;
using UnityEngine;

namespace Achievements
{
	public static class AchievementController
	{
		public class Achievement
		{
			public readonly string ID;

			public readonly string Name;

			public readonly string Description;

			public readonly int Order;

			public readonly bool OnlyInGame;

			public readonly bool Hidden;

			public readonly Func<bool> Check;

			public readonly Texture2D Unachieved;

			public readonly Texture2D Achieved;

			public Achievement(int order, string id, string name, string description, bool hidden, Func<bool> check, bool onlyInGame, string overrideIcon = null)
			{
				Order = order;
				ID = id;
				Name = name;
				Description = description;
				Hidden = hidden;
				Check = check;
				Unachieved = Resources.Load<Texture2D>("Achievements/" + (overrideIcon ?? id) + "_unachieved");
				Achieved = Resources.Load<Texture2D>("Achievements/" + (overrideIcon ?? id) + "_achieved");
				OnlyInGame = onlyInGame;
			}

			public bool CanCheck()
			{
				if (Check != null)
				{
					if (OnlyInGame)
					{
						return !GameSettings.Instance.IsReferenceNull();
					}
					return true;
				}
				return false;
			}
		}

		[Flags]
		public enum Mechanics
		{
			Development = 1,
			Contracts = 2,
			Deals = 4,
			Printing = 8,
			Manufacturing = 0x10,
			LeadDesigner = 0x20,
			Subsidiaries = 0x40,
			Construction = 0x80,
			Paths = 0x100,
			Roofs = 0x200,
			Roads = 0x400,
			Servers = 0x800,
			Benefits = 0x1000,
			HR = 0x2000,
			Plots = 0x4000,
			ElectricityProduced = 0x8000,
			Stocks = 0x10000,
			Bonds = 0x20000,
			OffshoreAccount = 0x40000,
			Projectmanagement = 0x80000,
			Research = 0x100000,
			Rewards = 0x200000,
			Canteen = 0x400000,
			Temperatureregulation = 0x800000,
			BikeRack = 0x1000000,
			HardwareDesigner = 0x2000000,
			CustomLogos = 0x4000000,
			All = 0x7FFFFFF
		}

		private static Callback<UserStatsReceived_t> _statsReceived;

		private static int _lastChecked;

		private static Texture2D _hiddenIcon;

		private static Mechanics _interaction;

		private static object _interactionLock = new object();

		private static readonly Achievement[] _achievements = new Achievement[15]
		{
			new Achievement(13, "FULLMETA", "Let's go deeper", "Make the game in the game with the company and the developer", true, null, true),
			new Achievement(7, "FIREPERISH", "This is fine", "Have somebody perish in a fire", false, null, true),
			new Achievement(8, "MORETIME", "Need more time", "Play for 10 years with 8 days per month", false, TimeCheck, true),
			new Achievement(4, "LIFETIME", "A lifetime", "Play for 80 years", false, LifeTimeCheck, true),
			new Achievement(5, "FPSEASON", "Frames per season", "Have over 500 employees", false, FPSCheck, true),
			new Achievement(9, "EMPLOYEESUIT", "Bad company", "Have 10 employees sue you in a class action", false, null, true),
			new Achievement(10, "SPIFFBREAK", "That's pretty spiffing", "Cancel a project after receiving publisher funding and successfully win the lawsuit", false, null, true),
			new Achievement(6, "POLICEDRONE", "Oh yeah!", "Have a police drone break through walls to confiscate precious metals", false, null, true),
			new Achievement(12, "BUYPLAYER", "PvPayout", "Buy out another player's company", false, null, true),
			new Achievement(11, "PROPERCOOP", "Co-optimized", "Release a product with approximately equal revenue share with other players", false, null, true),
			new Achievement(0, "DEDICATION", "Number goes up", "Release 10 sequels for the same IP", false, null, true),
			new Achievement(3, "BUYOUTSTREAK", "Yoink!", "Take over 5 companies in one year", false, null, true),
			new Achievement(14, "COPYGOLD", "CTRL-C CTRL-$", "Try to duplicate precious metals in build mode", true, null, true),
			new Achievement(1, "PLATINUM", "The GOAT", "Win a platinum award by winning 5 years in a row", false, null, true),
			new Achievement(2, "FEATURECREEP", "Feature creep", "Interact with all features of the game {FeaturesLeft}", false, null, true)
		};

		private static readonly HashSet<string> _achieved = new HashSet<string>();

		private static bool _initialized = false;

		public static int GetFeaturesLeft()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 32; i++)
			{
				int num3 = 1 << i;
				if ((0x7FFFFFF & num3) != 0)
				{
					num++;
					if (((uint)_interaction & (uint)num3) != 0)
					{
						num2++;
					}
				}
			}
			return num - num2;
		}

		public static IEnumerable<Mechanics> GetAllFeaturesLeft()
		{
			for (int i = 0; i < 32; i++)
			{
				int num = 1 << i;
				if ((0x7FFFFFF & num) != 0 && ((uint)_interaction & (uint)num) == 0)
				{
					yield return (Mechanics)num;
				}
			}
		}

		private static bool TimeCheck()
		{
			if (GameSettings.DaysPerMonth >= 8)
			{
				return SDateTime.GetYears(GameSettings.Instance.MyCompany.Founded, SDateTime.Now()) >= 10f;
			}
			return false;
		}

		private static bool LifeTimeCheck()
		{
			return SDateTime.GetYears(GameSettings.Instance.MyCompany.Founded, SDateTime.Now()) >= 80f;
		}

		private static bool FPSCheck()
		{
			return GameSettings.Instance.sActorManager.Actors.Count >= 500;
		}

		[return: TupleElementNames(new string[] { "name", "desc" })]
		public static ValueTuple<string, string> GetAchievementLoc(Achievement ac)
		{
			string[] array = (ac.ID + "Achievement").LocAll();
			string item = ((array != null && array.Length != 0) ? array[0] : ac.Name);
			string s = ((array != null && array.Length > 1) ? array[1] : ac.Description);
			return new ValueTuple<string, string>(item, Utilities.RobustStringFormat(s, false, false));
		}

		[return: TupleElementNames(new string[] { "name", "desc", "icon", "achieved" })]
		public static IEnumerable<ValueTuple<string, string, Texture2D, bool>> GetAchievements()
		{
			foreach (Achievement item3 in from x in _achievements
				orderby x.Hidden ? 1 : 0, x.Order
				select x)
			{
				bool flag = _achieved.Contains(item3.ID);
				if (item3.Hidden && !flag)
				{
					yield return new ValueTuple<string, string, Texture2D, bool>("?", "", _hiddenIcon, false);
					continue;
				}
				ValueTuple<string, string> achievementLoc = GetAchievementLoc(item3);
				string item = achievementLoc.Item1;
				string item2 = achievementLoc.Item2;
				yield return new ValueTuple<string, string, Texture2D, bool>(item, item2, flag ? item3.Achieved : item3.Unachieved, flag);
			}
		}

		public static IEnumerable<ValueTuple<string, string, string>> GetAchievementLoc()
		{
			Achievement[] achievements = _achievements;
			foreach (Achievement achievement in achievements)
			{
				yield return new ValueTuple<string, string, string>(achievement.ID + "Achievement", achievement.Name, achievement.Description);
			}
		}

		public static void Init()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			_hiddenIcon = Resources.Load<Texture2D>("Achievements/HiddenAchievement");
			string path = Path.Combine(Utilities.GetRoot(), "ac.bin");
			if (File.Exists(path))
			{
				try
				{
					byte[] array = File.ReadAllBytes(path);
					_interaction = (Mechanics)BitConverter.ToInt32(array, 1);
					int num = 0;
					foreach (bool item in Utilities.ReadBits(array, 5))
					{
						if (item)
						{
							_achieved.Add(_achievements[num].ID);
						}
						num++;
						if (num == _achievements.Length)
						{
							break;
						}
					}
				}
				catch (Exception ex)
				{
					Debug.Log("Failed to load achievements:\n" + ex.ToString());
				}
			}
			if (SteamManager.Initialized)
			{
				_statsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
				SteamUserStats.RequestCurrentStats();
			}
		}

		public static void CheckAchievements()
		{
			if (_achieved.Count == _achievements.Length || (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.AchievementsDisabled))
			{
				return;
			}
			for (int i = 0; i < _achievements.Length; i++)
			{
				int num = (_lastChecked + i) % _achievements.Length;
				Achievement achievement = _achievements[num];
				if (!_achieved.Contains(achievement.ID) && achievement.CanCheck())
				{
					if (achievement.Check())
					{
						SetAchievement(achievement);
					}
					_lastChecked = num + 1;
					break;
				}
			}
		}

		public static void SetInteraction(Mechanics m)
		{
			if (LineParse.RunningScript)
			{
				return;
			}
			lock (_interactionLock)
			{
				if ((m & _interaction) == m)
				{
					return;
				}
				Assembly callingAssembly = Assembly.GetCallingAssembly();
				if (callingAssembly.FullName.StartsWith("Assembly-CSharp,") || callingAssembly.FullName.StartsWith("Assembly-CSharp-firstpass,"))
				{
					_interaction |= m;
					if (_interaction == Mechanics.All)
					{
						SetAchievement("FEATURECREEP");
					}
					WriteAchievements();
				}
			}
		}

		private static void SetAchievement(Achievement ac)
		{
			if ((GameSettings.Instance.IsReferenceNull() || !GameSettings.Instance.AchievementsDisabled) && _achieved.Add(ac.ID))
			{
				if (SteamManager.Initialized)
				{
					SteamUserStats.SetAchievement(ac.ID);
					SteamUserStats.StoreStats();
				}
				else
				{
					WindowManager.Instance.AchievementAchieved(ac);
				}
				WriteAchievements();
			}
		}

		public static bool HasAchievement(string id)
		{
			return _achieved.Contains(id);
		}

		public static void SetAchievement(string id)
		{
			if (LineParse.RunningScript || _achieved.Contains(id))
			{
				return;
			}
			Achievement achievement = _achievements.FirstOrDefault((Achievement x) => x.ID.Equals(id));
			if (achievement != null)
			{
				Assembly callingAssembly = Assembly.GetCallingAssembly();
				if (!callingAssembly.FullName.StartsWith("Assembly-CSharp,") && !callingAssembly.FullName.StartsWith("Assembly-CSharp-firstpass,"))
				{
					Debug.Log("Tried to set achievement from " + callingAssembly.FullName);
				}
				else
				{
					SetAchievement(achievement);
				}
			}
		}

		private static void WriteAchievements()
		{
			try
			{
				using (FileStream fileStream = File.OpenWrite(Path.Combine(Utilities.GetRoot(), "ac.bin")))
				{
					fileStream.WriteByte(0);
					fileStream.Write(BitConverter.GetBytes((int)_interaction), 0, 4);
					Utilities.WriteBits(_achievements, (Achievement x) => _achieved.Contains(x.ID), fileStream);
					fileStream.Flush();
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Failed to save achievements:\n" + ex.ToString());
			}
		}

		private static void OnUserStatsReceived(UserStatsReceived_t param)
		{
			if (param.m_eResult != EResult.k_EResultOK)
			{
				return;
			}
			_achieved.Clear();
			Achievement[] achievements = _achievements;
			foreach (Achievement achievement in achievements)
			{
				bool pbAchieved;
				if (SteamUserStats.GetAchievement(achievement.ID, out pbAchieved) && pbAchieved)
				{
					_achieved.Add(achievement.ID);
				}
			}
		}
	}
}
