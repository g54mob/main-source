using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableBossSpawner : BaseInteractable
{
	public GameObject minimapIcon;

	private List<Enemy> bossEnemies;

	public static Action A_BossSpawned;

	public static Action<bool> A_BossDefeated;

	public static Action<int> A_NumBossesDefeated;

	public GameObject preventObjectsSpawningHere;

	public GameObject portal;

	private int numBossesDefeated;

	public GameObject bossCurseFx;

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<Enemy> b = OnEnemyReleasedFromPool;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action = default(Action<Enemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<BaseInteractable, bool> b2 = OnInteractable;
		Delegate obj6 = Delegate.Combine(DetectInteractables.A_Interacted, b2);
		if ((object)obj6 == null)
		{
			DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<BaseInteractable, bool> action2 = default(Action<BaseInteractable, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		DetectInteractables.A_Interacted = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private new void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<Enemy> value = OnEnemyReleasedFromPool;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action = default(Action<Enemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<BaseInteractable, bool> value2 = OnInteractable;
		Delegate obj6 = Delegate.Remove(DetectInteractables.A_Interacted, value2);
		if ((object)obj6 == null)
		{
			DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<BaseInteractable, bool> action2 = default(Action<BaseInteractable, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		DetectInteractables.A_Interacted = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private new void Start()
	{
		base.Start();
		preventObjectsSpawningHere.SetActive(value: false);
	}

	private unsafe void OnEnemyReleasedFromPool(Enemy enemy)
	{
		//IL_01a0: Expected I, but got O
		//IL_01cd: Expected O, but got I
		//IL_011e: Expected O, but got Ref
		if (bossEnemies == null || !((List<object>)(object)bossEnemies).Contains((object)enemy))
		{
			return;
		}
		bool flag = ((List<object>)(object)bossEnemies).Remove((object)enemy);
		List<Enemy> list = bossEnemies;
		int num = numBossesDefeated + 1;
		numBossesDefeated = num;
		if (list._size == 0)
		{
			PickupManager.Instance.PickupAllXp();
			if (CanSpawnPortal())
			{
				portal.SetActive(value: true);
				UiManager instance = UiManager.Instance;
				Transform t = portal.transform;
				nint num2 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				object obj = num4 + 0;
				object obj2 = default(object);
				float timeout = default(float);
				float scaleMultiplier = default(float);
				instance.objectiveArrow.SetTarget(t, (Vector3)(&obj2), 8f, timeout, scaleMultiplier);
			}
			Action<bool> a_BossDefeated = A_BossDefeated;
			if (A_BossDefeated != null)
			{
				bool flag2 = CanSpawnPortal();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v322 @ rdi_v7 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			Action<int> a_NumBossesDefeated = A_NumBossesDefeated;
			if (A_NumBossesDefeated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v300 @ r9_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private bool CanSpawnPortal()
	{
		//IL_0049: Expected I4, but got O
		RunConfig runConfig = MapController.runConfig;
		if (MapController.runConfig == null)
		{
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		if (!MapController.IsLastStage() && MapController.index < runConfig.mapTierIndex)
		{
			return true;
		}
		return false;
	}

	public unsafe override bool Interact()
	{
		//IL_01ca: Expected I4, but got O
		//IL_0092: Expected O, but got Ref
		//IL_00e0: Expected O, but got Ref
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				Vector3 position2 = transform2.position;
				if ((object)MyPlayer.Instance != null)
				{
					Transform transform3 = MyPlayer.Instance.transform;
					if ((object)transform3 != null)
					{
						Vector3 position3 = transform3.position;
						float num = default(float);
						Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
						EnemyManager instance = EnemyManager.Instance;
						if ((object)EnemyManager.Instance != null && instance.summonerController != null)
						{
							List<Enemy> list = instance.summonerController.SpawnStageBoss((Vector3)(&num));
							bossEnemies = list;
							if ((object)minimapIcon != null)
							{
								GameObject gameObject = minimapIcon.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: false);
									GameObject gameObject2 = base.gameObject;
									if ((object)gameObject2 != null)
									{
										gameObject2.tag = "Untagged";
										Action a_BossSpawned = A_BossSpawned;
										if (A_BossSpawned != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v327.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
										}
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnInteractable(BaseInteractable interactable, bool success)
	{
		//IL_0030: Expected I, but got O
		//IL_0038: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_0084: Expected O, but got I
		if (!success || (object)interactable == null)
		{
			return;
		}
		nint num = (nint)typeof(InteractableShrineCursed);
		nint num2 = (nint)interactable;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<InteractableShrineCursed>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v2 (Il2CppClass<BaseInteractable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<InteractableShrineCursed>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v2 (Il2CppClass<BaseInteractable>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4+FFFFFFF8+v61 @ rax_v3*8]");
			if (0 == (nint)typeof(InteractableShrineCursed))
			{
				bossCurseFx.SetActive(value: true);
			}
		}
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C33]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SPAWN_BOSS");
	}

	public InteractableBossSpawner()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
