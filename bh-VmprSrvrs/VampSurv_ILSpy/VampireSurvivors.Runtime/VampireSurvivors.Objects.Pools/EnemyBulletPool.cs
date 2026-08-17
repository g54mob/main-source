using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Pools;

public class EnemyBulletPool : PhysicsGroup
{
	private ObjectPool _pool;

	public bool IsUncapped;

	public int UpperLimit;

	private static readonly ProfilerMarker _markerSpawnAt;

	public int AliveObjectsCount
	{
		get
		{
			//IL_005e: Expected I4, but got O
			ObjectPool pool = _pool;
			if ((object)_pool != null)
			{
				Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
				if (pool._aliveObjects != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v3 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v3 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
					return (int)(num - 0);
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public Dictionary<int, GameObject> Spawned
	{
		get
		{
			ObjectPool pool = _pool;
			if ((object)_pool != null)
			{
				return pool._aliveObjects;
			}
			return (Dictionary<int, GameObject>)(object)new NullReferenceException();
		}
	}

	public EnemyBulletPool(EnemyProjectile projectilePrefab, int capacity = 50)
	{
		//IL_0078: Expected I4, but got I8
		UpperLimit = 50;
		((Group)this)._002Ector(capacity);
		_physicsType = PhysicsType.DYNAMIC_BODY;
		if ((object)projectilePrefab != null && ((UnityEngine.Object)projectilePrefab).m_CachedPtr != (IntPtr)0)
		{
			GameObject template = projectilePrefab.gameObject;
			ObjectPool pool = ObjectPool.CreateAndInitialize(template, capacity, -1);
			_pool = pool;
			ObjectPool pool2 = _pool;
			MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(pool2._name, _pool);
			RBush rBush = ArcadePhysics.s_world.addGroupTree(this);
		}
		else
		{
			Debug.Log("Bullet pool has no projectile prefab.  Ignore if from the Candybox");
		}
	}

	public EnemyProjectile SpawnAt(float x, float y, float2 direction, int index = 0)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 10 Invalid \"Jump target not found in method: 0x187321120\"");
		EnemyProjectile result = default(EnemyProjectile);
		return result;
	}

	public unsafe EnemyProjectile SpawnAt(float2 pos, float2 direction, int index = 0)
	{
		//IL_00ab: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_01fc: Expected O, but got Ref
		//IL_01fc: Expected O, but got Ref
		ObjectPool pool = _pool;
		if ((object)_pool == null || ((UnityEngine.Object)pool).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0278;
		}
		ObjectPool pool2 = _pool;
		EnemyProjectile enemyProjectile;
		if ((object)_pool != null)
		{
			Dictionary<int, GameObject> aliveObjects = pool2._aliveObjects;
			if (pool2._aliveObjects != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v11 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v11 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
				object obj = num - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10790h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				if ((nint)pool2._aliveObjects >= 0)
				{
					if (!IsUncapped)
					{
						goto IL_0278;
					}
					ObjectPool pool3 = _pool;
					Dictionary<int, GameObject> aliveObjects2 = pool3._aliveObjects;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v31 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v31 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
					object obj2 = num2 - 0;
					if ((nint)obj2 > 0)
					{
						ObjectPool pool4 = _pool;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF2590");
						GameObject gameObject = default(GameObject);
						if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
						{
							EnemyProjectile component = gameObject.GetComponent<EnemyProjectile>();
							if ((object)component == null)
							{
								goto IL_0282;
							}
							float2 float5 = (float2)component;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v388 @ r8_v11 (Unity.Mathematics.float2)+278] (should have been resolved before IL gen)");
						}
					}
				}
				if ((object)_pool != null)
				{
					object obj4 = default(object);
					object obj5 = default(object);
					GameObject obj3 = _pool.GetObject((Vector3)(&obj4), (Quaternion)(&obj5));
					enemyProjectile = _pool.GetObjectComponent<EnemyProjectile>(obj3);
					if ((object)enemyProjectile != null && ((UnityEngine.Object)enemyProjectile).m_CachedPtr != (IntPtr)0)
					{
						enemyProjectile.InitProjectile(index, direction, this);
						Group obj6 = add(enemyProjectile);
					}
					goto IL_030c;
				}
			}
		}
		goto IL_0282;
		IL_0282:
		return (EnemyProjectile)(object)new NullReferenceException();
		IL_030c:
		return enemyProjectile;
		IL_0278:
		enemyProjectile = null;
		goto IL_030c;
	}

	public void Return(EnemyProjectile projectile)
	{
		if ((object)_pool != null)
		{
			GameObject obj = projectile.gameObject;
			_pool.Release(obj);
		}
	}

	public void Cleanup()
	{
		//IL_0018: Expected I, but got O
		//IL_0021: Expected O, but got I4
		//IL_003e: Expected O, but got I
		//IL_007a: Expected O, but got I
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		nint num = (nint)typeof(EnemyProjectile);
		object obj = 0;
		object obj2 = obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r9_v5+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r9_v5+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v15+FFFFFFF8+v266 @ rax_v14*8]");
			if (0 != (nint)typeof(EnemyProjectile))
			{
			}
		}
		throw new InvalidCastException();
	}

	public void Destroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		if ((object)_pool != null)
		{
			_pool.ReleaseAll();
		}
		ObjectPool pool = _pool;
		if ((object)_pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			ObjectPool pool2 = _pool;
			int num = masterObjectPooler._poolTable.FindEntry(pool2._name);
			if (num >= 0)
			{
				ObjectPool pool3 = _pool;
				MasterObjectPooler._003CInstance_003Ek__BackingField.DestroyPool(pool3._name);
			}
		}
	}

	static EnemyBulletPool()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("EnemyBulletPool.SpawnAt", 1, MarkerFlags.Default, 0);
		_markerSpawnAt = (ProfilerMarker)(nint)intPtr;
	}
}
