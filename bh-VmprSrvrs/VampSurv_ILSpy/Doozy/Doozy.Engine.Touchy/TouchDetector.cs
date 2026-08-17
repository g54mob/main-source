using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.Touchy;

public class TouchDetector : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private static TouchDetector s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	private bool _003CTouchInProgress_003Ek__BackingField;

	public Action<TouchInfo> OnTapAction;

	public Action<TouchInfo> OnLongTapAction;

	public Action<TouchInfo> OnSwipeAction;

	private Vector2 m_currentSwipe;

	private bool m_swipeEnded;

	private TouchInfo m_currentTouchInfo;

	private List<Touch> m_touches;

	private Touch m_touch;

	private PointerEventData m_pointerEventData;

	private List<RaycastResult> m_raycastResults;

	public static TouchDetector Instance
	{
		get
		{
			TouchDetector touchDetector = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)touchDetector).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				TouchDetector touchDetector2 = UnityEngine.Object.FindObjectOfType<TouchDetector>();
				s_instance = touchDetector2;
				TouchDetector touchDetector3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)touchDetector3).m_CachedPtr == (IntPtr)0)
				{
					TouchDetector touchDetector4 = DoozyUtils.AddToScene<TouchDetector>("Touch Detector", isSingleton: true);
					if ((object)touchDetector4 == null)
					{
						return (TouchDetector)(object)new NullReferenceException();
					}
					GameObject target = touchDetector4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	private static TouchySettings Settings => TouchySettings.Instance;

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

	public static float SwipeLength
	{
		get
		{
			TouchySettings instance = TouchySettings.Instance;
			return instance.SwipeLength;
		}
	}

	public static float LongTapDuration
	{
		get
		{
			TouchySettings instance = TouchySettings.Instance;
			return instance.LongTapDuration;
		}
	}

	private static bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugTouchDetector;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool TouchInProgress
	{
		get
		{
			return _003CTouchInProgress_003Ek__BackingField;
		}
		private set
		{
			_003CTouchInProgress_003Ek__BackingField = value;
		}
	}

	public unsafe TouchInfo CurrentTouchInfo
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			//IL_0058: Expected O, but got I
			//IL_0053: Expected native int or pointer, but got O
			//IL_006d: Expected O, but got I
			//IL_0068: Expected native int or pointer, but got O
			//IL_0082: Expected F4, but got I
			//IL_007d: Expected native int or pointer, but got O
			//IL_0097: Expected O, but got I
			//IL_0092: Expected native int or pointer, but got O
			//IL_00ac: Expected O, but got I
			//IL_00a7: Expected native int or pointer, but got O
			//IL_00c1: Expected F4, but got I
			//IL_00bc: Expected native int or pointer, but got O
			TouchInfo touchInfo = default(TouchInfo);
			((TouchInfo*)(nint)touchInfo)->Touch = (Touch)m_currentTouchInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+A0]");
			((TouchInfo*)(nint)touchInfo)->StartPosition = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+B0]");
			((TouchInfo*)(nint)touchInfo)->Velocity = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+C0]");
			((TouchInfo*)(nint)touchInfo)->Duration = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+D0]");
			System.Runtime.CompilerServices.Unsafe.Write(&((TouchInfo*)(nint)touchInfo)->GameObject, (GameObject)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+E0]");
			((TouchInfo*)(nint)touchInfo)->CurrentTouchPosition = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.Touchy.TouchDetector)+F0]");
			((TouchInfo*)(nint)touchInfo)->TouchDeltaTime = 0f;
			return touchInfo;
		}
	}

	protected TouchDetector()
	{
		List<Touch> touches = new List<Touch>();
		m_touches = touches;
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		m_raycastResults = raycastResults;
		m_swipeEnded = false;
		_003CTouchInProgress_003Ek__BackingField = false;
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
	}

	private void Awake()
	{
		//IL_03d1: Expected O, but got I4
		//IL_03eb: Expected O, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_02c2: Expected O, but got I4
		//IL_0288: Expected I, but got O
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		//IL_0320: Expected I, but got O
		TouchDetector touchDetector = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)touchDetector).m_CachedPtr != (IntPtr)0)
		{
			TouchDetector touchDetector2 = s_instance;
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
					flag4 = ((UnityEngine.Object)touchDetector2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					object obj4 = this + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					object obj5 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v694 @ rdx_v24+1B8] (should have been resolved before IL gen)");
					string text = default(string);
					string message = "There cannot be two '" + text + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj7 = base.gameObject;
					UnityEngine.Object.Destroy(obj7, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
		Initialize();
		EventSystem current = EventSystem.current;
		if ((object)current != null && ((UnityEngine.Object)current).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		EventSystem eventSystem = UnityEngine.Object.FindObjectOfType<EventSystem>();
		if ((object)eventSystem != null && ((UnityEngine.Object)eventSystem).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Type[] array = new Type[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj11 = default(object);
		object obj10 = obj11;
		if (obj10 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj12 = default(object);
			if (obj12 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj15 = default(object);
		object obj14 = obj15 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj16 = default(object);
		bool flag5 = obj16 == null;
		obj13 = obj16;
		if (!flag5)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			bool flag6 = obj17 == null;
			obj13 = obj16;
			if (flag6)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		GameObject gameObject = new GameObject("EventSystem", array);
	}

	private void Update()
	{
		DetectTouch();
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980954]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + ": OnBeginDrag";
			DDebug.Log(message, this);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980955]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + ": OnDrag";
			DDebug.Log(message, this);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980956]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + ": OnEndDrag";
			DDebug.Log(message, this);
		}
	}

	public void SetDraggedObject(GameObject target)
	{
	}

	private void Initialize()
	{
		if (m_touches == null)
		{
			List<Touch> touches = new List<Touch>();
			m_touches = touches;
		}
		if (m_raycastResults == null)
		{
			List<RaycastResult> raycastResults = new List<RaycastResult>();
			m_raycastResults = raycastResults;
		}
		Action<TouchInfo> action = null;
		((TouchDetector)(object)action).HandleSwipe((TouchInfo)this);
		Delegate obj = Delegate.Combine(OnSwipeAction, action);
		if ((object)obj == null)
		{
			OnSwipeAction = (Action<TouchInfo>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<TouchInfo> action2 = default(Action<TouchInfo>);
			if (action2 == null)
			{
				throw new InvalidCastException();
			}
			OnSwipeAction = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		Action<TouchInfo> action3 = null;
		((TouchDetector)(object)action3).HandleLongTap((TouchInfo)this);
		Delegate obj3 = Delegate.Combine(OnLongTapAction, action3);
		if ((object)obj3 == null)
		{
			OnLongTapAction = (Action<TouchInfo>)obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<TouchInfo> action4 = default(Action<TouchInfo>);
			if (action4 == null)
			{
				throw new InvalidCastException();
			}
			OnLongTapAction = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				throw new InvalidCastException();
			}
		}
		Action<TouchInfo> action5 = null;
		((TouchDetector)(object)action5).HandleTap((TouchInfo)this);
		Delegate obj5 = Delegate.Combine(OnTapAction, action5);
		if ((object)obj5 == null)
		{
			OnTapAction = (Action<TouchInfo>)obj5;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<TouchInfo> action6 = default(Action<TouchInfo>);
			if (action6 == null)
			{
				throw new InvalidCastException();
			}
			OnTapAction = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				throw new InvalidCastException();
			}
		}
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			TouchDetector instance2 = Instance;
			DDebug.Log("Initialized", instance2);
		}
	}

	private unsafe void DetectTouch()
	{
		//IL_0093: Expected O, but got I
		//IL_00aa: Expected O, but got I
		//IL_010d: Expected O, but got Ref
		//IL_03fe: Expected O, but got I
		//IL_02a0: Invalid comparison between F4 and I
		//IL_01a5: Invalid comparison between I and F4
		//IL_0487: Expected O, but got I
		//IL_034e: Invalid comparison between F4 and I
		//IL_02da: Invalid comparison between F4 and I
		//IL_01df: Invalid comparison between F4 and I
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_0630: Expected O, but got Ref
		//IL_051e: Expected O, but got I
		//IL_0533: Expected O, but got I
		//IL_0579: Expected O, but got Ref
		List<Touch> touches = TouchHelper.GetTouches();
		m_touches = touches;
		List<Touch> touches2 = m_touches;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Touch>)+18]");
		if ((nint)0 != 0 && !m_swipeEnded)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Touch>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Touch>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12+20]");
				m_touch = (Touch)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12+40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12+50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v12+60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+124]");
				object obj2 = default(object);
				if ((nint)0 != 0)
				{
					UpdateCurrentTouchInfo((Touch)(&obj2));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+124]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+124]");
						if ((nint)0 != 2)
						{
							goto IL_0230;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C5]");
					if ((nint)0 == 0)
					{
						TouchySettings instance = TouchySettings.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C0]");
						if (0f > instance.LongTapDuration)
						{
							TouchySettings instance2 = TouchySettings.Instance;
							float swipeLength = instance2.SwipeLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+CC]");
							if (swipeLength > 0f)
							{
								_ = 1;
								_ = 0;
								if (OnLongTapAction != null)
								{
									Action<TouchInfo> onLongTapAction = OnLongTapAction;
									goto IL_0571;
								}
								return;
							}
						}
					}
					goto IL_0230;
				}
				EventSystem current = EventSystem.current;
				PointerEventData pointerEventData = new PointerEventData(current);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+104]");
				pointerEventData._003Cposition_003Ek__BackingField = (Vector2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+108]");
				_ = 0;
				m_pointerEventData = pointerEventData;
				List<RaycastResult> raycastResults = m_raycastResults;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v15 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v15 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v15 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v15 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
					Array.Clear((Array)num, 0, 0);
				}
				EventSystem current2 = EventSystem.current;
				current2.RaycastAll(m_pointerEventData, m_raycastResults);
				List<RaycastResult> raycastResults2 = m_raycastResults;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
				GameObject gameObject;
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_056a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v26+20]");
					gameObject = (GameObject)0;
				}
				else
				{
					gameObject = null;
				}
				TouchInfo touchInfo = (TouchInfo)(this + 80);
				((TouchInfo*)touchInfo)->Update((Touch)(&obj2), gameObject);
				m_pointerEventData = null;
				_003CTouchInProgress_003Ek__BackingField = true;
				return;
			}
			goto IL_056a;
		}
		_003CTouchInProgress_003Ek__BackingField = false;
		return;
		IL_0571:
		object obj5 = default(object);
		object obj4 = (object)(&obj5);
		obj4 = m_currentTouchInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v415 @ r9_v10 (System.Action`1<Doozy.Engine.Touchy.TouchInfo>)+18] (should have been resolved before IL gen)");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+124]");
		if ((nint)0 != 3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+124]");
			if ((nint)0 != 4)
			{
				return;
			}
		}
		TouchySettings instance3 = TouchySettings.Instance;
		float longTapDuration = instance3.LongTapDuration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C0]");
		if (longTapDuration > 0f)
		{
			TouchySettings instance4 = TouchySettings.Instance;
			float swipeLength2 = instance4.SwipeLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+CC]");
			if (swipeLength2 > 0f)
			{
				_ = 1;
				_ = 0;
				if (OnTapAction != null)
				{
					Action<TouchInfo> onLongTapAction = OnTapAction;
					goto IL_0571;
				}
				return;
			}
		}
		TouchySettings instance5 = TouchySettings.Instance;
		float swipeLength3 = instance5.SwipeLength;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C8]");
		if (!(swipeLength3 > 0f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Touchy.TouchDetector)+C5]");
			if ((nint)0 == 0)
			{
				if (OnSwipeAction != null)
				{
					Action<TouchInfo> onLongTapAction = OnSwipeAction;
					goto IL_0571;
				}
				return;
			}
		}
		_ = 0;
		return;
		IL_056a:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void UpdateCurrentTouchInfo(Touch touch)
	{
		//IL_000f: Expected O, but got I4
		//IL_02b7: Expected O, but got F4
		//IL_02e1: Expected O, but got I
		//IL_0303: Expected O, but got I
		//IL_0320: Expected O, but got I
		//IL_00a6: Invalid comparison between F4 and I
		//IL_00c6: Expected O, but got I4
		//IL_01de: Invalid comparison between F4 and I
		//IL_0380: Expected O, but got I
		//IL_039d: Expected O, but got I
		//IL_03ba: Expected O, but got I
		//IL_0297: Expected O, but got I4
		//IL_00e1: Invalid comparison between F4 and I
		//IL_0203: Invalid comparison between F4 and I
		//IL_0289: Expected O, but got I4
		//IL_0106: Invalid comparison between F4 and I
		//IL_0228: Invalid comparison between F4 and I
		//IL_01c8: Expected O, but got I4
		//IL_027b: Expected O, but got I4
		//IL_012b: Invalid comparison between F4 and I
		//IL_024d: Invalid comparison between F4 and I
		//IL_01ba: Expected O, but got I4
		//IL_0175: Invalid comparison between F4 and I
		//IL_0187: Expected O, but got I4
		//IL_0150: Invalid comparison between F4 and I
		//IL_026d: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		m_currentTouchInfo = (TouchInfo)touch.m_FingerId;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+10]");
		_ = 0;
		_ = touch.m_TapCount;
		_ = touch.m_maximumPossiblePressure;
		_ = touch.m_AzimuthAngle;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+E4]");
		_ = 0;
		_ = touch.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		_ = 0;
		_ = touch.m_TimeDelta;
		_ = touch.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		_ = 0;
		object obj = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+B8]");
		object obj2 = num - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		Vector2 currentSwipe = (Vector2)(num2 - 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+AC]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A4]");
		object obj3 = num3 - 0;
		m_currentSwipe = currentSwipe;
		TouchySettings instance = TouchySettings.Instance;
		float swipeLength = instance.SwipeLength;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+CC]");
		object obj4;
		if (swipeLength > 0f)
		{
			obj4 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C245A0");
			if ((nint)m_currentSwipe <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
				if (22.5f > 0f)
				{
					goto IL_028e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
				if (!(67.5f > 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
					if (!(112.5f > 0f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
						if (!(157.5f > 0f))
						{
							goto IL_0164;
						}
						obj4 = 6;
					}
					else
					{
						obj4 = 4;
					}
				}
				else
				{
					obj4 = 1;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
				if (22.5f > 0f)
				{
					goto IL_028e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
				if (!(67.5f > 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
					if (!(112.5f > 0f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
						if (!(157.5f > 0f))
						{
							goto IL_0164;
						}
						obj4 = 8;
					}
					else
					{
						obj4 = 5;
					}
				}
				else
				{
					obj4 = 3;
				}
			}
		}
		goto IL_0347;
		IL_0347:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+AC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		object obj5 = num4 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+AC]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+A4]");
		object obj6 = num5 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+BC]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+B8]");
		object obj7 = num6 - 0;
		object obj8 = obj5 / obj7;
		object obj9 = obj6 / obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+C8]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+CC]");
		if (num7 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+C8]");
			_ = 0;
		}
		return;
		IL_0164:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v4 (Doozy.Engine.Touchy.TouchDetector)+44]");
		bool flag = !(180f > 0f);
		obj4 = 0;
		if (!flag)
		{
			obj4 = 7;
		}
		goto IL_0347;
		IL_028e:
		obj4 = 2;
		goto IL_0347;
	}

	private unsafe void HandleSwipe(TouchInfo touchInfo)
	{
		//IL_002f: Expected O, but got Ref
		//IL_00da: Expected O, but got Ref
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			object obj2 = default(object);
			object obj = (object)(&obj2);
			obj = touchInfo.Touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+40]");
			_ = 0;
			_ = touchInfo.StartPosition;
			_ = touchInfo.Velocity;
			_ = touchInfo.Duration;
			_ = touchInfo.GameObject;
			_ = touchInfo.CurrentTouchPosition;
			_ = touchInfo.TouchDeltaTime;
			object arg = (TouchInfo)obj2;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj3 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "HandleSwipe: {0}", (System.ParamsArray)(&obj3));
			DDebug.Log(message, this);
		}
	}

	private unsafe void HandleTap(TouchInfo touchInfo)
	{
		//IL_002f: Expected O, but got Ref
		//IL_00da: Expected O, but got Ref
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			object obj2 = default(object);
			object obj = (object)(&obj2);
			obj = touchInfo.Touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+40]");
			_ = 0;
			_ = touchInfo.StartPosition;
			_ = touchInfo.Velocity;
			_ = touchInfo.Duration;
			_ = touchInfo.GameObject;
			_ = touchInfo.CurrentTouchPosition;
			_ = touchInfo.TouchDeltaTime;
			object arg = (TouchInfo)obj2;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj3 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "HandleTap: {0}", (System.ParamsArray)(&obj3));
			DDebug.Log(message, this);
		}
	}

	private unsafe void HandleLongTap(TouchInfo touchInfo)
	{
		//IL_002f: Expected O, but got Ref
		//IL_00da: Expected O, but got Ref
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugTouchDetector)
		{
			object obj2 = default(object);
			object obj = (object)(&obj2);
			obj = touchInfo.Touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touchInfo @ rdx (Doozy.Engine.Touchy.TouchInfo)+40]");
			_ = 0;
			_ = touchInfo.StartPosition;
			_ = touchInfo.Velocity;
			_ = touchInfo.Duration;
			_ = touchInfo.GameObject;
			_ = touchInfo.CurrentTouchPosition;
			_ = touchInfo.TouchDeltaTime;
			object arg = (TouchInfo)obj2;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj3 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "HandleLongPress: {0}", (System.ParamsArray)(&obj3));
			DDebug.Log(message, this);
		}
	}

	public static void Init()
	{
		TouchDetector touchDetector = s_instance;
		if ((object)s_instance == null || ((UnityEngine.Object)touchDetector).m_CachedPtr == (IntPtr)0)
		{
			TouchDetector instance = Instance;
			s_instance = instance;
		}
	}

	public static Vector2 GetCardinalDirection(Swipe swipe)
	{
		return CardinalDirection.Get(swipe);
	}

	public static Swipe GetSwipe(SimpleSwipe simpleSwipe, bool reverse = false)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected I4, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		bool flag = simpleSwipe == SimpleSwipe.None;
		if (!flag)
		{
			object obj = simpleSwipe - 1;
			if (flag)
			{
				bool flag2 = !reverse;
				bool flag3 = !flag2;
				return (Swipe)((flag3 ? 1 : 0) + 4);
			}
			object obj2 = obj - 1;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb eax,eax\"");
				object obj3 = default(object);
				return (Swipe)(obj3 + 5);
			}
			object obj4 = obj2 - 1;
			if (flag)
			{
				bool flag4 = !reverse;
				Swipe result = Swipe.Up;
				if (!flag4)
				{
					result = Swipe.Down;
				}
				return result;
			}
			if ((nint)obj4 == 1)
			{
				bool flag5 = !reverse;
				Swipe result2 = Swipe.Down;
				if (!flag5)
				{
					result2 = Swipe.Up;
				}
				return result2;
			}
		}
		return Swipe.None;
	}

	public static SimpleSwipe GetSimpleSwipe(Swipe swipe, bool reverse = false)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (swipe <= Swipe.DownRight)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r8_v1+2C00B08+swipe @ rcx (Doozy.Engine.Touchy.Swipe)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return SimpleSwipe.None;
	}

	public static Swipe GetSwipeDirection(Vector2 direction)
	{
		//IL_00c3: Invalid comparison between F4 and O
		//IL_000e: Invalid comparison between F4 and O
		//IL_00e0: Invalid comparison between F4 and O
		//IL_002b: Invalid comparison between F4 and O
		//IL_00fd: Invalid comparison between F4 and O
		//IL_0048: Invalid comparison between F4 and O
		//IL_011a: Invalid comparison between F4 and O
		//IL_0082: Invalid comparison between F4 and O
		//IL_0065: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C245A0");
		object obj = default(object);
		object obj2 = default(object);
		if ((nint)obj <= 0)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)22.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)67.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)112.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)157.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							goto IL_0079;
						}
						return Swipe.DownLeft;
					}
					return Swipe.Left;
				}
				return Swipe.UpLeft;
			}
		}
		else if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)22.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)67.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)112.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)157.5f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						return Swipe.DownRight;
					}
					goto IL_0079;
				}
				return Swipe.Right;
			}
			return Swipe.UpRight;
		}
		Swipe result = Swipe.Up;
		goto IL_0182;
		IL_0079:
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)180f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		result = Swipe.None;
		if (!flag)
		{
			return Swipe.Down;
		}
		goto IL_0182;
		IL_0182:
		return result;
	}

	public static SimpleSwipe GetSimpleSwipeDirection(Vector2 direction)
	{
		//IL_00b7: Invalid comparison between F4 and O
		//IL_000e: Invalid comparison between F4 and O
		//IL_00d4: Invalid comparison between F4 and O
		//IL_002b: Invalid comparison between F4 and O
		//IL_00f1: Invalid comparison between F4 and O
		//IL_0048: Invalid comparison between F4 and O
		//IL_010e: Invalid comparison between F4 and O
		//IL_0082: Invalid comparison between F4 and O
		//IL_0065: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C245A0");
		object obj = default(object);
		object obj2 = default(object);
		if ((nint)obj <= 0)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)22.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)67.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)112.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)157.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							goto IL_0079;
						}
					}
				}
				return SimpleSwipe.Left;
			}
		}
		else if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)22.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)67.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)112.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)157.5f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						goto IL_0079;
					}
				}
			}
			return SimpleSwipe.Right;
		}
		SimpleSwipe result = SimpleSwipe.Up;
		goto IL_016a;
		IL_0079:
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)180f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		result = SimpleSwipe.None;
		if (!flag)
		{
			return SimpleSwipe.Down;
		}
		goto IL_016a;
		IL_016a:
		return result;
	}

	private static TouchDetector AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<TouchDetector>("Touch Detector", isSingleton: true, selectGameObjectAfterCreation);
	}
}
