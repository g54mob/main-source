using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Steam.LeaderboardsNew;
using Assets.Scripts.Tools;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;

namespace Assets.Scripts.Steam;

public class Leaderboards
{
	public static int numMaxDeatils = 64;

	public unsafe static void UploadScore(int score)
	{
		//IL_00f4: Expected I, but got O
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0429: Expected I4, but got O
		//IL_0450: Expected I4, but got O
		//IL_0477: Expected I4, but got O
		//IL_04fe: Expected I4, but got O
		//IL_08b6: Expected O, but got Ref
		//IL_08ed: Expected I4, but got O
		//IL_08f6: Expected O, but got Ref
		//IL_0928: Expected I4, but got O
		//IL_0d96: Expected O, but got I4
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db1: Expected I4, but got Unknown
		//IL_0df7: Expected O, but got I4
		//IL_0e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3a: Expected O, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			if (cfGameSettings.upload_score_to_leaderboard == 0)
			{
				return;
			}
		}
		RunConfig runConfig = MapController.runConfig;
		if (!(runConfig.challenge == null))
		{
			return;
		}
		int[] array = new int[numMaxDeatils];
		nint num = (nint)typeof(MapController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v52 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
		nint num2 = 0;
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		array[0] = (int)mapData.eMap;
		MyPlayer instance = MyPlayer.Instance;
		array[1] = (int)instance.character;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax+20h]\"");
		array[2] = (int)num2;
		int stat = RunStats.GetStat(EMyStat.goldEarned);
		array[3] = stat;
		int stat2 = RunStats.GetStat(EMyStat.goldSpent);
		array[4] = stat2;
		int stat3 = RunStats.GetStat(EMyStat.chestsOpened);
		array[5] = stat3;
		int stat4 = RunStats.GetStat(EMyStat.itemsPickedUp);
		array[6] = stat4;
		MyPlayer instance2 = MyPlayer.Instance;
		int characterLevel = instance2.inventory.GetCharacterLevel();
		array[7] = characterLevel;
		int stat5 = RunStats.GetStat(EMyStat.xpGained);
		array[8] = stat5;
		array[9] = Enemy.deaths;
		int stat6 = RunStats.GetStat(EMyStat.kills);
		array[10] = stat6;
		int stat7 = RunStats.GetStat(EMyStat.eliteKills);
		array[11] = stat7;
		int[] array2 = GenerateScoreHashNew(score, SteamManager.steamId);
		string text = null;
		string text2 = null;
		while ((nint)text2 < array2.Length)
		{
			_ = array2[(object)text];
			text++;
			text2 = text;
		}
		int[] weapons = GetWeapons();
		array[20] = weapons[0];
		array[21] = weapons[1];
		array[22] = weapons[2];
		int[] tomes = GetTomes();
		array[23] = tomes[0];
		array[24] = tomes[1];
		array[25] = tomes[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax+10h]\"");
		array[26] = tomes[0];
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rcx+14h]\"");
		array[27] = (int)typeof(Potato);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rcx+18h]\"");
		array[28] = (int)typeof(Potato);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rcx+1Ch]\"");
		array[29] = (int)typeof(Potato);
		array[30] = Potato.killsMinute1;
		array[31] = Potato.killsMinute2;
		array[32] = Potato.killsMinute5;
		array[33] = Potato.killsMinute10;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rcx+0Ch]\"");
		array[34] = (int)typeof(Potato);
		array[35] = Potato.enemyCollisionCalls;
		array[36] = Potato.playerDamageCalls;
		array[37] = Potato.damageBlocksCount;
		array[38] = Potato.damageTakenCount;
		array[39] = Potato.totalDamageTaken;
		array[40] = (int)Potato.flags;
		float stat8 = PlayerStats.GetStat(EStat.Difficulty);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[41] = (int)Potato.flags;
		float stat9 = PlayerStats.GetStat(EStat.Luck);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[42] = (int)Potato.flags;
		float stat10 = PlayerStats.GetStat(EStat.Armor);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[43] = (int)Potato.flags;
		float stat11 = PlayerStats.GetStat(EStat.MoveSpeedMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[44] = (int)Potato.flags;
		float stat12 = PlayerStats.GetStat(EStat.MaxHealth);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[45] = (int)Potato.flags;
		float stat13 = PlayerStats.GetStat(EStat.DamageMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[46] = (int)Potato.flags;
		float stat14 = PlayerStats.GetStat(EStat.AttackSpeed);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[47] = (int)Potato.flags;
		float stat15 = PlayerStats.GetStat(EStat.CritChance);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[48] = (int)Potato.flags;
		float stat16 = PlayerStats.GetStat(EStat.CritDamage);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[49] = (int)Potato.flags;
		float stat17 = PlayerStats.GetStat(EStat.SizeMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[50] = (int)Potato.flags;
		float stat18 = PlayerStats.GetStat(EStat.XpIncreaseMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[51] = (int)Potato.flags;
		float stat19 = PlayerStats.GetStat(EStat.PickupRange);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[52] = (int)Potato.flags;
		float stat20 = PlayerStats.GetStat(EStat.Projectiles);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[53] = (int)Potato.flags;
		float stat21 = PlayerStats.GetStat(EStat.Lifesteal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[54] = (int)Potato.flags;
		float stat22 = PlayerStats.GetStat(EStat.GoldIncreaseMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[55] = (int)Potato.flags;
		int stat23 = RunStats.GetStat(EMyStat.potsBroken);
		array[56] = stat23;
		int stat24 = RunStats.GetStat(EMyStat.shrineCharge);
		array[57] = stat24;
		IntPtr intPtr = default(IntPtr);
		string text3 = ((Enum)(&intPtr)).ToString();
		float stat25 = MyStats.GetStat(text3);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[58] = (int)text3;
		IntPtr intPtr2 = default(IntPtr);
		string text4 = ((Enum)(&intPtr2)).ToString();
		float stat26 = MyStats.GetStat(text4);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		array[59] = (int)text4;
		SteamLeaderboardNew leaderboardKillsWeekly = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;
		SteamLeaderboardNew leaderboardKillsAllTime = SteamLeaderboardsManagerNew.leaderboardKillsAllTime;
		SteamLeaderboardNew leaderboardKillsWeekly2 = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;
		bool flag = CanShowScore(SteamManager.steamId, score, array, out var _);
		object obj = score - 350000;
		int num3 = score ^ 0x55730;
		int num4 = score ^ obj;
		int num5 = num3 & num4;
		bool flag2 = num5 < 0;
		bool flag3 = (nint)obj < 0;
		bool flag4 = flag3 == flag2;
		object obj2 = flag & flag4;
		bool flag6 = default(bool);
		if (obj2 != null)
		{
			bool flag5 = Sus.CheckMods(out var _);
			string text5 = flag6.ToString();
			string text6 = "Has sus assemblies: " + text5;
			AppDomain curDomain = AppDomain.getCurDomain();
			string baseDirectory = curDomain.BaseDirectory;
			bool flag7 = baseDirectory != null;
			string path = baseDirectory;
			if (!flag7)
			{
				string dataPath = Application.dataPath;
				path = dataPath;
			}
			string[] array3 = new string[10];
			string text7 = Path.Combine(path, "MelonLoader");
			array3[0] = text7;
			string text8 = Path.Combine(path, "patchers");
			array3[1] = text8;
			string text9 = Path.Combine(path, "BepInExPack");
			array3[2] = text9;
			string text10 = Path.Combine(path, "BepInEx");
			array3[3] = text10;
			string text11 = Path.Combine(path, "Mods");
			array3[4] = text11;
			string text12 = Path.Combine(path, "Plugins");
			array3[5] = text12;
			string text13 = Path.Combine(path, "mod");
			array3[6] = text13;
			string text14 = Path.Combine(path, "BepInEx", "core");
			array3[7] = text14;
			string text15 = Path.Combine(path, "BepInEx", "plugins");
			array3[8] = text15;
			string text16 = Path.Combine(path, "BepInEx", "patchers");
			array3[9] = text16;
			string text17 = null;
			while ((nint)text17 < array3.Length)
			{
				if (Directory.Exists(array3[(object)text17]))
				{
				}
				text17++;
			}
		}
		bool flag8 = default(bool);
		string text18 = flag8.ToString();
		string text19 = flag6.ToString();
		string text20 = "IsLegit: " + text18 + ", hasSusFolder: " + text19;
		if (flag8 && !flag6)
		{
			SteamLeaderboardNew leaderboardKillsWeekly3 = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;
			LeaderboardEntry localEntry = leaderboardKillsWeekly3.localEntry;
			if (leaderboardKillsWeekly3.localEntry != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2778 @ rax_v143 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
				if ((nint)score < (nint)0)
				{
					goto IL_0ca9;
				}
			}
			SteamLeaderboardsManagerNew.QueueLeaderboardUpload(leaderboardKillsWeekly.lbName, score, array, isFriendsLb: false);
		}
		goto IL_0ca9;
		IL_0ca9:
		SteamLeaderboardsManagerNew.QueueLeaderboardUpload(leaderboardKillsWeekly2.lbNameFriends, score, array, isFriendsLb: true);
		SteamLeaderboardsManagerNew.QueueLeaderboardUpload(leaderboardKillsAllTime.lbNameFriends, score, array, isFriendsLb: true);
	}

	private unsafe static int[] GetWeapons()
	{
		//IL_0211: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_000f: Expected I, but got O
		//IL_004b: Expected I4, but got I8
		//IL_00a7: Expected I, but got O
		//IL_00ff: Expected O, but got I
		//IL_0133: Expected O, but got I4
		//IL_0174: Expected O, but got Ref
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a1: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
		object obj = default(object);
		int[] array = new int[obj];
		bool flag = array == null;
		nint num = (nint)typeof(int[]);
		if (!flag)
		{
			nint num2 = unchecked((nint)null);
			num = unchecked((nint)null);
			while (num2 < array.Length)
			{
				if (num < array.Length)
				{
					array[num] = -1;
					num++;
					num2 = num;
					continue;
				}
				throw new IndexOutOfRangeException();
			}
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null)
				{
					num = (nint)inventory.weaponInventory;
					if (inventory.weaponInventory != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9 (Il2CppClass<System.Int32[]>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9 (Il2CppClass<System.Int32[]>)+18]");
							Dictionary<EWeapon, WeaponBase>.KeyCollection keys = ((Dictionary<EWeapon, WeaponBase>)0).Keys;
							if (keys != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
								object obj2 = 0;
								Dictionary<EWeapon, WeaponBase>.KeyCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.KeyCollection.Enumerator);
								object obj4 = default(object);
								while (true)
								{
									if (enumerator.MoveNext())
									{
										if ((nint)obj2 < array.Length)
										{
											bool flag2 = (nint)obj2 >= array.Length;
											Dictionary<EWeapon, WeaponBase>.KeyCollection.Enumerator enumerator2 = (Dictionary<EWeapon, WeaponBase>.KeyCollection.Enumerator)(&enumerator);
											if (!flag2)
											{
												object obj3 = obj2 + 1;
												array[obj2] = (int)obj4;
												obj2 = obj3;
												continue;
											}
											throw new IndexOutOfRangeException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
									break;
								}
								return array;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe static int[] GetTomes()
	{
		//IL_01e1: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_000f: Expected I, but got O
		//IL_004b: Expected I4, but got I8
		//IL_00a7: Expected I, but got O
		//IL_00ff: Expected O, but got I
		//IL_0133: Expected O, but got I4
		//IL_0153: Expected O, but got Ref
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0180: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
		object obj = default(object);
		int[] array = new int[obj];
		bool flag = array == null;
		nint num = (nint)typeof(int[]);
		if (!flag)
		{
			nint num2 = unchecked((nint)null);
			num = unchecked((nint)null);
			while (num2 < array.Length)
			{
				if (num < array.Length)
				{
					array[num] = -1;
					num++;
					num2 = num;
					continue;
				}
				throw new IndexOutOfRangeException();
			}
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null)
				{
					num = (nint)inventory.tomeInventory;
					if (inventory.tomeInventory != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9 (Il2CppClass<System.Int32[]>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9 (Il2CppClass<System.Int32[]>)+18]");
							Dictionary<ETome, int>.KeyCollection keys = ((Dictionary<ETome, int>)0).Keys;
							if (keys != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
								object obj2 = 0;
								Dictionary<ETome, int>.KeyCollection.Enumerator enumerator = default(Dictionary<ETome, int>.KeyCollection.Enumerator);
								object obj4 = default(object);
								while (true)
								{
									if (enumerator.MoveNext())
									{
										bool flag2 = (nint)obj2 >= array.Length;
										Dictionary<ETome, int>.KeyCollection.Enumerator enumerator2 = (Dictionary<ETome, int>.KeyCollection.Enumerator)(&enumerator);
										if (flag2)
										{
											break;
										}
										object obj3 = obj2 + 1;
										array[obj2] = (int)obj4;
										obj2 = obj3;
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
									return array;
								}
								throw new IndexOutOfRangeException();
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static ECharacter GetCharacter(int[] details)
	{
		//IL_0070: Expected I4, but got O
		if (IsLegitCharacter(details))
		{
			if (details != null)
			{
				return (ECharacter)details[1];
			}
			NullReferenceException ex = new NullReferenceException();
			return (ECharacter)ex;
		}
		return ECharacter.Fox;
	}

	private static bool IsLegitCharacter(int[] details)
	{
		//IL_0127: Expected I4, but got O
		//IL_00aa: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected I4, but got Unknown
		if (details.Length > 1)
		{
			if (details[1] < 0)
			{
				return false;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ECharacter));
			Array values = Enum.GetValues(typeFromHandle);
			int num = values.System_002ECollections_002EICollection_002ECount;
			object obj = details[1] - num;
			int num2 = details[1] ^ num;
			int num3 = details[1] ^ obj;
			int num4 = num2 & num3;
			bool flag = num4 < 0;
			bool flag2 = (nint)obj < 0;
			return flag2 != flag;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe static bool CanShowScore(ulong steamid, int score, int[] leaderboardDetails, out string s)
	{
		//IL_03f9: Expected I4, but got O
		//IL_01f5: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_0306: Expected O, but got I4
		//IL_0343: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		ref string reference = ref *(string*)"";
		if (!SteamLeaderboardsManagerNew.IsCheater(steamid) && IsLegitCharacter(leaderboardDetails))
		{
			int[] array = new int[8];
			int length = default(int);
			Array.Copy(leaderboardDetails, 12, array, 0, length);
			int[] second = GenerateScoreHashNew(score, steamid);
			if (!Enumerable.SequenceEqual(array, second))
			{
				int[] second2 = GenerateScoreHash(score);
				if (!Enumerable.SequenceEqual(array, second2))
				{
					ulong num = default(ulong);
					string text = num.ToString();
					string text2 = "No acceptable hash for: " + text;
					goto IL_010d;
				}
			}
			if (leaderboardDetails.Length <= 2)
			{
				goto IL_03eb;
			}
			if (leaderboardDetails[2] > 0)
			{
				if (leaderboardDetails.Length <= 7 || leaderboardDetails.Length <= 8 || leaderboardDetails.Length <= 10 || leaderboardDetails.Length <= 11)
				{
					goto IL_03eb;
				}
				nint num2 = (nint)typeof(PlayerXp);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
				int num3 = leaderboardDetails[8];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v20 (Il2CppClass<Inventory__Items__Pickups.Xp_and_Levels.PlayerXp>)+B8]");
				if ((nint)num3 <= (nint)0)
				{
					if (leaderboardDetails.Length <= 9)
					{
						goto IL_03eb;
					}
					if (leaderboardDetails[9] == leaderboardDetails[10] && leaderboardDetails[9] == score)
					{
						if (leaderboardDetails.Length <= 40)
						{
							goto IL_03eb;
						}
						if (leaderboardDetails[40] == 0)
						{
							object obj = leaderboardDetails[2] * 500;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814DE520");
							object obj2 = default(object);
							bool flag = (nint)obj2 <= 10000;
							object obj3 = 10000;
							if (!flag)
							{
								obj3 = obj2;
							}
							if (leaderboardDetails[10] <= (nint)obj3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
								object obj4 = 2147483647 + leaderboardDetails[2];
								object obj5 = obj4 >> 5;
								object obj6 = obj5 >> 31;
								object obj7 = obj5 + obj6;
								if ((nint)obj7 > 1500)
								{
									obj7 = 1500;
								}
								if (leaderboardDetails.Length <= 6)
								{
									goto IL_03eb;
								}
								object obj8 = obj7 + 420;
								if (leaderboardDetails[6] <= (nint)obj8)
								{
									reference = ref *(string*)"All checks passed";
									return true;
								}
							}
						}
					}
				}
			}
		}
		goto IL_010d;
		IL_010d:
		return false;
		IL_03eb:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static string GetSecretKey()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		byte[] array = new byte[16]
		{
			146, 83, 32, 195, 186, 238, 46, 81, 165, 163,
			48, 229, 105, 162, 228, 15
		};
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < array.Length)
			{
				if ((nint)obj2 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+20+v30 @ rax_v2 (System.Byte[])]");
				_ = (nuint)0u ^ (nuint)0x55u;
				obj2++;
				obj = obj2;
				continue;
			}
			Encoding uTF = Encoding.UTF8;
			return uTF.GetString(array);
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private unsafe static int[] GenerateScoreHash(int score)
	{
		//IL_01f6: Expected O, but got Ref
		//IL_00bb: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_010b: Expected O, but got I4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0176: Expected I4, but got O
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		SHA256 sHA = SHA256.Create();
		HashAlgorithm hashAlgorithm = default(HashAlgorithm);
		object obj = (object)(&hashAlgorithm);
		int num = default(int);
		string text = num.ToString();
		string secretKey = GetSecretKey();
		string s = text + secretKey;
		Encoding uTF = Encoding.UTF8;
		bool flag = uTF == null;
		Encoding encoding = null;
		if (!flag)
		{
			byte[] bytes = uTF.GetBytes(s);
			if (hashAlgorithm != null)
			{
				byte[] array = hashAlgorithm.ComputeHash(bytes);
				if (array != null)
				{
					object obj2 = array.Length >> 31;
					object obj3 = obj2 & 3;
					object obj4 = obj3 + array.Length;
					object obj5 = obj4 >> 2;
					int[] array2 = new int[obj5];
					bool flag2 = array2 == null;
					object obj6 = 0;
					encoding = (Encoding)(object)typeof(int[]);
					if (!flag2)
					{
						Encoding encoding2 = default(Encoding);
						while ((nint)obj6 < array2.Length)
						{
							object obj7 = obj6 * 4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181442A60");
							array2[obj6] = (int)encoding2;
							obj6++;
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						return array2;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe static int[] GenerateScoreHashNew(int score, ulong steamid)
	{
		//IL_0204: Expected O, but got Ref
		//IL_00c9: Expected O, but got I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0119: Expected O, but got I4
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0184: Expected I4, but got O
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		SHA256 sHA = SHA256.Create();
		HashAlgorithm hashAlgorithm = default(HashAlgorithm);
		object obj = (object)(&hashAlgorithm);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		string secretKey = GetSecretKey();
		object arg = default(object);
		object arg2 = default(object);
		string s = $"{arg}:{arg2}:{secretKey}";
		Encoding uTF = Encoding.UTF8;
		bool flag = uTF == null;
		Encoding encoding = null;
		if (!flag)
		{
			byte[] bytes = uTF.GetBytes(s);
			if (hashAlgorithm != null)
			{
				byte[] array = hashAlgorithm.ComputeHash(bytes);
				if (array != null)
				{
					object obj2 = array.Length >> 31;
					object obj3 = obj2 & 3;
					object obj4 = obj3 + array.Length;
					object obj5 = obj4 >> 2;
					int[] array2 = new int[obj5];
					bool flag2 = array2 == null;
					object obj6 = 0;
					encoding = (Encoding)(object)typeof(int[]);
					if (!flag2)
					{
						Encoding encoding2 = default(Encoding);
						while ((nint)obj6 < array2.Length)
						{
							object obj7 = obj6 * 4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181442A60");
							array2[obj6] = (int)encoding2;
							obj6++;
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						return array2;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}
}
