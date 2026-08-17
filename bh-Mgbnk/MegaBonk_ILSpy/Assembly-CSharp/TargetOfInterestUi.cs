using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class TargetOfInterestUi : MonoBehaviour
{
	public List<TargetOfInterestPrefab> prefabs;

	private HashSet<Enemy> activeTargets;

	private List<Enemy> queuedTargets;

	private Queue<Enemy> addTargetQueue;

	private void Awake()
	{
		//IL_005a: Expected I, but got O
		//IL_005f: Expected I, but got O
		//IL_0068: Expected O, but got I4
		//IL_00ae: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_00bc: Expected O, but got I4
		//IL_015d: Expected I, but got O
		//IL_0162: Expected I, but got O
		//IL_0379: Expected O, but got I4
		//IL_0131: Expected I, but got O
		//IL_01a8: Expected I, but got O
		//IL_01b6: Expected I, but got O
		//IL_01bb: Expected I, but got O
		//IL_03b9: Expected I, but got O
		//IL_03f6: Expected I, but got O
		//IL_024b: Expected I, but got O
		//IL_0290: Expected I, but got O
		//IL_02e2: Expected O, but got I
		//IL_0309: Expected O, but got I
		//IL_030e: Expected I, but got O
		Action<Enemy> b = OnTargetOfInterestSpawned;
		Delegate obj = Delegate.Combine(Enemy.A_TargetOfInterestSpawn, b);
		object obj2;
		nint num;
		Delegate obj3;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_TargetOfInterestSpawn = (Action<Enemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action = default(Action<Enemy>);
			bool flag = action == null;
			num = (nint)typeof(Action<Enemy>);
			num2 = unchecked((nint)null);
			obj2 = 0;
			obj3 = obj;
			if (flag)
			{
				goto IL_034a;
			}
			Enemy.A_TargetOfInterestSpawn = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
			num = (nint)typeof(Action<Enemy>);
			num2 = unchecked((nint)null);
			obj2 = 0;
			obj3 = obj;
			if (flag2)
			{
				goto IL_0355;
			}
		}
		Action<Enemy> b2 = OnEnemyReleasedFromPool;
		Delegate obj5 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b2);
		nint num3;
		if ((object)obj5 == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj5;
			num3 = (nint)Enemy.A_EnemyReleasedFromPool;
			goto IL_01d6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action2 = default(Action<Enemy>);
		bool flag3 = action2 == null;
		num = (nint)typeof(Action<Enemy>);
		num2 = unchecked((nint)null);
		obj3 = obj5;
		if (!flag3)
		{
			Enemy.A_EnemyReleasedFromPool = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag4 = obj6 == null;
			num3 = (nint)typeof(Action<Enemy>);
			num = (nint)typeof(Action<Enemy>);
			num2 = unchecked((nint)null);
			obj3 = obj5;
			if (!flag4)
			{
				goto IL_01d6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj2 = 0;
		goto IL_0355;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_01d6:
		if (!(EnemyManager.Instance != null))
		{
			return;
		}
		EnemyManager instance = EnemyManager.Instance;
		bool flag5 = (object)EnemyManager.Instance == null;
		num = num3;
		num2 = unchecked((nint)null);
		obj3 = (Delegate)(object)EnemyManager.Instance;
		if (!flag5)
		{
			if (instance.enemies == null)
			{
				return;
			}
			EnemyManager instance2 = EnemyManager.Instance;
			bool flag6 = (object)EnemyManager.Instance == null;
			num = num3;
			num2 = unchecked((nint)null);
			obj3 = (Delegate)(object)EnemyManager.Instance;
			if (!flag6)
			{
				bool flag7 = instance2.enemies == null;
				num = num3;
				num2 = unchecked((nint)null);
				obj3 = (Delegate)(object)EnemyManager.Instance;
				if (!flag7)
				{
					Dictionary<uint, Enemy>.ValueCollection values = instance2.enemies.Values;
					bool flag8 = values == null;
					num = num3;
					num2 = unchecked((nint)null);
					obj3 = (Delegate)(object)EnemyManager.Instance;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
						num2 = 0;
						Dictionary<uint, Enemy>.ValueCollection.Enumerator enumerator = default(Dictionary<uint, Enemy>.ValueCollection.Enumerator);
						IntPtr intPtr = default(IntPtr);
						while (true)
						{
							if (enumerator.MoveNext())
							{
								if (intPtr == (IntPtr)0)
								{
									break;
								}
								if (((Enemy)(nint)intPtr).IsBoss())
								{
									OnTargetOfInterestSpawned((Enemy)(nint)intPtr);
									num2 = unchecked((nint)null);
								}
								continue;
							}
							enumerator.Dispose();
							return;
						}
						throw new NullReferenceException();
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0355:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
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
		Action<Enemy> value = OnTargetOfInterestSpawned;
		Delegate obj = Delegate.Remove(Enemy.A_TargetOfInterestSpawn, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_TargetOfInterestSpawn = (Action<Enemy>)obj;
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
			Enemy.A_TargetOfInterestSpawn = action;
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
		Action<Enemy> value2 = OnEnemyReleasedFromPool;
		Delegate obj6 = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value2);
		if ((object)obj6 == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action2 = default(Action<Enemy>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<Enemy>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		Enemy.A_EnemyReleasedFromPool = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<Enemy>);
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

	private void OnTargetOfInterestSpawned(Enemy enemy)
	{
		((Queue<object>)(object)addTargetQueue).Enqueue((object)enemy);
	}

	private void Update()
	{
		//IL_005c: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		UiManager instance = UiManager.Instance;
		CinematicBars cinematicBars = instance.cinematicBars;
		GameObject gameObject = cinematicBars.topBar.gameObject;
		if (gameObject.activeSelf)
		{
			return;
		}
		Queue<Enemy> queue = addTargetQueue;
		object obj = 0;
		object obj2 = 0;
		int num = default(int);
		while ((nint)obj2 < queue._size)
		{
			object obj3 = ((Queue<object>)(object)addTargetQueue).Dequeue();
			HashSet<Enemy> hashSet = activeTargets;
			List<TargetOfInterestPrefab> list = prefabs;
			if (hashSet._count < list._size)
			{
				bool flag = hashSet.Add((Enemy)obj3);
				RefreshPrefabs();
			}
			else
			{
				List<object> list2 = (List<object>)(object)queuedTargets;
				int version = list2._version + 1;
				list2._version = version;
				object[] items = list2._items;
				if (list2._size >= items.Length)
				{
					list2.AddWithResize(obj3);
				}
				else
				{
					int size = list2._size + 1;
					list2._size = size;
					items[num] = obj3;
				}
			}
			queue = addTargetQueue;
			obj++;
			obj2 = obj;
		}
	}

	private void DequeueEnemies(Enemy enemy)
	{
		HashSet<Enemy> hashSet = activeTargets;
		List<TargetOfInterestPrefab> list = prefabs;
		if (hashSet._count < list._size)
		{
			bool flag = hashSet.Add(enemy);
			RefreshPrefabs();
			return;
		}
		List<object> list2 = (List<object>)(object)queuedTargets;
		int version = list2._version + 1;
		list2._version = version;
		object[] items = list2._items;
		if (list2._size >= items.Length)
		{
			list2.AddWithResize((object)enemy);
			return;
		}
		int size = list2._size + 1;
		list2._size = size;
		int num = default(int);
		items[num] = enemy;
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
		//IL_002c: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		bool flag = ((List<object>)(object)queuedTargets).Contains((object)enemy);
		bool flag2 = !flag;
		object obj = 0;
		if (!flag2)
		{
			bool flag3 = ((List<object>)(object)queuedTargets).Remove((object)enemy);
			obj = 1;
		}
		if (((HashSet<object>)(object)activeTargets).Contains((object)enemy))
		{
			bool flag4 = ((HashSet<object>)(object)activeTargets).Remove((object)enemy);
		}
		else if (obj == null)
		{
			return;
		}
		RefreshPrefabs();
	}

	private void RefreshPrefabs()
	{
		HashSet<Enemy> hashSet = activeTargets;
		while (true)
		{
			List<TargetOfInterestPrefab> list = prefabs;
			if (hashSet._count < list._size)
			{
				List<Enemy> list2 = queuedTargets;
				if (list2._size > 0)
				{
					Enemy item = list2.get_Item(0);
					bool flag = activeTargets.Add(item);
					((List<object>)(object)queuedTargets).RemoveAt(0);
					hashSet = activeTargets;
					if (activeTargets == null)
					{
						break;
					}
					continue;
				}
			}
			List<TargetOfInterestPrefab> list3 = prefabs;
			int num = 0;
			for (int num2 = 0; num2 < list3._size; num2 = num)
			{
				HashSet<Enemy> hashSet2 = activeTargets;
				TargetOfInterestPrefab targetOfInterestPrefab2;
				object enemy;
				if (num >= hashSet2._count)
				{
					TargetOfInterestPrefab targetOfInterestPrefab = prefabs.get_Item(num);
					targetOfInterestPrefab2 = targetOfInterestPrefab;
					enemy = null;
				}
				else
				{
					TargetOfInterestPrefab targetOfInterestPrefab3 = prefabs.get_Item(num);
					enemy = Enumerable.ElementAt((IEnumerable<object>)activeTargets, num);
					targetOfInterestPrefab2 = targetOfInterestPrefab3;
				}
				targetOfInterestPrefab2.SetEnemy((Enemy)enemy);
				list3 = prefabs;
				num++;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public TargetOfInterestUi()
	{
		HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
		activeTargets = hashSet;
		queuedTargets = new List<Enemy>();
		addTargetQueue = new Queue<Enemy>();
		base._002Ector();
	}
}
