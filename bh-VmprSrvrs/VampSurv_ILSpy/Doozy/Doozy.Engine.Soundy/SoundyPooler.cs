using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.Bindings;

namespace Doozy.Engine.Soundy;

public class SoundyPooler : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SoundyController, bool> _003C_003E9__28_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRemoveNullControllersFromThePool_003Eb__28_0(SoundyController p)
		{
			if ((object)p != null)
			{
				bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	private sealed class _003CKillIdleControllersEnumerator_003Ed__29(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SoundyPooler _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00b8: Expected I4, but got I8
			//IL_016e: Invalid comparison between F4 and I4
			//IL_0180: Expected F4, but got I4
			//IL_0223: Expected O, but got I4
			//IL_0557: Expected O, but got I4
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Expected O, but got Unknown
			//IL_0289->IL041d: Incompatible stack heights: 1 vs 0
			//IL_02a8->IL041d: Incompatible stack heights: 1 vs 0
			//IL_02f2->IL041d: Incompatible stack heights: 1 vs 0
			//IL_0522->IL041d: Incompatible stack heights: 2 vs 0
			//IL_03f6->IL0578: Incompatible stack heights: 3 vs 0
			//IL_0328->IL041d: Incompatible stack heights: 3 vs 0
			//IL_0400->IL04a1: Incompatible stack heights: 3 vs 0
			//IL_037d->IL041d: Incompatible stack heights: 3 vs 0
			//IL_03b5->IL041d: Incompatible stack heights: 3 vs 0
			SoundyPooler soundyPooler = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				goto IL_04a1;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_040f;
			}
			_003C_003E1__state = -1;
			RemoveNullControllersFromThePool();
			SoundySettings instance = SoundySettings.Instance;
			if ((object)instance != null)
			{
				int num;
				if (instance.MinimumNumberOfControllers > 0)
				{
					SoundySettings instance2 = SoundySettings.Instance;
					if ((object)instance2 == null)
					{
						goto IL_041d;
					}
					num = instance2.MinimumNumberOfControllers;
				}
				else
				{
					num = 0;
				}
				SoundySettings instance3 = SoundySettings.Instance;
				if ((object)instance3 != null)
				{
					float controllerIdleKillDuration = instance3.ControllerIdleKillDuration;
					bool flag = !(instance3.ControllerIdleKillDuration > 0f);
					float num2 = 0f;
					if (!flag)
					{
						SoundySettings instance4 = SoundySettings.Instance;
						if ((object)instance4 == null)
						{
							goto IL_041d;
						}
						num2 = instance4.ControllerIdleKillDuration;
					}
					List<SoundyController> pool = Pool;
					if (pool != null)
					{
						if (pool._size <= num)
						{
							goto IL_04a1;
						}
						List<SoundyController> pool2 = Pool;
						if (pool2 != null)
						{
							object obj = pool2._size - 1;
							if ((nint)obj < num)
							{
								goto IL_04a1;
							}
							while (true)
							{
								List<SoundyController> pool3 = Pool;
								if (pool3 == null)
								{
									break;
								}
								bool flag2 = (nint)obj >= pool3._size;
								SoundyController[] items = pool3._items;
								if (pool3._items == null || (object)_003C_003E4__this == null)
								{
									break;
								}
								soundyPooler.m_tempController = items[obj];
								object tempController = soundyPooler.m_tempController;
								if ((object)soundyPooler.m_tempController == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v13 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v13 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								if ((object)gameObject == null)
								{
									break;
								}
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj2 == null)
								{
									if ((object)soundyPooler.m_tempController == null)
									{
										break;
									}
									controllerIdleKillDuration = soundyPooler.m_tempController.IdleDuration;
									if (!(num2 > controllerIdleKillDuration))
									{
										List<SoundyController> pool4 = Pool;
										if (pool4 == null)
										{
											break;
										}
										bool flag5 = ((List<object>)(object)pool4).Remove((object)soundyPooler.m_tempController);
										if ((object)soundyPooler.m_tempController == null)
										{
											break;
										}
										soundyPooler.m_tempController.Kill();
									}
								}
								obj--;
								if ((nint)obj >= num)
								{
									continue;
								}
								goto IL_04a1;
							}
						}
					}
				}
			}
			goto IL_041d;
			IL_041d:
			throw new NullReferenceException();
			IL_040f:
			return false;
			IL_04a1:
			SoundySettings instance5 = SoundySettings.Instance;
			if ((object)instance5 != null && (object)_003C_003E4__this != null)
			{
				if (instance5.AutoKillIdleControllers)
				{
					_003C_003E2__current = soundyPooler.m_idleCheckIntervalWaitForSecondsRealtime;
					_003C_003E1__state = 1;
					return true;
				}
				soundyPooler.m_idleCheckCoroutine = null;
				goto IL_040f;
			}
			goto IL_041d;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private static List<SoundyController> s_pool;

	private Coroutine m_idleCheckCoroutine;

	private WaitForSecondsRealtime m_idleCheckIntervalWaitForSecondsRealtime;

	private SoundyController m_tempController;

	public static SoundyPooler Instance => SoundyManager.Pooler;

	private static List<SoundyController> Pool
	{
		get
		{
			List<SoundyController> result = s_pool;
			if (s_pool == null)
			{
				result = (s_pool = new List<SoundyController>());
			}
			return result;
		}
		set
		{
			s_pool = value;
		}
	}

	public static bool AutoKillIdleControllers
	{
		get
		{
			//IL_003e: Expected I4, but got O
			SoundySettings instance = SoundySettings.Instance;
			if ((object)instance != null)
			{
				return instance.AutoKillIdleControllers;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static float ControllerIdleKillDuration
	{
		get
		{
			SoundySettings instance = SoundySettings.Instance;
			return instance.ControllerIdleKillDuration;
		}
	}

	public static float IdleCheckInterval
	{
		get
		{
			SoundySettings instance = SoundySettings.Instance;
			return instance.IdleCheckInterval;
		}
	}

	public static int MinimumNumberOfControllers
	{
		get
		{
			//IL_003e: Expected I4, but got O
			SoundySettings instance = SoundySettings.Instance;
			if ((object)instance != null)
			{
				return instance.MinimumNumberOfControllers;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugSoundyPooler;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Reset()
	{
		SoundySettings instance = SoundySettings.Instance;
	}

	private void OnEnable()
	{
		SoundySettings instance = SoundySettings.Instance;
		if (instance.AutoKillIdleControllers)
		{
			StartIdleCheckInterval();
		}
	}

	private void OnDisable()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980AA0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyPooler pooler = SoundyManager.Pooler;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyPooler)
		{
			SoundyPooler pooler2 = SoundyManager.Pooler;
			DDebug.Log("Stop Idle Check", pooler2);
		}
		if (m_idleCheckCoroutine != null)
		{
			StopCoroutine(m_idleCheckCoroutine);
			m_idleCheckCoroutine = null;
		}
	}

	public unsafe static void ClearPool(bool keepMinimumNumberOfControllers = false)
	{
		//IL_017f: Expected O, but got I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_02dc: Expected O, but got Ref
		//IL_0324: Expected O, but got Ref
		string text;
		int num = default(int);
		string text2;
		string message;
		if (!keepMinimumNumberOfControllers)
		{
			SoundyController.KillAll();
			List<SoundyController> pool = Pool;
			int version = pool._version + 1;
			pool._version = version;
			pool._size = 0;
			if (pool._size > 0)
			{
				Array.Clear(pool._items, 0, pool._size);
			}
			SoundyPooler pooler = SoundyManager.Pooler;
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugSoundyPooler)
			{
				return;
			}
			List<SoundyController> pool2 = Pool;
			text = num.ToString();
			text2 = "Clear Pool - Killed All Controllers - ";
		}
		else
		{
			RemoveNullControllersFromThePool();
			List<SoundyController> pool3 = Pool;
			SoundySettings instance2 = SoundySettings.Instance;
			if (pool3._size > instance2.MinimumNumberOfControllers)
			{
				List<SoundyController> pool4 = Pool;
				object obj = pool4._size - 1;
				SoundySettings instance3 = SoundySettings.Instance;
				int num2 = 0;
				while ((nint)obj >= instance3.MinimumNumberOfControllers)
				{
					List<SoundyController> pool5 = Pool;
					if ((nint)obj < pool5._size)
					{
						SoundyController[] items = pool5._items;
						List<SoundyController> pool6 = Pool;
						bool flag = ((List<object>)(object)pool6).Remove((object)items[obj]);
						items[obj].Kill();
						num2++;
						obj--;
						instance3 = SoundySettings.Instance;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				SoundyPooler pooler2 = SoundyManager.Pooler;
				DoozySettings instance4 = DoozySettings.Instance;
				if (!instance4.DebugSoundyPooler)
				{
					return;
				}
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj2 = default(object);
				string text3 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj2), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<SoundyController> pool7 = Pool;
				string text4 = System.Number.FormatInt32(pool7._size, (ReadOnlySpan<char>)(&obj2), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				message = string.Concat(array);
				goto IL_00f8;
			}
			SoundyPooler pooler3 = SoundyManager.Pooler;
			DoozySettings instance5 = DoozySettings.Instance;
			if (!instance5.DebugSoundyPooler)
			{
				return;
			}
			List<SoundyController> pool8 = Pool;
			text = num.ToString();
			text2 = "Clear Pool - ";
		}
		message = text2 + text + " Controllers Available";
		goto IL_00f8;
		IL_00f8:
		SoundyPooler pooler4 = SoundyManager.Pooler;
		DDebug.Log(message, pooler4);
	}

	public static SoundyController GetControllerFromPool()
	{
		RemoveNullControllersFromThePool();
		List<SoundyController> pool = Pool;
		if (pool._size <= 0)
		{
			SoundyController controller = SoundyController.GetController();
			PutControllerInPool(controller);
		}
		List<SoundyController> pool2 = Pool;
		if (pool2._size > 0)
		{
			SoundyController[] items = pool2._items;
			List<SoundyController> pool3 = Pool;
			bool flag = ((List<object>)(object)pool3).Remove((object)items[0]);
			GameObject gameObject = items[0].gameObject;
			gameObject.SetActive(value: true);
			return items[0];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		SoundyController result = default(SoundyController);
		return result;
	}

	public unsafe static void PopulatePool(int numberOfControllers)
	{
		//IL_0194: Expected I, but got O
		//IL_00d1: Expected O, but got Ref
		//IL_0119: Expected O, but got Ref
		RemoveNullControllersFromThePool();
		if (numberOfControllers >= 1)
		{
			int num = numberOfControllers;
			do
			{
				nint num2 = (nint)typeof(SoundyController);
				SoundyController controller = SoundyController.GetController();
				PutControllerInPool(controller);
				num--;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v5 (Il2CppClass<Doozy.Engine.Soundy.SoundyController>)+E4]");
			}
			while ((nint)0 != 0);
			SoundyPooler pooler = SoundyManager.Pooler;
			DoozySettings instance = DoozySettings.Instance;
			if ((instance.DebugSoundyPooler ? 1 : 0) != num)
			{
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text = System.Number.FormatInt32(numberOfControllers, (ReadOnlySpan<char>)(&obj), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<SoundyController> pool = Pool;
				string text2 = System.Number.FormatInt32(pool._size, (ReadOnlySpan<char>)(&obj), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				SoundyPooler pooler2 = SoundyManager.Pooler;
				DDebug.Log(message, pooler2);
			}
		}
	}

	public static void PutControllerInPool(SoundyController controller)
	{
		if ((object)controller == null || ((UnityEngine.Object)controller).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<SoundyController> pool = Pool;
		if (pool._size != 0)
		{
			int num = Array.IndexOf((object[])pool._items, (object)controller, 0, pool._size);
			if (num != -1)
			{
				goto IL_00c7;
			}
		}
		List<SoundyController> pool2 = Pool;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C390");
		goto IL_00c7;
		IL_00c7:
		GameObject gameObject = controller.gameObject;
		gameObject.SetActive(value: false);
		Transform transform = controller.transform;
		SoundyPooler pooler = SoundyManager.Pooler;
		Transform parent = pooler.transform;
		transform.SetParent(parent, worldPositionStays: true);
		SoundyPooler pooler2 = SoundyManager.Pooler;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyPooler)
		{
			string[] array = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text = ((UnityEngine.Object)controller).GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			List<SoundyController> pool3 = Pool;
			int num2 = default(int);
			string text2 = num2.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array);
			SoundyPooler pooler3 = SoundyManager.Pooler;
			DDebug.Log(message, pooler3);
		}
	}

	private void StartIdleCheckInterval()
	{
		//IL_006d: Invalid comparison between I4 and F4
		//IL_007c: Expected F4, but got I4
		SoundyPooler pooler = SoundyManager.Pooler;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyPooler)
		{
			SoundyPooler pooler2 = SoundyManager.Pooler;
			DDebug.Log("Start Idle Check", pooler2);
		}
		SoundySettings instance2 = SoundySettings.Instance;
		bool flag = 0f > instance2.IdleCheckInterval;
		float num = 0f;
		if (!flag)
		{
			SoundySettings instance3 = SoundySettings.Instance;
			num = instance3.IdleCheckInterval;
		}
		WaitForSecondsRealtime waitForSecondsRealtime = null;
		waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = num;
		waitForSecondsRealtime.m_WaitUntilTime = -1f;
		m_idleCheckIntervalWaitForSecondsRealtime = waitForSecondsRealtime;
		_003CKillIdleControllersEnumerator_003Ed__29 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine idleCheckCoroutine = StartCoroutine(obj);
		m_idleCheckCoroutine = idleCheckCoroutine;
	}

	private void StopIdleCheckInterval()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980AA0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyPooler pooler = SoundyManager.Pooler;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyPooler)
		{
			SoundyPooler pooler2 = SoundyManager.Pooler;
			DDebug.Log("Stop Idle Check", pooler2);
		}
		if (m_idleCheckCoroutine != null)
		{
			StopCoroutine(m_idleCheckCoroutine);
			m_idleCheckCoroutine = null;
		}
	}

	private static void RemoveNullControllersFromThePool()
	{
		List<SoundyController> pool = Pool;
		Func<SoundyController, bool> predicate = _003C_003Ec._003C_003E9__28_0;
		if (_003C_003Ec._003C_003E9__28_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__28_0 = delegate(SoundyController p)
			{
				if ((object)p != null)
				{
					bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<SoundyController> enumerable = Enumerable.Where(pool, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			s_pool = (List<SoundyController>)(object)list;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private IEnumerator KillIdleControllersEnumerator()
	{
		_003CKillIdleControllersEnumerator_003Ed__29 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public SoundyPooler()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
