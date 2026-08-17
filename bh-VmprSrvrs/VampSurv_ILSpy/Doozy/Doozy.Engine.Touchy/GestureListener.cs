using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Touchy;

public class GestureListener : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<TouchInfo> _003C_003E9__13_0;

		public static Action<TouchInfo> _003C_003E9__14_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CReset_003Eb__13_0(TouchInfo _003Cp0_003E)
		{
		}

		internal void _003CAwake_003Eb__14_0(TouchInfo _003Cp0_003E)
		{
		}
	}

	private sealed class _003CSendGameEventsInTheNextFrame_003Ed__25(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GestureListener _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_00e0: Expected I4, but got O
			//IL_00cd: Expected O, but got I
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				GameObject gameObject = _003C_003E4__this.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rcx_v1 (UnityEngine.Component)+48]");
				GameEventMessage.SendEvents((List<string>)0, gameObject);
			}
			return false;
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

	public bool DebugMode;

	public bool GlobalListener;

	public bool OverrideTarget;

	public GameObject TargetGameObject;

	public GestureType GestureType;

	public Swipe SwipeDirection;

	public TouchInfoEvent OnGestureEvent;

	public Action<TouchInfo> OnGestureAction;

	public List<string> GameEvents;

	private static TouchySettings Settings => TouchySettings.Instance;

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugGestureListener;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Reset()
	{
		GlobalListener = false;
		GameObject targetGameObject = base.gameObject;
		TargetGameObject = targetGameObject;
		GestureType = GestureType.Tap;
		TouchInfoEvent onGestureEvent = (TouchInfoEvent)new UnityEventBase();
		_ = 0;
		OnGestureEvent = onGestureEvent;
		Action<TouchInfo> onGestureAction = _003C_003Ec._003C_003E9__13_0;
		if (_003C_003Ec._003C_003E9__13_0 == null)
		{
			Action<TouchInfo> action = null;
			((_003C_003Ec)(object)action)._003CReset_003Eb__13_0((TouchInfo)_003C_003Ec._003C_003E9);
			_003C_003Ec._003C_003E9__13_0 = action;
			onGestureAction = action;
		}
		OnGestureAction = onGestureAction;
		List<string> gameEvents = new List<string>();
		GameEvents = gameEvents;
	}

	private void Awake()
	{
		TouchDetector s_instance = TouchDetector.s_instance;
		if ((object)TouchDetector.s_instance == null || ((UnityEngine.Object)s_instance).m_CachedPtr == (IntPtr)0)
		{
			TouchDetector instance = TouchDetector.Instance;
			TouchDetector.s_instance = instance;
		}
		if (OverrideTarget)
		{
			GameObject targetGameObject = TargetGameObject;
			if ((object)TargetGameObject != null && ((UnityEngine.Object)targetGameObject).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
		}
		GameObject targetGameObject2 = base.gameObject;
		TargetGameObject = targetGameObject2;
		if (OnGestureAction == null)
		{
			Action<TouchInfo> onGestureAction = _003C_003Ec._003C_003E9__14_0;
			if (_003C_003Ec._003C_003E9__14_0 == null)
			{
				Action<TouchInfo> action = null;
				((_003C_003Ec)(object)action)._003CAwake_003Eb__14_0((TouchInfo)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__14_0 = action;
				onGestureAction = action;
			}
			OnGestureAction = onGestureAction;
		}
	}

	private void OnEnable()
	{
		RegisterToTouchDetector();
	}

	private void OnDisable()
	{
		UnregisterFromTouchDetector();
	}

	private void RegisterToTouchDetector()
	{
		TouchDetector instance = TouchDetector.Instance;
		Action<TouchInfo> action = null;
		((GestureListener)(object)action).HandleTap((TouchInfo)this);
		Delegate obj = Delegate.Combine(instance.OnTapAction, action);
		if ((object)obj == null)
		{
			instance.OnTapAction = (Action<TouchInfo>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<TouchInfo> action2 = default(Action<TouchInfo>);
			if (action2 == null)
			{
				throw new InvalidCastException();
			}
			instance.OnTapAction = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		TouchDetector instance2 = TouchDetector.Instance;
		Action<TouchInfo> action3 = null;
		((GestureListener)(object)action3).HandleLongTap((TouchInfo)this);
		Delegate obj3 = Delegate.Combine(instance2.OnLongTapAction, action3);
		if ((object)obj3 == null)
		{
			instance2.OnLongTapAction = (Action<TouchInfo>)obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<TouchInfo> action4 = default(Action<TouchInfo>);
			if (action4 == null)
			{
				throw new InvalidCastException();
			}
			instance2.OnLongTapAction = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				throw new InvalidCastException();
			}
		}
		TouchDetector instance3 = TouchDetector.Instance;
		Action<TouchInfo> action5 = null;
		((GestureListener)(object)action5).HandleSwipe((TouchInfo)this);
		Delegate obj5 = Delegate.Combine(instance3.OnSwipeAction, action5);
		if ((object)obj5 == null)
		{
			instance3.OnSwipeAction = (Action<TouchInfo>)obj5;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<TouchInfo> action6 = default(Action<TouchInfo>);
		if (action6 != null)
		{
			instance3.OnSwipeAction = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void UnregisterFromTouchDetector()
	{
		if (TouchDetector._003CApplicationIsQuitting_003Ek__BackingField)
		{
			return;
		}
		TouchDetector instance = TouchDetector.Instance;
		if ((object)instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		TouchDetector instance2 = TouchDetector.Instance;
		if (instance2.OnTapAction != null)
		{
			TouchDetector instance3 = TouchDetector.Instance;
			Action<TouchInfo> action = null;
			((GestureListener)(object)action).HandleTap((TouchInfo)this);
			Delegate obj = Delegate.Remove(instance3.OnTapAction, action);
			if ((object)obj == null)
			{
				instance3.OnTapAction = (Action<TouchInfo>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<TouchInfo> action2 = default(Action<TouchInfo>);
				if (action2 == null)
				{
					throw new InvalidCastException();
				}
				instance3.OnTapAction = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		TouchDetector instance4 = TouchDetector.Instance;
		if (instance4.OnLongTapAction != null)
		{
			TouchDetector instance5 = TouchDetector.Instance;
			Action<TouchInfo> action3 = null;
			((GestureListener)(object)action3).HandleLongTap((TouchInfo)this);
			Delegate obj3 = Delegate.Remove(instance5.OnLongTapAction, action3);
			if ((object)obj3 == null)
			{
				instance5.OnLongTapAction = (Action<TouchInfo>)obj3;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<TouchInfo> action4 = default(Action<TouchInfo>);
				if (action4 == null)
				{
					throw new InvalidCastException();
				}
				instance5.OnLongTapAction = action4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		TouchDetector instance6 = TouchDetector.Instance;
		if (instance6.OnSwipeAction == null)
		{
			return;
		}
		TouchDetector instance7 = TouchDetector.Instance;
		Action<TouchInfo> action5 = null;
		((GestureListener)(object)action5).HandleSwipe((TouchInfo)this);
		Delegate obj5 = Delegate.Remove(instance7.OnSwipeAction, action5);
		if ((object)obj5 == null)
		{
			instance7.OnSwipeAction = (Action<TouchInfo>)obj5;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<TouchInfo> action6 = default(Action<TouchInfo>);
		if (action6 != null)
		{
			instance7.OnSwipeAction = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private unsafe void HandleTap(TouchInfo touchInfo)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0094: Expected O, but got Ref
		//IL_0127: Expected O, but got Ref
		//IL_0206: Expected O, but got Ref
		//IL_028d: Expected O, but got Ref
		if (GestureType != GestureType.Tap)
		{
			return;
		}
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
		if (!HasValidTarget((TouchInfo)(&obj2)))
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGestureListener)
			{
				goto IL_01fe;
			}
		}
		GameObject gameObject = base.gameObject;
		string arg = ((UnityEngine.Object)gameObject).GetName();
		object obj3 = (object)(&obj2);
		obj3 = touchInfo.Touch;
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
		object arg2 = (TouchInfo)obj2;
		string message = $"OnTap on {arg}: {arg2}";
		DDebug.Log(message, this);
		goto IL_01fe;
		IL_01fe:
		object obj4 = (object)(&obj2);
		obj4 = touchInfo.Touch;
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
		TriggerListener((TouchInfo)(&obj2));
	}

	private unsafe void HandleLongTap(TouchInfo touchInfo)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0094: Expected O, but got Ref
		//IL_0127: Expected O, but got Ref
		//IL_0206: Expected O, but got Ref
		//IL_028d: Expected O, but got Ref
		if (GestureType != GestureType.LongTap)
		{
			return;
		}
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
		if (!HasValidTarget((TouchInfo)(&obj2)))
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGestureListener)
			{
				goto IL_01fe;
			}
		}
		GameObject gameObject = base.gameObject;
		string arg = ((UnityEngine.Object)gameObject).GetName();
		object obj3 = (object)(&obj2);
		obj3 = touchInfo.Touch;
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
		object arg2 = (TouchInfo)obj2;
		string message = $"OnLongTap on {arg}: {arg2}";
		DDebug.Log(message, this);
		goto IL_01fe;
		IL_01fe:
		object obj4 = (object)(&obj2);
		obj4 = touchInfo.Touch;
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
		TriggerListener((TouchInfo)(&obj2));
	}

	private unsafe void HandleSwipe(TouchInfo touchInfo)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0094: Expected O, but got Ref
		//IL_00b9: Expected O, but got Ref
		//IL_01cd: Expected O, but got Ref
		//IL_02ac: Expected O, but got Ref
		//IL_0333: Expected O, but got Ref
		if (GestureType != GestureType.Swipe)
		{
			return;
		}
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
		if (!HasValidTarget((TouchInfo)(&obj2)))
		{
			return;
		}
		object obj3 = (object)(&obj2);
		obj3 = touchInfo.Touch;
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
		object obj4 = default(object);
		if ((nint)obj4 != (nint)SwipeDirection)
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGestureListener)
			{
				goto IL_02a4;
			}
		}
		GameObject gameObject = base.gameObject;
		string arg = ((UnityEngine.Object)gameObject).GetName();
		object obj5 = (object)(&obj2);
		obj5 = touchInfo.Touch;
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
		object arg2 = (TouchInfo)obj2;
		string message = $"OnSwipe on {arg}: {arg2}";
		DDebug.Log(message, this);
		goto IL_02a4;
		IL_02a4:
		object obj6 = (object)(&obj2);
		obj6 = touchInfo.Touch;
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
		TriggerListener((TouchInfo)(&obj2));
	}

	private unsafe bool HasValidTarget(TouchInfo touchInfo)
	{
		//IL_0053: Expected O, but got Ref
		//IL_025b: Expected O, but got I4
		//IL_0275: Expected O, but got I4
		//IL_01e6: Expected I4, but got O
		if (GlobalListener)
		{
			return true;
		}
		GameObject targetGameObject = TargetGameObject;
		if ((object)TargetGameObject != null && ((UnityEngine.Object)targetGameObject).m_CachedPtr != (IntPtr)0)
		{
			object obj2 = default(object);
			object obj = (object)(&obj2);
			GameObject targetGameObject2 = TargetGameObject;
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
			bool flag = (object)TargetGameObject == null;
			object obj3 = default(object);
			bool flag2 = obj3 == null;
			object obj4 = flag2 & flag;
			bool flag3 = obj4 == null;
			object obj5 = !flag3;
			if (obj5 == null)
			{
				if ((object)TargetGameObject != null)
				{
					if (obj3 != null)
					{
						object obj6 = obj3 - (object)TargetGameObject;
						return obj6 == null;
					}
					return ((UnityEngine.Object)targetGameObject2).m_CachedPtr == (IntPtr)0;
				}
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ stack_-38+10]");
					return (nint)0 == 0;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
		return false;
	}

	private unsafe void TriggerListener(TouchInfo touchInfo)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0099: Expected O, but got Ref
		//IL_00ca: Expected O, but got Ref
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
		OnGestureEvent.Invoke((TouchInfo)(&obj2));
		if (OnGestureAction != null)
		{
			Action<TouchInfo> onGestureAction = OnGestureAction;
			object obj3 = (object)(&obj2);
			obj3 = touchInfo.Touch;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v71 @ r9_v4 (System.Action`1<Doozy.Engine.Touchy.TouchInfo>)+18] (should have been resolved before IL gen)");
		}
		if (GameEvents != null)
		{
			List<string> gameEvents = GameEvents;
			if (gameEvents._size != 0)
			{
				_003CSendGameEventsInTheNextFrame_003Ed__25 obj4 = null;
				obj4._003C_003E1__state = 0;
				obj4._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj4);
			}
		}
	}

	private void SendGameEvents()
	{
		if (GameEvents != null)
		{
			List<string> gameEvents = GameEvents;
			if (gameEvents._size != 0)
			{
				_003CSendGameEventsInTheNextFrame_003Ed__25 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
	}

	private IEnumerator SendGameEventsInTheNextFrame()
	{
		_003CSendGameEventsInTheNextFrame_003Ed__25 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private static GestureListener AddToScene(bool selectGameObjectAfterCreation = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182BFCD40\"");
		GestureListener result = default(GestureListener);
		return result;
	}

	private static GestureListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
	{
		GestureListener gestureListener = DoozyUtils.AddToScene<GestureListener>("Gesture Listener", isSingleton: false, selectGameObjectAfterCreation);
		if ((object)gestureListener != null)
		{
			Transform transform = gestureListener.transform;
			if ((object)transform != null)
			{
				Transform root = transform.root;
				if ((object)root != null)
				{
					RectTransform component = root.GetComponent<RectTransform>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return gestureListener;
					}
					GameObject gameObject = gestureListener.gameObject;
					if ((object)gameObject != null)
					{
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						RectTransform component2 = gestureListener.GetComponent<RectTransform>();
						bool flag = (object)component2 == null;
						bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
						return gestureListener;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public GestureListener()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
