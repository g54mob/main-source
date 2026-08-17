using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace QFSW.MOP2;

public class MasterObjectPooler : MonoBehaviour
{
	private bool _singletonMode;

	private bool _LogReleaseWarnings;

	private ObjectPool[] _pools;

	private static MasterObjectPooler _003CInstance_003Ek__BackingField;

	private readonly Dictionary<string, ObjectPool> _poolTable;

	public static MasterObjectPooler Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public bool LogReleaseWarnings => _LogReleaseWarnings;

	// C# has no syntax for parameterized property 'Item'.
	public ObjectPool get_Item(string poolName)
	{
		return GetPool(poolName);
	}

	public void set_Item(string poolName, ObjectPool value)
	{
		bool flag = ((Dictionary<object, object>)(object)_poolTable).Remove((object)poolName);
		AddPool(poolName, value);
	}

	public Dictionary<string, ObjectPool> PoolTable => _poolTable;

	public List<ObjectPool> PoolTablePools
	{
		get
		{
			Dictionary<string, ObjectPool>.ValueCollection values = _poolTable.Values;
			if (values != null)
			{
				return (List<ObjectPool>)(object)new List<object>(values);
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
	}

	private void Awake()
	{
		if (!_singletonMode)
		{
			return;
		}
		MasterObjectPooler masterObjectPooler = _003CInstance_003Ek__BackingField;
		if ((object)_003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)masterObjectPooler).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			return;
		}
		_003CInstance_003Ek__BackingField = this;
		Transform transform = base.transform;
		Transform parent = transform.parent;
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			string text = GetName();
			string message = "Singleton mode enabled for the Master Object Pooler '" + text + "' which is not a root GameObject; this means it cannot be made scene persistent";
			Debug.LogWarning(message);
		}
		else
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}
	}

	private void Start()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		ObjectPool[] pools = _pools;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < pools.Length)
		{
			ObjectPool objectPool = pools[obj2];
			AddPool(objectPool._name, pools[obj2]);
			obj2++;
			obj = obj2;
		}
	}

	private void DestroyPoolInternal(ObjectPool pool)
	{
		pool.Purge();
	}

	public void AddPool(ObjectPool pool)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x1851DF440\"");
		throw new NullReferenceException();
	}

	public void AddPool(string poolName, ObjectPool pool)
	{
		if (!pool._003CInitialized_003Ek__BackingField)
		{
			pool._003CInitialized_003Ek__BackingField = true;
			pool.AutoFillName();
			pool.Populate(pool._defaultSize);
		}
		int num = _poolTable.FindEntry(poolName);
		if (num < 0)
		{
			bool flag = ((Dictionary<object, object>)(object)_poolTable).TryInsert((object)poolName, (object)pool, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			return;
		}
		string message = poolName + " could not be added to the pool table as a pool with the same name already exists";
		Debug.LogWarning(message);
	}

	public ObjectPool GetPool(string poolName)
	{
		if (((Dictionary<object, object>)(object)_poolTable).TryGetValue((object)poolName, out object value))
		{
			return (ObjectPool)value;
		}
		string text = "Cannot get pool " + poolName + " as it is not present in the pool table";
		object obj = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj;
	}

	public void RemoveAndDestroyPoolInstance(ObjectPool pool)
	{
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0 && _poolTable.ContainsValue(pool))
		{
			bool flag = ((Dictionary<object, object>)(object)_poolTable).Remove((object)pool._name);
			pool.Purge();
			UnityEngine.Object.Destroy(pool, 0f);
		}
	}

	public void DestroyAllPoolsAndRuntimeInstances()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		Dictionary<string, ObjectPool>.ValueCollection values = _poolTable.Values;
		IEnumerable<object> enumerable = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj11 = default(object);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				object obj6;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+20]");
					if ((nint)obj5 < 0)
					{
						obj6 = obj3 + 1;
						object obj7 = obj3 * 2;
						object obj8 = obj3 + obj7;
						object obj9 = obj8 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+18]");
						object obj10 = 0 + obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v32+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj6;
						continue;
					}
					_poolTable.Clear();
					return;
				}
				while (flag);
				bool flag2 = Enumerable.Contains(_pools, obj11);
				obj4 = obj6;
				if (!flag2)
				{
					((ObjectPool)obj11).Purge();
					UnityEngine.Object.Destroy((UnityEngine.Object)obj11);
					obj4 = obj6;
				}
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			enumerable = null;
			break;
		}
		throw new NullReferenceException();
	}

	public void DestroyAllPools()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		Dictionary<string, ObjectPool>.ValueCollection values = _poolTable.Values;
		ObjectPool objectPool = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		ObjectPool objectPool2 = default(ObjectPool);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ stack_-28_v10+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ stack_-28_v10+20]");
					if ((nint)obj5 < 0)
					{
						obj4 = obj3 + 1;
						object obj6 = obj3 * 2;
						object obj7 = obj3 + obj6;
						object obj8 = obj7 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ stack_-28_v10+18]");
						object obj9 = 0 + obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rax_v33+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					_poolTable.Clear();
					return;
				}
				while (flag);
				objectPool2.Purge();
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			objectPool = null;
			break;
		}
		throw new NullReferenceException();
	}

	public void DestroyPool(string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		pool.Purge();
		bool flag = ((Dictionary<object, object>)(object)_poolTable).Remove((object)poolName);
	}

	public void ReinitStartingPools()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		ObjectPool[] pools = _pools;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < pools.Length)
		{
			ObjectPool objectPool = pools[obj2];
			objectPool._003CInitialized_003Ek__BackingField = true;
			objectPool.AutoFillName();
			objectPool.Populate(objectPool._defaultSize);
			obj2++;
			obj = obj2;
		}
	}

	public GameObject GetObject(string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null)
		{
			return pool.GetObject();
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public unsafe GameObject GetObject(string poolName, Vector3 position)
	{
		//IL_0038: Expected O, but got Ref
		ObjectPool pool = GetPool(poolName);
		object obj = default(object);
		if ((object)pool != null)
		{
			return pool.GetObject((Vector3)(&obj));
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public unsafe GameObject GetObject(string poolName, Vector3 position, Quaternion rotation)
	{
		//IL_0041: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		ObjectPool pool = GetPool(poolName);
		object obj = default(object);
		object obj2 = default(object);
		if ((object)pool != null)
		{
			return pool.GetObject((Vector3)(&obj), (Quaternion)(&obj2));
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public T GetObjectComponent<T>(string poolName) where T : class
	{
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null)
		{
			return pool.GetObjectComponent<T>();
		}
		return (T)(object)new NullReferenceException();
	}

	public unsafe T GetObjectComponent<T>(string poolName, Vector3 position) where T : class
	{
		//IL_0042: Expected O, but got Ref
		ObjectPool pool = GetPool(poolName);
		object obj = default(object);
		if ((object)pool != null)
		{
			return pool.GetObjectComponent<T>((Vector3)(&obj));
		}
		return (T)(object)new NullReferenceException();
	}

	public unsafe T GetObjectComponent<T>(string poolName, Vector3 position, Quaternion rotation) where T : class
	{
		//IL_0072: Expected O, but got I
		//IL_00c7: Expected O, but got Ref
		//IL_00c7: Expected O, but got Ref
		//IL_00db: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
			object obj = 0;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rbx_v2+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			object obj3 = default(object);
			object obj4 = default(object);
			GameObject gameObject = pool.GetObject((Vector3)(&obj3), (Quaternion)(&obj4));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rbx_v2+38]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B7E40");
			T result = default(T);
			return result;
		}
		return (T)(object)new NullReferenceException();
	}

	public void Release(GameObject obj, string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		pool.Release(obj);
	}

	public void Release(IEnumerable<GameObject> objs, string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		pool.Release(objs);
	}

	public void ReleaseAll(string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		pool.ReleaseAll();
	}

	public void Destroy(GameObject obj)
	{
		string poolName = ((UnityEngine.Object)obj).GetName();
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			pool.Destroy(obj);
		}
		else
		{
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	public void Destroy(GameObject obj, string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			pool.Destroy(obj);
		}
		else
		{
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	public unsafe void Destroy(IEnumerable<GameObject> objs, string poolName)
	{
		//IL_005d: Expected O, but got Ref
		//IL_014b: Expected O, but got I4
		//IL_00f0: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_018b: Expected O, but got I
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			pool.Destroy(objs);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		UnityEngine.Object obj3 = null;
		object obj4 = default(object);
		object obj14 = default(object);
		UnityEngine.Object obj15 = default(UnityEngine.Object);
		while (true)
		{
			object obj13;
			object obj6;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj4 != null)
				{
					bool flag = obj2 == null;
					obj3 = null;
					if (flag)
					{
						break;
					}
					object obj5 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r10_v4+12E]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r10_v4+B0]");
						obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ r8_v9+v406 @ rax_v33*8]");
							if (0 == (nint)typeof(IEnumerator<GameObject>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r10_v4+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_0130;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ r8_v9+8+v462 @ rcx_v27*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + obj5;
						goto IL_0286;
					}
					goto IL_0130;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_0130:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj13 = obj14;
			obj6 = 0;
			goto IL_0286;
			IL_0286:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v467 @ rdx_v10] (should have been resolved before IL gen)");
			UnityEngine.Object.Destroy(obj15, 0f);
		}
		throw new NullReferenceException();
	}

	public void ReleaseAllInAllPools()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		Dictionary<string, ObjectPool>.ValueCollection values = _poolTable.Values;
		ObjectPool objectPool = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		ObjectPool objectPool2 = default(ObjectPool);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+20]");
					if ((nint)obj5 < 0)
					{
						obj4 = obj3 + 1;
						object obj6 = obj3 * 2;
						object obj7 = obj3 + obj6;
						object obj8 = obj7 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+18]");
						object obj9 = 0 + obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v30+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					return;
				}
				while (flag);
				objectPool2.ReleaseAll();
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			objectPool = null;
			break;
		}
		throw new NullReferenceException();
	}

	public void Populate(string poolName, int quantity, PopulateMethod method = PopulateMethod.Set)
	{
		ObjectPool pool = GetPool(poolName);
		pool.Populate(quantity, method);
	}

	public void Purge(string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		pool.Purge();
	}

	public void PurgeAll()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		Dictionary<string, ObjectPool>.ValueCollection values = _poolTable.Values;
		ObjectPool objectPool = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		ObjectPool objectPool2 = default(ObjectPool);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+20]");
					if ((nint)obj5 < 0)
					{
						obj4 = obj3 + 1;
						object obj6 = obj3 * 2;
						object obj7 = obj3 + obj6;
						object obj8 = obj7 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-28_v4+18]");
						object obj9 = 0 + obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v30+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					return;
				}
				while (flag);
				objectPool2.Purge();
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			objectPool = null;
			break;
		}
		throw new NullReferenceException();
	}

	public IEnumerable<GameObject> GetAllActiveObjects(string poolName)
	{
		ObjectPool pool = GetPool(poolName);
		if ((object)pool != null)
		{
			return pool.GetAllActiveObjects();
		}
		return (IEnumerable<GameObject>)new NullReferenceException();
	}

	public MasterObjectPooler()
	{
		ObjectPool[] pools = new ObjectPool[0];
		_pools = pools;
		Dictionary<string, ObjectPool> poolTable = new Dictionary<string, ObjectPool>();
		_poolTable = poolTable;
	}
}
