using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Pools;

public class BulletPool : PhysicsGroup
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

	public BulletPool(Projectile projectilePrefab, int capacity = 50)
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
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			ObjectPool pool2 = _pool;
			int num = masterObjectPooler._poolTable.FindEntry(pool2._name);
			if (num < 0)
			{
				ObjectPool pool3 = _pool;
				MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(pool3._name, _pool);
			}
			PhysicsManager sInstance = PhysicsManager._sInstance;
			ArcadePhysics.s_world.addSubsetGroupTree(this, sInstance._bulletGroup);
		}
		else
		{
			Debug.Log("Bullet pool has no projectile prefab.  Ignore if from the Candybox");
		}
	}

	public Projectile SpawnAt(float x, float y, Weapon weapon, int index = 0)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 9 Invalid \"Jump target not found in method: 0x18731FBE0\"");
		Projectile result = default(Projectile);
		return result;
	}

	public unsafe Projectile SpawnAt(float2 pos, Weapon weapon, int index = 0)
	{
		//IL_00ab: Expected O, but got I
		//IL_00c5: Invalid comparison between O and F4
		//IL_012c: Expected O, but got I
		//IL_01f4: Expected O, but got Ref
		//IL_01f4: Expected O, but got Ref
		ObjectPool pool = _pool;
		if ((object)_pool == null || ((UnityEngine.Object)pool).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0270;
		}
		ObjectPool pool2 = _pool;
		Projectile projectile;
		if ((object)_pool != null)
		{
			Dictionary<int, GameObject> aliveObjects = pool2._aliveObjects;
			if (pool2._aliveObjects != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v11 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v11 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
				object obj = num - 0;
				float num2 = (float)UpperLimit * 1.5f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
				{
					if (!IsUncapped)
					{
						goto IL_0270;
					}
					ObjectPool pool3 = _pool;
					Dictionary<int, GameObject> aliveObjects2 = pool3._aliveObjects;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v31 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v31 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
					object obj2 = num3 - 0;
					if ((nint)obj2 > 0)
					{
						ObjectPool pool4 = _pool;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF2590");
						GameObject gameObject = default(GameObject);
						if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
						{
							Projectile component = gameObject.GetComponent<Projectile>();
							if ((object)component == null)
							{
								goto IL_027a;
							}
							Weapon weapon2 = (Weapon)(object)component;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v393 @ r8_v11 (VampireSurvivors.Objects.Weapons.Weapon)+368] (should have been resolved before IL gen)");
						}
					}
				}
				if ((object)_pool != null)
				{
					object obj4 = default(object);
					object obj5 = default(object);
					GameObject obj3 = _pool.GetObject((Vector3)(&obj4), (Quaternion)(&obj5));
					projectile = _pool.GetObjectComponent<Projectile>(obj3);
					if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
					{
						projectile.InitProjectile(this, weapon, index);
						Group obj6 = add(projectile);
					}
					goto IL_0304;
				}
			}
		}
		goto IL_027a;
		IL_027a:
		return (Projectile)(object)new NullReferenceException();
		IL_0304:
		return projectile;
		IL_0270:
		projectile = null;
		goto IL_0304;
	}

	public void Return(Projectile projectile)
	{
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = projectile.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0 && (object)_pool != null)
			{
				GameObject obj = projectile.gameObject;
				_pool.Release(obj);
			}
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
		nint num = (nint)typeof(Projectile);
		object obj = 0;
		object obj2 = obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r9_v5+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r9_v5+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v15+FFFFFFF8+v266 @ rax_v14*8]");
			if (0 != (nint)typeof(Projectile))
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

	static BulletPool()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("BulletPool.SpawnAt", 1, MarkerFlags.Default, 0);
		_markerSpawnAt = (ProfilerMarker)(nint)intPtr;
	}
}
