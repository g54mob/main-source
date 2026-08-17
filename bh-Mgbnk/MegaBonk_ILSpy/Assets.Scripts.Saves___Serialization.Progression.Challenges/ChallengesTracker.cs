using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Saves___Serialization.Progression.Challenges;

public class ChallengesTracker
{
	public const string MODIFIER_NO_MOVEMENT = "no_movement";

	public const string MODIFIER_NO_ITEMS = "no_items";

	public const string MODIFIER_NO_WEAPONS = "no_weapons";

	public const string MODIFIER_INVERTED_CONTROLS = "inverted_controls";

	public const string MODIFIER_BLIND = "blind";

	public const string MODIFIER_SPEEDRUN = "speedrun";

	public const string MODIFIER_CRYPT = "crypt";

	public const string MODIFIER_MINIMALIST = "minimalist";

	public const string MODIFIER_NO_XP = "no_xp";

	private static ChallengeWinCondition winCondition;

	public static ChallengeModifier[] challengeModifiers;

	private static HashSet<string> modifierNames;

	public const float silverAddPerChallenge = 0.01f;

	private static bool victory;

	public static Action<ChallengeData> A_ChallengeCompleted;

	public static void Init()
	{
		//IL_032c: Expected I, but got O
		//IL_0335: Expected O, but got I4
		//IL_037c: Expected O, but got I4
		//IL_0392: Expected I, but got O
		//IL_03b8: Expected O, but got I4
		//IL_03ce: Expected I, but got O
		//IL_03f4: Expected O, but got I4
		//IL_040a: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_04b1: Expected O, but got I4
		//IL_04c7: Expected I, but got O
		//IL_04fa: Expected I, but got O
		//IL_0503: Expected O, but got I4
		Delegate a_NewRunStarted = MapController.A_NewRunStarted;
		Action action = OnNewRunStarted;
		Delegate obj = Delegate.Combine(MapController.A_NewRunStarted, action);
		Action action2;
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			MapController.A_NewRunStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0585;
			}
			MapController.A_NewRunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_054a;
			}
		}
		Action b = OnGameOver;
		Delegate obj6 = Delegate.Combine(GameManager.A_GameOver, b);
		if ((object)obj6 == null)
		{
			GameManager.A_GameOver = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0555;
			}
			GameManager.A_GameOver = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0565;
			}
		}
		Action<PlayerInventory> b2 = OnInventoryInitialized;
		Delegate obj9 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b2);
		if ((object)obj9 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
			bool flag8 = action3 == null;
			a_NewRunStarted = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_0440;
			}
			MyPlayer.A_PlayerInventoryInitialized = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag9 = obj10 == null;
			a_NewRunStarted = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_0450;
			}
		}
		a_NewRunStarted = EnemyManager.A_StageBossDied;
		Action action4 = OnStagebossDefeated;
		Delegate obj11 = Delegate.Combine(EnemyManager.A_StageBossDied, action4);
		if ((object)obj11 == null)
		{
			EnemyManager.A_StageBossDied = null;
			return;
		}
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag10)
		{
			obj12 = obj11;
		}
		bool flag11 = (object)obj12 == null;
		action2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag11)
		{
			goto IL_0575;
		}
		EnemyManager.A_StageBossDied = (Action)obj12;
		bool flag12 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag12)
		{
			obj13 = obj11;
		}
		bool flag13 = (object)obj13 == null;
		action2 = action4;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj11;
		if (!flag13)
		{
			return;
		}
		goto IL_0585;
		IL_0585:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0575;
		IL_0575:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0450;
		IL_0555:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_054a;
		IL_0440:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0565;
		IL_0450:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0440;
		IL_054a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0565:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0555;
	}

	public static void Cleanup()
	{
		//IL_0336: Expected I, but got O
		//IL_033f: Expected O, but got I4
		//IL_0386: Expected O, but got I4
		//IL_039c: Expected I, but got O
		//IL_03c2: Expected O, but got I4
		//IL_03d8: Expected I, but got O
		//IL_03fe: Expected O, but got I4
		//IL_0414: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_04bb: Expected O, but got I4
		//IL_04d1: Expected I, but got O
		//IL_0504: Expected I, but got O
		//IL_050d: Expected O, but got I4
		Delegate a_NewRunStarted = MapController.A_NewRunStarted;
		Action action = OnNewRunStarted;
		Delegate obj = Delegate.Remove(MapController.A_NewRunStarted, action);
		if ((object)obj == null)
		{
			MapController.A_NewRunStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			object obj3;
			Delegate obj4;
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				Action action2 = action;
				nint num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_058f;
			}
			MapController.A_NewRunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0554;
			}
		}
		Action value = OnGameOver;
		Delegate obj6 = Delegate.Remove(GameManager.A_GameOver, value);
		if ((object)obj6 == null)
		{
			GameManager.A_GameOver = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			object obj3 = 0;
			Delegate obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_055f;
			}
			GameManager.A_GameOver = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_056f;
			}
		}
		Action<PlayerInventory> value2 = OnInventoryInitialized;
		Delegate obj9 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value2);
		if ((object)obj9 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
			bool flag8 = action3 == null;
			a_NewRunStarted = (Delegate)(object)typeof(Action<PlayerInventory>);
			Action action2 = (Action)obj9;
			object obj3 = 0;
			Delegate obj4 = null;
			if (flag8)
			{
				goto IL_044a;
			}
			MyPlayer.A_PlayerInventoryInitialized = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag9 = obj10 == null;
			a_NewRunStarted = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_045a;
			}
		}
		a_NewRunStarted = EnemyManager.A_StageBossDied;
		Action action4 = OnStagebossDefeated;
		Delegate obj11 = Delegate.Remove(EnemyManager.A_StageBossDied, action4);
		if ((object)obj11 == null)
		{
			EnemyManager.A_StageBossDied = null;
		}
		else
		{
			bool flag10 = (object)obj11.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag10)
			{
				obj12 = obj11;
			}
			bool flag11 = (object)obj12 == null;
			Action action2 = action4;
			object obj3 = 0;
			Delegate obj4 = obj11;
			nint num5 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_057f;
			}
			EnemyManager.A_StageBossDied = (Action)obj12;
			bool flag12 = (object)obj11.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag12)
			{
				obj13 = obj11;
			}
			bool flag13 = (object)obj13 == null;
			action2 = action4;
			nint num = (nint)typeof(Action);
			obj3 = 0;
			obj4 = obj11;
			if (flag13)
			{
				goto IL_058f;
			}
		}
		CleanupChallengeModifiers();
		return;
		IL_058f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_057f;
		IL_057f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_045a;
		IL_0554:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_056f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_055f;
		IL_044a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_056f;
		IL_045a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_044a;
		IL_055f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0554;
	}

	private static void OnNewRunStarted()
	{
		//IL_0693: Expected O, but got I
		//IL_0032: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_06c0: Expected I, but got O
		//IL_007c: Expected I, but got O
		//IL_00b5: Expected I, but got O
		//IL_06e1: Expected I, but got O
		//IL_06ea: Expected O, but got I4
		//IL_06ff: Expected O, but got I
		//IL_070f: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_0754: Expected O, but got I
		//IL_0116: Expected O, but got I4
		//IL_0522: Expected I, but got O
		//IL_0148: Expected O, but got I
		//IL_07fa: Expected I, but got O
		//IL_0601: Expected O, but got I
		//IL_056d: Expected I, but got O
		//IL_01a7: Expected O, but got I
		//IL_01c8: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_0824: Expected I, but got O
		//IL_0852: Expected I, but got O
		//IL_085a: Expected O, but got I
		//IL_01fb: Expected O, but got I
		//IL_05ba: Expected I, but got O
		//IL_0221: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_02a2: Expected I, but got O
		//IL_02bb: Expected I, but got O
		//IL_02db: Expected O, but got I
		//IL_0326: Expected I, but got O
		//IL_0357: Expected O, but got I
		//IL_0375: Expected O, but got I
		//IL_03aa: Expected O, but got I
		//IL_03bb: Expected O, but got I
		//IL_03e6: Expected I, but got O
		//IL_0418: Expected I, but got O
		//IL_0436: Expected O, but got I
		//IL_045b: Expected I, but got O
		//IL_0487: Expected I, but got O
		//IL_04b4: Expected O, but got I
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		victory = false;
		HashSet<string> hashSet = modifierNames;
		if (modifierNames != null)
		{
			modifierNames.Clear();
			CleanupChallengeModifiers();
			hashSet = (HashSet<string>)(object)MapController.runConfig;
			bool flag = MapController.runConfig == null;
			UnityEngine.Object obj = (UnityEngine.Object)0;
			if (!flag)
			{
				if (!((UnityEngine.Object)hashSet._freeList != null))
				{
					return;
				}
				hashSet = (HashSet<string>)hashSet._freeList;
				RunConfig runConfig = MapController.runConfig;
				bool flag2 = MapController.runConfig == null;
				nint num = unchecked((nint)null);
				obj = null;
				if (!flag2)
				{
					ChallengeData challenge = runConfig.challenge;
					bool flag3 = (object)runConfig.challenge == null;
					num = unchecked((nint)null);
					obj = null;
					if (!flag3)
					{
						obj = (UnityEngine.Object)(object)challenge.challengeModifiers;
						bool flag4 = challenge.challengeModifiers == null;
						num = unchecked((nint)null);
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v1 (UnityEngine.Object)+18]");
							ChallengeModifier[] array = new ChallengeModifier[0];
							challengeModifiers = array;
							num = unchecked((nint)null);
							object obj2 = 0;
							object obj10 = default(object);
							object obj11 = default(object);
							while (true)
							{
								hashSet = (HashSet<string>)(object)typeof(ChallengesTracker);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+B8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v47+8]");
								obj = (UnityEngine.Object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v47+8]");
								if ((nint)0 == 0)
								{
									break;
								}
								object obj4 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v1 (UnityEngine.Object)+18]");
								if ((nint)obj4 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+B8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v76+8]");
									object obj6 = 0;
									hashSet = (HashSet<string>)(object)MapController.runConfig;
									if (MapController.runConfig == null)
									{
										break;
									}
									hashSet = (HashSet<string>)hashSet._freeList;
									if (hashSet._freeList == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+A8]");
									hashSet = (HashSet<string>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+A8]");
									if ((nint)0 == 0)
									{
										break;
									}
									object obj7 = obj2;
									HashSet<string>.Slot[] slots = hashSet._slots;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<HashSet<string>.Slot[], UIntPtr>(ref slots))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+20+v82 @ rbx_v14*8]");
										ChallengeModifier challengeModifier = UnityEngine.Object.Instantiate((ChallengeModifier)0);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v76+8]");
										bool flag5 = (nint)0 == 0;
										obj = (UnityEngine.Object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+20+v82 @ rbx_v14*8]");
										hashSet = (HashSet<string>)0;
										if (flag5)
										{
											break;
										}
										bool flag6 = (object)challengeModifier == null;
										UnityEngine.Object obj8 = (UnityEngine.Object)0;
										if (!flag6)
										{
											object obj9 = obj6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v30+40]");
											obj8 = (UnityEngine.Object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											bool flag7 = obj10 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v30+40]");
											obj = (UnityEngine.Object)0;
											hashSet = (HashSet<string>)(object)challengeModifier;
											if (flag7)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
												throw obj11;
											}
										}
										object obj12 = obj2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v10+18]");
										bool flag8 = (nint)obj12 >= 0;
										obj = obj8;
										if (!flag8)
										{
											nint num2 = (nint)typeof(ChallengesTracker);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v88 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Challenges.ChallengesTracker>)+B8]");
											nint num3 = 0;
											num = (nint)challengeModifiers;
											bool flag9 = challengeModifiers == null;
											obj = challengeModifier;
											hashSet = (HashSet<string>)num3;
											if (flag9)
											{
												break;
											}
											object obj13 = obj2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r8_v1 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Challenges.ChallengesTracker>)+18]");
											bool flag10 = (nint)obj13 >= 0;
											obj = challengeModifier;
											if (!flag10)
											{
												nint num4 = (nint)typeof(MapController);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v89 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
												nint num5 = 0;
												obj = (UnityEngine.Object)(object)MapController.runConfig;
												bool flag11 = MapController.runConfig == null;
												hashSet = (HashSet<string>)num5;
												if (flag11)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r8_v1 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Challenges.ChallengesTracker>)+20+v82 @ rbx_v14*8]");
												hashSet = (HashSet<string>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r8_v1 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Challenges.ChallengesTracker>)+20+v82 @ rbx_v14*8]");
												if ((nint)0 == 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v1 (UnityEngine.Object)+28]");
												obj = (UnityEngine.Object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r8_v1 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Challenges.ChallengesTracker>)+20+v82 @ rbx_v14*8]");
												int count = ((HashSet<T>)0).Count;
												hashSet = (HashSet<string>)(object)challengeModifiers;
												bool flag12 = challengeModifiers == null;
												num = (nint)typeof(ChallengesTracker);
												if (flag12)
												{
													break;
												}
												object obj14 = obj2;
												HashSet<string>.Slot[] slots2 = hashSet._slots;
												bool flag13 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) >= System.Runtime.CompilerServices.Unsafe.As<HashSet<string>.Slot[], UIntPtr>(ref slots2);
												num = (nint)typeof(ChallengesTracker);
												if (!flag13)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+20+v82 @ rbx_v14*8]");
													obj = (UnityEngine.Object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v42 (System.Collections.Generic.HashSet`1<System.String>)+20+v82 @ rbx_v14*8]");
													bool flag14 = (nint)0 == 0;
													num = (nint)typeof(ChallengesTracker);
													if (flag14)
													{
														break;
													}
													bool flag15 = modifierNames == null;
													num = (nint)typeof(ChallengesTracker);
													hashSet = modifierNames;
													if (flag15)
													{
														break;
													}
													HashSet<string> hashSet2 = modifierNames;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v1 (UnityEngine.Object)+18]");
													bool flag16 = hashSet2.Add((string)0);
													obj2++;
													num = 0;
													continue;
												}
											}
										}
									}
									throw new IndexOutOfRangeException();
								}
								RunConfig runConfig2 = MapController.runConfig;
								if (MapController.runConfig == null)
								{
									break;
								}
								ChallengeData challenge2 = runConfig2.challenge;
								if ((object)runConfig2.challenge == null)
								{
									break;
								}
								bool flag17 = challenge2.winCondition != null;
								num = unchecked((nint)null);
								obj = null;
								if (flag17)
								{
									hashSet = (HashSet<string>)(object)challenge2.winCondition;
									RunConfig runConfig3 = MapController.runConfig;
									bool flag18 = MapController.runConfig == null;
									num = unchecked((nint)null);
									obj = null;
									if (flag18)
									{
										break;
									}
									ChallengeData challenge3 = runConfig3.challenge;
									bool flag19 = (object)runConfig3.challenge == null;
									num = unchecked((nint)null);
									obj = null;
									if (flag19)
									{
										break;
									}
									ChallengeWinCondition challengeWinCondition = UnityEngine.Object.Instantiate(challenge3.winCondition);
									winCondition = challengeWinCondition;
									nint num6 = (nint)typeof(MapController);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v64 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
									nint num7 = 0;
									obj = (UnityEngine.Object)(object)MapController.runConfig;
									bool flag20 = MapController.runConfig == null;
									num = unchecked((nint)null);
									hashSet = (HashSet<string>)num7;
									if (flag20)
									{
										break;
									}
									hashSet = (HashSet<string>)(object)winCondition;
									bool flag21 = (object)winCondition == null;
									num = unchecked((nint)null);
									if (flag21)
									{
										break;
									}
									int count2 = ((HashSet<T>)(object)winCondition).Count;
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022C0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022D0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rax_v10+30]");
								object obj15 = 0;
								throw new NullReferenceException();
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static ChallengeData GetCurrentChallenge()
	{
		if (MapController.runConfig == null)
		{
			return null;
		}
		RunConfig runConfig = MapController.runConfig;
		if (MapController.runConfig != null)
		{
			return runConfig.challenge;
		}
		return (ChallengeData)(object)new NullReferenceException();
	}

	public static void Tick()
	{
		//IL_0037: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		if (challengeModifiers == null)
		{
			return;
		}
		ChallengeModifier[] array = challengeModifiers;
		if (array.Length != 0)
		{
			ChallengeModifier[] array2 = challengeModifiers;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array2.Length)
			{
				array2[obj].Tick();
				obj++;
				obj2 = obj;
			}
		}
	}

	private static void CleanupChallengeModifiers()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (challengeModifiers != null)
		{
			ChallengeModifier[] array = challengeModifiers;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].Cleanup();
				obj++;
				obj2 = obj;
			}
			challengeModifiers = null;
		}
		if (winCondition != null)
		{
			winCondition.Cleanup();
			winCondition = null;
		}
	}

	public static void CompleteChallenge()
	{
		//IL_0073: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_00a0: Expected O, but got I
		RunConfig runConfig = MapController.runConfig;
		if (runConfig.challenge != null)
		{
			RunConfig runConfig2 = MapController.runConfig;
			ChallengeData challenge = runConfig2.challenge;
			bool flag = MyAchievements.TryUnlock(challenge.internalName);
			Action<ChallengeData> a_ChallengeCompleted = A_ChallengeCompleted;
			if (A_ChallengeCompleted != null)
			{
				RunConfig runConfig3 = MapController.runConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v6 (System.Action`1<ChallengeData>)+28]");
				object obj = 0;
				ChallengeData challenge2 = runConfig3.challenge;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v6 (System.Action`1<ChallengeData>)+40]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v6 (System.Action`1<ChallengeData>)+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v156 @ rax_v23 (should have been resolved before IL gen)");
			}
		}
	}

	public static bool HasChallengeModifier(string internalName)
	{
		//IL_002a: Expected I4, but got O
		if (modifierNames != null)
		{
			return ((HashSet<object>)(object)modifierNames).Contains((object)internalName);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static List<string> GetChallengeModifiers()
	{
		return (List<string>)(object)Enumerable.ToList((IEnumerable<object>)modifierNames);
	}

	private unsafe static void OnInventoryInitialized(PlayerInventory pinv)
	{
		//IL_0030: Expected O, but got Ref
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0155: Invalid comparison between O and F4
		//IL_0097: Expected O, but got Ref
		if (!MapController.IsFirstStage())
		{
			return;
		}
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		float stat = MyStats.GetStat(text);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		bool addToShrineLog = default(bool);
		if ((nint)text > 0)
		{
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.SilverIncreaseMultiplier;
			string text2 = ((Enum)(&intPtr)).ToString();
			float stat2 = MyStats.GetStat(text2);
			statModifier.modifyType = EStatModifyType.Addition;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float modification = (float)text2 * 0.01f;
			statModifier.modification = modification;
			pinv.statInventory.ChangeStat(statModifier, permanent: true, 0f, addToShrineLog);
		}
		float silverMultiplier = MapController.runConfig.GetSilverMultiplier();
		float num = silverMultiplier - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f))
		{
			StatModifier statModifier2 = new StatModifier();
			statModifier2.stat = EStat.SilverIncreaseMultiplier;
			float silverMultiplier2 = MapController.runConfig.GetSilverMultiplier();
			statModifier2.modification = silverMultiplier2;
			statModifier2.modifyType = EStatModifyType.Multiplication;
			pinv.statInventory.ChangeStat(statModifier2, permanent: true, 0f, addToShrineLog);
		}
		ShopItemData shopItemData = DataManager.Instance.GetShopItemData(EShopItem.Silver);
		int level = shopItemData.GetLevel();
		if (level > 0)
		{
			StatModifier statModifier3 = new StatModifier();
			statModifier3.stat = EStat.SilverIncreaseMultiplier;
			ShopItemData shopItemData2 = DataManager.Instance.GetShopItemData(EShopItem.Silver);
			int level2 = shopItemData2.GetLevel();
			ShopItemData shopItemData3 = DataManager.Instance.GetShopItemData(EShopItem.Silver);
			statModifier3.modifyType = EStatModifyType.Addition;
			float num2 = shopItemData3.value / 100f;
			float modification2 = num2 * (float)level2;
			statModifier3.modification = modification2;
			pinv.statInventory.ChangeStat(statModifier3, permanent: true, 0f, addToShrineLog);
		}
		if (challengeModifiers == null)
		{
			return;
		}
		ChallengeModifier[] array = challengeModifiers;
		EStatModifyType eStatModifyType = EStatModifyType.Addition;
		EStatModifyType eStatModifyType2 = EStatModifyType.Addition;
		while ((int)eStatModifyType2 < array.Length)
		{
			ChallengeModifier challengeModifier = array[(int)eStatModifyType];
			StatModifier[] statModifiers = challengeModifier.statModifiers;
			for (EStatModifyType eStatModifyType3 = EStatModifyType.Addition; (int)eStatModifyType3 < statModifiers.Length; eStatModifyType3++)
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				inventory.statInventory.ChangeStat(statModifiers[(int)eStatModifyType3], permanent: true, 0f, addToShrineLog);
			}
			challengeModifier.OnStatsApplied();
			eStatModifyType++;
			eStatModifyType2 = eStatModifyType;
		}
	}

	public static bool HasChallenge()
	{
		//IL_006e: Expected I4, but got O
		RunConfig runConfig = MapController.runConfig;
		if (MapController.runConfig != null)
		{
			if (runConfig.challenge != null && challengeModifiers != null)
			{
				ChallengeModifier[] array = challengeModifiers;
				if (challengeModifiers == null)
				{
					goto IL_0060;
				}
				if (array.Length != 0)
				{
					return true;
				}
			}
			return false;
		}
		goto IL_0060;
		IL_0060:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static void OnGameOver()
	{
		//IL_009d: Expected O, but got I
		//IL_00ed: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_0193: Expected O, but got I
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		MyPlayer instance = MyPlayer.Instance;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		MenuMeta menuMeta = progression.menuMeta;
		progression.menuMeta.VerifyMap(mapData.eMap);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)menuMeta.mapsProgress).get_Item((System.Int32Enum)mapData.eMap);
		RunConfig runConfig = MapController.runConfig;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+38]");
		if (!((Dictionary<int, int>)0).ContainsKey(runConfig.mapTierIndex))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+38]");
			((Dictionary<int, int>)0).set_Item(runConfig.mapTierIndex, 0);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+38]");
		int num = ((Dictionary<int, int>)0).get_Item(runConfig.mapTierIndex);
		int value = num + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+38]");
		((Dictionary<int, int>)0).set_Item(runConfig.mapTierIndex, value);
		if (~(victory ? 1u : 0u) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+30]");
			if (!((Dictionary<int, HashSet<ECharacter>>)0).ContainsKey(runConfig.mapTierIndex))
			{
				HashSet<ECharacter> value2 = (HashSet<ECharacter>)(object)new HashSet<System.Int32Enum>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+30]");
				((Dictionary<int, object>)0).Add(runConfig.mapTierIndex, value2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v19 (System.Object)+30]");
			HashSet<ECharacter> hashSet = ((Dictionary<int, HashSet<ECharacter>>)0).get_Item(runConfig.mapTierIndex);
			bool flag = hashSet.Add(instance.character);
			((MapProgress)obj).CompleteTier(runConfig.mapTierIndex);
		}
	}

	private static void OnStagebossDefeated()
	{
		//IL_0096: Expected I, but got O
		//IL_015f: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_0199: Expected O, but got I
		if (!MapController.IsTierFinalStage())
		{
			return;
		}
		victory = true;
		RunConfig runConfig = MapController.runConfig;
		if (runConfig.challenge != null && challengeModifiers != null)
		{
			ChallengeModifier[] array = challengeModifiers;
			if (array.Length != 0)
			{
				goto IL_00d3;
			}
		}
		nint num = (nint)typeof(MapController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rax_v49 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
		nint num2 = 0;
		if (MapController.isFinalBossStage)
		{
			float num3 = MyTime.runTimer * 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		}
		goto IL_00d3;
		IL_00d3:
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		MenuMeta menuMeta = progression.menuMeta;
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		progression.menuMeta.VerifyMap(mapData.eMap);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)menuMeta.mapsProgress).get_Item((System.Int32Enum)mapData.eMap);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+48]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+24]");
		if (((Dictionary<int, float>)num4).ContainsKey(0))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+48]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+24]");
			float num6 = ((Dictionary<int, float>)num5).get_Item(0);
			if (!(num6 > MyTime.runTimer))
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+48]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v28 (System.Object)+24]");
		((Dictionary<int, float>)num7).set_Item(0, MyTime.runTimer);
	}

	static ChallengesTracker()
	{
		HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
		modifierNames = hashSet;
		victory = false;
	}
}
