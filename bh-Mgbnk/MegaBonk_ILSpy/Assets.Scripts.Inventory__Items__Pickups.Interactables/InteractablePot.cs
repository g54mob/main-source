using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Localization;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class InteractablePot : BaseInteractable
{
	public GameObject goldPrefab;

	public GameObject xpPrefab;

	public GameObject hpPrefab;

	public GameObject silverPrefab;

	public GameObject potBreakFx;

	private bool broken;

	public bool isBig;

	public bool isSilver;

	public LocalizedString localizedString;

	private string potLuckMovingStatName;

	private float luckPerPot;

	public bool isInCrypt;

	public static string debugName = "Pots";

	public static string debugNameSilver = "Silver Pots";

	public static string debugNameCrypt = "Crypt Pots";

	public static string debugGraveyardName = "Pumpkin";

	public unsafe override bool Interact()
	{
		//IL_0008: Expected O, but got Ref
		//IL_09b4: Expected I4, but got O
		//IL_09e4: Expected I, but got O
		//IL_0cf0: Expected O, but got Ref
		//IL_0d08: Expected O, but got Ref
		//IL_0cb1: Expected I, but got O
		//IL_08cf: Expected O, but got Ref
		//IL_08dd: Expected O, but got Ref
		//IL_00a8: Invalid comparison between F4 and I4
		//IL_0506: Invalid comparison between F4 and I4
		//IL_0976: Expected O, but got Ref
		//IL_0c1a: Expected I, but got O
		//IL_0bdb: Expected I, but got O
		//IL_0623: Expected O, but got Ref
		//IL_0631: Expected O, but got Ref
		//IL_057a: Expected O, but got Ref
		//IL_0588: Expected O, but got Ref
		//IL_05d7: Expected O, but got I4
		//IL_06b3: Expected O, but got Ref
		//IL_06de: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_0231: Expected I, but got O
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected O, but got Unknown
		//IL_0a7f: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_0255: Expected I, but got O
		//IL_0265: Expected O, but got I
		//IL_0291: Expected I, but got O
		//IL_02af: Expected O, but got I
		//IL_02dc: Expected I, but got O
		//IL_0ad9: Expected I, but got O
		//IL_0319: Expected I, but got O
		//IL_0353: Expected O, but got Ref
		//IL_0361: Expected O, but got Ref
		//IL_087d: Expected F4, but got I4
		//IL_03b2: Expected O, but got I4
		//IL_0b3f: Expected I, but got O
		//IL_03d7: Expected O, but got Ref
		//IL_0430: Expected O, but got I4
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_04c7: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int num14 = default(int);
		if (!broken)
		{
			broken = true;
			GameObject obj3 = base.gameObject;
			UnityEngine.Object.Destroy(obj3);
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				float num3 = position.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ rcx_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num4 = num3 + 0f;
				Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = Quaternion.identityQuaternion;
				GameObject gameObject = UnityEngine.Object.Instantiate(potBreakFx, position2, rotation);
				if (isSilver)
				{
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						Vector3 position3 = transform2.position;
						nint num5 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num6 = 0;
						float num7 = position3.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						float num8 = num7 + 0f;
						Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = Quaternion.identityQuaternion;
						GameObject gameObject2 = UnityEngine.Object.Instantiate(silverPrefab, position4, rotation2);
						bool flag = !isBig;
						bool flag2 = !flag;
						Transform transform3 = base.transform;
						if ((object)transform3 != null)
						{
							Vector3 position5 = transform3.position;
							_ = position5.x;
							Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = position5.z;
							int amount = (flag2 ? 1 : 0) + 1;
							MoneyUtility.SpawnSilverNoTimerImpact(amount, pos);
							goto IL_0882;
						}
					}
				}
				else if (MyRandom.random != null)
				{
					double num9 = MyRandom.random.NextDouble();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
					bool flag3 = ChallengesTracker.HasChallengeModifier("no_xp");
					if (0.45f < 0f || flag3)
					{
						bool flag4 = !(0.9f < 0f);
						bool flag5 = true;
						if (!flag4)
						{
							flag5 = flag3;
						}
						if (!flag5)
						{
							Transform transform4 = base.transform;
							if ((object)transform4 != null)
							{
								Vector3 position6 = transform4.position;
								nint num10 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v88 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num11 = 0;
								float num12 = position6.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v983 @ rcx_v68 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num13 = num12 + 0f;
								Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								Vector3 position7 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								_ = Quaternion.identityQuaternion;
								GameObject gameObject3 = UnityEngine.Object.Instantiate(hpPrefab, position7, rotation3);
								SpawnStuff(EPickup.Health, 1, 0.5f, num14);
								Quaternion quaternion = (Quaternion)1;
								goto IL_06e3;
							}
						}
						else
						{
							Transform transform5 = base.transform;
							if ((object)transform5 != null)
							{
								Vector3 position8 = transform5.position;
								nint num15 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rax_v70 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num16 = 0;
								float num17 = position8.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rcx_v54 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num18 = num17 + 0f;
								Quaternion rotation4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								Vector3 position9 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								_ = Quaternion.identityQuaternion;
								GameObject gameObject4 = UnityEngine.Object.Instantiate(goldPrefab, position9, rotation4);
								int potMoney = MoneyUtility.GetPotMoney(isBig);
								Transform transform6 = base.transform;
								if ((object)transform6 != null)
								{
									Vector3 position10 = transform6.position;
									Vector3 pos2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									_ = position10.x;
									_ = position10.z;
									MoneyUtility.SpawnMoney(potMoney, pos2);
									Quaternion quaternion = (Quaternion)0;
									goto IL_06e3;
								}
							}
						}
					}
					else
					{
						MyPlayer instance = MyPlayer.Instance;
						if ((object)MyPlayer.Instance != null)
						{
							PlayerInventory inventory = instance.inventory;
							if (instance.inventory != null)
							{
								PlayerXp playerXp = inventory.playerXp;
								if (inventory.playerXp != null)
								{
									int num19 = XpUtility.XpToNextLevelTotal(playerXp.xp);
									GameObject gameObject5 = UnityEngine.Object.Instantiate((GameObject)playerXp.xp, (Vector3)0, rotation);
									float num20 = (isBig ? 2f : 1f);
									MyPlayer instance2 = MyPlayer.Instance;
									if ((object)MyPlayer.Instance != null)
									{
										PlayerInventory inventory2 = instance2.inventory;
										if (instance2.inventory != null)
										{
											ItemInventory itemInventory = inventory2.itemInventory;
											if (inventory2.itemInventory != null)
											{
												ItemBase item = inventory2.itemInventory.GetItem(EItem.Pumpkin);
												bool flag6 = item == null;
												nint num21 = 0;
												nint num22 = unchecked((nint)null);
												if (!flag6)
												{
													nint num23 = (nint)typeof(ItemPumpkin);
													num21 = (nint)item;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ r8_v29 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
													itemInventory = (ItemInventory)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
													nint num24 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ r8_v29 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
													bool flag7 = num24 < 0;
													num22 = (nint)typeof(ItemPumpkin);
													if (!flag7)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
														ItemInventory itemInventory2 = (ItemInventory)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1346 @ rcx_v110 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)+FFFFFFF8+v1344 @ rcx_v83 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)*8]");
														bool flag8 = 0 != (nint)typeof(ItemPumpkin);
														num22 = (nint)typeof(ItemPumpkin);
														itemInventory = itemInventory2;
														if (!flag8)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180462D90");
															object obj4 = default(object);
															num20 *= (float)obj4;
															num22 = (nint)typeof(ItemPumpkin);
															itemInventory = (ItemInventory)(object)item;
														}
													}
												}
												object obj5 = gameObject5 + 3;
												float num25 = (float)obj5 * num20;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
												object obj6 = default(object);
												bool flag9 = (nint)obj6 >= 10;
												object obj7 = 10;
												if (!flag9)
												{
													obj7 = obj6;
												}
												object obj8 = obj6 / obj7;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
												Transform transform7 = base.transform;
												if ((object)transform7 != null)
												{
													Vector3 position11 = transform7.position;
													nint num26 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rax_v119 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num27 = 0;
													float num28 = position11.z;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rdx_v39 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
													float num29 = num28 + 0f;
													Quaternion quaternion = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
													Vector3 position12 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													_ = Quaternion.identityQuaternion;
													GameObject gameObject6 = UnityEngine.Object.Instantiate(xpPrefab, position12, quaternion);
													if ((nint)obj7 <= 0)
													{
														goto IL_06e3;
													}
													object obj9 = 0;
													int value = default(int);
													float pickupDelay = default(float);
													while (true)
													{
														Transform transform8 = base.transform;
														if ((object)transform8 == null)
														{
															break;
														}
														Vector3 position13 = transform8.position;
														nint num30 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v131 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num31 = 0;
														float num32 = position13.x + (float)Vector3.upVector;
														float num33 = position13.y;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rcx_v96 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
														float num34 = num33 + 0f;
														float num35 = position13.z;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rcx_v96 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
														float num36 = num35 + 0f;
														if ((object)PickupManager.Instance == null)
														{
															break;
														}
														Vector3 pos3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
														Pickup pickup = PickupManager.Instance.SpawnPickup(EPickup.Xp, pos3, value, (byte)num14 != 0, pickupDelay);
														bool flag10 = pickup != null;
														bool flag11 = !flag10;
														quaternion = (Quaternion)0;
														if (!flag11)
														{
															if ((object)GameManager.Instance == null)
															{
																break;
															}
															MyPlayer player = GameManager.Instance.GetPlayer();
															if ((object)player == null)
															{
																break;
															}
															Transform target = player.transform;
															if ((object)pickup == null)
															{
																break;
															}
															pickup.StartFollowingPlayer(target);
															quaternion = (Quaternion)0;
														}
														obj9++;
														if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
														{
															goto IL_06e3;
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
			goto IL_09a6;
		}
		return false;
		IL_09a6:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0882:
		return true;
		IL_06e3:
		if (isSilver)
		{
			goto IL_0882;
		}
		float num37 = (float)MapController.index * 0.5f;
		float num38 = num37 + 0.5f;
		float num39 = num38 * luckPerPot;
		if (isBig)
		{
			num39 *= 1.5f;
		}
		StatModifier statModifier = new StatModifier();
		if (statModifier != null)
		{
			statModifier.modification = num39;
			statModifier.stat = EStat.Luck;
			statModifier.modifyType = EStatModifyType.Flat;
			MyPlayer instance3 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory3 = instance3.inventory;
				if (instance3.inventory != null && inventory3.statInventory != null)
				{
					inventory3.statInventory.ChangeStat(statModifier, permanent: true, 0f, (byte)num14 != 0);
					UiManager instance4 = UiManager.Instance;
					if ((object)UiManager.Instance != null && (object)instance4.scoreUi != null)
					{
						instance4.scoreUi.AddScore(statModifier, isPositive: true, useSfx: false, num14);
						goto IL_0882;
					}
				}
			}
		}
		goto IL_09a6;
	}

	private void GiveLuck()
	{
		//IL_00fe: Expected F4, but got I4
		bool flag = !isBig;
		float num = (float)MapController.index * 0.5f;
		float num2 = num + 0.5f;
		float num3 = num2 * luckPerPot;
		if (!flag)
		{
			num3 *= 1.5f;
		}
		StatModifier statModifier = new StatModifier();
		statModifier.modification = num3;
		statModifier.stat = EStat.Luck;
		statModifier.modifyType = EStatModifyType.Flat;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		bool flag2 = default(bool);
		inventory.statInventory.ChangeStat(statModifier, permanent: true, 0f, flag2);
		UiManager instance2 = UiManager.Instance;
		instance2.scoreUi.AddScore(statModifier, isPositive: true, useSfx: false, flag2 ? 1 : 0);
	}

	private int GetXp()
	{
		//IL_0263: Expected I4, but got O
		//IL_0160: Expected I, but got O
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_017c: Expected I, but got O
		//IL_0184: Expected I, but got O
		//IL_0194: Expected O, but got I
		//IL_01c0: Expected I, but got O
		//IL_01de: Expected O, but got I
		//IL_020b: Expected I, but got O
		//IL_0248: Expected I, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				PlayerXp playerXp = inventory.playerXp;
				if (inventory.playerXp != null)
				{
					int num = XpUtility.XpToNextLevelTotal(playerXp.xp);
					float num2 = (float)num * 0.075f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
					float num3 = (isBig ? 2f : 1f);
					MyPlayer instance2 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory2 = instance2.inventory;
						if (instance2.inventory != null)
						{
							ItemInventory itemInventory = inventory2.itemInventory;
							if (inventory2.itemInventory != null)
							{
								ItemBase item = inventory2.itemInventory.GetItem(EItem.Pumpkin);
								bool flag = item == null;
								nint num4 = unchecked((nint)null);
								if (!flag)
								{
									nint num5 = (nint)typeof(ItemPumpkin);
									nint num6 = (nint)item;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v3 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
									itemInventory = (ItemInventory)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v3 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
									bool flag2 = num7 < 0;
									num4 = (nint)typeof(ItemPumpkin);
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
										ItemInventory itemInventory2 = (ItemInventory)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v11 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)+FFFFFFF8+v171 @ rcx_v9 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)*8]");
										bool flag3 = 0 != (nint)typeof(ItemPumpkin);
										num4 = (nint)typeof(ItemPumpkin);
										itemInventory = itemInventory2;
										if (!flag3)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180462D90");
											object obj = default(object);
											num3 *= (float)obj;
											num4 = (nint)typeof(ItemPumpkin);
											itemInventory = (ItemInventory)(object)item;
										}
									}
								}
								object obj3 = default(object);
								object obj2 = obj3 + 3;
								float num8 = (float)obj2 * num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
								int result = default(int);
								return result;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe void SpawnStuff(EPickup ePickup, int value, float pickupDelay, int amount)
	{
		//IL_000e: Expected O, but got I4
		//IL_0077: Expected O, but got Ref
		//IL_003c: Expected O, but got Ref
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			return;
		}
		object obj2 = 0;
		float num = default(float);
		float num3 = default(float);
		bool useRandomOffsetPosition = default(bool);
		float pickupDelay2 = default(float);
		do
		{
			if (ePickup != EPickup.Xp)
			{
				Transform transform = base.transform;
				Vector3 position = transform.position;
				EffectManager.Instance.SpawnPickupOrb(ePickup, (Vector3)(&num));
			}
			else
			{
				Transform transform2 = base.transform;
				float num2 = transform2.position.x + (float)Vector3.upVector;
				Pickup pickup = PickupManager.Instance.SpawnPickup(EPickup.Xp, (Vector3)(&num3), value, useRandomOffsetPosition, pickupDelay2);
				bool flag = pickup != null;
				bool flag2 = !flag;
				num3 = num2;
				if (!flag2)
				{
					MyPlayer player = GameManager.Instance.GetPlayer();
					Transform target = player.transform;
					pickup.StartFollowingPlayer(target);
					num3 = num2;
				}
			}
			obj2++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
	}

	public override string GetInteractString()
	{
		if (localizedString != null)
		{
			return localizedString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool ShowInDebug()
	{
		return !isSilver;
	}

	public override string GetDebugName()
	{
		if (!isSilver)
		{
			if (!isInCrypt)
			{
				if (MapController._003CcurrentMap_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A790");
					object obj = default(object);
					if (obj == null)
					{
						return (string)(object)new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v28+58]");
					if ((nint)0 == 8)
					{
						return debugGraveyardName;
					}
				}
				return debugName;
			}
			return debugNameCrypt;
		}
		return debugNameSilver;
	}

	private void OnDisable()
	{
		if (ShowInDebug() && !broken)
		{
			Action<string> a_DebugDisable = BaseInteractable.A_DebugDisable;
			if (BaseInteractable.A_DebugDisable != null)
			{
				string text = GetDebugName();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v90 @ rdi_v2 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public InteractablePot()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317298B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		potLuckMovingStatName = "PotLuck";
		luckPerPot = 0.005f;
		base._002Ector();
	}
}
