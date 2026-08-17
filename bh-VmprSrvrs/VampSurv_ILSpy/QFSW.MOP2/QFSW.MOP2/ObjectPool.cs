using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace QFSW.MOP2;

public class ObjectPool : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<GameObject, bool> _003C_003E9__60_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetAllActiveObjects_003Eb__60_0(GameObject x)
		{
			if ((object)x != null)
			{
				bool flag = ((UnityEngine.Object)x).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	private string _name;

	private GameObject _template;

	private int _defaultSize;

	private int _maxSize;

	private bool _incrementalInstanceNames;

	private bool _repopulateOnSceneChange;

	private bool _003CInitialized_003Ek__BackingField;

	private int _instanceCounter;

	private readonly Regex _poolRegex;

	private readonly List<GameObject> _pooledObjects;

	private readonly Dictionary<int, GameObject> _aliveObjects;

	private readonly List<GameObject> _releaseAllBuffer;

	private readonly Dictionary<(int, Type), object> _componentCache;

	private static ProfilerMarker _markerGetObject;

	private static readonly ProfilerMarker MarkerRelease;

	private static readonly ProfilerMarker MarkerReleaseAll;

	public bool IncrementalInstanceNames
	{
		get
		{
			return _incrementalInstanceNames;
		}
		set
		{
			_incrementalInstanceNames = value;
		}
	}

	public string PoolName => _name;

	private bool HasMaxSize
	{
		get
		{
			int num = _maxSize ^ _maxSize;
			int num2 = _maxSize & num;
			bool flag = num2 < 0;
			bool flag2 = _maxSize < 0;
			bool flag3 = _maxSize == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	private bool HasPooledObjects
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<GameObject> pooledObjects = _pooledObjects;
			if (_pooledObjects != null)
			{
				int num = pooledObjects._size ^ pooledObjects._size;
				int num2 = pooledObjects._size & num;
				bool flag = num2 < 0;
				bool flag2 = pooledObjects._size < 0;
				bool flag3 = pooledObjects._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool Initialized
	{
		get
		{
			return _003CInitialized_003Ek__BackingField;
		}
		private set
		{
			_003CInitialized_003Ek__BackingField = value;
		}
	}

	public GameObject Template => _template;

	public List<GameObject> PooledObjects => _pooledObjects;

	private ObjectPool()
	{
		//IL_014a: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_0014: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2+B8]");
		object obj2 = 0;
		_name = (string)obj2;
		_maxSize = -1;
		_poolRegex = new Regex("[_ ]*[Pp]ool");
		List<GameObject> list = null;
		list._items = null;
		_pooledObjects = list;
		Dictionary<int, GameObject> dictionary = null;
		int num = dictionary.Initialize(500);
		if (EqualityComparer<int>.Default != null)
		{
			_ = 0;
		}
		_aliveObjects = dictionary;
		List<GameObject> list2 = null;
		list2._items = null;
		_releaseAllBuffer = list2;
		Dictionary<(int, Type), object> dictionary2 = null;
		int num2 = dictionary2.Initialize(500);
		if (EqualityComparer<(int, object)>.Default != null)
		{
			_ = 0;
		}
		_componentCache = dictionary2;
		base._002Ector();
	}

	public static ObjectPool Create(GameObject template, int defaultSize = 0, int maxSize = -1)
	{
		if ((object)template != null)
		{
			string text = ((UnityEngine.Object)template).GetName();
			return Create(template, text, defaultSize, maxSize);
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public static ObjectPool Create(GameObject template, string name, int defaultSize = 0, int maxSize = -1)
	{
		ObjectPool objectPool = ScriptableObject.CreateInstance<ObjectPool>();
		if ((object)objectPool != null)
		{
			objectPool._name = name;
			objectPool._template = template;
			objectPool._defaultSize = defaultSize;
			objectPool._maxSize = maxSize;
			return objectPool;
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public static ObjectPool CreateAndInitialize(GameObject template, int defaultSize = 0, int maxSize = -1)
	{
		if ((object)template != null)
		{
			string text = ((UnityEngine.Object)template).GetName();
			ObjectPool objectPool = Create(template, text, defaultSize, maxSize);
			if ((object)objectPool != null)
			{
				if (!objectPool._003CInitialized_003Ek__BackingField)
				{
					objectPool._003CInitialized_003Ek__BackingField = true;
					objectPool.AutoFillName();
					objectPool.Populate(objectPool._defaultSize);
				}
				return objectPool;
			}
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public static ObjectPool CreateAndInitialize(GameObject template, string name, int defaultSize = 0, int maxSize = -1)
	{
		ObjectPool objectPool = Create(template, name, defaultSize, maxSize);
		if ((object)objectPool != null)
		{
			if (!objectPool._003CInitialized_003Ek__BackingField)
			{
				objectPool._003CInitialized_003Ek__BackingField = true;
				objectPool.AutoFillName();
				objectPool.Populate(objectPool._defaultSize);
			}
			return objectPool;
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	private void OnEnable()
	{
		_instanceCounter = 0;
		UnityAction<Scene> unityAction = null;
		((ObjectPool)(object)unityAction).OnSceneUnload((Scene)this);
		SceneManager.sceneUnloaded += unityAction;
	}

	private void OnDisable()
	{
		UnityAction<Scene> unityAction = null;
		((ObjectPool)(object)unityAction).OnSceneUnload((Scene)this);
		SceneManager.sceneUnloaded -= unityAction;
	}

	public void Initialize(bool forceReinitialization = false)
	{
		bool flag = _003CInitialized_003Ek__BackingField;
		bool flag2 = forceReinitialization;
		if (!flag)
		{
			flag2 = true;
		}
		if (flag2)
		{
			_003CInitialized_003Ek__BackingField = true;
			AutoFillName();
			Populate(_defaultSize);
		}
	}

	internal void AutoFillName()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0042: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		//IL_01f2: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_021c: Expected O, but got I4
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_02eb: Expected I4, but got I8
		//IL_0082: Expected I4, but got O
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0106: Expected O, but got I4
		//IL_013d: Expected I4, but got O
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		string text = _name;
		if (_name != null)
		{
			object obj = _name + 20;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj2 < text._stringLength)
			{
				if ((nint)obj3 < text._stringLength)
				{
					if (char.IsWhiteSpace((char)(int)obj))
					{
						obj3++;
						obj += 2;
						obj2 = obj3;
						continue;
					}
					goto IL_00c8;
				}
				goto IL_0267;
			}
		}
		Regex poolRegex = _poolRegex;
		string text2 = GetName();
		if (text2 != null)
		{
			object obj4 = poolRegex.roptions & RegexOptions.RightToLeft;
			bool flag = obj4 == null;
			bool flag2 = (nint)obj4 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v15+B8]");
			object replacement = 0;
			bool flag3 = !flag2;
			object obj6 = !flag3;
			object obj7 = obj6 | flag;
			if (obj7 == null)
			{
			}
			int startat = default(int);
			string text3 = poolRegex.Replace(text2, (string)replacement, -1, startat);
			_name = text3;
			goto IL_023c;
		}
		goto IL_02ba;
		IL_02ba:
		ArgumentNullException ex = new ArgumentNullException("input");
		ex._002Ector("input");
		throw ex;
		IL_0267:
		System.ThrowHelper.ThrowIndexOutOfRangeException();
		goto IL_02ba;
		IL_023c:
		SetName(_name);
		return;
		IL_00c8:
		string text4 = GetName();
		if (text4 != null)
		{
			object obj8 = text4 + 20;
			object obj9 = 0;
			while ((nint)obj9 < text4._stringLength)
			{
				if ((nint)obj9 < text4._stringLength)
				{
					if (char.IsWhiteSpace((char)(int)obj8))
					{
						obj9++;
						obj8 += 2;
						continue;
					}
					return;
				}
				goto IL_0267;
			}
		}
		goto IL_023c;
	}

	private void InitializeIPoolable(GameObject go)
	{
		//IL_0061: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		IPoolable[] componentsInChildren = go.GetComponentsInChildren<IPoolable>(includeInactive: false);
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < componentsInChildren.Length)
			{
				componentsInChildren[obj].InitializeTemplate(this);
				obj++;
				obj2 = obj;
			}
		}
	}

	private unsafe GameObject CreateNewObject()
	{
		//IL_011f: Expected O, but got Ref
		//IL_011f: Expected O, but got Ref
		//IL_00dc->IL008b: Incompatible stack heights: 1 vs 0
		//IL_007c->IL008b: Incompatible stack heights: 1 vs 0
		if ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_template != null)
				{
					Transform transform2 = _template.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Quaternion ret2);
						object obj = default(object);
						return CreateNewObject((Vector3)(&ret2), (Quaternion)(&obj));
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe GameObject CreateNewObject(Vector3 position, Quaternion rotation)
	{
		//IL_0099: Expected O, but got Ref
		//IL_010b: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		SwitchNetworking(_template, enable: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
		SwitchNetworking(_template, enable: true);
		string text;
		if (!_incrementalInstanceNames)
		{
			text = ((UnityEngine.Object)_template).GetName();
		}
		else
		{
			string arg = ((UnityEngine.Object)_template).GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			text = string.FormatHelper((IFormatProvider)null, "{0}#{1:000}", (System.ParamsArray)(&obj));
		}
		UnityEngine.Object obj2 = default(UnityEngine.Object);
		obj2.SetName(text);
		IPoolable[] componentsInChildren = ((GameObject)obj2).GetComponentsInChildren<IPoolable>(false);
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			object obj3 = 0;
			object obj4 = 0;
			while ((nint)obj3 < componentsInChildren.Length)
			{
				if ((nint)obj4 < componentsInChildren.Length)
				{
					componentsInChildren[obj4].InitializeTemplate(this);
					obj4++;
					obj3 = obj4;
					continue;
				}
				return (GameObject)(object)new IndexOutOfRangeException();
			}
		}
		int instanceCounter = _instanceCounter + 1;
		_instanceCounter = instanceCounter;
		return (GameObject)obj2;
	}

	private void SwitchNetworking(GameObject obj, bool enable)
	{
		CoherenceSync component = obj.GetComponent<CoherenceSync>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.enabled = enable;
		}
	}

	private void CleanseInternal()
	{
		List<GameObject> pooledObjects = _pooledObjects;
		int version = pooledObjects._version + 1;
		pooledObjects._version = version;
		pooledObjects._size = 0;
		if (pooledObjects._size > 0)
		{
			Array.Clear(pooledObjects._items, 0, pooledObjects._size);
		}
		_aliveObjects.Clear();
		((Dictionary<int, GameObject>)(object)_componentCache).Clear();
	}

	public unsafe GameObject GetObject()
	{
		//IL_0096: Expected O, but got Ref
		if ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				return GetObject((Vector3)(&obj));
			}
		}
		throw new NullReferenceException();
	}

	public unsafe GameObject GetObject(Vector3 position)
	{
		//IL_009f: Expected O, but got Ref
		//IL_009f: Expected O, but got Ref
		if ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Quaternion ret);
				object obj = default(object);
				return GetObject((Vector3)(&ret), (Quaternion)(&obj));
			}
		}
		throw new NullReferenceException();
	}

	public unsafe GameObject GetObject(Vector3 position, Quaternion rotation, bool onlineSynchronization = true)
	{
		//IL_0245: Expected I, but got O
		//IL_007e: Expected O, but got I4
		//IL_003a: Expected O, but got Ref
		//IL_003a: Expected O, but got Ref
		//IL_00c3: Expected O, but got I4
		//IL_0212: Expected O, but got Ref
		//IL_0212: Expected O, but got Ref
		//IL_0231->IL03d4: Incompatible stack heights: 3 vs 2
		//IL_038b->IL024a: Incompatible stack heights: 9 vs 1
		if ((object)_markerGetObject != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)_markerGetObject);
		}
		List<GameObject> pooledObjects = _pooledObjects;
		bool flag = _pooledObjects == null;
		float ret = default(float);
		float value = default(float);
		GameObject gameObject2;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (pooledObjects._size <= 0)
		{
			GameObject gameObject = CreateNewObject((Vector3)(&ret), (Quaternion)(&value));
			gameObject2 = gameObject;
		}
		else
		{
			bool flag2 = _pooledObjects == null;
			object obj = pooledObjects._size - 1;
			bool flag3 = (nint)obj >= pooledObjects._size;
			GameObject[] items = pooledObjects._items;
			object obj2 = pooledObjects._size - 1;
			gameObject2 = items[obj2];
			int index = pooledObjects._size - 1;
			_pooledObjects.RemoveAt(index);
			float rotation2 = default(float);
			if ((object)items[obj2] == null || ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0)
			{
				string message = "Object in pool '" + _name + "' was null or destroyed; it may have been destroyed externally. Attempting to retrieve a new object";
				Debug.LogWarning(message);
				GameObject gameObject3 = GetObject((Vector3)(&value), (Quaternion)(&rotation2));
				autoScope.Dispose();
				gameObject2 = gameObject3;
				goto IL_03d4;
			}
			Transform transform = items[obj2].transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1406 @ rax_v46 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1406 @ rax_v46 (UnityEngine.Transform)+10]");
			float position2 = default(float);
			Transform.SetPositionAndRotation_Injected((IntPtr)0, ref *(Vector3*)(&position2), ref *(Quaternion*)(&rotation2));
			Transform transform2 = items[obj2].transform;
			bool flag5 = (object)_template == null;
			Transform transform3 = _template.transform;
			bool flag6 = (object)transform3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1325 @ rax_v53 (UnityEngine.Transform)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1325 @ rax_v53 (UnityEngine.Transform)+10]");
			Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret));
			bool flag8 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v52 (UnityEngine.Transform)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v52 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
		}
		gameObject2.SetActive(value: true);
		SwitchNetworking(gameObject2, onlineSynchronization);
		bool flag10 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
		int key = 0;
		if (!flag10)
		{
			IntPtr cachedPtr = ((UnityEngine.Object)gameObject2).m_CachedPtr;
			int offsetOfInstanceIDInCPlusPlusObject = UnityEngine.Object.OffsetOfInstanceIDInCPlusPlusObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rcx_v16 (System.Int32)+v871 @ rsi_v5 (System.IntPtr)]");
			key = 0;
		}
		bool flag11 = _aliveObjects == null;
		bool flag12 = ((Dictionary<int, object>)(object)_aliveObjects).TryInsert(key, (object)gameObject2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		autoScope.Dispose();
		goto IL_03d4;
		IL_03d4:
		return gameObject2;
	}

	public unsafe T GetObjectComponent<T>() where T : class
	{
		//IL_00a0: Expected O, but got Ref
		if ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				return GetObjectComponent<T>((Vector3)(&obj));
			}
		}
		throw new NullReferenceException();
	}

	public unsafe T GetObjectComponent<T>(Vector3 position, bool onlineSynchronization = true) where T : class
	{
		//IL_006c: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		if ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Quaternion ret);
				object obj2 = default(object);
				GameObject obj = GetObject((Vector3)(&ret), (Quaternion)(&obj2), onlineSynchronization);
				return GetObjectComponent<T>(obj);
			}
		}
		throw new NullReferenceException();
	}

	public unsafe T GetObjectComponent<T>(Vector3 position, Quaternion rotation, bool onlineSynchronization = true) where T : class
	{
		//IL_0049: Expected O, but got Ref
		//IL_0049: Expected O, but got Ref
		//IL_005d: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = GetObject((Vector3)(&obj), (Quaternion)(&obj2), onlineSynchronization);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B7E40");
		T result = default(T);
		return result;
	}

	public unsafe T GetObjectComponent<T>(GameObject obj) where T : class
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007f: Expected O, but got Ref
		//IL_00b8: Expected O, but got I
		//IL_00db: Expected O, but got I
		//IL_0353: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_02bb: Expected O, but got Ref
		//IL_032d: Expected O, but got Ref
		//IL_011b: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_0168: Expected O, but got I4
		//IL_01f8: Expected O, but got I
		//IL_0232: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		int instanceID = obj.GetInstanceID();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Dictionary<(int, object), object> componentCache = (Dictionary<(int, object), object>)(object)_componentCache;
		int num2 = default(int);
		int num = ((Dictionary<(int, object), object>)(object)_componentCache).FindEntry(((int, object))(&num2));
		if (num < 0)
		{
			goto IL_02c4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v4 (System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Object>, System.Object>)+18]");
		object obj4 = 0;
		int num3 = num << 5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v22 (System.Int32)+38+v126 @ rdi_v10]");
		T val = (T)0;
		Type type = (Type)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v22 (System.Int32)+38+v126 @ rdi_v10]");
		if ((nint)0 != 0)
		{
			Type type2 = (Type)(object)val;
			if (RuntimeTypeHandle.type_is_assignable_from((Type)0, (Type)(object)val))
			{
				goto IL_033e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r15_v9 (System.Type)+136]");
			object obj5 = (nint)0 & (nint)0x10;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rsi_v9 (System.Type)+118]");
				object obj6 = (nint)0 & (nint)0x20;
				bool flag = obj6 == null;
				object obj7 = !flag;
				if (obj7 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rsi_v9 (System.Type)+2A]");
					if ((nint)0 != 19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rsi_v9 (System.Type)+2A]");
						if ((nint)0 != 30)
						{
							goto IL_0256;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rsi_v9 (System.Type)+70]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rsi_v9 (System.Type)+70]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rax_v30+28]");
					if ((nint)0 != 0)
					{
						T val2 = val;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rax_v30+28]");
						if (((Dictionary<(int, Type), object>)(object)val2).FindEntry(((int, Type))0) != 0)
						{
							goto IL_033e;
						}
					}
				}
				goto IL_0256;
			}
		}
		goto IL_028d;
		IL_033e:
		return val;
		IL_02c4:
		object component = obj.GetComponent<T>();
		bool flag2 = component == null;
		val = (T)component;
		if (!flag2)
		{
			if (_componentCache == null)
			{
				goto IL_0380;
			}
			bool flag3 = ((Dictionary<(int, object), object>)(object)_componentCache).TryInsert(((int, object))(&num2), component, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			val = (T)component;
		}
		goto IL_033e;
		IL_0256:
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		bool flag4 = num4 != 0;
		T val3 = null;
		if (!flag4)
		{
			val3 = val;
		}
		bool flag5 = val3 != null;
		val = val3;
		if (!flag5)
		{
			goto IL_028d;
		}
		goto IL_033e;
		IL_028d:
		if (_componentCache != null)
		{
			bool flag6 = ((Dictionary<(int, object), object>)(object)_componentCache).Remove(((int, object))(&num2));
			goto IL_02c4;
		}
		goto IL_0380;
		IL_0380:
		return (T)(object)new NullReferenceException();
	}

	public unsafe void Release(GameObject obj)
	{
		//IL_01ed: Expected I, but got O
		//IL_01a7: Expected O, but got Ref
		//IL_0145: Expected I4, but got O
		//IL_020a->IL01c4: Incompatible stack heights: 2 vs 3
		//IL_015d->IL01fc: Incompatible stack heights: 3 vs 2
		//IL_00f5->IL011b: Incompatible stack heights: 3 vs 2
		if ((object)MarkerRelease != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerRelease);
		}
		bool flag = (object)obj == null;
		int instanceID = obj.GetInstanceID();
		bool flag2 = _aliveObjects == null;
		bool num;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (((Dictionary<int, object>)(object)_aliveObjects).Remove(instanceID))
		{
			if (((UnityEngine.Object)obj).m_CachedPtr != (IntPtr)0)
			{
				if (_maxSize > 0)
				{
					List<GameObject> pooledObjects = _pooledObjects;
					bool flag3 = _pooledObjects == null;
					num = flag3;
					if (pooledObjects._size >= _maxSize)
					{
						UnityEngine.Object.Destroy(obj);
						autoScope.Dispose();
						return;
					}
				}
				bool flag4 = _pooledObjects == null;
				bool flag5 = ((Dictionary<int, GameObject>)(object)_pooledObjects).Remove((int)obj);
				obj.SetActive(value: false);
			}
			autoScope.Dispose();
		}
		else
		{
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			bool flag6 = (object)MasterObjectPooler._003CInstance_003Ek__BackingField == null;
			num = flag6;
			if (masterObjectPooler._LogReleaseWarnings)
			{
				System.ParamsArray paramsArray = new System.ParamsArray(obj, _name);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string message = string.FormatHelper((IFormatProvider)null, "Object '{0}' could not be found in pool '{1}'; it may have already been released.", (System.ParamsArray)(&paramsArray2));
				Debug.LogWarning(message);
			}
			autoScope.Dispose();
		}
	}

	public unsafe void Release(IEnumerable<GameObject> objs)
	{
		//IL_0017: Expected O, but got Ref
		//IL_00e3: Expected O, but got I4
		//IL_0088: Expected O, but got I
		//IL_0091: Expected O, but got I4
		//IL_010b: Expected O, but got I
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ObjectPool objectPool = null;
		GameObject obj14 = default(GameObject);
		object obj3 = default(object);
		object obj13 = default(object);
		for (; obj2 != null; Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ rdx_v9] (should have been resolved before IL gen)"), Release(obj14))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj12;
			object obj5;
			if (obj3 != null)
			{
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+12E]");
				if ((nint)0 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r8_v7+v243 @ rax_v21*8]");
						if (0 == (nint)typeof(IEnumerator<GameObject>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_00c8;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r8_v7+8+v299 @ rcx_v17*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					continue;
				}
				goto IL_00c8;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_00c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj12 = obj13;
			obj5 = 0;
		}
		throw new NullReferenceException();
	}

	public void ReleaseAll()
	{
		List<GameObject> releaseAllBuffer = _releaseAllBuffer;
		int version = releaseAllBuffer._version + 1;
		releaseAllBuffer._version = version;
		releaseAllBuffer._size = 0;
		if (releaseAllBuffer._size > 0)
		{
			Array.Clear(releaseAllBuffer._items, 0, releaseAllBuffer._size);
		}
		List<object> releaseAllBuffer2 = (List<object>)(object)_releaseAllBuffer;
		Dictionary<int, GameObject>.ValueCollection values = _aliveObjects.Values;
		((List<object>)(object)_releaseAllBuffer).InsertRange(releaseAllBuffer2._size, (IEnumerable<object>)values);
		Release(_releaseAllBuffer);
	}

	public void Destroy(GameObject obj)
	{
		int instanceID = obj.GetInstanceID();
		bool flag = ((Dictionary<int, object>)(object)_aliveObjects).Remove(instanceID);
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public unsafe void Destroy(IEnumerable<GameObject> objs)
	{
		//IL_0017: Expected O, but got Ref
		//IL_00e3: Expected O, but got I4
		//IL_0088: Expected O, but got I
		//IL_0091: Expected O, but got I4
		//IL_010b: Expected O, but got I
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ObjectPool objectPool = null;
		GameObject obj14 = default(GameObject);
		object obj3 = default(object);
		object obj13 = default(object);
		for (; obj2 != null; Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ rdx_v9] (should have been resolved before IL gen)"), Destroy(obj14))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj12;
			object obj5;
			if (obj3 != null)
			{
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+12E]");
				if ((nint)0 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r8_v7+v243 @ rax_v21*8]");
						if (0 == (nint)typeof(IEnumerator<GameObject>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v3+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_00c8;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r8_v7+8+v299 @ rcx_v17*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					continue;
				}
				goto IL_00c8;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_00c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj12 = obj13;
			obj5 = 0;
		}
		throw new NullReferenceException();
	}

	public unsafe void Populate(int quantity, PopulateMethod method = PopulateMethod.Set)
	{
		//IL_0357: Expected O, but got Ref
		//IL_0357: Expected O, but got Ref
		//IL_0191: Expected I, but got O
		//IL_0228: Expected I4, but got O
		//IL_030e->IL0268: Incompatible stack heights: 1 vs 0
		//IL_014b->IL0268: Incompatible stack heights: 1 vs 0
		//IL_0373->IL0268: Incompatible stack heights: 2 vs 0
		//IL_03d3->IL0268: Incompatible stack heights: 3 vs 0
		//IL_01ae->IL0268: Incompatible stack heights: 3 vs 0
		//IL_0262->IL03d8: Incompatible stack heights: 3 vs 0
		//IL_0267->IL0267: Incompatible stack heights: 3 vs 0
		int num;
		PopulateMethod populateMethod = default(PopulateMethod);
		if (populateMethod == PopulateMethod.Set)
		{
			List<GameObject> pooledObjects = _pooledObjects;
			if (_pooledObjects == null)
			{
				goto IL_0268;
			}
			num = quantity - pooledObjects._size;
		}
		else
		{
			bool flag = populateMethod != PopulateMethod.Add;
			int num2 = 0;
			if (!flag)
			{
				num2 = quantity;
			}
			num = num2;
		}
		if (_maxSize > 0)
		{
			List<GameObject> pooledObjects2 = _pooledObjects;
			if (_pooledObjects == null)
			{
				goto IL_0268;
			}
			int num3 = _maxSize - pooledObjects2._size;
			if (num >= num3)
			{
				num = num3;
			}
		}
		bool flag2 = num < 0;
		int num4 = 0;
		if (!flag2)
		{
			num4 = num;
		}
		bool flag3 = num4 <= 0;
		int num5 = 0;
		if (flag3)
		{
			return;
		}
		object obj = default(object);
		object obj2 = default(object);
		while ((object)_template != null)
		{
			Transform transform = _template.transform;
			if ((object)transform == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v20 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v20 (UnityEngine.Transform)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			if ((object)_template == null)
			{
				break;
			}
			Transform transform2 = _template.transform;
			if ((object)transform2 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v26 (UnityEngine.Transform)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v26 (UnityEngine.Transform)+10]");
			Transform.get_rotation_Injected((IntPtr)0, out Quaternion ret2);
			GameObject gameObject = CreateNewObject((Vector3)(&obj), (Quaternion)(&obj2));
			if ((object)gameObject == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v32 (UnityEngine.GameObject)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v32 (UnityEngine.GameObject)+10]");
			GameObject.SetActive_Injected((IntPtr)0, false);
			List<object> pooledObjects3 = (List<object>)(object)_pooledObjects;
			if (_pooledObjects == null)
			{
				break;
			}
			int version = pooledObjects3._version + 1;
			pooledObjects3._version = version;
			nint num6 = (nint)pooledObjects3._items;
			if (pooledObjects3._items == null)
			{
				break;
			}
			int size = pooledObjects3._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v7 (Il2CppMethodInfo)+18]");
			if ((nint)size >= (nint)0)
			{
				((List<object>)(object)_pooledObjects).AddWithResize((object)gameObject);
				populateMethod = PopulateMethod.Set;
			}
			else
			{
				int size2 = pooledObjects3._size + 1;
				pooledObjects3._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				populateMethod = (PopulateMethod)gameObject;
			}
			num5++;
			bool flag7 = num5 < num4;
			obj = ret;
			obj2 = ret2;
			if (!flag7)
			{
				return;
			}
		}
		goto IL_0268;
		IL_0268:
		throw new NullReferenceException();
	}

	public void Purge()
	{
		//IL_0235: Expected O, but got I4
		//IL_00d6: Expected O, but got I
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		bool flag = _pooledObjects == null;
		Dictionary<int, GameObject> dictionary = (Dictionary<int, GameObject>)(object)this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			dictionary = _aliveObjects;
			if (_aliveObjects != null)
			{
				Dictionary<int, GameObject>.ValueCollection values = _aliveObjects.Values;
				if (values != null)
				{
					object obj = default(object);
					object obj2 = default(object);
					object obj4 = default(object);
					UnityEngine.Object obj10 = default(UnityEngine.Object);
					while (true)
					{
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ stack_-50_v10+2C]");
							if (obj2 == null)
							{
								object obj3 = obj4;
								while (true)
								{
									object obj5 = obj3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ stack_-50_v10+20]");
									if ((nint)obj5 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ stack_-50_v10+18]");
										object obj6 = 0;
										obj4 = obj3 + 1;
										object obj7 = obj3 * 2;
										object obj8 = obj3 + obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v18+20+v787 @ r8_v15*8]");
										bool flag2 = (nint)0 < (nint)0;
										obj3 = obj4;
										if (flag2)
										{
											continue;
										}
										goto IL_013b;
									}
									break;
								}
								break;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							object obj9 = 0;
						}
						throw new NullReferenceException();
						IL_013b:
						UnityEngine.Object.Destroy(obj10, 0f);
					}
					dictionary = (Dictionary<int, GameObject>)(object)_pooledObjects;
					if (_pooledObjects != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+10]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+18]");
							Array.Clear((Array)num, 0, 0);
						}
						if (_aliveObjects != null)
						{
							_aliveObjects.Clear();
							if (_componentCache != null)
							{
								((Dictionary<int, GameObject>)(object)_componentCache).Clear();
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public IEnumerable<GameObject> GetAllActiveObjects()
	{
		if (_aliveObjects != null)
		{
			Dictionary<int, GameObject>.ValueCollection values = _aliveObjects.Values;
			Func<GameObject, bool> predicate = _003C_003Ec._003C_003E9__60_0;
			if (_003C_003Ec._003C_003E9__60_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__60_0 = delegate(GameObject x)
				{
					if ((object)x != null)
					{
						bool flag = ((UnityEngine.Object)x).m_CachedPtr == (IntPtr)0;
						return !flag;
					}
					return false;
				});
			}
			return Enumerable.Where(values, predicate);
		}
		return (IEnumerable<GameObject>)new NullReferenceException();
	}

	public Dictionary<int, GameObject> AliveObjects()
	{
		return _aliveObjects;
	}

	public Dictionary<int, GameObject>.Enumerator GetAllActiveObjectsEnumerator()
	{
		//IL_001a: Expected O, but got I
		//IL_0030: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
			ObjectPool objectPool = (ObjectPool)0;
			((UnityEngine.Object)this).m_CachedPtr = (IntPtr)0;
			_template = (GameObject)2;
			return (Dictionary<int, GameObject>.Enumerator)this;
		}
		return (Dictionary<int, GameObject>.Enumerator)new NullReferenceException();
	}

	public int GetAliveObjectsCount()
	{
		//IL_0035: Expected I4, but got O
		Dictionary<int, GameObject> aliveObjects = _aliveObjects;
		if (_aliveObjects != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
			return (int)(num - 0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void Awake()
	{
		_003CInitialized_003Ek__BackingField = false;
	}

	private void OnSceneUnload(Scene scene)
	{
		List<GameObject> pooledObjects = _pooledObjects;
		int version = pooledObjects._version + 1;
		pooledObjects._version = version;
		pooledObjects._size = 0;
		if (pooledObjects._size > 0)
		{
			Array.Clear(pooledObjects._items, 0, pooledObjects._size);
		}
		_aliveObjects.Clear();
		((Dictionary<int, GameObject>)(object)_componentCache).Clear();
		if (_repopulateOnSceneChange)
		{
			Populate(_defaultSize);
		}
	}

	static ObjectPool()
	{
		//IL_0035: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_000e: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("ObjectPool.GetObject", 1, MarkerFlags.Default, 0);
		_markerGetObject = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("ObjectPool.Release", 1, MarkerFlags.Default, 0);
		MarkerRelease = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("ObjectPool.ReleaseAll", 1, MarkerFlags.Default, 0);
		MarkerReleaseAll = (ProfilerMarker)(nint)intPtr3;
	}
}
