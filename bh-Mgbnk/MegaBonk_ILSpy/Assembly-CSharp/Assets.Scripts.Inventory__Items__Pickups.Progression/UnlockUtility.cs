using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Progression;

public class UnlockUtility
{
	public const float UNLOCKABLE_PRICE_MULTIPLIER = 1.75f;

	public unsafe static HashSet<TomeData> GetAvailableTomes()
	{
		//IL_03df: Expected O, but got Ref
		//IL_004e: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_041d: Expected O, but got Ref
		//IL_021d: Expected O, but got I4
		//IL_0298: Expected I, but got O
		//IL_02a8: Expected O, but got I
		//IL_0328: Expected O, but got I4
		//IL_02e4: Expected O, but got I
		//IL_0335: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		HashSet<TomeData> hashSet = (HashSet<TomeData>)(object)new HashSet<object>();
		DataManager dataManager = DataManager.Instance;
		UnlockableBase unlockableBase;
		if ((object)DataManager.Instance != null)
		{
			List<TomeData> allTomes = DataManager.Instance.GetAllTomes();
			if (allTomes != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				ETome eTome = default(ETome);
				while (enumerator.MoveNext())
				{
					if (MyAchievements.IsAvailable((UnlockableBase)eTome))
					{
						bool flag = hashSet == null;
						unlockableBase = (UnlockableBase)eTome;
						if (flag)
						{
							throw new NullReferenceException();
						}
						bool flag2 = hashSet.Add((TomeData)eTome);
					}
				}
				((List<TomeData>.Enumerator*)(&enumerator))->Dispose();
				dataManager = (DataManager)(&enumerator);
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory = instance.inventory;
					if (instance.inventory != null)
					{
						dataManager = (DataManager)(object)inventory.tomeInventory;
						if (inventory.tomeInventory != null)
						{
							bool flag3 = ((MonoBehaviour)dataManager).m_CancellationTokenSource == null;
							dataManager = (DataManager)(object)((MonoBehaviour)dataManager).m_CancellationTokenSource;
							if (!flag3)
							{
								Dictionary<ETome, int>.KeyCollection keys = ((Dictionary<ETome, int>)(object)((MonoBehaviour)dataManager).m_CancellationTokenSource).Keys;
								bool flag4 = keys == null;
								dataManager = (DataManager)(object)((MonoBehaviour)dataManager).m_CancellationTokenSource;
								if (!flag4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
									Dictionary<ETome, int>.KeyCollection.Enumerator enumerator2 = default(Dictionary<ETome, int>.KeyCollection.Enumerator);
									while (enumerator2.MoveNext())
									{
										if ((object)DataManager.Instance != null)
										{
											TomeData tome = DataManager.Instance.GetTome(eTome);
											if (hashSet != null)
											{
												bool flag5 = hashSet.Add(tome);
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									enumerator2.Dispose();
									dataManager = (DataManager)(&enumerator2);
									if (RunUnlockables.banishedUpgradables != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
										HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
										while (true)
										{
											object item;
											object obj3;
											if (enumerator3.MoveNext())
											{
												if (!Enumerable.Contains((IEnumerable<object>)hashSet, (object)eTome))
												{
													continue;
												}
												if (hashSet == null)
												{
													break;
												}
												if (eTome == ETome.Damage)
												{
													item = null;
													goto IL_0458;
												}
												nint num = (nint)eTome;
												nint num2 = (nint)typeof(TomeData);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rdx_v23 (Il2CppClass<TomeData>)+130]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ r8_v15 (Il2CppClass<System.Object>)+130]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rdx_v23 (Il2CppClass<TomeData>)+130]");
												if (num3 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ r8_v15 (Il2CppClass<System.Object>)+C8]");
													object obj2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v49+FFFFFFF8+v653 @ rax_v45*8]");
													if (0 == (nint)typeof(TomeData))
													{
														obj3 = 1;
														goto IL_046f;
													}
												}
												obj3 = 0;
												goto IL_046f;
											}
											((HashSet<UnlockableBase>.Enumerator*)(&enumerator3))->Dispose();
											return hashSet;
											IL_0458:
											bool flag6 = ((HashSet<object>)(object)hashSet).Remove(item);
											continue;
											IL_046f:
											bool flag7 = obj3 == null;
											item = null;
											if (!flag7)
											{
												item = eTome;
											}
											goto IL_0458;
										}
										throw new NullReferenceException();
									}
								}
							}
						}
					}
				}
			}
		}
		unlockableBase = (UnlockableBase)(object)dataManager;
		throw new NullReferenceException();
	}

	public unsafe static List<WeaponData> GetAvailableWeapons()
	{
		//IL_01cc: Expected O, but got Ref
		//IL_01f1: Expected O, but got Ref
		//IL_0211: Expected O, but got I4
		//IL_02b3: Expected I, but got O
		//IL_02c1: Expected I, but got O
		//IL_02d1: Expected O, but got I
		//IL_0351: Expected O, but got I4
		//IL_030d: Expected O, but got I
		//IL_0343: Expected O, but got I4
		if (!ChallengesTracker.HasChallengeModifier("no_weapons"))
		{
			HashSet<WeaponData> hashSet = (HashSet<WeaponData>)(object)new HashSet<object>();
			if ((object)DataManager.Instance != null)
			{
				List<WeaponData> allWeapons = DataManager.Instance.GetAllWeapons();
				if (allWeapons != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					UnlockableBase unlockableBase = default(UnlockableBase);
					while (enumerator.MoveNext())
					{
						if (MyAchievements.IsAvailable(unlockableBase))
						{
							if (hashSet == null)
							{
								throw new NullReferenceException();
							}
							bool flag = hashSet.Add((WeaponData)unlockableBase);
						}
					}
					((List<WeaponData>.Enumerator*)(&enumerator))->Dispose();
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null)
						{
							WeaponInventory weaponInventory = inventory.weaponInventory;
							if (inventory.weaponInventory != null && weaponInventory.weapons != null)
							{
								Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
								if (values != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
									Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator2 = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
									while (enumerator2.MoveNext())
									{
										bool flag2 = (object)unlockableBase == null;
										Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator3 = (Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator)(&enumerator2);
										if (!flag2)
										{
											bool flag3 = hashSet == null;
											enumerator3 = (Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator)(&enumerator2);
											if (!flag3)
											{
												bool flag4 = hashSet.Add((WeaponData)unlockableBase.isEnabled);
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									enumerator2.Dispose();
									if (RunUnlockables.banishedUpgradables != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
										HashSet<object>.Enumerator enumerator4 = default(HashSet<object>.Enumerator);
										while (true)
										{
											object item;
											object obj3;
											if (enumerator4.MoveNext())
											{
												if (!Enumerable.Contains((IEnumerable<object>)hashSet, (object)unlockableBase))
												{
													continue;
												}
												if (hashSet == null)
												{
													break;
												}
												if ((object)unlockableBase == null)
												{
													item = null;
													goto IL_0450;
												}
												nint num = (nint)unlockableBase;
												nint num2 = (nint)typeof(WeaponData);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rdx_v26 (Il2CppClass<WeaponData>)+130]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ r8_v15 (Il2CppClass<System.Object>)+130]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rdx_v26 (Il2CppClass<WeaponData>)+130]");
												if (num3 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ r8_v15 (Il2CppClass<System.Object>)+C8]");
													object obj2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v722 @ rax_v52+FFFFFFF8+v690 @ rax_v48*8]");
													if (0 == (nint)typeof(WeaponData))
													{
														obj3 = 1;
														goto IL_0467;
													}
												}
												obj3 = 0;
												goto IL_0467;
											}
											((HashSet<UnlockableBase>.Enumerator*)(&enumerator4))->Dispose();
											return (List<WeaponData>)(object)Enumerable.ToList((IEnumerable<object>)hashSet);
											IL_0450:
											bool flag5 = ((HashSet<object>)(object)hashSet).Remove(item);
											continue;
											IL_0467:
											bool flag6 = obj3 == null;
											item = null;
											if (!flag6)
											{
												item = unlockableBase;
											}
											goto IL_0450;
										}
										throw new NullReferenceException();
									}
								}
							}
						}
					}
				}
			}
			return (List<WeaponData>)(object)new NullReferenceException();
		}
		return new List<WeaponData>();
	}
}
