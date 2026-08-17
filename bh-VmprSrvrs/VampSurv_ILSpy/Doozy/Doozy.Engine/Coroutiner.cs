using System;
using System.Collections;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine;

public class Coroutiner : MonoBehaviour
{
	private static Coroutiner s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	public static Coroutiner Instance
	{
		get
		{
			//IL_0102: Expected I, but got O
			Coroutiner coroutiner = s_instance;
			if ((object)s_instance != null && ((UnityEngine.Object)coroutiner).m_CachedPtr != (IntPtr)0)
			{
				return s_instance;
			}
			if (!_003CApplicationIsQuitting_003Ek__BackingField)
			{
				Coroutiner coroutiner2 = UnityEngine.Object.FindObjectOfType<Coroutiner>();
				s_instance = coroutiner2;
				Coroutiner coroutiner3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)coroutiner3).m_CachedPtr == (IntPtr)0)
				{
					Type[] array = new Type[1];
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Coroutiner));
					if (array != null)
					{
						if ((object)typeFromHandle != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						GameObject gameObject = new GameObject("Coroutiner", array);
						if ((object)gameObject != null)
						{
							Coroutiner component = gameObject.GetComponent<Coroutiner>();
							s_instance = component;
							goto IL_0183;
						}
					}
					return (Coroutiner)(object)new NullReferenceException();
				}
				goto IL_0183;
			}
			return null;
			IL_0183:
			return s_instance;
		}
	}

	public static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		private set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
	}

	private void Awake()
	{
		//IL_016c: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		Coroutiner coroutiner = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)coroutiner).m_CachedPtr != (IntPtr)0)
		{
			Coroutiner coroutiner2 = s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)coroutiner2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					GameObject obj4 = base.gameObject;
					UnityEngine.Object.Destroy(obj4, 0f);
					return;
				}
			}
		}
		s_instance = this;
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public Coroutine StartLocalCoroutine(IEnumerator enumerator)
	{
		return StartCoroutine(enumerator);
	}

	public void StopLocalCoroutine(Coroutine coroutine)
	{
		StopCoroutine(coroutine);
	}

	public void StopLocalCoroutine(IEnumerator enumerator)
	{
		StopCoroutine(enumerator);
	}

	public void StopAllLocalCoroutines()
	{
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v50 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public static Coroutine Start(IEnumerator enumerator)
	{
		Coroutiner instance = Instance;
		if ((object)instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0 && enumerator != null)
		{
			Coroutiner instance2 = Instance;
			if ((object)instance2 != null)
			{
				return instance2.StartCoroutine(enumerator);
			}
			return (Coroutine)(object)new NullReferenceException();
		}
		return null;
	}

	public static void Stop(IEnumerator enumerator)
	{
		Coroutiner instance = Instance;
		if ((object)instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0 && enumerator != null)
		{
			Coroutiner instance2 = Instance;
			instance2.StopCoroutine(enumerator);
		}
	}

	public static void Stop(Coroutine coroutine)
	{
		Coroutiner instance = Instance;
		if ((object)instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0 && coroutine != null)
		{
			Coroutiner instance2 = Instance;
			instance2.StopCoroutine(coroutine);
		}
	}

	public static void StopAll()
	{
		//IL_00b0->IL007e: Incompatible stack heights: 1 vs 0
		Coroutiner instance = Instance;
		if ((object)instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			Coroutiner instance2 = Instance;
			bool flag = ((UnityEngine.Object)instance2).m_CachedPtr == (IntPtr)0;
			MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)instance2).m_CachedPtr);
		}
	}

	public Coroutiner()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
