using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Achievements;

public class BaseGame_CustomAchivementHandleing : ICustomAchievements
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public WeaponType[] passives;

		public int i;

		public Predicate<Equipment> _003C_003E9__0;

		internal bool _003CRunSecretsCheck_003Eb__0(Equipment x)
		{
			//IL_0078: Expected I4, but got O
			//IL_0056: Expected O, but got I
			WeaponType[] array = passives;
			int num = i;
			if (i < array.Length)
			{
				WeaponType equipmentType = x._equipmentType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v3 (VampireSurvivors.Data.WeaponType[])+20+v43 @ rax_v4 (System.Int32)*4]");
				object obj = (nint)equipmentType - (nint)0;
				return obj == null;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
	}

	public unsafe List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
	{
		//IL_0044: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_00f7: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0276: Expected O, but got I4
		//IL_0291: Expected O, but got I
		//IL_02bf: Expected O, but got Ref
		//IL_0354: Expected O, but got I
		//IL_372c: Expected O, but got Ref
		//IL_0380: Expected O, but got Ref
		//IL_0426: Expected O, but got I
		//IL_042f: Expected O, but got I4
		//IL_039e: Expected O, but got I
		//IL_3782: Expected O, but got Ref
		//IL_044b: Expected O, but got Ref
		//IL_0401: Expected O, but got I
		//IL_37d0: Expected O, but got I
		//IL_0584: Expected O, but got Ref
		//IL_05b5: Expected O, but got I
		//IL_05c5: Expected O, but got I
		//IL_06c0: Expected O, but got I
		//IL_06d0: Expected O, but got I
		//IL_084e: Expected I, but got O
		//IL_0644: Expected O, but got I
		//IL_0747: Expected O, but got I
		//IL_0516: Expected O, but got I
		//IL_089c: Expected O, but got I
		//IL_08ac: Expected O, but got I
		//IL_052b: Expected O, but got I
		//IL_093c: Expected O, but got I
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_091b: Expected O, but got I
		//IL_0b78: Expected O, but got I
		//IL_0b88: Expected O, but got I
		//IL_0a92: Expected O, but got I
		//IL_0aa2: Expected O, but got I
		//IL_0bff: Expected O, but got I
		//IL_0b19: Expected O, but got I
		//IL_3866: Expected O, but got I
		//IL_3876: Expected O, but got I
		//IL_0c8d: Expected O, but got I
		//IL_38be: Expected O, but got I
		//IL_38ce: Expected O, but got I
		//IL_0d1b: Expected O, but got I
		//IL_3916: Expected O, but got I
		//IL_3926: Expected O, but got I
		//IL_0da9: Expected O, but got I
		//IL_396e: Expected O, but got I
		//IL_397e: Expected O, but got I
		//IL_0e37: Expected O, but got I
		//IL_39c6: Expected O, but got I
		//IL_39d6: Expected O, but got I
		//IL_0ec5: Expected O, but got I
		//IL_3a1e: Expected O, but got I
		//IL_3a2e: Expected O, but got I
		//IL_0f53: Expected O, but got I
		//IL_3a76: Expected O, but got I
		//IL_3a86: Expected O, but got I
		//IL_0fe1: Expected O, but got I
		//IL_3ace: Expected O, but got I
		//IL_3ade: Expected O, but got I
		//IL_106f: Expected O, but got I
		//IL_3b26: Expected O, but got I
		//IL_3b36: Expected O, but got I
		//IL_10fd: Expected O, but got I
		//IL_3b7e: Expected O, but got I
		//IL_3b8e: Expected O, but got I
		//IL_118b: Expected O, but got I
		//IL_3bd6: Expected O, but got I
		//IL_3be6: Expected O, but got I
		//IL_1219: Expected O, but got I
		//IL_3c2e: Expected O, but got I
		//IL_3c3e: Expected O, but got I
		//IL_12a7: Expected O, but got I
		//IL_3c86: Expected O, but got I
		//IL_3c96: Expected O, but got I
		//IL_1335: Expected O, but got I
		//IL_3cde: Expected O, but got I
		//IL_3cee: Expected O, but got I
		//IL_13c3: Expected O, but got I
		//IL_3d36: Expected O, but got I
		//IL_3d46: Expected O, but got I
		//IL_1451: Expected O, but got I
		//IL_3d8e: Expected O, but got I
		//IL_3d9e: Expected O, but got I
		//IL_14df: Expected O, but got I
		//IL_3de6: Expected O, but got I
		//IL_3df6: Expected O, but got I
		//IL_156d: Expected O, but got I
		//IL_3e3e: Expected O, but got I
		//IL_3e4e: Expected O, but got I
		//IL_1604: Expected O, but got I
		//IL_3e7c: Expected O, but got I4
		//IL_3e85: Expected O, but got I4
		//IL_3e8e: Expected O, but got I4
		//IL_1739: Expected O, but got I
		//IL_17d6: Expected I, but got O
		//IL_1c76: Expected O, but got I4
		//IL_1824: Unknown result type (might be due to invalid IL or missing references)
		//IL_1829: Expected O, but got Unknown
		//IL_1832: Unknown result type (might be due to invalid IL or missing references)
		//IL_1837: Expected O, but got Unknown
		//IL_1ce8: Expected I, but got O
		//IL_1d19: Expected O, but got I
		//IL_1c00: Expected I, but got O
		//IL_1c29: Expected I, but got O
		//IL_1c32: Expected O, but got I4
		//IL_1c3b: Expected O, but got I4
		//IL_1d43: Expected O, but got I
		//IL_1ccc: Expected O, but got I4
		//IL_1cd5: Expected O, but got I4
		//IL_3f55: Expected O, but got I
		//IL_1e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e53: Expected O, but got Unknown
		//IL_1eb3: Expected I, but got O
		//IL_1ee4: Expected O, but got I
		//IL_1f0e: Expected O, but got I
		//IL_1ea0: Expected O, but got I4
		//IL_1f3d: Expected O, but got I
		//IL_1fd1: Expected O, but got I
		//IL_2030: Expected I, but got O
		//IL_2061: Expected O, but got I
		//IL_208b: Expected O, but got I
		//IL_20ac: Expected I, but got O
		//IL_20dd: Expected O, but got I
		//IL_20f3: Expected O, but got I
		//IL_21eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f0: Expected O, but got Unknown
		//IL_229d: Expected I, but got O
		//IL_22ce: Expected O, but got I
		//IL_22e4: Expected O, but got I
		//IL_23dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e1: Expected O, but got Unknown
		//IL_24ef: Expected I, but got O
		//IL_2506: Expected O, but got I4
		//IL_2514: Expected O, but got I4
		//IL_251c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2521: Expected O, but got Unknown
		//IL_26be: Expected I, but got O
		//IL_26ef: Expected O, but got I
		//IL_2a97: Expected O, but got I4
		//IL_2aa5: Expected I, but got O
		//IL_2ad6: Expected O, but got I
		//IL_2bc7: Expected I, but got O
		//IL_2bf8: Expected O, but got I
		//IL_2b0e: Expected O, but got I
		//IL_2794: Expected I, but got O
		//IL_27c5: Expected O, but got I
		//IL_2c2f: Expected O, but got I
		//IL_286d: Expected I, but got O
		//IL_289e: Expected O, but got I
		//IL_28e2: Expected O, but got I
		//IL_290f: Expected O, but got I
		//IL_2937: Expected O, but got I
		//IL_2940: Expected O, but got I4
		//IL_40f3: Expected O, but got Ref
		//IL_2964: Expected O, but got Ref
		//IL_2a41: Expected O, but got Ref
		//IL_2982: Expected O, but got I
		//IL_2a01: Expected O, but got I4
		List<AchievementType> list = new List<AchievementType>();
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		List<Equipment> list2;
		DataManager dataManager2;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rcx_v166 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rcx_v166 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rcx_v166 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					if (config._003CPassedGaeaEvent_003Ek__BackingField)
					{
						if (list == null)
						{
							goto IL_3489;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
					}
					nint num = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v106 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num2 = 0;
					GameManager core2 = GM.Core;
					bool flag = (object)GM.Core == null;
					core = (PlayerOptions)num2;
					if (!flag)
					{
						core = core2._playerOptions;
						if (core2._playerOptions != null)
						{
							PlayerOptionsData config2 = core2._playerOptions.Config;
							if (config2 != null)
							{
								if (!(config2._003CTrainHazardEnemiesHit_003Ek__BackingField < 25120f))
								{
									if (list == null)
									{
										goto IL_3489;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
									core = (PlayerOptions)(object)list;
								}
								if (playerOptions != null)
								{
									PlayerOptionsData config3 = playerOptions.Config;
									bool flag2 = config3 == null;
									core = playerOptions;
									if (!flag2)
									{
										bool flag3 = config3._003CDestroyedCount_003Ek__BackingField == null;
										core = playerOptions;
										if (!flag3)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B180");
											object obj = 0;
											Dictionary<PropType, int>.Enumerator enumerator = default(Dictionary<PropType, int>.Enumerator);
											while (enumerator.MoveNext())
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2051 @ rax_v111+10]");
												object obj2 = (nint)0 >> 32;
												obj += obj2;
											}
											if ((nint)obj >= 20)
											{
												bool flag4 = list == null;
												core = (PlayerOptions)(&enumerator);
												if (flag4)
												{
													goto IL_3489;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
											}
											list2 = new List<Equipment>();
											AchievementManager achievementManager2 = default(AchievementManager);
											bool flag5 = achievementManager2 == null;
											core = (PlayerOptions)(object)list2;
											if (!flag5)
											{
												bool flag6 = achievementManager2._Characters == null;
												core = (PlayerOptions)(object)list2;
												if (!flag6)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2511 @ rax_v118+10]");
													object obj3 = 0;
													dataManager2 = dataManager;
													List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
													while (enumerator2.MoveNext())
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2511 @ rax_v118+10]");
														bool flag7 = (nint)0 == 0;
														core = (PlayerOptions)(&enumerator2);
														if (!flag7)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ xmm1_v49+C0]");
															core = (PlayerOptions)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ xmm1_v49+C0]");
															if ((nint)0 != 0)
															{
																if (list2 != null)
																{
																	((List<object>)(object)list2).InsertRange(list2._size, (IEnumerable<object>)core._signalBus);
																	dataManager2 = (DataManager)0;
																	continue;
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													bool flag8 = list2 == null;
													core = (PlayerOptions)(&enumerator2);
													if (!flag8)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2909 @ rax_v122+10]");
														object obj4 = 0;
														object obj5 = 0;
														List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
														while (enumerator3.MoveNext())
														{
															bool flag9 = dataManager == null;
															Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator3);
															if (!flag9)
															{
																Dictionary<WeaponType, List<WeaponData>> convertedWeapons = dataManager.GetConvertedWeapons();
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2909 @ rax_v122+10]");
																if ((nint)0 != 0)
																{
																	if (convertedWeapons != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ xmm1_v50+48]");
																		object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
																		if (obj6 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1938 @ rax_v442 (System.Object)+18]");
																			if ((nint)0 > (nint)0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1938 @ rax_v442 (System.Object)+10]");
																				object obj7 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ rax_v443+20]");
																				object obj8 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1798 @ rcx_v282+60]");
																				if ((nint)0 != 0)
																				{
																					obj5++;
																				}
																				continue;
																			}
																			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
																			dictionary = null;
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														bool flag10 = (nint)obj5 < 6;
														core = (PlayerOptions)(&enumerator3);
														if (flag10)
														{
															goto IL_3790;
														}
														bool flag11 = list == null;
														core = (PlayerOptions)(&enumerator3);
														if (!flag11)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
															core = (PlayerOptions)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
															object obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																if (0 >= (nint)core.PowerUpPurchased)
																{
																	((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)107);
																	core = (PlayerOptions)(object)list;
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	object obj10 = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	if (0 >= (nint)core.PowerUpPurchased)
																	{
																		goto IL_37b2;
																	}
																	_ = 107;
																}
																goto IL_3790;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_3489;
		IL_400d:
		PlayerOptionsData playerOptionsData;
		BaseGame_CustomAchivementHandleing baseGame_CustomAchivementHandleing = default(BaseGame_CustomAchivementHandleing);
		PlayerOptionsData playerOptionsData2;
		if (playerOptionsData != null)
		{
			core = (PlayerOptions)(object)playerOptionsData._003CContentGroupSealedWeapons_003Ek__BackingField;
			if (playerOptionsData._003CContentGroupSealedWeapons_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v60 (System.Collections.Generic.LinkedList`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj11 = 0 - core.PowerUpPurchased;
				if ((nint)obj11 >= 80)
				{
					if (list == null)
					{
						goto IL_3489;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
				}
				int num3 = baseGame_CustomAchivementHandleing.CountKilledEnemiesAndVariants(EnemyType.EX_BATS_COUNTER, playerOptions, dataManager);
				if (num3 >= 161616)
				{
					bool flag12 = list == null;
					core = (PlayerOptions)(object)baseGame_CustomAchivementHandleing;
					if (flag12)
					{
						goto IL_3489;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
				}
				int num4 = baseGame_CustomAchivementHandleing.CountKilledEnemiesAndVariants(EnemyType.EX_SHOOTING_ENEMIES_COUNTER, playerOptions, dataManager);
				System.Random random = new System.Random(num4);
				bool flag13 = random == null;
				core = (PlayerOptions)(object)random;
				if (!flag13)
				{
					nint num5 = (nint)random;
					PlayerOptions playerOptions2 = (PlayerOptions)random.Next(1, 10);
					object obj12 = num4 * 4;
					object obj13 = num4 + obj12;
					object obj14 = obj13 + obj13;
					object obj15 = obj14 - (object)playerOptions2;
					bool flag14 = (nint)obj15 < 251096;
					core = playerOptions2;
					if (!flag14)
					{
						bool flag15 = list == null;
						core = playerOptions2;
						if (flag15)
						{
							goto IL_3489;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
						core = (PlayerOptions)(object)list;
					}
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData2 = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_404f;
							}
						}
						playerOptionsData2 = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData2 = playerOptions._hostGameConfig;
					}
					goto IL_404f;
				}
			}
		}
		goto IL_3489;
		IL_415c:
		PlayerOptionsData playerOptionsData3;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_37f7;
					}
				}
				playerOptionsData3 = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_37f7;
		IL_37c0:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A37E6]");
		core = (PlayerOptions)0;
		PlayerOptionsData playerOptionsData4;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData4 = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_37d5;
					}
				}
				playerOptionsData4 = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData4 = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData4 = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_37d5;
		IL_2a06:
		float num6 = 1800f;
		int num7 = 0;
		UnityEngine.Object obj17 = default(UnityEngine.Object);
		UnityEngine.Object obj16 = obj17;
		goto IL_406c;
		IL_406c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4660 @ r14_v57 (UnityEngine.Object)+58]");
		if ((nint)0 != 0)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			object obj19 = default(object);
			while (enumerator4.MoveNext())
			{
				object obj18 = 0;
				nint num8 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6832 @ rax_v223 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num9 = 0;
				GameManager core3 = GM.Core;
				bool flag16 = (object)GM.Core == null;
				EggFloat eggFloat = (EggFloat)num9;
				if (!flag16)
				{
					if (!(core3._003CSurvivedSeconds_003Ek__BackingField < 1200f))
					{
						eggFloat = (EggFloat)num9;
						throw new NullReferenceException();
					}
					nint num10 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6874 @ rax_v226 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num11 = 0;
					GameManager core4 = GM.Core;
					bool flag17 = (object)GM.Core == null;
					eggFloat = (EggFloat)num11;
					if (!flag17)
					{
						if (!(core4._003CSurvivedSeconds_003Ek__BackingField < num6))
						{
							eggFloat = (EggFloat)num11;
							throw new NullReferenceException();
						}
						PlayerOptionsData config4 = playerOptions.Config;
						bool flag18 = config4 == null;
						eggFloat = (EggFloat)(object)playerOptions;
						if (!flag18)
						{
							eggFloat = (EggFloat)(object)config4._003CCollectedItems_003Ek__BackingField;
							if (config4._003CCollectedItems_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
								if (obj19 != null)
								{
									throw new NullReferenceException();
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return list;
		}
		goto IL_3489;
		IL_1cda:
		nint num12 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6067 @ rax_v171 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num13 = 0;
		GameManager core5 = GM.Core;
		bool flag19 = (object)GM.Core == null;
		core = (PlayerOptions)num13;
		PlayerOptionsData playerOptionsData5;
		if (!flag19)
		{
			bool flag20 = core5._levelUpFactory == null;
			core = (PlayerOptions)num13;
			if (!flag20)
			{
				core = (PlayerOptions)num13;
				LinkedList<WeaponType> banishedWeapons = LevelUpFactory._banishedWeapons;
				if (LevelUpFactory._banishedWeapons != null)
				{
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData5 = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_3f7f;
								}
							}
							playerOptionsData5 = playerOptions._mainGameConfig;
						}
						else
						{
							playerOptionsData5 = playerOptions._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData5 = playerOptions._onlineClientWithRunDataConfig;
					}
					goto IL_3f7f;
				}
			}
		}
		goto IL_3489;
		IL_3f30:
		PlayerOptionsData playerOptionsData6;
		nint num14;
		if (playerOptionsData6 != null)
		{
			core = (PlayerOptions)(object)playerOptionsData6._003CAchievements_003Ek__BackingField;
			if (playerOptionsData6._003CAchievements_003Ek__BackingField != null)
			{
				nint num15;
				object obj21;
				PlayerOptions playerOptions3;
				if (core.PowerUpPurchased != null)
				{
					num14 = (nint)core.PowerUpPurchased;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj20 = default(object);
					bool flag21 = (nint)obj20 != -1;
					num15 = (nint)core.PowerUpPurchased;
					obj21 = 0;
					playerOptions3 = (PlayerOptions)129;
					if (flag21)
					{
						goto IL_1cda;
					}
				}
				bool flag22 = baseGame_CustomAchivementHandleing.CheckSigmaUnlock(playerOptions);
				bool flag23 = !flag22;
				num15 = num14;
				obj21 = 0;
				playerOptions3 = playerOptions;
				if (!flag23)
				{
					bool flag24 = list == null;
					core = (PlayerOptions)(object)baseGame_CustomAchivementHandleing;
					if (flag24)
					{
						goto IL_3489;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
					num15 = num14;
					obj21 = 0;
					playerOptions3 = (PlayerOptions)129;
				}
				goto IL_1cda;
			}
		}
		goto IL_3489;
		IL_3ed5:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		core = null;
		goto IL_4091;
		IL_37f7:
		if (playerOptionsData3 != null)
		{
			if (playerOptionsData3._003CRunCoins_003Ek__BackingField < 5000f)
			{
				goto IL_3814;
			}
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				core = (PlayerOptions)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					if (0 >= (nint)core.PowerUpPurchased)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)38);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj23 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						if (0 >= (nint)core.PowerUpPurchased)
						{
							goto IL_37b2;
						}
						_ = 38;
					}
					goto IL_3814;
				}
			}
		}
		goto IL_3489;
		IL_3489:
		throw new NullReferenceException();
		IL_37b2:
		return (List<AchievementType>)(object)new IndexOutOfRangeException();
		IL_37d5:
		if (playerOptionsData4 != null)
		{
			bool flag25 = playerOptionsData4._003CLifetimeHeal_003Ek__BackingField < 1000f;
			num14 = (nint)dataManager2;
			if (flag25)
			{
				goto IL_415c;
			}
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v217+18]");
					if (num16 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)37);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A37E6]");
						core = (PlayerOptions)0;
						num14 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj26 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v217+18]");
						if (num17 >= 0)
						{
							goto IL_37b2;
						}
						_ = 37;
						num14 = 0;
					}
					goto IL_415c;
				}
			}
		}
		goto IL_3489;
		IL_3f7f:
		PlayerOptionsData playerOptionsData7;
		if (playerOptionsData5 != null)
		{
			core = (PlayerOptions)(object)playerOptionsData5._003CContentGroupSealedWeapons_003Ek__BackingField;
			if (playerOptionsData5._003CContentGroupSealedWeapons_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v52 (System.Collections.Generic.LinkedList`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj27 = 0 - core.PowerUpPurchased;
				if ((nint)obj27 >= 10)
				{
					if (list == null)
					{
						goto IL_3489;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
					PlayerOptions playerOptions3 = (PlayerOptions)140;
				}
				nint num18 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6208 @ rax_v180 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num19 = 0;
				GameManager core6 = GM.Core;
				bool flag26 = (object)GM.Core == null;
				core = (PlayerOptions)num19;
				if (!flag26)
				{
					bool flag27 = core6._levelUpFactory == null;
					core = (PlayerOptions)num19;
					if (!flag27)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BE3F30");
						object obj28 = default(object);
						bool flag28 = obj28 == null;
						core = (PlayerOptions)num19;
						if (!flag28)
						{
							PlayerOptionsData config5 = playerOptions.Config;
							bool flag29 = config5 == null;
							core = playerOptions;
							if (!flag29)
							{
								List<WeaponType> list3 = config5._003CContentGroupSealedWeapons_003Ek__BackingField;
								bool flag30 = config5._003CContentGroupSealedWeapons_003Ek__BackingField == null;
								core = playerOptions;
								if (!flag30)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1469 @ rax_v182+18]");
									nint num20 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v184 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									object obj29 = num20 - 0;
									if ((nint)obj29 >= 20)
									{
										bool flag31 = list == null;
										core = playerOptions;
										if (flag31)
										{
											goto IL_3489;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
									}
									nint num21 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6235 @ rax_v186 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num22 = 0;
									GameManager core7 = GM.Core;
									bool flag32 = (object)GM.Core == null;
									core = (PlayerOptions)num22;
									if (!flag32)
									{
										bool flag33 = core7._levelUpFactory == null;
										core = (PlayerOptions)num22;
										if (!flag33)
										{
											nint num23 = (nint)typeof(LevelUpFactory);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1473 @ rax_v190 (Il2CppClass<VampireSurvivors.Framework.LevelUpFactory>)+B8]");
											nint num24 = 0;
											LinkedList<WeaponType> banishedWeapons2 = LevelUpFactory._banishedWeapons;
											bool flag34 = LevelUpFactory._banishedWeapons == null;
											core = (PlayerOptions)num24;
											if (!flag34)
											{
												core = (PlayerOptions)num24;
												if (playerOptions._onlineClientWithRunDataConfig == null)
												{
													if (playerOptions._hostGameConfig == null)
													{
														if (playerOptions._currentAdventureSaveData != null)
														{
															playerOptionsData7 = playerOptions._currentAdventureSaveData;
															if ((object)playerOptionsData7._003CSelectedAdventureType_003Ek__BackingField != null)
															{
																goto IL_3fc6;
															}
														}
														playerOptionsData7 = playerOptions._mainGameConfig;
													}
													else
													{
														playerOptionsData7 = playerOptions._hostGameConfig;
													}
												}
												else
												{
													playerOptionsData7 = playerOptions._onlineClientWithRunDataConfig;
												}
												goto IL_3fc6;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_3489;
		IL_3fc6:
		if (playerOptionsData7 != null)
		{
			core = (PlayerOptions)(object)playerOptionsData7._003CContentGroupSealedWeapons_003Ek__BackingField;
			if (playerOptionsData7._003CContentGroupSealedWeapons_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v57 (System.Collections.Generic.LinkedList`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj30 = 0 - core.PowerUpPurchased;
				if ((nint)obj30 >= 40)
				{
					if (list == null)
					{
						goto IL_3489;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
					core = (PlayerOptions)(object)list;
				}
				GameManager core8 = GM.Core;
				if ((object)GM.Core != null && core8._levelUpFactory != null)
				{
					nint num25 = (nint)typeof(LevelUpFactory);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rax_v198 (Il2CppClass<VampireSurvivors.Framework.LevelUpFactory>)+B8]");
					nint num26 = 0;
					LinkedList<WeaponType> banishedWeapons3 = LevelUpFactory._banishedWeapons;
					bool flag35 = LevelUpFactory._banishedWeapons == null;
					core = (PlayerOptions)num26;
					if (!flag35)
					{
						core = (PlayerOptions)num26;
						if (playerOptions._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions._hostGameConfig == null)
							{
								if (playerOptions._currentAdventureSaveData != null)
								{
									playerOptionsData = playerOptions._currentAdventureSaveData;
									if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_400d;
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
						goto IL_400d;
					}
				}
			}
		}
		goto IL_3489;
		IL_3790:
		if (list2._size >= 6)
		{
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				core = (PlayerOptions)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					if (0 >= (nint)core.PowerUpPurchased)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj32 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						if (0 >= (nint)core.PowerUpPurchased)
						{
							goto IL_37b2;
						}
						_ = 2;
					}
					goto IL_37c0;
				}
			}
			goto IL_3489;
		}
		goto IL_37c0;
		IL_2a78:
		num6 = 1800f;
		obj16 = obj17;
		goto IL_406c;
		IL_3814:
		List<AchievementType> list4 = new List<AchievementType>();
		bool flag36 = list4 == null;
		core = (PlayerOptions)(object)list4;
		if (!flag36)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				if (0 >= (nint)core.PowerUpPurchased)
				{
					((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)28);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					object obj34 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					if (0 >= (nint)core.PowerUpPurchased)
					{
						goto IL_37b2;
					}
					_ = 28;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				core = (PlayerOptions)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					if (0 >= (nint)core.PowerUpPurchased)
					{
						((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)29);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj36 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						if (0 >= (nint)core.PowerUpPurchased)
						{
							goto IL_37b2;
						}
						_ = 29;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
					core = (PlayerOptions)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					object obj37 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						if (0 >= (nint)core.PowerUpPurchased)
						{
							((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)30);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							object obj38 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							if (0 >= (nint)core.PowerUpPurchased)
							{
								goto IL_37b2;
							}
							_ = 30;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						core = (PlayerOptions)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
						object obj39 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							if (0 >= (nint)core.PowerUpPurchased)
							{
								((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)31);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj40 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								if (0 >= (nint)core.PowerUpPurchased)
								{
									goto IL_37b2;
								}
								_ = 31;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							core = (PlayerOptions)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							object obj41 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								if (0 >= (nint)core.PowerUpPurchased)
								{
									((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)42);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									object obj42 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									if (0 >= (nint)core.PowerUpPurchased)
									{
										goto IL_37b2;
									}
									_ = 42;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
								core = (PlayerOptions)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj43 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									if (0 >= (nint)core.PowerUpPurchased)
									{
										((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)43);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
										object obj44 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
										if (0 >= (nint)core.PowerUpPurchased)
										{
											goto IL_37b2;
										}
										_ = 43;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
									core = (PlayerOptions)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
									object obj45 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
										if (0 >= (nint)core.PowerUpPurchased)
										{
											((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)32);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
											object obj46 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
											if (0 >= (nint)core.PowerUpPurchased)
											{
												goto IL_37b2;
											}
											_ = 32;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
										core = (PlayerOptions)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
										object obj47 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
											if (0 >= (nint)core.PowerUpPurchased)
											{
												((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)33);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
												object obj48 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
												if (0 >= (nint)core.PowerUpPurchased)
												{
													goto IL_37b2;
												}
												_ = 33;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
											core = (PlayerOptions)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
											object obj49 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
												if (0 >= (nint)core.PowerUpPurchased)
												{
													((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)34);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
													object obj50 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
													if (0 >= (nint)core.PowerUpPurchased)
													{
														goto IL_37b2;
													}
													_ = 34;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
												core = (PlayerOptions)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
												object obj51 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
													if (0 >= (nint)core.PowerUpPurchased)
													{
														((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)35);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
														object obj52 = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
														if (0 >= (nint)core.PowerUpPurchased)
														{
															goto IL_37b2;
														}
														_ = 35;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
													core = (PlayerOptions)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
													object obj53 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
														if (0 >= (nint)core.PowerUpPurchased)
														{
															((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)71);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
															object obj54 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
															if (0 >= (nint)core.PowerUpPurchased)
															{
																goto IL_37b2;
															}
															_ = 71;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
														core = (PlayerOptions)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
														object obj55 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
															if (0 >= (nint)core.PowerUpPurchased)
															{
																((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)59);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																object obj56 = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																if (0 >= (nint)core.PowerUpPurchased)
																{
																	goto IL_37b2;
																}
																_ = 59;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
															core = (PlayerOptions)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
															object obj57 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																if (0 >= (nint)core.PowerUpPurchased)
																{
																	((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)36);
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	object obj58 = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	if (0 >= (nint)core.PowerUpPurchased)
																	{
																		goto IL_37b2;
																	}
																	_ = 36;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																_ = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																core = (PlayerOptions)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																object obj59 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	if (0 >= (nint)core.PowerUpPurchased)
																	{
																		((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)64);
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																		object obj60 = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																		if (0 >= (nint)core.PowerUpPurchased)
																		{
																			goto IL_37b2;
																		}
																		_ = 64;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																	_ = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																	core = (PlayerOptions)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																	object obj61 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																		if (0 >= (nint)core.PowerUpPurchased)
																		{
																			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)91);
																		}
																		else
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																			object obj62 = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																			if (0 >= (nint)core.PowerUpPurchased)
																			{
																				goto IL_37b2;
																			}
																			_ = 91;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																		_ = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																		core = (PlayerOptions)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																		object obj63 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																			if (0 >= (nint)core.PowerUpPurchased)
																			{
																				((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)55);
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																				object obj64 = (nint)0 + (nint)1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																				if (0 >= (nint)core.PowerUpPurchased)
																				{
																					goto IL_37b2;
																				}
																				_ = 55;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																			_ = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																			core = (PlayerOptions)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																			object obj65 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																				if (0 >= (nint)core.PowerUpPurchased)
																				{
																					((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)92);
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																					object obj66 = (nint)0 + (nint)1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																					if (0 >= (nint)core.PowerUpPurchased)
																					{
																						goto IL_37b2;
																					}
																					_ = 92;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																				_ = (nint)0 + (nint)1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																				core = (PlayerOptions)0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																				object obj67 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																					if (0 >= (nint)core.PowerUpPurchased)
																					{
																						((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)112);
																					}
																					else
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																						object obj68 = (nint)0 + (nint)1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																						if (0 >= (nint)core.PowerUpPurchased)
																						{
																							goto IL_37b2;
																						}
																						_ = 112;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
																					_ = (nint)0 + (nint)1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																					core = (PlayerOptions)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																					object obj69 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																						if (0 >= (nint)core.PowerUpPurchased)
																						{
																							((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)134);
																							core = (PlayerOptions)(object)list4;
																						}
																						else
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																							object obj70 = (nint)0 + (nint)1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																							if (0 >= (nint)core.PowerUpPurchased)
																							{
																								goto IL_37b2;
																							}
																							_ = 134;
																						}
																						object obj71 = 0;
																						object obj72 = 0;
																						object obj73 = 0;
																						object obj78 = default(object);
																						while (true)
																						{
																							object obj74 = obj73;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																							if ((nint)obj74 >= 0)
																							{
																								break;
																							}
																							PlayerOptionsData playerOptionsData8;
																							if (playerOptions._onlineClientWithRunDataConfig == null)
																							{
																								if (playerOptions._hostGameConfig == null)
																								{
																									if (playerOptions._currentAdventureSaveData != null)
																									{
																										playerOptionsData8 = playerOptions._currentAdventureSaveData;
																										if ((object)playerOptionsData8._003CSelectedAdventureType_003Ek__BackingField != null)
																										{
																											goto IL_3eb8;
																										}
																									}
																									playerOptionsData8 = playerOptions._mainGameConfig;
																								}
																								else
																								{
																									playerOptionsData8 = playerOptions._hostGameConfig;
																								}
																							}
																							else
																							{
																								playerOptionsData8 = playerOptions._onlineClientWithRunDataConfig;
																							}
																							goto IL_3eb8;
																							IL_3eb8:
																							if (playerOptionsData8 != null)
																							{
																								core = (PlayerOptions)(object)playerOptionsData8._003CAchievements_003Ek__BackingField;
																								object obj75 = obj71;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																								if ((nint)obj75 >= 0)
																								{
																									goto IL_3ed5;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																								object obj76 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
																								if ((nint)0 != 0)
																								{
																									object obj77 = obj71;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1455 @ rax_v347+18]");
																									if ((nint)obj77 >= 0)
																									{
																										goto IL_37b2;
																									}
																									if (playerOptionsData8._003CAchievements_003Ek__BackingField != null)
																									{
																										if (core.PowerUpPurchased == null)
																										{
																											break;
																										}
																										num14 = (nint)core.PowerUpPurchased;
																										core = (PlayerOptions)(object)core.RunGoldUpdated;
																										PlayerOptions.OnValueChanged runGoldUpdated = core.RunGoldUpdated;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1455 @ rax_v347+20+v199 @ r14_v50*4]");
																										((List<AchievementType>)(object)runGoldUpdated).Add(AchievementType.ReachLV5);
																										if ((nint)obj78 == -1)
																										{
																											break;
																										}
																										obj72++;
																										obj71++;
																										obj73 = obj71;
																										continue;
																									}
																								}
																							}
																							goto IL_3489;
																						}
																						object obj79 = obj72;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4731 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																						if ((nint)obj79 >= 0)
																						{
																							if (list == null)
																							{
																								goto IL_3489;
																							}
																							list.Add(AchievementType.EvolveAll);
																						}
																						if (baseGame_CustomAchivementHandleing.CheckForStage6Achievement(playerOptions))
																						{
																							bool flag37 = list == null;
																							core = (PlayerOptions)(object)baseGame_CustomAchivementHandleing;
																							if (flag37)
																							{
																								goto IL_3489;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																						}
																						List<StageType> validUnlockedHypers = Stage.GetValidUnlockedHypers();
																						bool flag38 = validUnlockedHypers == null;
																						core = null;
																						if (!flag38)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rax_v162 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
																							bool flag39 = (nint)0 < (nint)1;
																							core = null;
																							if (!flag39)
																							{
																								bool flag40 = list == null;
																								core = null;
																								if (flag40)
																								{
																									goto IL_3489;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																								core = (PlayerOptions)(object)list;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rax_v162 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
																							if ((nint)0 >= (nint)2)
																							{
																								if (list == null)
																								{
																									goto IL_3489;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																								core = (PlayerOptions)(object)list;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rax_v162 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
																							if ((nint)0 >= (nint)3)
																							{
																								if (list == null)
																								{
																									goto IL_3489;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																								core = (PlayerOptions)(object)list;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rax_v162 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
																							if ((nint)0 >= (nint)4)
																							{
																								if (list == null)
																								{
																									goto IL_3489;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																								core = (PlayerOptions)(object)list;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rax_v162 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
																							if ((nint)0 >= (nint)5)
																							{
																								if (list == null)
																								{
																									goto IL_3489;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																								core = (PlayerOptions)(object)list;
																							}
																							if (playerOptions._onlineClientWithRunDataConfig == null)
																							{
																								if (playerOptions._hostGameConfig == null)
																								{
																									if (playerOptions._currentAdventureSaveData != null)
																									{
																										playerOptionsData6 = playerOptions._currentAdventureSaveData;
																										if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
																										{
																											goto IL_3f30;
																										}
																									}
																									playerOptionsData6 = playerOptions._mainGameConfig;
																								}
																								else
																								{
																									playerOptionsData6 = playerOptions._hostGameConfig;
																								}
																							}
																							else
																							{
																								playerOptionsData6 = playerOptions._onlineClientWithRunDataConfig;
																							}
																							goto IL_3f30;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_3489;
		IL_404f:
		if (playerOptionsData2 != null)
		{
			core = (PlayerOptions)(object)playerOptionsData2._003CCollectedItems_003Ek__BackingField;
			if (playerOptionsData2._003CCollectedItems_003Ek__BackingField != null)
			{
				bool flag41 = core.PowerUpPurchased == null;
				num7 = 10;
				if (!flag41)
				{
					core = (PlayerOptions)(object)core.RunGoldUpdated;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj80 = default(object);
					bool flag42 = (nint)obj80 == -1;
					num7 = 0;
					if (!flag42)
					{
						nint num27 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6771 @ rax_v272 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num28 = 0;
						GameManager core9 = GM.Core;
						bool flag43 = (object)GM.Core == null;
						core = (PlayerOptions)num28;
						if (!flag43)
						{
							core = core9._playerOptions;
							if (core9._playerOptions != null)
							{
								PlayerOptionsData configDuringRun = core9._playerOptions.ConfigDuringRun;
								if (configDuringRun != null)
								{
									bool flag44 = !configDuringRun._003CSelectedInverse_003Ek__BackingField;
									num7 = 0;
									if (flag44)
									{
										goto IL_2a78;
									}
									nint num29 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6833 @ rax_v275 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num30 = 0;
									GameManager core10 = GM.Core;
									bool flag45 = (object)GM.Core == null;
									core = (PlayerOptions)num30;
									if (!flag45)
									{
										core = core10._playerOptions;
										if (core10._playerOptions != null)
										{
											PlayerOptionsData configDuringRun2 = core10._playerOptions.ConfigDuringRun;
											if (configDuringRun2 != null)
											{
												bool flag46 = configDuringRun2._003CSelectedStage_003Ek__BackingField != StageType.GREENACRES;
												num7 = 0;
												if (flag46)
												{
													goto IL_2a78;
												}
												nint num31 = (nint)typeof(GM);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6925 @ rax_v278 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
												nint num32 = 0;
												GameManager core11 = GM.Core;
												bool flag47 = (object)GM.Core == null;
												core = (PlayerOptions)num32;
												if (!flag47)
												{
													bool flag48 = core11._003CSurvivedSeconds_003Ek__BackingField < 1800f;
													num6 = 1800f;
													num7 = 0;
													obj16 = obj17;
													core = (PlayerOptions)num32;
													if (!flag48)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6723 @ stack_18 (UnityEngine.Object)+58]");
														bool flag49 = (nint)0 == 0;
														core = (PlayerOptions)num32;
														if (flag49)
														{
															goto IL_3489;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6938 @ rax_v280+10]");
														object obj81 = 0;
														object obj82 = 0;
														List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator5 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
														while (enumerator5.MoveNext())
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6938 @ rax_v280+10]");
															bool flag50 = (nint)0 == 0;
															List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator6 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator5);
															if (!flag50)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ xmm1_v53+C0]");
																core = (PlayerOptions)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ xmm1_v53+C0]");
																if ((nint)0 != 0)
																{
																	SignalBus signalBus = core._signalBus;
																	if (core._signalBus != null)
																	{
																		if ((nint)signalBus._localDeclarationMap <= 0)
																		{
																			obj82 = 1;
																			continue;
																		}
																		goto IL_2a06;
																	}
																	goto IL_4091;
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														bool flag51 = obj82 == null;
														num6 = 1800f;
														num7 = 0;
														obj16 = obj17;
														core = (PlayerOptions)(&enumerator5);
														if (!flag51)
														{
															bool flag52 = list == null;
															core = (PlayerOptions)(&enumerator5);
															if (flag52)
															{
																goto IL_3489;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
															num6 = 1800f;
															num7 = 0;
															obj16 = obj17;
														}
													}
													goto IL_406c;
												}
											}
										}
									}
								}
							}
						}
						goto IL_3489;
					}
				}
				goto IL_2a78;
			}
		}
		goto IL_3489;
		IL_4091:
		throw new NullReferenceException();
	}

	public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
	{
		//IL_00d4: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_02f3: Expected O, but got I
		//IL_0282: Expected O, but got I
		List<AchievementType> list = new List<AchievementType>();
		PlayerOptionsData config = playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_00b1;
			}
		}
		PlayerOptionsData config2 = playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
		object obj2 = default(object);
		if (obj2 != null)
		{
			goto IL_00b1;
		}
		goto IL_01ac;
		IL_02f8:
		return (List<AchievementType>)(object)new IndexOutOfRangeException();
		IL_01ac:
		PlayerOptionsData config3 = playerOptions.Config;
		List<ArcanaType> list3 = config3._003CUnlockedArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				PlayerOptionsData config4 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
				}
			}
		}
		return list;
		IL_00b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v7+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)73);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v7+18]");
			if (num2 >= 0)
			{
				goto IL_02f8;
			}
			_ = 73;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v17+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)76);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v17+18]");
			if (num4 >= 0)
			{
				goto IL_02f8;
			}
			_ = 76;
		}
		goto IL_01ac;
	}

	public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
	{
		//IL_0154: Expected O, but got I
		//IL_0098: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_026e: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_0388: Expected O, but got I
		//IL_03e2: Expected O, but got I
		//IL_062f: Expected O, but got I
		//IL_0689: Expected O, but got I
		List<AchievementType> list = new List<AchievementType>();
		PlayerOptionsData config = playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v58+18]");
				if (num >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)102);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v58+18]");
					if (num2 >= 0)
					{
						goto IL_06fe;
					}
					_ = 102;
				}
			}
		}
		if (CheckForStage6Achievement(playerOptions))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v52+18]");
			if (num3 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)136);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj5 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v52+18]");
				if (num4 >= 0)
				{
					goto IL_06fe;
				}
				_ = 136;
			}
		}
		PlayerOptionsData config2 = playerOptions.Config;
		List<ItemType> list3 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v50+18]");
				if (num5 >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)137);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					object obj8 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v50+18]");
					if (num6 >= 0)
					{
						goto IL_06fe;
					}
					_ = 137;
				}
			}
		}
		PlayerOptionsData config3 = playerOptions.Config;
		List<ItemType> list4 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj9 = default(object);
			if ((nint)obj9 != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v44+18]");
				if (num7 >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)138);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					object obj11 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v44+18]");
					if (num8 >= 0)
					{
						goto IL_06fe;
					}
					_ = 138;
				}
			}
		}
		PlayerOptionsData config4 = playerOptions.Config;
		List<AchievementType> list5 = config4._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj12 = default(object);
			if ((nint)obj12 != -1)
			{
				PlayerOptionsData config5 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj13 = default(object);
				if (obj13 == null)
				{
					PlayerOptionsData config6 = playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				}
			}
		}
		PlayerOptionsData config7 = playerOptions.Config;
		List<AchievementType> list6 = config7._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj14 = default(object);
			if ((nint)obj14 != -1)
			{
				PlayerOptionsData config8 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
				object obj15 = default(object);
				if (obj15 == null)
				{
					PlayerOptionsData config9 = playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
				}
			}
		}
		PlayerOptionsData config10 = playerOptions.Config;
		List<CharacterType> list7 = config10._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj16 = default(object);
			if ((nint)obj16 != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v22+18]");
				if (num9 >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)459);
					return list;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj18 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v22+18]");
				if (num10 >= 0)
				{
					goto IL_06fe;
				}
				_ = 459;
			}
		}
		return list;
		IL_06fe:
		return (List<AchievementType>)(object)new IndexOutOfRangeException();
	}

	public unsafe void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_002e: Expected O, but got I
		//IL_003f: Invalid comparison between I and F4
		//IL_053e: Expected F4, but got I4
		//IL_1712: Expected I, but got O
		//IL_1743: Expected O, but got I
		//IL_0063: Expected O, but got I
		//IL_0099: Expected O, but got I
		//IL_05d2: Expected I4, but got O
		//IL_0c9e: Expected I, but got O
		//IL_0ccf: Expected O, but got I
		//IL_0656: Expected I4, but got O
		//IL_065f: Expected O, but got I4
		//IL_1840: Expected O, but got I4
		//IL_0527: Expected F4, but got I4
		//IL_015c: Expected O, but got Ref
		//IL_1057: Expected I, but got O
		//IL_1088: Expected O, but got I
		//IL_1878: Expected O, but got F4
		//IL_0a99: Expected I, but got O
		//IL_0aca: Expected O, but got I
		//IL_0db3: Expected O, but got I
		//IL_0af4: Expected O, but got I
		//IL_0de9: Expected O, but got I
		//IL_1273: Expected I, but got O
		//IL_12a4: Expected O, but got I
		//IL_1165: Expected I, but got O
		//IL_1196: Expected O, but got I
		//IL_0e68: Invalid comparison between F4 and O
		//IL_0e86: Invalid comparison between F4 and I4
		//IL_0eaf: Expected O, but got I4
		//IL_0b90: Expected O, but got I
		//IL_0eda: Expected I, but got O
		//IL_0f0b: Expected O, but got I
		//IL_07b0: Expected I4, but got O
		//IL_0c3a: Expected O, but got I4
		//IL_0bef: Expected O, but got I
		//IL_17c6: Expected O, but got Ref
		//IL_0f92: Expected O, but got I
		//IL_1381: Expected I, but got O
		//IL_13b2: Expected O, but got I
		//IL_1492: Expected I, but got O
		//IL_14c3: Expected O, but got I
		//IL_098e: Expected O, but got I4
		//IL_0fcd: Expected O, but got I
		//IL_09a5: Expected O, but got I4
		//IL_1004: Expected O, but got I
		//IL_1044: Expected O, but got I
		//IL_154a: Expected O, but got I
		//IL_0a61: Expected O, but got I4
		//IL_158a: Expected O, but got I
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator;
		DataManager characters = default(DataManager);
		float num3;
		int i;
		int num;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
			enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+3E0]");
			if (0f < 900f)
			{
				goto IL_0535;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					if (config._003CSelectedStage_003Ek__BackingField != StageType.RASH)
					{
						goto IL_0535;
					}
					if (achievementManager != null)
					{
						characters = (DataManager)(object)achievementManager._Characters;
						if (achievementManager._Characters != null)
						{
							num = 0;
							enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)achievementManager._Characters;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator2.MoveNext())
							{
								int num2 = 0;
								core = (PlayerOptions)(&enumerator2);
								throw new NullReferenceException();
							}
							num3 = 0f;
							i = 0;
							goto IL_1704;
						}
					}
				}
			}
		}
		goto IL_1590;
		IL_0c90:
		nint num4 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1498 @ rax_v49 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num5 = 0;
		GameManager core2 = GM.Core;
		bool flag = (object)GM.Core == null;
		core = (PlayerOptions)num5;
		if (!flag)
		{
			core = core2._playerOptions;
			if (core2._playerOptions != null)
			{
				PlayerOptionsData config2 = core2._playerOptions.Config;
				if (config2 != null)
				{
					core = (PlayerOptions)(object)config2._003CPickupCount_003Ek__BackingField;
					if (config2._003CPickupCount_003Ek__BackingField != null)
					{
						int num6 = config2._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.CLOVER);
						if (num6 < 0)
						{
							goto IL_1049;
						}
						object obj = UnityEngine.Random.value;
						core = (PlayerOptions)(object)GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
							core = (PlayerOptions)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
								PlayerOptionsData config3 = ((PlayerOptions)0).Config;
								if (config3 != null)
								{
									bool flag2 = config3._003CPickupCount_003Ek__BackingField == null;
									core = (PlayerOptions)(object)config3._003CPickupCount_003Ek__BackingField;
									if (!flag2)
									{
										int num7 = config3._003CPickupCount_003Ek__BackingField.get_Item(ItemType.CLOVER);
										float num8 = (float)num7 / 65535f;
										bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) < System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref enumerator);
										float num9 = num8 - (float)enumerator;
										bool flag4 = num9 == 0f;
										bool flag5 = !flag3;
										bool flag6 = !flag4;
										object obj2 = flag6 & flag5;
										if (obj2 == null)
										{
											goto IL_1049;
										}
										nint num10 = (nint)typeof(GM);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v90 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
										nint num11 = 0;
										GameManager core3 = GM.Core;
										bool flag7 = (object)GM.Core == null;
										core = (PlayerOptions)num11;
										if (!flag7)
										{
											core = core3._playerOptions;
											if (core3._playerOptions != null)
											{
												core3._playerOptions.UnlockCharacter(CharacterType.EXDASH);
												core = (PlayerOptions)(object)GM.Core;
												if ((object)GM.Core != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
													core = (PlayerOptions)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
														((PlayerOptions)0).BuyCharacter(CharacterType.EXDASH);
														core = (PlayerOptions)(object)GM.Core;
														if ((object)GM.Core != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
															core = (PlayerOptions)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
																((PlayerOptions)0).Save();
																goto IL_1049;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1590;
		IL_1484:
		nint num12 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3136 @ rax_v64 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num13 = 0;
		GameManager core4 = GM.Core;
		bool flag8 = (object)GM.Core == null;
		core = (PlayerOptions)num13;
		if (!flag8)
		{
			core = core4._playerOptions;
			if (core4._playerOptions != null)
			{
				core4._playerOptions.UnlockCharacter(CharacterType.NOSTRO);
				core = (PlayerOptions)(object)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
					core = (PlayerOptions)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+90]");
						((PlayerOptions)0).Save();
						return;
					}
				}
			}
		}
		goto IL_1590;
		IL_1704:
		nint num14 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v45 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num15 = 0;
		GameManager core5 = GM.Core;
		bool flag9 = (object)GM.Core == null;
		core = (PlayerOptions)num15;
		if (!flag9)
		{
			core = core5._playerOptions;
			if (core5._playerOptions != null)
			{
				PlayerOptionsData config4 = core5._playerOptions.Config;
				if (config4 != null)
				{
					bool flag10 = config4._003CSelectedStage_003Ek__BackingField != StageType.SINKING;
					int num16 = (int)characters;
					if (flag10)
					{
						goto IL_0c90;
					}
					_003C_003Ec__DisplayClass3_0 obj3 = new _003C_003Ec__DisplayClass3_0();
					WeaponType[] array = new WeaponType[16]
					{
						WeaponType.POWER,
						WeaponType.SPEED,
						WeaponType.DURATION,
						WeaponType.AREA,
						WeaponType.MAXHEALTH,
						WeaponType.REGEN,
						WeaponType.ARMOR,
						WeaponType.MOVESPEED,
						WeaponType.COOLDOWN,
						WeaponType.AMOUNT,
						WeaponType.REVIVAL,
						WeaponType.MAGNET,
						WeaponType.LUCK,
						WeaponType.GROWTH,
						WeaponType.GREED,
						WeaponType.CURSE
					};
					bool flag11 = obj3 == null;
					core = (PlayerOptions)(object)array;
					if (!flag11)
					{
						obj3.passives = array;
						obj3.i = i;
						num16 = (int)characters;
						object obj4 = 0;
						DataManager dataManager2 = default(DataManager);
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						List<Equipment>.Enumerator enumerator4 = default(List<Equipment>.Enumerator);
						List<Equipment>.Enumerator enumerator5 = default(List<Equipment>.Enumerator);
						object obj7 = default(object);
						object obj8 = default(object);
						float time = default(float);
						while (true)
						{
							core = (PlayerOptions)obj3.i;
							WeaponType[] passives = obj3.passives;
							if (obj3.passives == null)
							{
								break;
							}
							if (obj3.i < passives.Length)
							{
								bool flag12 = dataManager2 == null;
								core = (PlayerOptions)(object)dataManager2;
								if (flag12)
								{
									break;
								}
								Dictionary<WeaponType, List<WeaponData>> convertedWeapons = dataManager2.GetConvertedWeapons();
								core = (PlayerOptions)(object)obj3.passives;
								int i2 = obj3.i;
								if (obj3.passives == null)
								{
									break;
								}
								if (obj3.i >= (nint)core.PowerUpPurchased)
								{
									throw new IndexOutOfRangeException();
								}
								if (convertedWeapons == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v50 (VampireSurvivors.Objects.PlayerOptions)+20+v256 @ rdx_v59 (System.Int32)*4]");
								object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
								List<Equipment> list = new List<Equipment>();
								GameManager core6 = GM.Core;
								bool flag13 = (object)GM.Core == null;
								core = (PlayerOptions)(object)typeof(GM);
								if (flag13)
								{
									break;
								}
								num16 = (int)core6._mainCharacters;
								bool flag14 = core6._mainCharacters == null;
								core = (PlayerOptions)(object)typeof(GM);
								if (flag14)
								{
									break;
								}
								if (enumerator3.MoveNext())
								{
									int num17 = 0;
									nint num18 = (nint)(&enumerator3);
									throw new NullReferenceException();
								}
								bool flag15 = list == null;
								core = (PlayerOptions)(&enumerator3);
								if (flag15)
								{
									break;
								}
								bool flag16 = list._size <= 0;
								num = 0;
								enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)num16;
								if (!flag16)
								{
									object obj6 = 1;
									if (enumerator4.MoveNext())
									{
										int num19 = 0;
										nint num18 = (nint)(&enumerator4);
										throw new NullReferenceException();
									}
									bool flag17 = obj6 == null;
									num = 0;
									enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)enumerator5;
									if (!flag17)
									{
										int i3 = obj3.i + 1;
										obj3.i = i3;
										num = 0;
										obj4 = 1;
										enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)enumerator5;
										continue;
									}
								}
							}
							else if (obj4 != null)
							{
								nint num20 = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v104 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num21 = 0;
								GameManager core7 = GM.Core;
								bool flag18 = (object)GM.Core == null;
								core = (PlayerOptions)num21;
								if (flag18)
								{
									break;
								}
								bool flag19 = core7._playerOptions == null;
								core = (PlayerOptions)num21;
								if (flag19)
								{
									break;
								}
								PlayerOptionsData config5 = core7._playerOptions.Config;
								bool flag20 = core7._playerOptions.UnlockSecret(SecretType.Master16, config5);
								bool flag21 = !flag20;
								num16 = 0;
								if (!flag21)
								{
									bool flag22 = obj7 == null;
									core = core7._playerOptions;
									if (flag22)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2842 @ stack_10+50]");
									core = (PlayerOptions)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2842 @ stack_10+50]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B210");
									if (obj8 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2842 @ stack_10+50]");
										core = (PlayerOptions)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2842 @ stack_10+50]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B280");
									}
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Detune = -1000f;
									soundConfig.Rate = 0.5f;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, num3, 10, time);
									float num22 = num3;
									num16 = 10;
								}
							}
							goto IL_0c90;
						}
					}
				}
			}
		}
		goto IL_1590;
		IL_1265:
		nint num23 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2883 @ rax_v70 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num24 = 0;
		GameManager core8 = GM.Core;
		bool flag23 = (object)GM.Core == null;
		core = (PlayerOptions)num24;
		if (!flag23)
		{
			core = core8._playerOptions;
			if (core8._playerOptions != null)
			{
				PlayerOptionsData config6 = core8._playerOptions.Config;
				if (config6 != null)
				{
					core = (PlayerOptions)(object)config6._003CKillCount_003Ek__BackingField;
					if (config6._003CKillCount_003Ek__BackingField != null)
					{
						int num25 = config6._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.BOSS_XLDEATH2);
						if (num25 < 0)
						{
							return;
						}
						nint num26 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3137 @ rax_v76 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num27 = 0;
						GameManager core9 = GM.Core;
						bool flag24 = (object)GM.Core == null;
						core = (PlayerOptions)num27;
						if (!flag24)
						{
							core = core9._playerOptions;
							if (core9._playerOptions != null)
							{
								PlayerOptionsData config7 = core9._playerOptions.Config;
								if (config7 != null)
								{
									bool flag25 = config7._003CKillCount_003Ek__BackingField == null;
									core = (PlayerOptions)(object)config7._003CKillCount_003Ek__BackingField;
									if (!flag25)
									{
										int num28 = config7._003CKillCount_003Ek__BackingField.get_Item(EnemyType.BOSS_XLDEATH2);
										if (num28 > 0)
										{
											goto IL_1484;
										}
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1590;
		IL_0535:
		num3 = 0f;
		num = 0;
		i = 0;
		goto IL_1704;
		IL_1049:
		nint num29 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2127 @ rax_v56 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num30 = 0;
		GameManager core10 = GM.Core;
		bool flag26 = (object)GM.Core == null;
		core = (PlayerOptions)num30;
		if (!flag26)
		{
			core = core10._playerOptions;
			if (core10._playerOptions != null)
			{
				PlayerOptionsData config8 = core10._playerOptions.Config;
				if (config8 != null)
				{
					core = (PlayerOptions)(object)config8._003CKillCount_003Ek__BackingField;
					if (config8._003CKillCount_003Ek__BackingField != null)
					{
						int num31 = config8._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.BOSS_XLDEATH);
						if (num31 < 0)
						{
							goto IL_1265;
						}
						nint num32 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2856 @ rax_v80 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num33 = 0;
						GameManager core11 = GM.Core;
						bool flag27 = (object)GM.Core == null;
						core = (PlayerOptions)num33;
						if (!flag27)
						{
							core = core11._playerOptions;
							if (core11._playerOptions != null)
							{
								PlayerOptionsData config9 = core11._playerOptions.Config;
								if (config9 != null)
								{
									bool flag28 = config9._003CKillCount_003Ek__BackingField == null;
									core = (PlayerOptions)(object)config9._003CKillCount_003Ek__BackingField;
									if (!flag28)
									{
										int num34 = config9._003CKillCount_003Ek__BackingField.get_Item(EnemyType.BOSS_XLDEATH);
										if (num34 <= 0)
										{
											goto IL_1265;
										}
										goto IL_1484;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1590;
		IL_1590:
		throw new NullReferenceException();
	}

	private bool CheckForStage6Achievement(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_06f2: Expected I4, but got O
		//IL_06df: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0715: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_073d: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0765: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_078d: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_07b5: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_07dd: Expected O, but got I
		//IL_048e: Expected O, but got I
		//IL_0805: Expected O, but got I
		//IL_0523: Expected O, but got I
		//IL_0813: Expected O, but got I4
		//IL_081c: Expected O, but got I4
		//IL_0825: Expected O, but got I4
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_05ac: Expected O, but got I
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected O, but got Unknown
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Expected O, but got Unknown
		List<AchievementType> list = new List<AchievementType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)119);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v5+18]");
			if (num2 >= 0)
			{
				goto IL_06e4;
			}
			_ = 119;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)52);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7+18]");
			if (num4 >= 0)
			{
				goto IL_06e4;
			}
			_ = 52;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v9+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v9+18]");
			if (num6 >= 0)
			{
				goto IL_06e4;
			}
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v11+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)73);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v11+18]");
			if (num8 >= 0)
			{
				goto IL_06e4;
			}
			_ = 73;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v13+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)66);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v13+18]");
			if (num10 >= 0)
			{
				goto IL_06e4;
			}
			_ = 66;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v15+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)121);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v15+18]");
			if (num12 >= 0)
			{
				goto IL_06e4;
			}
			_ = 121;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v17+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)98);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v17+18]");
			if (num14 >= 0)
			{
				goto IL_06e4;
			}
			_ = 98;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v19+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)95);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v19+18]");
			if (num16 >= 0)
			{
				goto IL_06e4;
			}
			_ = 95;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v21+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)128);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v21+18]");
			if (num18 >= 0)
			{
				goto IL_06e4;
			}
			_ = 128;
		}
		object obj19 = 0;
		object obj20 = 0;
		object obj21 = 0;
		object obj26 = default(object);
		while (true)
		{
			object obj22 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			if ((nint)obj22 < 0)
			{
				PlayerOptionsData config = playerOptions.Config;
				object obj23 = obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				if ((nint)obj23 >= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
				object obj24 = 0;
				object obj25 = obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v26+18]");
				if ((nint)obj25 >= 0)
				{
					break;
				}
				List<AchievementType> list2 = config._003CAchievements_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v26+20+v76 @ rdi_v5*4]");
				list2.Add(AchievementType.ReachLV5);
				if (obj26 != null)
				{
					obj20++;
					obj19++;
					obj21 = obj19;
					continue;
				}
			}
			object obj27 = obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj28 = obj27 - 0;
			object obj29 = obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj30 = obj29 ^ 0;
			object obj31 = obj20 ^ obj28;
			object obj32 = obj30 & obj31;
			bool flag = (nint)obj32 < 0;
			bool flag2 = (nint)obj28 < 0;
			return flag2 == flag;
		}
		goto IL_06e4;
		IL_06e4:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private bool CheckSigmaUnlock(PlayerOptions playerOptions)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_1db0: Expected I4, but got O
		//IL_1d9d: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_1dd3: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_1dfb: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_1e23: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_1e4b: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_1e73: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_1e9b: Expected O, but got I
		//IL_048e: Expected O, but got I
		//IL_1ec3: Expected O, but got I
		//IL_0522: Expected O, but got I
		//IL_1eeb: Expected O, but got I
		//IL_05b6: Expected O, but got I
		//IL_1f13: Expected O, but got I
		//IL_064a: Expected O, but got I
		//IL_1f3b: Expected O, but got I
		//IL_06de: Expected O, but got I
		//IL_1f63: Expected O, but got I
		//IL_0772: Expected O, but got I
		//IL_1f8b: Expected O, but got I
		//IL_0806: Expected O, but got I
		//IL_1fb3: Expected O, but got I
		//IL_089a: Expected O, but got I
		//IL_1fdb: Expected O, but got I
		//IL_092e: Expected O, but got I
		//IL_2003: Expected O, but got I
		//IL_09c2: Expected O, but got I
		//IL_202b: Expected O, but got I
		//IL_0a56: Expected O, but got I
		//IL_2053: Expected O, but got I
		//IL_0aea: Expected O, but got I
		//IL_207b: Expected O, but got I
		//IL_0b7e: Expected O, but got I
		//IL_20a3: Expected O, but got I
		//IL_0c12: Expected O, but got I
		//IL_20cb: Expected O, but got I
		//IL_0ca6: Expected O, but got I
		//IL_20f3: Expected O, but got I
		//IL_0d3a: Expected O, but got I
		//IL_211b: Expected O, but got I
		//IL_0dce: Expected O, but got I
		//IL_2143: Expected O, but got I
		//IL_0e62: Expected O, but got I
		//IL_216b: Expected O, but got I
		//IL_0ef6: Expected O, but got I
		//IL_2193: Expected O, but got I
		//IL_0f8a: Expected O, but got I
		//IL_21bb: Expected O, but got I
		//IL_101f: Expected O, but got I
		//IL_161d: Expected O, but got I
		//IL_1677: Expected O, but got I
		//IL_2212: Expected O, but got I
		//IL_170b: Expected O, but got I
		//IL_223a: Expected O, but got I
		//IL_179f: Expected O, but got I
		//IL_2262: Expected O, but got I
		//IL_1833: Expected O, but got I
		//IL_228a: Expected O, but got I
		//IL_18c7: Expected O, but got I
		//IL_22b2: Expected O, but got I
		//IL_195b: Expected O, but got I
		//IL_22da: Expected O, but got I
		//IL_19ef: Expected O, but got I
		//IL_2302: Expected O, but got I
		//IL_1a84: Expected O, but got I
		//IL_2310: Expected O, but got I4
		//IL_2319: Expected O, but got I4
		//IL_1b94: Expected O, but got I4
		//IL_1b9d: Expected O, but got I4
		//IL_2372: Expected O, but got I4
		//IL_1b0d: Expected O, but got I
		//IL_1beb: Expected O, but got I
		//IL_1cd9: Expected O, but got I
		//IL_1b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7e: Expected O, but got Unknown
		//IL_1c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5c: Expected O, but got Unknown
		//IL_1d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Expected O, but got Unknown
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v5+18]");
			if (num2 >= 0)
			{
				goto IL_1da2;
			}
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v7+18]");
			if (num4 >= 0)
			{
				goto IL_1da2;
			}
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v9+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v9+18]");
			if (num6 >= 0)
			{
				goto IL_1da2;
			}
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v11+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v11+18]");
			if (num8 >= 0)
			{
				goto IL_1da2;
			}
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v13+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v13+18]");
			if (num10 >= 0)
			{
				goto IL_1da2;
			}
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v15+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v15+18]");
			if (num12 >= 0)
			{
				goto IL_1da2;
			}
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v17+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v17+18]");
			if (num14 >= 0)
			{
				goto IL_1da2;
			}
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v19+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v19+18]");
			if (num16 >= 0)
			{
				goto IL_1da2;
			}
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v21+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v21+18]");
			if (num18 >= 0)
			{
				goto IL_1da2;
			}
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v23+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v23+18]");
			if (num20 >= 0)
			{
				goto IL_1da2;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v25+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v25+18]");
			if (num22 >= 0)
			{
				goto IL_1da2;
			}
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v27+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)69);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v27+18]");
			if (num24 >= 0)
			{
				goto IL_1da2;
			}
			_ = 69;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v29+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v29+18]");
			if (num26 >= 0)
			{
				goto IL_1da2;
			}
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v31+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v31+18]");
			if (num28 >= 0)
			{
				goto IL_1da2;
			}
			_ = 13;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v33+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v33+18]");
			if (num30 >= 0)
			{
				goto IL_1da2;
			}
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v35+18]");
		if (num31 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v35+18]");
			if (num32 >= 0)
			{
				goto IL_1da2;
			}
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v37+18]");
		if (num33 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v37+18]");
			if (num34 >= 0)
			{
				goto IL_1da2;
			}
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v39+18]");
		if (num35 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v39+18]");
			if (num36 >= 0)
			{
				goto IL_1da2;
			}
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v41+18]");
		if (num37 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v41+18]");
			if (num38 >= 0)
			{
				goto IL_1da2;
			}
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v43+18]");
		if (num39 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v43+18]");
			if (num40 >= 0)
			{
				goto IL_1da2;
			}
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v45+18]");
		if (num41 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v45+18]");
			if (num42 >= 0)
			{
				goto IL_1da2;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v47+18]");
		if (num43 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)74);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v47+18]");
			if (num44 >= 0)
			{
				goto IL_1da2;
			}
			_ = 74;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v49+18]");
		if (num45 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)22);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num46 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v49+18]");
			if (num46 >= 0)
			{
				goto IL_1da2;
			}
			_ = 22;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v51+18]");
		if (num47 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num48 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v51+18]");
			if (num48 >= 0)
			{
				goto IL_1da2;
			}
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v53+18]");
		if (num49 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num50 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v53+18]");
			if (num50 >= 0)
			{
				goto IL_1da2;
			}
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v55+18]");
		if (num51 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj52 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v55+18]");
			if (num52 >= 0)
			{
				goto IL_1da2;
			}
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v57+18]");
		if (num53 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)27);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj54 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num54 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v57+18]");
			if (num54 >= 0)
			{
				goto IL_1da2;
			}
			_ = 27;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v59+18]");
		if (num55 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)28);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj56 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num56 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v59+18]");
			if (num56 >= 0)
			{
				goto IL_1da2;
			}
			_ = 28;
		}
		list.Add(WeaponType.SILF3);
		list.Add(WeaponType.SILF_COUNTER);
		list.Add(WeaponType.SILF2_COUNTER);
		list.Add(WeaponType.BONE);
		list.Add(WeaponType.LANCET);
		list.Add(WeaponType.CORRIDOR);
		list.Add(WeaponType.SONG);
		list.Add(WeaponType.MANNAGGIA);
		list.Add(WeaponType.CHERRY);
		list.Add(WeaponType.CART2);
		list.Add(WeaponType.GATTI);
		list.Add(WeaponType.GATTI_COUNTER);
		list.Add(WeaponType.STIGRANGATTI);
		list.Add(WeaponType.FLOWER);
		list.Add(WeaponType.ROBBA);
		list.Add(WeaponType.CANDYBOX);
		list.Add(WeaponType.GUNS);
		list.Add(WeaponType.GUNS2);
		list.Add(WeaponType.GUNS3);
		list.Add(WeaponType.GUNS_COUNTER);
		list.Add(WeaponType.GUNS2_COUNTER);
		list.Add(WeaponType.TRAPANO);
		list.Add(WeaponType.TRAPANO2);
		list.Add(WeaponType.VENTO);
		list.Add(WeaponType.VENTO2);
		list.Add(WeaponType.TRIASSO1);
		list.Add(WeaponType.TRIASSO2);
		list.Add(WeaponType.TRIASSO3);
		list.Add(WeaponType.POWER);
		list.Add(WeaponType.AREA);
		list.Add(WeaponType.SPEED);
		list.Add(WeaponType.COOLDOWN);
		list.Add(WeaponType.DURATION);
		list.Add(WeaponType.AMOUNT);
		list.Add(WeaponType.MAXHEALTH);
		list.Add(WeaponType.ARMOR);
		list.Add(WeaponType.MOVESPEED);
		list.Add(WeaponType.MAGNET);
		list.Add(WeaponType.GROWTH);
		list.Add(WeaponType.LUCK);
		list.Add(WeaponType.GREED);
		list.Add(WeaponType.REVIVAL);
		list.Add(WeaponType.REGEN);
		list.Add(WeaponType.CURSE);
		list.Add(WeaponType.SILVER);
		list.Add(WeaponType.GOLD);
		list.Add(WeaponType.LEFT);
		list.Add(WeaponType.RIGHT);
		list.Add(WeaponType.PANDORA);
		list.Add(WeaponType.JUBILEE);
		List<ItemType> list2 = new List<ItemType>();
		((List<WeaponType>)(object)list2).Add(WeaponType.WHIP);
		((List<WeaponType>)(object)list2).Add(WeaponType.AXE);
		((List<WeaponType>)(object)list2).Add(WeaponType.KNIFE);
		((List<WeaponType>)(object)list2).Add(WeaponType.GATTI_SCUFFLE);
		((List<WeaponType>)(object)list2).Add(WeaponType.HOLYWATER);
		((List<WeaponType>)(object)list2).Add(WeaponType.BORA);
		((List<WeaponType>)(object)list2).Add(WeaponType.DIAMOND);
		((List<WeaponType>)(object)list2).Add(WeaponType.FIREBALL);
		((List<WeaponType>)(object)list2).Add(WeaponType.HEAVENSWORD);
		((List<WeaponType>)(object)list2).Add(WeaponType.THOUSAND);
		((List<WeaponType>)(object)list2).Add(WeaponType.LIGHTNING);
		((List<WeaponType>)(object)list2).Add(WeaponType.LAUREL);
		((List<WeaponType>)(object)list2).Add(WeaponType.LOOP);
		((List<WeaponType>)(object)list2).Add(WeaponType.PENTAGRAM);
		((List<WeaponType>)(object)list2).Add(WeaponType.SIRE);
		((List<WeaponType>)(object)list2).Add(WeaponType.SILF);
		((List<WeaponType>)(object)list2).Add(WeaponType.SILF2);
		((List<WeaponType>)(object)list2).Add(WeaponType.CART);
		((List<WeaponType>)(object)list2).Add(WeaponType.CART2);
		((List<WeaponType>)(object)list2).Add(WeaponType.GATTI);
		((List<WeaponType>)(object)list2).Add(WeaponType.STIGRANGATTI);
		((List<WeaponType>)(object)list2).Add(WeaponType.GATTI_SCRATCH);
		((List<WeaponType>)(object)list2).Add(WeaponType.POWER);
		((List<WeaponType>)(object)list2).Add(WeaponType.AREA);
		List<ArcanaType> list3 = new List<ArcanaType>();
		((List<WeaponType>)(object)list3).Add(WeaponType.VOID);
		((List<WeaponType>)(object)list3).Add(WeaponType.MAGIC_MISSILE);
		((List<WeaponType>)(object)list3).Add(WeaponType.HOLY_MISSILE);
		((List<WeaponType>)(object)list3).Add(WeaponType.WHIP);
		((List<WeaponType>)(object)list3).Add(WeaponType.VAMPIRICA);
		((List<WeaponType>)(object)list3).Add(WeaponType.AXE);
		((List<WeaponType>)(object)list3).Add(WeaponType.SCYTHE);
		((List<WeaponType>)(object)list3).Add(WeaponType.KNIFE);
		((List<WeaponType>)(object)list3).Add(WeaponType.THOUSAND);
		((List<WeaponType>)(object)list3).Add(WeaponType.HOLYWATER);
		((List<WeaponType>)(object)list3).Add(WeaponType.BORA);
		((List<WeaponType>)(object)list3).Add(WeaponType.DIAMOND);
		((List<WeaponType>)(object)list3).Add(WeaponType.FIREBALL);
		((List<WeaponType>)(object)list3).Add(WeaponType.HELLFIRE);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v60+18]");
		if (num57 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj58 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num58 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v60+18]");
			if (num58 >= 0)
			{
				goto IL_1da2;
			}
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v62+18]");
		if (num59 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj60 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num60 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v62+18]");
			if (num60 >= 0)
			{
				goto IL_1da2;
			}
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v64+18]");
		if (num61 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj62 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num62 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v64+18]");
			if (num62 >= 0)
			{
				goto IL_1da2;
			}
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v66+18]");
		if (num63 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj64 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num64 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v66+18]");
			if (num64 >= 0)
			{
				goto IL_1da2;
			}
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v68+18]");
		if (num65 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj66 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num66 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v68+18]");
			if (num66 >= 0)
			{
				goto IL_1da2;
			}
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v70+18]");
		if (num67 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj68 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num68 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v70+18]");
			if (num68 >= 0)
			{
				goto IL_1da2;
			}
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v72+18]");
		if (num69 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj70 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num70 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v72+18]");
			if (num70 >= 0)
			{
				goto IL_1da2;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v165+18]");
		if (num71 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj72 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num72 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v165+18]");
			if (num72 >= 0)
			{
				goto IL_1da2;
			}
			_ = 21;
		}
		object obj73 = 0;
		object obj74 = 0;
		object obj79 = default(object);
		object obj87 = default(object);
		object obj92 = default(object);
		while (true)
		{
			object obj75 = obj74;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)obj75 < 0)
			{
				PlayerOptionsData config = playerOptions.Config;
				object obj76 = obj73;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj76 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj77 = 0;
					object obj78 = obj73;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v179+18]");
					if ((nint)obj78 >= 0)
					{
						break;
					}
					List<WeaponType> list4 = config._003CCollectedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v179+20+v83 @ rbp_v5*4]");
					((List<ArcanaType>)(object)list4).Add(ArcanaType.T00_KILLER);
					if (obj79 != null)
					{
						obj73++;
						obj74 = obj73;
						continue;
					}
					goto IL_1d4f;
				}
			}
			else
			{
				object obj80 = 0;
				object obj81 = 0;
				while (true)
				{
					object obj82 = obj81;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2448 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					bool flag = (nint)obj82 >= 0;
					object obj83 = 0;
					if (!flag)
					{
						PlayerOptionsData config2 = playerOptions.Config;
						object obj84 = obj80;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2448 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)obj84 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2448 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
						object obj85 = 0;
						object obj86 = obj80;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v176+18]");
						if ((nint)obj86 >= 0)
						{
							goto end_IL_2329;
						}
						List<ItemType> list5 = config2._003CCollectedItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v176+20+v127 @ rbx_v9*4]");
						((List<ArcanaType>)(object)list5).Add(ArcanaType.T00_KILLER);
						if (obj87 != null)
						{
							obj80++;
							obj81 = obj80;
							continue;
						}
						goto IL_1d4f;
					}
					while (true)
					{
						object obj88 = obj83;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
						if ((nint)obj88 < 0)
						{
							PlayerOptionsData config3 = playerOptions.Config;
							object obj89 = obj83;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
							if ((nint)obj89 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ rax_v114 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
							object obj90 = 0;
							object obj91 = obj83;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v173+18]");
							if ((nint)obj91 >= 0)
							{
								goto end_IL_2329;
							}
							List<ArcanaType> list6 = config3._003CUnlockedArcanas_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v173+20+v81 @ rsi_v8*4]");
							list6.Add(ArcanaType.T00_KILLER);
							if (obj92 != null)
							{
								obj83++;
								continue;
							}
							goto IL_1d4f;
						}
						return true;
					}
					break;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			IL_1d4f:
			return false;
			continue;
			end_IL_2329:
			break;
		}
		goto IL_1da2;
		IL_1da2:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public int CountKilledEnemiesAndVariants(EnemyType enemyType, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_0185: Expected O, but got I
		//IL_01c2: Expected O, but got I
		//IL_03be: Expected O, but got I
		//IL_05f2: Expected O, but got I4
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_021c: Expected O, but got I
		//IL_051b: Expected O, but got I
		//IL_052d: Expected O, but got I4
		//IL_02a7: Expected O, but got I
		//IL_0582: Expected I, but got O
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_0345: Expected O, but got I
		List<EnemyType> list = new List<EnemyType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v30+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)enemyType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v30+18]");
			if (num2 >= 0)
			{
				goto IL_0627;
			}
		}
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = dataManager.GetConvertedEnemyData();
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).TryGetValue((System.Int32Enum)enemyType, out object value);
		bool flag2 = !flag;
		int num3 = 0;
		object obj6 = default(object);
		object obj8 = default(object);
		if (!flag2)
		{
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-48_v21 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-48_v21 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-48_v21 (System.Object)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v55+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0627;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v55+20]");
					List<EnemyType> list2 = (List<EnemyType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v55+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rcx_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rcx_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v94+18]");
							if ((nint)0 > (nint)0)
							{
								object obj5 = default(object);
								object obj11 = default(object);
								while (true)
								{
									if (obj5 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ stack_-88_v25+1C]");
										if (obj6 == null)
										{
											object obj7 = obj8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ stack_-88_v25+18]");
											if ((nint)obj7 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ stack_-88_v25+10]");
												object obj9 = 0;
												object obj10 = obj8 + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
												bool flag3 = obj11 != null;
												obj8 = obj10;
												if (!flag3)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF90");
													obj8 = obj10;
												}
												continue;
											}
											break;
										}
										break;
									}
									throw new NullReferenceException();
								}
								bool flag4 = obj5 == null;
								nint num4 = 0;
								if (!flag4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ stack_-88_v25+1C]");
									if (obj6 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ stack_-88_v25+18]");
										object obj12 = (nint)0 + (nint)1;
										obj8 = obj12;
										goto IL_0352;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									num4 = unchecked((nint)null);
								}
								throw new NullReferenceException();
							}
						}
					}
				}
			}
			goto IL_0352;
		}
		goto IL_0635;
		IL_0627:
		throw new IndexOutOfRangeException();
		IL_0352:
		num3 = 0;
		object obj14 = default(object);
		object obj13;
		while (true)
		{
			obj13 = obj14;
			while (true)
			{
				PlayerOptionsData playerOptionsData;
				if (obj13 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rcx_v43+1C]");
					if (obj6 != null)
					{
						break;
					}
					object obj15 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rcx_v43+18]");
					if ((nint)obj15 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rcx_v43+10]");
					object obj16 = 0;
					obj8++;
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_048a;
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
					goto IL_048a;
				}
				throw new NullReferenceException();
				IL_048a:
				if (playerOptionsData._003CKillCount_003Ek__BackingField == null)
				{
					continue;
				}
				goto IL_04ac;
			}
			break;
			IL_04ac:
			PlayerOptionsData config = playerOptions.Config;
			Dictionary<EnemyType, int> dictionary = config._003CKillCount_003Ek__BackingField;
			Dictionary<EnemyType, int> dictionary2 = config._003CKillCount_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ rax_v74+20+v174 @ stack_-80_v25*4]");
			int num5 = dictionary2.FindEntry(EnemyType.BAT1);
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v18 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
				object obj17 = 0;
				object obj18 = num5 + num5;
				int num6 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rax_v80+2C+v1186 @ rcx_v48*8]");
				num3 = (int)((nint)num6 + (nint)0);
			}
		}
		if (obj13 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rcx_v43+1C]");
			if (obj6 == null)
			{
				goto IL_0635;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			obj13 = 0;
		}
		throw new NullReferenceException();
		IL_0635:
		return num3;
	}
}
