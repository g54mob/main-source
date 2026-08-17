using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Achievements;

public class ThosePeople_CustomAchivementHandleing : ICustomAchievements
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__1_0;

		public static Predicate<Equipment> _003C_003E9__4_6;

		public static Predicate<Equipment> _003C_003E9__4_7;

		public static Func<Equipment, bool> _003C_003E9__4_1;

		public static Func<Equipment, bool> _003C_003E9__4_2;

		public static Func<Equipment, bool> _003C_003E9__4_3;

		public static Func<Equipment, bool> _003C_003E9__4_4;

		public static Func<Equipment, bool> _003C_003E9__4_5;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CCheckAchievements_003Eb__1_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1589;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_6(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1589;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_7(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 29;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1575;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1602;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1603;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_4(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1612;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CRunSecretsCheck_003Eb__4_5(Equipment e)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)e != null)
			{
				object obj = e._equipmentType - 1613;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PlayerOptions playerOptions;

		internal bool _003CRunSecretsCheck_003Eb__0(WeaponType weapon)
		{
			//IL_0070: Expected I4, but got O
			if (playerOptions != null)
			{
				PlayerOptionsData config = playerOptions.Config;
				if (config != null && config._003CCollectedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					bool result = default(bool);
					return result;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public WeaponType weapon;

		internal bool _003CRunSecretsCheck_003Eb__8(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weapon;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static void RunManualCreditsUnlockChecks(AchievementManager achievementManager, PlayerOptions playerOptions)
	{
		if (achievementManager.CheckHaveOpenedCoffinForXCharacter(CharacterType.TP_DRACULA))
		{
			bool flag = achievementManager.Unlock(AchievementType.TP_Dracula_FindCoffin3);
		}
		PlayerOptionsData config = playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				bool flag2 = achievementManager.Unlock(AchievementType.TP_Relic_BlackDisk);
			}
		}
	}

	public unsafe List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
	{
		//IL_008f: Expected I4, but got O
		//IL_1dfd: Expected I4, but got O
		//IL_00e1: Expected O, but got I4
		//IL_020b: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_1e2e: Expected O, but got I
		//IL_0329: Expected O, but got I
		//IL_1ec2: Expected I4, but got O
		//IL_037c: Expected I4, but got O
		//IL_0499: Expected O, but got I
		//IL_03ad: Expected O, but got I
		//IL_0523: Expected O, but got I
		//IL_0437: Expected O, but got I
		//IL_1ef3: Expected O, but got I
		//IL_05b7: Expected O, but got I
		//IL_1f79: Expected I4, but got O
		//IL_060a: Expected I4, but got O
		//IL_0727: Expected O, but got I
		//IL_063b: Expected O, but got I
		//IL_07b1: Expected O, but got I
		//IL_06c5: Expected O, but got I
		//IL_1faa: Expected O, but got I
		//IL_0845: Expected O, but got I
		//IL_2030: Expected I4, but got O
		//IL_0898: Expected I4, but got O
		//IL_09b5: Expected O, but got I
		//IL_08c9: Expected O, but got I
		//IL_0a3f: Expected O, but got I
		//IL_0953: Expected O, but got I
		//IL_2061: Expected O, but got I
		//IL_0ad3: Expected O, but got I
		//IL_20e7: Expected I4, but got O
		//IL_0b26: Expected I4, but got O
		//IL_0c43: Expected O, but got I
		//IL_0b57: Expected O, but got I
		//IL_0ccd: Expected O, but got I
		//IL_0be1: Expected O, but got I
		//IL_2118: Expected O, but got I
		//IL_0d61: Expected O, but got I
		//IL_219e: Expected I4, but got O
		//IL_0db4: Expected I4, but got O
		//IL_0ed1: Expected O, but got I
		//IL_0de5: Expected O, but got I
		//IL_0f5b: Expected O, but got I
		//IL_0e6f: Expected O, but got I
		//IL_21cf: Expected O, but got I
		//IL_0fef: Expected O, but got I
		//IL_2255: Expected I4, but got O
		//IL_1042: Expected I4, but got O
		//IL_115f: Expected O, but got I
		//IL_1073: Expected O, but got I
		//IL_11e9: Expected O, but got I
		//IL_10fd: Expected O, but got I
		//IL_2286: Expected O, but got I
		//IL_127d: Expected O, but got I
		//IL_230c: Expected I4, but got O
		//IL_12d0: Expected I4, but got O
		//IL_13ed: Expected O, but got I
		//IL_1301: Expected O, but got I
		//IL_1477: Expected O, but got I
		//IL_138b: Expected O, but got I
		//IL_233d: Expected O, but got I
		//IL_150b: Expected O, but got I
		//IL_155e: Expected I4, but got O
		//IL_166c: Expected I4, but got O
		//IL_177a: Expected I4, but got O
		//IL_158f: Expected O, but got I
		//IL_1888: Expected I4, but got O
		//IL_169d: Expected O, but got I
		//IL_1996: Expected I4, but got O
		//IL_17ab: Expected O, but got I
		//IL_1aa4: Expected I4, but got O
		//IL_18b9: Expected O, but got I
		//IL_1619: Expected O, but got I
		//IL_19c7: Expected O, but got I
		//IL_1727: Expected O, but got I
		//IL_1ad5: Expected O, but got I
		//IL_1835: Expected O, but got I
		//IL_1bde: Expected O, but got I
		//IL_1bee: Expected O, but got I
		//IL_1943: Expected O, but got I
		//IL_1a51: Expected O, but got I
		//IL_1b5f: Expected O, but got I
		//IL_1c6e: Expected O, but got I
		List<AchievementType> list = new List<AchievementType>();
		bool flag = CharacterSaveManager.HasCharacterCompletedAnyStage(CharacterType.TP_SHANOA);
		bool flag2 = !flag;
		CharacterType characterType = CharacterType.TP_SHANOA;
		if (!flag2)
		{
			bool flag3 = CharacterSaveManager.HasCharacterCompletedAnyStage(CharacterType.TP_JUSTE);
			bool flag4 = !flag3;
			characterType = CharacterType.TP_JUSTE;
			if (!flag4)
			{
				bool flag5 = list == null;
				characterType = CharacterType.TP_JUSTE;
				if (flag5)
				{
					goto IL_1cad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
				characterType = (CharacterType)list;
			}
		}
		if (achievementManager != null && achievementManager._Characters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				nint num = (nint)(&enumerator);
				throw new NullReferenceException();
			}
			List<WeaponType> list2 = new List<WeaponType>();
			bool flag6 = list2 == null;
			characterType = (CharacterType)list2;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v14+18]");
					if (num2 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1411);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj3 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v14+18]");
						if (num3 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1411;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					characterType = CharacterType.VOID;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v16+18]");
						if (num4 >= 0)
						{
							((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1412);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							object obj5 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v16+18]");
							if (num5 >= 0)
							{
								goto IL_1e63;
							}
							_ = 1412;
						}
						if (!Weapon_Unlock_Damage_Achievement(achievementManager, list2))
						{
							goto IL_1ea1;
						}
						bool flag7 = list == null;
						characterType = (CharacterType)this;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							characterType = CharacterType.VOID;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v121+18]");
								if (num6 >= 0)
								{
									((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)350);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									object obj7 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v121+18]");
									if (num7 >= 0)
									{
										goto IL_1e63;
									}
									_ = 350;
								}
								goto IL_1ea1;
							}
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_248c:
		return list;
		IL_200f:
		List<WeaponType> list3 = new List<WeaponType>();
		bool flag8 = list3 == null;
		characterType = (CharacterType)list3;
		if (!flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rdx_v35+18]");
				if (num8 >= 0)
				{
					((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1419);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj9 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rdx_v35+18]");
					if (num9 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1419;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v37+18]");
					if (num10 >= 0)
					{
						((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1420);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj11 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2223 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v37+18]");
						if (num11 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1420;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list3, 4000f))
					{
						goto IL_20c6;
					}
					bool flag9 = list == null;
					characterType = (CharacterType)this;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdx_v109+18]");
							if (num12 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)353);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj13 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdx_v109+18]");
								if (num13 >= 0)
								{
									goto IL_1e63;
								}
								_ = 353;
							}
							goto IL_20c6;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_2465:
		if (Check_CandyboxSkins(playerOptions))
		{
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				bool flag10 = (nint)0 == 0;
				characterType = CharacterType.VOID;
				if (!flag10)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v81+18]");
					if (num14 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)392);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj16 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v81+18]");
						if (num15 >= 0)
						{
							goto IL_1e63;
						}
						_ = 392;
					}
					goto IL_248c;
				}
			}
			goto IL_1cad;
		}
		goto IL_248c;
		IL_217d:
		List<WeaponType> list4 = new List<WeaponType>();
		bool flag11 = list4 == null;
		characterType = (CharacterType)list4;
		if (!flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v49+18]");
				if (num16 >= 0)
				{
					((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1503);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj18 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v49+18]");
					if (num17 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1503;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rdx_v51+18]");
					if (num18 >= 0)
					{
						((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1504);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj20 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rdx_v51+18]");
						if (num19 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1504;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list4, 6000f))
					{
						goto IL_2234;
					}
					bool flag12 = list == null;
					characterType = (CharacterType)this;
					if (!flag12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num20 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rdx_v101+18]");
							if (num20 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)355);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj22 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num21 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rdx_v101+18]");
								if (num21 >= 0)
								{
									goto IL_1e63;
								}
								_ = 355;
							}
							goto IL_2234;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_20c6:
		List<WeaponType> list5 = new List<WeaponType>();
		bool flag13 = list5 == null;
		characterType = (CharacterType)list5;
		if (!flag13)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v42+18]");
				if (num22 >= 0)
				{
					((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1417);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj24 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v42+18]");
					if (num23 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1417;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v44+18]");
					if (num24 >= 0)
					{
						((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1418);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj26 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ rax_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num25 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v44+18]");
						if (num25 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1418;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list5, 5000f))
					{
						goto IL_217d;
					}
					bool flag14 = list == null;
					characterType = (CharacterType)this;
					if (!flag14)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj27 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num26 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rdx_v105+18]");
							if (num26 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)354);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj28 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num27 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rdx_v105+18]");
								if (num27 >= 0)
								{
									goto IL_1e63;
								}
								_ = 354;
							}
							goto IL_217d;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_22eb:
		List<WeaponType> list6 = new List<WeaponType>();
		bool flag15 = list6 == null;
		characterType = (CharacterType)list6;
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v63+18]");
				if (num28 >= 0)
				{
					((List<System.Int32Enum>)(object)list6).AddWithResize((System.Int32Enum)1501);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj30 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v63+18]");
					if (num29 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1501;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v65+18]");
					if (num30 >= 0)
					{
						((List<System.Int32Enum>)(object)list6).AddWithResize((System.Int32Enum)1502);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj32 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2647 @ rax_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num31 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v65+18]");
						if (num31 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1502;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list6, 8000f))
					{
						goto IL_23a2;
					}
					bool flag16 = list == null;
					characterType = (CharacterType)this;
					if (!flag16)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num32 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v93+18]");
							if (num32 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)357);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj34 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num33 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v93+18]");
								if (num33 >= 0)
								{
									goto IL_1e63;
								}
								_ = 357;
							}
							goto IL_23a2;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_1e63:
		return (List<AchievementType>)(object)new IndexOutOfRangeException();
		IL_1ea1:
		List<WeaponType> list7 = new List<WeaponType>();
		bool flag17 = list7 == null;
		characterType = (CharacterType)list7;
		if (!flag17)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v21+18]");
				if (num34 >= 0)
				{
					((List<System.Int32Enum>)(object)list7).AddWithResize((System.Int32Enum)1494);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj36 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v21+18]");
					if (num35 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1494;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v23+18]");
					if (num36 >= 0)
					{
						((List<System.Int32Enum>)(object)list7).AddWithResize((System.Int32Enum)1495);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj38 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num37 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v23+18]");
						if (num37 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1495;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list7, 2000f))
					{
						goto IL_1f58;
					}
					bool flag18 = list == null;
					characterType = (CharacterType)this;
					if (!flag18)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj39 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num38 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v117+18]");
							if (num38 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)351);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj40 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num39 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v117+18]");
								if (num39 >= 0)
								{
									goto IL_1e63;
								}
								_ = 351;
							}
							goto IL_1f58;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_23f0:
		if (Check_Diabologue(playerOptions))
		{
			bool flag19 = list == null;
			characterType = (CharacterType)this;
			if (!flag19)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rdx_v87+18]");
					if (num40 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)319);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj42 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num41 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rdx_v87+18]");
						if (num41 >= 0)
						{
							goto IL_1e63;
						}
						_ = 319;
					}
					goto IL_2417;
				}
			}
			goto IL_1cad;
		}
		goto IL_2417;
		IL_2417:
		if (Check_CoatOfArms(playerOptions))
		{
			bool flag20 = list == null;
			characterType = (CharacterType)this;
			if (!flag20)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj43 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num42 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v85+18]");
					if (num42 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)317);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj44 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num43 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v85+18]");
						if (num43 >= 0)
						{
							goto IL_1e63;
						}
						_ = 317;
					}
					goto IL_243e;
				}
			}
			goto IL_1cad;
		}
		goto IL_243e;
		IL_23a2:
		if (Check_MorningStar(playerOptions))
		{
			bool flag21 = list == null;
			characterType = (CharacterType)this;
			if (!flag21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num44 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v91+18]");
					if (num44 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)315);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj46 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num45 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v91+18]");
						if (num45 >= 0)
						{
							goto IL_1e63;
						}
						_ = 315;
					}
					goto IL_23c9;
				}
			}
			goto IL_1cad;
		}
		goto IL_23c9;
		IL_1cad:
		throw new NullReferenceException();
		IL_1f58:
		List<WeaponType> list8 = new List<WeaponType>();
		bool flag22 = list8 == null;
		characterType = (CharacterType)list8;
		if (!flag22)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj47 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+18]");
				if (num46 >= 0)
				{
					((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)1415);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj48 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num47 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v28+18]");
					if (num47 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1415;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj49 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num48 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v30+18]");
					if (num48 >= 0)
					{
						((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)1416);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj50 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num49 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v30+18]");
						if (num49 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1416;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list8, 3000f))
					{
						goto IL_200f;
					}
					bool flag23 = list == null;
					characterType = (CharacterType)this;
					if (!flag23)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj51 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num50 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v113+18]");
							if (num50 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)352);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj52 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num51 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v113+18]");
								if (num51 >= 0)
								{
									goto IL_1e63;
								}
								_ = 352;
							}
							goto IL_200f;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_2234:
		List<WeaponType> list9 = new List<WeaponType>();
		bool flag24 = list9 == null;
		characterType = (CharacterType)list9;
		if (!flag24)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj53 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			characterType = CharacterType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num52 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v56+18]");
				if (num52 >= 0)
				{
					((List<System.Int32Enum>)(object)list9).AddWithResize((System.Int32Enum)1508);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj54 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num53 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v56+18]");
					if (num53 >= 0)
					{
						goto IL_1e63;
					}
					_ = 1508;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj55 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num54 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v58+18]");
					if (num54 >= 0)
					{
						((List<System.Int32Enum>)(object)list9).AddWithResize((System.Int32Enum)1509);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj56 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2541 @ rax_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num55 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v58+18]");
						if (num55 >= 0)
						{
							goto IL_1e63;
						}
						_ = 1509;
					}
					if (!Weapon_Unlock_Damage_Achievement(achievementManager, list9, 7000f))
					{
						goto IL_22eb;
					}
					bool flag25 = list == null;
					characterType = (CharacterType)this;
					if (!flag25)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						object obj57 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						characterType = CharacterType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							nint num56 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v97+18]");
							if (num56 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)356);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj58 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num57 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v97+18]");
								if (num57 >= 0)
								{
									goto IL_1e63;
								}
								_ = 356;
							}
							goto IL_22eb;
						}
					}
				}
			}
		}
		goto IL_1cad;
		IL_23c9:
		if (Check_Spellbook(playerOptions))
		{
			bool flag26 = list == null;
			characterType = (CharacterType)this;
			if (!flag26)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj59 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num58 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v89+18]");
					if (num58 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)318);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj60 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num59 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v89+18]");
						if (num59 >= 0)
						{
							goto IL_1e63;
						}
						_ = 318;
					}
					goto IL_23f0;
				}
			}
			goto IL_1cad;
		}
		goto IL_23f0;
		IL_243e:
		if (Check_SpectralSword(playerOptions))
		{
			bool flag27 = list == null;
			characterType = (CharacterType)this;
			if (!flag27)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj61 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num60 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v83+18]");
					if (num60 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)316);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj62 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num61 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v83+18]");
						if (num61 >= 0)
						{
							goto IL_1e63;
						}
						_ = 316;
					}
					goto IL_2465;
				}
			}
			goto IL_1cad;
		}
		goto IL_2465;
	}

	public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
	{
		return new List<AchievementType>();
	}

	public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
	{
		return new List<AchievementType>();
	}

	public void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_013d: Expected O, but got I
		//IL_014f: Expected O, but got I4
		//IL_015f: Expected O, but got I
		//IL_0128: Expected O, but got I4
		//IL_409b: Expected O, but got F4
		//IL_40b4: Invalid comparison between I4 and F4
		//IL_31e2: Invalid comparison between I4 and F4
		//IL_31f3: Expected I4, but got O
		//IL_076f: Expected O, but got I
		//IL_0785: Expected O, but got I
		//IL_140c: Expected O, but got F4
		//IL_146f: Invalid comparison between F4 and O
		//IL_148d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1492: Expected O, but got Unknown
		//IL_1ae9: Expected O, but got I
		//IL_1b26: Expected I4, but got O
		//IL_3a41: Expected O, but got I4
		//IL_3aa4: Expected O, but got I
		//IL_3ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ab7: Expected O, but got Unknown
		//IL_3ae7: Expected O, but got I4
		//IL_3b6e: Expected I4, but got I8
		//IL_3b7e: Expected I, but got O
		//IL_3ba3: Expected O, but got I4
		//IL_3c00: Expected O, but got I4
		//IL_3c58: Expected O, but got I4
		//IL_3ca2: Expected I, but got O
		//IL_2757: Expected O, but got I
		//IL_2768: Invalid comparison between I and F4
		//IL_27ae: Expected O, but got I
		//IL_2ee8: Expected O, but got I
		//IL_2ef9: Invalid comparison between I and F4
		//IL_2f44: Expected O, but got I
		//IL_0935->IL0a7a: Incompatible stack heights: 7 vs 4
		//IL_0883->IL0884: Incompatible stack heights: 8 vs 4
		//IL_0bc4->IL0e48: Incompatible stack heights: 11 vs 7
		//IL_09c3->IL0a7a: Incompatible stack heights: 10 vs 4
		//IL_0f0c->IL106e: Incompatible stack heights: 10 vs 7
		//IL_1123->IL126c: Incompatible stack heights: 9 vs 7
		//IL_1394->IL1394: Incompatible stack heights: 12 vs 8
		//IL_0c52->IL0e48: Incompatible stack heights: 14 vs 7
		//IL_14b2->IL4181: Incompatible stack heights: 12 vs 9
		//IL_0a7a->IL0a7a: Incompatible stack heights: 14 vs 4
		//IL_14ea->IL4181: Incompatible stack heights: 12 vs 9
		//IL_11b6->IL126c: Incompatible stack heights: 12 vs 7
		//IL_180e->IL180e: Incompatible stack heights: 13 vs 9
		//IL_1909->IL19c8: Incompatible stack heights: 13 vs 12
		//IL_106e->IL106e: Incompatible stack heights: 18 vs 7
		//IL_1717->IL0e48: Incompatible stack heights: 18 vs 7
		//IL_0cdd->IL0e48: Incompatible stack heights: 14 vs 7
		//IL_15b1->IL4181: Incompatible stack heights: 16 vs 9
		//IL_126c->IL126c: Incompatible stack heights: 16 vs 7
		//IL_41bd->IL0e48: Incompatible stack heights: 18 vs 7
		//IL_19c8->IL19c8: Incompatible stack heights: 17 vs 12
		//IL_0d93->IL0e48: Incompatible stack heights: 18 vs 7
		//IL_1ba0->IL421d: Incompatible stack heights: 15 vs 13
		//IL_1bc3->IL421d: Incompatible stack heights: 15 vs 13
		//IL_1dde->IL1e9d: Incompatible stack heights: 20 vs 16
		//IL_21fd->IL2309: Incompatible stack heights: 19 vs 16
		//IL_1f6e->IL214c: Incompatible stack heights: 20 vs 16
		//IL_1d0d->IL1d0d: Incompatible stack heights: 20 vs 16
		//IL_3af7->IL3ca7: Incompatible stack heights: 1 vs 3
		//IL_3aec->IL4405: Incompatible stack heights: 1 vs 0
		//IL_224a->IL2309: Incompatible stack heights: 20 vs 16
		//IL_23ff->IL24be: Incompatible stack heights: 20 vs 19
		//IL_1fff->IL214c: Incompatible stack heights: 23 vs 16
		//IL_1e9d->IL1e9d: Incompatible stack heights: 24 vs 16
		//IL_258f->IL264e: Incompatible stack heights: 23 vs 19
		//IL_271f->IL28aa: Incompatible stack heights: 23 vs 19
		//IL_2b66->IL2c1c: Incompatible stack heights: 20 vs 19
		//IL_297b->IL2ae2: Incompatible stack heights: 23 vs 19
		//IL_2ca0->IL2d56: Incompatible stack heights: 20 vs 19
		//IL_2309->IL2309: Incompatible stack heights: 24 vs 16
		//IL_2e17->IL2fa1: Incompatible stack heights: 22 vs 19
		//IL_2777->IL28aa: Incompatible stack heights: 24 vs 19
		//IL_24be->IL24be: Incompatible stack heights: 24 vs 19
		//IL_208d->IL214c: Incompatible stack heights: 26 vs 16
		//IL_3030->IL43d1: Incompatible stack heights: 20 vs 0
		//IL_264e->IL264e: Incompatible stack heights: 27 vs 19
		//IL_306f->IL43d1: Incompatible stack heights: 21 vs 0
		//IL_2c1c->IL2c1c: Incompatible stack heights: 24 vs 19
		//IL_2a2c->IL2ae2: Incompatible stack heights: 27 vs 19
		//IL_27eb->IL28aa: Incompatible stack heights: 26 vs 19
		//IL_2eb0->IL2fa1: Incompatible stack heights: 25 vs 19
		//IL_2d56->IL2d56: Incompatible stack heights: 24 vs 19
		//IL_214c->IL214c: Incompatible stack heights: 30 vs 16
		//IL_2f08->IL2fa1: Incompatible stack heights: 26 vs 19
		//IL_3fc1->IL4011: Incompatible stack heights: 3 vs 0
		//IL_3101->IL43d1: Incompatible stack heights: 24 vs 0
		//IL_2ae2->IL2ae2: Incompatible stack heights: 31 vs 19
		//IL_28aa->IL28aa: Incompatible stack heights: 30 vs 19
		//IL_4011->IL4011: Incompatible stack heights: 3 vs 0
		//IL_2fa1->IL2fa1: Incompatible stack heights: 29 vs 19
		//IL_31b8->IL43d1: Incompatible stack heights: 28 vs 0
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals12.playerOptions = playerOptions;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v218 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		Dictionary<EnemyType, int> dictionary = config2._003CKillCount_003Ek__BackingField;
		int num = config2._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_CAVETROLL);
		object obj2;
		if (num < 0)
		{
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ rbx_v213 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
			object obj3 = 0;
			object obj4 = num + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ rax_v1118+2C+v2043 @ rcx_v764*8]");
			obj2 = 0;
		}
		if ((nint)obj2 >= 6000)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			bool flag = core3._playerOptions.UnlockSecret(SecretType.tp_cavetroll, config3);
			GameManager core4 = GM.Core;
			core4._playerOptions.UnlockCharacter(CharacterType.TP_CAVETROLL);
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config4 = core5._playerOptions.Config;
		bool flag2 = config4._003CKillCount_003Ek__BackingField == null;
		int num2 = config4._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_FLEAMAN);
		int num3 = 0;
		if (!flag2)
		{
			PlayerOptionsData config5 = CS_0024_003C_003E8__locals12.playerOptions.Config;
			int num4 = config5._003CKillCount_003Ek__BackingField.get_Item(EnemyType.TP_FLEAMAN);
			num3 = num4;
		}
		GameManager core6 = GM.Core;
		PlayerOptionsData config6 = core6._playerOptions.Config;
		bool flag3 = config6._003CKillCount_003Ek__BackingField == null;
		int num5 = config6._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_FLEAMAN_SWARM);
		if (!flag3)
		{
			PlayerOptionsData config7 = CS_0024_003C_003E8__locals12.playerOptions.Config;
			int num6 = config7._003CKillCount_003Ek__BackingField.get_Item(EnemyType.TP_FLEAMAN_SWARM);
			num3 += num6;
		}
		GameManager core7 = GM.Core;
		PlayerOptionsData config8 = core7._playerOptions.Config;
		bool flag4 = config8._003CKillCount_003Ek__BackingField == null;
		int num7 = config8._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_MEGA_FLEAMAN);
		if (!flag4)
		{
			PlayerOptionsData config9 = CS_0024_003C_003E8__locals12.playerOptions.Config;
			int num8 = config9._003CKillCount_003Ek__BackingField.get_Item(EnemyType.TP_MEGA_FLEAMAN);
			num3 += num8;
		}
		GameManager core8 = GM.Core;
		PlayerOptionsData config10 = core8._playerOptions.Config;
		bool flag5 = config10._003CKillCount_003Ek__BackingField == null;
		int num9 = config10._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_FLEARIDER);
		if (!flag5)
		{
			PlayerOptionsData config11 = CS_0024_003C_003E8__locals12.playerOptions.Config;
			int num10 = config11._003CKillCount_003Ek__BackingField.get_Item(EnemyType.TP_FLEARIDER);
			num3 += num10;
		}
		GameManager core9 = GM.Core;
		PlayerOptionsData config12 = core9._playerOptions.Config;
		bool flag6 = config12._003CKillCount_003Ek__BackingField == null;
		int num11 = config12._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.TP_FLEAARMOR);
		if (!flag6)
		{
			PlayerOptionsData config13 = CS_0024_003C_003E8__locals12.playerOptions.Config;
			int num12 = config13._003CKillCount_003Ek__BackingField.get_Item(EnemyType.TP_FLEAARMOR);
			num3 += num12;
		}
		if (num3 >= 3000)
		{
			object obj5 = UnityEngine.Random.value;
			float num13 = 0f * 9000f;
			if ((float)num3 > num13)
			{
				GameManager core10 = GM.Core;
				PlayerOptionsData config14 = core10._playerOptions.Config;
				bool flag7 = core10._playerOptions.UnlockSecret(SecretType.tp_fleaman, config14);
				GameManager core11 = GM.Core;
				core11._playerOptions.UnlockCharacter(CharacterType.TP_FLEAMAN);
			}
		}
		GameManager core12 = GM.Core;
		PlayerOptionsData config15 = core12._playerOptions.Config;
		List<EnemyType> list2 = config15._003CRunBossesTypes_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rax_v487 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		if ((nint)0 >= (nint)22)
		{
			GameManager core13 = GM.Core;
			PlayerOptionsData config16 = core13._playerOptions.Config;
			if (config16._003CSelectedStage_003Ek__BackingField == StageType.TP_CASTLE)
			{
				GameManager core14 = GM.Core;
				PlayerOptionsData config17 = core14._playerOptions.Config;
				bool flag8 = core14._playerOptions.UnlockSecret(SecretType.tp_graham, config17);
				GameManager core15 = GM.Core;
				core15._playerOptions.UnlockCharacter(CharacterType.TP_GRAHAM);
			}
		}
		GameManager core16 = GM.Core;
		PlayerOptionsData config18 = core16._playerOptions.Config;
		List<VampireSurvivors.Objects.Characters.CharacterController> list3 = achievementManager._Characters;
		VampireSurvivors.Objects.Characters.CharacterController characterController = null;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)achievementManager._Characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj6 = default(object);
		object obj7 = default(object);
		object obj8 = default(object);
		ThosePeople_CustomAchivementHandleing thosePeople_CustomAchivementHandleing2 = default(ThosePeople_CustomAchivementHandleing);
		object obj10 = default(object);
		object obj11 = default(object);
		List<WeaponType>.Enumerator enumerator3 = default(List<WeaponType>.Enumerator);
		object obj12 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj15 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
			GameManager core17 = GM.Core;
			bool flag9 = (object)GM.Core == null;
			bool flag10 = core17._playerOptions == null;
			PlayerOptionsData config19 = core17._playerOptions.Config;
			bool flag11 = config19 == null;
			List<EnemyType> list4 = config19._003CRunBossesTypes_003Ek__BackingField;
			bool flag12 = config19._003CRunBossesTypes_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6581 @ rcx_v434 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6581 @ rcx_v434 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
				list3 = (List<VampireSurvivors.Objects.Characters.CharacterController>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6581 @ rcx_v434 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
				int num14 = ((Dictionary<EnemyType, int>)0).get_Item(EnemyType.TP_BOSS_MALPHAS);
				if (num14 != -1 && characterController2._characterType == CharacterType.TP_QUINCY)
				{
					GameManager core18 = GM.Core;
					bool flag13 = (object)GM.Core == null;
					bool flag14 = core18._playerOptions == null;
					bool flag15 = core18._playerOptions.UnlockSecret(SecretType.tp_malphas);
					GameManager core19 = GM.Core;
					bool flag16 = (object)GM.Core == null;
					bool flag17 = core19._playerOptions == null;
					core19._playerOptions.UnlockCharacter(CharacterType.TP_MALPHAS);
				}
			}
			if (characterController2._characterType == CharacterType.TP_CORNELL)
			{
				GameManager core20 = GM.Core;
				bool flag18 = (object)GM.Core == null;
				bool flag19 = core20._playerOptions == null;
				PlayerOptionsData config20 = core20._playerOptions.Config;
				bool flag20 = config20 == null;
				if (config20._003CSelectedStage_003Ek__BackingField == StageType.TP_CASTLE)
				{
					GameManager core21 = GM.Core;
					bool flag21 = (object)GM.Core == null;
					bool flag22 = core21._playerOptions == null;
					PlayerOptionsData config21 = core21._playerOptions.Config;
					bool flag23 = config21 == null;
					if (config21._003CRunEnemies_003Ek__BackingField >= 100000)
					{
						GameManager core22 = GM.Core;
						bool flag24 = (object)GM.Core == null;
						bool flag25 = core22._playerOptions == null;
						bool flag26 = core22._playerOptions.UnlockSecret(SecretType.tp_bluecornell);
						GameManager core23 = GM.Core;
						bool flag27 = (object)GM.Core == null;
						bool flag28 = core23._playerOptions == null;
						core23._playerOptions.UnlockCharacter(CharacterType.TP_CORNELL_BCM);
					}
				}
			}
			GameManager core24 = GM.Core;
			bool flag29 = (object)GM.Core == null;
			bool flag30 = core24._playerOptions == null;
			PlayerOptionsData config22 = core24._playerOptions.Config;
			bool flag31 = config22 == null;
			if (config22._003CSelectedStage_003Ek__BackingField == StageType.TP_CASTLE)
			{
				GameManager core25 = GM.Core;
				bool flag32 = (object)GM.Core == null;
				bool flag33 = core25._playerOptions == null;
				PlayerOptionsData config23 = core25._playerOptions.Config;
				bool flag34 = config23 == null;
				bool flag35 = config23._003CCollectedItems_003Ek__BackingField == null;
				if (((Dictionary<EnemyType, int>)(object)config23._003CCollectedItems_003Ek__BackingField).get_Item(EnemyType.XLDEMON2) != 0)
				{
					GameManager core26 = GM.Core;
					bool flag36 = (object)GM.Core == null;
					bool flag37 = core26._playerOptions == null;
					PlayerOptionsData config24 = core26._playerOptions.Config;
					bool flag38 = config24 == null;
					if (config24._003CRunEnemies_003Ek__BackingField >= 100000)
					{
						if (characterController2._characterType != CharacterType.TP_ELIZABETH)
						{
							bool num15;
							bool num16;
							bool num17;
							bool num18;
							CharacterType characterType;
							PlayerOptions playerOptions2;
							if (characterController2._characterType != CharacterType.TP_OLROX)
							{
								if (characterController2._characterType != CharacterType.TP_DEATH)
								{
									if (characterController2._characterType == CharacterType.TP_DRACULA)
									{
										GameManager core27 = GM.Core;
										bool flag39 = (object)GM.Core == null;
										bool flag40 = core27._playerOptions == null;
										bool flag41 = core27._playerOptions.UnlockSecret(SecretType.tp_draculamega);
										GameManager core28 = GM.Core;
										bool flag42 = (object)GM.Core == null;
										bool flag43 = core28._playerOptions == null;
										core28._playerOptions.UnlockCharacter(CharacterType.TP_DRACULA_MEGA);
									}
									goto IL_0e48;
								}
								GameManager core29 = GM.Core;
								bool flag44 = (object)GM.Core == null;
								num15 = flag44;
								bool flag45 = core29._playerOptions == null;
								num16 = flag45;
								bool flag46 = core29._playerOptions.UnlockSecret(SecretType.tp_deathmega);
								GameManager core30 = GM.Core;
								bool flag47 = (object)GM.Core == null;
								num17 = flag47;
								bool flag48 = core30._playerOptions == null;
								num18 = flag48;
								characterType = CharacterType.TP_DEATH_MEGA;
								playerOptions2 = core30._playerOptions;
							}
							else
							{
								GameManager core31 = GM.Core;
								bool flag49 = (object)GM.Core == null;
								num15 = flag49;
								bool flag50 = core31._playerOptions == null;
								num16 = flag50;
								bool flag51 = core31._playerOptions.UnlockSecret(SecretType.tp_olroxmega);
								GameManager core32 = GM.Core;
								bool flag52 = (object)GM.Core == null;
								num17 = flag52;
								bool flag53 = core32._playerOptions == null;
								num18 = flag53;
								characterType = CharacterType.TP_OLROX_MEGA;
								playerOptions2 = core32._playerOptions;
							}
							playerOptions2.UnlockCharacter(characterType);
						}
						else
						{
							GameManager core33 = GM.Core;
							bool flag54 = (object)GM.Core == null;
							bool flag55 = core33._playerOptions == null;
							bool flag56 = core33._playerOptions.UnlockSecret(SecretType.tp_elizabethmega);
							GameManager core34 = GM.Core;
							bool flag57 = (object)GM.Core == null;
							bool flag58 = core34._playerOptions == null;
							core34._playerOptions.UnlockCharacter(CharacterType.TP_ELIZABETH_MEGA);
						}
					}
				}
			}
			goto IL_0e48;
			IL_0e48:
			if (characterController2._characterType == CharacterType.TP_JULIA)
			{
				CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
				bool flag59 = (object)characterController2._weaponsManager == null;
				Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__4_6;
				if (_003C_003Ec._003C_003E9__4_6 == null)
				{
					Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__4_6 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 1589;
						return obj26 == null;
					});
					list3 = null;
					match = (Predicate<object>)predicate;
				}
				bool flag60 = ((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField == null;
				List<object> list5 = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField).FindAll(match);
				bool flag61 = list5 == null;
				if (list5._size >= 2)
				{
					GameManager core35 = GM.Core;
					bool flag62 = (object)GM.Core == null;
					bool flag63 = core35._playerOptions == null;
					bool flag64 = core35._playerOptions.UnlockSecret(SecretType.tp_familiar);
					GameManager core36 = GM.Core;
					bool flag65 = (object)GM.Core == null;
					bool flag66 = core36._playerOptions == null;
					bool flag67 = core36._playerOptions.UnlockSecret(SecretType.tp_innocent);
					GameManager core37 = GM.Core;
					bool flag68 = (object)GM.Core == null;
					bool flag69 = core37._playerOptions == null;
					core37._playerOptions.UnlockCharacter(CharacterType.TP_FAMILIARS);
					GameManager core38 = GM.Core;
					bool flag70 = (object)GM.Core == null;
					bool flag71 = core38._playerOptions == null;
					core38._playerOptions.UnlockCharacter(CharacterType.TP_INNOCENT_DEVILS);
				}
			}
			if (characterController2._characterType == CharacterType.TP_MARIAA)
			{
				CharacterWeaponsManager weaponsManager2 = characterController2._weaponsManager;
				bool flag72 = (object)characterController2._weaponsManager == null;
				Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__4_7;
				if (_003C_003Ec._003C_003E9__4_7 == null)
				{
					Predicate<Equipment> predicate2 = (_003C_003Ec._003C_003E9__4_7 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 29;
						return obj26 == null;
					});
					list3 = null;
					match2 = predicate2;
				}
				bool flag73 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField == null;
				Equipment equipment = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField.Find(match2);
				if (equipment != null)
				{
					GameManager core39 = GM.Core;
					bool flag74 = (object)GM.Core == null;
					ArcanaManager arcanaManager = core39._arcanaManager;
					bool flag75 = core39._arcanaManager == null;
					bool flag76 = arcanaManager._003CActiveArcanas_003Ek__BackingField == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
					if (obj6 != null)
					{
						GameManager core40 = GM.Core;
						bool flag77 = (object)GM.Core == null;
						bool flag78 = core40._playerOptions == null;
						bool flag79 = core40._playerOptions.UnlockSecret(SecretType.tp_mariab);
						GameManager core41 = GM.Core;
						bool flag80 = (object)GM.Core == null;
						bool flag81 = core41._playerOptions == null;
						core41._playerOptions.UnlockCharacter(CharacterType.TP_MARIAB);
					}
				}
			}
			bool flag82 = (object)characterController2._weaponsManager == null;
			Weapon weaponByType = characterController2._weaponsManager.GetWeaponByType(WeaponType.TP_UNIVERSITAS, searchHidden: true);
			bool flag83 = weaponByType;
			bool flag84 = !flag83;
			bool flag85 = true;
			if (!flag84)
			{
				GameManager core42 = GM.Core;
				bool flag86 = (object)GM.Core == null;
				bool flag87 = core42._playerOptions == null;
				bool flag88 = core42._playerOptions.UnlockSecret(SecretType.tp_celia);
				GameManager core43 = GM.Core;
				bool flag89 = (object)GM.Core == null;
				bool flag90 = core43._playerOptions == null;
				core43._playerOptions.UnlockCharacter(CharacterType.TP_CELIA);
				flag85 = false;
			}
			bool flag91 = config18._003CUnlockedCharacters_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			ThosePeople_CustomAchivementHandleing thosePeople_CustomAchivementHandleing;
			if (obj7 == null)
			{
				GameManager core44 = GM.Core;
				bool flag92 = (object)GM.Core == null;
				characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core44._003CSurvivedSeconds_003Ek__BackingField;
				Stage stage = core44._stage;
				bool flag93 = (object)core44._stage == null;
				StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
				bool flag94 = stage._003CStageMods_003Ek__BackingField == null;
				float num19 = core44._003CSurvivedSeconds_003Ek__BackingField;
				bool flag95 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num19) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8);
				bool flag96 = !flag95;
				object obj9 = (_003F?)stageModifiers._003CTimeLimit_003Ek__BackingField & flag96;
				bool flag97 = obj9 == null;
				thosePeople_CustomAchivementHandleing = thosePeople_CustomAchivementHandleing2;
				if (!flag97)
				{
					bool flag98 = thosePeople_CustomAchivementHandleing2.CheckForFireTypeWeapons(null);
					bool flag99 = !flag98;
					flag85 = false;
					thosePeople_CustomAchivementHandleing = thosePeople_CustomAchivementHandleing2;
					if (!flag99)
					{
						GameManager core45 = GM.Core;
						bool flag100 = (object)GM.Core == null;
						bool flag101 = core45._playerOptions == null;
						bool flag102 = core45._playerOptions.UnlockSecret(SecretType.tp_dario);
						GameManager core46 = GM.Core;
						bool flag103 = (object)GM.Core == null;
						bool flag104 = core46._playerOptions == null;
						core46._playerOptions.UnlockCharacter(CharacterType.TP_DARIO);
						flag85 = false;
						thosePeople_CustomAchivementHandleing = thosePeople_CustomAchivementHandleing2;
					}
				}
			}
			else
			{
				thosePeople_CustomAchivementHandleing = thosePeople_CustomAchivementHandleing2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			if (obj10 == null)
			{
				bool flag105 = thosePeople_CustomAchivementHandleing.CheckForCoatOfArmsEvos(null);
				bool flag106 = !flag105;
				flag85 = false;
				if (!flag106)
				{
					GameManager core47 = GM.Core;
					bool flag107 = (object)GM.Core == null;
					bool flag108 = core47._playerOptions == null;
					bool flag109 = core47._playerOptions.UnlockSecret(SecretType.tp_hammer);
					GameManager core48 = GM.Core;
					bool flag110 = (object)GM.Core == null;
					bool flag111 = core48._playerOptions == null;
					core48._playerOptions.UnlockCharacter(CharacterType.TP_HAMMER);
					flag85 = false;
				}
			}
			GameManager core49 = GM.Core;
			bool flag112 = (object)GM.Core == null;
			bool flag113 = core49._playerOptions == null;
			PlayerOptionsData config25 = core49._playerOptions.Config;
			bool flag114 = config25 == null;
			bool flag115 = config25._003CSelectedStage_003Ek__BackingField != StageType.TOWER;
			list3 = null;
			if (!flag115)
			{
				CharacterWeaponsManager weaponsManager3 = characterController2._weaponsManager;
				bool flag116 = (object)characterController2._weaponsManager == null;
				Func<Equipment, bool> predicate3 = _003C_003Ec._003C_003E9__4_1;
				bool flag117 = _003C_003Ec._003C_003E9__4_1 != null;
				list3 = null;
				if (!flag117)
				{
					Func<Equipment, bool> func = (_003C_003Ec._003C_003E9__4_1 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 1575;
						return obj26 == null;
					});
					list3 = null;
					predicate3 = func;
				}
				bool flag118 = Enumerable.Any(((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField, predicate3);
				bool flag119 = !flag118;
				flag85 = false;
				if (!flag119)
				{
					GameManager core50 = GM.Core;
					bool flag120 = (object)GM.Core == null;
					bool flag121 = core50._playerOptions == null;
					bool flag122 = core50._playerOptions.UnlockSecret(SecretType.aljibarian);
					GameManager core51 = GM.Core;
					bool flag123 = (object)GM.Core == null;
					bool flag124 = core51._playerOptions == null;
					core51._playerOptions.UnlockCharacter(CharacterType.TP_ANNETTE);
					flag85 = false;
				}
			}
			List<WeaponType> list6 = new List<WeaponType>();
			bool flag125 = list6 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494E50");
			List<WeaponType>.Enumerator enumerator2 = (List<WeaponType>.Enumerator)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11037 @ rax_v726+10]");
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)0;
			int num20 = 0;
			while (enumerator3.MoveNext())
			{
				_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass4_1();
				bool flag126 = CS_0024_003C_003E8__locals10 == null;
				CS_0024_003C_003E8__locals10.weapon = (WeaponType)characterController;
				CharacterWeaponsManager weaponsManager4 = characterController2._weaponsManager;
				bool flag127 = (object)characterController2._weaponsManager == null;
				bool flag128 = Enumerable.Any(predicate: delegate(Equipment x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj26 = x._equipmentType - CS_0024_003C_003E8__locals10.weapon;
					return obj26 == null;
				}, source: ((EquipmentManager)weaponsManager4)._003CActiveEquipment_003Ek__BackingField);
				bool flag129 = !flag128;
				list3 = null;
				flag85 = false;
				if (!flag129)
				{
					num20++;
					list3 = null;
					flag85 = false;
				}
			}
			GameManager core52 = GM.Core;
			bool flag130 = (object)GM.Core == null;
			bool flag131 = core52._playerOptions == null;
			PlayerOptionsData config26 = core52._playerOptions.Config;
			bool flag132 = config26 == null;
			if (config26._003CSelectedStage_003Ek__BackingField == StageType.WAREHOUSE && num20 >= 6)
			{
				GameManager core53 = GM.Core;
				bool flag133 = (object)GM.Core == null;
				bool flag134 = core53._playerOptions == null;
				bool flag135 = core53._playerOptions.UnlockSecret(SecretType.enviousblade);
				GameManager core54 = GM.Core;
				bool flag136 = (object)GM.Core == null;
				bool flag137 = core54._playerOptions == null;
				core54._playerOptions.UnlockCharacter(CharacterType.TP_HUGH);
				flag85 = false;
			}
			if (characterController2._characterType == CharacterType.TP_MINA)
			{
				GameManager core55 = GM.Core;
				bool flag138 = (object)GM.Core == null;
				bool flag139 = core55._playerOptions == null;
				PlayerOptionsData config27 = core55._playerOptions.Config;
				bool flag140 = config27 == null;
				bool flag141 = config27._003CKillCount_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
				if (obj12 != null)
				{
					GameManager core56 = GM.Core;
					bool flag142 = (object)GM.Core == null;
					bool flag143 = core56._playerOptions == null;
					bool flag144 = core56._playerOptions.UnlockSecret(SecretType.odakira);
					GameManager core57 = GM.Core;
					bool flag145 = (object)GM.Core == null;
					bool flag146 = core57._playerOptions == null;
					core57._playerOptions.UnlockCharacter(CharacterType.TP_GENYA);
					flag85 = false;
				}
			}
			if (characterController2._characterType == CharacterType.TP_SHANOA)
			{
				GameManager core58 = GM.Core;
				bool flag147 = (object)GM.Core == null;
				bool flag148 = core58._playerOptions == null;
				PlayerOptionsData config28 = core58._playerOptions.Config;
				bool flag149 = config28 == null;
				bool flag150 = config28._003CKillCount_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
				if (obj13 != null)
				{
					GameManager core59 = GM.Core;
					bool flag151 = (object)GM.Core == null;
					bool flag152 = core59._playerOptions == null;
					PlayerOptionsData config29 = core59._playerOptions.Config;
					bool flag153 = config29 == null;
					if (config29._003CSelectedStage_003Ek__BackingField == StageType.BONEZONE)
					{
						GameManager core60 = GM.Core;
						bool flag154 = (object)GM.Core == null;
						bool flag155 = core60._playerOptions == null;
						PlayerOptionsData config30 = core60._playerOptions.Config;
						bool flag156 = config30 == null;
						if (config30._003CSelectedInverse_003Ek__BackingField)
						{
							GameManager core61 = GM.Core;
							bool flag157 = (object)GM.Core == null;
							bool flag158 = core61._playerOptions == null;
							bool flag159 = core61._playerOptions.UnlockSecret(SecretType.ismycontrollerbroken);
							GameManager core62 = GM.Core;
							bool flag160 = (object)GM.Core == null;
							bool flag161 = core62._playerOptions == null;
							core62._playerOptions.UnlockCharacter(CharacterType.TP_STONESKULL);
							flag85 = false;
						}
					}
				}
			}
			if (characterController2._characterType == CharacterType.TP_ELIZABETH)
			{
				GameManager core63 = GM.Core;
				bool flag162 = (object)GM.Core == null;
				bool flag163 = core63._playerOptions == null;
				PlayerOptionsData config31 = core63._playerOptions.Config;
				bool flag164 = config31 == null;
				if (config31._003CSelectedStage_003Ek__BackingField == StageType.CHAPEL)
				{
					PlayerModifierStats playerStats = characterController2._playerStats;
					bool flag165 = characterController2._playerStats == null;
					if (playerStats._003CUsedRevivals_003Ek__BackingField >= 6)
					{
						GameManager core64 = GM.Core;
						bool flag166 = (object)GM.Core == null;
						bool flag167 = core64._playerOptions == null;
						bool flag168 = core64._playerOptions.UnlockSecret(SecretType.inadvertentresurrector);
						GameManager core65 = GM.Core;
						bool flag169 = (object)GM.Core == null;
						bool flag170 = core65._playerOptions == null;
						core65._playerOptions.UnlockCharacter(CharacterType.TP_DROLTA);
						flag85 = false;
					}
				}
			}
			GameManager core66 = GM.Core;
			bool flag171 = (object)GM.Core == null;
			bool flag172 = core66._playerOptions == null;
			PlayerOptionsData config32 = core66._playerOptions.Config;
			bool flag173 = config32 == null;
			if (config32._003CSelectedStage_003Ek__BackingField == StageType.SINKING)
			{
				CharacterWeaponsManager weaponsManager5 = characterController2._weaponsManager;
				bool flag174 = (object)characterController2._weaponsManager == null;
				Func<Equipment, bool> predicate4 = _003C_003Ec._003C_003E9__4_2;
				if (_003C_003Ec._003C_003E9__4_2 == null)
				{
					Func<Equipment, bool> func2 = (_003C_003Ec._003C_003E9__4_2 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 1602;
						return obj26 == null;
					});
					list3 = null;
					predicate4 = func2;
				}
				bool flag175 = Enumerable.Any(((EquipmentManager)weaponsManager5)._003CActiveEquipment_003Ek__BackingField, predicate4);
				bool flag176 = !flag175;
				flag85 = false;
				if (!flag176)
				{
					GameManager core67 = GM.Core;
					bool flag177 = (object)GM.Core == null;
					bool flag178 = core67._playerOptions == null;
					bool flag179 = core67._playerOptions.UnlockSecret(SecretType.dampmage);
					GameManager core68 = GM.Core;
					bool flag180 = (object)GM.Core == null;
					bool flag181 = core68._playerOptions == null;
					core68._playerOptions.UnlockCharacter(CharacterType.TP_WATERMAGICIAN);
					flag85 = false;
				}
			}
			if (characterController2._characterType == CharacterType.TP_CARRIE)
			{
				GameManager core69 = GM.Core;
				bool flag182 = (object)GM.Core == null;
				bool flag183 = core69._playerOptions == null;
				PlayerOptionsData config33 = core69._playerOptions.Config;
				bool flag184 = config33 == null;
				bool flag185 = config33._003CKillCount_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
				if (obj14 != null)
				{
					GameManager core70 = GM.Core;
					bool flag186 = (object)GM.Core == null;
					bool flag187 = core70._playerOptions == null;
					bool flag188 = core70._playerOptions.UnlockSecret(SecretType.gemstonelegacy);
					GameManager core71 = GM.Core;
					bool flag189 = (object)GM.Core == null;
					bool flag190 = core71._playerOptions == null;
					core71._playerOptions.UnlockCharacter(CharacterType.TP_ACTRISE);
					flag85 = false;
				}
			}
			if (characterController2._characterType == CharacterType.TP_SOMA)
			{
				GameManager core72 = GM.Core;
				bool flag191 = (object)GM.Core == null;
				bool flag192 = core72._playerOptions == null;
				PlayerOptionsData config34 = core72._playerOptions.Config;
				bool flag193 = config34 == null;
				bool flag194 = config34._003CKillCount_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
				if (obj15 != null)
				{
					PlayerOptions core73 = (PlayerOptions)(object)GM.Core;
					bool flag195 = (object)GM.Core == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12892 @ rcx_v561 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
					enumerator2 = (List<WeaponType>.Enumerator)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12892 @ rcx_v561 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
					if (!(0f < 1800f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12892 @ rcx_v561 (VampireSurvivors.Objects.PlayerOptions)+90]");
						bool flag196 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12892 @ rcx_v561 (VampireSurvivors.Objects.PlayerOptions)+90]");
						PlayerOptionsData config35 = ((PlayerOptions)0).Config;
						bool flag197 = config35 == null;
						if (config35._003CSelectedStage_003Ek__BackingField == StageType.TP_CASTLE)
						{
							GameManager core74 = GM.Core;
							bool flag198 = (object)GM.Core == null;
							bool flag199 = core74._playerOptions == null;
							bool flag200 = core74._playerOptions.UnlockSecret(SecretType.abouttimeyoushowedup);
							GameManager core75 = GM.Core;
							bool flag201 = (object)GM.Core == null;
							bool flag202 = core75._playerOptions == null;
							core75._playerOptions.UnlockCharacter(CharacterType.TP_ZEPHYR);
							flag85 = false;
						}
					}
				}
			}
			if (characterController2._characterType == CharacterType.TP_FLEAMAN)
			{
				GameManager core76 = GM.Core;
				bool flag203 = (object)GM.Core == null;
				bool flag204 = core76._playerOptions == null;
				PlayerOptionsData config36 = core76._playerOptions.Config;
				bool flag205 = config36 == null;
				bool flag206 = config36._003CKillCount_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
				if (obj16 != null)
				{
					GameManager core77 = GM.Core;
					bool flag207 = (object)GM.Core == null;
					bool flag208 = core77._playerOptions == null;
					PlayerOptionsData config37 = core77._playerOptions.Config;
					bool flag209 = config37 == null;
					bool flag210 = config37._003CKillCount_003Ek__BackingField == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
					if (obj17 != null)
					{
						GameManager core78 = GM.Core;
						bool flag211 = (object)GM.Core == null;
						bool flag212 = core78._playerOptions == null;
						bool flag213 = core78._playerOptions.UnlockSecret(SecretType.platonicpartners);
						GameManager core79 = GM.Core;
						bool flag214 = (object)GM.Core == null;
						bool flag215 = core79._playerOptions == null;
						core79._playerOptions.UnlockCharacter(CharacterType.TP_SLOGRA_AND_GAIBON);
					}
				}
			}
			if (characterController2._characterType == CharacterType.TP_NATHAN)
			{
				CharacterWeaponsManager weaponsManager6 = characterController2._weaponsManager;
				bool flag216 = (object)characterController2._weaponsManager == null;
				Func<Equipment, bool> predicate5 = _003C_003Ec._003C_003E9__4_3;
				if (_003C_003Ec._003C_003E9__4_3 == null)
				{
					Func<Equipment, bool> func3 = (_003C_003Ec._003C_003E9__4_3 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 1603;
						return obj26 == null;
					});
					list3 = null;
					predicate5 = func3;
				}
				if (Enumerable.Any(((EquipmentManager)weaponsManager6)._003CActiveEquipment_003Ek__BackingField, predicate5))
				{
					GameManager core80 = GM.Core;
					bool flag217 = (object)GM.Core == null;
					bool flag218 = core80._playerOptions == null;
					bool flag219 = core80._playerOptions.UnlockSecret(SecretType.bloodisthicker);
					GameManager core81 = GM.Core;
					bool flag220 = (object)GM.Core == null;
					bool flag221 = core81._playerOptions == null;
					core81._playerOptions.UnlockCharacter(CharacterType.TP_MORRIS);
				}
			}
			if (characterController2._characterType == CharacterType.TP_SIMON)
			{
				CharacterWeaponsManager weaponsManager7 = characterController2._weaponsManager;
				bool flag222 = (object)characterController2._weaponsManager == null;
				Func<Equipment, bool> predicate6 = _003C_003Ec._003C_003E9__4_4;
				if (_003C_003Ec._003C_003E9__4_4 == null)
				{
					Func<Equipment, bool> func4 = (_003C_003Ec._003C_003E9__4_4 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj26 = x._equipmentType - 1612;
						return obj26 == null;
					});
					list3 = null;
					predicate6 = func4;
				}
				if (Enumerable.Any(((EquipmentManager)weaponsManager7)._003CActiveEquipment_003Ek__BackingField, predicate6))
				{
					GameManager core82 = GM.Core;
					bool flag223 = (object)GM.Core == null;
					bool flag224 = core82._playerOptions == null;
					bool flag225 = core82._playerOptions.UnlockSecret(SecretType.vaccuumproserpina);
					GameManager core83 = GM.Core;
					bool flag226 = (object)GM.Core == null;
					bool flag227 = core83._playerOptions == null;
					core83._playerOptions.UnlockCharacter(CharacterType.TP_PERSEPHONE);
				}
			}
			bool flag228 = characterController2._characterType != CharacterType.TP_JONATHAN;
			characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)enumerator2;
			if (!flag228)
			{
				GameManager core84 = GM.Core;
				bool flag229 = (object)GM.Core == null;
				bool flag230 = core84._playerOptions == null;
				PlayerOptionsData config38 = core84._playerOptions.Config;
				bool flag231 = config38 == null;
				bool flag232 = config38._003CRunEnemies_003Ek__BackingField != 0;
				characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)enumerator2;
				if (!flag232)
				{
					GameManager core85 = GM.Core;
					bool flag233 = (object)GM.Core == null;
					bool flag234 = core85._playerOptions == null;
					PlayerOptionsData config39 = core85._playerOptions.Config;
					bool flag235 = config39 == null;
					bool flag236 = config39._003CSelectedStage_003Ek__BackingField != StageType.MOLISE;
					characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)enumerator2;
					if (!flag236)
					{
						PlayerOptions core86 = (PlayerOptions)(object)GM.Core;
						bool flag237 = (object)GM.Core == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14163 @ rcx_v514 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
						characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14163 @ rcx_v514 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
						if (!(0f < 300f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14163 @ rcx_v514 (VampireSurvivors.Objects.PlayerOptions)+90]");
							bool flag238 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14163 @ rcx_v514 (VampireSurvivors.Objects.PlayerOptions)+90]");
							bool flag239 = ((PlayerOptions)0).UnlockSecret(SecretType.nomancandefy);
							GameManager core87 = GM.Core;
							bool flag240 = (object)GM.Core == null;
							bool flag241 = core87._playerOptions == null;
							core87._playerOptions.UnlockCharacter(CharacterType.TP_ASTARTE);
						}
					}
				}
			}
			CharacterWeaponsManager weaponsManager8 = characterController2._weaponsManager;
			bool flag242 = (object)characterController2._weaponsManager == null;
			Func<object, bool> predicate7 = (Func<object, bool>)_003C_003Ec._003C_003E9__4_5;
			if (_003C_003Ec._003C_003E9__4_5 == null)
			{
				Func<Equipment, bool> func5 = (_003C_003Ec._003C_003E9__4_5 = delegate(Equipment e)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)e == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj26 = e._equipmentType - 1613;
					return obj26 == null;
				});
				list3 = null;
				predicate7 = (Func<object, bool>)func5;
			}
			object source = Enumerable.FirstOrDefault(((EquipmentManager)weaponsManager8)._003CActiveEquipment_003Ek__BackingField, predicate7);
			Equipment equipment2 = Enumerable.FirstOrDefault((IEnumerable<Equipment>)source, (Func<Equipment, bool>)(object)typeof(TP_Frog2_Weapon));
			if (!(equipment2 != null))
			{
				continue;
			}
			bool flag243 = (object)equipment2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15519 @ rax_v752 (VampireSurvivors.Objects.Equipment)+230]");
			if ((nint)0 >= (nint)5000)
			{
				GameManager core88 = GM.Core;
				bool flag244 = (object)GM.Core == null;
				bool flag245 = core88._playerOptions == null;
				PlayerOptionsData config40 = core88._playerOptions.Config;
				bool flag246 = config40 == null;
				if (config40._003CSelectedStage_003Ek__BackingField == StageType.FOREST)
				{
					GameManager core89 = GM.Core;
					bool flag247 = (object)GM.Core == null;
					bool flag248 = core89._playerOptions == null;
					bool flag249 = core89._playerOptions.UnlockSecret(SecretType.hophophophophophophophophophophophophop);
					GameManager core90 = GM.Core;
					bool flag250 = (object)GM.Core == null;
					bool flag251 = core90._playerOptions == null;
					core90._playerOptions.UnlockCharacter(CharacterType.TP_JIANGSHI);
				}
			}
		}
		GameManager core91 = GM.Core;
		PlayerOptionsData config41 = core91._playerOptions.Config;
		bool flag252 = !((float)config41._003CLibraryMerchantGoldSpent_003Ek__BackingField > 42000f);
		int num21 = (int)list3;
		if (!flag252)
		{
			GameManager core92 = GM.Core;
			PlayerOptionsData config42 = core92._playerOptions.Config;
			bool flag253 = core92._playerOptions.UnlockSecret(SecretType.tp_librarian, config42);
			GameManager core93 = GM.Core;
			core93._playerOptions.UnlockCharacter(CharacterType.TP_LIBRARIAN);
			num21 = 0;
		}
		if (((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.STAGEKILLER) != 0 && ((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.XLARMOR_GREEN) != 0)
		{
			if (((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.D_SKULL) == 0)
			{
				GameManager core94 = GM.Core;
				core94._playerOptions.UnlockCharacter(CharacterType.TP_STELLA_AND_LORETTA);
			}
			if (((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.DIRECTER) == 0)
			{
				GameManager core95 = GM.Core;
				core95._playerOptions.UnlockCharacter(CharacterType.TP_LORETTA_AND_STELLA);
			}
			if (((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.D_MASK_GREED) == 0)
			{
				GameManager core96 = GM.Core;
				core96._playerOptions.UnlockCharacter(CharacterType.TP_JONATHAN_AND_CHARLOTTE);
			}
			if (((Dictionary<EnemyType, int>)(object)config18._003CUnlockedCharacters_003Ek__BackingField).get_Item(EnemyType.D_MASK_VOID) == 0)
			{
				GameManager core97 = GM.Core;
				core97._playerOptions.UnlockCharacter(CharacterType.TP_CHARLOTTE_AND_JONATHAN);
			}
		}
		List<SecretType> list7 = new List<SecretType>();
		int num22 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MOON_MASK2);
		int num23 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MOON_MASK3);
		int num24 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MOON_MASK5);
		int num25 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MOON_BAT_PROJECTILE);
		int num26 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MOON_SHADE);
		int num27 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_XLMADDENER);
		int num28 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MASK_GOLD);
		int num29 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MASK_SILVER);
		int num30 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MASK_LEFT);
		int num31 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.MASK_RIGHT);
		int num32 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_NOOB);
		int num33 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_WEREWOLF2);
		int num34 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.FANGEL3);
		int num35 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_FANGEL3);
		int num36 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_DROWNER_NORMAL);
		int num37 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.TRAINEE_B);
		int num38 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.KALI1);
		int num39 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.KALI2);
		int num40 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.KALI2_FAST);
		int num41 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.SUCCUBUS);
		int num42 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_SUCCUBUS);
		int num43 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_STALKER_NORMAL);
		int num44 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.TRAINEE_G);
		int num45 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.ARMOR_FIRE);
		int num46 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.ARMOR_SWORD);
		int num47 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.XLARMOR_GOLD);
		int num48 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.XLARMOR_GREEN);
		int num49 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_XLARMOR_GREEN);
		int num50 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_TRICKSTER_NORMAL);
		int num51 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.TRAINEE_P);
		int num52 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.DEMON);
		int num53 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.DEMON_FAST);
		int num54 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.XLDEMON);
		int num55 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.XLDEMON2);
		int num56 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.XLARCHDEMON);
		int num57 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.BOSS_XLARCHDEMON);
		int num58 = ((Dictionary<EnemyType, int>)(object)list7).get_Item(EnemyType.POLTER_GEM);
		List<CharacterType> list8 = new List<CharacterType>();
		int num59 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.STAGEKILLER);
		int num60 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.XLARMOR_GREEN);
		int num61 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.TRAINEE_B);
		int num62 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.FANGEL2);
		int num63 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_CLUSTER_COINS);
		int num64 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_MASK_CITY);
		int num65 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_NOOB);
		int num66 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.MS_KAPPA);
		int num67 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.MS_MIKOS);
		int num68 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_TRICKSTER_NORMAL);
		int num69 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_XLDETH);
		int num70 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_GIANT_MIMIC1);
		int num71 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.UNDEADHEAD);
		int num72 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_MASK_MOON);
		int num73 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_GIANT_MIMIC3);
		int num74 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BULLET_EYE);
		int num75 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BULLET_EGG);
		int num76 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_MASK_VOLCANO);
		int num77 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_MASK_SUN);
		int num78 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.XXLBAT);
		int num79 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_WEREWOLF2);
		int num80 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_XLCRAB_RASH);
		int num81 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.TRAINEE);
		int num82 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_CLUSTER_GEMS);
		int num83 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_DROWNER_RASH);
		int num84 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_GIANT_MIMIC2);
		int num85 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_WEAK_REAPER_A);
		int num86 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_EYE2);
		int num87 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.TRAINEE_ANY);
		int num88 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.BOSS_XLDEATH2);
		int num89 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.UNDEADEYES);
		int num90 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_MASK_WINDS);
		int num91 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_WEAK_REAPER_C);
		int num92 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_WEAK_REAPER_D);
		int num93 = ((Dictionary<EnemyType, int>)(object)list8).get_Item(EnemyType.D_WEAK_REAPER_B);
		object obj18 = 0;
		object obj19 = default(object);
		object obj20 = default(object);
		object obj22 = default(object);
		object obj24 = default(object);
		float time = default(float);
		while (true)
		{
			bool flag254 = obj19 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ stack_-E8_v10+1C]");
			nint num94;
			if (obj20 == null)
			{
				object obj21 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ stack_-E8_v10+18]");
				if ((nint)obj21 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ stack_-E8_v10+10]");
					object obj23 = 0;
					obj22++;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
					if (obj24 != null)
					{
						obj18 = 1;
						continue;
					}
					num94 = 0;
					break;
				}
			}
			bool flag255 = obj19 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ stack_-E8_v10+1C]");
			bool flag256 = obj20 != null;
			bool flag257 = obj18 == null;
			num94 = 0;
			if (!flag257)
			{
				GameManager core98 = GM.Core;
				bool flag258 = core98._playerOptions.UnlockSecret(SecretType.tp_chaos);
				GameManager core99 = GM.Core;
				core99._playerOptions.UnlockCharacter(CharacterType.TP_CHAOS);
				bool flag259 = !flag258;
				num94 = unchecked((nint)null);
				if (!flag259)
				{
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Detune = -1000f,
						Rate = 0.5f
					}, 0f, 10, time);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Detune = -1000f,
						Rate = 0.45f
					}, 0f, 10, time);
					PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ThingFound, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Detune = -1000f,
						Rate = 0.4f
					}, 0f, 10, time);
					num21 = 10;
					num94 = unchecked((nint)null);
				}
			}
			break;
		}
		GameManager core100 = GM.Core;
		PlayerOptionsData config43 = core100._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A420");
		object obj25 = default(object);
		bool flag260 = obj25 == null;
		int num95 = 0;
		if (!flag260)
		{
			GameManager core101 = GM.Core;
			PlayerOptionsData config44 = core101._playerOptions.Config;
			int num96 = config44._003CKillCount_003Ek__BackingField.get_Item(EnemyType.SKELANGUE);
			num95 = num96;
		}
		GameManager core102 = GM.Core;
		PlayerOptionsData config45 = core102._playerOptions.Config;
		int num97 = config45._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.SKULOROSSO);
		if (num97 >= 0)
		{
			GameManager core103 = GM.Core;
			PlayerOptionsData config46 = core103._playerOptions.Config;
			int num98 = config46._003CKillCount_003Ek__BackingField.get_Item(EnemyType.SKULOROSSO);
			num95 += num98;
		}
		if (num95 >= 10000)
		{
			GameManager core104 = GM.Core;
			bool flag261 = core104._playerOptions.UnlockSecret(SecretType.skelenun);
			GameManager core105 = GM.Core;
			core105._playerOptions.UnlockCharacter(CharacterType.TP_TERA);
		}
		List<WeaponType> list9 = new List<WeaponType>();
		int num99 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1600);
		int num100 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1601);
		int num101 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1602);
		int num102 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1603);
		int num103 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1609);
		int num104 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1605);
		int num105 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1604);
		int num106 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1606);
		int num107 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1610);
		int num108 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1611);
		int num109 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1607);
		int num110 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1612);
		int num111 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1608);
		int num112 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1613);
		int num113 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1618);
		int num114 = ((Dictionary<EnemyType, int>)(object)list9).get_Item((EnemyType)1616);
		Func<WeaponType, bool> predicate8 = delegate
		{
			//IL_0070: Expected I4, but got O
			if (CS_0024_003C_003E8__locals12.playerOptions != null)
			{
				PlayerOptionsData config47 = CS_0024_003C_003E8__locals12.playerOptions.Config;
				if (config47 != null && config47._003CCollectedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					bool result = default(bool);
					return result;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		if (Enumerable.All(list9, predicate8))
		{
			GameManager core106 = GM.Core;
			bool flag262 = core106._playerOptions.UnlockSecret(SecretType.theysmelldifferent);
			GameManager core107 = GM.Core;
			core107._playerOptions.UnlockCharacter(CharacterType.TP_FAKE_TRIO);
		}
	}

	public bool Check_MorningStar(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_053d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0565: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_058d: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05b5: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0369: Expected O, but got I
		//IL_0391: Expected O, but got I4
		//IL_045f: Expected O, but got I
		//IL_04ca: Expected O, but got I
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1406);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1406;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1489);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1489;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1446);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1446;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1506);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1506;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1442);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1442;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1491);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1491;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1444);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1444;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1436);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1436;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj17 = 0;
			object obj21 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0688;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0688;
				IL_0688:
				object obj18 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj18 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj19 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v22+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num9).Add(WeaponType.VOID);
						object obj20 = obj21 - -1;
						bool flag5 = obj20 == null;
						flag4 = !flag5;
					}
					obj17++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj22 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj22 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	public bool Check_Spellbook(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_053d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0565: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_058d: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05b5: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0369: Expected O, but got I
		//IL_0391: Expected O, but got I4
		//IL_045f: Expected O, but got I
		//IL_04ca: Expected O, but got I
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1456);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1456;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1458);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1458;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1460);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1460;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1462);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1462;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1464);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1464;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1466);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1466;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1470);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1470;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1468);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1468;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj17 = 0;
			object obj21 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0688;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0688;
				IL_0688:
				object obj18 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj18 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj19 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v22+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num9).Add(WeaponType.VOID);
						object obj20 = obj21 - -1;
						bool flag5 = obj20 == null;
						flag4 = !flag5;
					}
					obj17++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj22 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj22 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	public bool Check_CoatOfArms(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_088d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_08b5: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_08dd: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0905: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_092d: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0955: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_097d: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_09a5: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_09cd: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_0a1d: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_0a45: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_0a6d: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_0a95: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_0abd: Expected O, but got I
		//IL_06b9: Expected O, but got I
		//IL_06e1: Expected O, but got I4
		//IL_07af: Expected O, but got I
		//IL_081a: Expected O, but got I
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1426);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1426;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1424);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1424;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1422);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1422;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1432);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1432;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1414);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1414;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1493);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1493;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1450);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1450;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1434);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1434;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v28+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v30+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v32+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)69);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 69;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v34+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj33 = 0;
			object obj37 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0b18;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0b18;
				IL_0b18:
				object obj34 = obj33;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj34 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj35 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v38+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num17).Add(WeaponType.VOID);
						object obj36 = obj37 - -1;
						bool flag5 = obj36 == null;
						flag4 = !flag5;
					}
					obj33++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj38 = obj33;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj38 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	public bool Check_Diabologue(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_053d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0565: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_058d: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05b5: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0369: Expected O, but got I
		//IL_0391: Expected O, but got I4
		//IL_045f: Expected O, but got I
		//IL_04ca: Expected O, but got I
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1428);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1428;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1430);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1430;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1472);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1472;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1474);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1474;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1453);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1453;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1440);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1440;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1500;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1404);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1404;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj17 = 0;
			object obj21 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0688;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0688;
				IL_0688:
				object obj18 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj18 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj19 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v22+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num9).Add(WeaponType.VOID);
						object obj20 = obj21 - -1;
						bool flag5 = obj20 == null;
						flag4 = !flag5;
					}
					obj17++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj22 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj22 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	public bool Check_SpectralSword(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_053d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0565: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_058d: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05b5: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0369: Expected O, but got I
		//IL_0391: Expected O, but got I4
		//IL_045f: Expected O, but got I
		//IL_04ca: Expected O, but got I
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1420);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1420;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1412);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1412;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1418);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1418;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1416);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1416;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1495);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1495;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1502);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1502;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1504);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1504;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1509);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1509;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj17 = 0;
			object obj21 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0688;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0688;
				IL_0688:
				object obj18 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj18 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj19 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v22+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num9).Add(WeaponType.VOID);
						object obj20 = obj21 - -1;
						bool flag5 = obj20 == null;
						flag4 = !flag5;
					}
					obj17++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj22 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj22 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	public bool Check_CandyboxSkins(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_03ff: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0427: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_022b: Expected O, but got I
		//IL_0253: Expected O, but got I4
		//IL_0321: Expected O, but got I
		//IL_038c: Expected O, but got I
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1408);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1408;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1410);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1410;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1407);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1407;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1409);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1409;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1507);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1507;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag = (nint)0 <= (nint)0;
		bool flag2 = true;
		if (!flag)
		{
			bool flag3 = true;
			object obj11 = 0;
			object obj15 = default(object);
			bool flag7;
			bool result = default(bool);
			do
			{
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_04d2;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_04d2;
				IL_04d2:
				object obj12 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj12 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj13 = 0;
					List<WeaponType> list2 = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4;
					if ((nint)0 == 0)
					{
						flag4 = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v16+20+v97 @ rsi_v6*4]");
						((List<WeaponType>)num6).Add(WeaponType.VOID);
						object obj14 = obj15 - -1;
						bool flag5 = obj14 == null;
						flag4 = !flag5;
					}
					obj11++;
					bool flag6 = !flag4;
					flag2 = false;
					if (!flag6)
					{
						flag2 = flag3;
					}
					object obj16 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					flag7 = (nint)obj16 < 0;
					flag3 = flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag7);
		}
		return flag2;
	}

	private bool CheckForFireTypeWeapons(VampireSurvivors.Objects.Characters.CharacterController currentCharacter)
	{
		//IL_0105: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		CharacterWeaponsManager weaponsManager = currentCharacter._weaponsManager;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> first = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			CharacterWeaponsManager weaponsManager2 = currentCharacter._weaponsManager;
			if (((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField != null)
			{
				List<object> second = new List<object>(((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField);
				IEnumerable<Equipment> enumerable = Enumerable.Concat((IEnumerable<Equipment>)first, (IEnumerable<Equipment>)second);
				if (enumerable != null)
				{
					List<object> list = new List<object>(enumerable);
					object obj = 0;
					object obj2 = 0;
					while (true)
					{
						if ((nint)obj2 < list._size)
						{
							if ((nint)obj >= list._size)
							{
								break;
							}
							object[] items = list._items;
							object obj3 = items[obj];
							WeaponType[] fireDamageTypes = EnemyController.FireDamageTypes;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v19 (System.Object)+48]");
							if (Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)fireDamageTypes, (System.Int32Enum)0))
							{
								obj++;
								obj2 = obj;
								continue;
							}
							return false;
						}
						return true;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			Exception ex2 = System.Linq.Error.ArgumentNull("source");
			throw ex2;
		}
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
	}

	private bool CheckForCoatOfArmsEvos(VampireSurvivors.Objects.Characters.CharacterController currentCharacter)
	{
		//IL_012e: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_0869: Expected O, but got I
		//IL_01f2: Expected O, but got I
		//IL_089d: Expected O, but got I
		//IL_025c: Expected O, but got I
		//IL_08c5: Expected O, but got I
		//IL_02c6: Expected O, but got I
		//IL_08ed: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_0915: Expected O, but got I
		//IL_039a: Expected O, but got I
		//IL_093d: Expected O, but got I
		//IL_0404: Expected O, but got I
		//IL_0965: Expected O, but got I
		//IL_046e: Expected O, but got I
		//IL_098d: Expected O, but got I
		//IL_04d8: Expected O, but got I
		//IL_09b5: Expected O, but got I
		//IL_0542: Expected O, but got I
		//IL_09dd: Expected O, but got I
		//IL_05ac: Expected O, but got I
		//IL_0a05: Expected O, but got I
		//IL_0616: Expected O, but got I
		//IL_0656: Expected O, but got I4
		//IL_065f: Expected O, but got I4
		//IL_0668: Expected O, but got I4
		//IL_0781: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Expected O, but got Unknown
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Expected O, but got Unknown
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Expected O, but got Unknown
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Expected O, but got Unknown
		CharacterWeaponsManager weaponsManager = currentCharacter._weaponsManager;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> first = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			CharacterWeaponsManager weaponsManager2 = currentCharacter._weaponsManager;
			if (((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField != null)
			{
				List<object> second = new List<object>(((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField);
				IEnumerable<Equipment> enumerable = Enumerable.Concat((IEnumerable<Equipment>)first, (IEnumerable<Equipment>)second);
				if (enumerable != null)
				{
					List<object> list = new List<object>(enumerable);
					List<WeaponType> list2 = new List<WeaponType>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v18+18]");
					if (num >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1426);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj2 = (nint)0 + (nint)1;
						_ = 1426;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v20+18]");
					if (num2 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1422);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj4 = (nint)0 + (nint)1;
						_ = 1422;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v22+18]");
					if (num3 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1414);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj6 = (nint)0 + (nint)1;
						_ = 1414;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v24+18]");
					if (num4 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1424);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj8 = (nint)0 + (nint)1;
						_ = 1424;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v26+18]");
					if (num5 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1493);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj10 = (nint)0 + (nint)1;
						_ = 1493;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v28+18]");
					if (num6 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1450);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj12 = (nint)0 + (nint)1;
						_ = 1450;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v30+18]");
					if (num7 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1432);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj14 = (nint)0 + (nint)1;
						_ = 1432;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v32+18]");
					if (num8 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1434);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj16 = (nint)0 + (nint)1;
						_ = 1434;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v34+18]");
					if (num9 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1601);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj18 = (nint)0 + (nint)1;
						_ = 1601;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v36+18]");
					if (num10 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1600);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj20 = (nint)0 + (nint)1;
						_ = 1600;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v38+18]");
					if (num11 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1602);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj22 = (nint)0 + (nint)1;
						_ = 1602;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v40+18]");
					if (num12 >= 0)
					{
						((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1603);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj24 = (nint)0 + (nint)1;
						_ = 1603;
					}
					if (list._size >= 6)
					{
						object obj25 = 0;
						object obj26 = 0;
						object obj27 = 0;
						object obj31 = default(object);
						while (true)
						{
							if ((nint)obj26 < list._size)
							{
								if ((nint)obj27 >= list._size)
								{
									break;
								}
								object[] items = list._items;
								object obj28 = items[obj27];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if ((nint)0 == 0)
								{
									obj27++;
									object obj29 = obj25 + 1;
									obj29 = obj25;
									obj25 = obj29;
									obj26 = obj27;
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj30 = obj31 - -1;
								bool flag = obj30 == null;
								bool flag2 = !flag;
								obj27++;
								object obj32 = obj25 + 1;
								if (!flag2)
								{
									obj32 = obj25;
								}
								obj25 = obj32;
								obj26 = obj27;
								continue;
							}
							object obj33 = obj25 - 6;
							object obj34 = obj25 ^ 6;
							object obj35 = obj25 ^ obj33;
							object obj36 = obj34 & obj35;
							bool flag3 = (nint)obj36 < 0;
							bool flag4 = (nint)obj33 < 0;
							return flag4 == flag3;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new IndexOutOfRangeException();
					}
					return false;
				}
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			Exception ex2 = System.Linq.Error.ArgumentNull("source");
			throw ex2;
		}
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
	}

	public unsafe bool Weapon_Unlock_Damage_Achievement(AchievementManager achievementManager, List<WeaponType> weapons, float damage = 1000f)
	{
		//IL_0069: Expected O, but got Ref
		//IL_0085: Expected O, but got I4
		//IL_02ac: Invalid comparison between O and F4
		//IL_00d5: Expected I, but got O
		//IL_00e3: Expected I, but got O
		//IL_00f3: Expected O, but got I
		//IL_0173: Expected O, but got I4
		//IL_00c3: Expected I, but got O
		//IL_012f: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		if (achievementManager != null && achievementManager._Characters != null)
		{
			AchievementManager achievementManager2 = achievementManager;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			List<WeaponType> list = default(List<WeaponType>);
			List<WeaponType>.Enumerator enumerator3 = default(List<WeaponType>.Enumerator);
			while (true)
			{
				if (enumerator.MoveNext())
				{
					bool flag = list == null;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
					if (flag)
					{
						break;
					}
					object obj = 0;
					while (enumerator3.MoveNext())
					{
						Equipment playerEquipment = AchivementManagerSupport.GetPlayerEquipment(null, WeaponType.VOID, checkRemovedEquipment: true);
						nint num;
						if ((object)playerEquipment == null)
						{
							num = unchecked((nint)null);
							achievementManager2 = null;
							goto IL_0261;
						}
						num = (nint)playerEquipment;
						nint num2 = (nint)typeof(Weapon);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj4;
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v40+FFFFFFF8+v573 @ rax_v36*8]");
							if (0 == (nint)typeof(Weapon))
							{
								obj4 = 1;
								goto IL_023a;
							}
						}
						obj4 = 0;
						goto IL_023a;
						IL_0261:
						if (achievementManager2 != null && achievementManager2.AchievementsUnlockedOnPlatform != null)
						{
							object obj5 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rbx_v6 (VampireSurvivors.Achievements.AchievementManager)+134]");
							obj = obj5 + 0;
						}
						continue;
						IL_023a:
						bool flag2 = obj4 == null;
						achievementManager2 = null;
						if (!flag2)
						{
							achievementManager2 = (AchievementManager)(object)playerEquipment;
						}
						goto IL_0261;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)damage))
					{
						return true;
					}
					continue;
				}
				return false;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}
}
