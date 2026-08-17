using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Extra;

public class BullseyeMarker : MonoBehaviour
{
	private Enemy markedEnemy;

	private float doneAtTime;

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
		Action<Enemy, DamageContainer> b2 = OnEnemyDied;
		Delegate obj6 = Delegate.Combine(Enemy.A_EnemyDied, b2);
		if ((object)obj6 == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<Enemy, DamageContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		Enemy.A_EnemyDied = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<Enemy, DamageContainer>);
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

	private void OnDestroy()
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
		Action<Enemy, DamageContainer> value2 = OnEnemyDied;
		Delegate obj6 = Delegate.Remove(Enemy.A_EnemyDied, value2);
		if ((object)obj6 == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<Enemy, DamageContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		Enemy.A_EnemyDied = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<Enemy, DamageContainer>);
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

	public void Set(Enemy enemy, float duration)
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		markedEnemy = enemy;
		float num = duration + MyTime.time;
		doneAtTime = num;
	}

	private unsafe void Update()
	{
		//IL_0036: Expected O, but got Ref
		//IL_00a3: Expected O, but got Ref
		//IL_00a3: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		if (!(MyTime.time > doneAtTime))
		{
			Transform transform = base.transform;
			Vector3 centerPosition = markedEnemy.GetCenterPosition();
			float num = default(float);
			transform.position = (Vector3)(&num);
			Transform transform2 = PlayerCamera.Instance.transform;
			Vector3 position = transform2.position;
			Transform transform3 = base.transform;
			Vector3 position2 = transform3.position;
			float num2 = default(float);
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num2), (Vector3)(&num));
			float time = Time.time;
			float angle = time * 90f;
			Quaternion quaternion2 = Quaternion.AngleAxis(angle, (Vector3)(&num2));
			Transform transform4 = base.transform;
			transform4.rotation = (Quaternion)(&num2);
		}
		else
		{
			Cleanup();
		}
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
		if (enemy == markedEnemy)
		{
			Cleanup();
		}
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		if (enemy == markedEnemy)
		{
			Cleanup();
		}
	}

	private void Cleanup()
	{
		GameObject gameObject = base.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
		PoolManager instance = PoolManager.Instance;
		ObjectPool<GameObject> bullseyePool = instance.bullseyePool;
		GameObject gameObject3 = base.gameObject;
		Action<GameObject> actionOnRelease = bullseyePool.m_ActionOnRelease;
		if (bullseyePool.m_ActionOnRelease != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v296 @ rax_v15 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if ((object)bullseyePool.m_FreshlyReleased != null)
		{
			int countInactive = bullseyePool.CountInactive;
			if (countInactive >= bullseyePool.m_MaxSize)
			{
				int num = bullseyePool._003CCountAll_003Ek__BackingField - 1;
				bullseyePool._003CCountAll_003Ek__BackingField = num;
				Action<GameObject> actionOnDestroy = bullseyePool.m_ActionOnDestroy;
				if (bullseyePool.m_ActionOnDestroy != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ rax_v26 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			List<object> list = (List<object>)(object)bullseyePool.m_List;
			object[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)gameObject3);
				return;
			}
			int size = list._size + 1;
			list._size = size;
			int num2 = default(int);
			items[num2] = gameObject3;
		}
		else
		{
			bullseyePool.m_FreshlyReleased = gameObject3;
		}
	}
}
